using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type bool with 3 columns and 2 rows.
    /// </summary>
    public static class bool3x2Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<bool> GetEnumerator(this bool3x2 value)
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
        public static bool[,] GetValues(this bool3x2 value) => new[,] { { value.m00, value.m01 }, { value.m10, value.m11 }, { value.m20, value.m21 } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static bool[] GetValues1D(this bool3x2 value) => new[] { value.m00, value.m01, value.m10, value.m11, value.m20, value.m21 };

        #endregion

    }
}
