using System;
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        [DataMember]
        public const int Count = 3;

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
        /// Implicitly converts this to a uint3.
        /// </summary>
        public static implicit operator uint3(int3 v) => new uint3((uint)v.x, (uint)v.y, (uint)v.z);

        /// <summary>
        /// Implicitly converts this to a float3.
        /// </summary>
        public static implicit operator float3(int3 v) => new float3(v.x, v.y, v.z);

        /// <summary>
        /// Implicitly converts this to a double3.
        /// </summary>
        public static implicit operator double3(int3 v) => new double3(v.x, v.y, v.z);

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

        #endregion


        #region Operators

        /// <summary>
        /// 
        /// </summary>
        public static bool operator ==(int3 lhs, int3 rhs) => lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;

        /// <summary>
        /// 
        /// </summary>
        public static bool operator !=(int3 lhs, int3 rhs) => lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z;

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

        #endregion


        #region Static Functions

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (int.Clamp(v, min, max)).
        /// </summary>
        public static int3 Clamp(int3 v, int min, int max) => new int3(int.Clamp(v.x, min, max), int.Clamp(v.y, min, max), int.Clamp(v.z, min, max));

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(int3 lhs, int3 rhs) => new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(int3 lhs, int3 rhs) => new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(int3 lhs, int3 rhs) => new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(int3 lhs, int3 rhs) => new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(int3 lhs, int3 rhs) => new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(int3 lhs, int3 rhs) => new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of Abs (int.Abs(v)).
        /// </summary>
        public static int3 Abs(int3 v) => new int3(int.Abs(v.x), int.Abs(v.y), int.Abs(v.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Sign (int.Sign(v)).
        /// </summary>
        public static int3 Sign(int3 v) => new int3(int.Sign(v.x), int.Sign(v.y), int.Sign(v.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Min (int.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int3 lhs, int3 rhs) => new int3(int.Min(lhs.x, rhs.x), int.Min(lhs.y, rhs.y), int.Min(lhs.z, rhs.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Min (int.Min(lhs, rhs)).
        /// </summary>
        public static int3 Min(int3 lhs, int rhs) => new int3(int.Min(lhs.x, rhs), int.Min(lhs.y, rhs), int.Min(lhs.z, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Max (int.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int3 lhs, int3 rhs) => new int3(int.Max(lhs.x, rhs.x), int.Max(lhs.y, rhs.y), int.Max(lhs.z, rhs.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Max (int.Max(lhs, rhs)).
        /// </summary>
        public static int3 Max(int3 lhs, int rhs) => new int3(int.Max(lhs.x, rhs), int.Max(lhs.y, rhs), int.Max(lhs.z, rhs));

        /// <summary>
        /// Returns a int3 from component-wise application of Clamp (int.Clamp(v, min, max)).
        /// </summary>
        public static int3 Clamp(int3 v, int3 min, int3 max) => new int3(int.Clamp(v.x, min.x, max.x), int.Clamp(v.y, min.y, max.y), int.Clamp(v.z, min.z, max.z));

        /// <summary>
        /// Returns a int3 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static int3 Mix(int3 x, int3 y, bool3 a) => new int3(a.x ? y.x : x.x, a.y ? y.y : x.y, a.z ? y.z : x.z);

        /// <summary>
        /// Returns a float3 from component-wise application of IntBitsToFloat (Unsafe.As&lt;int, float&gt;(ref v)).
        /// </summary>
        public static float3 IntBitsToFloat(int3 v) => new float3(Unsafe.As<int, float>(ref v.x), Unsafe.As<int, float>(ref v.y), Unsafe.As<int, float>(ref v.z));

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a int3 from component-wise application of operator- (-v).
        /// </summary>
        public static int3 operator -(int3 v) => new int3(-v.x, -v.y, -v.z);

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
        /// Returns a int3 from component-wise application of operator~ (~v).
        /// </summary>
        public static int3 operator ~(int3 v) => new int3(~v.x, ~v.y, ~v.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int3 operator %(int3 lhs, int3 rhs) => new int3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int3 operator %(int3 lhs, int rhs) => new int3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int3 operator %(int lhs, int3 rhs) => new int3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z);

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
        public static int3 operator <<(int3 lhs, int3 rhs) => new int3(lhs.x << rhs.x, lhs.y << rhs.y, lhs.z << rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int3 operator <<(int3 lhs, int rhs) => new int3(lhs.x << rhs, lhs.y << rhs, lhs.z << rhs);

        /// <summary>
        /// Returns a int3 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 operator >>(int3 lhs, int3 rhs) => new int3(lhs.x >> rhs.x, lhs.y >> rhs.y, lhs.z >> rhs.z);

        /// <summary>
        /// Returns a int3 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int3 operator >>(int3 lhs, int rhs) => new int3(lhs.x >> rhs, lhs.y >> rhs, lhs.z >> rhs);

        #endregion

    }
}
