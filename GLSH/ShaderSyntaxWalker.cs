using GLSH.Primitives.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GLSH;

internal partial class ShaderSyntaxWalker : CSharpSyntaxWalker
{
    private readonly Compilation _compilation;
    private readonly LanguageBackend[] _backends;
    private readonly ShaderSetInfo _shaderSet;

    private readonly Dictionary<int, int> _setCounts = [];

    public ShaderSyntaxWalker(Compilation compilation, LanguageBackend[] backends, ShaderSetInfo ss)
        : base(SyntaxWalkerDepth.Token)
    {
        _compilation = compilation;
        _backends = backends;
        _shaderSet = ss;
    }

    private SemanticModel GetModel(SyntaxNode node) => _compilation.GetSemanticModel(node.SyntaxTree);

    [Obsolete("Rewrite this hell")]
    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        ShaderFunctionAndMethodDeclarationSyntax sfab = Utilities.GetShaderFunction(node, _compilation, true);
        foreach (LanguageBackend b in _backends)
        {
            b.AddFunction(_shaderSet.name, sfab);

            foreach (var calledFunction in sfab.orderedFunctionList)
                b.AddFunction(_shaderSet.name, calledFunction);
        }
    }

    public override void VisitStructDeclaration(StructDeclarationSyntax node)
    {
        TryGetStructDefinition(GetModel(node), node, out var sd);
        foreach (var b in _backends)
            b.AddStructure(_shaderSet.name, sd);
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        if (node.Modifiers.Any(x => x.IsKind(SyntaxKind.ConstKeyword)))
            return;

        base.VisitFieldDeclaration(node);
    }

    public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
    {
        if (node.Variables.Count != 1)
            throw new ShaderGenerationException("Cannot declare multiple variables together.");

        VariableDeclaratorSyntax vds = node.Variables[0];

        string resourceName = vds.Identifier.Text;
        TypeInfo typeInfo = GetModel(node).GetTypeInfo(node.Type);
        string fullTypeName = GetModel(node).GetFullTypeName(node.Type);
        TypeReference valueType = new(fullTypeName, typeInfo.Type);
        ShaderResourceKind kind = ClassifyResourceKind(fullTypeName);
        bool genericKind =
            kind == ShaderResourceKind.StructuredBuffer ||
            kind == ShaderResourceKind.RWStructuredBuffer ||
            kind == ShaderResourceKind.RWTexture2D;

        valueType = genericKind ? ParseGenericElementType(vds) : valueType;

        int set = 0; // Default value if not otherwise specified.
        if (AttributeHelper.TryGetAttribute<ResourceSetAttribute>(node, GetModel(node), out var syntax))
            set = syntax.CreateAttributeOfType<ResourceSetAttribute>(GetModel(node)).Set;

        int resourceBinding = GetAndIncrementBinding(set);

        ResourceDefinition rd = new(resourceName, set, resourceBinding, valueType, kind);
        if (kind == ShaderResourceKind.Uniform)
            ValidateUniformType(typeInfo);

        foreach (LanguageBackend b in _backends)
            b.AddResource(_shaderSet.name, rd);
    }

    private TypeReference ParseGenericElementType(VariableDeclaratorSyntax vds)
    {
        FieldDeclarationSyntax fieldDecl = (FieldDeclarationSyntax)vds.Parent.Parent;
        TypeSyntax fieldType = fieldDecl.Declaration.Type;

        while (fieldType is QualifiedNameSyntax qns)
            fieldType = qns.Right;

        GenericNameSyntax gns = (GenericNameSyntax)fieldType;
        TypeSyntax type = gns.TypeArgumentList.Arguments[0];
        string fullName = GetModel(vds).GetFullTypeName(type);
        return new TypeReference(fullName, GetModel(vds).GetTypeInfo(type).Type);
    }

    [Obsolete("Rewrite this hell")]
    private int GetAndIncrementBinding(int set)
    {
        if (!_setCounts.TryGetValue(set, out int ret))
        {
            ret = 0;
            _setCounts.Add(set, ret);
        }
        else
        {
            ret += 1;
            _setCounts[set] = ret;
        }

        return ret;
    }
}
