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
        public static swizzle_bvec3 swizzle(bool3 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(bool3 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        public static int Count(bool3 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(bool3 v, bool3 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(bool3 v) => v.GetHashCode();

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool3 lhs, bool3 rhs) => bool3.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool Equal(bool lhs, bool rhs) => lhs == rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool3 lhs, bool3 rhs) => bool3.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool NotEqual(bool lhs, bool rhs) => lhs != rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of Not (!v).
        /// </summary>
        public static bool3 Not(bool3 v) => bool3.Not(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of Not (!v).
        /// </summary>
        public static bool Not(bool v) => !v;

        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool3 lhs, bool3 rhs) => bool3.And(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool And(bool lhs, bool rhs) => lhs && rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool3 lhs, bool3 rhs) => bool3.Nand(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool Nand(bool lhs, bool rhs) => !(lhs && rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool3 lhs, bool3 rhs) => bool3.Or(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool Or(bool lhs, bool rhs) => lhs || rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool3 lhs, bool3 rhs) => bool3.Nor(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool Nor(bool lhs, bool rhs) => !(lhs || rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool3 lhs, bool3 rhs) => bool3.Xor(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool Xor(bool lhs, bool rhs) => lhs != rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool3 lhs, bool3 rhs) => bool3.Xnor(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool Xnor(bool lhs, bool rhs) => lhs == rhs;

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static bool MinElement(bool3 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static bool MaxElement(bool3 v) => v.MaxElement;

        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public static bool All(bool3 v) => v.All;

        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public static bool Any(bool3 v) => v.Any;

    }
}
