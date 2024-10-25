using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {
        
        /// <summary>
        /// Returns a float3 from component-wise application of Radians (float.DegreesToRadians(v)).
        /// </summary>
        public static float3 Radians(float3 v) => float3.Radians(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Degrees (float.RadiansToDegrees(v)).
        /// </summary>
        public static float3 Degrees(float3 v) => float3.Degrees(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Sin (float.Sin(v)).
        /// </summary>
        public static float3 Sin(float3 v) => float3.Sin(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Cos (float.Cos(v)).
        /// </summary>
        public static float3 Cos(float3 v) => float3.Cos(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Tan (float.Tan(v)).
        /// </summary>
        public static float3 Tan(float3 v) => float3.Tan(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Asin (float.Asin(v)).
        /// </summary>
        public static float3 Asin(float3 v) => float3.Asin(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Acos (float.Acos(v)).
        /// </summary>
        public static float3 Acos(float3 v) => float3.Acos(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Atan (float.Atan(y / x)).
        /// </summary>
        public static float3 Atan(float3 y, float3 x) => float3.Atan(y, x);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Atan (float.Atan(v)).
        /// </summary>
        public static float3 Atan(float3 v) => float3.Atan(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Sinh (float.Sinh(v)).
        /// </summary>
        public static float3 Sinh(float3 v) => float3.Sinh(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Cosh (float.Cosh(v)).
        /// </summary>
        public static float3 Cosh(float3 v) => float3.Cosh(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Tanh (float.Tanh(v)).
        /// </summary>
        public static float3 Tanh(float3 v) => float3.Tanh(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Asinh (float.Asinh(v)).
        /// </summary>
        public static float3 Asinh(float3 v) => float3.Asinh(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Acosh (float.Acosh(v)).
        /// </summary>
        public static float3 Acosh(float3 v) => float3.Acosh(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Atanh (float.Atanh(v)).
        /// </summary>
        public static float3 Atanh(float3 v) => float3.Atanh(v);
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(float3 v) => float3.Length(v);
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(float3 lhs, float3 rhs) => float3.Distance(lhs, rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static float Dot(float3 lhs, float3 rhs) => float3.Dot(lhs, rhs);
        
        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static float3 Cross(float3 lhs, float3 rhs) => float3.Cross(lhs, rhs);
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static float3 Normalize(float3 v) => float3.Normalize(v);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static float3 FaceForward(float3 N, float3 I, float3 Nref) => float3.FaceForward(N, I, Nref);
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float3 Reflect(float3 I, float3 N) => float3.Reflect(I, N);
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float3 Refract(float3 I, float3 N, float eta) => float3.Refract(I, N, eta);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Pow (float.Pow(lhs, rhs)).
        /// </summary>
        public static float3 Pow(float3 lhs, float3 rhs) => float3.Pow(lhs, rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Exp (float.Exp(v)).
        /// </summary>
        public static float3 Exp(float3 v) => float3.Exp(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Log (float.Log(v)).
        /// </summary>
        public static float3 Log(float3 v) => float3.Log(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Exp2 (float.Exp2(v)).
        /// </summary>
        public static float3 Exp2(float3 v) => float3.Exp2(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Log2 (float.Log2(v)).
        /// </summary>
        public static float3 Log2(float3 v) => float3.Log2(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Sqrt (float.Sqrt(v)).
        /// </summary>
        public static float3 Sqrt(float3 v) => float3.Sqrt(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of InverseSqrt (float.ReciprocalSqrtEstimate(v)).
        /// </summary>
        public static float3 InverseSqrt(float3 v) => float3.InverseSqrt(v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(float3 lhs, float3 rhs) => float3.LesserThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(float3 lhs, float3 rhs) => float3.LesserThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(float3 lhs, float3 rhs) => float3.GreaterThan(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(float3 lhs, float3 rhs) => float3.GreaterThanEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(float3 lhs, float3 rhs) => float3.Equal(lhs, rhs);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(float3 lhs, float3 rhs) => float3.NotEqual(lhs, rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Abs (float.Abs(v)).
        /// </summary>
        public static float3 Abs(float3 v) => float3.Abs(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Sign (float.Sign(v)).
        /// </summary>
        public static float3 Sign(float3 v) => float3.Sign(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Floor (float.Floor(v)).
        /// </summary>
        public static float3 Floor(float3 v) => float3.Floor(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Truncate (float.Truncate(v)).
        /// </summary>
        public static float3 Truncate(float3 v) => float3.Truncate(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Round (float.Round(v)).
        /// </summary>
        public static float3 Round(float3 v) => float3.Round(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of RoundEven (float.Round(v, MidpointRounding.ToEven)).
        /// </summary>
        public static float3 RoundEven(float3 v) => float3.RoundEven(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Ceiling (float.Ceiling(v)).
        /// </summary>
        public static float3 Ceiling(float3 v) => float3.Ceiling(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Fract (v - float.Floor(v)).
        /// </summary>
        public static float3 Fract(float3 v) => float3.Fract(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Mod (lhs - rhs * float.Floor(lhs / rhs)).
        /// </summary>
        public static float3 Mod(float3 lhs, float3 rhs) => float3.Mod(lhs, rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Lerp (float.Lerp(edge0, edge1, v)).
        /// </summary>
        public static float3 Lerp(float3 edge0, float3 edge1, float3 v) => float3.Lerp(edge0, edge1, v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static float3 Step(float3 edge, float3 x) => float3.Step(edge, x);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Smoothstep (float.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static float3 Smoothstep(float3 edge0, float3 edge1, float3 v) => float3.Smoothstep(edge0, edge1, v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (float.IsNaN(v)).
        /// </summary>
        public static bool3 IsNaN(float3 v) => float3.IsNaN(v);
        
        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (float.IsInfinity(v)).
        /// </summary>
        public static bool3 IsInfinity(float3 v) => float3.IsInfinity(v);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Fma (float.FusedMultiplyAdd(a, b, c)).
        /// </summary>
        public static float3 Fma(float3 a, float3 b, float3 c) => float3.Fma(a, b, c);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Min (float.Min(lhs, rhs)).
        /// </summary>
        public static float3 Min(float3 lhs, float3 rhs) => float3.Min(lhs, rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Max (float.Max(lhs, rhs)).
        /// </summary>
        public static float3 Max(float3 lhs, float3 rhs) => float3.Max(lhs, rhs);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (float.Clamp(v, min, max)).
        /// </summary>
        public static float3 Clamp(float3 v, float3 min, float3 max) => float3.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Clamp (float.Clamp(v, min, max)).
        /// </summary>
        public static float3 Clamp(float3 v, float min, float max) => float3.Clamp(v, min, max);
        
        /// <summary>
        /// Returns a float3 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static float3 Mix(float3 x, float3 y, bool3 a) => float3.Mix(x, y, a);
        
        /// <summary>
        /// Returns a int3 from component-wise application of FloatBitsToInt (Unsafe.As&lt;float, int&gt;(ref v)).
        /// </summary>
        public static int3 FloatBitsToInt(float3 v) => float3.FloatBitsToInt(v);
        
        /// <summary>
        /// Returns a uint3 from component-wise application of FloatBitsToUInt (Unsafe.As&lt;float, uint&gt;(ref v)).
        /// </summary>
        public static uint3 FloatBitsToUInt(float3 v) => float3.FloatBitsToUInt(v);
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(float3 v) => v.ToString();

    }
}
