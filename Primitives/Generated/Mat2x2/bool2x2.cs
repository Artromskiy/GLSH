using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A matrix of type bool with 2 columns and 2 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct bool2x2
    {

        #region Fields

        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        [DataMember]
        public bool m00;

        /// <summary>
        /// Column 0, Rows 1
        /// </summary>
        [DataMember]
        public bool m01;

        /// <summary>
        /// Column 1, Rows 0
        /// </summary>
        [DataMember]
        public bool m10;

        /// <summary>
        /// Column 1, Rows 1
        /// </summary>
        [DataMember]
        public bool m11;

        #endregion


        #region Constructors

        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public bool2x2(bool m00, bool m01, bool m10, bool m11)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m10 = m10;
            this.m11 = m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool2x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool3x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool4x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool2x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool3x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool4x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool2x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool3x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a bool4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool4x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m10 = m.m10;
            this.m11 = m.m11;
        }

        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public bool2x2(bool2 c0, bool2 c1)
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
        public bool2 Column0
        {
            get
            {
                return new bool2(m00, m01);
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
        public bool2 Column1
        {
            get
            {
                return new bool2(m10, m11);
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
        public bool2 Row0
        {
            get
            {
                return new bool2(m00, m10);
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
        public bool2 Row1
        {
            get
            {
                return new bool2(m01, m11);
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
        public static bool2x2 Zero { get; } = new bool2x2(false, false, false, false);

        /// <summary>
        /// Predefined all-ones matrix
        /// </summary>
        public static bool2x2 Ones { get; } = new bool2x2(true, true, true, true);

        /// <summary>
        /// Predefined identity matrix
        /// </summary>
        public static bool2x2 Identity { get; } = new bool2x2(true, false, false, true);

        #endregion


        /// <summary>
        /// Returns the number of Fields (2 x 2 = 4).
        /// </summary>
        public const int Count = 4;

        /// <summary>
        /// Gets/Sets a specific indexed component (a bit slower than direct access).
        /// </summary>
        public bool this[int fieldIndex]
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
        public bool this[int col, int row]
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
        public bool Equals(bool2x2 rhs) => ((m00.Equals(rhs.m00) && m01.Equals(rhs.m01)) && (m10.Equals(rhs.m10) && m11.Equals(rhs.m11)));

        /// <summary>
        /// Returns true iff this equals rhs component-wise.
        /// </summary>
        public static bool operator ==(bool2x2 lhs, bool2x2 rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Returns true iff this does not equal rhs (component-wise).
        /// </summary>
        public static bool operator !=(bool2x2 lhs, bool2x2 rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((((((m00.GetHashCode()) * 2) ^ m01.GetHashCode()) * 2) ^ m10.GetHashCode()) * 2) ^ m11.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a transposed version of this matrix.
        /// </summary>
        public bool2x2 Transposed => new bool2x2(m00, m10, m01, m11);

        /// <summary>
        /// Returns the minimal component of this matrix.
        /// </summary>
        public bool MinElement => ((m00 && m01) && (m10 && m11));

        /// <summary>
        /// Returns the maximal component of this matrix.
        /// </summary>
        public bool MaxElement => ((m00 || m01) || (m10 || m11));

        /// <summary>
        /// Returns true if all component are true.
        /// </summary>
        public bool All => ((m00 && m01) && (m10 && m11));

        /// <summary>
        /// Returns true if any component is true.
        /// </summary>
        public bool Any => ((m00 || m01) || (m10 || m11));

        /// <summary>
        /// Executes a component-wise &amp;&amp;. (sorry for different overload but &amp;&amp; cannot be overloaded directly)
        /// </summary>
        public static bool2x2 operator &(bool2x2 lhs, bool2x2 rhs) => new bool2x2(lhs.m00 && rhs.m00, lhs.m01 && rhs.m01, lhs.m10 && rhs.m10, lhs.m11 && rhs.m11);

        /// <summary>
        /// Executes a component-wise ||. (sorry for different overload but || cannot be overloaded directly)
        /// </summary>
        public static bool2x2 operator |(bool2x2 lhs, bool2x2 rhs) => new bool2x2(lhs.m00 || rhs.m00, lhs.m01 || rhs.m01, lhs.m10 || rhs.m10, lhs.m11 || rhs.m11);
    }
}
