using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A matrix of type float with 3 columns and 2 rows.
    /// </summary>
    public static class float3x2Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<float> GetEnumerator(this float3x2 value)
        {
            yield return value[0, 0];
            yield return value[0, 1];
            yield return value[1, 0];
            yield return value[1, 1];
            yield return value[2, 0];
            yield return value[2, 1];
        }

        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static float[,] GetValues(this float3x2 value) => new[,] { { value[0, 0], value[0, 1] }, { value[1, 0], value[1, 1] }, { value[2, 0], value[2, 1] } };

        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static float[] GetValues1D(this float3x2 value) => new[] { value[0, 0], value[0, 1], value[1, 0], value[1, 1], value[2, 0], value[2, 1] };

        #endregion

    }
}
