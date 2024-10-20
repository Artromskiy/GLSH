using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type int with 2 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct int2
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public int x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public int y;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public int2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public int2(int v)
        {
            this.x = v;
            this.y = v;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public int2(int2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public int2(int3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public int2(int4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        #endregion


        #region Implicit Operators

        /// <summary>
        /// Implicitly converts this to a float2.
        /// </summary>
        public static implicit operator float2(int2 v) => new float2(v.x, v.y);

        /// <summary>
        /// Implicitly converts this to a double2.
        /// </summary>
        public static implicit operator double2(int2 v) => new double2(v.x, v.y);

        #endregion


        #region Explicit Operators

        /// <summary>
        /// Explicitly converts this to a int3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int3(int2 v) => new int3(v.x, v.y, 0);

        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(int2 v) => new int4(v.x, v.y, 0, 0);

        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(int2 v) => new uint2((uint)v.x, (uint)v.y);

        /// <summary>
        /// Explicitly converts this to a uint3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint3(int2 v) => new uint3((uint)v.x, (uint)v.y, 0u);

        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(int2 v) => new uint4((uint)v.x, (uint)v.y, 0u, 0u);

        /// <summary>
        /// Explicitly converts this to a float3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float3(int2 v) => new float3(v.x, v.y, 0f);

        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(int2 v) => new float4(v.x, v.y, 0f, 0f);

        /// <summary>
        /// Explicitly converts this to a double3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double3(int2 v) => new double3(v.x, v.y, 0.0);

        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(int2 v) => new double4(v.x, v.y, 0.0, 0.0);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(int2 v) => new bool2(v.x != 0, v.y != 0);

        /// <summary>
        /// Explicitly converts this to a bool3. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool3(int2 v) => new bool3(v.x != 0, v.y != 0, false);

        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(int2 v) => new bool4(v.x != 0, v.y != 0, false, false);

        #endregion


        #region Indexer

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public int this[int index]
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
        public swizzle_ivec2 swizzle => new swizzle_ivec2(x, y);

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public int2 xy
        {
            get
            {
                return new int2(x, y);
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
        public int2 rg
        {
            get
            {
                return new int2(x, y);
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
        public int r
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
        public int g
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
        public int MinElement => Math.Min(x, y);

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public int MaxElement => Math.Max(x, y);

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
        public int Sum => (x + y);

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public float Norm => (float)Math.Sqrt((x * x + y * y));

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public float Norm1 => (Math.Abs(x) + Math.Abs(y));

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt((x * x + y * y));

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public float NormMax => Math.Max(Math.Abs(x), Math.Abs(y));

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static int2 Zero { get; } = new int2(0, 0);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static int2 Ones { get; } = new int2(1, 1);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static int2 UnitX { get; } = new int2(1, 0);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static int2 UnitY { get; } = new int2(0, 1);

        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        public static int2 MaxValue { get; } = new int2(int.MaxValue, int.MaxValue);

        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        public static int2 MinValue { get; } = new int2(int.MinValue, int.MinValue);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(int2 lhs, int2 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(int2 lhs, int2 rhs) => !lhs.Equals(rhs);

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
        public bool Equals(int2 rhs) => (x.Equals(rhs.x) && y.Equals(rhs.y));

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
        public double NormP(double p) => Math.Pow((Math.Pow(Math.Abs(x), p) + Math.Pow(Math.Abs(y), p)), 1 / p);

        #endregion


        #region Static Functions

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int2x2 OuterProduct(int2 c, int2 r) => new int2x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int2x3 OuterProduct(int3 c, int2 r) => new int2x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x2 OuterProduct(int2 c, int3 r) => new int3x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int2x4 OuterProduct(int4 c, int2 r) => new int2x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int4x2 OuterProduct(int2 c, int4 r) => new int4x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z, c.x * r.w, c.y * r.w);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static int Dot(int2 lhs, int2 rhs) => (lhs.x * rhs.x + lhs.y * rhs.y);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(int2 lhs, int2 rhs) => (lhs - rhs).Length;

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(int2 lhs, int2 rhs) => (lhs - rhs).LengthSqr;

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int2 Reflect(int2 I, int2 N) => I - 2 * Dot(N, I) * N;

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int2 Refract(int2 I, int2 N, int eta)
        {
            var dNI = Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (int)Math.Sqrt(k)) * N;
        }

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static int2 FaceForward(int2 N, int2 I, int2 Nref) => Dot(Nref, I) < 0 ? N : -N;

        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static int Cross(int2 l, int2 r) => l.x * r.y - l.y * r.x;

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(int2 lhs, int2 rhs) => new bool2(lhs.x == rhs.x, lhs.y == rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(int2 lhs, int rhs) => new bool2(lhs.x == rhs, lhs.y == rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(int lhs, int2 rhs) => new bool2(lhs == rhs.x, lhs == rhs.y);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(int lhs, int rhs) => new bool2(lhs == rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(int2 lhs, int2 rhs) => new bool2(lhs.x != rhs.x, lhs.y != rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(int2 lhs, int rhs) => new bool2(lhs.x != rhs, lhs.y != rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(int lhs, int2 rhs) => new bool2(lhs != rhs.x, lhs != rhs.y);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(int lhs, int rhs) => new bool2(lhs != rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(int2 lhs, int2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(int2 lhs, int rhs) => new bool2(lhs.x > rhs, lhs.y > rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(int lhs, int2 rhs) => new bool2(lhs > rhs.x, lhs > rhs.y);

        /// <summary>
        /// Returns a bvec from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(int lhs, int rhs) => new bool2(lhs > rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(int2 lhs, int2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(int2 lhs, int rhs) => new bool2(lhs.x >= rhs, lhs.y >= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(int lhs, int2 rhs) => new bool2(lhs >= rhs.x, lhs >= rhs.y);

        /// <summary>
        /// Returns a bvec from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(int lhs, int rhs) => new bool2(lhs >= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(int2 lhs, int2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(int2 lhs, int rhs) => new bool2(lhs.x < rhs, lhs.y < rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(int lhs, int2 rhs) => new bool2(lhs < rhs.x, lhs < rhs.y);

        /// <summary>
        /// Returns a bvec from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(int lhs, int rhs) => new bool2(lhs < rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(int2 lhs, int2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(int2 lhs, int rhs) => new bool2(lhs.x <= rhs, lhs.y <= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(int lhs, int2 rhs) => new bool2(lhs <= rhs.x, lhs <= rhs.y);

        /// <summary>
        /// Returns a bvec from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(int lhs, int rhs) => new bool2(lhs <= rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static int2 Abs(int2 v) => new int2(Math.Abs(v.x), Math.Abs(v.y));

        /// <summary>
        /// Returns a ivec from the application of Abs (Math.Abs(v)).
        /// </summary>
        public static int2 Abs(int v) => new int2(Math.Abs(v));

        /// <summary>
        /// Returns a int2 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int2 HermiteInterpolationOrder3(int2 v) => new int2((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y);

        /// <summary>
        /// Returns a ivec from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int2 HermiteInterpolationOrder3(int v) => new int2((3 - 2 * v) * v * v);

        /// <summary>
        /// Returns a int2 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int2 HermiteInterpolationOrder5(int2 v) => new int2(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y);

        /// <summary>
        /// Returns a ivec from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int2 HermiteInterpolationOrder5(int v) => new int2(((6 * v - 15) * v + 10) * v * v * v);

        /// <summary>
        /// Returns a int2 from component-wise application of Sqr (v * v).
        /// </summary>
        public static int2 Sqr(int2 v) => new int2(v.x * v.x, v.y * v.y);

        /// <summary>
        /// Returns a ivec from the application of Sqr (v * v).
        /// </summary>
        public static int2 Sqr(int v) => new int2(v * v);

        /// <summary>
        /// Returns a int2 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static int2 Pow2(int2 v) => new int2(v.x * v.x, v.y * v.y);

        /// <summary>
        /// Returns a ivec from the application of Pow2 (v * v).
        /// </summary>
        public static int2 Pow2(int v) => new int2(v * v);

        /// <summary>
        /// Returns a int2 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static int2 Pow3(int2 v) => new int2(v.x * v.x * v.x, v.y * v.y * v.y);

        /// <summary>
        /// Returns a ivec from the application of Pow3 (v * v * v).
        /// </summary>
        public static int2 Pow3(int v) => new int2(v * v * v);

        /// <summary>
        /// Returns a int2 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int2 Step(int2 v) => new int2(v.x >= 0 ? 1 : 0, v.y >= 0 ? 1 : 0);

        /// <summary>
        /// Returns a ivec from the application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int2 Step(int v) => new int2(v >= 0 ? 1 : 0);

        /// <summary>
        /// Returns a int2 from component-wise application of Sqrt ((int)Math.Sqrt((double)v)).
        /// </summary>
        public static int2 Sqrt(int2 v) => new int2((int)Math.Sqrt(v.x), (int)Math.Sqrt(v.y));

        /// <summary>
        /// Returns a ivec from the application of Sqrt ((int)Math.Sqrt((double)v)).
        /// </summary>
        public static int2 Sqrt(int v) => new int2((int)Math.Sqrt(v));

        /// <summary>
        /// Returns a int2 from component-wise application of InverseSqrt ((int)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static int2 InverseSqrt(int2 v) => new int2((int)(1.0 / Math.Sqrt(v.x)), (int)(1.0 / Math.Sqrt(v.y)));

        /// <summary>
        /// Returns a ivec from the application of InverseSqrt ((int)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static int2 InverseSqrt(int v) => new int2((int)(1.0 / Math.Sqrt(v)));

        /// <summary>
        /// Returns a int2 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int2 Sign(int2 v) => new int2(Math.Sign(v.x), Math.Sign(v.y));

        /// <summary>
        /// Returns a ivec from the application of Sign (Math.Sign(v)).
        /// </summary>
        public static int2 Sign(int v) => new int2(Math.Sign(v));

        /// <summary>
        /// Returns a int2 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int2 Max(int2 lhs, int2 rhs) => new int2(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y));

        /// <summary>
        /// Returns a int2 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int2 Max(int2 lhs, int rhs) => new int2(Math.Max(lhs.x, rhs), Math.Max(lhs.y, rhs));

        /// <summary>
        /// Returns a int2 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int2 Max(int lhs, int2 rhs) => new int2(Math.Max(lhs, rhs.x), Math.Max(lhs, rhs.y));

        /// <summary>
        /// Returns a ivec from the application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int2 Max(int lhs, int rhs) => new int2(Math.Max(lhs, rhs));

        /// <summary>
        /// Returns a int2 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int2 Min(int2 lhs, int2 rhs) => new int2(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y));

        /// <summary>
        /// Returns a int2 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int2 Min(int2 lhs, int rhs) => new int2(Math.Min(lhs.x, rhs), Math.Min(lhs.y, rhs));

        /// <summary>
        /// Returns a int2 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int2 Min(int lhs, int2 rhs) => new int2(Math.Min(lhs, rhs.x), Math.Min(lhs, rhs.y));

        /// <summary>
        /// Returns a ivec from the application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int2 Min(int lhs, int rhs) => new int2(Math.Min(lhs, rhs));

        /// <summary>
        /// Returns a int2 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int2 Pow(int2 lhs, int2 rhs) => new int2((int)Math.Pow(lhs.x, rhs.x), (int)Math.Pow(lhs.y, rhs.y));

        /// <summary>
        /// Returns a int2 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int2 Pow(int2 lhs, int rhs) => new int2((int)Math.Pow(lhs.x, rhs), (int)Math.Pow(lhs.y, rhs));

        /// <summary>
        /// Returns a int2 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int2 Pow(int lhs, int2 rhs) => new int2((int)Math.Pow(lhs, rhs.x), (int)Math.Pow(lhs, rhs.y));

        /// <summary>
        /// Returns a ivec from the application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int2 Pow(int lhs, int rhs) => new int2((int)Math.Pow(lhs, rhs));

        /// <summary>
        /// Returns a int2 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int2 Log(int2 lhs, int2 rhs) => new int2((int)Math.Log(lhs.x, rhs.x), (int)Math.Log(lhs.y, rhs.y));

        /// <summary>
        /// Returns a int2 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int2 Log(int2 lhs, int rhs) => new int2((int)Math.Log(lhs.x, rhs), (int)Math.Log(lhs.y, rhs));

        /// <summary>
        /// Returns a int2 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int2 Log(int lhs, int2 rhs) => new int2((int)Math.Log(lhs, rhs.x), (int)Math.Log(lhs, rhs.y));

        /// <summary>
        /// Returns a ivec from the application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int2 Log(int lhs, int rhs) => new int2((int)Math.Log(lhs, rhs));

        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int2 Clamp(int2 v, int2 min, int2 max) => new int2(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y));

        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int2 Clamp(int2 v, int2 min, int max) => new int2(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max));

        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int2 Clamp(int2 v, int min, int2 max) => new int2(Math.Min(Math.Max(v.x, min), max.x), Math.Min(Math.Max(v.y, min), max.y));

        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int2 Clamp(int2 v, int min, int max) => new int2(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max));

        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int2 Clamp(int v, int2 min, int2 max) => new int2(Math.Min(Math.Max(v, min.x), max.x), Math.Min(Math.Max(v, min.y), max.y));

        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int2 Clamp(int v, int2 min, int max) => new int2(Math.Min(Math.Max(v, min.x), max), Math.Min(Math.Max(v, min.y), max));

        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int2 Clamp(int v, int min, int2 max) => new int2(Math.Min(Math.Max(v, min), max.x), Math.Min(Math.Max(v, min), max.y));

        /// <summary>
        /// Returns a ivec from the application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int2 Clamp(int v, int min, int max) => new int2(Math.Min(Math.Max(v, min), max));

        /// <summary>
        /// Returns a int2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int2 Mix(int2 min, int2 max, int2 a) => new int2(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int2 Mix(int2 min, int2 max, int a) => new int2(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a);

        /// <summary>
        /// Returns a int2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int2 Mix(int2 min, int max, int2 a) => new int2(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int2 Mix(int2 min, int max, int a) => new int2(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a);

        /// <summary>
        /// Returns a int2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int2 Mix(int min, int2 max, int2 a) => new int2(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int2 Mix(int min, int2 max, int a) => new int2(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a);

        /// <summary>
        /// Returns a int2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int2 Mix(int min, int max, int2 a) => new int2(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y);

        /// <summary>
        /// Returns a ivec from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int2 Mix(int min, int max, int a) => new int2(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a int2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int2 Lerp(int2 min, int2 max, int2 a) => new int2(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int2 Lerp(int2 min, int2 max, int a) => new int2(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a);

        /// <summary>
        /// Returns a int2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int2 Lerp(int2 min, int max, int2 a) => new int2(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int2 Lerp(int2 min, int max, int a) => new int2(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a);

        /// <summary>
        /// Returns a int2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int2 Lerp(int min, int2 max, int2 a) => new int2(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int2 Lerp(int min, int2 max, int a) => new int2(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a);

        /// <summary>
        /// Returns a int2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int2 Lerp(int min, int max, int2 a) => new int2(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y);

        /// <summary>
        /// Returns a ivec from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int2 Lerp(int min, int max, int a) => new int2(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a int2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int2 Smoothstep(int2 edge0, int2 edge1, int2 v) => new int2(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int2 Smoothstep(int2 edge0, int2 edge1, int v) => new int2(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int2 Smoothstep(int2 edge0, int edge1, int2 v) => new int2(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int2 Smoothstep(int2 edge0, int edge1, int v) => new int2(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int2 Smoothstep(int edge0, int2 edge1, int2 v) => new int2(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int2 Smoothstep(int edge0, int2 edge1, int v) => new int2(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int2 Smoothstep(int edge0, int edge1, int2 v) => new int2(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a ivec from the application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int2 Smoothstep(int edge0, int edge1, int v) => new int2(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int2 Smootherstep(int2 edge0, int2 edge1, int2 v) => new int2(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int2 Smootherstep(int2 edge0, int2 edge1, int v) => new int2(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int2 Smootherstep(int2 edge0, int edge1, int2 v) => new int2(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int2 Smootherstep(int2 edge0, int edge1, int v) => new int2(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int2 Smootherstep(int edge0, int2 edge1, int2 v) => new int2(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int2 Smootherstep(int edge0, int2 edge1, int v) => new int2(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int2 Smootherstep(int edge0, int edge1, int2 v) => new int2(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a ivec from the application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int2 Smootherstep(int edge0, int edge1, int v) => new int2(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int2 Fma(int2 a, int2 b, int2 c) => new int2(a.x * b.x + c.x, a.y * b.y + c.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int2 Fma(int2 a, int2 b, int c) => new int2(a.x * b.x + c, a.y * b.y + c);

        /// <summary>
        /// Returns a int2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int2 Fma(int2 a, int b, int2 c) => new int2(a.x * b + c.x, a.y * b + c.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int2 Fma(int2 a, int b, int c) => new int2(a.x * b + c, a.y * b + c);

        /// <summary>
        /// Returns a int2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int2 Fma(int a, int2 b, int2 c) => new int2(a * b.x + c.x, a * b.y + c.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int2 Fma(int a, int2 b, int c) => new int2(a * b.x + c, a * b.y + c);

        /// <summary>
        /// Returns a int2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int2 Fma(int a, int b, int2 c) => new int2(a * b + c.x, a * b + c.y);

        /// <summary>
        /// Returns a ivec from the application of Fma (a * b + c).
        /// </summary>
        public static int2 Fma(int a, int b, int c) => new int2(a * b + c);

        /// <summary>
        /// Returns a int2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int2 Add(int2 lhs, int2 rhs) => new int2(lhs.x + rhs.x, lhs.y + rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int2 Add(int2 lhs, int rhs) => new int2(lhs.x + rhs, lhs.y + rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int2 Add(int lhs, int2 rhs) => new int2(lhs + rhs.x, lhs + rhs.y);

        /// <summary>
        /// Returns a ivec from the application of Add (lhs + rhs).
        /// </summary>
        public static int2 Add(int lhs, int rhs) => new int2(lhs + rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int2 Sub(int2 lhs, int2 rhs) => new int2(lhs.x - rhs.x, lhs.y - rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int2 Sub(int2 lhs, int rhs) => new int2(lhs.x - rhs, lhs.y - rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int2 Sub(int lhs, int2 rhs) => new int2(lhs - rhs.x, lhs - rhs.y);

        /// <summary>
        /// Returns a ivec from the application of Sub (lhs - rhs).
        /// </summary>
        public static int2 Sub(int lhs, int rhs) => new int2(lhs - rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int2 Mul(int2 lhs, int2 rhs) => new int2(lhs.x * rhs.x, lhs.y * rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int2 Mul(int2 lhs, int rhs) => new int2(lhs.x * rhs, lhs.y * rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int2 Mul(int lhs, int2 rhs) => new int2(lhs * rhs.x, lhs * rhs.y);

        /// <summary>
        /// Returns a ivec from the application of Mul (lhs * rhs).
        /// </summary>
        public static int2 Mul(int lhs, int rhs) => new int2(lhs * rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int2 Div(int2 lhs, int2 rhs) => new int2(lhs.x / rhs.x, lhs.y / rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int2 Div(int2 lhs, int rhs) => new int2(lhs.x / rhs, lhs.y / rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int2 Div(int lhs, int2 rhs) => new int2(lhs / rhs.x, lhs / rhs.y);

        /// <summary>
        /// Returns a ivec from the application of Div (lhs / rhs).
        /// </summary>
        public static int2 Div(int lhs, int rhs) => new int2(lhs / rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int2 Xor(int2 lhs, int2 rhs) => new int2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int2 Xor(int2 lhs, int rhs) => new int2(lhs.x ^ rhs, lhs.y ^ rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int2 Xor(int lhs, int2 rhs) => new int2(lhs ^ rhs.x, lhs ^ rhs.y);

        /// <summary>
        /// Returns a ivec from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static int2 Xor(int lhs, int rhs) => new int2(lhs ^ rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int2 BitwiseOr(int2 lhs, int2 rhs) => new int2(lhs.x | rhs.x, lhs.y | rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int2 BitwiseOr(int2 lhs, int rhs) => new int2(lhs.x | rhs, lhs.y | rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int2 BitwiseOr(int lhs, int2 rhs) => new int2(lhs | rhs.x, lhs | rhs.y);

        /// <summary>
        /// Returns a ivec from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int2 BitwiseOr(int lhs, int rhs) => new int2(lhs | rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int2 BitwiseAnd(int2 lhs, int2 rhs) => new int2(lhs.x & rhs.x, lhs.y & rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int2 BitwiseAnd(int2 lhs, int rhs) => new int2(lhs.x & rhs, lhs.y & rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int2 BitwiseAnd(int lhs, int2 rhs) => new int2(lhs & rhs.x, lhs & rhs.y);

        /// <summary>
        /// Returns a ivec from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int2 BitwiseAnd(int lhs, int rhs) => new int2(lhs & rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int2 LeftShift(int2 lhs, int2 rhs) => new int2(lhs.x << rhs.x, lhs.y << rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int2 LeftShift(int2 lhs, int rhs) => new int2(lhs.x << rhs, lhs.y << rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int2 LeftShift(int lhs, int2 rhs) => new int2(lhs << rhs.x, lhs << rhs.y);

        /// <summary>
        /// Returns a ivec from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int2 LeftShift(int lhs, int rhs) => new int2(lhs << rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int2 RightShift(int2 lhs, int2 rhs) => new int2(lhs.x >> rhs.x, lhs.y >> rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int2 RightShift(int2 lhs, int rhs) => new int2(lhs.x >> rhs, lhs.y >> rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int2 RightShift(int lhs, int2 rhs) => new int2(lhs >> rhs.x, lhs >> rhs.y);

        /// <summary>
        /// Returns a ivec from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int2 RightShift(int lhs, int rhs) => new int2(lhs >> rhs);

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator <(int2 lhs, int2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator <(int2 lhs, int rhs) => new bool2(lhs.x < rhs, lhs.y < rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool2 operator <(int lhs, int2 rhs) => new bool2(lhs < rhs.x, lhs < rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator <=(int2 lhs, int2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator <=(int2 lhs, int rhs) => new bool2(lhs.x <= rhs, lhs.y <= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool2 operator <=(int lhs, int2 rhs) => new bool2(lhs <= rhs.x, lhs <= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator >(int2 lhs, int2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator >(int2 lhs, int rhs) => new bool2(lhs.x > rhs, lhs.y > rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool2 operator >(int lhs, int2 rhs) => new bool2(lhs > rhs.x, lhs > rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator >=(int2 lhs, int2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator >=(int2 lhs, int rhs) => new bool2(lhs.x >= rhs, lhs.y >= rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool2 operator >=(int lhs, int2 rhs) => new bool2(lhs >= rhs.x, lhs >= rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int2 operator +(int2 lhs, int2 rhs) => new int2(lhs.x + rhs.x, lhs.y + rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int2 operator +(int2 lhs, int rhs) => new int2(lhs.x + rhs, lhs.y + rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int2 operator +(int lhs, int2 rhs) => new int2(lhs + rhs.x, lhs + rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int2 operator -(int2 lhs, int2 rhs) => new int2(lhs.x - rhs.x, lhs.y - rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int2 operator -(int2 lhs, int rhs) => new int2(lhs.x - rhs, lhs.y - rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int2 operator -(int lhs, int2 rhs) => new int2(lhs - rhs.x, lhs - rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int2 operator *(int2 lhs, int2 rhs) => new int2(lhs.x * rhs.x, lhs.y * rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int2 operator *(int2 lhs, int rhs) => new int2(lhs.x * rhs, lhs.y * rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int2 operator *(int lhs, int2 rhs) => new int2(lhs * rhs.x, lhs * rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int2 operator /(int2 lhs, int2 rhs) => new int2(lhs.x / rhs.x, lhs.y / rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int2 operator /(int2 lhs, int rhs) => new int2(lhs.x / rhs, lhs.y / rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int2 operator /(int lhs, int2 rhs) => new int2(lhs / rhs.x, lhs / rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator+ (identity).
        /// </summary>
        public static int2 operator +(int2 v) => v;

        /// <summary>
        /// Returns a int2 from component-wise application of operator- (-v).
        /// </summary>
        public static int2 operator -(int2 v) => new int2(-v.x, -v.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator~ (~v).
        /// </summary>
        public static int2 operator ~(int2 v) => new int2(~v.x, ~v.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int2 operator ^(int2 lhs, int2 rhs) => new int2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int2 operator ^(int2 lhs, int rhs) => new int2(lhs.x ^ rhs, lhs.y ^ rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int2 operator ^(int lhs, int2 rhs) => new int2(lhs ^ rhs.x, lhs ^ rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int2 operator |(int2 lhs, int2 rhs) => new int2(lhs.x | rhs.x, lhs.y | rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int2 operator |(int2 lhs, int rhs) => new int2(lhs.x | rhs, lhs.y | rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int2 operator |(int lhs, int2 rhs) => new int2(lhs | rhs.x, lhs | rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int2 operator &(int2 lhs, int2 rhs) => new int2(lhs.x & rhs.x, lhs.y & rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int2 operator &(int2 lhs, int rhs) => new int2(lhs.x & rhs, lhs.y & rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int2 operator &(int lhs, int2 rhs) => new int2(lhs & rhs.x, lhs & rhs.y);

        /// <summary>
        /// Returns a int2 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int2 operator <<(int2 lhs, int rhs) => new int2(lhs.x << rhs, lhs.y << rhs);

        /// <summary>
        /// Returns a int2 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int2 operator >>(int2 lhs, int rhs) => new int2(lhs.x >> rhs, lhs.y >> rhs);

        #endregion

    }
}
