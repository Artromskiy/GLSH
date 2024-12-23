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
    /// A vector of type uint with 4 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct uint4
    {

        #region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        public uint x;
        
        /// <summary>
        /// y-component
        /// </summary>
        public uint y;
        
        /// <summary>
        /// z-component
        /// </summary>
        public uint z;
        
        /// <summary>
        /// w-component
        /// </summary>
        public uint w;
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public const int Count = 4;

        #endregion


        #region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public uint4(uint x, uint y, uint z, uint w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public uint4(uint v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public uint4(uint2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0u;
            this.w = 0u;
        }
        
        /// <summary>
        /// from-vector-and-value constructor (empty fields are zero/false)
        /// </summary>
        public uint4(uint2 v, uint z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = 0u;
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public uint4(uint2 v, uint z, uint w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = w;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public uint4(uint3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = 0u;
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public uint4(uint3 v, uint w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = w;
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public uint4(uint4 v)
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
        public static implicit operator float4(uint4 v) => new float4((float)v.x, (float)v.y, (float)v.z, (float)v.w);
        
        /// <summary>
        /// Implicitly converts this to a double4.
        /// </summary>
        public static implicit operator double4(uint4 v) => new double4((double)v.x, (double)v.y, (double)v.z, (double)v.w);

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


        #region Properties
        
        /// <summary>
        /// Gets or sets the specified subset of components.
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
        /// Gets or sets the specified subset of components.
        /// </summary>
        public uint2 xz
        {
            get
            {
                return new uint2(x, z);
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
        public uint2 yz
        {
            get
            {
                return new uint2(y, z);
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
        public uint3 xyz
        {
            get
            {
                return new uint3(x, y, z);
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
        public uint2 xw
        {
            get
            {
                return new uint2(x, w);
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
        public uint2 yw
        {
            get
            {
                return new uint2(y, w);
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
        public uint3 xyw
        {
            get
            {
                return new uint3(x, y, w);
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
        public uint2 zw
        {
            get
            {
                return new uint2(z, w);
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
        public uint3 xzw
        {
            get
            {
                return new uint3(x, z, w);
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
        public uint3 yzw
        {
            get
            {
                return new uint3(y, z, w);
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
        public uint4 xyzw
        {
            get
            {
                return new uint4(x, y, z, w);
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
        /// Gets or sets the specified subset of components.
        /// </summary>
        public uint2 rb
        {
            get
            {
                return new uint2(x, z);
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
        public uint2 gb
        {
            get
            {
                return new uint2(y, z);
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
        public uint3 rgb
        {
            get
            {
                return new uint3(x, y, z);
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
        public uint2 ra
        {
            get
            {
                return new uint2(x, w);
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
        public uint2 ga
        {
            get
            {
                return new uint2(y, w);
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
        public uint3 rga
        {
            get
            {
                return new uint3(x, y, w);
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
        public uint2 ba
        {
            get
            {
                return new uint2(z, w);
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
        public uint3 rba
        {
            get
            {
                return new uint3(x, z, w);
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
        public uint3 gba
        {
            get
            {
                return new uint3(y, z, w);
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
        public uint4 rgba
        {
            get
            {
                return new uint4(x, y, z, w);
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
        /// Gets or sets the specified RGBA component.
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
        /// Gets or sets the specified RGBA component.
        /// </summary>
        public uint b
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
        public uint a
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
        public static bool operator==(uint4 lhs, uint4 rhs) => lhs.x == rhs.x&&lhs.y == rhs.y&&lhs.z == rhs.z&&lhs.w == rhs.w;
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator!=(uint4 lhs, uint4 rhs) => lhs.x != rhs.x||lhs.y != rhs.y||lhs.z != rhs.z||lhs.w != rhs.w;

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
        /// Returns a uint4 from component-wise application of Clamp (uint.Clamp(v, min, max)).
        /// </summary>
        public static uint4 Clamp(uint4 v, uint min, uint max) => new uint4(uint.Clamp(v.x, min, max), uint.Clamp(v.y, min, max), uint.Clamp(v.z, min, max), uint.Clamp(v.w, min, max));

        #endregion


        #region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(uint4 lhs, uint4 rhs) => new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(uint4 lhs, uint4 rhs) => new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(uint4 lhs, uint4 rhs) => new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(uint4 lhs, uint4 rhs) => new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(uint4 lhs, uint4 rhs) => new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(uint4 lhs, uint4 rhs) => new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Min (uint.Min(lhs, rhs)).
        /// </summary>
        public static uint4 Min(uint4 lhs, uint4 rhs) => new uint4(uint.Min(lhs.x, rhs.x), uint.Min(lhs.y, rhs.y), uint.Min(lhs.z, rhs.z), uint.Min(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Min (uint.Min(lhs, rhs)).
        /// </summary>
        public static uint4 Min(uint4 lhs, uint rhs) => new uint4(uint.Min(lhs.x, rhs), uint.Min(lhs.y, rhs), uint.Min(lhs.z, rhs), uint.Min(lhs.w, rhs));
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Max (uint.Max(lhs, rhs)).
        /// </summary>
        public static uint4 Max(uint4 lhs, uint4 rhs) => new uint4(uint.Max(lhs.x, rhs.x), uint.Max(lhs.y, rhs.y), uint.Max(lhs.z, rhs.z), uint.Max(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Max (uint.Max(lhs, rhs)).
        /// </summary>
        public static uint4 Max(uint4 lhs, uint rhs) => new uint4(uint.Max(lhs.x, rhs), uint.Max(lhs.y, rhs), uint.Max(lhs.z, rhs), uint.Max(lhs.w, rhs));
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Clamp (uint.Clamp(v, min, max)).
        /// </summary>
        public static uint4 Clamp(uint4 v, uint4 min, uint4 max) => new uint4(uint.Clamp(v.x, min.x, max.x), uint.Clamp(v.y, min.y, max.y), uint.Clamp(v.z, min.z, max.z), uint.Clamp(v.w, min.w, max.w));
        
        /// <summary>
        /// Returns a uint4 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static uint4 Mix(uint4 x, uint4 y, bool4 a) => new uint4(a.x ? y.x : x.x, a.y ? y.y : x.y, a.z ? y.z : x.z, a.w ? y.w : x.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of UIntBitsToFloat (Unsafe.As&lt;uint, float&gt;(ref v)).
        /// </summary>
        public static float4 UIntBitsToFloat(uint4 v) => new float4(Unsafe.As<uint, float>(ref v.x), Unsafe.As<uint, float>(ref v.y), Unsafe.As<uint, float>(ref v.z), Unsafe.As<uint, float>(ref v.w));

        #endregion


        #region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint4 operator+(uint4 lhs, uint4 rhs) => new uint4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint4 operator+(uint4 lhs, uint rhs) => new uint4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static uint4 operator+(uint lhs, uint4 rhs) => new uint4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint4 operator-(uint4 lhs, uint4 rhs) => new uint4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint4 operator-(uint4 lhs, uint rhs) => new uint4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static uint4 operator-(uint lhs, uint4 rhs) => new uint4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint4 operator*(uint4 lhs, uint4 rhs) => new uint4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint4 operator*(uint4 lhs, uint rhs) => new uint4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static uint4 operator*(uint lhs, uint4 rhs) => new uint4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint4 operator/(uint4 lhs, uint4 rhs) => new uint4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint4 operator/(uint4 lhs, uint rhs) => new uint4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static uint4 operator/(uint lhs, uint4 rhs) => new uint4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator~ (~v).
        /// </summary>
        public static uint4 operator~(uint4 v) => new uint4(~v.x, ~v.y, ~v.z, ~v.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static uint4 operator%(uint4 lhs, uint4 rhs) => new uint4(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z, lhs.w % rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static uint4 operator%(uint4 lhs, uint rhs) => new uint4(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs, lhs.w % rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator% (lhs % rhs).
        /// </summary>
        public static uint4 operator%(uint lhs, uint4 rhs) => new uint4(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z, lhs % rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint4 operator^(uint4 lhs, uint4 rhs) => new uint4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint4 operator^(uint4 lhs, uint rhs) => new uint4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator^ (lhs ^ rhs).
        /// </summary>
        public static uint4 operator^(uint lhs, uint4 rhs) => new uint4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint4 operator|(uint4 lhs, uint4 rhs) => new uint4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint4 operator|(uint4 lhs, uint rhs) => new uint4(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs, lhs.w | rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator| (lhs | rhs).
        /// </summary>
        public static uint4 operator|(uint lhs, uint4 rhs) => new uint4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint4 operator&(uint4 lhs, uint4 rhs) => new uint4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint4 operator&(uint4 lhs, uint rhs) => new uint4(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs, lhs.w & rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator&amp; (lhs &amp; rhs).
        /// </summary>
        public static uint4 operator&(uint lhs, uint4 rhs) => new uint4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; (int)rhs).
        /// </summary>
        public static uint4 operator<<(uint4 lhs, uint4 rhs) => new uint4(lhs.x << (int)rhs.x, lhs.y << (int)rhs.y, lhs.z << (int)rhs.z, lhs.w << (int)rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator&lt;&lt; (lhs &lt;&lt; (int)rhs).
        /// </summary>
        public static uint4 operator<<(uint4 lhs, uint rhs) => new uint4(lhs.x << (int)rhs, lhs.y << (int)rhs, lhs.z << (int)rhs, lhs.w << (int)rhs);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; (int)rhs).
        /// </summary>
        public static uint4 operator>>(uint4 lhs, uint4 rhs) => new uint4(lhs.x >> (int)rhs.x, lhs.y >> (int)rhs.y, lhs.z >> (int)rhs.z, lhs.w >> (int)rhs.w);
        
        /// <summary>
        /// Returns a uint4 from component-wise application of operator&gt;&gt; (lhs &gt;&gt; (int)rhs).
        /// </summary>
        public static uint4 operator>>(uint4 lhs, uint rhs) => new uint4(lhs.x >> (int)rhs, lhs.y >> (int)rhs, lhs.z >> (int)rhs, lhs.w >> (int)rhs);

        #endregion

    }
}
