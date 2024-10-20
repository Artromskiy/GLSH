using GLSH;
using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets.PartialClassShader
{
    public partial class PartialVertex
    {
        private struct FragmentInput
        {
            [Layout(location: 0)] public Vector4 Position;
            [Layout(location: 1)] public Vector4 Color;
        }

        public SamplerResource Sampler;

        [VertexEntryPoint]
        private FragmentInput VertexShaderFunc(VertexInput input)
        {
            FragmentInput output;
            output.Position = new Vector4(input.Position, 1);
            output.Color = input.Color;
            return output;
        }
    }
}
