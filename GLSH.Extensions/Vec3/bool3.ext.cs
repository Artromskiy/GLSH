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
    /// A vector of type bool with 3 components.
    /// </summary>
    public static class bool3Extensions
    {

        #region ExtensionFunctions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public static bool[] GetValues(this bool3 value) => new[] { value.x, value.y, value.z };
        
        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<bool> GetEnumerator(this bool3 value)
        {
            yield return value.x;
            yield return value.y;
            yield return value.z;
        }

        #endregion

    }
}