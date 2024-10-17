using GLSH.Primitives.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GLSH;

internal class PipelineDiscoverer : CSharpSyntaxWalker
{
    private readonly HashSet<string> _discoveredNames = [];
    private readonly List<ShaderSetInfo> _shaderSets = [];
    private readonly Compilation _compilation;
    public ShaderSetInfo[] ShaderSets => [.. _shaderSets];

    private const int AttributeLength = 9;

    private static readonly string GraphicsPipelineName = nameof(GraphicsPipelineAttribute)[..^AttributeLength];
    private static readonly string ComputePipelineName = nameof(ComputePipelineAttribute)[..^AttributeLength];

    private readonly Dictionary<SyntaxTree, SemanticModel> _cachedSemanticModels = [];

    public PipelineDiscoverer(Compilation compilation)
    {
        _compilation = compilation;
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node) => VisitTypeDeclaratin(node);
    public override void VisitStructDeclaration(StructDeclarationSyntax node) => VisitTypeDeclaratin(node);

    [Obsolete("Rewrite this hell")]
    private void VisitTypeDeclaratin(TypeDeclarationSyntax node)
    {
        var model = GetOrCreateSemanticModel(node.SyntaxTree);

        bool isGraphicsPipeline = AttributeHelper.TryGetAttribute<GraphicsPipelineAttribute>
            (node, model, out var graphicsPipelineAttributeSyntax);
        bool isComputePipeline = AttributeHelper.TryGetAttribute<ComputePipelineAttribute>
            (node, model, out var computePipelineAttributeSyntax);

        if (isGraphicsPipeline && isComputePipeline)
        {
            var typeName = model.GetTypeInfo(node).Type?.GetFullMetadataName();
            throw new ShaderGenerationException($"{typeName} contains more than one method marked with {typeof(Primitives.Attributes.VertexEntryPointAttribute).FullName}. Multiple entry points are not supported.");
        }
        if (isGraphicsPipeline)
        {
            var graphicsPipelineAttribute = graphicsPipelineAttributeSyntax.CreateAttributeOfType<GraphicsPipelineAttribute>(model);
            ValidateGraphicsPipeline(node, graphicsPipelineAttribute);
        }
        if (isComputePipeline)
        {
            var computePipelineAttribute = computePipelineAttributeSyntax.CreateAttributeOfType<ComputePipelineAttribute>(model);
            ValidateComputePipeline(node, computePipelineAttribute);
        }
    }


    [Obsolete("Rewrite this hell")]
    private void ValidateGraphicsPipeline(TypeDeclarationSyntax classDeclarationSyntax, GraphicsPipelineAttribute data)
    {
        string? pipelineName = data.name;
        var model = GetOrCreateSemanticModel(classDeclarationSyntax.SyntaxTree);

        var vertEntryPoints = classDeclarationSyntax.Members.OfType<MethodDeclarationSyntax>().Select(methodSyntax =>
        {
            AttributeHelper.TryGetAttribute<VertexEntryPointAttribute>(methodSyntax, model, out var attributeSyntax);
            return (methodSyntax, attributeSyntax);
        }).Where(s => s.attributeSyntax is not null).ToArray();

        var fragEntryPoints = classDeclarationSyntax.Members.OfType<MethodDeclarationSyntax>().Select(methodSyntax =>
        {
            AttributeHelper.TryGetAttribute<FragmentEntryPointAttribute>(methodSyntax, model, out var attributeSyntax);
            return (methodSyntax, attributeSyntax);
        }).Where(s => s.attributeSyntax is not null).ToArray();

        if (vertEntryPoints.Length > 1 || fragEntryPoints.Length > 1 || (fragEntryPoints.Length + vertEntryPoints.Length) == 0)
        {
            var typeName = model.GetTypeInfo(classDeclarationSyntax).Type?.GetFullMetadataName();
            if (vertEntryPoints.Length > 1)
                throw new ShaderGenerationException($"{typeName} contains more than one method marked with {typeof(Primitives.Attributes.VertexEntryPointAttribute).FullName}. Multiple entry points are not supported.");
            if (fragEntryPoints.Length > 1)
                throw new ShaderGenerationException($"{typeName} contains more than one method marked with {typeof(Primitives.Attributes.FragmentEntryPointAttribute).FullName}. Multiple entry points are not supported.");
            if (fragEntryPoints.Length + vertEntryPoints.Length == 0)
                throw new ShaderGenerationException($"{typeName} must specify at least one shader name.");
        }
        TypeAndMethodName? vsName = null;
        TypeAndMethodName? fsName = null;

        string? vertexEntryPointFullName = model.GetDeclaredSymbol(vertEntryPoints.FirstOrDefault().methodSyntax)?.GetFullMetadataName();
        string? fragmentEntryPintFullName = model.GetDeclaredSymbol(fragEntryPoints.FirstOrDefault().methodSyntax)?.GetFullMetadataName();

        if (vertexEntryPointFullName != null && !TypeAndMethodName.Get(vertexEntryPointFullName, out vsName))
            throw new ShaderGenerationException("ShaderSetAttribute has an incomplete or invalid vertex shader name.");

        if (fragmentEntryPintFullName != null && !TypeAndMethodName.Get(fragmentEntryPintFullName, out fsName))
            throw new ShaderGenerationException("ShaderSetAttribute has an incomplete or invalid fragment shader name.");

        if (!_discoveredNames.Add(pipelineName))
            throw new ShaderGenerationException("Multiple shader sets with the same name were defined: " + pipelineName);

        _shaderSets.Add(new(pipelineName, vsName, fsName));
    }

    private void ValidateComputePipeline(TypeDeclarationSyntax classDeclarationSyntax, ComputePipelineAttribute data)
    {
        throw new NotImplementedException();
    }



    private SemanticModel GetOrCreateSemanticModel(SyntaxTree tree)
    {
        if (!_cachedSemanticModels.TryGetValue(tree, out var model))
            _cachedSemanticModels[tree] = model = _compilation.GetSemanticModel(tree);
        return model;
    }
}
