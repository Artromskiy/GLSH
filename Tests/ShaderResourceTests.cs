using GLSH;
using GLSH.Glsl;
using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using Microsoft.CodeAnalysis;
using Tests.TestAssets;
using Xunit;

namespace Tests
{
    public static class ShaderResourceTests
    {
        [Fact]
        public static void ReferenceTypeField_ThrowsShaderGenerationException()
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new(compilation, backend, "ShaderGen.Tests.ReferenceTypeField.VS");
            Assert.Throws<ShaderGenerationException>(sg.GenerateShaders);
        }
    }

    internal class ReferenceTypeField
    {
#pragma warning disable 0649
        public object ReferenceField;
#pragma warning restore 0649

        [VertexEntryPoint]
        public Position4Texture2 VS(PositionTexture input)
        {
            Position4Texture2 output;
            output.Position = new System.Numerics.Vector4(input.Position, 1);
            output.TextureCoord = input.TextureCoord;
            return output;
        }
    }
}
