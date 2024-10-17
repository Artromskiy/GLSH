using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public struct PositionTexture
    {
        [VertexSemantic(SemanticType.Position)]
        public Vector3 Position;
        [VertexSemantic(SemanticType.TextureCoordinate)]
        public Vector2 TextureCoord;
    }

    public struct Position4Texture2
    {
        [VertexSemantic(SemanticType.Position)] public Vector4 Position;
        [VertexSemantic(SemanticType.TextureCoordinate)] public Vector2 TextureCoord;
    }

    public struct SystemPosition4Texture2
    {
        [VertexSemantic(SemanticType.SystemPosition)] public Vector4 Position;
        [VertexSemantic(SemanticType.TextureCoordinate)] public Vector2 TextureCoord;
    }
}
