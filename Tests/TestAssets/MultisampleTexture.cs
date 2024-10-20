using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class MultisampleTexture
    {
        public Texture2DMSResource MultisampleTex2D;
        public SamplerResource Sampler;

        public struct PositionTexture
        {
            [Layout(location: 0)] public Vector4 Position;
            [Layout(location: 1)] public Vector2 TexCoords;
        }

        public struct FragmentInput
        {
            [Layout(location: 0)] public Vector4 Position;
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
