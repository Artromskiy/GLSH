﻿using GLSH;
using GLSH.Attributes;
using System.Numerics;
using System.Runtime.InteropServices;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class ShaderBuiltinsTestShader
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct VectorHolder
        {
            public Matrix4x4 M4x4;
            public Vector4 V4;
            public Vector2 V2;
            private readonly float _padding0;
            private readonly float _padding1;
            public Vector3 V3;
        }

        public VectorHolder VH;

        [VertexEntryPoint]
        public SystemPosition4 VS(Position4 input)
        {
            float f = 0;

            float r = 0;
            Vector2 r2 = new Vector2(0, 0);
            Vector3 r3 = new Vector3(0, 0, 0);
            Vector4 r4 = new Vector4(0, 0, 0, 0);

            // Abs
            r = Abs(f);
            r2 = Abs(VH.V2);
            r3 = Abs(VH.V3);
            r4 = Abs(VH.V4);

            // Acos
            r = Acos(f);
            r2 = Acos(VH.V2);
            r3 = Acos(VH.V3);
            r4 = Acos(VH.V4);

            // Clamp
            r = Clamp(f, 0, 10);
            r2 = Clamp(VH.V2, new Vector2(0, 0), new Vector2(10, 10));
            r3 = Clamp(VH.V3, new Vector3(0, 0, 0), new Vector3(10, 10, 10));
            r4 = Clamp(VH.V4, new Vector4(0, 0, 0, 0), new Vector4(10, 10, 10, 10));

            // Cos
            r = Cos(f);
            r2 = Cos(VH.V2);
            r3 = Cos(VH.V3);
            r4 = Cos(VH.V4);

            // Floor
            r = Floor(f);
            r2 = Floor(VH.V2);
            r3 = Floor(VH.V3);
            r4 = Floor(VH.V4);

            // Frac
            r = Frac(f);
            r2 = Frac(VH.V2);
            r3 = Frac(VH.V3);
            r4 = Frac(VH.V4);

            // Lerp
            r = Lerp(f, f, f);
            r2 = Lerp(VH.V2, VH.V2, f);
            r3 = Lerp(VH.V3, VH.V3, f);
            r4 = Lerp(VH.V4, VH.V4, f);

            // Pow
            r = Pow(f, 10);
            r2 = Pow(VH.V2, new Vector2(10, 12));
            r3 = Pow(VH.V3, new Vector3(10, 12, 14));
            r4 = Pow(VH.V4, new Vector4(10, 12, 14, 16));

            // Saturate
            r = Clamp(f, 0, 1);
            r2 = Clamp(VH.V2, 0, 1);
            r3 = Clamp(VH.V3, 0, 1);
            r4 = Clamp(VH.V4, 0, 1);

            // Sin
            r = Sin(f);
            r2 = Sin(VH.V2);
            r3 = Sin(VH.V3);
            r4 = Sin(VH.V4);

            // SmoothStep
            r = SmoothStep(1f, 2f, f);
            r2 = SmoothStep(new Vector2(1f, 1f), new Vector2(2f, 2f), VH.V2);
            r3 = SmoothStep(new Vector3(1f, 1f, 1f), new Vector3(2f, 2f, 2f), VH.V3);
            r4 = SmoothStep(new Vector4(1f, 1f, 1f, 1f), new Vector4(2f, 2f, 2f, 2f), VH.V4);

            // Tan
            r = Tan(f);
            r2 = Tan(VH.V2);
            r3 = Tan(VH.V3);
            r4 = Tan(VH.V4);

            // Mod
            r = Mod(f, 2);
            r2 = Mod(VH.V2, new Vector2(2, 4));
            r3 = Mod(VH.V3, new Vector3(2, 4, 6));
            r4 = Mod(VH.V4, new Vector4(2, 4, 6, 8));

            // ClipToTextureCoordinates
            r2 = ClipToTextureCoordinates(VH.V4);
            Vector4 v4 = VH.V4;
            r2 = ClipToTextureCoordinates(v4);

            SystemPosition4 output;
            output.Position = input.Position;

            return output;
        }

        [FragmentEntryPoint]
        public Vector4 FS(SystemPosition4 input)
        {
            Vector4 ret = Vector4.Zero;
            if (IsFrontFace)
            {
                ret += Vector4.One;
            }

            // Ddx
            float r = Ddx(ret.X);
            Vector2 r2 = Ddx(ret.XY());
            Vector3 r3 = Ddx(ret.XYZ());
            Vector4 r4 = Ddx(ret);

            // DdxFine
            r = DdxFine(ret.X);
            r2 = DdxFine(ret.XY());
            r3 = DdxFine(ret.XYZ());
            r4 = DdxFine(ret);

            // Ddy
            r = Ddy(ret.X);
            r2 = Ddy(ret.XY());
            r3 = Ddy(ret.XYZ());
            r4 = Ddy(ret);

            // DdyFine
            r = DdyFine(ret.X);
            r2 = DdyFine(ret.XY());
            r3 = DdyFine(ret.XYZ());
            r4 = DdyFine(ret);

            return ret;
        }
    }
}
