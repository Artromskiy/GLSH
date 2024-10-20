using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type bool with 3 components, used for implementing swizzling for bool3.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_bvec3
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        internal readonly bool x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        internal readonly bool y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        internal readonly bool z;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_bvec3.
        /// </summary>
        internal swizzle_bvec3(bool x, bool y, bool z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns bool3.xx swizzling.
        /// </summary>
        public bool2 xx => new bool2(x, x);

        /// <summary>
        /// Returns bool3.rr swizzling (equivalent to bool3.xx).
        /// </summary>
        public bool2 rr => new bool2(x, x);

        /// <summary>
        /// Returns bool3.xxx swizzling.
        /// </summary>
        public bool3 xxx => new bool3(x, x, x);

        /// <summary>
        /// Returns bool3.rrr swizzling (equivalent to bool3.xxx).
        /// </summary>
        public bool3 rrr => new bool3(x, x, x);

        /// <summary>
        /// Returns bool3.xxxx swizzling.
        /// </summary>
        public bool4 xxxx => new bool4(x, x, x, x);

        /// <summary>
        /// Returns bool3.rrrr swizzling (equivalent to bool3.xxxx).
        /// </summary>
        public bool4 rrrr => new bool4(x, x, x, x);

        /// <summary>
        /// Returns bool3.xxxy swizzling.
        /// </summary>
        public bool4 xxxy => new bool4(x, x, x, y);

        /// <summary>
        /// Returns bool3.rrrg swizzling (equivalent to bool3.xxxy).
        /// </summary>
        public bool4 rrrg => new bool4(x, x, x, y);

        /// <summary>
        /// Returns bool3.xxxz swizzling.
        /// </summary>
        public bool4 xxxz => new bool4(x, x, x, z);

        /// <summary>
        /// Returns bool3.rrrb swizzling (equivalent to bool3.xxxz).
        /// </summary>
        public bool4 rrrb => new bool4(x, x, x, z);

        /// <summary>
        /// Returns bool3.xxy swizzling.
        /// </summary>
        public bool3 xxy => new bool3(x, x, y);

        /// <summary>
        /// Returns bool3.rrg swizzling (equivalent to bool3.xxy).
        /// </summary>
        public bool3 rrg => new bool3(x, x, y);

        /// <summary>
        /// Returns bool3.xxyx swizzling.
        /// </summary>
        public bool4 xxyx => new bool4(x, x, y, x);

        /// <summary>
        /// Returns bool3.rrgr swizzling (equivalent to bool3.xxyx).
        /// </summary>
        public bool4 rrgr => new bool4(x, x, y, x);

        /// <summary>
        /// Returns bool3.xxyy swizzling.
        /// </summary>
        public bool4 xxyy => new bool4(x, x, y, y);

        /// <summary>
        /// Returns bool3.rrgg swizzling (equivalent to bool3.xxyy).
        /// </summary>
        public bool4 rrgg => new bool4(x, x, y, y);

        /// <summary>
        /// Returns bool3.xxyz swizzling.
        /// </summary>
        public bool4 xxyz => new bool4(x, x, y, z);

        /// <summary>
        /// Returns bool3.rrgb swizzling (equivalent to bool3.xxyz).
        /// </summary>
        public bool4 rrgb => new bool4(x, x, y, z);

        /// <summary>
        /// Returns bool3.xxz swizzling.
        /// </summary>
        public bool3 xxz => new bool3(x, x, z);

        /// <summary>
        /// Returns bool3.rrb swizzling (equivalent to bool3.xxz).
        /// </summary>
        public bool3 rrb => new bool3(x, x, z);

        /// <summary>
        /// Returns bool3.xxzx swizzling.
        /// </summary>
        public bool4 xxzx => new bool4(x, x, z, x);

        /// <summary>
        /// Returns bool3.rrbr swizzling (equivalent to bool3.xxzx).
        /// </summary>
        public bool4 rrbr => new bool4(x, x, z, x);

        /// <summary>
        /// Returns bool3.xxzy swizzling.
        /// </summary>
        public bool4 xxzy => new bool4(x, x, z, y);

        /// <summary>
        /// Returns bool3.rrbg swizzling (equivalent to bool3.xxzy).
        /// </summary>
        public bool4 rrbg => new bool4(x, x, z, y);

        /// <summary>
        /// Returns bool3.xxzz swizzling.
        /// </summary>
        public bool4 xxzz => new bool4(x, x, z, z);

        /// <summary>
        /// Returns bool3.rrbb swizzling (equivalent to bool3.xxzz).
        /// </summary>
        public bool4 rrbb => new bool4(x, x, z, z);

        /// <summary>
        /// Returns bool3.xy swizzling.
        /// </summary>
        public bool2 xy => new bool2(x, y);

        /// <summary>
        /// Returns bool3.rg swizzling (equivalent to bool3.xy).
        /// </summary>
        public bool2 rg => new bool2(x, y);

        /// <summary>
        /// Returns bool3.xyx swizzling.
        /// </summary>
        public bool3 xyx => new bool3(x, y, x);

        /// <summary>
        /// Returns bool3.rgr swizzling (equivalent to bool3.xyx).
        /// </summary>
        public bool3 rgr => new bool3(x, y, x);

        /// <summary>
        /// Returns bool3.xyxx swizzling.
        /// </summary>
        public bool4 xyxx => new bool4(x, y, x, x);

        /// <summary>
        /// Returns bool3.rgrr swizzling (equivalent to bool3.xyxx).
        /// </summary>
        public bool4 rgrr => new bool4(x, y, x, x);

        /// <summary>
        /// Returns bool3.xyxy swizzling.
        /// </summary>
        public bool4 xyxy => new bool4(x, y, x, y);

        /// <summary>
        /// Returns bool3.rgrg swizzling (equivalent to bool3.xyxy).
        /// </summary>
        public bool4 rgrg => new bool4(x, y, x, y);

        /// <summary>
        /// Returns bool3.xyxz swizzling.
        /// </summary>
        public bool4 xyxz => new bool4(x, y, x, z);

        /// <summary>
        /// Returns bool3.rgrb swizzling (equivalent to bool3.xyxz).
        /// </summary>
        public bool4 rgrb => new bool4(x, y, x, z);

        /// <summary>
        /// Returns bool3.xyy swizzling.
        /// </summary>
        public bool3 xyy => new bool3(x, y, y);

        /// <summary>
        /// Returns bool3.rgg swizzling (equivalent to bool3.xyy).
        /// </summary>
        public bool3 rgg => new bool3(x, y, y);

        /// <summary>
        /// Returns bool3.xyyx swizzling.
        /// </summary>
        public bool4 xyyx => new bool4(x, y, y, x);

        /// <summary>
        /// Returns bool3.rggr swizzling (equivalent to bool3.xyyx).
        /// </summary>
        public bool4 rggr => new bool4(x, y, y, x);

        /// <summary>
        /// Returns bool3.xyyy swizzling.
        /// </summary>
        public bool4 xyyy => new bool4(x, y, y, y);

        /// <summary>
        /// Returns bool3.rggg swizzling (equivalent to bool3.xyyy).
        /// </summary>
        public bool4 rggg => new bool4(x, y, y, y);

        /// <summary>
        /// Returns bool3.xyyz swizzling.
        /// </summary>
        public bool4 xyyz => new bool4(x, y, y, z);

        /// <summary>
        /// Returns bool3.rggb swizzling (equivalent to bool3.xyyz).
        /// </summary>
        public bool4 rggb => new bool4(x, y, y, z);

        /// <summary>
        /// Returns bool3.xyz swizzling.
        /// </summary>
        public bool3 xyz => new bool3(x, y, z);

        /// <summary>
        /// Returns bool3.rgb swizzling (equivalent to bool3.xyz).
        /// </summary>
        public bool3 rgb => new bool3(x, y, z);

        /// <summary>
        /// Returns bool3.xyzx swizzling.
        /// </summary>
        public bool4 xyzx => new bool4(x, y, z, x);

        /// <summary>
        /// Returns bool3.rgbr swizzling (equivalent to bool3.xyzx).
        /// </summary>
        public bool4 rgbr => new bool4(x, y, z, x);

        /// <summary>
        /// Returns bool3.xyzy swizzling.
        /// </summary>
        public bool4 xyzy => new bool4(x, y, z, y);

        /// <summary>
        /// Returns bool3.rgbg swizzling (equivalent to bool3.xyzy).
        /// </summary>
        public bool4 rgbg => new bool4(x, y, z, y);

        /// <summary>
        /// Returns bool3.xyzz swizzling.
        /// </summary>
        public bool4 xyzz => new bool4(x, y, z, z);

        /// <summary>
        /// Returns bool3.rgbb swizzling (equivalent to bool3.xyzz).
        /// </summary>
        public bool4 rgbb => new bool4(x, y, z, z);

        /// <summary>
        /// Returns bool3.xz swizzling.
        /// </summary>
        public bool2 xz => new bool2(x, z);

        /// <summary>
        /// Returns bool3.rb swizzling (equivalent to bool3.xz).
        /// </summary>
        public bool2 rb => new bool2(x, z);

        /// <summary>
        /// Returns bool3.xzx swizzling.
        /// </summary>
        public bool3 xzx => new bool3(x, z, x);

        /// <summary>
        /// Returns bool3.rbr swizzling (equivalent to bool3.xzx).
        /// </summary>
        public bool3 rbr => new bool3(x, z, x);

        /// <summary>
        /// Returns bool3.xzxx swizzling.
        /// </summary>
        public bool4 xzxx => new bool4(x, z, x, x);

        /// <summary>
        /// Returns bool3.rbrr swizzling (equivalent to bool3.xzxx).
        /// </summary>
        public bool4 rbrr => new bool4(x, z, x, x);

        /// <summary>
        /// Returns bool3.xzxy swizzling.
        /// </summary>
        public bool4 xzxy => new bool4(x, z, x, y);

        /// <summary>
        /// Returns bool3.rbrg swizzling (equivalent to bool3.xzxy).
        /// </summary>
        public bool4 rbrg => new bool4(x, z, x, y);

        /// <summary>
        /// Returns bool3.xzxz swizzling.
        /// </summary>
        public bool4 xzxz => new bool4(x, z, x, z);

        /// <summary>
        /// Returns bool3.rbrb swizzling (equivalent to bool3.xzxz).
        /// </summary>
        public bool4 rbrb => new bool4(x, z, x, z);

        /// <summary>
        /// Returns bool3.xzy swizzling.
        /// </summary>
        public bool3 xzy => new bool3(x, z, y);

        /// <summary>
        /// Returns bool3.rbg swizzling (equivalent to bool3.xzy).
        /// </summary>
        public bool3 rbg => new bool3(x, z, y);

        /// <summary>
        /// Returns bool3.xzyx swizzling.
        /// </summary>
        public bool4 xzyx => new bool4(x, z, y, x);

        /// <summary>
        /// Returns bool3.rbgr swizzling (equivalent to bool3.xzyx).
        /// </summary>
        public bool4 rbgr => new bool4(x, z, y, x);

        /// <summary>
        /// Returns bool3.xzyy swizzling.
        /// </summary>
        public bool4 xzyy => new bool4(x, z, y, y);

        /// <summary>
        /// Returns bool3.rbgg swizzling (equivalent to bool3.xzyy).
        /// </summary>
        public bool4 rbgg => new bool4(x, z, y, y);

        /// <summary>
        /// Returns bool3.xzyz swizzling.
        /// </summary>
        public bool4 xzyz => new bool4(x, z, y, z);

        /// <summary>
        /// Returns bool3.rbgb swizzling (equivalent to bool3.xzyz).
        /// </summary>
        public bool4 rbgb => new bool4(x, z, y, z);

        /// <summary>
        /// Returns bool3.xzz swizzling.
        /// </summary>
        public bool3 xzz => new bool3(x, z, z);

        /// <summary>
        /// Returns bool3.rbb swizzling (equivalent to bool3.xzz).
        /// </summary>
        public bool3 rbb => new bool3(x, z, z);

        /// <summary>
        /// Returns bool3.xzzx swizzling.
        /// </summary>
        public bool4 xzzx => new bool4(x, z, z, x);

        /// <summary>
        /// Returns bool3.rbbr swizzling (equivalent to bool3.xzzx).
        /// </summary>
        public bool4 rbbr => new bool4(x, z, z, x);

        /// <summary>
        /// Returns bool3.xzzy swizzling.
        /// </summary>
        public bool4 xzzy => new bool4(x, z, z, y);

        /// <summary>
        /// Returns bool3.rbbg swizzling (equivalent to bool3.xzzy).
        /// </summary>
        public bool4 rbbg => new bool4(x, z, z, y);

        /// <summary>
        /// Returns bool3.xzzz swizzling.
        /// </summary>
        public bool4 xzzz => new bool4(x, z, z, z);

        /// <summary>
        /// Returns bool3.rbbb swizzling (equivalent to bool3.xzzz).
        /// </summary>
        public bool4 rbbb => new bool4(x, z, z, z);

        /// <summary>
        /// Returns bool3.yx swizzling.
        /// </summary>
        public bool2 yx => new bool2(y, x);

        /// <summary>
        /// Returns bool3.gr swizzling (equivalent to bool3.yx).
        /// </summary>
        public bool2 gr => new bool2(y, x);

        /// <summary>
        /// Returns bool3.yxx swizzling.
        /// </summary>
        public bool3 yxx => new bool3(y, x, x);

        /// <summary>
        /// Returns bool3.grr swizzling (equivalent to bool3.yxx).
        /// </summary>
        public bool3 grr => new bool3(y, x, x);

        /// <summary>
        /// Returns bool3.yxxx swizzling.
        /// </summary>
        public bool4 yxxx => new bool4(y, x, x, x);

        /// <summary>
        /// Returns bool3.grrr swizzling (equivalent to bool3.yxxx).
        /// </summary>
        public bool4 grrr => new bool4(y, x, x, x);

        /// <summary>
        /// Returns bool3.yxxy swizzling.
        /// </summary>
        public bool4 yxxy => new bool4(y, x, x, y);

        /// <summary>
        /// Returns bool3.grrg swizzling (equivalent to bool3.yxxy).
        /// </summary>
        public bool4 grrg => new bool4(y, x, x, y);

        /// <summary>
        /// Returns bool3.yxxz swizzling.
        /// </summary>
        public bool4 yxxz => new bool4(y, x, x, z);

        /// <summary>
        /// Returns bool3.grrb swizzling (equivalent to bool3.yxxz).
        /// </summary>
        public bool4 grrb => new bool4(y, x, x, z);

        /// <summary>
        /// Returns bool3.yxy swizzling.
        /// </summary>
        public bool3 yxy => new bool3(y, x, y);

        /// <summary>
        /// Returns bool3.grg swizzling (equivalent to bool3.yxy).
        /// </summary>
        public bool3 grg => new bool3(y, x, y);

        /// <summary>
        /// Returns bool3.yxyx swizzling.
        /// </summary>
        public bool4 yxyx => new bool4(y, x, y, x);

        /// <summary>
        /// Returns bool3.grgr swizzling (equivalent to bool3.yxyx).
        /// </summary>
        public bool4 grgr => new bool4(y, x, y, x);

        /// <summary>
        /// Returns bool3.yxyy swizzling.
        /// </summary>
        public bool4 yxyy => new bool4(y, x, y, y);

        /// <summary>
        /// Returns bool3.grgg swizzling (equivalent to bool3.yxyy).
        /// </summary>
        public bool4 grgg => new bool4(y, x, y, y);

        /// <summary>
        /// Returns bool3.yxyz swizzling.
        /// </summary>
        public bool4 yxyz => new bool4(y, x, y, z);

        /// <summary>
        /// Returns bool3.grgb swizzling (equivalent to bool3.yxyz).
        /// </summary>
        public bool4 grgb => new bool4(y, x, y, z);

        /// <summary>
        /// Returns bool3.yxz swizzling.
        /// </summary>
        public bool3 yxz => new bool3(y, x, z);

        /// <summary>
        /// Returns bool3.grb swizzling (equivalent to bool3.yxz).
        /// </summary>
        public bool3 grb => new bool3(y, x, z);

        /// <summary>
        /// Returns bool3.yxzx swizzling.
        /// </summary>
        public bool4 yxzx => new bool4(y, x, z, x);

        /// <summary>
        /// Returns bool3.grbr swizzling (equivalent to bool3.yxzx).
        /// </summary>
        public bool4 grbr => new bool4(y, x, z, x);

        /// <summary>
        /// Returns bool3.yxzy swizzling.
        /// </summary>
        public bool4 yxzy => new bool4(y, x, z, y);

        /// <summary>
        /// Returns bool3.grbg swizzling (equivalent to bool3.yxzy).
        /// </summary>
        public bool4 grbg => new bool4(y, x, z, y);

        /// <summary>
        /// Returns bool3.yxzz swizzling.
        /// </summary>
        public bool4 yxzz => new bool4(y, x, z, z);

        /// <summary>
        /// Returns bool3.grbb swizzling (equivalent to bool3.yxzz).
        /// </summary>
        public bool4 grbb => new bool4(y, x, z, z);

        /// <summary>
        /// Returns bool3.yy swizzling.
        /// </summary>
        public bool2 yy => new bool2(y, y);

        /// <summary>
        /// Returns bool3.gg swizzling (equivalent to bool3.yy).
        /// </summary>
        public bool2 gg => new bool2(y, y);

        /// <summary>
        /// Returns bool3.yyx swizzling.
        /// </summary>
        public bool3 yyx => new bool3(y, y, x);

        /// <summary>
        /// Returns bool3.ggr swizzling (equivalent to bool3.yyx).
        /// </summary>
        public bool3 ggr => new bool3(y, y, x);

        /// <summary>
        /// Returns bool3.yyxx swizzling.
        /// </summary>
        public bool4 yyxx => new bool4(y, y, x, x);

        /// <summary>
        /// Returns bool3.ggrr swizzling (equivalent to bool3.yyxx).
        /// </summary>
        public bool4 ggrr => new bool4(y, y, x, x);

        /// <summary>
        /// Returns bool3.yyxy swizzling.
        /// </summary>
        public bool4 yyxy => new bool4(y, y, x, y);

        /// <summary>
        /// Returns bool3.ggrg swizzling (equivalent to bool3.yyxy).
        /// </summary>
        public bool4 ggrg => new bool4(y, y, x, y);

        /// <summary>
        /// Returns bool3.yyxz swizzling.
        /// </summary>
        public bool4 yyxz => new bool4(y, y, x, z);

        /// <summary>
        /// Returns bool3.ggrb swizzling (equivalent to bool3.yyxz).
        /// </summary>
        public bool4 ggrb => new bool4(y, y, x, z);

        /// <summary>
        /// Returns bool3.yyy swizzling.
        /// </summary>
        public bool3 yyy => new bool3(y, y, y);

        /// <summary>
        /// Returns bool3.ggg swizzling (equivalent to bool3.yyy).
        /// </summary>
        public bool3 ggg => new bool3(y, y, y);

        /// <summary>
        /// Returns bool3.yyyx swizzling.
        /// </summary>
        public bool4 yyyx => new bool4(y, y, y, x);

        /// <summary>
        /// Returns bool3.gggr swizzling (equivalent to bool3.yyyx).
        /// </summary>
        public bool4 gggr => new bool4(y, y, y, x);

        /// <summary>
        /// Returns bool3.yyyy swizzling.
        /// </summary>
        public bool4 yyyy => new bool4(y, y, y, y);

        /// <summary>
        /// Returns bool3.gggg swizzling (equivalent to bool3.yyyy).
        /// </summary>
        public bool4 gggg => new bool4(y, y, y, y);

        /// <summary>
        /// Returns bool3.yyyz swizzling.
        /// </summary>
        public bool4 yyyz => new bool4(y, y, y, z);

        /// <summary>
        /// Returns bool3.gggb swizzling (equivalent to bool3.yyyz).
        /// </summary>
        public bool4 gggb => new bool4(y, y, y, z);

        /// <summary>
        /// Returns bool3.yyz swizzling.
        /// </summary>
        public bool3 yyz => new bool3(y, y, z);

        /// <summary>
        /// Returns bool3.ggb swizzling (equivalent to bool3.yyz).
        /// </summary>
        public bool3 ggb => new bool3(y, y, z);

        /// <summary>
        /// Returns bool3.yyzx swizzling.
        /// </summary>
        public bool4 yyzx => new bool4(y, y, z, x);

        /// <summary>
        /// Returns bool3.ggbr swizzling (equivalent to bool3.yyzx).
        /// </summary>
        public bool4 ggbr => new bool4(y, y, z, x);

        /// <summary>
        /// Returns bool3.yyzy swizzling.
        /// </summary>
        public bool4 yyzy => new bool4(y, y, z, y);

        /// <summary>
        /// Returns bool3.ggbg swizzling (equivalent to bool3.yyzy).
        /// </summary>
        public bool4 ggbg => new bool4(y, y, z, y);

        /// <summary>
        /// Returns bool3.yyzz swizzling.
        /// </summary>
        public bool4 yyzz => new bool4(y, y, z, z);

        /// <summary>
        /// Returns bool3.ggbb swizzling (equivalent to bool3.yyzz).
        /// </summary>
        public bool4 ggbb => new bool4(y, y, z, z);

        /// <summary>
        /// Returns bool3.yz swizzling.
        /// </summary>
        public bool2 yz => new bool2(y, z);

        /// <summary>
        /// Returns bool3.gb swizzling (equivalent to bool3.yz).
        /// </summary>
        public bool2 gb => new bool2(y, z);

        /// <summary>
        /// Returns bool3.yzx swizzling.
        /// </summary>
        public bool3 yzx => new bool3(y, z, x);

        /// <summary>
        /// Returns bool3.gbr swizzling (equivalent to bool3.yzx).
        /// </summary>
        public bool3 gbr => new bool3(y, z, x);

        /// <summary>
        /// Returns bool3.yzxx swizzling.
        /// </summary>
        public bool4 yzxx => new bool4(y, z, x, x);

        /// <summary>
        /// Returns bool3.gbrr swizzling (equivalent to bool3.yzxx).
        /// </summary>
        public bool4 gbrr => new bool4(y, z, x, x);

        /// <summary>
        /// Returns bool3.yzxy swizzling.
        /// </summary>
        public bool4 yzxy => new bool4(y, z, x, y);

        /// <summary>
        /// Returns bool3.gbrg swizzling (equivalent to bool3.yzxy).
        /// </summary>
        public bool4 gbrg => new bool4(y, z, x, y);

        /// <summary>
        /// Returns bool3.yzxz swizzling.
        /// </summary>
        public bool4 yzxz => new bool4(y, z, x, z);

        /// <summary>
        /// Returns bool3.gbrb swizzling (equivalent to bool3.yzxz).
        /// </summary>
        public bool4 gbrb => new bool4(y, z, x, z);

        /// <summary>
        /// Returns bool3.yzy swizzling.
        /// </summary>
        public bool3 yzy => new bool3(y, z, y);

        /// <summary>
        /// Returns bool3.gbg swizzling (equivalent to bool3.yzy).
        /// </summary>
        public bool3 gbg => new bool3(y, z, y);

        /// <summary>
        /// Returns bool3.yzyx swizzling.
        /// </summary>
        public bool4 yzyx => new bool4(y, z, y, x);

        /// <summary>
        /// Returns bool3.gbgr swizzling (equivalent to bool3.yzyx).
        /// </summary>
        public bool4 gbgr => new bool4(y, z, y, x);

        /// <summary>
        /// Returns bool3.yzyy swizzling.
        /// </summary>
        public bool4 yzyy => new bool4(y, z, y, y);

        /// <summary>
        /// Returns bool3.gbgg swizzling (equivalent to bool3.yzyy).
        /// </summary>
        public bool4 gbgg => new bool4(y, z, y, y);

        /// <summary>
        /// Returns bool3.yzyz swizzling.
        /// </summary>
        public bool4 yzyz => new bool4(y, z, y, z);

        /// <summary>
        /// Returns bool3.gbgb swizzling (equivalent to bool3.yzyz).
        /// </summary>
        public bool4 gbgb => new bool4(y, z, y, z);

        /// <summary>
        /// Returns bool3.yzz swizzling.
        /// </summary>
        public bool3 yzz => new bool3(y, z, z);

        /// <summary>
        /// Returns bool3.gbb swizzling (equivalent to bool3.yzz).
        /// </summary>
        public bool3 gbb => new bool3(y, z, z);

        /// <summary>
        /// Returns bool3.yzzx swizzling.
        /// </summary>
        public bool4 yzzx => new bool4(y, z, z, x);

        /// <summary>
        /// Returns bool3.gbbr swizzling (equivalent to bool3.yzzx).
        /// </summary>
        public bool4 gbbr => new bool4(y, z, z, x);

        /// <summary>
        /// Returns bool3.yzzy swizzling.
        /// </summary>
        public bool4 yzzy => new bool4(y, z, z, y);

        /// <summary>
        /// Returns bool3.gbbg swizzling (equivalent to bool3.yzzy).
        /// </summary>
        public bool4 gbbg => new bool4(y, z, z, y);

        /// <summary>
        /// Returns bool3.yzzz swizzling.
        /// </summary>
        public bool4 yzzz => new bool4(y, z, z, z);

        /// <summary>
        /// Returns bool3.gbbb swizzling (equivalent to bool3.yzzz).
        /// </summary>
        public bool4 gbbb => new bool4(y, z, z, z);

        /// <summary>
        /// Returns bool3.zx swizzling.
        /// </summary>
        public bool2 zx => new bool2(z, x);

        /// <summary>
        /// Returns bool3.br swizzling (equivalent to bool3.zx).
        /// </summary>
        public bool2 br => new bool2(z, x);

        /// <summary>
        /// Returns bool3.zxx swizzling.
        /// </summary>
        public bool3 zxx => new bool3(z, x, x);

        /// <summary>
        /// Returns bool3.brr swizzling (equivalent to bool3.zxx).
        /// </summary>
        public bool3 brr => new bool3(z, x, x);

        /// <summary>
        /// Returns bool3.zxxx swizzling.
        /// </summary>
        public bool4 zxxx => new bool4(z, x, x, x);

        /// <summary>
        /// Returns bool3.brrr swizzling (equivalent to bool3.zxxx).
        /// </summary>
        public bool4 brrr => new bool4(z, x, x, x);

        /// <summary>
        /// Returns bool3.zxxy swizzling.
        /// </summary>
        public bool4 zxxy => new bool4(z, x, x, y);

        /// <summary>
        /// Returns bool3.brrg swizzling (equivalent to bool3.zxxy).
        /// </summary>
        public bool4 brrg => new bool4(z, x, x, y);

        /// <summary>
        /// Returns bool3.zxxz swizzling.
        /// </summary>
        public bool4 zxxz => new bool4(z, x, x, z);

        /// <summary>
        /// Returns bool3.brrb swizzling (equivalent to bool3.zxxz).
        /// </summary>
        public bool4 brrb => new bool4(z, x, x, z);

        /// <summary>
        /// Returns bool3.zxy swizzling.
        /// </summary>
        public bool3 zxy => new bool3(z, x, y);

        /// <summary>
        /// Returns bool3.brg swizzling (equivalent to bool3.zxy).
        /// </summary>
        public bool3 brg => new bool3(z, x, y);

        /// <summary>
        /// Returns bool3.zxyx swizzling.
        /// </summary>
        public bool4 zxyx => new bool4(z, x, y, x);

        /// <summary>
        /// Returns bool3.brgr swizzling (equivalent to bool3.zxyx).
        /// </summary>
        public bool4 brgr => new bool4(z, x, y, x);

        /// <summary>
        /// Returns bool3.zxyy swizzling.
        /// </summary>
        public bool4 zxyy => new bool4(z, x, y, y);

        /// <summary>
        /// Returns bool3.brgg swizzling (equivalent to bool3.zxyy).
        /// </summary>
        public bool4 brgg => new bool4(z, x, y, y);

        /// <summary>
        /// Returns bool3.zxyz swizzling.
        /// </summary>
        public bool4 zxyz => new bool4(z, x, y, z);

        /// <summary>
        /// Returns bool3.brgb swizzling (equivalent to bool3.zxyz).
        /// </summary>
        public bool4 brgb => new bool4(z, x, y, z);

        /// <summary>
        /// Returns bool3.zxz swizzling.
        /// </summary>
        public bool3 zxz => new bool3(z, x, z);

        /// <summary>
        /// Returns bool3.brb swizzling (equivalent to bool3.zxz).
        /// </summary>
        public bool3 brb => new bool3(z, x, z);

        /// <summary>
        /// Returns bool3.zxzx swizzling.
        /// </summary>
        public bool4 zxzx => new bool4(z, x, z, x);

        /// <summary>
        /// Returns bool3.brbr swizzling (equivalent to bool3.zxzx).
        /// </summary>
        public bool4 brbr => new bool4(z, x, z, x);

        /// <summary>
        /// Returns bool3.zxzy swizzling.
        /// </summary>
        public bool4 zxzy => new bool4(z, x, z, y);

        /// <summary>
        /// Returns bool3.brbg swizzling (equivalent to bool3.zxzy).
        /// </summary>
        public bool4 brbg => new bool4(z, x, z, y);

        /// <summary>
        /// Returns bool3.zxzz swizzling.
        /// </summary>
        public bool4 zxzz => new bool4(z, x, z, z);

        /// <summary>
        /// Returns bool3.brbb swizzling (equivalent to bool3.zxzz).
        /// </summary>
        public bool4 brbb => new bool4(z, x, z, z);

        /// <summary>
        /// Returns bool3.zy swizzling.
        /// </summary>
        public bool2 zy => new bool2(z, y);

        /// <summary>
        /// Returns bool3.bg swizzling (equivalent to bool3.zy).
        /// </summary>
        public bool2 bg => new bool2(z, y);

        /// <summary>
        /// Returns bool3.zyx swizzling.
        /// </summary>
        public bool3 zyx => new bool3(z, y, x);

        /// <summary>
        /// Returns bool3.bgr swizzling (equivalent to bool3.zyx).
        /// </summary>
        public bool3 bgr => new bool3(z, y, x);

        /// <summary>
        /// Returns bool3.zyxx swizzling.
        /// </summary>
        public bool4 zyxx => new bool4(z, y, x, x);

        /// <summary>
        /// Returns bool3.bgrr swizzling (equivalent to bool3.zyxx).
        /// </summary>
        public bool4 bgrr => new bool4(z, y, x, x);

        /// <summary>
        /// Returns bool3.zyxy swizzling.
        /// </summary>
        public bool4 zyxy => new bool4(z, y, x, y);

        /// <summary>
        /// Returns bool3.bgrg swizzling (equivalent to bool3.zyxy).
        /// </summary>
        public bool4 bgrg => new bool4(z, y, x, y);

        /// <summary>
        /// Returns bool3.zyxz swizzling.
        /// </summary>
        public bool4 zyxz => new bool4(z, y, x, z);

        /// <summary>
        /// Returns bool3.bgrb swizzling (equivalent to bool3.zyxz).
        /// </summary>
        public bool4 bgrb => new bool4(z, y, x, z);

        /// <summary>
        /// Returns bool3.zyy swizzling.
        /// </summary>
        public bool3 zyy => new bool3(z, y, y);

        /// <summary>
        /// Returns bool3.bgg swizzling (equivalent to bool3.zyy).
        /// </summary>
        public bool3 bgg => new bool3(z, y, y);

        /// <summary>
        /// Returns bool3.zyyx swizzling.
        /// </summary>
        public bool4 zyyx => new bool4(z, y, y, x);

        /// <summary>
        /// Returns bool3.bggr swizzling (equivalent to bool3.zyyx).
        /// </summary>
        public bool4 bggr => new bool4(z, y, y, x);

        /// <summary>
        /// Returns bool3.zyyy swizzling.
        /// </summary>
        public bool4 zyyy => new bool4(z, y, y, y);

        /// <summary>
        /// Returns bool3.bggg swizzling (equivalent to bool3.zyyy).
        /// </summary>
        public bool4 bggg => new bool4(z, y, y, y);

        /// <summary>
        /// Returns bool3.zyyz swizzling.
        /// </summary>
        public bool4 zyyz => new bool4(z, y, y, z);

        /// <summary>
        /// Returns bool3.bggb swizzling (equivalent to bool3.zyyz).
        /// </summary>
        public bool4 bggb => new bool4(z, y, y, z);

        /// <summary>
        /// Returns bool3.zyz swizzling.
        /// </summary>
        public bool3 zyz => new bool3(z, y, z);

        /// <summary>
        /// Returns bool3.bgb swizzling (equivalent to bool3.zyz).
        /// </summary>
        public bool3 bgb => new bool3(z, y, z);

        /// <summary>
        /// Returns bool3.zyzx swizzling.
        /// </summary>
        public bool4 zyzx => new bool4(z, y, z, x);

        /// <summary>
        /// Returns bool3.bgbr swizzling (equivalent to bool3.zyzx).
        /// </summary>
        public bool4 bgbr => new bool4(z, y, z, x);

        /// <summary>
        /// Returns bool3.zyzy swizzling.
        /// </summary>
        public bool4 zyzy => new bool4(z, y, z, y);

        /// <summary>
        /// Returns bool3.bgbg swizzling (equivalent to bool3.zyzy).
        /// </summary>
        public bool4 bgbg => new bool4(z, y, z, y);

        /// <summary>
        /// Returns bool3.zyzz swizzling.
        /// </summary>
        public bool4 zyzz => new bool4(z, y, z, z);

        /// <summary>
        /// Returns bool3.bgbb swizzling (equivalent to bool3.zyzz).
        /// </summary>
        public bool4 bgbb => new bool4(z, y, z, z);

        /// <summary>
        /// Returns bool3.zz swizzling.
        /// </summary>
        public bool2 zz => new bool2(z, z);

        /// <summary>
        /// Returns bool3.bb swizzling (equivalent to bool3.zz).
        /// </summary>
        public bool2 bb => new bool2(z, z);

        /// <summary>
        /// Returns bool3.zzx swizzling.
        /// </summary>
        public bool3 zzx => new bool3(z, z, x);

        /// <summary>
        /// Returns bool3.bbr swizzling (equivalent to bool3.zzx).
        /// </summary>
        public bool3 bbr => new bool3(z, z, x);

        /// <summary>
        /// Returns bool3.zzxx swizzling.
        /// </summary>
        public bool4 zzxx => new bool4(z, z, x, x);

        /// <summary>
        /// Returns bool3.bbrr swizzling (equivalent to bool3.zzxx).
        /// </summary>
        public bool4 bbrr => new bool4(z, z, x, x);

        /// <summary>
        /// Returns bool3.zzxy swizzling.
        /// </summary>
        public bool4 zzxy => new bool4(z, z, x, y);

        /// <summary>
        /// Returns bool3.bbrg swizzling (equivalent to bool3.zzxy).
        /// </summary>
        public bool4 bbrg => new bool4(z, z, x, y);

        /// <summary>
        /// Returns bool3.zzxz swizzling.
        /// </summary>
        public bool4 zzxz => new bool4(z, z, x, z);

        /// <summary>
        /// Returns bool3.bbrb swizzling (equivalent to bool3.zzxz).
        /// </summary>
        public bool4 bbrb => new bool4(z, z, x, z);

        /// <summary>
        /// Returns bool3.zzy swizzling.
        /// </summary>
        public bool3 zzy => new bool3(z, z, y);

        /// <summary>
        /// Returns bool3.bbg swizzling (equivalent to bool3.zzy).
        /// </summary>
        public bool3 bbg => new bool3(z, z, y);

        /// <summary>
        /// Returns bool3.zzyx swizzling.
        /// </summary>
        public bool4 zzyx => new bool4(z, z, y, x);

        /// <summary>
        /// Returns bool3.bbgr swizzling (equivalent to bool3.zzyx).
        /// </summary>
        public bool4 bbgr => new bool4(z, z, y, x);

        /// <summary>
        /// Returns bool3.zzyy swizzling.
        /// </summary>
        public bool4 zzyy => new bool4(z, z, y, y);

        /// <summary>
        /// Returns bool3.bbgg swizzling (equivalent to bool3.zzyy).
        /// </summary>
        public bool4 bbgg => new bool4(z, z, y, y);

        /// <summary>
        /// Returns bool3.zzyz swizzling.
        /// </summary>
        public bool4 zzyz => new bool4(z, z, y, z);

        /// <summary>
        /// Returns bool3.bbgb swizzling (equivalent to bool3.zzyz).
        /// </summary>
        public bool4 bbgb => new bool4(z, z, y, z);

        /// <summary>
        /// Returns bool3.zzz swizzling.
        /// </summary>
        public bool3 zzz => new bool3(z, z, z);

        /// <summary>
        /// Returns bool3.bbb swizzling (equivalent to bool3.zzz).
        /// </summary>
        public bool3 bbb => new bool3(z, z, z);

        /// <summary>
        /// Returns bool3.zzzx swizzling.
        /// </summary>
        public bool4 zzzx => new bool4(z, z, z, x);

        /// <summary>
        /// Returns bool3.bbbr swizzling (equivalent to bool3.zzzx).
        /// </summary>
        public bool4 bbbr => new bool4(z, z, z, x);

        /// <summary>
        /// Returns bool3.zzzy swizzling.
        /// </summary>
        public bool4 zzzy => new bool4(z, z, z, y);

        /// <summary>
        /// Returns bool3.bbbg swizzling (equivalent to bool3.zzzy).
        /// </summary>
        public bool4 bbbg => new bool4(z, z, z, y);

        /// <summary>
        /// Returns bool3.zzzz swizzling.
        /// </summary>
        public bool4 zzzz => new bool4(z, z, z, z);

        /// <summary>
        /// Returns bool3.bbbb swizzling (equivalent to bool3.zzzz).
        /// </summary>
        public bool4 bbbb => new bool4(z, z, z, z);

        #endregion

    }
}
