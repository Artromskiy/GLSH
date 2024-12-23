﻿using GLSH;
using GLSH.Attributes;
using System.Numerics;
using Tests.TestAssets.CustomStructResource;

namespace Tests.TestAssets
{
    public class ProcessorTestShaders
    {
#pragma warning disable 0649
        public Matrix4x4 This;
        public Texture2DResource Sentence;
        public SamplerResource Should;
        public TextureCubeResource Be;
        public Vector4 Printed;
        public CustomBlittableStruct By_Enumerating;
        public Vector4 All;
        public Matrix4x4 Resources;
        public SamplerResource In;
        public Matrix4x4 Order;
#pragma warning restore 0649

        [VertexEntryPoint]
        private SystemPosition4 VS(Position4 input)
        {
            SystemPosition4 output;
            output.Position = input.Position;
            return output;
        }

        [FragmentEntryPoint]
        private Vector4 FS(SystemPosition4 input) { return input.Position; }
    }
}
