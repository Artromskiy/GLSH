using GLSH.Swizzle;
using System;

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
        public static swizzle_dvec3 swizzle(double3 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(double3 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        public static int Count(double3 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(double3 v, double3 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(double3 v) => v.GetHashCode();

        /// <summary>
        /// Returns true iff distance between lhs and rhs is less than or equal to epsilon
        /// </summary>
        public static bool ApproxEqual(double3 lhs, double3 rhs, double eps = 0.1d) => double3.ApproxEqual(lhs, rhs, eps);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(double3 lhs, double3 rhs) => double3.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool Equal(double lhs, double rhs) => lhs == rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(double3 lhs, double3 rhs) => double3.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool NotEqual(double lhs, double rhs) => lhs != rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(double3 lhs, double3 rhs) => double3.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool GreaterThan(double lhs, double rhs) => lhs > rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(double3 lhs, double3 rhs) => double3.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool GreaterThanEqual(double lhs, double rhs) => lhs >= rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(double3 lhs, double3 rhs) => double3.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool LesserThan(double lhs, double rhs) => lhs < rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(double3 lhs, double3 rhs) => double3.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool LesserThanEqual(double lhs, double rhs) => lhs <= rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool3 IsInfinity(double3 v) => double3.IsInfinity(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool IsInfinity(double v) => double.IsInfinity(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsFinite (!double.IsNaN(v) &amp;&amp; !double.IsInfinity(v)).
        /// </summary>
        public static bool3 IsFinite(double3 v) => double3.IsFinite(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsFinite (!double.IsNaN(v) &amp;&amp; !double.IsInfinity(v)).
        /// </summary>
        public static bool IsFinite(double v) => !double.IsNaN(v) && !double.IsInfinity(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool3 IsNaN(double3 v) => double3.IsNaN(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool IsNaN(double v) => double.IsNaN(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsNegativeInfinity (double.IsNegativeInfinity(v)).
        /// </summary>
        public static bool3 IsNegativeInfinity(double3 v) => double3.IsNegativeInfinity(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsNegativeInfinity (double.IsNegativeInfinity(v)).
        /// </summary>
        public static bool IsNegativeInfinity(double v) => double.IsNegativeInfinity(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsPositiveInfinity (double.IsPositiveInfinity(v)).
        /// </summary>
        public static bool3 IsPositiveInfinity(double3 v) => double3.IsPositiveInfinity(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsPositiveInfinity (double.IsPositiveInfinity(v)).
        /// </summary>
        public static bool IsPositiveInfinity(double v) => double.IsPositiveInfinity(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static double3 Abs(double3 v) => double3.Abs(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Abs (Math.Abs(v)).
        /// </summary>
        public static double Abs(double v) => Math.Abs(v);

        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static double3 HermiteInterpolationOrder3(double3 v) => double3.HermiteInterpolationOrder3(v);

        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static double HermiteInterpolationOrder3(double v) => (3 - 2 * v) * v * v;

        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static double3 HermiteInterpolationOrder5(double3 v) => double3.HermiteInterpolationOrder5(v);

        /// <summary>
        /// Returns a double3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static double HermiteInterpolationOrder5(double v) => ((6 * v - 15) * v + 10) * v * v * v;

        /// <summary>
        /// Returns a double3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static double3 Sqr(double3 v) => double3.Sqr(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static double Sqr(double v) => v * v;

        /// <summary>
        /// Returns a double3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static double3 Pow2(double3 v) => double3.Pow2(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static double Pow2(double v) => v * v;

        /// <summary>
        /// Returns a double3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static double3 Pow3(double3 v) => double3.Pow3(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static double Pow3(double v) => v * v * v;

        /// <summary>
        /// Returns a double3 from component-wise application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        public static double3 Step(double3 v) => double3.Step(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Step (v &gt;= 0.0 ? 1.0 : 0.0).
        /// </summary>
        public static double Step(double v) => v >= 0.0 ? 1.0 : 0.0;

        /// <summary>
        /// Returns a double3 from component-wise application of Sqrt ((double)Math.Sqrt((double)v)).
        /// </summary>
        public static double3 Sqrt(double3 v) => double3.Sqrt(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Sqrt ((double)Math.Sqrt((double)v)).
        /// </summary>
        public static double Sqrt(double v) => (double)Math.Sqrt((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of InverseSqrt ((double)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static double3 InverseSqrt(double3 v) => double3.InverseSqrt(v);

        /// <summary>
        /// Returns a double3 from component-wise application of InverseSqrt ((double)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static double InverseSqrt(double v) => (double)(1.0 / Math.Sqrt((double)v));

        /// <summary>
        /// Returns a int3 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int3 Sign(double3 v) => double3.Sign(v);

        /// <summary>
        /// Returns a int3 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int Sign(double v) => Math.Sign(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static double3 Max(double3 lhs, double3 rhs) => double3.Max(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static double Max(double lhs, double rhs) => Math.Max(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static double3 Min(double3 lhs, double3 rhs) => double3.Min(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static double Min(double lhs, double rhs) => Math.Min(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Pow ((double)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Pow(double3 lhs, double3 rhs) => double3.Pow(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Pow ((double)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static double Pow(double lhs, double rhs) => (double)Math.Pow((double)lhs, (double)rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double3 Log(double3 lhs, double3 rhs) => double3.Log(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static double Log(double lhs, double rhs) => (double)Math.Log((double)lhs, (double)rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double3 Clamp(double3 v, double3 min, double3 max) => double3.Clamp(v, min, max);

        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static double Clamp(double v, double min, double max) => Math.Min(Math.Max(v, min), max);

        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double3 Mix(double3 min, double3 max, double3 a) => double3.Mix(min, max, a);

        /// <summary>
        /// Returns a double3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static double Mix(double min, double max, double a) => min * (1 - a) + max * a;

        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double3 Lerp(double3 min, double3 max, double3 a) => double3.Lerp(min, max, a);

        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static double Lerp(double min, double max, double a) => min * (1 - a) + max * a;

        /// <summary>
        /// Returns a double3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double3 Smoothstep(double3 edge0, double3 edge1, double3 v) => double3.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a double3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static double Smoothstep(double edge0, double edge1, double v) => ((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3();

        /// <summary>
        /// Returns a double3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double3 Smootherstep(double3 edge0, double3 edge1, double3 v) => double3.Smootherstep(edge0, edge1, v);

        /// <summary>
        /// Returns a double3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static double Smootherstep(double edge0, double edge1, double v) => ((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5();

        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double3 Fma(double3 a, double3 b, double3 c) => double3.Fma(a, b, c);

        /// <summary>
        /// Returns a double3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static double Fma(double a, double b, double c) => a * b + c;

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double2x3 OuterProduct(double3 c, double2 r) => double3.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double3x3 OuterProduct(double3 c, double3 r) => double3.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static double4x3 OuterProduct(double3 c, double4 r) => double3.OuterProduct(c, r);

        /// <summary>
        /// Returns a double3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double3 Add(double3 lhs, double3 rhs) => double3.Add(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static double Add(double lhs, double rhs) => lhs + rhs;

        /// <summary>
        /// Returns a double3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double3 Sub(double3 lhs, double3 rhs) => double3.Sub(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static double Sub(double lhs, double rhs) => lhs - rhs;

        /// <summary>
        /// Returns a double3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double3 Mul(double3 lhs, double3 rhs) => double3.Mul(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static double Mul(double lhs, double rhs) => lhs * rhs;

        /// <summary>
        /// Returns a double3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double3 Div(double3 lhs, double3 rhs) => double3.Div(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static double Div(double lhs, double rhs) => lhs / rhs;

        /// <summary>
        /// Returns a double3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double3 Modulo(double3 lhs, double3 rhs) => double3.Modulo(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Modulo (lhs % rhs).
        /// </summary>
        public static double Modulo(double lhs, double rhs) => lhs % rhs;

        /// <summary>
        /// Returns a double3 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static double3 Degrees(double3 v) => double3.Degrees(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Degrees (Radians-To-Degrees Conversion).
        /// </summary>
        public static double Degrees(double v) => (double)(v * 57.295779513082320876798154814105170332405472466564321d);

        /// <summary>
        /// Returns a double3 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static double3 Radians(double3 v) => double3.Radians(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Radians (Degrees-To-Radians Conversion).
        /// </summary>
        public static double Radians(double v) => (double)(v * 0.0174532925199432957692369076848861271344287188854172d);

        /// <summary>
        /// Returns a double3 from component-wise application of Acos ((double)Math.Acos((double)v)).
        /// </summary>
        public static double3 Acos(double3 v) => double3.Acos(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Acos ((double)Math.Acos((double)v)).
        /// </summary>
        public static double Acos(double v) => (double)Math.Acos((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Asin ((double)Math.Asin((double)v)).
        /// </summary>
        public static double3 Asin(double3 v) => double3.Asin(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Asin ((double)Math.Asin((double)v)).
        /// </summary>
        public static double Asin(double v) => (double)Math.Asin((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Atan ((double)Math.Atan((double)v)).
        /// </summary>
        public static double3 Atan(double3 v) => double3.Atan(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Atan ((double)Math.Atan((double)v)).
        /// </summary>
        public static double Atan(double v) => (double)Math.Atan((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Cos ((double)Math.Cos((double)v)).
        /// </summary>
        public static double3 Cos(double3 v) => double3.Cos(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Cos ((double)Math.Cos((double)v)).
        /// </summary>
        public static double Cos(double v) => (double)Math.Cos((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Cosh ((double)Math.Cosh((double)v)).
        /// </summary>
        public static double3 Cosh(double3 v) => double3.Cosh(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Cosh ((double)Math.Cosh((double)v)).
        /// </summary>
        public static double Cosh(double v) => (double)Math.Cosh((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Exp ((double)Math.Exp((double)v)).
        /// </summary>
        public static double3 Exp(double3 v) => double3.Exp(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Exp ((double)Math.Exp((double)v)).
        /// </summary>
        public static double Exp(double v) => (double)Math.Exp((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)Math.Log((double)v)).
        /// </summary>
        public static double3 Log(double3 v) => double3.Log(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Log ((double)Math.Log((double)v)).
        /// </summary>
        public static double Log(double v) => (double)Math.Log((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Log2 ((double)Math.Log((double)v, 2)).
        /// </summary>
        public static double3 Log2(double3 v) => double3.Log2(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Log2 ((double)Math.Log((double)v, 2)).
        /// </summary>
        public static double Log2(double v) => (double)Math.Log((double)v, 2);

        /// <summary>
        /// Returns a double3 from component-wise application of Log10 ((double)Math.Log10((double)v)).
        /// </summary>
        public static double3 Log10(double3 v) => double3.Log10(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Log10 ((double)Math.Log10((double)v)).
        /// </summary>
        public static double Log10(double v) => (double)Math.Log10((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Floor ((double)Math.Floor(v)).
        /// </summary>
        public static double3 Floor(double3 v) => double3.Floor(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Floor ((double)Math.Floor(v)).
        /// </summary>
        public static double Floor(double v) => (double)Math.Floor(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Ceiling ((double)Math.Ceiling(v)).
        /// </summary>
        public static double3 Ceiling(double3 v) => double3.Ceiling(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Ceiling ((double)Math.Ceiling(v)).
        /// </summary>
        public static double Ceiling(double v) => (double)Math.Ceiling(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Round ((double)Math.Round(v)).
        /// </summary>
        public static double3 Round(double3 v) => double3.Round(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Round ((double)Math.Round(v)).
        /// </summary>
        public static double Round(double v) => (double)Math.Round(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Sin ((double)Math.Sin((double)v)).
        /// </summary>
        public static double3 Sin(double3 v) => double3.Sin(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Sin ((double)Math.Sin((double)v)).
        /// </summary>
        public static double Sin(double v) => (double)Math.Sin((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Sinh ((double)Math.Sinh((double)v)).
        /// </summary>
        public static double3 Sinh(double3 v) => double3.Sinh(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Sinh ((double)Math.Sinh((double)v)).
        /// </summary>
        public static double Sinh(double v) => (double)Math.Sinh((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Tan ((double)Math.Tan((double)v)).
        /// </summary>
        public static double3 Tan(double3 v) => double3.Tan(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Tan ((double)Math.Tan((double)v)).
        /// </summary>
        public static double Tan(double v) => (double)Math.Tan((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Tanh ((double)Math.Tanh((double)v)).
        /// </summary>
        public static double3 Tanh(double3 v) => double3.Tanh(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Tanh ((double)Math.Tanh((double)v)).
        /// </summary>
        public static double Tanh(double v) => (double)Math.Tanh((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Truncate ((double)Math.Truncate((double)v)).
        /// </summary>
        public static double3 Truncate(double3 v) => double3.Truncate(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Truncate ((double)Math.Truncate((double)v)).
        /// </summary>
        public static double Truncate(double v) => (double)Math.Truncate((double)v);

        /// <summary>
        /// Returns a double3 from component-wise application of Fract ((double)(v - Math.Floor(v))).
        /// </summary>
        public static double3 Fract(double3 v) => double3.Fract(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Fract ((double)(v - Math.Floor(v))).
        /// </summary>
        public static double Fract(double v) => (double)(v - Math.Floor(v));

        /// <summary>
        /// Returns a double3 from component-wise application of Trunc ((long)(v)).
        /// </summary>
        public static double3 Trunc(double3 v) => double3.Trunc(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Trunc ((long)(v)).
        /// </summary>
        public static double Trunc(double v) => (long)(v);

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static double MinElement(double3 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static double MaxElement(double3 v) => v.MaxElement;

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static double Length(double3 v) => v.Length;

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public static double LengthSqr(double3 v) => v.LengthSqr;

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public static double Sum(double3 v) => v.Sum;

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public static double Norm(double3 v) => v.Norm;

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public static double Norm1(double3 v) => v.Norm1;

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public static double Norm2(double3 v) => v.Norm2;

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public static double NormMax(double3 v) => v.NormMax;

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public static double NormP(double3 v, double p) => v.NormP(p);

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static double3 Normalized(double3 v) => v.Normalized;

        /// <summary>
        /// Returns a copy of this vector with length one (returns zero if length is zero).
        /// </summary>
        public static double3 NormalizedSafe(double3 v) => v.NormalizedSafe;

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static double Dot(double3 lhs, double3 rhs) => double3.Dot(lhs, rhs);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(double3 lhs, double3 rhs) => double3.Distance(lhs, rhs);

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static double DistanceSqr(double3 lhs, double3 rhs) => double3.DistanceSqr(lhs, rhs);

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double3 Reflect(double3 I, double3 N) => double3.Reflect(I, N);

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double3 Refract(double3 I, double3 N, double eta) => double3.Refract(I, N, eta);

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static double3 FaceForward(double3 N, double3 I, double3 Nref) => double3.FaceForward(N, I, Nref);

        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static double3 Cross(double3 l, double3 r) => double3.Cross(l, r);

    }
}
