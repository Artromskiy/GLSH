using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A matrix of type int with 4 columns and 3 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct int4x3
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

        /// <summary>
        /// Column 2, Rows 0
        /// </summary>
        [DataMember]
        public int m20;

        /// <summary>
        /// Column 2, Rows 1
        /// </summary>
        [DataMember]
        public int m21;

        /// <summary>
        /// Column 2, Rows 2
        /// </summary>
        [DataMember]
        public int m22;

        /// <summary>
        /// Column 3, Rows 0
        /// </summary>
        [DataMember]
        public int m30;

        /// <summary>
        /// Column 3, Rows 1
        /// </summary>
        [DataMember]
        public int m31;

        /// <summary>
        /// Column 3, Rows 2
        /// </summary>
        [DataMember]
        public int m32;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public int4x3(int m00, int m01, int m02, int m10, int m11, int m12, int m20, int m21, int m22, int m30, int m31, int m32)
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
            this.m30 = m30;
            this.m31 = m31;
            this.m32 = m32;
        }

        /// <summary>
        /// Constructs this matrix from a int2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int2x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0;
            this.m20 = 0;
            this.m21 = 0;
            this.m22 = 1;
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int3x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0;
            this.m20 = m.m20;
            this.m21 = m.m21;
            this.m22 = 1;
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int4x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0;
            this.m20 = m.m20;
            this.m21 = m.m21;
            this.m22 = 1;
            this.m30 = m.m30;
            this.m31 = m.m31;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int2x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m20 = 0;
            this.m21 = 0;
            this.m22 = 1;
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int3x3 m)
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
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int4x3 m)
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
            this.m30 = m.m30;
            this.m31 = m.m31;
            this.m32 = m.m32;
        }

        /// <summary>
        /// Constructs this matrix from a int2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int2x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m20 = 0;
            this.m21 = 0;
            this.m22 = 1;
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int3x4 m)
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
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a int4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int4x4 m)
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
            this.m30 = m.m30;
            this.m31 = m.m31;
            this.m32 = m.m32;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int2 c0, int2 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = 0;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = 0;
            this.m20 = 0;
            this.m21 = 0;
            this.m22 = 1;
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int2 c0, int2 c1, int2 c2)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = 0;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = 0;
            this.m20 = c2.x;
            this.m21 = c2.y;
            this.m22 = 1;
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int2 c0, int2 c1, int2 c2, int2 c3)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = 0;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = 0;
            this.m20 = c2.x;
            this.m21 = c2.y;
            this.m22 = 1;
            this.m30 = c3.x;
            this.m31 = c3.y;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int3 c0, int3 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
            this.m20 = 0;
            this.m21 = 0;
            this.m22 = 1;
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int3 c0, int3 c1, int3 c2)
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
            this.m30 = 0;
            this.m31 = 0;
            this.m32 = 0;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public int4x3(int3 c0, int3 c1, int3 c2, int3 c3)
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
            this.m30 = c3.x;
            this.m31 = c3.y;
            this.m32 = c3.z;
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
        /// Gets or sets the column nr 2
        /// </summary>
        public int3 Column2
        {
            get
            {
                return new int3(m20, m21, m22);
            }
            set
            {
                m20 = value.x;
                m21 = value.y;
                m22 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the column nr 3
        /// </summary>
        public int3 Column3
        {
            get
            {
                return new int3(m30, m31, m32);
            }
            set
            {
                m30 = value.x;
                m31 = value.y;
                m32 = value.z;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 0
        /// </summary>
        public int4 Row0
        {
            get
            {
                return new int4(m00, m10, m20, m30);
            }
            set
            {
                m00 = value.x;
                m10 = value.y;
                m20 = value.z;
                m30 = value.w;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 1
        /// </summary>
        public int4 Row1
        {
            get
            {
                return new int4(m01, m11, m21, m31);
            }
            set
            {
                m01 = value.x;
                m11 = value.y;
                m21 = value.z;
                m31 = value.w;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 2
        /// </summary>
        public int4 Row2
        {
            get
            {
                return new int4(m02, m12, m22, m32);
            }
            set
            {
                m02 = value.x;
                m12 = value.y;
                m22 = value.z;
                m32 = value.w;
            }
        }

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        public static int4x3 Zero { get; } = new int4x3(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        public static int4x3 Ones { get; } = new int4x3(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        public static int4x3 Identity { get; } = new int4x3(1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0);

        /// <summary>
        /// Predefined all-MaxValue matrix
        /// </summary>
        public static int4x3 AllMaxValue { get; } = new int4x3(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);

        /// <summary>
        /// Predefined diagonal-MaxValue matrix
        /// </summary>
        public static int4x3 DiagonalMaxValue { get; } = new int4x3(int.MaxValue, 0, 0, 0, int.MaxValue, 0, 0, 0, int.MaxValue, 0, 0, 0);

        /// <summary>
        /// Predefined all-MinValue matrix
        /// </summary>
        public static int4x3 AllMinValue { get; } = new int4x3(int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue, int.MinValue);

        /// <summary>
        /// Predefined diagonal-MinValue matrix
        /// </summary>
        public static int4x3 DiagonalMinValue { get; } = new int4x3(int.MinValue, 0, 0, 0, int.MinValue, 0, 0, 0, int.MinValue, 0, 0, 0);

        #endregion


        /// <summary>
        /// Returns the number of Fields (4 x 3 = 12).
        /// </summary>
        public const int Count = 12;

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
                    case 6: return m20;
                    case 7: return m21;
                    case 8: return m22;
                    case 9: return m30;
                    case 10: return m31;
                    case 11: return m32;
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
                    case 9: this.m30 = value; break;
                    case 10: this.m31 = value; break;
                    case 11: this.m32 = value; break;
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
        public bool Equals(int4x3 rhs) => ((((m00.Equals(rhs.m00) && m01.Equals(rhs.m01)) && m02.Equals(rhs.m02)) && ((m10.Equals(rhs.m10) && m11.Equals(rhs.m11)) && m12.Equals(rhs.m12))) && (((m20.Equals(rhs.m20) && m21.Equals(rhs.m21)) && m22.Equals(rhs.m22)) && ((m30.Equals(rhs.m30) && m31.Equals(rhs.m31)) && m32.Equals(rhs.m32))));

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(int4x3 lhs, int4x3 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(int4x3 lhs, int4x3 rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((((((((((((((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m02.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode()) * 397) ^ m12.GetHashCode()) * 397) ^ m20.GetHashCode()) * 397) ^ m21.GetHashCode()) * 397) ^ m22.GetHashCode()) * 397) ^ m30.GetHashCode()) * 397) ^ m31.GetHashCode()) * 397) ^ m32.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public int3x4 Transposed => new int3x4(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32);

        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public int MinElement => Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(Math.Min(m00, m01), m02), m10), m11), m12), m20), m21), m22), m30), m31), m32);

        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public int MaxElement => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(m00, m01), m02), m10), m11), m12), m20), m21), m22), m30), m31), m32);

        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public float Length => (float)Math.Sqrt(((((m00 * m00 + m01 * m01) + m02 * m02) + ((m10 * m10 + m11 * m11) + m12 * m12)) + (((m20 * m20 + m21 * m21) + m22 * m22) + ((m30 * m30 + m31 * m31) + m32 * m32))));

        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public float LengthSqr => ((((m00 * m00 + m01 * m01) + m02 * m02) + ((m10 * m10 + m11 * m11) + m12 * m12)) + (((m20 * m20 + m21 * m21) + m22 * m22) + ((m30 * m30 + m31 * m31) + m32 * m32)));

        /// <summary>
        /// Returns the sum of all fields.
        /// </summary>
        public int Sum => ((((m00 + m01) + m02) + ((m10 + m11) + m12)) + (((m20 + m21) + m22) + ((m30 + m31) + m32)));

        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public float Norm => (float)Math.Sqrt(((((m00 * m00 + m01 * m01) + m02 * m02) + ((m10 * m10 + m11 * m11) + m12 * m12)) + (((m20 * m20 + m21 * m21) + m22 * m22) + ((m30 * m30 + m31 * m31) + m32 * m32))));

        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public float Norm1 => ((((Math.Abs(m00) + Math.Abs(m01)) + Math.Abs(m02)) + ((Math.Abs(m10) + Math.Abs(m11)) + Math.Abs(m12))) + (((Math.Abs(m20) + Math.Abs(m21)) + Math.Abs(m22)) + ((Math.Abs(m30) + Math.Abs(m31)) + Math.Abs(m32))));

        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt(((((m00 * m00 + m01 * m01) + m02 * m02) + ((m10 * m10 + m11 * m11) + m12 * m12)) + (((m20 * m20 + m21 * m21) + m22 * m22) + ((m30 * m30 + m31 * m31) + m32 * m32))));

        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public int NormMax => Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(Math.Abs(m00), Math.Abs(m01)), Math.Abs(m02)), Math.Abs(m10)), Math.Abs(m11)), Math.Abs(m12)), Math.Abs(m20)), Math.Abs(m21)), Math.Abs(m22)), Math.Abs(m30)), Math.Abs(m31)), Math.Abs(m32));

        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => Math.Pow(((((Math.Pow(Math.Abs(m00), p) + Math.Pow(Math.Abs(m01), p)) + Math.Pow(Math.Abs(m02), p)) + ((Math.Pow(Math.Abs(m10), p) + Math.Pow(Math.Abs(m11), p)) + Math.Pow(Math.Abs(m12), p))) + (((Math.Pow(Math.Abs(m20), p) + Math.Pow(Math.Abs(m21), p)) + Math.Pow(Math.Abs(m22), p)) + ((Math.Pow(Math.Abs(m30), p) + Math.Pow(Math.Abs(m31), p)) + Math.Pow(Math.Abs(m32), p)))), 1 / p);

        /// <summary>
        /// Executes a matrix-matrix-multiplication int4x3 * int2x4 -> int2x3.
        /// </summary>
        public static int2x3 operator *(int4x3 lhs, int2x4 rhs) => new int2x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)));

        /// <summary>
        /// Executes a matrix-matrix-multiplication int4x3 * int3x4 -> int3x3.
        /// </summary>
        public static int3x3 operator *(int4x3 lhs, int3x4 rhs) => new int3x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + (lhs.m22 * rhs.m22 + lhs.m32 * rhs.m23)));

        /// <summary>
        /// Executes a matrix-matrix-multiplication int4x3 * int4x4 -> int4x3.
        /// </summary>
        public static int4x3 operator *(int4x3 lhs, int4x4 rhs) => new int4x3(((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01) + (lhs.m20 * rhs.m02 + lhs.m30 * rhs.m03)), ((lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01) + (lhs.m21 * rhs.m02 + lhs.m31 * rhs.m03)), ((lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01) + (lhs.m22 * rhs.m02 + lhs.m32 * rhs.m03)), ((lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11) + (lhs.m20 * rhs.m12 + lhs.m30 * rhs.m13)), ((lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11) + (lhs.m21 * rhs.m12 + lhs.m31 * rhs.m13)), ((lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11) + (lhs.m22 * rhs.m12 + lhs.m32 * rhs.m13)), ((lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21) + (lhs.m20 * rhs.m22 + lhs.m30 * rhs.m23)), ((lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21) + (lhs.m21 * rhs.m22 + lhs.m31 * rhs.m23)), ((lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21) + (lhs.m22 * rhs.m22 + lhs.m32 * rhs.m23)), ((lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31) + (lhs.m20 * rhs.m32 + lhs.m30 * rhs.m33)), ((lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31) + (lhs.m21 * rhs.m32 + lhs.m31 * rhs.m33)), ((lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31) + (lhs.m22 * rhs.m32 + lhs.m32 * rhs.m33)));

        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static int3 operator *(int4x3 m, int4 v) => new int3(((m.m00 * v.x + m.m10 * v.y) + (m.m20 * v.z + m.m30 * v.w)), ((m.m01 * v.x + m.m11 * v.y) + (m.m21 * v.z + m.m31 * v.w)), ((m.m02 * v.x + m.m12 * v.y) + (m.m22 * v.z + m.m32 * v.w)));

        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static int4x3 CompMul(int4x3 A, int4x3 B) => new int4x3(A.m00 * B.m00, A.m01 * B.m01, A.m02 * B.m02, A.m10 * B.m10, A.m11 * B.m11, A.m12 * B.m12, A.m20 * B.m20, A.m21 * B.m21, A.m22 * B.m22, A.m30 * B.m30, A.m31 * B.m31, A.m32 * B.m32);

        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static int4x3 CompDiv(int4x3 A, int4x3 B) => new int4x3(A.m00 / B.m00, A.m01 / B.m01, A.m02 / B.m02, A.m10 / B.m10, A.m11 / B.m11, A.m12 / B.m12, A.m20 / B.m20, A.m21 / B.m21, A.m22 / B.m22, A.m30 / B.m30, A.m31 / B.m31, A.m32 / B.m32);

        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static int4x3 CompAdd(int4x3 A, int4x3 B) => new int4x3(A.m00 + B.m00, A.m01 + B.m01, A.m02 + B.m02, A.m10 + B.m10, A.m11 + B.m11, A.m12 + B.m12, A.m20 + B.m20, A.m21 + B.m21, A.m22 + B.m22, A.m30 + B.m30, A.m31 + B.m31, A.m32 + B.m32);

        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static int4x3 CompSub(int4x3 A, int4x3 B) => new int4x3(A.m00 - B.m00, A.m01 - B.m01, A.m02 - B.m02, A.m10 - B.m10, A.m11 - B.m11, A.m12 - B.m12, A.m20 - B.m20, A.m21 - B.m21, A.m22 - B.m22, A.m30 - B.m30, A.m31 - B.m31, A.m32 - B.m32);

        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static int4x3 operator +(int4x3 lhs, int4x3 rhs) => new int4x3(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m02 + rhs.m02, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11, lhs.m12 + rhs.m12, lhs.m20 + rhs.m20, lhs.m21 + rhs.m21, lhs.m22 + rhs.m22, lhs.m30 + rhs.m30, lhs.m31 + rhs.m31, lhs.m32 + rhs.m32);

        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static int4x3 operator +(int4x3 lhs, int rhs) => new int4x3(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m02 + rhs, lhs.m10 + rhs, lhs.m11 + rhs, lhs.m12 + rhs, lhs.m20 + rhs, lhs.m21 + rhs, lhs.m22 + rhs, lhs.m30 + rhs, lhs.m31 + rhs, lhs.m32 + rhs);

        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static int4x3 operator +(int lhs, int4x3 rhs) => new int4x3(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m02, lhs + rhs.m10, lhs + rhs.m11, lhs + rhs.m12, lhs + rhs.m20, lhs + rhs.m21, lhs + rhs.m22, lhs + rhs.m30, lhs + rhs.m31, lhs + rhs.m32);

        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static int4x3 operator -(int4x3 lhs, int4x3 rhs) => new int4x3(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m02 - rhs.m02, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11, lhs.m12 - rhs.m12, lhs.m20 - rhs.m20, lhs.m21 - rhs.m21, lhs.m22 - rhs.m22, lhs.m30 - rhs.m30, lhs.m31 - rhs.m31, lhs.m32 - rhs.m32);

        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static int4x3 operator -(int4x3 lhs, int rhs) => new int4x3(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m02 - rhs, lhs.m10 - rhs, lhs.m11 - rhs, lhs.m12 - rhs, lhs.m20 - rhs, lhs.m21 - rhs, lhs.m22 - rhs, lhs.m30 - rhs, lhs.m31 - rhs, lhs.m32 - rhs);

        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static int4x3 operator -(int lhs, int4x3 rhs) => new int4x3(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m02, lhs - rhs.m10, lhs - rhs.m11, lhs - rhs.m12, lhs - rhs.m20, lhs - rhs.m21, lhs - rhs.m22, lhs - rhs.m30, lhs - rhs.m31, lhs - rhs.m32);

        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static int4x3 operator /(int4x3 lhs, int rhs) => new int4x3(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m02 / rhs, lhs.m10 / rhs, lhs.m11 / rhs, lhs.m12 / rhs, lhs.m20 / rhs, lhs.m21 / rhs, lhs.m22 / rhs, lhs.m30 / rhs, lhs.m31 / rhs, lhs.m32 / rhs);

        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static int4x3 operator /(int lhs, int4x3 rhs) => new int4x3(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m02, lhs / rhs.m10, lhs / rhs.m11, lhs / rhs.m12, lhs / rhs.m20, lhs / rhs.m21, lhs / rhs.m22, lhs / rhs.m30, lhs / rhs.m31, lhs / rhs.m32);

        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static int4x3 operator *(int4x3 lhs, int rhs) => new int4x3(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m02 * rhs, lhs.m10 * rhs, lhs.m11 * rhs, lhs.m12 * rhs, lhs.m20 * rhs, lhs.m21 * rhs, lhs.m22 * rhs, lhs.m30 * rhs, lhs.m31 * rhs, lhs.m32 * rhs);

        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static int4x3 operator *(int lhs, int4x3 rhs) => new int4x3(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m02, lhs * rhs.m10, lhs * rhs.m11, lhs * rhs.m12, lhs * rhs.m20, lhs * rhs.m21, lhs * rhs.m22, lhs * rhs.m30, lhs * rhs.m31, lhs * rhs.m32);

        /// <summary>
        /// Executes a component-wise % (modulo).
        /// </summary>
        public static int4x3 operator %(int4x3 lhs, int4x3 rhs) => new int4x3(lhs.m00 % rhs.m00, lhs.m01 % rhs.m01, lhs.m02 % rhs.m02, lhs.m10 % rhs.m10, lhs.m11 % rhs.m11, lhs.m12 % rhs.m12, lhs.m20 % rhs.m20, lhs.m21 % rhs.m21, lhs.m22 % rhs.m22, lhs.m30 % rhs.m30, lhs.m31 % rhs.m31, lhs.m32 % rhs.m32);

        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static int4x3 operator %(int4x3 lhs, int rhs) => new int4x3(lhs.m00 % rhs, lhs.m01 % rhs, lhs.m02 % rhs, lhs.m10 % rhs, lhs.m11 % rhs, lhs.m12 % rhs, lhs.m20 % rhs, lhs.m21 % rhs, lhs.m22 % rhs, lhs.m30 % rhs, lhs.m31 % rhs, lhs.m32 % rhs);

        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static int4x3 operator %(int lhs, int4x3 rhs) => new int4x3(lhs % rhs.m00, lhs % rhs.m01, lhs % rhs.m02, lhs % rhs.m10, lhs % rhs.m11, lhs % rhs.m12, lhs % rhs.m20, lhs % rhs.m21, lhs % rhs.m22, lhs % rhs.m30, lhs % rhs.m31, lhs % rhs.m32);

        /// <summary>
        /// Executes a component-wise ^ (xor).
        /// </summary>
        public static int4x3 operator ^(int4x3 lhs, int4x3 rhs) => new int4x3(lhs.m00 ^ rhs.m00, lhs.m01 ^ rhs.m01, lhs.m02 ^ rhs.m02, lhs.m10 ^ rhs.m10, lhs.m11 ^ rhs.m11, lhs.m12 ^ rhs.m12, lhs.m20 ^ rhs.m20, lhs.m21 ^ rhs.m21, lhs.m22 ^ rhs.m22, lhs.m30 ^ rhs.m30, lhs.m31 ^ rhs.m31, lhs.m32 ^ rhs.m32);

        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static int4x3 operator ^(int4x3 lhs, int rhs) => new int4x3(lhs.m00 ^ rhs, lhs.m01 ^ rhs, lhs.m02 ^ rhs, lhs.m10 ^ rhs, lhs.m11 ^ rhs, lhs.m12 ^ rhs, lhs.m20 ^ rhs, lhs.m21 ^ rhs, lhs.m22 ^ rhs, lhs.m30 ^ rhs, lhs.m31 ^ rhs, lhs.m32 ^ rhs);

        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static int4x3 operator ^(int lhs, int4x3 rhs) => new int4x3(lhs ^ rhs.m00, lhs ^ rhs.m01, lhs ^ rhs.m02, lhs ^ rhs.m10, lhs ^ rhs.m11, lhs ^ rhs.m12, lhs ^ rhs.m20, lhs ^ rhs.m21, lhs ^ rhs.m22, lhs ^ rhs.m30, lhs ^ rhs.m31, lhs ^ rhs.m32);

        /// <summary>
        /// Executes a component-wise | (bitwise-or).
        /// </summary>
        public static int4x3 operator |(int4x3 lhs, int4x3 rhs) => new int4x3(lhs.m00 | rhs.m00, lhs.m01 | rhs.m01, lhs.m02 | rhs.m02, lhs.m10 | rhs.m10, lhs.m11 | rhs.m11, lhs.m12 | rhs.m12, lhs.m20 | rhs.m20, lhs.m21 | rhs.m21, lhs.m22 | rhs.m22, lhs.m30 | rhs.m30, lhs.m31 | rhs.m31, lhs.m32 | rhs.m32);

        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static int4x3 operator |(int4x3 lhs, int rhs) => new int4x3(lhs.m00 | rhs, lhs.m01 | rhs, lhs.m02 | rhs, lhs.m10 | rhs, lhs.m11 | rhs, lhs.m12 | rhs, lhs.m20 | rhs, lhs.m21 | rhs, lhs.m22 | rhs, lhs.m30 | rhs, lhs.m31 | rhs, lhs.m32 | rhs);

        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static int4x3 operator |(int lhs, int4x3 rhs) => new int4x3(lhs | rhs.m00, lhs | rhs.m01, lhs | rhs.m02, lhs | rhs.m10, lhs | rhs.m11, lhs | rhs.m12, lhs | rhs.m20, lhs | rhs.m21, lhs | rhs.m22, lhs | rhs.m30, lhs | rhs.m31, lhs | rhs.m32);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and).
        /// </summary>
        public static int4x3 operator &(int4x3 lhs, int4x3 rhs) => new int4x3(lhs.m00 & rhs.m00, lhs.m01 & rhs.m01, lhs.m02 & rhs.m02, lhs.m10 & rhs.m10, lhs.m11 & rhs.m11, lhs.m12 & rhs.m12, lhs.m20 & rhs.m20, lhs.m21 & rhs.m21, lhs.m22 & rhs.m22, lhs.m30 & rhs.m30, lhs.m31 & rhs.m31, lhs.m32 & rhs.m32);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static int4x3 operator &(int4x3 lhs, int rhs) => new int4x3(lhs.m00 & rhs, lhs.m01 & rhs, lhs.m02 & rhs, lhs.m10 & rhs, lhs.m11 & rhs, lhs.m12 & rhs, lhs.m20 & rhs, lhs.m21 & rhs, lhs.m22 & rhs, lhs.m30 & rhs, lhs.m31 & rhs, lhs.m32 & rhs);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static int4x3 operator &(int lhs, int4x3 rhs) => new int4x3(lhs & rhs.m00, lhs & rhs.m01, lhs & rhs.m02, lhs & rhs.m10, lhs & rhs.m11, lhs & rhs.m12, lhs & rhs.m20, lhs & rhs.m21, lhs & rhs.m22, lhs & rhs.m30, lhs & rhs.m31, lhs & rhs.m32);

        /// <summary>
        /// Executes a component-wise left-shift with a scalar.
        /// </summary>
        public static int4x3 operator <<(int4x3 lhs, int rhs) => new int4x3(lhs.m00 << rhs, lhs.m01 << rhs, lhs.m02 << rhs, lhs.m10 << rhs, lhs.m11 << rhs, lhs.m12 << rhs, lhs.m20 << rhs, lhs.m21 << rhs, lhs.m22 << rhs, lhs.m30 << rhs, lhs.m31 << rhs, lhs.m32 << rhs);

        /// <summary>
        /// Executes a component-wise right-shift with a scalar.
        /// </summary>
        public static int4x3 operator >>(int4x3 lhs, int rhs) => new int4x3(lhs.m00 >> rhs, lhs.m01 >> rhs, lhs.m02 >> rhs, lhs.m10 >> rhs, lhs.m11 >> rhs, lhs.m12 >> rhs, lhs.m20 >> rhs, lhs.m21 >> rhs, lhs.m22 >> rhs, lhs.m30 >> rhs, lhs.m31 >> rhs, lhs.m32 >> rhs);

        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bool4x3 operator <(int4x3 lhs, int4x3 rhs) => new bool4x3(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m02 < rhs.m02, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11, lhs.m12 < rhs.m12, lhs.m20 < rhs.m20, lhs.m21 < rhs.m21, lhs.m22 < rhs.m22, lhs.m30 < rhs.m30, lhs.m31 < rhs.m31, lhs.m32 < rhs.m32);

        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool4x3 operator <(int4x3 lhs, int rhs) => new bool4x3(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m02 < rhs, lhs.m10 < rhs, lhs.m11 < rhs, lhs.m12 < rhs, lhs.m20 < rhs, lhs.m21 < rhs, lhs.m22 < rhs, lhs.m30 < rhs, lhs.m31 < rhs, lhs.m32 < rhs);

        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool4x3 operator <(int lhs, int4x3 rhs) => new bool4x3(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m02, lhs < rhs.m10, lhs < rhs.m11, lhs < rhs.m12, lhs < rhs.m20, lhs < rhs.m21, lhs < rhs.m22, lhs < rhs.m30, lhs < rhs.m31, lhs < rhs.m32);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bool4x3 operator <=(int4x3 lhs, int4x3 rhs) => new bool4x3(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m02 <= rhs.m02, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11, lhs.m12 <= rhs.m12, lhs.m20 <= rhs.m20, lhs.m21 <= rhs.m21, lhs.m22 <= rhs.m22, lhs.m30 <= rhs.m30, lhs.m31 <= rhs.m31, lhs.m32 <= rhs.m32);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x3 operator <=(int4x3 lhs, int rhs) => new bool4x3(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m02 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs, lhs.m12 <= rhs, lhs.m20 <= rhs, lhs.m21 <= rhs, lhs.m22 <= rhs, lhs.m30 <= rhs, lhs.m31 <= rhs, lhs.m32 <= rhs);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x3 operator <=(int lhs, int4x3 rhs) => new bool4x3(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m02, lhs <= rhs.m10, lhs <= rhs.m11, lhs <= rhs.m12, lhs <= rhs.m20, lhs <= rhs.m21, lhs <= rhs.m22, lhs <= rhs.m30, lhs <= rhs.m31, lhs <= rhs.m32);

        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bool4x3 operator >(int4x3 lhs, int4x3 rhs) => new bool4x3(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m02 > rhs.m02, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11, lhs.m12 > rhs.m12, lhs.m20 > rhs.m20, lhs.m21 > rhs.m21, lhs.m22 > rhs.m22, lhs.m30 > rhs.m30, lhs.m31 > rhs.m31, lhs.m32 > rhs.m32);

        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool4x3 operator >(int4x3 lhs, int rhs) => new bool4x3(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m02 > rhs, lhs.m10 > rhs, lhs.m11 > rhs, lhs.m12 > rhs, lhs.m20 > rhs, lhs.m21 > rhs, lhs.m22 > rhs, lhs.m30 > rhs, lhs.m31 > rhs, lhs.m32 > rhs);

        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool4x3 operator >(int lhs, int4x3 rhs) => new bool4x3(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m02, lhs > rhs.m10, lhs > rhs.m11, lhs > rhs.m12, lhs > rhs.m20, lhs > rhs.m21, lhs > rhs.m22, lhs > rhs.m30, lhs > rhs.m31, lhs > rhs.m32);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bool4x3 operator >=(int4x3 lhs, int4x3 rhs) => new bool4x3(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m02 >= rhs.m02, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11, lhs.m12 >= rhs.m12, lhs.m20 >= rhs.m20, lhs.m21 >= rhs.m21, lhs.m22 >= rhs.m22, lhs.m30 >= rhs.m30, lhs.m31 >= rhs.m31, lhs.m32 >= rhs.m32);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x3 operator >=(int4x3 lhs, int rhs) => new bool4x3(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m02 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs, lhs.m12 >= rhs, lhs.m20 >= rhs, lhs.m21 >= rhs, lhs.m22 >= rhs, lhs.m30 >= rhs, lhs.m31 >= rhs, lhs.m32 >= rhs);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool4x3 operator >=(int lhs, int4x3 rhs) => new bool4x3(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m02, lhs >= rhs.m10, lhs >= rhs.m11, lhs >= rhs.m12, lhs >= rhs.m20, lhs >= rhs.m21, lhs >= rhs.m22, lhs >= rhs.m30, lhs >= rhs.m31, lhs >= rhs.m32);
    }
}
