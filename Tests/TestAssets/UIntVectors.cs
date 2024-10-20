﻿using GLSH;
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
            public UInt2 U32x2;
            [Layout(location: 1)]
            public UInt3 U32x3;
            [Layout(location: 2)]
            public UInt4 U32x4;

            [Layout(location: 0)]
            public Int2 I32x2;
            [Layout(location: 0)]
            public Int3 I32x3;
            [Layout(location: 0)]
            public Int4 I32x4;
        }

        [VertexEntryPoint]
        public SystemPosition4 VS(VertexInput input)
        {
            SystemPosition4 output;
            output.Position = new System.Numerics.Vector4(
                input.U32x2.X + input.U32x3.X + input.U32x4.X,
                input.U32x2.Y + input.U32x3.Y + input.U32x4.Y,
                input.U32x3.Z + input.U32x4.Z,
                input.U32x4.Z);

            output.Position += new System.Numerics.Vector4(
                input.I32x2.X + input.I32x3.X + input.I32x4.X,
                input.I32x2.Y + input.I32x3.Y + input.I32x4.Y,
                input.I32x3.Z + input.I32x4.Z,
                input.I32x4.W);

            return output;
        }
    }
}
