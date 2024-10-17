using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System;
using System.Numerics;

namespace Tests.TestAssets
{
    public class MathFunctions
    {
        [VertexEntryPoint]
        public SystemPosition4 VS(Position4 input)
        {
            SystemPosition4 output;
            float a = MathF.Max(0f, 10f);
            float b = MathF.Min(0f, 10f);
            float c = MathF.Pow(2, 10);
            output.Position = new Vector4(a, b, c, 1);
            return output;
        }
    }
}
