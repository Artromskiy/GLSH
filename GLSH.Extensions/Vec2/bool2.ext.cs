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
    /// A vector of type bool with 2 components.
    /// </summary>
    public static class bool2Extensions
    {

        #region ExtensionFunctions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public static bool[] GetValues(this bool2 value) => new[] { value.x, value.y };
        
        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<bool> GetEnumerator(this bool2 value)
        {
            yield return value.x;
            yield return value.y;
        }

        #endregion

    }
}
