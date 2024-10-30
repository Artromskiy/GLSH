using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System;

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

        var orderedVertexMethods = Walkers.GetOrderedMethodDeclarations(_compilation, pipelineInfo.vertexEntry);
        var orderedFragmentMethods = Walkers.GetOrderedMethodDeclarations(_compilation, pipelineInfo.fragmentEntry);

        var orderedVertexStructs = Walkers.GetOrderedStructDeclarations(_compilation, pipelineInfo.vertexEntry);
        var orderedFragmentStructs = Walkers.GetOrderedStructDeclarations(_compilation, pipelineInfo.fragmentEntry);

        var res = _language.ProcessEntryFunction(pipelineInfo.vertexEntry);

        //var orderedComputeMethods = ShaderWalkers.GetOrderedMethodDeclarations(_compilation, pipelineInfo.computeEntry);

        //ShaderSyntaxWalker walker = new(_compilation, _language, pipelineInfo);

        //foreach (SyntaxTree tree in treesToVisit)
        //    walker.Visit(tree.GetRoot());

        //string? vsCode = _language.ProcessEntryFunction(pipelineInfo.name, vsFunc).fullText : null;
        //string? fsCode = _language.ProcessEntryFunction(pipelineInfo.name, fsFunc).fullText : null;
        //string? csCode = _language.ProcessEntryFunction(pipelineInfo.name, csFunc).fullText : null;
        //
        //output.AddShaderSet(new(pipelineInfo.name, vsCode, fsCode, csCode, vsFunc, fsFunc, csFunc, model));
    }
}