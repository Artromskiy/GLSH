using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public struct Position4
    {
        [VertexSemantic(SemanticType.Position)] public Vector4 Position;
    }

    public struct SystemPosition4
    {
        [VertexSemantic(SemanticType.SystemPosition)] public Vector4 Position;
    }
}
