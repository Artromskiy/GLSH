using GLSH.Attributes;
using GLSH.Compiler;
using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace GLSH;

internal partial class ShaderSyntaxWalker : CSharpSyntaxWalker
{
    private readonly Compilation _compilation;
    private readonly LanguageBackend _backend;
    private readonly ShaderSetInfo _shaderSet;


    public ShaderSyntaxWalker(Compilation compilation, LanguageBackend backend, ShaderSetInfo ss)
        : base(SyntaxWalkerDepth.Token)
    {
        _compilation = compilation;
        _backend = backend;
        _shaderSet = ss;
    }

    private SemanticModel GetModel(SyntaxNode node) => _compilation.GetSemanticModel(node.SyntaxTree);

    [Obsolete("Rewrite this hell")]
    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        ShaderFunctionAndMethodDeclarationSyntax sfab = Utilities.GetShaderFunction(node, _compilation, true);
        _backend.AddFunction(_shaderSet.name, sfab);
        foreach (var calledFunction in sfab.orderedFunctionList)
            _backend.AddFunction(_shaderSet.name, calledFunction);
    }

    public override void VisitStructDeclaration(StructDeclarationSyntax node)
    {
        TryGetStructDefinition(GetModel(node), node, out var sd);
        _backend.AddStructure(_shaderSet.name, sd);
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        if (node.Modifiers.Any(x => x.IsKind(SyntaxKind.ConstKeyword)))
            return;

        ShaderGenerationException.ThrowIf(node.Declaration.Variables.Count != 1,
            "Cannot declare multiple variables together as it will cause layout intersection.");

        var resourceName = node.Declaration.Variables[0].Identifier.Text;
        TypeInfo typeInfo = GetModel(node).GetTypeInfo(node.Declaration.Type);
        string fullTypeName = GetModel(node).GetFullTypeName(node.Declaration.Type);
        TypeReference valueType = new(fullTypeName, typeInfo.Type);
        ShaderResourceKind kind = ClassifyResourceKind(fullTypeName);
        bool genericKind = kind.IsGenericResource();

        valueType = genericKind ? ParseGenericElementType(node.Declaration.Type) : valueType;

        ShaderGenerationException.ThrowIf(!AttributeHelper.TryGetAttribute<LayoutAttribute>(node, GetModel(node), out var syntax),
            "All resources must specify set and binding");

        var attributeData = syntax.CreateAttributeOfType<LayoutAttribute>(GetModel(node));
        int set = attributeData.set;
        int binding = attributeData.binding;

        ResourceDefinition rd = new(resourceName, set, binding, valueType, kind);
        if (kind == ShaderResourceKind.Uniform)
            ValidateUniformType(typeInfo);

        _backend.AddResource(_shaderSet.name, rd);
    }

    private TypeReference ParseGenericElementType(TypeSyntax fieldType)
    {
        while (fieldType is QualifiedNameSyntax qns)
            fieldType = qns.Right;

        GenericNameSyntax gns = (GenericNameSyntax)fieldType;
        TypeSyntax type = gns.TypeArgumentList.Arguments[0];
        string fullName = GetModel(fieldType).GetFullTypeName(type);
        return new TypeReference(fullName, GetModel(fieldType).GetTypeInfo(type).Type);
    }

    /*
    public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        ShaderGenerationException.ThrowIf(HasAccessors(node),
            "Resource may not specify getters and setters.");

        string resourceName = node.Identifier.Text;
        TypeInfo typeInfo = GetModel(node).GetTypeInfo(node.Type);
        string fullTypeName = GetModel(node).GetFullTypeName(node.Type);
        TypeReference valueType = new(fullTypeName, typeInfo.Type);
        ShaderResourceKind kind = ClassifyResourceKind(fullTypeName);
        bool genericKind = kind.IsGenericResource();
        valueType = genericKind ? ParseGenericElementType(node) : valueType;
        ShaderGenerationException.ThrowIf(!AttributeHelper.TryGetAttribute<LayoutAttribute>(node, GetModel(node), out var syntax),
            "All resources must specify set and binding");
        var attributeData = syntax.CreateAttributeOfType<LayoutAttribute>(GetModel(node));
        int set = attributeData.set;
        int binding = attributeData.binding;

        ResourceDefinition rd = new(resourceName, set, binding, valueType, kind);
        if (kind == ShaderResourceKind.Uniform)
            ValidateUniformType(typeInfo);

        foreach (LanguageBackend b in _backends)
            b.AddResource(_shaderSet.name, rd);
    }
    */
    /*
    private bool HasAccessors(PropertyDeclarationSyntax node)
    {
        if (node.AccessorList == null)
            return false;
        foreach (var item in node.AccessorList.Accessors)
            if (item.Body != null)
                return true;

        return false;
    }
    */
}
