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
        public static float3x3 Transpose(float3x3 v) => float3x3.Transpose(v);
        
        /// <summary>
        /// 
        /// </summary>
        public static float Determinant(float3x3 v) => float3x3.Determinant(v);

    }
}
