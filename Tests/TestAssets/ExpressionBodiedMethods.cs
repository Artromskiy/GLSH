using GLSH.Primitives;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Tests.TestAssets
{
    public class ExpressionBodiedMethods
    {
        [FragmentShader]
        public Vector4 ExpressionBodyWithReturn()
            => new Vector4(0f, 0f, 0f, 1f);

        [FragmentShader]
        public void ExpressionBodyWithoutReturn()
            => new Vector4(0f, 0f, 0f, 1f);
    }
}
