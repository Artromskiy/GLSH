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
    /// A matrix of type double with 3 columns and 2 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [InlineArray(3)]
    public struct double3x2
    {

        #region Fields
        
        /// <summary>
        /// First column of matrix
        /// </summary>
        private double2 _buffer;
        
        /// <summary>
        /// Returns the number of Fields (3 x 2 = 6).
        /// </summary>
        public const int Count = 6;

        #endregion


        #region Constructors
        
        /// <summary>
        /// Constructs diagonal matrix with scalar, non diagonal values are set to zero.
        /// </summary>
        public double3x2(double s)
        {
            this[0, 0] = 0;
            this[0, 1] = 0;
            this[1, 0] = 0;
            this[1, 1] = 0;
            this[2, 0] = 0;
            this[2, 1] = 0;
        }
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public double3x2(double m00, double m01, double m10, double m11, double m20, double m21)
        {
            this[0, 0] = m00;
            this[0, 1] = m01;
            this[1, 0] = m10;
            this[1, 1] = m11;
            this[2, 0] = m20;
            this[2, 1] = m21;
        }
        
        /// <summary>
        /// Constructs matrix from a series of column vectors.
        /// </summary>
        public double3x2(double2 v0, double2 v1, double2 v2)
        {
            this[0] = v0;
            this[1] = v1;
            this[2] = v2;
        }
        
        /// <summary>
        /// Constructs matrix from a double2x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double2x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
        }
        
        /// <summary>
        /// Constructs matrix from a double3x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double3x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }
        
        /// <summary>
        /// Constructs matrix from a double4x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double4x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }
        
        /// <summary>
        /// Constructs matrix from a double2x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double2x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
        }
        
        /// <summary>
        /// Constructs matrix from a double3x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double3x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }
        
        /// <summary>
        /// Constructs matrix from a double4x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double4x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }
        
        /// <summary>
        /// Constructs matrix from a double2x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double2x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
        }
        
        /// <summary>
        /// Constructs matrix from a double3x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double3x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }
        
        /// <summary>
        /// Constructs matrix from a double4x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x2(double4x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }

        #endregion


        #region Indexer
        
        /// <summary>
        /// Gets/Sets a specific indexed column.
        /// </summary>
        public double this[int col, int row]
        {
            get
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 2)
                    throw new ArgumentOutOfRangeException(nameof(row));
                return Unsafe.Add(ref Unsafe.As<double2, double>(ref _buffer), col * 2 + row);
            }
            set
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 2)
                    throw new ArgumentOutOfRangeException(nameof(row));
                Unsafe.Add(ref Unsafe.As<double2, double>(ref _buffer), col * 2 + row) = value;
            }
        }

        #endregion


        #region Operators
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x2 * double2x3 -> double2x2.
        /// </summary>
        public static double2x2 operator*(double3x2 lhs, double2x3 rhs) => new double2x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2]);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x2 * double3x3 -> double3x2.
        /// </summary>
        public static double3x2 operator*(double3x2 lhs, double3x3 rhs) => new double3x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2]);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x2 * double4x3 -> double4x2.
        /// </summary>
        public static double4x2 operator*(double3x2 lhs, double4x3 rhs) => new double4x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2], lhs[0, 0] * rhs[3, 0] + lhs[1, 0] * rhs[3, 1] + lhs[2, 0] * rhs[3, 2], lhs[0, 1] * rhs[3, 0] + lhs[1, 1] * rhs[3, 1] + lhs[2, 1] * rhs[3, 2]);
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static double2 operator*(double3x2 m, double3 v) => new double2(m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z, m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z);
        
        /// <summary>
        /// Executes a component-wise + (addition).
        /// </summary>
        public static double3x2 operator+(double3x2 lhs, double3x2 rhs) => new double3x2(lhs[0, 0] + rhs[0, 0], lhs[0, 1] + rhs[0, 1], lhs[1, 0] + rhs[1, 0], lhs[1, 1] + rhs[1, 1], lhs[2, 0] + rhs[2, 0], lhs[2, 1] + rhs[2, 1]);
        
        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static double3x2 operator+(double s, double3x2 m) => new double3x2(s + m[0, 0], s + m[0, 1], s + m[1, 0], s + m[1, 1], s + m[2, 0], s + m[2, 1]);
        
        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static double3x2 operator+(double3x2 m, double s) => new double3x2(m[0, 0] + s, m[0, 1] + s, m[1, 0] + s, m[1, 1] + s, m[2, 0] + s, m[2, 1] + s);
        
        /// <summary>
        /// Executes a component-wise - (subtraction).
        /// </summary>
        public static double3x2 operator-(double3x2 lhs, double3x2 rhs) => new double3x2(lhs[0, 0] - rhs[0, 0], lhs[0, 1] - rhs[0, 1], lhs[1, 0] - rhs[1, 0], lhs[1, 1] - rhs[1, 1], lhs[2, 0] - rhs[2, 0], lhs[2, 1] - rhs[2, 1]);
        
        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static double3x2 operator-(double s, double3x2 m) => new double3x2(s - m[0, 0], s - m[0, 1], s - m[1, 0], s - m[1, 1], s - m[2, 0], s - m[2, 1]);
        
        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static double3x2 operator-(double3x2 m, double s) => new double3x2(m[0, 0] - s, m[0, 1] - s, m[1, 0] - s, m[1, 1] - s, m[2, 0] - s, m[2, 1] - s);
        
        /// <summary>
        /// Executes a component-wise / (division).
        /// </summary>
        public static double3x2 operator/(double3x2 lhs, double3x2 rhs) => new double3x2(lhs[0, 0] / rhs[0, 0], lhs[0, 1] / rhs[0, 1], lhs[1, 0] / rhs[1, 0], lhs[1, 1] / rhs[1, 1], lhs[2, 0] / rhs[2, 0], lhs[2, 1] / rhs[2, 1]);
        
        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static double3x2 operator/(double s, double3x2 m) => new double3x2(s / m[0, 0], s / m[0, 1], s / m[1, 0], s / m[1, 1], s / m[2, 0], s / m[2, 1]);
        
        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static double3x2 operator/(double3x2 m, double s) => new double3x2(m[0, 0] / s, m[0, 1] / s, m[1, 0] / s, m[1, 1] / s, m[2, 0] / s, m[2, 1] / s);
        
        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static double3x2 operator*(double s, double3x2 m) => new double3x2(s * m[0, 0], s * m[0, 1], s * m[1, 0], s * m[1, 1], s * m[2, 0], s * m[2, 1]);
        
        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static double3x2 operator*(double3x2 m, double s) => new double3x2(m[0, 0] * s, m[0, 1] * s, m[1, 0] * s, m[1, 1] * s, m[2, 0] * s, m[2, 1] * s);

        #endregion


        #region Static Functions
        
        /// <summary>
        /// 
        /// </summary>
        public static double3x2 OuterProduct(double2 col, double3 row) => new double3x2(row.x * col.x, row.x * col.y, row.y * col.x, row.y * col.y, row.z * col.x, row.z * col.y);
        
        /// <summary>
        /// 
        /// </summary>
        public static double2x3 Transpose(double3x2 v) => new double2x3(v[0, 0], v[1, 0], v[2, 0], v[0, 1], v[1, 1], v[2, 1]);

        #endregion

    }
}
