using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type uint with 3 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct uint3
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public uint x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public uint y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        public uint z;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public uint3(uint x, uint y, uint z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public uint3(uint v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public uint3(uint2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0u;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public uint3(uint2 v, uint z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public uint3(uint3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public uint3(uint4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        #endregion


        #region Implicit Operators

        /// <summary>
        /// Implicitly converts this to a float3.
        /// </summary>
        public static implicit operator float3(uint3 v) => new float3(v.x, v.y, v.z);

        /// <summary>
        /// Implicitly converts this to a double3.
        /// </summary>
        public static implicit operator double3(uint3 v) => new double3(v.x, v.y, v.z);

        #endregion


        #region Explicit Operators

        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(uint3 v) => new int2((int)v.x, (int)v.y);

        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(uint3 v) => new int3((int)v.x, (int)v.y, (int)v.z);

        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(uint3 v) => new int4((int)v.x, (int)v.y, (int)v.z, 0);

        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(uint3 v) => new uint2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(uint3 v) => new uint4(v.x, v.y, v.z, 0u);

        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(uint3 v) => new float2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(uint3 v) => new float4(v.x, v.y, v.z, 0f);

        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(uint3 v) => new double2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(uint3 v) => new double4(v.x, v.y, v.z, 0.0);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(uint3 v) => new bool2(v.x != 0u, v.y != 0u);

        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(uint3 v) => new bool3(v.x != 0u, v.y != 0u, v.z != 0u);

        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(uint3 v) => new bool4(v.x != 0u, v.y != 0u, v.z != 0u, false);

        #endregion


        #region Indexer

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public uint this[int index]
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
        public swizzle_uvec3 swizzle => new swizzle_uvec3(x, y, z);

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public uint2 xy
        {
            get
            {
                return new uint2(x, y);
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
        public uint2 xz
        {
            get
            {
                return new uint2(x, z);
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
        public uint2 yz
        {
            get
            {
                return new uint2(y, z);
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
        public uint3 xyz
        {
            get
            {
                return new uint3(x, y, z);
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
        public uint2 rg
        {
            get
            {
                return new uint2(x, y);
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
        public uint2 rb
        {
            get
            {
                return new uint2(x, z);
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
        public uint2 gb
        {
            get
            {
                return new uint2(y, z);
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
        public uint3 rgb
        {
            get
            {
                return new uint3(x, y, z);
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
        public uint r
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
        public uint g
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
        public uint b
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
        public uint MinElement => Math.Min(Math.Min(x, y), z);

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public uint MaxElement => Math.Max(Math.Max(x, y), z);

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public float Length => (float)Math.Sqrt(((x * x + y * y) + z * z));

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public float LengthSqr => ((x * x + y * y) + z * z);

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public uint Sum => ((x + y) + z);

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public float Norm => (float)Math.Sqrt(((x * x + y * y) + z * z));

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public float Norm1 => ((x + y) + z);

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt(((x * x + y * y) + z * z));

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public float NormMax => Math.Max(Math.Max(x, y), z);

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static uint3 Zero { get; } = new uint3(0u, 0u, 0u);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static uint3 Ones { get; } = new uint3(1u, 1u, 1u);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static uint3 UnitX { get; } = new uint3(1u, 0u, 0u);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static uint3 UnitY { get; } = new uint3(0u, 1u, 0u);

        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        public static uint3 UnitZ { get; } = new uint3(0u, 0u, 1u);

        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        public static uint3 MaxValue { get; } = new uint3(uint.MaxValue, uint.MaxValue, uint.MaxValue);

        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        public static uint3 MinValue { get; } = new uint3(uint.MinValue, uint.MinValue, uint.MinValue);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(uint3 lhs, uint3 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(uint3 lhs, uint3 rhs) => !lhs.Equals(rhs);

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
        public bool Equals(uint3 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z));

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode();
            }
        }

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public double NormP(double p) => Math.Pow(((Math.Pow(x, p) + Math.Pow(y, p)) + Math.Pow(z, p)), 1 / p);

        #endregion


        #region Static Functions

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint3x2 OuterProduct(uint2 c, uint3 r) => new uint3x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x3 OuterProduct(uint3 c, uint2 r) => new uint2x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint3x3 OuterProduct(uint3 c, uint3 r) => new uint3x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint3x4 OuterProduct(uint4 c, uint3 r) => new uint3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint4x3 OuterProduct(uint3 c, uint4 r) => new uint4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static uint Dot(uint3 lhs, uint3 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + lhs.z * rhs.z);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(uint3 lhs, uint3 rhs) => (lhs - rhs).Length;

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(uint3 lhs, uint3 rhs) => (lhs - rhs).LengthSqr;

        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static uint3 Cross(uint3 l, uint3 r) => new uint3(l.y * r.z - l.z * r.y, l.z * r.x - l.x * r.z, l.x * r.y - l.y * r.x);

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(uint3 lhs, uint3 rhs) => new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(uint3 lhs, uint rhs) => new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(uint lhs, uint3 rhs) => new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(uint lhs, uint rhs) => new bool3(lhs == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(uint3 lhs, uint3 rhs) => new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(uint3 lhs, uint rhs) => new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(uint lhs, uint3 rhs) => new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(uint lhs, uint rhs) => new bool3(lhs != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(uint3 lhs, uint3 rhs) => new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(uint3 lhs, uint rhs) => new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(uint lhs, uint3 rhs) => new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);

        /// <summary>
        /// Returns a bvec from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(uint lhs, uint rhs) => new bool3(lhs > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(uint3 lhs, uint3 rhs) => new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(uint3 lhs, uint rhs) => new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(uint lhs, uint3 rhs) => new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);

        /// <summary>
        /// Returns a bvec from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(uint lhs, uint rhs) => new bool3(lhs >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(uint3 lhs, uint3 rhs) => new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(uint3 lhs, uint rhs) => new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(uint lhs, uint3 rhs) => new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);

        /// <summary>
        /// Returns a bvec from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(uint lhs, uint rhs) => new bool3(lhs < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(uint3 lhs, uint3 rhs) => new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(uint3 lhs, uint rhs) => new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(uint lhs, uint3 rhs) => new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);

        /// <summary>
        /// Returns a bvec from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(uint lhs, uint rhs) => new bool3(lhs <= rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Abs (v).
        /// </summary>
        public static uint3 Abs(uint3 v) => new uint3(v.x, v.y, v.z);

        /// <summary>
        /// Returns a uvec from the application of Abs (v).
        /// </summary>
        public static uint3 Abs(uint v) => new uint3(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint3 HermiteInterpolationOrder3(uint3 v) => new uint3((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z);

        /// <summary>
        /// Returns a uvec from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint3 HermiteInterpolationOrder3(uint v) => new uint3((3 - 2 * v) * v * v);

        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint3 HermiteInterpolationOrder5(uint3 v) => new uint3(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z);

        /// <summary>
        /// Returns a uvec from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint3 HermiteInterpolationOrder5(uint v) => new uint3(((6 * v - 15) * v + 10) * v * v * v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static uint3 Sqr(uint3 v) => new uint3(v.x * v.x, v.y * v.y, v.z * v.z);

        /// <summary>
        /// Returns a uvec from the application of Sqr (v * v).
        /// </summary>
        public static uint3 Sqr(uint v) => new uint3(v * v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static uint3 Pow2(uint3 v) => new uint3(v.x * v.x, v.y * v.y, v.z * v.z);

        /// <summary>
        /// Returns a uvec from the application of Pow2 (v * v).
        /// </summary>
        public static uint3 Pow2(uint v) => new uint3(v * v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static uint3 Pow3(uint3 v) => new uint3(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z);

        /// <summary>
        /// Returns a uvec from the application of Pow3 (v * v * v).
        /// </summary>
        public static uint3 Pow3(uint v) => new uint3(v * v * v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint3 Step(uint3 v) => new uint3(v.x >= 0u ? 1u : 0u, v.y >= 0u ? 1u : 0u, v.z >= 0u ? 1u : 0u);

        /// <summary>
        /// Returns a uvec from the application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint3 Step(uint v) => new uint3(v >= 0u ? 1u : 0u);

        /// <summary>
        /// Returns a uint3 from component-wise application of Sqrt ((uint)Math.Sqrt((double)v)).
        /// </summary>
        public static uint3 Sqrt(uint3 v) => new uint3((uint)Math.Sqrt(v.x), (uint)Math.Sqrt(v.y), (uint)Math.Sqrt(v.z));

        /// <summary>
        /// Returns a uvec from the application of Sqrt ((uint)Math.Sqrt((double)v)).
        /// </summary>
        public static uint3 Sqrt(uint v) => new uint3((uint)Math.Sqrt(v));

        /// <summary>
        /// Returns a uint3 from component-wise application of InverseSqrt ((uint)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static uint3 InverseSqrt(uint3 v) => new uint3((uint)(1.0 / Math.Sqrt(v.x)), (uint)(1.0 / Math.Sqrt(v.y)), (uint)(1.0 / Math.Sqrt(v.z)));

        /// <summary>
        /// Returns a uvec from the application of InverseSqrt ((uint)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static uint3 InverseSqrt(uint v) => new uint3((uint)(1.0 / Math.Sqrt(v)));

        /// <summary>
        /// Returns a int3 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int3 Sign(uint3 v) => new int3(Math.Sign(v.x), Math.Sign(v.y), Math.Sign(v.z));

        /// <summary>
        /// Returns a ivec from the application of Sign (Math.Sign(v)).
        /// </summary>
        public static int3 Sign(uint v) => new int3(Math.Sign(v));

        /// <summary>
        /// Returns a uint3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint3 Max(uint3 lhs, uint3 rhs) => new uint3(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z));

        /// <summary>
        /// Returns a uint3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint3 Max(uint3 lhs, uint rhs) => new uint3(Math.Max(lhs.x, rhs), Math.Max(lhs.y, rhs), Math.Max(lhs.z, rhs));

        /// <summary>
        /// Returns a uint3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint3 Max(uint lhs, uint3 rhs) => new uint3(Math.Max(lhs, rhs.x), Math.Max(lhs, rhs.y), Math.Max(lhs, rhs.z));

        /// <summary>
        /// Returns a uvec from the application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint3 Max(uint lhs, uint rhs) => new uint3(Math.Max(lhs, rhs));

        /// <summary>
        /// Returns a uint3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint3 Min(uint3 lhs, uint3 rhs) => new uint3(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z));

        /// <summary>
        /// Returns a uint3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint3 Min(uint3 lhs, uint rhs) => new uint3(Math.Min(lhs.x, rhs), Math.Min(lhs.y, rhs), Math.Min(lhs.z, rhs));

        /// <summary>
        /// Returns a uint3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint3 Min(uint lhs, uint3 rhs) => new uint3(Math.Min(lhs, rhs.x), Math.Min(lhs, rhs.y), Math.Min(lhs, rhs.z));

        /// <summary>
        /// Returns a uvec from the application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint3 Min(uint lhs, uint rhs) => new uint3(Math.Min(lhs, rhs));

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Pow(uint3 lhs, uint3 rhs) => new uint3((uint)Math.Pow(lhs.x, rhs.x), (uint)Math.Pow(lhs.y, rhs.y), (uint)Math.Pow(lhs.z, rhs.z));

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Pow(uint3 lhs, uint rhs) => new uint3((uint)Math.Pow(lhs.x, rhs), (uint)Math.Pow(lhs.y, rhs), (uint)Math.Pow(lhs.z, rhs));

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Pow(uint lhs, uint3 rhs) => new uint3((uint)Math.Pow(lhs, rhs.x), (uint)Math.Pow(lhs, rhs.y), (uint)Math.Pow(lhs, rhs.z));

        /// <summary>
        /// Returns a uvec from the application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Pow(uint lhs, uint rhs) => new uint3((uint)Math.Pow(lhs, rhs));

        /// <summary>
        /// Returns a uint3 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Log(uint3 lhs, uint3 rhs) => new uint3((uint)Math.Log(lhs.x, rhs.x), (uint)Math.Log(lhs.y, rhs.y), (uint)Math.Log(lhs.z, rhs.z));

        /// <summary>
        /// Returns a uint3 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Log(uint3 lhs, uint rhs) => new uint3((uint)Math.Log(lhs.x, rhs), (uint)Math.Log(lhs.y, rhs), (uint)Math.Log(lhs.z, rhs));

        /// <summary>
        /// Returns a uint3 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Log(uint lhs, uint3 rhs) => new uint3((uint)Math.Log(lhs, rhs.x), (uint)Math.Log(lhs, rhs.y), (uint)Math.Log(lhs, rhs.z));

        /// <summary>
        /// Returns a uvec from the application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Log(uint lhs, uint rhs) => new uint3((uint)Math.Log(lhs, rhs));

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint3 v, uint3 min, uint3 max) => new uint3(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z));

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint3 v, uint3 min, uint max) => new uint3(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max), Math.Min(Math.Max(v.z, min.z), max));

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint3 v, uint min, uint3 max) => new uint3(Math.Min(Math.Max(v.x, min), max.x), Math.Min(Math.Max(v.y, min), max.y), Math.Min(Math.Max(v.z, min), max.z));

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint3 v, uint min, uint max) => new uint3(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max));

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint v, uint3 min, uint3 max) => new uint3(Math.Min(Math.Max(v, min.x), max.x), Math.Min(Math.Max(v, min.y), max.y), Math.Min(Math.Max(v, min.z), max.z));

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint v, uint3 min, uint max) => new uint3(Math.Min(Math.Max(v, min.x), max), Math.Min(Math.Max(v, min.y), max), Math.Min(Math.Max(v, min.z), max));

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint v, uint min, uint3 max) => new uint3(Math.Min(Math.Max(v, min), max.x), Math.Min(Math.Max(v, min), max.y), Math.Min(Math.Max(v, min), max.z));

        /// <summary>
        /// Returns a uvec from the application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint v, uint min, uint max) => new uint3(Math.Min(Math.Max(v, min), max));

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint3 min, uint3 max, uint3 a) => new uint3(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint3 min, uint3 max, uint a) => new uint3(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint3 min, uint max, uint3 a) => new uint3(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint3 min, uint max, uint a) => new uint3(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint min, uint3 max, uint3 a) => new uint3(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint min, uint3 max, uint a) => new uint3(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint min, uint max, uint3 a) => new uint3(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a uvec from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint min, uint max, uint a) => new uint3(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint3 min, uint3 max, uint3 a) => new uint3(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint3 min, uint3 max, uint a) => new uint3(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint3 min, uint max, uint3 a) => new uint3(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint3 min, uint max, uint a) => new uint3(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint min, uint3 max, uint3 a) => new uint3(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint min, uint3 max, uint a) => new uint3(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint min, uint max, uint3 a) => new uint3(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a uvec from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint min, uint max, uint a) => new uint3(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint3 edge0, uint3 edge1, uint3 v) => new uint3(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint3 edge0, uint3 edge1, uint v) => new uint3(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint3 edge0, uint edge1, uint3 v) => new uint3(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint3 edge0, uint edge1, uint v) => new uint3(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint edge0, uint3 edge1, uint3 v) => new uint3(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint edge0, uint3 edge1, uint v) => new uint3(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint edge0, uint edge1, uint3 v) => new uint3(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uvec from the application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint edge0, uint edge1, uint v) => new uint3(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint3 edge0, uint3 edge1, uint3 v) => new uint3(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint3 edge0, uint3 edge1, uint v) => new uint3(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint3 edge0, uint edge1, uint3 v) => new uint3(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint3 edge0, uint edge1, uint v) => new uint3(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint edge0, uint3 edge1, uint3 v) => new uint3(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint edge0, uint3 edge1, uint v) => new uint3(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint edge0, uint edge1, uint3 v) => new uint3(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uvec from the application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint edge0, uint edge1, uint v) => new uint3(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint3 a, uint3 b, uint3 c) => new uint3(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint3 a, uint3 b, uint c) => new uint3(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c);

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint3 a, uint b, uint3 c) => new uint3(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint3 a, uint b, uint c) => new uint3(a.x * b + c, a.y * b + c, a.z * b + c);

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint a, uint3 b, uint3 c) => new uint3(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint a, uint3 b, uint c) => new uint3(a * b.x + c, a * b.y + c, a * b.z + c);

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint a, uint b, uint3 c) => new uint3(a * b + c.x, a * b + c.y, a * b + c.z);

        /// <summary>
        /// Returns a uvec from the application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint a, uint b, uint c) => new uint3(a * b + c);

        /// <summary>
        /// Returns a uint3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint3 Add(uint3 lhs, uint3 rhs) => new uint3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint3 Add(uint3 lhs, uint rhs) => new uint3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint3 Add(uint lhs, uint3 rhs) => new uint3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);

        /// <summary>
        /// Returns a uvec from the application of Add (lhs + rhs).
        /// </summary>
        public static uint3 Add(uint lhs, uint rhs) => new uint3(lhs + rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint3 Sub(uint3 lhs, uint3 rhs) => new uint3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint3 Sub(uint3 lhs, uint rhs) => new uint3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint3 Sub(uint lhs, uint3 rhs) => new uint3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);

        /// <summary>
        /// Returns a uvec from the application of Sub (lhs - rhs).
        /// </summary>
        public static uint3 Sub(uint lhs, uint rhs) => new uint3(lhs - rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint3 Mul(uint3 lhs, uint3 rhs) => new uint3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint3 Mul(uint3 lhs, uint rhs) => new uint3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint3 Mul(uint lhs, uint3 rhs) => new uint3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);

        /// <summary>
        /// Returns a uvec from the application of Mul (lhs * rhs).
        /// </summary>
        public static uint3 Mul(uint lhs, uint rhs) => new uint3(lhs * rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint3 Div(uint3 lhs, uint3 rhs) => new uint3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint3 Div(uint3 lhs, uint rhs) => new uint3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint3 Div(uint lhs, uint3 rhs) => new uint3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);

        /// <summary>
        /// Returns a uvec from the application of Div (lhs / rhs).
        /// </summary>
        public static uint3 Div(uint lhs, uint rhs) => new uint3(lhs / rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint3 Xor(uint3 lhs, uint3 rhs) => new uint3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint3 Xor(uint3 lhs, uint rhs) => new uint3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint3 Xor(uint lhs, uint3 rhs) => new uint3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z);

        /// <summary>
        /// Returns a uvec from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint3 Xor(uint lhs, uint rhs) => new uint3(lhs ^ rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint3 BitwiseOr(uint3 lhs, uint3 rhs) => new uint3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint3 BitwiseOr(uint3 lhs, uint rhs) => new uint3(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint3 BitwiseOr(uint lhs, uint3 rhs) => new uint3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z);

        /// <summary>
        /// Returns a uvec from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint3 BitwiseOr(uint lhs, uint rhs) => new uint3(lhs | rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint3 BitwiseAnd(uint3 lhs, uint3 rhs) => new uint3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint3 BitwiseAnd(uint3 lhs, uint rhs) => new uint3(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint3 BitwiseAnd(uint lhs, uint3 rhs) => new uint3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z);

        /// <summary>
        /// Returns a uvec from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint3 BitwiseAnd(uint lhs, uint rhs) => new uint3(lhs & rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint3 LeftShift(uint3 lhs, int3 rhs) => new uint3(lhs.x << rhs.x, lhs.y << rhs.y, lhs.z << rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint3 LeftShift(uint3 lhs, int rhs) => new uint3(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint3 LeftShift(uint lhs, int3 rhs) => new uint3(lhs << rhs.x, lhs << rhs.y, lhs << rhs.z);

        /// <summary>
        /// Returns a uvec from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint3 LeftShift(uint lhs, int rhs) => new uint3(lhs << rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint3 RightShift(uint3 lhs, int3 rhs) => new uint3(lhs.x >> rhs.x, lhs.y >> rhs.y, lhs.z >> rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint3 RightShift(uint3 lhs, int rhs) => new uint3(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint3 RightShift(uint lhs, int3 rhs) => new uint3(lhs >> rhs.x, lhs >> rhs.y, lhs >> rhs.z);

        /// <summary>
        /// Returns a uvec from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint3 RightShift(uint lhs, int rhs) => new uint3(lhs >> rhs);

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(uint3 lhs, uint3 rhs) => new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(uint3 lhs, uint rhs) => new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(uint lhs, uint3 rhs) => new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(uint3 lhs, uint3 rhs) => new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(uint3 lhs, uint rhs) => new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(uint lhs, uint3 rhs) => new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(uint3 lhs, uint3 rhs) => new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(uint3 lhs, uint rhs) => new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(uint lhs, uint3 rhs) => new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(uint3 lhs, uint3 rhs) => new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(uint3 lhs, uint rhs) => new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(uint lhs, uint3 rhs) => new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint3 operator +(uint3 lhs, uint3 rhs) => new uint3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint3 operator +(uint3 lhs, uint rhs) => new uint3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint3 operator +(uint lhs, uint3 rhs) => new uint3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint3 operator -(uint3 lhs, uint3 rhs) => new uint3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint3 operator -(uint3 lhs, uint rhs) => new uint3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint3 operator -(uint lhs, uint3 rhs) => new uint3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint3 operator *(uint3 lhs, uint3 rhs) => new uint3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint3 operator *(uint3 lhs, uint rhs) => new uint3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint3 operator *(uint lhs, uint3 rhs) => new uint3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint3 operator /(uint3 lhs, uint3 rhs) => new uint3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint3 operator /(uint3 lhs, uint rhs) => new uint3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint3 operator /(uint lhs, uint3 rhs) => new uint3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator+ (identity).
        /// </summary>
        public static uint3 operator +(uint3 v) => v;

        /// <summary>
        /// Returns a uint3 from component-wise application of operator~ (~v).
        /// </summary>
        public static uint3 operator ~(uint3 v) => new uint3(~v.x, ~v.y, ~v.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint3 operator ^(uint3 lhs, uint3 rhs) => new uint3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint3 operator ^(uint3 lhs, uint rhs) => new uint3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint3 operator ^(uint lhs, uint3 rhs) => new uint3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint3 operator |(uint3 lhs, uint3 rhs) => new uint3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint3 operator |(uint3 lhs, uint rhs) => new uint3(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint3 operator |(uint lhs, uint3 rhs) => new uint3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint3 operator &(uint3 lhs, uint3 rhs) => new uint3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint3 operator &(uint3 lhs, uint rhs) => new uint3(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint3 operator &(uint lhs, uint3 rhs) => new uint3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint3 operator <<(uint3 lhs, int rhs) => new uint3(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint3 operator >>(uint3 lhs, int rhs) => new uint3(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs);

        #endregion

    }
}
