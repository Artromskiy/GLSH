using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets.PartialClassShader
{
    public partial class PartialVertex
    {
        public struct VertexInput
        {
            [VertexSemantic(SemanticType.Position)] public Vector3 Position;
            [VertexSemantic(SemanticType.Color)] public Vector4 Color;
        }

        public Matrix4x4 First;
        public Matrix4x4 Second;
    }
}
