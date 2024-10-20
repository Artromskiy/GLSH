using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type double with 4 columns and 4 rows.
    /// </summary>
    public static class double4x4Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<double> GetEnumerator(this double4x4 value)
        {
            yield return value.m00;
            yield return value.m01;
            yield return value.m02;
            yield return value.m03;
            yield return value.m10;
            yield return value.m11;
            yield return value.m12;
            yield return value.m13;
            yield return value.m20;
            yield return value.m21;
            yield return value.m22;
            yield return value.m23;
            yield return value.m30;
            yield return value.m31;
            yield return value.m32;
            yield return value.m33;
        }

        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static double[,] GetValues(this double4x4 value) => new[,] { { value.m00, value.m01, value.m02, value.m03 }, { value.m10, value.m11, value.m12, value.m13 }, { value.m20, value.m21, value.m22, value.m23 }, { value.m30, value.m31, value.m32, value.m33 } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static double[] GetValues1D(this double4x4 value) => new[] { value.m00, value.m01, value.m02, value.m03, value.m10, value.m11, value.m12, value.m13, value.m20, value.m21, value.m22, value.m23, value.m30, value.m31, value.m32, value.m33 };

        #endregion

    }
}
