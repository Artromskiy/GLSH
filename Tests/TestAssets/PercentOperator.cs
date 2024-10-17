using GLSH.Primitives;
using GLSH.Primitives.Attributes;

namespace Tests.TestAssets
{
    public class PercentOperator
    {
        [VertexEntryPoint]
        public SystemPosition4 PercentEqualsVS(Position4 input)
        {
            float x = 5;
            x %= input.Position.Y;
            SystemPosition4 output;
            output.Position = input.Position;
            return output;
        }
    }
}
