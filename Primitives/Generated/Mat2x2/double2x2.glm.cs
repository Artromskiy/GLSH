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
        public static double2x2 Transpose(double2x2 v) => double2x2.Transpose(v);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public static double2x2 Inverse(double2x2 v) => double2x2.Inverse(v);

        /// <summary>
        /// 
        /// </summary>
        public static double Determinant(double2x2 v) => double2x2.Determinant(v);

    }
}
