using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

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
            [VertexSemantic(SemanticType.SystemPosition)]
            public Vector4 Position;
            [VertexSemantic(SemanticType.TextureCoordinate)]
            public Vector2 TextureCoord;
        }
    }
}
