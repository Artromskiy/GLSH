using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets.PartialClassShader
{
    public partial class PartialVertex
    {
        public struct VertexInput
        {
            [Layout(location: 0)] public Vector3 Position;
            [Layout(location: 1)] public Vector4 Color;
        }

        public Matrix4x4 First;
        public Matrix4x4 Second;
    }
}
