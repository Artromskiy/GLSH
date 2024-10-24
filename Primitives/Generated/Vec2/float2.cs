using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A vector of type float with 2 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct float2
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public float x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public float y;

        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        [DataMember]
        public const int Count = 2;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public float2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public float2(float v)
        {
            this.x = v;
            this.y = v;
        }

        /// <summary>
        /// from-vector constructor
        /// </summary>
        public float2(float2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public float2(float3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public float2(float4 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        #endregion


        #region Implicit Operators

        /// <summary>
        /// Implicitly converts this to a double2.
        /// </summary>
        public static implicit operator double2(float2 v) => new double2(v.x, v.y);

        #endregion


        #region Indexer

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public float this[int index]
        {
            get
            {
                if ((uint)index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return Unsafe.Add(ref x, index);
            }
            set
            {
                if ((uint)index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                Unsafe.Add(ref x, index) = value;
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the specified subset of components.
        /// </summary>
        public float2 xy
        {
            get
            {
                return new float2(x, y);
            }
            set
            {
                x = value.x;
                y = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified subset of components.
        /// </summary>
        public float2 rg
        {
            get
            {
                return new float2(x, y);
            }
            set
            {
                x = value.x;
                y = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the specified RGBA component.
        /// </summary>
        public float r
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Gets or sets the specified RGBA component.
        /// </summary>
        public float g
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        #endregion


        #region Operators

        /// <summary>
        /// 
        /// </summary>
        public static bool operator ==(float2 lhs, float2 rhs) => lhs.x == rhs.x && lhs.y == rhs.y;

        /// <summary>
        /// 
        /// </summary>
        public static bool operator !=(float2 lhs, float2 rhs) => lhs.x != rhs.x || lhs.y != rhs.y;

        #endregion


        #region Functions

        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public override string ToString() => ToString(", ");

        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        private string ToString(string sep) => (x + sep + y);

        #endregion


        #region Static Functions

        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static float Length(float2 v) => float.Sqrt((v.x * v.x + v.y * v.y));

        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static float Distance(float2 lhs, float2 rhs) => float2.Length(lhs - rhs);

        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static float Dot(float2 lhs, float2 rhs) => (lhs.x * rhs.x + lhs.y * rhs.y);

        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static float2 Normalize(float2 v) => v / float2.Length(v);

        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static float2 FaceForward(float2 N, float2 I, float2 Nref) => float2.Dot(Nref, I) < 0 ? N : -N;

        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float2 Reflect(float2 I, float2 N) => I - 2 * float2.Dot(N, I) * N;

        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static float2 Refract(float2 I, float2 N, float eta)
        {
            var dNI = float2.Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return new float2(0);
            return eta * I - (eta * dNI + float.Sqrt(k)) * N;
        }

        /// <summary>
        /// Returns a int4 from component-wise application of Clamp (float.Clamp(v, min, max)).
        /// </summary>
        public static float2 Clamp(float2 v, float min, float max) => new float2(float.Clamp(v.x, min, max), float.Clamp(v.y, min, max));

        #endregion


        #region Component-Wise Static Functions

        /// <summary>
        /// Returns a float2 from component-wise application of Radians (float.DegreesToRadians(v)).
        /// </summary>
        public static float2 Radians(float2 v) => new float2(float.DegreesToRadians(v.x), float.DegreesToRadians(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Degrees (float.RadiansToDegrees(v)).
        /// </summary>
        public static float2 Degrees(float2 v) => new float2(float.RadiansToDegrees(v.x), float.RadiansToDegrees(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Sin (float.Sin(v)).
        /// </summary>
        public static float2 Sin(float2 v) => new float2(float.Sin(v.x), float.Sin(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Cos (float.Cos(v)).
        /// </summary>
        public static float2 Cos(float2 v) => new float2(float.Cos(v.x), float.Cos(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Tan (float.Tan(v)).
        /// </summary>
        public static float2 Tan(float2 v) => new float2(float.Tan(v.x), float.Tan(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Asin (float.Asin(v)).
        /// </summary>
        public static float2 Asin(float2 v) => new float2(float.Asin(v.x), float.Asin(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Acos (float.Acos(v)).
        /// </summary>
        public static float2 Acos(float2 v) => new float2(float.Acos(v.x), float.Acos(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Atan (float.Atan(y / x)).
        /// </summary>
        public static float2 Atan(float2 y, float2 x) => new float2(float.Atan(y.x / x.x), float.Atan(y.y / x.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Atan (float.Atan(v)).
        /// </summary>
        public static float2 Atan(float2 v) => new float2(float.Atan(v.x), float.Atan(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Sinh (float.Sinh(v)).
        /// </summary>
        public static float2 Sinh(float2 v) => new float2(float.Sinh(v.x), float.Sinh(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Cosh (float.Cosh(v)).
        /// </summary>
        public static float2 Cosh(float2 v) => new float2(float.Cosh(v.x), float.Cosh(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Tanh (float.Tanh(v)).
        /// </summary>
        public static float2 Tanh(float2 v) => new float2(float.Tanh(v.x), float.Tanh(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Asinh (float.Asinh(v)).
        /// </summary>
        public static float2 Asinh(float2 v) => new float2(float.Asinh(v.x), float.Asinh(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Acosh (float.Acosh(v)).
        /// </summary>
        public static float2 Acosh(float2 v) => new float2(float.Acosh(v.x), float.Acosh(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Atanh (float.Atanh(v)).
        /// </summary>
        public static float2 Atanh(float2 v) => new float2(float.Atanh(v.x), float.Atanh(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Pow (float.Pow(lhs, rhs)).
        /// </summary>
        public static float2 Pow(float2 lhs, float2 rhs) => new float2(float.Pow(lhs.x, rhs.x), float.Pow(lhs.y, rhs.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Exp (float.Exp(v)).
        /// </summary>
        public static float2 Exp(float2 v) => new float2(float.Exp(v.x), float.Exp(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Log (float.Log(v)).
        /// </summary>
        public static float2 Log(float2 v) => new float2(float.Log(v.x), float.Log(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Exp2 (float.Exp2(v)).
        /// </summary>
        public static float2 Exp2(float2 v) => new float2(float.Exp2(v.x), float.Exp2(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Log2 (float.Log2(v)).
        /// </summary>
        public static float2 Log2(float2 v) => new float2(float.Log2(v.x), float.Log2(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Sqrt (float.Sqrt(v)).
        /// </summary>
        public static float2 Sqrt(float2 v) => new float2(float.Sqrt(v.x), float.Sqrt(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of InverseSqrt (float.ReciprocalSqrtEstimate(v)).
        /// </summary>
        public static float2 InverseSqrt(float2 v) => new float2(float.ReciprocalSqrtEstimate(v.x), float.ReciprocalSqrtEstimate(v.y));

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(float2 lhs, float2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(float2 lhs, float2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(float2 lhs, float2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(float2 lhs, float2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(float2 lhs, float2 rhs) => new bool2(lhs.x == rhs.x, lhs.y == rhs.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(float2 lhs, float2 rhs) => new bool2(lhs.x != rhs.x, lhs.y != rhs.y);

        /// <summary>
        /// Returns a float2 from component-wise application of Abs (float.Abs(v)).
        /// </summary>
        public static float2 Abs(float2 v) => new float2(float.Abs(v.x), float.Abs(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Sign (float.Sign(v)).
        /// </summary>
        public static float2 Sign(float2 v) => new float2(float.Sign(v.x), float.Sign(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Floor (float.Floor(v)).
        /// </summary>
        public static float2 Floor(float2 v) => new float2(float.Floor(v.x), float.Floor(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Truncate (float.Truncate(v)).
        /// </summary>
        public static float2 Truncate(float2 v) => new float2(float.Truncate(v.x), float.Truncate(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Round (float.Round(v)).
        /// </summary>
        public static float2 Round(float2 v) => new float2(float.Round(v.x), float.Round(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of RoundEven (float.Round(v, MidpointRounding.ToEven)).
        /// </summary>
        public static float2 RoundEven(float2 v) => new float2(float.Round(v.x, MidpointRounding.ToEven), float.Round(v.y, MidpointRounding.ToEven));

        /// <summary>
        /// Returns a float2 from component-wise application of Ceiling (float.Ceiling(v)).
        /// </summary>
        public static float2 Ceiling(float2 v) => new float2(float.Ceiling(v.x), float.Ceiling(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Fract (v - float.Floor(v)).
        /// </summary>
        public static float2 Fract(float2 v) => new float2(v.x - float.Floor(v.x), v.y - float.Floor(v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Mod (lhs - rhs * float.Floor(lhs / rhs)).
        /// </summary>
        public static float2 Mod(float2 lhs, float2 rhs) => new float2(lhs.x - rhs.x * float.Floor(lhs.x / rhs.x), lhs.y - rhs.y * float.Floor(lhs.y / rhs.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Mod (lhs - rhs * float.Floor(lhs / rhs)).
        /// </summary>
        public static float2 Mod(float2 lhs, float rhs) => new float2(lhs.x - rhs * float.Floor(lhs.x / rhs), lhs.y - rhs * float.Floor(lhs.y / rhs));

        /// <summary>
        /// Returns a float2 from component-wise application of Lerp (float.Lerp(edge0, edge1, v)).
        /// </summary>
        public static float2 Lerp(float2 edge0, float2 edge1, float2 v) => new float2(float.Lerp(edge0.x, edge1.x, v.x), float.Lerp(edge0.y, edge1.y, v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Lerp (float.Lerp(edge0, edge1, v)).
        /// </summary>
        public static float2 Lerp(float2 edge0, float2 edge1, float v) => new float2(float.Lerp(edge0.x, edge1.x, v), float.Lerp(edge0.y, edge1.y, v));

        /// <summary>
        /// Returns a float2 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static float2 Step(float2 edge, float2 x) => new float2(x.x < edge.x ? 0 : 1, x.y < edge.y ? 0 : 1);

        /// <summary>
        /// Returns a float2 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static float2 Step(float edge, float2 x) => new float2(x.x < edge ? 0 : 1, x.y < edge ? 0 : 1);

        /// <summary>
        /// Returns a float2 from component-wise application of Smoothstep (float.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static float2 Smoothstep(float2 edge0, float2 edge1, float2 v) => new float2(float.Clamp((v.x - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v.y - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float2 from component-wise application of Smoothstep (float.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static float2 Smoothstep(float2 edge0, float2 edge1, float v) => new float2(float.Clamp((v - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), float.Clamp((v - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3());

        /// <summary>
        /// Returns a float2 from component-wise application of Min (float.Min(lhs, rhs)).
        /// </summary>
        public static float2 Min(float2 lhs, float2 rhs) => new float2(float.Min(lhs.x, rhs.x), float.Min(lhs.y, rhs.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Min (float.Min(lhs, rhs)).
        /// </summary>
        public static float2 Min(float2 lhs, float rhs) => new float2(float.Min(lhs.x, rhs), float.Min(lhs.y, rhs));

        /// <summary>
        /// Returns a float2 from component-wise application of Max (float.Max(lhs, rhs)).
        /// </summary>
        public static float2 Max(float2 lhs, float2 rhs) => new float2(float.Max(lhs.x, rhs.x), float.Max(lhs.y, rhs.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Max (float.Max(lhs, rhs)).
        /// </summary>
        public static float2 Max(float2 lhs, float rhs) => new float2(float.Max(lhs.x, rhs), float.Max(lhs.y, rhs));

        /// <summary>
        /// Returns a float2 from component-wise application of Clamp (float.Clamp(v, min, max)).
        /// </summary>
        public static float2 Clamp(float2 v, float2 min, float2 max) => new float2(float.Clamp(v.x, min.x, max.x), float.Clamp(v.y, min.y, max.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static float2 Mix(float2 x, float2 y, bool2 a) => new float2(a.x ? y.x : x.x, a.y ? y.y : x.y);

        /// <summary>
        /// Returns a bool2 from component-wise application of IsNaN (float.IsNaN(v)).
        /// </summary>
        public static bool2 IsNaN(float2 v) => new bool2(float.IsNaN(v.x), float.IsNaN(v.y));

        /// <summary>
        /// Returns a bool2 from component-wise application of IsInfinity (float.IsInfinity(v)).
        /// </summary>
        public static bool2 IsInfinity(float2 v) => new bool2(float.IsInfinity(v.x), float.IsInfinity(v.y));

        /// <summary>
        /// Returns a int2 from component-wise application of FloatBitsToInt (Unsafe.As&lt;float, int&gt;(ref v)).
        /// </summary>
        public static int2 FloatBitsToInt(float2 v) => new int2(Unsafe.As<float, int>(ref v.x), Unsafe.As<float, int>(ref v.y));

        /// <summary>
        /// Returns a uint2 from component-wise application of FloatBitsToUInt (Unsafe.As&lt;float, uint&gt;(ref v)).
        /// </summary>
        public static uint2 FloatBitsToUInt(float2 v) => new uint2(Unsafe.As<float, uint>(ref v.x), Unsafe.As<float, uint>(ref v.y));

        /// <summary>
        /// Returns a float2 from component-wise application of Fma (float.FusedMultiplyAdd(a, b, c)).
        /// </summary>
        public static float2 Fma(float2 a, float2 b, float2 c) => new float2(float.FusedMultiplyAdd(a.x, b.x, c.x), float.FusedMultiplyAdd(a.y, b.y, c.y));

        #endregion


        #region Component-Wise Operator Overloads

        /// <summary>
        /// Returns a float2 from component-wise application of operator- (-v).
        /// </summary>
        public static float2 operator -(float2 v) => new float2(-v.x, -v.y);

        /// <summary>
        /// Returns a float2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float2 operator +(float2 lhs, float2 rhs) => new float2(lhs.x + rhs.x, lhs.y + rhs.y);

        /// <summary>
        /// Returns a float2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float2 operator +(float2 lhs, float rhs) => new float2(lhs.x + rhs, lhs.y + rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static float2 operator +(float lhs, float2 rhs) => new float2(lhs + rhs.x, lhs + rhs.y);

        /// <summary>
        /// Returns a float2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float2 operator -(float2 lhs, float2 rhs) => new float2(lhs.x - rhs.x, lhs.y - rhs.y);

        /// <summary>
        /// Returns a float2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float2 operator -(float2 lhs, float rhs) => new float2(lhs.x - rhs, lhs.y - rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static float2 operator -(float lhs, float2 rhs) => new float2(lhs - rhs.x, lhs - rhs.y);

        /// <summary>
        /// Returns a float2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float2 operator *(float2 lhs, float2 rhs) => new float2(lhs.x * rhs.x, lhs.y * rhs.y);

        /// <summary>
        /// Returns a float2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float2 operator *(float2 lhs, float rhs) => new float2(lhs.x * rhs, lhs.y * rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static float2 operator *(float lhs, float2 rhs) => new float2(lhs * rhs.x, lhs * rhs.y);

        /// <summary>
        /// Returns a float2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float2 operator /(float2 lhs, float2 rhs) => new float2(lhs.x / rhs.x, lhs.y / rhs.y);

        /// <summary>
        /// Returns a float2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float2 operator /(float2 lhs, float rhs) => new float2(lhs.x / rhs, lhs.y / rhs);

        /// <summary>
        /// Returns a float2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static float2 operator /(float lhs, float2 rhs) => new float2(lhs / rhs.x, lhs / rhs.y);

        #endregion

    }
}
