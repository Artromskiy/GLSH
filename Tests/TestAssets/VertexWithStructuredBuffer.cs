using GLSH.Primitives;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class VertexWithStructuredBuffer
    {
        public RWStructuredBuffer<Vector4> Vectors;

        [VertexShader]
        public SystemPosition4 VS()
        {
            SystemPosition4 output;
            output.Position = UseStructuredBufferIndirect(ShaderBuiltins.VertexID);
            return output;
        }

        public Vector4 UseStructuredBufferIndirect(uint id)
        {
            return Vectors[id];
        }
    }
}
