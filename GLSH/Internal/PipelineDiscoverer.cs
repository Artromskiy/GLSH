using GLSH.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace GLSH.Compiler.Internal;

internal class PipelineDiscoverer : CSharpSyntaxWalker
{
    private readonly Compilation _compilation;

    private readonly HashSet<string> _discoveredNames = [];
    private readonly List<PipelineInfo> _discoveredPipelines = [];
    public PipelineInfo[] PipelineInfos => [.. _discoveredPipelines];

    private const int AttributeLength = 9;


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
            Debug.Assert(graphicsPipelineAttributeSyntax != null);
            var graphicsPipelineAttribute = graphicsPipelineAttributeSyntax.CreateAttributeOfType<GraphicsPipelineAttribute>(model);
            ValidateGraphicsPipeline(node, graphicsPipelineAttribute);
        }
        if (isComputePipeline)
        {
            Debug.Assert(computePipelineAttributeSyntax != null);
            var computePipelineAttribute = computePipelineAttributeSyntax.CreateAttributeOfType<ComputePipelineAttribute>(model);
            ValidateComputePipeline(node, computePipelineAttribute);
        }
    }

    private void ValidateGraphicsPipeline(TypeDeclarationSyntax classDeclarationSyntax, GraphicsPipelineAttribute data)
    {
        string? pipelineName = data.name;

        if (_discoveredNames.Contains(pipelineName))
            throw new ShaderGenerationException("Multiple pipelines with the same name were defined: " + pipelineName);

        var model = GetOrCreateSemanticModel(classDeclarationSyntax.SyntaxTree);

        var vertEntryPoints = GetMarkedMethods<VertexEntryPointAttribute>(classDeclarationSyntax, model);
        var fragEntryPoints = GetMarkedMethods<FragmentEntryPointAttribute>(classDeclarationSyntax, model);

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

        var vertexEntrySymbol = model.GetDeclaredSymbol(vertEntryPoints[0].methodSyntax);
        var fragmentEntrySymbol = model.GetDeclaredSymbol(fragEntryPoints[0].methodSyntax);

        ShaderGenerationException.ThrowIfNull(vertexEntrySymbol, "Unable to find declared symbol for method marked {0}", nameof(VertexEntryPointAttribute));
        ShaderGenerationException.ThrowIfNull(fragmentEntrySymbol, "Unable to find declared symbol for method marked {0}", nameof(FragmentEntryPointAttribute));

        var vertexEntryDeclaration = Utilities.GetMethodDeclarationData(vertexEntrySymbol);
        var fragmentEntryDeclaration = Utilities.GetMethodDeclarationData(fragmentEntrySymbol);

        _discoveredNames.Add(pipelineName);
        _discoveredPipelines.Add(new(pipelineName, vertexEntryDeclaration, fragmentEntryDeclaration));
    }

    private void ValidateComputePipeline(TypeDeclarationSyntax classDeclarationSyntax, ComputePipelineAttribute data)
    {
        throw new NotImplementedException();
    }

    private static (MethodDeclarationSyntax methodSyntax, AttributeSyntax? attributeSyntax)[] GetMarkedMethods<T>(TypeDeclarationSyntax classDeclarationSyntax, SemanticModel model) where T : Attribute
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
