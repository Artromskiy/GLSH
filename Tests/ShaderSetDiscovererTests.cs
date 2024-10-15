using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using GLSH;
using Xunit;
using Tests.Tools;
using GLSH.Glsl;

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
            Assert.Equal("VertexAndFragment", set.Name);

            CompileResult result = ToolChain.Compile(set.VertexShaderCode, Stage.Vertex, "VS");
            Assert.False(result.HasError, result.ToString());

            result = ToolChain.Compile(set.FragmentShaderCode, Stage.Fragment, "FS");
            Assert.False(result.HasError, result.ToString());
        }
    }
}
