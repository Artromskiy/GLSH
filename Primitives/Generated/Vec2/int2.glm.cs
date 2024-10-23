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
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(int2 lhs, int2 rhs) => int2.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(int2 lhs, int2 rhs) => int2.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(int2 lhs, int2 rhs) => int2.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(int2 lhs, int2 rhs) => int2.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(int2 lhs, int2 rhs) => int2.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(int2 lhs, int2 rhs) => int2.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Abs (int.Abs(v)).
        /// </summary>
        public static int2 Abs(int2 v) => int2.Abs(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sign (int.Sign(v)).
        /// </summary>
        public static int2 Sign(int2 v) => int2.Sign(v);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Min (int.Min(lhs, rhs)).
        /// </summary>
        public static int2 Min(int2 lhs, int2 rhs) => int2.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Max (int.Max(lhs, rhs)).
        /// </summary>
        public static int2 Max(int2 lhs, int2 rhs) => int2.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (int.Clamp(v, min, max)).
        /// </summary>
        public static int2 Clamp(int2 v, int2 min, int2 max) => int2.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static int2 Mix(int2 x, int2 y, bool2 a) => int2.Mix(x, y, a);
        
        /// <summary>
        /// Returns a float2 from component-wise application of IntBitsToFloat (Unsafe.As&lt;int, float&gt;(ref v)).
        /// </summary>
        public static float2 IntBitsToFloat(int2 v) => int2.IntBitsToFloat(v);
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(int2 v) => v.ToString();

    }
}
