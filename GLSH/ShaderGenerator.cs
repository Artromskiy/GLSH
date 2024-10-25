using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace GLSH.Compiler;

public partial class ShaderGenerator
{
    private readonly Compilation _compilation;
    private readonly LanguageBackend _language;
    private readonly PipelineInfo[] _pipelineInfos;


    public ShaderGenerator(Compilation compilation, LanguageBackend language)
    {
        ArgumentNullException.ThrowIfNull(language);
        ArgumentNullException.ThrowIfNull(compilation);

        _compilation = compilation;
        _language = language;

        PipelineDiscoverer pipelineDiscoverer = new(compilation);
        foreach (SyntaxTree tree in _compilation.SyntaxTrees)
            pipelineDiscoverer.Visit(tree.GetRoot());

        _pipelineInfos = pipelineDiscoverer.PipelineInfos;
        return;
    }

    public ShaderGenerationResult GenerateShaders()
    {
        ShaderGenerationResult result = new();
        foreach (PipelineInfo ss in _pipelineInfos)
            GenerateShaders(ss, result);
        return result;
    }

    private void GenerateShaders(PipelineInfo pipelineInfo, ShaderGenerationResult output)
    {
        HashSet<SyntaxTree> treesToVisit = [];

        if (pipelineInfo.vertexEntry != null)
            GetTrees(treesToVisit, pipelineInfo.vertexEntry.containingTypeName);
        if (pipelineInfo.fragmentEntry != null)
            GetTrees(treesToVisit, pipelineInfo.fragmentEntry.containingTypeName);
        if (pipelineInfo.computeEntry != null)
            GetTrees(treesToVisit, pipelineInfo.computeEntry.containingTypeName);

        _language.InitContext(pipelineInfo.name);

        CallGraphWalker w = new(_compilation, pipelineInfo.vertexEntry);

        ShaderSyntaxWalker walker = new(_compilation, _language, pipelineInfo);

        foreach (SyntaxTree tree in treesToVisit)
            walker.Visit(tree.GetRoot());

        ShaderModel model = _language.GetShaderModel(pipelineInfo.name);
        ShaderFunction? vsFunc = pipelineInfo.vertexEntry != null ? model.GetFunction(pipelineInfo.vertexEntry.fullMethodName) : null;
        ShaderFunction? fsFunc = pipelineInfo.fragmentEntry != null ? model.GetFunction(pipelineInfo.fragmentEntry.fullMethodName) : null;
        ShaderFunction? csFunc = pipelineInfo.computeEntry != null ? model.GetFunction(pipelineInfo.computeEntry.fullMethodName) : null;
        string? vsCode = vsFunc != null ? _language.ProcessEntryFunction(pipelineInfo.name, vsFunc).fullText : null;
        string? fsCode = fsFunc != null ? _language.ProcessEntryFunction(pipelineInfo.name, fsFunc).fullText : null;
        string? csCode = csFunc != null ? _language.ProcessEntryFunction(pipelineInfo.name, csFunc).fullText : null;

        output.AddShaderSet(new(pipelineInfo.name, vsCode, fsCode, csCode, vsFunc, fsFunc, csFunc, model));
    }

    private void GetTrees(HashSet<SyntaxTree> treesToVisit, string typeName)
    {
        INamedTypeSymbol? typeSymbol = _compilation.GetTypeByMetadataName(typeName);
        ShaderGenerationException.ThrowIfNull(typeSymbol, "No type was found with the name {0}", typeName);
        foreach (SyntaxReference syntaxRef in typeSymbol.DeclaringSyntaxReferences)
            treesToVisit.Add(syntaxRef.SyntaxTree);
    }
}