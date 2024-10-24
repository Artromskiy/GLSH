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
        public static bool2 GreaterThan(uint2 lhs, uint2 rhs) => uint2.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint2 lhs, uint2 rhs) => uint2.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint2 lhs, uint2 rhs) => uint2.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint2 lhs, uint2 rhs) => uint2.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint2 lhs, uint2 rhs) => uint2.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint2 lhs, uint2 rhs) => uint2.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Min (uint.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint2 lhs, uint2 rhs) => uint2.Min(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Max (uint.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint2 lhs, uint2 rhs) => uint2.Max(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (uint.Clamp(v, min, max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint2 min, uint2 max) => uint2.Clamp(v, min, max);

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (uint.Clamp(v, min, max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint min, uint max) => uint2.Clamp(v, min, max);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static uint2 Mix(uint2 x, uint2 y, bool2 a) => uint2.Mix(x, y, a);

        /// <summary>
        /// Returns a float2 from component-wise application of UIntBitsToFloat (Unsafe.As&lt;uint, float&gt;(ref v)).
        /// </summary>
        public static float2 UIntBitsToFloat(uint2 v) => uint2.UIntBitsToFloat(v);

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(uint2 v) => v.ToString();

    }
}
