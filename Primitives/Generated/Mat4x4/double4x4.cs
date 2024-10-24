using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A matrix of type double with 4 columns and 4 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct double4x4
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
        /// Column 0, Rows 3
        /// </summary>
        [DataMember]
        private double m03;

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
        /// Column 1, Rows 3
        /// </summary>
        [DataMember]
        private double m13;

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
        /// Column 2, Rows 3
        /// </summary>
        [DataMember]
        private double m23;

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
        /// Column 3, Rows 2
        /// </summary>
        [DataMember]
        private double m32;

        /// <summary>
        /// Column 3, Rows 3
        /// </summary>
        [DataMember]
        private double m33;

        /// <summary>
        /// Returns the number of Fields (4 x 4 = 16).
        /// </summary>
        [DataMember]
        public const int Count = 16;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructs diagonal matrix with scalar, non diagonal values are set to zero.
        /// </summary>
        public double4x4(double s)
        {
            this[0, 0] = 0;
            this[0, 1] = 0;
            this[0, 2] = 0;
            this[0, 3] = 0;
            this[1, 0] = 0;
            this[1, 1] = 0;
            this[1, 2] = 0;
            this[1, 3] = 0;
            this[2, 0] = 0;
            this[2, 1] = 0;
            this[2, 2] = 0;
            this[2, 3] = 0;
            this[3, 0] = 0;
            this[3, 1] = 0;
            this[3, 2] = 0;
            this[3, 3] = 0;
        }

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public double4x4(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23, double m30, double m31, double m32, double m33)
        {
            this[0, 0] = m00;
            this[0, 1] = m01;
            this[0, 2] = m02;
            this[0, 3] = m03;
            this[1, 0] = m10;
            this[1, 1] = m11;
            this[1, 2] = m12;
            this[1, 3] = m13;
            this[2, 0] = m20;
            this[2, 1] = m21;
            this[2, 2] = m22;
            this[2, 3] = m23;
            this[3, 0] = m30;
            this[3, 1] = m31;
            this[3, 2] = m32;
            this[3, 3] = m33;
        }

        /// <summary>
        /// Constructs matrix from a series of column vectors.
        /// </summary>
        public double4x4(double4 v0, double4 v1, double4 v2, double4 v3)
        {
            this[0] = v0;
            this[1] = v1;
            this[2] = v2;
            this[3] = v3;
        }

        /// <summary>
        /// Constructs matrix from a double2x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double2x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[2, 2] = 0.0;
            this[2, 3] = 0.0;
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
            this[3, 2] = 0.0;
            this[3, 3] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double3x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
            this[2, 3] = m[2, 3];
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
            this[3, 2] = 0.0;
            this[3, 3] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double4x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double4x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
            this[2, 3] = m[2, 3];
            this[3, 0] = m[3, 0];
            this[3, 1] = m[3, 1];
            this[3, 2] = m[3, 2];
            this[3, 3] = m[3, 3];
        }

        /// <summary>
        /// Constructs matrix from a double2x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double2x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[2, 2] = 0.0;
            this[2, 3] = 0.0;
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
            this[3, 2] = 0.0;
            this[3, 3] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double3x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
            this[2, 3] = m[2, 3];
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
            this[3, 2] = 0.0;
            this[3, 3] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double4x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double4x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
            this[2, 3] = m[2, 3];
            this[3, 0] = m[3, 0];
            this[3, 1] = m[3, 1];
            this[3, 2] = m[3, 2];
            this[3, 3] = m[3, 3];
        }

        /// <summary>
        /// Constructs matrix from a double2x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double2x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = 0.0;
            this[2, 1] = 0.0;
            this[2, 2] = 0.0;
            this[2, 3] = 0.0;
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
            this[3, 2] = 0.0;
            this[3, 3] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double3x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double3x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
            this[2, 3] = m[2, 3];
            this[3, 0] = 0.0;
            this[3, 1] = 0.0;
            this[3, 2] = 0.0;
            this[3, 3] = 0.0;
        }

        /// <summary>
        /// Constructs matrix from a double4x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double4x4(double4x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
            this[2, 2] = m[2, 2];
            this[2, 3] = m[2, 3];
            this[3, 0] = m[3, 0];
            this[3, 1] = m[3, 1];
            this[3, 2] = m[3, 2];
            this[3, 3] = m[3, 3];
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
                if ((uint)row >= 4)
                    throw new ArgumentOutOfRangeException(nameof(row));
                return Unsafe.Add(ref m00, col * 4 + row);
            }
            set
            {
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 4)
                    throw new ArgumentOutOfRangeException(nameof(row));
                Unsafe.Add(ref m00, col * 4 + row) = value;
            }
        }

        /// <summary>
        /// Gets/Sets a specific indexed component.
        /// </summary>
        public double4 this[int col]
        {
            get
            {
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                return MemoryMarshal.Cast<double4x4, double4>(new Span<double4x4>(ref this))[col];
            }
            set
            {
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                MemoryMarshal.Cast<double4x4, double4>(new Span<double4x4>(ref this))[col] = value;
            }
        }

        #endregion


        #region Operators

        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x4 * double2x4 -> double2x4.
        /// </summary>
        public static double2x4 operator *(double4x4 lhs, double2x4 rhs) => new double2x4(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2] + lhs[3, 2] * rhs[0, 3], lhs[0, 3] * rhs[0, 0] + lhs[1, 3] * rhs[0, 1] + lhs[2, 3] * rhs[0, 2] + lhs[3, 3] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2] + lhs[3, 2] * rhs[1, 3], lhs[0, 3] * rhs[1, 0] + lhs[1, 3] * rhs[1, 1] + lhs[2, 3] * rhs[1, 2] + lhs[3, 3] * rhs[1, 3]);

        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x4 * double3x4 -> double3x4.
        /// </summary>
        public static double3x4 operator *(double4x4 lhs, double3x4 rhs) => new double3x4(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2] + lhs[3, 2] * rhs[0, 3], lhs[0, 3] * rhs[0, 0] + lhs[1, 3] * rhs[0, 1] + lhs[2, 3] * rhs[0, 2] + lhs[3, 3] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2] + lhs[3, 2] * rhs[1, 3], lhs[0, 3] * rhs[1, 0] + lhs[1, 3] * rhs[1, 1] + lhs[2, 3] * rhs[1, 2] + lhs[3, 3] * rhs[1, 3], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2] + lhs[3, 0] * rhs[2, 3], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2] + lhs[3, 1] * rhs[2, 3], lhs[0, 2] * rhs[2, 0] + lhs[1, 2] * rhs[2, 1] + lhs[2, 2] * rhs[2, 2] + lhs[3, 2] * rhs[2, 3], lhs[0, 3] * rhs[2, 0] + lhs[1, 3] * rhs[2, 1] + lhs[2, 3] * rhs[2, 2] + lhs[3, 3] * rhs[2, 3]);

        /// <summary>
        /// Executes a matrix-matrix-multiplication double4x4 * double4x4 -> double4x4.
        /// </summary>
        public static double4x4 operator *(double4x4 lhs, double4x4 rhs) => new double4x4(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2] + lhs[3, 2] * rhs[0, 3], lhs[0, 3] * rhs[0, 0] + lhs[1, 3] * rhs[0, 1] + lhs[2, 3] * rhs[0, 2] + lhs[3, 3] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2] + lhs[3, 2] * rhs[1, 3], lhs[0, 3] * rhs[1, 0] + lhs[1, 3] * rhs[1, 1] + lhs[2, 3] * rhs[1, 2] + lhs[3, 3] * rhs[1, 3], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2] + lhs[3, 0] * rhs[2, 3], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2] + lhs[3, 1] * rhs[2, 3], lhs[0, 2] * rhs[2, 0] + lhs[1, 2] * rhs[2, 1] + lhs[2, 2] * rhs[2, 2] + lhs[3, 2] * rhs[2, 3], lhs[0, 3] * rhs[2, 0] + lhs[1, 3] * rhs[2, 1] + lhs[2, 3] * rhs[2, 2] + lhs[3, 3] * rhs[2, 3], lhs[0, 0] * rhs[3, 0] + lhs[1, 0] * rhs[3, 1] + lhs[2, 0] * rhs[3, 2] + lhs[3, 0] * rhs[3, 3], lhs[0, 1] * rhs[3, 0] + lhs[1, 1] * rhs[3, 1] + lhs[2, 1] * rhs[3, 2] + lhs[3, 1] * rhs[3, 3], lhs[0, 2] * rhs[3, 0] + lhs[1, 2] * rhs[3, 1] + lhs[2, 2] * rhs[3, 2] + lhs[3, 2] * rhs[3, 3], lhs[0, 3] * rhs[3, 0] + lhs[1, 3] * rhs[3, 1] + lhs[2, 3] * rhs[3, 2] + lhs[3, 3] * rhs[3, 3]);

        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static double4 operator *(double4x4 m, double4 v) => new double4(m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z + m[3, 0] * v.w, m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z + m[3, 1] * v.w, m[0, 2] * v.x + m[1, 2] * v.y + m[2, 2] * v.z + m[3, 2] * v.w, m[0, 3] * v.x + m[1, 3] * v.y + m[2, 3] * v.z + m[3, 3] * v.w);

        /// <summary>
        /// Executes a component-wise + (addition).
        /// </summary>
        public static double4x4 operator +(double4x4 lhs, double4x4 rhs) => new double4x4(lhs[0, 0] + rhs[0, 0], lhs[0, 1] + rhs[0, 1], lhs[0, 2] + rhs[0, 2], lhs[0, 3] + rhs[0, 3], lhs[1, 0] + rhs[1, 0], lhs[1, 1] + rhs[1, 1], lhs[1, 2] + rhs[1, 2], lhs[1, 3] + rhs[1, 3], lhs[2, 0] + rhs[2, 0], lhs[2, 1] + rhs[2, 1], lhs[2, 2] + rhs[2, 2], lhs[2, 3] + rhs[2, 3], lhs[3, 0] + rhs[3, 0], lhs[3, 1] + rhs[3, 1], lhs[3, 2] + rhs[3, 2], lhs[3, 3] + rhs[3, 3]);

        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static double4x4 operator +(double s, double4x4 m) => new double4x4(s + m[0, 0], s + m[0, 1], s + m[0, 2], s + m[0, 3], s + m[1, 0], s + m[1, 1], s + m[1, 2], s + m[1, 3], s + m[2, 0], s + m[2, 1], s + m[2, 2], s + m[2, 3], s + m[3, 0], s + m[3, 1], s + m[3, 2], s + m[3, 3]);

        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static double4x4 operator +(double4x4 m, double s) => new double4x4(m[0, 0] + s, m[0, 1] + s, m[0, 2] + s, m[0, 3] + s, m[1, 0] + s, m[1, 1] + s, m[1, 2] + s, m[1, 3] + s, m[2, 0] + s, m[2, 1] + s, m[2, 2] + s, m[2, 3] + s, m[3, 0] + s, m[3, 1] + s, m[3, 2] + s, m[3, 3] + s);

        /// <summary>
        /// Executes a component-wise - (subtraction).
        /// </summary>
        public static double4x4 operator -(double4x4 lhs, double4x4 rhs) => new double4x4(lhs[0, 0] - rhs[0, 0], lhs[0, 1] - rhs[0, 1], lhs[0, 2] - rhs[0, 2], lhs[0, 3] - rhs[0, 3], lhs[1, 0] - rhs[1, 0], lhs[1, 1] - rhs[1, 1], lhs[1, 2] - rhs[1, 2], lhs[1, 3] - rhs[1, 3], lhs[2, 0] - rhs[2, 0], lhs[2, 1] - rhs[2, 1], lhs[2, 2] - rhs[2, 2], lhs[2, 3] - rhs[2, 3], lhs[3, 0] - rhs[3, 0], lhs[3, 1] - rhs[3, 1], lhs[3, 2] - rhs[3, 2], lhs[3, 3] - rhs[3, 3]);

        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static double4x4 operator -(double s, double4x4 m) => new double4x4(s - m[0, 0], s - m[0, 1], s - m[0, 2], s - m[0, 3], s - m[1, 0], s - m[1, 1], s - m[1, 2], s - m[1, 3], s - m[2, 0], s - m[2, 1], s - m[2, 2], s - m[2, 3], s - m[3, 0], s - m[3, 1], s - m[3, 2], s - m[3, 3]);

        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static double4x4 operator -(double4x4 m, double s) => new double4x4(m[0, 0] - s, m[0, 1] - s, m[0, 2] - s, m[0, 3] - s, m[1, 0] - s, m[1, 1] - s, m[1, 2] - s, m[1, 3] - s, m[2, 0] - s, m[2, 1] - s, m[2, 2] - s, m[2, 3] - s, m[3, 0] - s, m[3, 1] - s, m[3, 2] - s, m[3, 3] - s);

        /// <summary>
        /// Executes a component-wise / (division).
        /// </summary>
        public static double4x4 operator /(double4x4 lhs, double4x4 rhs) => new double4x4(lhs[0, 0] / rhs[0, 0], lhs[0, 1] / rhs[0, 1], lhs[0, 2] / rhs[0, 2], lhs[0, 3] / rhs[0, 3], lhs[1, 0] / rhs[1, 0], lhs[1, 1] / rhs[1, 1], lhs[1, 2] / rhs[1, 2], lhs[1, 3] / rhs[1, 3], lhs[2, 0] / rhs[2, 0], lhs[2, 1] / rhs[2, 1], lhs[2, 2] / rhs[2, 2], lhs[2, 3] / rhs[2, 3], lhs[3, 0] / rhs[3, 0], lhs[3, 1] / rhs[3, 1], lhs[3, 2] / rhs[3, 2], lhs[3, 3] / rhs[3, 3]);

        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static double4x4 operator /(double s, double4x4 m) => new double4x4(s / m[0, 0], s / m[0, 1], s / m[0, 2], s / m[0, 3], s / m[1, 0], s / m[1, 1], s / m[1, 2], s / m[1, 3], s / m[2, 0], s / m[2, 1], s / m[2, 2], s / m[2, 3], s / m[3, 0], s / m[3, 1], s / m[3, 2], s / m[3, 3]);

        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static double4x4 operator /(double4x4 m, double s) => new double4x4(m[0, 0] / s, m[0, 1] / s, m[0, 2] / s, m[0, 3] / s, m[1, 0] / s, m[1, 1] / s, m[1, 2] / s, m[1, 3] / s, m[2, 0] / s, m[2, 1] / s, m[2, 2] / s, m[2, 3] / s, m[3, 0] / s, m[3, 1] / s, m[3, 2] / s, m[3, 3] / s);

        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static double4x4 operator *(double s, double4x4 m) => new double4x4(s * m[0, 0], s * m[0, 1], s * m[0, 2], s * m[0, 3], s * m[1, 0], s * m[1, 1], s * m[1, 2], s * m[1, 3], s * m[2, 0], s * m[2, 1], s * m[2, 2], s * m[2, 3], s * m[3, 0], s * m[3, 1], s * m[3, 2], s * m[3, 3]);

        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static double4x4 operator *(double4x4 m, double s) => new double4x4(m[0, 0] * s, m[0, 1] * s, m[0, 2] * s, m[0, 3] * s, m[1, 0] * s, m[1, 1] * s, m[1, 2] * s, m[1, 3] * s, m[2, 0] * s, m[2, 1] * s, m[2, 2] * s, m[2, 3] * s, m[3, 0] * s, m[3, 1] * s, m[3, 2] * s, m[3, 3] * s);

        #endregion


        #region Static Functions

        /// <summary>
        /// 
        /// </summary>
        public static double4x4 OuterProduct(double4 col, double4 row) => new double4x4(row.x * col.x, row.x * col.y, row.x * col.z, row.x * col.w, row.y * col.x, row.y * col.y, row.y * col.z, row.y * col.w, row.z * col.x, row.z * col.y, row.z * col.z, row.z * col.w, row.w * col.x, row.w * col.y, row.w * col.z, row.w * col.w);

        /// <summary>
        /// 
        /// </summary>
        public static double4x4 Transpose(double4x4 v) => new double4x4(v[0, 0], v[1, 0], v[2, 0], v[3, 0], v[0, 1], v[1, 1], v[2, 1], v[3, 1], v[0, 2], v[1, 2], v[2, 2], v[3, 2], v[0, 3], v[1, 3], v[2, 3], v[3, 3]);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public static double4x4 Inverse(double4x4 v) => double4x4.Adjugate(v) / double4x4.Determinant(v);

        /// <summary>
        /// 
        /// </summary>
        public static double Determinant(double4x4 v) => v.m00 * (v.m11 * (v.m22 * v.m33 - v.m32 * v.m23) - v.m21 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m31 * (v.m12 * v.m23 - v.m22 * v.m13)) - v.m10 * (v.m01 * (v.m22 * v.m33 - v.m32 * v.m23) - v.m21 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m23 - v.m22 * v.m03)) + v.m20 * (v.m01 * (v.m12 * v.m33 - v.m32 * v.m13) - v.m11 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m13 - v.m12 * v.m03)) - v.m30 * (v.m01 * (v.m12 * v.m23 - v.m22 * v.m13) - v.m11 * (v.m02 * v.m23 - v.m22 * v.m03) + v.m21 * (v.m02 * v.m13 - v.m12 * v.m03));

        /// <summary>
        /// Executes a matrix-matrix-divison A / B == A * B^-1 (use with caution).
        /// </summary>
        private static double4x4 Divide(double4x4 A, double4x4 B) => A * double4x4.Inverse(B);

        /// <summary>
        /// 
        /// </summary>
        private static double4x4 Adjugate(double4x4 v) => new double4x4(v.m11 * (v.m22 * v.m33 - v.m32 * v.m23) + v.m21 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m31 * (v.m12 * v.m23 - v.m22 * v.m13), v.m01 * (v.m22 * v.m33 - v.m32 * v.m23) + v.m21 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m23 - v.m22 * v.m03), v.m01 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m11 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m13 - v.m12 * v.m03), v.m01 * (v.m12 * v.m23 - v.m22 * v.m13) + v.m11 * (v.m02 * v.m23 - v.m22 * v.m03) - v.m21 * (v.m02 * v.m13 - v.m12 * v.m03), v.m11 * (v.m22 * v.m33 - v.m32 * v.m23) + v.m21 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m31 * (v.m12 * v.m23 - v.m22 * v.m13), v.m01 * (v.m22 * v.m33 - v.m32 * v.m23) + v.m21 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m23 - v.m22 * v.m03), v.m01 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m11 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m13 - v.m12 * v.m03), v.m01 * (v.m12 * v.m23 - v.m22 * v.m13) + v.m11 * (v.m02 * v.m23 - v.m22 * v.m03) - v.m21 * (v.m02 * v.m13 - v.m12 * v.m03), v.m11 * (v.m22 * v.m33 - v.m32 * v.m23) + v.m21 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m31 * (v.m12 * v.m23 - v.m22 * v.m13), v.m01 * (v.m22 * v.m33 - v.m32 * v.m23) + v.m21 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m23 - v.m22 * v.m03), v.m01 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m11 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m13 - v.m12 * v.m03), v.m01 * (v.m12 * v.m23 - v.m22 * v.m13) + v.m11 * (v.m02 * v.m23 - v.m22 * v.m03) - v.m21 * (v.m02 * v.m13 - v.m12 * v.m03), v.m11 * (v.m22 * v.m33 - v.m32 * v.m23) + v.m21 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m31 * (v.m12 * v.m23 - v.m22 * v.m13), v.m01 * (v.m22 * v.m33 - v.m32 * v.m23) + v.m21 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m23 - v.m22 * v.m03), v.m01 * (v.m12 * v.m33 - v.m32 * v.m13) + v.m11 * (v.m02 * v.m33 - v.m32 * v.m03) + v.m31 * (v.m02 * v.m13 - v.m12 * v.m03), v.m01 * (v.m12 * v.m23 - v.m22 * v.m13) + v.m11 * (v.m02 * v.m23 - v.m22 * v.m03) - v.m21 * (v.m02 * v.m13 - v.m12 * v.m03));

        #endregion

    }
}
