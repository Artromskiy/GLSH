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
    /// A matrix of type float with 2 columns and 2 rows.
    /// </summary>
    public static class float2x2Extensions
    {

        #region ExtensionFunctions
        
        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<float> GetEnumerator(this float2x2 value)
        {
            yield return value.m00;
            yield return value.m01;
            yield return value.m10;
            yield return value.m11;
        }
        
        /// <summary>
        /// Creates a 2D array with all values (address: Values[x, y])
        /// </summary>
        public static float[,] GetValues(this float2x2 value) => new[,] { { value.m00, value.m01 }, { value.m10, value.m11 } };
        
        /// <summary>
        /// Creates a 1D array with all values (internal order)
        /// </summary>
        public static float[] GetValues1D(this float2x2 value) => new[] { value.m00, value.m01, value.m10, value.m11 };

        #endregion

    }
}
