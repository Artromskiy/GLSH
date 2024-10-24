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
        public static float4x4 Transpose(float4x4 v) => float4x4.Transpose(v);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public static float4x4 Inverse(float4x4 v) => float4x4.Inverse(v);

        /// <summary>
        /// 
        /// </summary>
        public static float Determinant(float4x4 v) => float4x4.Determinant(v);

    }
}
