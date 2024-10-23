using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace GLSH
{
    
    /// <summary>
    /// A vector of type double with 4 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct double4
    {

        #region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        public double x;
        
        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        public double y;
        
        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        public double z;
        
        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        public double w;
        
        /// <summary>
        /// Returns the number of components (4).
        /// </summary>
        [DataMember]
        public const int Count = 4;

        #endregion


        #region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public double4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public double4(double v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public double4(double2 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = 0.0;
            this.w = 0.0;
        }
        
        /// <summary>
        /// from-vector-and-value constructor (empty fields are zero/false)
        /// </summary>
        public double4(double2 v, double z)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = 0.0;
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public double4(double2 v, double z, double w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
            this.w = w;
        }
        
        /// <summary>
        /// from-vector constructor (empty fields are zero/false)
        /// </summary>
        public double4(double3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = 0.0;
        }
        
        /// <summary>
        /// from-vector-and-value constructor
        /// </summary>
        public double4(double3 v, double w)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = w;
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public double4(double4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        #endregion


        #region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public double this[int index]
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


        #region Operators
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator==(double4 lhs, double4 rhs) => lhs.x == rhs.x&&lhs.y == rhs.y&&lhs.z == rhs.z&&lhs.w == rhs.w;
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator!=(double4 lhs, double4 rhs) => lhs.x != rhs.x||lhs.y != rhs.y||lhs.z != rhs.z||lhs.w != rhs.w;

        #endregion


        #region Functions
        
        /// <summary>
        /// Returns a string representation of this vector using ', ' as a seperator.
        /// </summary>
        public override string ToString() => ToString(", ");
        
        /// <summary>
        /// Returns a string representation of this vector using a provided seperator.
        /// </summary>
        private string ToString(string sep) => ((x + sep + y) + sep + (z + sep + w));

        #endregion


        #region Static Functions
        
        /// <summary>
        /// Returns the euclidean length of this vector.
        /// </summary>
        public static double Length(double4 v) => double.Sqrt(((v.x*v.x + v.y*v.y) + (v.z*v.z + v.w*v.w)));
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(double4 lhs, double4 rhs) => double4.Length(lhs - rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static double Dot(double4 lhs, double4 rhs) => ((lhs.x * rhs.x + lhs.y * rhs.y) + (lhs.z * rhs.z + lhs.w * rhs.w));
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static double4 Normalize(double4 v) => v / double4.Length(v);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static double4 FaceForward(double4 N, double4 I, double4 Nref) => double4.Dot(Nref, I) < 0 ? N : -N;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double4 Reflect(double4 I, double4 N) => I - 2 * double4.Dot(N, I) * N;
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double4 Refract(double4 I, double4 N, double eta)
        {
            var dNI = double4.Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return new double4((double)0);
            return eta * I - (eta * dNI + double.Sqrt(k)) * N;
        }

        #endregion


        #region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a double4 from component-wise application of Sqrt (double.Sqrt(v)).
        /// </summary>
        public static double4 Sqrt(double4 v) => new double4(double.Sqrt(v.x), double.Sqrt(v.y), double.Sqrt(v.z), double.Sqrt(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of InverseSqrt (double.ReciprocalSqrtEstimate(v)).
        /// </summary>
        public static double4 InverseSqrt(double4 v) => new double4(double.ReciprocalSqrtEstimate(v.x), double.ReciprocalSqrtEstimate(v.y), double.ReciprocalSqrtEstimate(v.z), double.ReciprocalSqrtEstimate(v.w));
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool4 GreaterThan(double4 lhs, double4 rhs) => new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool4 GreaterThanEqual(double4 lhs, double4 rhs) => new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool4 LesserThan(double4 lhs, double4 rhs) => new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool4 LesserThanEqual(double4 lhs, double4 rhs) => new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool4 Equal(double4 lhs, double4 rhs) => new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool4 NotEqual(double4 lhs, double4 rhs) => new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of Abs (double.Abs(v)).
        /// </summary>
        public static double4 Abs(double4 v) => new double4(double.Abs(v.x), double.Abs(v.y), double.Abs(v.z), double.Abs(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Sign (double.Sign(v)).
        /// </summary>
        public static double4 Sign(double4 v) => new double4(double.Sign(v.x), double.Sign(v.y), double.Sign(v.z), double.Sign(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Floor (double.Floor(v)).
        /// </summary>
        public static double4 Floor(double4 v) => new double4(double.Floor(v.x), double.Floor(v.y), double.Floor(v.z), double.Floor(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Truncate (double.Truncate(v)).
        /// </summary>
        public static double4 Truncate(double4 v) => new double4(double.Truncate(v.x), double.Truncate(v.y), double.Truncate(v.z), double.Truncate(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Round (double.Round(v)).
        /// </summary>
        public static double4 Round(double4 v) => new double4(double.Round(v.x), double.Round(v.y), double.Round(v.z), double.Round(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of RoundEven (double.Round(v, MidpointRounding.ToEven)).
        /// </summary>
        public static double4 RoundEven(double4 v) => new double4(double.Round(v.x, MidpointRounding.ToEven), double.Round(v.y, MidpointRounding.ToEven), double.Round(v.z, MidpointRounding.ToEven), double.Round(v.w, MidpointRounding.ToEven));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Ceiling (double.Ceiling(v)).
        /// </summary>
        public static double4 Ceiling(double4 v) => new double4(double.Ceiling(v.x), double.Ceiling(v.y), double.Ceiling(v.z), double.Ceiling(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Fract (v - double.Floor(v)).
        /// </summary>
        public static double4 Fract(double4 v) => new double4(v.x - double.Floor(v.x), v.y - double.Floor(v.y), v.z - double.Floor(v.z), v.w - double.Floor(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Mod (lhs - rhs * double.Floor(lhs / rhs)).
        /// </summary>
        public static double4 Mod(double4 lhs, double4 rhs) => new double4(lhs.x - rhs.x * double.Floor(lhs.x / rhs.x), lhs.y - rhs.y * double.Floor(lhs.y / rhs.y), lhs.z - rhs.z * double.Floor(lhs.z / rhs.z), lhs.w - rhs.w * double.Floor(lhs.w / rhs.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Mod (lhs - rhs * double.Floor(lhs / rhs)).
        /// </summary>
        public static double4 Mod(double4 lhs, double rhs) => new double4(lhs.x - rhs * double.Floor(lhs.x / rhs), lhs.y - rhs * double.Floor(lhs.y / rhs), lhs.z - rhs * double.Floor(lhs.z / rhs), lhs.w - rhs * double.Floor(lhs.w / rhs));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (double.Lerp(edge0, edge1, v)).
        /// </summary>
        public static double4 Lerp(double4 edge0, double4 edge1, double4 v) => new double4(double.Lerp(edge0.x, edge1.x, v.x), double.Lerp(edge0.y, edge1.y, v.y), double.Lerp(edge0.z, edge1.z, v.z), double.Lerp(edge0.w, edge1.w, v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Lerp (double.Lerp(edge0, edge1, v)).
        /// </summary>
        public static double4 Lerp(double4 edge0, double4 edge1, double v) => new double4(double.Lerp(edge0.x, edge1.x, v), double.Lerp(edge0.y, edge1.y, v), double.Lerp(edge0.z, edge1.z, v), double.Lerp(edge0.w, edge1.w, v));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static double4 Step(double4 edge, double4 x) => new double4(x.x < edge.x ? 0 : 1, x.y < edge.y ? 0 : 1, x.z < edge.z ? 0 : 1, x.w < edge.w ? 0 : 1);
        
        /// <summary>
        /// Returns a double4 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static double4 Step(double edge, double4 x) => new double4(x.x < edge ? 0 : 1, x.y < edge ? 0 : 1, x.z < edge ? 0 : 1, x.w < edge ? 0 : 1);
        
        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (double.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double4 edge0, double4 edge1, double4 v) => new double4(double.Clamp((v.x - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), double.Clamp((v.y - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3(), double.Clamp((v.z - edge0.z) / (edge1.z - edge0.z), 0, 1).HermiteInterpolationOrder3(), double.Clamp((v.w - edge0.w) / (edge1.w - edge0.w), 0, 1).HermiteInterpolationOrder3());
        
        /// <summary>
        /// Returns a double4 from component-wise application of Smoothstep (double.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static double4 Smoothstep(double4 edge0, double4 edge1, double v) => new double4(double.Clamp((v - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), double.Clamp((v - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3(), double.Clamp((v - edge0.z) / (edge1.z - edge0.z), 0, 1).HermiteInterpolationOrder3(), double.Clamp((v - edge0.w) / (edge1.w - edge0.w), 0, 1).HermiteInterpolationOrder3());
        
        /// <summary>
        /// Returns a double4 from component-wise application of Min (double.Min(lhs, rhs)).
        /// </summary>
        public static double4 Min(double4 lhs, double4 rhs) => new double4(double.Min(lhs.x, rhs.x), double.Min(lhs.y, rhs.y), double.Min(lhs.z, rhs.z), double.Min(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Min (double.Min(lhs, rhs)).
        /// </summary>
        public static double4 Min(double4 lhs, double rhs) => new double4(double.Min(lhs.x, rhs), double.Min(lhs.y, rhs), double.Min(lhs.z, rhs), double.Min(lhs.w, rhs));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Max (double.Max(lhs, rhs)).
        /// </summary>
        public static double4 Max(double4 lhs, double4 rhs) => new double4(double.Max(lhs.x, rhs.x), double.Max(lhs.y, rhs.y), double.Max(lhs.z, rhs.z), double.Max(lhs.w, rhs.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Max (double.Max(lhs, rhs)).
        /// </summary>
        public static double4 Max(double4 lhs, double rhs) => new double4(double.Max(lhs.x, rhs), double.Max(lhs.y, rhs), double.Max(lhs.z, rhs), double.Max(lhs.w, rhs));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Clamp (double.Clamp(v, min, max)).
        /// </summary>
        public static double4 Clamp(double4 v, double4 min, double4 max) => new double4(double.Clamp(v.x, min.x, max.x), double.Clamp(v.y, min.y, max.y), double.Clamp(v.z, min.z, max.z), double.Clamp(v.w, min.w, max.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static double4 Mix(double4 x, double4 y, bool4 a) => new double4(a.x ? y.x : x.x, a.y ? y.y : x.y, a.z ? y.z : x.z, a.w ? y.w : x.w);
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool4 IsNaN(double4 v) => new bool4(double.IsNaN(v.x), double.IsNaN(v.y), double.IsNaN(v.z), double.IsNaN(v.w));
        
        /// <summary>
        /// Returns a bool4 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool4 IsInfinity(double4 v) => new bool4(double.IsInfinity(v.x), double.IsInfinity(v.y), double.IsInfinity(v.z), double.IsInfinity(v.w));
        
        /// <summary>
        /// Returns a double4 from component-wise application of Fma (double.FusedMultiplyAdd(a, b, c)).
        /// </summary>
        public static double4 Fma(double4 a, double4 b, double4 c) => new double4(double.FusedMultiplyAdd(a.x, b.x, c.x), double.FusedMultiplyAdd(a.y, b.y, c.y), double.FusedMultiplyAdd(a.z, b.z, c.z), double.FusedMultiplyAdd(a.w, b.w, c.w));

        #endregion


        #region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator- (-v).
        /// </summary>
        public static double4 operator-(double4 v) => new double4(-v.x, -v.y, -v.z, -v.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double4 operator+(double4 lhs, double4 rhs) => new double4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double4 operator+(double4 lhs, double rhs) => new double4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double4 operator+(double lhs, double4 rhs) => new double4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double4 operator-(double4 lhs, double4 rhs) => new double4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double4 operator-(double4 lhs, double rhs) => new double4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double4 operator-(double lhs, double4 rhs) => new double4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double4 operator*(double4 lhs, double4 rhs) => new double4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double4 operator*(double4 lhs, double rhs) => new double4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double4 operator*(double lhs, double4 rhs) => new double4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double4 operator/(double4 lhs, double4 rhs) => new double4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double4 operator/(double4 lhs, double rhs) => new double4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        
        /// <summary>
        /// Returns a double4 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double4 operator/(double lhs, double4 rhs) => new double4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w);

        #endregion

    }
}
