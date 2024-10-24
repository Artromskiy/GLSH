using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH
{

    /// <summary>
    /// A matrix of type float with 3 columns and 2 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct float3x2
    {

        #region Fields

        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        [DataMember]
        private float m00;

        /// <summary>
        /// Column 0, Rows 1
        /// </summary>
        [DataMember]
        private float m01;

        /// <summary>
        /// Column 1, Rows 0
        /// </summary>
        [DataMember]
        private float m10;

        /// <summary>
        /// Column 1, Rows 1
        /// </summary>
        [DataMember]
        private float m11;

        /// <summary>
        /// Column 2, Rows 0
        /// </summary>
        [DataMember]
        private float m20;

        /// <summary>
        /// Column 2, Rows 1
        /// </summary>
        [DataMember]
        private float m21;

        /// <summary>
        /// Returns the number of Fields (3 x 2 = 6).
        /// </summary>
        [DataMember]
        public const int Count = 6;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructs diagonal matrix with scalar, non diagonal values are set to zero.
        /// </summary>
        public float3x2(float s)
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
        public float3x2(float m00, float m01, float m10, float m11, float m20, float m21)
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
        public float3x2(float2 v0, float2 v1, float2 v2)
        {
            this[0] = v0;
            this[1] = v1;
            this[2] = v2;
        }

        /// <summary>
        /// Constructs matrix from a float2x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float2x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
        }

        /// <summary>
        /// Constructs matrix from a float3x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float3x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }

        /// <summary>
        /// Constructs matrix from a float4x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float4x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }

        /// <summary>
        /// Constructs matrix from a float2x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float2x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
        }

        /// <summary>
        /// Constructs matrix from a float3x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float3x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }

        /// <summary>
        /// Constructs matrix from a float4x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float4x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }

        /// <summary>
        /// Constructs matrix from a float2x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float2x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
        }

        /// <summary>
        /// Constructs matrix from a float3x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float3x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[2, 0] = m[2, 0];
            this[2, 1] = m[2, 1];
        }

        /// <summary>
        /// Constructs matrix from a float4x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x2(float4x4 m)
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
        public float this[int col, int row]
        {
            get
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 2)
                    throw new ArgumentOutOfRangeException(nameof(row));
                return Unsafe.Add(ref m00, col * 2 + row);
            }
            set
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 2)
                    throw new ArgumentOutOfRangeException(nameof(row));
                Unsafe.Add(ref m00, col * 2 + row) = value;
            }
        }

        /// <summary>
        /// Gets/Sets a specific indexed component.
        /// </summary>
        public float2 this[int col]
        {
            get
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                return MemoryMarshal.Cast<float3x2, float2>(new Span<float3x2>(ref this))[col];
            }
            set
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                MemoryMarshal.Cast<float3x2, float2>(new Span<float3x2>(ref this))[col] = value;
            }
        }

        #endregion


        #region Operators

        /// <summary>
        /// Executes a matrix-matrix-multiplication float3x2 * float2x3 -> float2x2.
        /// </summary>
        public static float2x2 operator *(float3x2 lhs, float2x3 rhs) => new float2x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2]);

        /// <summary>
        /// Executes a matrix-matrix-multiplication float3x2 * float3x3 -> float3x2.
        /// </summary>
        public static float3x2 operator *(float3x2 lhs, float3x3 rhs) => new float3x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2]);

        /// <summary>
        /// Executes a matrix-matrix-multiplication float3x2 * float4x3 -> float4x2.
        /// </summary>
        public static float4x2 operator *(float3x2 lhs, float4x3 rhs) => new float4x2(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2], lhs[0, 0] * rhs[3, 0] + lhs[1, 0] * rhs[3, 1] + lhs[2, 0] * rhs[3, 2], lhs[0, 1] * rhs[3, 0] + lhs[1, 1] * rhs[3, 1] + lhs[2, 1] * rhs[3, 2]);

        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static float2 operator *(float3x2 m, float3 v) => new float2(m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z, m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z);

        /// <summary>
        /// Executes a component-wise + (addition).
        /// </summary>
        public static float3x2 operator +(float3x2 lhs, float3x2 rhs) => new float3x2(lhs[0, 0] + rhs[0, 0], lhs[0, 1] + rhs[0, 1], lhs[1, 0] + rhs[1, 0], lhs[1, 1] + rhs[1, 1], lhs[2, 0] + rhs[2, 0], lhs[2, 1] + rhs[2, 1]);

        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static float3x2 operator +(float s, float3x2 m) => new float3x2(s + m[0, 0], s + m[0, 1], s + m[1, 0], s + m[1, 1], s + m[2, 0], s + m[2, 1]);

        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static float3x2 operator +(float3x2 m, float s) => new float3x2(m[0, 0] + s, m[0, 1] + s, m[1, 0] + s, m[1, 1] + s, m[2, 0] + s, m[2, 1] + s);

        /// <summary>
        /// Executes a component-wise - (subtraction).
        /// </summary>
        public static float3x2 operator -(float3x2 lhs, float3x2 rhs) => new float3x2(lhs[0, 0] - rhs[0, 0], lhs[0, 1] - rhs[0, 1], lhs[1, 0] - rhs[1, 0], lhs[1, 1] - rhs[1, 1], lhs[2, 0] - rhs[2, 0], lhs[2, 1] - rhs[2, 1]);

        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static float3x2 operator -(float s, float3x2 m) => new float3x2(s - m[0, 0], s - m[0, 1], s - m[1, 0], s - m[1, 1], s - m[2, 0], s - m[2, 1]);

        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static float3x2 operator -(float3x2 m, float s) => new float3x2(m[0, 0] - s, m[0, 1] - s, m[1, 0] - s, m[1, 1] - s, m[2, 0] - s, m[2, 1] - s);

        /// <summary>
        /// Executes a component-wise / (division).
        /// </summary>
        public static float3x2 operator /(float3x2 lhs, float3x2 rhs) => new float3x2(lhs[0, 0] / rhs[0, 0], lhs[0, 1] / rhs[0, 1], lhs[1, 0] / rhs[1, 0], lhs[1, 1] / rhs[1, 1], lhs[2, 0] / rhs[2, 0], lhs[2, 1] / rhs[2, 1]);

        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static float3x2 operator /(float s, float3x2 m) => new float3x2(s / m[0, 0], s / m[0, 1], s / m[1, 0], s / m[1, 1], s / m[2, 0], s / m[2, 1]);

        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static float3x2 operator /(float3x2 m, float s) => new float3x2(m[0, 0] / s, m[0, 1] / s, m[1, 0] / s, m[1, 1] / s, m[2, 0] / s, m[2, 1] / s);

        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static float3x2 operator *(float s, float3x2 m) => new float3x2(s * m[0, 0], s * m[0, 1], s * m[1, 0], s * m[1, 1], s * m[2, 0], s * m[2, 1]);

        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static float3x2 operator *(float3x2 m, float s) => new float3x2(m[0, 0] * s, m[0, 1] * s, m[1, 0] * s, m[1, 1] * s, m[2, 0] * s, m[2, 1] * s);

        #endregion


        #region Static Functions

        /// <summary>
        /// 
        /// </summary>
        public static float3x2 OuterProduct(float2 col, float3 row) => new float3x2(row.x * col.x, row.x * col.y, row.y * col.x, row.y * col.y, row.z * col.x, row.z * col.y);

        /// <summary>
        /// 
        /// </summary>
        public static float2x3 Transpose(float3x2 v) => new float2x3(v[0, 0], v[1, 0], v[2, 0], v[0, 1], v[1, 1], v[2, 1]);

        #endregion

    }
}
