using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets.PartialClassShader
{
    public partial class PartialVertex
    {
        private struct FragmentInput
        {
            [VertexSemantic(SemanticType.SystemPosition)] public Vector4 Position;
            [VertexSemantic(SemanticType.Color)] public Vector4 Color;
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
