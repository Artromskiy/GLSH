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
        public static swizzle_uvec3 swizzle(uint3 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(uint3 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (3).
        /// </summary>
        public static int Count(uint3 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(uint3 v, uint3 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(uint3 v) => v.GetHashCode();

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(uint3 lhs, uint3 rhs) => uint3.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool Equal(uint lhs, uint rhs) => lhs == rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(uint3 lhs, uint3 rhs) => uint3.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool NotEqual(uint lhs, uint rhs) => lhs != rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(uint3 lhs, uint3 rhs) => uint3.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool GreaterThan(uint lhs, uint rhs) => lhs > rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(uint3 lhs, uint3 rhs) => uint3.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool GreaterThanEqual(uint lhs, uint rhs) => lhs >= rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(uint3 lhs, uint3 rhs) => uint3.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool LesserThan(uint lhs, uint rhs) => lhs < rhs;

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(uint3 lhs, uint3 rhs) => uint3.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool LesserThanEqual(uint lhs, uint rhs) => lhs <= rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of Abs (v).
        /// </summary>
        public static uint3 Abs(uint3 v) => uint3.Abs(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Abs (v).
        /// </summary>
        public static uint Abs(uint v) => v;

        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint3 HermiteInterpolationOrder3(uint3 v) => uint3.HermiteInterpolationOrder3(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint HermiteInterpolationOrder3(uint v) => (3 - 2 * v) * v * v;

        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint3 HermiteInterpolationOrder5(uint3 v) => uint3.HermiteInterpolationOrder5(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint HermiteInterpolationOrder5(uint v) => ((6 * v - 15) * v + 10) * v * v * v;

        /// <summary>
        /// Returns a uint3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static uint3 Sqr(uint3 v) => uint3.Sqr(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Sqr (v * v).
        /// </summary>
        public static uint Sqr(uint v) => v * v;

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static uint3 Pow2(uint3 v) => uint3.Pow2(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static uint Pow2(uint v) => v * v;

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static uint3 Pow3(uint3 v) => uint3.Pow3(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static uint Pow3(uint v) => v * v * v;

        /// <summary>
        /// Returns a uint3 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint3 Step(uint3 v) => uint3.Step(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint Step(uint v) => v >= 0u ? 1u : 0u;

        /// <summary>
        /// Returns a uint3 from component-wise application of Sqrt ((uint)Math.Sqrt((double)v)).
        /// </summary>
        public static uint3 Sqrt(uint3 v) => uint3.Sqrt(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Sqrt ((uint)Math.Sqrt((double)v)).
        /// </summary>
        public static uint Sqrt(uint v) => (uint)Math.Sqrt(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of InverseSqrt ((uint)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static uint3 InverseSqrt(uint3 v) => uint3.InverseSqrt(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of InverseSqrt ((uint)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static uint InverseSqrt(uint v) => (uint)(1.0 / Math.Sqrt(v));

        /// <summary>
        /// Returns a int3 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int3 Sign(uint3 v) => uint3.Sign(v);

        /// <summary>
        /// Returns a int3 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int Sign(uint v) => Math.Sign(v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint3 Max(uint3 lhs, uint3 rhs) => uint3.Max(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint Max(uint lhs, uint rhs) => Math.Max(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint3 Min(uint3 lhs, uint3 rhs) => uint3.Min(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint Min(uint lhs, uint rhs) => Math.Min(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Pow(uint3 lhs, uint3 rhs) => uint3.Pow(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint Pow(uint lhs, uint rhs) => (uint)Math.Pow(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint3 Log(uint3 lhs, uint3 rhs) => uint3.Log(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint Log(uint lhs, uint rhs) => (uint)Math.Log(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint3 Clamp(uint3 v, uint3 min, uint3 max) => uint3.Clamp(v, min, max);

        /// <summary>
        /// Returns a uint3 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint Clamp(uint v, uint min, uint max) => Math.Min(Math.Max(v, min), max);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Mix(uint3 min, uint3 max, uint3 a) => uint3.Mix(min, max, a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint Mix(uint min, uint max, uint a) => min * (1 - a) + max * a;

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint3 Lerp(uint3 min, uint3 max, uint3 a) => uint3.Lerp(min, max, a);

        /// <summary>
        /// Returns a uint3 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint Lerp(uint min, uint max, uint a) => min * (1 - a) + max * a;

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint3 Smoothstep(uint3 edge0, uint3 edge1, uint3 v) => uint3.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint Smoothstep(uint edge0, uint edge1, uint v) => ((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3();

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint3 Smootherstep(uint3 edge0, uint3 edge1, uint3 v) => uint3.Smootherstep(edge0, edge1, v);

        /// <summary>
        /// Returns a uint3 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint Smootherstep(uint edge0, uint edge1, uint v) => ((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5();

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint3 Fma(uint3 a, uint3 b, uint3 c) => uint3.Fma(a, b, c);

        /// <summary>
        /// Returns a uint3 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint Fma(uint a, uint b, uint c) => a * b + c;

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x3 OuterProduct(uint3 c, uint2 r) => uint3.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint3x3 OuterProduct(uint3 c, uint3 r) => uint3.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint4x3 OuterProduct(uint3 c, uint4 r) => uint3.OuterProduct(c, r);

        /// <summary>
        /// Returns a uint3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint3 Add(uint3 lhs, uint3 rhs) => uint3.Add(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint Add(uint lhs, uint rhs) => lhs + rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint3 Sub(uint3 lhs, uint3 rhs) => uint3.Sub(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint Sub(uint lhs, uint rhs) => lhs - rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint3 Mul(uint3 lhs, uint3 rhs) => uint3.Mul(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint Mul(uint lhs, uint rhs) => lhs * rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint3 Div(uint3 lhs, uint3 rhs) => uint3.Div(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint Div(uint lhs, uint rhs) => lhs / rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint3 Xor(uint3 lhs, uint3 rhs) => uint3.Xor(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint Xor(uint lhs, uint rhs) => lhs ^ rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint3 BitwiseOr(uint3 lhs, uint3 rhs) => uint3.BitwiseOr(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint BitwiseOr(uint lhs, uint rhs) => lhs | rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint3 BitwiseAnd(uint3 lhs, uint3 rhs) => uint3.BitwiseAnd(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint BitwiseAnd(uint lhs, uint rhs) => lhs & rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint3 LeftShift(uint3 lhs, int3 rhs) => uint3.LeftShift(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint LeftShift(uint lhs, int rhs) => lhs << rhs;

        /// <summary>
        /// Returns a uint3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint3 RightShift(uint3 lhs, int3 rhs) => uint3.RightShift(lhs, rhs);

        /// <summary>
        /// Returns a uint3 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint RightShift(uint lhs, int rhs) => lhs >> rhs;

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static uint MinElement(uint3 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static uint MaxElement(uint3 v) => v.MaxElement;

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(uint3 v) => v.Length;

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public static float LengthSqr(uint3 v) => v.LengthSqr;

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public static uint Sum(uint3 v) => v.Sum;

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public static float Norm(uint3 v) => v.Norm;

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public static float Norm1(uint3 v) => v.Norm1;

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public static float Norm2(uint3 v) => v.Norm2;

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public static float NormMax(uint3 v) => v.NormMax;

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public static double NormP(uint3 v, double p) => v.NormP(p);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static uint Dot(uint3 lhs, uint3 rhs) => uint3.Dot(lhs, rhs);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(uint3 lhs, uint3 rhs) => uint3.Distance(lhs, rhs);

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(uint3 lhs, uint3 rhs) => uint3.DistanceSqr(lhs, rhs);

        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static uint3 Cross(uint3 l, uint3 r) => uint3.Cross(l, r);

    }
}
