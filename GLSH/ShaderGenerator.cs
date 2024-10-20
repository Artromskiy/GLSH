using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace GLSH.Compiler;

public partial class ShaderGenerator
{
    private readonly Compilation _compilation;
    private readonly LanguageBackend _language;
    private readonly IReadOnlyList<ShaderSetInfo> _shaderSets = [];
    private readonly IShaderSetProcessor[] _processors;


    [Obsolete("Rewrite this hell")]
    public ShaderGenerator(Compilation compilation, LanguageBackend language, params IShaderSetProcessor[] processors)
    {
        ArgumentNullException.ThrowIfNull(language);
        ArgumentNullException.ThrowIfNull(compilation);

        _compilation = compilation;
        _language = language;
        _processors = processors;

        PipelineDiscoverer pipelineDiscoverer = new(compilation);
        foreach (SyntaxTree tree in _compilation.SyntaxTrees)
            pipelineDiscoverer.Visit(tree.GetRoot());

        _shaderSets = pipelineDiscoverer.ShaderSets;
        return;
    }

    [Obsolete("Rewrite this hell")]
    public ShaderGenerationResult GenerateShaders()
    {
        ShaderGenerationResult result = new();
        foreach (ShaderSetInfo ss in _shaderSets)
            GenerateShaders(ss, result);
        foreach (IShaderSetProcessor processor in _processors)
        {
            // Kind of a hack, but the relevant info should be the same.
            foreach (GeneratedShaderSet gss in result.GetOutput())
            {
                ShaderSetProcessorInput input = new(gss.name, gss.vertexFunction, gss.fragmentFunction, gss.model);
                processor.ProcessShaderSet(input);
            }
        }
        return result;
    }

    [Obsolete("Rewrite this hell")]
    private void GenerateShaders(ShaderSetInfo shaderSetInfo, ShaderGenerationResult output)
    {
        TypeAndMethodName? vertexFunctionName = shaderSetInfo.vertexShader;
        TypeAndMethodName? fragmentFunctionName = shaderSetInfo.fragmentShader;
        TypeAndMethodName? computeFunctionName = shaderSetInfo.computeShader;

        HashSet<SyntaxTree> treesToVisit = [];
        if (vertexFunctionName != null)
            GetTrees(treesToVisit, vertexFunctionName.containingTypeName);
        if (fragmentFunctionName != null)
            GetTrees(treesToVisit, fragmentFunctionName.containingTypeName);
        if (computeFunctionName != null)
            GetTrees(treesToVisit, computeFunctionName.containingTypeName);

        _language.InitContext(shaderSetInfo.name);

        ShaderSyntaxWalker walker = new(_compilation, _language, shaderSetInfo);

        foreach (SyntaxTree tree in treesToVisit)
            walker.Visit(tree.GetRoot());

        ShaderModel model = _language.GetShaderModel(shaderSetInfo.name);
        ShaderFunction? vsFunc = shaderSetInfo.vertexShader != null ? model.GetFunction(shaderSetInfo.vertexShader.fullMethodName) : null;
        ShaderFunction? fsFunc = shaderSetInfo.fragmentShader != null ? model.GetFunction(shaderSetInfo.fragmentShader.fullMethodName) : null;
        ShaderFunction? csFunc = shaderSetInfo.computeShader != null ? model.GetFunction(shaderSetInfo.computeShader.fullMethodName) : null;
        string? vsCode = vsFunc != null ? _language.ProcessEntryFunction(shaderSetInfo.name, vsFunc).fullText : null;
        string? fsCode = fsFunc != null ? _language.ProcessEntryFunction(shaderSetInfo.name, fsFunc).fullText : null;
        string? csCode = csFunc != null ? _language.ProcessEntryFunction(shaderSetInfo.name, csFunc).fullText : null;

        output.AddShaderSet(new(shaderSetInfo.name, vsCode, fsCode, csCode, vsFunc, fsFunc, csFunc, model));
    }

    private void GetTrees(HashSet<SyntaxTree> treesToVisit, string typeName)
    {
        INamedTypeSymbol typeSymbol = _compilation.GetTypeByMetadataName(typeName);
        ShaderGenerationException.ThrowIfNull(typeSymbol, "No type was found with the name ");
        foreach (SyntaxReference syntaxRef in typeSymbol.DeclaringSyntaxReferences)
            treesToVisit.Add(syntaxRef.SyntaxTree);
    }
}