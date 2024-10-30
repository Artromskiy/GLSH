using GLSH;
using GLSH.Attributes;
using System.Runtime.InteropServices;

namespace Tests.TestAssets
{
    internal class UIntVectors
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct VertexInput
        {
            [Layout(location: 0)]
            public uint2 U32x2;
            [Layout(location: 1)]
            public uint3 U32x3;
            [Layout(location: 2)]
            public uint4 U32x4;

            [Layout(location: 0)]
            public int2 I32x2;
            [Layout(location: 0)]
            public int3 I32x3;
            [Layout(location: 0)]
            public int4 I32x4;
        }

        [VertexEntryPoint]
        public SystemPosition4 VS(VertexInput input)
        {
            SystemPosition4 output;
            output.Position = new System.Numerics.Vector4(
                input.U32x2.x + input.U32x3.x + input.U32x4.x,
                input.U32x2.y + input.U32x3.y + input.U32x4.y,
                input.U32x3.z + input.U32x4.z,
                input.U32x4.z);

            output.Position += new System.Numerics.Vector4(
                input.I32x2.x + input.I32x3.x + input.I32x4.x,
                input.I32x2.y + input.I32x3.y + input.I32x4.y,
                input.I32x3.z + input.I32x4.z,
                input.I32x4.w);

            return output;
        }
    }
}
