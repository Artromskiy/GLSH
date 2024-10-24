using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A vector of type uint with 4 components.
    /// </summary>
    public static class uint4Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public static uint[] GetValues(this uint4 value) => new[] { value.x, value.y, value.z, value.w };

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<uint> GetEnumerator(this uint4 value)
        {
            yield return value.x;
            yield return value.y;
            yield return value.z;
            yield return value.w;
        }

        #endregion

    }
}
