using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class BuiltInVariables
    {
        [VertexEntryPoint]
        private SystemPosition4 VS()
        {
            uint vertexID = ShaderBuiltins.VertexID;
            uint instanceID = InstanceID;

            SystemPosition4 output;
            output.Position = new Vector4(vertexID, instanceID, ShaderBuiltins.VertexID, 1);
            return output;
        }
    }
}
