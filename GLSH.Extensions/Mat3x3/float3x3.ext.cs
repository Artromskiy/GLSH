using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type float with 3 columns and 3 rows.
    /// </summary>
    public static class float3x3Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<float> GetEnumerator(this float3x3 value)
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
        }

        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static float[,] GetValues(this float3x3 value) => new[,] { { value.m00, value.m01, value.m02 }, { value.m10, value.m11, value.m12 }, { value.m20, value.m21, value.m22 } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static float[] GetValues1D(this float3x3 value) => new[] { value.m00, value.m01, value.m02, value.m10, value.m11, value.m12, value.m20, value.m21, value.m22 };

        #endregion

    }
}
