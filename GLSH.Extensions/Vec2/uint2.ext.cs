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
    /// A vector of type uint with 2 components.
    /// </summary>
    public static class uint2Extensions
    {

        #region ExtensionFunctions
        
        /// <summary>
        /// Returns an array with all values
        /// </summary>
        public static uint[] GetValues(this uint2 value) => new[] { value.x, value.y };
        
        /// <summary>
        /// Returns an enumerator that iterates through all fields.
        /// </summary>
        public static IEnumerator<uint> GetEnumerator(this uint2 value)
        {
            yield return value.x;
            yield return value.y;
        }

        #endregion

    }
}
