using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type uint with 2 components, used for implementing swizzling for uint2.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_uvec2
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

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_uvec2.
        /// </summary>
        internal swizzle_uvec2(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns uint2.xx swizzling.
        /// </summary>
        public uint2 xx => new uint2(x, x);

        /// <summary>
        /// Returns uint2.rr swizzling (equivalent to uint2.xx).
        /// </summary>
        public uint2 rr => new uint2(x, x);

        /// <summary>
        /// Returns uint2.xxx swizzling.
        /// </summary>
        public uint3 xxx => new uint3(x, x, x);

        /// <summary>
        /// Returns uint2.rrr swizzling (equivalent to uint2.xxx).
        /// </summary>
        public uint3 rrr => new uint3(x, x, x);

        /// <summary>
        /// Returns uint2.xxxx swizzling.
        /// </summary>
        public uint4 xxxx => new uint4(x, x, x, x);

        /// <summary>
        /// Returns uint2.rrrr swizzling (equivalent to uint2.xxxx).
        /// </summary>
        public uint4 rrrr => new uint4(x, x, x, x);

        /// <summary>
        /// Returns uint2.xxxy swizzling.
        /// </summary>
        public uint4 xxxy => new uint4(x, x, x, y);

        /// <summary>
        /// Returns uint2.rrrg swizzling (equivalent to uint2.xxxy).
        /// </summary>
        public uint4 rrrg => new uint4(x, x, x, y);

        /// <summary>
        /// Returns uint2.xxy swizzling.
        /// </summary>
        public uint3 xxy => new uint3(x, x, y);

        /// <summary>
        /// Returns uint2.rrg swizzling (equivalent to uint2.xxy).
        /// </summary>
        public uint3 rrg => new uint3(x, x, y);

        /// <summary>
        /// Returns uint2.xxyx swizzling.
        /// </summary>
        public uint4 xxyx => new uint4(x, x, y, x);

        /// <summary>
        /// Returns uint2.rrgr swizzling (equivalent to uint2.xxyx).
        /// </summary>
        public uint4 rrgr => new uint4(x, x, y, x);

        /// <summary>
        /// Returns uint2.xxyy swizzling.
        /// </summary>
        public uint4 xxyy => new uint4(x, x, y, y);

        /// <summary>
        /// Returns uint2.rrgg swizzling (equivalent to uint2.xxyy).
        /// </summary>
        public uint4 rrgg => new uint4(x, x, y, y);

        /// <summary>
        /// Returns uint2.xy swizzling.
        /// </summary>
        public uint2 xy => new uint2(x, y);

        /// <summary>
        /// Returns uint2.rg swizzling (equivalent to uint2.xy).
        /// </summary>
        public uint2 rg => new uint2(x, y);

        /// <summary>
        /// Returns uint2.xyx swizzling.
        /// </summary>
        public uint3 xyx => new uint3(x, y, x);

        /// <summary>
        /// Returns uint2.rgr swizzling (equivalent to uint2.xyx).
        /// </summary>
        public uint3 rgr => new uint3(x, y, x);

        /// <summary>
        /// Returns uint2.xyxx swizzling.
        /// </summary>
        public uint4 xyxx => new uint4(x, y, x, x);

        /// <summary>
        /// Returns uint2.rgrr swizzling (equivalent to uint2.xyxx).
        /// </summary>
        public uint4 rgrr => new uint4(x, y, x, x);

        /// <summary>
        /// Returns uint2.xyxy swizzling.
        /// </summary>
        public uint4 xyxy => new uint4(x, y, x, y);

        /// <summary>
        /// Returns uint2.rgrg swizzling (equivalent to uint2.xyxy).
        /// </summary>
        public uint4 rgrg => new uint4(x, y, x, y);

        /// <summary>
        /// Returns uint2.xyy swizzling.
        /// </summary>
        public uint3 xyy => new uint3(x, y, y);

        /// <summary>
        /// Returns uint2.rgg swizzling (equivalent to uint2.xyy).
        /// </summary>
        public uint3 rgg => new uint3(x, y, y);

        /// <summary>
        /// Returns uint2.xyyx swizzling.
        /// </summary>
        public uint4 xyyx => new uint4(x, y, y, x);

        /// <summary>
        /// Returns uint2.rggr swizzling (equivalent to uint2.xyyx).
        /// </summary>
        public uint4 rggr => new uint4(x, y, y, x);

        /// <summary>
        /// Returns uint2.xyyy swizzling.
        /// </summary>
        public uint4 xyyy => new uint4(x, y, y, y);

        /// <summary>
        /// Returns uint2.rggg swizzling (equivalent to uint2.xyyy).
        /// </summary>
        public uint4 rggg => new uint4(x, y, y, y);

        /// <summary>
        /// Returns uint2.yx swizzling.
        /// </summary>
        public uint2 yx => new uint2(y, x);

        /// <summary>
        /// Returns uint2.gr swizzling (equivalent to uint2.yx).
        /// </summary>
        public uint2 gr => new uint2(y, x);

        /// <summary>
        /// Returns uint2.yxx swizzling.
        /// </summary>
        public uint3 yxx => new uint3(y, x, x);

        /// <summary>
        /// Returns uint2.grr swizzling (equivalent to uint2.yxx).
        /// </summary>
        public uint3 grr => new uint3(y, x, x);

        /// <summary>
        /// Returns uint2.yxxx swizzling.
        /// </summary>
        public uint4 yxxx => new uint4(y, x, x, x);

        /// <summary>
        /// Returns uint2.grrr swizzling (equivalent to uint2.yxxx).
        /// </summary>
        public uint4 grrr => new uint4(y, x, x, x);

        /// <summary>
        /// Returns uint2.yxxy swizzling.
        /// </summary>
        public uint4 yxxy => new uint4(y, x, x, y);

        /// <summary>
        /// Returns uint2.grrg swizzling (equivalent to uint2.yxxy).
        /// </summary>
        public uint4 grrg => new uint4(y, x, x, y);

        /// <summary>
        /// Returns uint2.yxy swizzling.
        /// </summary>
        public uint3 yxy => new uint3(y, x, y);

        /// <summary>
        /// Returns uint2.grg swizzling (equivalent to uint2.yxy).
        /// </summary>
        public uint3 grg => new uint3(y, x, y);

        /// <summary>
        /// Returns uint2.yxyx swizzling.
        /// </summary>
        public uint4 yxyx => new uint4(y, x, y, x);

        /// <summary>
        /// Returns uint2.grgr swizzling (equivalent to uint2.yxyx).
        /// </summary>
        public uint4 grgr => new uint4(y, x, y, x);

        /// <summary>
        /// Returns uint2.yxyy swizzling.
        /// </summary>
        public uint4 yxyy => new uint4(y, x, y, y);

        /// <summary>
        /// Returns uint2.grgg swizzling (equivalent to uint2.yxyy).
        /// </summary>
        public uint4 grgg => new uint4(y, x, y, y);

        /// <summary>
        /// Returns uint2.yy swizzling.
        /// </summary>
        public uint2 yy => new uint2(y, y);

        /// <summary>
        /// Returns uint2.gg swizzling (equivalent to uint2.yy).
        /// </summary>
        public uint2 gg => new uint2(y, y);

        /// <summary>
        /// Returns uint2.yyx swizzling.
        /// </summary>
        public uint3 yyx => new uint3(y, y, x);

        /// <summary>
        /// Returns uint2.ggr swizzling (equivalent to uint2.yyx).
        /// </summary>
        public uint3 ggr => new uint3(y, y, x);

        /// <summary>
        /// Returns uint2.yyxx swizzling.
        /// </summary>
        public uint4 yyxx => new uint4(y, y, x, x);

        /// <summary>
        /// Returns uint2.ggrr swizzling (equivalent to uint2.yyxx).
        /// </summary>
        public uint4 ggrr => new uint4(y, y, x, x);

        /// <summary>
        /// Returns uint2.yyxy swizzling.
        /// </summary>
        public uint4 yyxy => new uint4(y, y, x, y);

        /// <summary>
        /// Returns uint2.ggrg swizzling (equivalent to uint2.yyxy).
        /// </summary>
        public uint4 ggrg => new uint4(y, y, x, y);

        /// <summary>
        /// Returns uint2.yyy swizzling.
        /// </summary>
        public uint3 yyy => new uint3(y, y, y);

        /// <summary>
        /// Returns uint2.ggg swizzling (equivalent to uint2.yyy).
        /// </summary>
        public uint3 ggg => new uint3(y, y, y);

        /// <summary>
        /// Returns uint2.yyyx swizzling.
        /// </summary>
        public uint4 yyyx => new uint4(y, y, y, x);

        /// <summary>
        /// Returns uint2.gggr swizzling (equivalent to uint2.yyyx).
        /// </summary>
        public uint4 gggr => new uint4(y, y, y, x);

        /// <summary>
        /// Returns uint2.yyyy swizzling.
        /// </summary>
        public uint4 yyyy => new uint4(y, y, y, y);

        /// <summary>
        /// Returns uint2.gggg swizzling (equivalent to uint2.yyyy).
        /// </summary>
        public uint4 gggg => new uint4(y, y, y, y);

        #endregion

    }
}
