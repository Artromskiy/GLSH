using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class ComplexCompute
    {
        // Not supported by GLSL ES
        public RWTexture2DResource<Vector4> RWTex;

        [ComputeEntryPoint(1, 1, 1)]
        public void CS()
        {
            Vector4 existing = Load(RWTex, new uint2(10, 20));
            Store(
                RWTex,
                new uint2(10, 20),
                existing + new Vector4(DispatchThreadID.x, DispatchThreadID.y, DispatchThreadID.z, 1));
        }
    }
}
