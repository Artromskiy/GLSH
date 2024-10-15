using GLSH.Primitives;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets
{
    public struct Position4
    {
        [PositionSemantic] public Vector4 Position;
    }

    public struct SystemPosition4
    {
        [SystemPositionSemantic] public Vector4 Position;
    }
}
