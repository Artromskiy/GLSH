using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class DepthTextureSamplerFragment
    {
        public struct FragmentInput
        {
            [Layout(location: 0)]
            public Vector4 Position;
            [Layout(location: 1)]
            public Vector2 TextureCoordinate;
        }

        public DepthTexture2DResource Tex2D;
        public DepthTexture2DArrayResource TexArray;
        public SamplerComparisonResource Sampler;

        [FragmentEntryPoint]
        public Vector4 FS(FragmentInput input)
        {
            float arraySample = SampleComparisonLevelZero(TexArray, Sampler, new Vector2(1, 2), 3, 0.5f);
            return new Vector4(
                SampleComparisonLevelZero(Tex2D, Sampler, input.TextureCoordinate, 0.5f),
                SampleMethod(Tex2D, Sampler),
                0,
                1);
        }

        private float SampleMethod(DepthTexture2DResource depthTexture, SamplerComparisonResource mySampler)
        {
            return SampleComparisonLevelZero(depthTexture, mySampler, Vector2.Zero, 0.2f)
                + SampleMethodInner(depthTexture, mySampler);
        }

        private float SampleMethodInner(DepthTexture2DResource depthTexture2, SamplerComparisonResource mySampler)
        {
            return SampleComparisonLevelZero(depthTexture2, mySampler, Vector2.Zero, 0.2f);
        }
    }
}
