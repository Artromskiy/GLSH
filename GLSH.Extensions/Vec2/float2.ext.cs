using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A vector of type float with 2 components.
    /// </summary>
    public static class float2Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public static float[] GetValues(this float2 value) => new[] { value.x, value.y };

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<float> GetEnumerator(this float2 value)
        {
            yield return value.x;
            yield return value.y;
        }

        #endregion

    }
}
