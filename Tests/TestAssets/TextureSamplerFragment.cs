using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class TextureSamplerFragment
    {
        public struct FragmentInput
        {
            [Layout(location: 0)]
            public Vector4 Position;
            [Layout(location: 1)]
            public Vector2 TextureCoordinate;
        }

        public Texture2DResource Tex2D;
        public TextureCubeResource TexCube;
        public Texture2DArrayResource TexArray;
        public SamplerResource Sampler;

        [FragmentEntryPoint]
        public Vector4 FS(FragmentInput input)
        {
            Vector4 cubeSample = Sample(TexCube, Sampler, new Vector3(1, 2, 3));
            Vector4 arraySample = Sample(TexArray, Sampler, new Vector2(1, 2), 3);
            Vector4 gradSample = SampleGrad(Tex2D, Sampler, input.TextureCoordinate, Vector2.One, Vector2.One);
            Vector4 arrayGradSample = SampleGrad(TexArray, Sampler, input.TextureCoordinate, 3, Vector2.One, Vector2.One);
            Vector4 calledMethodSample = SampleTexture(Tex2D, Sampler);
            Vector4 loaded = Load(Tex2D, Sampler, new Vector2(1, 2), 0);
            return Sample(Tex2D, Sampler, input.TextureCoordinate);
        }

        private Vector4 SampleTexture(Texture2DResource myTexture, SamplerResource mySampler)
        {
            return Sample(myTexture, mySampler, Vector2.Zero);
        }
    }
}
