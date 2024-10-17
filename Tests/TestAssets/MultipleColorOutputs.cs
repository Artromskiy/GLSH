using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class MultipleColorOutputs
    {
        [VertexEntryPoint]
        public SystemPosition4 VS(Position4 input)
        {
            SystemPosition4 output;
            output.Position = input.Position;
            return output;
        }

        [FragmentEntryPoint]
        public DualOutput FS(SystemPosition4 input)
        {
            DualOutput output;
            output.FirstOutput = new Vector4(input.Position.X, input.Position.Y, input.Position.Z, 1);
            output.SecondOutput = new Vector4(input.Position.Z, input.Position.X, input.Position.Y, 1);
            return output;
        }

        public struct DualOutput
        {
            [VertexSemantic(SemanticType.ColorTarget)]
            public Vector4 FirstOutput;
            [VertexSemantic(SemanticType.ColorTarget)]
            public Vector4 SecondOutput;
        }
    }
}
