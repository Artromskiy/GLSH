using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type uint with 4 components, used for implementing swizzling for uint4.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_uvec4
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

        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        internal readonly uint w;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_uvec4.
        /// </summary>
        internal swizzle_uvec4(uint x, uint y, uint z, uint w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns uint4.xx swizzling.
        /// </summary>
        public uint2 xx => new uint2(x, x);

        /// <summary>
        /// Returns uint4.rr swizzling (equivalent to uint4.xx).
        /// </summary>
        public uint2 rr => new uint2(x, x);

        /// <summary>
        /// Returns uint4.xxx swizzling.
        /// </summary>
        public uint3 xxx => new uint3(x, x, x);

        /// <summary>
        /// Returns uint4.rrr swizzling (equivalent to uint4.xxx).
        /// </summary>
        public uint3 rrr => new uint3(x, x, x);

        /// <summary>
        /// Returns uint4.xxxx swizzling.
        /// </summary>
        public uint4 xxxx => new uint4(x, x, x, x);

        /// <summary>
        /// Returns uint4.rrrr swizzling (equivalent to uint4.xxxx).
        /// </summary>
        public uint4 rrrr => new uint4(x, x, x, x);

        /// <summary>
        /// Returns uint4.xxxy swizzling.
        /// </summary>
        public uint4 xxxy => new uint4(x, x, x, y);

        /// <summary>
        /// Returns uint4.rrrg swizzling (equivalent to uint4.xxxy).
        /// </summary>
        public uint4 rrrg => new uint4(x, x, x, y);

        /// <summary>
        /// Returns uint4.xxxz swizzling.
        /// </summary>
        public uint4 xxxz => new uint4(x, x, x, z);

        /// <summary>
        /// Returns uint4.rrrb swizzling (equivalent to uint4.xxxz).
        /// </summary>
        public uint4 rrrb => new uint4(x, x, x, z);

        /// <summary>
        /// Returns uint4.xxxw swizzling.
        /// </summary>
        public uint4 xxxw => new uint4(x, x, x, w);

        /// <summary>
        /// Returns uint4.rrra swizzling (equivalent to uint4.xxxw).
        /// </summary>
        public uint4 rrra => new uint4(x, x, x, w);

        /// <summary>
        /// Returns uint4.xxy swizzling.
        /// </summary>
        public uint3 xxy => new uint3(x, x, y);

        /// <summary>
        /// Returns uint4.rrg swizzling (equivalent to uint4.xxy).
        /// </summary>
        public uint3 rrg => new uint3(x, x, y);

        /// <summary>
        /// Returns uint4.xxyx swizzling.
        /// </summary>
        public uint4 xxyx => new uint4(x, x, y, x);

        /// <summary>
        /// Returns uint4.rrgr swizzling (equivalent to uint4.xxyx).
        /// </summary>
        public uint4 rrgr => new uint4(x, x, y, x);

        /// <summary>
        /// Returns uint4.xxyy swizzling.
        /// </summary>
        public uint4 xxyy => new uint4(x, x, y, y);

        /// <summary>
        /// Returns uint4.rrgg swizzling (equivalent to uint4.xxyy).
        /// </summary>
        public uint4 rrgg => new uint4(x, x, y, y);

        /// <summary>
        /// Returns uint4.xxyz swizzling.
        /// </summary>
        public uint4 xxyz => new uint4(x, x, y, z);

        /// <summary>
        /// Returns uint4.rrgb swizzling (equivalent to uint4.xxyz).
        /// </summary>
        public uint4 rrgb => new uint4(x, x, y, z);

        /// <summary>
        /// Returns uint4.xxyw swizzling.
        /// </summary>
        public uint4 xxyw => new uint4(x, x, y, w);

        /// <summary>
        /// Returns uint4.rrga swizzling (equivalent to uint4.xxyw).
        /// </summary>
        public uint4 rrga => new uint4(x, x, y, w);

        /// <summary>
        /// Returns uint4.xxz swizzling.
        /// </summary>
        public uint3 xxz => new uint3(x, x, z);

        /// <summary>
        /// Returns uint4.rrb swizzling (equivalent to uint4.xxz).
        /// </summary>
        public uint3 rrb => new uint3(x, x, z);

        /// <summary>
        /// Returns uint4.xxzx swizzling.
        /// </summary>
        public uint4 xxzx => new uint4(x, x, z, x);

        /// <summary>
        /// Returns uint4.rrbr swizzling (equivalent to uint4.xxzx).
        /// </summary>
        public uint4 rrbr => new uint4(x, x, z, x);

        /// <summary>
        /// Returns uint4.xxzy swizzling.
        /// </summary>
        public uint4 xxzy => new uint4(x, x, z, y);

        /// <summary>
        /// Returns uint4.rrbg swizzling (equivalent to uint4.xxzy).
        /// </summary>
        public uint4 rrbg => new uint4(x, x, z, y);

        /// <summary>
        /// Returns uint4.xxzz swizzling.
        /// </summary>
        public uint4 xxzz => new uint4(x, x, z, z);

        /// <summary>
        /// Returns uint4.rrbb swizzling (equivalent to uint4.xxzz).
        /// </summary>
        public uint4 rrbb => new uint4(x, x, z, z);

        /// <summary>
        /// Returns uint4.xxzw swizzling.
        /// </summary>
        public uint4 xxzw => new uint4(x, x, z, w);

        /// <summary>
        /// Returns uint4.rrba swizzling (equivalent to uint4.xxzw).
        /// </summary>
        public uint4 rrba => new uint4(x, x, z, w);

        /// <summary>
        /// Returns uint4.xxw swizzling.
        /// </summary>
        public uint3 xxw => new uint3(x, x, w);

        /// <summary>
        /// Returns uint4.rra swizzling (equivalent to uint4.xxw).
        /// </summary>
        public uint3 rra => new uint3(x, x, w);

        /// <summary>
        /// Returns uint4.xxwx swizzling.
        /// </summary>
        public uint4 xxwx => new uint4(x, x, w, x);

        /// <summary>
        /// Returns uint4.rrar swizzling (equivalent to uint4.xxwx).
        /// </summary>
        public uint4 rrar => new uint4(x, x, w, x);

        /// <summary>
        /// Returns uint4.xxwy swizzling.
        /// </summary>
        public uint4 xxwy => new uint4(x, x, w, y);

        /// <summary>
        /// Returns uint4.rrag swizzling (equivalent to uint4.xxwy).
        /// </summary>
        public uint4 rrag => new uint4(x, x, w, y);

        /// <summary>
        /// Returns uint4.xxwz swizzling.
        /// </summary>
        public uint4 xxwz => new uint4(x, x, w, z);

        /// <summary>
        /// Returns uint4.rrab swizzling (equivalent to uint4.xxwz).
        /// </summary>
        public uint4 rrab => new uint4(x, x, w, z);

        /// <summary>
        /// Returns uint4.xxww swizzling.
        /// </summary>
        public uint4 xxww => new uint4(x, x, w, w);

        /// <summary>
        /// Returns uint4.rraa swizzling (equivalent to uint4.xxww).
        /// </summary>
        public uint4 rraa => new uint4(x, x, w, w);

        /// <summary>
        /// Returns uint4.xy swizzling.
        /// </summary>
        public uint2 xy => new uint2(x, y);

        /// <summary>
        /// Returns uint4.rg swizzling (equivalent to uint4.xy).
        /// </summary>
        public uint2 rg => new uint2(x, y);

        /// <summary>
        /// Returns uint4.xyx swizzling.
        /// </summary>
        public uint3 xyx => new uint3(x, y, x);

        /// <summary>
        /// Returns uint4.rgr swizzling (equivalent to uint4.xyx).
        /// </summary>
        public uint3 rgr => new uint3(x, y, x);

        /// <summary>
        /// Returns uint4.xyxx swizzling.
        /// </summary>
        public uint4 xyxx => new uint4(x, y, x, x);

        /// <summary>
        /// Returns uint4.rgrr swizzling (equivalent to uint4.xyxx).
        /// </summary>
        public uint4 rgrr => new uint4(x, y, x, x);

        /// <summary>
        /// Returns uint4.xyxy swizzling.
        /// </summary>
        public uint4 xyxy => new uint4(x, y, x, y);

        /// <summary>
        /// Returns uint4.rgrg swizzling (equivalent to uint4.xyxy).
        /// </summary>
        public uint4 rgrg => new uint4(x, y, x, y);

        /// <summary>
        /// Returns uint4.xyxz swizzling.
        /// </summary>
        public uint4 xyxz => new uint4(x, y, x, z);

        /// <summary>
        /// Returns uint4.rgrb swizzling (equivalent to uint4.xyxz).
        /// </summary>
        public uint4 rgrb => new uint4(x, y, x, z);

        /// <summary>
        /// Returns uint4.xyxw swizzling.
        /// </summary>
        public uint4 xyxw => new uint4(x, y, x, w);

        /// <summary>
        /// Returns uint4.rgra swizzling (equivalent to uint4.xyxw).
        /// </summary>
        public uint4 rgra => new uint4(x, y, x, w);

        /// <summary>
        /// Returns uint4.xyy swizzling.
        /// </summary>
        public uint3 xyy => new uint3(x, y, y);

        /// <summary>
        /// Returns uint4.rgg swizzling (equivalent to uint4.xyy).
        /// </summary>
        public uint3 rgg => new uint3(x, y, y);

        /// <summary>
        /// Returns uint4.xyyx swizzling.
        /// </summary>
        public uint4 xyyx => new uint4(x, y, y, x);

        /// <summary>
        /// Returns uint4.rggr swizzling (equivalent to uint4.xyyx).
        /// </summary>
        public uint4 rggr => new uint4(x, y, y, x);

        /// <summary>
        /// Returns uint4.xyyy swizzling.
        /// </summary>
        public uint4 xyyy => new uint4(x, y, y, y);

        /// <summary>
        /// Returns uint4.rggg swizzling (equivalent to uint4.xyyy).
        /// </summary>
        public uint4 rggg => new uint4(x, y, y, y);

        /// <summary>
        /// Returns uint4.xyyz swizzling.
        /// </summary>
        public uint4 xyyz => new uint4(x, y, y, z);

        /// <summary>
        /// Returns uint4.rggb swizzling (equivalent to uint4.xyyz).
        /// </summary>
        public uint4 rggb => new uint4(x, y, y, z);

        /// <summary>
        /// Returns uint4.xyyw swizzling.
        /// </summary>
        public uint4 xyyw => new uint4(x, y, y, w);

        /// <summary>
        /// Returns uint4.rgga swizzling (equivalent to uint4.xyyw).
        /// </summary>
        public uint4 rgga => new uint4(x, y, y, w);

        /// <summary>
        /// Returns uint4.xyz swizzling.
        /// </summary>
        public uint3 xyz => new uint3(x, y, z);

        /// <summary>
        /// Returns uint4.rgb swizzling (equivalent to uint4.xyz).
        /// </summary>
        public uint3 rgb => new uint3(x, y, z);

        /// <summary>
        /// Returns uint4.xyzx swizzling.
        /// </summary>
        public uint4 xyzx => new uint4(x, y, z, x);

        /// <summary>
        /// Returns uint4.rgbr swizzling (equivalent to uint4.xyzx).
        /// </summary>
        public uint4 rgbr => new uint4(x, y, z, x);

        /// <summary>
        /// Returns uint4.xyzy swizzling.
        /// </summary>
        public uint4 xyzy => new uint4(x, y, z, y);

        /// <summary>
        /// Returns uint4.rgbg swizzling (equivalent to uint4.xyzy).
        /// </summary>
        public uint4 rgbg => new uint4(x, y, z, y);

        /// <summary>
        /// Returns uint4.xyzz swizzling.
        /// </summary>
        public uint4 xyzz => new uint4(x, y, z, z);

        /// <summary>
        /// Returns uint4.rgbb swizzling (equivalent to uint4.xyzz).
        /// </summary>
        public uint4 rgbb => new uint4(x, y, z, z);

        /// <summary>
        /// Returns uint4.xyzw swizzling.
        /// </summary>
        public uint4 xyzw => new uint4(x, y, z, w);

        /// <summary>
        /// Returns uint4.rgba swizzling (equivalent to uint4.xyzw).
        /// </summary>
        public uint4 rgba => new uint4(x, y, z, w);

        /// <summary>
        /// Returns uint4.xyw swizzling.
        /// </summary>
        public uint3 xyw => new uint3(x, y, w);

        /// <summary>
        /// Returns uint4.rga swizzling (equivalent to uint4.xyw).
        /// </summary>
        public uint3 rga => new uint3(x, y, w);

        /// <summary>
        /// Returns uint4.xywx swizzling.
        /// </summary>
        public uint4 xywx => new uint4(x, y, w, x);

        /// <summary>
        /// Returns uint4.rgar swizzling (equivalent to uint4.xywx).
        /// </summary>
        public uint4 rgar => new uint4(x, y, w, x);

        /// <summary>
        /// Returns uint4.xywy swizzling.
        /// </summary>
        public uint4 xywy => new uint4(x, y, w, y);

        /// <summary>
        /// Returns uint4.rgag swizzling (equivalent to uint4.xywy).
        /// </summary>
        public uint4 rgag => new uint4(x, y, w, y);

        /// <summary>
        /// Returns uint4.xywz swizzling.
        /// </summary>
        public uint4 xywz => new uint4(x, y, w, z);

        /// <summary>
        /// Returns uint4.rgab swizzling (equivalent to uint4.xywz).
        /// </summary>
        public uint4 rgab => new uint4(x, y, w, z);

        /// <summary>
        /// Returns uint4.xyww swizzling.
        /// </summary>
        public uint4 xyww => new uint4(x, y, w, w);

        /// <summary>
        /// Returns uint4.rgaa swizzling (equivalent to uint4.xyww).
        /// </summary>
        public uint4 rgaa => new uint4(x, y, w, w);

        /// <summary>
        /// Returns uint4.xz swizzling.
        /// </summary>
        public uint2 xz => new uint2(x, z);

        /// <summary>
        /// Returns uint4.rb swizzling (equivalent to uint4.xz).
        /// </summary>
        public uint2 rb => new uint2(x, z);

        /// <summary>
        /// Returns uint4.xzx swizzling.
        /// </summary>
        public uint3 xzx => new uint3(x, z, x);

        /// <summary>
        /// Returns uint4.rbr swizzling (equivalent to uint4.xzx).
        /// </summary>
        public uint3 rbr => new uint3(x, z, x);

        /// <summary>
        /// Returns uint4.xzxx swizzling.
        /// </summary>
        public uint4 xzxx => new uint4(x, z, x, x);

        /// <summary>
        /// Returns uint4.rbrr swizzling (equivalent to uint4.xzxx).
        /// </summary>
        public uint4 rbrr => new uint4(x, z, x, x);

        /// <summary>
        /// Returns uint4.xzxy swizzling.
        /// </summary>
        public uint4 xzxy => new uint4(x, z, x, y);

        /// <summary>
        /// Returns uint4.rbrg swizzling (equivalent to uint4.xzxy).
        /// </summary>
        public uint4 rbrg => new uint4(x, z, x, y);

        /// <summary>
        /// Returns uint4.xzxz swizzling.
        /// </summary>
        public uint4 xzxz => new uint4(x, z, x, z);

        /// <summary>
        /// Returns uint4.rbrb swizzling (equivalent to uint4.xzxz).
        /// </summary>
        public uint4 rbrb => new uint4(x, z, x, z);

        /// <summary>
        /// Returns uint4.xzxw swizzling.
        /// </summary>
        public uint4 xzxw => new uint4(x, z, x, w);

        /// <summary>
        /// Returns uint4.rbra swizzling (equivalent to uint4.xzxw).
        /// </summary>
        public uint4 rbra => new uint4(x, z, x, w);

        /// <summary>
        /// Returns uint4.xzy swizzling.
        /// </summary>
        public uint3 xzy => new uint3(x, z, y);

        /// <summary>
        /// Returns uint4.rbg swizzling (equivalent to uint4.xzy).
        /// </summary>
        public uint3 rbg => new uint3(x, z, y);

        /// <summary>
        /// Returns uint4.xzyx swizzling.
        /// </summary>
        public uint4 xzyx => new uint4(x, z, y, x);

        /// <summary>
        /// Returns uint4.rbgr swizzling (equivalent to uint4.xzyx).
        /// </summary>
        public uint4 rbgr => new uint4(x, z, y, x);

        /// <summary>
        /// Returns uint4.xzyy swizzling.
        /// </summary>
        public uint4 xzyy => new uint4(x, z, y, y);

        /// <summary>
        /// Returns uint4.rbgg swizzling (equivalent to uint4.xzyy).
        /// </summary>
        public uint4 rbgg => new uint4(x, z, y, y);

        /// <summary>
        /// Returns uint4.xzyz swizzling.
        /// </summary>
        public uint4 xzyz => new uint4(x, z, y, z);

        /// <summary>
        /// Returns uint4.rbgb swizzling (equivalent to uint4.xzyz).
        /// </summary>
        public uint4 rbgb => new uint4(x, z, y, z);

        /// <summary>
        /// Returns uint4.xzyw swizzling.
        /// </summary>
        public uint4 xzyw => new uint4(x, z, y, w);

        /// <summary>
        /// Returns uint4.rbga swizzling (equivalent to uint4.xzyw).
        /// </summary>
        public uint4 rbga => new uint4(x, z, y, w);

        /// <summary>
        /// Returns uint4.xzz swizzling.
        /// </summary>
        public uint3 xzz => new uint3(x, z, z);

        /// <summary>
        /// Returns uint4.rbb swizzling (equivalent to uint4.xzz).
        /// </summary>
        public uint3 rbb => new uint3(x, z, z);

        /// <summary>
        /// Returns uint4.xzzx swizzling.
        /// </summary>
        public uint4 xzzx => new uint4(x, z, z, x);

        /// <summary>
        /// Returns uint4.rbbr swizzling (equivalent to uint4.xzzx).
        /// </summary>
        public uint4 rbbr => new uint4(x, z, z, x);

        /// <summary>
        /// Returns uint4.xzzy swizzling.
        /// </summary>
        public uint4 xzzy => new uint4(x, z, z, y);

        /// <summary>
        /// Returns uint4.rbbg swizzling (equivalent to uint4.xzzy).
        /// </summary>
        public uint4 rbbg => new uint4(x, z, z, y);

        /// <summary>
        /// Returns uint4.xzzz swizzling.
        /// </summary>
        public uint4 xzzz => new uint4(x, z, z, z);

        /// <summary>
        /// Returns uint4.rbbb swizzling (equivalent to uint4.xzzz).
        /// </summary>
        public uint4 rbbb => new uint4(x, z, z, z);

        /// <summary>
        /// Returns uint4.xzzw swizzling.
        /// </summary>
        public uint4 xzzw => new uint4(x, z, z, w);

        /// <summary>
        /// Returns uint4.rbba swizzling (equivalent to uint4.xzzw).
        /// </summary>
        public uint4 rbba => new uint4(x, z, z, w);

        /// <summary>
        /// Returns uint4.xzw swizzling.
        /// </summary>
        public uint3 xzw => new uint3(x, z, w);

        /// <summary>
        /// Returns uint4.rba swizzling (equivalent to uint4.xzw).
        /// </summary>
        public uint3 rba => new uint3(x, z, w);

        /// <summary>
        /// Returns uint4.xzwx swizzling.
        /// </summary>
        public uint4 xzwx => new uint4(x, z, w, x);

        /// <summary>
        /// Returns uint4.rbar swizzling (equivalent to uint4.xzwx).
        /// </summary>
        public uint4 rbar => new uint4(x, z, w, x);

        /// <summary>
        /// Returns uint4.xzwy swizzling.
        /// </summary>
        public uint4 xzwy => new uint4(x, z, w, y);

        /// <summary>
        /// Returns uint4.rbag swizzling (equivalent to uint4.xzwy).
        /// </summary>
        public uint4 rbag => new uint4(x, z, w, y);

        /// <summary>
        /// Returns uint4.xzwz swizzling.
        /// </summary>
        public uint4 xzwz => new uint4(x, z, w, z);

        /// <summary>
        /// Returns uint4.rbab swizzling (equivalent to uint4.xzwz).
        /// </summary>
        public uint4 rbab => new uint4(x, z, w, z);

        /// <summary>
        /// Returns uint4.xzww swizzling.
        /// </summary>
        public uint4 xzww => new uint4(x, z, w, w);

        /// <summary>
        /// Returns uint4.rbaa swizzling (equivalent to uint4.xzww).
        /// </summary>
        public uint4 rbaa => new uint4(x, z, w, w);

        /// <summary>
        /// Returns uint4.xw swizzling.
        /// </summary>
        public uint2 xw => new uint2(x, w);

        /// <summary>
        /// Returns uint4.ra swizzling (equivalent to uint4.xw).
        /// </summary>
        public uint2 ra => new uint2(x, w);

        /// <summary>
        /// Returns uint4.xwx swizzling.
        /// </summary>
        public uint3 xwx => new uint3(x, w, x);

        /// <summary>
        /// Returns uint4.rar swizzling (equivalent to uint4.xwx).
        /// </summary>
        public uint3 rar => new uint3(x, w, x);

        /// <summary>
        /// Returns uint4.xwxx swizzling.
        /// </summary>
        public uint4 xwxx => new uint4(x, w, x, x);

        /// <summary>
        /// Returns uint4.rarr swizzling (equivalent to uint4.xwxx).
        /// </summary>
        public uint4 rarr => new uint4(x, w, x, x);

        /// <summary>
        /// Returns uint4.xwxy swizzling.
        /// </summary>
        public uint4 xwxy => new uint4(x, w, x, y);

        /// <summary>
        /// Returns uint4.rarg swizzling (equivalent to uint4.xwxy).
        /// </summary>
        public uint4 rarg => new uint4(x, w, x, y);

        /// <summary>
        /// Returns uint4.xwxz swizzling.
        /// </summary>
        public uint4 xwxz => new uint4(x, w, x, z);

        /// <summary>
        /// Returns uint4.rarb swizzling (equivalent to uint4.xwxz).
        /// </summary>
        public uint4 rarb => new uint4(x, w, x, z);

        /// <summary>
        /// Returns uint4.xwxw swizzling.
        /// </summary>
        public uint4 xwxw => new uint4(x, w, x, w);

        /// <summary>
        /// Returns uint4.rara swizzling (equivalent to uint4.xwxw).
        /// </summary>
        public uint4 rara => new uint4(x, w, x, w);

        /// <summary>
        /// Returns uint4.xwy swizzling.
        /// </summary>
        public uint3 xwy => new uint3(x, w, y);

        /// <summary>
        /// Returns uint4.rag swizzling (equivalent to uint4.xwy).
        /// </summary>
        public uint3 rag => new uint3(x, w, y);

        /// <summary>
        /// Returns uint4.xwyx swizzling.
        /// </summary>
        public uint4 xwyx => new uint4(x, w, y, x);

        /// <summary>
        /// Returns uint4.ragr swizzling (equivalent to uint4.xwyx).
        /// </summary>
        public uint4 ragr => new uint4(x, w, y, x);

        /// <summary>
        /// Returns uint4.xwyy swizzling.
        /// </summary>
        public uint4 xwyy => new uint4(x, w, y, y);

        /// <summary>
        /// Returns uint4.ragg swizzling (equivalent to uint4.xwyy).
        /// </summary>
        public uint4 ragg => new uint4(x, w, y, y);

        /// <summary>
        /// Returns uint4.xwyz swizzling.
        /// </summary>
        public uint4 xwyz => new uint4(x, w, y, z);

        /// <summary>
        /// Returns uint4.ragb swizzling (equivalent to uint4.xwyz).
        /// </summary>
        public uint4 ragb => new uint4(x, w, y, z);

        /// <summary>
        /// Returns uint4.xwyw swizzling.
        /// </summary>
        public uint4 xwyw => new uint4(x, w, y, w);

        /// <summary>
        /// Returns uint4.raga swizzling (equivalent to uint4.xwyw).
        /// </summary>
        public uint4 raga => new uint4(x, w, y, w);

        /// <summary>
        /// Returns uint4.xwz swizzling.
        /// </summary>
        public uint3 xwz => new uint3(x, w, z);

        /// <summary>
        /// Returns uint4.rab swizzling (equivalent to uint4.xwz).
        /// </summary>
        public uint3 rab => new uint3(x, w, z);

        /// <summary>
        /// Returns uint4.xwzx swizzling.
        /// </summary>
        public uint4 xwzx => new uint4(x, w, z, x);

        /// <summary>
        /// Returns uint4.rabr swizzling (equivalent to uint4.xwzx).
        /// </summary>
        public uint4 rabr => new uint4(x, w, z, x);

        /// <summary>
        /// Returns uint4.xwzy swizzling.
        /// </summary>
        public uint4 xwzy => new uint4(x, w, z, y);

        /// <summary>
        /// Returns uint4.rabg swizzling (equivalent to uint4.xwzy).
        /// </summary>
        public uint4 rabg => new uint4(x, w, z, y);

        /// <summary>
        /// Returns uint4.xwzz swizzling.
        /// </summary>
        public uint4 xwzz => new uint4(x, w, z, z);

        /// <summary>
        /// Returns uint4.rabb swizzling (equivalent to uint4.xwzz).
        /// </summary>
        public uint4 rabb => new uint4(x, w, z, z);

        /// <summary>
        /// Returns uint4.xwzw swizzling.
        /// </summary>
        public uint4 xwzw => new uint4(x, w, z, w);

        /// <summary>
        /// Returns uint4.raba swizzling (equivalent to uint4.xwzw).
        /// </summary>
        public uint4 raba => new uint4(x, w, z, w);

        /// <summary>
        /// Returns uint4.xww swizzling.
        /// </summary>
        public uint3 xww => new uint3(x, w, w);

        /// <summary>
        /// Returns uint4.raa swizzling (equivalent to uint4.xww).
        /// </summary>
        public uint3 raa => new uint3(x, w, w);

        /// <summary>
        /// Returns uint4.xwwx swizzling.
        /// </summary>
        public uint4 xwwx => new uint4(x, w, w, x);

        /// <summary>
        /// Returns uint4.raar swizzling (equivalent to uint4.xwwx).
        /// </summary>
        public uint4 raar => new uint4(x, w, w, x);

        /// <summary>
        /// Returns uint4.xwwy swizzling.
        /// </summary>
        public uint4 xwwy => new uint4(x, w, w, y);

        /// <summary>
        /// Returns uint4.raag swizzling (equivalent to uint4.xwwy).
        /// </summary>
        public uint4 raag => new uint4(x, w, w, y);

        /// <summary>
        /// Returns uint4.xwwz swizzling.
        /// </summary>
        public uint4 xwwz => new uint4(x, w, w, z);

        /// <summary>
        /// Returns uint4.raab swizzling (equivalent to uint4.xwwz).
        /// </summary>
        public uint4 raab => new uint4(x, w, w, z);

        /// <summary>
        /// Returns uint4.xwww swizzling.
        /// </summary>
        public uint4 xwww => new uint4(x, w, w, w);

        /// <summary>
        /// Returns uint4.raaa swizzling (equivalent to uint4.xwww).
        /// </summary>
        public uint4 raaa => new uint4(x, w, w, w);

        /// <summary>
        /// Returns uint4.yx swizzling.
        /// </summary>
        public uint2 yx => new uint2(y, x);

        /// <summary>
        /// Returns uint4.gr swizzling (equivalent to uint4.yx).
        /// </summary>
        public uint2 gr => new uint2(y, x);

        /// <summary>
        /// Returns uint4.yxx swizzling.
        /// </summary>
        public uint3 yxx => new uint3(y, x, x);

        /// <summary>
        /// Returns uint4.grr swizzling (equivalent to uint4.yxx).
        /// </summary>
        public uint3 grr => new uint3(y, x, x);

        /// <summary>
        /// Returns uint4.yxxx swizzling.
        /// </summary>
        public uint4 yxxx => new uint4(y, x, x, x);

        /// <summary>
        /// Returns uint4.grrr swizzling (equivalent to uint4.yxxx).
        /// </summary>
        public uint4 grrr => new uint4(y, x, x, x);

        /// <summary>
        /// Returns uint4.yxxy swizzling.
        /// </summary>
        public uint4 yxxy => new uint4(y, x, x, y);

        /// <summary>
        /// Returns uint4.grrg swizzling (equivalent to uint4.yxxy).
        /// </summary>
        public uint4 grrg => new uint4(y, x, x, y);

        /// <summary>
        /// Returns uint4.yxxz swizzling.
        /// </summary>
        public uint4 yxxz => new uint4(y, x, x, z);

        /// <summary>
        /// Returns uint4.grrb swizzling (equivalent to uint4.yxxz).
        /// </summary>
        public uint4 grrb => new uint4(y, x, x, z);

        /// <summary>
        /// Returns uint4.yxxw swizzling.
        /// </summary>
        public uint4 yxxw => new uint4(y, x, x, w);

        /// <summary>
        /// Returns uint4.grra swizzling (equivalent to uint4.yxxw).
        /// </summary>
        public uint4 grra => new uint4(y, x, x, w);

        /// <summary>
        /// Returns uint4.yxy swizzling.
        /// </summary>
        public uint3 yxy => new uint3(y, x, y);

        /// <summary>
        /// Returns uint4.grg swizzling (equivalent to uint4.yxy).
        /// </summary>
        public uint3 grg => new uint3(y, x, y);

        /// <summary>
        /// Returns uint4.yxyx swizzling.
        /// </summary>
        public uint4 yxyx => new uint4(y, x, y, x);

        /// <summary>
        /// Returns uint4.grgr swizzling (equivalent to uint4.yxyx).
        /// </summary>
        public uint4 grgr => new uint4(y, x, y, x);

        /// <summary>
        /// Returns uint4.yxyy swizzling.
        /// </summary>
        public uint4 yxyy => new uint4(y, x, y, y);

        /// <summary>
        /// Returns uint4.grgg swizzling (equivalent to uint4.yxyy).
        /// </summary>
        public uint4 grgg => new uint4(y, x, y, y);

        /// <summary>
        /// Returns uint4.yxyz swizzling.
        /// </summary>
        public uint4 yxyz => new uint4(y, x, y, z);

        /// <summary>
        /// Returns uint4.grgb swizzling (equivalent to uint4.yxyz).
        /// </summary>
        public uint4 grgb => new uint4(y, x, y, z);

        /// <summary>
        /// Returns uint4.yxyw swizzling.
        /// </summary>
        public uint4 yxyw => new uint4(y, x, y, w);

        /// <summary>
        /// Returns uint4.grga swizzling (equivalent to uint4.yxyw).
        /// </summary>
        public uint4 grga => new uint4(y, x, y, w);

        /// <summary>
        /// Returns uint4.yxz swizzling.
        /// </summary>
        public uint3 yxz => new uint3(y, x, z);

        /// <summary>
        /// Returns uint4.grb swizzling (equivalent to uint4.yxz).
        /// </summary>
        public uint3 grb => new uint3(y, x, z);

        /// <summary>
        /// Returns uint4.yxzx swizzling.
        /// </summary>
        public uint4 yxzx => new uint4(y, x, z, x);

        /// <summary>
        /// Returns uint4.grbr swizzling (equivalent to uint4.yxzx).
        /// </summary>
        public uint4 grbr => new uint4(y, x, z, x);

        /// <summary>
        /// Returns uint4.yxzy swizzling.
        /// </summary>
        public uint4 yxzy => new uint4(y, x, z, y);

        /// <summary>
        /// Returns uint4.grbg swizzling (equivalent to uint4.yxzy).
        /// </summary>
        public uint4 grbg => new uint4(y, x, z, y);

        /// <summary>
        /// Returns uint4.yxzz swizzling.
        /// </summary>
        public uint4 yxzz => new uint4(y, x, z, z);

        /// <summary>
        /// Returns uint4.grbb swizzling (equivalent to uint4.yxzz).
        /// </summary>
        public uint4 grbb => new uint4(y, x, z, z);

        /// <summary>
        /// Returns uint4.yxzw swizzling.
        /// </summary>
        public uint4 yxzw => new uint4(y, x, z, w);

        /// <summary>
        /// Returns uint4.grba swizzling (equivalent to uint4.yxzw).
        /// </summary>
        public uint4 grba => new uint4(y, x, z, w);

        /// <summary>
        /// Returns uint4.yxw swizzling.
        /// </summary>
        public uint3 yxw => new uint3(y, x, w);

        /// <summary>
        /// Returns uint4.gra swizzling (equivalent to uint4.yxw).
        /// </summary>
        public uint3 gra => new uint3(y, x, w);

        /// <summary>
        /// Returns uint4.yxwx swizzling.
        /// </summary>
        public uint4 yxwx => new uint4(y, x, w, x);

        /// <summary>
        /// Returns uint4.grar swizzling (equivalent to uint4.yxwx).
        /// </summary>
        public uint4 grar => new uint4(y, x, w, x);

        /// <summary>
        /// Returns uint4.yxwy swizzling.
        /// </summary>
        public uint4 yxwy => new uint4(y, x, w, y);

        /// <summary>
        /// Returns uint4.grag swizzling (equivalent to uint4.yxwy).
        /// </summary>
        public uint4 grag => new uint4(y, x, w, y);

        /// <summary>
        /// Returns uint4.yxwz swizzling.
        /// </summary>
        public uint4 yxwz => new uint4(y, x, w, z);

        /// <summary>
        /// Returns uint4.grab swizzling (equivalent to uint4.yxwz).
        /// </summary>
        public uint4 grab => new uint4(y, x, w, z);

        /// <summary>
        /// Returns uint4.yxww swizzling.
        /// </summary>
        public uint4 yxww => new uint4(y, x, w, w);

        /// <summary>
        /// Returns uint4.graa swizzling (equivalent to uint4.yxww).
        /// </summary>
        public uint4 graa => new uint4(y, x, w, w);

        /// <summary>
        /// Returns uint4.yy swizzling.
        /// </summary>
        public uint2 yy => new uint2(y, y);

        /// <summary>
        /// Returns uint4.gg swizzling (equivalent to uint4.yy).
        /// </summary>
        public uint2 gg => new uint2(y, y);

        /// <summary>
        /// Returns uint4.yyx swizzling.
        /// </summary>
        public uint3 yyx => new uint3(y, y, x);

        /// <summary>
        /// Returns uint4.ggr swizzling (equivalent to uint4.yyx).
        /// </summary>
        public uint3 ggr => new uint3(y, y, x);

        /// <summary>
        /// Returns uint4.yyxx swizzling.
        /// </summary>
        public uint4 yyxx => new uint4(y, y, x, x);

        /// <summary>
        /// Returns uint4.ggrr swizzling (equivalent to uint4.yyxx).
        /// </summary>
        public uint4 ggrr => new uint4(y, y, x, x);

        /// <summary>
        /// Returns uint4.yyxy swizzling.
        /// </summary>
        public uint4 yyxy => new uint4(y, y, x, y);

        /// <summary>
        /// Returns uint4.ggrg swizzling (equivalent to uint4.yyxy).
        /// </summary>
        public uint4 ggrg => new uint4(y, y, x, y);

        /// <summary>
        /// Returns uint4.yyxz swizzling.
        /// </summary>
        public uint4 yyxz => new uint4(y, y, x, z);

        /// <summary>
        /// Returns uint4.ggrb swizzling (equivalent to uint4.yyxz).
        /// </summary>
        public uint4 ggrb => new uint4(y, y, x, z);

        /// <summary>
        /// Returns uint4.yyxw swizzling.
        /// </summary>
        public uint4 yyxw => new uint4(y, y, x, w);

        /// <summary>
        /// Returns uint4.ggra swizzling (equivalent to uint4.yyxw).
        /// </summary>
        public uint4 ggra => new uint4(y, y, x, w);

        /// <summary>
        /// Returns uint4.yyy swizzling.
        /// </summary>
        public uint3 yyy => new uint3(y, y, y);

        /// <summary>
        /// Returns uint4.ggg swizzling (equivalent to uint4.yyy).
        /// </summary>
        public uint3 ggg => new uint3(y, y, y);

        /// <summary>
        /// Returns uint4.yyyx swizzling.
        /// </summary>
        public uint4 yyyx => new uint4(y, y, y, x);

        /// <summary>
        /// Returns uint4.gggr swizzling (equivalent to uint4.yyyx).
        /// </summary>
        public uint4 gggr => new uint4(y, y, y, x);

        /// <summary>
        /// Returns uint4.yyyy swizzling.
        /// </summary>
        public uint4 yyyy => new uint4(y, y, y, y);

        /// <summary>
        /// Returns uint4.gggg swizzling (equivalent to uint4.yyyy).
        /// </summary>
        public uint4 gggg => new uint4(y, y, y, y);

        /// <summary>
        /// Returns uint4.yyyz swizzling.
        /// </summary>
        public uint4 yyyz => new uint4(y, y, y, z);

        /// <summary>
        /// Returns uint4.gggb swizzling (equivalent to uint4.yyyz).
        /// </summary>
        public uint4 gggb => new uint4(y, y, y, z);

        /// <summary>
        /// Returns uint4.yyyw swizzling.
        /// </summary>
        public uint4 yyyw => new uint4(y, y, y, w);

        /// <summary>
        /// Returns uint4.ggga swizzling (equivalent to uint4.yyyw).
        /// </summary>
        public uint4 ggga => new uint4(y, y, y, w);

        /// <summary>
        /// Returns uint4.yyz swizzling.
        /// </summary>
        public uint3 yyz => new uint3(y, y, z);

        /// <summary>
        /// Returns uint4.ggb swizzling (equivalent to uint4.yyz).
        /// </summary>
        public uint3 ggb => new uint3(y, y, z);

        /// <summary>
        /// Returns uint4.yyzx swizzling.
        /// </summary>
        public uint4 yyzx => new uint4(y, y, z, x);

        /// <summary>
        /// Returns uint4.ggbr swizzling (equivalent to uint4.yyzx).
        /// </summary>
        public uint4 ggbr => new uint4(y, y, z, x);

        /// <summary>
        /// Returns uint4.yyzy swizzling.
        /// </summary>
        public uint4 yyzy => new uint4(y, y, z, y);

        /// <summary>
        /// Returns uint4.ggbg swizzling (equivalent to uint4.yyzy).
        /// </summary>
        public uint4 ggbg => new uint4(y, y, z, y);

        /// <summary>
        /// Returns uint4.yyzz swizzling.
        /// </summary>
        public uint4 yyzz => new uint4(y, y, z, z);

        /// <summary>
        /// Returns uint4.ggbb swizzling (equivalent to uint4.yyzz).
        /// </summary>
        public uint4 ggbb => new uint4(y, y, z, z);

        /// <summary>
        /// Returns uint4.yyzw swizzling.
        /// </summary>
        public uint4 yyzw => new uint4(y, y, z, w);

        /// <summary>
        /// Returns uint4.ggba swizzling (equivalent to uint4.yyzw).
        /// </summary>
        public uint4 ggba => new uint4(y, y, z, w);

        /// <summary>
        /// Returns uint4.yyw swizzling.
        /// </summary>
        public uint3 yyw => new uint3(y, y, w);

        /// <summary>
        /// Returns uint4.gga swizzling (equivalent to uint4.yyw).
        /// </summary>
        public uint3 gga => new uint3(y, y, w);

        /// <summary>
        /// Returns uint4.yywx swizzling.
        /// </summary>
        public uint4 yywx => new uint4(y, y, w, x);

        /// <summary>
        /// Returns uint4.ggar swizzling (equivalent to uint4.yywx).
        /// </summary>
        public uint4 ggar => new uint4(y, y, w, x);

        /// <summary>
        /// Returns uint4.yywy swizzling.
        /// </summary>
        public uint4 yywy => new uint4(y, y, w, y);

        /// <summary>
        /// Returns uint4.ggag swizzling (equivalent to uint4.yywy).
        /// </summary>
        public uint4 ggag => new uint4(y, y, w, y);

        /// <summary>
        /// Returns uint4.yywz swizzling.
        /// </summary>
        public uint4 yywz => new uint4(y, y, w, z);

        /// <summary>
        /// Returns uint4.ggab swizzling (equivalent to uint4.yywz).
        /// </summary>
        public uint4 ggab => new uint4(y, y, w, z);

        /// <summary>
        /// Returns uint4.yyww swizzling.
        /// </summary>
        public uint4 yyww => new uint4(y, y, w, w);

        /// <summary>
        /// Returns uint4.ggaa swizzling (equivalent to uint4.yyww).
        /// </summary>
        public uint4 ggaa => new uint4(y, y, w, w);

        /// <summary>
        /// Returns uint4.yz swizzling.
        /// </summary>
        public uint2 yz => new uint2(y, z);

        /// <summary>
        /// Returns uint4.gb swizzling (equivalent to uint4.yz).
        /// </summary>
        public uint2 gb => new uint2(y, z);

        /// <summary>
        /// Returns uint4.yzx swizzling.
        /// </summary>
        public uint3 yzx => new uint3(y, z, x);

        /// <summary>
        /// Returns uint4.gbr swizzling (equivalent to uint4.yzx).
        /// </summary>
        public uint3 gbr => new uint3(y, z, x);

        /// <summary>
        /// Returns uint4.yzxx swizzling.
        /// </summary>
        public uint4 yzxx => new uint4(y, z, x, x);

        /// <summary>
        /// Returns uint4.gbrr swizzling (equivalent to uint4.yzxx).
        /// </summary>
        public uint4 gbrr => new uint4(y, z, x, x);

        /// <summary>
        /// Returns uint4.yzxy swizzling.
        /// </summary>
        public uint4 yzxy => new uint4(y, z, x, y);

        /// <summary>
        /// Returns uint4.gbrg swizzling (equivalent to uint4.yzxy).
        /// </summary>
        public uint4 gbrg => new uint4(y, z, x, y);

        /// <summary>
        /// Returns uint4.yzxz swizzling.
        /// </summary>
        public uint4 yzxz => new uint4(y, z, x, z);

        /// <summary>
        /// Returns uint4.gbrb swizzling (equivalent to uint4.yzxz).
        /// </summary>
        public uint4 gbrb => new uint4(y, z, x, z);

        /// <summary>
        /// Returns uint4.yzxw swizzling.
        /// </summary>
        public uint4 yzxw => new uint4(y, z, x, w);

        /// <summary>
        /// Returns uint4.gbra swizzling (equivalent to uint4.yzxw).
        /// </summary>
        public uint4 gbra => new uint4(y, z, x, w);

        /// <summary>
        /// Returns uint4.yzy swizzling.
        /// </summary>
        public uint3 yzy => new uint3(y, z, y);

        /// <summary>
        /// Returns uint4.gbg swizzling (equivalent to uint4.yzy).
        /// </summary>
        public uint3 gbg => new uint3(y, z, y);

        /// <summary>
        /// Returns uint4.yzyx swizzling.
        /// </summary>
        public uint4 yzyx => new uint4(y, z, y, x);

        /// <summary>
        /// Returns uint4.gbgr swizzling (equivalent to uint4.yzyx).
        /// </summary>
        public uint4 gbgr => new uint4(y, z, y, x);

        /// <summary>
        /// Returns uint4.yzyy swizzling.
        /// </summary>
        public uint4 yzyy => new uint4(y, z, y, y);

        /// <summary>
        /// Returns uint4.gbgg swizzling (equivalent to uint4.yzyy).
        /// </summary>
        public uint4 gbgg => new uint4(y, z, y, y);

        /// <summary>
        /// Returns uint4.yzyz swizzling.
        /// </summary>
        public uint4 yzyz => new uint4(y, z, y, z);

        /// <summary>
        /// Returns uint4.gbgb swizzling (equivalent to uint4.yzyz).
        /// </summary>
        public uint4 gbgb => new uint4(y, z, y, z);

        /// <summary>
        /// Returns uint4.yzyw swizzling.
        /// </summary>
        public uint4 yzyw => new uint4(y, z, y, w);

        /// <summary>
        /// Returns uint4.gbga swizzling (equivalent to uint4.yzyw).
        /// </summary>
        public uint4 gbga => new uint4(y, z, y, w);

        /// <summary>
        /// Returns uint4.yzz swizzling.
        /// </summary>
        public uint3 yzz => new uint3(y, z, z);

        /// <summary>
        /// Returns uint4.gbb swizzling (equivalent to uint4.yzz).
        /// </summary>
        public uint3 gbb => new uint3(y, z, z);

        /// <summary>
        /// Returns uint4.yzzx swizzling.
        /// </summary>
        public uint4 yzzx => new uint4(y, z, z, x);

        /// <summary>
        /// Returns uint4.gbbr swizzling (equivalent to uint4.yzzx).
        /// </summary>
        public uint4 gbbr => new uint4(y, z, z, x);

        /// <summary>
        /// Returns uint4.yzzy swizzling.
        /// </summary>
        public uint4 yzzy => new uint4(y, z, z, y);

        /// <summary>
        /// Returns uint4.gbbg swizzling (equivalent to uint4.yzzy).
        /// </summary>
        public uint4 gbbg => new uint4(y, z, z, y);

        /// <summary>
        /// Returns uint4.yzzz swizzling.
        /// </summary>
        public uint4 yzzz => new uint4(y, z, z, z);

        /// <summary>
        /// Returns uint4.gbbb swizzling (equivalent to uint4.yzzz).
        /// </summary>
        public uint4 gbbb => new uint4(y, z, z, z);

        /// <summary>
        /// Returns uint4.yzzw swizzling.
        /// </summary>
        public uint4 yzzw => new uint4(y, z, z, w);

        /// <summary>
        /// Returns uint4.gbba swizzling (equivalent to uint4.yzzw).
        /// </summary>
        public uint4 gbba => new uint4(y, z, z, w);

        /// <summary>
        /// Returns uint4.yzw swizzling.
        /// </summary>
        public uint3 yzw => new uint3(y, z, w);

        /// <summary>
        /// Returns uint4.gba swizzling (equivalent to uint4.yzw).
        /// </summary>
        public uint3 gba => new uint3(y, z, w);

        /// <summary>
        /// Returns uint4.yzwx swizzling.
        /// </summary>
        public uint4 yzwx => new uint4(y, z, w, x);

        /// <summary>
        /// Returns uint4.gbar swizzling (equivalent to uint4.yzwx).
        /// </summary>
        public uint4 gbar => new uint4(y, z, w, x);

        /// <summary>
        /// Returns uint4.yzwy swizzling.
        /// </summary>
        public uint4 yzwy => new uint4(y, z, w, y);

        /// <summary>
        /// Returns uint4.gbag swizzling (equivalent to uint4.yzwy).
        /// </summary>
        public uint4 gbag => new uint4(y, z, w, y);

        /// <summary>
        /// Returns uint4.yzwz swizzling.
        /// </summary>
        public uint4 yzwz => new uint4(y, z, w, z);

        /// <summary>
        /// Returns uint4.gbab swizzling (equivalent to uint4.yzwz).
        /// </summary>
        public uint4 gbab => new uint4(y, z, w, z);

        /// <summary>
        /// Returns uint4.yzww swizzling.
        /// </summary>
        public uint4 yzww => new uint4(y, z, w, w);

        /// <summary>
        /// Returns uint4.gbaa swizzling (equivalent to uint4.yzww).
        /// </summary>
        public uint4 gbaa => new uint4(y, z, w, w);

        /// <summary>
        /// Returns uint4.yw swizzling.
        /// </summary>
        public uint2 yw => new uint2(y, w);

        /// <summary>
        /// Returns uint4.ga swizzling (equivalent to uint4.yw).
        /// </summary>
        public uint2 ga => new uint2(y, w);

        /// <summary>
        /// Returns uint4.ywx swizzling.
        /// </summary>
        public uint3 ywx => new uint3(y, w, x);

        /// <summary>
        /// Returns uint4.gar swizzling (equivalent to uint4.ywx).
        /// </summary>
        public uint3 gar => new uint3(y, w, x);

        /// <summary>
        /// Returns uint4.ywxx swizzling.
        /// </summary>
        public uint4 ywxx => new uint4(y, w, x, x);

        /// <summary>
        /// Returns uint4.garr swizzling (equivalent to uint4.ywxx).
        /// </summary>
        public uint4 garr => new uint4(y, w, x, x);

        /// <summary>
        /// Returns uint4.ywxy swizzling.
        /// </summary>
        public uint4 ywxy => new uint4(y, w, x, y);

        /// <summary>
        /// Returns uint4.garg swizzling (equivalent to uint4.ywxy).
        /// </summary>
        public uint4 garg => new uint4(y, w, x, y);

        /// <summary>
        /// Returns uint4.ywxz swizzling.
        /// </summary>
        public uint4 ywxz => new uint4(y, w, x, z);

        /// <summary>
        /// Returns uint4.garb swizzling (equivalent to uint4.ywxz).
        /// </summary>
        public uint4 garb => new uint4(y, w, x, z);

        /// <summary>
        /// Returns uint4.ywxw swizzling.
        /// </summary>
        public uint4 ywxw => new uint4(y, w, x, w);

        /// <summary>
        /// Returns uint4.gara swizzling (equivalent to uint4.ywxw).
        /// </summary>
        public uint4 gara => new uint4(y, w, x, w);

        /// <summary>
        /// Returns uint4.ywy swizzling.
        /// </summary>
        public uint3 ywy => new uint3(y, w, y);

        /// <summary>
        /// Returns uint4.gag swizzling (equivalent to uint4.ywy).
        /// </summary>
        public uint3 gag => new uint3(y, w, y);

        /// <summary>
        /// Returns uint4.ywyx swizzling.
        /// </summary>
        public uint4 ywyx => new uint4(y, w, y, x);

        /// <summary>
        /// Returns uint4.gagr swizzling (equivalent to uint4.ywyx).
        /// </summary>
        public uint4 gagr => new uint4(y, w, y, x);

        /// <summary>
        /// Returns uint4.ywyy swizzling.
        /// </summary>
        public uint4 ywyy => new uint4(y, w, y, y);

        /// <summary>
        /// Returns uint4.gagg swizzling (equivalent to uint4.ywyy).
        /// </summary>
        public uint4 gagg => new uint4(y, w, y, y);

        /// <summary>
        /// Returns uint4.ywyz swizzling.
        /// </summary>
        public uint4 ywyz => new uint4(y, w, y, z);

        /// <summary>
        /// Returns uint4.gagb swizzling (equivalent to uint4.ywyz).
        /// </summary>
        public uint4 gagb => new uint4(y, w, y, z);

        /// <summary>
        /// Returns uint4.ywyw swizzling.
        /// </summary>
        public uint4 ywyw => new uint4(y, w, y, w);

        /// <summary>
        /// Returns uint4.gaga swizzling (equivalent to uint4.ywyw).
        /// </summary>
        public uint4 gaga => new uint4(y, w, y, w);

        /// <summary>
        /// Returns uint4.ywz swizzling.
        /// </summary>
        public uint3 ywz => new uint3(y, w, z);

        /// <summary>
        /// Returns uint4.gab swizzling (equivalent to uint4.ywz).
        /// </summary>
        public uint3 gab => new uint3(y, w, z);

        /// <summary>
        /// Returns uint4.ywzx swizzling.
        /// </summary>
        public uint4 ywzx => new uint4(y, w, z, x);

        /// <summary>
        /// Returns uint4.gabr swizzling (equivalent to uint4.ywzx).
        /// </summary>
        public uint4 gabr => new uint4(y, w, z, x);

        /// <summary>
        /// Returns uint4.ywzy swizzling.
        /// </summary>
        public uint4 ywzy => new uint4(y, w, z, y);

        /// <summary>
        /// Returns uint4.gabg swizzling (equivalent to uint4.ywzy).
        /// </summary>
        public uint4 gabg => new uint4(y, w, z, y);

        /// <summary>
        /// Returns uint4.ywzz swizzling.
        /// </summary>
        public uint4 ywzz => new uint4(y, w, z, z);

        /// <summary>
        /// Returns uint4.gabb swizzling (equivalent to uint4.ywzz).
        /// </summary>
        public uint4 gabb => new uint4(y, w, z, z);

        /// <summary>
        /// Returns uint4.ywzw swizzling.
        /// </summary>
        public uint4 ywzw => new uint4(y, w, z, w);

        /// <summary>
        /// Returns uint4.gaba swizzling (equivalent to uint4.ywzw).
        /// </summary>
        public uint4 gaba => new uint4(y, w, z, w);

        /// <summary>
        /// Returns uint4.yww swizzling.
        /// </summary>
        public uint3 yww => new uint3(y, w, w);

        /// <summary>
        /// Returns uint4.gaa swizzling (equivalent to uint4.yww).
        /// </summary>
        public uint3 gaa => new uint3(y, w, w);

        /// <summary>
        /// Returns uint4.ywwx swizzling.
        /// </summary>
        public uint4 ywwx => new uint4(y, w, w, x);

        /// <summary>
        /// Returns uint4.gaar swizzling (equivalent to uint4.ywwx).
        /// </summary>
        public uint4 gaar => new uint4(y, w, w, x);

        /// <summary>
        /// Returns uint4.ywwy swizzling.
        /// </summary>
        public uint4 ywwy => new uint4(y, w, w, y);

        /// <summary>
        /// Returns uint4.gaag swizzling (equivalent to uint4.ywwy).
        /// </summary>
        public uint4 gaag => new uint4(y, w, w, y);

        /// <summary>
        /// Returns uint4.ywwz swizzling.
        /// </summary>
        public uint4 ywwz => new uint4(y, w, w, z);

        /// <summary>
        /// Returns uint4.gaab swizzling (equivalent to uint4.ywwz).
        /// </summary>
        public uint4 gaab => new uint4(y, w, w, z);

        /// <summary>
        /// Returns uint4.ywww swizzling.
        /// </summary>
        public uint4 ywww => new uint4(y, w, w, w);

        /// <summary>
        /// Returns uint4.gaaa swizzling (equivalent to uint4.ywww).
        /// </summary>
        public uint4 gaaa => new uint4(y, w, w, w);

        /// <summary>
        /// Returns uint4.zx swizzling.
        /// </summary>
        public uint2 zx => new uint2(z, x);

        /// <summary>
        /// Returns uint4.br swizzling (equivalent to uint4.zx).
        /// </summary>
        public uint2 br => new uint2(z, x);

        /// <summary>
        /// Returns uint4.zxx swizzling.
        /// </summary>
        public uint3 zxx => new uint3(z, x, x);

        /// <summary>
        /// Returns uint4.brr swizzling (equivalent to uint4.zxx).
        /// </summary>
        public uint3 brr => new uint3(z, x, x);

        /// <summary>
        /// Returns uint4.zxxx swizzling.
        /// </summary>
        public uint4 zxxx => new uint4(z, x, x, x);

        /// <summary>
        /// Returns uint4.brrr swizzling (equivalent to uint4.zxxx).
        /// </summary>
        public uint4 brrr => new uint4(z, x, x, x);

        /// <summary>
        /// Returns uint4.zxxy swizzling.
        /// </summary>
        public uint4 zxxy => new uint4(z, x, x, y);

        /// <summary>
        /// Returns uint4.brrg swizzling (equivalent to uint4.zxxy).
        /// </summary>
        public uint4 brrg => new uint4(z, x, x, y);

        /// <summary>
        /// Returns uint4.zxxz swizzling.
        /// </summary>
        public uint4 zxxz => new uint4(z, x, x, z);

        /// <summary>
        /// Returns uint4.brrb swizzling (equivalent to uint4.zxxz).
        /// </summary>
        public uint4 brrb => new uint4(z, x, x, z);

        /// <summary>
        /// Returns uint4.zxxw swizzling.
        /// </summary>
        public uint4 zxxw => new uint4(z, x, x, w);

        /// <summary>
        /// Returns uint4.brra swizzling (equivalent to uint4.zxxw).
        /// </summary>
        public uint4 brra => new uint4(z, x, x, w);

        /// <summary>
        /// Returns uint4.zxy swizzling.
        /// </summary>
        public uint3 zxy => new uint3(z, x, y);

        /// <summary>
        /// Returns uint4.brg swizzling (equivalent to uint4.zxy).
        /// </summary>
        public uint3 brg => new uint3(z, x, y);

        /// <summary>
        /// Returns uint4.zxyx swizzling.
        /// </summary>
        public uint4 zxyx => new uint4(z, x, y, x);

        /// <summary>
        /// Returns uint4.brgr swizzling (equivalent to uint4.zxyx).
        /// </summary>
        public uint4 brgr => new uint4(z, x, y, x);

        /// <summary>
        /// Returns uint4.zxyy swizzling.
        /// </summary>
        public uint4 zxyy => new uint4(z, x, y, y);

        /// <summary>
        /// Returns uint4.brgg swizzling (equivalent to uint4.zxyy).
        /// </summary>
        public uint4 brgg => new uint4(z, x, y, y);

        /// <summary>
        /// Returns uint4.zxyz swizzling.
        /// </summary>
        public uint4 zxyz => new uint4(z, x, y, z);

        /// <summary>
        /// Returns uint4.brgb swizzling (equivalent to uint4.zxyz).
        /// </summary>
        public uint4 brgb => new uint4(z, x, y, z);

        /// <summary>
        /// Returns uint4.zxyw swizzling.
        /// </summary>
        public uint4 zxyw => new uint4(z, x, y, w);

        /// <summary>
        /// Returns uint4.brga swizzling (equivalent to uint4.zxyw).
        /// </summary>
        public uint4 brga => new uint4(z, x, y, w);

        /// <summary>
        /// Returns uint4.zxz swizzling.
        /// </summary>
        public uint3 zxz => new uint3(z, x, z);

        /// <summary>
        /// Returns uint4.brb swizzling (equivalent to uint4.zxz).
        /// </summary>
        public uint3 brb => new uint3(z, x, z);

        /// <summary>
        /// Returns uint4.zxzx swizzling.
        /// </summary>
        public uint4 zxzx => new uint4(z, x, z, x);

        /// <summary>
        /// Returns uint4.brbr swizzling (equivalent to uint4.zxzx).
        /// </summary>
        public uint4 brbr => new uint4(z, x, z, x);

        /// <summary>
        /// Returns uint4.zxzy swizzling.
        /// </summary>
        public uint4 zxzy => new uint4(z, x, z, y);

        /// <summary>
        /// Returns uint4.brbg swizzling (equivalent to uint4.zxzy).
        /// </summary>
        public uint4 brbg => new uint4(z, x, z, y);

        /// <summary>
        /// Returns uint4.zxzz swizzling.
        /// </summary>
        public uint4 zxzz => new uint4(z, x, z, z);

        /// <summary>
        /// Returns uint4.brbb swizzling (equivalent to uint4.zxzz).
        /// </summary>
        public uint4 brbb => new uint4(z, x, z, z);

        /// <summary>
        /// Returns uint4.zxzw swizzling.
        /// </summary>
        public uint4 zxzw => new uint4(z, x, z, w);

        /// <summary>
        /// Returns uint4.brba swizzling (equivalent to uint4.zxzw).
        /// </summary>
        public uint4 brba => new uint4(z, x, z, w);

        /// <summary>
        /// Returns uint4.zxw swizzling.
        /// </summary>
        public uint3 zxw => new uint3(z, x, w);

        /// <summary>
        /// Returns uint4.bra swizzling (equivalent to uint4.zxw).
        /// </summary>
        public uint3 bra => new uint3(z, x, w);

        /// <summary>
        /// Returns uint4.zxwx swizzling.
        /// </summary>
        public uint4 zxwx => new uint4(z, x, w, x);

        /// <summary>
        /// Returns uint4.brar swizzling (equivalent to uint4.zxwx).
        /// </summary>
        public uint4 brar => new uint4(z, x, w, x);

        /// <summary>
        /// Returns uint4.zxwy swizzling.
        /// </summary>
        public uint4 zxwy => new uint4(z, x, w, y);

        /// <summary>
        /// Returns uint4.brag swizzling (equivalent to uint4.zxwy).
        /// </summary>
        public uint4 brag => new uint4(z, x, w, y);

        /// <summary>
        /// Returns uint4.zxwz swizzling.
        /// </summary>
        public uint4 zxwz => new uint4(z, x, w, z);

        /// <summary>
        /// Returns uint4.brab swizzling (equivalent to uint4.zxwz).
        /// </summary>
        public uint4 brab => new uint4(z, x, w, z);

        /// <summary>
        /// Returns uint4.zxww swizzling.
        /// </summary>
        public uint4 zxww => new uint4(z, x, w, w);

        /// <summary>
        /// Returns uint4.braa swizzling (equivalent to uint4.zxww).
        /// </summary>
        public uint4 braa => new uint4(z, x, w, w);

        /// <summary>
        /// Returns uint4.zy swizzling.
        /// </summary>
        public uint2 zy => new uint2(z, y);

        /// <summary>
        /// Returns uint4.bg swizzling (equivalent to uint4.zy).
        /// </summary>
        public uint2 bg => new uint2(z, y);

        /// <summary>
        /// Returns uint4.zyx swizzling.
        /// </summary>
        public uint3 zyx => new uint3(z, y, x);

        /// <summary>
        /// Returns uint4.bgr swizzling (equivalent to uint4.zyx).
        /// </summary>
        public uint3 bgr => new uint3(z, y, x);

        /// <summary>
        /// Returns uint4.zyxx swizzling.
        /// </summary>
        public uint4 zyxx => new uint4(z, y, x, x);

        /// <summary>
        /// Returns uint4.bgrr swizzling (equivalent to uint4.zyxx).
        /// </summary>
        public uint4 bgrr => new uint4(z, y, x, x);

        /// <summary>
        /// Returns uint4.zyxy swizzling.
        /// </summary>
        public uint4 zyxy => new uint4(z, y, x, y);

        /// <summary>
        /// Returns uint4.bgrg swizzling (equivalent to uint4.zyxy).
        /// </summary>
        public uint4 bgrg => new uint4(z, y, x, y);

        /// <summary>
        /// Returns uint4.zyxz swizzling.
        /// </summary>
        public uint4 zyxz => new uint4(z, y, x, z);

        /// <summary>
        /// Returns uint4.bgrb swizzling (equivalent to uint4.zyxz).
        /// </summary>
        public uint4 bgrb => new uint4(z, y, x, z);

        /// <summary>
        /// Returns uint4.zyxw swizzling.
        /// </summary>
        public uint4 zyxw => new uint4(z, y, x, w);

        /// <summary>
        /// Returns uint4.bgra swizzling (equivalent to uint4.zyxw).
        /// </summary>
        public uint4 bgra => new uint4(z, y, x, w);

        /// <summary>
        /// Returns uint4.zyy swizzling.
        /// </summary>
        public uint3 zyy => new uint3(z, y, y);

        /// <summary>
        /// Returns uint4.bgg swizzling (equivalent to uint4.zyy).
        /// </summary>
        public uint3 bgg => new uint3(z, y, y);

        /// <summary>
        /// Returns uint4.zyyx swizzling.
        /// </summary>
        public uint4 zyyx => new uint4(z, y, y, x);

        /// <summary>
        /// Returns uint4.bggr swizzling (equivalent to uint4.zyyx).
        /// </summary>
        public uint4 bggr => new uint4(z, y, y, x);

        /// <summary>
        /// Returns uint4.zyyy swizzling.
        /// </summary>
        public uint4 zyyy => new uint4(z, y, y, y);

        /// <summary>
        /// Returns uint4.bggg swizzling (equivalent to uint4.zyyy).
        /// </summary>
        public uint4 bggg => new uint4(z, y, y, y);

        /// <summary>
        /// Returns uint4.zyyz swizzling.
        /// </summary>
        public uint4 zyyz => new uint4(z, y, y, z);

        /// <summary>
        /// Returns uint4.bggb swizzling (equivalent to uint4.zyyz).
        /// </summary>
        public uint4 bggb => new uint4(z, y, y, z);

        /// <summary>
        /// Returns uint4.zyyw swizzling.
        /// </summary>
        public uint4 zyyw => new uint4(z, y, y, w);

        /// <summary>
        /// Returns uint4.bgga swizzling (equivalent to uint4.zyyw).
        /// </summary>
        public uint4 bgga => new uint4(z, y, y, w);

        /// <summary>
        /// Returns uint4.zyz swizzling.
        /// </summary>
        public uint3 zyz => new uint3(z, y, z);

        /// <summary>
        /// Returns uint4.bgb swizzling (equivalent to uint4.zyz).
        /// </summary>
        public uint3 bgb => new uint3(z, y, z);

        /// <summary>
        /// Returns uint4.zyzx swizzling.
        /// </summary>
        public uint4 zyzx => new uint4(z, y, z, x);

        /// <summary>
        /// Returns uint4.bgbr swizzling (equivalent to uint4.zyzx).
        /// </summary>
        public uint4 bgbr => new uint4(z, y, z, x);

        /// <summary>
        /// Returns uint4.zyzy swizzling.
        /// </summary>
        public uint4 zyzy => new uint4(z, y, z, y);

        /// <summary>
        /// Returns uint4.bgbg swizzling (equivalent to uint4.zyzy).
        /// </summary>
        public uint4 bgbg => new uint4(z, y, z, y);

        /// <summary>
        /// Returns uint4.zyzz swizzling.
        /// </summary>
        public uint4 zyzz => new uint4(z, y, z, z);

        /// <summary>
        /// Returns uint4.bgbb swizzling (equivalent to uint4.zyzz).
        /// </summary>
        public uint4 bgbb => new uint4(z, y, z, z);

        /// <summary>
        /// Returns uint4.zyzw swizzling.
        /// </summary>
        public uint4 zyzw => new uint4(z, y, z, w);

        /// <summary>
        /// Returns uint4.bgba swizzling (equivalent to uint4.zyzw).
        /// </summary>
        public uint4 bgba => new uint4(z, y, z, w);

        /// <summary>
        /// Returns uint4.zyw swizzling.
        /// </summary>
        public uint3 zyw => new uint3(z, y, w);

        /// <summary>
        /// Returns uint4.bga swizzling (equivalent to uint4.zyw).
        /// </summary>
        public uint3 bga => new uint3(z, y, w);

        /// <summary>
        /// Returns uint4.zywx swizzling.
        /// </summary>
        public uint4 zywx => new uint4(z, y, w, x);

        /// <summary>
        /// Returns uint4.bgar swizzling (equivalent to uint4.zywx).
        /// </summary>
        public uint4 bgar => new uint4(z, y, w, x);

        /// <summary>
        /// Returns uint4.zywy swizzling.
        /// </summary>
        public uint4 zywy => new uint4(z, y, w, y);

        /// <summary>
        /// Returns uint4.bgag swizzling (equivalent to uint4.zywy).
        /// </summary>
        public uint4 bgag => new uint4(z, y, w, y);

        /// <summary>
        /// Returns uint4.zywz swizzling.
        /// </summary>
        public uint4 zywz => new uint4(z, y, w, z);

        /// <summary>
        /// Returns uint4.bgab swizzling (equivalent to uint4.zywz).
        /// </summary>
        public uint4 bgab => new uint4(z, y, w, z);

        /// <summary>
        /// Returns uint4.zyww swizzling.
        /// </summary>
        public uint4 zyww => new uint4(z, y, w, w);

        /// <summary>
        /// Returns uint4.bgaa swizzling (equivalent to uint4.zyww).
        /// </summary>
        public uint4 bgaa => new uint4(z, y, w, w);

        /// <summary>
        /// Returns uint4.zz swizzling.
        /// </summary>
        public uint2 zz => new uint2(z, z);

        /// <summary>
        /// Returns uint4.bb swizzling (equivalent to uint4.zz).
        /// </summary>
        public uint2 bb => new uint2(z, z);

        /// <summary>
        /// Returns uint4.zzx swizzling.
        /// </summary>
        public uint3 zzx => new uint3(z, z, x);

        /// <summary>
        /// Returns uint4.bbr swizzling (equivalent to uint4.zzx).
        /// </summary>
        public uint3 bbr => new uint3(z, z, x);

        /// <summary>
        /// Returns uint4.zzxx swizzling.
        /// </summary>
        public uint4 zzxx => new uint4(z, z, x, x);

        /// <summary>
        /// Returns uint4.bbrr swizzling (equivalent to uint4.zzxx).
        /// </summary>
        public uint4 bbrr => new uint4(z, z, x, x);

        /// <summary>
        /// Returns uint4.zzxy swizzling.
        /// </summary>
        public uint4 zzxy => new uint4(z, z, x, y);

        /// <summary>
        /// Returns uint4.bbrg swizzling (equivalent to uint4.zzxy).
        /// </summary>
        public uint4 bbrg => new uint4(z, z, x, y);

        /// <summary>
        /// Returns uint4.zzxz swizzling.
        /// </summary>
        public uint4 zzxz => new uint4(z, z, x, z);

        /// <summary>
        /// Returns uint4.bbrb swizzling (equivalent to uint4.zzxz).
        /// </summary>
        public uint4 bbrb => new uint4(z, z, x, z);

        /// <summary>
        /// Returns uint4.zzxw swizzling.
        /// </summary>
        public uint4 zzxw => new uint4(z, z, x, w);

        /// <summary>
        /// Returns uint4.bbra swizzling (equivalent to uint4.zzxw).
        /// </summary>
        public uint4 bbra => new uint4(z, z, x, w);

        /// <summary>
        /// Returns uint4.zzy swizzling.
        /// </summary>
        public uint3 zzy => new uint3(z, z, y);

        /// <summary>
        /// Returns uint4.bbg swizzling (equivalent to uint4.zzy).
        /// </summary>
        public uint3 bbg => new uint3(z, z, y);

        /// <summary>
        /// Returns uint4.zzyx swizzling.
        /// </summary>
        public uint4 zzyx => new uint4(z, z, y, x);

        /// <summary>
        /// Returns uint4.bbgr swizzling (equivalent to uint4.zzyx).
        /// </summary>
        public uint4 bbgr => new uint4(z, z, y, x);

        /// <summary>
        /// Returns uint4.zzyy swizzling.
        /// </summary>
        public uint4 zzyy => new uint4(z, z, y, y);

        /// <summary>
        /// Returns uint4.bbgg swizzling (equivalent to uint4.zzyy).
        /// </summary>
        public uint4 bbgg => new uint4(z, z, y, y);

        /// <summary>
        /// Returns uint4.zzyz swizzling.
        /// </summary>
        public uint4 zzyz => new uint4(z, z, y, z);

        /// <summary>
        /// Returns uint4.bbgb swizzling (equivalent to uint4.zzyz).
        /// </summary>
        public uint4 bbgb => new uint4(z, z, y, z);

        /// <summary>
        /// Returns uint4.zzyw swizzling.
        /// </summary>
        public uint4 zzyw => new uint4(z, z, y, w);

        /// <summary>
        /// Returns uint4.bbga swizzling (equivalent to uint4.zzyw).
        /// </summary>
        public uint4 bbga => new uint4(z, z, y, w);

        /// <summary>
        /// Returns uint4.zzz swizzling.
        /// </summary>
        public uint3 zzz => new uint3(z, z, z);

        /// <summary>
        /// Returns uint4.bbb swizzling (equivalent to uint4.zzz).
        /// </summary>
        public uint3 bbb => new uint3(z, z, z);

        /// <summary>
        /// Returns uint4.zzzx swizzling.
        /// </summary>
        public uint4 zzzx => new uint4(z, z, z, x);

        /// <summary>
        /// Returns uint4.bbbr swizzling (equivalent to uint4.zzzx).
        /// </summary>
        public uint4 bbbr => new uint4(z, z, z, x);

        /// <summary>
        /// Returns uint4.zzzy swizzling.
        /// </summary>
        public uint4 zzzy => new uint4(z, z, z, y);

        /// <summary>
        /// Returns uint4.bbbg swizzling (equivalent to uint4.zzzy).
        /// </summary>
        public uint4 bbbg => new uint4(z, z, z, y);

        /// <summary>
        /// Returns uint4.zzzz swizzling.
        /// </summary>
        public uint4 zzzz => new uint4(z, z, z, z);

        /// <summary>
        /// Returns uint4.bbbb swizzling (equivalent to uint4.zzzz).
        /// </summary>
        public uint4 bbbb => new uint4(z, z, z, z);

        /// <summary>
        /// Returns uint4.zzzw swizzling.
        /// </summary>
        public uint4 zzzw => new uint4(z, z, z, w);

        /// <summary>
        /// Returns uint4.bbba swizzling (equivalent to uint4.zzzw).
        /// </summary>
        public uint4 bbba => new uint4(z, z, z, w);

        /// <summary>
        /// Returns uint4.zzw swizzling.
        /// </summary>
        public uint3 zzw => new uint3(z, z, w);

        /// <summary>
        /// Returns uint4.bba swizzling (equivalent to uint4.zzw).
        /// </summary>
        public uint3 bba => new uint3(z, z, w);

        /// <summary>
        /// Returns uint4.zzwx swizzling.
        /// </summary>
        public uint4 zzwx => new uint4(z, z, w, x);

        /// <summary>
        /// Returns uint4.bbar swizzling (equivalent to uint4.zzwx).
        /// </summary>
        public uint4 bbar => new uint4(z, z, w, x);

        /// <summary>
        /// Returns uint4.zzwy swizzling.
        /// </summary>
        public uint4 zzwy => new uint4(z, z, w, y);

        /// <summary>
        /// Returns uint4.bbag swizzling (equivalent to uint4.zzwy).
        /// </summary>
        public uint4 bbag => new uint4(z, z, w, y);

        /// <summary>
        /// Returns uint4.zzwz swizzling.
        /// </summary>
        public uint4 zzwz => new uint4(z, z, w, z);

        /// <summary>
        /// Returns uint4.bbab swizzling (equivalent to uint4.zzwz).
        /// </summary>
        public uint4 bbab => new uint4(z, z, w, z);

        /// <summary>
        /// Returns uint4.zzww swizzling.
        /// </summary>
        public uint4 zzww => new uint4(z, z, w, w);

        /// <summary>
        /// Returns uint4.bbaa swizzling (equivalent to uint4.zzww).
        /// </summary>
        public uint4 bbaa => new uint4(z, z, w, w);

        /// <summary>
        /// Returns uint4.zw swizzling.
        /// </summary>
        public uint2 zw => new uint2(z, w);

        /// <summary>
        /// Returns uint4.ba swizzling (equivalent to uint4.zw).
        /// </summary>
        public uint2 ba => new uint2(z, w);

        /// <summary>
        /// Returns uint4.zwx swizzling.
        /// </summary>
        public uint3 zwx => new uint3(z, w, x);

        /// <summary>
        /// Returns uint4.bar swizzling (equivalent to uint4.zwx).
        /// </summary>
        public uint3 bar => new uint3(z, w, x);

        /// <summary>
        /// Returns uint4.zwxx swizzling.
        /// </summary>
        public uint4 zwxx => new uint4(z, w, x, x);

        /// <summary>
        /// Returns uint4.barr swizzling (equivalent to uint4.zwxx).
        /// </summary>
        public uint4 barr => new uint4(z, w, x, x);

        /// <summary>
        /// Returns uint4.zwxy swizzling.
        /// </summary>
        public uint4 zwxy => new uint4(z, w, x, y);

        /// <summary>
        /// Returns uint4.barg swizzling (equivalent to uint4.zwxy).
        /// </summary>
        public uint4 barg => new uint4(z, w, x, y);

        /// <summary>
        /// Returns uint4.zwxz swizzling.
        /// </summary>
        public uint4 zwxz => new uint4(z, w, x, z);

        /// <summary>
        /// Returns uint4.barb swizzling (equivalent to uint4.zwxz).
        /// </summary>
        public uint4 barb => new uint4(z, w, x, z);

        /// <summary>
        /// Returns uint4.zwxw swizzling.
        /// </summary>
        public uint4 zwxw => new uint4(z, w, x, w);

        /// <summary>
        /// Returns uint4.bara swizzling (equivalent to uint4.zwxw).
        /// </summary>
        public uint4 bara => new uint4(z, w, x, w);

        /// <summary>
        /// Returns uint4.zwy swizzling.
        /// </summary>
        public uint3 zwy => new uint3(z, w, y);

        /// <summary>
        /// Returns uint4.bag swizzling (equivalent to uint4.zwy).
        /// </summary>
        public uint3 bag => new uint3(z, w, y);

        /// <summary>
        /// Returns uint4.zwyx swizzling.
        /// </summary>
        public uint4 zwyx => new uint4(z, w, y, x);

        /// <summary>
        /// Returns uint4.bagr swizzling (equivalent to uint4.zwyx).
        /// </summary>
        public uint4 bagr => new uint4(z, w, y, x);

        /// <summary>
        /// Returns uint4.zwyy swizzling.
        /// </summary>
        public uint4 zwyy => new uint4(z, w, y, y);

        /// <summary>
        /// Returns uint4.bagg swizzling (equivalent to uint4.zwyy).
        /// </summary>
        public uint4 bagg => new uint4(z, w, y, y);

        /// <summary>
        /// Returns uint4.zwyz swizzling.
        /// </summary>
        public uint4 zwyz => new uint4(z, w, y, z);

        /// <summary>
        /// Returns uint4.bagb swizzling (equivalent to uint4.zwyz).
        /// </summary>
        public uint4 bagb => new uint4(z, w, y, z);

        /// <summary>
        /// Returns uint4.zwyw swizzling.
        /// </summary>
        public uint4 zwyw => new uint4(z, w, y, w);

        /// <summary>
        /// Returns uint4.baga swizzling (equivalent to uint4.zwyw).
        /// </summary>
        public uint4 baga => new uint4(z, w, y, w);

        /// <summary>
        /// Returns uint4.zwz swizzling.
        /// </summary>
        public uint3 zwz => new uint3(z, w, z);

        /// <summary>
        /// Returns uint4.bab swizzling (equivalent to uint4.zwz).
        /// </summary>
        public uint3 bab => new uint3(z, w, z);

        /// <summary>
        /// Returns uint4.zwzx swizzling.
        /// </summary>
        public uint4 zwzx => new uint4(z, w, z, x);

        /// <summary>
        /// Returns uint4.babr swizzling (equivalent to uint4.zwzx).
        /// </summary>
        public uint4 babr => new uint4(z, w, z, x);

        /// <summary>
        /// Returns uint4.zwzy swizzling.
        /// </summary>
        public uint4 zwzy => new uint4(z, w, z, y);

        /// <summary>
        /// Returns uint4.babg swizzling (equivalent to uint4.zwzy).
        /// </summary>
        public uint4 babg => new uint4(z, w, z, y);

        /// <summary>
        /// Returns uint4.zwzz swizzling.
        /// </summary>
        public uint4 zwzz => new uint4(z, w, z, z);

        /// <summary>
        /// Returns uint4.babb swizzling (equivalent to uint4.zwzz).
        /// </summary>
        public uint4 babb => new uint4(z, w, z, z);

        /// <summary>
        /// Returns uint4.zwzw swizzling.
        /// </summary>
        public uint4 zwzw => new uint4(z, w, z, w);

        /// <summary>
        /// Returns uint4.baba swizzling (equivalent to uint4.zwzw).
        /// </summary>
        public uint4 baba => new uint4(z, w, z, w);

        /// <summary>
        /// Returns uint4.zww swizzling.
        /// </summary>
        public uint3 zww => new uint3(z, w, w);

        /// <summary>
        /// Returns uint4.baa swizzling (equivalent to uint4.zww).
        /// </summary>
        public uint3 baa => new uint3(z, w, w);

        /// <summary>
        /// Returns uint4.zwwx swizzling.
        /// </summary>
        public uint4 zwwx => new uint4(z, w, w, x);

        /// <summary>
        /// Returns uint4.baar swizzling (equivalent to uint4.zwwx).
        /// </summary>
        public uint4 baar => new uint4(z, w, w, x);

        /// <summary>
        /// Returns uint4.zwwy swizzling.
        /// </summary>
        public uint4 zwwy => new uint4(z, w, w, y);

        /// <summary>
        /// Returns uint4.baag swizzling (equivalent to uint4.zwwy).
        /// </summary>
        public uint4 baag => new uint4(z, w, w, y);

        /// <summary>
        /// Returns uint4.zwwz swizzling.
        /// </summary>
        public uint4 zwwz => new uint4(z, w, w, z);

        /// <summary>
        /// Returns uint4.baab swizzling (equivalent to uint4.zwwz).
        /// </summary>
        public uint4 baab => new uint4(z, w, w, z);

        /// <summary>
        /// Returns uint4.zwww swizzling.
        /// </summary>
        public uint4 zwww => new uint4(z, w, w, w);

        /// <summary>
        /// Returns uint4.baaa swizzling (equivalent to uint4.zwww).
        /// </summary>
        public uint4 baaa => new uint4(z, w, w, w);

        /// <summary>
        /// Returns uint4.wx swizzling.
        /// </summary>
        public uint2 wx => new uint2(w, x);

        /// <summary>
        /// Returns uint4.ar swizzling (equivalent to uint4.wx).
        /// </summary>
        public uint2 ar => new uint2(w, x);

        /// <summary>
        /// Returns uint4.wxx swizzling.
        /// </summary>
        public uint3 wxx => new uint3(w, x, x);

        /// <summary>
        /// Returns uint4.arr swizzling (equivalent to uint4.wxx).
        /// </summary>
        public uint3 arr => new uint3(w, x, x);

        /// <summary>
        /// Returns uint4.wxxx swizzling.
        /// </summary>
        public uint4 wxxx => new uint4(w, x, x, x);

        /// <summary>
        /// Returns uint4.arrr swizzling (equivalent to uint4.wxxx).
        /// </summary>
        public uint4 arrr => new uint4(w, x, x, x);

        /// <summary>
        /// Returns uint4.wxxy swizzling.
        /// </summary>
        public uint4 wxxy => new uint4(w, x, x, y);

        /// <summary>
        /// Returns uint4.arrg swizzling (equivalent to uint4.wxxy).
        /// </summary>
        public uint4 arrg => new uint4(w, x, x, y);

        /// <summary>
        /// Returns uint4.wxxz swizzling.
        /// </summary>
        public uint4 wxxz => new uint4(w, x, x, z);

        /// <summary>
        /// Returns uint4.arrb swizzling (equivalent to uint4.wxxz).
        /// </summary>
        public uint4 arrb => new uint4(w, x, x, z);

        /// <summary>
        /// Returns uint4.wxxw swizzling.
        /// </summary>
        public uint4 wxxw => new uint4(w, x, x, w);

        /// <summary>
        /// Returns uint4.arra swizzling (equivalent to uint4.wxxw).
        /// </summary>
        public uint4 arra => new uint4(w, x, x, w);

        /// <summary>
        /// Returns uint4.wxy swizzling.
        /// </summary>
        public uint3 wxy => new uint3(w, x, y);

        /// <summary>
        /// Returns uint4.arg swizzling (equivalent to uint4.wxy).
        /// </summary>
        public uint3 arg => new uint3(w, x, y);

        /// <summary>
        /// Returns uint4.wxyx swizzling.
        /// </summary>
        public uint4 wxyx => new uint4(w, x, y, x);

        /// <summary>
        /// Returns uint4.argr swizzling (equivalent to uint4.wxyx).
        /// </summary>
        public uint4 argr => new uint4(w, x, y, x);

        /// <summary>
        /// Returns uint4.wxyy swizzling.
        /// </summary>
        public uint4 wxyy => new uint4(w, x, y, y);

        /// <summary>
        /// Returns uint4.argg swizzling (equivalent to uint4.wxyy).
        /// </summary>
        public uint4 argg => new uint4(w, x, y, y);

        /// <summary>
        /// Returns uint4.wxyz swizzling.
        /// </summary>
        public uint4 wxyz => new uint4(w, x, y, z);

        /// <summary>
        /// Returns uint4.argb swizzling (equivalent to uint4.wxyz).
        /// </summary>
        public uint4 argb => new uint4(w, x, y, z);

        /// <summary>
        /// Returns uint4.wxyw swizzling.
        /// </summary>
        public uint4 wxyw => new uint4(w, x, y, w);

        /// <summary>
        /// Returns uint4.arga swizzling (equivalent to uint4.wxyw).
        /// </summary>
        public uint4 arga => new uint4(w, x, y, w);

        /// <summary>
        /// Returns uint4.wxz swizzling.
        /// </summary>
        public uint3 wxz => new uint3(w, x, z);

        /// <summary>
        /// Returns uint4.arb swizzling (equivalent to uint4.wxz).
        /// </summary>
        public uint3 arb => new uint3(w, x, z);

        /// <summary>
        /// Returns uint4.wxzx swizzling.
        /// </summary>
        public uint4 wxzx => new uint4(w, x, z, x);

        /// <summary>
        /// Returns uint4.arbr swizzling (equivalent to uint4.wxzx).
        /// </summary>
        public uint4 arbr => new uint4(w, x, z, x);

        /// <summary>
        /// Returns uint4.wxzy swizzling.
        /// </summary>
        public uint4 wxzy => new uint4(w, x, z, y);

        /// <summary>
        /// Returns uint4.arbg swizzling (equivalent to uint4.wxzy).
        /// </summary>
        public uint4 arbg => new uint4(w, x, z, y);

        /// <summary>
        /// Returns uint4.wxzz swizzling.
        /// </summary>
        public uint4 wxzz => new uint4(w, x, z, z);

        /// <summary>
        /// Returns uint4.arbb swizzling (equivalent to uint4.wxzz).
        /// </summary>
        public uint4 arbb => new uint4(w, x, z, z);

        /// <summary>
        /// Returns uint4.wxzw swizzling.
        /// </summary>
        public uint4 wxzw => new uint4(w, x, z, w);

        /// <summary>
        /// Returns uint4.arba swizzling (equivalent to uint4.wxzw).
        /// </summary>
        public uint4 arba => new uint4(w, x, z, w);

        /// <summary>
        /// Returns uint4.wxw swizzling.
        /// </summary>
        public uint3 wxw => new uint3(w, x, w);

        /// <summary>
        /// Returns uint4.ara swizzling (equivalent to uint4.wxw).
        /// </summary>
        public uint3 ara => new uint3(w, x, w);

        /// <summary>
        /// Returns uint4.wxwx swizzling.
        /// </summary>
        public uint4 wxwx => new uint4(w, x, w, x);

        /// <summary>
        /// Returns uint4.arar swizzling (equivalent to uint4.wxwx).
        /// </summary>
        public uint4 arar => new uint4(w, x, w, x);

        /// <summary>
        /// Returns uint4.wxwy swizzling.
        /// </summary>
        public uint4 wxwy => new uint4(w, x, w, y);

        /// <summary>
        /// Returns uint4.arag swizzling (equivalent to uint4.wxwy).
        /// </summary>
        public uint4 arag => new uint4(w, x, w, y);

        /// <summary>
        /// Returns uint4.wxwz swizzling.
        /// </summary>
        public uint4 wxwz => new uint4(w, x, w, z);

        /// <summary>
        /// Returns uint4.arab swizzling (equivalent to uint4.wxwz).
        /// </summary>
        public uint4 arab => new uint4(w, x, w, z);

        /// <summary>
        /// Returns uint4.wxww swizzling.
        /// </summary>
        public uint4 wxww => new uint4(w, x, w, w);

        /// <summary>
        /// Returns uint4.araa swizzling (equivalent to uint4.wxww).
        /// </summary>
        public uint4 araa => new uint4(w, x, w, w);

        /// <summary>
        /// Returns uint4.wy swizzling.
        /// </summary>
        public uint2 wy => new uint2(w, y);

        /// <summary>
        /// Returns uint4.ag swizzling (equivalent to uint4.wy).
        /// </summary>
        public uint2 ag => new uint2(w, y);

        /// <summary>
        /// Returns uint4.wyx swizzling.
        /// </summary>
        public uint3 wyx => new uint3(w, y, x);

        /// <summary>
        /// Returns uint4.agr swizzling (equivalent to uint4.wyx).
        /// </summary>
        public uint3 agr => new uint3(w, y, x);

        /// <summary>
        /// Returns uint4.wyxx swizzling.
        /// </summary>
        public uint4 wyxx => new uint4(w, y, x, x);

        /// <summary>
        /// Returns uint4.agrr swizzling (equivalent to uint4.wyxx).
        /// </summary>
        public uint4 agrr => new uint4(w, y, x, x);

        /// <summary>
        /// Returns uint4.wyxy swizzling.
        /// </summary>
        public uint4 wyxy => new uint4(w, y, x, y);

        /// <summary>
        /// Returns uint4.agrg swizzling (equivalent to uint4.wyxy).
        /// </summary>
        public uint4 agrg => new uint4(w, y, x, y);

        /// <summary>
        /// Returns uint4.wyxz swizzling.
        /// </summary>
        public uint4 wyxz => new uint4(w, y, x, z);

        /// <summary>
        /// Returns uint4.agrb swizzling (equivalent to uint4.wyxz).
        /// </summary>
        public uint4 agrb => new uint4(w, y, x, z);

        /// <summary>
        /// Returns uint4.wyxw swizzling.
        /// </summary>
        public uint4 wyxw => new uint4(w, y, x, w);

        /// <summary>
        /// Returns uint4.agra swizzling (equivalent to uint4.wyxw).
        /// </summary>
        public uint4 agra => new uint4(w, y, x, w);

        /// <summary>
        /// Returns uint4.wyy swizzling.
        /// </summary>
        public uint3 wyy => new uint3(w, y, y);

        /// <summary>
        /// Returns uint4.agg swizzling (equivalent to uint4.wyy).
        /// </summary>
        public uint3 agg => new uint3(w, y, y);

        /// <summary>
        /// Returns uint4.wyyx swizzling.
        /// </summary>
        public uint4 wyyx => new uint4(w, y, y, x);

        /// <summary>
        /// Returns uint4.aggr swizzling (equivalent to uint4.wyyx).
        /// </summary>
        public uint4 aggr => new uint4(w, y, y, x);

        /// <summary>
        /// Returns uint4.wyyy swizzling.
        /// </summary>
        public uint4 wyyy => new uint4(w, y, y, y);

        /// <summary>
        /// Returns uint4.aggg swizzling (equivalent to uint4.wyyy).
        /// </summary>
        public uint4 aggg => new uint4(w, y, y, y);

        /// <summary>
        /// Returns uint4.wyyz swizzling.
        /// </summary>
        public uint4 wyyz => new uint4(w, y, y, z);

        /// <summary>
        /// Returns uint4.aggb swizzling (equivalent to uint4.wyyz).
        /// </summary>
        public uint4 aggb => new uint4(w, y, y, z);

        /// <summary>
        /// Returns uint4.wyyw swizzling.
        /// </summary>
        public uint4 wyyw => new uint4(w, y, y, w);

        /// <summary>
        /// Returns uint4.agga swizzling (equivalent to uint4.wyyw).
        /// </summary>
        public uint4 agga => new uint4(w, y, y, w);

        /// <summary>
        /// Returns uint4.wyz swizzling.
        /// </summary>
        public uint3 wyz => new uint3(w, y, z);

        /// <summary>
        /// Returns uint4.agb swizzling (equivalent to uint4.wyz).
        /// </summary>
        public uint3 agb => new uint3(w, y, z);

        /// <summary>
        /// Returns uint4.wyzx swizzling.
        /// </summary>
        public uint4 wyzx => new uint4(w, y, z, x);

        /// <summary>
        /// Returns uint4.agbr swizzling (equivalent to uint4.wyzx).
        /// </summary>
        public uint4 agbr => new uint4(w, y, z, x);

        /// <summary>
        /// Returns uint4.wyzy swizzling.
        /// </summary>
        public uint4 wyzy => new uint4(w, y, z, y);

        /// <summary>
        /// Returns uint4.agbg swizzling (equivalent to uint4.wyzy).
        /// </summary>
        public uint4 agbg => new uint4(w, y, z, y);

        /// <summary>
        /// Returns uint4.wyzz swizzling.
        /// </summary>
        public uint4 wyzz => new uint4(w, y, z, z);

        /// <summary>
        /// Returns uint4.agbb swizzling (equivalent to uint4.wyzz).
        /// </summary>
        public uint4 agbb => new uint4(w, y, z, z);

        /// <summary>
        /// Returns uint4.wyzw swizzling.
        /// </summary>
        public uint4 wyzw => new uint4(w, y, z, w);

        /// <summary>
        /// Returns uint4.agba swizzling (equivalent to uint4.wyzw).
        /// </summary>
        public uint4 agba => new uint4(w, y, z, w);

        /// <summary>
        /// Returns uint4.wyw swizzling.
        /// </summary>
        public uint3 wyw => new uint3(w, y, w);

        /// <summary>
        /// Returns uint4.aga swizzling (equivalent to uint4.wyw).
        /// </summary>
        public uint3 aga => new uint3(w, y, w);

        /// <summary>
        /// Returns uint4.wywx swizzling.
        /// </summary>
        public uint4 wywx => new uint4(w, y, w, x);

        /// <summary>
        /// Returns uint4.agar swizzling (equivalent to uint4.wywx).
        /// </summary>
        public uint4 agar => new uint4(w, y, w, x);

        /// <summary>
        /// Returns uint4.wywy swizzling.
        /// </summary>
        public uint4 wywy => new uint4(w, y, w, y);

        /// <summary>
        /// Returns uint4.agag swizzling (equivalent to uint4.wywy).
        /// </summary>
        public uint4 agag => new uint4(w, y, w, y);

        /// <summary>
        /// Returns uint4.wywz swizzling.
        /// </summary>
        public uint4 wywz => new uint4(w, y, w, z);

        /// <summary>
        /// Returns uint4.agab swizzling (equivalent to uint4.wywz).
        /// </summary>
        public uint4 agab => new uint4(w, y, w, z);

        /// <summary>
        /// Returns uint4.wyww swizzling.
        /// </summary>
        public uint4 wyww => new uint4(w, y, w, w);

        /// <summary>
        /// Returns uint4.agaa swizzling (equivalent to uint4.wyww).
        /// </summary>
        public uint4 agaa => new uint4(w, y, w, w);

        /// <summary>
        /// Returns uint4.wz swizzling.
        /// </summary>
        public uint2 wz => new uint2(w, z);

        /// <summary>
        /// Returns uint4.ab swizzling (equivalent to uint4.wz).
        /// </summary>
        public uint2 ab => new uint2(w, z);

        /// <summary>
        /// Returns uint4.wzx swizzling.
        /// </summary>
        public uint3 wzx => new uint3(w, z, x);

        /// <summary>
        /// Returns uint4.abr swizzling (equivalent to uint4.wzx).
        /// </summary>
        public uint3 abr => new uint3(w, z, x);

        /// <summary>
        /// Returns uint4.wzxx swizzling.
        /// </summary>
        public uint4 wzxx => new uint4(w, z, x, x);

        /// <summary>
        /// Returns uint4.abrr swizzling (equivalent to uint4.wzxx).
        /// </summary>
        public uint4 abrr => new uint4(w, z, x, x);

        /// <summary>
        /// Returns uint4.wzxy swizzling.
        /// </summary>
        public uint4 wzxy => new uint4(w, z, x, y);

        /// <summary>
        /// Returns uint4.abrg swizzling (equivalent to uint4.wzxy).
        /// </summary>
        public uint4 abrg => new uint4(w, z, x, y);

        /// <summary>
        /// Returns uint4.wzxz swizzling.
        /// </summary>
        public uint4 wzxz => new uint4(w, z, x, z);

        /// <summary>
        /// Returns uint4.abrb swizzling (equivalent to uint4.wzxz).
        /// </summary>
        public uint4 abrb => new uint4(w, z, x, z);

        /// <summary>
        /// Returns uint4.wzxw swizzling.
        /// </summary>
        public uint4 wzxw => new uint4(w, z, x, w);

        /// <summary>
        /// Returns uint4.abra swizzling (equivalent to uint4.wzxw).
        /// </summary>
        public uint4 abra => new uint4(w, z, x, w);

        /// <summary>
        /// Returns uint4.wzy swizzling.
        /// </summary>
        public uint3 wzy => new uint3(w, z, y);

        /// <summary>
        /// Returns uint4.abg swizzling (equivalent to uint4.wzy).
        /// </summary>
        public uint3 abg => new uint3(w, z, y);

        /// <summary>
        /// Returns uint4.wzyx swizzling.
        /// </summary>
        public uint4 wzyx => new uint4(w, z, y, x);

        /// <summary>
        /// Returns uint4.abgr swizzling (equivalent to uint4.wzyx).
        /// </summary>
        public uint4 abgr => new uint4(w, z, y, x);

        /// <summary>
        /// Returns uint4.wzyy swizzling.
        /// </summary>
        public uint4 wzyy => new uint4(w, z, y, y);

        /// <summary>
        /// Returns uint4.abgg swizzling (equivalent to uint4.wzyy).
        /// </summary>
        public uint4 abgg => new uint4(w, z, y, y);

        /// <summary>
        /// Returns uint4.wzyz swizzling.
        /// </summary>
        public uint4 wzyz => new uint4(w, z, y, z);

        /// <summary>
        /// Returns uint4.abgb swizzling (equivalent to uint4.wzyz).
        /// </summary>
        public uint4 abgb => new uint4(w, z, y, z);

        /// <summary>
        /// Returns uint4.wzyw swizzling.
        /// </summary>
        public uint4 wzyw => new uint4(w, z, y, w);

        /// <summary>
        /// Returns uint4.abga swizzling (equivalent to uint4.wzyw).
        /// </summary>
        public uint4 abga => new uint4(w, z, y, w);

        /// <summary>
        /// Returns uint4.wzz swizzling.
        /// </summary>
        public uint3 wzz => new uint3(w, z, z);

        /// <summary>
        /// Returns uint4.abb swizzling (equivalent to uint4.wzz).
        /// </summary>
        public uint3 abb => new uint3(w, z, z);

        /// <summary>
        /// Returns uint4.wzzx swizzling.
        /// </summary>
        public uint4 wzzx => new uint4(w, z, z, x);

        /// <summary>
        /// Returns uint4.abbr swizzling (equivalent to uint4.wzzx).
        /// </summary>
        public uint4 abbr => new uint4(w, z, z, x);

        /// <summary>
        /// Returns uint4.wzzy swizzling.
        /// </summary>
        public uint4 wzzy => new uint4(w, z, z, y);

        /// <summary>
        /// Returns uint4.abbg swizzling (equivalent to uint4.wzzy).
        /// </summary>
        public uint4 abbg => new uint4(w, z, z, y);

        /// <summary>
        /// Returns uint4.wzzz swizzling.
        /// </summary>
        public uint4 wzzz => new uint4(w, z, z, z);

        /// <summary>
        /// Returns uint4.abbb swizzling (equivalent to uint4.wzzz).
        /// </summary>
        public uint4 abbb => new uint4(w, z, z, z);

        /// <summary>
        /// Returns uint4.wzzw swizzling.
        /// </summary>
        public uint4 wzzw => new uint4(w, z, z, w);

        /// <summary>
        /// Returns uint4.abba swizzling (equivalent to uint4.wzzw).
        /// </summary>
        public uint4 abba => new uint4(w, z, z, w);

        /// <summary>
        /// Returns uint4.wzw swizzling.
        /// </summary>
        public uint3 wzw => new uint3(w, z, w);

        /// <summary>
        /// Returns uint4.aba swizzling (equivalent to uint4.wzw).
        /// </summary>
        public uint3 aba => new uint3(w, z, w);

        /// <summary>
        /// Returns uint4.wzwx swizzling.
        /// </summary>
        public uint4 wzwx => new uint4(w, z, w, x);

        /// <summary>
        /// Returns uint4.abar swizzling (equivalent to uint4.wzwx).
        /// </summary>
        public uint4 abar => new uint4(w, z, w, x);

        /// <summary>
        /// Returns uint4.wzwy swizzling.
        /// </summary>
        public uint4 wzwy => new uint4(w, z, w, y);

        /// <summary>
        /// Returns uint4.abag swizzling (equivalent to uint4.wzwy).
        /// </summary>
        public uint4 abag => new uint4(w, z, w, y);

        /// <summary>
        /// Returns uint4.wzwz swizzling.
        /// </summary>
        public uint4 wzwz => new uint4(w, z, w, z);

        /// <summary>
        /// Returns uint4.abab swizzling (equivalent to uint4.wzwz).
        /// </summary>
        public uint4 abab => new uint4(w, z, w, z);

        /// <summary>
        /// Returns uint4.wzww swizzling.
        /// </summary>
        public uint4 wzww => new uint4(w, z, w, w);

        /// <summary>
        /// Returns uint4.abaa swizzling (equivalent to uint4.wzww).
        /// </summary>
        public uint4 abaa => new uint4(w, z, w, w);

        /// <summary>
        /// Returns uint4.ww swizzling.
        /// </summary>
        public uint2 ww => new uint2(w, w);

        /// <summary>
        /// Returns uint4.aa swizzling (equivalent to uint4.ww).
        /// </summary>
        public uint2 aa => new uint2(w, w);

        /// <summary>
        /// Returns uint4.wwx swizzling.
        /// </summary>
        public uint3 wwx => new uint3(w, w, x);

        /// <summary>
        /// Returns uint4.aar swizzling (equivalent to uint4.wwx).
        /// </summary>
        public uint3 aar => new uint3(w, w, x);

        /// <summary>
        /// Returns uint4.wwxx swizzling.
        /// </summary>
        public uint4 wwxx => new uint4(w, w, x, x);

        /// <summary>
        /// Returns uint4.aarr swizzling (equivalent to uint4.wwxx).
        /// </summary>
        public uint4 aarr => new uint4(w, w, x, x);

        /// <summary>
        /// Returns uint4.wwxy swizzling.
        /// </summary>
        public uint4 wwxy => new uint4(w, w, x, y);

        /// <summary>
        /// Returns uint4.aarg swizzling (equivalent to uint4.wwxy).
        /// </summary>
        public uint4 aarg => new uint4(w, w, x, y);

        /// <summary>
        /// Returns uint4.wwxz swizzling.
        /// </summary>
        public uint4 wwxz => new uint4(w, w, x, z);

        /// <summary>
        /// Returns uint4.aarb swizzling (equivalent to uint4.wwxz).
        /// </summary>
        public uint4 aarb => new uint4(w, w, x, z);

        /// <summary>
        /// Returns uint4.wwxw swizzling.
        /// </summary>
        public uint4 wwxw => new uint4(w, w, x, w);

        /// <summary>
        /// Returns uint4.aara swizzling (equivalent to uint4.wwxw).
        /// </summary>
        public uint4 aara => new uint4(w, w, x, w);

        /// <summary>
        /// Returns uint4.wwy swizzling.
        /// </summary>
        public uint3 wwy => new uint3(w, w, y);

        /// <summary>
        /// Returns uint4.aag swizzling (equivalent to uint4.wwy).
        /// </summary>
        public uint3 aag => new uint3(w, w, y);

        /// <summary>
        /// Returns uint4.wwyx swizzling.
        /// </summary>
        public uint4 wwyx => new uint4(w, w, y, x);

        /// <summary>
        /// Returns uint4.aagr swizzling (equivalent to uint4.wwyx).
        /// </summary>
        public uint4 aagr => new uint4(w, w, y, x);

        /// <summary>
        /// Returns uint4.wwyy swizzling.
        /// </summary>
        public uint4 wwyy => new uint4(w, w, y, y);

        /// <summary>
        /// Returns uint4.aagg swizzling (equivalent to uint4.wwyy).
        /// </summary>
        public uint4 aagg => new uint4(w, w, y, y);

        /// <summary>
        /// Returns uint4.wwyz swizzling.
        /// </summary>
        public uint4 wwyz => new uint4(w, w, y, z);

        /// <summary>
        /// Returns uint4.aagb swizzling (equivalent to uint4.wwyz).
        /// </summary>
        public uint4 aagb => new uint4(w, w, y, z);

        /// <summary>
        /// Returns uint4.wwyw swizzling.
        /// </summary>
        public uint4 wwyw => new uint4(w, w, y, w);

        /// <summary>
        /// Returns uint4.aaga swizzling (equivalent to uint4.wwyw).
        /// </summary>
        public uint4 aaga => new uint4(w, w, y, w);

        /// <summary>
        /// Returns uint4.wwz swizzling.
        /// </summary>
        public uint3 wwz => new uint3(w, w, z);

        /// <summary>
        /// Returns uint4.aab swizzling (equivalent to uint4.wwz).
        /// </summary>
        public uint3 aab => new uint3(w, w, z);

        /// <summary>
        /// Returns uint4.wwzx swizzling.
        /// </summary>
        public uint4 wwzx => new uint4(w, w, z, x);

        /// <summary>
        /// Returns uint4.aabr swizzling (equivalent to uint4.wwzx).
        /// </summary>
        public uint4 aabr => new uint4(w, w, z, x);

        /// <summary>
        /// Returns uint4.wwzy swizzling.
        /// </summary>
        public uint4 wwzy => new uint4(w, w, z, y);

        /// <summary>
        /// Returns uint4.aabg swizzling (equivalent to uint4.wwzy).
        /// </summary>
        public uint4 aabg => new uint4(w, w, z, y);

        /// <summary>
        /// Returns uint4.wwzz swizzling.
        /// </summary>
        public uint4 wwzz => new uint4(w, w, z, z);

        /// <summary>
        /// Returns uint4.aabb swizzling (equivalent to uint4.wwzz).
        /// </summary>
        public uint4 aabb => new uint4(w, w, z, z);

        /// <summary>
        /// Returns uint4.wwzw swizzling.
        /// </summary>
        public uint4 wwzw => new uint4(w, w, z, w);

        /// <summary>
        /// Returns uint4.aaba swizzling (equivalent to uint4.wwzw).
        /// </summary>
        public uint4 aaba => new uint4(w, w, z, w);

        /// <summary>
        /// Returns uint4.www swizzling.
        /// </summary>
        public uint3 www => new uint3(w, w, w);

        /// <summary>
        /// Returns uint4.aaa swizzling (equivalent to uint4.www).
        /// </summary>
        public uint3 aaa => new uint3(w, w, w);

        /// <summary>
        /// Returns uint4.wwwx swizzling.
        /// </summary>
        public uint4 wwwx => new uint4(w, w, w, x);

        /// <summary>
        /// Returns uint4.aaar swizzling (equivalent to uint4.wwwx).
        /// </summary>
        public uint4 aaar => new uint4(w, w, w, x);

        /// <summary>
        /// Returns uint4.wwwy swizzling.
        /// </summary>
        public uint4 wwwy => new uint4(w, w, w, y);

        /// <summary>
        /// Returns uint4.aaag swizzling (equivalent to uint4.wwwy).
        /// </summary>
        public uint4 aaag => new uint4(w, w, w, y);

        /// <summary>
        /// Returns uint4.wwwz swizzling.
        /// </summary>
        public uint4 wwwz => new uint4(w, w, w, z);

        /// <summary>
        /// Returns uint4.aaab swizzling (equivalent to uint4.wwwz).
        /// </summary>
        public uint4 aaab => new uint4(w, w, w, z);

        /// <summary>
        /// Returns uint4.wwww swizzling.
        /// </summary>
        public uint4 wwww => new uint4(w, w, w, w);

        /// <summary>
        /// Returns uint4.aaaa swizzling (equivalent to uint4.wwww).
        /// </summary>
        public uint4 aaaa => new uint4(w, w, w, w);

        #endregion

    }
}
