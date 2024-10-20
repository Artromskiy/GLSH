using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type bool with 2 components, used for implementing swizzling for bool2.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_bvec2
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

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_bvec2.
        /// </summary>
        internal swizzle_bvec2(bool x, bool y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns bool2.xx swizzling.
        /// </summary>
        public bool2 xx => new bool2(x, x);

        /// <summary>
        /// Returns bool2.rr swizzling (equivalent to bool2.xx).
        /// </summary>
        public bool2 rr => new bool2(x, x);

        /// <summary>
        /// Returns bool2.xxx swizzling.
        /// </summary>
        public bool3 xxx => new bool3(x, x, x);

        /// <summary>
        /// Returns bool2.rrr swizzling (equivalent to bool2.xxx).
        /// </summary>
        public bool3 rrr => new bool3(x, x, x);

        /// <summary>
        /// Returns bool2.xxxx swizzling.
        /// </summary>
        public bool4 xxxx => new bool4(x, x, x, x);

        /// <summary>
        /// Returns bool2.rrrr swizzling (equivalent to bool2.xxxx).
        /// </summary>
        public bool4 rrrr => new bool4(x, x, x, x);

        /// <summary>
        /// Returns bool2.xxxy swizzling.
        /// </summary>
        public bool4 xxxy => new bool4(x, x, x, y);

        /// <summary>
        /// Returns bool2.rrrg swizzling (equivalent to bool2.xxxy).
        /// </summary>
        public bool4 rrrg => new bool4(x, x, x, y);

        /// <summary>
        /// Returns bool2.xxy swizzling.
        /// </summary>
        public bool3 xxy => new bool3(x, x, y);

        /// <summary>
        /// Returns bool2.rrg swizzling (equivalent to bool2.xxy).
        /// </summary>
        public bool3 rrg => new bool3(x, x, y);

        /// <summary>
        /// Returns bool2.xxyx swizzling.
        /// </summary>
        public bool4 xxyx => new bool4(x, x, y, x);

        /// <summary>
        /// Returns bool2.rrgr swizzling (equivalent to bool2.xxyx).
        /// </summary>
        public bool4 rrgr => new bool4(x, x, y, x);

        /// <summary>
        /// Returns bool2.xxyy swizzling.
        /// </summary>
        public bool4 xxyy => new bool4(x, x, y, y);

        /// <summary>
        /// Returns bool2.rrgg swizzling (equivalent to bool2.xxyy).
        /// </summary>
        public bool4 rrgg => new bool4(x, x, y, y);

        /// <summary>
        /// Returns bool2.xy swizzling.
        /// </summary>
        public bool2 xy => new bool2(x, y);

        /// <summary>
        /// Returns bool2.rg swizzling (equivalent to bool2.xy).
        /// </summary>
        public bool2 rg => new bool2(x, y);

        /// <summary>
        /// Returns bool2.xyx swizzling.
        /// </summary>
        public bool3 xyx => new bool3(x, y, x);

        /// <summary>
        /// Returns bool2.rgr swizzling (equivalent to bool2.xyx).
        /// </summary>
        public bool3 rgr => new bool3(x, y, x);

        /// <summary>
        /// Returns bool2.xyxx swizzling.
        /// </summary>
        public bool4 xyxx => new bool4(x, y, x, x);

        /// <summary>
        /// Returns bool2.rgrr swizzling (equivalent to bool2.xyxx).
        /// </summary>
        public bool4 rgrr => new bool4(x, y, x, x);

        /// <summary>
        /// Returns bool2.xyxy swizzling.
        /// </summary>
        public bool4 xyxy => new bool4(x, y, x, y);

        /// <summary>
        /// Returns bool2.rgrg swizzling (equivalent to bool2.xyxy).
        /// </summary>
        public bool4 rgrg => new bool4(x, y, x, y);

        /// <summary>
        /// Returns bool2.xyy swizzling.
        /// </summary>
        public bool3 xyy => new bool3(x, y, y);

        /// <summary>
        /// Returns bool2.rgg swizzling (equivalent to bool2.xyy).
        /// </summary>
        public bool3 rgg => new bool3(x, y, y);

        /// <summary>
        /// Returns bool2.xyyx swizzling.
        /// </summary>
        public bool4 xyyx => new bool4(x, y, y, x);

        /// <summary>
        /// Returns bool2.rggr swizzling (equivalent to bool2.xyyx).
        /// </summary>
        public bool4 rggr => new bool4(x, y, y, x);

        /// <summary>
        /// Returns bool2.xyyy swizzling.
        /// </summary>
        public bool4 xyyy => new bool4(x, y, y, y);

        /// <summary>
        /// Returns bool2.rggg swizzling (equivalent to bool2.xyyy).
        /// </summary>
        public bool4 rggg => new bool4(x, y, y, y);

        /// <summary>
        /// Returns bool2.yx swizzling.
        /// </summary>
        public bool2 yx => new bool2(y, x);

        /// <summary>
        /// Returns bool2.gr swizzling (equivalent to bool2.yx).
        /// </summary>
        public bool2 gr => new bool2(y, x);

        /// <summary>
        /// Returns bool2.yxx swizzling.
        /// </summary>
        public bool3 yxx => new bool3(y, x, x);

        /// <summary>
        /// Returns bool2.grr swizzling (equivalent to bool2.yxx).
        /// </summary>
        public bool3 grr => new bool3(y, x, x);

        /// <summary>
        /// Returns bool2.yxxx swizzling.
        /// </summary>
        public bool4 yxxx => new bool4(y, x, x, x);

        /// <summary>
        /// Returns bool2.grrr swizzling (equivalent to bool2.yxxx).
        /// </summary>
        public bool4 grrr => new bool4(y, x, x, x);

        /// <summary>
        /// Returns bool2.yxxy swizzling.
        /// </summary>
        public bool4 yxxy => new bool4(y, x, x, y);

        /// <summary>
        /// Returns bool2.grrg swizzling (equivalent to bool2.yxxy).
        /// </summary>
        public bool4 grrg => new bool4(y, x, x, y);

        /// <summary>
        /// Returns bool2.yxy swizzling.
        /// </summary>
        public bool3 yxy => new bool3(y, x, y);

        /// <summary>
        /// Returns bool2.grg swizzling (equivalent to bool2.yxy).
        /// </summary>
        public bool3 grg => new bool3(y, x, y);

        /// <summary>
        /// Returns bool2.yxyx swizzling.
        /// </summary>
        public bool4 yxyx => new bool4(y, x, y, x);

        /// <summary>
        /// Returns bool2.grgr swizzling (equivalent to bool2.yxyx).
        /// </summary>
        public bool4 grgr => new bool4(y, x, y, x);

        /// <summary>
        /// Returns bool2.yxyy swizzling.
        /// </summary>
        public bool4 yxyy => new bool4(y, x, y, y);

        /// <summary>
        /// Returns bool2.grgg swizzling (equivalent to bool2.yxyy).
        /// </summary>
        public bool4 grgg => new bool4(y, x, y, y);

        /// <summary>
        /// Returns bool2.yy swizzling.
        /// </summary>
        public bool2 yy => new bool2(y, y);

        /// <summary>
        /// Returns bool2.gg swizzling (equivalent to bool2.yy).
        /// </summary>
        public bool2 gg => new bool2(y, y);

        /// <summary>
        /// Returns bool2.yyx swizzling.
        /// </summary>
        public bool3 yyx => new bool3(y, y, x);

        /// <summary>
        /// Returns bool2.ggr swizzling (equivalent to bool2.yyx).
        /// </summary>
        public bool3 ggr => new bool3(y, y, x);

        /// <summary>
        /// Returns bool2.yyxx swizzling.
        /// </summary>
        public bool4 yyxx => new bool4(y, y, x, x);

        /// <summary>
        /// Returns bool2.ggrr swizzling (equivalent to bool2.yyxx).
        /// </summary>
        public bool4 ggrr => new bool4(y, y, x, x);

        /// <summary>
        /// Returns bool2.yyxy swizzling.
        /// </summary>
        public bool4 yyxy => new bool4(y, y, x, y);

        /// <summary>
        /// Returns bool2.ggrg swizzling (equivalent to bool2.yyxy).
        /// </summary>
        public bool4 ggrg => new bool4(y, y, x, y);

        /// <summary>
        /// Returns bool2.yyy swizzling.
        /// </summary>
        public bool3 yyy => new bool3(y, y, y);

        /// <summary>
        /// Returns bool2.ggg swizzling (equivalent to bool2.yyy).
        /// </summary>
        public bool3 ggg => new bool3(y, y, y);

        /// <summary>
        /// Returns bool2.yyyx swizzling.
        /// </summary>
        public bool4 yyyx => new bool4(y, y, y, x);

        /// <summary>
        /// Returns bool2.gggr swizzling (equivalent to bool2.yyyx).
        /// </summary>
        public bool4 gggr => new bool4(y, y, y, x);

        /// <summary>
        /// Returns bool2.yyyy swizzling.
        /// </summary>
        public bool4 yyyy => new bool4(y, y, y, y);

        /// <summary>
        /// Returns bool2.gggg swizzling (equivalent to bool2.yyyy).
        /// </summary>
        public bool4 gggg => new bool4(y, y, y, y);

        #endregion

    }
}
