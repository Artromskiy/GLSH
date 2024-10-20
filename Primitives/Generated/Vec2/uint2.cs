using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type uint with 2 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct uint2
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

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public uint2(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public uint2(uint v)
        {
            this.x = v;
            this.y = v;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public uint2(uint2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public uint2(uint3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public uint2(uint4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        #endregion


        #region Implicit Operators

        /// <summary>
        /// Implicitly converts this to a float2.
        /// </summary>
        public static implicit operator float2(uint2 v) => new float2(v.x, v.y);

        /// <summary>
        /// Implicitly converts this to a double2.
        /// </summary>
        public static implicit operator double2(uint2 v) => new double2(v.x, v.y);

        #endregion


        #region Explicit Operators

        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(uint2 v) => new int2((int)v.x, (int)v.y);

        /// <summary>
        /// Explicitly converts this to a int3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int3(uint2 v) => new int3((int)v.x, (int)v.y, 0);

        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(uint2 v) => new int4((int)v.x, (int)v.y, 0, 0);

        /// <summary>
        /// Explicitly converts this to a uint3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint3(uint2 v) => new uint3(v.x, v.y, 0u);

        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(uint2 v) => new uint4(v.x, v.y, 0u, 0u);

        /// <summary>
        /// Explicitly converts this to a float3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float3(uint2 v) => new float3(v.x, v.y, 0f);

        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(uint2 v) => new float4(v.x, v.y, 0f, 0f);

        /// <summary>
        /// Explicitly converts this to a double3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double3(uint2 v) => new double3(v.x, v.y, 0.0);

        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(uint2 v) => new double4(v.x, v.y, 0.0, 0.0);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(uint2 v) => new bool2(v.x != 0u, v.y != 0u);

        /// <summary>
        /// Explicitly converts this to a bool3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool3(uint2 v) => new bool3(v.x != 0u, v.y != 0u, false);

        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(uint2 v) => new bool4(v.x != 0u, v.y != 0u, false, false);

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
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public swizzle_uvec2 swizzle => new swizzle_uvec2(x, y);

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
        /// Returns the number of components (2).
        /// </summary>
        public int Count => 2;

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public uint MinElement => Math.Min(x, y);

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public uint MaxElement => Math.Max(x, y);

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public float Length => (float)Math.Sqrt((x * x + y * y));

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public float LengthSqr => (x * x + y * y);

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public uint Sum => (x + y);

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public float Norm => (float)Math.Sqrt((x * x + y * y));

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public float Norm1 => (x + y);

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt((x * x + y * y));

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public float NormMax => Math.Max(x, y);

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static uint2 Zero { get; } = new uint2(0u, 0u);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static uint2 Ones { get; } = new uint2(1u, 1u);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static uint2 UnitX { get; } = new uint2(1u, 0u);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static uint2 UnitY { get; } = new uint2(0u, 1u);

        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        public static uint2 MaxValue { get; } = new uint2(uint.MaxValue, uint.MaxValue);

        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        public static uint2 MinValue { get; } = new uint2(uint.MinValue, uint.MinValue);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(uint2 lhs, uint2 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(uint2 lhs, uint2 rhs) => !lhs.Equals(rhs);

        #endregion


        #region Functions

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public override string ToString() => ToString(", ");

        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        private string ToString(string sep) => (x + sep + y);

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(uint2 rhs) => (x.Equals(rhs.x) && y.Equals(rhs.y));

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((x.GetHashCode()) * 397) ^ y.GetHashCode();
            }
        }

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public double NormP(double p) => Math.Pow((Math.Pow(x, p) + Math.Pow(y, p)), 1 / p);

        #endregion


        #region Static Functions

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x2 OuterProduct(uint2 c, uint2 r) => new uint2x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x3 OuterProduct(uint3 c, uint2 r) => new uint2x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint3x2 OuterProduct(uint2 c, uint3 r) => new uint3x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x4 OuterProduct(uint4 c, uint2 r) => new uint2x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint4x2 OuterProduct(uint2 c, uint4 r) => new uint4x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z, c.x * r.w, c.y * r.w);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static uint Dot(uint2 lhs, uint2 rhs) => (lhs.x * rhs.x + lhs.y * rhs.y);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(uint2 lhs, uint2 rhs) => (lhs - rhs).Length;

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(uint2 lhs, uint2 rhs) => (lhs - rhs).LengthSqr;

        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static uint Cross(uint2 l, uint2 r) => l.x * r.y - l.y * r.x;

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint2 lhs, uint2 rhs) => new bool2(lhs.x == rhs.x, lhs.y == rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint2 lhs, uint rhs) => new bool2(lhs.x == rhs, lhs.y == rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint lhs, uint2 rhs) => new bool2(lhs == rhs.x, lhs == rhs.y);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint lhs, uint rhs) => new bool2(lhs == rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint2 lhs, uint2 rhs) => new bool2(lhs.x != rhs.x, lhs.y != rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint2 lhs, uint rhs) => new bool2(lhs.x != rhs, lhs.y != rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint lhs, uint2 rhs) => new bool2(lhs != rhs.x, lhs != rhs.y);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint lhs, uint rhs) => new bool2(lhs != rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint2 lhs, uint2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint2 lhs, uint rhs) => new bool2(lhs.x > rhs, lhs.y > rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint lhs, uint2 rhs) => new bool2(lhs > rhs.x, lhs > rhs.y);

        /// <summary>
        /// Returns a bvec from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint lhs, uint rhs) => new bool2(lhs > rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint2 lhs, uint2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint2 lhs, uint rhs) => new bool2(lhs.x >= rhs, lhs.y >= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint lhs, uint2 rhs) => new bool2(lhs >= rhs.x, lhs >= rhs.y);

        /// <summary>
        /// Returns a bvec from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint lhs, uint rhs) => new bool2(lhs >= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint2 lhs, uint2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint2 lhs, uint rhs) => new bool2(lhs.x < rhs, lhs.y < rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint lhs, uint2 rhs) => new bool2(lhs < rhs.x, lhs < rhs.y);

        /// <summary>
        /// Returns a bvec from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint lhs, uint rhs) => new bool2(lhs < rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint2 lhs, uint2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint2 lhs, uint rhs) => new bool2(lhs.x <= rhs, lhs.y <= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint lhs, uint2 rhs) => new bool2(lhs <= rhs.x, lhs <= rhs.y);

        /// <summary>
        /// Returns a bvec from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint lhs, uint rhs) => new bool2(lhs <= rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Abs (v).
        /// </summary>
        public static uint2 Abs(uint2 v) => new uint2(v.x, v.y);

        /// <summary>
        /// Returns a uvec from the application of Abs (v).
        /// </summary>
        public static uint2 Abs(uint v) => new uint2(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder3(uint2 v) => new uint2((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y);

        /// <summary>
        /// Returns a uvec from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder3(uint v) => new uint2((3 - 2 * v) * v * v);

        /// <summary>
        /// Returns a uint2 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder5(uint2 v) => new uint2(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y);

        /// <summary>
        /// Returns a uvec from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder5(uint v) => new uint2(((6 * v - 15) * v + 10) * v * v * v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Sqr (v * v).
        /// </summary>
        public static uint2 Sqr(uint2 v) => new uint2(v.x * v.x, v.y * v.y);

        /// <summary>
        /// Returns a uvec from the application of Sqr (v * v).
        /// </summary>
        public static uint2 Sqr(uint v) => new uint2(v * v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static uint2 Pow2(uint2 v) => new uint2(v.x * v.x, v.y * v.y);

        /// <summary>
        /// Returns a uvec from the application of Pow2 (v * v).
        /// </summary>
        public static uint2 Pow2(uint v) => new uint2(v * v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static uint2 Pow3(uint2 v) => new uint2(v.x * v.x * v.x, v.y * v.y * v.y);

        /// <summary>
        /// Returns a uvec from the application of Pow3 (v * v * v).
        /// </summary>
        public static uint2 Pow3(uint v) => new uint2(v * v * v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint2 Step(uint2 v) => new uint2(v.x >= 0u ? 1u : 0u, v.y >= 0u ? 1u : 0u);

        /// <summary>
        /// Returns a uvec from the application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint2 Step(uint v) => new uint2(v >= 0u ? 1u : 0u);

        /// <summary>
        /// Returns a uint2 from component-wise application of Sqrt ((uint)Math.Sqrt((double)v)).
        /// </summary>
        public static uint2 Sqrt(uint2 v) => new uint2((uint)Math.Sqrt(v.x), (uint)Math.Sqrt(v.y));

        /// <summary>
        /// Returns a uvec from the application of Sqrt ((uint)Math.Sqrt((double)v)).
        /// </summary>
        public static uint2 Sqrt(uint v) => new uint2((uint)Math.Sqrt(v));

        /// <summary>
        /// Returns a uint2 from component-wise application of InverseSqrt ((uint)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static uint2 InverseSqrt(uint2 v) => new uint2((uint)(1.0 / Math.Sqrt(v.x)), (uint)(1.0 / Math.Sqrt(v.y)));

        /// <summary>
        /// Returns a uvec from the application of InverseSqrt ((uint)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static uint2 InverseSqrt(uint v) => new uint2((uint)(1.0 / Math.Sqrt(v)));

        /// <summary>
        /// Returns a int2 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int2 Sign(uint2 v) => new int2(Math.Sign(v.x), Math.Sign(v.y));

        /// <summary>
        /// Returns a ivec from the application of Sign (Math.Sign(v)).
        /// </summary>
        public static int2 Sign(uint v) => new int2(Math.Sign(v));

        /// <summary>
        /// Returns a uint2 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint2 lhs, uint2 rhs) => new uint2(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y));

        /// <summary>
        /// Returns a uint2 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint2 lhs, uint rhs) => new uint2(Math.Max(lhs.x, rhs), Math.Max(lhs.y, rhs));

        /// <summary>
        /// Returns a uint2 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint lhs, uint2 rhs) => new uint2(Math.Max(lhs, rhs.x), Math.Max(lhs, rhs.y));

        /// <summary>
        /// Returns a uvec from the application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint lhs, uint rhs) => new uint2(Math.Max(lhs, rhs));

        /// <summary>
        /// Returns a uint2 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint2 lhs, uint2 rhs) => new uint2(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y));

        /// <summary>
        /// Returns a uint2 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint2 lhs, uint rhs) => new uint2(Math.Min(lhs.x, rhs), Math.Min(lhs.y, rhs));

        /// <summary>
        /// Returns a uint2 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint lhs, uint2 rhs) => new uint2(Math.Min(lhs, rhs.x), Math.Min(lhs, rhs.y));

        /// <summary>
        /// Returns a uvec from the application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint lhs, uint rhs) => new uint2(Math.Min(lhs, rhs));

        /// <summary>
        /// Returns a uint2 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint2 lhs, uint2 rhs) => new uint2((uint)Math.Pow(lhs.x, rhs.x), (uint)Math.Pow(lhs.y, rhs.y));

        /// <summary>
        /// Returns a uint2 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint2 lhs, uint rhs) => new uint2((uint)Math.Pow(lhs.x, rhs), (uint)Math.Pow(lhs.y, rhs));

        /// <summary>
        /// Returns a uint2 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint lhs, uint2 rhs) => new uint2((uint)Math.Pow(lhs, rhs.x), (uint)Math.Pow(lhs, rhs.y));

        /// <summary>
        /// Returns a uvec from the application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint lhs, uint rhs) => new uint2((uint)Math.Pow(lhs, rhs));

        /// <summary>
        /// Returns a uint2 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint2 lhs, uint2 rhs) => new uint2((uint)Math.Log(lhs.x, rhs.x), (uint)Math.Log(lhs.y, rhs.y));

        /// <summary>
        /// Returns a uint2 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint2 lhs, uint rhs) => new uint2((uint)Math.Log(lhs.x, rhs), (uint)Math.Log(lhs.y, rhs));

        /// <summary>
        /// Returns a uint2 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint lhs, uint2 rhs) => new uint2((uint)Math.Log(lhs, rhs.x), (uint)Math.Log(lhs, rhs.y));

        /// <summary>
        /// Returns a uvec from the application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint lhs, uint rhs) => new uint2((uint)Math.Log(lhs, rhs));

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint2 min, uint2 max) => new uint2(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y));

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint2 min, uint max) => new uint2(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max));

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint min, uint2 max) => new uint2(Math.Min(Math.Max(v.x, min), max.x), Math.Min(Math.Max(v.y, min), max.y));

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint min, uint max) => new uint2(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max));

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint v, uint2 min, uint2 max) => new uint2(Math.Min(Math.Max(v, min.x), max.x), Math.Min(Math.Max(v, min.y), max.y));

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint v, uint2 min, uint max) => new uint2(Math.Min(Math.Max(v, min.x), max), Math.Min(Math.Max(v, min.y), max));

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint v, uint min, uint2 max) => new uint2(Math.Min(Math.Max(v, min), max.x), Math.Min(Math.Max(v, min), max.y));

        /// <summary>
        /// Returns a uvec from the application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint v, uint min, uint max) => new uint2(Math.Min(Math.Max(v, min), max));

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint2 max, uint2 a) => new uint2(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint2 max, uint a) => new uint2(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint max, uint2 a) => new uint2(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint max, uint a) => new uint2(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint min, uint2 max, uint2 a) => new uint2(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint min, uint2 max, uint a) => new uint2(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint min, uint max, uint2 a) => new uint2(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y);

        /// <summary>
        /// Returns a uvec from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint min, uint max, uint a) => new uint2(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint2 max, uint2 a) => new uint2(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint2 max, uint a) => new uint2(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint max, uint2 a) => new uint2(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint max, uint a) => new uint2(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint min, uint2 max, uint2 a) => new uint2(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint min, uint2 max, uint a) => new uint2(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint min, uint max, uint2 a) => new uint2(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y);

        /// <summary>
        /// Returns a uvec from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint min, uint max, uint a) => new uint2(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint2 edge0, uint2 edge1, uint2 v) => new uint2(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint2 edge0, uint2 edge1, uint v) => new uint2(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint2 edge0, uint edge1, uint2 v) => new uint2(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint2 edge0, uint edge1, uint v) => new uint2(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint edge0, uint2 edge1, uint2 v) => new uint2(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint edge0, uint2 edge1, uint v) => new uint2(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint edge0, uint edge1, uint2 v) => new uint2(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uvec from the application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint edge0, uint edge1, uint v) => new uint2(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint2 edge0, uint2 edge1, uint2 v) => new uint2(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint2 edge0, uint2 edge1, uint v) => new uint2(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint2 edge0, uint edge1, uint2 v) => new uint2(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint2 edge0, uint edge1, uint v) => new uint2(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint edge0, uint2 edge1, uint2 v) => new uint2(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint edge0, uint2 edge1, uint v) => new uint2(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint edge0, uint edge1, uint2 v) => new uint2(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uvec from the application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint edge0, uint edge1, uint v) => new uint2(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint2 b, uint2 c) => new uint2(a.x * b.x + c.x, a.y * b.y + c.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint2 b, uint c) => new uint2(a.x * b.x + c, a.y * b.y + c);

        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint b, uint2 c) => new uint2(a.x * b + c.x, a.y * b + c.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint b, uint c) => new uint2(a.x * b + c, a.y * b + c);

        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint a, uint2 b, uint2 c) => new uint2(a * b.x + c.x, a * b.y + c.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint a, uint2 b, uint c) => new uint2(a * b.x + c, a * b.y + c);

        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint a, uint b, uint2 c) => new uint2(a * b + c.x, a * b + c.y);

        /// <summary>
        /// Returns a uvec from the application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint a, uint b, uint c) => new uint2(a * b + c);

        /// <summary>
        /// Returns a uint2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint2 lhs, uint2 rhs) => new uint2(lhs.x + rhs.x, lhs.y + rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint2 lhs, uint rhs) => new uint2(lhs.x + rhs, lhs.y + rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint lhs, uint2 rhs) => new uint2(lhs + rhs.x, lhs + rhs.y);

        /// <summary>
        /// Returns a uvec from the application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint lhs, uint rhs) => new uint2(lhs + rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint2 lhs, uint2 rhs) => new uint2(lhs.x - rhs.x, lhs.y - rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint2 lhs, uint rhs) => new uint2(lhs.x - rhs, lhs.y - rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint lhs, uint2 rhs) => new uint2(lhs - rhs.x, lhs - rhs.y);

        /// <summary>
        /// Returns a uvec from the application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint lhs, uint rhs) => new uint2(lhs - rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint2 lhs, uint2 rhs) => new uint2(lhs.x * rhs.x, lhs.y * rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint2 lhs, uint rhs) => new uint2(lhs.x * rhs, lhs.y * rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint lhs, uint2 rhs) => new uint2(lhs * rhs.x, lhs * rhs.y);

        /// <summary>
        /// Returns a uvec from the application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint lhs, uint rhs) => new uint2(lhs * rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint2 lhs, uint2 rhs) => new uint2(lhs.x / rhs.x, lhs.y / rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint2 lhs, uint rhs) => new uint2(lhs.x / rhs, lhs.y / rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint lhs, uint2 rhs) => new uint2(lhs / rhs.x, lhs / rhs.y);

        /// <summary>
        /// Returns a uvec from the application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint lhs, uint rhs) => new uint2(lhs / rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint2 lhs, uint2 rhs) => new uint2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint2 lhs, uint rhs) => new uint2(lhs.x ^ rhs, lhs.y ^ rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint lhs, uint2 rhs) => new uint2(lhs ^ rhs.x, lhs ^ rhs.y);

        /// <summary>
        /// Returns a uvec from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint lhs, uint rhs) => new uint2(lhs ^ rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint2 lhs, uint2 rhs) => new uint2(lhs.x | rhs.x, lhs.y | rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint2 lhs, uint rhs) => new uint2(lhs.x | rhs, lhs.y | rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint lhs, uint2 rhs) => new uint2(lhs | rhs.x, lhs | rhs.y);

        /// <summary>
        /// Returns a uvec from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint lhs, uint rhs) => new uint2(lhs | rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint2 lhs, uint2 rhs) => new uint2(lhs.x & rhs.x, lhs.y & rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint2 lhs, uint rhs) => new uint2(lhs.x & rhs, lhs.y & rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint lhs, uint2 rhs) => new uint2(lhs & rhs.x, lhs & rhs.y);

        /// <summary>
        /// Returns a uvec from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint lhs, uint rhs) => new uint2(lhs & rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint2 lhs, int2 rhs) => new uint2(lhs.x << rhs.x, lhs.y << rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint2 lhs, int rhs) => new uint2(lhs.x << rhs, lhs.y << rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint lhs, int2 rhs) => new uint2(lhs << rhs.x, lhs << rhs.y);

        /// <summary>
        /// Returns a uvec from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint lhs, int rhs) => new uint2(lhs << rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint2 lhs, int2 rhs) => new uint2(lhs.x >> rhs.x, lhs.y >> rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint2 lhs, int rhs) => new uint2(lhs.x >> rhs, lhs.y >> rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint lhs, int2 rhs) => new uint2(lhs >> rhs.x, lhs >> rhs.y);

        /// <summary>
        /// Returns a uvec from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint lhs, int rhs) => new uint2(lhs >> rhs);

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator <(uint2 lhs, uint2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator <(uint2 lhs, uint rhs) => new bool2(lhs.x < rhs, lhs.y < rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator <(uint lhs, uint2 rhs) => new bool2(lhs < rhs.x, lhs < rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator <=(uint2 lhs, uint2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator <=(uint2 lhs, uint rhs) => new bool2(lhs.x <= rhs, lhs.y <= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator <=(uint lhs, uint2 rhs) => new bool2(lhs <= rhs.x, lhs <= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator >(uint2 lhs, uint2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator >(uint2 lhs, uint rhs) => new bool2(lhs.x > rhs, lhs.y > rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator >(uint lhs, uint2 rhs) => new bool2(lhs > rhs.x, lhs > rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator >=(uint2 lhs, uint2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator >=(uint2 lhs, uint rhs) => new bool2(lhs.x >= rhs, lhs.y >= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator >=(uint lhs, uint2 rhs) => new bool2(lhs >= rhs.x, lhs >= rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator +(uint2 lhs, uint2 rhs) => new uint2(lhs.x + rhs.x, lhs.y + rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator +(uint2 lhs, uint rhs) => new uint2(lhs.x + rhs, lhs.y + rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator +(uint lhs, uint2 rhs) => new uint2(lhs + rhs.x, lhs + rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator -(uint2 lhs, uint2 rhs) => new uint2(lhs.x - rhs.x, lhs.y - rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator -(uint2 lhs, uint rhs) => new uint2(lhs.x - rhs, lhs.y - rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator -(uint lhs, uint2 rhs) => new uint2(lhs - rhs.x, lhs - rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator *(uint2 lhs, uint2 rhs) => new uint2(lhs.x * rhs.x, lhs.y * rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator *(uint2 lhs, uint rhs) => new uint2(lhs.x * rhs, lhs.y * rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator *(uint lhs, uint2 rhs) => new uint2(lhs * rhs.x, lhs * rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator /(uint2 lhs, uint2 rhs) => new uint2(lhs.x / rhs.x, lhs.y / rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator /(uint2 lhs, uint rhs) => new uint2(lhs.x / rhs, lhs.y / rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator /(uint lhs, uint2 rhs) => new uint2(lhs / rhs.x, lhs / rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (identity).
        /// </summary>
        public static uint2 operator +(uint2 v) => v;

        /// <summary>
        /// Returns a uint2 from component-wise application of operator~ (~v).
        /// </summary>
        public static uint2 operator ~(uint2 v) => new uint2(~v.x, ~v.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator ^(uint2 lhs, uint2 rhs) => new uint2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator ^(uint2 lhs, uint rhs) => new uint2(lhs.x ^ rhs, lhs.y ^ rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator ^(uint lhs, uint2 rhs) => new uint2(lhs ^ rhs.x, lhs ^ rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator |(uint2 lhs, uint2 rhs) => new uint2(lhs.x | rhs.x, lhs.y | rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator |(uint2 lhs, uint rhs) => new uint2(lhs.x | rhs, lhs.y | rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator |(uint lhs, uint2 rhs) => new uint2(lhs | rhs.x, lhs | rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator &(uint2 lhs, uint2 rhs) => new uint2(lhs.x & rhs.x, lhs.y & rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator &(uint2 lhs, uint rhs) => new uint2(lhs.x & rhs, lhs.y & rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator &(uint lhs, uint2 rhs) => new uint2(lhs & rhs.x, lhs & rhs.y);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 operator <<(uint2 lhs, int rhs) => new uint2(lhs.x << rhs, lhs.y << rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 operator >>(uint2 lhs, int rhs) => new uint2(lhs.x >> rhs, lhs.y >> rhs);

        #endregion

    }
}
