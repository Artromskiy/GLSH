using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public struct PositionTexture
    {
        [Layout(location: 0)]
        public Vector3 Position;
        [Layout(location: 1)]
        public Vector2 TextureCoord;
    }

    public struct Position4Texture2
    {
        [Layout(location: 0)] public Vector4 Position;
        [Layout(location: 1)] public Vector2 TextureCoord;
    }

    public struct SystemPosition4Texture2
    {
        [Layout(location: 0)] public Vector4 Position;
        [Layout(location: 1)] public Vector2 TextureCoord;
    }
}
