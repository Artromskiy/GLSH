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
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        [DataMember]
        public const int Count = 2;

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


        #region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public uint this[int index]
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


        #region Operators
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator==(uint2 lhs, uint2 rhs) => lhs.x == rhs.x&&lhs.y == rhs.y;
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator!=(uint2 lhs, uint2 rhs) => lhs.x != rhs.x||lhs.y != rhs.y;

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


        #region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint2 lhs, uint2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint2 lhs, uint2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint2 lhs, uint2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint2 lhs, uint2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint2 lhs, uint2 rhs) => new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint2 lhs, uint2 rhs) => new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Min (uint.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint2 lhs, uint2 rhs) => new uint2(uint.Min(lhs.x, rhs.x), uint.Min(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Min (uint.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint2 lhs, uint rhs) => new uint2(uint.Min(lhs.x, rhs), uint.Min(lhs.y, rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Max (uint.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint2 lhs, uint2 rhs) => new uint2(uint.Max(lhs.x, rhs.x), uint.Max(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Max (uint.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint2 lhs, uint rhs) => new uint2(uint.Max(lhs.x, rhs), uint.Max(lhs.y, rhs));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (uint.Clamp(v, min, max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint2 min, uint2 max) => new uint2(uint.Clamp(v.x, min.x, max.x), uint.Clamp(v.y, min.y, max.y));
        
        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static uint2 Mix(uint2 x, uint2 y, bool2 a) => new uint2(a.x ? y.x : x.x, a.y ? y.y : x.y);
        
        /// <summary>
        /// Returns a float2 from component-wise application of UIntBitsToFloat (Unsafe.As&lt;uint, float&gt;(ref v)).
        /// </summary>
        public static float2 UIntBitsToFloat(uint2 v) => new float2(Unsafe.As<uint, float>(ref v.x), Unsafe.As<uint, float>(ref v.y));

        #endregion


        #region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator+(uint2 lhs, uint2 rhs) => new uint2(lhs.x + rhs.x, lhs.y + rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator+(uint2 lhs, uint rhs) => new uint2(lhs.x + rhs, lhs.y + rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint2 operator+(uint lhs, uint2 rhs) => new uint2(lhs + rhs.x, lhs + rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator-(uint2 lhs, uint2 rhs) => new uint2(lhs.x - rhs.x, lhs.y - rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator-(uint2 lhs, uint rhs) => new uint2(lhs.x - rhs, lhs.y - rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint2 operator-(uint lhs, uint2 rhs) => new uint2(lhs - rhs.x, lhs - rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator*(uint2 lhs, uint2 rhs) => new uint2(lhs.x * rhs.x, lhs.y * rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator*(uint2 lhs, uint rhs) => new uint2(lhs.x * rhs, lhs.y * rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint2 operator*(uint lhs, uint2 rhs) => new uint2(lhs * rhs.x, lhs * rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator/(uint2 lhs, uint2 rhs) => new uint2(lhs.x / rhs.x, lhs.y / rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator/(uint2 lhs, uint rhs) => new uint2(lhs.x / rhs, lhs.y / rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint2 operator/(uint lhs, uint2 rhs) => new uint2(lhs / rhs.x, lhs / rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator~ (~v).
        /// </summary>
        public static uint2 operator~(uint2 v) => new uint2(~v.x, ~v.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static uint2 operator%(uint2 lhs, uint2 rhs) => new uint2(lhs.x % rhs.x, lhs.y % rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static uint2 operator%(uint2 lhs, uint rhs) => new uint2(lhs.x % rhs, lhs.y % rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static uint2 operator%(uint lhs, uint2 rhs) => new uint2(lhs % rhs.x, lhs % rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 operator<<(uint2 lhs, uint2 rhs) => new uint2(lhs.x << rhs.x, lhs.y << rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 operator<<(uint2 lhs, uint rhs) => new uint2(lhs.x << rhs, lhs.y << rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 operator>>(uint2 lhs, uint2 rhs) => new uint2(lhs.x >> rhs.x, lhs.y >> rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 operator>>(uint2 lhs, uint rhs) => new uint2(lhs.x >> rhs, lhs.y >> rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator^(uint2 lhs, uint2 rhs) => new uint2(lhs.x ^ rhs.x, lhs.y ^ rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator^(uint2 lhs, uint rhs) => new uint2(lhs.x ^ rhs, lhs.y ^ rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint2 operator^(uint lhs, uint2 rhs) => new uint2(lhs ^ rhs.x, lhs ^ rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator|(uint2 lhs, uint2 rhs) => new uint2(lhs.x | rhs.x, lhs.y | rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator|(uint2 lhs, uint rhs) => new uint2(lhs.x | rhs, lhs.y | rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint2 operator|(uint lhs, uint2 rhs) => new uint2(lhs | rhs.x, lhs | rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator&(uint2 lhs, uint2 rhs) => new uint2(lhs.x & rhs.x, lhs.y & rhs.y);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator&(uint2 lhs, uint rhs) => new uint2(lhs.x & rhs, lhs.y & rhs);
        
        /// <summary>
        /// Returns a uint2 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint2 operator&(uint lhs, uint2 rhs) => new uint2(lhs & rhs.x, lhs & rhs.y);

        #endregion

    }
}
