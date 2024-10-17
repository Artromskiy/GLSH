using GLSH.Primitives;
using GLSH.Primitives.Attributes;
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
            [VertexSemantic(SemanticType.SystemPosition)]
            public Vector4 Position;
            [VertexSemantic(SemanticType.Color)]
            public Vector4 Color;
        }
    }
}
