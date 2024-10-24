// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(bool2 lhs, bool2 rhs) => bool2.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(bool2 lhs, bool2 rhs) => bool2.NotEqual(lhs, rhs);

        /// <summary>
        /// 
        /// </summary>
        public static bool Any(bool2 v) => bool2.Any(v);

        /// <summary>
        /// 
        /// </summary>
        public static bool All(bool2 v) => bool2.All(v);

        /// <summary>
        /// Returns a bool2 from component-wise application of Not (!v).
        /// </summary>
        public static bool2 Not(bool2 v) => bool2.Not(v);

        /// <summary>
        /// Returns a bool2 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static bool2 Mix(bool2 x, bool2 y, bool2 a) => bool2.Mix(x, y, a);

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(bool2 v) => v.ToString();

    }
}
