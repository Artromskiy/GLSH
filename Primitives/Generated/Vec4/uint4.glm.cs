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
        public static swizzle_uvec4 swizzle(uint4 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(uint4 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        public static int Count(uint4 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(uint4 v, uint4 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(uint4 v) => v.GetHashCode();

        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(uint4 lhs, uint4 rhs) => uint4.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(uint4 lhs, uint4 rhs) => uint4.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(uint4 lhs, uint4 rhs) => uint4.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(uint4 lhs, uint4 rhs) => uint4.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(uint4 lhs, uint4 rhs) => uint4.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(uint4 lhs, uint4 rhs) => uint4.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Abs (v).
        /// </summary>
        public static uint4 Abs(uint4 v) => uint4.Abs(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint4 HermiteInterpolationOrder3(uint4 v) => uint4.HermiteInterpolationOrder3(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint4 HermiteInterpolationOrder5(uint4 v) => uint4.HermiteInterpolationOrder5(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of Sqr (v * v).
        /// </summary>
        public static uint4 Sqr(uint4 v) => uint4.Sqr(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static uint4 Pow2(uint4 v) => uint4.Pow2(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static uint4 Pow3(uint4 v) => uint4.Pow3(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint4 Step(uint4 v) => uint4.Step(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of Sqrt ((uint)Math.Sqrt((double)v)).
        /// </summary>
        public static uint4 Sqrt(uint4 v) => uint4.Sqrt(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of InverseSqrt ((uint)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static uint4 InverseSqrt(uint4 v) => uint4.InverseSqrt(v);

        /// <summary>
        /// Returns a int4 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int4 Sign(uint4 v) => uint4.Sign(v);

        /// <summary>
        /// Returns a uint4 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint4 Max(uint4 lhs, uint4 rhs) => uint4.Max(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint4 Min(uint4 lhs, uint4 rhs) => uint4.Min(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint4 Pow(uint4 lhs, uint4 rhs) => uint4.Pow(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint4 Log(uint4 lhs, uint4 rhs) => uint4.Log(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint4 Clamp(uint4 v, uint4 min, uint4 max) => uint4.Clamp(v, min, max);

        /// <summary>
        /// Returns a uint4 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint4 Mix(uint4 min, uint4 max, uint4 a) => uint4.Mix(min, max, a);

        /// <summary>
        /// Returns a uint4 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint4 Lerp(uint4 min, uint4 max, uint4 a) => uint4.Lerp(min, max, a);

        /// <summary>
        /// Returns a uint4 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint4 Smoothstep(uint4 edge0, uint4 edge1, uint4 v) => uint4.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a uint4 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint4 Smootherstep(uint4 edge0, uint4 edge1, uint4 v) => uint4.Smootherstep(edge0, edge1, v);

        /// <summary>
        /// Returns a uint4 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint4 Fma(uint4 a, uint4 b, uint4 c) => uint4.Fma(a, b, c);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x4 OuterProduct(uint4 c, uint2 r) => uint4.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint3x4 OuterProduct(uint4 c, uint3 r) => uint4.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint4x4 OuterProduct(uint4 c, uint4 r) => uint4.OuterProduct(c, r);

        /// <summary>
        /// Returns a uint4 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint4 Add(uint4 lhs, uint4 rhs) => uint4.Add(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint4 Sub(uint4 lhs, uint4 rhs) => uint4.Sub(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint4 Mul(uint4 lhs, uint4 rhs) => uint4.Mul(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint4 Div(uint4 lhs, uint4 rhs) => uint4.Div(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint4 Xor(uint4 lhs, uint4 rhs) => uint4.Xor(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint4 BitwiseOr(uint4 lhs, uint4 rhs) => uint4.BitwiseOr(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint4 BitwiseAnd(uint4 lhs, uint4 rhs) => uint4.BitwiseAnd(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint4 LeftShift(uint4 lhs, int4 rhs) => uint4.LeftShift(lhs, rhs);

        /// <summary>
        /// Returns a uint4 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint4 RightShift(uint4 lhs, int4 rhs) => uint4.RightShift(lhs, rhs);

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static uint MinElement(uint4 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static uint MaxElement(uint4 v) => v.MaxElement;

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(uint4 v) => v.Length;

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public static float LengthSqr(uint4 v) => v.LengthSqr;

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public static uint Sum(uint4 v) => v.Sum;

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public static float Norm(uint4 v) => v.Norm;

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public static float Norm1(uint4 v) => v.Norm1;

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public static float Norm2(uint4 v) => v.Norm2;

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public static float NormMax(uint4 v) => v.NormMax;

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public static double NormP(uint4 v, double p) => v.NormP(p);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static uint Dot(uint4 lhs, uint4 rhs) => uint4.Dot(lhs, rhs);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(uint4 lhs, uint4 rhs) => uint4.Distance(lhs, rhs);

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(uint4 lhs, uint4 rhs) => uint4.DistanceSqr(lhs, rhs);

    }
}
