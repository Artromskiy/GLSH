using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A vector of type int with 3 components.
    /// </summary>
    public static class int3Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public static int[] GetValues(this int3 value) => new[] { value.x, value.y, value.z };

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<int> GetEnumerator(this int3 value)
        {
            yield return value.x;
            yield return value.y;
            yield return value.z;
        }

        #endregion

    }
}
