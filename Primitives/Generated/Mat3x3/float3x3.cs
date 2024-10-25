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
    /// A matrix of type float with 3 columns and 3 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [InlineArray(3)]
    public struct float3x3
    {

        #region Fields
        
        /// <summary>
        /// First column of matrix
        /// </summary>
        private float3 _buffer;
        
        /// <summary>
        /// Returns the number of Fields (3 x 3 = 9).
        /// </summary>
        public const int Count = 9;

        #endregion


        #region Constructors
        
        /// <summary>
        /// Constructs diagonal matrix with scalar, non diagonal values are set to zero.
        /// </summary>
        public float3x3(float s)
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
        public float3x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22)
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
        public float3x3(float3 v0, float3 v1, float3 v2)
        {
            this[0] = v0;
            this[1] = v1;
            this[2] = v2;
        }
        
        /// <summary>
        /// Constructs matrix from a float2x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float2x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
            this[2, 2] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float3x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float3x2 m)
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
        /// Constructs matrix from a float4x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float4x2 m)
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
        /// Constructs matrix from a float2x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float2x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
            this[2, 2] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float3x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float3x3 m)
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
        /// Constructs matrix from a float4x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float4x3 m)
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
        /// Constructs matrix from a float2x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float2x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
            this[2, 2] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float3x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float3x4 m)
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
        /// Constructs matrix from a float4x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float3x3(float4x4 m)
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
        public float this[int col, int row]
        {
            get
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 3)
                    throw new ArgumentOutOfRangeException(nameof(row));
                return Unsafe.Add(ref Unsafe.As<float3, float>(ref _buffer), col * 3 + row);
            }
            set
            {
                if ((uint)col >= 3)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 3)
                    throw new ArgumentOutOfRangeException(nameof(row));
                Unsafe.Add(ref Unsafe.As<float3, float>(ref _buffer), col * 3 + row) = value;
            }
        }

        #endregion


        #region Operators
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float3x3 * float2x3 -> float2x3.
        /// </summary>
        public static float2x3 operator*(float3x3 lhs, float2x3 rhs) => new float2x3(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2]);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float3x3 * float3x3 -> float3x3.
        /// </summary>
        public static float3x3 operator*(float3x3 lhs, float3x3 rhs) => new float3x3(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2], lhs[0, 2] * rhs[2, 0] + lhs[1, 2] * rhs[2, 1] + lhs[2, 2] * rhs[2, 2]);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float3x3 * float4x3 -> float4x3.
        /// </summary>
        public static float4x3 operator*(float3x3 lhs, float4x3 rhs) => new float4x3(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2], lhs[0, 2] * rhs[2, 0] + lhs[1, 2] * rhs[2, 1] + lhs[2, 2] * rhs[2, 2], lhs[0, 0] * rhs[3, 0] + lhs[1, 0] * rhs[3, 1] + lhs[2, 0] * rhs[3, 2], lhs[0, 1] * rhs[3, 0] + lhs[1, 1] * rhs[3, 1] + lhs[2, 1] * rhs[3, 2], lhs[0, 2] * rhs[3, 0] + lhs[1, 2] * rhs[3, 1] + lhs[2, 2] * rhs[3, 2]);
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static float3 operator*(float3x3 m, float3 v) => new float3(m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z, m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z, m[0, 2] * v.x + m[1, 2] * v.y + m[2, 2] * v.z);
        
        /// <summary>
        /// Executes a component-wise + (addition).
        /// </summary>
        public static float3x3 operator+(float3x3 lhs, float3x3 rhs) => new float3x3(lhs[0, 0] + rhs[0, 0], lhs[0, 1] + rhs[0, 1], lhs[0, 2] + rhs[0, 2], lhs[1, 0] + rhs[1, 0], lhs[1, 1] + rhs[1, 1], lhs[1, 2] + rhs[1, 2], lhs[2, 0] + rhs[2, 0], lhs[2, 1] + rhs[2, 1], lhs[2, 2] + rhs[2, 2]);
        
        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static float3x3 operator+(float s, float3x3 m) => new float3x3(s + m[0, 0], s + m[0, 1], s + m[0, 2], s + m[1, 0], s + m[1, 1], s + m[1, 2], s + m[2, 0], s + m[2, 1], s + m[2, 2]);
        
        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static float3x3 operator+(float3x3 m, float s) => new float3x3(m[0, 0] + s, m[0, 1] + s, m[0, 2] + s, m[1, 0] + s, m[1, 1] + s, m[1, 2] + s, m[2, 0] + s, m[2, 1] + s, m[2, 2] + s);
        
        /// <summary>
        /// Executes a component-wise - (subtraction).
        /// </summary>
        public static float3x3 operator-(float3x3 lhs, float3x3 rhs) => new float3x3(lhs[0, 0] - rhs[0, 0], lhs[0, 1] - rhs[0, 1], lhs[0, 2] - rhs[0, 2], lhs[1, 0] - rhs[1, 0], lhs[1, 1] - rhs[1, 1], lhs[1, 2] - rhs[1, 2], lhs[2, 0] - rhs[2, 0], lhs[2, 1] - rhs[2, 1], lhs[2, 2] - rhs[2, 2]);
        
        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static float3x3 operator-(float s, float3x3 m) => new float3x3(s - m[0, 0], s - m[0, 1], s - m[0, 2], s - m[1, 0], s - m[1, 1], s - m[1, 2], s - m[2, 0], s - m[2, 1], s - m[2, 2]);
        
        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static float3x3 operator-(float3x3 m, float s) => new float3x3(m[0, 0] - s, m[0, 1] - s, m[0, 2] - s, m[1, 0] - s, m[1, 1] - s, m[1, 2] - s, m[2, 0] - s, m[2, 1] - s, m[2, 2] - s);
        
        /// <summary>
        /// Executes a component-wise / (division).
        /// </summary>
        public static float3x3 operator/(float3x3 lhs, float3x3 rhs) => new float3x3(lhs[0, 0] / rhs[0, 0], lhs[0, 1] / rhs[0, 1], lhs[0, 2] / rhs[0, 2], lhs[1, 0] / rhs[1, 0], lhs[1, 1] / rhs[1, 1], lhs[1, 2] / rhs[1, 2], lhs[2, 0] / rhs[2, 0], lhs[2, 1] / rhs[2, 1], lhs[2, 2] / rhs[2, 2]);
        
        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static float3x3 operator/(float s, float3x3 m) => new float3x3(s / m[0, 0], s / m[0, 1], s / m[0, 2], s / m[1, 0], s / m[1, 1], s / m[1, 2], s / m[2, 0], s / m[2, 1], s / m[2, 2]);
        
        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static float3x3 operator/(float3x3 m, float s) => new float3x3(m[0, 0] / s, m[0, 1] / s, m[0, 2] / s, m[1, 0] / s, m[1, 1] / s, m[1, 2] / s, m[2, 0] / s, m[2, 1] / s, m[2, 2] / s);
        
        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static float3x3 operator*(float s, float3x3 m) => new float3x3(s * m[0, 0], s * m[0, 1], s * m[0, 2], s * m[1, 0], s * m[1, 1], s * m[1, 2], s * m[2, 0], s * m[2, 1], s * m[2, 2]);
        
        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static float3x3 operator*(float3x3 m, float s) => new float3x3(m[0, 0] * s, m[0, 1] * s, m[0, 2] * s, m[1, 0] * s, m[1, 1] * s, m[1, 2] * s, m[2, 0] * s, m[2, 1] * s, m[2, 2] * s);

        #endregion


        #region Static Functions
        
        /// <summary>
        /// 
        /// </summary>
        public static float3x3 OuterProduct(float3 col, float3 row) => new float3x3(row.x * col.x, row.x * col.y, row.x * col.z, row.y * col.x, row.y * col.y, row.y * col.z, row.z * col.x, row.z * col.y, row.z * col.z);
        
        /// <summary>
        /// 
        /// </summary>
        public static float3x3 Transpose(float3x3 v) => new float3x3(v[0, 0], v[1, 0], v[2, 0], v[0, 1], v[1, 1], v[2, 1], v[0, 2], v[1, 2], v[2, 2]);
        
        /// <summary>
        /// 
        /// </summary>
        public static float Determinant(float3x3 v) => v[0, 0] * (v[1, 1] * v[2, 2] - v[2, 1] * v[1, 2]) - v[1, 0] * (v[0, 1] * v[2, 2] - v[2, 1] * v[0, 2]) + v[2, 0] * (v[0, 1] * v[1, 2] - v[1, 1] * v[0, 2]);

        #endregion

    }
}
