using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    internal class MultipleResourceSets
    {
#pragma warning disable 0649
        public Matrix4x4 NoAttributeMatrix;                     // 0
        [Layout(set: 0)] public Matrix4x4 Matrix0;              // 1
        [Layout(set: 1)] public Matrix4x4 Matrix1;              // 2
        [Layout(set: 2)] public Matrix4x4 Matrix2;              // 3
        [Layout(set: 3)] public Matrix4x4 Matrix4;              // 4
        [Layout(set: 4)] public Matrix4x4 Matrix3;              // 5
        [Layout(set: 0)] public Matrix4x4 Matrix00;             // 6

        [Layout(set: 0)] public SamplerResource Sampler0;       // 7
        [Layout(set: 4)] public SamplerResource Sampler4;       // 8
        public SamplerResource NoAttributeSampler;              // 9

        [Layout(set: 2)] public Texture2DResource Texture2D2;   // 10
        public Texture2DResource NoAttributeTexture2D;          // 11
        [Layout(set: 1)] public Texture2DResource Texture2D1;   // 12
#pragma warning restore 0649

        [VertexEntryPoint]
        public SystemPosition4 VS(Position4 input)
        {
            Vector4 outputPos;
            Matrix4x4 result = NoAttributeMatrix * Matrix0 * Matrix1 * Matrix2 * Matrix3 * Matrix4 * Matrix00;
            outputPos = Mul(result, input.Position);

            SystemPosition4 output;
            output.Position = outputPos;
            return output;
        }

        [FragmentEntryPoint]
        public Vector4 FS(SystemPosition4 input)
        {
            return input.Position;
        }
    }
}
