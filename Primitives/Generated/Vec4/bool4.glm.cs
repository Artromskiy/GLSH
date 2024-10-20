using GLSH.Swizzle;

// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {

        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public static swizzle_bvec4 swizzle(bool4 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(bool4 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public static int Count(bool4 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(bool4 v, bool4 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(bool4 v) => v.GetHashCode();

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(bool4 lhs, bool4 rhs) => bool4.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(bool4 lhs, bool4 rhs) => bool4.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Not (!v).
        /// </summary>
        public static bool4 Not(bool4 v) => bool4.Not(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool4 And(bool4 lhs, bool4 rhs) => bool4.And(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool4 Nand(bool4 lhs, bool4 rhs) => bool4.Nand(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool4 Or(bool4 lhs, bool4 rhs) => bool4.Or(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool4 Nor(bool4 lhs, bool4 rhs) => bool4.Nor(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool4 Xor(bool4 lhs, bool4 rhs) => bool4.Xor(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool4 Xnor(bool4 lhs, bool4 rhs) => bool4.Xnor(lhs, rhs);

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static bool MinElement(bool4 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static bool MaxElement(bool4 v) => v.MaxElement;

        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public static bool All(bool4 v) => v.All;

        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public static bool Any(bool4 v) => v.Any;

    }
}
