using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type uint with 3 components, used for implementing swizzling for uint3.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_uvec3
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        internal readonly uint x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        internal readonly uint y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        internal readonly uint z;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_uvec3.
        /// </summary>
        internal swizzle_uvec3(uint x, uint y, uint z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns uint3.xx swizzling.
        /// </summary>
        public uint2 xx => new uint2(x, x);

        /// <summary>
        /// Returns uint3.rr swizzling (equivalent to uint3.xx).
        /// </summary>
        public uint2 rr => new uint2(x, x);

        /// <summary>
        /// Returns uint3.xxx swizzling.
        /// </summary>
        public uint3 xxx => new uint3(x, x, x);

        /// <summary>
        /// Returns uint3.rrr swizzling (equivalent to uint3.xxx).
        /// </summary>
        public uint3 rrr => new uint3(x, x, x);

        /// <summary>
        /// Returns uint3.xxxx swizzling.
        /// </summary>
        public uint4 xxxx => new uint4(x, x, x, x);

        /// <summary>
        /// Returns uint3.rrrr swizzling (equivalent to uint3.xxxx).
        /// </summary>
        public uint4 rrrr => new uint4(x, x, x, x);

        /// <summary>
        /// Returns uint3.xxxy swizzling.
        /// </summary>
        public uint4 xxxy => new uint4(x, x, x, y);

        /// <summary>
        /// Returns uint3.rrrg swizzling (equivalent to uint3.xxxy).
        /// </summary>
        public uint4 rrrg => new uint4(x, x, x, y);

        /// <summary>
        /// Returns uint3.xxxz swizzling.
        /// </summary>
        public uint4 xxxz => new uint4(x, x, x, z);

        /// <summary>
        /// Returns uint3.rrrb swizzling (equivalent to uint3.xxxz).
        /// </summary>
        public uint4 rrrb => new uint4(x, x, x, z);

        /// <summary>
        /// Returns uint3.xxy swizzling.
        /// </summary>
        public uint3 xxy => new uint3(x, x, y);

        /// <summary>
        /// Returns uint3.rrg swizzling (equivalent to uint3.xxy).
        /// </summary>
        public uint3 rrg => new uint3(x, x, y);

        /// <summary>
        /// Returns uint3.xxyx swizzling.
        /// </summary>
        public uint4 xxyx => new uint4(x, x, y, x);

        /// <summary>
        /// Returns uint3.rrgr swizzling (equivalent to uint3.xxyx).
        /// </summary>
        public uint4 rrgr => new uint4(x, x, y, x);

        /// <summary>
        /// Returns uint3.xxyy swizzling.
        /// </summary>
        public uint4 xxyy => new uint4(x, x, y, y);

        /// <summary>
        /// Returns uint3.rrgg swizzling (equivalent to uint3.xxyy).
        /// </summary>
        public uint4 rrgg => new uint4(x, x, y, y);

        /// <summary>
        /// Returns uint3.xxyz swizzling.
        /// </summary>
        public uint4 xxyz => new uint4(x, x, y, z);

        /// <summary>
        /// Returns uint3.rrgb swizzling (equivalent to uint3.xxyz).
        /// </summary>
        public uint4 rrgb => new uint4(x, x, y, z);

        /// <summary>
        /// Returns uint3.xxz swizzling.
        /// </summary>
        public uint3 xxz => new uint3(x, x, z);

        /// <summary>
        /// Returns uint3.rrb swizzling (equivalent to uint3.xxz).
        /// </summary>
        public uint3 rrb => new uint3(x, x, z);

        /// <summary>
        /// Returns uint3.xxzx swizzling.
        /// </summary>
        public uint4 xxzx => new uint4(x, x, z, x);

        /// <summary>
        /// Returns uint3.rrbr swizzling (equivalent to uint3.xxzx).
        /// </summary>
        public uint4 rrbr => new uint4(x, x, z, x);

        /// <summary>
        /// Returns uint3.xxzy swizzling.
        /// </summary>
        public uint4 xxzy => new uint4(x, x, z, y);

        /// <summary>
        /// Returns uint3.rrbg swizzling (equivalent to uint3.xxzy).
        /// </summary>
        public uint4 rrbg => new uint4(x, x, z, y);

        /// <summary>
        /// Returns uint3.xxzz swizzling.
        /// </summary>
        public uint4 xxzz => new uint4(x, x, z, z);

        /// <summary>
        /// Returns uint3.rrbb swizzling (equivalent to uint3.xxzz).
        /// </summary>
        public uint4 rrbb => new uint4(x, x, z, z);

        /// <summary>
        /// Returns uint3.xy swizzling.
        /// </summary>
        public uint2 xy => new uint2(x, y);

        /// <summary>
        /// Returns uint3.rg swizzling (equivalent to uint3.xy).
        /// </summary>
        public uint2 rg => new uint2(x, y);

        /// <summary>
        /// Returns uint3.xyx swizzling.
        /// </summary>
        public uint3 xyx => new uint3(x, y, x);

        /// <summary>
        /// Returns uint3.rgr swizzling (equivalent to uint3.xyx).
        /// </summary>
        public uint3 rgr => new uint3(x, y, x);

        /// <summary>
        /// Returns uint3.xyxx swizzling.
        /// </summary>
        public uint4 xyxx => new uint4(x, y, x, x);

        /// <summary>
        /// Returns uint3.rgrr swizzling (equivalent to uint3.xyxx).
        /// </summary>
        public uint4 rgrr => new uint4(x, y, x, x);

        /// <summary>
        /// Returns uint3.xyxy swizzling.
        /// </summary>
        public uint4 xyxy => new uint4(x, y, x, y);

        /// <summary>
        /// Returns uint3.rgrg swizzling (equivalent to uint3.xyxy).
        /// </summary>
        public uint4 rgrg => new uint4(x, y, x, y);

        /// <summary>
        /// Returns uint3.xyxz swizzling.
        /// </summary>
        public uint4 xyxz => new uint4(x, y, x, z);

        /// <summary>
        /// Returns uint3.rgrb swizzling (equivalent to uint3.xyxz).
        /// </summary>
        public uint4 rgrb => new uint4(x, y, x, z);

        /// <summary>
        /// Returns uint3.xyy swizzling.
        /// </summary>
        public uint3 xyy => new uint3(x, y, y);

        /// <summary>
        /// Returns uint3.rgg swizzling (equivalent to uint3.xyy).
        /// </summary>
        public uint3 rgg => new uint3(x, y, y);

        /// <summary>
        /// Returns uint3.xyyx swizzling.
        /// </summary>
        public uint4 xyyx => new uint4(x, y, y, x);

        /// <summary>
        /// Returns uint3.rggr swizzling (equivalent to uint3.xyyx).
        /// </summary>
        public uint4 rggr => new uint4(x, y, y, x);

        /// <summary>
        /// Returns uint3.xyyy swizzling.
        /// </summary>
        public uint4 xyyy => new uint4(x, y, y, y);

        /// <summary>
        /// Returns uint3.rggg swizzling (equivalent to uint3.xyyy).
        /// </summary>
        public uint4 rggg => new uint4(x, y, y, y);

        /// <summary>
        /// Returns uint3.xyyz swizzling.
        /// </summary>
        public uint4 xyyz => new uint4(x, y, y, z);

        /// <summary>
        /// Returns uint3.rggb swizzling (equivalent to uint3.xyyz).
        /// </summary>
        public uint4 rggb => new uint4(x, y, y, z);

        /// <summary>
        /// Returns uint3.xyz swizzling.
        /// </summary>
        public uint3 xyz => new uint3(x, y, z);

        /// <summary>
        /// Returns uint3.rgb swizzling (equivalent to uint3.xyz).
        /// </summary>
        public uint3 rgb => new uint3(x, y, z);

        /// <summary>
        /// Returns uint3.xyzx swizzling.
        /// </summary>
        public uint4 xyzx => new uint4(x, y, z, x);

        /// <summary>
        /// Returns uint3.rgbr swizzling (equivalent to uint3.xyzx).
        /// </summary>
        public uint4 rgbr => new uint4(x, y, z, x);

        /// <summary>
        /// Returns uint3.xyzy swizzling.
        /// </summary>
        public uint4 xyzy => new uint4(x, y, z, y);

        /// <summary>
        /// Returns uint3.rgbg swizzling (equivalent to uint3.xyzy).
        /// </summary>
        public uint4 rgbg => new uint4(x, y, z, y);

        /// <summary>
        /// Returns uint3.xyzz swizzling.
        /// </summary>
        public uint4 xyzz => new uint4(x, y, z, z);

        /// <summary>
        /// Returns uint3.rgbb swizzling (equivalent to uint3.xyzz).
        /// </summary>
        public uint4 rgbb => new uint4(x, y, z, z);

        /// <summary>
        /// Returns uint3.xz swizzling.
        /// </summary>
        public uint2 xz => new uint2(x, z);

        /// <summary>
        /// Returns uint3.rb swizzling (equivalent to uint3.xz).
        /// </summary>
        public uint2 rb => new uint2(x, z);

        /// <summary>
        /// Returns uint3.xzx swizzling.
        /// </summary>
        public uint3 xzx => new uint3(x, z, x);

        /// <summary>
        /// Returns uint3.rbr swizzling (equivalent to uint3.xzx).
        /// </summary>
        public uint3 rbr => new uint3(x, z, x);

        /// <summary>
        /// Returns uint3.xzxx swizzling.
        /// </summary>
        public uint4 xzxx => new uint4(x, z, x, x);

        /// <summary>
        /// Returns uint3.rbrr swizzling (equivalent to uint3.xzxx).
        /// </summary>
        public uint4 rbrr => new uint4(x, z, x, x);

        /// <summary>
        /// Returns uint3.xzxy swizzling.
        /// </summary>
        public uint4 xzxy => new uint4(x, z, x, y);

        /// <summary>
        /// Returns uint3.rbrg swizzling (equivalent to uint3.xzxy).
        /// </summary>
        public uint4 rbrg => new uint4(x, z, x, y);

        /// <summary>
        /// Returns uint3.xzxz swizzling.
        /// </summary>
        public uint4 xzxz => new uint4(x, z, x, z);

        /// <summary>
        /// Returns uint3.rbrb swizzling (equivalent to uint3.xzxz).
        /// </summary>
        public uint4 rbrb => new uint4(x, z, x, z);

        /// <summary>
        /// Returns uint3.xzy swizzling.
        /// </summary>
        public uint3 xzy => new uint3(x, z, y);

        /// <summary>
        /// Returns uint3.rbg swizzling (equivalent to uint3.xzy).
        /// </summary>
        public uint3 rbg => new uint3(x, z, y);

        /// <summary>
        /// Returns uint3.xzyx swizzling.
        /// </summary>
        public uint4 xzyx => new uint4(x, z, y, x);

        /// <summary>
        /// Returns uint3.rbgr swizzling (equivalent to uint3.xzyx).
        /// </summary>
        public uint4 rbgr => new uint4(x, z, y, x);

        /// <summary>
        /// Returns uint3.xzyy swizzling.
        /// </summary>
        public uint4 xzyy => new uint4(x, z, y, y);

        /// <summary>
        /// Returns uint3.rbgg swizzling (equivalent to uint3.xzyy).
        /// </summary>
        public uint4 rbgg => new uint4(x, z, y, y);

        /// <summary>
        /// Returns uint3.xzyz swizzling.
        /// </summary>
        public uint4 xzyz => new uint4(x, z, y, z);

        /// <summary>
        /// Returns uint3.rbgb swizzling (equivalent to uint3.xzyz).
        /// </summary>
        public uint4 rbgb => new uint4(x, z, y, z);

        /// <summary>
        /// Returns uint3.xzz swizzling.
        /// </summary>
        public uint3 xzz => new uint3(x, z, z);

        /// <summary>
        /// Returns uint3.rbb swizzling (equivalent to uint3.xzz).
        /// </summary>
        public uint3 rbb => new uint3(x, z, z);

        /// <summary>
        /// Returns uint3.xzzx swizzling.
        /// </summary>
        public uint4 xzzx => new uint4(x, z, z, x);

        /// <summary>
        /// Returns uint3.rbbr swizzling (equivalent to uint3.xzzx).
        /// </summary>
        public uint4 rbbr => new uint4(x, z, z, x);

        /// <summary>
        /// Returns uint3.xzzy swizzling.
        /// </summary>
        public uint4 xzzy => new uint4(x, z, z, y);

        /// <summary>
        /// Returns uint3.rbbg swizzling (equivalent to uint3.xzzy).
        /// </summary>
        public uint4 rbbg => new uint4(x, z, z, y);

        /// <summary>
        /// Returns uint3.xzzz swizzling.
        /// </summary>
        public uint4 xzzz => new uint4(x, z, z, z);

        /// <summary>
        /// Returns uint3.rbbb swizzling (equivalent to uint3.xzzz).
        /// </summary>
        public uint4 rbbb => new uint4(x, z, z, z);

        /// <summary>
        /// Returns uint3.yx swizzling.
        /// </summary>
        public uint2 yx => new uint2(y, x);

        /// <summary>
        /// Returns uint3.gr swizzling (equivalent to uint3.yx).
        /// </summary>
        public uint2 gr => new uint2(y, x);

        /// <summary>
        /// Returns uint3.yxx swizzling.
        /// </summary>
        public uint3 yxx => new uint3(y, x, x);

        /// <summary>
        /// Returns uint3.grr swizzling (equivalent to uint3.yxx).
        /// </summary>
        public uint3 grr => new uint3(y, x, x);

        /// <summary>
        /// Returns uint3.yxxx swizzling.
        /// </summary>
        public uint4 yxxx => new uint4(y, x, x, x);

        /// <summary>
        /// Returns uint3.grrr swizzling (equivalent to uint3.yxxx).
        /// </summary>
        public uint4 grrr => new uint4(y, x, x, x);

        /// <summary>
        /// Returns uint3.yxxy swizzling.
        /// </summary>
        public uint4 yxxy => new uint4(y, x, x, y);

        /// <summary>
        /// Returns uint3.grrg swizzling (equivalent to uint3.yxxy).
        /// </summary>
        public uint4 grrg => new uint4(y, x, x, y);

        /// <summary>
        /// Returns uint3.yxxz swizzling.
        /// </summary>
        public uint4 yxxz => new uint4(y, x, x, z);

        /// <summary>
        /// Returns uint3.grrb swizzling (equivalent to uint3.yxxz).
        /// </summary>
        public uint4 grrb => new uint4(y, x, x, z);

        /// <summary>
        /// Returns uint3.yxy swizzling.
        /// </summary>
        public uint3 yxy => new uint3(y, x, y);

        /// <summary>
        /// Returns uint3.grg swizzling (equivalent to uint3.yxy).
        /// </summary>
        public uint3 grg => new uint3(y, x, y);

        /// <summary>
        /// Returns uint3.yxyx swizzling.
        /// </summary>
        public uint4 yxyx => new uint4(y, x, y, x);

        /// <summary>
        /// Returns uint3.grgr swizzling (equivalent to uint3.yxyx).
        /// </summary>
        public uint4 grgr => new uint4(y, x, y, x);

        /// <summary>
        /// Returns uint3.yxyy swizzling.
        /// </summary>
        public uint4 yxyy => new uint4(y, x, y, y);

        /// <summary>
        /// Returns uint3.grgg swizzling (equivalent to uint3.yxyy).
        /// </summary>
        public uint4 grgg => new uint4(y, x, y, y);

        /// <summary>
        /// Returns uint3.yxyz swizzling.
        /// </summary>
        public uint4 yxyz => new uint4(y, x, y, z);

        /// <summary>
        /// Returns uint3.grgb swizzling (equivalent to uint3.yxyz).
        /// </summary>
        public uint4 grgb => new uint4(y, x, y, z);

        /// <summary>
        /// Returns uint3.yxz swizzling.
        /// </summary>
        public uint3 yxz => new uint3(y, x, z);

        /// <summary>
        /// Returns uint3.grb swizzling (equivalent to uint3.yxz).
        /// </summary>
        public uint3 grb => new uint3(y, x, z);

        /// <summary>
        /// Returns uint3.yxzx swizzling.
        /// </summary>
        public uint4 yxzx => new uint4(y, x, z, x);

        /// <summary>
        /// Returns uint3.grbr swizzling (equivalent to uint3.yxzx).
        /// </summary>
        public uint4 grbr => new uint4(y, x, z, x);

        /// <summary>
        /// Returns uint3.yxzy swizzling.
        /// </summary>
        public uint4 yxzy => new uint4(y, x, z, y);

        /// <summary>
        /// Returns uint3.grbg swizzling (equivalent to uint3.yxzy).
        /// </summary>
        public uint4 grbg => new uint4(y, x, z, y);

        /// <summary>
        /// Returns uint3.yxzz swizzling.
        /// </summary>
        public uint4 yxzz => new uint4(y, x, z, z);

        /// <summary>
        /// Returns uint3.grbb swizzling (equivalent to uint3.yxzz).
        /// </summary>
        public uint4 grbb => new uint4(y, x, z, z);

        /// <summary>
        /// Returns uint3.yy swizzling.
        /// </summary>
        public uint2 yy => new uint2(y, y);

        /// <summary>
        /// Returns uint3.gg swizzling (equivalent to uint3.yy).
        /// </summary>
        public uint2 gg => new uint2(y, y);

        /// <summary>
        /// Returns uint3.yyx swizzling.
        /// </summary>
        public uint3 yyx => new uint3(y, y, x);

        /// <summary>
        /// Returns uint3.ggr swizzling (equivalent to uint3.yyx).
        /// </summary>
        public uint3 ggr => new uint3(y, y, x);

        /// <summary>
        /// Returns uint3.yyxx swizzling.
        /// </summary>
        public uint4 yyxx => new uint4(y, y, x, x);

        /// <summary>
        /// Returns uint3.ggrr swizzling (equivalent to uint3.yyxx).
        /// </summary>
        public uint4 ggrr => new uint4(y, y, x, x);

        /// <summary>
        /// Returns uint3.yyxy swizzling.
        /// </summary>
        public uint4 yyxy => new uint4(y, y, x, y);

        /// <summary>
        /// Returns uint3.ggrg swizzling (equivalent to uint3.yyxy).
        /// </summary>
        public uint4 ggrg => new uint4(y, y, x, y);

        /// <summary>
        /// Returns uint3.yyxz swizzling.
        /// </summary>
        public uint4 yyxz => new uint4(y, y, x, z);

        /// <summary>
        /// Returns uint3.ggrb swizzling (equivalent to uint3.yyxz).
        /// </summary>
        public uint4 ggrb => new uint4(y, y, x, z);

        /// <summary>
        /// Returns uint3.yyy swizzling.
        /// </summary>
        public uint3 yyy => new uint3(y, y, y);

        /// <summary>
        /// Returns uint3.ggg swizzling (equivalent to uint3.yyy).
        /// </summary>
        public uint3 ggg => new uint3(y, y, y);

        /// <summary>
        /// Returns uint3.yyyx swizzling.
        /// </summary>
        public uint4 yyyx => new uint4(y, y, y, x);

        /// <summary>
        /// Returns uint3.gggr swizzling (equivalent to uint3.yyyx).
        /// </summary>
        public uint4 gggr => new uint4(y, y, y, x);

        /// <summary>
        /// Returns uint3.yyyy swizzling.
        /// </summary>
        public uint4 yyyy => new uint4(y, y, y, y);

        /// <summary>
        /// Returns uint3.gggg swizzling (equivalent to uint3.yyyy).
        /// </summary>
        public uint4 gggg => new uint4(y, y, y, y);

        /// <summary>
        /// Returns uint3.yyyz swizzling.
        /// </summary>
        public uint4 yyyz => new uint4(y, y, y, z);

        /// <summary>
        /// Returns uint3.gggb swizzling (equivalent to uint3.yyyz).
        /// </summary>
        public uint4 gggb => new uint4(y, y, y, z);

        /// <summary>
        /// Returns uint3.yyz swizzling.
        /// </summary>
        public uint3 yyz => new uint3(y, y, z);

        /// <summary>
        /// Returns uint3.ggb swizzling (equivalent to uint3.yyz).
        /// </summary>
        public uint3 ggb => new uint3(y, y, z);

        /// <summary>
        /// Returns uint3.yyzx swizzling.
        /// </summary>
        public uint4 yyzx => new uint4(y, y, z, x);

        /// <summary>
        /// Returns uint3.ggbr swizzling (equivalent to uint3.yyzx).
        /// </summary>
        public uint4 ggbr => new uint4(y, y, z, x);

        /// <summary>
        /// Returns uint3.yyzy swizzling.
        /// </summary>
        public uint4 yyzy => new uint4(y, y, z, y);

        /// <summary>
        /// Returns uint3.ggbg swizzling (equivalent to uint3.yyzy).
        /// </summary>
        public uint4 ggbg => new uint4(y, y, z, y);

        /// <summary>
        /// Returns uint3.yyzz swizzling.
        /// </summary>
        public uint4 yyzz => new uint4(y, y, z, z);

        /// <summary>
        /// Returns uint3.ggbb swizzling (equivalent to uint3.yyzz).
        /// </summary>
        public uint4 ggbb => new uint4(y, y, z, z);

        /// <summary>
        /// Returns uint3.yz swizzling.
        /// </summary>
        public uint2 yz => new uint2(y, z);

        /// <summary>
        /// Returns uint3.gb swizzling (equivalent to uint3.yz).
        /// </summary>
        public uint2 gb => new uint2(y, z);

        /// <summary>
        /// Returns uint3.yzx swizzling.
        /// </summary>
        public uint3 yzx => new uint3(y, z, x);

        /// <summary>
        /// Returns uint3.gbr swizzling (equivalent to uint3.yzx).
        /// </summary>
        public uint3 gbr => new uint3(y, z, x);

        /// <summary>
        /// Returns uint3.yzxx swizzling.
        /// </summary>
        public uint4 yzxx => new uint4(y, z, x, x);

        /// <summary>
        /// Returns uint3.gbrr swizzling (equivalent to uint3.yzxx).
        /// </summary>
        public uint4 gbrr => new uint4(y, z, x, x);

        /// <summary>
        /// Returns uint3.yzxy swizzling.
        /// </summary>
        public uint4 yzxy => new uint4(y, z, x, y);

        /// <summary>
        /// Returns uint3.gbrg swizzling (equivalent to uint3.yzxy).
        /// </summary>
        public uint4 gbrg => new uint4(y, z, x, y);

        /// <summary>
        /// Returns uint3.yzxz swizzling.
        /// </summary>
        public uint4 yzxz => new uint4(y, z, x, z);

        /// <summary>
        /// Returns uint3.gbrb swizzling (equivalent to uint3.yzxz).
        /// </summary>
        public uint4 gbrb => new uint4(y, z, x, z);

        /// <summary>
        /// Returns uint3.yzy swizzling.
        /// </summary>
        public uint3 yzy => new uint3(y, z, y);

        /// <summary>
        /// Returns uint3.gbg swizzling (equivalent to uint3.yzy).
        /// </summary>
        public uint3 gbg => new uint3(y, z, y);

        /// <summary>
        /// Returns uint3.yzyx swizzling.
        /// </summary>
        public uint4 yzyx => new uint4(y, z, y, x);

        /// <summary>
        /// Returns uint3.gbgr swizzling (equivalent to uint3.yzyx).
        /// </summary>
        public uint4 gbgr => new uint4(y, z, y, x);

        /// <summary>
        /// Returns uint3.yzyy swizzling.
        /// </summary>
        public uint4 yzyy => new uint4(y, z, y, y);

        /// <summary>
        /// Returns uint3.gbgg swizzling (equivalent to uint3.yzyy).
        /// </summary>
        public uint4 gbgg => new uint4(y, z, y, y);

        /// <summary>
        /// Returns uint3.yzyz swizzling.
        /// </summary>
        public uint4 yzyz => new uint4(y, z, y, z);

        /// <summary>
        /// Returns uint3.gbgb swizzling (equivalent to uint3.yzyz).
        /// </summary>
        public uint4 gbgb => new uint4(y, z, y, z);

        /// <summary>
        /// Returns uint3.yzz swizzling.
        /// </summary>
        public uint3 yzz => new uint3(y, z, z);

        /// <summary>
        /// Returns uint3.gbb swizzling (equivalent to uint3.yzz).
        /// </summary>
        public uint3 gbb => new uint3(y, z, z);

        /// <summary>
        /// Returns uint3.yzzx swizzling.
        /// </summary>
        public uint4 yzzx => new uint4(y, z, z, x);

        /// <summary>
        /// Returns uint3.gbbr swizzling (equivalent to uint3.yzzx).
        /// </summary>
        public uint4 gbbr => new uint4(y, z, z, x);

        /// <summary>
        /// Returns uint3.yzzy swizzling.
        /// </summary>
        public uint4 yzzy => new uint4(y, z, z, y);

        /// <summary>
        /// Returns uint3.gbbg swizzling (equivalent to uint3.yzzy).
        /// </summary>
        public uint4 gbbg => new uint4(y, z, z, y);

        /// <summary>
        /// Returns uint3.yzzz swizzling.
        /// </summary>
        public uint4 yzzz => new uint4(y, z, z, z);

        /// <summary>
        /// Returns uint3.gbbb swizzling (equivalent to uint3.yzzz).
        /// </summary>
        public uint4 gbbb => new uint4(y, z, z, z);

        /// <summary>
        /// Returns uint3.zx swizzling.
        /// </summary>
        public uint2 zx => new uint2(z, x);

        /// <summary>
        /// Returns uint3.br swizzling (equivalent to uint3.zx).
        /// </summary>
        public uint2 br => new uint2(z, x);

        /// <summary>
        /// Returns uint3.zxx swizzling.
        /// </summary>
        public uint3 zxx => new uint3(z, x, x);

        /// <summary>
        /// Returns uint3.brr swizzling (equivalent to uint3.zxx).
        /// </summary>
        public uint3 brr => new uint3(z, x, x);

        /// <summary>
        /// Returns uint3.zxxx swizzling.
        /// </summary>
        public uint4 zxxx => new uint4(z, x, x, x);

        /// <summary>
        /// Returns uint3.brrr swizzling (equivalent to uint3.zxxx).
        /// </summary>
        public uint4 brrr => new uint4(z, x, x, x);

        /// <summary>
        /// Returns uint3.zxxy swizzling.
        /// </summary>
        public uint4 zxxy => new uint4(z, x, x, y);

        /// <summary>
        /// Returns uint3.brrg swizzling (equivalent to uint3.zxxy).
        /// </summary>
        public uint4 brrg => new uint4(z, x, x, y);

        /// <summary>
        /// Returns uint3.zxxz swizzling.
        /// </summary>
        public uint4 zxxz => new uint4(z, x, x, z);

        /// <summary>
        /// Returns uint3.brrb swizzling (equivalent to uint3.zxxz).
        /// </summary>
        public uint4 brrb => new uint4(z, x, x, z);

        /// <summary>
        /// Returns uint3.zxy swizzling.
        /// </summary>
        public uint3 zxy => new uint3(z, x, y);

        /// <summary>
        /// Returns uint3.brg swizzling (equivalent to uint3.zxy).
        /// </summary>
        public uint3 brg => new uint3(z, x, y);

        /// <summary>
        /// Returns uint3.zxyx swizzling.
        /// </summary>
        public uint4 zxyx => new uint4(z, x, y, x);

        /// <summary>
        /// Returns uint3.brgr swizzling (equivalent to uint3.zxyx).
        /// </summary>
        public uint4 brgr => new uint4(z, x, y, x);

        /// <summary>
        /// Returns uint3.zxyy swizzling.
        /// </summary>
        public uint4 zxyy => new uint4(z, x, y, y);

        /// <summary>
        /// Returns uint3.brgg swizzling (equivalent to uint3.zxyy).
        /// </summary>
        public uint4 brgg => new uint4(z, x, y, y);

        /// <summary>
        /// Returns uint3.zxyz swizzling.
        /// </summary>
        public uint4 zxyz => new uint4(z, x, y, z);

        /// <summary>
        /// Returns uint3.brgb swizzling (equivalent to uint3.zxyz).
        /// </summary>
        public uint4 brgb => new uint4(z, x, y, z);

        /// <summary>
        /// Returns uint3.zxz swizzling.
        /// </summary>
        public uint3 zxz => new uint3(z, x, z);

        /// <summary>
        /// Returns uint3.brb swizzling (equivalent to uint3.zxz).
        /// </summary>
        public uint3 brb => new uint3(z, x, z);

        /// <summary>
        /// Returns uint3.zxzx swizzling.
        /// </summary>
        public uint4 zxzx => new uint4(z, x, z, x);

        /// <summary>
        /// Returns uint3.brbr swizzling (equivalent to uint3.zxzx).
        /// </summary>
        public uint4 brbr => new uint4(z, x, z, x);

        /// <summary>
        /// Returns uint3.zxzy swizzling.
        /// </summary>
        public uint4 zxzy => new uint4(z, x, z, y);

        /// <summary>
        /// Returns uint3.brbg swizzling (equivalent to uint3.zxzy).
        /// </summary>
        public uint4 brbg => new uint4(z, x, z, y);

        /// <summary>
        /// Returns uint3.zxzz swizzling.
        /// </summary>
        public uint4 zxzz => new uint4(z, x, z, z);

        /// <summary>
        /// Returns uint3.brbb swizzling (equivalent to uint3.zxzz).
        /// </summary>
        public uint4 brbb => new uint4(z, x, z, z);

        /// <summary>
        /// Returns uint3.zy swizzling.
        /// </summary>
        public uint2 zy => new uint2(z, y);

        /// <summary>
        /// Returns uint3.bg swizzling (equivalent to uint3.zy).
        /// </summary>
        public uint2 bg => new uint2(z, y);

        /// <summary>
        /// Returns uint3.zyx swizzling.
        /// </summary>
        public uint3 zyx => new uint3(z, y, x);

        /// <summary>
        /// Returns uint3.bgr swizzling (equivalent to uint3.zyx).
        /// </summary>
        public uint3 bgr => new uint3(z, y, x);

        /// <summary>
        /// Returns uint3.zyxx swizzling.
        /// </summary>
        public uint4 zyxx => new uint4(z, y, x, x);

        /// <summary>
        /// Returns uint3.bgrr swizzling (equivalent to uint3.zyxx).
        /// </summary>
        public uint4 bgrr => new uint4(z, y, x, x);

        /// <summary>
        /// Returns uint3.zyxy swizzling.
        /// </summary>
        public uint4 zyxy => new uint4(z, y, x, y);

        /// <summary>
        /// Returns uint3.bgrg swizzling (equivalent to uint3.zyxy).
        /// </summary>
        public uint4 bgrg => new uint4(z, y, x, y);

        /// <summary>
        /// Returns uint3.zyxz swizzling.
        /// </summary>
        public uint4 zyxz => new uint4(z, y, x, z);

        /// <summary>
        /// Returns uint3.bgrb swizzling (equivalent to uint3.zyxz).
        /// </summary>
        public uint4 bgrb => new uint4(z, y, x, z);

        /// <summary>
        /// Returns uint3.zyy swizzling.
        /// </summary>
        public uint3 zyy => new uint3(z, y, y);

        /// <summary>
        /// Returns uint3.bgg swizzling (equivalent to uint3.zyy).
        /// </summary>
        public uint3 bgg => new uint3(z, y, y);

        /// <summary>
        /// Returns uint3.zyyx swizzling.
        /// </summary>
        public uint4 zyyx => new uint4(z, y, y, x);

        /// <summary>
        /// Returns uint3.bggr swizzling (equivalent to uint3.zyyx).
        /// </summary>
        public uint4 bggr => new uint4(z, y, y, x);

        /// <summary>
        /// Returns uint3.zyyy swizzling.
        /// </summary>
        public uint4 zyyy => new uint4(z, y, y, y);

        /// <summary>
        /// Returns uint3.bggg swizzling (equivalent to uint3.zyyy).
        /// </summary>
        public uint4 bggg => new uint4(z, y, y, y);

        /// <summary>
        /// Returns uint3.zyyz swizzling.
        /// </summary>
        public uint4 zyyz => new uint4(z, y, y, z);

        /// <summary>
        /// Returns uint3.bggb swizzling (equivalent to uint3.zyyz).
        /// </summary>
        public uint4 bggb => new uint4(z, y, y, z);

        /// <summary>
        /// Returns uint3.zyz swizzling.
        /// </summary>
        public uint3 zyz => new uint3(z, y, z);

        /// <summary>
        /// Returns uint3.bgb swizzling (equivalent to uint3.zyz).
        /// </summary>
        public uint3 bgb => new uint3(z, y, z);

        /// <summary>
        /// Returns uint3.zyzx swizzling.
        /// </summary>
        public uint4 zyzx => new uint4(z, y, z, x);

        /// <summary>
        /// Returns uint3.bgbr swizzling (equivalent to uint3.zyzx).
        /// </summary>
        public uint4 bgbr => new uint4(z, y, z, x);

        /// <summary>
        /// Returns uint3.zyzy swizzling.
        /// </summary>
        public uint4 zyzy => new uint4(z, y, z, y);

        /// <summary>
        /// Returns uint3.bgbg swizzling (equivalent to uint3.zyzy).
        /// </summary>
        public uint4 bgbg => new uint4(z, y, z, y);

        /// <summary>
        /// Returns uint3.zyzz swizzling.
        /// </summary>
        public uint4 zyzz => new uint4(z, y, z, z);

        /// <summary>
        /// Returns uint3.bgbb swizzling (equivalent to uint3.zyzz).
        /// </summary>
        public uint4 bgbb => new uint4(z, y, z, z);

        /// <summary>
        /// Returns uint3.zz swizzling.
        /// </summary>
        public uint2 zz => new uint2(z, z);

        /// <summary>
        /// Returns uint3.bb swizzling (equivalent to uint3.zz).
        /// </summary>
        public uint2 bb => new uint2(z, z);

        /// <summary>
        /// Returns uint3.zzx swizzling.
        /// </summary>
        public uint3 zzx => new uint3(z, z, x);

        /// <summary>
        /// Returns uint3.bbr swizzling (equivalent to uint3.zzx).
        /// </summary>
        public uint3 bbr => new uint3(z, z, x);

        /// <summary>
        /// Returns uint3.zzxx swizzling.
        /// </summary>
        public uint4 zzxx => new uint4(z, z, x, x);

        /// <summary>
        /// Returns uint3.bbrr swizzling (equivalent to uint3.zzxx).
        /// </summary>
        public uint4 bbrr => new uint4(z, z, x, x);

        /// <summary>
        /// Returns uint3.zzxy swizzling.
        /// </summary>
        public uint4 zzxy => new uint4(z, z, x, y);

        /// <summary>
        /// Returns uint3.bbrg swizzling (equivalent to uint3.zzxy).
        /// </summary>
        public uint4 bbrg => new uint4(z, z, x, y);

        /// <summary>
        /// Returns uint3.zzxz swizzling.
        /// </summary>
        public uint4 zzxz => new uint4(z, z, x, z);

        /// <summary>
        /// Returns uint3.bbrb swizzling (equivalent to uint3.zzxz).
        /// </summary>
        public uint4 bbrb => new uint4(z, z, x, z);

        /// <summary>
        /// Returns uint3.zzy swizzling.
        /// </summary>
        public uint3 zzy => new uint3(z, z, y);

        /// <summary>
        /// Returns uint3.bbg swizzling (equivalent to uint3.zzy).
        /// </summary>
        public uint3 bbg => new uint3(z, z, y);

        /// <summary>
        /// Returns uint3.zzyx swizzling.
        /// </summary>
        public uint4 zzyx => new uint4(z, z, y, x);

        /// <summary>
        /// Returns uint3.bbgr swizzling (equivalent to uint3.zzyx).
        /// </summary>
        public uint4 bbgr => new uint4(z, z, y, x);

        /// <summary>
        /// Returns uint3.zzyy swizzling.
        /// </summary>
        public uint4 zzyy => new uint4(z, z, y, y);

        /// <summary>
        /// Returns uint3.bbgg swizzling (equivalent to uint3.zzyy).
        /// </summary>
        public uint4 bbgg => new uint4(z, z, y, y);

        /// <summary>
        /// Returns uint3.zzyz swizzling.
        /// </summary>
        public uint4 zzyz => new uint4(z, z, y, z);

        /// <summary>
        /// Returns uint3.bbgb swizzling (equivalent to uint3.zzyz).
        /// </summary>
        public uint4 bbgb => new uint4(z, z, y, z);

        /// <summary>
        /// Returns uint3.zzz swizzling.
        /// </summary>
        public uint3 zzz => new uint3(z, z, z);

        /// <summary>
        /// Returns uint3.bbb swizzling (equivalent to uint3.zzz).
        /// </summary>
        public uint3 bbb => new uint3(z, z, z);

        /// <summary>
        /// Returns uint3.zzzx swizzling.
        /// </summary>
        public uint4 zzzx => new uint4(z, z, z, x);

        /// <summary>
        /// Returns uint3.bbbr swizzling (equivalent to uint3.zzzx).
        /// </summary>
        public uint4 bbbr => new uint4(z, z, z, x);

        /// <summary>
        /// Returns uint3.zzzy swizzling.
        /// </summary>
        public uint4 zzzy => new uint4(z, z, z, y);

        /// <summary>
        /// Returns uint3.bbbg swizzling (equivalent to uint3.zzzy).
        /// </summary>
        public uint4 bbbg => new uint4(z, z, z, y);

        /// <summary>
        /// Returns uint3.zzzz swizzling.
        /// </summary>
        public uint4 zzzz => new uint4(z, z, z, z);

        /// <summary>
        /// Returns uint3.bbbb swizzling (equivalent to uint3.zzzz).
        /// </summary>
        public uint4 bbbb => new uint4(z, z, z, z);

        #endregion

    }
}
