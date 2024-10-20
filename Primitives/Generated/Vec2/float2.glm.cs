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
        public static swizzle_vec2 swizzle(float2 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(float2 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        public static int Count(float2 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(float2 v, float2 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(float2 v) => v.GetHashCode();

        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        public static bool ApproxEqual(float2 lhs, float2 rhs, float eps = 0.1f) => float2.ApproxEqual(lhs, rhs, eps);

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(float2 lhs, float2 rhs) => float2.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(float2 lhs, float2 rhs) => float2.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(float2 lhs, float2 rhs) => float2.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(float2 lhs, float2 rhs) => float2.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(float2 lhs, float2 rhs) => float2.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(float2 lhs, float2 rhs) => float2.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of IsInfinity (float.IsInfinity(v)).
        /// </summary>
        public static bool2 IsInfinity(float2 v) => float2.IsInfinity(v);

        /// <summary>
        /// Returns a bool2 from component-wise application of IsFinite (!float.IsNaN(v) &amp;&amp; !float.IsInfinity(v)).
        /// </summary>
        public static bool2 IsFinite(float2 v) => float2.IsFinite(v);

        /// <summary>
        /// Returns a bool2 from component-wise application of IsNaN (float.IsNaN(v)).
        /// </summary>
        public static bool2 IsNaN(float2 v) => float2.IsNaN(v);

        /// <summary>
        /// Returns a bool2 from component-wise application of IsNegativeInfinity (float.IsNegativeInfinity(v)).
        /// </summary>
        public static bool2 IsNegativeInfinity(float2 v) => float2.IsNegativeInfinity(v);

        /// <summary>
        /// Returns a bool2 from component-wise application of IsPositiveInfinity (float.IsPositiveInfinity(v)).
        /// </summary>
        public static bool2 IsPositiveInfinity(float2 v) => float2.IsPositiveInfinity(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static float2 Abs(float2 v) => float2.Abs(v);

        /// <summary>
        /// Returns a float2 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static float2 HermiteInterpolationOrder3(float2 v) => float2.HermiteInterpolationOrder3(v);

        /// <summary>
        /// Returns a float2 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static float2 HermiteInterpolationOrder5(float2 v) => float2.HermiteInterpolationOrder5(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Sqr (v * v).
        /// </summary>
        public static float2 Sqr(float2 v) => float2.Sqr(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static float2 Pow2(float2 v) => float2.Pow2(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static float2 Pow3(float2 v) => float2.Pow3(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Step (v &gt;= 0f ? 1f : 0f).
        /// </summary>
        public static float2 Step(float2 v) => float2.Step(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Sqrt ((float)Math.Sqrt((double)v)).
        /// </summary>
        public static float2 Sqrt(float2 v) => float2.Sqrt(v);

        /// <summary>
        /// Returns a float2 from component-wise application of InverseSqrt ((float)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static float2 InverseSqrt(float2 v) => float2.InverseSqrt(v);

        /// <summary>
        /// Returns a int2 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int2 Sign(float2 v) => float2.Sign(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static float2 Max(float2 lhs, float2 rhs) => float2.Max(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static float2 Min(float2 lhs, float2 rhs) => float2.Min(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Pow ((float)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static float2 Pow(float2 lhs, float2 rhs) => float2.Pow(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Log ((float)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static float2 Log(float2 lhs, float2 rhs) => float2.Log(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static float2 Clamp(float2 v, float2 min, float2 max) => float2.Clamp(v, min, max);

        /// <summary>
        /// Returns a float2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static float2 Mix(float2 min, float2 max, float2 a) => float2.Mix(min, max, a);

        /// <summary>
        /// Returns a float2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static float2 Lerp(float2 min, float2 max, float2 a) => float2.Lerp(min, max, a);

        /// <summary>
        /// Returns a float2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static float2 Smoothstep(float2 edge0, float2 edge1, float2 v) => float2.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a float2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static float2 Smootherstep(float2 edge0, float2 edge1, float2 v) => float2.Smootherstep(edge0, edge1, v);

        /// <summary>
        /// Returns a float2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static float2 Fma(float2 a, float2 b, float2 c) => float2.Fma(a, b, c);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float2x2 OuterProduct(float2 c, float2 r) => float2.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float3x2 OuterProduct(float2 c, float3 r) => float2.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static float4x2 OuterProduct(float2 c, float4 r) => float2.OuterProduct(c, r);

        /// <summary>
        /// Returns a float2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static float2 Add(float2 lhs, float2 rhs) => float2.Add(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static float2 Sub(float2 lhs, float2 rhs) => float2.Sub(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static float2 Mul(float2 lhs, float2 rhs) => float2.Mul(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static float2 Div(float2 lhs, float2 rhs) => float2.Div(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static float2 Modulo(float2 lhs, float2 rhs) => float2.Modulo(lhs, rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static float2 Degrees(float2 v) => float2.Degrees(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static float2 Radians(float2 v) => float2.Radians(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Acos ((float)Math.Acos((double)v)).
        /// </summary>
        public static float2 Acos(float2 v) => float2.Acos(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Asin ((float)Math.Asin((double)v)).
        /// </summary>
        public static float2 Asin(float2 v) => float2.Asin(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Atan ((float)Math.Atan((double)v)).
        /// </summary>
        public static float2 Atan(float2 v) => float2.Atan(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Cos ((float)Math.Cos((double)v)).
        /// </summary>
        public static float2 Cos(float2 v) => float2.Cos(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Cosh ((float)Math.Cosh((double)v)).
        /// </summary>
        public static float2 Cosh(float2 v) => float2.Cosh(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Exp ((float)Math.Exp((double)v)).
        /// </summary>
        public static float2 Exp(float2 v) => float2.Exp(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Log ((float)Math.Log((double)v)).
        /// </summary>
        public static float2 Log(float2 v) => float2.Log(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Log2 ((float)Math.Log((double)v, 2)).
        /// </summary>
        public static float2 Log2(float2 v) => float2.Log2(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Log10 ((float)Math.Log10((double)v)).
        /// </summary>
        public static float2 Log10(float2 v) => float2.Log10(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Floor ((float)Math.Floor(v)).
        /// </summary>
        public static float2 Floor(float2 v) => float2.Floor(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Ceiling ((float)Math.Ceiling(v)).
        /// </summary>
        public static float2 Ceiling(float2 v) => float2.Ceiling(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Round ((float)Math.Round(v)).
        /// </summary>
        public static float2 Round(float2 v) => float2.Round(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Sin ((float)Math.Sin((double)v)).
        /// </summary>
        public static float2 Sin(float2 v) => float2.Sin(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Sinh ((float)Math.Sinh((double)v)).
        /// </summary>
        public static float2 Sinh(float2 v) => float2.Sinh(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Tan ((float)Math.Tan((double)v)).
        /// </summary>
        public static float2 Tan(float2 v) => float2.Tan(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Tanh ((float)Math.Tanh((double)v)).
        /// </summary>
        public static float2 Tanh(float2 v) => float2.Tanh(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Truncate ((float)Math.Truncate((double)v)).
        /// </summary>
        public static float2 Truncate(float2 v) => float2.Truncate(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Fract ((float)(v - Math.Floor(v))).
        /// </summary>
        public static float2 Fract(float2 v) => float2.Fract(v);

        /// <summary>
        /// Returns a float2 from component-wise application of Trunc ((long)(v)).
        /// </summary>
        public static float2 Trunc(float2 v) => float2.Trunc(v);

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static float MinElement(float2 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static float MaxElement(float2 v) => v.MaxElement;

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(float2 v) => v.Length;

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public static float LengthSqr(float2 v) => v.LengthSqr;

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public static float Sum(float2 v) => v.Sum;

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public static float Norm(float2 v) => v.Norm;

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public static float Norm1(float2 v) => v.Norm1;

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public static float Norm2(float2 v) => v.Norm2;

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public static float NormMax(float2 v) => v.NormMax;

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public static double NormP(float2 v, double p) => v.NormP(p);

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static float2 Normalized(float2 v) => v.Normalized;

        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        public static float2 NormalizedSafe(float2 v) => v.NormalizedSafe;

        /// <summary>
        /// Returns the vector angle (atan2(y, x)) in radians.
        /// </summary>
        public static double Angle(float2 v) => v.Angle;

        /// <summary>
        /// Returns a 2D vector that was rotated by a given angle in radians (CAUTION: result is casted and may be truncated).
        /// </summary>
        public static float2 Rotated(float2 v, double angleInRad) => v.Rotated(angleInRad);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static float Dot(float2 lhs, float2 rhs) => float2.Dot(lhs, rhs);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(float2 lhs, float2 rhs) => float2.Distance(lhs, rhs);

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(float2 lhs, float2 rhs) => float2.DistanceSqr(lhs, rhs);

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float2 Reflect(float2 I, float2 N) => float2.Reflect(I, N);

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float2 Refract(float2 I, float2 N, float eta) => float2.Refract(I, N, eta);

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static float2 FaceForward(float2 N, float2 I, float2 Nref) => float2.FaceForward(N, I, Nref);

        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static float Cross(float2 l, float2 r) => float2.Cross(l, r);

    }
}
