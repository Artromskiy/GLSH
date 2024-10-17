using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;

namespace Tests.TestAssets
{
    public class ExpressionBodiedMethods
    {
        [FragmentEntryPoint]
        public Vector4 ExpressionBodyWithReturn()
            => new Vector4(0f, 0f, 0f, 1f);

        [FragmentEntryPoint]
        public void ExpressionBodyWithoutReturn()
            => new Vector4(0f, 0f, 0f, 1f);
    }
}
