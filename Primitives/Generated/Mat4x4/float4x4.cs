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
    /// A matrix of type float with 4 columns and 4 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [InlineArray(4)]
    public struct float4x4
    {

        #region Fields
        
        /// <summary>
        /// First column of matrix
        /// </summary>
        private float4 _buffer;
        
        /// <summary>
        /// Returns the number of Fields (4 x 4 = 16).
        /// </summary>
        public const int Count = 16;

        #endregion


        #region Constructors
        
        /// <summary>
        /// Constructs diagonal matrix with scalar, non diagonal values are set to zero.
        /// </summary>
        public float4x4(float s)
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
        public float4x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
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
        public float4x4(float4 v0, float4 v1, float4 v2, float4 v3)
        {
            this[0] = v0;
            this[1] = v1;
            this[2] = v2;
            this[3] = v3;
        }
        
        /// <summary>
        /// Constructs matrix from a float2x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float2x2 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
            this[2, 2] = 0f;
            this[2, 3] = 0f;
            this[3, 0] = 0f;
            this[3, 1] = 0f;
            this[3, 2] = 0f;
            this[3, 3] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float3x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float3x2 m)
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
            this[3, 0] = 0f;
            this[3, 1] = 0f;
            this[3, 2] = 0f;
            this[3, 3] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float4x2 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float4x2 m)
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
        /// Constructs matrix from a float2x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float2x3 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
            this[2, 2] = 0f;
            this[2, 3] = 0f;
            this[3, 0] = 0f;
            this[3, 1] = 0f;
            this[3, 2] = 0f;
            this[3, 3] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float3x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float3x3 m)
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
            this[3, 0] = 0f;
            this[3, 1] = 0f;
            this[3, 2] = 0f;
            this[3, 3] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float4x3 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float4x3 m)
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
        /// Constructs matrix from a float2x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float2x4 m)
        {
            this[0, 0] = m[0, 0];
            this[0, 1] = m[0, 1];
            this[0, 2] = m[0, 2];
            this[0, 3] = m[0, 3];
            this[1, 0] = m[1, 0];
            this[1, 1] = m[1, 1];
            this[1, 2] = m[1, 2];
            this[1, 3] = m[1, 3];
            this[2, 0] = 0f;
            this[2, 1] = 0f;
            this[2, 2] = 0f;
            this[2, 3] = 0f;
            this[3, 0] = 0f;
            this[3, 1] = 0f;
            this[3, 2] = 0f;
            this[3, 3] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float3x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float3x4 m)
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
            this[3, 0] = 0f;
            this[3, 1] = 0f;
            this[3, 2] = 0f;
            this[3, 3] = 0f;
        }
        
        /// <summary>
        /// Constructs matrix from a float4x4 which will occupie left upper corner. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float4x4(float4x4 m)
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
        public float this[int col, int row]
        {
            get
            {
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 4)
                    throw new ArgumentOutOfRangeException(nameof(row));
                return Unsafe.Add(ref Unsafe.As<float4, float>(ref _buffer), col * 4 + row);
            }
            set
            {
                if ((uint)col >= 4)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 4)
                    throw new ArgumentOutOfRangeException(nameof(row));
                Unsafe.Add(ref Unsafe.As<float4, float>(ref _buffer), col * 4 + row) = value;
            }
        }

        #endregion


        #region Operators
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float4x4 * float2x4 -> float2x4.
        /// </summary>
        public static float2x4 operator*(float4x4 lhs, float2x4 rhs) => new float2x4(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2] + lhs[3, 2] * rhs[0, 3], lhs[0, 3] * rhs[0, 0] + lhs[1, 3] * rhs[0, 1] + lhs[2, 3] * rhs[0, 2] + lhs[3, 3] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2] + lhs[3, 2] * rhs[1, 3], lhs[0, 3] * rhs[1, 0] + lhs[1, 3] * rhs[1, 1] + lhs[2, 3] * rhs[1, 2] + lhs[3, 3] * rhs[1, 3]);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float4x4 * float3x4 -> float3x4.
        /// </summary>
        public static float3x4 operator*(float4x4 lhs, float3x4 rhs) => new float3x4(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2] + lhs[3, 2] * rhs[0, 3], lhs[0, 3] * rhs[0, 0] + lhs[1, 3] * rhs[0, 1] + lhs[2, 3] * rhs[0, 2] + lhs[3, 3] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2] + lhs[3, 2] * rhs[1, 3], lhs[0, 3] * rhs[1, 0] + lhs[1, 3] * rhs[1, 1] + lhs[2, 3] * rhs[1, 2] + lhs[3, 3] * rhs[1, 3], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2] + lhs[3, 0] * rhs[2, 3], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2] + lhs[3, 1] * rhs[2, 3], lhs[0, 2] * rhs[2, 0] + lhs[1, 2] * rhs[2, 1] + lhs[2, 2] * rhs[2, 2] + lhs[3, 2] * rhs[2, 3], lhs[0, 3] * rhs[2, 0] + lhs[1, 3] * rhs[2, 1] + lhs[2, 3] * rhs[2, 2] + lhs[3, 3] * rhs[2, 3]);
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float4x4 * float4x4 -> float4x4.
        /// </summary>
        public static float4x4 operator*(float4x4 lhs, float4x4 rhs) => new float4x4(lhs[0, 0] * rhs[0, 0] + lhs[1, 0] * rhs[0, 1] + lhs[2, 0] * rhs[0, 2] + lhs[3, 0] * rhs[0, 3], lhs[0, 1] * rhs[0, 0] + lhs[1, 1] * rhs[0, 1] + lhs[2, 1] * rhs[0, 2] + lhs[3, 1] * rhs[0, 3], lhs[0, 2] * rhs[0, 0] + lhs[1, 2] * rhs[0, 1] + lhs[2, 2] * rhs[0, 2] + lhs[3, 2] * rhs[0, 3], lhs[0, 3] * rhs[0, 0] + lhs[1, 3] * rhs[0, 1] + lhs[2, 3] * rhs[0, 2] + lhs[3, 3] * rhs[0, 3], lhs[0, 0] * rhs[1, 0] + lhs[1, 0] * rhs[1, 1] + lhs[2, 0] * rhs[1, 2] + lhs[3, 0] * rhs[1, 3], lhs[0, 1] * rhs[1, 0] + lhs[1, 1] * rhs[1, 1] + lhs[2, 1] * rhs[1, 2] + lhs[3, 1] * rhs[1, 3], lhs[0, 2] * rhs[1, 0] + lhs[1, 2] * rhs[1, 1] + lhs[2, 2] * rhs[1, 2] + lhs[3, 2] * rhs[1, 3], lhs[0, 3] * rhs[1, 0] + lhs[1, 3] * rhs[1, 1] + lhs[2, 3] * rhs[1, 2] + lhs[3, 3] * rhs[1, 3], lhs[0, 0] * rhs[2, 0] + lhs[1, 0] * rhs[2, 1] + lhs[2, 0] * rhs[2, 2] + lhs[3, 0] * rhs[2, 3], lhs[0, 1] * rhs[2, 0] + lhs[1, 1] * rhs[2, 1] + lhs[2, 1] * rhs[2, 2] + lhs[3, 1] * rhs[2, 3], lhs[0, 2] * rhs[2, 0] + lhs[1, 2] * rhs[2, 1] + lhs[2, 2] * rhs[2, 2] + lhs[3, 2] * rhs[2, 3], lhs[0, 3] * rhs[2, 0] + lhs[1, 3] * rhs[2, 1] + lhs[2, 3] * rhs[2, 2] + lhs[3, 3] * rhs[2, 3], lhs[0, 0] * rhs[3, 0] + lhs[1, 0] * rhs[3, 1] + lhs[2, 0] * rhs[3, 2] + lhs[3, 0] * rhs[3, 3], lhs[0, 1] * rhs[3, 0] + lhs[1, 1] * rhs[3, 1] + lhs[2, 1] * rhs[3, 2] + lhs[3, 1] * rhs[3, 3], lhs[0, 2] * rhs[3, 0] + lhs[1, 2] * rhs[3, 1] + lhs[2, 2] * rhs[3, 2] + lhs[3, 2] * rhs[3, 3], lhs[0, 3] * rhs[3, 0] + lhs[1, 3] * rhs[3, 1] + lhs[2, 3] * rhs[3, 2] + lhs[3, 3] * rhs[3, 3]);
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static float4 operator*(float4x4 m, float4 v) => new float4(m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z + m[3, 0] * v.w, m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z + m[3, 1] * v.w, m[0, 2] * v.x + m[1, 2] * v.y + m[2, 2] * v.z + m[3, 2] * v.w, m[0, 3] * v.x + m[1, 3] * v.y + m[2, 3] * v.z + m[3, 3] * v.w);
        
        /// <summary>
        /// Executes a component-wise + (addition).
        /// </summary>
        public static float4x4 operator+(float4x4 lhs, float4x4 rhs) => new float4x4(lhs[0, 0] + rhs[0, 0], lhs[0, 1] + rhs[0, 1], lhs[0, 2] + rhs[0, 2], lhs[0, 3] + rhs[0, 3], lhs[1, 0] + rhs[1, 0], lhs[1, 1] + rhs[1, 1], lhs[1, 2] + rhs[1, 2], lhs[1, 3] + rhs[1, 3], lhs[2, 0] + rhs[2, 0], lhs[2, 1] + rhs[2, 1], lhs[2, 2] + rhs[2, 2], lhs[2, 3] + rhs[2, 3], lhs[3, 0] + rhs[3, 0], lhs[3, 1] + rhs[3, 1], lhs[3, 2] + rhs[3, 2], lhs[3, 3] + rhs[3, 3]);
        
        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static float4x4 operator+(float s, float4x4 m) => new float4x4(s + m[0, 0], s + m[0, 1], s + m[0, 2], s + m[0, 3], s + m[1, 0], s + m[1, 1], s + m[1, 2], s + m[1, 3], s + m[2, 0], s + m[2, 1], s + m[2, 2], s + m[2, 3], s + m[3, 0], s + m[3, 1], s + m[3, 2], s + m[3, 3]);
        
        /// <summary>
        /// Executes a component-wise + (addition) with scalar.
        /// </summary>
        public static float4x4 operator+(float4x4 m, float s) => new float4x4(m[0, 0] + s, m[0, 1] + s, m[0, 2] + s, m[0, 3] + s, m[1, 0] + s, m[1, 1] + s, m[1, 2] + s, m[1, 3] + s, m[2, 0] + s, m[2, 1] + s, m[2, 2] + s, m[2, 3] + s, m[3, 0] + s, m[3, 1] + s, m[3, 2] + s, m[3, 3] + s);
        
        /// <summary>
        /// Executes a component-wise - (subtraction).
        /// </summary>
        public static float4x4 operator-(float4x4 lhs, float4x4 rhs) => new float4x4(lhs[0, 0] - rhs[0, 0], lhs[0, 1] - rhs[0, 1], lhs[0, 2] - rhs[0, 2], lhs[0, 3] - rhs[0, 3], lhs[1, 0] - rhs[1, 0], lhs[1, 1] - rhs[1, 1], lhs[1, 2] - rhs[1, 2], lhs[1, 3] - rhs[1, 3], lhs[2, 0] - rhs[2, 0], lhs[2, 1] - rhs[2, 1], lhs[2, 2] - rhs[2, 2], lhs[2, 3] - rhs[2, 3], lhs[3, 0] - rhs[3, 0], lhs[3, 1] - rhs[3, 1], lhs[3, 2] - rhs[3, 2], lhs[3, 3] - rhs[3, 3]);
        
        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static float4x4 operator-(float s, float4x4 m) => new float4x4(s - m[0, 0], s - m[0, 1], s - m[0, 2], s - m[0, 3], s - m[1, 0], s - m[1, 1], s - m[1, 2], s - m[1, 3], s - m[2, 0], s - m[2, 1], s - m[2, 2], s - m[2, 3], s - m[3, 0], s - m[3, 1], s - m[3, 2], s - m[3, 3]);
        
        /// <summary>
        /// Executes a component-wise - (subtraction) with scalar.
        /// </summary>
        public static float4x4 operator-(float4x4 m, float s) => new float4x4(m[0, 0] - s, m[0, 1] - s, m[0, 2] - s, m[0, 3] - s, m[1, 0] - s, m[1, 1] - s, m[1, 2] - s, m[1, 3] - s, m[2, 0] - s, m[2, 1] - s, m[2, 2] - s, m[2, 3] - s, m[3, 0] - s, m[3, 1] - s, m[3, 2] - s, m[3, 3] - s);
        
        /// <summary>
        /// Executes a component-wise / (division).
        /// </summary>
        public static float4x4 operator/(float4x4 lhs, float4x4 rhs) => new float4x4(lhs[0, 0] / rhs[0, 0], lhs[0, 1] / rhs[0, 1], lhs[0, 2] / rhs[0, 2], lhs[0, 3] / rhs[0, 3], lhs[1, 0] / rhs[1, 0], lhs[1, 1] / rhs[1, 1], lhs[1, 2] / rhs[1, 2], lhs[1, 3] / rhs[1, 3], lhs[2, 0] / rhs[2, 0], lhs[2, 1] / rhs[2, 1], lhs[2, 2] / rhs[2, 2], lhs[2, 3] / rhs[2, 3], lhs[3, 0] / rhs[3, 0], lhs[3, 1] / rhs[3, 1], lhs[3, 2] / rhs[3, 2], lhs[3, 3] / rhs[3, 3]);
        
        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static float4x4 operator/(float s, float4x4 m) => new float4x4(s / m[0, 0], s / m[0, 1], s / m[0, 2], s / m[0, 3], s / m[1, 0], s / m[1, 1], s / m[1, 2], s / m[1, 3], s / m[2, 0], s / m[2, 1], s / m[2, 2], s / m[2, 3], s / m[3, 0], s / m[3, 1], s / m[3, 2], s / m[3, 3]);
        
        /// <summary>
        /// Executes a component-wise / (division) with scalar.
        /// </summary>
        public static float4x4 operator/(float4x4 m, float s) => new float4x4(m[0, 0] / s, m[0, 1] / s, m[0, 2] / s, m[0, 3] / s, m[1, 0] / s, m[1, 1] / s, m[1, 2] / s, m[1, 3] / s, m[2, 0] / s, m[2, 1] / s, m[2, 2] / s, m[2, 3] / s, m[3, 0] / s, m[3, 1] / s, m[3, 2] / s, m[3, 3] / s);
        
        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static float4x4 operator*(float s, float4x4 m) => new float4x4(s * m[0, 0], s * m[0, 1], s * m[0, 2], s * m[0, 3], s * m[1, 0], s * m[1, 1], s * m[1, 2], s * m[1, 3], s * m[2, 0], s * m[2, 1], s * m[2, 2], s * m[2, 3], s * m[3, 0], s * m[3, 1], s * m[3, 2], s * m[3, 3]);
        
        /// <summary>
        /// Executes a component-wise * (multiplication) with scalar.
        /// </summary>
        public static float4x4 operator*(float4x4 m, float s) => new float4x4(m[0, 0] * s, m[0, 1] * s, m[0, 2] * s, m[0, 3] * s, m[1, 0] * s, m[1, 1] * s, m[1, 2] * s, m[1, 3] * s, m[2, 0] * s, m[2, 1] * s, m[2, 2] * s, m[2, 3] * s, m[3, 0] * s, m[3, 1] * s, m[3, 2] * s, m[3, 3] * s);

        #endregion


        #region Static Functions
        
        /// <summary>
        /// 
        /// </summary>
        public static float4x4 OuterProduct(float4 col, float4 row) => new float4x4(row.x * col.x, row.x * col.y, row.x * col.z, row.x * col.w, row.y * col.x, row.y * col.y, row.y * col.z, row.y * col.w, row.z * col.x, row.z * col.y, row.z * col.z, row.z * col.w, row.w * col.x, row.w * col.y, row.w * col.z, row.w * col.w);
        
        /// <summary>
        /// 
        /// </summary>
        public static float4x4 Transpose(float4x4 v) => new float4x4(v[0, 0], v[1, 0], v[2, 0], v[3, 0], v[0, 1], v[1, 1], v[2, 1], v[3, 1], v[0, 2], v[1, 2], v[2, 2], v[3, 2], v[0, 3], v[1, 3], v[2, 3], v[3, 3]);
        
        /// <summary>
        /// 
        /// </summary>
        public static float Determinant(float4x4 v) => v[0, 0] * (v[1, 1] * (v[2, 2] * v[3, 3] - v[3, 2] * v[2, 3]) - v[2, 1] * (v[1, 2] * v[3, 3] - v[3, 2] * v[1, 3]) + v[3, 1] * (v[1, 2] * v[2, 3] - v[2, 2] * v[1, 3])) - v[1, 0] * (v[0, 1] * (v[2, 2] * v[3, 3] - v[3, 2] * v[2, 3]) - v[2, 1] * (v[0, 2] * v[3, 3] - v[3, 2] * v[0, 3]) + v[3, 1] * (v[0, 2] * v[2, 3] - v[2, 2] * v[0, 3])) + v[2, 0] * (v[0, 1] * (v[1, 2] * v[3, 3] - v[3, 2] * v[1, 3]) - v[1, 1] * (v[0, 2] * v[3, 3] - v[3, 2] * v[0, 3]) + v[3, 1] * (v[0, 2] * v[1, 3] - v[1, 2] * v[0, 3])) - v[3, 0] * (v[0, 1] * (v[1, 2] * v[2, 3] - v[2, 2] * v[1, 3]) - v[1, 1] * (v[0, 2] * v[2, 3] - v[2, 2] * v[0, 3]) + v[2, 1] * (v[0, 2] * v[1, 3] - v[1, 2] * v[0, 3]));

        #endregion

    }
}
