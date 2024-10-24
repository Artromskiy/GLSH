// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(bool4 lhs, bool4 rhs) => bool4.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(bool4 lhs, bool4 rhs) => bool4.NotEqual(lhs, rhs);

        /// <summary>
        /// 
        /// </summary>
        public static bool Any(bool4 v) => bool4.Any(v);

        /// <summary>
        /// 
        /// </summary>
        public static bool All(bool4 v) => bool4.All(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of Not (!v).
        /// </summary>
        public static bool4 Not(bool4 v) => bool4.Not(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static bool4 Mix(bool4 x, bool4 y, bool4 a) => bool4.Mix(x, y, a);

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(bool4 v) => v.ToString();

    }
}
