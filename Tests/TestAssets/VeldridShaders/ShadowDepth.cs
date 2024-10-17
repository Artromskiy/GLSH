using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;
namespace Tests.TestAssets.VeldridShaders
{
    public class ShadowDepth
    {
        public Matrix4x4 Projection;
        public Matrix4x4 View;
        public Matrix4x4 World;

        [VertexEntryPoint]
        public FragmentInput VS(VertexInput input)
        {
            FragmentInput output;
            output.Position = Mul(Projection, Mul(View, Mul(World, new Vector4(input.Position, 1))));
            return output;
        }

        [FragmentEntryPoint]
        public void FS(FragmentInput input) { }

        public struct VertexInput
        {
            [VertexSemantic(SemanticType.Position)] public Vector3 Position;
            [VertexSemantic(SemanticType.Normal)] public Vector3 Normal;
            [VertexSemantic(SemanticType.TextureCoordinate)] public Vector2 TexCoord;
        }

        public struct FragmentInput
        {
            [VertexSemantic(SemanticType.SystemPosition)]
            public Vector4 Position;
        }
    }
}
