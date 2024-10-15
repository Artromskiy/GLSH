using System;
using System.Collections.Generic;

namespace GLSH;

public class ShaderGenerationResult
{
    private readonly Dictionary<LanguageBackend, List<GeneratedShaderSet>> _generatedShaders = [];

    public IReadOnlyList<GeneratedShaderSet> GetOutput(LanguageBackend backend)
    {
        if (_generatedShaders.Count == 0)
        {
            return [];
        }

        if (!_generatedShaders.TryGetValue(backend, out var list))
        {
            throw new InvalidOperationException($"The backend {backend} was not used to generate shaders for this object.");
        }

        return list;
    }

    internal void AddShaderSet(LanguageBackend backend, GeneratedShaderSet gss)
    {
        if (!_generatedShaders.TryGetValue(backend, out var list))
        {
            list = [];
            _generatedShaders.Add(backend, list);
        }

        list.Add(gss);
    }
}
