using GLSH.Swizzle;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type double with 4 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct double4
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public double x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public double y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        public double z;

        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        public double w;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public double4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public double4(double v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public double4(double2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0.0;
            this.w = 0.0;
        }

        /// <summary>
        /// from-vector-and-value constructor (empty fields are zero/false)
        /// </summary>
        public double4(double2 v, double z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = 0.0;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public double4(double2 v, double z, double w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public double4(double3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = 0.0;
        }

        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public double4(double3 v, double w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = w;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public double4(double4 v)
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
        public static explicit operator int2(double4 v) => new int2((int)v.x, (int)v.y);

        /// <summary>
        /// Explicitly converts this to a int3.
        /// </summary>
        public static explicit operator int3(double4 v) => new int3((int)v.x, (int)v.y, (int)v.z);

        /// <summary>
        /// Explicitly converts this to a int4.
        /// </summary>
        public static explicit operator int4(double4 v) => new int4((int)v.x, (int)v.y, (int)v.z, (int)v.w);

        /// <summary>
        /// Explicitly converts this to a uint2.
        /// </summary>
        public static explicit operator uint2(double4 v) => new uint2((uint)v.x, (uint)v.y);

        /// <summary>
        /// Explicitly converts this to a uint3.
        /// </summary>
        public static explicit operator uint3(double4 v) => new uint3((uint)v.x, (uint)v.y, (uint)v.z);

        /// <summary>
        /// Explicitly converts this to a uint4.
        /// </summary>
        public static explicit operator uint4(double4 v) => new uint4((uint)v.x, (uint)v.y, (uint)v.z, (uint)v.w);

        /// <summary>
        /// Explicitly converts this to a float2.
        /// </summary>
        public static explicit operator float2(double4 v) => new float2((float)v.x, (float)v.y);

        /// <summary>
        /// Explicitly converts this to a float3.
        /// </summary>
        public static explicit operator float3(double4 v) => new float3((float)v.x, (float)v.y, (float)v.z);

        /// <summary>
        /// Explicitly converts this to a float4.
        /// </summary>
        public static explicit operator float4(double4 v) => new float4((float)v.x, (float)v.y, (float)v.z, (float)v.w);

        /// <summary>
        /// Explicitly converts this to a double2.
        /// </summary>
        public static explicit operator double2(double4 v) => new double2(v.x, v.y);

        /// <summary>
        /// Explicitly converts this to a double3.
        /// </summary>
        public static explicit operator double3(double4 v) => new double3(v.x, v.y, v.z);

        /// <summary>
        /// Explicitly converts this to a bool2.
        /// </summary>
        public static explicit operator bool2(double4 v) => new bool2(v.x != 0.0, v.y != 0.0);

        /// <summary>
        /// Explicitly converts this to a bool3.
        /// </summary>
        public static explicit operator bool3(double4 v) => new bool3(v.x != 0.0, v.y != 0.0, v.z != 0.0);

        /// <summary>
        /// Explicitly converts this to a bool4.
        /// </summary>
        public static explicit operator bool4(double4 v) => new bool4(v.x != 0.0, v.y != 0.0, v.z != 0.0, v.w != 0.0);

        #endregion


        #region Indexer

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public double this[int index]
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
        public swizzle_dvec4 swizzle => new swizzle_dvec4(x, y, z, w);

        /// <summary>
        /// Gets or sets the specified subset of components. For more advanced (read-only) swizzling, use the .swizzle property.
        /// </summary>
        public double2 xy
        {
            get
            {
                return new double2(x, y);
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
        public double2 xz
        {
            get
            {
                return new double2(x, z);
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
        public double2 yz
        {
            get
            {
                return new double2(y, z);
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
        public double3 xyz
        {
            get
            {
                return new double3(x, y, z);
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
        public double2 xw
        {
            get
            {
                return new double2(x, w);
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
        public double2 yw
        {
            get
            {
                return new double2(y, w);
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
        public double3 xyw
        {
            get
            {
                return new double3(x, y, w);
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
        public double2 zw
        {
            get
            {
                return new double2(z, w);
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
        public double3 xzw
        {
            get
            {
                return new double3(x, z, w);
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
        public double3 yzw
        {
            get
            {
                return new double3(y, z, w);
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
        public double4 xyzw
        {
            get
            {
                return new double4(x, y, z, w);
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
        public double2 rg
        {
            get
            {
                return new double2(x, y);
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
        public double2 rb
        {
            get
            {
                return new double2(x, z);
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
        public double2 gb
        {
            get
            {
                return new double2(y, z);
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
        public double3 rgb
        {
            get
            {
                return new double3(x, y, z);
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
        public double2 ra
        {
            get
            {
                return new double2(x, w);
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
        public double2 ga
        {
            get
            {
                return new double2(y, w);
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
        public double3 rga
        {
            get
            {
                return new double3(x, y, w);
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
        public double2 ba
        {
            get
            {
                return new double2(z, w);
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
        public double3 rba
        {
            get
            {
                return new double3(x, z, w);
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
        public double3 gba
        {
            get
            {
                return new double3(y, z, w);
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
        public double4 rgba
        {
            get
            {
                return new double4(x, y, z, w);
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
        public double r
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
        public double g
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
        public double b
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
        public double a
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
        public double MinElement => Math.Min(Math.Min(x, y), Math.Min(z, w));

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public double MaxElement => Math.Max(Math.Max(x, y), Math.Max(z, w));

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public double Length => (double)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public double LengthSqr => ((x * x + y * y) + (z * z + w * w));

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public double Sum => ((x + y) + (z + w));

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public double Norm => (double)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public double Norm1 => ((Math.Abs(x) + Math.Abs(y)) + (Math.Abs(z) + Math.Abs(w)));

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public double Norm2 => (double)Math.Sqrt(((x * x + y * y) + (z * z + w * w)));

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public double NormMax => Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Max(Math.Abs(z), Math.Abs(w)));

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public double4 Normalized => this / (double)Length;

        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        public double4 NormalizedSafe => this == Zero ? Zero : this / (double)Length;

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero vector
        /// </summary>
        public static double4 Zero { get; } = new double4(0.0, 0.0, 0.0, 0.0);

        /// <summary>
        /// Predefined all-ones vector
        /// </summary>
        public static double4 Ones { get; } = new double4(1.0, 1.0, 1.0, 1.0);

        /// <summary>
        /// Predefined unit-X vector
        /// </summary>
        public static double4 UnitX { get; } = new double4(1.0, 0.0, 0.0, 0.0);

        /// <summary>
        /// Predefined unit-Y vector
        /// </summary>
        public static double4 UnitY { get; } = new double4(0.0, 1.0, 0.0, 0.0);

        /// <summary>
        /// Predefined unit-Z vector
        /// </summary>
        public static double4 UnitZ { get; } = new double4(0.0, 0.0, 1.0, 0.0);

        /// <summary>
        /// Predefined unit-W vector
        /// </summary>
        public static double4 UnitW { get; } = new double4(0.0, 0.0, 0.0, 1.0);

        /// <summary>
        /// Predefined all-MaxValue vector
        /// </summary>
        public static double4 MaxValue { get; } = new double4(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);

        /// <summary>
        /// Predefined all-MinValue vector
        /// </summary>
        public static double4 MinValue { get; } = new double4(double.MinValue, double.MinValue, double.MinValue, double.MinValue);

        /// <summary>
        /// Predefined all-Epsilon vector
        /// </summary>
        public static double4 Epsilon { get; } = new double4(double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon);

        /// <summary>
        /// Predefined all-NaN vector
        /// </summary>
        public static double4 NaN { get; } = new double4(double.NaN, double.NaN, double.NaN, double.NaN);

        /// <summary>
        /// Predefined all-NegativeInfinity vector
        /// </summary>
        public static double4 NegativeInfinity { get; } = new double4(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

        /// <summary>
        /// Predefined all-PositiveInfinity vector
        /// </summary>
        public static double4 PositiveInfinity { get; } = new double4(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);

        #endregion


        #region Operators

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(double4 lhs, double4 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(double4 lhs, double4 rhs) => !lhs.Equals(rhs);

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
        public bool Equals(double4 rhs) => ((x.Equals(rhs.x) && y.Equals(rhs.y)) && (z.Equals(rhs.z) && w.Equals(rhs.w)));

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
        public double NormP(double p) => Math.Pow(((Math.Pow((double)Math.Abs(x), p) + Math.Pow((double)Math.Abs(y), p)) + (Math.Pow((double)Math.Abs(z), p) + Math.Pow((double)Math.Abs(w), p))), 1 / p);

        #endregion


        #region Static Functions

        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        public static bool ApproxEqual(double4 lhs, double4 rhs, double eps = 0.1d) => Distance(lhs, rhs) <= eps;

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double4x2 OuterProduct(double2 c, double4 r) => new double4x2(c.x * r.x, c.y * r.x, c.x * r.y, c.y * r.y, c.x * r.z, c.y * r.z, c.x * r.w, c.y * r.w);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double2x4 OuterProduct(double4 c, double2 r) => new double2x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double4x3 OuterProduct(double3 c, double4 r) => new double4x3(c.x * r.x, c.y * r.x, c.z * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.x * r.w, c.y * r.w, c.z * r.w);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double3x4 OuterProduct(double4 c, double3 r) => new double3x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double4x4 OuterProduct(double4 c, double4 r) => new double4x4(c.x * r.x, c.y * r.x, c.z * r.x, c.w * r.x, c.x * r.y, c.y * r.y, c.z * r.y, c.w * r.y, c.x * r.z, c.y * r.z, c.z * r.z, c.w * r.z, c.x * r.w, c.y * r.w, c.z * r.w, c.w * r.w);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static double Dot(double4 lhs, double4 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(double4 lhs, double4 rhs) => (lhs - rhs).Length;

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static double DistanceSqr(double4 lhs, double4 rhs) => (lhs - rhs).LengthSqr;

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double4 Reflect(double4 I, double4 N) => I - 2 * Dot(N, I) * N;

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double4 Refract(double4 I, double4 N, double eta)
        {
            var dNI = Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return Zero;
            return eta * I - (eta * dNI + (double)Math.Sqrt(k)) * N;
        }

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static double4 FaceForward(double4 N, double4 I, double4 Nref) => Dot(Nref, I) < 0 ? N : -N;

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(double4 lhs, double4 rhs) => new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(double4 lhs, double rhs) => new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(double lhs, double4 rhs) => new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w);

        /// <summary>
        /// Returns a bvec from the application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(double lhs, double rhs) => new bool4(lhs == rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(double4 lhs, double4 rhs) => new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(double4 lhs, double rhs) => new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(double lhs, double4 rhs) => new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w);

        /// <summary>
        /// Returns a bvec from the application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(double lhs, double rhs) => new bool4(lhs != rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(double4 lhs, double4 rhs) => new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(double4 lhs, double rhs) => new bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(double lhs, double4 rhs) => new bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);

        /// <summary>
        /// Returns a bvec from the application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(double lhs, double rhs) => new bool4(lhs > rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(double4 lhs, double4 rhs) => new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(double4 lhs, double rhs) => new bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(double lhs, double4 rhs) => new bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);

        /// <summary>
        /// Returns a bvec from the application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(double lhs, double rhs) => new bool4(lhs >= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(double4 lhs, double4 rhs) => new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(double4 lhs, double rhs) => new bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(double lhs, double4 rhs) => new bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);

        /// <summary>
        /// Returns a bvec from the application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(double lhs, double rhs) => new bool4(lhs < rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(double4 lhs, double4 rhs) => new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(double4 lhs, double rhs) => new bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(double lhs, double4 rhs) => new bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);

        /// <summary>
        /// Returns a bvec from the application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(double lhs, double rhs) => new bool4(lhs <= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool4 IsInfinity(double4 v) => new bool4(double.IsInfinity(v.x), double.IsInfinity(v.y), double.IsInfinity(v.z), double.IsInfinity(v.w));

        /// <summary>
        /// Returns a bvec from the application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool4 IsInfinity(double v) => new bool4(double.IsInfinity(v));

        /// <summary>
        /// Returns a bool4 from component-wise application of IsFinite (!double.IsNaN(v) &amp;&amp; !double.IsInfinity(v)).
        /// </summary>
        public static bool4 IsFinite(double4 v) => new bool4(!double.IsNaN(v.x) && !double.IsInfinity(v.x), !double.IsNaN(v.y) && !double.IsInfinity(v.y), !double.IsNaN(v.z) && !double.IsInfinity(v.z), !double.IsNaN(v.w) && !double.IsInfinity(v.w));

        /// <summary>
        /// Returns a bvec from the application of IsFinite (!double.IsNaN(v) &amp;&amp; !double.IsInfinity(v)).
        /// </summary>
        public static bool4 IsFinite(double v) => new bool4(!double.IsNaN(v) && !double.IsInfinity(v));

        /// <summary>
        /// Returns a bool4 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool4 IsNaN(double4 v) => new bool4(double.IsNaN(v.x), double.IsNaN(v.y), double.IsNaN(v.z), double.IsNaN(v.w));

        /// <summary>
        /// Returns a bvec from the application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool4 IsNaN(double v) => new bool4(double.IsNaN(v));

        /// <summary>
        /// Returns a bool4 from component-wise application of IsNegativeInfinity (double.IsNegativeInfinity(v)).
        /// </summary>
        public static bool4 IsNegativeInfinity(double4 v) => new bool4(double.IsNegativeInfinity(v.x), double.IsNegativeInfinity(v.y), double.IsNegativeInfinity(v.z), double.IsNegativeInfinity(v.w));

        /// <summary>
        /// Returns a bvec from the application of IsNegativeInfinity (double.IsNegativeInfinity(v)).
        /// </summary>
        public static bool4 IsNegativeInfinity(double v) => new bool4(double.IsNegativeInfinity(v));

        /// <summary>
        /// Returns a bool4 from component-wise application of IsPositiveInfinity (double.IsPositiveInfinity(v)).
        /// </summary>
        public static bool4 IsPositiveInfinity(double4 v) => new bool4(double.IsPositiveInfinity(v.x), double.IsPositiveInfinity(v.y), double.IsPositiveInfinity(v.z), double.IsPositiveInfinity(v.w));

        /// <summary>
        /// Returns a bvec from the application of IsPositiveInfinity (double.IsPositiveInfinity(v)).
        /// </summary>
        public static bool4 IsPositiveInfinity(double v) => new bool4(double.IsPositiveInfinity(v));

        /// <summary>
        /// Returns a double4 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static double4 Abs(double4 v) => new double4(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z), Math.Abs(v.w));

        /// <summary>
        /// Returns a dvec from the application of Abs (Math.Abs(v)).
        /// </summary>
        public static double4 Abs(double v) => new double4(Math.Abs(v));

        /// <summary>
        /// Returns a double4 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static double4 HermiteInterpolationOrder3(double4 v) => new double4((3 - 2 * v.x) * v.x * v.x, (3 - 2 * v.y) * v.y * v.y, (3 - 2 * v.z) * v.z * v.z, (3 - 2 * v.w) * v.w * v.w);

        /// <summary>
        /// Returns a dvec from the application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static double4 HermiteInterpolationOrder3(double v) => new double4((3 - 2 * v) * v * v);

        /// <summary>
        /// Returns a double4 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static double4 HermiteInterpolationOrder5(double4 v) => new double4(((6 * v.x - 15) * v.x + 10) * v.x * v.x * v.x, ((6 * v.y - 15) * v.y + 10) * v.y * v.y * v.y, ((6 * v.z - 15) * v.z + 10) * v.z * v.z * v.z, ((6 * v.w - 15) * v.w + 10) * v.w * v.w * v.w);

        /// <summary>
        /// Returns a dvec from the application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static double4 HermiteInterpolationOrder5(double v) => new double4(((6 * v - 15) * v + 10) * v * v * v);

        /// <summary>
        /// Returns a double4 from component-wise application of Sqr (v * v).
        /// </summary>
        public static double4 Sqr(double4 v) => new double4(v.x * v.x, v.y * v.y, v.z * v.z, v.w * v.w);

        /// <summary>
        /// Returns a dvec from the application of Sqr (v * v).
        /// </summary>
        public static double4 Sqr(double v) => new double4(v * v);

        /// <summary>
        /// Returns a double4 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static double4 Pow2(double4 v) => new double4(v.x * v.x, v.y * v.y, v.z * v.z, v.w * v.w);

        /// <summary>
        /// Returns a dvec from the application of Pow2 (v * v).
        /// </summary>
        public static double4 Pow2(double v) => new double4(v * v);

        /// <summary>
        /// Returns a double4 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static double4 Pow3(double4 v) => new double4(v.x * v.x * v.x, v.y * v.y * v.y, v.z * v.z * v.z, v.w * v.w * v.w);

        /// <summary>
        /// Returns a dvec from the application of Pow3 (v * v * v).
        /// </summary>
        public static double4 Pow3(double v) => new double4(v * v * v);

        /// <summary>
        /// Returns a double4 from component-wise application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        public static double4 Step(double4 v) => new double4(v.x >= 0.0 ? 1.0 : 0.0, v.y >= 0.0 ? 1.0 : 0.0, v.z >= 0.0 ? 1.0 : 0.0, v.w >= 0.0 ? 1.0 : 0.0);

        /// <summary>
        /// Returns a dvec from the application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        public static double4 Step(double v) => new double4(v >= 0.0 ? 1.0 : 0.0);

        /// <summary>
        /// Returns a double4 from component-wise application of Sqrt ((double)Math.Sqrt((double)v)).
        /// </summary>
        public static double4 Sqrt(double4 v) => new double4((double)Math.Sqrt(v.x), (double)Math.Sqrt(v.y), (double)Math.Sqrt(v.z), (double)Math.Sqrt(v.w));

        /// <summary>
        /// Returns a dvec from the application of Sqrt ((double)Math.Sqrt((double)v)).
        /// </summary>
        public static double4 Sqrt(double v) => new double4((double)Math.Sqrt((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of InverseSqrt ((double)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static double4 InverseSqrt(double4 v) => new double4((double)(1.0 / Math.Sqrt(v.x)), (double)(1.0 / Math.Sqrt(v.y)), (double)(1.0 / Math.Sqrt(v.z)), (double)(1.0 / Math.Sqrt(v.w)));

        /// <summary>
        /// Returns a dvec from the application of InverseSqrt ((double)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static double4 InverseSqrt(double v) => new double4((double)(1.0 / Math.Sqrt((double)v)));

        /// <summary>
        /// Returns a int4 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int4 Sign(double4 v) => new int4(Math.Sign(v.x), Math.Sign(v.y), Math.Sign(v.z), Math.Sign(v.w));

        /// <summary>
        /// Returns a ivec from the application of Sign (Math.Sign(v)).
        /// </summary>
        public static int4 Sign(double v) => new int4(Math.Sign(v));

        /// <summary>
        /// Returns a double4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static double4 Max(double4 lhs, double4 rhs) => new double4(Math.Max(lhs.x, rhs.x), Math.Max(lhs.y, rhs.y), Math.Max(lhs.z, rhs.z), Math.Max(lhs.w, rhs.w));

        /// <summary>
        /// Returns a double4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static double4 Max(double4 lhs, double rhs) => new double4(Math.Max(lhs.x, rhs), Math.Max(lhs.y, rhs), Math.Max(lhs.z, rhs), Math.Max(lhs.w, rhs));

        /// <summary>
        /// Returns a double4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static double4 Max(double lhs, double4 rhs) => new double4(Math.Max(lhs, rhs.x), Math.Max(lhs, rhs.y), Math.Max(lhs, rhs.z), Math.Max(lhs, rhs.w));

        /// <summary>
        /// Returns a dvec from the application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static double4 Max(double lhs, double rhs) => new double4(Math.Max(lhs, rhs));

        /// <summary>
        /// Returns a double4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static double4 Min(double4 lhs, double4 rhs) => new double4(Math.Min(lhs.x, rhs.x), Math.Min(lhs.y, rhs.y), Math.Min(lhs.z, rhs.z), Math.Min(lhs.w, rhs.w));

        /// <summary>
        /// Returns a double4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static double4 Min(double4 lhs, double rhs) => new double4(Math.Min(lhs.x, rhs), Math.Min(lhs.y, rhs), Math.Min(lhs.z, rhs), Math.Min(lhs.w, rhs));

        /// <summary>
        /// Returns a double4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static double4 Min(double lhs, double4 rhs) => new double4(Math.Min(lhs, rhs.x), Math.Min(lhs, rhs.y), Math.Min(lhs, rhs.z), Math.Min(lhs, rhs.w));

        /// <summary>
        /// Returns a dvec from the application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static double4 Min(double lhs, double rhs) => new double4(Math.Min(lhs, rhs));

        /// <summary>
        /// Returns a double4 from component-wise application of Pow ((double)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Pow(double4 lhs, double4 rhs) => new double4((double)Math.Pow(lhs.x, rhs.x), (double)Math.Pow(lhs.y, rhs.y), (double)Math.Pow(lhs.z, rhs.z), (double)Math.Pow(lhs.w, rhs.w));

        /// <summary>
        /// Returns a double4 from component-wise application of Pow ((double)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Pow(double4 lhs, double rhs) => new double4((double)Math.Pow(lhs.x, (double)rhs), (double)Math.Pow(lhs.y, (double)rhs), (double)Math.Pow(lhs.z, (double)rhs), (double)Math.Pow(lhs.w, (double)rhs));

        /// <summary>
        /// Returns a double4 from component-wise application of Pow ((double)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Pow(double lhs, double4 rhs) => new double4((double)Math.Pow((double)lhs, rhs.x), (double)Math.Pow((double)lhs, rhs.y), (double)Math.Pow((double)lhs, rhs.z), (double)Math.Pow((double)lhs, rhs.w));

        /// <summary>
        /// Returns a dvec from the application of Pow ((double)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Pow(double lhs, double rhs) => new double4((double)Math.Pow((double)lhs, (double)rhs));

        /// <summary>
        /// Returns a double4 from component-wise application of Log ((double)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Log(double4 lhs, double4 rhs) => new double4((double)Math.Log(lhs.x, rhs.x), (double)Math.Log(lhs.y, rhs.y), (double)Math.Log(lhs.z, rhs.z), (double)Math.Log(lhs.w, rhs.w));

        /// <summary>
        /// Returns a double4 from component-wise application of Log ((double)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Log(double4 lhs, double rhs) => new double4((double)Math.Log(lhs.x, (double)rhs), (double)Math.Log(lhs.y, (double)rhs), (double)Math.Log(lhs.z, (double)rhs), (double)Math.Log(lhs.w, (double)rhs));

        /// <summary>
        /// Returns a double4 from component-wise application of Log ((double)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Log(double lhs, double4 rhs) => new double4((double)Math.Log((double)lhs, rhs.x), (double)Math.Log((double)lhs, rhs.y), (double)Math.Log((double)lhs, rhs.z), (double)Math.Log((double)lhs, rhs.w));

        /// <summary>
        /// Returns a dvec from the application of Log ((double)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Log(double lhs, double rhs) => new double4((double)Math.Log((double)lhs, (double)rhs));

        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double4 v, double4 min, double4 max) => new double4(Math.Min(Math.Max(v.x, min.x), max.x), Math.Min(Math.Max(v.y, min.y), max.y), Math.Min(Math.Max(v.z, min.z), max.z), Math.Min(Math.Max(v.w, min.w), max.w));

        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double4 v, double4 min, double max) => new double4(Math.Min(Math.Max(v.x, min.x), max), Math.Min(Math.Max(v.y, min.y), max), Math.Min(Math.Max(v.z, min.z), max), Math.Min(Math.Max(v.w, min.w), max));

        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double4 v, double min, double4 max) => new double4(Math.Min(Math.Max(v.x, min), max.x), Math.Min(Math.Max(v.y, min), max.y), Math.Min(Math.Max(v.z, min), max.z), Math.Min(Math.Max(v.w, min), max.w));

        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double4 v, double min, double max) => new double4(Math.Min(Math.Max(v.x, min), max), Math.Min(Math.Max(v.y, min), max), Math.Min(Math.Max(v.z, min), max), Math.Min(Math.Max(v.w, min), max));

        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double v, double4 min, double4 max) => new double4(Math.Min(Math.Max(v, min.x), max.x), Math.Min(Math.Max(v, min.y), max.y), Math.Min(Math.Max(v, min.z), max.z), Math.Min(Math.Max(v, min.w), max.w));

        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double v, double4 min, double max) => new double4(Math.Min(Math.Max(v, min.x), max), Math.Min(Math.Max(v, min.y), max), Math.Min(Math.Max(v, min.z), max), Math.Min(Math.Max(v, min.w), max));

        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double v, double min, double4 max) => new double4(Math.Min(Math.Max(v, min), max.x), Math.Min(Math.Max(v, min), max.y), Math.Min(Math.Max(v, min), max.z), Math.Min(Math.Max(v, min), max.w));

        /// <summary>
        /// Returns a dvec from the application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double v, double min, double max) => new double4(Math.Min(Math.Max(v, min), max));

        /// <summary>
        /// Returns a double4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double4 min, double4 max, double4 a) => new double4(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z, min.w * (1 - a.w) + max.w * a.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double4 min, double4 max, double a) => new double4(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a, min.w * (1 - a) + max.w * a);

        /// <summary>
        /// Returns a double4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double4 min, double max, double4 a) => new double4(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z, min.w * (1 - a.w) + max * a.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double4 min, double max, double a) => new double4(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a, min.w * (1 - a) + max * a);

        /// <summary>
        /// Returns a double4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double min, double4 max, double4 a) => new double4(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z, min * (1 - a.w) + max.w * a.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double min, double4 max, double a) => new double4(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a, min * (1 - a) + max.w * a);

        /// <summary>
        /// Returns a double4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double min, double max, double4 a) => new double4(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z, min * (1 - a.w) + max * a.w);

        /// <summary>
        /// Returns a dvec from the application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double min, double max, double a) => new double4(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double4 min, double4 max, double4 a) => new double4(min.x * (1 - a.x) + max.x * a.x, min.y * (1 - a.y) + max.y * a.y, min.z * (1 - a.z) + max.z * a.z, min.w * (1 - a.w) + max.w * a.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double4 min, double4 max, double a) => new double4(min.x * (1 - a) + max.x * a, min.y * (1 - a) + max.y * a, min.z * (1 - a) + max.z * a, min.w * (1 - a) + max.w * a);

        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double4 min, double max, double4 a) => new double4(min.x * (1 - a.x) + max * a.x, min.y * (1 - a.y) + max * a.y, min.z * (1 - a.z) + max * a.z, min.w * (1 - a.w) + max * a.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double4 min, double max, double a) => new double4(min.x * (1 - a) + max * a, min.y * (1 - a) + max * a, min.z * (1 - a) + max * a, min.w * (1 - a) + max * a);

        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double min, double4 max, double4 a) => new double4(min * (1 - a.x) + max.x * a.x, min * (1 - a.y) + max.y * a.y, min * (1 - a.z) + max.z * a.z, min * (1 - a.w) + max.w * a.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double min, double4 max, double a) => new double4(min * (1 - a) + max.x * a, min * (1 - a) + max.y * a, min * (1 - a) + max.z * a, min * (1 - a) + max.w * a);

        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double min, double max, double4 a) => new double4(min * (1 - a.x) + max * a.x, min * (1 - a.y) + max * a.y, min * (1 - a.z) + max * a.z, min * (1 - a.w) + max * a.w);

        /// <summary>
        /// Returns a dvec from the application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double min, double max, double a) => new double4(min * (1 - a) + max * a);

        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double4 edge0, double4 edge1, double4 v) => new double4(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3(), ((v.w - edge0.w) / (edge1.w - edge0.w)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double4 edge0, double4 edge1, double v) => new double4(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.w) / (edge1.w - edge0.w)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double4 edge0, double edge1, double4 v) => new double4(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3(), ((v.w - edge0.w) / (edge1 - edge0.w)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double4 edge0, double edge1, double v) => new double4(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder3(), ((v - edge0.w) / (edge1 - edge0.w)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double edge0, double4 edge1, double4 v) => new double4(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.w - edge0) / (edge1.w - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double edge0, double4 edge1, double v) => new double4(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder3(), ((v - edge0) / (edge1.w - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double edge0, double edge1, double4 v) => new double4(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3(), ((v.w - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a dvec from the application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double edge0, double edge1, double v) => new double4(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a double4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double4 edge0, double4 edge1, double4 v) => new double4(((v.x - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5(), ((v.w - edge0.w) / (edge1.w - edge0.w)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a double4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double4 edge0, double4 edge1, double v) => new double4(((v - edge0.x) / (edge1.x - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1.y - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1.z - edge0.z)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.w) / (edge1.w - edge0.w)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a double4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double4 edge0, double edge1, double4 v) => new double4(((v.x - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5(), ((v.w - edge0.w) / (edge1 - edge0.w)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a double4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double4 edge0, double edge1, double v) => new double4(((v - edge0.x) / (edge1 - edge0.x)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.y) / (edge1 - edge0.y)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.z) / (edge1 - edge0.z)).Clamp().HermiteInterpolationOrder5(), ((v - edge0.w) / (edge1 - edge0.w)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a double4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double edge0, double4 edge1, double4 v) => new double4(((v.x - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.w - edge0) / (edge1.w - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a double4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double edge0, double4 edge1, double v) => new double4(((v - edge0) / (edge1.x - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.y - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.z - edge0)).Clamp().HermiteInterpolationOrder5(), ((v - edge0) / (edge1.w - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a double4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double edge0, double edge1, double4 v) => new double4(((v.x - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.y - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.z - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5(), ((v.w - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a dvec from the application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double edge0, double edge1, double v) => new double4(((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5());

        /// <summary>
        /// Returns a double4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double4 a, double4 b, double4 c) => new double4(a.x * b.x + c.x, a.y * b.y + c.y, a.z * b.z + c.z, a.w * b.w + c.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double4 a, double4 b, double c) => new double4(a.x * b.x + c, a.y * b.y + c, a.z * b.z + c, a.w * b.w + c);

        /// <summary>
        /// Returns a double4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double4 a, double b, double4 c) => new double4(a.x * b + c.x, a.y * b + c.y, a.z * b + c.z, a.w * b + c.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double4 a, double b, double c) => new double4(a.x * b + c, a.y * b + c, a.z * b + c, a.w * b + c);

        /// <summary>
        /// Returns a double4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double a, double4 b, double4 c) => new double4(a * b.x + c.x, a * b.y + c.y, a * b.z + c.z, a * b.w + c.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double a, double4 b, double c) => new double4(a * b.x + c, a * b.y + c, a * b.z + c, a * b.w + c);

        /// <summary>
        /// Returns a double4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double a, double b, double4 c) => new double4(a * b + c.x, a * b + c.y, a * b + c.z, a * b + c.w);

        /// <summary>
        /// Returns a dvec from the application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double a, double b, double c) => new double4(a * b + c);

        /// <summary>
        /// Returns a double4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double4 Add(double4 lhs, double4 rhs) => new double4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double4 Add(double4 lhs, double rhs) => new double4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double4 Add(double lhs, double4 rhs) => new double4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);

        /// <summary>
        /// Returns a dvec from the application of Add (lhs + rhs).
        /// </summary>
        public static double4 Add(double lhs, double rhs) => new double4(lhs + rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double4 Sub(double4 lhs, double4 rhs) => new double4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double4 Sub(double4 lhs, double rhs) => new double4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double4 Sub(double lhs, double4 rhs) => new double4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);

        /// <summary>
        /// Returns a dvec from the application of Sub (lhs - rhs).
        /// </summary>
        public static double4 Sub(double lhs, double rhs) => new double4(lhs - rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double4 Mul(double4 lhs, double4 rhs) => new double4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double4 Mul(double4 lhs, double rhs) => new double4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double4 Mul(double lhs, double4 rhs) => new double4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);

        /// <summary>
        /// Returns a dvec from the application of Mul (lhs * rhs).
        /// </summary>
        public static double4 Mul(double lhs, double rhs) => new double4(lhs * rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double4 Div(double4 lhs, double4 rhs) => new double4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double4 Div(double4 lhs, double rhs) => new double4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double4 Div(double lhs, double4 rhs) => new double4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);

        /// <summary>
        /// Returns a dvec from the application of Div (lhs / rhs).
        /// </summary>
        public static double4 Div(double lhs, double rhs) => new double4(lhs / rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double4 Modulo(double4 lhs, double4 rhs) => new double4(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z, lhs.w % rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double4 Modulo(double4 lhs, double rhs) => new double4(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs, lhs.w % rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double4 Modulo(double lhs, double4 rhs) => new double4(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z, lhs % rhs.w);

        /// <summary>
        /// Returns a dvec from the application of Modulo (lhs % rhs).
        /// </summary>
        public static double4 Modulo(double lhs, double rhs) => new double4(lhs % rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static double4 Degrees(double4 v) => new double4((double)(v.x * 57.295779513082320876798154814105170332405472466564321d), (double)(v.y * 57.295779513082320876798154814105170332405472466564321d), (double)(v.z * 57.295779513082320876798154814105170332405472466564321d), (double)(v.w * 57.295779513082320876798154814105170332405472466564321d));

        /// <summary>
        /// Returns a dvec from the application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static double4 Degrees(double v) => new double4((double)(v * 57.295779513082320876798154814105170332405472466564321d));

        /// <summary>
        /// Returns a double4 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static double4 Radians(double4 v) => new double4((double)(v.x * 0.0174532925199432957692369076848861271344287188854172d), (double)(v.y * 0.0174532925199432957692369076848861271344287188854172d), (double)(v.z * 0.0174532925199432957692369076848861271344287188854172d), (double)(v.w * 0.0174532925199432957692369076848861271344287188854172d));

        /// <summary>
        /// Returns a dvec from the application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static double4 Radians(double v) => new double4((double)(v * 0.0174532925199432957692369076848861271344287188854172d));

        /// <summary>
        /// Returns a double4 from component-wise application of Acos ((double)Math.Acos((double)v)).
        /// </summary>
        public static double4 Acos(double4 v) => new double4((double)Math.Acos(v.x), (double)Math.Acos(v.y), (double)Math.Acos(v.z), (double)Math.Acos(v.w));

        /// <summary>
        /// Returns a dvec from the application of Acos ((double)Math.Acos((double)v)).
        /// </summary>
        public static double4 Acos(double v) => new double4((double)Math.Acos((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Asin ((double)Math.Asin((double)v)).
        /// </summary>
        public static double4 Asin(double4 v) => new double4((double)Math.Asin(v.x), (double)Math.Asin(v.y), (double)Math.Asin(v.z), (double)Math.Asin(v.w));

        /// <summary>
        /// Returns a dvec from the application of Asin ((double)Math.Asin((double)v)).
        /// </summary>
        public static double4 Asin(double v) => new double4((double)Math.Asin((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Atan ((double)Math.Atan((double)v)).
        /// </summary>
        public static double4 Atan(double4 v) => new double4((double)Math.Atan(v.x), (double)Math.Atan(v.y), (double)Math.Atan(v.z), (double)Math.Atan(v.w));

        /// <summary>
        /// Returns a dvec from the application of Atan ((double)Math.Atan((double)v)).
        /// </summary>
        public static double4 Atan(double v) => new double4((double)Math.Atan((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Cos ((double)Math.Cos((double)v)).
        /// </summary>
        public static double4 Cos(double4 v) => new double4((double)Math.Cos(v.x), (double)Math.Cos(v.y), (double)Math.Cos(v.z), (double)Math.Cos(v.w));

        /// <summary>
        /// Returns a dvec from the application of Cos ((double)Math.Cos((double)v)).
        /// </summary>
        public static double4 Cos(double v) => new double4((double)Math.Cos((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Cosh ((double)Math.Cosh((double)v)).
        /// </summary>
        public static double4 Cosh(double4 v) => new double4((double)Math.Cosh(v.x), (double)Math.Cosh(v.y), (double)Math.Cosh(v.z), (double)Math.Cosh(v.w));

        /// <summary>
        /// Returns a dvec from the application of Cosh ((double)Math.Cosh((double)v)).
        /// </summary>
        public static double4 Cosh(double v) => new double4((double)Math.Cosh((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Exp ((double)Math.Exp((double)v)).
        /// </summary>
        public static double4 Exp(double4 v) => new double4((double)Math.Exp(v.x), (double)Math.Exp(v.y), (double)Math.Exp(v.z), (double)Math.Exp(v.w));

        /// <summary>
        /// Returns a dvec from the application of Exp ((double)Math.Exp((double)v)).
        /// </summary>
        public static double4 Exp(double v) => new double4((double)Math.Exp((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Log ((double)Math.Log((double)v)).
        /// </summary>
        public static double4 Log(double4 v) => new double4((double)Math.Log(v.x), (double)Math.Log(v.y), (double)Math.Log(v.z), (double)Math.Log(v.w));

        /// <summary>
        /// Returns a dvec from the application of Log ((double)Math.Log((double)v)).
        /// </summary>
        public static double4 Log(double v) => new double4((double)Math.Log((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Log2 ((double)Math.Log((double)v, 2)).
        /// </summary>
        public static double4 Log2(double4 v) => new double4((double)Math.Log(v.x, 2), (double)Math.Log(v.y, 2), (double)Math.Log(v.z, 2), (double)Math.Log(v.w, 2));

        /// <summary>
        /// Returns a dvec from the application of Log2 ((double)Math.Log((double)v, 2)).
        /// </summary>
        public static double4 Log2(double v) => new double4((double)Math.Log((double)v, 2));

        /// <summary>
        /// Returns a double4 from component-wise application of Log10 ((double)Math.Log10((double)v)).
        /// </summary>
        public static double4 Log10(double4 v) => new double4((double)Math.Log10(v.x), (double)Math.Log10(v.y), (double)Math.Log10(v.z), (double)Math.Log10(v.w));

        /// <summary>
        /// Returns a dvec from the application of Log10 ((double)Math.Log10((double)v)).
        /// </summary>
        public static double4 Log10(double v) => new double4((double)Math.Log10((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Floor ((double)Math.Floor(v)).
        /// </summary>
        public static double4 Floor(double4 v) => new double4((double)Math.Floor(v.x), (double)Math.Floor(v.y), (double)Math.Floor(v.z), (double)Math.Floor(v.w));

        /// <summary>
        /// Returns a dvec from the application of Floor ((double)Math.Floor(v)).
        /// </summary>
        public static double4 Floor(double v) => new double4((double)Math.Floor(v));

        /// <summary>
        /// Returns a double4 from component-wise application of Ceiling ((double)Math.Ceiling(v)).
        /// </summary>
        public static double4 Ceiling(double4 v) => new double4((double)Math.Ceiling(v.x), (double)Math.Ceiling(v.y), (double)Math.Ceiling(v.z), (double)Math.Ceiling(v.w));

        /// <summary>
        /// Returns a dvec from the application of Ceiling ((double)Math.Ceiling(v)).
        /// </summary>
        public static double4 Ceiling(double v) => new double4((double)Math.Ceiling(v));

        /// <summary>
        /// Returns a double4 from component-wise application of Round ((double)Math.Round(v)).
        /// </summary>
        public static double4 Round(double4 v) => new double4((double)Math.Round(v.x), (double)Math.Round(v.y), (double)Math.Round(v.z), (double)Math.Round(v.w));

        /// <summary>
        /// Returns a dvec from the application of Round ((double)Math.Round(v)).
        /// </summary>
        public static double4 Round(double v) => new double4((double)Math.Round(v));

        /// <summary>
        /// Returns a double4 from component-wise application of Sin ((double)Math.Sin((double)v)).
        /// </summary>
        public static double4 Sin(double4 v) => new double4((double)Math.Sin(v.x), (double)Math.Sin(v.y), (double)Math.Sin(v.z), (double)Math.Sin(v.w));

        /// <summary>
        /// Returns a dvec from the application of Sin ((double)Math.Sin((double)v)).
        /// </summary>
        public static double4 Sin(double v) => new double4((double)Math.Sin((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Sinh ((double)Math.Sinh((double)v)).
        /// </summary>
        public static double4 Sinh(double4 v) => new double4((double)Math.Sinh(v.x), (double)Math.Sinh(v.y), (double)Math.Sinh(v.z), (double)Math.Sinh(v.w));

        /// <summary>
        /// Returns a dvec from the application of Sinh ((double)Math.Sinh((double)v)).
        /// </summary>
        public static double4 Sinh(double v) => new double4((double)Math.Sinh((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Tan ((double)Math.Tan((double)v)).
        /// </summary>
        public static double4 Tan(double4 v) => new double4((double)Math.Tan(v.x), (double)Math.Tan(v.y), (double)Math.Tan(v.z), (double)Math.Tan(v.w));

        /// <summary>
        /// Returns a dvec from the application of Tan ((double)Math.Tan((double)v)).
        /// </summary>
        public static double4 Tan(double v) => new double4((double)Math.Tan((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Tanh ((double)Math.Tanh((double)v)).
        /// </summary>
        public static double4 Tanh(double4 v) => new double4((double)Math.Tanh(v.x), (double)Math.Tanh(v.y), (double)Math.Tanh(v.z), (double)Math.Tanh(v.w));

        /// <summary>
        /// Returns a dvec from the application of Tanh ((double)Math.Tanh((double)v)).
        /// </summary>
        public static double4 Tanh(double v) => new double4((double)Math.Tanh((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Truncate ((double)Math.Truncate((double)v)).
        /// </summary>
        public static double4 Truncate(double4 v) => new double4((double)Math.Truncate(v.x), (double)Math.Truncate(v.y), (double)Math.Truncate(v.z), (double)Math.Truncate(v.w));

        /// <summary>
        /// Returns a dvec from the application of Truncate ((double)Math.Truncate((double)v)).
        /// </summary>
        public static double4 Truncate(double v) => new double4((double)Math.Truncate((double)v));

        /// <summary>
        /// Returns a double4 from component-wise application of Fract ((double)(v - Math.Floor(v))).
        /// </summary>
        public static double4 Fract(double4 v) => new double4((double)(v.x - Math.Floor(v.x)), (double)(v.y - Math.Floor(v.y)), (double)(v.z - Math.Floor(v.z)), (double)(v.w - Math.Floor(v.w)));

        /// <summary>
        /// Returns a dvec from the application of Fract ((double)(v - Math.Floor(v))).
        /// </summary>
        public static double4 Fract(double v) => new double4((double)(v - Math.Floor(v)));

        /// <summary>
        /// Returns a double4 from component-wise application of Trunc ((long)(v)).
        /// </summary>
        public static double4 Trunc(double4 v) => new double4((long)(v.x), (long)(v.y), (long)(v.z), (long)(v.w));

        /// <summary>
        /// Returns a dvec from the application of Trunc ((long)(v)).
        /// </summary>
        public static double4 Trunc(double v) => new double4((long)(v));

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator <(double4 lhs, double4 rhs) => new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator <(double4 lhs, double rhs) => new bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt; (lhs &lt; rhs).
        /// </summary>
        public static bool4 operator <(double lhs, double4 rhs) => new bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator <=(double4 lhs, double4 rhs) => new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator <=(double4 lhs, double rhs) => new bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&lt;= (lhs &lt;= rhs).
        /// </summary>
        public static bool4 operator <=(double lhs, double4 rhs) => new bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator >(double4 lhs, double4 rhs) => new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator >(double4 lhs, double rhs) => new bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt; (lhs &gt; rhs).
        /// </summary>
        public static bool4 operator >(double lhs, double4 rhs) => new bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator >=(double4 lhs, double4 rhs) => new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator >=(double4 lhs, double rhs) => new bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of operator&gt;= (lhs &gt;= rhs).
        /// </summary>
        public static bool4 operator >=(double lhs, double4 rhs) => new bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double4 operator +(double4 lhs, double4 rhs) => new double4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double4 operator +(double4 lhs, double rhs) => new double4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double4 operator +(double lhs, double4 rhs) => new double4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double4 operator -(double4 lhs, double4 rhs) => new double4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double4 operator -(double4 lhs, double rhs) => new double4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double4 operator -(double lhs, double4 rhs) => new double4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double4 operator *(double4 lhs, double4 rhs) => new double4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double4 operator *(double4 lhs, double rhs) => new double4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double4 operator *(double lhs, double4 rhs) => new double4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double4 operator /(double4 lhs, double4 rhs) => new double4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double4 operator /(double4 lhs, double rhs) => new double4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double4 operator /(double lhs, double4 rhs) => new double4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator+ (identity).
        /// </summary>
        public static double4 operator +(double4 v) => v;

        /// <summary>
        /// Returns a double4 from component-wise application of operator- (-v).
        /// </summary>
        public static double4 operator -(double4 v) => new double4(-v.x, -v.y, -v.z, -v.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static double4 operator %(double4 lhs, double4 rhs) => new double4(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z, lhs.w % rhs.w);

        /// <summary>
        /// Returns a double4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static double4 operator %(double4 lhs, double rhs) => new double4(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs, lhs.w % rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static double4 operator %(double lhs, double4 rhs) => new double4(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z, lhs % rhs.w);

        #endregion

    }
}
