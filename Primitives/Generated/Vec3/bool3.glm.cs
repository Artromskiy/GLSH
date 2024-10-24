// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool3 lhs, bool3 rhs) => bool3.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool3 lhs, bool3 rhs) => bool3.NotEqual(lhs, rhs);

        /// <summary>
        /// 
        /// </summary>
        public static bool Any(bool3 v) => bool3.Any(v);

        /// <summary>
        /// 
        /// </summary>
        public static bool All(bool3 v) => bool3.All(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of Not (!v).
        /// </summary>
        public static bool3 Not(bool3 v) => bool3.Not(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static bool3 Mix(bool3 x, bool3 y, bool3 a) => bool3.Mix(x, y, a);

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(bool3 v) => v.ToString();

    }
}
