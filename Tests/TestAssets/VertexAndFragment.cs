using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class VertexAndFragment
    {
        [VertexEntryPoint]
        public FragmentInput VS(VertexInput input)
        {
            FragmentInput output;
            output.Position = new Vector4(input.Position, 1);
            return output;
        }

        [FragmentEntryPoint]
        public Vector4 FS(FragmentInput input)
        {
            return new Vector4(input.Position.X, input.Position.Y, input.Position.Z, 1);
        }

        public struct VertexInput
        {
            [VertexSemantic(SemanticType.Position)]
            public Vector3 Position;
        }

        public struct FragmentInput
        {
            [VertexSemantic(SemanticType.SystemPosition)]
            public Vector4 Position;
        }
    }
}
