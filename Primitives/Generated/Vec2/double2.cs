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
    /// A vector of type double with 2 components.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "vec")]
    [StructLayout(LayoutKind.Sequential)]
    public struct double2
    {

        #region Fields
        
        /// <summary>
        /// x-component
        /// </summary>
        public double x;
        
        /// <summary>
        /// y-component
        /// </summary>
        public double y;
        
        /// <summary>
        /// Returns the number of components (2).
        /// </summary>
        public const int Count = 2;

        #endregion


        #region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public double2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        
        /// <summary>
        /// all-same-value constructor
        /// </summary>
        public double2(double v)
        {
            this.x = v;
            this.y = v;
        }
        
        /// <summary>
        /// from-vector constructor
        /// </summary>
        public double2(double2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public double2(double3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        
        /// <summary>
        /// from-vector constructor (additional fields are truncated)
        /// </summary>
        public double2(double4 v)
        {
            this.x = v.x;
            this.y = v.y;
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


        #region Properties
        
        /// <summary>
        /// Gets or sets the specified subset of components.
        /// </summary>
        public double2 xy
        {
            get
            {
                return new double2(x, y);
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
        public double2 rg
        {
            get
            {
                return new double2(x, y);
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
        public double r
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
        public double g
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
        public static bool operator==(double2 lhs, double2 rhs) => lhs.x == rhs.x&&lhs.y == rhs.y;
        
        /// <summary>
        /// 
        /// </summary>
        public static bool operator!=(double2 lhs, double2 rhs) => lhs.x != rhs.x||lhs.y != rhs.y;

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
        public static double Length(double2 v) => double.Sqrt((v.x*v.x + v.y*v.y));
        
        /// <summary>
        /// Returns the euclidean distance between the two vectors.
        /// </summary>
        public static double Distance(double2 lhs, double2 rhs) => double2.Length(lhs - rhs);
        
        /// <summary>
        /// Returns the inner product (dot product, scalar product) of the two vectors.
        /// </summary>
        public static double Dot(double2 lhs, double2 rhs) => (lhs.x * rhs.x + lhs.y * rhs.y);
        
        /// <summary>
        /// Returns a copy of this vector with length one (undefined if this has zero length).
        /// </summary>
        public static double2 Normalize(double2 v) => v / double2.Length(v);
        
        /// <summary>
        /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
        /// </summary>
        public static double2 FaceForward(double2 N, double2 I, double2 Nref) => double2.Dot(Nref, I) < 0 ? N : -N;
        
        /// <summary>
        /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double2 Reflect(double2 I, double2 N) => I - 2 * double2.Dot(N, I) * N;
        
        /// <summary>
        /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
        /// </summary>
        public static double2 Refract(double2 I, double2 N, double eta)
        {
            var dNI = double2.Dot(N, I);
            var k = 1 - eta * eta * (1 - dNI * dNI);
            if (k < 0) return new double2((double)0);
            return eta * I - (eta * dNI + double.Sqrt(k)) * N;
        }
        
        /// <summary>
        /// Returns a double2 from component-wise application of Clamp (double.Clamp(v, min, max)).
        /// </summary>
        public static double2 Clamp(double2 v, double min, double max) => new double2(double.Clamp(v.x, min, max), double.Clamp(v.y, min, max));

        #endregion


        #region Component-Wise Static Functions
        
        /// <summary>
        /// Returns a double2 from component-wise application of Sqrt (double.Sqrt(v)).
        /// </summary>
        public static double2 Sqrt(double2 v) => new double2(double.Sqrt(v.x), double.Sqrt(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of InverseSqrt (double.ReciprocalSqrtEstimate(v)).
        /// </summary>
        public static double2 InverseSqrt(double2 v) => new double2(double.ReciprocalSqrtEstimate(v.x), double.ReciprocalSqrtEstimate(v.y));
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThan (lhs &lt; rhs).
        /// </summary>
        public static bool2 LesserThan(double2 lhs, double2 rhs) => new bool2(lhs.x < rhs.x, lhs.y < rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of LesserThanEqual (lhs &lt;= rhs).
        /// </summary>
        public static bool2 LesserThanEqual(double2 lhs, double2 rhs) => new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThan (lhs &gt; rhs).
        /// </summary>
        public static bool2 GreaterThan(double2 lhs, double2 rhs) => new bool2(lhs.x > rhs.x, lhs.y > rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of GreaterThanEqual (lhs &gt;= rhs).
        /// </summary>
        public static bool2 GreaterThanEqual(double2 lhs, double2 rhs) => new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of Equal (lhs == rhs).
        /// </summary>
        public static bool2 Equal(double2 lhs, double2 rhs) => new bool2(lhs.x == rhs.x, lhs.y == rhs.y);
        
        /// <summary>
        /// Returns a bool2 from component-wise application of NotEqual (lhs != rhs).
        /// </summary>
        public static bool2 NotEqual(double2 lhs, double2 rhs) => new bool2(lhs.x != rhs.x, lhs.y != rhs.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Abs (double.Abs(v)).
        /// </summary>
        public static double2 Abs(double2 v) => new double2(double.Abs(v.x), double.Abs(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Sign (double.Sign(v)).
        /// </summary>
        public static double2 Sign(double2 v) => new double2(double.Sign(v.x), double.Sign(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Floor (double.Floor(v)).
        /// </summary>
        public static double2 Floor(double2 v) => new double2(double.Floor(v.x), double.Floor(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Truncate (double.Truncate(v)).
        /// </summary>
        public static double2 Truncate(double2 v) => new double2(double.Truncate(v.x), double.Truncate(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Round (double.Round(v)).
        /// </summary>
        public static double2 Round(double2 v) => new double2(double.Round(v.x), double.Round(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of RoundEven (double.Round(v, MidpointRounding.ToEven)).
        /// </summary>
        public static double2 RoundEven(double2 v) => new double2(double.Round(v.x, MidpointRounding.ToEven), double.Round(v.y, MidpointRounding.ToEven));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Ceiling (double.Ceiling(v)).
        /// </summary>
        public static double2 Ceiling(double2 v) => new double2(double.Ceiling(v.x), double.Ceiling(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Fract (v - double.Floor(v)).
        /// </summary>
        public static double2 Fract(double2 v) => new double2(v.x - double.Floor(v.x), v.y - double.Floor(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Mod (lhs - rhs * double.Floor(lhs / rhs)).
        /// </summary>
        public static double2 Mod(double2 lhs, double2 rhs) => new double2(lhs.x - rhs.x * double.Floor(lhs.x / rhs.x), lhs.y - rhs.y * double.Floor(lhs.y / rhs.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Mod (lhs - rhs * double.Floor(lhs / rhs)).
        /// </summary>
        public static double2 Mod(double2 lhs, double rhs) => new double2(lhs.x - rhs * double.Floor(lhs.x / rhs), lhs.y - rhs * double.Floor(lhs.y / rhs));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Lerp (double.Lerp(edge0, edge1, v)).
        /// </summary>
        public static double2 Lerp(double2 edge0, double2 edge1, double2 v) => new double2(double.Lerp(edge0.x, edge1.x, v.x), double.Lerp(edge0.y, edge1.y, v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Lerp (double.Lerp(edge0, edge1, v)).
        /// </summary>
        public static double2 Lerp(double2 edge0, double2 edge1, double v) => new double2(double.Lerp(edge0.x, edge1.x, v), double.Lerp(edge0.y, edge1.y, v));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static double2 Step(double2 edge, double2 x) => new double2(x.x < edge.x ? 0 : 1, x.y < edge.y ? 0 : 1);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Step (x &lt; edge ? 0 : 1).
        /// </summary>
        public static double2 Step(double edge, double2 x) => new double2(x.x < edge ? 0 : 1, x.y < edge ? 0 : 1);
        
        /// <summary>
        /// Returns a double2 from component-wise application of Smoothstep (double.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static double2 Smoothstep(double2 edge0, double2 edge1, double2 v) => new double2(double.Clamp((v.x - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), double.Clamp((v.y - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3());
        
        /// <summary>
        /// Returns a double2 from component-wise application of Smoothstep (double.Clamp((v - edge0) / (edge1 - edge0), 0, 1).HermiteInterpolationOrder3()).
        /// </summary>
        public static double2 Smoothstep(double2 edge0, double2 edge1, double v) => new double2(double.Clamp((v - edge0.x) / (edge1.x - edge0.x), 0, 1).HermiteInterpolationOrder3(), double.Clamp((v - edge0.y) / (edge1.y - edge0.y), 0, 1).HermiteInterpolationOrder3());
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsNaN (double.IsNaN(v)).
        /// </summary>
        public static bool2 IsNaN(double2 v) => new bool2(double.IsNaN(v.x), double.IsNaN(v.y));
        
        /// <summary>
        /// Returns a bool2 from component-wise application of IsInfinity (double.IsInfinity(v)).
        /// </summary>
        public static bool2 IsInfinity(double2 v) => new bool2(double.IsInfinity(v.x), double.IsInfinity(v.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Fma (double.FusedMultiplyAdd(a, b, c)).
        /// </summary>
        public static double2 Fma(double2 a, double2 b, double2 c) => new double2(double.FusedMultiplyAdd(a.x, b.x, c.x), double.FusedMultiplyAdd(a.y, b.y, c.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Min (double.Min(lhs, rhs)).
        /// </summary>
        public static double2 Min(double2 lhs, double2 rhs) => new double2(double.Min(lhs.x, rhs.x), double.Min(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Min (double.Min(lhs, rhs)).
        /// </summary>
        public static double2 Min(double2 lhs, double rhs) => new double2(double.Min(lhs.x, rhs), double.Min(lhs.y, rhs));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Max (double.Max(lhs, rhs)).
        /// </summary>
        public static double2 Max(double2 lhs, double2 rhs) => new double2(double.Max(lhs.x, rhs.x), double.Max(lhs.y, rhs.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Max (double.Max(lhs, rhs)).
        /// </summary>
        public static double2 Max(double2 lhs, double rhs) => new double2(double.Max(lhs.x, rhs), double.Max(lhs.y, rhs));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Clamp (double.Clamp(v, min, max)).
        /// </summary>
        public static double2 Clamp(double2 v, double2 min, double2 max) => new double2(double.Clamp(v.x, min.x, max.x), double.Clamp(v.y, min.y, max.y));
        
        /// <summary>
        /// Returns a double2 from component-wise application of Mix (a ? y : x).
        /// </summary>
        public static double2 Mix(double2 x, double2 y, bool2 a) => new double2(a.x ? y.x : x.x, a.y ? y.y : x.y);

        #endregion


        #region Component-Wise Operator Overloads
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator- (-v).
        /// </summary>
        public static double2 operator-(double2 v) => new double2(-v.x, -v.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double2 operator+(double2 lhs, double2 rhs) => new double2(lhs.x + rhs.x, lhs.y + rhs.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double2 operator+(double2 lhs, double rhs) => new double2(lhs.x + rhs, lhs.y + rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator+ (lhs + rhs).
        /// </summary>
        public static double2 operator+(double lhs, double2 rhs) => new double2(lhs + rhs.x, lhs + rhs.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double2 operator-(double2 lhs, double2 rhs) => new double2(lhs.x - rhs.x, lhs.y - rhs.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double2 operator-(double2 lhs, double rhs) => new double2(lhs.x - rhs, lhs.y - rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator- (lhs - rhs).
        /// </summary>
        public static double2 operator-(double lhs, double2 rhs) => new double2(lhs - rhs.x, lhs - rhs.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double2 operator*(double2 lhs, double2 rhs) => new double2(lhs.x * rhs.x, lhs.y * rhs.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double2 operator*(double2 lhs, double rhs) => new double2(lhs.x * rhs, lhs.y * rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator* (lhs * rhs).
        /// </summary>
        public static double2 operator*(double lhs, double2 rhs) => new double2(lhs * rhs.x, lhs * rhs.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double2 operator/(double2 lhs, double2 rhs) => new double2(lhs.x / rhs.x, lhs.y / rhs.y);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double2 operator/(double2 lhs, double rhs) => new double2(lhs.x / rhs, lhs.y / rhs);
        
        /// <summary>
        /// Returns a double2 from component-wise application of operator/ (lhs / rhs).
        /// </summary>
        public static double2 operator/(double lhs, double2 rhs) => new double2(lhs / rhs.x, lhs / rhs.y);

        #endregion

    }
}
