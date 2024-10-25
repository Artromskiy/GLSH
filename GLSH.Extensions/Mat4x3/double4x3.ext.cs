using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace GLSH.Extensions
{
    
    /// <summary>
    /// A matrix of type double with 4 columns and 3 rows.
    /// </summary>
    public static class double4x3Extensions
    {

        #region ExtensionFunctions
        
        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<double> GetEnumerator(this double4x3 value)
        {
            yield return value[0, 0];
            yield return value[0, 1];
            yield return value[0, 2];
            yield return value[1, 0];
            yield return value[1, 1];
            yield return value[1, 2];
            yield return value[2, 0];
            yield return value[2, 1];
            yield return value[2, 2];
            yield return value[3, 0];
            yield return value[3, 1];
            yield return value[3, 2];
        }
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static double[,] GetValues(this double4x3 value) => new[,] { { value[0, 0], value[0, 1], value[0, 2] }, { value[1, 0], value[1, 1], value[1, 2] }, { value[2, 0], value[2, 1], value[2, 2] }, { value[3, 0], value[3, 1], value[3, 2] } };
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static double[] GetValues1D(this double4x3 value) => new[] { value[0, 0], value[0, 1], value[0, 2], value[1, 0], value[1, 1], value[1, 2], value[2, 0], value[2, 1], value[2, 2], value[3, 0], value[3, 1], value[3, 2] };

        #endregion

    }
}
