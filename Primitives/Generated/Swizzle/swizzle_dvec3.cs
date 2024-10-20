using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type double with 3 components, used for implementing swizzling for double3.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_dvec3
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        internal readonly double x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        internal readonly double y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        internal readonly double z;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_dvec3.
        /// </summary>
        internal swizzle_dvec3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns double3.xx swizzling.
        /// </summary>
        public double2 xx => new double2(x, x);

        /// <summary>
        /// Returns double3.rr swizzling (equivalent to double3.xx).
        /// </summary>
        public double2 rr => new double2(x, x);

        /// <summary>
        /// Returns double3.xxx swizzling.
        /// </summary>
        public double3 xxx => new double3(x, x, x);

        /// <summary>
        /// Returns double3.rrr swizzling (equivalent to double3.xxx).
        /// </summary>
        public double3 rrr => new double3(x, x, x);

        /// <summary>
        /// Returns double3.xxxx swizzling.
        /// </summary>
        public double4 xxxx => new double4(x, x, x, x);

        /// <summary>
        /// Returns double3.rrrr swizzling (equivalent to double3.xxxx).
        /// </summary>
        public double4 rrrr => new double4(x, x, x, x);

        /// <summary>
        /// Returns double3.xxxy swizzling.
        /// </summary>
        public double4 xxxy => new double4(x, x, x, y);

        /// <summary>
        /// Returns double3.rrrg swizzling (equivalent to double3.xxxy).
        /// </summary>
        public double4 rrrg => new double4(x, x, x, y);

        /// <summary>
        /// Returns double3.xxxz swizzling.
        /// </summary>
        public double4 xxxz => new double4(x, x, x, z);

        /// <summary>
        /// Returns double3.rrrb swizzling (equivalent to double3.xxxz).
        /// </summary>
        public double4 rrrb => new double4(x, x, x, z);

        /// <summary>
        /// Returns double3.xxy swizzling.
        /// </summary>
        public double3 xxy => new double3(x, x, y);

        /// <summary>
        /// Returns double3.rrg swizzling (equivalent to double3.xxy).
        /// </summary>
        public double3 rrg => new double3(x, x, y);

        /// <summary>
        /// Returns double3.xxyx swizzling.
        /// </summary>
        public double4 xxyx => new double4(x, x, y, x);

        /// <summary>
        /// Returns double3.rrgr swizzling (equivalent to double3.xxyx).
        /// </summary>
        public double4 rrgr => new double4(x, x, y, x);

        /// <summary>
        /// Returns double3.xxyy swizzling.
        /// </summary>
        public double4 xxyy => new double4(x, x, y, y);

        /// <summary>
        /// Returns double3.rrgg swizzling (equivalent to double3.xxyy).
        /// </summary>
        public double4 rrgg => new double4(x, x, y, y);

        /// <summary>
        /// Returns double3.xxyz swizzling.
        /// </summary>
        public double4 xxyz => new double4(x, x, y, z);

        /// <summary>
        /// Returns double3.rrgb swizzling (equivalent to double3.xxyz).
        /// </summary>
        public double4 rrgb => new double4(x, x, y, z);

        /// <summary>
        /// Returns double3.xxz swizzling.
        /// </summary>
        public double3 xxz => new double3(x, x, z);

        /// <summary>
        /// Returns double3.rrb swizzling (equivalent to double3.xxz).
        /// </summary>
        public double3 rrb => new double3(x, x, z);

        /// <summary>
        /// Returns double3.xxzx swizzling.
        /// </summary>
        public double4 xxzx => new double4(x, x, z, x);

        /// <summary>
        /// Returns double3.rrbr swizzling (equivalent to double3.xxzx).
        /// </summary>
        public double4 rrbr => new double4(x, x, z, x);

        /// <summary>
        /// Returns double3.xxzy swizzling.
        /// </summary>
        public double4 xxzy => new double4(x, x, z, y);

        /// <summary>
        /// Returns double3.rrbg swizzling (equivalent to double3.xxzy).
        /// </summary>
        public double4 rrbg => new double4(x, x, z, y);

        /// <summary>
        /// Returns double3.xxzz swizzling.
        /// </summary>
        public double4 xxzz => new double4(x, x, z, z);

        /// <summary>
        /// Returns double3.rrbb swizzling (equivalent to double3.xxzz).
        /// </summary>
        public double4 rrbb => new double4(x, x, z, z);

        /// <summary>
        /// Returns double3.xy swizzling.
        /// </summary>
        public double2 xy => new double2(x, y);

        /// <summary>
        /// Returns double3.rg swizzling (equivalent to double3.xy).
        /// </summary>
        public double2 rg => new double2(x, y);

        /// <summary>
        /// Returns double3.xyx swizzling.
        /// </summary>
        public double3 xyx => new double3(x, y, x);

        /// <summary>
        /// Returns double3.rgr swizzling (equivalent to double3.xyx).
        /// </summary>
        public double3 rgr => new double3(x, y, x);

        /// <summary>
        /// Returns double3.xyxx swizzling.
        /// </summary>
        public double4 xyxx => new double4(x, y, x, x);

        /// <summary>
        /// Returns double3.rgrr swizzling (equivalent to double3.xyxx).
        /// </summary>
        public double4 rgrr => new double4(x, y, x, x);

        /// <summary>
        /// Returns double3.xyxy swizzling.
        /// </summary>
        public double4 xyxy => new double4(x, y, x, y);

        /// <summary>
        /// Returns double3.rgrg swizzling (equivalent to double3.xyxy).
        /// </summary>
        public double4 rgrg => new double4(x, y, x, y);

        /// <summary>
        /// Returns double3.xyxz swizzling.
        /// </summary>
        public double4 xyxz => new double4(x, y, x, z);

        /// <summary>
        /// Returns double3.rgrb swizzling (equivalent to double3.xyxz).
        /// </summary>
        public double4 rgrb => new double4(x, y, x, z);

        /// <summary>
        /// Returns double3.xyy swizzling.
        /// </summary>
        public double3 xyy => new double3(x, y, y);

        /// <summary>
        /// Returns double3.rgg swizzling (equivalent to double3.xyy).
        /// </summary>
        public double3 rgg => new double3(x, y, y);

        /// <summary>
        /// Returns double3.xyyx swizzling.
        /// </summary>
        public double4 xyyx => new double4(x, y, y, x);

        /// <summary>
        /// Returns double3.rggr swizzling (equivalent to double3.xyyx).
        /// </summary>
        public double4 rggr => new double4(x, y, y, x);

        /// <summary>
        /// Returns double3.xyyy swizzling.
        /// </summary>
        public double4 xyyy => new double4(x, y, y, y);

        /// <summary>
        /// Returns double3.rggg swizzling (equivalent to double3.xyyy).
        /// </summary>
        public double4 rggg => new double4(x, y, y, y);

        /// <summary>
        /// Returns double3.xyyz swizzling.
        /// </summary>
        public double4 xyyz => new double4(x, y, y, z);

        /// <summary>
        /// Returns double3.rggb swizzling (equivalent to double3.xyyz).
        /// </summary>
        public double4 rggb => new double4(x, y, y, z);

        /// <summary>
        /// Returns double3.xyz swizzling.
        /// </summary>
        public double3 xyz => new double3(x, y, z);

        /// <summary>
        /// Returns double3.rgb swizzling (equivalent to double3.xyz).
        /// </summary>
        public double3 rgb => new double3(x, y, z);

        /// <summary>
        /// Returns double3.xyzx swizzling.
        /// </summary>
        public double4 xyzx => new double4(x, y, z, x);

        /// <summary>
        /// Returns double3.rgbr swizzling (equivalent to double3.xyzx).
        /// </summary>
        public double4 rgbr => new double4(x, y, z, x);

        /// <summary>
        /// Returns double3.xyzy swizzling.
        /// </summary>
        public double4 xyzy => new double4(x, y, z, y);

        /// <summary>
        /// Returns double3.rgbg swizzling (equivalent to double3.xyzy).
        /// </summary>
        public double4 rgbg => new double4(x, y, z, y);

        /// <summary>
        /// Returns double3.xyzz swizzling.
        /// </summary>
        public double4 xyzz => new double4(x, y, z, z);

        /// <summary>
        /// Returns double3.rgbb swizzling (equivalent to double3.xyzz).
        /// </summary>
        public double4 rgbb => new double4(x, y, z, z);

        /// <summary>
        /// Returns double3.xz swizzling.
        /// </summary>
        public double2 xz => new double2(x, z);

        /// <summary>
        /// Returns double3.rb swizzling (equivalent to double3.xz).
        /// </summary>
        public double2 rb => new double2(x, z);

        /// <summary>
        /// Returns double3.xzx swizzling.
        /// </summary>
        public double3 xzx => new double3(x, z, x);

        /// <summary>
        /// Returns double3.rbr swizzling (equivalent to double3.xzx).
        /// </summary>
        public double3 rbr => new double3(x, z, x);

        /// <summary>
        /// Returns double3.xzxx swizzling.
        /// </summary>
        public double4 xzxx => new double4(x, z, x, x);

        /// <summary>
        /// Returns double3.rbrr swizzling (equivalent to double3.xzxx).
        /// </summary>
        public double4 rbrr => new double4(x, z, x, x);

        /// <summary>
        /// Returns double3.xzxy swizzling.
        /// </summary>
        public double4 xzxy => new double4(x, z, x, y);

        /// <summary>
        /// Returns double3.rbrg swizzling (equivalent to double3.xzxy).
        /// </summary>
        public double4 rbrg => new double4(x, z, x, y);

        /// <summary>
        /// Returns double3.xzxz swizzling.
        /// </summary>
        public double4 xzxz => new double4(x, z, x, z);

        /// <summary>
        /// Returns double3.rbrb swizzling (equivalent to double3.xzxz).
        /// </summary>
        public double4 rbrb => new double4(x, z, x, z);

        /// <summary>
        /// Returns double3.xzy swizzling.
        /// </summary>
        public double3 xzy => new double3(x, z, y);

        /// <summary>
        /// Returns double3.rbg swizzling (equivalent to double3.xzy).
        /// </summary>
        public double3 rbg => new double3(x, z, y);

        /// <summary>
        /// Returns double3.xzyx swizzling.
        /// </summary>
        public double4 xzyx => new double4(x, z, y, x);

        /// <summary>
        /// Returns double3.rbgr swizzling (equivalent to double3.xzyx).
        /// </summary>
        public double4 rbgr => new double4(x, z, y, x);

        /// <summary>
        /// Returns double3.xzyy swizzling.
        /// </summary>
        public double4 xzyy => new double4(x, z, y, y);

        /// <summary>
        /// Returns double3.rbgg swizzling (equivalent to double3.xzyy).
        /// </summary>
        public double4 rbgg => new double4(x, z, y, y);

        /// <summary>
        /// Returns double3.xzyz swizzling.
        /// </summary>
        public double4 xzyz => new double4(x, z, y, z);

        /// <summary>
        /// Returns double3.rbgb swizzling (equivalent to double3.xzyz).
        /// </summary>
        public double4 rbgb => new double4(x, z, y, z);

        /// <summary>
        /// Returns double3.xzz swizzling.
        /// </summary>
        public double3 xzz => new double3(x, z, z);

        /// <summary>
        /// Returns double3.rbb swizzling (equivalent to double3.xzz).
        /// </summary>
        public double3 rbb => new double3(x, z, z);

        /// <summary>
        /// Returns double3.xzzx swizzling.
        /// </summary>
        public double4 xzzx => new double4(x, z, z, x);

        /// <summary>
        /// Returns double3.rbbr swizzling (equivalent to double3.xzzx).
        /// </summary>
        public double4 rbbr => new double4(x, z, z, x);

        /// <summary>
        /// Returns double3.xzzy swizzling.
        /// </summary>
        public double4 xzzy => new double4(x, z, z, y);

        /// <summary>
        /// Returns double3.rbbg swizzling (equivalent to double3.xzzy).
        /// </summary>
        public double4 rbbg => new double4(x, z, z, y);

        /// <summary>
        /// Returns double3.xzzz swizzling.
        /// </summary>
        public double4 xzzz => new double4(x, z, z, z);

        /// <summary>
        /// Returns double3.rbbb swizzling (equivalent to double3.xzzz).
        /// </summary>
        public double4 rbbb => new double4(x, z, z, z);

        /// <summary>
        /// Returns double3.yx swizzling.
        /// </summary>
        public double2 yx => new double2(y, x);

        /// <summary>
        /// Returns double3.gr swizzling (equivalent to double3.yx).
        /// </summary>
        public double2 gr => new double2(y, x);

        /// <summary>
        /// Returns double3.yxx swizzling.
        /// </summary>
        public double3 yxx => new double3(y, x, x);

        /// <summary>
        /// Returns double3.grr swizzling (equivalent to double3.yxx).
        /// </summary>
        public double3 grr => new double3(y, x, x);

        /// <summary>
        /// Returns double3.yxxx swizzling.
        /// </summary>
        public double4 yxxx => new double4(y, x, x, x);

        /// <summary>
        /// Returns double3.grrr swizzling (equivalent to double3.yxxx).
        /// </summary>
        public double4 grrr => new double4(y, x, x, x);

        /// <summary>
        /// Returns double3.yxxy swizzling.
        /// </summary>
        public double4 yxxy => new double4(y, x, x, y);

        /// <summary>
        /// Returns double3.grrg swizzling (equivalent to double3.yxxy).
        /// </summary>
        public double4 grrg => new double4(y, x, x, y);

        /// <summary>
        /// Returns double3.yxxz swizzling.
        /// </summary>
        public double4 yxxz => new double4(y, x, x, z);

        /// <summary>
        /// Returns double3.grrb swizzling (equivalent to double3.yxxz).
        /// </summary>
        public double4 grrb => new double4(y, x, x, z);

        /// <summary>
        /// Returns double3.yxy swizzling.
        /// </summary>
        public double3 yxy => new double3(y, x, y);

        /// <summary>
        /// Returns double3.grg swizzling (equivalent to double3.yxy).
        /// </summary>
        public double3 grg => new double3(y, x, y);

        /// <summary>
        /// Returns double3.yxyx swizzling.
        /// </summary>
        public double4 yxyx => new double4(y, x, y, x);

        /// <summary>
        /// Returns double3.grgr swizzling (equivalent to double3.yxyx).
        /// </summary>
        public double4 grgr => new double4(y, x, y, x);

        /// <summary>
        /// Returns double3.yxyy swizzling.
        /// </summary>
        public double4 yxyy => new double4(y, x, y, y);

        /// <summary>
        /// Returns double3.grgg swizzling (equivalent to double3.yxyy).
        /// </summary>
        public double4 grgg => new double4(y, x, y, y);

        /// <summary>
        /// Returns double3.yxyz swizzling.
        /// </summary>
        public double4 yxyz => new double4(y, x, y, z);

        /// <summary>
        /// Returns double3.grgb swizzling (equivalent to double3.yxyz).
        /// </summary>
        public double4 grgb => new double4(y, x, y, z);

        /// <summary>
        /// Returns double3.yxz swizzling.
        /// </summary>
        public double3 yxz => new double3(y, x, z);

        /// <summary>
        /// Returns double3.grb swizzling (equivalent to double3.yxz).
        /// </summary>
        public double3 grb => new double3(y, x, z);

        /// <summary>
        /// Returns double3.yxzx swizzling.
        /// </summary>
        public double4 yxzx => new double4(y, x, z, x);

        /// <summary>
        /// Returns double3.grbr swizzling (equivalent to double3.yxzx).
        /// </summary>
        public double4 grbr => new double4(y, x, z, x);

        /// <summary>
        /// Returns double3.yxzy swizzling.
        /// </summary>
        public double4 yxzy => new double4(y, x, z, y);

        /// <summary>
        /// Returns double3.grbg swizzling (equivalent to double3.yxzy).
        /// </summary>
        public double4 grbg => new double4(y, x, z, y);

        /// <summary>
        /// Returns double3.yxzz swizzling.
        /// </summary>
        public double4 yxzz => new double4(y, x, z, z);

        /// <summary>
        /// Returns double3.grbb swizzling (equivalent to double3.yxzz).
        /// </summary>
        public double4 grbb => new double4(y, x, z, z);

        /// <summary>
        /// Returns double3.yy swizzling.
        /// </summary>
        public double2 yy => new double2(y, y);

        /// <summary>
        /// Returns double3.gg swizzling (equivalent to double3.yy).
        /// </summary>
        public double2 gg => new double2(y, y);

        /// <summary>
        /// Returns double3.yyx swizzling.
        /// </summary>
        public double3 yyx => new double3(y, y, x);

        /// <summary>
        /// Returns double3.ggr swizzling (equivalent to double3.yyx).
        /// </summary>
        public double3 ggr => new double3(y, y, x);

        /// <summary>
        /// Returns double3.yyxx swizzling.
        /// </summary>
        public double4 yyxx => new double4(y, y, x, x);

        /// <summary>
        /// Returns double3.ggrr swizzling (equivalent to double3.yyxx).
        /// </summary>
        public double4 ggrr => new double4(y, y, x, x);

        /// <summary>
        /// Returns double3.yyxy swizzling.
        /// </summary>
        public double4 yyxy => new double4(y, y, x, y);

        /// <summary>
        /// Returns double3.ggrg swizzling (equivalent to double3.yyxy).
        /// </summary>
        public double4 ggrg => new double4(y, y, x, y);

        /// <summary>
        /// Returns double3.yyxz swizzling.
        /// </summary>
        public double4 yyxz => new double4(y, y, x, z);

        /// <summary>
        /// Returns double3.ggrb swizzling (equivalent to double3.yyxz).
        /// </summary>
        public double4 ggrb => new double4(y, y, x, z);

        /// <summary>
        /// Returns double3.yyy swizzling.
        /// </summary>
        public double3 yyy => new double3(y, y, y);

        /// <summary>
        /// Returns double3.ggg swizzling (equivalent to double3.yyy).
        /// </summary>
        public double3 ggg => new double3(y, y, y);

        /// <summary>
        /// Returns double3.yyyx swizzling.
        /// </summary>
        public double4 yyyx => new double4(y, y, y, x);

        /// <summary>
        /// Returns double3.gggr swizzling (equivalent to double3.yyyx).
        /// </summary>
        public double4 gggr => new double4(y, y, y, x);

        /// <summary>
        /// Returns double3.yyyy swizzling.
        /// </summary>
        public double4 yyyy => new double4(y, y, y, y);

        /// <summary>
        /// Returns double3.gggg swizzling (equivalent to double3.yyyy).
        /// </summary>
        public double4 gggg => new double4(y, y, y, y);

        /// <summary>
        /// Returns double3.yyyz swizzling.
        /// </summary>
        public double4 yyyz => new double4(y, y, y, z);

        /// <summary>
        /// Returns double3.gggb swizzling (equivalent to double3.yyyz).
        /// </summary>
        public double4 gggb => new double4(y, y, y, z);

        /// <summary>
        /// Returns double3.yyz swizzling.
        /// </summary>
        public double3 yyz => new double3(y, y, z);

        /// <summary>
        /// Returns double3.ggb swizzling (equivalent to double3.yyz).
        /// </summary>
        public double3 ggb => new double3(y, y, z);

        /// <summary>
        /// Returns double3.yyzx swizzling.
        /// </summary>
        public double4 yyzx => new double4(y, y, z, x);

        /// <summary>
        /// Returns double3.ggbr swizzling (equivalent to double3.yyzx).
        /// </summary>
        public double4 ggbr => new double4(y, y, z, x);

        /// <summary>
        /// Returns double3.yyzy swizzling.
        /// </summary>
        public double4 yyzy => new double4(y, y, z, y);

        /// <summary>
        /// Returns double3.ggbg swizzling (equivalent to double3.yyzy).
        /// </summary>
        public double4 ggbg => new double4(y, y, z, y);

        /// <summary>
        /// Returns double3.yyzz swizzling.
        /// </summary>
        public double4 yyzz => new double4(y, y, z, z);

        /// <summary>
        /// Returns double3.ggbb swizzling (equivalent to double3.yyzz).
        /// </summary>
        public double4 ggbb => new double4(y, y, z, z);

        /// <summary>
        /// Returns double3.yz swizzling.
        /// </summary>
        public double2 yz => new double2(y, z);

        /// <summary>
        /// Returns double3.gb swizzling (equivalent to double3.yz).
        /// </summary>
        public double2 gb => new double2(y, z);

        /// <summary>
        /// Returns double3.yzx swizzling.
        /// </summary>
        public double3 yzx => new double3(y, z, x);

        /// <summary>
        /// Returns double3.gbr swizzling (equivalent to double3.yzx).
        /// </summary>
        public double3 gbr => new double3(y, z, x);

        /// <summary>
        /// Returns double3.yzxx swizzling.
        /// </summary>
        public double4 yzxx => new double4(y, z, x, x);

        /// <summary>
        /// Returns double3.gbrr swizzling (equivalent to double3.yzxx).
        /// </summary>
        public double4 gbrr => new double4(y, z, x, x);

        /// <summary>
        /// Returns double3.yzxy swizzling.
        /// </summary>
        public double4 yzxy => new double4(y, z, x, y);

        /// <summary>
        /// Returns double3.gbrg swizzling (equivalent to double3.yzxy).
        /// </summary>
        public double4 gbrg => new double4(y, z, x, y);

        /// <summary>
        /// Returns double3.yzxz swizzling.
        /// </summary>
        public double4 yzxz => new double4(y, z, x, z);

        /// <summary>
        /// Returns double3.gbrb swizzling (equivalent to double3.yzxz).
        /// </summary>
        public double4 gbrb => new double4(y, z, x, z);

        /// <summary>
        /// Returns double3.yzy swizzling.
        /// </summary>
        public double3 yzy => new double3(y, z, y);

        /// <summary>
        /// Returns double3.gbg swizzling (equivalent to double3.yzy).
        /// </summary>
        public double3 gbg => new double3(y, z, y);

        /// <summary>
        /// Returns double3.yzyx swizzling.
        /// </summary>
        public double4 yzyx => new double4(y, z, y, x);

        /// <summary>
        /// Returns double3.gbgr swizzling (equivalent to double3.yzyx).
        /// </summary>
        public double4 gbgr => new double4(y, z, y, x);

        /// <summary>
        /// Returns double3.yzyy swizzling.
        /// </summary>
        public double4 yzyy => new double4(y, z, y, y);

        /// <summary>
        /// Returns double3.gbgg swizzling (equivalent to double3.yzyy).
        /// </summary>
        public double4 gbgg => new double4(y, z, y, y);

        /// <summary>
        /// Returns double3.yzyz swizzling.
        /// </summary>
        public double4 yzyz => new double4(y, z, y, z);

        /// <summary>
        /// Returns double3.gbgb swizzling (equivalent to double3.yzyz).
        /// </summary>
        public double4 gbgb => new double4(y, z, y, z);

        /// <summary>
        /// Returns double3.yzz swizzling.
        /// </summary>
        public double3 yzz => new double3(y, z, z);

        /// <summary>
        /// Returns double3.gbb swizzling (equivalent to double3.yzz).
        /// </summary>
        public double3 gbb => new double3(y, z, z);

        /// <summary>
        /// Returns double3.yzzx swizzling.
        /// </summary>
        public double4 yzzx => new double4(y, z, z, x);

        /// <summary>
        /// Returns double3.gbbr swizzling (equivalent to double3.yzzx).
        /// </summary>
        public double4 gbbr => new double4(y, z, z, x);

        /// <summary>
        /// Returns double3.yzzy swizzling.
        /// </summary>
        public double4 yzzy => new double4(y, z, z, y);

        /// <summary>
        /// Returns double3.gbbg swizzling (equivalent to double3.yzzy).
        /// </summary>
        public double4 gbbg => new double4(y, z, z, y);

        /// <summary>
        /// Returns double3.yzzz swizzling.
        /// </summary>
        public double4 yzzz => new double4(y, z, z, z);

        /// <summary>
        /// Returns double3.gbbb swizzling (equivalent to double3.yzzz).
        /// </summary>
        public double4 gbbb => new double4(y, z, z, z);

        /// <summary>
        /// Returns double3.zx swizzling.
        /// </summary>
        public double2 zx => new double2(z, x);

        /// <summary>
        /// Returns double3.br swizzling (equivalent to double3.zx).
        /// </summary>
        public double2 br => new double2(z, x);

        /// <summary>
        /// Returns double3.zxx swizzling.
        /// </summary>
        public double3 zxx => new double3(z, x, x);

        /// <summary>
        /// Returns double3.brr swizzling (equivalent to double3.zxx).
        /// </summary>
        public double3 brr => new double3(z, x, x);

        /// <summary>
        /// Returns double3.zxxx swizzling.
        /// </summary>
        public double4 zxxx => new double4(z, x, x, x);

        /// <summary>
        /// Returns double3.brrr swizzling (equivalent to double3.zxxx).
        /// </summary>
        public double4 brrr => new double4(z, x, x, x);

        /// <summary>
        /// Returns double3.zxxy swizzling.
        /// </summary>
        public double4 zxxy => new double4(z, x, x, y);

        /// <summary>
        /// Returns double3.brrg swizzling (equivalent to double3.zxxy).
        /// </summary>
        public double4 brrg => new double4(z, x, x, y);

        /// <summary>
        /// Returns double3.zxxz swizzling.
        /// </summary>
        public double4 zxxz => new double4(z, x, x, z);

        /// <summary>
        /// Returns double3.brrb swizzling (equivalent to double3.zxxz).
        /// </summary>
        public double4 brrb => new double4(z, x, x, z);

        /// <summary>
        /// Returns double3.zxy swizzling.
        /// </summary>
        public double3 zxy => new double3(z, x, y);

        /// <summary>
        /// Returns double3.brg swizzling (equivalent to double3.zxy).
        /// </summary>
        public double3 brg => new double3(z, x, y);

        /// <summary>
        /// Returns double3.zxyx swizzling.
        /// </summary>
        public double4 zxyx => new double4(z, x, y, x);

        /// <summary>
        /// Returns double3.brgr swizzling (equivalent to double3.zxyx).
        /// </summary>
        public double4 brgr => new double4(z, x, y, x);

        /// <summary>
        /// Returns double3.zxyy swizzling.
        /// </summary>
        public double4 zxyy => new double4(z, x, y, y);

        /// <summary>
        /// Returns double3.brgg swizzling (equivalent to double3.zxyy).
        /// </summary>
        public double4 brgg => new double4(z, x, y, y);

        /// <summary>
        /// Returns double3.zxyz swizzling.
        /// </summary>
        public double4 zxyz => new double4(z, x, y, z);

        /// <summary>
        /// Returns double3.brgb swizzling (equivalent to double3.zxyz).
        /// </summary>
        public double4 brgb => new double4(z, x, y, z);

        /// <summary>
        /// Returns double3.zxz swizzling.
        /// </summary>
        public double3 zxz => new double3(z, x, z);

        /// <summary>
        /// Returns double3.brb swizzling (equivalent to double3.zxz).
        /// </summary>
        public double3 brb => new double3(z, x, z);

        /// <summary>
        /// Returns double3.zxzx swizzling.
        /// </summary>
        public double4 zxzx => new double4(z, x, z, x);

        /// <summary>
        /// Returns double3.brbr swizzling (equivalent to double3.zxzx).
        /// </summary>
        public double4 brbr => new double4(z, x, z, x);

        /// <summary>
        /// Returns double3.zxzy swizzling.
        /// </summary>
        public double4 zxzy => new double4(z, x, z, y);

        /// <summary>
        /// Returns double3.brbg swizzling (equivalent to double3.zxzy).
        /// </summary>
        public double4 brbg => new double4(z, x, z, y);

        /// <summary>
        /// Returns double3.zxzz swizzling.
        /// </summary>
        public double4 zxzz => new double4(z, x, z, z);

        /// <summary>
        /// Returns double3.brbb swizzling (equivalent to double3.zxzz).
        /// </summary>
        public double4 brbb => new double4(z, x, z, z);

        /// <summary>
        /// Returns double3.zy swizzling.
        /// </summary>
        public double2 zy => new double2(z, y);

        /// <summary>
        /// Returns double3.bg swizzling (equivalent to double3.zy).
        /// </summary>
        public double2 bg => new double2(z, y);

        /// <summary>
        /// Returns double3.zyx swizzling.
        /// </summary>
        public double3 zyx => new double3(z, y, x);

        /// <summary>
        /// Returns double3.bgr swizzling (equivalent to double3.zyx).
        /// </summary>
        public double3 bgr => new double3(z, y, x);

        /// <summary>
        /// Returns double3.zyxx swizzling.
        /// </summary>
        public double4 zyxx => new double4(z, y, x, x);

        /// <summary>
        /// Returns double3.bgrr swizzling (equivalent to double3.zyxx).
        /// </summary>
        public double4 bgrr => new double4(z, y, x, x);

        /// <summary>
        /// Returns double3.zyxy swizzling.
        /// </summary>
        public double4 zyxy => new double4(z, y, x, y);

        /// <summary>
        /// Returns double3.bgrg swizzling (equivalent to double3.zyxy).
        /// </summary>
        public double4 bgrg => new double4(z, y, x, y);

        /// <summary>
        /// Returns double3.zyxz swizzling.
        /// </summary>
        public double4 zyxz => new double4(z, y, x, z);

        /// <summary>
        /// Returns double3.bgrb swizzling (equivalent to double3.zyxz).
        /// </summary>
        public double4 bgrb => new double4(z, y, x, z);

        /// <summary>
        /// Returns double3.zyy swizzling.
        /// </summary>
        public double3 zyy => new double3(z, y, y);

        /// <summary>
        /// Returns double3.bgg swizzling (equivalent to double3.zyy).
        /// </summary>
        public double3 bgg => new double3(z, y, y);

        /// <summary>
        /// Returns double3.zyyx swizzling.
        /// </summary>
        public double4 zyyx => new double4(z, y, y, x);

        /// <summary>
        /// Returns double3.bggr swizzling (equivalent to double3.zyyx).
        /// </summary>
        public double4 bggr => new double4(z, y, y, x);

        /// <summary>
        /// Returns double3.zyyy swizzling.
        /// </summary>
        public double4 zyyy => new double4(z, y, y, y);

        /// <summary>
        /// Returns double3.bggg swizzling (equivalent to double3.zyyy).
        /// </summary>
        public double4 bggg => new double4(z, y, y, y);

        /// <summary>
        /// Returns double3.zyyz swizzling.
        /// </summary>
        public double4 zyyz => new double4(z, y, y, z);

        /// <summary>
        /// Returns double3.bggb swizzling (equivalent to double3.zyyz).
        /// </summary>
        public double4 bggb => new double4(z, y, y, z);

        /// <summary>
        /// Returns double3.zyz swizzling.
        /// </summary>
        public double3 zyz => new double3(z, y, z);

        /// <summary>
        /// Returns double3.bgb swizzling (equivalent to double3.zyz).
        /// </summary>
        public double3 bgb => new double3(z, y, z);

        /// <summary>
        /// Returns double3.zyzx swizzling.
        /// </summary>
        public double4 zyzx => new double4(z, y, z, x);

        /// <summary>
        /// Returns double3.bgbr swizzling (equivalent to double3.zyzx).
        /// </summary>
        public double4 bgbr => new double4(z, y, z, x);

        /// <summary>
        /// Returns double3.zyzy swizzling.
        /// </summary>
        public double4 zyzy => new double4(z, y, z, y);

        /// <summary>
        /// Returns double3.bgbg swizzling (equivalent to double3.zyzy).
        /// </summary>
        public double4 bgbg => new double4(z, y, z, y);

        /// <summary>
        /// Returns double3.zyzz swizzling.
        /// </summary>
        public double4 zyzz => new double4(z, y, z, z);

        /// <summary>
        /// Returns double3.bgbb swizzling (equivalent to double3.zyzz).
        /// </summary>
        public double4 bgbb => new double4(z, y, z, z);

        /// <summary>
        /// Returns double3.zz swizzling.
        /// </summary>
        public double2 zz => new double2(z, z);

        /// <summary>
        /// Returns double3.bb swizzling (equivalent to double3.zz).
        /// </summary>
        public double2 bb => new double2(z, z);

        /// <summary>
        /// Returns double3.zzx swizzling.
        /// </summary>
        public double3 zzx => new double3(z, z, x);

        /// <summary>
        /// Returns double3.bbr swizzling (equivalent to double3.zzx).
        /// </summary>
        public double3 bbr => new double3(z, z, x);

        /// <summary>
        /// Returns double3.zzxx swizzling.
        /// </summary>
        public double4 zzxx => new double4(z, z, x, x);

        /// <summary>
        /// Returns double3.bbrr swizzling (equivalent to double3.zzxx).
        /// </summary>
        public double4 bbrr => new double4(z, z, x, x);

        /// <summary>
        /// Returns double3.zzxy swizzling.
        /// </summary>
        public double4 zzxy => new double4(z, z, x, y);

        /// <summary>
        /// Returns double3.bbrg swizzling (equivalent to double3.zzxy).
        /// </summary>
        public double4 bbrg => new double4(z, z, x, y);

        /// <summary>
        /// Returns double3.zzxz swizzling.
        /// </summary>
        public double4 zzxz => new double4(z, z, x, z);

        /// <summary>
        /// Returns double3.bbrb swizzling (equivalent to double3.zzxz).
        /// </summary>
        public double4 bbrb => new double4(z, z, x, z);

        /// <summary>
        /// Returns double3.zzy swizzling.
        /// </summary>
        public double3 zzy => new double3(z, z, y);

        /// <summary>
        /// Returns double3.bbg swizzling (equivalent to double3.zzy).
        /// </summary>
        public double3 bbg => new double3(z, z, y);

        /// <summary>
        /// Returns double3.zzyx swizzling.
        /// </summary>
        public double4 zzyx => new double4(z, z, y, x);

        /// <summary>
        /// Returns double3.bbgr swizzling (equivalent to double3.zzyx).
        /// </summary>
        public double4 bbgr => new double4(z, z, y, x);

        /// <summary>
        /// Returns double3.zzyy swizzling.
        /// </summary>
        public double4 zzyy => new double4(z, z, y, y);

        /// <summary>
        /// Returns double3.bbgg swizzling (equivalent to double3.zzyy).
        /// </summary>
        public double4 bbgg => new double4(z, z, y, y);

        /// <summary>
        /// Returns double3.zzyz swizzling.
        /// </summary>
        public double4 zzyz => new double4(z, z, y, z);

        /// <summary>
        /// Returns double3.bbgb swizzling (equivalent to double3.zzyz).
        /// </summary>
        public double4 bbgb => new double4(z, z, y, z);

        /// <summary>
        /// Returns double3.zzz swizzling.
        /// </summary>
        public double3 zzz => new double3(z, z, z);

        /// <summary>
        /// Returns double3.bbb swizzling (equivalent to double3.zzz).
        /// </summary>
        public double3 bbb => new double3(z, z, z);

        /// <summary>
        /// Returns double3.zzzx swizzling.
        /// </summary>
        public double4 zzzx => new double4(z, z, z, x);

        /// <summary>
        /// Returns double3.bbbr swizzling (equivalent to double3.zzzx).
        /// </summary>
        public double4 bbbr => new double4(z, z, z, x);

        /// <summary>
        /// Returns double3.zzzy swizzling.
        /// </summary>
        public double4 zzzy => new double4(z, z, z, y);

        /// <summary>
        /// Returns double3.bbbg swizzling (equivalent to double3.zzzy).
        /// </summary>
        public double4 bbbg => new double4(z, z, z, y);

        /// <summary>
        /// Returns double3.zzzz swizzling.
        /// </summary>
        public double4 zzzz => new double4(z, z, z, z);

        /// <summary>
        /// Returns double3.bbbb swizzling (equivalent to double3.zzzz).
        /// </summary>
        public double4 bbbb => new double4(z, z, z, z);

        #endregion

    }
}
