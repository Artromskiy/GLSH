﻿using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GLSH;

internal partial class ShaderSyntaxWalker
{
    public static bool TryGetStructDefinition(SemanticModel model, StructDeclarationSyntax node, out StructureDefinition sd)
    {
        string structName = model.GetDeclaredSymbol(node).GetFullMetadataName();

        int structCSharpSize = 0;
        int structShaderSize = 0;
        int structCSharpAlignment = 0;
        int structShaderAlignment = 0;

        List<FieldDefinition> fields = [];
        foreach (MemberDeclarationSyntax member in node.Members)
        {
            if (member is not FieldDeclarationSyntax fds || fds.Modifiers.Any(x => x.IsKind(SyntaxKind.ConstKeyword)))
                continue;

            VariableDeclarationSyntax varDecl = fds.Declaration;
            foreach (VariableDeclaratorSyntax vds in varDecl.Variables)
            {
                string fieldName = vds.Identifier.Text.Trim();
                string typeName = model.GetFullTypeName(varDecl.Type, out bool isArray);
                int arrayElementCount = isArray ? GetArrayCountValue(vds, model) : 0;

                TypeInfo typeInfo = model.GetTypeInfo(varDecl.Type);

                AlignmentInfo fieldSizeAndAlignment;

                if (typeInfo.Type.Kind == SymbolKind.ArrayType)
                {
                    ITypeSymbol elementType = ((IArrayTypeSymbol)typeInfo.Type).ElementType;
                    AlignmentInfo elementSizeAndAlignment = TypeSizeCache.Get(elementType);

                    fieldSizeAndAlignment = new AlignmentInfo(
                        elementSizeAndAlignment.CSharpSize * arrayElementCount,
                        elementSizeAndAlignment.ShaderSize * arrayElementCount,
                        elementSizeAndAlignment.CSharpAlignment,
                        elementSizeAndAlignment.ShaderAlignment);
                }
                else
                {
                    fieldSizeAndAlignment = TypeSizeCache.Get(typeInfo.Type);
                }

                structCSharpSize += structCSharpSize % fieldSizeAndAlignment.CSharpAlignment;
                structCSharpSize += fieldSizeAndAlignment.CSharpSize;
                structCSharpAlignment = Math.Max(structCSharpAlignment, fieldSizeAndAlignment.CSharpAlignment);

                structShaderSize += structShaderSize % fieldSizeAndAlignment.ShaderAlignment;
                structShaderSize += fieldSizeAndAlignment.ShaderSize;
                structShaderAlignment = Math.Max(structShaderAlignment, fieldSizeAndAlignment.ShaderAlignment);

                TypeReference tr = new(typeName, model.GetTypeInfo(varDecl.Type).Type);
                SemanticType semanticType = GetSemanticType(vds, model);
                fields.Add(new(fieldName, tr, semanticType, arrayElementCount, fieldSizeAndAlignment));
            }
        }

        sd = new StructureDefinition(structName.Trim(), [.. fields],
            new AlignmentInfo(structCSharpSize, structShaderSize, structCSharpAlignment, structShaderAlignment));
        return true;
    }

    private static int GetArrayCountValue(VariableDeclaratorSyntax vds, SemanticModel semanticModel)
    {
        if (!AttributeHelper.TryGetAttribute<ArraySizeAttribute>(vds, semanticModel, out var arraySizeAttr))
            throw new ShaderGenerationException("Attempt to create from non existent attribute");
        return arraySizeAttr.CreateAttributeOfType<ArraySizeAttribute>(semanticModel.Compilation).ElementCount;
    }

    private static SemanticType GetSemanticType(VariableDeclaratorSyntax vds, SemanticModel model)
    {
        if (AttributeHelper.TryGetAttribute<VertexSemanticAttribute>(vds, model, out AttributeSyntax? attributeSyntax))
            return attributeSyntax.CreateAttributeOfType<VertexSemanticAttribute>(model).type;

        return SemanticType.None;
    }

    /// <summary>
    /// Checks that TypeInfo is not reference type except for predefined resources
    /// </summary>
    /// <param name="typeInfo"></param>
    /// <exception cref="ShaderGenerationException"></exception>
    [Obsolete("Need to rewrite typeInfo.Type.ToDisplayString")]
    private static void ValidateUniformType(TypeInfo typeInfo)
    {
        string name = typeInfo.Type.ToDisplayString();
        bool validRefType =
            name == typeof(Texture2DResource).FullName! ||
            name == typeof(Texture2DArrayResource).FullName! ||
            name == typeof(TextureCubeResource).FullName! ||
            name == typeof(Texture2DMSResource).FullName! ||
            name == typeof(SamplerResource).FullName! ||
            name == typeof(SamplerComparisonResource).FullName!;

        if (!validRefType && typeInfo.Type.IsReferenceType)
        {
            throw new ShaderGenerationException("Shader resource fields must be simple blittable structures.");
        }
    }

    private static ShaderResourceKind ClassifyResourceKind(string fullTypeName)
    {
        if (fullTypeName == typeof(Texture2DResource).FullName!)
            return ShaderResourceKind.Texture2D;
        if (fullTypeName == typeof(Texture2DArrayResource).FullName!)
            return ShaderResourceKind.Texture2DArray;
        else if (fullTypeName == typeof(TextureCubeResource).FullName!)
            return ShaderResourceKind.TextureCube;
        else if (fullTypeName == typeof(Texture2DMSResource).FullName!)
            return ShaderResourceKind.Texture2DMS;
        else if (fullTypeName == typeof(SamplerResource).FullName!)
            return ShaderResourceKind.Sampler;
        else if (fullTypeName == typeof(SamplerComparisonResource).FullName!)
            return ShaderResourceKind.SamplerComparison;
        else if (fullTypeName.Contains(typeof(RWStructuredBuffer<>).FullName!))
            return ShaderResourceKind.RWStructuredBuffer;
        else if (fullTypeName.Contains(typeof(StructuredBuffer<>).FullName!))
            return ShaderResourceKind.StructuredBuffer;
        else if (fullTypeName.Contains(typeof(RWTexture2DResource<>).FullName!))
            return ShaderResourceKind.RWTexture2D;
        else if (fullTypeName.Contains(typeof(DepthTexture2DResource).FullName!))
            return ShaderResourceKind.DepthTexture2D;
        else if (fullTypeName.Contains(typeof(DepthTexture2DArrayResource).FullName!))
            return ShaderResourceKind.DepthTexture2DArray;
        else if (fullTypeName.Contains(typeof(AtomicBufferInt32).FullName!))
            return ShaderResourceKind.AtomicBuffer;
        else if (fullTypeName.Contains(typeof(AtomicBufferUInt32).FullName!))
            return ShaderResourceKind.AtomicBuffer;
        else
            return ShaderResourceKind.Uniform;
    }
}