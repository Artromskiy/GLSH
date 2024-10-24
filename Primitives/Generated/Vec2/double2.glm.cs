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
        public static double Length(double2 v) => double2.Length(v);

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(double2 lhs, double2 rhs) => double2.Distance(lhs, rhs);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static double Dot(double2 lhs, double2 rhs) => double2.Dot(lhs, rhs);

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static double2 Normalize(double2 v) => double2.Normalize(v);

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static double2 FaceForward(double2 N, double2 I, double2 Nref) => double2.FaceForward(N, I, Nref);

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double2 Reflect(double2 I, double2 N) => double2.Reflect(I, N);

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double2 Refract(double2 I, double2 N, double eta) => double2.Refract(I, N, eta);

        /// <summary>
        /// Returns a double2 from component-wise application of Sqrt (double.Sqrt(v)).
        /// </summary>
        public static double2 Sqrt(double2 v) => double2.Sqrt(v);

        /// <summary>
        /// Returns a double2 from component-wise application of InverseSqrt (double.ReciprocalSqrtEstimate(v)).
        /// </summary>
        public static double2 InverseSqrt(double2 v) => double2.InverseSqrt(v);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(double2 lhs, double2 rhs) => double2.GreaterThan(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(double2 lhs, double2 rhs) => double2.GreaterThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(double2 lhs, double2 rhs) => double2.LesserThan(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(double2 lhs, double2 rhs) => double2.LesserThanEqual(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(double2 lhs, double2 rhs) => double2.Equal(lhs, rhs);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(double2 lhs, double2 rhs) => double2.NotEqual(lhs, rhs);

        /// <summary>
        /// Returns a double2 from component-wise application of Abs (double.Abs(v)).
        /// </summary>
        public static double2 Abs(double2 v) => double2.Abs(v);

        /// <summary>
        /// Returns a double2 from component-wise application of Sign (double.Sign(v)).
        /// </summary>
        public static double2 Sign(double2 v) => double2.Sign(v);

        /// <summary>
        /// Returns a double2 from component-wise application of Floor (double.Floor(v)).
        /// </summary>
        public static double2 Floor(double2 v) => double2.Floor(v);

        /// <summary>
        /// Returns a double2 from component-wise application of Truncate (double.Truncate(v)).
        /// </summary>
        public static double2 Truncate(double2 v) => double2.Truncate(v);

        /// <summary>
        /// Returns a double2 from component-wise application of Round (double.Round(v)).
        /// </summary>
        public static double2 Round(double2 v) => double2.Round(v);

        /// <summary>
        /// Returns a double2 from component-wise application of RoundEven (double.Round(v, MidpointRounding.ToEven)).
        /// </summary>
        public static double2 RoundEven(double2 v) => double2.RoundEven(v);

        /// <summary>
        /// Returns a double2 from component-wise application of Ceiling (double.Ceiling(v)).
        /// </summary>
        public static double2 Ceiling(double2 v) => double2.Ceiling(v);

        /// <summary>
        /// Returns a double2 from component-wise application of Fract (v - double.Floor(v)).
        /// </summary>
        public static double2 Fract(double2 v) => double2.Fract(v);

        /// <summary>
        /// Returns a double2 from component-wise application of Mod (lhs - rhs * double.Floor(lhs / rhs)).
        /// </summary>
        public static double2 Mod(double2 lhs, double2 rhs) => double2.Mod(lhs, rhs);

        /// <summary>
        /// Returns a double2 from component-wise application of Lerp (double.Lerp(edge0, edge1, v)).
        /// </summary>
        public static double2 Lerp(double2 edge0, double2 edge1, double2 v) => double2.Lerp(edge0, edge1, v);

        /// <summary>
        /// Returns a double2 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static double2 Step(double2 edge, double2 x) => double2.Step(edge, x);

        /// <summary>
        /// Returns a double2 from component-wise application of Smoothstep (double.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static double2 Smoothstep(double2 edge0, double2 edge1, double2 v) => double2.Smoothstep(edge0, edge1, v);

        /// <summary>
        /// Returns a double2 from component-wise application of Min (double.Min(lhs, rhs)).
        /// </summary>
        public static double2 Min(double2 lhs, double2 rhs) => double2.Min(lhs, rhs);

        /// <summary>
        /// Returns a double2 from component-wise application of Max (double.Max(lhs, rhs)).
        /// </summary>
        public static double2 Max(double2 lhs, double2 rhs) => double2.Max(lhs, rhs);

        /// <summary>
        /// Returns a double2 from component-wise application of Clamp (double.Clamp(v, min, max)).
        /// </summary>
        public static double2 Clamp(double2 v, double2 min, double2 max) => double2.Clamp(v, min, max);

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (double.Clamp(v, min, max)).
        /// </summary>
        public static double2 Clamp(double2 v, double min, double max) => double2.Clamp(v, min, max);

        /// <summary>
        /// Returns a double2 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static double2 Mix(double2 x, double2 y, bool2 a) => double2.Mix(x, y, a);

        /// <summary>
        /// Returns a bool2 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool2 IsNaN(double2 v) => double2.IsNaN(v);

        /// <summary>
        /// Returns a bool2 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool2 IsInfinity(double2 v) => double2.IsInfinity(v);

        /// <summary>
        /// Returns a double2 from component-wise application of Fma (double.FusedMultiplyAdd(a, b, c)).
        /// </summary>
        public static double2 Fma(double2 a, double2 b, double2 c) => double2.Fma(a, b, c);

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public static string ToString(double2 v) => v.ToString();

    }
}
