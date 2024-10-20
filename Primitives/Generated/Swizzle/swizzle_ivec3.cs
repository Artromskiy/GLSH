using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type int with 3 components, used for implementing swizzling for int3.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_ivec3
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        internal readonly int x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        internal readonly int y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        internal readonly int z;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_ivec3.
        /// </summary>
        internal swizzle_ivec3(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns int3.xx swizzling.
        /// </summary>
        public int2 xx => new int2(x, x);

        /// <summary>
        /// Returns int3.rr swizzling (equivalent to int3.xx).
        /// </summary>
        public int2 rr => new int2(x, x);

        /// <summary>
        /// Returns int3.xxx swizzling.
        /// </summary>
        public int3 xxx => new int3(x, x, x);

        /// <summary>
        /// Returns int3.rrr swizzling (equivalent to int3.xxx).
        /// </summary>
        public int3 rrr => new int3(x, x, x);

        /// <summary>
        /// Returns int3.xxxx swizzling.
        /// </summary>
        public int4 xxxx => new int4(x, x, x, x);

        /// <summary>
        /// Returns int3.rrrr swizzling (equivalent to int3.xxxx).
        /// </summary>
        public int4 rrrr => new int4(x, x, x, x);

        /// <summary>
        /// Returns int3.xxxy swizzling.
        /// </summary>
        public int4 xxxy => new int4(x, x, x, y);

        /// <summary>
        /// Returns int3.rrrg swizzling (equivalent to int3.xxxy).
        /// </summary>
        public int4 rrrg => new int4(x, x, x, y);

        /// <summary>
        /// Returns int3.xxxz swizzling.
        /// </summary>
        public int4 xxxz => new int4(x, x, x, z);

        /// <summary>
        /// Returns int3.rrrb swizzling (equivalent to int3.xxxz).
        /// </summary>
        public int4 rrrb => new int4(x, x, x, z);

        /// <summary>
        /// Returns int3.xxy swizzling.
        /// </summary>
        public int3 xxy => new int3(x, x, y);

        /// <summary>
        /// Returns int3.rrg swizzling (equivalent to int3.xxy).
        /// </summary>
        public int3 rrg => new int3(x, x, y);

        /// <summary>
        /// Returns int3.xxyx swizzling.
        /// </summary>
        public int4 xxyx => new int4(x, x, y, x);

        /// <summary>
        /// Returns int3.rrgr swizzling (equivalent to int3.xxyx).
        /// </summary>
        public int4 rrgr => new int4(x, x, y, x);

        /// <summary>
        /// Returns int3.xxyy swizzling.
        /// </summary>
        public int4 xxyy => new int4(x, x, y, y);

        /// <summary>
        /// Returns int3.rrgg swizzling (equivalent to int3.xxyy).
        /// </summary>
        public int4 rrgg => new int4(x, x, y, y);

        /// <summary>
        /// Returns int3.xxyz swizzling.
        /// </summary>
        public int4 xxyz => new int4(x, x, y, z);

        /// <summary>
        /// Returns int3.rrgb swizzling (equivalent to int3.xxyz).
        /// </summary>
        public int4 rrgb => new int4(x, x, y, z);

        /// <summary>
        /// Returns int3.xxz swizzling.
        /// </summary>
        public int3 xxz => new int3(x, x, z);

        /// <summary>
        /// Returns int3.rrb swizzling (equivalent to int3.xxz).
        /// </summary>
        public int3 rrb => new int3(x, x, z);

        /// <summary>
        /// Returns int3.xxzx swizzling.
        /// </summary>
        public int4 xxzx => new int4(x, x, z, x);

        /// <summary>
        /// Returns int3.rrbr swizzling (equivalent to int3.xxzx).
        /// </summary>
        public int4 rrbr => new int4(x, x, z, x);

        /// <summary>
        /// Returns int3.xxzy swizzling.
        /// </summary>
        public int4 xxzy => new int4(x, x, z, y);

        /// <summary>
        /// Returns int3.rrbg swizzling (equivalent to int3.xxzy).
        /// </summary>
        public int4 rrbg => new int4(x, x, z, y);

        /// <summary>
        /// Returns int3.xxzz swizzling.
        /// </summary>
        public int4 xxzz => new int4(x, x, z, z);

        /// <summary>
        /// Returns int3.rrbb swizzling (equivalent to int3.xxzz).
        /// </summary>
        public int4 rrbb => new int4(x, x, z, z);

        /// <summary>
        /// Returns int3.xy swizzling.
        /// </summary>
        public int2 xy => new int2(x, y);

        /// <summary>
        /// Returns int3.rg swizzling (equivalent to int3.xy).
        /// </summary>
        public int2 rg => new int2(x, y);

        /// <summary>
        /// Returns int3.xyx swizzling.
        /// </summary>
        public int3 xyx => new int3(x, y, x);

        /// <summary>
        /// Returns int3.rgr swizzling (equivalent to int3.xyx).
        /// </summary>
        public int3 rgr => new int3(x, y, x);

        /// <summary>
        /// Returns int3.xyxx swizzling.
        /// </summary>
        public int4 xyxx => new int4(x, y, x, x);

        /// <summary>
        /// Returns int3.rgrr swizzling (equivalent to int3.xyxx).
        /// </summary>
        public int4 rgrr => new int4(x, y, x, x);

        /// <summary>
        /// Returns int3.xyxy swizzling.
        /// </summary>
        public int4 xyxy => new int4(x, y, x, y);

        /// <summary>
        /// Returns int3.rgrg swizzling (equivalent to int3.xyxy).
        /// </summary>
        public int4 rgrg => new int4(x, y, x, y);

        /// <summary>
        /// Returns int3.xyxz swizzling.
        /// </summary>
        public int4 xyxz => new int4(x, y, x, z);

        /// <summary>
        /// Returns int3.rgrb swizzling (equivalent to int3.xyxz).
        /// </summary>
        public int4 rgrb => new int4(x, y, x, z);

        /// <summary>
        /// Returns int3.xyy swizzling.
        /// </summary>
        public int3 xyy => new int3(x, y, y);

        /// <summary>
        /// Returns int3.rgg swizzling (equivalent to int3.xyy).
        /// </summary>
        public int3 rgg => new int3(x, y, y);

        /// <summary>
        /// Returns int3.xyyx swizzling.
        /// </summary>
        public int4 xyyx => new int4(x, y, y, x);

        /// <summary>
        /// Returns int3.rggr swizzling (equivalent to int3.xyyx).
        /// </summary>
        public int4 rggr => new int4(x, y, y, x);

        /// <summary>
        /// Returns int3.xyyy swizzling.
        /// </summary>
        public int4 xyyy => new int4(x, y, y, y);

        /// <summary>
        /// Returns int3.rggg swizzling (equivalent to int3.xyyy).
        /// </summary>
        public int4 rggg => new int4(x, y, y, y);

        /// <summary>
        /// Returns int3.xyyz swizzling.
        /// </summary>
        public int4 xyyz => new int4(x, y, y, z);

        /// <summary>
        /// Returns int3.rggb swizzling (equivalent to int3.xyyz).
        /// </summary>
        public int4 rggb => new int4(x, y, y, z);

        /// <summary>
        /// Returns int3.xyz swizzling.
        /// </summary>
        public int3 xyz => new int3(x, y, z);

        /// <summary>
        /// Returns int3.rgb swizzling (equivalent to int3.xyz).
        /// </summary>
        public int3 rgb => new int3(x, y, z);

        /// <summary>
        /// Returns int3.xyzx swizzling.
        /// </summary>
        public int4 xyzx => new int4(x, y, z, x);

        /// <summary>
        /// Returns int3.rgbr swizzling (equivalent to int3.xyzx).
        /// </summary>
        public int4 rgbr => new int4(x, y, z, x);

        /// <summary>
        /// Returns int3.xyzy swizzling.
        /// </summary>
        public int4 xyzy => new int4(x, y, z, y);

        /// <summary>
        /// Returns int3.rgbg swizzling (equivalent to int3.xyzy).
        /// </summary>
        public int4 rgbg => new int4(x, y, z, y);

        /// <summary>
        /// Returns int3.xyzz swizzling.
        /// </summary>
        public int4 xyzz => new int4(x, y, z, z);

        /// <summary>
        /// Returns int3.rgbb swizzling (equivalent to int3.xyzz).
        /// </summary>
        public int4 rgbb => new int4(x, y, z, z);

        /// <summary>
        /// Returns int3.xz swizzling.
        /// </summary>
        public int2 xz => new int2(x, z);

        /// <summary>
        /// Returns int3.rb swizzling (equivalent to int3.xz).
        /// </summary>
        public int2 rb => new int2(x, z);

        /// <summary>
        /// Returns int3.xzx swizzling.
        /// </summary>
        public int3 xzx => new int3(x, z, x);

        /// <summary>
        /// Returns int3.rbr swizzling (equivalent to int3.xzx).
        /// </summary>
        public int3 rbr => new int3(x, z, x);

        /// <summary>
        /// Returns int3.xzxx swizzling.
        /// </summary>
        public int4 xzxx => new int4(x, z, x, x);

        /// <summary>
        /// Returns int3.rbrr swizzling (equivalent to int3.xzxx).
        /// </summary>
        public int4 rbrr => new int4(x, z, x, x);

        /// <summary>
        /// Returns int3.xzxy swizzling.
        /// </summary>
        public int4 xzxy => new int4(x, z, x, y);

        /// <summary>
        /// Returns int3.rbrg swizzling (equivalent to int3.xzxy).
        /// </summary>
        public int4 rbrg => new int4(x, z, x, y);

        /// <summary>
        /// Returns int3.xzxz swizzling.
        /// </summary>
        public int4 xzxz => new int4(x, z, x, z);

        /// <summary>
        /// Returns int3.rbrb swizzling (equivalent to int3.xzxz).
        /// </summary>
        public int4 rbrb => new int4(x, z, x, z);

        /// <summary>
        /// Returns int3.xzy swizzling.
        /// </summary>
        public int3 xzy => new int3(x, z, y);

        /// <summary>
        /// Returns int3.rbg swizzling (equivalent to int3.xzy).
        /// </summary>
        public int3 rbg => new int3(x, z, y);

        /// <summary>
        /// Returns int3.xzyx swizzling.
        /// </summary>
        public int4 xzyx => new int4(x, z, y, x);

        /// <summary>
        /// Returns int3.rbgr swizzling (equivalent to int3.xzyx).
        /// </summary>
        public int4 rbgr => new int4(x, z, y, x);

        /// <summary>
        /// Returns int3.xzyy swizzling.
        /// </summary>
        public int4 xzyy => new int4(x, z, y, y);

        /// <summary>
        /// Returns int3.rbgg swizzling (equivalent to int3.xzyy).
        /// </summary>
        public int4 rbgg => new int4(x, z, y, y);

        /// <summary>
        /// Returns int3.xzyz swizzling.
        /// </summary>
        public int4 xzyz => new int4(x, z, y, z);

        /// <summary>
        /// Returns int3.rbgb swizzling (equivalent to int3.xzyz).
        /// </summary>
        public int4 rbgb => new int4(x, z, y, z);

        /// <summary>
        /// Returns int3.xzz swizzling.
        /// </summary>
        public int3 xzz => new int3(x, z, z);

        /// <summary>
        /// Returns int3.rbb swizzling (equivalent to int3.xzz).
        /// </summary>
        public int3 rbb => new int3(x, z, z);

        /// <summary>
        /// Returns int3.xzzx swizzling.
        /// </summary>
        public int4 xzzx => new int4(x, z, z, x);

        /// <summary>
        /// Returns int3.rbbr swizzling (equivalent to int3.xzzx).
        /// </summary>
        public int4 rbbr => new int4(x, z, z, x);

        /// <summary>
        /// Returns int3.xzzy swizzling.
        /// </summary>
        public int4 xzzy => new int4(x, z, z, y);

        /// <summary>
        /// Returns int3.rbbg swizzling (equivalent to int3.xzzy).
        /// </summary>
        public int4 rbbg => new int4(x, z, z, y);

        /// <summary>
        /// Returns int3.xzzz swizzling.
        /// </summary>
        public int4 xzzz => new int4(x, z, z, z);

        /// <summary>
        /// Returns int3.rbbb swizzling (equivalent to int3.xzzz).
        /// </summary>
        public int4 rbbb => new int4(x, z, z, z);

        /// <summary>
        /// Returns int3.yx swizzling.
        /// </summary>
        public int2 yx => new int2(y, x);

        /// <summary>
        /// Returns int3.gr swizzling (equivalent to int3.yx).
        /// </summary>
        public int2 gr => new int2(y, x);

        /// <summary>
        /// Returns int3.yxx swizzling.
        /// </summary>
        public int3 yxx => new int3(y, x, x);

        /// <summary>
        /// Returns int3.grr swizzling (equivalent to int3.yxx).
        /// </summary>
        public int3 grr => new int3(y, x, x);

        /// <summary>
        /// Returns int3.yxxx swizzling.
        /// </summary>
        public int4 yxxx => new int4(y, x, x, x);

        /// <summary>
        /// Returns int3.grrr swizzling (equivalent to int3.yxxx).
        /// </summary>
        public int4 grrr => new int4(y, x, x, x);

        /// <summary>
        /// Returns int3.yxxy swizzling.
        /// </summary>
        public int4 yxxy => new int4(y, x, x, y);

        /// <summary>
        /// Returns int3.grrg swizzling (equivalent to int3.yxxy).
        /// </summary>
        public int4 grrg => new int4(y, x, x, y);

        /// <summary>
        /// Returns int3.yxxz swizzling.
        /// </summary>
        public int4 yxxz => new int4(y, x, x, z);

        /// <summary>
        /// Returns int3.grrb swizzling (equivalent to int3.yxxz).
        /// </summary>
        public int4 grrb => new int4(y, x, x, z);

        /// <summary>
        /// Returns int3.yxy swizzling.
        /// </summary>
        public int3 yxy => new int3(y, x, y);

        /// <summary>
        /// Returns int3.grg swizzling (equivalent to int3.yxy).
        /// </summary>
        public int3 grg => new int3(y, x, y);

        /// <summary>
        /// Returns int3.yxyx swizzling.
        /// </summary>
        public int4 yxyx => new int4(y, x, y, x);

        /// <summary>
        /// Returns int3.grgr swizzling (equivalent to int3.yxyx).
        /// </summary>
        public int4 grgr => new int4(y, x, y, x);

        /// <summary>
        /// Returns int3.yxyy swizzling.
        /// </summary>
        public int4 yxyy => new int4(y, x, y, y);

        /// <summary>
        /// Returns int3.grgg swizzling (equivalent to int3.yxyy).
        /// </summary>
        public int4 grgg => new int4(y, x, y, y);

        /// <summary>
        /// Returns int3.yxyz swizzling.
        /// </summary>
        public int4 yxyz => new int4(y, x, y, z);

        /// <summary>
        /// Returns int3.grgb swizzling (equivalent to int3.yxyz).
        /// </summary>
        public int4 grgb => new int4(y, x, y, z);

        /// <summary>
        /// Returns int3.yxz swizzling.
        /// </summary>
        public int3 yxz => new int3(y, x, z);

        /// <summary>
        /// Returns int3.grb swizzling (equivalent to int3.yxz).
        /// </summary>
        public int3 grb => new int3(y, x, z);

        /// <summary>
        /// Returns int3.yxzx swizzling.
        /// </summary>
        public int4 yxzx => new int4(y, x, z, x);

        /// <summary>
        /// Returns int3.grbr swizzling (equivalent to int3.yxzx).
        /// </summary>
        public int4 grbr => new int4(y, x, z, x);

        /// <summary>
        /// Returns int3.yxzy swizzling.
        /// </summary>
        public int4 yxzy => new int4(y, x, z, y);

        /// <summary>
        /// Returns int3.grbg swizzling (equivalent to int3.yxzy).
        /// </summary>
        public int4 grbg => new int4(y, x, z, y);

        /// <summary>
        /// Returns int3.yxzz swizzling.
        /// </summary>
        public int4 yxzz => new int4(y, x, z, z);

        /// <summary>
        /// Returns int3.grbb swizzling (equivalent to int3.yxzz).
        /// </summary>
        public int4 grbb => new int4(y, x, z, z);

        /// <summary>
        /// Returns int3.yy swizzling.
        /// </summary>
        public int2 yy => new int2(y, y);

        /// <summary>
        /// Returns int3.gg swizzling (equivalent to int3.yy).
        /// </summary>
        public int2 gg => new int2(y, y);

        /// <summary>
        /// Returns int3.yyx swizzling.
        /// </summary>
        public int3 yyx => new int3(y, y, x);

        /// <summary>
        /// Returns int3.ggr swizzling (equivalent to int3.yyx).
        /// </summary>
        public int3 ggr => new int3(y, y, x);

        /// <summary>
        /// Returns int3.yyxx swizzling.
        /// </summary>
        public int4 yyxx => new int4(y, y, x, x);

        /// <summary>
        /// Returns int3.ggrr swizzling (equivalent to int3.yyxx).
        /// </summary>
        public int4 ggrr => new int4(y, y, x, x);

        /// <summary>
        /// Returns int3.yyxy swizzling.
        /// </summary>
        public int4 yyxy => new int4(y, y, x, y);

        /// <summary>
        /// Returns int3.ggrg swizzling (equivalent to int3.yyxy).
        /// </summary>
        public int4 ggrg => new int4(y, y, x, y);

        /// <summary>
        /// Returns int3.yyxz swizzling.
        /// </summary>
        public int4 yyxz => new int4(y, y, x, z);

        /// <summary>
        /// Returns int3.ggrb swizzling (equivalent to int3.yyxz).
        /// </summary>
        public int4 ggrb => new int4(y, y, x, z);

        /// <summary>
        /// Returns int3.yyy swizzling.
        /// </summary>
        public int3 yyy => new int3(y, y, y);

        /// <summary>
        /// Returns int3.ggg swizzling (equivalent to int3.yyy).
        /// </summary>
        public int3 ggg => new int3(y, y, y);

        /// <summary>
        /// Returns int3.yyyx swizzling.
        /// </summary>
        public int4 yyyx => new int4(y, y, y, x);

        /// <summary>
        /// Returns int3.gggr swizzling (equivalent to int3.yyyx).
        /// </summary>
        public int4 gggr => new int4(y, y, y, x);

        /// <summary>
        /// Returns int3.yyyy swizzling.
        /// </summary>
        public int4 yyyy => new int4(y, y, y, y);

        /// <summary>
        /// Returns int3.gggg swizzling (equivalent to int3.yyyy).
        /// </summary>
        public int4 gggg => new int4(y, y, y, y);

        /// <summary>
        /// Returns int3.yyyz swizzling.
        /// </summary>
        public int4 yyyz => new int4(y, y, y, z);

        /// <summary>
        /// Returns int3.gggb swizzling (equivalent to int3.yyyz).
        /// </summary>
        public int4 gggb => new int4(y, y, y, z);

        /// <summary>
        /// Returns int3.yyz swizzling.
        /// </summary>
        public int3 yyz => new int3(y, y, z);

        /// <summary>
        /// Returns int3.ggb swizzling (equivalent to int3.yyz).
        /// </summary>
        public int3 ggb => new int3(y, y, z);

        /// <summary>
        /// Returns int3.yyzx swizzling.
        /// </summary>
        public int4 yyzx => new int4(y, y, z, x);

        /// <summary>
        /// Returns int3.ggbr swizzling (equivalent to int3.yyzx).
        /// </summary>
        public int4 ggbr => new int4(y, y, z, x);

        /// <summary>
        /// Returns int3.yyzy swizzling.
        /// </summary>
        public int4 yyzy => new int4(y, y, z, y);

        /// <summary>
        /// Returns int3.ggbg swizzling (equivalent to int3.yyzy).
        /// </summary>
        public int4 ggbg => new int4(y, y, z, y);

        /// <summary>
        /// Returns int3.yyzz swizzling.
        /// </summary>
        public int4 yyzz => new int4(y, y, z, z);

        /// <summary>
        /// Returns int3.ggbb swizzling (equivalent to int3.yyzz).
        /// </summary>
        public int4 ggbb => new int4(y, y, z, z);

        /// <summary>
        /// Returns int3.yz swizzling.
        /// </summary>
        public int2 yz => new int2(y, z);

        /// <summary>
        /// Returns int3.gb swizzling (equivalent to int3.yz).
        /// </summary>
        public int2 gb => new int2(y, z);

        /// <summary>
        /// Returns int3.yzx swizzling.
        /// </summary>
        public int3 yzx => new int3(y, z, x);

        /// <summary>
        /// Returns int3.gbr swizzling (equivalent to int3.yzx).
        /// </summary>
        public int3 gbr => new int3(y, z, x);

        /// <summary>
        /// Returns int3.yzxx swizzling.
        /// </summary>
        public int4 yzxx => new int4(y, z, x, x);

        /// <summary>
        /// Returns int3.gbrr swizzling (equivalent to int3.yzxx).
        /// </summary>
        public int4 gbrr => new int4(y, z, x, x);

        /// <summary>
        /// Returns int3.yzxy swizzling.
        /// </summary>
        public int4 yzxy => new int4(y, z, x, y);

        /// <summary>
        /// Returns int3.gbrg swizzling (equivalent to int3.yzxy).
        /// </summary>
        public int4 gbrg => new int4(y, z, x, y);

        /// <summary>
        /// Returns int3.yzxz swizzling.
        /// </summary>
        public int4 yzxz => new int4(y, z, x, z);

        /// <summary>
        /// Returns int3.gbrb swizzling (equivalent to int3.yzxz).
        /// </summary>
        public int4 gbrb => new int4(y, z, x, z);

        /// <summary>
        /// Returns int3.yzy swizzling.
        /// </summary>
        public int3 yzy => new int3(y, z, y);

        /// <summary>
        /// Returns int3.gbg swizzling (equivalent to int3.yzy).
        /// </summary>
        public int3 gbg => new int3(y, z, y);

        /// <summary>
        /// Returns int3.yzyx swizzling.
        /// </summary>
        public int4 yzyx => new int4(y, z, y, x);

        /// <summary>
        /// Returns int3.gbgr swizzling (equivalent to int3.yzyx).
        /// </summary>
        public int4 gbgr => new int4(y, z, y, x);

        /// <summary>
        /// Returns int3.yzyy swizzling.
        /// </summary>
        public int4 yzyy => new int4(y, z, y, y);

        /// <summary>
        /// Returns int3.gbgg swizzling (equivalent to int3.yzyy).
        /// </summary>
        public int4 gbgg => new int4(y, z, y, y);

        /// <summary>
        /// Returns int3.yzyz swizzling.
        /// </summary>
        public int4 yzyz => new int4(y, z, y, z);

        /// <summary>
        /// Returns int3.gbgb swizzling (equivalent to int3.yzyz).
        /// </summary>
        public int4 gbgb => new int4(y, z, y, z);

        /// <summary>
        /// Returns int3.yzz swizzling.
        /// </summary>
        public int3 yzz => new int3(y, z, z);

        /// <summary>
        /// Returns int3.gbb swizzling (equivalent to int3.yzz).
        /// </summary>
        public int3 gbb => new int3(y, z, z);

        /// <summary>
        /// Returns int3.yzzx swizzling.
        /// </summary>
        public int4 yzzx => new int4(y, z, z, x);

        /// <summary>
        /// Returns int3.gbbr swizzling (equivalent to int3.yzzx).
        /// </summary>
        public int4 gbbr => new int4(y, z, z, x);

        /// <summary>
        /// Returns int3.yzzy swizzling.
        /// </summary>
        public int4 yzzy => new int4(y, z, z, y);

        /// <summary>
        /// Returns int3.gbbg swizzling (equivalent to int3.yzzy).
        /// </summary>
        public int4 gbbg => new int4(y, z, z, y);

        /// <summary>
        /// Returns int3.yzzz swizzling.
        /// </summary>
        public int4 yzzz => new int4(y, z, z, z);

        /// <summary>
        /// Returns int3.gbbb swizzling (equivalent to int3.yzzz).
        /// </summary>
        public int4 gbbb => new int4(y, z, z, z);

        /// <summary>
        /// Returns int3.zx swizzling.
        /// </summary>
        public int2 zx => new int2(z, x);

        /// <summary>
        /// Returns int3.br swizzling (equivalent to int3.zx).
        /// </summary>
        public int2 br => new int2(z, x);

        /// <summary>
        /// Returns int3.zxx swizzling.
        /// </summary>
        public int3 zxx => new int3(z, x, x);

        /// <summary>
        /// Returns int3.brr swizzling (equivalent to int3.zxx).
        /// </summary>
        public int3 brr => new int3(z, x, x);

        /// <summary>
        /// Returns int3.zxxx swizzling.
        /// </summary>
        public int4 zxxx => new int4(z, x, x, x);

        /// <summary>
        /// Returns int3.brrr swizzling (equivalent to int3.zxxx).
        /// </summary>
        public int4 brrr => new int4(z, x, x, x);

        /// <summary>
        /// Returns int3.zxxy swizzling.
        /// </summary>
        public int4 zxxy => new int4(z, x, x, y);

        /// <summary>
        /// Returns int3.brrg swizzling (equivalent to int3.zxxy).
        /// </summary>
        public int4 brrg => new int4(z, x, x, y);

        /// <summary>
        /// Returns int3.zxxz swizzling.
        /// </summary>
        public int4 zxxz => new int4(z, x, x, z);

        /// <summary>
        /// Returns int3.brrb swizzling (equivalent to int3.zxxz).
        /// </summary>
        public int4 brrb => new int4(z, x, x, z);

        /// <summary>
        /// Returns int3.zxy swizzling.
        /// </summary>
        public int3 zxy => new int3(z, x, y);

        /// <summary>
        /// Returns int3.brg swizzling (equivalent to int3.zxy).
        /// </summary>
        public int3 brg => new int3(z, x, y);

        /// <summary>
        /// Returns int3.zxyx swizzling.
        /// </summary>
        public int4 zxyx => new int4(z, x, y, x);

        /// <summary>
        /// Returns int3.brgr swizzling (equivalent to int3.zxyx).
        /// </summary>
        public int4 brgr => new int4(z, x, y, x);

        /// <summary>
        /// Returns int3.zxyy swizzling.
        /// </summary>
        public int4 zxyy => new int4(z, x, y, y);

        /// <summary>
        /// Returns int3.brgg swizzling (equivalent to int3.zxyy).
        /// </summary>
        public int4 brgg => new int4(z, x, y, y);

        /// <summary>
        /// Returns int3.zxyz swizzling.
        /// </summary>
        public int4 zxyz => new int4(z, x, y, z);

        /// <summary>
        /// Returns int3.brgb swizzling (equivalent to int3.zxyz).
        /// </summary>
        public int4 brgb => new int4(z, x, y, z);

        /// <summary>
        /// Returns int3.zxz swizzling.
        /// </summary>
        public int3 zxz => new int3(z, x, z);

        /// <summary>
        /// Returns int3.brb swizzling (equivalent to int3.zxz).
        /// </summary>
        public int3 brb => new int3(z, x, z);

        /// <summary>
        /// Returns int3.zxzx swizzling.
        /// </summary>
        public int4 zxzx => new int4(z, x, z, x);

        /// <summary>
        /// Returns int3.brbr swizzling (equivalent to int3.zxzx).
        /// </summary>
        public int4 brbr => new int4(z, x, z, x);

        /// <summary>
        /// Returns int3.zxzy swizzling.
        /// </summary>
        public int4 zxzy => new int4(z, x, z, y);

        /// <summary>
        /// Returns int3.brbg swizzling (equivalent to int3.zxzy).
        /// </summary>
        public int4 brbg => new int4(z, x, z, y);

        /// <summary>
        /// Returns int3.zxzz swizzling.
        /// </summary>
        public int4 zxzz => new int4(z, x, z, z);

        /// <summary>
        /// Returns int3.brbb swizzling (equivalent to int3.zxzz).
        /// </summary>
        public int4 brbb => new int4(z, x, z, z);

        /// <summary>
        /// Returns int3.zy swizzling.
        /// </summary>
        public int2 zy => new int2(z, y);

        /// <summary>
        /// Returns int3.bg swizzling (equivalent to int3.zy).
        /// </summary>
        public int2 bg => new int2(z, y);

        /// <summary>
        /// Returns int3.zyx swizzling.
        /// </summary>
        public int3 zyx => new int3(z, y, x);

        /// <summary>
        /// Returns int3.bgr swizzling (equivalent to int3.zyx).
        /// </summary>
        public int3 bgr => new int3(z, y, x);

        /// <summary>
        /// Returns int3.zyxx swizzling.
        /// </summary>
        public int4 zyxx => new int4(z, y, x, x);

        /// <summary>
        /// Returns int3.bgrr swizzling (equivalent to int3.zyxx).
        /// </summary>
        public int4 bgrr => new int4(z, y, x, x);

        /// <summary>
        /// Returns int3.zyxy swizzling.
        /// </summary>
        public int4 zyxy => new int4(z, y, x, y);

        /// <summary>
        /// Returns int3.bgrg swizzling (equivalent to int3.zyxy).
        /// </summary>
        public int4 bgrg => new int4(z, y, x, y);

        /// <summary>
        /// Returns int3.zyxz swizzling.
        /// </summary>
        public int4 zyxz => new int4(z, y, x, z);

        /// <summary>
        /// Returns int3.bgrb swizzling (equivalent to int3.zyxz).
        /// </summary>
        public int4 bgrb => new int4(z, y, x, z);

        /// <summary>
        /// Returns int3.zyy swizzling.
        /// </summary>
        public int3 zyy => new int3(z, y, y);

        /// <summary>
        /// Returns int3.bgg swizzling (equivalent to int3.zyy).
        /// </summary>
        public int3 bgg => new int3(z, y, y);

        /// <summary>
        /// Returns int3.zyyx swizzling.
        /// </summary>
        public int4 zyyx => new int4(z, y, y, x);

        /// <summary>
        /// Returns int3.bggr swizzling (equivalent to int3.zyyx).
        /// </summary>
        public int4 bggr => new int4(z, y, y, x);

        /// <summary>
        /// Returns int3.zyyy swizzling.
        /// </summary>
        public int4 zyyy => new int4(z, y, y, y);

        /// <summary>
        /// Returns int3.bggg swizzling (equivalent to int3.zyyy).
        /// </summary>
        public int4 bggg => new int4(z, y, y, y);

        /// <summary>
        /// Returns int3.zyyz swizzling.
        /// </summary>
        public int4 zyyz => new int4(z, y, y, z);

        /// <summary>
        /// Returns int3.bggb swizzling (equivalent to int3.zyyz).
        /// </summary>
        public int4 bggb => new int4(z, y, y, z);

        /// <summary>
        /// Returns int3.zyz swizzling.
        /// </summary>
        public int3 zyz => new int3(z, y, z);

        /// <summary>
        /// Returns int3.bgb swizzling (equivalent to int3.zyz).
        /// </summary>
        public int3 bgb => new int3(z, y, z);

        /// <summary>
        /// Returns int3.zyzx swizzling.
        /// </summary>
        public int4 zyzx => new int4(z, y, z, x);

        /// <summary>
        /// Returns int3.bgbr swizzling (equivalent to int3.zyzx).
        /// </summary>
        public int4 bgbr => new int4(z, y, z, x);

        /// <summary>
        /// Returns int3.zyzy swizzling.
        /// </summary>
        public int4 zyzy => new int4(z, y, z, y);

        /// <summary>
        /// Returns int3.bgbg swizzling (equivalent to int3.zyzy).
        /// </summary>
        public int4 bgbg => new int4(z, y, z, y);

        /// <summary>
        /// Returns int3.zyzz swizzling.
        /// </summary>
        public int4 zyzz => new int4(z, y, z, z);

        /// <summary>
        /// Returns int3.bgbb swizzling (equivalent to int3.zyzz).
        /// </summary>
        public int4 bgbb => new int4(z, y, z, z);

        /// <summary>
        /// Returns int3.zz swizzling.
        /// </summary>
        public int2 zz => new int2(z, z);

        /// <summary>
        /// Returns int3.bb swizzling (equivalent to int3.zz).
        /// </summary>
        public int2 bb => new int2(z, z);

        /// <summary>
        /// Returns int3.zzx swizzling.
        /// </summary>
        public int3 zzx => new int3(z, z, x);

        /// <summary>
        /// Returns int3.bbr swizzling (equivalent to int3.zzx).
        /// </summary>
        public int3 bbr => new int3(z, z, x);

        /// <summary>
        /// Returns int3.zzxx swizzling.
        /// </summary>
        public int4 zzxx => new int4(z, z, x, x);

        /// <summary>
        /// Returns int3.bbrr swizzling (equivalent to int3.zzxx).
        /// </summary>
        public int4 bbrr => new int4(z, z, x, x);

        /// <summary>
        /// Returns int3.zzxy swizzling.
        /// </summary>
        public int4 zzxy => new int4(z, z, x, y);

        /// <summary>
        /// Returns int3.bbrg swizzling (equivalent to int3.zzxy).
        /// </summary>
        public int4 bbrg => new int4(z, z, x, y);

        /// <summary>
        /// Returns int3.zzxz swizzling.
        /// </summary>
        public int4 zzxz => new int4(z, z, x, z);

        /// <summary>
        /// Returns int3.bbrb swizzling (equivalent to int3.zzxz).
        /// </summary>
        public int4 bbrb => new int4(z, z, x, z);

        /// <summary>
        /// Returns int3.zzy swizzling.
        /// </summary>
        public int3 zzy => new int3(z, z, y);

        /// <summary>
        /// Returns int3.bbg swizzling (equivalent to int3.zzy).
        /// </summary>
        public int3 bbg => new int3(z, z, y);

        /// <summary>
        /// Returns int3.zzyx swizzling.
        /// </summary>
        public int4 zzyx => new int4(z, z, y, x);

        /// <summary>
        /// Returns int3.bbgr swizzling (equivalent to int3.zzyx).
        /// </summary>
        public int4 bbgr => new int4(z, z, y, x);

        /// <summary>
        /// Returns int3.zzyy swizzling.
        /// </summary>
        public int4 zzyy => new int4(z, z, y, y);

        /// <summary>
        /// Returns int3.bbgg swizzling (equivalent to int3.zzyy).
        /// </summary>
        public int4 bbgg => new int4(z, z, y, y);

        /// <summary>
        /// Returns int3.zzyz swizzling.
        /// </summary>
        public int4 zzyz => new int4(z, z, y, z);

        /// <summary>
        /// Returns int3.bbgb swizzling (equivalent to int3.zzyz).
        /// </summary>
        public int4 bbgb => new int4(z, z, y, z);

        /// <summary>
        /// Returns int3.zzz swizzling.
        /// </summary>
        public int3 zzz => new int3(z, z, z);

        /// <summary>
        /// Returns int3.bbb swizzling (equivalent to int3.zzz).
        /// </summary>
        public int3 bbb => new int3(z, z, z);

        /// <summary>
        /// Returns int3.zzzx swizzling.
        /// </summary>
        public int4 zzzx => new int4(z, z, z, x);

        /// <summary>
        /// Returns int3.bbbr swizzling (equivalent to int3.zzzx).
        /// </summary>
        public int4 bbbr => new int4(z, z, z, x);

        /// <summary>
        /// Returns int3.zzzy swizzling.
        /// </summary>
        public int4 zzzy => new int4(z, z, z, y);

        /// <summary>
        /// Returns int3.bbbg swizzling (equivalent to int3.zzzy).
        /// </summary>
        public int4 bbbg => new int4(z, z, z, y);

        /// <summary>
        /// Returns int3.zzzz swizzling.
        /// </summary>
        public int4 zzzz => new int4(z, z, z, z);

        /// <summary>
        /// Returns int3.bbbb swizzling (equivalent to int3.zzzz).
        /// </summary>
        public int4 bbbb => new int4(z, z, z, z);

        #endregion

    }
}
