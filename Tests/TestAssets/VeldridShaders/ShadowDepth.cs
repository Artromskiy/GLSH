using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;
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
            [Layout(location: 0)] public Vector3 Position;
            [Layout(location: 1)] public Vector3 Normal;
            [Layout(location: 2)] public Vector2 TexCoord;
        }

        public struct FragmentInput
        {
            [Layout(location: 0)]
            public Vector4 Position;
        }
    }
}
