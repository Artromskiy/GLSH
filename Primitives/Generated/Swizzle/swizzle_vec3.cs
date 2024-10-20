using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type float with 3 components, used for implementing swizzling for float3.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_vec3
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

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        internal readonly float z;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_vec3.
        /// </summary>
        internal swizzle_vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns float3.xx swizzling.
        /// </summary>
        public float2 xx => new float2(x, x);

        /// <summary>
        /// Returns float3.rr swizzling (equivalent to float3.xx).
        /// </summary>
        public float2 rr => new float2(x, x);

        /// <summary>
        /// Returns float3.xxx swizzling.
        /// </summary>
        public float3 xxx => new float3(x, x, x);

        /// <summary>
        /// Returns float3.rrr swizzling (equivalent to float3.xxx).
        /// </summary>
        public float3 rrr => new float3(x, x, x);

        /// <summary>
        /// Returns float3.xxxx swizzling.
        /// </summary>
        public float4 xxxx => new float4(x, x, x, x);

        /// <summary>
        /// Returns float3.rrrr swizzling (equivalent to float3.xxxx).
        /// </summary>
        public float4 rrrr => new float4(x, x, x, x);

        /// <summary>
        /// Returns float3.xxxy swizzling.
        /// </summary>
        public float4 xxxy => new float4(x, x, x, y);

        /// <summary>
        /// Returns float3.rrrg swizzling (equivalent to float3.xxxy).
        /// </summary>
        public float4 rrrg => new float4(x, x, x, y);

        /// <summary>
        /// Returns float3.xxxz swizzling.
        /// </summary>
        public float4 xxxz => new float4(x, x, x, z);

        /// <summary>
        /// Returns float3.rrrb swizzling (equivalent to float3.xxxz).
        /// </summary>
        public float4 rrrb => new float4(x, x, x, z);

        /// <summary>
        /// Returns float3.xxy swizzling.
        /// </summary>
        public float3 xxy => new float3(x, x, y);

        /// <summary>
        /// Returns float3.rrg swizzling (equivalent to float3.xxy).
        /// </summary>
        public float3 rrg => new float3(x, x, y);

        /// <summary>
        /// Returns float3.xxyx swizzling.
        /// </summary>
        public float4 xxyx => new float4(x, x, y, x);

        /// <summary>
        /// Returns float3.rrgr swizzling (equivalent to float3.xxyx).
        /// </summary>
        public float4 rrgr => new float4(x, x, y, x);

        /// <summary>
        /// Returns float3.xxyy swizzling.
        /// </summary>
        public float4 xxyy => new float4(x, x, y, y);

        /// <summary>
        /// Returns float3.rrgg swizzling (equivalent to float3.xxyy).
        /// </summary>
        public float4 rrgg => new float4(x, x, y, y);

        /// <summary>
        /// Returns float3.xxyz swizzling.
        /// </summary>
        public float4 xxyz => new float4(x, x, y, z);

        /// <summary>
        /// Returns float3.rrgb swizzling (equivalent to float3.xxyz).
        /// </summary>
        public float4 rrgb => new float4(x, x, y, z);

        /// <summary>
        /// Returns float3.xxz swizzling.
        /// </summary>
        public float3 xxz => new float3(x, x, z);

        /// <summary>
        /// Returns float3.rrb swizzling (equivalent to float3.xxz).
        /// </summary>
        public float3 rrb => new float3(x, x, z);

        /// <summary>
        /// Returns float3.xxzx swizzling.
        /// </summary>
        public float4 xxzx => new float4(x, x, z, x);

        /// <summary>
        /// Returns float3.rrbr swizzling (equivalent to float3.xxzx).
        /// </summary>
        public float4 rrbr => new float4(x, x, z, x);

        /// <summary>
        /// Returns float3.xxzy swizzling.
        /// </summary>
        public float4 xxzy => new float4(x, x, z, y);

        /// <summary>
        /// Returns float3.rrbg swizzling (equivalent to float3.xxzy).
        /// </summary>
        public float4 rrbg => new float4(x, x, z, y);

        /// <summary>
        /// Returns float3.xxzz swizzling.
        /// </summary>
        public float4 xxzz => new float4(x, x, z, z);

        /// <summary>
        /// Returns float3.rrbb swizzling (equivalent to float3.xxzz).
        /// </summary>
        public float4 rrbb => new float4(x, x, z, z);

        /// <summary>
        /// Returns float3.xy swizzling.
        /// </summary>
        public float2 xy => new float2(x, y);

        /// <summary>
        /// Returns float3.rg swizzling (equivalent to float3.xy).
        /// </summary>
        public float2 rg => new float2(x, y);

        /// <summary>
        /// Returns float3.xyx swizzling.
        /// </summary>
        public float3 xyx => new float3(x, y, x);

        /// <summary>
        /// Returns float3.rgr swizzling (equivalent to float3.xyx).
        /// </summary>
        public float3 rgr => new float3(x, y, x);

        /// <summary>
        /// Returns float3.xyxx swizzling.
        /// </summary>
        public float4 xyxx => new float4(x, y, x, x);

        /// <summary>
        /// Returns float3.rgrr swizzling (equivalent to float3.xyxx).
        /// </summary>
        public float4 rgrr => new float4(x, y, x, x);

        /// <summary>
        /// Returns float3.xyxy swizzling.
        /// </summary>
        public float4 xyxy => new float4(x, y, x, y);

        /// <summary>
        /// Returns float3.rgrg swizzling (equivalent to float3.xyxy).
        /// </summary>
        public float4 rgrg => new float4(x, y, x, y);

        /// <summary>
        /// Returns float3.xyxz swizzling.
        /// </summary>
        public float4 xyxz => new float4(x, y, x, z);

        /// <summary>
        /// Returns float3.rgrb swizzling (equivalent to float3.xyxz).
        /// </summary>
        public float4 rgrb => new float4(x, y, x, z);

        /// <summary>
        /// Returns float3.xyy swizzling.
        /// </summary>
        public float3 xyy => new float3(x, y, y);

        /// <summary>
        /// Returns float3.rgg swizzling (equivalent to float3.xyy).
        /// </summary>
        public float3 rgg => new float3(x, y, y);

        /// <summary>
        /// Returns float3.xyyx swizzling.
        /// </summary>
        public float4 xyyx => new float4(x, y, y, x);

        /// <summary>
        /// Returns float3.rggr swizzling (equivalent to float3.xyyx).
        /// </summary>
        public float4 rggr => new float4(x, y, y, x);

        /// <summary>
        /// Returns float3.xyyy swizzling.
        /// </summary>
        public float4 xyyy => new float4(x, y, y, y);

        /// <summary>
        /// Returns float3.rggg swizzling (equivalent to float3.xyyy).
        /// </summary>
        public float4 rggg => new float4(x, y, y, y);

        /// <summary>
        /// Returns float3.xyyz swizzling.
        /// </summary>
        public float4 xyyz => new float4(x, y, y, z);

        /// <summary>
        /// Returns float3.rggb swizzling (equivalent to float3.xyyz).
        /// </summary>
        public float4 rggb => new float4(x, y, y, z);

        /// <summary>
        /// Returns float3.xyz swizzling.
        /// </summary>
        public float3 xyz => new float3(x, y, z);

        /// <summary>
        /// Returns float3.rgb swizzling (equivalent to float3.xyz).
        /// </summary>
        public float3 rgb => new float3(x, y, z);

        /// <summary>
        /// Returns float3.xyzx swizzling.
        /// </summary>
        public float4 xyzx => new float4(x, y, z, x);

        /// <summary>
        /// Returns float3.rgbr swizzling (equivalent to float3.xyzx).
        /// </summary>
        public float4 rgbr => new float4(x, y, z, x);

        /// <summary>
        /// Returns float3.xyzy swizzling.
        /// </summary>
        public float4 xyzy => new float4(x, y, z, y);

        /// <summary>
        /// Returns float3.rgbg swizzling (equivalent to float3.xyzy).
        /// </summary>
        public float4 rgbg => new float4(x, y, z, y);

        /// <summary>
        /// Returns float3.xyzz swizzling.
        /// </summary>
        public float4 xyzz => new float4(x, y, z, z);

        /// <summary>
        /// Returns float3.rgbb swizzling (equivalent to float3.xyzz).
        /// </summary>
        public float4 rgbb => new float4(x, y, z, z);

        /// <summary>
        /// Returns float3.xz swizzling.
        /// </summary>
        public float2 xz => new float2(x, z);

        /// <summary>
        /// Returns float3.rb swizzling (equivalent to float3.xz).
        /// </summary>
        public float2 rb => new float2(x, z);

        /// <summary>
        /// Returns float3.xzx swizzling.
        /// </summary>
        public float3 xzx => new float3(x, z, x);

        /// <summary>
        /// Returns float3.rbr swizzling (equivalent to float3.xzx).
        /// </summary>
        public float3 rbr => new float3(x, z, x);

        /// <summary>
        /// Returns float3.xzxx swizzling.
        /// </summary>
        public float4 xzxx => new float4(x, z, x, x);

        /// <summary>
        /// Returns float3.rbrr swizzling (equivalent to float3.xzxx).
        /// </summary>
        public float4 rbrr => new float4(x, z, x, x);

        /// <summary>
        /// Returns float3.xzxy swizzling.
        /// </summary>
        public float4 xzxy => new float4(x, z, x, y);

        /// <summary>
        /// Returns float3.rbrg swizzling (equivalent to float3.xzxy).
        /// </summary>
        public float4 rbrg => new float4(x, z, x, y);

        /// <summary>
        /// Returns float3.xzxz swizzling.
        /// </summary>
        public float4 xzxz => new float4(x, z, x, z);

        /// <summary>
        /// Returns float3.rbrb swizzling (equivalent to float3.xzxz).
        /// </summary>
        public float4 rbrb => new float4(x, z, x, z);

        /// <summary>
        /// Returns float3.xzy swizzling.
        /// </summary>
        public float3 xzy => new float3(x, z, y);

        /// <summary>
        /// Returns float3.rbg swizzling (equivalent to float3.xzy).
        /// </summary>
        public float3 rbg => new float3(x, z, y);

        /// <summary>
        /// Returns float3.xzyx swizzling.
        /// </summary>
        public float4 xzyx => new float4(x, z, y, x);

        /// <summary>
        /// Returns float3.rbgr swizzling (equivalent to float3.xzyx).
        /// </summary>
        public float4 rbgr => new float4(x, z, y, x);

        /// <summary>
        /// Returns float3.xzyy swizzling.
        /// </summary>
        public float4 xzyy => new float4(x, z, y, y);

        /// <summary>
        /// Returns float3.rbgg swizzling (equivalent to float3.xzyy).
        /// </summary>
        public float4 rbgg => new float4(x, z, y, y);

        /// <summary>
        /// Returns float3.xzyz swizzling.
        /// </summary>
        public float4 xzyz => new float4(x, z, y, z);

        /// <summary>
        /// Returns float3.rbgb swizzling (equivalent to float3.xzyz).
        /// </summary>
        public float4 rbgb => new float4(x, z, y, z);

        /// <summary>
        /// Returns float3.xzz swizzling.
        /// </summary>
        public float3 xzz => new float3(x, z, z);

        /// <summary>
        /// Returns float3.rbb swizzling (equivalent to float3.xzz).
        /// </summary>
        public float3 rbb => new float3(x, z, z);

        /// <summary>
        /// Returns float3.xzzx swizzling.
        /// </summary>
        public float4 xzzx => new float4(x, z, z, x);

        /// <summary>
        /// Returns float3.rbbr swizzling (equivalent to float3.xzzx).
        /// </summary>
        public float4 rbbr => new float4(x, z, z, x);

        /// <summary>
        /// Returns float3.xzzy swizzling.
        /// </summary>
        public float4 xzzy => new float4(x, z, z, y);

        /// <summary>
        /// Returns float3.rbbg swizzling (equivalent to float3.xzzy).
        /// </summary>
        public float4 rbbg => new float4(x, z, z, y);

        /// <summary>
        /// Returns float3.xzzz swizzling.
        /// </summary>
        public float4 xzzz => new float4(x, z, z, z);

        /// <summary>
        /// Returns float3.rbbb swizzling (equivalent to float3.xzzz).
        /// </summary>
        public float4 rbbb => new float4(x, z, z, z);

        /// <summary>
        /// Returns float3.yx swizzling.
        /// </summary>
        public float2 yx => new float2(y, x);

        /// <summary>
        /// Returns float3.gr swizzling (equivalent to float3.yx).
        /// </summary>
        public float2 gr => new float2(y, x);

        /// <summary>
        /// Returns float3.yxx swizzling.
        /// </summary>
        public float3 yxx => new float3(y, x, x);

        /// <summary>
        /// Returns float3.grr swizzling (equivalent to float3.yxx).
        /// </summary>
        public float3 grr => new float3(y, x, x);

        /// <summary>
        /// Returns float3.yxxx swizzling.
        /// </summary>
        public float4 yxxx => new float4(y, x, x, x);

        /// <summary>
        /// Returns float3.grrr swizzling (equivalent to float3.yxxx).
        /// </summary>
        public float4 grrr => new float4(y, x, x, x);

        /// <summary>
        /// Returns float3.yxxy swizzling.
        /// </summary>
        public float4 yxxy => new float4(y, x, x, y);

        /// <summary>
        /// Returns float3.grrg swizzling (equivalent to float3.yxxy).
        /// </summary>
        public float4 grrg => new float4(y, x, x, y);

        /// <summary>
        /// Returns float3.yxxz swizzling.
        /// </summary>
        public float4 yxxz => new float4(y, x, x, z);

        /// <summary>
        /// Returns float3.grrb swizzling (equivalent to float3.yxxz).
        /// </summary>
        public float4 grrb => new float4(y, x, x, z);

        /// <summary>
        /// Returns float3.yxy swizzling.
        /// </summary>
        public float3 yxy => new float3(y, x, y);

        /// <summary>
        /// Returns float3.grg swizzling (equivalent to float3.yxy).
        /// </summary>
        public float3 grg => new float3(y, x, y);

        /// <summary>
        /// Returns float3.yxyx swizzling.
        /// </summary>
        public float4 yxyx => new float4(y, x, y, x);

        /// <summary>
        /// Returns float3.grgr swizzling (equivalent to float3.yxyx).
        /// </summary>
        public float4 grgr => new float4(y, x, y, x);

        /// <summary>
        /// Returns float3.yxyy swizzling.
        /// </summary>
        public float4 yxyy => new float4(y, x, y, y);

        /// <summary>
        /// Returns float3.grgg swizzling (equivalent to float3.yxyy).
        /// </summary>
        public float4 grgg => new float4(y, x, y, y);

        /// <summary>
        /// Returns float3.yxyz swizzling.
        /// </summary>
        public float4 yxyz => new float4(y, x, y, z);

        /// <summary>
        /// Returns float3.grgb swizzling (equivalent to float3.yxyz).
        /// </summary>
        public float4 grgb => new float4(y, x, y, z);

        /// <summary>
        /// Returns float3.yxz swizzling.
        /// </summary>
        public float3 yxz => new float3(y, x, z);

        /// <summary>
        /// Returns float3.grb swizzling (equivalent to float3.yxz).
        /// </summary>
        public float3 grb => new float3(y, x, z);

        /// <summary>
        /// Returns float3.yxzx swizzling.
        /// </summary>
        public float4 yxzx => new float4(y, x, z, x);

        /// <summary>
        /// Returns float3.grbr swizzling (equivalent to float3.yxzx).
        /// </summary>
        public float4 grbr => new float4(y, x, z, x);

        /// <summary>
        /// Returns float3.yxzy swizzling.
        /// </summary>
        public float4 yxzy => new float4(y, x, z, y);

        /// <summary>
        /// Returns float3.grbg swizzling (equivalent to float3.yxzy).
        /// </summary>
        public float4 grbg => new float4(y, x, z, y);

        /// <summary>
        /// Returns float3.yxzz swizzling.
        /// </summary>
        public float4 yxzz => new float4(y, x, z, z);

        /// <summary>
        /// Returns float3.grbb swizzling (equivalent to float3.yxzz).
        /// </summary>
        public float4 grbb => new float4(y, x, z, z);

        /// <summary>
        /// Returns float3.yy swizzling.
        /// </summary>
        public float2 yy => new float2(y, y);

        /// <summary>
        /// Returns float3.gg swizzling (equivalent to float3.yy).
        /// </summary>
        public float2 gg => new float2(y, y);

        /// <summary>
        /// Returns float3.yyx swizzling.
        /// </summary>
        public float3 yyx => new float3(y, y, x);

        /// <summary>
        /// Returns float3.ggr swizzling (equivalent to float3.yyx).
        /// </summary>
        public float3 ggr => new float3(y, y, x);

        /// <summary>
        /// Returns float3.yyxx swizzling.
        /// </summary>
        public float4 yyxx => new float4(y, y, x, x);

        /// <summary>
        /// Returns float3.ggrr swizzling (equivalent to float3.yyxx).
        /// </summary>
        public float4 ggrr => new float4(y, y, x, x);

        /// <summary>
        /// Returns float3.yyxy swizzling.
        /// </summary>
        public float4 yyxy => new float4(y, y, x, y);

        /// <summary>
        /// Returns float3.ggrg swizzling (equivalent to float3.yyxy).
        /// </summary>
        public float4 ggrg => new float4(y, y, x, y);

        /// <summary>
        /// Returns float3.yyxz swizzling.
        /// </summary>
        public float4 yyxz => new float4(y, y, x, z);

        /// <summary>
        /// Returns float3.ggrb swizzling (equivalent to float3.yyxz).
        /// </summary>
        public float4 ggrb => new float4(y, y, x, z);

        /// <summary>
        /// Returns float3.yyy swizzling.
        /// </summary>
        public float3 yyy => new float3(y, y, y);

        /// <summary>
        /// Returns float3.ggg swizzling (equivalent to float3.yyy).
        /// </summary>
        public float3 ggg => new float3(y, y, y);

        /// <summary>
        /// Returns float3.yyyx swizzling.
        /// </summary>
        public float4 yyyx => new float4(y, y, y, x);

        /// <summary>
        /// Returns float3.gggr swizzling (equivalent to float3.yyyx).
        /// </summary>
        public float4 gggr => new float4(y, y, y, x);

        /// <summary>
        /// Returns float3.yyyy swizzling.
        /// </summary>
        public float4 yyyy => new float4(y, y, y, y);

        /// <summary>
        /// Returns float3.gggg swizzling (equivalent to float3.yyyy).
        /// </summary>
        public float4 gggg => new float4(y, y, y, y);

        /// <summary>
        /// Returns float3.yyyz swizzling.
        /// </summary>
        public float4 yyyz => new float4(y, y, y, z);

        /// <summary>
        /// Returns float3.gggb swizzling (equivalent to float3.yyyz).
        /// </summary>
        public float4 gggb => new float4(y, y, y, z);

        /// <summary>
        /// Returns float3.yyz swizzling.
        /// </summary>
        public float3 yyz => new float3(y, y, z);

        /// <summary>
        /// Returns float3.ggb swizzling (equivalent to float3.yyz).
        /// </summary>
        public float3 ggb => new float3(y, y, z);

        /// <summary>
        /// Returns float3.yyzx swizzling.
        /// </summary>
        public float4 yyzx => new float4(y, y, z, x);

        /// <summary>
        /// Returns float3.ggbr swizzling (equivalent to float3.yyzx).
        /// </summary>
        public float4 ggbr => new float4(y, y, z, x);

        /// <summary>
        /// Returns float3.yyzy swizzling.
        /// </summary>
        public float4 yyzy => new float4(y, y, z, y);

        /// <summary>
        /// Returns float3.ggbg swizzling (equivalent to float3.yyzy).
        /// </summary>
        public float4 ggbg => new float4(y, y, z, y);

        /// <summary>
        /// Returns float3.yyzz swizzling.
        /// </summary>
        public float4 yyzz => new float4(y, y, z, z);

        /// <summary>
        /// Returns float3.ggbb swizzling (equivalent to float3.yyzz).
        /// </summary>
        public float4 ggbb => new float4(y, y, z, z);

        /// <summary>
        /// Returns float3.yz swizzling.
        /// </summary>
        public float2 yz => new float2(y, z);

        /// <summary>
        /// Returns float3.gb swizzling (equivalent to float3.yz).
        /// </summary>
        public float2 gb => new float2(y, z);

        /// <summary>
        /// Returns float3.yzx swizzling.
        /// </summary>
        public float3 yzx => new float3(y, z, x);

        /// <summary>
        /// Returns float3.gbr swizzling (equivalent to float3.yzx).
        /// </summary>
        public float3 gbr => new float3(y, z, x);

        /// <summary>
        /// Returns float3.yzxx swizzling.
        /// </summary>
        public float4 yzxx => new float4(y, z, x, x);

        /// <summary>
        /// Returns float3.gbrr swizzling (equivalent to float3.yzxx).
        /// </summary>
        public float4 gbrr => new float4(y, z, x, x);

        /// <summary>
        /// Returns float3.yzxy swizzling.
        /// </summary>
        public float4 yzxy => new float4(y, z, x, y);

        /// <summary>
        /// Returns float3.gbrg swizzling (equivalent to float3.yzxy).
        /// </summary>
        public float4 gbrg => new float4(y, z, x, y);

        /// <summary>
        /// Returns float3.yzxz swizzling.
        /// </summary>
        public float4 yzxz => new float4(y, z, x, z);

        /// <summary>
        /// Returns float3.gbrb swizzling (equivalent to float3.yzxz).
        /// </summary>
        public float4 gbrb => new float4(y, z, x, z);

        /// <summary>
        /// Returns float3.yzy swizzling.
        /// </summary>
        public float3 yzy => new float3(y, z, y);

        /// <summary>
        /// Returns float3.gbg swizzling (equivalent to float3.yzy).
        /// </summary>
        public float3 gbg => new float3(y, z, y);

        /// <summary>
        /// Returns float3.yzyx swizzling.
        /// </summary>
        public float4 yzyx => new float4(y, z, y, x);

        /// <summary>
        /// Returns float3.gbgr swizzling (equivalent to float3.yzyx).
        /// </summary>
        public float4 gbgr => new float4(y, z, y, x);

        /// <summary>
        /// Returns float3.yzyy swizzling.
        /// </summary>
        public float4 yzyy => new float4(y, z, y, y);

        /// <summary>
        /// Returns float3.gbgg swizzling (equivalent to float3.yzyy).
        /// </summary>
        public float4 gbgg => new float4(y, z, y, y);

        /// <summary>
        /// Returns float3.yzyz swizzling.
        /// </summary>
        public float4 yzyz => new float4(y, z, y, z);

        /// <summary>
        /// Returns float3.gbgb swizzling (equivalent to float3.yzyz).
        /// </summary>
        public float4 gbgb => new float4(y, z, y, z);

        /// <summary>
        /// Returns float3.yzz swizzling.
        /// </summary>
        public float3 yzz => new float3(y, z, z);

        /// <summary>
        /// Returns float3.gbb swizzling (equivalent to float3.yzz).
        /// </summary>
        public float3 gbb => new float3(y, z, z);

        /// <summary>
        /// Returns float3.yzzx swizzling.
        /// </summary>
        public float4 yzzx => new float4(y, z, z, x);

        /// <summary>
        /// Returns float3.gbbr swizzling (equivalent to float3.yzzx).
        /// </summary>
        public float4 gbbr => new float4(y, z, z, x);

        /// <summary>
        /// Returns float3.yzzy swizzling.
        /// </summary>
        public float4 yzzy => new float4(y, z, z, y);

        /// <summary>
        /// Returns float3.gbbg swizzling (equivalent to float3.yzzy).
        /// </summary>
        public float4 gbbg => new float4(y, z, z, y);

        /// <summary>
        /// Returns float3.yzzz swizzling.
        /// </summary>
        public float4 yzzz => new float4(y, z, z, z);

        /// <summary>
        /// Returns float3.gbbb swizzling (equivalent to float3.yzzz).
        /// </summary>
        public float4 gbbb => new float4(y, z, z, z);

        /// <summary>
        /// Returns float3.zx swizzling.
        /// </summary>
        public float2 zx => new float2(z, x);

        /// <summary>
        /// Returns float3.br swizzling (equivalent to float3.zx).
        /// </summary>
        public float2 br => new float2(z, x);

        /// <summary>
        /// Returns float3.zxx swizzling.
        /// </summary>
        public float3 zxx => new float3(z, x, x);

        /// <summary>
        /// Returns float3.brr swizzling (equivalent to float3.zxx).
        /// </summary>
        public float3 brr => new float3(z, x, x);

        /// <summary>
        /// Returns float3.zxxx swizzling.
        /// </summary>
        public float4 zxxx => new float4(z, x, x, x);

        /// <summary>
        /// Returns float3.brrr swizzling (equivalent to float3.zxxx).
        /// </summary>
        public float4 brrr => new float4(z, x, x, x);

        /// <summary>
        /// Returns float3.zxxy swizzling.
        /// </summary>
        public float4 zxxy => new float4(z, x, x, y);

        /// <summary>
        /// Returns float3.brrg swizzling (equivalent to float3.zxxy).
        /// </summary>
        public float4 brrg => new float4(z, x, x, y);

        /// <summary>
        /// Returns float3.zxxz swizzling.
        /// </summary>
        public float4 zxxz => new float4(z, x, x, z);

        /// <summary>
        /// Returns float3.brrb swizzling (equivalent to float3.zxxz).
        /// </summary>
        public float4 brrb => new float4(z, x, x, z);

        /// <summary>
        /// Returns float3.zxy swizzling.
        /// </summary>
        public float3 zxy => new float3(z, x, y);

        /// <summary>
        /// Returns float3.brg swizzling (equivalent to float3.zxy).
        /// </summary>
        public float3 brg => new float3(z, x, y);

        /// <summary>
        /// Returns float3.zxyx swizzling.
        /// </summary>
        public float4 zxyx => new float4(z, x, y, x);

        /// <summary>
        /// Returns float3.brgr swizzling (equivalent to float3.zxyx).
        /// </summary>
        public float4 brgr => new float4(z, x, y, x);

        /// <summary>
        /// Returns float3.zxyy swizzling.
        /// </summary>
        public float4 zxyy => new float4(z, x, y, y);

        /// <summary>
        /// Returns float3.brgg swizzling (equivalent to float3.zxyy).
        /// </summary>
        public float4 brgg => new float4(z, x, y, y);

        /// <summary>
        /// Returns float3.zxyz swizzling.
        /// </summary>
        public float4 zxyz => new float4(z, x, y, z);

        /// <summary>
        /// Returns float3.brgb swizzling (equivalent to float3.zxyz).
        /// </summary>
        public float4 brgb => new float4(z, x, y, z);

        /// <summary>
        /// Returns float3.zxz swizzling.
        /// </summary>
        public float3 zxz => new float3(z, x, z);

        /// <summary>
        /// Returns float3.brb swizzling (equivalent to float3.zxz).
        /// </summary>
        public float3 brb => new float3(z, x, z);

        /// <summary>
        /// Returns float3.zxzx swizzling.
        /// </summary>
        public float4 zxzx => new float4(z, x, z, x);

        /// <summary>
        /// Returns float3.brbr swizzling (equivalent to float3.zxzx).
        /// </summary>
        public float4 brbr => new float4(z, x, z, x);

        /// <summary>
        /// Returns float3.zxzy swizzling.
        /// </summary>
        public float4 zxzy => new float4(z, x, z, y);

        /// <summary>
        /// Returns float3.brbg swizzling (equivalent to float3.zxzy).
        /// </summary>
        public float4 brbg => new float4(z, x, z, y);

        /// <summary>
        /// Returns float3.zxzz swizzling.
        /// </summary>
        public float4 zxzz => new float4(z, x, z, z);

        /// <summary>
        /// Returns float3.brbb swizzling (equivalent to float3.zxzz).
        /// </summary>
        public float4 brbb => new float4(z, x, z, z);

        /// <summary>
        /// Returns float3.zy swizzling.
        /// </summary>
        public float2 zy => new float2(z, y);

        /// <summary>
        /// Returns float3.bg swizzling (equivalent to float3.zy).
        /// </summary>
        public float2 bg => new float2(z, y);

        /// <summary>
        /// Returns float3.zyx swizzling.
        /// </summary>
        public float3 zyx => new float3(z, y, x);

        /// <summary>
        /// Returns float3.bgr swizzling (equivalent to float3.zyx).
        /// </summary>
        public float3 bgr => new float3(z, y, x);

        /// <summary>
        /// Returns float3.zyxx swizzling.
        /// </summary>
        public float4 zyxx => new float4(z, y, x, x);

        /// <summary>
        /// Returns float3.bgrr swizzling (equivalent to float3.zyxx).
        /// </summary>
        public float4 bgrr => new float4(z, y, x, x);

        /// <summary>
        /// Returns float3.zyxy swizzling.
        /// </summary>
        public float4 zyxy => new float4(z, y, x, y);

        /// <summary>
        /// Returns float3.bgrg swizzling (equivalent to float3.zyxy).
        /// </summary>
        public float4 bgrg => new float4(z, y, x, y);

        /// <summary>
        /// Returns float3.zyxz swizzling.
        /// </summary>
        public float4 zyxz => new float4(z, y, x, z);

        /// <summary>
        /// Returns float3.bgrb swizzling (equivalent to float3.zyxz).
        /// </summary>
        public float4 bgrb => new float4(z, y, x, z);

        /// <summary>
        /// Returns float3.zyy swizzling.
        /// </summary>
        public float3 zyy => new float3(z, y, y);

        /// <summary>
        /// Returns float3.bgg swizzling (equivalent to float3.zyy).
        /// </summary>
        public float3 bgg => new float3(z, y, y);

        /// <summary>
        /// Returns float3.zyyx swizzling.
        /// </summary>
        public float4 zyyx => new float4(z, y, y, x);

        /// <summary>
        /// Returns float3.bggr swizzling (equivalent to float3.zyyx).
        /// </summary>
        public float4 bggr => new float4(z, y, y, x);

        /// <summary>
        /// Returns float3.zyyy swizzling.
        /// </summary>
        public float4 zyyy => new float4(z, y, y, y);

        /// <summary>
        /// Returns float3.bggg swizzling (equivalent to float3.zyyy).
        /// </summary>
        public float4 bggg => new float4(z, y, y, y);

        /// <summary>
        /// Returns float3.zyyz swizzling.
        /// </summary>
        public float4 zyyz => new float4(z, y, y, z);

        /// <summary>
        /// Returns float3.bggb swizzling (equivalent to float3.zyyz).
        /// </summary>
        public float4 bggb => new float4(z, y, y, z);

        /// <summary>
        /// Returns float3.zyz swizzling.
        /// </summary>
        public float3 zyz => new float3(z, y, z);

        /// <summary>
        /// Returns float3.bgb swizzling (equivalent to float3.zyz).
        /// </summary>
        public float3 bgb => new float3(z, y, z);

        /// <summary>
        /// Returns float3.zyzx swizzling.
        /// </summary>
        public float4 zyzx => new float4(z, y, z, x);

        /// <summary>
        /// Returns float3.bgbr swizzling (equivalent to float3.zyzx).
        /// </summary>
        public float4 bgbr => new float4(z, y, z, x);

        /// <summary>
        /// Returns float3.zyzy swizzling.
        /// </summary>
        public float4 zyzy => new float4(z, y, z, y);

        /// <summary>
        /// Returns float3.bgbg swizzling (equivalent to float3.zyzy).
        /// </summary>
        public float4 bgbg => new float4(z, y, z, y);

        /// <summary>
        /// Returns float3.zyzz swizzling.
        /// </summary>
        public float4 zyzz => new float4(z, y, z, z);

        /// <summary>
        /// Returns float3.bgbb swizzling (equivalent to float3.zyzz).
        /// </summary>
        public float4 bgbb => new float4(z, y, z, z);

        /// <summary>
        /// Returns float3.zz swizzling.
        /// </summary>
        public float2 zz => new float2(z, z);

        /// <summary>
        /// Returns float3.bb swizzling (equivalent to float3.zz).
        /// </summary>
        public float2 bb => new float2(z, z);

        /// <summary>
        /// Returns float3.zzx swizzling.
        /// </summary>
        public float3 zzx => new float3(z, z, x);

        /// <summary>
        /// Returns float3.bbr swizzling (equivalent to float3.zzx).
        /// </summary>
        public float3 bbr => new float3(z, z, x);

        /// <summary>
        /// Returns float3.zzxx swizzling.
        /// </summary>
        public float4 zzxx => new float4(z, z, x, x);

        /// <summary>
        /// Returns float3.bbrr swizzling (equivalent to float3.zzxx).
        /// </summary>
        public float4 bbrr => new float4(z, z, x, x);

        /// <summary>
        /// Returns float3.zzxy swizzling.
        /// </summary>
        public float4 zzxy => new float4(z, z, x, y);

        /// <summary>
        /// Returns float3.bbrg swizzling (equivalent to float3.zzxy).
        /// </summary>
        public float4 bbrg => new float4(z, z, x, y);

        /// <summary>
        /// Returns float3.zzxz swizzling.
        /// </summary>
        public float4 zzxz => new float4(z, z, x, z);

        /// <summary>
        /// Returns float3.bbrb swizzling (equivalent to float3.zzxz).
        /// </summary>
        public float4 bbrb => new float4(z, z, x, z);

        /// <summary>
        /// Returns float3.zzy swizzling.
        /// </summary>
        public float3 zzy => new float3(z, z, y);

        /// <summary>
        /// Returns float3.bbg swizzling (equivalent to float3.zzy).
        /// </summary>
        public float3 bbg => new float3(z, z, y);

        /// <summary>
        /// Returns float3.zzyx swizzling.
        /// </summary>
        public float4 zzyx => new float4(z, z, y, x);

        /// <summary>
        /// Returns float3.bbgr swizzling (equivalent to float3.zzyx).
        /// </summary>
        public float4 bbgr => new float4(z, z, y, x);

        /// <summary>
        /// Returns float3.zzyy swizzling.
        /// </summary>
        public float4 zzyy => new float4(z, z, y, y);

        /// <summary>
        /// Returns float3.bbgg swizzling (equivalent to float3.zzyy).
        /// </summary>
        public float4 bbgg => new float4(z, z, y, y);

        /// <summary>
        /// Returns float3.zzyz swizzling.
        /// </summary>
        public float4 zzyz => new float4(z, z, y, z);

        /// <summary>
        /// Returns float3.bbgb swizzling (equivalent to float3.zzyz).
        /// </summary>
        public float4 bbgb => new float4(z, z, y, z);

        /// <summary>
        /// Returns float3.zzz swizzling.
        /// </summary>
        public float3 zzz => new float3(z, z, z);

        /// <summary>
        /// Returns float3.bbb swizzling (equivalent to float3.zzz).
        /// </summary>
        public float3 bbb => new float3(z, z, z);

        /// <summary>
        /// Returns float3.zzzx swizzling.
        /// </summary>
        public float4 zzzx => new float4(z, z, z, x);

        /// <summary>
        /// Returns float3.bbbr swizzling (equivalent to float3.zzzx).
        /// </summary>
        public float4 bbbr => new float4(z, z, z, x);

        /// <summary>
        /// Returns float3.zzzy swizzling.
        /// </summary>
        public float4 zzzy => new float4(z, z, z, y);

        /// <summary>
        /// Returns float3.bbbg swizzling (equivalent to float3.zzzy).
        /// </summary>
        public float4 bbbg => new float4(z, z, z, y);

        /// <summary>
        /// Returns float3.zzzz swizzling.
        /// </summary>
        public float4 zzzz => new float4(z, z, z, z);

        /// <summary>
        /// Returns float3.bbbb swizzling (equivalent to float3.zzzz).
        /// </summary>
        public float4 bbbb => new float4(z, z, z, z);

        #endregion

    }
}
