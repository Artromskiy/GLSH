using GLSH.Primitives;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class ComplexCompute
    {
        // Not supported by GLSL ES
        public RWTexture2DResource<Vector4> RWTex;

        [ComputeEntryPoint(1, 1, 1)]
        public void CS()
        {
            Vector4 existing = Load(RWTex, new UInt2(10, 20));
            Store(
                RWTex,
                new UInt2(10, 20),
                existing + new Vector4(DispatchThreadID.X, DispatchThreadID.Y, DispatchThreadID.Z, 1));
        }
    }
}
