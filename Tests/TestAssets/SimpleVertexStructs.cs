using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public struct Position4
    {
        [Layout(location: 0)] public Vector4 Position;
    }

    public struct SystemPosition4
    {
        [Layout(location: 0)] public Vector4 Position;
    }
}
