using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Tests.TestAssets.VeldridShaders
{
    public class UIntVertexAttribs
    {
        public struct Vertex
        {
            [VertexSemantic(SemanticType.Position)]
            public Vector2 Position;
            [VertexSemantic(SemanticType.Color)]
            public UInt4 Color_Int;
        }

        public struct FragmentInput
        {
            [VertexSemantic(SemanticType.SystemPosition)]
            public Vector4 Position;
            [VertexSemantic(SemanticType.Color)]
            public Vector4 Color;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Info
        {
            public uint ColorNormalizationFactor;
            private readonly float _padding0;
            private readonly float _padding1;
            private readonly float _padding2;
        }

        public Info InfoBuffer;

        [VertexEntryPoint]
        public FragmentInput VS(Vertex input)
        {
            FragmentInput output;
            output.Position = new Vector4(input.Position, 0, 1);
            output.Color = new Vector4(input.Color_Int.X, input.Color_Int.Y, input.Color_Int.Z, input.Color_Int.W) / InfoBuffer.ColorNormalizationFactor;
            return output;
        }

        [FragmentEntryPoint]
        public Vector4 FS(FragmentInput input)
        {
            return input.Color;
        }
    }
}
