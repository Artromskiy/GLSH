using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class MultisampleTexture
    {
        public Texture2DMSResource MultisampleTex2D;
        public SamplerResource Sampler;

        public struct PositionTexture
        {
            [VertexSemantic(SemanticType.Position)] public Vector4 Position;
            [VertexSemantic(SemanticType.TextureCoordinate)] public Vector2 TexCoords;
        }

        public struct FragmentInput
        {
            [VertexSemantic(SemanticType.SystemPosition)] public Vector4 Position;
        }

        [VertexEntryPoint]
        public FragmentInput VS(PositionTexture input)
        {
            FragmentInput output;
            output.Position = Load(MultisampleTex2D, Sampler, input.TexCoords, 0);
            return output;
        }
    }
}
