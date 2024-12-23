﻿using GLSH;
using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class StructureSizeTests
    {
        [VertexEntryPoint]
        private SystemPosition4 VS(Position4 input)
        {
            SystemPosition4 output;
            output.Position = new Vector4();
            return output;
        }

        public struct SizeTest_0
        {
            public Vector4 One;
            public Vector4 Two;
            public Vector4 Three;
        }

        public struct SizeTest_1
        {
            public Vector4 One;
            public Vector4 Two;
            public Vector4 Three;
            public float Four;
        }

        public struct SizeTest_2
        {
            public float One;
            public Vector3 Two;
            public Vector3 Three;
            public Vector4 Four;
            public float Five;
        }

        public struct SizeTest_3
        {
            public int One;
            public Vector3 Two;
            public int3 Three;
            public Vector4 Four;
            public uint Five;
            public int4 Six;
        }
    }
}
