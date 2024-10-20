using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class MissingInputSemantics
    {
        public Matrix4x4 World;
        public Matrix4x4 View;
        public Matrix4x4 Projection;

        // Not a real uniform.
        public Matrix4x4 NotARealUniformField;

        [VertexEntryPoint]
        public VertexOutput VS(VertexNoSemantics input)
        {
            VertexOutput output;
            Vector4 worldPosition = Mul(World, new Vector4(input.Position, 1));
            Vector4 viewPosition = Mul(View, worldPosition);
            output.Position = Mul(Projection, viewPosition);
            output.TextureCoord = input.TextureCoord;
            return output;
        }

        public struct VertexNoSemantics
        {
            public Vector3 Position;
            public Vector2 TextureCoord;
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
