// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {

        /// <summary>
        /// 
        /// </summary>
        public static float2x2 Transpose(float2x2 v) => float2x2.Transpose(v);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public static float2x2 Inverse(float2x2 v) => float2x2.Inverse(v);

        /// <summary>
        /// 
        /// </summary>
        public static float Determinant(float2x2 v) => float2x2.Determinant(v);

    }
}
