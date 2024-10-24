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
        public static double4x4 Transpose(double4x4 v) => double4x4.Transpose(v);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public static double4x4 Inverse(double4x4 v) => double4x4.Inverse(v);

        /// <summary>
        /// 
        /// </summary>
        public static double Determinant(double4x4 v) => double4x4.Determinant(v);

    }
}
