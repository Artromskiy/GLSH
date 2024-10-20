using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type int with 2 components, used for implementing swizzling for int2.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_ivec2
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

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_ivec2.
        /// </summary>
        internal swizzle_ivec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns int2.xx swizzling.
        /// </summary>
        public int2 xx => new int2(x, x);

        /// <summary>
        /// Returns int2.rr swizzling (equivalent to int2.xx).
        /// </summary>
        public int2 rr => new int2(x, x);

        /// <summary>
        /// Returns int2.xxx swizzling.
        /// </summary>
        public int3 xxx => new int3(x, x, x);

        /// <summary>
        /// Returns int2.rrr swizzling (equivalent to int2.xxx).
        /// </summary>
        public int3 rrr => new int3(x, x, x);

        /// <summary>
        /// Returns int2.xxxx swizzling.
        /// </summary>
        public int4 xxxx => new int4(x, x, x, x);

        /// <summary>
        /// Returns int2.rrrr swizzling (equivalent to int2.xxxx).
        /// </summary>
        public int4 rrrr => new int4(x, x, x, x);

        /// <summary>
        /// Returns int2.xxxy swizzling.
        /// </summary>
        public int4 xxxy => new int4(x, x, x, y);

        /// <summary>
        /// Returns int2.rrrg swizzling (equivalent to int2.xxxy).
        /// </summary>
        public int4 rrrg => new int4(x, x, x, y);

        /// <summary>
        /// Returns int2.xxy swizzling.
        /// </summary>
        public int3 xxy => new int3(x, x, y);

        /// <summary>
        /// Returns int2.rrg swizzling (equivalent to int2.xxy).
        /// </summary>
        public int3 rrg => new int3(x, x, y);

        /// <summary>
        /// Returns int2.xxyx swizzling.
        /// </summary>
        public int4 xxyx => new int4(x, x, y, x);

        /// <summary>
        /// Returns int2.rrgr swizzling (equivalent to int2.xxyx).
        /// </summary>
        public int4 rrgr => new int4(x, x, y, x);

        /// <summary>
        /// Returns int2.xxyy swizzling.
        /// </summary>
        public int4 xxyy => new int4(x, x, y, y);

        /// <summary>
        /// Returns int2.rrgg swizzling (equivalent to int2.xxyy).
        /// </summary>
        public int4 rrgg => new int4(x, x, y, y);

        /// <summary>
        /// Returns int2.xy swizzling.
        /// </summary>
        public int2 xy => new int2(x, y);

        /// <summary>
        /// Returns int2.rg swizzling (equivalent to int2.xy).
        /// </summary>
        public int2 rg => new int2(x, y);

        /// <summary>
        /// Returns int2.xyx swizzling.
        /// </summary>
        public int3 xyx => new int3(x, y, x);

        /// <summary>
        /// Returns int2.rgr swizzling (equivalent to int2.xyx).
        /// </summary>
        public int3 rgr => new int3(x, y, x);

        /// <summary>
        /// Returns int2.xyxx swizzling.
        /// </summary>
        public int4 xyxx => new int4(x, y, x, x);

        /// <summary>
        /// Returns int2.rgrr swizzling (equivalent to int2.xyxx).
        /// </summary>
        public int4 rgrr => new int4(x, y, x, x);

        /// <summary>
        /// Returns int2.xyxy swizzling.
        /// </summary>
        public int4 xyxy => new int4(x, y, x, y);

        /// <summary>
        /// Returns int2.rgrg swizzling (equivalent to int2.xyxy).
        /// </summary>
        public int4 rgrg => new int4(x, y, x, y);

        /// <summary>
        /// Returns int2.xyy swizzling.
        /// </summary>
        public int3 xyy => new int3(x, y, y);

        /// <summary>
        /// Returns int2.rgg swizzling (equivalent to int2.xyy).
        /// </summary>
        public int3 rgg => new int3(x, y, y);

        /// <summary>
        /// Returns int2.xyyx swizzling.
        /// </summary>
        public int4 xyyx => new int4(x, y, y, x);

        /// <summary>
        /// Returns int2.rggr swizzling (equivalent to int2.xyyx).
        /// </summary>
        public int4 rggr => new int4(x, y, y, x);

        /// <summary>
        /// Returns int2.xyyy swizzling.
        /// </summary>
        public int4 xyyy => new int4(x, y, y, y);

        /// <summary>
        /// Returns int2.rggg swizzling (equivalent to int2.xyyy).
        /// </summary>
        public int4 rggg => new int4(x, y, y, y);

        /// <summary>
        /// Returns int2.yx swizzling.
        /// </summary>
        public int2 yx => new int2(y, x);

        /// <summary>
        /// Returns int2.gr swizzling (equivalent to int2.yx).
        /// </summary>
        public int2 gr => new int2(y, x);

        /// <summary>
        /// Returns int2.yxx swizzling.
        /// </summary>
        public int3 yxx => new int3(y, x, x);

        /// <summary>
        /// Returns int2.grr swizzling (equivalent to int2.yxx).
        /// </summary>
        public int3 grr => new int3(y, x, x);

        /// <summary>
        /// Returns int2.yxxx swizzling.
        /// </summary>
        public int4 yxxx => new int4(y, x, x, x);

        /// <summary>
        /// Returns int2.grrr swizzling (equivalent to int2.yxxx).
        /// </summary>
        public int4 grrr => new int4(y, x, x, x);

        /// <summary>
        /// Returns int2.yxxy swizzling.
        /// </summary>
        public int4 yxxy => new int4(y, x, x, y);

        /// <summary>
        /// Returns int2.grrg swizzling (equivalent to int2.yxxy).
        /// </summary>
        public int4 grrg => new int4(y, x, x, y);

        /// <summary>
        /// Returns int2.yxy swizzling.
        /// </summary>
        public int3 yxy => new int3(y, x, y);

        /// <summary>
        /// Returns int2.grg swizzling (equivalent to int2.yxy).
        /// </summary>
        public int3 grg => new int3(y, x, y);

        /// <summary>
        /// Returns int2.yxyx swizzling.
        /// </summary>
        public int4 yxyx => new int4(y, x, y, x);

        /// <summary>
        /// Returns int2.grgr swizzling (equivalent to int2.yxyx).
        /// </summary>
        public int4 grgr => new int4(y, x, y, x);

        /// <summary>
        /// Returns int2.yxyy swizzling.
        /// </summary>
        public int4 yxyy => new int4(y, x, y, y);

        /// <summary>
        /// Returns int2.grgg swizzling (equivalent to int2.yxyy).
        /// </summary>
        public int4 grgg => new int4(y, x, y, y);

        /// <summary>
        /// Returns int2.yy swizzling.
        /// </summary>
        public int2 yy => new int2(y, y);

        /// <summary>
        /// Returns int2.gg swizzling (equivalent to int2.yy).
        /// </summary>
        public int2 gg => new int2(y, y);

        /// <summary>
        /// Returns int2.yyx swizzling.
        /// </summary>
        public int3 yyx => new int3(y, y, x);

        /// <summary>
        /// Returns int2.ggr swizzling (equivalent to int2.yyx).
        /// </summary>
        public int3 ggr => new int3(y, y, x);

        /// <summary>
        /// Returns int2.yyxx swizzling.
        /// </summary>
        public int4 yyxx => new int4(y, y, x, x);

        /// <summary>
        /// Returns int2.ggrr swizzling (equivalent to int2.yyxx).
        /// </summary>
        public int4 ggrr => new int4(y, y, x, x);

        /// <summary>
        /// Returns int2.yyxy swizzling.
        /// </summary>
        public int4 yyxy => new int4(y, y, x, y);

        /// <summary>
        /// Returns int2.ggrg swizzling (equivalent to int2.yyxy).
        /// </summary>
        public int4 ggrg => new int4(y, y, x, y);

        /// <summary>
        /// Returns int2.yyy swizzling.
        /// </summary>
        public int3 yyy => new int3(y, y, y);

        /// <summary>
        /// Returns int2.ggg swizzling (equivalent to int2.yyy).
        /// </summary>
        public int3 ggg => new int3(y, y, y);

        /// <summary>
        /// Returns int2.yyyx swizzling.
        /// </summary>
        public int4 yyyx => new int4(y, y, y, x);

        /// <summary>
        /// Returns int2.gggr swizzling (equivalent to int2.yyyx).
        /// </summary>
        public int4 gggr => new int4(y, y, y, x);

        /// <summary>
        /// Returns int2.yyyy swizzling.
        /// </summary>
        public int4 yyyy => new int4(y, y, y, y);

        /// <summary>
        /// Returns int2.gggg swizzling (equivalent to int2.yyyy).
        /// </summary>
        public int4 gggg => new int4(y, y, y, y);

        #endregion

    }
}
