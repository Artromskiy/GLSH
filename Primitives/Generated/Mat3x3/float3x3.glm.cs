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
        public static float3x3 Transpose(float3x3 v) => float3x3.Transpose(v);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public static float3x3 Inverse(float3x3 v) => float3x3.Inverse(v);

        /// <summary>
        /// 
        /// </summary>
        public static float Determinant(float3x3 v) => float3x3.Determinant(v);

    }
}
