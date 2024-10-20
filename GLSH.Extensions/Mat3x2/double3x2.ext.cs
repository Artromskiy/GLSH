using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type double with 3 columns and 2 rows.
    /// </summary>
    public static class double3x2Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<double> GetEnumerator(this double3x2 value)
        {
            yield return value.m00;
            yield return value.m01;
            yield return value.m10;
            yield return value.m11;
            yield return value.m20;
            yield return value.m21;
        }

        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static double[,] GetValues(this double3x2 value) => new[,] { { value.m00, value.m01 }, { value.m10, value.m11 }, { value.m20, value.m21 } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static double[] GetValues1D(this double3x2 value) => new[] { value.m00, value.m01, value.m10, value.m11, value.m20, value.m21 };

        #endregion

    }
}
