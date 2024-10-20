using System.Collections.Generic;

namespace GLSH.Compiler;

public class ShaderGenerationResult
{
    private readonly List<GeneratedShaderSet> _generatedShaders = [];

    public IReadOnlyList<GeneratedShaderSet> GetOutput()
    {
        if (_generatedShaders.Count == 0)
            return [];

        return _generatedShaders;
    }

    internal void AddShaderSet(GeneratedShaderSet gss)
    {
        _generatedShaders.Add(gss);
    }
}
