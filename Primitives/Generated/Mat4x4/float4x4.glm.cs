using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace GLSH
{
    /// <summary>
    /// Static class that contains static glm functions
    /// </summary>
    public static partial class glm
    {
        
        /// <summary>
        /// 
        /// </summary>
        public static float4x4 Transpose(float4x4 v) => float4x4.Transpose(v);
        
        /// <summary>
        /// 
        /// </summary>
        public static float Determinant(float4x4 v) => float4x4.Determinant(v);

    }
}
