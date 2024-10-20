using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class TestVertexShader
    {
        public Matrix4x4 World;
        public Matrix4x4 View;
        public Matrix4x4 Projection;

        [VertexEntryPoint]
        public VertexOutput VS(PositionTexture input)
        {
            VertexOutput output;
            Vector4 worldPosition = Mul(World, new Vector4(input.Position, 1));
            Vector4 viewPosition = Mul(View, worldPosition);
            output.Position = Mul(Projection, viewPosition);
            output.TextureCoord = input.TextureCoord;
            return output;
        }

        public struct VertexOutput
        {
            [Layout(location: 0)]
            public Vector4 Position;
            [Layout(location: 1)]
            public Vector2 TextureCoord;
        }
    }
}
