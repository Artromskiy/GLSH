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
        public static double2x3 Transpose(double3x2 v) => double3x2.Transpose(v);

    }
}
