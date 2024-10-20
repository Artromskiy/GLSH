using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A matrix of type int with 2 columns and 3 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct int2x3
    {

        #region Fields

        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        [DataMember]
        public int m00;

        /// <summary>
        /// Column 0, Rows 1
        /// </summary>
        [DataMember]
        public int m01;

        /// <summary>
        /// Column 0, Rows 2
        /// </summary>
        [DataMember]
        public int m02;

        /// <summary>
        /// Column 1, Rows 0
        /// </summary>
        [DataMember]
        public int m10;

        /// <summary>
        /// Column 1, Rows 1
        /// </summary>
        [DataMember]
        public int m11;

        /// <summary>
        /// Column 1, Rows 2
        /// </summary>
        [DataMember]
        public int m12;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public int2x3(int m00, int m01, int m02, int m10, int m11, int m12)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m02 = m02;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
        }

        /// <summary>
        /// Constructs this matrix from a int2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int2x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int3x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int4x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int2x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
        }

        /// <summary>
        /// Constructs this matrix from a int3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int3x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
        }

        /// <summary>
        /// Constructs this matrix from a int4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int4x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
        }

        /// <summary>
        /// Constructs this matrix from a int2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int2x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
        }

        /// <summary>
        /// Constructs this matrix from a int3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int3x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
        }

        /// <summary>
        /// Constructs this matrix from a int4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int4x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int2 c0, int2 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = 0;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int2x3(int3 c0, int3 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the column nr 0
        /// </summary>
        public int3 Column0
        {
            get
            {
                return new int3(m00, m01, m02);
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
        public int3 Column1
        {
            get
            {
                return new int3(m10, m11, m12);
            }
            set
            {
                m10 = value.x;
                m11 = value.y;
                m12 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 0
        /// </summary>
        public int2 Row0
        {
            get
            {
                return new int2(m00, m10);
            }
            set
            {
                m00 = value.x;
                m10 = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 1
        /// </summary>
        public int2 Row1
        {
            get
            {
                return new int2(m01, m11);
            }
            set
            {
                m01 = value.x;
                m11 = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 2
        /// </summary>
        public int2 Row2
        {
            get
            {
                return new int2(m02, m12);
            }
            set
            {
                m02 = value.x;
                m12 = value.y;
            }
        }

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        public static int2x3 Zero { get; } = new int2x3(0, 0, 0, 0, 0, 0);

        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        public static int2x3 Ones { get; } = new int2x3(1, 1, 1, 1, 1, 1);

        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        public static int2x3 Identity { get; } = new int2x3(1, 0, 0, 0, 1, 0);

        /// <summary>
        /// Predefined all-MaxValue matrix
        /// </summary>
        public static int2x3 AllMaxValue { get; } = new int2x3(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        /// <summary>
        /// Predefined diagonal-MaxValue matrix
        /// </summary>
        public static int2x3 DiagonalMaxValue { get; } = new int2x3(int.MaxValue, 0, 0, 0, int.MaxValue, 0);

        /// <summary>
        /// Predefined all-MinValue matrix
        /// </summary>
        public static int2x3 AllMinValue { get; } = new int2x3(int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue);

        /// <summary>
        /// Predefined diagonal-MinValue matrix
        /// </summary>
        public static int2x3 DiagonalMinValue { get; } = new int2x3(int.MinValue, 0, 0, 0, int.MinValue, 0);

        #endregion


        /// <summary>
        /// Returns the number of Fields (2 x 3 = 6).
        /// </summary>
        public const int Count = 6;

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public int this[int fieldIndex]
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
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
        }

        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public int this[int col, int row]
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
        public bool Equals(int2x3 rhs) => (((m00.Equals(rhs.m00) && m01.Equals(rhs.m01)) && m02.Equals(rhs.m02)) && ((m10.Equals(rhs.m10) && m11.Equals(rhs.m11)) && m12.Equals(rhs.m12)));

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(int2x3 lhs, int2x3 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(int2x3 lhs, int2x3 rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public int3x2 Transposed => new int3x2(m00, m10, m01, m11, m02, m12);

        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public int MinElement => Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(m00, m01), m02), m10), m11), m12);

        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public int MaxElement => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(m00, m01), m02), m10), m11), m12);

        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public float Length => (float)Math.Sqrt((((m00 * m00 + m01 * m01) + m02 * m02) + ((m10 * m10 + m11 * m11) + m12 * m12)));

        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public float LengthSqr => (((m00 * m00 + m01 * m01) + m02 * m02) + ((m10 * m10 + m11 * m11) + m12 * m12));

        /// <summary>
        /// Returns the sum of all fields.
        /// </summary>
        public int Sum => (((m00 + m01) + m02) + ((m10 + m11) + m12));

        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public float Norm => (float)Math.Sqrt((((m00 * m00 + m01 * m01) + m02 * m02) + ((m10 * m10 + m11 * m11) + m12 * m12)));

        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public float Norm1 => (((Math.Abs(m00) + Math.Abs(m01)) + Math.Abs(m02)) + ((Math.Abs(m10) + Math.Abs(m11)) + Math.Abs(m12)));

        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt((((m00 * m00 + m01 * m01) + m02 * m02) + ((m10 * m10 + m11 * m11) + m12 * m12)));

        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public int NormMax => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Abs(m00), Math.Abs(m01)), Math.Abs(m02)), Math.Abs(m10)), Math.Abs(m11)), Math.Abs(m12));

        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => Math.Pow((((Math.Pow(Math.Abs(m00), p) + Math.Pow(Math.Abs(m01), p)) + Math.Pow(Math.Abs(m02), p)) + ((Math.Pow(Math.Abs(m10), p) + Math.Pow(Math.Abs(m11), p)) + Math.Pow(Math.Abs(m12), p))), 1 / p);

        /// <summary>
        /// Executes a matrix-matrix-multiplication int2x3 * int2x2 -> int2x3.
        /// </summary>
        public static int2x3 operator *(int2x3 lhs, int2x2 rhs) => new int2x3((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11));

        /// <summary>
        /// Executes a matrix-matrix-multiplication int2x3 * int3x2 -> int3x3.
        /// </summary>
        public static int3x3 operator *(int2x3 lhs, int3x2 rhs) => new int3x3((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11), (lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21), (lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21), (lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21));

        /// <summary>
        /// Executes a matrix-matrix-multiplication int2x3 * int4x2 -> int4x3.
        /// </summary>
        public static int4x3 operator *(int2x3 lhs, int4x2 rhs) => new int4x3((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11), (lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21), (lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21), (lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21), (lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31), (lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31), (lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31));

        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static int3 operator *(int2x3 m, int2 v) => new int3((m.m00 * v.x + m.m10 * v.y), (m.m01 * v.x + m.m11 * v.y), (m.m02 * v.x + m.m12 * v.y));

        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static int2x3 CompMul(int2x3 A, int2x3 B) => new int2x3(A.m00 * B.m00, A.m01 * B.m01, A.m02 * B.m02, A.m10 * B.m10, A.m11 * B.m11, A.m12 * B.m12);

        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static int2x3 CompDiv(int2x3 A, int2x3 B) => new int2x3(A.m00 / B.m00, A.m01 / B.m01, A.m02 / B.m02, A.m10 / B.m10, A.m11 / B.m11, A.m12 / B.m12);

        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static int2x3 CompAdd(int2x3 A, int2x3 B) => new int2x3(A.m00 + B.m00, A.m01 + B.m01, A.m02 + B.m02, A.m10 + B.m10, A.m11 + B.m11, A.m12 + B.m12);

        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static int2x3 CompSub(int2x3 A, int2x3 B) => new int2x3(A.m00 - B.m00, A.m01 - B.m01, A.m02 - B.m02, A.m10 - B.m10, A.m11 - B.m11, A.m12 - B.m12);

        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static int2x3 operator +(int2x3 lhs, int2x3 rhs) => new int2x3(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12);

        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static int2x3 operator +(int2x3 lhs, int rhs) => new int2x3(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs);

        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static int2x3 operator +(int lhs, int2x3 rhs) => new int2x3(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12);

        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static int2x3 operator -(int2x3 lhs, int2x3 rhs) => new int2x3(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12);

        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static int2x3 operator -(int2x3 lhs, int rhs) => new int2x3(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs);

        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static int2x3 operator -(int lhs, int2x3 rhs) => new int2x3(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12);

        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static int2x3 operator /(int2x3 lhs, int rhs) => new int2x3(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs);

        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static int2x3 operator /(int lhs, int2x3 rhs) => new int2x3(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12);

        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static int2x3 operator *(int2x3 lhs, int rhs) => new int2x3(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs);

        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static int2x3 operator *(int lhs, int2x3 rhs) => new int2x3(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12);

        /// <summary>
        /// Executes a component-wise % (modulo).
        /// </summary>
        public static int2x3 operator %(int2x3 lhs, int2x3 rhs) => new int2x3(lhs.m00 % rhs.m00, lhs.m01 % rhs.m01, lhs.m02 % rhs.m02, lhs.m10 % rhs.m10, lhs.m11 % rhs.m11, lhs.m12 % rhs.m12);

        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static int2x3 operator %(int2x3 lhs, int rhs) => new int2x3(lhs.m00 % rhs, lhs.m01 % rhs, lhs.m02 % rhs, lhs.m10 % rhs, lhs.m11 % rhs, lhs.m12 % rhs);

        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static int2x3 operator %(int lhs, int2x3 rhs) => new int2x3(lhs % rhs.m00, lhs % rhs.m01, lhs % rhs.m02, lhs % rhs.m10, lhs % rhs.m11, lhs % rhs.m12);

        /// <summary>
        /// Executes a component-wise ^ (xor).
        /// </summary>
        public static int2x3 operator ^(int2x3 lhs, int2x3 rhs) => new int2x3(lhs.m00 ^ rhs.m00, lhs.m01 ^ rhs.m01, lhs.m02 ^ rhs.m02, lhs.m10 ^ rhs.m10, lhs.m11 ^ rhs.m11, lhs.m12 ^ rhs.m12);

        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static int2x3 operator ^(int2x3 lhs, int rhs) => new int2x3(lhs.m00 ^ rhs, lhs.m01 ^ rhs, lhs.m02 ^ rhs, lhs.m10 ^ rhs, lhs.m11 ^ rhs, lhs.m12 ^ rhs);

        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static int2x3 operator ^(int lhs, int2x3 rhs) => new int2x3(lhs ^ rhs.m00, lhs ^ rhs.m01, lhs ^ rhs.m02, lhs ^ rhs.m10, lhs ^ rhs.m11, lhs ^ rhs.m12);

        /// <summary>
        /// Executes a component-wise | (bitwise-or).
        /// </summary>
        public static int2x3 operator |(int2x3 lhs, int2x3 rhs) => new int2x3(lhs.m00 | rhs.m00, lhs.m01 | rhs.m01, lhs.m02 | rhs.m02, lhs.m10 | rhs.m10, lhs.m11 | rhs.m11, lhs.m12 | rhs.m12);

        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static int2x3 operator |(int2x3 lhs, int rhs) => new int2x3(lhs.m00 | rhs, lhs.m01 | rhs, lhs.m02 | rhs, lhs.m10 | rhs, lhs.m11 | rhs, lhs.m12 | rhs);

        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static int2x3 operator |(int lhs, int2x3 rhs) => new int2x3(lhs | rhs.m00, lhs | rhs.m01, lhs | rhs.m02, lhs | rhs.m10, lhs | rhs.m11, lhs | rhs.m12);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and).
        /// </summary>
        public static int2x3 operator &(int2x3 lhs, int2x3 rhs) => new int2x3(lhs.m00 & rhs.m00, lhs.m01 & rhs.m01, lhs.m02 & rhs.m02, lhs.m10 & rhs.m10, lhs.m11 & rhs.m11, lhs.m12 & rhs.m12);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static int2x3 operator &(int2x3 lhs, int rhs) => new int2x3(lhs.m00 & rhs, lhs.m01 & rhs, lhs.m02 & rhs, lhs.m10 & rhs, lhs.m11 & rhs, lhs.m12 & rhs);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static int2x3 operator &(int lhs, int2x3 rhs) => new int2x3(lhs & rhs.m00, lhs & rhs.m01, lhs & rhs.m02, lhs & rhs.m10, lhs & rhs.m11, lhs & rhs.m12);

        /// <summary>
        /// Executes a component-wise left-shift with a scalar.
        /// </summary>
        public static int2x3 operator <<(int2x3 lhs, int rhs) => new int2x3(lhs.m00 << rhs, lhs.m01 << rhs, lhs.m02 << rhs, lhs.m10 << rhs, lhs.m11 << rhs, lhs.m12 << rhs);

        /// <summary>
        /// Executes a component-wise right-shift with a scalar.
        /// </summary>
        public static int2x3 operator >>(int2x3 lhs, int rhs) => new int2x3(lhs.m00 >> rhs, lhs.m01 >> rhs, lhs.m02 >> rhs, lhs.m10 >> rhs, lhs.m11 >> rhs, lhs.m12 >> rhs);

        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bool2x3 operator <(int2x3 lhs, int2x3 rhs) => new bool2x3(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m02 < rhs.m02, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11, lhs.m12 < rhs.m12);

        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool2x3 operator <(int2x3 lhs, int rhs) => new bool2x3(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m02 < rhs, lhs.m10 < rhs, lhs.m11 < rhs, lhs.m12 < rhs);

        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool2x3 operator <(int lhs, int2x3 rhs) => new bool2x3(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m02, lhs < rhs.m10, lhs < rhs.m11, lhs < rhs.m12);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bool2x3 operator <=(int2x3 lhs, int2x3 rhs) => new bool2x3(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m02 <= rhs.m02, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11, lhs.m12 <= rhs.m12);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x3 operator <=(int2x3 lhs, int rhs) => new bool2x3(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m02 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs, lhs.m12 <= rhs);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x3 operator <=(int lhs, int2x3 rhs) => new bool2x3(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m02, lhs <= rhs.m10, lhs <= rhs.m11, lhs <= rhs.m12);

        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bool2x3 operator >(int2x3 lhs, int2x3 rhs) => new bool2x3(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m02 > rhs.m02, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11, lhs.m12 > rhs.m12);

        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool2x3 operator >(int2x3 lhs, int rhs) => new bool2x3(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m02 > rhs, lhs.m10 > rhs, lhs.m11 > rhs, lhs.m12 > rhs);

        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool2x3 operator >(int lhs, int2x3 rhs) => new bool2x3(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m02, lhs > rhs.m10, lhs > rhs.m11, lhs > rhs.m12);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bool2x3 operator >=(int2x3 lhs, int2x3 rhs) => new bool2x3(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m02 >= rhs.m02, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11, lhs.m12 >= rhs.m12);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x3 operator >=(int2x3 lhs, int rhs) => new bool2x3(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m02 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs, lhs.m12 >= rhs);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x3 operator >=(int lhs, int2x3 rhs) => new bool2x3(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m02, lhs >= rhs.m10, lhs >= rhs.m11, lhs >= rhs.m12);
    }
}
