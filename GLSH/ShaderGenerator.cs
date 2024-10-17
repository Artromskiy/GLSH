using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace GLSH;

public partial class ShaderGenerator
{
    private readonly Compilation _compilation;
    private readonly IReadOnlyList<ShaderSetInfo> _shaderSets = [];
    private readonly IReadOnlyList<LanguageBackend> _languages;
    private readonly IShaderSetProcessor[] _processors;

    public ShaderGenerator(
        Compilation compilation,
        LanguageBackend[] languages,
        params IShaderSetProcessor[] processors)
        : this(compilation, languages, null, null, null, processors) { }

    public ShaderGenerator(
        Compilation compilation,
        LanguageBackend language,
        params IShaderSetProcessor[] processors)
        : this(compilation, [language], null, null, null, processors) { }

    public ShaderGenerator(
        Compilation compilation,
        LanguageBackend language,
        string vertexFunctionName = null,
        string fragmentFunctionName = null,
        string computeFunctionName = null,
        params IShaderSetProcessor[] processors)
    : this(compilation, [language], vertexFunctionName, fragmentFunctionName, computeFunctionName, processors) { }

    [Obsolete("Rewrite this hell")]
    public ShaderGenerator(
        Compilation compilation,
        LanguageBackend[] languages,
        string? vertexFunctionName = null,
        string? fragmentFunctionName = null,
        string? computeFunctionName = null,
        params IShaderSetProcessor[] processors)
    {
        ArgumentNullException.ThrowIfNull(languages);
        _compilation = compilation ?? throw new ArgumentNullException(nameof(compilation));
        if (languages.Length <= 0)
            throw new ArgumentException("At least one LanguageBackend must be provided.");

        _languages = [.. languages];
        _processors = processors;

        // If we've not specified any names, we're auto-discovering
        if (string.IsNullOrWhiteSpace(vertexFunctionName) &&
            string.IsNullOrWhiteSpace(fragmentFunctionName) &&
            string.IsNullOrWhiteSpace(computeFunctionName))
        {
            PipelineDiscoverer pipelineDiscoverer = new(compilation);
            foreach (SyntaxTree tree in _compilation.SyntaxTrees)
                pipelineDiscoverer.Visit(tree.GetRoot());

            _shaderSets = pipelineDiscoverer.ShaderSets;
            return;
        }
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
            foreach (GeneratedShaderSet gss in result.GetOutput(_languages[0]))
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
        TypeAndMethodName vertexFunctionName = shaderSetInfo.vertexShader;
        TypeAndMethodName fragmentFunctionName = shaderSetInfo.fragmentShader;
        TypeAndMethodName computeFunctionName = shaderSetInfo.computeShader;

        HashSet<SyntaxTree> treesToVisit = [];
        if (vertexFunctionName != null)
            GetTrees(treesToVisit, vertexFunctionName.typeName);
        if (fragmentFunctionName != null)
            GetTrees(treesToVisit, fragmentFunctionName.typeName);
        if (computeFunctionName != null)
            GetTrees(treesToVisit, computeFunctionName.typeName);

        foreach (LanguageBackend language in _languages)
            language.InitContext(shaderSetInfo.name);

        ShaderSyntaxWalker walker = new(_compilation, [.. _languages], shaderSetInfo);

        foreach (SyntaxTree tree in treesToVisit)
            walker.Visit(tree.GetRoot());

        foreach (LanguageBackend language in _languages)
        {
            ShaderModel model = language.GetShaderModel(shaderSetInfo.name);
            ShaderFunction? vsFunc = shaderSetInfo.vertexShader != null ? model.GetFunction(shaderSetInfo.vertexShader.fullName) : null;
            ShaderFunction? fsFunc = shaderSetInfo.fragmentShader != null ? model.GetFunction(shaderSetInfo.fragmentShader.fullName) : null;
            ShaderFunction? csFunc = shaderSetInfo.computeShader != null ? model.GetFunction(shaderSetInfo.computeShader.fullName) : null;
            string? vsCode = vsFunc != null ? language.ProcessEntryFunction(shaderSetInfo.name, vsFunc).fullText : null;
            string? fsCode = fsFunc != null ? language.ProcessEntryFunction(shaderSetInfo.name, fsFunc).fullText : null;
            string? csCode = csFunc != null ? language.ProcessEntryFunction(shaderSetInfo.name, csFunc).fullText : null;

            output.AddShaderSet(language,
                new GeneratedShaderSet(shaderSetInfo.name, vsCode, fsCode, csCode, vsFunc, fsFunc, csFunc, model));
        }
    }

    private void GetTrees(HashSet<SyntaxTree> treesToVisit, string typeName)
    {
        INamedTypeSymbol typeSymbol = _compilation.GetTypeByMetadataName(typeName);
        if (typeSymbol == null)
        {
            throw new ShaderGenerationException("No type was found with the name " + typeName);
        }
        foreach (SyntaxReference syntaxRef in typeSymbol.DeclaringSyntaxReferences)
        {
            treesToVisit.Add(syntaxRef.SyntaxTree);
        }
    }
}
