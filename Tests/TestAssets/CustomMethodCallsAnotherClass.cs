using static GLSH.ShaderBuiltins;

namespace Tests.TestAssets
{
    public static class AnotherClass
    {
        public static float CustomAbs(float v)
        {
            return HelperMethod(v);
        }

        public static float HelperMethod(float v)
        {
            return Abs(v);
        }
    }
}
