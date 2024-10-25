using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;

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
        public int x;
        
        /// <summary>
        /// y-component
        /// </summary>
        public int y;
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        public const int Count = 2;

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
        /// Implicitly converts this to a uint2.
        /// </summary>
        public static implicit operator uint2(int2 v) => new uint2((uint)v.x, (uint)v.y);
        
        /// <summary>
        /// Implicitly converts this to a float2.
        /// </summary>
        public static implicit operator float2(int2 v) => new float2((float)v.x, (float)v.y);
        
        /// <summary>
        /// Implicitly converts this to a double2.
        /// </summary>
        public static implicit operator double2(int2 v) => new double2((double)v.x, (double)v.y);

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

        #endregion


        #region Operators
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator==(int2 lhs, int2 rhs) => lhs.x == rhs.x&&lhs.y == rhs.y;
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator!=(int2 lhs, int2 rhs) => lhs.x != rhs.x||lhs.y != rhs.y;

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

        #endregion


        #region Static Functions
        
        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (int.Clamp(v, min, max)).
        /// </summary>
        public static int2 Clamp(int2 v, int min, int max) => new int2(int.Clamp(v.x, min, max), int.Clamp(v.y, min, max));

        #endregion


        #region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(int2 lhs, int2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(int2 lhs, int2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(int2 lhs, int2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(int2 lhs, int2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(int2 lhs, int2 rhs) => new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(int2 lhs, int2 rhs) => new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of Abs (int.Abs(v)).
        /// </summary>
        public static int2 Abs(int2 v) => new int2(int.Abs(v.x), int.Abs(v.y));
        
        /// <summary>
        /// Returns a int2 from component-wise application of Sign (int.Sign(v)).
        /// </summary>
        public static int2 Sign(int2 v) => new int2(int.Sign(v.x), int.Sign(v.y));
        
        /// <summary>
        /// Returns a int2 from component-wise application of Min (int.Min(lhs, rhs)).
        /// </summary>
        public static int2 Min(int2 lhs, int2 rhs) => new int2(int.Min(lhs.x, rhs.x), int.Min(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a int2 from component-wise application of Min (int.Min(lhs, rhs)).
        /// </summary>
        public static int2 Min(int2 lhs, int rhs) => new int2(int.Min(lhs.x, rhs), int.Min(lhs.y, rhs));
        
        /// <summary>
        /// Returns a int2 from component-wise application of Max (int.Max(lhs, rhs)).
        /// </summary>
        public static int2 Max(int2 lhs, int2 rhs) => new int2(int.Max(lhs.x, rhs.x), int.Max(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a int2 from component-wise application of Max (int.Max(lhs, rhs)).
        /// </summary>
        public static int2 Max(int2 lhs, int rhs) => new int2(int.Max(lhs.x, rhs), int.Max(lhs.y, rhs));
        
        /// <summary>
        /// Returns a int2 from component-wise application of Clamp (int.Clamp(v, min, max)).
        /// </summary>
        public static int2 Clamp(int2 v, int2 min, int2 max) => new int2(int.Clamp(v.x, min.x, max.x), int.Clamp(v.y, min.y, max.y));
        
        /// <summary>
        /// Returns a int2 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static int2 Mix(int2 x, int2 y, bool2 a) => new int2(a.x ? y.x : x.x, a.y ? y.y : x.y);
        
        /// <summary>
        /// Returns a float2 from component-wise application of IntBitsToFloat (Unsafe.As&lt;int, float&gt;(ref v)).
        /// </summary>
        public static float2 IntBitsToFloat(int2 v) => new float2(Unsafe.As<int, float>(ref v.x), Unsafe.As<int, float>(ref v.y));

        #endregion


        #region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator- (-v).
        /// </summary>
        public static int2 operator-(int2 v) => new int2(-v.x, -v.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int2 operator+(int2 lhs, int2 rhs) => new int2(lhs.x + rhs.x, lhs.y + rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int2 operator+(int2 lhs, int rhs) => new int2(lhs.x + rhs, lhs.y + rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static int2 operator+(int lhs, int2 rhs) => new int2(lhs + rhs.x, lhs + rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int2 operator-(int2 lhs, int2 rhs) => new int2(lhs.x - rhs.x, lhs.y - rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int2 operator-(int2 lhs, int rhs) => new int2(lhs.x - rhs, lhs.y - rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static int2 operator-(int lhs, int2 rhs) => new int2(lhs - rhs.x, lhs - rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int2 operator*(int2 lhs, int2 rhs) => new int2(lhs.x * rhs.x, lhs.y * rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int2 operator*(int2 lhs, int rhs) => new int2(lhs.x * rhs, lhs.y * rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static int2 operator*(int lhs, int2 rhs) => new int2(lhs * rhs.x, lhs * rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int2 operator/(int2 lhs, int2 rhs) => new int2(lhs.x / rhs.x, lhs.y / rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int2 operator/(int2 lhs, int rhs) => new int2(lhs.x / rhs, lhs.y / rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static int2 operator/(int lhs, int2 rhs) => new int2(lhs / rhs.x, lhs / rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator~ (~v).
        /// </summary>
        public static int2 operator~(int2 v) => new int2(~v.x, ~v.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int2 operator%(int2 lhs, int2 rhs) => new int2(lhs.x % rhs.x, lhs.y % rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int2 operator%(int2 lhs, int rhs) => new int2(lhs.x % rhs, lhs.y % rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static int2 operator%(int lhs, int2 rhs) => new int2(lhs % rhs.x, lhs % rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int2 operator^(int2 lhs, int2 rhs) => new int2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int2 operator^(int2 lhs, int rhs) => new int2(lhs.x ^ rhs, lhs.y ^ rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static int2 operator^(int lhs, int2 rhs) => new int2(lhs ^ rhs.x, lhs ^ rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int2 operator|(int2 lhs, int2 rhs) => new int2(lhs.x | rhs.x, lhs.y | rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int2 operator|(int2 lhs, int rhs) => new int2(lhs.x | rhs, lhs.y | rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static int2 operator|(int lhs, int2 rhs) => new int2(lhs | rhs.x, lhs | rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int2 operator&(int2 lhs, int2 rhs) => new int2(lhs.x & rhs.x, lhs.y & rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int2 operator&(int2 lhs, int rhs) => new int2(lhs.x & rhs, lhs.y & rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static int2 operator&(int lhs, int2 rhs) => new int2(lhs & rhs.x, lhs & rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int2 operator<<(int2 lhs, int2 rhs) => new int2(lhs.x << rhs.x, lhs.y << rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static int2 operator<<(int2 lhs, int rhs) => new int2(lhs.x << rhs, lhs.y << rhs);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int2 operator>>(int2 lhs, int2 rhs) => new int2(lhs.x >> rhs.x, lhs.y >> rhs.y);
        
        /// <summary>
        /// Returns a int2 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static int2 operator>>(int2 lhs, int rhs) => new int2(lhs.x >> rhs, lhs.y >> rhs);

        #endregion

    }
}
