using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type float with 2 components, used for implementing swizzling for float2.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_vec2
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        internal readonly float x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        internal readonly float y;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_vec2.
        /// </summary>
        internal swizzle_vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns float2.xx swizzling.
        /// </summary>
        public float2 xx => new float2(x, x);

        /// <summary>
        /// Returns float2.rr swizzling (equivalent to float2.xx).
        /// </summary>
        public float2 rr => new float2(x, x);

        /// <summary>
        /// Returns float2.xxx swizzling.
        /// </summary>
        public float3 xxx => new float3(x, x, x);

        /// <summary>
        /// Returns float2.rrr swizzling (equivalent to float2.xxx).
        /// </summary>
        public float3 rrr => new float3(x, x, x);

        /// <summary>
        /// Returns float2.xxxx swizzling.
        /// </summary>
        public float4 xxxx => new float4(x, x, x, x);

        /// <summary>
        /// Returns float2.rrrr swizzling (equivalent to float2.xxxx).
        /// </summary>
        public float4 rrrr => new float4(x, x, x, x);

        /// <summary>
        /// Returns float2.xxxy swizzling.
        /// </summary>
        public float4 xxxy => new float4(x, x, x, y);

        /// <summary>
        /// Returns float2.rrrg swizzling (equivalent to float2.xxxy).
        /// </summary>
        public float4 rrrg => new float4(x, x, x, y);

        /// <summary>
        /// Returns float2.xxy swizzling.
        /// </summary>
        public float3 xxy => new float3(x, x, y);

        /// <summary>
        /// Returns float2.rrg swizzling (equivalent to float2.xxy).
        /// </summary>
        public float3 rrg => new float3(x, x, y);

        /// <summary>
        /// Returns float2.xxyx swizzling.
        /// </summary>
        public float4 xxyx => new float4(x, x, y, x);

        /// <summary>
        /// Returns float2.rrgr swizzling (equivalent to float2.xxyx).
        /// </summary>
        public float4 rrgr => new float4(x, x, y, x);

        /// <summary>
        /// Returns float2.xxyy swizzling.
        /// </summary>
        public float4 xxyy => new float4(x, x, y, y);

        /// <summary>
        /// Returns float2.rrgg swizzling (equivalent to float2.xxyy).
        /// </summary>
        public float4 rrgg => new float4(x, x, y, y);

        /// <summary>
        /// Returns float2.xy swizzling.
        /// </summary>
        public float2 xy => new float2(x, y);

        /// <summary>
        /// Returns float2.rg swizzling (equivalent to float2.xy).
        /// </summary>
        public float2 rg => new float2(x, y);

        /// <summary>
        /// Returns float2.xyx swizzling.
        /// </summary>
        public float3 xyx => new float3(x, y, x);

        /// <summary>
        /// Returns float2.rgr swizzling (equivalent to float2.xyx).
        /// </summary>
        public float3 rgr => new float3(x, y, x);

        /// <summary>
        /// Returns float2.xyxx swizzling.
        /// </summary>
        public float4 xyxx => new float4(x, y, x, x);

        /// <summary>
        /// Returns float2.rgrr swizzling (equivalent to float2.xyxx).
        /// </summary>
        public float4 rgrr => new float4(x, y, x, x);

        /// <summary>
        /// Returns float2.xyxy swizzling.
        /// </summary>
        public float4 xyxy => new float4(x, y, x, y);

        /// <summary>
        /// Returns float2.rgrg swizzling (equivalent to float2.xyxy).
        /// </summary>
        public float4 rgrg => new float4(x, y, x, y);

        /// <summary>
        /// Returns float2.xyy swizzling.
        /// </summary>
        public float3 xyy => new float3(x, y, y);

        /// <summary>
        /// Returns float2.rgg swizzling (equivalent to float2.xyy).
        /// </summary>
        public float3 rgg => new float3(x, y, y);

        /// <summary>
        /// Returns float2.xyyx swizzling.
        /// </summary>
        public float4 xyyx => new float4(x, y, y, x);

        /// <summary>
        /// Returns float2.rggr swizzling (equivalent to float2.xyyx).
        /// </summary>
        public float4 rggr => new float4(x, y, y, x);

        /// <summary>
        /// Returns float2.xyyy swizzling.
        /// </summary>
        public float4 xyyy => new float4(x, y, y, y);

        /// <summary>
        /// Returns float2.rggg swizzling (equivalent to float2.xyyy).
        /// </summary>
        public float4 rggg => new float4(x, y, y, y);

        /// <summary>
        /// Returns float2.yx swizzling.
        /// </summary>
        public float2 yx => new float2(y, x);

        /// <summary>
        /// Returns float2.gr swizzling (equivalent to float2.yx).
        /// </summary>
        public float2 gr => new float2(y, x);

        /// <summary>
        /// Returns float2.yxx swizzling.
        /// </summary>
        public float3 yxx => new float3(y, x, x);

        /// <summary>
        /// Returns float2.grr swizzling (equivalent to float2.yxx).
        /// </summary>
        public float3 grr => new float3(y, x, x);

        /// <summary>
        /// Returns float2.yxxx swizzling.
        /// </summary>
        public float4 yxxx => new float4(y, x, x, x);

        /// <summary>
        /// Returns float2.grrr swizzling (equivalent to float2.yxxx).
        /// </summary>
        public float4 grrr => new float4(y, x, x, x);

        /// <summary>
        /// Returns float2.yxxy swizzling.
        /// </summary>
        public float4 yxxy => new float4(y, x, x, y);

        /// <summary>
        /// Returns float2.grrg swizzling (equivalent to float2.yxxy).
        /// </summary>
        public float4 grrg => new float4(y, x, x, y);

        /// <summary>
        /// Returns float2.yxy swizzling.
        /// </summary>
        public float3 yxy => new float3(y, x, y);

        /// <summary>
        /// Returns float2.grg swizzling (equivalent to float2.yxy).
        /// </summary>
        public float3 grg => new float3(y, x, y);

        /// <summary>
        /// Returns float2.yxyx swizzling.
        /// </summary>
        public float4 yxyx => new float4(y, x, y, x);

        /// <summary>
        /// Returns float2.grgr swizzling (equivalent to float2.yxyx).
        /// </summary>
        public float4 grgr => new float4(y, x, y, x);

        /// <summary>
        /// Returns float2.yxyy swizzling.
        /// </summary>
        public float4 yxyy => new float4(y, x, y, y);

        /// <summary>
        /// Returns float2.grgg swizzling (equivalent to float2.yxyy).
        /// </summary>
        public float4 grgg => new float4(y, x, y, y);

        /// <summary>
        /// Returns float2.yy swizzling.
        /// </summary>
        public float2 yy => new float2(y, y);

        /// <summary>
        /// Returns float2.gg swizzling (equivalent to float2.yy).
        /// </summary>
        public float2 gg => new float2(y, y);

        /// <summary>
        /// Returns float2.yyx swizzling.
        /// </summary>
        public float3 yyx => new float3(y, y, x);

        /// <summary>
        /// Returns float2.ggr swizzling (equivalent to float2.yyx).
        /// </summary>
        public float3 ggr => new float3(y, y, x);

        /// <summary>
        /// Returns float2.yyxx swizzling.
        /// </summary>
        public float4 yyxx => new float4(y, y, x, x);

        /// <summary>
        /// Returns float2.ggrr swizzling (equivalent to float2.yyxx).
        /// </summary>
        public float4 ggrr => new float4(y, y, x, x);

        /// <summary>
        /// Returns float2.yyxy swizzling.
        /// </summary>
        public float4 yyxy => new float4(y, y, x, y);

        /// <summary>
        /// Returns float2.ggrg swizzling (equivalent to float2.yyxy).
        /// </summary>
        public float4 ggrg => new float4(y, y, x, y);

        /// <summary>
        /// Returns float2.yyy swizzling.
        /// </summary>
        public float3 yyy => new float3(y, y, y);

        /// <summary>
        /// Returns float2.ggg swizzling (equivalent to float2.yyy).
        /// </summary>
        public float3 ggg => new float3(y, y, y);

        /// <summary>
        /// Returns float2.yyyx swizzling.
        /// </summary>
        public float4 yyyx => new float4(y, y, y, x);

        /// <summary>
        /// Returns float2.gggr swizzling (equivalent to float2.yyyx).
        /// </summary>
        public float4 gggr => new float4(y, y, y, x);

        /// <summary>
        /// Returns float2.yyyy swizzling.
        /// </summary>
        public float4 yyyy => new float4(y, y, y, y);

        /// <summary>
        /// Returns float2.gggg swizzling (equivalent to float2.yyyy).
        /// </summary>
        public float4 gggg => new float4(y, y, y, y);

        #endregion

    }
}
