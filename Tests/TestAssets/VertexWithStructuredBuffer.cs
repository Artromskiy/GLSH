using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class VertexWithStructuredBuffer
    {
        public RWStructuredBuffer<Vector4> Vectors;

        [VertexEntryPoint]
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
