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


        #region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public float this[int index]
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
        public static bool operator==(float3 lhs, float3 rhs) => lhs.x == rhs.x&&lhs.y == rhs.y&&lhs.z == rhs.z;
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator!=(float3 lhs, float3 rhs) => lhs.x != rhs.x||lhs.y != rhs.y||lhs.z != rhs.z;

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
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(float3 v) => float.Sqrt(((v.x*v.x + v.y*v.y) + v.z*v.z));
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(float3 lhs, float3 rhs) => float3.Length(lhs - rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static float Dot(float3 lhs, float3 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + lhs.z * rhs.z);
        
        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static float3 Cross(float3 lhs, float3 rhs) => new float3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static float3 Normalize(float3 v) => v / float3.Length(v);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static float3 FaceForward(float3 N, float3 I, float3 Nref) => float3.Dot(Nref, I) < 0 ? N : -N;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float3 Reflect(float3 I, float3 N) => I - 2 * float3.Dot(N, I) * N;
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float3 Refract(float3 I, float3 N, float eta)
        {
            var dNI = float3.Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return new float3((float)0);
            return eta * I - (eta * dNI + float.Sqrt(k)) * N;
        }

        #endregion


        #region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a float3 from component-wise application of Radians (float.DegreesToRadians(v)).
        /// </summary>
        public static float3 Radians(float3 v) => new float3(float.DegreesToRadians(v.x), float.DegreesToRadians(v.y), float.DegreesToRadians(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Degrees (float.RadiansToDegrees(v)).
        /// </summary>
        public static float3 Degrees(float3 v) => new float3(float.RadiansToDegrees(v.x), float.RadiansToDegrees(v.y), float.RadiansToDegrees(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Sin (float.Sin(v)).
        /// </summary>
        public static float3 Sin(float3 v) => new float3(float.Sin(v.x), float.Sin(v.y), float.Sin(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Cos (float.Cos(v)).
        /// </summary>
        public static float3 Cos(float3 v) => new float3(float.Cos(v.x), float.Cos(v.y), float.Cos(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Tan (float.Tan(v)).
        /// </summary>
        public static float3 Tan(float3 v) => new float3(float.Tan(v.x), float.Tan(v.y), float.Tan(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Asin (float.Asin(v)).
        /// </summary>
        public static float3 Asin(float3 v) => new float3(float.Asin(v.x), float.Asin(v.y), float.Asin(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Acos (float.Acos(v)).
        /// </summary>
        public static float3 Acos(float3 v) => new float3(float.Acos(v.x), float.Acos(v.y), float.Acos(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Atan (float.Atan(y / x)).
        /// </summary>
        public static float3 Atan(float3 y, float3 x) => new float3(float.Atan(y.x / x.x), float.Atan(y.y / x.y), float.Atan(y.z / x.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Atan (float.Atan(v)).
        /// </summary>
        public static float3 Atan(float3 v) => new float3(float.Atan(v.x), float.Atan(v.y), float.Atan(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Sinh (float.Sinh(v)).
        /// </summary>
        public static float3 Sinh(float3 v) => new float3(float.Sinh(v.x), float.Sinh(v.y), float.Sinh(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Cosh (float.Cosh(v)).
        /// </summary>
        public static float3 Cosh(float3 v) => new float3(float.Cosh(v.x), float.Cosh(v.y), float.Cosh(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Tanh (float.Tanh(v)).
        /// </summary>
        public static float3 Tanh(float3 v) => new float3(float.Tanh(v.x), float.Tanh(v.y), float.Tanh(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Asinh (float.Asinh(v)).
        /// </summary>
        public static float3 Asinh(float3 v) => new float3(float.Asinh(v.x), float.Asinh(v.y), float.Asinh(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Acosh (float.Acosh(v)).
        /// </summary>
        public static float3 Acosh(float3 v) => new float3(float.Acosh(v.x), float.Acosh(v.y), float.Acosh(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Atanh (float.Atanh(v)).
        /// </summary>
        public static float3 Atanh(float3 v) => new float3(float.Atanh(v.x), float.Atanh(v.y), float.Atanh(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Pow (float.Pow(lhs, rhs)).
        /// </summary>
        public static float3 Pow(float3 lhs, float3 rhs) => new float3(float.Pow(lhs.x, rhs.x), float.Pow(lhs.y, rhs.y), float.Pow(lhs.z, rhs.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Exp (float.Exp(v)).
        /// </summary>
        public static float3 Exp(float3 v) => new float3(float.Exp(v.x), float.Exp(v.y), float.Exp(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Log (float.Log(v)).
        /// </summary>
        public static float3 Log(float3 v) => new float3(float.Log(v.x), float.Log(v.y), float.Log(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Exp2 (float.Exp2(v)).
        /// </summary>
        public static float3 Exp2(float3 v) => new float3(float.Exp2(v.x), float.Exp2(v.y), float.Exp2(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Log2 (float.Log2(v)).
        /// </summary>
        public static float3 Log2(float3 v) => new float3(float.Log2(v.x), float.Log2(v.y), float.Log2(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Sqrt (float.Sqrt(v)).
        /// </summary>
        public static float3 Sqrt(float3 v) => new float3(float.Sqrt(v.x), float.Sqrt(v.y), float.Sqrt(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of InverseSqrt (float.ReciprocalSqrtEstimate(v)).
        /// </summary>
        public static float3 InverseSqrt(float3 v) => new float3(float.ReciprocalSqrtEstimate(v.x), float.ReciprocalSqrtEstimate(v.y), float.ReciprocalSqrtEstimate(v.z));
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(float3 lhs, float3 rhs) => new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(float3 lhs, float3 rhs) => new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(float3 lhs, float3 rhs) => new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(float3 lhs, float3 rhs) => new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(float3 lhs, float3 rhs) => new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(float3 lhs, float3 rhs) => new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Abs (float.Abs(v)).
        /// </summary>
        public static float3 Abs(float3 v) => new float3(float.Abs(v.x), float.Abs(v.y), float.Abs(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Sign (float.Sign(v)).
        /// </summary>
        public static float3 Sign(float3 v) => new float3(float.Sign(v.x), float.Sign(v.y), float.Sign(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Floor (float.Floor(v)).
        /// </summary>
        public static float3 Floor(float3 v) => new float3(float.Floor(v.x), float.Floor(v.y), float.Floor(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Truncate (float.Truncate(v)).
        /// </summary>
        public static float3 Truncate(float3 v) => new float3(float.Truncate(v.x), float.Truncate(v.y), float.Truncate(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Round (float.Round(v)).
        /// </summary>
        public static float3 Round(float3 v) => new float3(float.Round(v.x), float.Round(v.y), float.Round(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of RoundEven (float.Round(v, MidpointRounding.ToEven)).
        /// </summary>
        public static float3 RoundEven(float3 v) => new float3(float.Round(v.x, MidpointRounding.ToEven), float.Round(v.y, MidpointRounding.ToEven), float.Round(v.z, MidpointRounding.ToEven));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Ceiling (float.Ceiling(v)).
        /// </summary>
        public static float3 Ceiling(float3 v) => new float3(float.Ceiling(v.x), float.Ceiling(v.y), float.Ceiling(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Fract (v - float.Floor(v)).
        /// </summary>
        public static float3 Fract(float3 v) => new float3(v.x - float.Floor(v.x), v.y - float.Floor(v.y), v.z - float.Floor(v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Mod (lhs - rhs * float.Floor(lhs / rhs)).
        /// </summary>
        public static float3 Mod(float3 lhs, float3 rhs) => new float3(lhs.x - rhs.x * float.Floor(lhs.x / rhs.x), lhs.y - rhs.y * float.Floor(lhs.y / rhs.y), lhs.z - rhs.z * float.Floor(lhs.z / rhs.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Mod (lhs - rhs * float.Floor(lhs / rhs)).
        /// </summary>
        public static float3 Mod(float3 lhs, float rhs) => new float3(lhs.x - rhs * float.Floor(lhs.x / rhs), lhs.y - rhs * float.Floor(lhs.y / rhs), lhs.z - rhs * float.Floor(lhs.z / rhs));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (float.Lerp(edge0, edge1, v)).
        /// </summary>
        public static float3 Lerp(float3 edge0, float3 edge1, float3 v) => new float3(float.Lerp(edge0.x, edge1.x, v.x), float.Lerp(edge0.y, edge1.y, v.y), float.Lerp(edge0.z, edge1.z, v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (float.Lerp(edge0, edge1, v)).
        /// </summary>
        public static float3 Lerp(float3 edge0, float3 edge1, float v) => new float3(float.Lerp(edge0.x, edge1.x, v), float.Lerp(edge0.y, edge1.y, v), float.Lerp(edge0.z, edge1.z, v));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static float3 Step(float3 edge, float3 x) => new float3(x.x < edge.x ? 0 : 1, x.y < edge.y ? 0 : 1, x.z < edge.z ? 0 : 1);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static float3 Step(float edge, float3 x) => new float3(x.x < edge ? 0 : 1, x.y < edge ? 0 : 1, x.z < edge ? 0 : 1);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (float.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float3 edge0, float3 edge1, float3 v) => new float3(float.Clamp((v.x - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v.y - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v.z - edge0.z) / (edge1.z - edge0.z), 0, 1).HermiteInterpolationOrder3());
        
        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (float.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float3 edge0, float3 edge1, float v) => new float3(float.Clamp((v - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v - edge0.z) / (edge1.z - edge0.z), 0, 1).HermiteInterpolationOrder3());
        
        /// <summary>
        /// Returns a float3 from component-wise application of Min (float.Min(lhs, rhs)).
        /// </summary>
        public static float3 Min(float3 lhs, float3 rhs) => new float3(float.Min(lhs.x, rhs.x), float.Min(lhs.y, rhs.y), float.Min(lhs.z, rhs.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Min (float.Min(lhs, rhs)).
        /// </summary>
        public static float3 Min(float3 lhs, float rhs) => new float3(float.Min(lhs.x, rhs), float.Min(lhs.y, rhs), float.Min(lhs.z, rhs));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Max (float.Max(lhs, rhs)).
        /// </summary>
        public static float3 Max(float3 lhs, float3 rhs) => new float3(float.Max(lhs.x, rhs.x), float.Max(lhs.y, rhs.y), float.Max(lhs.z, rhs.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Max (float.Max(lhs, rhs)).
        /// </summary>
        public static float3 Max(float3 lhs, float rhs) => new float3(float.Max(lhs.x, rhs), float.Max(lhs.y, rhs), float.Max(lhs.z, rhs));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (float.Clamp(v, min, max)).
        /// </summary>
        public static float3 Clamp(float3 v, float3 min, float3 max) => new float3(float.Clamp(v.x, min.x, max.x), float.Clamp(v.y, min.y, max.y), float.Clamp(v.z, min.z, max.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static float3 Mix(float3 x, float3 y, bool3 a) => new float3(a.x ? y.x : x.x, a.y ? y.y : x.y, a.z ? y.z : x.z);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (float.IsNaN(v)).
        /// </summary>
        public static bool3 IsNaN(float3 v) => new bool3(float.IsNaN(v.x), float.IsNaN(v.y), float.IsNaN(v.z));
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (float.IsInfinity(v)).
        /// </summary>
        public static bool3 IsInfinity(float3 v) => new bool3(float.IsInfinity(v.x), float.IsInfinity(v.y), float.IsInfinity(v.z));
        
        /// <summary>
        /// Returns a int3 from component-wise application of FloatBitsToInt (Unsafe.As&lt;float, int&gt;(ref v)).
        /// </summary>
        public static int3 FloatBitsToInt(float3 v) => new int3(Unsafe.As<float, int>(ref v.x), Unsafe.As<float, int>(ref v.y), Unsafe.As<float, int>(ref v.z));
        
        /// <summary>
        /// Returns a uint3 from component-wise application of FloatBitsToUInt (Unsafe.As&lt;float, uint&gt;(ref v)).
        /// </summary>
        public static uint3 FloatBitsToUInt(float3 v) => new uint3(Unsafe.As<float, uint>(ref v.x), Unsafe.As<float, uint>(ref v.y), Unsafe.As<float, uint>(ref v.z));
        
        /// <summary>
        /// Returns a float3 from component-wise application of Fma (float.FusedMultiplyAdd(a, b, c)).
        /// </summary>
        public static float3 Fma(float3 a, float3 b, float3 c) => new float3(float.FusedMultiplyAdd(a.x, b.x, c.x), float.FusedMultiplyAdd(a.y, b.y, c.y), float.FusedMultiplyAdd(a.z, b.z, c.z));

        #endregion


        #region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator- (-v).
        /// </summary>
        public static float3 operator-(float3 v) => new float3(-v.x, -v.y, -v.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float3 operator+(float3 lhs, float3 rhs) => new float3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float3 operator+(float3 lhs, float rhs) => new float3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float3 operator+(float lhs, float3 rhs) => new float3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float3 operator-(float3 lhs, float3 rhs) => new float3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float3 operator-(float3 lhs, float rhs) => new float3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float3 operator-(float lhs, float3 rhs) => new float3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float3 operator*(float3 lhs, float3 rhs) => new float3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float3 operator*(float3 lhs, float rhs) => new float3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float3 operator*(float lhs, float3 rhs) => new float3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float3 operator/(float3 lhs, float3 rhs) => new float3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float3 operator/(float3 lhs, float rhs) => new float3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float3 operator/(float lhs, float3 rhs) => new float3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);

        #endregion

    }
}
