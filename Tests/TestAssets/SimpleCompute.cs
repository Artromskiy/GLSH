using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class SimpleCompute
    {
        public StructuredBuffer<Matrix4x4> StructuredInput;
        public RWStructuredBuffer<Vector4> StructuredInOut;

        public RWStructuredBuffer<PointLightInfo> RWBufferWithCustomStruct;
        public RWTexture2DResource<float> RWTex;

        public AtomicBufferUInt32 AtomicU32;
        public AtomicBufferInt32 AtomicI32;

        [ComputeEntryPoint(1, 1, 1)]
        public void CS()
        {
            Matrix4x4 m = StructuredInput[DispatchThreadID.y];
            StructuredInOut[DispatchThreadID.x].X = m.M11;
            StructuredInOut[DispatchThreadID.y].Z = 1;

            RWBufferWithCustomStruct[0].Color = new Vector3(1, 2, 3);

            float existing = Load(RWTex, new uint2(10, 20));
            Store(
                RWTex,
                new uint2(10, 20),
                existing + DispatchThreadID.x);

            FuncUsingInterlockedAdd();
        }

        private void FuncUsingInterlockedAdd()
        {
            // Interlocked
            uint originalU32 = InterlockedAdd(AtomicU32, 5, 55);
            originalU32 = InterlockedAdd(AtomicU32, 5u, 55); // unsigned index overload
            int originalI32 = InterlockedAdd(AtomicI32, 5, 55);
            originalI32 = InterlockedAdd(AtomicI32, 5u, 55); // unsigned index overload
        }
    }
}
