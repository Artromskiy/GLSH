using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A matrix of type double with 3 columns and 3 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct double3x3
    {

        #region Fields

        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        [DataMember]
        private double m00;

        /// <summary>
        /// Column 0, Rows 1
        /// </summary>
        [DataMember]
        private double m01;

        /// <summary>
        /// Column 0, Rows 2
        /// </summary>
        [DataMember]
        private double m02;

        /// <summary>
        /// Column 1, Rows 0
        /// </summary>
        [DataMember]
        private double m10;

        /// <summary>
        /// Column 1, Rows 1
        /// </summary>
        [DataMember]
        private double m11;

        /// <summary>
        /// Column 1, Rows 2
        /// </summary>
        [DataMember]
        private double m12;

        /// <summary>
        /// Column 2, Rows 0
        /// </summary>
        [DataMember]
        private double m20;

        /// <summary>
        /// Column 2, Rows 1
        /// </summary>
        [DataMember]
        private double m21;

        /// <summary>
        /// Column 2, Rows 2
        /// </summary>
        [DataMember]
        private double m22;

        /// <summary>
        /// Returns the number of Fields (3 x 3 = 9).
        /// </summary>
        [DataMember]
        public const int Count = 9;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructs diagonal matrix with scalar, non diagonal values are set to zero.
        /// </summary>
        public double3x3(double s)
        {
            this[0, 0] = 0;
            this[0, 1] = 0;
            this[0, 2] = 0;
            this[1, 0] = 0;
            this[1, 1] = 0;
            this[1, 2] = 0;
            this[2, 0] = 0;
            this[2, 1] = 0;
            this[2, 2] = 0;
        }

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public double3x3(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22)
        {
            this[0, 0] = m00;
            this[0, 1] = m01;
            this[0, 2] = m02;
            this[1, 0] = m10;
            this[1, 1] = m11;
            this[1, 2] = m12;
            this[2, 0] = m20;
            this[2, 1] = m21;
            this[2, 2] = m22;
        }

        /// <summary>
        /// Constructs matrix from a series of column vectors.
        /// </summary>
        public double3x3(double3 v0, double3 v1, double3 v2)
        {
            this[0] = v0;
            this[1] = v1;
            this[2] = v2;
        }

        /// <summary>
        /// Constructs matrix from a double2x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double2x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[2, 2] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double3x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
        }

        /// <summary>
        /// Constructs matrix from a double4x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double4x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
        }

        /// <summary>
        /// Constructs matrix from a double2x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double2x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[2, 2] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double3x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
        }

        /// <summary>
        /// Constructs matrix from a double4x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double4x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
        }

        /// <summary>
        /// Constructs matrix from a double2x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double2x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[2, 2] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double3x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
        }

        /// <summary>
        /// Constructs matrix from a double4x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double4x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
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
                if ((uint)row >= 3)
                    throw new ArgumentOutOfRangeException(nameof(row));
                return Unsafe.Add(ref m00, col * 3 + row);
            }
            set
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 3)
                    throw new ArgumentOutOfRangeException(nameof(row));
                Unsafe.Add(ref m00, col * 3 + row) = value;
            }
        }

        /// <summary>
        /// Gets/Sets a specific indexed component.
        /// </summary>
        public double3 this[int col]
        {
            get
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                return MemoryMarshal.Cast<double3x3, double3>(new Span<double3x3>(ref this))[col];
            }
            set
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                MemoryMarshal.Cast<double3x3, double3>(new Span<double3x3>(ref this))[col] = value;
            }
        }

        #endregion


        #region Operators

        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x3 * double2x3 -> double2x3.
        /// </summary>
        public static double2x3 operator *(double3x3 lhs, double2x3 rhs) => new double2x3(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2]);

        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x3 * double3x3 -> double3x3.
        /// </summary>
        public static double3x3 operator *(double3x3 lhs, double3x3 rhs) => new double3x3(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2], lhs[0, 2] * rhs[2, 0] + lhs[1, 2] * rhs[2, 1] + lhs[2, 2] * rhs[2, 2]);

        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x3 * double4x3 -> double4x3.
        /// </summary>
        public static double4x3 operator *(double3x3 lhs, double4x3 rhs) => new double4x3(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2], lhs[0, 2] * rhs[2, 0] + lhs[1, 2] * rhs[2, 1] + lhs[2, 2] * rhs[2, 2], lhs[0, 0] * rhs[3, 0] + lhs[1, 0] * rhs[3, 1] + lhs[2, 0] * rhs[3, 2], lhs[0, 1] * rhs[3, 0] + lhs[1, 1] * rhs[3, 1] + lhs[2, 1] * rhs[3, 2], lhs[0, 2] * rhs[3, 0] + lhs[1, 2] * rhs[3, 1] + lhs[2, 2] * rhs[3, 2]);

        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static double3 operator *(double3x3 m, double3 v) => new double3(m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z, m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z, m[0, 2] * v.x + m[1, 2] * v.y + m[2, 2] * v.z);

        /// <summary>
        /// Executes a component-wise + (addition).
        /// </summary>
        public static double3x3 operator +(double3x3 lhs, double3x3 rhs) => new double3x3(lhs[0, 0] + rhs[0, 0], lhs[0, 1] + rhs[0, 1], lhs[0, 2] + rhs[0, 2], lhs[1, 0] + rhs[1, 0], lhs[1, 1] + rhs[1, 1], lhs[1, 2] + rhs[1, 2], lhs[2, 0] + rhs[2, 0], lhs[2, 1] + rhs[2, 1], lhs[2, 2] + rhs[2, 2]);

        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static double3x3 operator +(double s, double3x3 m) => new double3x3(s + m[0, 0], s + m[0, 1], s + m[0, 2], s + m[1, 0], s + m[1, 1], s + m[1, 2], s + m[2, 0], s + m[2, 1], s + m[2, 2]);

        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static double3x3 operator +(double3x3 m, double s) => new double3x3(m[0, 0] + s, m[0, 1] + s, m[0, 2] + s, m[1, 0] + s, m[1, 1] + s, m[1, 2] + s, m[2, 0] + s, m[2, 1] + s, m[2, 2] + s);

        /// <summary>
        /// Executes a component-wise - (subtraction).
        /// </summary>
        public static double3x3 operator -(double3x3 lhs, double3x3 rhs) => new double3x3(lhs[0, 0] - rhs[0, 0], lhs[0, 1] - rhs[0, 1], lhs[0, 2] - rhs[0, 2], lhs[1, 0] - rhs[1, 0], lhs[1, 1] - rhs[1, 1], lhs[1, 2] - rhs[1, 2], lhs[2, 0] - rhs[2, 0], lhs[2, 1] - rhs[2, 1], lhs[2, 2] - rhs[2, 2]);

        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static double3x3 operator -(double s, double3x3 m) => new double3x3(s - m[0, 0], s - m[0, 1], s - m[0, 2], s - m[1, 0], s - m[1, 1], s - m[1, 2], s - m[2, 0], s - m[2, 1], s - m[2, 2]);

        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static double3x3 operator -(double3x3 m, double s) => new double3x3(m[0, 0] - s, m[0, 1] - s, m[0, 2] - s, m[1, 0] - s, m[1, 1] - s, m[1, 2] - s, m[2, 0] - s, m[2, 1] - s, m[2, 2] - s);

        /// <summary>
        /// Executes a component-wise / (division).
        /// </summary>
        public static double3x3 operator /(double3x3 lhs, double3x3 rhs) => new double3x3(lhs[0, 0] / rhs[0, 0], lhs[0, 1] / rhs[0, 1], lhs[0, 2] / rhs[0, 2], lhs[1, 0] / rhs[1, 0], lhs[1, 1] / rhs[1, 1], lhs[1, 2] / rhs[1, 2], lhs[2, 0] / rhs[2, 0], lhs[2, 1] / rhs[2, 1], lhs[2, 2] / rhs[2, 2]);

        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static double3x3 operator /(double s, double3x3 m) => new double3x3(s / m[0, 0], s / m[0, 1], s / m[0, 2], s / m[1, 0], s / m[1, 1], s / m[1, 2], s / m[2, 0], s / m[2, 1], s / m[2, 2]);

        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static double3x3 operator /(double3x3 m, double s) => new double3x3(m[0, 0] / s, m[0, 1] / s, m[0, 2] / s, m[1, 0] / s, m[1, 1] / s, m[1, 2] / s, m[2, 0] / s, m[2, 1] / s, m[2, 2] / s);

        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static double3x3 operator *(double s, double3x3 m) => new double3x3(s * m[0, 0], s * m[0, 1], s * m[0, 2], s * m[1, 0], s * m[1, 1], s * m[1, 2], s * m[2, 0], s * m[2, 1], s * m[2, 2]);

        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static double3x3 operator *(double3x3 m, double s) => new double3x3(m[0, 0] * s, m[0, 1] * s, m[0, 2] * s, m[1, 0] * s, m[1, 1] * s, m[1, 2] * s, m[2, 0] * s, m[2, 1] * s, m[2, 2] * s);

        #endregion


        #region Static Functions

        /// <summary>
        /// 
        /// </summary>
        public static double3x3 OuterProduct(double3 col, double3 row) => new double3x3(row.x * col.x, row.x * col.y, row.x * col.z, row.y * col.x, row.y * col.y, row.y * col.z, row.z * col.x, row.z * col.y, row.z * col.z);

        /// <summary>
        /// 
        /// </summary>
        public static double3x3 Transpose(double3x3 v) => new double3x3(v[0, 0], v[1, 0], v[2, 0], v[0, 1], v[1, 1], v[2, 1], v[0, 2], v[1, 2], v[2, 2]);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public static double3x3 Inverse(double3x3 v) => double3x3.Adjugate(v) / double3x3.Determinant(v);

        /// <summary>
        /// 
        /// </summary>
        public static double Determinant(double3x3 v) => v.m00 * (v.m11 * v.m22 - v.m21 * v.m12) - v.m10 * (v.m01 * v.m22 - v.m21 * v.m02) + v.m20 * (v.m01 * v.m12 - v.m11 * v.m02);

        /// <summary>
        /// Executes a matrix-matrix-divison A / B == A * B^-1 (use with caution).
        /// </summary>
        private static double3x3 Divide(double3x3 A, double3x3 B) => A * double3x3.Inverse(B);

        /// <summary>
        /// 
        /// </summary>
        private static double3x3 Adjugate(double3x3 v) => new double3x3(v.m11 * v.m22 - v.m21 * v.m12, v.m01 * v.m22 + v.m21 * v.m02, v.m01 * v.m12 - v.m11 * v.m02, v.m11 * v.m22 - v.m21 * v.m12, v.m01 * v.m22 + v.m21 * v.m02, v.m01 * v.m12 - v.m11 * v.m02, v.m11 * v.m22 - v.m21 * v.m12, v.m01 * v.m22 + v.m21 * v.m02, v.m01 * v.m12 - v.m11 * v.m02);

        #endregion

    }
}
