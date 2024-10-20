using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type bool with 4 columns and 3 rows.
    /// </summary>
    public static class bool4x3Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<bool> GetEnumerator(this bool4x3 value)
        {
            yield return value.m00;
            yield return value.m01;
            yield return value.m02;
            yield return value.m10;
            yield return value.m11;
            yield return value.m12;
            yield return value.m20;
            yield return value.m21;
            yield return value.m22;
            yield return value.m30;
            yield return value.m31;
            yield return value.m32;
        }

        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static bool[,] GetValues(this bool4x3 value) => new[,] { { value.m00, value.m01, value.m02 }, { value.m10, value.m11, value.m12 }, { value.m20, value.m21, value.m22 }, { value.m30, value.m31, value.m32 } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static bool[] GetValues1D(this bool4x3 value) => new[] { value.m00, value.m01, value.m02, value.m10, value.m11, value.m12, value.m20, value.m21, value.m22, value.m30, value.m31, value.m32 };

        #endregion

    }
}
