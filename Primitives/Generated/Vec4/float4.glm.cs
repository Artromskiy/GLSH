using GLSH.Swizzle;

// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {

        /// <summary>
        /// Returns an object that can be used for arbitrary swizzling (e.g. swizzle.zy)
        /// </summary>
        public static swizzle_vec4 swizzle(float4 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(float4 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public static int Count(float4 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(float4 v, float4 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(float4 v) => v.GetHashCode();

        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        public static bool ApproxEqual(float4 lhs, float4 rhs, float eps = 0.1f) => float4.ApproxEqual(lhs, rhs, eps);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(float4 lhs, float4 rhs) => float4.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(float4 lhs, float4 rhs) => float4.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(float4 lhs, float4 rhs) => float4.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(float4 lhs, float4 rhs) => float4.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(float4 lhs, float4 rhs) => float4.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(float4 lhs, float4 rhs) => float4.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsInfinity (float.IsInfinity(v)).
        /// </summary>
        public static bool4 IsInfinity(float4 v) => float4.IsInfinity(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsFinite (!float.IsNaN(v) &amp;&amp; !float.IsInfinity(v)).
        /// </summary>
        public static bool4 IsFinite(float4 v) => float4.IsFinite(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsNaN (float.IsNaN(v)).
        /// </summary>
        public static bool4 IsNaN(float4 v) => float4.IsNaN(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsNegativeInfinity (float.IsNegativeInfinity(v)).
        /// </summary>
        public static bool4 IsNegativeInfinity(float4 v) => float4.IsNegativeInfinity(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsPositiveInfinity (float.IsPositiveInfinity(v)).
        /// </summary>
        public static bool4 IsPositiveInfinity(float4 v) => float4.IsPositiveInfinity(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static float4 Abs(float4 v) => float4.Abs(v);

        /// <summary>
        /// Returns a float4 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static float4 HermiteInterpolationOrder3(float4 v) => float4.HermiteInterpolationOrder3(v);

        /// <summary>
        /// Returns a float4 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static float4 HermiteInterpolationOrder5(float4 v) => float4.HermiteInterpolationOrder5(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Sqr (v * v).
        /// </summary>
        public static float4 Sqr(float4 v) => float4.Sqr(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static float4 Pow2(float4 v) => float4.Pow2(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static float4 Pow3(float4 v) => float4.Pow3(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Step (v &gt;= 0f ? 1f : 0f).
        /// </summary>
        public static float4 Step(float4 v) => float4.Step(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Sqrt ((float)Math.Sqrt((double)v)).
        /// </summary>
        public static float4 Sqrt(float4 v) => float4.Sqrt(v);

        /// <summary>
        /// Returns a float4 from component-wise application of InverseSqrt ((float)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static float4 InverseSqrt(float4 v) => float4.InverseSqrt(v);

        /// <summary>
        /// Returns a int4 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int4 Sign(float4 v) => float4.Sign(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static float4 Max(float4 lhs, float4 rhs) => float4.Max(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static float4 Min(float4 lhs, float4 rhs) => float4.Min(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Pow ((float)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static float4 Pow(float4 lhs, float4 rhs) => float4.Pow(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Log ((float)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static float4 Log(float4 lhs, float4 rhs) => float4.Log(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float4 Clamp(float4 v, float4 min, float4 max) => float4.Clamp(v, min, max);

        /// <summary>
        /// Returns a float4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float4 Mix(float4 min, float4 max, float4 a) => float4.Mix(min, max, a);

        /// <summary>
        /// Returns a float4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float4 Lerp(float4 min, float4 max, float4 a) => float4.Lerp(min, max, a);

        /// <summary>
        /// Returns a float4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float4 Smoothstep(float4 edge0, float4 edge1, float4 v) => float4.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a float4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float4 Smootherstep(float4 edge0, float4 edge1, float4 v) => float4.Smootherstep(edge0, edge1, v);

        /// <summary>
        /// Returns a float4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float4 Fma(float4 a, float4 b, float4 c) => float4.Fma(a, b, c);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float2x4 OuterProduct(float4 c, float2 r) => float4.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float3x4 OuterProduct(float4 c, float3 r) => float4.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float4x4 OuterProduct(float4 c, float4 r) => float4.OuterProduct(c, r);

        /// <summary>
        /// Returns a float4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static float4 Add(float4 lhs, float4 rhs) => float4.Add(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static float4 Sub(float4 lhs, float4 rhs) => float4.Sub(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static float4 Mul(float4 lhs, float4 rhs) => float4.Mul(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static float4 Div(float4 lhs, float4 rhs) => float4.Div(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static float4 Modulo(float4 lhs, float4 rhs) => float4.Modulo(lhs, rhs);

        /// <summary>
        /// Returns a float4 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static float4 Degrees(float4 v) => float4.Degrees(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static float4 Radians(float4 v) => float4.Radians(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Acos ((float)Math.Acos((double)v)).
        /// </summary>
        public static float4 Acos(float4 v) => float4.Acos(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Asin ((float)Math.Asin((double)v)).
        /// </summary>
        public static float4 Asin(float4 v) => float4.Asin(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Atan ((float)Math.Atan((double)v)).
        /// </summary>
        public static float4 Atan(float4 v) => float4.Atan(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Cos ((float)Math.Cos((double)v)).
        /// </summary>
        public static float4 Cos(float4 v) => float4.Cos(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Cosh ((float)Math.Cosh((double)v)).
        /// </summary>
        public static float4 Cosh(float4 v) => float4.Cosh(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Exp ((float)Math.Exp((double)v)).
        /// </summary>
        public static float4 Exp(float4 v) => float4.Exp(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Log ((float)Math.Log((double)v)).
        /// </summary>
        public static float4 Log(float4 v) => float4.Log(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Log2 ((float)Math.Log((double)v, 2)).
        /// </summary>
        public static float4 Log2(float4 v) => float4.Log2(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Log10 ((float)Math.Log10((double)v)).
        /// </summary>
        public static float4 Log10(float4 v) => float4.Log10(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Floor ((float)Math.Floor(v)).
        /// </summary>
        public static float4 Floor(float4 v) => float4.Floor(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Ceiling ((float)Math.Ceiling(v)).
        /// </summary>
        public static float4 Ceiling(float4 v) => float4.Ceiling(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Round ((float)Math.Round(v)).
        /// </summary>
        public static float4 Round(float4 v) => float4.Round(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Sin ((float)Math.Sin((double)v)).
        /// </summary>
        public static float4 Sin(float4 v) => float4.Sin(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Sinh ((float)Math.Sinh((double)v)).
        /// </summary>
        public static float4 Sinh(float4 v) => float4.Sinh(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Tan ((float)Math.Tan((double)v)).
        /// </summary>
        public static float4 Tan(float4 v) => float4.Tan(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Tanh ((float)Math.Tanh((double)v)).
        /// </summary>
        public static float4 Tanh(float4 v) => float4.Tanh(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Truncate ((float)Math.Truncate((double)v)).
        /// </summary>
        public static float4 Truncate(float4 v) => float4.Truncate(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Fract ((float)(v - Math.Floor(v))).
        /// </summary>
        public static float4 Fract(float4 v) => float4.Fract(v);

        /// <summary>
        /// Returns a float4 from component-wise application of Trunc ((long)(v)).
        /// </summary>
        public static float4 Trunc(float4 v) => float4.Trunc(v);

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static float MinElement(float4 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static float MaxElement(float4 v) => v.MaxElement;

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(float4 v) => v.Length;

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public static float LengthSqr(float4 v) => v.LengthSqr;

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public static float Sum(float4 v) => v.Sum;

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public static float Norm(float4 v) => v.Norm;

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public static float Norm1(float4 v) => v.Norm1;

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public static float Norm2(float4 v) => v.Norm2;

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public static float NormMax(float4 v) => v.NormMax;

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public static double NormP(float4 v, double p) => v.NormP(p);

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static float4 Normalized(float4 v) => v.Normalized;

        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        public static float4 NormalizedSafe(float4 v) => v.NormalizedSafe;

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static float Dot(float4 lhs, float4 rhs) => float4.Dot(lhs, rhs);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(float4 lhs, float4 rhs) => float4.Distance(lhs, rhs);

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(float4 lhs, float4 rhs) => float4.DistanceSqr(lhs, rhs);

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float4 Reflect(float4 I, float4 N) => float4.Reflect(I, N);

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float4 Refract(float4 I, float4 N, float eta) => float4.Refract(I, N, eta);

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static float4 FaceForward(float4 N, float4 I, float4 Nref) => float4.FaceForward(N, I, Nref);

    }
}
