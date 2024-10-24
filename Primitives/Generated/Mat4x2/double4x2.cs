using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A matrix of type double with 4 columns and 2 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct double4x2
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
        /// Column 3, Rows 0
        /// </summary>
        [DataMember]
        private double m30;

        /// <summary>
        /// Column 3, Rows 1
        /// </summary>
        [DataMember]
        private double m31;

        /// <summary>
        /// Returns the number of Fields (4 x 2 = 8).
        /// </summary>
        [DataMember]
        public const int Count = 8;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructs diagonal matrix with scalar, non diagonal values are set to zero.
        /// </summary>
        public double4x2(double s)
        {
            this[0, 0] = 0;
            this[0, 1] = 0;
            this[1, 0] = 0;
            this[1, 1] = 0;
            this[2, 0] = 0;
            this[2, 1] = 0;
            this[3, 0] = 0;
            this[3, 1] = 0;
        }

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public double4x2(double m00, double m01, double m10, double m11, double m20, double m21, double m30, double m31)
        {
            this[0, 0] = m00;
            this[0, 1] = m01;
            this[1, 0] = m10;
            this[1, 1] = m11;
            this[2, 0] = m20;
            this[2, 1] = m21;
            this[3, 0] = m30;
            this[3, 1] = m31;
        }

        /// <summary>
        /// Constructs matrix from a series of column vectors.
        /// </summary>
        public double4x2(double2 v0, double2 v1, double2 v2, double2 v3)
        {
            this[0] = v0;
            this[1] = v1;
            this[2] = v2;
            this[3] = v3;
        }

        /// <summary>
        /// Constructs matrix from a double2x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double2x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double3x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double4x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double4x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[3, 0] = m[3, 0];
            this[3, 1] = m[3, 1];
        }

        /// <summary>
        /// Constructs matrix from a double2x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double2x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double3x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double4x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double4x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[3, 0] = m[3, 0];
            this[3, 1] = m[3, 1];
        }

        /// <summary>
        /// Constructs matrix from a double2x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double2x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double3x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double4x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x2(double4x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[3, 0] = m[3, 0];
            this[3, 1] = m[3, 1];
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
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 2)
                    throw new ArgumentOutOfRangeException(nameof(row));
                return Unsafe.Add(ref m00, col * 2 + row);
            }
            set
            {
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 2)
                    throw new ArgumentOutOfRangeException(nameof(row));
                Unsafe.Add(ref m00, col * 2 + row) = value;
            }
        }

        /// <summary>
        /// Gets/Sets a specific indexed component.
        /// </summary>
        public double2 this[int col]
        {
            get
            {
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                return MemoryMarshal.Cast<double4x2, double2>(new Span<double4x2>(ref this))[col];
            }
            set
            {
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                MemoryMarshal.Cast<double4x2, double2>(new Span<double4x2>(ref this))[col] = value;
            }
        }

        #endregion


        #region Operators

        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x2 * double2x4 -> double2x2.
        /// </summary>
        public static double2x2 operator *(double4x2 lhs, double2x4 rhs) => new double2x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3]);

        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x2 * double3x4 -> double3x2.
        /// </summary>
        public static double3x2 operator *(double4x2 lhs, double3x4 rhs) => new double3x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2] + lhs[3, 0] * rhs[2, 3], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2] + lhs[3, 1] * rhs[2, 3]);

        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x2 * double4x4 -> double4x2.
        /// </summary>
        public static double4x2 operator *(double4x2 lhs, double4x4 rhs) => new double4x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2] + lhs[3, 0] * rhs[2, 3], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2] + lhs[3, 1] * rhs[2, 3], lhs[0, 0] * rhs[3, 0] + lhs[1, 0] * rhs[3, 1] + lhs[2, 0] * rhs[3, 2] + lhs[3, 0] * rhs[3, 3], lhs[0, 1] * rhs[3, 0] + lhs[1, 1] * rhs[3, 1] + lhs[2, 1] * rhs[3, 2] + lhs[3, 1] * rhs[3, 3]);

        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static double2 operator *(double4x2 m, double4 v) => new double2(m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z + m[3, 0] * v.w, m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z + m[3, 1] * v.w);

        /// <summary>
        /// Executes a component-wise + (addition).
        /// </summary>
        public static double4x2 operator +(double4x2 lhs, double4x2 rhs) => new double4x2(lhs[0, 0] + rhs[0, 0], lhs[0, 1] + rhs[0, 1], lhs[1, 0] + rhs[1, 0], lhs[1, 1] + rhs[1, 1], lhs[2, 0] + rhs[2, 0], lhs[2, 1] + rhs[2, 1], lhs[3, 0] + rhs[3, 0], lhs[3, 1] + rhs[3, 1]);

        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static double4x2 operator +(double s, double4x2 m) => new double4x2(s + m[0, 0], s + m[0, 1], s + m[1, 0], s + m[1, 1], s + m[2, 0], s + m[2, 1], s + m[3, 0], s + m[3, 1]);

        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static double4x2 operator +(double4x2 m, double s) => new double4x2(m[0, 0] + s, m[0, 1] + s, m[1, 0] + s, m[1, 1] + s, m[2, 0] + s, m[2, 1] + s, m[3, 0] + s, m[3, 1] + s);

        /// <summary>
        /// Executes a component-wise - (subtraction).
        /// </summary>
        public static double4x2 operator -(double4x2 lhs, double4x2 rhs) => new double4x2(lhs[0, 0] - rhs[0, 0], lhs[0, 1] - rhs[0, 1], lhs[1, 0] - rhs[1, 0], lhs[1, 1] - rhs[1, 1], lhs[2, 0] - rhs[2, 0], lhs[2, 1] - rhs[2, 1], lhs[3, 0] - rhs[3, 0], lhs[3, 1] - rhs[3, 1]);

        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static double4x2 operator -(double s, double4x2 m) => new double4x2(s - m[0, 0], s - m[0, 1], s - m[1, 0], s - m[1, 1], s - m[2, 0], s - m[2, 1], s - m[3, 0], s - m[3, 1]);

        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static double4x2 operator -(double4x2 m, double s) => new double4x2(m[0, 0] - s, m[0, 1] - s, m[1, 0] - s, m[1, 1] - s, m[2, 0] - s, m[2, 1] - s, m[3, 0] - s, m[3, 1] - s);

        /// <summary>
        /// Executes a component-wise / (division).
        /// </summary>
        public static double4x2 operator /(double4x2 lhs, double4x2 rhs) => new double4x2(lhs[0, 0] / rhs[0, 0], lhs[0, 1] / rhs[0, 1], lhs[1, 0] / rhs[1, 0], lhs[1, 1] / rhs[1, 1], lhs[2, 0] / rhs[2, 0], lhs[2, 1] / rhs[2, 1], lhs[3, 0] / rhs[3, 0], lhs[3, 1] / rhs[3, 1]);

        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static double4x2 operator /(double s, double4x2 m) => new double4x2(s / m[0, 0], s / m[0, 1], s / m[1, 0], s / m[1, 1], s / m[2, 0], s / m[2, 1], s / m[3, 0], s / m[3, 1]);

        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static double4x2 operator /(double4x2 m, double s) => new double4x2(m[0, 0] / s, m[0, 1] / s, m[1, 0] / s, m[1, 1] / s, m[2, 0] / s, m[2, 1] / s, m[3, 0] / s, m[3, 1] / s);

        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static double4x2 operator *(double s, double4x2 m) => new double4x2(s * m[0, 0], s * m[0, 1], s * m[1, 0], s * m[1, 1], s * m[2, 0], s * m[2, 1], s * m[3, 0], s * m[3, 1]);

        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static double4x2 operator *(double4x2 m, double s) => new double4x2(m[0, 0] * s, m[0, 1] * s, m[1, 0] * s, m[1, 1] * s, m[2, 0] * s, m[2, 1] * s, m[3, 0] * s, m[3, 1] * s);

        #endregion


        #region Static Functions

        /// <summary>
        /// 
        /// </summary>
        public static double4x2 OuterProduct(double2 col, double4 row) => new double4x2(row.x * col.x, row.x * col.y, row.y * col.x, row.y * col.y, row.z * col.x, row.z * col.y, row.w * col.x, row.w * col.y);

        /// <summary>
        /// 
        /// </summary>
        public static double2x4 Transpose(double4x2 v) => new double2x4(v[0, 0], v[1, 0], v[2, 0], v[3, 0], v[0, 1], v[1, 1], v[2, 1], v[3, 1]);

        #endregion

    }
}
