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
        public static double3x3 Transpose(double3x3 v) => double3x3.Transpose(v);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public static double3x3 Inverse(double3x3 v) => double3x3.Inverse(v);

        /// <summary>
        /// 
        /// </summary>
        public static double Determinant(double3x3 v) => double3x3.Determinant(v);

    }
}
