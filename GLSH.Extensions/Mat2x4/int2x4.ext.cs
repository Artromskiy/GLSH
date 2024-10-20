using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type int with 2 columns and 4 rows.
    /// </summary>
    public static class int2x4Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<int> GetEnumerator(this int2x4 value)
        {
            yield return value.m00;
            yield return value.m01;
            yield return value.m02;
            yield return value.m03;
            yield return value.m10;
            yield return value.m11;
            yield return value.m12;
            yield return value.m13;
        }

        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static int[,] GetValues(this int2x4 value) => new[,] { { value.m00, value.m01, value.m02, value.m03 }, { value.m10, value.m11, value.m12, value.m13 } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static int[] GetValues1D(this int2x4 value) => new[] { value.m00, value.m01, value.m02, value.m03, value.m10, value.m11, value.m12, value.m13 };

        #endregion

    }
}
