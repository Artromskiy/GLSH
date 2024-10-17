using System.Numerics;
using System.Runtime.InteropServices;

namespace Tests.TestAssets.CustomStructResource
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CustomBlittableStruct
    {
        public Vector3 F3_0;
        private readonly float _padding0;
        public Vector2 F2_1;
        private readonly float _padding1;
        private readonly float _padding2;
        public Vector4 F4_2;
        public float F1_3;
        private readonly float _padding3;
        public Vector2 F2_4;
    }
}
