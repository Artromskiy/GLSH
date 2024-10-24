using System;
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [DataMember]
        public const int Count = 4;

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
        /// Implicitly converts this to a uint4.
        /// </summary>
        public static implicit operator uint4(int4 v) => new uint4((uint)v.x, (uint)v.y, (uint)v.z, (uint)v.w);

        /// <summary>
        /// Implicitly converts this to a float4.
        /// </summary>
        public static implicit operator float4(int4 v) => new float4(v.x, v.y, v.z, v.w);

        /// <summary>
        /// Implicitly converts this to a double4.
        /// </summary>
        public static implicit operator double4(int4 v) => new double4(v.x, v.y, v.z, v.w);

        #endregion


        #region Indexer

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public int this[int index]
        {
            get
            {
                if ((uint)index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return Unsafe.Add(ref x, index);
            }
            set
            {
                if ((uint)index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                Unsafe.Add(ref x, index) = value;
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified RGBA component.
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
        /// Gets or sets the specified RGBA component.
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
        /// Gets or sets the specified RGBA component.
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
        /// Gets or sets the specified RGBA component.
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

        #endregion


        #region Operators

        /// <summary>
        /// 
        /// </summary>
        public static bool operator ==(int4 lhs, int4 rhs) => lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w;

        /// <summary>
        /// 
        /// </summary>
        public static bool operator !=(int4 lhs, int4 rhs) => lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z || lhs.w != rhs.w;

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

        #endregion


        #region Static Functions

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (int.Clamp(v, min, max)).
        /// </summary>
        public static int4 Clamp(int4 v, int min, int max) => new int4(int.Clamp(v.x, min, max), int.Clamp(v.y, min, max), int.Clamp(v.z, min, max), int.Clamp(v.w, min, max));

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(int4 lhs, int4 rhs) => new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(int4 lhs, int4 rhs) => new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(int4 lhs, int4 rhs) => new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(int4 lhs, int4 rhs) => new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(int4 lhs, int4 rhs) => new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(int4 lhs, int4 rhs) => new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of Abs (int.Abs(v)).
        /// </summary>
        public static int4 Abs(int4 v) => new int4(int.Abs(v.x), int.Abs(v.y), int.Abs(v.z), int.Abs(v.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Sign (int.Sign(v)).
        /// </summary>
        public static int4 Sign(int4 v) => new int4(int.Sign(v.x), int.Sign(v.y), int.Sign(v.z), int.Sign(v.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Min (int.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int4 lhs, int4 rhs) => new int4(int.Min(lhs.x, rhs.x), int.Min(lhs.y, rhs.y), int.Min(lhs.z, rhs.z), int.Min(lhs.w, rhs.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Min (int.Min(lhs, rhs)).
        /// </summary>
        public static int4 Min(int4 lhs, int rhs) => new int4(int.Min(lhs.x, rhs), int.Min(lhs.y, rhs), int.Min(lhs.z, rhs), int.Min(lhs.w, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Max (int.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int4 lhs, int4 rhs) => new int4(int.Max(lhs.x, rhs.x), int.Max(lhs.y, rhs.y), int.Max(lhs.z, rhs.z), int.Max(lhs.w, rhs.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Max (int.Max(lhs, rhs)).
        /// </summary>
        public static int4 Max(int4 lhs, int rhs) => new int4(int.Max(lhs.x, rhs), int.Max(lhs.y, rhs), int.Max(lhs.z, rhs), int.Max(lhs.w, rhs));

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (int.Clamp(v, min, max)).
        /// </summary>
        public static int4 Clamp(int4 v, int4 min, int4 max) => new int4(int.Clamp(v.x, min.x, max.x), int.Clamp(v.y, min.y, max.y), int.Clamp(v.z, min.z, max.z), int.Clamp(v.w, min.w, max.w));

        /// <summary>
        /// Returns a int4 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static int4 Mix(int4 x, int4 y, bool4 a) => new int4(a.x ? y.x : x.x, a.y ? y.y : x.y, a.z ? y.z : x.z, a.w ? y.w : x.w);

        /// <summary>
        /// Returns a float4 from component-wise application of IntBitsToFloat (Unsafe.As&lt;int, float&gt;(ref v)).
        /// </summary>
        public static float4 IntBitsToFloat(int4 v) => new float4(Unsafe.As<int, float>(ref v.x), Unsafe.As<int, float>(ref v.y), Unsafe.As<int, float>(ref v.z), Unsafe.As<int, float>(ref v.w));

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a int4 from component-wise application of operator- (-v).
        /// </summary>
        public static int4 operator -(int4 v) => new int4(-v.x, -v.y, -v.z, -v.w);

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
        /// Returns a int4 from component-wise application of operator~ (~v).
        /// </summary>
        public static int4 operator ~(int4 v) => new int4(~v.x, ~v.y, ~v.z, ~v.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int4 operator %(int4 lhs, int4 rhs) => new int4(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z, lhs.w % rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int4 operator %(int4 lhs, int rhs) => new int4(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs, lhs.w % rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int4 operator %(int lhs, int4 rhs) => new int4(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z, lhs % rhs.w);

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
        public static int4 operator <<(int4 lhs, int4 rhs) => new int4(lhs.x << rhs.x, lhs.y << rhs.y, lhs.z << rhs.z, lhs.w << rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int4 operator <<(int4 lhs, int rhs) => new int4(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs, lhs.w << rhs);

        /// <summary>
        /// Returns a int4 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 operator >>(int4 lhs, int4 rhs) => new int4(lhs.x >> rhs.x, lhs.y >> rhs.y, lhs.z >> rhs.z, lhs.w >> rhs.w);

        /// <summary>
        /// Returns a int4 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int4 operator >>(int4 lhs, int rhs) => new int4(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs, lhs.w >> rhs);

        #endregion

    }
}
