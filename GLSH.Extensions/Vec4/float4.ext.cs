using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A vector of type float with 4 components.
    /// </summary>
    public static class float4Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public static float[] GetValues(this float4 value) => new[] { value.x, value.y, value.z, value.w };

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<float> GetEnumerator(this float4 value)
        {
            yield return value.x;
            yield return value.y;
            yield return value.z;
            yield return value.w;
        }

        #endregion

    }
}
