using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type bool with 4 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct bool4
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

        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        public bool w;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public bool4(bool x, bool y, bool z, bool w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public bool4(bool v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public bool4(bool2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = false;
            this.w = false;
        }

        /// <summary>
        /// from-vector-and-value constructor (empty fields are zero/false)
        /// </summary>
        public bool4(bool2 v, bool z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = false;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public bool4(bool2 v, bool z, bool w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public bool4(bool3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = false;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public bool4(bool3 v, bool w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = w;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public bool4(bool4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        #endregion


        #region Explicit Operators

        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(bool4 v) => new int2(v.x ? 1 : 0, v.y ? 1 : 0);

        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(bool4 v) => new int3(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0);

        /// <summary>
        /// Explicitly converts this to a int4.
        /// </summary>
        public static explicit operator int4(bool4 v) => new int4(v.x ? 1 : 0, v.y ? 1 : 0, v.z ? 1 : 0, v.w ? 1 : 0);

        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(bool4 v) => new uint2(v.x ? 1u : 0u, v.y ? 1u : 0u);

        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(bool4 v) => new uint3(v.x ? 1u : 0u, v.y ? 1u : 0u, v.z ? 1u : 0u);

        /// <summary>
        /// Explicitly converts this to a uint4.
        /// </summary>
        public static explicit operator uint4(bool4 v) => new uint4(v.x ? 1u : 0u, v.y ? 1u : 0u, v.z ? 1u : 0u, v.w ? 1u : 0u);

        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(bool4 v) => new float2(v.x ? 1f : 0f, v.y ? 1f : 0f);

        /// <summary>
        /// Explicitly converts this to a float3.
        /// </summary>
        public static explicit operator float3(bool4 v) => new float3(v.x ? 1f : 0f, v.y ? 1f : 0f, v.z ? 1f : 0f);

        /// <summary>
        /// Explicitly converts this to a float4.
        /// </summary>
        public static explicit operator float4(bool4 v) => new float4(v.x ? 1f : 0f, v.y ? 1f : 0f, v.z ? 1f : 0f, v.w ? 1f : 0f);

        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(bool4 v) => new double2(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0);

        /// <summary>
        /// Explicitly converts this to a double3.
        /// </summary>
        public static explicit operator double3(bool4 v) => new double3(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, v.z ? 1.0 : 0.0);

        /// <summary>
        /// Explicitly converts this to a double4.
        /// </summary>
        public static explicit operator double4(bool4 v) => new double4(v.x ? 1.0 : 0.0, v.y ? 1.0 : 0.0, v.z ? 1.0 : 0.0, v.w ? 1.0 : 0.0);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(bool4 v) => new bool2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(bool4 v) => new bool3(v.x, v.y, v.z);

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
                    case 3: return w;
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
                    case 3: w = value; break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public swizzle_bvec4 swizzle => new swizzle_bvec4(x, y, z, w);

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
        public bool2 xw
        {
            get
            {
                return new bool2(x, w);
            }
            set
            {
                x = value.x;
                w = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 yw
        {
            get
            {
                return new bool2(y, w);
            }
            set
            {
                y = value.x;
                w = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool3 xyw
        {
            get
            {
                return new bool3(x, y, w);
            }
            set
            {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 zw
        {
            get
            {
                return new bool2(z, w);
            }
            set
            {
                z = value.x;
                w = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool3 xzw
        {
            get
            {
                return new bool3(x, z, w);
            }
            set
            {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool3 yzw
        {
            get
            {
                return new bool3(y, z, w);
            }
            set
            {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool4 xyzw
        {
            get
            {
                return new bool4(x, y, z, w);
            }
            set
            {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
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
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 ra
        {
            get
            {
                return new bool2(x, w);
            }
            set
            {
                x = value.x;
                w = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 ga
        {
            get
            {
                return new bool2(y, w);
            }
            set
            {
                y = value.x;
                w = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool3 rga
        {
            get
            {
                return new bool3(x, y, w);
            }
            set
            {
                x = value.x;
                y = value.y;
                w = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool2 ba
        {
            get
            {
                return new bool2(z, w);
            }
            set
            {
                z = value.x;
                w = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool3 rba
        {
            get
            {
                return new bool3(x, z, w);
            }
            set
            {
                x = value.x;
                z = value.y;
                w = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool3 gba
        {
            get
            {
                return new bool3(y, z, w);
            }
            set
            {
                y = value.x;
                z = value.y;
                w = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool4 rgba
        {
            get
            {
                return new bool4(x, y, z, w);
            }
            set
            {
                x = value.x;
                y = value.y;
                z = value.z;
                w = value.w;
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
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public bool a
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }

        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public int Count => 4;

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public bool MinElement => ((x && y) && (z && w));

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public bool MaxElement => ((x || y) || (z || w));

        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public bool All => ((x && y) && (z && w));

        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public bool Any => ((x || y) || (z || w));

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static bool4 Zero { get; } = new bool4(false, false, false, false);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static bool4 Ones { get; } = new bool4(true, true, true, true);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static bool4 UnitX { get; } = new bool4(true, false, false, false);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static bool4 UnitY { get; } = new bool4(false, true, false, false);

        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        public static bool4 UnitZ { get; } = new bool4(false, false, true, false);

        /// <summary>
        /// Predefined unit-W vector
        /// </summary>
        public static bool4 UnitW { get; } = new bool4(false, false, false, true);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(bool4 lhs, bool4 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(bool4 lhs, bool4 rhs) => !lhs.Equals(rhs);

        #endregion


        #region Functions

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public override string ToString() => ToString(", ");

        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        private string ToString(string sep) => ((x + sep + y) + sep + (z + sep + w));

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(bool4 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && (z.Equals(rhs.z) && w.Equals(rhs.w)));

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((x.GetHashCode()) * 2) ^ y.GetHashCode()) * 2) ^ z.GetHashCode()) * 2) ^ w.GetHashCode();
            }
        }

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(bool4 lhs, bool4 rhs) => new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(bool4 lhs, bool rhs) => new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(bool lhs, bool4 rhs) => new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(bool lhs, bool rhs) => new bool4(lhs == rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(bool4 lhs, bool4 rhs) => new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(bool4 lhs, bool rhs) => new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(bool lhs, bool4 rhs) => new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(bool lhs, bool rhs) => new bool4(lhs != rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Not (!v).
        /// </summary>
        public static bool4 Not(bool4 v) => new bool4(!v.x, !v.y, !v.z, !v.w);

        /// <summary>
        /// Returns a bvec from the application of Not (!v).
        /// </summary>
        public static bool4 Not(bool v) => new bool4(!v);

        /// <summary>
        /// Returns a bool4 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool4 And(bool4 lhs, bool4 rhs) => new bool4(lhs.x && rhs.x, lhs.y && rhs.y, lhs.z && rhs.z, lhs.w && rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool4 And(bool4 lhs, bool rhs) => new bool4(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs, lhs.w && rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool4 And(bool lhs, bool4 rhs) => new bool4(lhs && rhs.x, lhs && rhs.y, lhs && rhs.z, lhs && rhs.w);

        /// <summary>
        /// Returns a bvec from the application of And (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool4 And(bool lhs, bool rhs) => new bool4(lhs && rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool4 Nand(bool4 lhs, bool4 rhs) => new bool4(!(lhs.x && rhs.x), !(lhs.y && rhs.y), !(lhs.z && rhs.z), !(lhs.w && rhs.w));

        /// <summary>
        /// Returns a bool4 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool4 Nand(bool4 lhs, bool rhs) => new bool4(!(lhs.x && rhs), !(lhs.y && rhs), !(lhs.z && rhs), !(lhs.w && rhs));

        /// <summary>
        /// Returns a bool4 from component-wise application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool4 Nand(bool lhs, bool4 rhs) => new bool4(!(lhs && rhs.x), !(lhs && rhs.y), !(lhs && rhs.z), !(lhs && rhs.w));

        /// <summary>
        /// Returns a bvec from the application of Nand (!(lhs &amp;&amp; rhs)).
        /// </summary>
        public static bool4 Nand(bool lhs, bool rhs) => new bool4(!(lhs && rhs));

        /// <summary>
        /// Returns a bool4 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool4 Or(bool4 lhs, bool4 rhs) => new bool4(lhs.x || rhs.x, lhs.y || rhs.y, lhs.z || rhs.z, lhs.w || rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool4 Or(bool4 lhs, bool rhs) => new bool4(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs, lhs.w || rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Or (lhs || rhs).
        /// </summary>
        public static bool4 Or(bool lhs, bool4 rhs) => new bool4(lhs || rhs.x, lhs || rhs.y, lhs || rhs.z, lhs || rhs.w);

        /// <summary>
        /// Returns a bvec from the application of Or (lhs || rhs).
        /// </summary>
        public static bool4 Or(bool lhs, bool rhs) => new bool4(lhs || rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool4 Nor(bool4 lhs, bool4 rhs) => new bool4(!(lhs.x || rhs.x), !(lhs.y || rhs.y), !(lhs.z || rhs.z), !(lhs.w || rhs.w));

        /// <summary>
        /// Returns a bool4 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool4 Nor(bool4 lhs, bool rhs) => new bool4(!(lhs.x || rhs), !(lhs.y || rhs), !(lhs.z || rhs), !(lhs.w || rhs));

        /// <summary>
        /// Returns a bool4 from component-wise application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool4 Nor(bool lhs, bool4 rhs) => new bool4(!(lhs || rhs.x), !(lhs || rhs.y), !(lhs || rhs.z), !(lhs || rhs.w));

        /// <summary>
        /// Returns a bvec from the application of Nor (!(lhs || rhs)).
        /// </summary>
        public static bool4 Nor(bool lhs, bool rhs) => new bool4(!(lhs || rhs));

        /// <summary>
        /// Returns a bool4 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool4 Xor(bool4 lhs, bool4 rhs) => new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool4 Xor(bool4 lhs, bool rhs) => new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Xor (lhs != rhs).
        /// </summary>
        public static bool4 Xor(bool lhs, bool4 rhs) => new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);

        /// <summary>
        /// Returns a bvec from the application of Xor (lhs != rhs).
        /// </summary>
        public static bool4 Xor(bool lhs, bool rhs) => new bool4(lhs != rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool4 Xnor(bool4 lhs, bool4 rhs) => new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool4 Xnor(bool4 lhs, bool rhs) => new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Xnor (lhs == rhs).
        /// </summary>
        public static bool4 Xnor(bool lhs, bool4 rhs) => new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);

        /// <summary>
        /// Returns a bvec from the application of Xnor (lhs == rhs).
        /// </summary>
        public static bool4 Xnor(bool lhs, bool rhs) => new bool4(lhs == rhs);

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool4 from component-wise application of operator! (!v).
        /// </summary>
        public static bool4 operator !(bool4 v) => new bool4(!v.x, !v.y, !v.z, !v.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool4 operator &(bool4 lhs, bool4 rhs) => new bool4(lhs.x && rhs.x, lhs.y && rhs.y, lhs.z && rhs.z, lhs.w && rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool4 operator &(bool4 lhs, bool rhs) => new bool4(lhs.x && rhs, lhs.y && rhs, lhs.z && rhs, lhs.w && rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&amp; (lhs &amp;&amp; rhs).
        /// </summary>
        public static bool4 operator &(bool lhs, bool4 rhs) => new bool4(lhs && rhs.x, lhs && rhs.y, lhs && rhs.z, lhs && rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool4 operator |(bool4 lhs, bool4 rhs) => new bool4(lhs.x || rhs.x, lhs.y || rhs.y, lhs.z || rhs.z, lhs.w || rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool4 operator |(bool4 lhs, bool rhs) => new bool4(lhs.x || rhs, lhs.y || rhs, lhs.z || rhs, lhs.w || rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator| (lhs || rhs).
        /// </summary>
        public static bool4 operator |(bool lhs, bool4 rhs) => new bool4(lhs || rhs.x, lhs || rhs.y, lhs || rhs.z, lhs || rhs.w);

        #endregion

    }
}
