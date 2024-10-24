using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{

    /// <summary>
    /// A vector of type double with 2 components.
    /// </summary>
    public static class double2Extensions
    {

        #region ExtensionFunctions

        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public static double[] GetValues(this double2 value) => new[] { value.x, value.y };

        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<double> GetEnumerator(this double2 value)
        {
            yield return value.x;
            yield return value.y;
        }

        #endregion

    }
}
