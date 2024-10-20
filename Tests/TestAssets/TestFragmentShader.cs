using GLSH.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class TestFragmentShader
    {
        [FragmentEntryPoint]
        public Vector4 FS(VertexOutput input)
        {
            return input.Color;
        }

        public struct VertexOutput
        {
            [Layout(location: 0)]
            public Vector4 Position;
            [Layout(location: 1)]
            public Vector4 Color;
        }
    }
}
