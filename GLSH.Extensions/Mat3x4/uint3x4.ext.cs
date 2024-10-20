using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type uint with 3 columns and 4 rows.
    /// </summary>
    public static class uint3x4Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<uint> GetEnumerator(this uint3x4 value)
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
        }

        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static uint[,] GetValues(this uint3x4 value) => new[,] { { value.m00, value.m01, value.m02, value.m03 }, { value.m10, value.m11, value.m12, value.m13 }, { value.m20, value.m21, value.m22, value.m23 } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static uint[] GetValues1D(this uint3x4 value) => new[] { value.m00, value.m01, value.m02, value.m03, value.m10, value.m11, value.m12, value.m13, value.m20, value.m21, value.m22, value.m23 };

        #endregion

    }
}
