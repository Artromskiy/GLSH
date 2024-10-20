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
        public static swizzle_dvec4 swizzle(double4 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(double4 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public static int Count(double4 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(double4 v, double4 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(double4 v) => v.GetHashCode();

        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        public static bool ApproxEqual(double4 lhs, double4 rhs, double eps = 0.1d) => double4.ApproxEqual(lhs, rhs, eps);

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(double4 lhs, double4 rhs) => double4.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(double4 lhs, double4 rhs) => double4.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(double4 lhs, double4 rhs) => double4.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(double4 lhs, double4 rhs) => double4.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(double4 lhs, double4 rhs) => double4.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(double4 lhs, double4 rhs) => double4.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool4 IsInfinity(double4 v) => double4.IsInfinity(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsFinite (!double.IsNaN(v) &amp;&amp; !double.IsInfinity(v)).
        /// </summary>
        public static bool4 IsFinite(double4 v) => double4.IsFinite(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool4 IsNaN(double4 v) => double4.IsNaN(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsNegativeInfinity (double.IsNegativeInfinity(v)).
        /// </summary>
        public static bool4 IsNegativeInfinity(double4 v) => double4.IsNegativeInfinity(v);

        /// <summary>
        /// Returns a bool4 from component-wise application of IsPositiveInfinity (double.IsPositiveInfinity(v)).
        /// </summary>
        public static bool4 IsPositiveInfinity(double4 v) => double4.IsPositiveInfinity(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static double4 Abs(double4 v) => double4.Abs(v);

        /// <summary>
        /// Returns a double4 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static double4 HermiteInterpolationOrder3(double4 v) => double4.HermiteInterpolationOrder3(v);

        /// <summary>
        /// Returns a double4 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static double4 HermiteInterpolationOrder5(double4 v) => double4.HermiteInterpolationOrder5(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Sqr (v * v).
        /// </summary>
        public static double4 Sqr(double4 v) => double4.Sqr(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static double4 Pow2(double4 v) => double4.Pow2(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static double4 Pow3(double4 v) => double4.Pow3(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        public static double4 Step(double4 v) => double4.Step(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Sqrt ((double)Math.Sqrt((double)v)).
        /// </summary>
        public static double4 Sqrt(double4 v) => double4.Sqrt(v);

        /// <summary>
        /// Returns a double4 from component-wise application of InverseSqrt ((double)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static double4 InverseSqrt(double4 v) => double4.InverseSqrt(v);

        /// <summary>
        /// Returns a int4 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int4 Sign(double4 v) => double4.Sign(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static double4 Max(double4 lhs, double4 rhs) => double4.Max(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static double4 Min(double4 lhs, double4 rhs) => double4.Min(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Pow ((double)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Pow(double4 lhs, double4 rhs) => double4.Pow(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Log ((double)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double4 Log(double4 lhs, double4 rhs) => double4.Log(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double4 Clamp(double4 v, double4 min, double4 max) => double4.Clamp(v, min, max);

        /// <summary>
        /// Returns a double4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double4 Mix(double4 min, double4 max, double4 a) => double4.Mix(min, max, a);

        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double4 Lerp(double4 min, double4 max, double4 a) => double4.Lerp(min, max, a);

        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double4 edge0, double4 edge1, double4 v) => double4.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a double4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double4 Smootherstep(double4 edge0, double4 edge1, double4 v) => double4.Smootherstep(edge0, edge1, v);

        /// <summary>
        /// Returns a double4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double4 Fma(double4 a, double4 b, double4 c) => double4.Fma(a, b, c);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double2x4 OuterProduct(double4 c, double2 r) => double4.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double3x4 OuterProduct(double4 c, double3 r) => double4.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double4x4 OuterProduct(double4 c, double4 r) => double4.OuterProduct(c, r);

        /// <summary>
        /// Returns a double4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double4 Add(double4 lhs, double4 rhs) => double4.Add(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double4 Sub(double4 lhs, double4 rhs) => double4.Sub(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double4 Mul(double4 lhs, double4 rhs) => double4.Mul(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double4 Div(double4 lhs, double4 rhs) => double4.Div(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double4 Modulo(double4 lhs, double4 rhs) => double4.Modulo(lhs, rhs);

        /// <summary>
        /// Returns a double4 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static double4 Degrees(double4 v) => double4.Degrees(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static double4 Radians(double4 v) => double4.Radians(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Acos ((double)Math.Acos((double)v)).
        /// </summary>
        public static double4 Acos(double4 v) => double4.Acos(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Asin ((double)Math.Asin((double)v)).
        /// </summary>
        public static double4 Asin(double4 v) => double4.Asin(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Atan ((double)Math.Atan((double)v)).
        /// </summary>
        public static double4 Atan(double4 v) => double4.Atan(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Cos ((double)Math.Cos((double)v)).
        /// </summary>
        public static double4 Cos(double4 v) => double4.Cos(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Cosh ((double)Math.Cosh((double)v)).
        /// </summary>
        public static double4 Cosh(double4 v) => double4.Cosh(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Exp ((double)Math.Exp((double)v)).
        /// </summary>
        public static double4 Exp(double4 v) => double4.Exp(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Log ((double)Math.Log((double)v)).
        /// </summary>
        public static double4 Log(double4 v) => double4.Log(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Log2 ((double)Math.Log((double)v, 2)).
        /// </summary>
        public static double4 Log2(double4 v) => double4.Log2(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Log10 ((double)Math.Log10((double)v)).
        /// </summary>
        public static double4 Log10(double4 v) => double4.Log10(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Floor ((double)Math.Floor(v)).
        /// </summary>
        public static double4 Floor(double4 v) => double4.Floor(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Ceiling ((double)Math.Ceiling(v)).
        /// </summary>
        public static double4 Ceiling(double4 v) => double4.Ceiling(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Round ((double)Math.Round(v)).
        /// </summary>
        public static double4 Round(double4 v) => double4.Round(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Sin ((double)Math.Sin((double)v)).
        /// </summary>
        public static double4 Sin(double4 v) => double4.Sin(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Sinh ((double)Math.Sinh((double)v)).
        /// </summary>
        public static double4 Sinh(double4 v) => double4.Sinh(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Tan ((double)Math.Tan((double)v)).
        /// </summary>
        public static double4 Tan(double4 v) => double4.Tan(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Tanh ((double)Math.Tanh((double)v)).
        /// </summary>
        public static double4 Tanh(double4 v) => double4.Tanh(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Truncate ((double)Math.Truncate((double)v)).
        /// </summary>
        public static double4 Truncate(double4 v) => double4.Truncate(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Fract ((double)(v - Math.Floor(v))).
        /// </summary>
        public static double4 Fract(double4 v) => double4.Fract(v);

        /// <summary>
        /// Returns a double4 from component-wise application of Trunc ((long)(v)).
        /// </summary>
        public static double4 Trunc(double4 v) => double4.Trunc(v);

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static double MinElement(double4 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static double MaxElement(double4 v) => v.MaxElement;

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static double Length(double4 v) => v.Length;

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public static double LengthSqr(double4 v) => v.LengthSqr;

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public static double Sum(double4 v) => v.Sum;

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public static double Norm(double4 v) => v.Norm;

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public static double Norm1(double4 v) => v.Norm1;

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public static double Norm2(double4 v) => v.Norm2;

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public static double NormMax(double4 v) => v.NormMax;

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public static double NormP(double4 v, double p) => v.NormP(p);

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static double4 Normalized(double4 v) => v.Normalized;

        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        public static double4 NormalizedSafe(double4 v) => v.NormalizedSafe;

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static double Dot(double4 lhs, double4 rhs) => double4.Dot(lhs, rhs);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(double4 lhs, double4 rhs) => double4.Distance(lhs, rhs);

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static double DistanceSqr(double4 lhs, double4 rhs) => double4.DistanceSqr(lhs, rhs);

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double4 Reflect(double4 I, double4 N) => double4.Reflect(I, N);

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double4 Refract(double4 I, double4 N, double eta) => double4.Refract(I, N, eta);

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static double4 FaceForward(double4 N, double4 I, double4 Nref) => double4.FaceForward(N, I, Nref);

    }
}
