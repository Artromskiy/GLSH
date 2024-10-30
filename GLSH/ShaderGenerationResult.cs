using System.Collections.Generic;

namespace GLSH.Compiler;

public class ShaderGenerationResult
{
    private readonly List<GeneratedPipeline> _generatedShaders = [];

    public IReadOnlyList<GeneratedPipeline> GetOutput()
    {
        if (_generatedShaders.Count == 0)
            return [];

        return _generatedShaders;
    }

    internal void AddShaderSet(GeneratedPipeline gss)
    {
        _generatedShaders.Add(gss);
    }
}
