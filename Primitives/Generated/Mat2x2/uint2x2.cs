using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A matrix of type uint with 2 columns and 2 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct uint2x2
    {

        #region Fields

        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        [DataMember]
        public uint m00;

        /// <summary>
        /// Column 0, Rows 1
        /// </summary>
        [DataMember]
        public uint m01;

        /// <summary>
        /// Column 1, Rows 0
        /// </summary>
        [DataMember]
        public uint m10;

        /// <summary>
        /// Column 1, Rows 1
        /// </summary>
        [DataMember]
        public uint m11;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public uint2x2(uint m00, uint m01, uint m10, uint m11)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m10 = m10;
            this.m11 = m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint2x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint3x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint4x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint2x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint3x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint4x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint2x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint3x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a uint4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint4x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public uint2x2(uint2 c0, uint2 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m10 = c1.x;
            this.m11 = c1.y;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets the column nr 0
        /// </summary>
        public uint2 Column0
        {
            get
            {
                return new uint2(m00, m01);
            }
            set
            {
                m00 = value.x;
                m01 = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the column nr 1
        /// </summary>
        public uint2 Column1
        {
            get
            {
                return new uint2(m10, m11);
            }
            set
            {
                m10 = value.x;
                m11 = value.y;
            }
        }

        /// <summary>
        /// Gets or sets the row nr 0
        /// </summary>
        public uint2 Row0
        {
            get
            {
                return new uint2(m00, m10);
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
        public uint2 Row1
        {
            get
            {
                return new uint2(m01, m11);
            }
            set
            {
                m01 = value.x;
                m11 = value.y;
            }
        }

        #endregion


        #region Static Properties

        /// <summary>
        /// Predefined all-zero matrix
        /// </summary>
        public static uint2x2 Zero { get; } = new uint2x2(0u, 0u, 0u, 0u);

        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        public static uint2x2 Ones { get; } = new uint2x2(1u, 1u, 1u, 1u);

        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        public static uint2x2 Identity { get; } = new uint2x2(1u, 0u, 0u, 1u);

        /// <summary>
        /// Predefined all-MaxValue matrix
        /// </summary>
        public static uint2x2 AllMaxValue { get; } = new uint2x2(uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue);

        /// <summary>
        /// Predefined diagonal-MaxValue matrix
        /// </summary>
        public static uint2x2 DiagonalMaxValue { get; } = new uint2x2(uint.MaxValue, 0u, 0u, uint.MaxValue);

        /// <summary>
        /// Predefined all-MinValue matrix
        /// </summary>
        public static uint2x2 AllMinValue { get; } = new uint2x2(uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue);

        /// <summary>
        /// Predefined diagonal-MinValue matrix
        /// </summary>
        public static uint2x2 DiagonalMinValue { get; } = new uint2x2(uint.MinValue, 0u, 0u, uint.MinValue);

        #endregion


        /// <summary>
        /// Returns the number of Fields (2 x 2 = 4).
        /// </summary>
        public const int Count = 4;

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public uint this[int fieldIndex]
        {
            get
            {
                switch (fieldIndex)
                {
                    case 0: return m00;
                    case 1: return m01;
                    case 2: return m10;
                    case 3: return m11;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
            set
            {
                switch (fieldIndex)
                {
                    case 0: this.m00 = value; break;
                    case 1: this.m01 = value; break;
                    case 2: this.m10 = value; break;
                    case 3: this.m11 = value; break;
                    default: throw new ArgumentOutOfRangeException("fieldIndex");
                }
            }
        }

        /// <summary>
        /// Gets/Sets a specific 2D-indexed component (a bit slower than direct access).
        /// </summary>
        public uint this[int col, int row]
        {
            get
            {
                return this[col * 2 + row];
            }
            set
            {
                this[col * 2 + row] = value;
            }
        }

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public bool Equals(uint2x2 rhs) => ((m00.Equals(rhs.m00) && m01.Equals(rhs.m01)) && (m10.Equals(rhs.m10) && m11.Equals(rhs.m11)));

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(uint2x2 lhs, uint2x2 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(uint2x2 lhs, uint2x2 rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((m00.GetHashCode()) * 397) ^ m01.GetHashCode()) * 397) ^ m10.GetHashCode()) * 397) ^ m11.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public uint2x2 Transposed => new uint2x2(m00, m10, m01, m11);

        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public uint MinElement => Math.Min(Math.Min(Math.Min(m00, m01), m10), m11);

        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public uint MaxElement => Math.Max(Math.Max(Math.Max(m00, m01), m10), m11);

        /// <summary>
        /// Returns the euclidean length of this matrix.
        /// </summary>
        public float Length => (float)Math.Sqrt(((m00 * m00 + m01 * m01) + (m10 * m10 + m11 * m11)));

        /// <summary>
        /// Returns the squared euclidean length of this matrix.
        /// </summary>
        public float LengthSqr => ((m00 * m00 + m01 * m01) + (m10 * m10 + m11 * m11));

        /// <summary>
        /// Returns the sum of all fields.
        /// </summary>
        public uint Sum => ((m00 + m01) + (m10 + m11));

        /// <summary>
        /// Returns the euclidean norm of this matrix.
        /// </summary>
        public float Norm => (float)Math.Sqrt(((m00 * m00 + m01 * m01) + (m10 * m10 + m11 * m11)));

        /// <summary>
        /// Returns the one-norm of this matrix.
        /// </summary>
        public float Norm1 => ((m00 + m01) + (m10 + m11));

        /// <summary>
        /// Returns the two-norm of this matrix.
        /// </summary>
        public float Norm2 => (float)Math.Sqrt(((m00 * m00 + m01 * m01) + (m10 * m10 + m11 * m11)));

        /// <summary>
        /// Returns the max-norm of this matrix.
        /// </summary>
        public uint NormMax => Math.Max(Math.Max(Math.Max(m00, m01), m10), m11);

        /// <summary>
        /// Returns the p-norm of this matrix.
        /// </summary>
        public double NormP(double p) => Math.Pow(((Math.Pow(m00, p) + Math.Pow(m01, p)) + (Math.Pow(m10, p) + Math.Pow(m11, p))), 1 / p);

        /// <summary>
        /// Returns determinant of this matrix.
        /// </summary>
        public uint Determinant => m00 * m11 - m10 * m01;

        /// <summary>
        /// Executes a matrix-matrix-multiplication uint2x2 * uint2x2 -> uint2x2.
        /// </summary>
        public static uint2x2 operator *(uint2x2 lhs, uint2x2 rhs) => new uint2x2((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11));

        /// <summary>
        /// Executes a matrix-matrix-multiplication uint2x2 * uint3x2 -> uint3x2.
        /// </summary>
        public static uint3x2 operator *(uint2x2 lhs, uint3x2 rhs) => new uint3x2((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21), (lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21));

        /// <summary>
        /// Executes a matrix-matrix-multiplication uint2x2 * uint4x2 -> uint4x2.
        /// </summary>
        public static uint4x2 operator *(uint2x2 lhs, uint4x2 rhs) => new uint4x2((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21), (lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21), (lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31), (lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31));

        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static uint2 operator *(uint2x2 m, uint2 v) => new uint2((m.m00 * v.x + m.m10 * v.y), (m.m01 * v.x + m.m11 * v.y));

        /// <summary>
        /// Executes a component-wise * (multiply).
        /// </summary>
        public static uint2x2 CompMul(uint2x2 A, uint2x2 B) => new uint2x2(A.m00 * B.m00, A.m01 * B.m01, A.m10 * B.m10, A.m11 * B.m11);

        /// <summary>
        /// Executes a component-wise / (divide).
        /// </summary>
        public static uint2x2 CompDiv(uint2x2 A, uint2x2 B) => new uint2x2(A.m00 / B.m00, A.m01 / B.m01, A.m10 / B.m10, A.m11 / B.m11);

        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static uint2x2 CompAdd(uint2x2 A, uint2x2 B) => new uint2x2(A.m00 + B.m00, A.m01 + B.m01, A.m10 + B.m10, A.m11 + B.m11);

        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static uint2x2 CompSub(uint2x2 A, uint2x2 B) => new uint2x2(A.m00 - B.m00, A.m01 - B.m01, A.m10 - B.m10, A.m11 - B.m11);

        /// <summary>
        /// Executes a component-wise + (add).
        /// </summary>
        public static uint2x2 operator +(uint2x2 lhs, uint2x2 rhs) => new uint2x2(lhs.m00 + rhs.m00, lhs.m01 + rhs.m01, lhs.m10 + rhs.m10, lhs.m11 + rhs.m11);

        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static uint2x2 operator +(uint2x2 lhs, uint rhs) => new uint2x2(lhs.m00 + rhs, lhs.m01 + rhs, lhs.m10 + rhs, lhs.m11 + rhs);

        /// <summary>
        /// Executes a component-wise + (add) with a scalar.
        /// </summary>
        public static uint2x2 operator +(uint lhs, uint2x2 rhs) => new uint2x2(lhs + rhs.m00, lhs + rhs.m01, lhs + rhs.m10, lhs + rhs.m11);

        /// <summary>
        /// Executes a component-wise - (subtract).
        /// </summary>
        public static uint2x2 operator -(uint2x2 lhs, uint2x2 rhs) => new uint2x2(lhs.m00 - rhs.m00, lhs.m01 - rhs.m01, lhs.m10 - rhs.m10, lhs.m11 - rhs.m11);

        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static uint2x2 operator -(uint2x2 lhs, uint rhs) => new uint2x2(lhs.m00 - rhs, lhs.m01 - rhs, lhs.m10 - rhs, lhs.m11 - rhs);

        /// <summary>
        /// Executes a component-wise - (subtract) with a scalar.
        /// </summary>
        public static uint2x2 operator -(uint lhs, uint2x2 rhs) => new uint2x2(lhs - rhs.m00, lhs - rhs.m01, lhs - rhs.m10, lhs - rhs.m11);

        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static uint2x2 operator /(uint2x2 lhs, uint rhs) => new uint2x2(lhs.m00 / rhs, lhs.m01 / rhs, lhs.m10 / rhs, lhs.m11 / rhs);

        /// <summary>
        /// Executes a component-wise / (divide) with a scalar.
        /// </summary>
        public static uint2x2 operator /(uint lhs, uint2x2 rhs) => new uint2x2(lhs / rhs.m00, lhs / rhs.m01, lhs / rhs.m10, lhs / rhs.m11);

        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static uint2x2 operator *(uint2x2 lhs, uint rhs) => new uint2x2(lhs.m00 * rhs, lhs.m01 * rhs, lhs.m10 * rhs, lhs.m11 * rhs);

        /// <summary>
        /// Executes a component-wise * (multiply) with a scalar.
        /// </summary>
        public static uint2x2 operator *(uint lhs, uint2x2 rhs) => new uint2x2(lhs * rhs.m00, lhs * rhs.m01, lhs * rhs.m10, lhs * rhs.m11);

        /// <summary>
        /// Executes a component-wise % (modulo).
        /// </summary>
        public static uint2x2 operator %(uint2x2 lhs, uint2x2 rhs) => new uint2x2(lhs.m00 % rhs.m00, lhs.m01 % rhs.m01, lhs.m10 % rhs.m10, lhs.m11 % rhs.m11);

        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static uint2x2 operator %(uint2x2 lhs, uint rhs) => new uint2x2(lhs.m00 % rhs, lhs.m01 % rhs, lhs.m10 % rhs, lhs.m11 % rhs);

        /// <summary>
        /// Executes a component-wise % (modulo) with a scalar.
        /// </summary>
        public static uint2x2 operator %(uint lhs, uint2x2 rhs) => new uint2x2(lhs % rhs.m00, lhs % rhs.m01, lhs % rhs.m10, lhs % rhs.m11);

        /// <summary>
        /// Executes a component-wise ^ (xor).
        /// </summary>
        public static uint2x2 operator ^(uint2x2 lhs, uint2x2 rhs) => new uint2x2(lhs.m00 ^ rhs.m00, lhs.m01 ^ rhs.m01, lhs.m10 ^ rhs.m10, lhs.m11 ^ rhs.m11);

        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static uint2x2 operator ^(uint2x2 lhs, uint rhs) => new uint2x2(lhs.m00 ^ rhs, lhs.m01 ^ rhs, lhs.m10 ^ rhs, lhs.m11 ^ rhs);

        /// <summary>
        /// Executes a component-wise ^ (xor) with a scalar.
        /// </summary>
        public static uint2x2 operator ^(uint lhs, uint2x2 rhs) => new uint2x2(lhs ^ rhs.m00, lhs ^ rhs.m01, lhs ^ rhs.m10, lhs ^ rhs.m11);

        /// <summary>
        /// Executes a component-wise | (bitwise-or).
        /// </summary>
        public static uint2x2 operator |(uint2x2 lhs, uint2x2 rhs) => new uint2x2(lhs.m00 | rhs.m00, lhs.m01 | rhs.m01, lhs.m10 | rhs.m10, lhs.m11 | rhs.m11);

        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static uint2x2 operator |(uint2x2 lhs, uint rhs) => new uint2x2(lhs.m00 | rhs, lhs.m01 | rhs, lhs.m10 | rhs, lhs.m11 | rhs);

        /// <summary>
        /// Executes a component-wise | (bitwise-or) with a scalar.
        /// </summary>
        public static uint2x2 operator |(uint lhs, uint2x2 rhs) => new uint2x2(lhs | rhs.m00, lhs | rhs.m01, lhs | rhs.m10, lhs | rhs.m11);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and).
        /// </summary>
        public static uint2x2 operator &(uint2x2 lhs, uint2x2 rhs) => new uint2x2(lhs.m00 & rhs.m00, lhs.m01 & rhs.m01, lhs.m10 & rhs.m10, lhs.m11 & rhs.m11);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static uint2x2 operator &(uint2x2 lhs, uint rhs) => new uint2x2(lhs.m00 & rhs, lhs.m01 & rhs, lhs.m10 & rhs, lhs.m11 & rhs);

        /// <summary>
        /// Executes a component-wise &amp; (bitwise-and) with a scalar.
        /// </summary>
        public static uint2x2 operator &(uint lhs, uint2x2 rhs) => new uint2x2(lhs & rhs.m00, lhs & rhs.m01, lhs & rhs.m10, lhs & rhs.m11);

        /// <summary>
        /// Executes a component-wise left-shift with a scalar.
        /// </summary>
        public static uint2x2 operator <<(uint2x2 lhs, int rhs) => new uint2x2(lhs.m00 << rhs, lhs.m01 << rhs, lhs.m10 << rhs, lhs.m11 << rhs);

        /// <summary>
        /// Executes a component-wise right-shift with a scalar.
        /// </summary>
        public static uint2x2 operator >>(uint2x2 lhs, int rhs) => new uint2x2(lhs.m00 >> rhs, lhs.m01 >> rhs, lhs.m10 >> rhs, lhs.m11 >> rhs);

        /// <summary>
        /// Executes a component-wise lesser-than comparison.
        /// </summary>
        public static bool2x2 operator <(uint2x2 lhs, uint2x2 rhs) => new bool2x2(lhs.m00 < rhs.m00, lhs.m01 < rhs.m01, lhs.m10 < rhs.m10, lhs.m11 < rhs.m11);

        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool2x2 operator <(uint2x2 lhs, uint rhs) => new bool2x2(lhs.m00 < rhs, lhs.m01 < rhs, lhs.m10 < rhs, lhs.m11 < rhs);

        /// <summary>
        /// Executes a component-wise lesser-than comparison with a scalar.
        /// </summary>
        public static bool2x2 operator <(uint lhs, uint2x2 rhs) => new bool2x2(lhs < rhs.m00, lhs < rhs.m01, lhs < rhs.m10, lhs < rhs.m11);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison.
        /// </summary>
        public static bool2x2 operator <=(uint2x2 lhs, uint2x2 rhs) => new bool2x2(lhs.m00 <= rhs.m00, lhs.m01 <= rhs.m01, lhs.m10 <= rhs.m10, lhs.m11 <= rhs.m11);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x2 operator <=(uint2x2 lhs, uint rhs) => new bool2x2(lhs.m00 <= rhs, lhs.m01 <= rhs, lhs.m10 <= rhs, lhs.m11 <= rhs);

        /// <summary>
        /// Executes a component-wise lesser-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x2 operator <=(uint lhs, uint2x2 rhs) => new bool2x2(lhs <= rhs.m00, lhs <= rhs.m01, lhs <= rhs.m10, lhs <= rhs.m11);

        /// <summary>
        /// Executes a component-wise greater-than comparison.
        /// </summary>
        public static bool2x2 operator >(uint2x2 lhs, uint2x2 rhs) => new bool2x2(lhs.m00 > rhs.m00, lhs.m01 > rhs.m01, lhs.m10 > rhs.m10, lhs.m11 > rhs.m11);

        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool2x2 operator >(uint2x2 lhs, uint rhs) => new bool2x2(lhs.m00 > rhs, lhs.m01 > rhs, lhs.m10 > rhs, lhs.m11 > rhs);

        /// <summary>
        /// Executes a component-wise greater-than comparison with a scalar.
        /// </summary>
        public static bool2x2 operator >(uint lhs, uint2x2 rhs) => new bool2x2(lhs > rhs.m00, lhs > rhs.m01, lhs > rhs.m10, lhs > rhs.m11);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison.
        /// </summary>
        public static bool2x2 operator >=(uint2x2 lhs, uint2x2 rhs) => new bool2x2(lhs.m00 >= rhs.m00, lhs.m01 >= rhs.m01, lhs.m10 >= rhs.m10, lhs.m11 >= rhs.m11);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x2 operator >=(uint2x2 lhs, uint rhs) => new bool2x2(lhs.m00 >= rhs, lhs.m01 >= rhs, lhs.m10 >= rhs, lhs.m11 >= rhs);

        /// <summary>
        /// Executes a component-wise greater-or-equal comparison with a scalar.
        /// </summary>
        public static bool2x2 operator >=(uint lhs, uint2x2 rhs) => new bool2x2(lhs >= rhs.m00, lhs >= rhs.m01, lhs >= rhs.m10, lhs >= rhs.m11);
    }
}
