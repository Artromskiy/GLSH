using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type bool with 3 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct bool3
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public bool x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public bool y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        public bool z;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public bool3(bool x, bool y, bool z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public bool3(bool v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public bool3(bool2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = false;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public bool3(bool2 v, bool z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public bool3(bool3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public bool3(bool4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        #endregion


        #region Explicit Operators

        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(bool3 v) => new int2(v.x ? 1 : 0, v.y ? 1 : 0);

        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(bool3 v) => new int3(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0);

        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(bool3 v) => new int4(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0, 0);

        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(bool3 v) => new uint2(v.x ? 1u : 0u, v.y ? 1u : 0u);

        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(bool3 v) => new uint3(v.x ? 1u : 0u, v.y ? 1u : 0u, v.z ? 1u : 0u);

        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(bool3 v) => new uint4(v.x ? 1u : 0u, v.y ? 1u : 0u, v.z ? 1u : 0u, 0u);

        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(bool3 v) => new float2(v.x ? 1f : 0f, v.y ? 1f : 0f);

        /// <summary>
        /// Explicitly converts this to a float3.
        /// </summary>
        public static explicit operator float3(bool3 v) => new float3(v.x ? 1f : 0f, v.y ? 1f : 0f, v.z ? 1f : 0f);

        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(bool3 v) => new float4(v.x ? 1f : 0f, v.y ? 1f : 0f, v.z ? 1f : 0f, 0f);

        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(bool3 v) => new double2(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0);

        /// <summary>
        /// Explicitly converts this to a double3.
        /// </summary>
        public static explicit operator double3(bool3 v) => new double3(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, v.z ? 1.0 : 0.0);

        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(bool3 v) => new double4(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, v.z ? 1.0 : 0.0, 0.0);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(bool3 v) => new bool2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(bool3 v) => new bool4(v.x, v.y, v.z, false);

        #endregion


        #region Indexer

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public bool this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public swizzle_bvec3 swizzle => new swizzle_bvec3(x, y, z);

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 xy
        {
            get
            {
                return new bool2(x, y);
            }
            set
            {
                x = value.x;
                y = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 xz
        {
            get
            {
                return new bool2(x, z);
            }
            set
            {
                x = value.x;
                z = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 yz
        {
            get
            {
                return new bool2(y, z);
            }
            set
            {
                y = value.x;
                z = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool3 xyz
        {
            get
            {
                return new bool3(x, y, z);
            }
            set
            {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 rg
        {
            get
            {
                return new bool2(x, y);
            }
            set
            {
                x = value.x;
                y = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 rb
        {
            get
            {
                return new bool2(x, z);
            }
            set
            {
                x = value.x;
                z = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 gb
        {
            get
            {
                return new bool2(y, z);
            }
            set
            {
                y = value.x;
                z = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool3 rgb
        {
            get
            {
                return new bool3(x, y, z);
            }
            set
            {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool r
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool g
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool b
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        public int Count => 3;

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public bool MinElement => ((x && y) && z);

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public bool MaxElement => ((x || y) || z);

        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public bool All => ((x && y) && z);

        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public bool Any => ((x || y) || z);

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static bool3 Zero { get; } = new bool3(false, false, false);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static bool3 Ones { get; } = new bool3(true, true, true);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static bool3 UnitX { get; } = new bool3(true, false, false);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static bool3 UnitY { get; } = new bool3(false, true, false);

        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        public static bool3 UnitZ { get; } = new bool3(false, false, true);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(bool3 lhs, bool3 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(bool3 lhs, bool3 rhs) => !lhs.Equals(rhs);

        #endregion


        #region Functions

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public override string ToString() => ToString(", ");

        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        private string ToString(string sep) => ((x + sep + y) + sep + z);

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(bool3 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z));

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((x.GetHashCode()) * 2) ^ y.GetHashCode()) * 2) ^ z.GetHashCode();
            }
        }

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool3 lhs, bool3 rhs) => new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool3 lhs, bool rhs) => new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool lhs, bool3 rhs) => new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(bool lhs, bool rhs) => new bool3(lhs == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool3 lhs, bool3 rhs) => new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool3 lhs, bool rhs) => new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool lhs, bool3 rhs) => new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(bool lhs, bool rhs) => new bool3(lhs != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Not (!v).
        /// </summary>
        public static bool3 Not(bool3 v) => new bool3(!v.x, !v.y, !v.z);

        /// <summary>
        /// Returns a bvec from the application of Not (!v).
        /// </summary>
        public static bool3 Not(bool v) => new bool3(!v);

        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool3 lhs, bool3 rhs) => new bool3(lhs.x && rhs.x, lhs.y && rhs.y, lhs.z && rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool3 lhs, bool rhs) => new bool3(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool lhs, bool3 rhs) => new bool3(lhs && rhs.x, lhs && rhs.y, lhs && rhs.z);

        /// <summary>
        /// Returns a bvec from the application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 And(bool lhs, bool rhs) => new bool3(lhs && rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool3 lhs, bool3 rhs) => new bool3(!(lhs.x && rhs.x), !(lhs.y && rhs.y), !(lhs.z && rhs.z));

        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool3 lhs, bool rhs) => new bool3(!(lhs.x && rhs), !(lhs.y && rhs), !(lhs.z && rhs));

        /// <summary>
        /// Returns a bool3 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool lhs, bool3 rhs) => new bool3(!(lhs && rhs.x), !(lhs && rhs.y), !(lhs && rhs.z));

        /// <summary>
        /// Returns a bvec from the application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool3 Nand(bool lhs, bool rhs) => new bool3(!(lhs && rhs));

        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool3 lhs, bool3 rhs) => new bool3(lhs.x || rhs.x, lhs.y || rhs.y, lhs.z || rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool3 lhs, bool rhs) => new bool3(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool lhs, bool3 rhs) => new bool3(lhs || rhs.x, lhs || rhs.y, lhs || rhs.z);

        /// <summary>
        /// Returns a bvec from the application of Or (lhs || rhs).
        /// </summary>
        public static bool3 Or(bool lhs, bool rhs) => new bool3(lhs || rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool3 lhs, bool3 rhs) => new bool3(!(lhs.x || rhs.x), !(lhs.y || rhs.y), !(lhs.z || rhs.z));

        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool3 lhs, bool rhs) => new bool3(!(lhs.x || rhs), !(lhs.y || rhs), !(lhs.z || rhs));

        /// <summary>
        /// Returns a bool3 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool lhs, bool3 rhs) => new bool3(!(lhs || rhs.x), !(lhs || rhs.y), !(lhs || rhs.z));

        /// <summary>
        /// Returns a bvec from the application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool3 Nor(bool lhs, bool rhs) => new bool3(!(lhs || rhs));

        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool3 lhs, bool3 rhs) => new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool3 lhs, bool rhs) => new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool lhs, bool3 rhs) => new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);

        /// <summary>
        /// Returns a bvec from the application of Xor (lhs != rhs).
        /// </summary>
        public static bool3 Xor(bool lhs, bool rhs) => new bool3(lhs != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool3 lhs, bool3 rhs) => new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool3 lhs, bool rhs) => new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool lhs, bool3 rhs) => new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);

        /// <summary>
        /// Returns a bvec from the application of Xnor (lhs == rhs).
        /// </summary>
        public static bool3 Xnor(bool lhs, bool rhs) => new bool3(lhs == rhs);

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool3 from component-wise application of operator! (!v).
        /// </summary>
        public static bool3 operator !(bool3 v) => new bool3(!v.x, !v.y, !v.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 operator &(bool3 lhs, bool3 rhs) => new bool3(lhs.x && rhs.x, lhs.y && rhs.y, lhs.z && rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 operator &(bool3 lhs, bool rhs) => new bool3(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool3 operator &(bool lhs, bool3 rhs) => new bool3(lhs && rhs.x, lhs && rhs.y, lhs && rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool3 operator |(bool3 lhs, bool3 rhs) => new bool3(lhs.x || rhs.x, lhs.y || rhs.y, lhs.z || rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool3 operator |(bool3 lhs, bool rhs) => new bool3(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool3 operator |(bool lhs, bool3 rhs) => new bool3(lhs || rhs.x, lhs || rhs.y, lhs || rhs.z);

        #endregion

    }
}
