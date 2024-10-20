using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type int with 3 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct int3
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

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        public int z;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public int3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public int3(int v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public int3(int2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public int3(int2 v, int z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public int3(int3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public int3(int4 v)
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
        public static implicit operator float3(int3 v) => new float3(v.x, v.y, v.z);

        /// <summary>
        /// Implicitly converts this to a double3.
        /// </summary>
        public static implicit operator double3(int3 v) => new double3(v.x, v.y, v.z);

        #endregion


        #region Explicit Operators

        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(int3 v) => new int2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a int4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator int4(int3 v) => new int4(v.x, v.y, v.z, 0);

        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(int3 v) => new uint2((uint)v.x, (uint)v.y);

        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(int3 v) => new uint3((uint)v.x, (uint)v.y, (uint)v.z);

        /// <summary>
        /// Explicitly converts this to a uint4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator uint4(int3 v) => new uint4((uint)v.x, (uint)v.y, (uint)v.z, 0u);

        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(int3 v) => new float2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a float4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator float4(int3 v) => new float4(v.x, v.y, v.z, 0f);

        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(int3 v) => new double2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a double4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator double4(int3 v) => new double4(v.x, v.y, v.z, 0.0);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(int3 v) => new bool2(v.x != 0, v.y != 0);

        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(int3 v) => new bool3(v.x != 0, v.y != 0, v.z != 0);

        /// <summary>
        /// Explicitly converts this to a bool4. (Higher components are zeroed)
        /// </summary>
        public static explicit operator bool4(int3 v) => new bool4(v.x != 0, v.y != 0, v.z != 0, false);

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
        public swizzle_ivec3 swizzle => new swizzle_ivec3(x, y, z);

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
        public int2 xz
        {
            get
            {
                return new int2(x, z);
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
        public int2 yz
        {
            get
            {
                return new int2(y, z);
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
        public int3 xyz
        {
            get
            {
                return new int3(x, y, z);
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
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public int2 rb
        {
            get
            {
                return new int2(x, z);
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
        public int2 gb
        {
            get
            {
                return new int2(y, z);
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
        public int3 rgb
        {
            get
            {
                return new int3(x, y, z);
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
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public int b
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
        public int MinElement => Math.Min(Math.Min(x, y), z);

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public int MaxElement => Math.Max(Math.Max(x, y), z);

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
        public int Sum => ((x + y) + z);

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

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static int3 Zero { get; } = new int3(0, 0, 0);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static int3 Ones { get; } = new int3(1, 1, 1);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static int3 UnitX { get; } = new int3(1, 0, 0);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static int3 UnitY { get; } = new int3(0, 1, 0);

        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        public static int3 UnitZ { get; } = new int3(0, 0, 1);

        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        public static int3 MaxValue { get; } = new int3(int.MaxValue, int.MaxValue, int.MaxValue);

        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        public static int3 MinValue { get; } = new int3(int.MinValue, int.MinValue, int.MinValue);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(int3 lhs, int3 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(int3 lhs, int3 rhs) => !lhs.Equals(rhs);

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
        public bool Equals(int3 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && z.Equals(rhs.z));

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
        public double NormP(double p) => Math.Pow(((Math.Pow(Math.Abs(x), p) + Math.Pow(Math.Abs(y), p)) + Math.Pow(Math.Abs(z), p)), 1 / p);

        #endregion


        #region Static Functions

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x2 OuterProduct(int2 c, int3 r) => new int3x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int2x3 OuterProduct(int3 c, int2 r) => new int2x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x3 OuterProduct(int3 c, int3 r) => new int3x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x4 OuterProduct(int4 c, int3 r) => new int3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int4x3 OuterProduct(int3 c, int4 r) => new int4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static int Dot(int3 lhs, int3 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + lhs.z * rhs.z);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(int3 lhs, int3 rhs) => (lhs - rhs).Length;

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(int3 lhs, int3 rhs) => (lhs - rhs).LengthSqr;

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int3 Reflect(int3 I, int3 N) => I - 2 * Dot(N, I) * N;

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int3 Refract(int3 I, int3 N, int eta)
        {
            var dNI = Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (int)Math.Sqrt(k)) * N;
        }

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static int3 FaceForward(int3 N, int3 I, int3 Nref) => Dot(Nref, I) < 0 ? N : -N;

        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static int3 Cross(int3 l, int3 r) => new int3(l.y * r.z - l.z * r.y, l.z * r.x - l.x * r.z, l.x * r.y - l.y * r.x);

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int3 lhs, int3 rhs) => new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int3 lhs, int rhs) => new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int lhs, int3 rhs) => new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int lhs, int rhs) => new bool3(lhs == rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int3 lhs, int3 rhs) => new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int3 lhs, int rhs) => new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int lhs, int3 rhs) => new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int lhs, int rhs) => new bool3(lhs != rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int3 lhs, int3 rhs) => new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int3 lhs, int rhs) => new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int lhs, int3 rhs) => new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);

        /// <summary>
        /// Returns a bvec from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int lhs, int rhs) => new bool3(lhs > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int3 lhs, int3 rhs) => new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int3 lhs, int rhs) => new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int lhs, int3 rhs) => new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);

        /// <summary>
        /// Returns a bvec from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int lhs, int rhs) => new bool3(lhs >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int3 lhs, int3 rhs) => new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int3 lhs, int rhs) => new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int lhs, int3 rhs) => new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);

        /// <summary>
        /// Returns a bvec from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int lhs, int rhs) => new bool3(lhs < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int3 lhs, int3 rhs) => new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int3 lhs, int rhs) => new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int lhs, int3 rhs) => new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);

        /// <summary>
        /// Returns a bvec from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int lhs, int rhs) => new bool3(lhs <= rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static int3 Abs(int3 v) => new int3(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z));

        /// <summary>
        /// Returns a ivec from the application of Abs (Math.Abs(v)).
        /// </summary>
        public static int3 Abs(int v) => new int3(Math.Abs(v));

        /// <summary>
        /// Returns a int3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int3 HermiteInterpolationOrder3(int3 v) => new int3((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z);

        /// <summary>
        /// Returns a ivec from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int3 HermiteInterpolationOrder3(int v) => new int3((3 - 2 * v) * v * v);

        /// <summary>
        /// Returns a int3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int3 HermiteInterpolationOrder5(int3 v) => new int3(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z);

        /// <summary>
        /// Returns a ivec from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int3 HermiteInterpolationOrder5(int v) => new int3(((6 * v - 15) * v + 10) * v * v * v);

        /// <summary>
        /// Returns a int3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static int3 Sqr(int3 v) => new int3(v.x * v.x, v.y * v.y, v.z * v.z);

        /// <summary>
        /// Returns a ivec from the application of Sqr (v * v).
        /// </summary>
        public static int3 Sqr(int v) => new int3(v * v);

        /// <summary>
        /// Returns a int3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static int3 Pow2(int3 v) => new int3(v.x * v.x, v.y * v.y, v.z * v.z);

        /// <summary>
        /// Returns a ivec from the application of Pow2 (v * v).
        /// </summary>
        public static int3 Pow2(int v) => new int3(v * v);

        /// <summary>
        /// Returns a int3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static int3 Pow3(int3 v) => new int3(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z);

        /// <summary>
        /// Returns a ivec from the application of Pow3 (v * v * v).
        /// </summary>
        public static int3 Pow3(int v) => new int3(v * v * v);

        /// <summary>
        /// Returns a int3 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int3 Step(int3 v) => new int3(v.x >= 0 ? 1 : 0, v.y >= 0 ? 1 : 0, v.z >= 0 ? 1 : 0);

        /// <summary>
        /// Returns a ivec from the application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int3 Step(int v) => new int3(v >= 0 ? 1 : 0);

        /// <summary>
        /// Returns a int3 from component-wise application of Sqrt ((int)Math.Sqrt((double)v)).
        /// </summary>
        public static int3 Sqrt(int3 v) => new int3((int)Math.Sqrt(v.x), (int)Math.Sqrt(v.y), (int)Math.Sqrt(v.z));

        /// <summary>
        /// Returns a ivec from the application of Sqrt ((int)Math.Sqrt((double)v)).
        /// </summary>
        public static int3 Sqrt(int v) => new int3((int)Math.Sqrt(v));

        /// <summary>
        /// Returns a int3 from component-wise application of InverseSqrt ((int)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static int3 InverseSqrt(int3 v) => new int3((int)(1.0 / Math.Sqrt(v.x)), (int)(1.0 / Math.Sqrt(v.y)), (int)(1.0 / Math.Sqrt(v.z)));

        /// <summary>
        /// Returns a ivec from the application of InverseSqrt ((int)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static int3 InverseSqrt(int v) => new int3((int)(1.0 / Math.Sqrt(v)));

        /// <summary>
        /// Returns a int3 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int3 Sign(int3 v) => new int3(Math.Sign(v.x), Math.Sign(v.y), Math.Sign(v.z));

        /// <summary>
        /// Returns a ivec from the application of Sign (Math.Sign(v)).
        /// </summary>
        public static int3 Sign(int v) => new int3(Math.Sign(v));

        /// <summary>
        /// Returns a int3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int3 lhs, int3 rhs) => new int3(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int3 lhs, int rhs) => new int3(Math.Max(lhs.x, rhs), Math.Max(lhs.y, rhs), Math.Max(lhs.z, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int lhs, int3 rhs) => new int3(Math.Max(lhs, rhs.x), Math.Max(lhs, rhs.y), Math.Max(lhs, rhs.z));

        /// <summary>
        /// Returns a ivec from the application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int lhs, int rhs) => new int3(Math.Max(lhs, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int3 lhs, int3 rhs) => new int3(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int3 lhs, int rhs) => new int3(Math.Min(lhs.x, rhs), Math.Min(lhs.y, rhs), Math.Min(lhs.z, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int lhs, int3 rhs) => new int3(Math.Min(lhs, rhs.x), Math.Min(lhs, rhs.y), Math.Min(lhs, rhs.z));

        /// <summary>
        /// Returns a ivec from the application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int lhs, int rhs) => new int3(Math.Min(lhs, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Pow(int3 lhs, int3 rhs) => new int3((int)Math.Pow(lhs.x, rhs.x), (int)Math.Pow(lhs.y, rhs.y), (int)Math.Pow(lhs.z, rhs.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Pow(int3 lhs, int rhs) => new int3((int)Math.Pow(lhs.x, rhs), (int)Math.Pow(lhs.y, rhs), (int)Math.Pow(lhs.z, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Pow(int lhs, int3 rhs) => new int3((int)Math.Pow(lhs, rhs.x), (int)Math.Pow(lhs, rhs.y), (int)Math.Pow(lhs, rhs.z));

        /// <summary>
        /// Returns a ivec from the application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Pow(int lhs, int rhs) => new int3((int)Math.Pow(lhs, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Log(int3 lhs, int3 rhs) => new int3((int)Math.Log(lhs.x, rhs.x), (int)Math.Log(lhs.y, rhs.y), (int)Math.Log(lhs.z, rhs.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Log(int3 lhs, int rhs) => new int3((int)Math.Log(lhs.x, rhs), (int)Math.Log(lhs.y, rhs), (int)Math.Log(lhs.z, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Log(int lhs, int3 rhs) => new int3((int)Math.Log(lhs, rhs.x), (int)Math.Log(lhs, rhs.y), (int)Math.Log(lhs, rhs.z));

        /// <summary>
        /// Returns a ivec from the application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int3 Log(int lhs, int rhs) => new int3((int)Math.Log(lhs, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int3 v, int3 min, int3 max) => new int3(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int3 v, int3 min, int max) => new int3(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max), Math.Min(Math.Max(v.z, min.z), max));

        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int3 v, int min, int3 max) => new int3(Math.Min(Math.Max(v.x, min), max.x), Math.Min(Math.Max(v.y, min), max.y), Math.Min(Math.Max(v.z, min), max.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int3 v, int min, int max) => new int3(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max));

        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int v, int3 min, int3 max) => new int3(Math.Min(Math.Max(v, min.x), max.x), Math.Min(Math.Max(v, min.y), max.y), Math.Min(Math.Max(v, min.z), max.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int v, int3 min, int max) => new int3(Math.Min(Math.Max(v, min.x), max), Math.Min(Math.Max(v, min.y), max), Math.Min(Math.Max(v, min.z), max));

        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int v, int min, int3 max) => new int3(Math.Min(Math.Max(v, min), max.x), Math.Min(Math.Max(v, min), max.y), Math.Min(Math.Max(v, min), max.z));

        /// <summary>
        /// Returns a ivec from the application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int3 Clamp(int v, int min, int max) => new int3(Math.Min(Math.Max(v, min), max));

        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int3 min, int3 max, int3 a) => new int3(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int3 min, int3 max, int a) => new int3(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int3 min, int max, int3 a) => new int3(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int3 min, int max, int a) => new int3(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a);

        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int min, int3 max, int3 a) => new int3(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int min, int3 max, int a) => new int3(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a int3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int min, int max, int3 a) => new int3(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a ivec from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int3 Mix(int min, int max, int a) => new int3(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int3 min, int3 max, int3 a) => new int3(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int3 min, int3 max, int a) => new int3(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int3 min, int max, int3 a) => new int3(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int3 min, int max, int a) => new int3(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a);

        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int min, int3 max, int3 a) => new int3(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int min, int3 max, int a) => new int3(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a);

        /// <summary>
        /// Returns a int3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int min, int max, int3 a) => new int3(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z);

        /// <summary>
        /// Returns a ivec from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int3 Lerp(int min, int max, int a) => new int3(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a int3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int3 Smoothstep(int3 edge0, int3 edge1, int3 v) => new int3(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int3 Smoothstep(int3 edge0, int3 edge1, int v) => new int3(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int3 Smoothstep(int3 edge0, int edge1, int3 v) => new int3(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int3 Smoothstep(int3 edge0, int edge1, int v) => new int3(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int3 Smoothstep(int edge0, int3 edge1, int3 v) => new int3(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int3 Smoothstep(int edge0, int3 edge1, int v) => new int3(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int3 Smoothstep(int edge0, int edge1, int3 v) => new int3(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a ivec from the application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int3 Smoothstep(int edge0, int edge1, int v) => new int3(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int3 Smootherstep(int3 edge0, int3 edge1, int3 v) => new int3(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int3 Smootherstep(int3 edge0, int3 edge1, int v) => new int3(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int3 Smootherstep(int3 edge0, int edge1, int3 v) => new int3(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int3 Smootherstep(int3 edge0, int edge1, int v) => new int3(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int3 Smootherstep(int edge0, int3 edge1, int3 v) => new int3(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int3 Smootherstep(int edge0, int3 edge1, int v) => new int3(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int3 Smootherstep(int edge0, int edge1, int3 v) => new int3(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a ivec from the application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int3 Smootherstep(int edge0, int edge1, int v) => new int3(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int3 a, int3 b, int3 c) => new int3(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int3 a, int3 b, int c) => new int3(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c);

        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int3 a, int b, int3 c) => new int3(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int3 a, int b, int c) => new int3(a.x * b + c, a.y * b + c, a.z * b + c);

        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int a, int3 b, int3 c) => new int3(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int a, int3 b, int c) => new int3(a * b.x + c, a * b.y + c, a * b.z + c);

        /// <summary>
        /// Returns a int3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int a, int b, int3 c) => new int3(a * b + c.x, a * b + c.y, a * b + c.z);

        /// <summary>
        /// Returns a ivec from the application of Fma (a * b + c).
        /// </summary>
        public static int3 Fma(int a, int b, int c) => new int3(a * b + c);

        /// <summary>
        /// Returns a int3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int3 Add(int3 lhs, int3 rhs) => new int3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int3 Add(int3 lhs, int rhs) => new int3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int3 Add(int lhs, int3 rhs) => new int3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);

        /// <summary>
        /// Returns a ivec from the application of Add (lhs + rhs).
        /// </summary>
        public static int3 Add(int lhs, int rhs) => new int3(lhs + rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int3 Sub(int3 lhs, int3 rhs) => new int3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int3 Sub(int3 lhs, int rhs) => new int3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int3 Sub(int lhs, int3 rhs) => new int3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);

        /// <summary>
        /// Returns a ivec from the application of Sub (lhs - rhs).
        /// </summary>
        public static int3 Sub(int lhs, int rhs) => new int3(lhs - rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int3 Mul(int3 lhs, int3 rhs) => new int3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int3 Mul(int3 lhs, int rhs) => new int3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int3 Mul(int lhs, int3 rhs) => new int3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);

        /// <summary>
        /// Returns a ivec from the application of Mul (lhs * rhs).
        /// </summary>
        public static int3 Mul(int lhs, int rhs) => new int3(lhs * rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int3 Div(int3 lhs, int3 rhs) => new int3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int3 Div(int3 lhs, int rhs) => new int3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int3 Div(int lhs, int3 rhs) => new int3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);

        /// <summary>
        /// Returns a ivec from the application of Div (lhs / rhs).
        /// </summary>
        public static int3 Div(int lhs, int rhs) => new int3(lhs / rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int3 Xor(int3 lhs, int3 rhs) => new int3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int3 Xor(int3 lhs, int rhs) => new int3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int3 Xor(int lhs, int3 rhs) => new int3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z);

        /// <summary>
        /// Returns a ivec from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static int3 Xor(int lhs, int rhs) => new int3(lhs ^ rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int3 BitwiseOr(int3 lhs, int3 rhs) => new int3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int3 BitwiseOr(int3 lhs, int rhs) => new int3(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int3 BitwiseOr(int lhs, int3 rhs) => new int3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z);

        /// <summary>
        /// Returns a ivec from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int3 BitwiseOr(int lhs, int rhs) => new int3(lhs | rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int3 BitwiseAnd(int3 lhs, int3 rhs) => new int3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int3 BitwiseAnd(int3 lhs, int rhs) => new int3(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int3 BitwiseAnd(int lhs, int3 rhs) => new int3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z);

        /// <summary>
        /// Returns a ivec from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int3 BitwiseAnd(int lhs, int rhs) => new int3(lhs & rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 LeftShift(int3 lhs, int3 rhs) => new int3(lhs.x << rhs.x, lhs.y << rhs.y, lhs.z << rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 LeftShift(int3 lhs, int rhs) => new int3(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 LeftShift(int lhs, int3 rhs) => new int3(lhs << rhs.x, lhs << rhs.y, lhs << rhs.z);

        /// <summary>
        /// Returns a ivec from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 LeftShift(int lhs, int rhs) => new int3(lhs << rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 RightShift(int3 lhs, int3 rhs) => new int3(lhs.x >> rhs.x, lhs.y >> rhs.y, lhs.z >> rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 RightShift(int3 lhs, int rhs) => new int3(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 RightShift(int lhs, int3 rhs) => new int3(lhs >> rhs.x, lhs >> rhs.y, lhs >> rhs.z);

        /// <summary>
        /// Returns a ivec from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 RightShift(int lhs, int rhs) => new int3(lhs >> rhs);

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(int3 lhs, int3 rhs) => new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(int3 lhs, int rhs) => new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool3 operator <(int lhs, int3 rhs) => new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(int3 lhs, int3 rhs) => new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(int3 lhs, int rhs) => new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool3 operator <=(int lhs, int3 rhs) => new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(int3 lhs, int3 rhs) => new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(int3 lhs, int rhs) => new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool3 operator >(int lhs, int3 rhs) => new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(int3 lhs, int3 rhs) => new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(int3 lhs, int rhs) => new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool3 operator >=(int lhs, int3 rhs) => new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int3 operator +(int3 lhs, int3 rhs) => new int3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int3 operator +(int3 lhs, int rhs) => new int3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int3 operator +(int lhs, int3 rhs) => new int3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int3 operator -(int3 lhs, int3 rhs) => new int3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int3 operator -(int3 lhs, int rhs) => new int3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int3 operator -(int lhs, int3 rhs) => new int3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int3 operator *(int3 lhs, int3 rhs) => new int3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int3 operator *(int3 lhs, int rhs) => new int3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int3 operator *(int lhs, int3 rhs) => new int3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int3 operator /(int3 lhs, int3 rhs) => new int3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int3 operator /(int3 lhs, int rhs) => new int3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int3 operator /(int lhs, int3 rhs) => new int3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator+ (identity).
        /// </summary>
        public static int3 operator +(int3 v) => v;

        /// <summary>
        /// Returns a int3 from component-wise application of operator- (-v).
        /// </summary>
        public static int3 operator -(int3 v) => new int3(-v.x, -v.y, -v.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator~ (~v).
        /// </summary>
        public static int3 operator ~(int3 v) => new int3(~v.x, ~v.y, ~v.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int3 operator ^(int3 lhs, int3 rhs) => new int3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int3 operator ^(int3 lhs, int rhs) => new int3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int3 operator ^(int lhs, int3 rhs) => new int3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int3 operator |(int3 lhs, int3 rhs) => new int3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int3 operator |(int3 lhs, int rhs) => new int3(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int3 operator |(int lhs, int3 rhs) => new int3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int3 operator &(int3 lhs, int3 rhs) => new int3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int3 operator &(int3 lhs, int rhs) => new int3(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int3 operator &(int lhs, int3 rhs) => new int3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 operator <<(int3 lhs, int rhs) => new int3(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 operator >>(int3 lhs, int rhs) => new int3(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs);

        #endregion

    }
}
