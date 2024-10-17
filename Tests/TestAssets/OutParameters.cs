using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class OutParameters
    {
        private void MyFunc(Vector4 position, ref Vector2 xy, out Vector2 zw)
        {
            xy = position.XY();
            zw = position.ZW();
        }

        [VertexEntryPoint]
        public SystemPosition4 VS(Position4 input)
        {
            Vector2 xy = Vector2.Zero;
            Vector2 zw;
            MyFunc(input.Position, ref xy, out zw);

            MyFunc(input.Position, ref xy, out var zw2);
            zw += zw2;

            MyFunc(input.Position, ref xy, out _);
            MyFunc(input.Position, ref xy, out _);

            SystemPosition4 output;
            output.Position.X = xy.X;
            output.Position.Y = xy.Y;
            output.Position.Z = zw.X;
            output.Position.W = zw.Y;
            return output;
        }
    }
}
