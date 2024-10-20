using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type double with 2 columns and 2 rows.
    /// </summary>
    public static class double2x2Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<double> GetEnumerator(this double2x2 value)
        {
            yield return value.m00;
            yield return value.m01;
            yield return value.m10;
            yield return value.m11;
        }

        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static double[,] GetValues(this double2x2 value) => new[,] { { value.m00, value.m01 }, { value.m10, value.m11 } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static double[] GetValues1D(this double2x2 value) => new[] { value.m00, value.m01, value.m10, value.m11 };

        #endregion

    }
}
