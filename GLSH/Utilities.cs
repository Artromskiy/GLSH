using GLSH.Attributes;
using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GLSH.Compiler;

internal static class Utilities
{
    public static string GetFullTypeName(this SemanticModel model, ExpressionSyntax type)
    {
        return model.GetFullTypeName(type, out _);
    }

    [Obsolete("Rewrite this hell")]
    public static string GetFullTypeName(this SemanticModel model, ExpressionSyntax type, out bool isArray)
    {
        ArgumentNullException.ThrowIfNull(model);
        ArgumentNullException.ThrowIfNull(type);

        if (type.SyntaxTree != model.SyntaxTree)
            model = model.Compilation.GetSemanticModel(type.SyntaxTree);

        TypeInfo typeInfo = model.GetTypeInfo(type);
        if (typeInfo.Type == null)
        {
            typeInfo = model.GetSpeculativeTypeInfo(0, type, SpeculativeBindingOption.BindAsTypeOrNamespace);
            if (typeInfo.Type == null || typeInfo.Type is IErrorTypeSymbol)
            {
                throw new InvalidOperationException("Unable to resolve type: " + type + " at " + type.GetLocation());
            }
        }

        return GetFullTypeName(typeInfo.Type, out isArray);
    }

    public static string GetFullTypeName(ITypeSymbol type, out bool isArray)
    {
        if (type is IArrayTypeSymbol ats)
        {
            isArray = true;
            return ats.ElementType.GetFullMetadataName();
        }
        else
        {
            isArray = false;
            return type.GetFullMetadataName();
        }
    }

    public static string GetFullTypeName(ITypeSymbol type)
    {
        if (type is IArrayTypeSymbol ats)
            return ats.ElementType.GetFullMetadataName();
        else
            return type.GetFullMetadataName();
    }

    public static string GetFullMetadataName(this ISymbol s)
    {
        if (s == null || IsRootNamespace(s))
            return string.Empty;

        if (s.Kind == SymbolKind.ArrayType)
            return ((IArrayTypeSymbol)s).ElementType.GetFullMetadataName() + "[]";

        StringBuilder sb = new(s.MetadataName);
        ISymbol last = s;

        s = s.ContainingSymbol;

        while (!IsRootNamespace(s))
        {
            var separator = s is ITypeSymbol && last is ITypeSymbol ? '+' : '.';
            sb.Insert(0, separator);
            sb.Insert(0, s.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat));
            s = s.ContainingSymbol;
        }
        return sb.ToString();
    }

    private static bool IsRootNamespace(ISymbol symbol) => symbol is INamespaceSymbol s && s.IsGlobalNamespace;

    public static string? GetFunctionContainingTypeName(
        SyntaxNode node,
        SemanticModel model)
    {
        return model.GetDeclaredSymbol(node)?.ContainingSymbol.GetFullMetadataName();
    }

    /// <summary>
    /// Gets the full namespace + name for the given SymbolInfo.
    /// </summary>
    public static string GetFullName(SymbolInfo symbolInfo)
    {
        Debug.Assert(symbolInfo.Symbol != null);
        return symbolInfo.Symbol.GetFullMetadataName();
    }

    [Obsolete("Rewrite this hell")]
    internal static ShaderFunctionAndMethodDeclarationSyntax GetShaderFunction(
        BaseMethodDeclarationSyntax node,
        Compilation compilation,
        bool generateOrderedFunctionList)
    {
        SemanticModel semanticModel = compilation.GetSemanticModel(node.SyntaxTree);
        string functionName;
        TypeReference returnTypeReference;
        UInt3 computeGroupCounts = new();
        bool isVertexShader;
        bool isFragmentShader;
        bool isComputeShader;

        if (node is MethodDeclarationSyntax mds)
        {
            functionName = mds.Identifier.ToFullString();
            returnTypeReference = new(semanticModel.GetFullTypeName(mds.ReturnType), semanticModel.GetTypeInfo(mds.ReturnType).Type);
        }
        else if (node is ConstructorDeclarationSyntax cds)
        {
            functionName = ".ctor";
            ITypeSymbol typeSymbol = semanticModel.GetDeclaredSymbol(cds).ContainingType;
            returnTypeReference = new(GetFullTypeName(typeSymbol), typeSymbol);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(node), "Unsupported BaseMethodDeclarationSyntax type.");
        }

        isVertexShader = AttributeHelper.TryGetAttribute<VertexEntryPointAttribute>(node, semanticModel, out _);
        isFragmentShader = AttributeHelper.TryGetAttribute<FragmentEntryPointAttribute>(node, semanticModel, out _);
        isComputeShader = AttributeHelper.TryGetAttribute<ComputeEntryPointAttribute>(node, semanticModel, out var computeEntryAttributeSyntax);
        if (isComputeShader)
        {
            Debug.Assert(computeEntryAttributeSyntax != null);
            var data = computeEntryAttributeSyntax.CreateAttributeOfType<ComputeEntryPointAttribute>(semanticModel);
            computeGroupCounts.X = data.localSizeX;
            computeGroupCounts.Y = data.localSizeY;
            computeGroupCounts.Z = data.localSizeZ;
        }

        ShaderFunctionType type;
        if (isVertexShader)
            type = ShaderFunctionType.VertexEntryPoint;
        else if (isFragmentShader)
            type = ShaderFunctionType.FragmentEntryPoint;
        else if (isComputeShader)
            type = ShaderFunctionType.ComputeEntryPoint;
        else
            type = ShaderFunctionType.Normal;

        string nestedTypePrefix = GetFunctionContainingTypeName(node, semanticModel);

        List<ParameterDefinition> parameters = [];
        foreach (ParameterSyntax ps in node.ParameterList.Parameters)
            parameters.Add(ParameterDefinition.GetParameterDefinition(compilation, ps));

        ShaderFunction sf = new(
            nestedTypePrefix,
            functionName,
            returnTypeReference,
            [.. parameters],
            type,
            computeGroupCounts);

        ShaderFunctionAndMethodDeclarationSyntax[] orderedFunctionList;
        if (type != ShaderFunctionType.Normal && generateOrderedFunctionList)
        {
            FunctionCallGraphDiscoverer fcgd = new(
                compilation,
                new TypeAndMethodName(sf.declaringType, sf.name));
            fcgd.GenerateFullGraph();
            orderedFunctionList = fcgd.GetOrderedCallList();
        }
        else
        {
            orderedFunctionList = [];
        }

        return new ShaderFunctionAndMethodDeclarationSyntax(sf, node, orderedFunctionList);
    }
}
