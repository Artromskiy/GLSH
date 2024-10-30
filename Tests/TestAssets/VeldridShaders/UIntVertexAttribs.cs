using GLSH;
using GLSH.Attributes;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Tests.TestAssets.VeldridShaders
{
    public class UIntVertexAttribs
    {
        public struct Vertex
        {
            [Layout(location: 0)]
            public Vector2 Position;
            [Layout(location: 1)]
            public uint4 Color_Int;
        }

        public struct FragmentInput
        {
            [Layout(location: 0)]
            public Vector4 Position;
            [Layout(location: 1)]
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
            output.Color = new Vector4(input.Color_Int.x, input.Color_Int.y, input.Color_Int.z, input.Color_Int.w) / InfoBuffer.ColorNormalizationFactor;
            return output;
        }

        [FragmentEntryPoint]
        public Vector4 FS(FragmentInput input)
        {
            return input.Color;
        }
    }
}
