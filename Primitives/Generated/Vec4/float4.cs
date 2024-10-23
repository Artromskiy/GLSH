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
    /// A vector of type float with 4 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct float4
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
        /// w-component
        /// </summary>
        [DataMember]
        public float w;
        
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
        public float4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public float4(float v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public float4(float2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0f;
            this.w = 0f;
        }
        
        /// <summary>
        /// from-vector-and-value constructor (empty fields are zero/false)
        /// </summary>
        public float4(float2 v, float z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = 0f;
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public float4(float2 v, float z, float w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = w;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public float4(float3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = 0f;
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public float4(float3 v, float w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = w;
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public float4(float4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
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
        public static bool operator==(float4 lhs, float4 rhs) => lhs.x == rhs.x&&lhs.y == rhs.y&&lhs.z == rhs.z&&lhs.w == rhs.w;
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator!=(float4 lhs, float4 rhs) => lhs.x != rhs.x||lhs.y != rhs.y||lhs.z != rhs.z||lhs.w != rhs.w;

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
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(float4 v) => float.Sqrt(((v.x*v.x + v.y*v.y) + (v.z*v.z + v.w*v.w)));
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(float4 lhs, float4 rhs) => float4.Length(lhs - rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static float Dot(float4 lhs, float4 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static float4 Normalize(float4 v) => v / float4.Length(v);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static float4 FaceForward(float4 N, float4 I, float4 Nref) => float4.Dot(Nref, I) < 0 ? N : -N;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float4 Reflect(float4 I, float4 N) => I - 2 * float4.Dot(N, I) * N;
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float4 Refract(float4 I, float4 N, float eta)
        {
            var dNI = float4.Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return new float4((float)0);
            return eta * I - (eta * dNI + float.Sqrt(k)) * N;
        }

        #endregion


        #region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a float4 from component-wise application of Radians (float.DegreesToRadians(v)).
        /// </summary>
        public static float4 Radians(float4 v) => new float4(float.DegreesToRadians(v.x), float.DegreesToRadians(v.y), float.DegreesToRadians(v.z), float.DegreesToRadians(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Degrees (float.RadiansToDegrees(v)).
        /// </summary>
        public static float4 Degrees(float4 v) => new float4(float.RadiansToDegrees(v.x), float.RadiansToDegrees(v.y), float.RadiansToDegrees(v.z), float.RadiansToDegrees(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sin (float.Sin(v)).
        /// </summary>
        public static float4 Sin(float4 v) => new float4(float.Sin(v.x), float.Sin(v.y), float.Sin(v.z), float.Sin(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Cos (float.Cos(v)).
        /// </summary>
        public static float4 Cos(float4 v) => new float4(float.Cos(v.x), float.Cos(v.y), float.Cos(v.z), float.Cos(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Tan (float.Tan(v)).
        /// </summary>
        public static float4 Tan(float4 v) => new float4(float.Tan(v.x), float.Tan(v.y), float.Tan(v.z), float.Tan(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Asin (float.Asin(v)).
        /// </summary>
        public static float4 Asin(float4 v) => new float4(float.Asin(v.x), float.Asin(v.y), float.Asin(v.z), float.Asin(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Acos (float.Acos(v)).
        /// </summary>
        public static float4 Acos(float4 v) => new float4(float.Acos(v.x), float.Acos(v.y), float.Acos(v.z), float.Acos(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Atan (float.Atan(y / x)).
        /// </summary>
        public static float4 Atan(float4 y, float4 x) => new float4(float.Atan(y.x / x.x), float.Atan(y.y / x.y), float.Atan(y.z / x.z), float.Atan(y.w / x.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Atan (float.Atan(v)).
        /// </summary>
        public static float4 Atan(float4 v) => new float4(float.Atan(v.x), float.Atan(v.y), float.Atan(v.z), float.Atan(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sinh (float.Sinh(v)).
        /// </summary>
        public static float4 Sinh(float4 v) => new float4(float.Sinh(v.x), float.Sinh(v.y), float.Sinh(v.z), float.Sinh(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Cosh (float.Cosh(v)).
        /// </summary>
        public static float4 Cosh(float4 v) => new float4(float.Cosh(v.x), float.Cosh(v.y), float.Cosh(v.z), float.Cosh(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Tanh (float.Tanh(v)).
        /// </summary>
        public static float4 Tanh(float4 v) => new float4(float.Tanh(v.x), float.Tanh(v.y), float.Tanh(v.z), float.Tanh(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Asinh (float.Asinh(v)).
        /// </summary>
        public static float4 Asinh(float4 v) => new float4(float.Asinh(v.x), float.Asinh(v.y), float.Asinh(v.z), float.Asinh(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Acosh (float.Acosh(v)).
        /// </summary>
        public static float4 Acosh(float4 v) => new float4(float.Acosh(v.x), float.Acosh(v.y), float.Acosh(v.z), float.Acosh(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Atanh (float.Atanh(v)).
        /// </summary>
        public static float4 Atanh(float4 v) => new float4(float.Atanh(v.x), float.Atanh(v.y), float.Atanh(v.z), float.Atanh(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Pow (float.Pow(lhs, rhs)).
        /// </summary>
        public static float4 Pow(float4 lhs, float4 rhs) => new float4(float.Pow(lhs.x, rhs.x), float.Pow(lhs.y, rhs.y), float.Pow(lhs.z, rhs.z), float.Pow(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Exp (float.Exp(v)).
        /// </summary>
        public static float4 Exp(float4 v) => new float4(float.Exp(v.x), float.Exp(v.y), float.Exp(v.z), float.Exp(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Log (float.Log(v)).
        /// </summary>
        public static float4 Log(float4 v) => new float4(float.Log(v.x), float.Log(v.y), float.Log(v.z), float.Log(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Exp2 (float.Exp2(v)).
        /// </summary>
        public static float4 Exp2(float4 v) => new float4(float.Exp2(v.x), float.Exp2(v.y), float.Exp2(v.z), float.Exp2(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Log2 (float.Log2(v)).
        /// </summary>
        public static float4 Log2(float4 v) => new float4(float.Log2(v.x), float.Log2(v.y), float.Log2(v.z), float.Log2(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sqrt (float.Sqrt(v)).
        /// </summary>
        public static float4 Sqrt(float4 v) => new float4(float.Sqrt(v.x), float.Sqrt(v.y), float.Sqrt(v.z), float.Sqrt(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of InverseSqrt (float.ReciprocalSqrtEstimate(v)).
        /// </summary>
        public static float4 InverseSqrt(float4 v) => new float4(float.ReciprocalSqrtEstimate(v.x), float.ReciprocalSqrtEstimate(v.y), float.ReciprocalSqrtEstimate(v.z), float.ReciprocalSqrtEstimate(v.w));
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(float4 lhs, float4 rhs) => new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(float4 lhs, float4 rhs) => new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(float4 lhs, float4 rhs) => new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(float4 lhs, float4 rhs) => new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(float4 lhs, float4 rhs) => new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(float4 lhs, float4 rhs) => new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Abs (float.Abs(v)).
        /// </summary>
        public static float4 Abs(float4 v) => new float4(float.Abs(v.x), float.Abs(v.y), float.Abs(v.z), float.Abs(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Sign (float.Sign(v)).
        /// </summary>
        public static float4 Sign(float4 v) => new float4(float.Sign(v.x), float.Sign(v.y), float.Sign(v.z), float.Sign(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Floor (float.Floor(v)).
        /// </summary>
        public static float4 Floor(float4 v) => new float4(float.Floor(v.x), float.Floor(v.y), float.Floor(v.z), float.Floor(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Truncate (float.Truncate(v)).
        /// </summary>
        public static float4 Truncate(float4 v) => new float4(float.Truncate(v.x), float.Truncate(v.y), float.Truncate(v.z), float.Truncate(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Round (float.Round(v)).
        /// </summary>
        public static float4 Round(float4 v) => new float4(float.Round(v.x), float.Round(v.y), float.Round(v.z), float.Round(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of RoundEven (float.Round(v, MidpointRounding.ToEven)).
        /// </summary>
        public static float4 RoundEven(float4 v) => new float4(float.Round(v.x, MidpointRounding.ToEven), float.Round(v.y, MidpointRounding.ToEven), float.Round(v.z, MidpointRounding.ToEven), float.Round(v.w, MidpointRounding.ToEven));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Ceiling (float.Ceiling(v)).
        /// </summary>
        public static float4 Ceiling(float4 v) => new float4(float.Ceiling(v.x), float.Ceiling(v.y), float.Ceiling(v.z), float.Ceiling(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Fract (v - float.Floor(v)).
        /// </summary>
        public static float4 Fract(float4 v) => new float4(v.x - float.Floor(v.x), v.y - float.Floor(v.y), v.z - float.Floor(v.z), v.w - float.Floor(v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Mod (lhs - rhs * float.Floor(lhs / rhs)).
        /// </summary>
        public static float4 Mod(float4 lhs, float4 rhs) => new float4(lhs.x - rhs.x * float.Floor(lhs.x / rhs.x), lhs.y - rhs.y * float.Floor(lhs.y / rhs.y), lhs.z - rhs.z * float.Floor(lhs.z / rhs.z), lhs.w - rhs.w * float.Floor(lhs.w / rhs.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Mod (lhs - rhs * float.Floor(lhs / rhs)).
        /// </summary>
        public static float4 Mod(float4 lhs, float rhs) => new float4(lhs.x - rhs * float.Floor(lhs.x / rhs), lhs.y - rhs * float.Floor(lhs.y / rhs), lhs.z - rhs * float.Floor(lhs.z / rhs), lhs.w - rhs * float.Floor(lhs.w / rhs));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Lerp (float.Lerp(edge0, edge1, v)).
        /// </summary>
        public static float4 Lerp(float4 edge0, float4 edge1, float4 v) => new float4(float.Lerp(edge0.x, edge1.x, v.x), float.Lerp(edge0.y, edge1.y, v.y), float.Lerp(edge0.z, edge1.z, v.z), float.Lerp(edge0.w, edge1.w, v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Lerp (float.Lerp(edge0, edge1, v)).
        /// </summary>
        public static float4 Lerp(float4 edge0, float4 edge1, float v) => new float4(float.Lerp(edge0.x, edge1.x, v), float.Lerp(edge0.y, edge1.y, v), float.Lerp(edge0.z, edge1.z, v), float.Lerp(edge0.w, edge1.w, v));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static float4 Step(float4 edge, float4 x) => new float4(x.x < edge.x ? 0 : 1, x.y < edge.y ? 0 : 1, x.z < edge.z ? 0 : 1, x.w < edge.w ? 0 : 1);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static float4 Step(float edge, float4 x) => new float4(x.x < edge ? 0 : 1, x.y < edge ? 0 : 1, x.z < edge ? 0 : 1, x.w < edge ? 0 : 1);
        
        /// <summary>
        /// Returns a float4 from component-wise application of Smoothstep (float.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static float4 Smoothstep(float4 edge0, float4 edge1, float4 v) => new float4(float.Clamp((v.x - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v.y - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v.z - edge0.z) / (edge1.z - edge0.z), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v.w - edge0.w) / (edge1.w - edge0.w), 0, 1).HermiteInterpolationOrder3());
        
        /// <summary>
        /// Returns a float4 from component-wise application of Smoothstep (float.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static float4 Smoothstep(float4 edge0, float4 edge1, float v) => new float4(float.Clamp((v - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v - edge0.z) / (edge1.z - edge0.z), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v - edge0.w) / (edge1.w - edge0.w), 0, 1).HermiteInterpolationOrder3());
        
        /// <summary>
        /// Returns a float4 from component-wise application of Min (float.Min(lhs, rhs)).
        /// </summary>
        public static float4 Min(float4 lhs, float4 rhs) => new float4(float.Min(lhs.x, rhs.x), float.Min(lhs.y, rhs.y), float.Min(lhs.z, rhs.z), float.Min(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Min (float.Min(lhs, rhs)).
        /// </summary>
        public static float4 Min(float4 lhs, float rhs) => new float4(float.Min(lhs.x, rhs), float.Min(lhs.y, rhs), float.Min(lhs.z, rhs), float.Min(lhs.w, rhs));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Max (float.Max(lhs, rhs)).
        /// </summary>
        public static float4 Max(float4 lhs, float4 rhs) => new float4(float.Max(lhs.x, rhs.x), float.Max(lhs.y, rhs.y), float.Max(lhs.z, rhs.z), float.Max(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Max (float.Max(lhs, rhs)).
        /// </summary>
        public static float4 Max(float4 lhs, float rhs) => new float4(float.Max(lhs.x, rhs), float.Max(lhs.y, rhs), float.Max(lhs.z, rhs), float.Max(lhs.w, rhs));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Clamp (float.Clamp(v, min, max)).
        /// </summary>
        public static float4 Clamp(float4 v, float4 min, float4 max) => new float4(float.Clamp(v.x, min.x, max.x), float.Clamp(v.y, min.y, max.y), float.Clamp(v.z, min.z, max.z), float.Clamp(v.w, min.w, max.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static float4 Mix(float4 x, float4 y, bool4 a) => new float4(a.x ? y.x : x.x, a.y ? y.y : x.y, a.z ? y.z : x.z, a.w ? y.w : x.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsNaN (float.IsNaN(v)).
        /// </summary>
        public static bool4 IsNaN(float4 v) => new bool4(float.IsNaN(v.x), float.IsNaN(v.y), float.IsNaN(v.z), float.IsNaN(v.w));
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsInfinity (float.IsInfinity(v)).
        /// </summary>
        public static bool4 IsInfinity(float4 v) => new bool4(float.IsInfinity(v.x), float.IsInfinity(v.y), float.IsInfinity(v.z), float.IsInfinity(v.w));
        
        /// <summary>
        /// Returns a int4 from component-wise application of FloatBitsToInt (Unsafe.As&lt;float, int&gt;(ref v)).
        /// </summary>
        public static int4 FloatBitsToInt(float4 v) => new int4(Unsafe.As<float, int>(ref v.x), Unsafe.As<float, int>(ref v.y), Unsafe.As<float, int>(ref v.z), Unsafe.As<float, int>(ref v.w));
        
        /// <summary>
        /// Returns a uint4 from component-wise application of FloatBitsToUInt (Unsafe.As&lt;float, uint&gt;(ref v)).
        /// </summary>
        public static uint4 FloatBitsToUInt(float4 v) => new uint4(Unsafe.As<float, uint>(ref v.x), Unsafe.As<float, uint>(ref v.y), Unsafe.As<float, uint>(ref v.z), Unsafe.As<float, uint>(ref v.w));
        
        /// <summary>
        /// Returns a float4 from component-wise application of Fma (float.FusedMultiplyAdd(a, b, c)).
        /// </summary>
        public static float4 Fma(float4 a, float4 b, float4 c) => new float4(float.FusedMultiplyAdd(a.x, b.x, c.x), float.FusedMultiplyAdd(a.y, b.y, c.y), float.FusedMultiplyAdd(a.z, b.z, c.z), float.FusedMultiplyAdd(a.w, b.w, c.w));

        #endregion


        #region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator- (-v).
        /// </summary>
        public static float4 operator-(float4 v) => new float4(-v.x, -v.y, -v.z, -v.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float4 operator+(float4 lhs, float4 rhs) => new float4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float4 operator+(float4 lhs, float rhs) => new float4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float4 operator+(float lhs, float4 rhs) => new float4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float4 operator-(float4 lhs, float4 rhs) => new float4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float4 operator-(float4 lhs, float rhs) => new float4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float4 operator-(float lhs, float4 rhs) => new float4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float4 operator*(float4 lhs, float4 rhs) => new float4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float4 operator*(float4 lhs, float rhs) => new float4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float4 operator*(float lhs, float4 rhs) => new float4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float4 operator/(float4 lhs, float4 rhs) => new float4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float4 operator/(float4 lhs, float rhs) => new float4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        
        /// <summary>
        /// Returns a float4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float4 operator/(float lhs, float4 rhs) => new float4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);

        #endregion

    }
}
