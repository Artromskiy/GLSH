using GLSH.Primitives;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets
{
    public struct PositionTexture
    {
        [PositionSemantic]
        public Vector3 Position;
        [TextureCoordinateSemantic]
        public Vector2 TextureCoord;
    }

    public struct Position4Texture2
    {
        [PositionSemantic] public Vector4 Position;
        [TextureCoordinateSemantic] public Vector2 TextureCoord;
    }

    public struct SystemPosition4Texture2
    {
        [SystemPositionSemantic] public Vector4 Position;
        [TextureCoordinateSemantic] public Vector2 TextureCoord;
    }
}
