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
        public static swizzle_uvec2 swizzle(uint2 v) => v.swizzle;

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(uint2 v) => v.ToString();

        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        public static int Count(uint2 v) => v.Count;

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool Equals(uint2 v, uint2 rhs) => v.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public static int GetHashCode(uint2 v) => v.GetHashCode();

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(uint2 lhs, uint2 rhs) => uint2.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(uint2 lhs, uint2 rhs) => uint2.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(uint2 lhs, uint2 rhs) => uint2.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(uint2 lhs, uint2 rhs) => uint2.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(uint2 lhs, uint2 rhs) => uint2.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(uint2 lhs, uint2 rhs) => uint2.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Abs (v).
        /// </summary>
        public static uint2 Abs(uint2 v) => uint2.Abs(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of HermiteInterpolationOrder3 ((3 - 2 * v) * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder3(uint2 v) => uint2.HermiteInterpolationOrder3(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of HermiteInterpolationOrder5 (((6 * v - 15) * v + 10) * v * v * v).
        /// </summary>
        public static uint2 HermiteInterpolationOrder5(uint2 v) => uint2.HermiteInterpolationOrder5(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Sqr (v * v).
        /// </summary>
        public static uint2 Sqr(uint2 v) => uint2.Sqr(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Pow2 (v * v).
        /// </summary>
        public static uint2 Pow2(uint2 v) => uint2.Pow2(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Pow3 (v * v * v).
        /// </summary>
        public static uint2 Pow3(uint2 v) => uint2.Pow3(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Step (v &gt;= 0u ? 1u : 0u).
        /// </summary>
        public static uint2 Step(uint2 v) => uint2.Step(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Sqrt ((uint)Math.Sqrt((double)v)).
        /// </summary>
        public static uint2 Sqrt(uint2 v) => uint2.Sqrt(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of InverseSqrt ((uint)(1.0 / Math.Sqrt((double)v))).
        /// </summary>
        public static uint2 InverseSqrt(uint2 v) => uint2.InverseSqrt(v);

        /// <summary>
        /// Returns a int2 from component-wise application of Sign (Math.Sign(v)).
        /// </summary>
        public static int2 Sign(uint2 v) => uint2.Sign(v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Max (Math.Max(lhs, rhs)).
        /// </summary>
        public static uint2 Max(uint2 lhs, uint2 rhs) => uint2.Max(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Min (Math.Min(lhs, rhs)).
        /// </summary>
        public static uint2 Min(uint2 lhs, uint2 rhs) => uint2.Min(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Pow ((uint)Math.Pow((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Pow(uint2 lhs, uint2 rhs) => uint2.Pow(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Log ((uint)Math.Log((double)lhs, (double)rhs)).
        /// </summary>
        public static uint2 Log(uint2 lhs, uint2 rhs) => uint2.Log(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Clamp (Math.Min(Math.Max(v, min), max)).
        /// </summary>
        public static uint2 Clamp(uint2 v, uint2 min, uint2 max) => uint2.Clamp(v, min, max);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mix (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Mix(uint2 min, uint2 max, uint2 a) => uint2.Mix(min, max, a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Lerp (min * (1-a) + max * a).
        /// </summary>
        public static uint2 Lerp(uint2 min, uint2 max, uint2 a) => uint2.Lerp(min, max, a);

        /// <summary>
        /// Returns a uint2 from component-wise application of Smoothstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder3()).
        /// </summary>
        public static uint2 Smoothstep(uint2 edge0, uint2 edge1, uint2 v) => uint2.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Smootherstep (((v - edge0) / (edge1 - edge0)).Clamp().HermiteInterpolationOrder5()).
        /// </summary>
        public static uint2 Smootherstep(uint2 edge0, uint2 edge1, uint2 v) => uint2.Smootherstep(edge0, edge1, v);

        /// <summary>
        /// Returns a uint2 from component-wise application of Fma (a * b + c).
        /// </summary>
        public static uint2 Fma(uint2 a, uint2 b, uint2 c) => uint2.Fma(a, b, c);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint2x2 OuterProduct(uint2 c, uint2 r) => uint2.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint3x2 OuterProduct(uint2 c, uint3 r) => uint2.OuterProduct(c, r);

        /// <summary>
        /// OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r.
        /// </summary>
        public static uint4x2 OuterProduct(uint2 c, uint4 r) => uint2.OuterProduct(c, r);

        /// <summary>
        /// Returns a uint2 from component-wise application of Add (lhs + rhs).
        /// </summary>
        public static uint2 Add(uint2 lhs, uint2 rhs) => uint2.Add(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Sub (lhs - rhs).
        /// </summary>
        public static uint2 Sub(uint2 lhs, uint2 rhs) => uint2.Sub(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Mul (lhs * rhs).
        /// </summary>
        public static uint2 Mul(uint2 lhs, uint2 rhs) => uint2.Mul(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Div (lhs / rhs).
        /// </summary>
        public static uint2 Div(uint2 lhs, uint2 rhs) => uint2.Div(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of Xor (lhs ^ rhs).
        /// </summary>
        public static uint2 Xor(uint2 lhs, uint2 rhs) => uint2.Xor(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseOr (lhs | rhs).
        /// </summary>
        public static uint2 BitwiseOr(uint2 lhs, uint2 rhs) => uint2.BitwiseOr(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of BitwiseAnd (lhs &amp; rhs).
        /// </summary>
        public static uint2 BitwiseAnd(uint2 lhs, uint2 rhs) => uint2.BitwiseAnd(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of LeftShift (lhs &lt;&lt; rhs).
        /// </summary>
        public static uint2 LeftShift(uint2 lhs, int2 rhs) => uint2.LeftShift(lhs, rhs);

        /// <summary>
        /// Returns a uint2 from component-wise application of RightShift (lhs &gt;&gt; rhs).
        /// </summary>
        public static uint2 RightShift(uint2 lhs, int2 rhs) => uint2.RightShift(lhs, rhs);

        /// <summary>
        /// Returns the minimal component of this vector.
        /// </summary>
        public static uint MinElement(uint2 v) => v.MinElement;

        /// <summary>
        /// Returns the maximal component of this vector.
        /// </summary>
        public static uint MaxElement(uint2 v) => v.MaxElement;

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(uint2 v) => v.Length;

        /// <summary>
        /// Returns the squared euclidean length of this vector.
        /// </summary>
        public static float LengthSqr(uint2 v) => v.LengthSqr;

        /// <summary>
        /// Returns the sum of all components.
        /// </summary>
        public static uint Sum(uint2 v) => v.Sum;

        /// <summary>
        /// Returns the euclidean norm of this vector.
        /// </summary>
        public static float Norm(uint2 v) => v.Norm;

        /// <summary>
        /// Returns the one-norm of this vector.
        /// </summary>
        public static float Norm1(uint2 v) => v.Norm1;

        /// <summary>
        /// Returns the two-norm (euclidean length) of this vector.
        /// </summary>
        public static float Norm2(uint2 v) => v.Norm2;

        /// <summary>
        /// Returns the max-norm of this vector.
        /// </summary>
        public static float NormMax(uint2 v) => v.NormMax;

        /// <summary>
        /// Returns the p-norm of this vector.
        /// </summary>
        public static double NormP(uint2 v, double p) => v.NormP(p);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static uint Dot(uint2 lhs, uint2 rhs) => uint2.Dot(lhs, rhs);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(uint2 lhs, uint2 rhs) => uint2.Distance(lhs, rhs);

        /// <summary>
        /// Returns the squared euclidean distance between the two vectors.
        /// </summary>
        public static float DistanceSqr(uint2 lhs, uint2 rhs) => uint2.DistanceSqr(lhs, rhs);

        /// <summary>
        /// Returns the length of the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static uint Cross(uint2 l, uint2 r) => uint2.Cross(l, r);

    }
}
