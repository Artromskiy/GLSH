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
    /// A matrix of type float with 2 columns and 4 rows.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "mat")]
    [StructLayout(LayoutKind.Sequential)]
    public struct float2x4
    {

        #region Fields
        
        /// <summary>
        /// Column 0, Rows 0
        /// </summary>
        [DataMember]
        public float m00;
        
        /// <summary>
        /// Column 0, Rows 1
        /// </summary>
        [DataMember]
        public float m01;
        
        /// <summary>
        /// Column 0, Rows 2
        /// </summary>
        [DataMember]
        public float m02;
        
        /// <summary>
        /// Column 0, Rows 3
        /// </summary>
        [DataMember]
        public float m03;
        
        /// <summary>
        /// Column 1, Rows 0
        /// </summary>
        [DataMember]
        public float m10;
        
        /// <summary>
        /// Column 1, Rows 1
        /// </summary>
        [DataMember]
        public float m11;
        
        /// <summary>
        /// Column 1, Rows 2
        /// </summary>
        [DataMember]
        public float m12;
        
        /// <summary>
        /// Column 1, Rows 3
        /// </summary>
        [DataMember]
        public float m13;
        
        /// <summary>
        /// Returns the number of Fields (2 x 4 = 8).
        /// </summary>
        [DataMember]
        public const int Count = 8;

        #endregion


        #region Constructors
        
        /// <summary>
        /// Component-wise constructor
        /// </summary>
        public float2x4(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m02 = m02;
            this.m03 = m03;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
        }
        
        /// <summary>
        /// Constructs this matrix from a float2x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float2x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0f;
            this.m03 = 0f;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0f;
            this.m13 = 0f;
        }
        
        /// <summary>
        /// Constructs this matrix from a float3x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float3x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0f;
            this.m03 = 0f;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0f;
            this.m13 = 0f;
        }
        
        /// <summary>
        /// Constructs this matrix from a float4x2. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float4x2 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = 0f;
            this.m03 = 0f;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = 0f;
            this.m13 = 0f;
        }
        
        /// <summary>
        /// Constructs this matrix from a float2x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float2x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m03 = 0f;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m13 = 0f;
        }
        
        /// <summary>
        /// Constructs this matrix from a float3x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float3x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m03 = 0f;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m13 = 0f;
        }
        
        /// <summary>
        /// Constructs this matrix from a float4x3. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float4x3 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m03 = 0f;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m13 = 0f;
        }
        
        /// <summary>
        /// Constructs this matrix from a float2x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float2x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m03 = m.m03;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m13 = m.m13;
        }
        
        /// <summary>
        /// Constructs this matrix from a float3x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float3x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m03 = m.m03;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m13 = m.m13;
        }
        
        /// <summary>
        /// Constructs this matrix from a float4x4. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float4x4 m)
        {
            this.m00 = m.m00;
            this.m01 = m.m01;
            this.m02 = m.m02;
            this.m03 = m.m03;
            this.m10 = m.m10;
            this.m11 = m.m11;
            this.m12 = m.m12;
            this.m13 = m.m13;
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float2 c0, float2 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = 0f;
            this.m03 = 0f;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = 0f;
            this.m13 = 0f;
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float3 c0, float3 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m03 = 0f;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
            this.m13 = 0f;
        }
        
        /// <summary>
        /// Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.
        /// </summary>
        public float2x4(float4 c0, float4 c1)
        {
            this.m00 = c0.x;
            this.m01 = c0.y;
            this.m02 = c0.z;
            this.m03 = c0.w;
            this.m10 = c1.x;
            this.m11 = c1.y;
            this.m12 = c1.z;
            this.m13 = c1.w;
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
                if ((uint)col >= 2)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 4)
                    throw new ArgumentOutOfRangeException(nameof(row));
                return Unsafe.Add(ref m00, col * 4 + row);
            }
            set
            {
                if ((uint)col >= 2)
                    throw new ArgumentOutOfRangeException(nameof(col));
                if ((uint)row >= 4)
                    throw new ArgumentOutOfRangeException(nameof(row));
                Unsafe.Add(ref m00, col * 4 + row) = value;
            }
        }
        
        /// <summary>
        /// Gets/Sets a specific indexed component.
        /// </summary>
        public float4 this[int col]
        {
            get
            {
                if ((uint)col >= 2)
                    throw new ArgumentOutOfRangeException(nameof(col));
                return MemoryMarshal.Cast<float2x4, float4>(new Span<float2x4>(ref this))[col];
            }
            set
            {
                if ((uint)col >= 2)
                    throw new ArgumentOutOfRangeException(nameof(col));
                MemoryMarshal.Cast<float2x4, float4>(new Span<float2x4>(ref this))[col] = value;
            }
        }

        #endregion


        #region Operators
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float2x4 * float2x2 -> GlmSharpGenerator.Types.MatrixType.
        /// </summary>
        public static float2x4 operator*(float2x4 lhs, float2x2 rhs) => new float2x4((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11), (lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float2x4 * float3x2 -> GlmSharpGenerator.Types.MatrixType.
        /// </summary>
        public static float3x4 operator*(float2x4 lhs, float3x2 rhs) => new float3x4((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11), (lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11), (lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21), (lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21), (lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21), (lhs.m03 * rhs.m20 + lhs.m13 * rhs.m21));
        
        /// <summary>
        /// Executes a matrix-matrix-multiplication float2x4 * float4x2 -> GlmSharpGenerator.Types.MatrixType.
        /// </summary>
        public static float4x4 operator*(float2x4 lhs, float4x2 rhs) => new float4x4((lhs.m00 * rhs.m00 + lhs.m10 * rhs.m01), (lhs.m01 * rhs.m00 + lhs.m11 * rhs.m01), (lhs.m02 * rhs.m00 + lhs.m12 * rhs.m01), (lhs.m03 * rhs.m00 + lhs.m13 * rhs.m01), (lhs.m00 * rhs.m10 + lhs.m10 * rhs.m11), (lhs.m01 * rhs.m10 + lhs.m11 * rhs.m11), (lhs.m02 * rhs.m10 + lhs.m12 * rhs.m11), (lhs.m03 * rhs.m10 + lhs.m13 * rhs.m11), (lhs.m00 * rhs.m20 + lhs.m10 * rhs.m21), (lhs.m01 * rhs.m20 + lhs.m11 * rhs.m21), (lhs.m02 * rhs.m20 + lhs.m12 * rhs.m21), (lhs.m03 * rhs.m20 + lhs.m13 * rhs.m21), (lhs.m00 * rhs.m30 + lhs.m10 * rhs.m31), (lhs.m01 * rhs.m30 + lhs.m11 * rhs.m31), (lhs.m02 * rhs.m30 + lhs.m12 * rhs.m31), (lhs.m03 * rhs.m30 + lhs.m13 * rhs.m31));
        
        /// <summary>
        /// Executes a matrix-vector-multiplication.
        /// </summary>
        public static float4 operator*(float2x4 m, float2 v) => new float4((m.m00 * v.x + m.m10 * v.y), (m.m01 * v.x + m.m11 * v.y), (m.m02 * v.x + m.m12 * v.y), (m.m03 * v.x + m.m13 * v.y));

        #endregion


        #region Static Functions
        
        /// <summary>
        /// 
        /// </summary>
        public static float2x4 OuterProduct(float4 col, float2 row) => new float2x4(row.x * col.x, row.x * col.y, row.x * col.z, row.x * col.w, row.y * col.x, row.y * col.y, row.y * col.z, row.y * col.w);
        
        /// <summary>
        /// 
        /// </summary>
        public static float4x2 Transpose(float2x4 v) => new float4x2(v.m00, v.m10, v.m01, v.m11, v.m02, v.m12, v.m03, v.m13);

        #endregion

    }
}
