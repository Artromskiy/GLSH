using System.Numerics;
using System.Runtime.InteropServices;
using GLSH.Primitives;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets.CustomStructResource
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CustomBlittableStruct
    {
        public Vector3 F3_0;
        private float _padding0;
        public Vector2 F2_1;
        private float _padding1;
        private float _padding2;
        public Vector4 F4_2;
        public float F1_3;
        private float _padding3;
        public Vector2 F2_4;
    }
}
