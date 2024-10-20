using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type float with 3 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct float3
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public float x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public float y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        public float z;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public float3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public float3(float v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public float3(float2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0f;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public float3(float2 v, float z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public float3(float3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public float3(float4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        #endregion


        #region Implicit Operators

        /// <summary>
        /// Implicitly converts this to a double3.
        /// </summary>
        public static implicit operator double3(float3 v) => new double3(v.x, v.y, v.z);

        #endregion


        #region Explicit Operators

        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(float3 v) => new int2((int)v.x, (int)v.y);

        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(float3 v) => new int3((int)v.x, (int)v.y, (int)v.z);

        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(float3 v) => new int4((int)v.x, (int)v.y, (int)v.z, 0);

        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(float3 v) => new uint2((uint)v.x, (uint)v.y);

        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(float3 v) => new uint3((uint)v.x, (uint)v.y, (uint)v.z);

        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(float3 v) => new uint4((uint)v.x, (uint)v.y, (uint)v.z, 0u);

        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(float3 v) => new float2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(float3 v) => new float4(v.x, v.y, v.z, 0f);

        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(float3 v) => new double2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(float3 v) => new double4(v.x, v.y, v.z, 0.0);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(float3 v) => new bool2(v.x != 0f, v.y != 0f);

        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(float3 v) => new bool3(v.x != 0f, v.y != 0f, v.z != 0f);

        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(float3 v) => new bool4(v.x != 0f, v.y != 0f, v.z != 0f, false);

        #endregion


        #region Indexer

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public float this[int index]
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
        public swizzle_vec3 swizzle => new swizzle_vec3(x, y, z);

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public float2 xy
        {
            get
            {
                return new float2(x, y);
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
        public float2 xz
        {
            get
            {
                return new float2(x, z);
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
        public float2 yz
        {
            get
            {
                return new float2(y, z);
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
        public float3 xyz
        {
            get
            {
                return new float3(x, y, z);
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
        public float2 rg
        {
            get
            {
                return new float2(x, y);
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
        public float2 rb
        {
            get
            {
                return new float2(x, z);
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
        public float2 gb
        {
            get
            {
                return new float2(y, z);
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
        public float3 rgb
        {
            get
            {
                return new float3(x, y, z);
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
        public float r
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
        public float g
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
        public float b
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
        public float MinElement => Math.Min(Math.Min(x, y), z);

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public float MaxElement => Math.Max(Math.Max(x, y), z);

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
        public float Sum => ((x + y) + z);

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public float Norm => (float)Math.Sqrt(((x * x + y * y) + z * z));

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public float Norm1 => ((Math.Abs(x) + Math.Abs(y)) + Math.Abs(z));

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt(((x * x + y * y) + z * z));

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public float NormMax => Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs(z));

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public float3 Normalized => this / (float)Length;

        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        public float3 NormalizedSafe => this == Zero ? Zero : this / (float)Length;

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static float3 Zero { get; } = new float3(0f, 0f, 0f);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static float3 Ones { get; } = new float3(1f, 1f, 1f);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static float3 UnitX { get; } = new float3(1f, 0f, 0f);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static float3 UnitY { get; } = new float3(0f, 1f, 0f);

        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        public static float3 UnitZ { get; } = new float3(0f, 0f, 1f);

        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        public static float3 MaxValue { get; } = new float3(float.MaxValue, float.MaxValue, float.MaxValue);

        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        public static float3 MinValue { get; } = new float3(float.MinValue, float.MinValue, float.MinValue);

        /// <summary>
        /// Predefined all-Epsilon vector
        /// </summary>
        public static float3 Epsilon { get; } = new float3(float.Epsilon, float.Epsilon, float.Epsilon);

        /// <summary>
        /// Predefined all-NaN vector
        /// </summary>
        public static float3 NaN { get; } = new float3(float.NaN, float.NaN, float.NaN);

        /// <summary>
        /// Predefined all-NegativeInfinity vector
        /// </summary>
        public static float3 NegativeInfinity { get; } = new float3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

        /// <summary>
        /// Predefined all-PositiveInfinity vector
        /// </summary>
        public static float3 PositiveInfinity { get; } = new float3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(float3 lhs, float3 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(float3 lhs, float3 rhs) => !lhs.Equals(rhs);

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
        public bool Equals(float3 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z));

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
        public double NormP(double p) => Math.Pow(((Math.Pow((double)Math.Abs(x), p) + Math.Pow((double)Math.Abs(y), p)) + Math.Pow((double)Math.Abs(z), p)), 1 / p);

        #endregion


        #region Static Functions

        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        public static bool ApproxEqual(float3 lhs, float3 rhs, float eps = 0.1f) => Distance(lhs, rhs) <= eps;

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float3x2 OuterProduct(float2 c, float3 r) => new float3x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float2x3 OuterProduct(float3 c, float2 r) => new float2x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float3x3 OuterProduct(float3 c, float3 r) => new float3x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float3x4 OuterProduct(float4 c, float3 r) => new float3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float4x3 OuterProduct(float3 c, float4 r) => new float4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static float Dot(float3 lhs, float3 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + lhs.z * rhs.z);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(float3 lhs, float3 rhs) => (lhs - rhs).Length;

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(float3 lhs, float3 rhs) => (lhs - rhs).LengthSqr;

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float3 Reflect(float3 I, float3 N) => I - 2 * Dot(N, I) * N;

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float3 Refract(float3 I, float3 N, float eta)
        {
            var dNI = Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (float)Math.Sqrt(k)) * N;
        }

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static float3 FaceForward(float3 N, float3 I, float3 Nref) => Dot(Nref, I) < 0 ? N : -N;

        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static float3 Cross(float3 l, float3 r) => new float3(l.y * r.z - l.z * r.y, l.z * r.x - l.x * r.z, l.x * r.y - l.y * r.x);

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(float3 lhs, float3 rhs) => new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(float3 lhs, float rhs) => new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(float lhs, float3 rhs) => new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(float lhs, float rhs) => new bool3(lhs == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(float3 lhs, float3 rhs) => new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(float3 lhs, float rhs) => new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(float lhs, float3 rhs) => new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(float lhs, float rhs) => new bool3(lhs != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(float3 lhs, float3 rhs) => new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(float3 lhs, float rhs) => new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(float lhs, float3 rhs) => new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);

        /// <summary>
        /// Returns a bvec from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(float lhs, float rhs) => new bool3(lhs > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(float3 lhs, float3 rhs) => new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(float3 lhs, float rhs) => new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(float lhs, float3 rhs) => new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);

        /// <summary>
        /// Returns a bvec from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(float lhs, float rhs) => new bool3(lhs >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(float3 lhs, float3 rhs) => new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(float3 lhs, float rhs) => new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(float lhs, float3 rhs) => new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);

        /// <summary>
        /// Returns a bvec from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(float lhs, float rhs) => new bool3(lhs < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(float3 lhs, float3 rhs) => new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(float3 lhs, float rhs) => new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(float lhs, float3 rhs) => new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);

        /// <summary>
        /// Returns a bvec from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(float lhs, float rhs) => new bool3(lhs <= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (float.IsInfinity(v)).
        /// </summary>
        public static bool3 IsInfinity(float3 v) => new bool3(float.IsInfinity(v.x), float.IsInfinity(v.y), float.IsInfinity(v.z));

        /// <summary>
        /// Returns a bvec from the application of IsInfinity (float.IsInfinity(v)).
        /// </summary>
        public static bool3 IsInfinity(float v) => new bool3(float.IsInfinity(v));

        /// <summary>
        /// Returns a bool3 from component-wise application of IsFinite (!float.IsNaN(v) &amp;&amp; !float.IsInfinity(v)).
        /// </summary>
        public static bool3 IsFinite(float3 v) => new bool3(!float.IsNaN(v.x) && !float.IsInfinity(v.x), !float.IsNaN(v.y) && !float.IsInfinity(v.y), !float.IsNaN(v.z) && !float.IsInfinity(v.z));

        /// <summary>
        /// Returns a bvec from the application of IsFinite (!float.IsNaN(v) &amp;&amp; !float.IsInfinity(v)).
        /// </summary>
        public static bool3 IsFinite(float v) => new bool3(!float.IsNaN(v) && !float.IsInfinity(v));

        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (float.IsNaN(v)).
        /// </summary>
        public static bool3 IsNaN(float3 v) => new bool3(float.IsNaN(v.x), float.IsNaN(v.y), float.IsNaN(v.z));

        /// <summary>
        /// Returns a bvec from the application of IsNaN (float.IsNaN(v)).
        /// </summary>
        public static bool3 IsNaN(float v) => new bool3(float.IsNaN(v));

        /// <summary>
        /// Returns a bool3 from component-wise application of IsNegativeInfinity (float.IsNegativeInfinity(v)).
        /// </summary>
        public static bool3 IsNegativeInfinity(float3 v) => new bool3(float.IsNegativeInfinity(v.x), float.IsNegativeInfinity(v.y), float.IsNegativeInfinity(v.z));

        /// <summary>
        /// Returns a bvec from the application of IsNegativeInfinity (float.IsNegativeInfinity(v)).
        /// </summary>
        public static bool3 IsNegativeInfinity(float v) => new bool3(float.IsNegativeInfinity(v));

        /// <summary>
        /// Returns a bool3 from component-wise application of IsPositiveInfinity (float.IsPositiveInfinity(v)).
        /// </summary>
        public static bool3 IsPositiveInfinity(float3 v) => new bool3(float.IsPositiveInfinity(v.x), float.IsPositiveInfinity(v.y), float.IsPositiveInfinity(v.z));

        /// <summary>
        /// Returns a bvec from the application of IsPositiveInfinity (float.IsPositiveInfinity(v)).
        /// </summary>
        public static bool3 IsPositiveInfinity(float v) => new bool3(float.IsPositiveInfinity(v));

        /// <summary>
        /// Returns a float3 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static float3 Abs(float3 v) => new float3(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z));

        /// <summary>
        /// Returns a vec from the application of Abs (Math.Abs(v)).
        /// </summary>
        public static float3 Abs(float v) => new float3(Math.Abs(v));

        /// <summary>
        /// Returns a float3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static float3 HermiteInterpolationOrder3(float3 v) => new float3((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z);

        /// <summary>
        /// Returns a vec from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static float3 HermiteInterpolationOrder3(float v) => new float3((3 - 2 * v) * v * v);

        /// <summary>
        /// Returns a float3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static float3 HermiteInterpolationOrder5(float3 v) => new float3(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z);

        /// <summary>
        /// Returns a vec from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static float3 HermiteInterpolationOrder5(float v) => new float3(((6 * v - 15) * v + 10) * v * v * v);

        /// <summary>
        /// Returns a float3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static float3 Sqr(float3 v) => new float3(v.x * v.x, v.y * v.y, v.z * v.z);

        /// <summary>
        /// Returns a vec from the application of Sqr (v * v).
        /// </summary>
        public static float3 Sqr(float v) => new float3(v * v);

        /// <summary>
        /// Returns a float3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static float3 Pow2(float3 v) => new float3(v.x * v.x, v.y * v.y, v.z * v.z);

        /// <summary>
        /// Returns a vec from the application of Pow2 (v * v).
        /// </summary>
        public static float3 Pow2(float v) => new float3(v * v);

        /// <summary>
        /// Returns a float3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static float3 Pow3(float3 v) => new float3(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z);

        /// <summary>
        /// Returns a vec from the application of Pow3 (v * v * v).
        /// </summary>
        public static float3 Pow3(float v) => new float3(v * v * v);

        /// <summary>
        /// Returns a float3 from component-wise application of Step (v &gt;= 0f ? 1f : 0f).
        /// </summary>
        public static float3 Step(float3 v) => new float3(v.x >= 0f ? 1f : 0f, v.y >= 0f ? 1f : 0f, v.z >= 0f ? 1f : 0f);

        /// <summary>
        /// Returns a vec from the application of Step (v &gt;= 0f ? 1f : 0f).
        /// </summary>
        public static float3 Step(float v) => new float3(v >= 0f ? 1f : 0f);

        /// <summary>
        /// Returns a float3 from component-wise application of Sqrt ((float)Math.Sqrt((double)v)).
        /// </summary>
        public static float3 Sqrt(float3 v) => new float3((float)Math.Sqrt(v.x), (float)Math.Sqrt(v.y), (float)Math.Sqrt(v.z));

        /// <summary>
        /// Returns a vec from the application of Sqrt ((float)Math.Sqrt((double)v)).
        /// </summary>
        public static float3 Sqrt(float v) => new float3((float)Math.Sqrt((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of InverseSqrt ((float)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static float3 InverseSqrt(float3 v) => new float3((float)(1.0 / Math.Sqrt(v.x)), (float)(1.0 / Math.Sqrt(v.y)), (float)(1.0 / Math.Sqrt(v.z)));

        /// <summary>
        /// Returns a vec from the application of InverseSqrt ((float)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static float3 InverseSqrt(float v) => new float3((float)(1.0 / Math.Sqrt((double)v)));

        /// <summary>
        /// Returns a int3 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int3 Sign(float3 v) => new int3(Math.Sign(v.x), Math.Sign(v.y), Math.Sign(v.z));

        /// <summary>
        /// Returns a ivec from the application of Sign (Math.Sign(v)).
        /// </summary>
        public static int3 Sign(float v) => new int3(Math.Sign(v));

        /// <summary>
        /// Returns a float3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static float3 Max(float3 lhs, float3 rhs) => new float3(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z));

        /// <summary>
        /// Returns a float3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static float3 Max(float3 lhs, float rhs) => new float3(Math.Max(lhs.x, rhs), Math.Max(lhs.y, rhs), Math.Max(lhs.z, rhs));

        /// <summary>
        /// Returns a float3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static float3 Max(float lhs, float3 rhs) => new float3(Math.Max(lhs, rhs.x), Math.Max(lhs, rhs.y), Math.Max(lhs, rhs.z));

        /// <summary>
        /// Returns a vec from the application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static float3 Max(float lhs, float rhs) => new float3(Math.Max(lhs, rhs));

        /// <summary>
        /// Returns a float3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static float3 Min(float3 lhs, float3 rhs) => new float3(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z));

        /// <summary>
        /// Returns a float3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static float3 Min(float3 lhs, float rhs) => new float3(Math.Min(lhs.x, rhs), Math.Min(lhs.y, rhs), Math.Min(lhs.z, rhs));

        /// <summary>
        /// Returns a float3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static float3 Min(float lhs, float3 rhs) => new float3(Math.Min(lhs, rhs.x), Math.Min(lhs, rhs.y), Math.Min(lhs, rhs.z));

        /// <summary>
        /// Returns a vec from the application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static float3 Min(float lhs, float rhs) => new float3(Math.Min(lhs, rhs));

        /// <summary>
        /// Returns a float3 from component-wise application of Pow ((float)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static float3 Pow(float3 lhs, float3 rhs) => new float3((float)Math.Pow(lhs.x, rhs.x), (float)Math.Pow(lhs.y, rhs.y), (float)Math.Pow(lhs.z, rhs.z));

        /// <summary>
        /// Returns a float3 from component-wise application of Pow ((float)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static float3 Pow(float3 lhs, float rhs) => new float3((float)Math.Pow(lhs.x, (double)rhs), (float)Math.Pow(lhs.y, (double)rhs), (float)Math.Pow(lhs.z, (double)rhs));

        /// <summary>
        /// Returns a float3 from component-wise application of Pow ((float)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static float3 Pow(float lhs, float3 rhs) => new float3((float)Math.Pow((double)lhs, rhs.x), (float)Math.Pow((double)lhs, rhs.y), (float)Math.Pow((double)lhs, rhs.z));

        /// <summary>
        /// Returns a vec from the application of Pow ((float)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static float3 Pow(float lhs, float rhs) => new float3((float)Math.Pow((double)lhs, (double)rhs));

        /// <summary>
        /// Returns a float3 from component-wise application of Log ((float)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static float3 Log(float3 lhs, float3 rhs) => new float3((float)Math.Log(lhs.x, rhs.x), (float)Math.Log(lhs.y, rhs.y), (float)Math.Log(lhs.z, rhs.z));

        /// <summary>
        /// Returns a float3 from component-wise application of Log ((float)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static float3 Log(float3 lhs, float rhs) => new float3((float)Math.Log(lhs.x, (double)rhs), (float)Math.Log(lhs.y, (double)rhs), (float)Math.Log(lhs.z, (double)rhs));

        /// <summary>
        /// Returns a float3 from component-wise application of Log ((float)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static float3 Log(float lhs, float3 rhs) => new float3((float)Math.Log((double)lhs, rhs.x), (float)Math.Log((double)lhs, rhs.y), (float)Math.Log((double)lhs, rhs.z));

        /// <summary>
        /// Returns a vec from the application of Log ((float)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static float3 Log(float lhs, float rhs) => new float3((float)Math.Log((double)lhs, (double)rhs));

        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float3 Clamp(float3 v, float3 min, float3 max) => new float3(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z));

        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float3 Clamp(float3 v, float3 min, float max) => new float3(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max), Math.Min(Math.Max(v.z, min.z), max));

        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float3 Clamp(float3 v, float min, float3 max) => new float3(Math.Min(Math.Max(v.x, min), max.x), Math.Min(Math.Max(v.y, min), max.y), Math.Min(Math.Max(v.z, min), max.z));

        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float3 Clamp(float3 v, float min, float max) => new float3(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max));

        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float3 Clamp(float v, float3 min, float3 max) => new float3(Math.Min(Math.Max(v, min.x), max.x), Math.Min(Math.Max(v, min.y), max.y), Math.Min(Math.Max(v, min.z), max.z));

        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float3 Clamp(float v, float3 min, float max) => new float3(Math.Min(Math.Max(v, min.x), max), Math.Min(Math.Max(v, min.y), max), Math.Min(Math.Max(v, min.z), max));

        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float3 Clamp(float v, float min, float3 max) => new float3(Math.Min(Math.Max(v, min), max.x), Math.Min(Math.Max(v, min), max.y), Math.Min(Math.Max(v, min), max.z));

        /// <summary>
        /// Returns a vec from the application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float3 Clamp(float v, float min, float max) => new float3(Math.Min(Math.Max(v, min), max));

        /// <summary>
        /// Returns a float3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float3 Mix(float3 min, float3 max, float3 a) => new float3(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float3 Mix(float3 min, float3 max, float a) => new float3(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a float3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float3 Mix(float3 min, float max, float3 a) => new float3(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float3 Mix(float3 min, float max, float a) => new float3(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a);

        /// <summary>
        /// Returns a float3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float3 Mix(float min, float3 max, float3 a) => new float3(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float3 Mix(float min, float3 max, float a) => new float3(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a float3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float3 Mix(float min, float max, float3 a) => new float3(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a vec from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float3 Mix(float min, float max, float a) => new float3(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float3 Lerp(float3 min, float3 max, float3 a) => new float3(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float3 Lerp(float3 min, float3 max, float a) => new float3(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float3 Lerp(float3 min, float max, float3 a) => new float3(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float3 Lerp(float3 min, float max, float a) => new float3(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a);

        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float3 Lerp(float min, float3 max, float3 a) => new float3(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float3 Lerp(float min, float3 max, float a) => new float3(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float3 Lerp(float min, float max, float3 a) => new float3(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a vec from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float3 Lerp(float min, float max, float a) => new float3(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float3 edge0, float3 edge1, float3 v) => new float3(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float3 edge0, float3 edge1, float v) => new float3(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float3 edge0, float edge1, float3 v) => new float3(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float3 edge0, float edge1, float v) => new float3(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float edge0, float3 edge1, float3 v) => new float3(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float edge0, float3 edge1, float v) => new float3(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float edge0, float edge1, float3 v) => new float3(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a vec from the application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float edge0, float edge1, float v) => new float3(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float3 Smootherstep(float3 edge0, float3 edge1, float3 v) => new float3(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a float3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float3 Smootherstep(float3 edge0, float3 edge1, float v) => new float3(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a float3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float3 Smootherstep(float3 edge0, float edge1, float3 v) => new float3(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a float3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float3 Smootherstep(float3 edge0, float edge1, float v) => new float3(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a float3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float3 Smootherstep(float edge0, float3 edge1, float3 v) => new float3(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a float3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float3 Smootherstep(float edge0, float3 edge1, float v) => new float3(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a float3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float3 Smootherstep(float edge0, float edge1, float3 v) => new float3(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a vec from the application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float3 Smootherstep(float edge0, float edge1, float v) => new float3(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a float3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float3 Fma(float3 a, float3 b, float3 c) => new float3(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float3 Fma(float3 a, float3 b, float c) => new float3(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c);

        /// <summary>
        /// Returns a float3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float3 Fma(float3 a, float b, float3 c) => new float3(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float3 Fma(float3 a, float b, float c) => new float3(a.x * b + c, a.y * b + c, a.z * b + c);

        /// <summary>
        /// Returns a float3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float3 Fma(float a, float3 b, float3 c) => new float3(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float3 Fma(float a, float3 b, float c) => new float3(a * b.x + c, a * b.y + c, a * b.z + c);

        /// <summary>
        /// Returns a float3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float3 Fma(float a, float b, float3 c) => new float3(a * b + c.x, a * b + c.y, a * b + c.z);

        /// <summary>
        /// Returns a vec from the application of Fma (a * b + c).
        /// </summary>
        public static float3 Fma(float a, float b, float c) => new float3(a * b + c);

        /// <summary>
        /// Returns a float3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static float3 Add(float3 lhs, float3 rhs) => new float3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static float3 Add(float3 lhs, float rhs) => new float3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static float3 Add(float lhs, float3 rhs) => new float3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);

        /// <summary>
        /// Returns a vec from the application of Add (lhs + rhs).
        /// </summary>
        public static float3 Add(float lhs, float rhs) => new float3(lhs + rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static float3 Sub(float3 lhs, float3 rhs) => new float3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static float3 Sub(float3 lhs, float rhs) => new float3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static float3 Sub(float lhs, float3 rhs) => new float3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);

        /// <summary>
        /// Returns a vec from the application of Sub (lhs - rhs).
        /// </summary>
        public static float3 Sub(float lhs, float rhs) => new float3(lhs - rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static float3 Mul(float3 lhs, float3 rhs) => new float3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static float3 Mul(float3 lhs, float rhs) => new float3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static float3 Mul(float lhs, float3 rhs) => new float3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);

        /// <summary>
        /// Returns a vec from the application of Mul (lhs * rhs).
        /// </summary>
        public static float3 Mul(float lhs, float rhs) => new float3(lhs * rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static float3 Div(float3 lhs, float3 rhs) => new float3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static float3 Div(float3 lhs, float rhs) => new float3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static float3 Div(float lhs, float3 rhs) => new float3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);

        /// <summary>
        /// Returns a vec from the application of Div (lhs / rhs).
        /// </summary>
        public static float3 Div(float lhs, float rhs) => new float3(lhs / rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static float3 Modulo(float3 lhs, float3 rhs) => new float3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static float3 Modulo(float3 lhs, float rhs) => new float3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static float3 Modulo(float lhs, float3 rhs) => new float3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z);

        /// <summary>
        /// Returns a vec from the application of Modulo (lhs % rhs).
        /// </summary>
        public static float3 Modulo(float lhs, float rhs) => new float3(lhs % rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static float3 Degrees(float3 v) => new float3((float)(v.x * 57.295779513082320876798154814105170332405472466564321f), (float)(v.y * 57.295779513082320876798154814105170332405472466564321f), (float)(v.z * 57.295779513082320876798154814105170332405472466564321f));

        /// <summary>
        /// Returns a vec from the application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static float3 Degrees(float v) => new float3((float)(v * 57.295779513082320876798154814105170332405472466564321f));

        /// <summary>
        /// Returns a float3 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static float3 Radians(float3 v) => new float3((float)(v.x * 0.0174532925199432957692369076848861271344287188854172f), (float)(v.y * 0.0174532925199432957692369076848861271344287188854172f), (float)(v.z * 0.0174532925199432957692369076848861271344287188854172f));

        /// <summary>
        /// Returns a vec from the application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static float3 Radians(float v) => new float3((float)(v * 0.0174532925199432957692369076848861271344287188854172f));

        /// <summary>
        /// Returns a float3 from component-wise application of Acos ((float)Math.Acos((double)v)).
        /// </summary>
        public static float3 Acos(float3 v) => new float3((float)Math.Acos(v.x), (float)Math.Acos(v.y), (float)Math.Acos(v.z));

        /// <summary>
        /// Returns a vec from the application of Acos ((float)Math.Acos((double)v)).
        /// </summary>
        public static float3 Acos(float v) => new float3((float)Math.Acos((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Asin ((float)Math.Asin((double)v)).
        /// </summary>
        public static float3 Asin(float3 v) => new float3((float)Math.Asin(v.x), (float)Math.Asin(v.y), (float)Math.Asin(v.z));

        /// <summary>
        /// Returns a vec from the application of Asin ((float)Math.Asin((double)v)).
        /// </summary>
        public static float3 Asin(float v) => new float3((float)Math.Asin((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Atan ((float)Math.Atan((double)v)).
        /// </summary>
        public static float3 Atan(float3 v) => new float3((float)Math.Atan(v.x), (float)Math.Atan(v.y), (float)Math.Atan(v.z));

        /// <summary>
        /// Returns a vec from the application of Atan ((float)Math.Atan((double)v)).
        /// </summary>
        public static float3 Atan(float v) => new float3((float)Math.Atan((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Cos ((float)Math.Cos((double)v)).
        /// </summary>
        public static float3 Cos(float3 v) => new float3((float)Math.Cos(v.x), (float)Math.Cos(v.y), (float)Math.Cos(v.z));

        /// <summary>
        /// Returns a vec from the application of Cos ((float)Math.Cos((double)v)).
        /// </summary>
        public static float3 Cos(float v) => new float3((float)Math.Cos((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Cosh ((float)Math.Cosh((double)v)).
        /// </summary>
        public static float3 Cosh(float3 v) => new float3((float)Math.Cosh(v.x), (float)Math.Cosh(v.y), (float)Math.Cosh(v.z));

        /// <summary>
        /// Returns a vec from the application of Cosh ((float)Math.Cosh((double)v)).
        /// </summary>
        public static float3 Cosh(float v) => new float3((float)Math.Cosh((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Exp ((float)Math.Exp((double)v)).
        /// </summary>
        public static float3 Exp(float3 v) => new float3((float)Math.Exp(v.x), (float)Math.Exp(v.y), (float)Math.Exp(v.z));

        /// <summary>
        /// Returns a vec from the application of Exp ((float)Math.Exp((double)v)).
        /// </summary>
        public static float3 Exp(float v) => new float3((float)Math.Exp((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Log ((float)Math.Log((double)v)).
        /// </summary>
        public static float3 Log(float3 v) => new float3((float)Math.Log(v.x), (float)Math.Log(v.y), (float)Math.Log(v.z));

        /// <summary>
        /// Returns a vec from the application of Log ((float)Math.Log((double)v)).
        /// </summary>
        public static float3 Log(float v) => new float3((float)Math.Log((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Log2 ((float)Math.Log((double)v, 2)).
        /// </summary>
        public static float3 Log2(float3 v) => new float3((float)Math.Log(v.x, 2), (float)Math.Log(v.y, 2), (float)Math.Log(v.z, 2));

        /// <summary>
        /// Returns a vec from the application of Log2 ((float)Math.Log((double)v, 2)).
        /// </summary>
        public static float3 Log2(float v) => new float3((float)Math.Log((double)v, 2));

        /// <summary>
        /// Returns a float3 from component-wise application of Log10 ((float)Math.Log10((double)v)).
        /// </summary>
        public static float3 Log10(float3 v) => new float3((float)Math.Log10(v.x), (float)Math.Log10(v.y), (float)Math.Log10(v.z));

        /// <summary>
        /// Returns a vec from the application of Log10 ((float)Math.Log10((double)v)).
        /// </summary>
        public static float3 Log10(float v) => new float3((float)Math.Log10((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Floor ((float)Math.Floor(v)).
        /// </summary>
        public static float3 Floor(float3 v) => new float3((float)Math.Floor(v.x), (float)Math.Floor(v.y), (float)Math.Floor(v.z));

        /// <summary>
        /// Returns a vec from the application of Floor ((float)Math.Floor(v)).
        /// </summary>
        public static float3 Floor(float v) => new float3((float)Math.Floor(v));

        /// <summary>
        /// Returns a float3 from component-wise application of Ceiling ((float)Math.Ceiling(v)).
        /// </summary>
        public static float3 Ceiling(float3 v) => new float3((float)Math.Ceiling(v.x), (float)Math.Ceiling(v.y), (float)Math.Ceiling(v.z));

        /// <summary>
        /// Returns a vec from the application of Ceiling ((float)Math.Ceiling(v)).
        /// </summary>
        public static float3 Ceiling(float v) => new float3((float)Math.Ceiling(v));

        /// <summary>
        /// Returns a float3 from component-wise application of Round ((float)Math.Round(v)).
        /// </summary>
        public static float3 Round(float3 v) => new float3((float)Math.Round(v.x), (float)Math.Round(v.y), (float)Math.Round(v.z));

        /// <summary>
        /// Returns a vec from the application of Round ((float)Math.Round(v)).
        /// </summary>
        public static float3 Round(float v) => new float3((float)Math.Round(v));

        /// <summary>
        /// Returns a float3 from component-wise application of Sin ((float)Math.Sin((double)v)).
        /// </summary>
        public static float3 Sin(float3 v) => new float3((float)Math.Sin(v.x), (float)Math.Sin(v.y), (float)Math.Sin(v.z));

        /// <summary>
        /// Returns a vec from the application of Sin ((float)Math.Sin((double)v)).
        /// </summary>
        public static float3 Sin(float v) => new float3((float)Math.Sin((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Sinh ((float)Math.Sinh((double)v)).
        /// </summary>
        public static float3 Sinh(float3 v) => new float3((float)Math.Sinh(v.x), (float)Math.Sinh(v.y), (float)Math.Sinh(v.z));

        /// <summary>
        /// Returns a vec from the application of Sinh ((float)Math.Sinh((double)v)).
        /// </summary>
        public static float3 Sinh(float v) => new float3((float)Math.Sinh((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Tan ((float)Math.Tan((double)v)).
        /// </summary>
        public static float3 Tan(float3 v) => new float3((float)Math.Tan(v.x), (float)Math.Tan(v.y), (float)Math.Tan(v.z));

        /// <summary>
        /// Returns a vec from the application of Tan ((float)Math.Tan((double)v)).
        /// </summary>
        public static float3 Tan(float v) => new float3((float)Math.Tan((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Tanh ((float)Math.Tanh((double)v)).
        /// </summary>
        public static float3 Tanh(float3 v) => new float3((float)Math.Tanh(v.x), (float)Math.Tanh(v.y), (float)Math.Tanh(v.z));

        /// <summary>
        /// Returns a vec from the application of Tanh ((float)Math.Tanh((double)v)).
        /// </summary>
        public static float3 Tanh(float v) => new float3((float)Math.Tanh((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Truncate ((float)Math.Truncate((double)v)).
        /// </summary>
        public static float3 Truncate(float3 v) => new float3((float)Math.Truncate(v.x), (float)Math.Truncate(v.y), (float)Math.Truncate(v.z));

        /// <summary>
        /// Returns a vec from the application of Truncate ((float)Math.Truncate((double)v)).
        /// </summary>
        public static float3 Truncate(float v) => new float3((float)Math.Truncate((double)v));

        /// <summary>
        /// Returns a float3 from component-wise application of Fract ((float)(v - Math.Floor(v))).
        /// </summary>
        public static float3 Fract(float3 v) => new float3((float)(v.x - Math.Floor(v.x)), (float)(v.y - Math.Floor(v.y)), (float)(v.z - Math.Floor(v.z)));

        /// <summary>
        /// Returns a vec from the application of Fract ((float)(v - Math.Floor(v))).
        /// </summary>
        public static float3 Fract(float v) => new float3((float)(v - Math.Floor(v)));

        /// <summary>
        /// Returns a float3 from component-wise application of Trunc ((long)(v)).
        /// </summary>
        public static float3 Trunc(float3 v) => new float3((long)(v.x), (long)(v.y), (long)(v.z));

        /// <summary>
        /// Returns a vec from the application of Trunc ((long)(v)).
        /// </summary>
        public static float3 Trunc(float v) => new float3((long)(v));

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(float3 lhs, float3 rhs) => new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(float3 lhs, float rhs) => new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(float lhs, float3 rhs) => new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(float3 lhs, float3 rhs) => new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(float3 lhs, float rhs) => new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(float lhs, float3 rhs) => new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(float3 lhs, float3 rhs) => new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(float3 lhs, float rhs) => new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(float lhs, float3 rhs) => new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(float3 lhs, float3 rhs) => new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(float3 lhs, float rhs) => new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(float lhs, float3 rhs) => new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float3 operator +(float3 lhs, float3 rhs) => new float3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float3 operator +(float3 lhs, float rhs) => new float3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float3 operator +(float lhs, float3 rhs) => new float3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float3 operator -(float3 lhs, float3 rhs) => new float3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float3 operator -(float3 lhs, float rhs) => new float3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float3 operator -(float lhs, float3 rhs) => new float3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float3 operator *(float3 lhs, float3 rhs) => new float3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float3 operator *(float3 lhs, float rhs) => new float3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float3 operator *(float lhs, float3 rhs) => new float3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float3 operator /(float3 lhs, float3 rhs) => new float3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float3 operator /(float3 lhs, float rhs) => new float3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float3 operator /(float lhs, float3 rhs) => new float3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator+ (identity).
        /// </summary>
        public static float3 operator +(float3 v) => v;

        /// <summary>
        /// Returns a float3 from component-wise application of operator- (-v).
        /// </summary>
        public static float3 operator -(float3 v) => new float3(-v.x, -v.y, -v.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static float3 operator %(float3 lhs, float3 rhs) => new float3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z);

        /// <summary>
        /// Returns a float3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static float3 operator %(float3 lhs, float rhs) => new float3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs);

        /// <summary>
        /// Returns a float3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static float3 operator %(float lhs, float3 rhs) => new float3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z);

        #endregion

    }
}
