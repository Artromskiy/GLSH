using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type double with 2 components, used for implementing swizzling for double2.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_dvec2
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

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_dvec2.
        /// </summary>
        internal swizzle_dvec2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns double2.xx swizzling.
        /// </summary>
        public double2 xx => new double2(x, x);

        /// <summary>
        /// Returns double2.rr swizzling (equivalent to double2.xx).
        /// </summary>
        public double2 rr => new double2(x, x);

        /// <summary>
        /// Returns double2.xxx swizzling.
        /// </summary>
        public double3 xxx => new double3(x, x, x);

        /// <summary>
        /// Returns double2.rrr swizzling (equivalent to double2.xxx).
        /// </summary>
        public double3 rrr => new double3(x, x, x);

        /// <summary>
        /// Returns double2.xxxx swizzling.
        /// </summary>
        public double4 xxxx => new double4(x, x, x, x);

        /// <summary>
        /// Returns double2.rrrr swizzling (equivalent to double2.xxxx).
        /// </summary>
        public double4 rrrr => new double4(x, x, x, x);

        /// <summary>
        /// Returns double2.xxxy swizzling.
        /// </summary>
        public double4 xxxy => new double4(x, x, x, y);

        /// <summary>
        /// Returns double2.rrrg swizzling (equivalent to double2.xxxy).
        /// </summary>
        public double4 rrrg => new double4(x, x, x, y);

        /// <summary>
        /// Returns double2.xxy swizzling.
        /// </summary>
        public double3 xxy => new double3(x, x, y);

        /// <summary>
        /// Returns double2.rrg swizzling (equivalent to double2.xxy).
        /// </summary>
        public double3 rrg => new double3(x, x, y);

        /// <summary>
        /// Returns double2.xxyx swizzling.
        /// </summary>
        public double4 xxyx => new double4(x, x, y, x);

        /// <summary>
        /// Returns double2.rrgr swizzling (equivalent to double2.xxyx).
        /// </summary>
        public double4 rrgr => new double4(x, x, y, x);

        /// <summary>
        /// Returns double2.xxyy swizzling.
        /// </summary>
        public double4 xxyy => new double4(x, x, y, y);

        /// <summary>
        /// Returns double2.rrgg swizzling (equivalent to double2.xxyy).
        /// </summary>
        public double4 rrgg => new double4(x, x, y, y);

        /// <summary>
        /// Returns double2.xy swizzling.
        /// </summary>
        public double2 xy => new double2(x, y);

        /// <summary>
        /// Returns double2.rg swizzling (equivalent to double2.xy).
        /// </summary>
        public double2 rg => new double2(x, y);

        /// <summary>
        /// Returns double2.xyx swizzling.
        /// </summary>
        public double3 xyx => new double3(x, y, x);

        /// <summary>
        /// Returns double2.rgr swizzling (equivalent to double2.xyx).
        /// </summary>
        public double3 rgr => new double3(x, y, x);

        /// <summary>
        /// Returns double2.xyxx swizzling.
        /// </summary>
        public double4 xyxx => new double4(x, y, x, x);

        /// <summary>
        /// Returns double2.rgrr swizzling (equivalent to double2.xyxx).
        /// </summary>
        public double4 rgrr => new double4(x, y, x, x);

        /// <summary>
        /// Returns double2.xyxy swizzling.
        /// </summary>
        public double4 xyxy => new double4(x, y, x, y);

        /// <summary>
        /// Returns double2.rgrg swizzling (equivalent to double2.xyxy).
        /// </summary>
        public double4 rgrg => new double4(x, y, x, y);

        /// <summary>
        /// Returns double2.xyy swizzling.
        /// </summary>
        public double3 xyy => new double3(x, y, y);

        /// <summary>
        /// Returns double2.rgg swizzling (equivalent to double2.xyy).
        /// </summary>
        public double3 rgg => new double3(x, y, y);

        /// <summary>
        /// Returns double2.xyyx swizzling.
        /// </summary>
        public double4 xyyx => new double4(x, y, y, x);

        /// <summary>
        /// Returns double2.rggr swizzling (equivalent to double2.xyyx).
        /// </summary>
        public double4 rggr => new double4(x, y, y, x);

        /// <summary>
        /// Returns double2.xyyy swizzling.
        /// </summary>
        public double4 xyyy => new double4(x, y, y, y);

        /// <summary>
        /// Returns double2.rggg swizzling (equivalent to double2.xyyy).
        /// </summary>
        public double4 rggg => new double4(x, y, y, y);

        /// <summary>
        /// Returns double2.yx swizzling.
        /// </summary>
        public double2 yx => new double2(y, x);

        /// <summary>
        /// Returns double2.gr swizzling (equivalent to double2.yx).
        /// </summary>
        public double2 gr => new double2(y, x);

        /// <summary>
        /// Returns double2.yxx swizzling.
        /// </summary>
        public double3 yxx => new double3(y, x, x);

        /// <summary>
        /// Returns double2.grr swizzling (equivalent to double2.yxx).
        /// </summary>
        public double3 grr => new double3(y, x, x);

        /// <summary>
        /// Returns double2.yxxx swizzling.
        /// </summary>
        public double4 yxxx => new double4(y, x, x, x);

        /// <summary>
        /// Returns double2.grrr swizzling (equivalent to double2.yxxx).
        /// </summary>
        public double4 grrr => new double4(y, x, x, x);

        /// <summary>
        /// Returns double2.yxxy swizzling.
        /// </summary>
        public double4 yxxy => new double4(y, x, x, y);

        /// <summary>
        /// Returns double2.grrg swizzling (equivalent to double2.yxxy).
        /// </summary>
        public double4 grrg => new double4(y, x, x, y);

        /// <summary>
        /// Returns double2.yxy swizzling.
        /// </summary>
        public double3 yxy => new double3(y, x, y);

        /// <summary>
        /// Returns double2.grg swizzling (equivalent to double2.yxy).
        /// </summary>
        public double3 grg => new double3(y, x, y);

        /// <summary>
        /// Returns double2.yxyx swizzling.
        /// </summary>
        public double4 yxyx => new double4(y, x, y, x);

        /// <summary>
        /// Returns double2.grgr swizzling (equivalent to double2.yxyx).
        /// </summary>
        public double4 grgr => new double4(y, x, y, x);

        /// <summary>
        /// Returns double2.yxyy swizzling.
        /// </summary>
        public double4 yxyy => new double4(y, x, y, y);

        /// <summary>
        /// Returns double2.grgg swizzling (equivalent to double2.yxyy).
        /// </summary>
        public double4 grgg => new double4(y, x, y, y);

        /// <summary>
        /// Returns double2.yy swizzling.
        /// </summary>
        public double2 yy => new double2(y, y);

        /// <summary>
        /// Returns double2.gg swizzling (equivalent to double2.yy).
        /// </summary>
        public double2 gg => new double2(y, y);

        /// <summary>
        /// Returns double2.yyx swizzling.
        /// </summary>
        public double3 yyx => new double3(y, y, x);

        /// <summary>
        /// Returns double2.ggr swizzling (equivalent to double2.yyx).
        /// </summary>
        public double3 ggr => new double3(y, y, x);

        /// <summary>
        /// Returns double2.yyxx swizzling.
        /// </summary>
        public double4 yyxx => new double4(y, y, x, x);

        /// <summary>
        /// Returns double2.ggrr swizzling (equivalent to double2.yyxx).
        /// </summary>
        public double4 ggrr => new double4(y, y, x, x);

        /// <summary>
        /// Returns double2.yyxy swizzling.
        /// </summary>
        public double4 yyxy => new double4(y, y, x, y);

        /// <summary>
        /// Returns double2.ggrg swizzling (equivalent to double2.yyxy).
        /// </summary>
        public double4 ggrg => new double4(y, y, x, y);

        /// <summary>
        /// Returns double2.yyy swizzling.
        /// </summary>
        public double3 yyy => new double3(y, y, y);

        /// <summary>
        /// Returns double2.ggg swizzling (equivalent to double2.yyy).
        /// </summary>
        public double3 ggg => new double3(y, y, y);

        /// <summary>
        /// Returns double2.yyyx swizzling.
        /// </summary>
        public double4 yyyx => new double4(y, y, y, x);

        /// <summary>
        /// Returns double2.gggr swizzling (equivalent to double2.yyyx).
        /// </summary>
        public double4 gggr => new double4(y, y, y, x);

        /// <summary>
        /// Returns double2.yyyy swizzling.
        /// </summary>
        public double4 yyyy => new double4(y, y, y, y);

        /// <summary>
        /// Returns double2.gggg swizzling (equivalent to double2.yyyy).
        /// </summary>
        public double4 gggg => new double4(y, y, y, y);

        #endregion

    }
}
