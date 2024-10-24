// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static double Length(double3 v) => double3.Length(v);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(double3 lhs, double3 rhs) => double3.Distance(lhs, rhs);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static double Dot(double3 lhs, double3 rhs) => double3.Dot(lhs, rhs);

        /// <summary>
        /// Returns the outer product (cross product, vector product) of the two vectors.
        /// </summary>
        public static double3 Cross(double3 lhs, double3 rhs) => double3.Cross(lhs, rhs);

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static double3 Normalize(double3 v) => double3.Normalize(v);

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static double3 FaceForward(double3 N, double3 I, double3 Nref) => double3.FaceForward(N, I, Nref);

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double3 Reflect(double3 I, double3 N) => double3.Reflect(I, N);

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double3 Refract(double3 I, double3 N, double eta) => double3.Refract(I, N, eta);

        /// <summary>
        /// Returns a double3 from component-wise application of Sqrt (double.Sqrt(v)).
        /// </summary>
        public static double3 Sqrt(double3 v) => double3.Sqrt(v);

        /// <summary>
        /// Returns a double3 from component-wise application of InverseSqrt (double.ReciprocalSqrtEstimate(v)).
        /// </summary>
        public static double3 InverseSqrt(double3 v) => double3.InverseSqrt(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool3 GreaterThan(double3 lhs, double3 rhs) => double3.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool3 GreaterThanEqual(double3 lhs, double3 rhs) => double3.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool3 LesserThan(double3 lhs, double3 rhs) => double3.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool3 LesserThanEqual(double3 lhs, double3 rhs) => double3.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool3 Equal(double3 lhs, double3 rhs) => double3.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool3 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool3 NotEqual(double3 lhs, double3 rhs) => double3.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Abs (double.Abs(v)).
        /// </summary>
        public static double3 Abs(double3 v) => double3.Abs(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Sign (double.Sign(v)).
        /// </summary>
        public static double3 Sign(double3 v) => double3.Sign(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Floor (double.Floor(v)).
        /// </summary>
        public static double3 Floor(double3 v) => double3.Floor(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Truncate (double.Truncate(v)).
        /// </summary>
        public static double3 Truncate(double3 v) => double3.Truncate(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Round (double.Round(v)).
        /// </summary>
        public static double3 Round(double3 v) => double3.Round(v);

        /// <summary>
        /// Returns a double3 from component-wise application of RoundEven (double.Round(v, MidpointRounding.ToEven)).
        /// </summary>
        public static double3 RoundEven(double3 v) => double3.RoundEven(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Ceiling (double.Ceiling(v)).
        /// </summary>
        public static double3 Ceiling(double3 v) => double3.Ceiling(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Fract (v - double.Floor(v)).
        /// </summary>
        public static double3 Fract(double3 v) => double3.Fract(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Mod (lhs - rhs * double.Floor(lhs / rhs)).
        /// </summary>
        public static double3 Mod(double3 lhs, double3 rhs) => double3.Mod(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Lerp (double.Lerp(edge0, edge1, v)).
        /// </summary>
        public static double3 Lerp(double3 edge0, double3 edge1, double3 v) => double3.Lerp(edge0, edge1, v);

        /// <summary>
        /// Returns a double3 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static double3 Step(double3 edge, double3 x) => double3.Step(edge, x);

        /// <summary>
        /// Returns a double3 from component-wise application of Smoothstep (double.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static double3 Smoothstep(double3 edge0, double3 edge1, double3 v) => double3.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a double3 from component-wise application of Min (double.Min(lhs, rhs)).
        /// </summary>
        public static double3 Min(double3 lhs, double3 rhs) => double3.Min(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Max (double.Max(lhs, rhs)).
        /// </summary>
        public static double3 Max(double3 lhs, double3 rhs) => double3.Max(lhs, rhs);

        /// <summary>
        /// Returns a double3 from component-wise application of Clamp (double.Clamp(v, min, max)).
        /// </summary>
        public static double3 Clamp(double3 v, double3 min, double3 max) => double3.Clamp(v, min, max);

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (double.Clamp(v, min, max)).
        /// </summary>
        public static double3 Clamp(double3 v, double min, double max) => double3.Clamp(v, min, max);

        /// <summary>
        /// Returns a double3 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static double3 Mix(double3 x, double3 y, bool3 a) => double3.Mix(x, y, a);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool3 IsNaN(double3 v) => double3.IsNaN(v);

        /// <summary>
        /// Returns a bool3 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool3 IsInfinity(double3 v) => double3.IsInfinity(v);

        /// <summary>
        /// Returns a double3 from component-wise application of Fma (double.FusedMultiplyAdd(a, b, c)).
        /// </summary>
        public static double3 Fma(double3 a, double3 b, double3 c) => double3.Fma(a, b, c);

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(double3 v) => v.ToString();

    }
}
