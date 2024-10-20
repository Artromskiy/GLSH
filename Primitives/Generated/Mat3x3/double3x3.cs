using System;
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
        public double m00;

        /// <summary>
        /// Column 0, Rows 1
        /// </summary>
        [DataMember]
        public double m01;

        /// <summary>
        /// Column 0, Rows 2
        /// </summary>
        [DataMember]
        public double m02;

        /// <summary>
        /// Column 1, Rows 0
        /// </summary>
        [DataMember]
        public double m10;

        /// <summary>
        /// Column 1, Rows 1
        /// </summary>
        [DataMember]
        public double m11;

        /// <summary>
        /// Column 1, Rows 2
        /// </summary>
        [DataMember]
        public double m12;

        /// <summary>
        /// Column 2, Rows 0
        /// </summary>
        [DataMember]
        public double m20;

        /// <summary>
        /// Column 2, Rows 1
        /// </summary>
        [DataMember]
        public double m21;

        /// <summary>
        /// Column 2, Rows 2
        /// </summary>
        [DataMember]
        public double m22;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public double3x3(double m00, double m01, double m02, double m10, double m11, double m12, double m20, double m21, double m22)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m02 = m02;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m20 = m20;
            this.m21 = m21;
            this.m22 = m22;
        }

        /// <summary>
        /// Constructs this matrix from a double2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double2x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0.0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0.0;
            this.m20 = 0.0;
            this.m21 = 0.0;
            this.m22 = 1.0;
        }

        /// <summary>
        /// Constructs this matrix from a double3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double3x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0.0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0.0;
            this.m20 = m.m20;
            this.m21 = m.m21;
            this.m22 = 1.0;
        }

        /// <summary>
        /// Constructs this matrix from a double4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double4x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0.0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0.0;
            this.m20 = m.m20;
            this.m21 = m.m21;
            this.m22 = 1.0;
        }

        /// <summary>
        /// Constructs this matrix from a double2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double2x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m20 = 0.0;
            this.m21 = 0.0;
            this.m22 = 1.0;
        }

        /// <summary>
        /// Constructs this matrix from a double3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double3x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m20 = m.m20;
            this.m21 = m.m21;
            this.m22 = m.m22;
        }

        /// <summary>
        /// Constructs this matrix from a double4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double4x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m20 = m.m20;
            this.m21 = m.m21;
            this.m22 = m.m22;
        }

        /// <summary>
        /// Constructs this matrix from a double2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double2x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m20 = 0.0;
            this.m21 = 0.0;
            this.m22 = 1.0;
        }

        /// <summary>
        /// Constructs this matrix from a double3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double3x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m20 = m.m20;
            this.m21 = m.m21;
            this.m22 = m.m22;
        }

        /// <summary>
        /// Constructs this matrix from a double4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double4x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m20 = m.m20;
            this.m21 = m.m21;
            this.m22 = m.m22;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double2 c0, double2 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = 0.0;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = 0.0;
            this.m20 = 0.0;
            this.m21 = 0.0;
            this.m22 = 1.0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double2 c0, double2 c1, double2 c2)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = 0.0;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = 0.0;
            this.m20 = c2.x;
            this.m21 = c2.y;
            this.m22 = 1.0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double3 c0, double3 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
            this.m20 = 0.0;
            this.m21 = 0.0;
            this.m22 = 1.0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public double3x3(double3 c0, double3 c1, double3 c2)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
            this.m20 = c2.x;
            this.m21 = c2.y;
            this.m22 = c2.z;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the column nr 0
        /// </summary>
        public double3 Column0
        {
            get
            {
                return new double3(m00, m01, m02);
            }
            set
            {
                m00 = value.x;
                m01 = value.y;
                m02 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the column nr 1
        /// </summary>
        public double3 Column1
        {
            get
            {
                return new double3(m10, m11, m12);
            }
            set
            {
                m10 = value.x;
                m11 = value.y;
                m12 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the column nr 2
        /// </summary>
        public double3 Column2
        {
            get
            {
                return new double3(m20, m21, m22);
            }
            set
            {
                m20 = value.x;
                m21 = value.y;
                m22 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 0
        /// </summary>
        public double3 Row0
        {
            get
            {
                return new double3(m00, m10, m20);
            }
            set
            {
                m00 = value.x;
                m10 = value.y;
                m20 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 1
        /// </summary>
        public double3 Row1
        {
            get
            {
                return new double3(m01, m11, m21);
            }
            set
            {
                m01 = value.x;
                m11 = value.y;
                m21 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 2
        /// </summary>
        public double3 Row2
        {
            get
            {
                return new double3(m02, m12, m22);
            }
            set
            {
                m02 = value.x;
                m12 = value.y;
                m22 = value.z;
            }
        }

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        public static double3x3 Zero { get; } = new double3x3(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        public static double3x3 Ones { get; } = new double3x3(1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);

        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        public static double3x3 Identity { get; } = new double3x3(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0);

        /// <summary>
        /// Predefined all-MaxValue matrix
        /// </summary>
        public static double3x3 AllMaxValue { get; } = new double3x3(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);

        /// <summary>
        /// Predefined diagonal-MaxValue matrix
        /// </summary>
        public static double3x3 DiagonalMaxValue { get; } = new double3x3(double.MaxValue, 0.0, 0.0, 0.0, double.MaxValue, 0.0, 0.0, 0.0, double.MaxValue);

        /// <summary>
        /// Predefined all-MinValue matrix
        /// </summary>
        public static double3x3 AllMinValue { get; } = new double3x3(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);

        /// <summary>
        /// Predefined diagonal-MinValue matrix
        /// </summary>
        public static double3x3 DiagonalMinValue { get; } = new double3x3(double.MinValue, 0.0, 0.0, 0.0, double.MinValue, 0.0, 0.0, 0.0, double.MinValue);

        /// <summary>
        /// Predefined all-Epsilon matrix
        /// </summary>
        public static double3x3 AllEpsilon { get; } = new double3x3(double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon, double.Epsilon);

        /// <summary>
        /// Predefined diagonal-Epsilon matrix
        /// </summary>
        public static double3x3 DiagonalEpsilon { get; } = new double3x3(double.Epsilon, 0.0, 0.0, 0.0, double.Epsilon, 0.0, 0.0, 0.0, double.Epsilon);

        /// <summary>
        /// Predefined all-NaN matrix
        /// </summary>
        public static double3x3 AllNaN { get; } = new double3x3(double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN);

        /// <summary>
        /// Predefined diagonal-NaN matrix
        /// </summary>
        public static double3x3 DiagonalNaN { get; } = new double3x3(double.NaN, 0.0, 0.0, 0.0, double.NaN, 0.0, 0.0, 0.0, double.NaN);

        /// <summary>
        /// Predefined all-NegativeInfinity matrix
        /// </summary>
        public static double3x3 AllNegativeInfinity { get; } = new double3x3(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

        /// <summary>
        /// Predefined diagonal-NegativeInfinity matrix
        /// </summary>
        public static double3x3 DiagonalNegativeInfinity { get; } = new double3x3(double.NegativeInfinity, 0.0, 0.0, 0.0, double.NegativeInfinity, 0.0, 0.0, 0.0, double.NegativeInfinity);

        /// <summary>
        /// Predefined all-PositiveInfinity matrix
        /// </summary>
        public static double3x3 AllPositiveInfinity { get; } = new double3x3(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);

        /// <summary>
        /// Predefined diagonal-PositiveInfinity matrix
        /// </summary>
        public static double3x3 DiagonalPositiveInfinity { get; } = new double3x3(double.PositiveInfinity, 0.0, 0.0, 0.0, double.PositiveInfinity, 0.0, 0.0, 0.0, double.PositiveInfinity);

        #endregion


        /// <summary>
        /// Returns the number of Fields (3 x 3 = 9).
        /// </summary>
        public const int Count = 9;

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public double this[int fieldIndex]
        {
            get
            {
                switch (fieldIndex)
                {
                    case 0: return m00;
                    case 1: return m01;
                    case 2: return m02;
                    case 3: return m10;
                    case 4: return m11;
                    case 5: return m12;
                    case 6: return m20;
                    case 7: return m21;
                    case 8: return m22;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
            set
            {
                switch (fieldIndex)
                {
                    case 0: this.m00 = value; break;
                    case 1: this.m01 = value; break;
                    case 2: this.m02 = value; break;
                    case 3: this.m10 = value; break;
                    case 4: this.m11 = value; break;
                    case 5: this.m12 = value; break;
                    case 6: this.m20 = value; break;
                    case 7: this.m21 = value; break;
                    case 8: this.m22 = value; break;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
        }

        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public double this[int col, int row]
        {
            get
            {
                return this[col * 3 + row];
            }
            set
            {
                this[col * 3 + row] = value;
            }
        }

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(double3x3 rhs) => ((((m00.Equals(rhs.m00) && m01.Equals(rhs.m01)) && m02.Equals(rhs.m02)) && (m10.Equals(rhs.m10) && m11.Equals(rhs.m11))) && ((m12.Equals(rhs.m12) && m20.Equals(rhs.m20)) && (m21.Equals(rhs.m21) && m22.Equals(rhs.m22))));

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(double3x3 lhs, double3x3 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(double3x3 lhs, double3x3 rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode()) * 397) ^ m20.GetHashCode()) * 397) ^ m21.GetHashCode()) * 397) ^ m22.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public double3x3 Transposed => new double3x3(m00, m10, m20, m01, m11, m21, m02, m12, m22);

        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public double MinElement => Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(m00, m01), m02), m10), m11), m12), m20), m21), m22);

        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public double MaxElement => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(m00, m01), m02), m10), m11), m12), m20), m21), m22);

        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public double Length => (double)Math.Sqrt(((((m00 * m00 + m01 * m01) + m02 * m02) + (m10 * m10 + m11 * m11)) + ((m12 * m12 + m20 * m20) + (m21 * m21 + m22 * m22))));

        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public double LengthSqr => ((((m00 * m00 + m01 * m01) + m02 * m02) + (m10 * m10 + m11 * m11)) + ((m12 * m12 + m20 * m20) + (m21 * m21 + m22 * m22)));

        /// <summary>
        /// Returns the sum of all fields.
        /// </summary>
        public double Sum => ((((m00 + m01) + m02) + (m10 + m11)) + ((m12 + m20) + (m21 + m22)));

        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public double Norm => (double)Math.Sqrt(((((m00 * m00 + m01 * m01) + m02 * m02) + (m10 * m10 + m11 * m11)) + ((m12 * m12 + m20 * m20) + (m21 * m21 + m22 * m22))));

        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public double Norm1 => ((((Math.Abs(m00) + Math.Abs(m01)) + Math.Abs(m02)) + (Math.Abs(m10) + Math.Abs(m11))) + ((Math.Abs(m12) + Math.Abs(m20)) + (Math.Abs(m21) + Math.Abs(m22))));

        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public double Norm2 => (double)Math.Sqrt(((((m00 * m00 + m01 * m01) + m02 * m02) + (m10 * m10 + m11 * m11)) + ((m12 * m12 + m20 * m20) + (m21 * m21 + m22 * m22))));

        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public double NormMax => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Abs(m00), Math.Abs(m01)), Math.Abs(m02)), Math.Abs(m10)), Math.Abs(m11)), Math.Abs(m12)), Math.Abs(m20)), Math.Abs(m21)), Math.Abs(m22));

        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => Math.Pow(((((Math.Pow((double)Math.Abs(m00), p) + Math.Pow((double)Math.Abs(m01), p)) + Math.Pow((double)Math.Abs(m02), p)) + (Math.Pow((double)Math.Abs(m10), p) + Math.Pow((double)Math.Abs(m11), p))) + ((Math.Pow((double)Math.Abs(m12), p) + Math.Pow((double)Math.Abs(m20), p)) + (Math.Pow((double)Math.Abs(m21), p) + Math.Pow((double)Math.Abs(m22), p)))), 1 / p);

        /// <summary>
        /// Returns determinant of this matrix.
        /// </summary>
        public double Determinant => m00 * (m11 * m22 - m21 * m12) - m10 * (m01 * m22 - m21 * m02) + m20 * (m01 * m12 - m11 * m02);

        /// <summary>
        /// Returns the adjunct of this matrix.
        /// </summary>
        public double3x3 Adjugate => new double3x3(m11 * m22 - m21 * m12, -m01 * m22 + m21 * m02, m01 * m12 - m11 * m02, -m10 * m22 + m20 * m12, m00 * m22 - m20 * m02, -m00 * m12 + m10 * m02, m10 * m21 - m20 * m11, -m00 * m21 + m20 * m01, m00 * m11 - m10 * m01);

        /// <summary>
        /// Returns the inverse of this matrix (use with caution).
        /// </summary>
        public double3x3 Inverse => Adjugate / Determinant;

        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x3 * double2x3 -> double2x3.
        /// </summary>
        public static double2x3 operator *(double3x3 lhs, double2x3 rhs) => new double2x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + lhs.m20 * rhs.m02), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + lhs.m21 * rhs.m02), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + lhs.m22 * rhs.m02), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + lhs.m20 * rhs.m12), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + lhs.m21 * rhs.m12), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + lhs.m22 * rhs.m12));

        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x3 * double3x3 -> double3x3.
        /// </summary>
        public static double3x3 operator *(double3x3 lhs, double3x3 rhs) => new double3x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + lhs.m20 * rhs.m02), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + lhs.m21 * rhs.m02), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + lhs.m22 * rhs.m02), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + lhs.m20 * rhs.m12), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + lhs.m21 * rhs.m12), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + lhs.m22 * rhs.m12), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + lhs.m20 * rhs.m22), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + lhs.m21 * rhs.m22), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + lhs.m22 * rhs.m22));

        /// <summary>
        /// Executes a matrix-matrix-multiplication double3x3 * double4x3 -> double4x3.
        /// </summary>
        public static double4x3 operator *(double3x3 lhs, double4x3 rhs) => new double4x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + lhs.m20 * rhs.m02), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + lhs.m21 * rhs.m02), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + lhs.m22 * rhs.m02), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + lhs.m20 * rhs.m12), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + lhs.m21 * rhs.m12), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + lhs.m22 * rhs.m12), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + lhs.m20 * rhs.m22), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + lhs.m21 * rhs.m22), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + lhs.m22 * rhs.m22), ((lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31) + lhs.m20 * rhs.m32), ((lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31) + lhs.m21 * rhs.m32), ((lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31) + lhs.m22 * rhs.m32));

        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static double3 operator *(double3x3 m, double3 v) => new double3(((m.m00 * v.x + m.m10 * v.y) + m.m20 * v.z), ((m.m01 * v.x + m.m11 * v.y) + m.m21 * v.z), ((m.m02 * v.x + m.m12 * v.y) + m.m22 * v.z));

        /// <summary>
        /// Executes a matrix-matrix-divison A / B == A * B^-1 (use with caution).
        /// </summary>
        public static double3x3 operator /(double3x3 A, double3x3 B) => A * B.Inverse;

        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static double3x3 CompMul(double3x3 A, double3x3 B) => new double3x3(A.m00 * B.m00, A.m01 * B.m01, A.m02 * B.m02, A.m10 * B.m10, A.m11 * B.m11, A.m12 * B.m12, A.m20 * B.m20, A.m21 * B.m21, A.m22 * B.m22);

        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static double3x3 CompDiv(double3x3 A, double3x3 B) => new double3x3(A.m00 / B.m00, A.m01 / B.m01, A.m02 / B.m02, A.m10 / B.m10, A.m11 / B.m11, A.m12 / B.m12, A.m20 / B.m20, A.m21 / B.m21, A.m22 / B.m22);

        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static double3x3 CompAdd(double3x3 A, double3x3 B) => new double3x3(A.m00 + B.m00, A.m01 + B.m01, A.m02 + B.m02, A.m10 + B.m10, A.m11 + B.m11, A.m12 + B.m12, A.m20 + B.m20, A.m21 + B.m21, A.m22 + B.m22);

        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static double3x3 CompSub(double3x3 A, double3x3 B) => new double3x3(A.m00 - B.m00, A.m01 - B.m01, A.m02 - B.m02, A.m10 - B.m10, A.m11 - B.m11, A.m12 - B.m12, A.m20 - B.m20, A.m21 - B.m21, A.m22 - B.m22);

        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static double3x3 operator +(double3x3 lhs, double3x3 rhs) => new double3x3(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m20 + rhs.m20, lhs.m21 + rhs.m21, lhs.m22 + rhs.m22);

        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static double3x3 operator +(double3x3 lhs, double rhs) => new double3x3(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs, lhs.m20 + rhs, lhs.m21 + rhs, lhs.m22 + rhs);

        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static double3x3 operator +(double lhs, double3x3 rhs) => new double3x3(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12, lhs + rhs.m20, lhs + rhs.m21, lhs + rhs.m22);

        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static double3x3 operator -(double3x3 lhs, double3x3 rhs) => new double3x3(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m20 - rhs.m20, lhs.m21 - rhs.m21, lhs.m22 - rhs.m22);

        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static double3x3 operator -(double3x3 lhs, double rhs) => new double3x3(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs, lhs.m20 - rhs, lhs.m21 - rhs, lhs.m22 - rhs);

        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static double3x3 operator -(double lhs, double3x3 rhs) => new double3x3(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12, lhs - rhs.m20, lhs - rhs.m21, lhs - rhs.m22);

        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static double3x3 operator /(double3x3 lhs, double rhs) => new double3x3(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs, lhs.m20 / rhs, lhs.m21 / rhs, lhs.m22 / rhs);

        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static double3x3 operator /(double lhs, double3x3 rhs) => new double3x3(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12, lhs / rhs.m20, lhs / rhs.m21, lhs / rhs.m22);

        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static double3x3 operator *(double3x3 lhs, double rhs) => new double3x3(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs, lhs.m20 * rhs, lhs.m21 * rhs, lhs.m22 * rhs);

        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static double3x3 operator *(double lhs, double3x3 rhs) => new double3x3(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12, lhs * rhs.m20, lhs * rhs.m21, lhs * rhs.m22);

        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bool3x3 operator <(double3x3 lhs, double3x3 rhs) => new bool3x3(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m02 < rhs.m02, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11, lhs.m12 < rhs.m12, lhs.m20 < rhs.m20, lhs.m21 < rhs.m21, lhs.m22 < rhs.m22);

        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool3x3 operator <(double3x3 lhs, double rhs) => new bool3x3(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m02 < rhs, lhs.m10 < rhs, lhs.m11 < rhs, lhs.m12 < rhs, lhs.m20 < rhs, lhs.m21 < rhs, lhs.m22 < rhs);

        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool3x3 operator <(double lhs, double3x3 rhs) => new bool3x3(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m02, lhs < rhs.m10, lhs < rhs.m11, lhs < rhs.m12, lhs < rhs.m20, lhs < rhs.m21, lhs < rhs.m22);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bool3x3 operator <=(double3x3 lhs, double3x3 rhs) => new bool3x3(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m02 <= rhs.m02, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11, lhs.m12 <= rhs.m12, lhs.m20 <= rhs.m20, lhs.m21 <= rhs.m21, lhs.m22 <= rhs.m22);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool3x3 operator <=(double3x3 lhs, double rhs) => new bool3x3(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m02 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs, lhs.m12 <= rhs, lhs.m20 <= rhs, lhs.m21 <= rhs, lhs.m22 <= rhs);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool3x3 operator <=(double lhs, double3x3 rhs) => new bool3x3(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m02, lhs <= rhs.m10, lhs <= rhs.m11, lhs <= rhs.m12, lhs <= rhs.m20, lhs <= rhs.m21, lhs <= rhs.m22);

        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bool3x3 operator >(double3x3 lhs, double3x3 rhs) => new bool3x3(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m02 > rhs.m02, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11, lhs.m12 > rhs.m12, lhs.m20 > rhs.m20, lhs.m21 > rhs.m21, lhs.m22 > rhs.m22);

        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool3x3 operator >(double3x3 lhs, double rhs) => new bool3x3(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m02 > rhs, lhs.m10 > rhs, lhs.m11 > rhs, lhs.m12 > rhs, lhs.m20 > rhs, lhs.m21 > rhs, lhs.m22 > rhs);

        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool3x3 operator >(double lhs, double3x3 rhs) => new bool3x3(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m02, lhs > rhs.m10, lhs > rhs.m11, lhs > rhs.m12, lhs > rhs.m20, lhs > rhs.m21, lhs > rhs.m22);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bool3x3 operator >=(double3x3 lhs, double3x3 rhs) => new bool3x3(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m02 >= rhs.m02, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11, lhs.m12 >= rhs.m12, lhs.m20 >= rhs.m20, lhs.m21 >= rhs.m21, lhs.m22 >= rhs.m22);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool3x3 operator >=(double3x3 lhs, double rhs) => new bool3x3(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m02 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs, lhs.m12 >= rhs, lhs.m20 >= rhs, lhs.m21 >= rhs, lhs.m22 >= rhs);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool3x3 operator >=(double lhs, double3x3 rhs) => new bool3x3(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m02, lhs >= rhs.m10, lhs >= rhs.m11, lhs >= rhs.m12, lhs >= rhs.m20, lhs >= rhs.m21, lhs >= rhs.m22);
    }
}
