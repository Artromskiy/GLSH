using GLSH.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GLSH.Compiler.Internal;

internal class PipelineDiscoverer : CSharpSyntaxWalker
{
    private readonly HashSet<string> _discoveredNames = [];
    private readonly List<PipelineInfo> _discoveredPipelines = [];
    private readonly Compilation _compilation;
    public PipelineInfo[] PipelineInfos => [.. _discoveredPipelines];

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
            throw new ShaderGenerationException($"{typeName} is marked with {nameof(GraphicsPipelineAttribute)} and {nameof(ComputePipelineAttribute)} at the same time. This is not supported.");
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

    private void ValidateGraphicsPipeline(TypeDeclarationSyntax classDeclarationSyntax, GraphicsPipelineAttribute data)
    {
        string? pipelineName = data.name;
        var model = GetOrCreateSemanticModel(classDeclarationSyntax.SyntaxTree);

        var vertEntryPoints = GetEntryPoints<VertexEntryPointAttribute>(classDeclarationSyntax, model);

        var fragEntryPoints = GetEntryPoints<FragmentEntryPointAttribute>(classDeclarationSyntax, model);

        if (vertEntryPoints.Length != 1 || fragEntryPoints.Length != 1)
        {
            var typeName = model.GetTypeInfo(classDeclarationSyntax).Type?.GetFullMetadataName();
            if (vertEntryPoints.Length > 1)
                throw new ShaderGenerationException($"{typeName} contains more than one method marked with {nameof(VertexEntryPointAttribute)}. Multiple entry points are not supported.");
            if (fragEntryPoints.Length > 1)
                throw new ShaderGenerationException($"{typeName} contains more than one method marked with {nameof(FragmentEntryPointAttribute)}. Multiple entry points are not supported.");
            else
                throw new ShaderGenerationException($"{typeName} must specify entry points with {nameof(VertexEntryPointAttribute)} and {nameof(FragmentEntryPointAttribute)}.");
        }

        string? vertexEntryPointFullName = model.GetDeclaredSymbol(vertEntryPoints[0].methodSyntax)?.GetFullMetadataName();
        string? fragmentEntryPointFullName = model.GetDeclaredSymbol(fragEntryPoints[0].methodSyntax)?.GetFullMetadataName();

        TypeAndMethodName? vsName = null;
        TypeAndMethodName? fsName = null;

        ShaderGenerationException.ThrowIf(vertexEntryPointFullName == null || !TypeAndMethodName.TryCreate(vertexEntryPointFullName, out vsName),
            "{0} has an incomplete or invalid vertex shader name.", nameof(GraphicsPipelineAttribute));

        ShaderGenerationException.ThrowIf(fragmentEntryPointFullName == null || !TypeAndMethodName.TryCreate(fragmentEntryPointFullName, out fsName),
            "{0} has an incomplete or invalid fragment shader name.", nameof(GraphicsPipelineAttribute));

        if (!_discoveredNames.Add(pipelineName))
            throw new ShaderGenerationException("Multiple pipelines with the same name were defined: " + pipelineName);

        _discoveredPipelines.Add(new(pipelineName, vsName, fsName));
    }

    private void ValidateComputePipeline(TypeDeclarationSyntax classDeclarationSyntax, ComputePipelineAttribute data)
    {
        throw new NotImplementedException();
    }

    private static (MethodDeclarationSyntax methodSyntax, AttributeSyntax? attributeSyntax)[] GetEntryPoints<T>(TypeDeclarationSyntax classDeclarationSyntax, SemanticModel model) where T : Attribute
    {
        return classDeclarationSyntax.Members.OfType<MethodDeclarationSyntax>().Select(methodSyntax =>
        {
            AttributeHelper.TryGetAttribute<T>(methodSyntax, model, out var attributeSyntax);
            return (methodSyntax, attributeSyntax);
        }).Where(s => s.attributeSyntax is not null).ToArray();

    }

    private SemanticModel GetOrCreateSemanticModel(SyntaxTree tree)
    {
        if (!_cachedSemanticModels.TryGetValue(tree, out var model))
            _cachedSemanticModels[tree] = model = _compilation.GetSemanticModel(tree);
        return model;
    }
}
