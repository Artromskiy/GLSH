using GLSH;
using GLSH.Glsl;
using Microsoft.CodeAnalysis;
using Xunit;

namespace Tests
{
    public class VertexSemanticTests
    {
        [Fact]
        public void MissingSemantic_ThrowsShaderGenerationException()
        {
            Compilation compilation = TestUtil.GetCompilation();
            ShaderGenerator sg = new(compilation, new Glsl450Backend(compilation), "TestShaders.MissingInputSemantics.VS");
            Assert.Throws<ShaderGenerationException>(sg.GenerateShaders);
        }
    }
}
