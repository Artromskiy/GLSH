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
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int4 lhs, int4 rhs) => int4.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int4 lhs, int4 rhs) => int4.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int4 lhs, int4 rhs) => int4.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int4 lhs, int4 rhs) => int4.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int4 lhs, int4 rhs) => int4.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int4 lhs, int4 rhs) => int4.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Abs (int.Abs(v)).
        /// </summary>
        public static int4 Abs(int4 v) => int4.Abs(v);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Sign (int.Sign(v)).
        /// </summary>
        public static int4 Sign(int4 v) => int4.Sign(v);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Min (int.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int4 lhs, int4 rhs) => int4.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Max (int.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int4 lhs, int4 rhs) => int4.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (int.Clamp(v, min, max)).
        /// </summary>
        public static int4 Clamp(int4 v, int4 min, int4 max) => int4.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a int4 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static int4 Mix(int4 x, int4 y, bool4 a) => int4.Mix(x, y, a);
        
        /// <summary>
        /// Returns a float4 from component-wise application of IntBitsToFloat (Unsafe.As&lt;int, float&gt;(ref v)).
        /// </summary>
        public static float4 IntBitsToFloat(int4 v) => int4.IntBitsToFloat(v);
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(int4 v) => v.ToString();

    }
}
