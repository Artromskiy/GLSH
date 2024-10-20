using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type int with 4 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct int4
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

        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        public int w;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public int4(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public int4(int v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public int4(int2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0;
            this.w = 0;
        }

        /// <summary>
        /// from-vector-and-value constructor (empty fields are zero/false)
        /// </summary>
        public int4(int2 v, int z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = 0;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public int4(int2 v, int z, int w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public int4(int3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = 0;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public int4(int3 v, int w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = w;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public int4(int4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        #endregion


        #region Implicit Operators

        /// <summary>
        /// Implicitly converts this to a float4.
        /// </summary>
        public static implicit operator float4(int4 v) => new float4(v.x, v.y, v.z, v.w);

        /// <summary>
        /// Implicitly converts this to a double4.
        /// </summary>
        public static implicit operator double4(int4 v) => new double4(v.x, v.y, v.z, v.w);

        #endregion


        #region Explicit Operators

        /// <summary>
        /// Explicitly converts this to a int2.
        /// </summary>
        public static explicit operator int2(int4 v) => new int2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(int4 v) => new int3(v.x, v.y, v.z);

        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(int4 v) => new uint2((uint)v.x, (uint)v.y);

        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(int4 v) => new uint3((uint)v.x, (uint)v.y, (uint)v.z);

        /// <summary>
        /// Explicitly converts this to a uint4.
        /// </summary>
        public static explicit operator uint4(int4 v) => new uint4((uint)v.x, (uint)v.y, (uint)v.z, (uint)v.w);

        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(int4 v) => new float2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a float3.
        /// </summary>
        public static explicit operator float3(int4 v) => new float3(v.x, v.y, v.z);

        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(int4 v) => new double2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a double3.
        /// </summary>
        public static explicit operator double3(int4 v) => new double3(v.x, v.y, v.z);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(int4 v) => new bool2(v.x != 0, v.y != 0);

        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(int4 v) => new bool3(v.x != 0, v.y != 0, v.z != 0);

        /// <summary>
        /// Explicitly converts this to a bool4.
        /// </summary>
        public static explicit operator bool4(int4 v) => new bool4(v.x != 0, v.y != 0, v.z != 0, v.w != 0);

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
        public swizzle_ivec4 swizzle => new swizzle_ivec4(x, y, z, w);

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
        public int2 xw
        {
            get
            {
                return new int2(x, w);
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
        public int2 yw
        {
            get
            {
                return new int2(y, w);
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
        public int3 xyw
        {
            get
            {
                return new int3(x, y, w);
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
        public int2 zw
        {
            get
            {
                return new int2(z, w);
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
        public int3 xzw
        {
            get
            {
                return new int3(x, z, w);
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
        public int3 yzw
        {
            get
            {
                return new int3(y, z, w);
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
        public int4 xyzw
        {
            get
            {
                return new int4(x, y, z, w);
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
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public int2 ra
        {
            get
            {
                return new int2(x, w);
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
        public int2 ga
        {
            get
            {
                return new int2(y, w);
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
        public int3 rga
        {
            get
            {
                return new int3(x, y, w);
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
        public int2 ba
        {
            get
            {
                return new int2(z, w);
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
        public int3 rba
        {
            get
            {
                return new int3(x, z, w);
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
        public int3 gba
        {
            get
            {
                return new int3(y, z, w);
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
        public int4 rgba
        {
            get
            {
                return new int4(x, y, z, w);
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
        /// Gets or sets the specified RGBA component. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public int a
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
        public int MinElement => Math.Min(Math.Min(x, y), Math.Min(z, w));

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public int MaxElement => Math.Max(Math.Max(x, y), Math.Max(z, w));

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public float Length => (float)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public float LengthSqr => ((x * x + y * y) + (z * z + w * w));

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public int Sum => ((x + y) + (z + w));

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public float Norm => (float)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public float Norm1 => ((Math.Abs(x) + Math.Abs(y)) + (Math.Abs(z) + Math.Abs(w)));

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public float NormMax => Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Max(Math.Abs(z), Math.Abs(w)));

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static int4 Zero { get; } = new int4(0, 0, 0, 0);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static int4 Ones { get; } = new int4(1, 1, 1, 1);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static int4 UnitX { get; } = new int4(1, 0, 0, 0);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static int4 UnitY { get; } = new int4(0, 1, 0, 0);

        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        public static int4 UnitZ { get; } = new int4(0, 0, 1, 0);

        /// <summary>
        /// Predefined unit-W vector
        /// </summary>
        public static int4 UnitW { get; } = new int4(0, 0, 0, 1);

        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        public static int4 MaxValue { get; } = new int4(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        public static int4 MinValue { get; } = new int4(int.MinValue, int.MinValue, int.MinValue, int.MinValue);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(int4 lhs, int4 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(int4 lhs, int4 rhs) => !lhs.Equals(rhs);

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
        public bool Equals(int4 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && (z.Equals(rhs.z) && w.Equals(rhs.w)));

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((x.GetHashCode()) * 397) ^ y.GetHashCode()) * 397) ^ z.GetHashCode()) * 397) ^ w.GetHashCode();
            }
        }

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public double NormP(double p) => Math.Pow(((Math.Pow(Math.Abs(x), p) + Math.Pow(Math.Abs(y), p)) + (Math.Pow(Math.Abs(z), p) + Math.Pow(Math.Abs(w), p))), 1 / p);

        #endregion


        #region Static Functions

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int4x2 OuterProduct(int2 c, int4 r) => new int4x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z, c.x * r.w, c.y * r.w);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int2x4 OuterProduct(int4 c, int2 r) => new int2x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int4x3 OuterProduct(int3 c, int4 r) => new int4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int3x4 OuterProduct(int4 c, int3 r) => new int3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static int4x4 OuterProduct(int4 c, int4 r) => new int4x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z, c.x * r.w, c.y * r.w, c.z * r.w, c.w * r.w);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static int Dot(int4 lhs, int4 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(int4 lhs, int4 rhs) => (lhs - rhs).Length;

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(int4 lhs, int4 rhs) => (lhs - rhs).LengthSqr;

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int4 Reflect(int4 I, int4 N) => I - 2 * Dot(N, I) * N;

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static int4 Refract(int4 I, int4 N, int eta)
        {
            var dNI = Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (int)Math.Sqrt(k)) * N;
        }

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static int4 FaceForward(int4 N, int4 I, int4 Nref) => Dot(Nref, I) < 0 ? N : -N;

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int4 lhs, int4 rhs) => new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int4 lhs, int rhs) => new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int lhs, int4 rhs) => new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int lhs, int rhs) => new bool4(lhs == rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int4 lhs, int4 rhs) => new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int4 lhs, int rhs) => new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int lhs, int4 rhs) => new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int lhs, int rhs) => new bool4(lhs != rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int4 lhs, int4 rhs) => new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int4 lhs, int rhs) => new bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int lhs, int4 rhs) => new bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);

        /// <summary>
        /// Returns a bvec from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int lhs, int rhs) => new bool4(lhs > rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int4 lhs, int4 rhs) => new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int4 lhs, int rhs) => new bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int lhs, int4 rhs) => new bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);

        /// <summary>
        /// Returns a bvec from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int lhs, int rhs) => new bool4(lhs >= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int4 lhs, int4 rhs) => new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int4 lhs, int rhs) => new bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int lhs, int4 rhs) => new bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);

        /// <summary>
        /// Returns a bvec from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int lhs, int rhs) => new bool4(lhs < rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int4 lhs, int4 rhs) => new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int4 lhs, int rhs) => new bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int lhs, int4 rhs) => new bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);

        /// <summary>
        /// Returns a bvec from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int lhs, int rhs) => new bool4(lhs <= rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static int4 Abs(int4 v) => new int4(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z), Math.Abs(v.w));

        /// <summary>
        /// Returns a ivec from the application of Abs (Math.Abs(v)).
        /// </summary>
        public static int4 Abs(int v) => new int4(Math.Abs(v));

        /// <summary>
        /// Returns a int4 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int4 HermiteInterpolationOrder3(int4 v) => new int4((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z, (3 - 2 * v.w) * v.w * v.w);

        /// <summary>
        /// Returns a ivec from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static int4 HermiteInterpolationOrder3(int v) => new int4((3 - 2 * v) * v * v);

        /// <summary>
        /// Returns a int4 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int4 HermiteInterpolationOrder5(int4 v) => new int4(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z, ((6 * v.w - 15) * v.w + 10) * v.w * v.w * v.w);

        /// <summary>
        /// Returns a ivec from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static int4 HermiteInterpolationOrder5(int v) => new int4(((6 * v - 15) * v + 10) * v * v * v);

        /// <summary>
        /// Returns a int4 from component-wise application of Sqr (v * v).
        /// </summary>
        public static int4 Sqr(int4 v) => new int4(v.x * v.x, v.y * v.y, v.z * v.z, v.w * v.w);

        /// <summary>
        /// Returns a ivec from the application of Sqr (v * v).
        /// </summary>
        public static int4 Sqr(int v) => new int4(v * v);

        /// <summary>
        /// Returns a int4 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static int4 Pow2(int4 v) => new int4(v.x * v.x, v.y * v.y, v.z * v.z, v.w * v.w);

        /// <summary>
        /// Returns a ivec from the application of Pow2 (v * v).
        /// </summary>
        public static int4 Pow2(int v) => new int4(v * v);

        /// <summary>
        /// Returns a int4 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static int4 Pow3(int4 v) => new int4(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z, v.w * v.w * v.w);

        /// <summary>
        /// Returns a ivec from the application of Pow3 (v * v * v).
        /// </summary>
        public static int4 Pow3(int v) => new int4(v * v * v);

        /// <summary>
        /// Returns a int4 from component-wise application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int4 Step(int4 v) => new int4(v.x >= 0 ? 1 : 0, v.y >= 0 ? 1 : 0, v.z >= 0 ? 1 : 0, v.w >= 0 ? 1 : 0);

        /// <summary>
        /// Returns a ivec from the application of Step (v &gt;= 0 ? 1 : 0).
        /// </summary>
        public static int4 Step(int v) => new int4(v >= 0 ? 1 : 0);

        /// <summary>
        /// Returns a int4 from component-wise application of Sqrt ((int)Math.Sqrt((double)v)).
        /// </summary>
        public static int4 Sqrt(int4 v) => new int4((int)Math.Sqrt(v.x), (int)Math.Sqrt(v.y), (int)Math.Sqrt(v.z), (int)Math.Sqrt(v.w));

        /// <summary>
        /// Returns a ivec from the application of Sqrt ((int)Math.Sqrt((double)v)).
        /// </summary>
        public static int4 Sqrt(int v) => new int4((int)Math.Sqrt(v));

        /// <summary>
        /// Returns a int4 from component-wise application of InverseSqrt ((int)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static int4 InverseSqrt(int4 v) => new int4((int)(1.0 / Math.Sqrt(v.x)), (int)(1.0 / Math.Sqrt(v.y)), (int)(1.0 / Math.Sqrt(v.z)), (int)(1.0 / Math.Sqrt(v.w)));

        /// <summary>
        /// Returns a ivec from the application of InverseSqrt ((int)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static int4 InverseSqrt(int v) => new int4((int)(1.0 / Math.Sqrt(v)));

        /// <summary>
        /// Returns a int4 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int4 Sign(int4 v) => new int4(Math.Sign(v.x), Math.Sign(v.y), Math.Sign(v.z), Math.Sign(v.w));

        /// <summary>
        /// Returns a ivec from the application of Sign (Math.Sign(v)).
        /// </summary>
        public static int4 Sign(int v) => new int4(Math.Sign(v));

        /// <summary>
        /// Returns a int4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int4 lhs, int4 rhs) => new int4(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z), Math.Max(lhs.w, rhs.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int4 lhs, int rhs) => new int4(Math.Max(lhs.x, rhs), Math.Max(lhs.y, rhs), Math.Max(lhs.z, rhs), Math.Max(lhs.w, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int lhs, int4 rhs) => new int4(Math.Max(lhs, rhs.x), Math.Max(lhs, rhs.y), Math.Max(lhs, rhs.z), Math.Max(lhs, rhs.w));

        /// <summary>
        /// Returns a ivec from the application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int lhs, int rhs) => new int4(Math.Max(lhs, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int4 lhs, int4 rhs) => new int4(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z), Math.Min(lhs.w, rhs.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int4 lhs, int rhs) => new int4(Math.Min(lhs.x, rhs), Math.Min(lhs.y, rhs), Math.Min(lhs.z, rhs), Math.Min(lhs.w, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int lhs, int4 rhs) => new int4(Math.Min(lhs, rhs.x), Math.Min(lhs, rhs.y), Math.Min(lhs, rhs.z), Math.Min(lhs, rhs.w));

        /// <summary>
        /// Returns a ivec from the application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int lhs, int rhs) => new int4(Math.Min(lhs, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Pow(int4 lhs, int4 rhs) => new int4((int)Math.Pow(lhs.x, rhs.x), (int)Math.Pow(lhs.y, rhs.y), (int)Math.Pow(lhs.z, rhs.z), (int)Math.Pow(lhs.w, rhs.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Pow(int4 lhs, int rhs) => new int4((int)Math.Pow(lhs.x, rhs), (int)Math.Pow(lhs.y, rhs), (int)Math.Pow(lhs.z, rhs), (int)Math.Pow(lhs.w, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Pow(int lhs, int4 rhs) => new int4((int)Math.Pow(lhs, rhs.x), (int)Math.Pow(lhs, rhs.y), (int)Math.Pow(lhs, rhs.z), (int)Math.Pow(lhs, rhs.w));

        /// <summary>
        /// Returns a ivec from the application of Pow ((int)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Pow(int lhs, int rhs) => new int4((int)Math.Pow(lhs, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Log(int4 lhs, int4 rhs) => new int4((int)Math.Log(lhs.x, rhs.x), (int)Math.Log(lhs.y, rhs.y), (int)Math.Log(lhs.z, rhs.z), (int)Math.Log(lhs.w, rhs.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Log(int4 lhs, int rhs) => new int4((int)Math.Log(lhs.x, rhs), (int)Math.Log(lhs.y, rhs), (int)Math.Log(lhs.z, rhs), (int)Math.Log(lhs.w, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Log(int lhs, int4 rhs) => new int4((int)Math.Log(lhs, rhs.x), (int)Math.Log(lhs, rhs.y), (int)Math.Log(lhs, rhs.z), (int)Math.Log(lhs, rhs.w));

        /// <summary>
        /// Returns a ivec from the application of Log ((int)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static int4 Log(int lhs, int rhs) => new int4((int)Math.Log(lhs, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int4 v, int4 min, int4 max) => new int4(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z), Math.Min(Math.Max(v.w, min.w), max.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int4 v, int4 min, int max) => new int4(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max), Math.Min(Math.Max(v.z, min.z), max), Math.Min(Math.Max(v.w, min.w), max));

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int4 v, int min, int4 max) => new int4(Math.Min(Math.Max(v.x, min), max.x), Math.Min(Math.Max(v.y, min), max.y), Math.Min(Math.Max(v.z, min), max.z), Math.Min(Math.Max(v.w, min), max.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int4 v, int min, int max) => new int4(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max), Math.Min(Math.Max(v.w, min), max));

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int v, int4 min, int4 max) => new int4(Math.Min(Math.Max(v, min.x), max.x), Math.Min(Math.Max(v, min.y), max.y), Math.Min(Math.Max(v, min.z), max.z), Math.Min(Math.Max(v, min.w), max.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int v, int4 min, int max) => new int4(Math.Min(Math.Max(v, min.x), max), Math.Min(Math.Max(v, min.y), max), Math.Min(Math.Max(v, min.z), max), Math.Min(Math.Max(v, min.w), max));

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int v, int min, int4 max) => new int4(Math.Min(Math.Max(v, min), max.x), Math.Min(Math.Max(v, min), max.y), Math.Min(Math.Max(v, min), max.z), Math.Min(Math.Max(v, min), max.w));

        /// <summary>
        /// Returns a ivec from the application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static int4 Clamp(int v, int min, int max) => new int4(Math.Min(Math.Max(v, min), max));

        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int4 min, int4 max, int4 a) => new int4(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z, min.w * (1 - a.w) + max.w * a.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int4 min, int4 max, int a) => new int4(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a, min.w * (1 - a) + max.w * a);

        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int4 min, int max, int4 a) => new int4(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z, min.w * (1 - a.w) + max * a.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int4 min, int max, int a) => new int4(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a, min.w * (1 - a) + max * a);

        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int min, int4 max, int4 a) => new int4(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z, min * (1 - a.w) + max.w * a.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int min, int4 max, int a) => new int4(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a, min * (1 - a) + max.w * a);

        /// <summary>
        /// Returns a int4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int min, int max, int4 a) => new int4(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z, min * (1 - a.w) + max * a.w);

        /// <summary>
        /// Returns a ivec from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static int4 Mix(int min, int max, int a) => new int4(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int4 min, int4 max, int4 a) => new int4(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z, min.w * (1 - a.w) + max.w * a.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int4 min, int4 max, int a) => new int4(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a, min.w * (1 - a) + max.w * a);

        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int4 min, int max, int4 a) => new int4(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z, min.w * (1 - a.w) + max * a.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int4 min, int max, int a) => new int4(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a, min.w * (1 - a) + max * a);

        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int min, int4 max, int4 a) => new int4(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z, min * (1 - a.w) + max.w * a.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int min, int4 max, int a) => new int4(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a, min * (1 - a) + max.w * a);

        /// <summary>
        /// Returns a int4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int min, int max, int4 a) => new int4(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z, min * (1 - a.w) + max * a.w);

        /// <summary>
        /// Returns a ivec from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static int4 Lerp(int min, int max, int a) => new int4(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a int4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int4 Smoothstep(int4 edge0, int4 edge1, int4 v) => new int4(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3(), ((v.w - edge0.w) / (edge1.w - edge0.w)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int4 Smoothstep(int4 edge0, int4 edge1, int v) => new int4(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.w) / (edge1.w - edge0.w)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int4 Smoothstep(int4 edge0, int edge1, int4 v) => new int4(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3(), ((v.w - edge0.w) / (edge1 - edge0.w)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int4 Smoothstep(int4 edge0, int edge1, int v) => new int4(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.w) / (edge1 - edge0.w)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int4 Smoothstep(int edge0, int4 edge1, int4 v) => new int4(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.w - edge0) / (edge1.w - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int4 Smoothstep(int edge0, int4 edge1, int v) => new int4(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.w - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int4 Smoothstep(int edge0, int edge1, int4 v) => new int4(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.w - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a ivec from the application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static int4 Smoothstep(int edge0, int edge1, int v) => new int4(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a int4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int4 Smootherstep(int4 edge0, int4 edge1, int4 v) => new int4(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5(), ((v.w - edge0.w) / (edge1.w - edge0.w)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int4 Smootherstep(int4 edge0, int4 edge1, int v) => new int4(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.w) / (edge1.w - edge0.w)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int4 Smootherstep(int4 edge0, int edge1, int4 v) => new int4(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5(), ((v.w - edge0.w) / (edge1 - edge0.w)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int4 Smootherstep(int4 edge0, int edge1, int v) => new int4(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.w) / (edge1 - edge0.w)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int4 Smootherstep(int edge0, int4 edge1, int4 v) => new int4(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.w - edge0) / (edge1.w - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int4 Smootherstep(int edge0, int4 edge1, int v) => new int4(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.w - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int4 Smootherstep(int edge0, int edge1, int4 v) => new int4(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.w - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a ivec from the application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static int4 Smootherstep(int edge0, int edge1, int v) => new int4(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int4 a, int4 b, int4 c) => new int4(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z, a.w * b.w + c.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int4 a, int4 b, int c) => new int4(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c, a.w * b.w + c);

        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int4 a, int b, int4 c) => new int4(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z, a.w * b + c.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int4 a, int b, int c) => new int4(a.x * b + c, a.y * b + c, a.z * b + c, a.w * b + c);

        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int a, int4 b, int4 c) => new int4(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z, a * b.w + c.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int a, int4 b, int c) => new int4(a * b.x + c, a * b.y + c, a * b.z + c, a * b.w + c);

        /// <summary>
        /// Returns a int4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int a, int b, int4 c) => new int4(a * b + c.x, a * b + c.y, a * b + c.z, a * b + c.w);

        /// <summary>
        /// Returns a ivec from the application of Fma (a * b + c).
        /// </summary>
        public static int4 Fma(int a, int b, int c) => new int4(a * b + c);

        /// <summary>
        /// Returns a int4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int4 Add(int4 lhs, int4 rhs) => new int4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int4 Add(int4 lhs, int rhs) => new int4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static int4 Add(int lhs, int4 rhs) => new int4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);

        /// <summary>
        /// Returns a ivec from the application of Add (lhs + rhs).
        /// </summary>
        public static int4 Add(int lhs, int rhs) => new int4(lhs + rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int4 Sub(int4 lhs, int4 rhs) => new int4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int4 Sub(int4 lhs, int rhs) => new int4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static int4 Sub(int lhs, int4 rhs) => new int4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);

        /// <summary>
        /// Returns a ivec from the application of Sub (lhs - rhs).
        /// </summary>
        public static int4 Sub(int lhs, int rhs) => new int4(lhs - rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int4 Mul(int4 lhs, int4 rhs) => new int4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int4 Mul(int4 lhs, int rhs) => new int4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static int4 Mul(int lhs, int4 rhs) => new int4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);

        /// <summary>
        /// Returns a ivec from the application of Mul (lhs * rhs).
        /// </summary>
        public static int4 Mul(int lhs, int rhs) => new int4(lhs * rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int4 Div(int4 lhs, int4 rhs) => new int4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int4 Div(int4 lhs, int rhs) => new int4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static int4 Div(int lhs, int4 rhs) => new int4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);

        /// <summary>
        /// Returns a ivec from the application of Div (lhs / rhs).
        /// </summary>
        public static int4 Div(int lhs, int rhs) => new int4(lhs / rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int4 Xor(int4 lhs, int4 rhs) => new int4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int4 Xor(int4 lhs, int rhs) => new int4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static int4 Xor(int lhs, int4 rhs) => new int4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w);

        /// <summary>
        /// Returns a ivec from the application of Xor (lhs ^ rhs).
        /// </summary>
        public static int4 Xor(int lhs, int rhs) => new int4(lhs ^ rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int4 BitwiseOr(int4 lhs, int4 rhs) => new int4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int4 BitwiseOr(int4 lhs, int rhs) => new int4(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs, lhs.w | rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int4 BitwiseOr(int lhs, int4 rhs) => new int4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w);

        /// <summary>
        /// Returns a ivec from the application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static int4 BitwiseOr(int lhs, int rhs) => new int4(lhs | rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int4 BitwiseAnd(int4 lhs, int4 rhs) => new int4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int4 BitwiseAnd(int4 lhs, int rhs) => new int4(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs, lhs.w & rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int4 BitwiseAnd(int lhs, int4 rhs) => new int4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w);

        /// <summary>
        /// Returns a ivec from the application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static int4 BitwiseAnd(int lhs, int rhs) => new int4(lhs & rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 LeftShift(int4 lhs, int4 rhs) => new int4(lhs.x << rhs.x, lhs.y << rhs.y, lhs.z << rhs.z, lhs.w << rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 LeftShift(int4 lhs, int rhs) => new int4(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs, lhs.w << rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 LeftShift(int lhs, int4 rhs) => new int4(lhs << rhs.x, lhs << rhs.y, lhs << rhs.z, lhs << rhs.w);

        /// <summary>
        /// Returns a ivec from the application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 LeftShift(int lhs, int rhs) => new int4(lhs << rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 RightShift(int4 lhs, int4 rhs) => new int4(lhs.x >> rhs.x, lhs.y >> rhs.y, lhs.z >> rhs.z, lhs.w >> rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 RightShift(int4 lhs, int rhs) => new int4(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs, lhs.w >> rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 RightShift(int lhs, int4 rhs) => new int4(lhs >> rhs.x, lhs >> rhs.y, lhs >> rhs.z, lhs >> rhs.w);

        /// <summary>
        /// Returns a ivec from the application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 RightShift(int lhs, int rhs) => new int4(lhs >> rhs);

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator <(int4 lhs, int4 rhs) => new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator <(int4 lhs, int rhs) => new bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator <(int lhs, int4 rhs) => new bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator <=(int4 lhs, int4 rhs) => new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator <=(int4 lhs, int rhs) => new bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator <=(int lhs, int4 rhs) => new bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator >(int4 lhs, int4 rhs) => new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator >(int4 lhs, int rhs) => new bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator >(int lhs, int4 rhs) => new bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator >=(int4 lhs, int4 rhs) => new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator >=(int4 lhs, int rhs) => new bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator >=(int lhs, int4 rhs) => new bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int4 operator +(int4 lhs, int4 rhs) => new int4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int4 operator +(int4 lhs, int rhs) => new int4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int4 operator +(int lhs, int4 rhs) => new int4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int4 operator -(int4 lhs, int4 rhs) => new int4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int4 operator -(int4 lhs, int rhs) => new int4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int4 operator -(int lhs, int4 rhs) => new int4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int4 operator *(int4 lhs, int4 rhs) => new int4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int4 operator *(int4 lhs, int rhs) => new int4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int4 operator *(int lhs, int4 rhs) => new int4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int4 operator /(int4 lhs, int4 rhs) => new int4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int4 operator /(int4 lhs, int rhs) => new int4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int4 operator /(int lhs, int4 rhs) => new int4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator+ (identity).
        /// </summary>
        public static int4 operator +(int4 v) => v;

        /// <summary>
        /// Returns a int4 from component-wise application of operator- (-v).
        /// </summary>
        public static int4 operator -(int4 v) => new int4(-v.x, -v.y, -v.z, -v.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator~ (~v).
        /// </summary>
        public static int4 operator ~(int4 v) => new int4(~v.x, ~v.y, ~v.z, ~v.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int4 operator ^(int4 lhs, int4 rhs) => new int4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int4 operator ^(int4 lhs, int rhs) => new int4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int4 operator ^(int lhs, int4 rhs) => new int4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int4 operator |(int4 lhs, int4 rhs) => new int4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int4 operator |(int4 lhs, int rhs) => new int4(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs, lhs.w | rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int4 operator |(int lhs, int4 rhs) => new int4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int4 operator &(int4 lhs, int4 rhs) => new int4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int4 operator &(int4 lhs, int rhs) => new int4(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs, lhs.w & rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int4 operator &(int lhs, int4 rhs) => new int4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 operator <<(int4 lhs, int rhs) => new int4(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs, lhs.w << rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 operator >>(int4 lhs, int rhs) => new int4(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs, lhs.w >> rhs);

        #endregion

    }
}
