﻿using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class ComplexExpression
    {
        public struct FragmentInput
        {
            [Layout(location: 0)]
            public Vector4 Position;
            [Layout(location: 1)]
            public Vector2 TextureCoordinate;
        }

        public struct TintInfo
        {
            public Vector3 Color;
            public float Factor;
        }

        public TintInfo Tint;
        public Texture2DResource Texture;
        public SamplerResource Sampler;

        [FragmentEntryPoint]
        public Vector4 FS(FragmentInput input)
        {
            float tintAlpha = 1 == 1
                ? 1.0f
                : 0.0f;

            Vector4 tintValue = new Vector4(Tint.Color, tintAlpha);
            Vector4 textureValue = Sample(Texture, Sampler, input.TextureCoordinate);
            return tintValue * Tint.Factor + textureValue * (1 - Tint.Factor);
        }
    }
}
