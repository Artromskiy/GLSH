using GLSH.Primitives;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class BuiltInVariables
    {
        [VertexShader]
        SystemPosition4 VS()
        {
            uint vertexID = ShaderBuiltins.VertexID;
            uint instanceID = InstanceID;

            SystemPosition4 output;
            output.Position = new Vector4(vertexID, instanceID, ShaderBuiltins.VertexID, 1);
            return output;
        }
    }
}
