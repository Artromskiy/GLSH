using GLSH;
using GLSH.Glsl;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using Tests.Tools;
using Xunit;

namespace Tests
{
    public static class ShaderSetDiscovererTests
    {
        [SkippableFact(typeof(RequiredToolFeatureMissingException))]
        public static void ShaderSetAutoDiscovery()
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new ShaderGenerator(compilation, backend);
            ShaderGenerationResult generationResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> hlslSets = generationResult.GetOutput(backend);
            Assert.Equal(4, hlslSets.Count);
            GeneratedShaderSet set = hlslSets[0];
            Assert.Equal("VertexAndFragment", set.name);

            CompileResult result = ToolChain.Compile(set.vertexShaderCode, Stage.Vertex, "VS");
            Assert.False(result.HasError, result.ToString());

            result = ToolChain.Compile(set.fragmentShaderCode, Stage.Fragment, "FS");
            Assert.False(result.HasError, result.ToString());
        }
    }
}
