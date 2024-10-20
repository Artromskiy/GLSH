using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class StructuredBufferTestShader
    {
        public StructuredBuffer<Matrix4x4> StructuredInput;
        public StructuredBuffer<TestStructure> TestStructures;

        [VertexEntryPoint]
        public VertexOutput VS(PositionTexture input)
        {
            Matrix4x4 World = StructuredInput[0];
            Matrix4x4 View = StructuredInput[1];
            Matrix4x4 Projection = StructuredInput[2];

            VertexOutput output;
            Vector4 worldPosition = Mul(World, new Vector4(input.Position, 1));
            Vector4 viewPosition = Mul(View, worldPosition);
            output.Position = Mul(Projection, viewPosition);
            output.TextureCoord = input.TextureCoord;
            return output;
        }

        [FragmentEntryPoint]
        public Vector4 FS(VertexOutput input)
        {
            Vector4 ret = new Vector4(
                StructuredInput[0].M11,
                StructuredInput[2].M12,
                StructuredInput[2].M13,
                StructuredInput[3].M14);
            return ret;
        }

        public struct VertexOutput
        {
            [Layout(location: 0)]
            public Vector4 Position;
            [Layout(location: 1)]
            public Vector2 TextureCoord;
        }

        public struct TestStructure
        {
            public Vector4 X;
            public Vector2 Y;
            public Vector2 Z;
            public Vector4 W;
        }
    }

}
