using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(uint4 lhs, uint4 rhs) => uint4.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(uint4 lhs, uint4 rhs) => uint4.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(uint4 lhs, uint4 rhs) => uint4.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(uint4 lhs, uint4 rhs) => uint4.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(uint4 lhs, uint4 rhs) => uint4.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(uint4 lhs, uint4 rhs) => uint4.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Min (uint.Min(lhs, rhs)).
        /// </summary>
        public static uint4 Min(uint4 lhs, uint4 rhs) => uint4.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Max (uint.Max(lhs, rhs)).
        /// </summary>
        public static uint4 Max(uint4 lhs, uint4 rhs) => uint4.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Clamp (uint.Clamp(v, min, max)).
        /// </summary>
        public static uint4 Clamp(uint4 v, uint4 min, uint4 max) => uint4.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Clamp (uint.Clamp(v, min, max)).
        /// </summary>
        public static uint4 Clamp(uint4 v, uint min, uint max) => uint4.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static uint4 Mix(uint4 x, uint4 y, bool4 a) => uint4.Mix(x, y, a);
        
        /// <summary>
        /// Returns a float4 from component-wise application of UIntBitsToFloat (Unsafe.As&lt;uint, float&gt;(ref v)).
        /// </summary>
        public static float4 UIntBitsToFloat(uint4 v) => uint4.UIntBitsToFloat(v);
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(uint4 v) => v.ToString();

    }
}
