using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type int with 4 components, used for implementing swizzling for int4.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_ivec4
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

        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        internal readonly int w;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_ivec4.
        /// </summary>
        internal swizzle_ivec4(int x, int y, int z, int w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns int4.xx swizzling.
        /// </summary>
        public int2 xx => new int2(x, x);

        /// <summary>
        /// Returns int4.rr swizzling (equivalent to int4.xx).
        /// </summary>
        public int2 rr => new int2(x, x);

        /// <summary>
        /// Returns int4.xxx swizzling.
        /// </summary>
        public int3 xxx => new int3(x, x, x);

        /// <summary>
        /// Returns int4.rrr swizzling (equivalent to int4.xxx).
        /// </summary>
        public int3 rrr => new int3(x, x, x);

        /// <summary>
        /// Returns int4.xxxx swizzling.
        /// </summary>
        public int4 xxxx => new int4(x, x, x, x);

        /// <summary>
        /// Returns int4.rrrr swizzling (equivalent to int4.xxxx).
        /// </summary>
        public int4 rrrr => new int4(x, x, x, x);

        /// <summary>
        /// Returns int4.xxxy swizzling.
        /// </summary>
        public int4 xxxy => new int4(x, x, x, y);

        /// <summary>
        /// Returns int4.rrrg swizzling (equivalent to int4.xxxy).
        /// </summary>
        public int4 rrrg => new int4(x, x, x, y);

        /// <summary>
        /// Returns int4.xxxz swizzling.
        /// </summary>
        public int4 xxxz => new int4(x, x, x, z);

        /// <summary>
        /// Returns int4.rrrb swizzling (equivalent to int4.xxxz).
        /// </summary>
        public int4 rrrb => new int4(x, x, x, z);

        /// <summary>
        /// Returns int4.xxxw swizzling.
        /// </summary>
        public int4 xxxw => new int4(x, x, x, w);

        /// <summary>
        /// Returns int4.rrra swizzling (equivalent to int4.xxxw).
        /// </summary>
        public int4 rrra => new int4(x, x, x, w);

        /// <summary>
        /// Returns int4.xxy swizzling.
        /// </summary>
        public int3 xxy => new int3(x, x, y);

        /// <summary>
        /// Returns int4.rrg swizzling (equivalent to int4.xxy).
        /// </summary>
        public int3 rrg => new int3(x, x, y);

        /// <summary>
        /// Returns int4.xxyx swizzling.
        /// </summary>
        public int4 xxyx => new int4(x, x, y, x);

        /// <summary>
        /// Returns int4.rrgr swizzling (equivalent to int4.xxyx).
        /// </summary>
        public int4 rrgr => new int4(x, x, y, x);

        /// <summary>
        /// Returns int4.xxyy swizzling.
        /// </summary>
        public int4 xxyy => new int4(x, x, y, y);

        /// <summary>
        /// Returns int4.rrgg swizzling (equivalent to int4.xxyy).
        /// </summary>
        public int4 rrgg => new int4(x, x, y, y);

        /// <summary>
        /// Returns int4.xxyz swizzling.
        /// </summary>
        public int4 xxyz => new int4(x, x, y, z);

        /// <summary>
        /// Returns int4.rrgb swizzling (equivalent to int4.xxyz).
        /// </summary>
        public int4 rrgb => new int4(x, x, y, z);

        /// <summary>
        /// Returns int4.xxyw swizzling.
        /// </summary>
        public int4 xxyw => new int4(x, x, y, w);

        /// <summary>
        /// Returns int4.rrga swizzling (equivalent to int4.xxyw).
        /// </summary>
        public int4 rrga => new int4(x, x, y, w);

        /// <summary>
        /// Returns int4.xxz swizzling.
        /// </summary>
        public int3 xxz => new int3(x, x, z);

        /// <summary>
        /// Returns int4.rrb swizzling (equivalent to int4.xxz).
        /// </summary>
        public int3 rrb => new int3(x, x, z);

        /// <summary>
        /// Returns int4.xxzx swizzling.
        /// </summary>
        public int4 xxzx => new int4(x, x, z, x);

        /// <summary>
        /// Returns int4.rrbr swizzling (equivalent to int4.xxzx).
        /// </summary>
        public int4 rrbr => new int4(x, x, z, x);

        /// <summary>
        /// Returns int4.xxzy swizzling.
        /// </summary>
        public int4 xxzy => new int4(x, x, z, y);

        /// <summary>
        /// Returns int4.rrbg swizzling (equivalent to int4.xxzy).
        /// </summary>
        public int4 rrbg => new int4(x, x, z, y);

        /// <summary>
        /// Returns int4.xxzz swizzling.
        /// </summary>
        public int4 xxzz => new int4(x, x, z, z);

        /// <summary>
        /// Returns int4.rrbb swizzling (equivalent to int4.xxzz).
        /// </summary>
        public int4 rrbb => new int4(x, x, z, z);

        /// <summary>
        /// Returns int4.xxzw swizzling.
        /// </summary>
        public int4 xxzw => new int4(x, x, z, w);

        /// <summary>
        /// Returns int4.rrba swizzling (equivalent to int4.xxzw).
        /// </summary>
        public int4 rrba => new int4(x, x, z, w);

        /// <summary>
        /// Returns int4.xxw swizzling.
        /// </summary>
        public int3 xxw => new int3(x, x, w);

        /// <summary>
        /// Returns int4.rra swizzling (equivalent to int4.xxw).
        /// </summary>
        public int3 rra => new int3(x, x, w);

        /// <summary>
        /// Returns int4.xxwx swizzling.
        /// </summary>
        public int4 xxwx => new int4(x, x, w, x);

        /// <summary>
        /// Returns int4.rrar swizzling (equivalent to int4.xxwx).
        /// </summary>
        public int4 rrar => new int4(x, x, w, x);

        /// <summary>
        /// Returns int4.xxwy swizzling.
        /// </summary>
        public int4 xxwy => new int4(x, x, w, y);

        /// <summary>
        /// Returns int4.rrag swizzling (equivalent to int4.xxwy).
        /// </summary>
        public int4 rrag => new int4(x, x, w, y);

        /// <summary>
        /// Returns int4.xxwz swizzling.
        /// </summary>
        public int4 xxwz => new int4(x, x, w, z);

        /// <summary>
        /// Returns int4.rrab swizzling (equivalent to int4.xxwz).
        /// </summary>
        public int4 rrab => new int4(x, x, w, z);

        /// <summary>
        /// Returns int4.xxww swizzling.
        /// </summary>
        public int4 xxww => new int4(x, x, w, w);

        /// <summary>
        /// Returns int4.rraa swizzling (equivalent to int4.xxww).
        /// </summary>
        public int4 rraa => new int4(x, x, w, w);

        /// <summary>
        /// Returns int4.xy swizzling.
        /// </summary>
        public int2 xy => new int2(x, y);

        /// <summary>
        /// Returns int4.rg swizzling (equivalent to int4.xy).
        /// </summary>
        public int2 rg => new int2(x, y);

        /// <summary>
        /// Returns int4.xyx swizzling.
        /// </summary>
        public int3 xyx => new int3(x, y, x);

        /// <summary>
        /// Returns int4.rgr swizzling (equivalent to int4.xyx).
        /// </summary>
        public int3 rgr => new int3(x, y, x);

        /// <summary>
        /// Returns int4.xyxx swizzling.
        /// </summary>
        public int4 xyxx => new int4(x, y, x, x);

        /// <summary>
        /// Returns int4.rgrr swizzling (equivalent to int4.xyxx).
        /// </summary>
        public int4 rgrr => new int4(x, y, x, x);

        /// <summary>
        /// Returns int4.xyxy swizzling.
        /// </summary>
        public int4 xyxy => new int4(x, y, x, y);

        /// <summary>
        /// Returns int4.rgrg swizzling (equivalent to int4.xyxy).
        /// </summary>
        public int4 rgrg => new int4(x, y, x, y);

        /// <summary>
        /// Returns int4.xyxz swizzling.
        /// </summary>
        public int4 xyxz => new int4(x, y, x, z);

        /// <summary>
        /// Returns int4.rgrb swizzling (equivalent to int4.xyxz).
        /// </summary>
        public int4 rgrb => new int4(x, y, x, z);

        /// <summary>
        /// Returns int4.xyxw swizzling.
        /// </summary>
        public int4 xyxw => new int4(x, y, x, w);

        /// <summary>
        /// Returns int4.rgra swizzling (equivalent to int4.xyxw).
        /// </summary>
        public int4 rgra => new int4(x, y, x, w);

        /// <summary>
        /// Returns int4.xyy swizzling.
        /// </summary>
        public int3 xyy => new int3(x, y, y);

        /// <summary>
        /// Returns int4.rgg swizzling (equivalent to int4.xyy).
        /// </summary>
        public int3 rgg => new int3(x, y, y);

        /// <summary>
        /// Returns int4.xyyx swizzling.
        /// </summary>
        public int4 xyyx => new int4(x, y, y, x);

        /// <summary>
        /// Returns int4.rggr swizzling (equivalent to int4.xyyx).
        /// </summary>
        public int4 rggr => new int4(x, y, y, x);

        /// <summary>
        /// Returns int4.xyyy swizzling.
        /// </summary>
        public int4 xyyy => new int4(x, y, y, y);

        /// <summary>
        /// Returns int4.rggg swizzling (equivalent to int4.xyyy).
        /// </summary>
        public int4 rggg => new int4(x, y, y, y);

        /// <summary>
        /// Returns int4.xyyz swizzling.
        /// </summary>
        public int4 xyyz => new int4(x, y, y, z);

        /// <summary>
        /// Returns int4.rggb swizzling (equivalent to int4.xyyz).
        /// </summary>
        public int4 rggb => new int4(x, y, y, z);

        /// <summary>
        /// Returns int4.xyyw swizzling.
        /// </summary>
        public int4 xyyw => new int4(x, y, y, w);

        /// <summary>
        /// Returns int4.rgga swizzling (equivalent to int4.xyyw).
        /// </summary>
        public int4 rgga => new int4(x, y, y, w);

        /// <summary>
        /// Returns int4.xyz swizzling.
        /// </summary>
        public int3 xyz => new int3(x, y, z);

        /// <summary>
        /// Returns int4.rgb swizzling (equivalent to int4.xyz).
        /// </summary>
        public int3 rgb => new int3(x, y, z);

        /// <summary>
        /// Returns int4.xyzx swizzling.
        /// </summary>
        public int4 xyzx => new int4(x, y, z, x);

        /// <summary>
        /// Returns int4.rgbr swizzling (equivalent to int4.xyzx).
        /// </summary>
        public int4 rgbr => new int4(x, y, z, x);

        /// <summary>
        /// Returns int4.xyzy swizzling.
        /// </summary>
        public int4 xyzy => new int4(x, y, z, y);

        /// <summary>
        /// Returns int4.rgbg swizzling (equivalent to int4.xyzy).
        /// </summary>
        public int4 rgbg => new int4(x, y, z, y);

        /// <summary>
        /// Returns int4.xyzz swizzling.
        /// </summary>
        public int4 xyzz => new int4(x, y, z, z);

        /// <summary>
        /// Returns int4.rgbb swizzling (equivalent to int4.xyzz).
        /// </summary>
        public int4 rgbb => new int4(x, y, z, z);

        /// <summary>
        /// Returns int4.xyzw swizzling.
        /// </summary>
        public int4 xyzw => new int4(x, y, z, w);

        /// <summary>
        /// Returns int4.rgba swizzling (equivalent to int4.xyzw).
        /// </summary>
        public int4 rgba => new int4(x, y, z, w);

        /// <summary>
        /// Returns int4.xyw swizzling.
        /// </summary>
        public int3 xyw => new int3(x, y, w);

        /// <summary>
        /// Returns int4.rga swizzling (equivalent to int4.xyw).
        /// </summary>
        public int3 rga => new int3(x, y, w);

        /// <summary>
        /// Returns int4.xywx swizzling.
        /// </summary>
        public int4 xywx => new int4(x, y, w, x);

        /// <summary>
        /// Returns int4.rgar swizzling (equivalent to int4.xywx).
        /// </summary>
        public int4 rgar => new int4(x, y, w, x);

        /// <summary>
        /// Returns int4.xywy swizzling.
        /// </summary>
        public int4 xywy => new int4(x, y, w, y);

        /// <summary>
        /// Returns int4.rgag swizzling (equivalent to int4.xywy).
        /// </summary>
        public int4 rgag => new int4(x, y, w, y);

        /// <summary>
        /// Returns int4.xywz swizzling.
        /// </summary>
        public int4 xywz => new int4(x, y, w, z);

        /// <summary>
        /// Returns int4.rgab swizzling (equivalent to int4.xywz).
        /// </summary>
        public int4 rgab => new int4(x, y, w, z);

        /// <summary>
        /// Returns int4.xyww swizzling.
        /// </summary>
        public int4 xyww => new int4(x, y, w, w);

        /// <summary>
        /// Returns int4.rgaa swizzling (equivalent to int4.xyww).
        /// </summary>
        public int4 rgaa => new int4(x, y, w, w);

        /// <summary>
        /// Returns int4.xz swizzling.
        /// </summary>
        public int2 xz => new int2(x, z);

        /// <summary>
        /// Returns int4.rb swizzling (equivalent to int4.xz).
        /// </summary>
        public int2 rb => new int2(x, z);

        /// <summary>
        /// Returns int4.xzx swizzling.
        /// </summary>
        public int3 xzx => new int3(x, z, x);

        /// <summary>
        /// Returns int4.rbr swizzling (equivalent to int4.xzx).
        /// </summary>
        public int3 rbr => new int3(x, z, x);

        /// <summary>
        /// Returns int4.xzxx swizzling.
        /// </summary>
        public int4 xzxx => new int4(x, z, x, x);

        /// <summary>
        /// Returns int4.rbrr swizzling (equivalent to int4.xzxx).
        /// </summary>
        public int4 rbrr => new int4(x, z, x, x);

        /// <summary>
        /// Returns int4.xzxy swizzling.
        /// </summary>
        public int4 xzxy => new int4(x, z, x, y);

        /// <summary>
        /// Returns int4.rbrg swizzling (equivalent to int4.xzxy).
        /// </summary>
        public int4 rbrg => new int4(x, z, x, y);

        /// <summary>
        /// Returns int4.xzxz swizzling.
        /// </summary>
        public int4 xzxz => new int4(x, z, x, z);

        /// <summary>
        /// Returns int4.rbrb swizzling (equivalent to int4.xzxz).
        /// </summary>
        public int4 rbrb => new int4(x, z, x, z);

        /// <summary>
        /// Returns int4.xzxw swizzling.
        /// </summary>
        public int4 xzxw => new int4(x, z, x, w);

        /// <summary>
        /// Returns int4.rbra swizzling (equivalent to int4.xzxw).
        /// </summary>
        public int4 rbra => new int4(x, z, x, w);

        /// <summary>
        /// Returns int4.xzy swizzling.
        /// </summary>
        public int3 xzy => new int3(x, z, y);

        /// <summary>
        /// Returns int4.rbg swizzling (equivalent to int4.xzy).
        /// </summary>
        public int3 rbg => new int3(x, z, y);

        /// <summary>
        /// Returns int4.xzyx swizzling.
        /// </summary>
        public int4 xzyx => new int4(x, z, y, x);

        /// <summary>
        /// Returns int4.rbgr swizzling (equivalent to int4.xzyx).
        /// </summary>
        public int4 rbgr => new int4(x, z, y, x);

        /// <summary>
        /// Returns int4.xzyy swizzling.
        /// </summary>
        public int4 xzyy => new int4(x, z, y, y);

        /// <summary>
        /// Returns int4.rbgg swizzling (equivalent to int4.xzyy).
        /// </summary>
        public int4 rbgg => new int4(x, z, y, y);

        /// <summary>
        /// Returns int4.xzyz swizzling.
        /// </summary>
        public int4 xzyz => new int4(x, z, y, z);

        /// <summary>
        /// Returns int4.rbgb swizzling (equivalent to int4.xzyz).
        /// </summary>
        public int4 rbgb => new int4(x, z, y, z);

        /// <summary>
        /// Returns int4.xzyw swizzling.
        /// </summary>
        public int4 xzyw => new int4(x, z, y, w);

        /// <summary>
        /// Returns int4.rbga swizzling (equivalent to int4.xzyw).
        /// </summary>
        public int4 rbga => new int4(x, z, y, w);

        /// <summary>
        /// Returns int4.xzz swizzling.
        /// </summary>
        public int3 xzz => new int3(x, z, z);

        /// <summary>
        /// Returns int4.rbb swizzling (equivalent to int4.xzz).
        /// </summary>
        public int3 rbb => new int3(x, z, z);

        /// <summary>
        /// Returns int4.xzzx swizzling.
        /// </summary>
        public int4 xzzx => new int4(x, z, z, x);

        /// <summary>
        /// Returns int4.rbbr swizzling (equivalent to int4.xzzx).
        /// </summary>
        public int4 rbbr => new int4(x, z, z, x);

        /// <summary>
        /// Returns int4.xzzy swizzling.
        /// </summary>
        public int4 xzzy => new int4(x, z, z, y);

        /// <summary>
        /// Returns int4.rbbg swizzling (equivalent to int4.xzzy).
        /// </summary>
        public int4 rbbg => new int4(x, z, z, y);

        /// <summary>
        /// Returns int4.xzzz swizzling.
        /// </summary>
        public int4 xzzz => new int4(x, z, z, z);

        /// <summary>
        /// Returns int4.rbbb swizzling (equivalent to int4.xzzz).
        /// </summary>
        public int4 rbbb => new int4(x, z, z, z);

        /// <summary>
        /// Returns int4.xzzw swizzling.
        /// </summary>
        public int4 xzzw => new int4(x, z, z, w);

        /// <summary>
        /// Returns int4.rbba swizzling (equivalent to int4.xzzw).
        /// </summary>
        public int4 rbba => new int4(x, z, z, w);

        /// <summary>
        /// Returns int4.xzw swizzling.
        /// </summary>
        public int3 xzw => new int3(x, z, w);

        /// <summary>
        /// Returns int4.rba swizzling (equivalent to int4.xzw).
        /// </summary>
        public int3 rba => new int3(x, z, w);

        /// <summary>
        /// Returns int4.xzwx swizzling.
        /// </summary>
        public int4 xzwx => new int4(x, z, w, x);

        /// <summary>
        /// Returns int4.rbar swizzling (equivalent to int4.xzwx).
        /// </summary>
        public int4 rbar => new int4(x, z, w, x);

        /// <summary>
        /// Returns int4.xzwy swizzling.
        /// </summary>
        public int4 xzwy => new int4(x, z, w, y);

        /// <summary>
        /// Returns int4.rbag swizzling (equivalent to int4.xzwy).
        /// </summary>
        public int4 rbag => new int4(x, z, w, y);

        /// <summary>
        /// Returns int4.xzwz swizzling.
        /// </summary>
        public int4 xzwz => new int4(x, z, w, z);

        /// <summary>
        /// Returns int4.rbab swizzling (equivalent to int4.xzwz).
        /// </summary>
        public int4 rbab => new int4(x, z, w, z);

        /// <summary>
        /// Returns int4.xzww swizzling.
        /// </summary>
        public int4 xzww => new int4(x, z, w, w);

        /// <summary>
        /// Returns int4.rbaa swizzling (equivalent to int4.xzww).
        /// </summary>
        public int4 rbaa => new int4(x, z, w, w);

        /// <summary>
        /// Returns int4.xw swizzling.
        /// </summary>
        public int2 xw => new int2(x, w);

        /// <summary>
        /// Returns int4.ra swizzling (equivalent to int4.xw).
        /// </summary>
        public int2 ra => new int2(x, w);

        /// <summary>
        /// Returns int4.xwx swizzling.
        /// </summary>
        public int3 xwx => new int3(x, w, x);

        /// <summary>
        /// Returns int4.rar swizzling (equivalent to int4.xwx).
        /// </summary>
        public int3 rar => new int3(x, w, x);

        /// <summary>
        /// Returns int4.xwxx swizzling.
        /// </summary>
        public int4 xwxx => new int4(x, w, x, x);

        /// <summary>
        /// Returns int4.rarr swizzling (equivalent to int4.xwxx).
        /// </summary>
        public int4 rarr => new int4(x, w, x, x);

        /// <summary>
        /// Returns int4.xwxy swizzling.
        /// </summary>
        public int4 xwxy => new int4(x, w, x, y);

        /// <summary>
        /// Returns int4.rarg swizzling (equivalent to int4.xwxy).
        /// </summary>
        public int4 rarg => new int4(x, w, x, y);

        /// <summary>
        /// Returns int4.xwxz swizzling.
        /// </summary>
        public int4 xwxz => new int4(x, w, x, z);

        /// <summary>
        /// Returns int4.rarb swizzling (equivalent to int4.xwxz).
        /// </summary>
        public int4 rarb => new int4(x, w, x, z);

        /// <summary>
        /// Returns int4.xwxw swizzling.
        /// </summary>
        public int4 xwxw => new int4(x, w, x, w);

        /// <summary>
        /// Returns int4.rara swizzling (equivalent to int4.xwxw).
        /// </summary>
        public int4 rara => new int4(x, w, x, w);

        /// <summary>
        /// Returns int4.xwy swizzling.
        /// </summary>
        public int3 xwy => new int3(x, w, y);

        /// <summary>
        /// Returns int4.rag swizzling (equivalent to int4.xwy).
        /// </summary>
        public int3 rag => new int3(x, w, y);

        /// <summary>
        /// Returns int4.xwyx swizzling.
        /// </summary>
        public int4 xwyx => new int4(x, w, y, x);

        /// <summary>
        /// Returns int4.ragr swizzling (equivalent to int4.xwyx).
        /// </summary>
        public int4 ragr => new int4(x, w, y, x);

        /// <summary>
        /// Returns int4.xwyy swizzling.
        /// </summary>
        public int4 xwyy => new int4(x, w, y, y);

        /// <summary>
        /// Returns int4.ragg swizzling (equivalent to int4.xwyy).
        /// </summary>
        public int4 ragg => new int4(x, w, y, y);

        /// <summary>
        /// Returns int4.xwyz swizzling.
        /// </summary>
        public int4 xwyz => new int4(x, w, y, z);

        /// <summary>
        /// Returns int4.ragb swizzling (equivalent to int4.xwyz).
        /// </summary>
        public int4 ragb => new int4(x, w, y, z);

        /// <summary>
        /// Returns int4.xwyw swizzling.
        /// </summary>
        public int4 xwyw => new int4(x, w, y, w);

        /// <summary>
        /// Returns int4.raga swizzling (equivalent to int4.xwyw).
        /// </summary>
        public int4 raga => new int4(x, w, y, w);

        /// <summary>
        /// Returns int4.xwz swizzling.
        /// </summary>
        public int3 xwz => new int3(x, w, z);

        /// <summary>
        /// Returns int4.rab swizzling (equivalent to int4.xwz).
        /// </summary>
        public int3 rab => new int3(x, w, z);

        /// <summary>
        /// Returns int4.xwzx swizzling.
        /// </summary>
        public int4 xwzx => new int4(x, w, z, x);

        /// <summary>
        /// Returns int4.rabr swizzling (equivalent to int4.xwzx).
        /// </summary>
        public int4 rabr => new int4(x, w, z, x);

        /// <summary>
        /// Returns int4.xwzy swizzling.
        /// </summary>
        public int4 xwzy => new int4(x, w, z, y);

        /// <summary>
        /// Returns int4.rabg swizzling (equivalent to int4.xwzy).
        /// </summary>
        public int4 rabg => new int4(x, w, z, y);

        /// <summary>
        /// Returns int4.xwzz swizzling.
        /// </summary>
        public int4 xwzz => new int4(x, w, z, z);

        /// <summary>
        /// Returns int4.rabb swizzling (equivalent to int4.xwzz).
        /// </summary>
        public int4 rabb => new int4(x, w, z, z);

        /// <summary>
        /// Returns int4.xwzw swizzling.
        /// </summary>
        public int4 xwzw => new int4(x, w, z, w);

        /// <summary>
        /// Returns int4.raba swizzling (equivalent to int4.xwzw).
        /// </summary>
        public int4 raba => new int4(x, w, z, w);

        /// <summary>
        /// Returns int4.xww swizzling.
        /// </summary>
        public int3 xww => new int3(x, w, w);

        /// <summary>
        /// Returns int4.raa swizzling (equivalent to int4.xww).
        /// </summary>
        public int3 raa => new int3(x, w, w);

        /// <summary>
        /// Returns int4.xwwx swizzling.
        /// </summary>
        public int4 xwwx => new int4(x, w, w, x);

        /// <summary>
        /// Returns int4.raar swizzling (equivalent to int4.xwwx).
        /// </summary>
        public int4 raar => new int4(x, w, w, x);

        /// <summary>
        /// Returns int4.xwwy swizzling.
        /// </summary>
        public int4 xwwy => new int4(x, w, w, y);

        /// <summary>
        /// Returns int4.raag swizzling (equivalent to int4.xwwy).
        /// </summary>
        public int4 raag => new int4(x, w, w, y);

        /// <summary>
        /// Returns int4.xwwz swizzling.
        /// </summary>
        public int4 xwwz => new int4(x, w, w, z);

        /// <summary>
        /// Returns int4.raab swizzling (equivalent to int4.xwwz).
        /// </summary>
        public int4 raab => new int4(x, w, w, z);

        /// <summary>
        /// Returns int4.xwww swizzling.
        /// </summary>
        public int4 xwww => new int4(x, w, w, w);

        /// <summary>
        /// Returns int4.raaa swizzling (equivalent to int4.xwww).
        /// </summary>
        public int4 raaa => new int4(x, w, w, w);

        /// <summary>
        /// Returns int4.yx swizzling.
        /// </summary>
        public int2 yx => new int2(y, x);

        /// <summary>
        /// Returns int4.gr swizzling (equivalent to int4.yx).
        /// </summary>
        public int2 gr => new int2(y, x);

        /// <summary>
        /// Returns int4.yxx swizzling.
        /// </summary>
        public int3 yxx => new int3(y, x, x);

        /// <summary>
        /// Returns int4.grr swizzling (equivalent to int4.yxx).
        /// </summary>
        public int3 grr => new int3(y, x, x);

        /// <summary>
        /// Returns int4.yxxx swizzling.
        /// </summary>
        public int4 yxxx => new int4(y, x, x, x);

        /// <summary>
        /// Returns int4.grrr swizzling (equivalent to int4.yxxx).
        /// </summary>
        public int4 grrr => new int4(y, x, x, x);

        /// <summary>
        /// Returns int4.yxxy swizzling.
        /// </summary>
        public int4 yxxy => new int4(y, x, x, y);

        /// <summary>
        /// Returns int4.grrg swizzling (equivalent to int4.yxxy).
        /// </summary>
        public int4 grrg => new int4(y, x, x, y);

        /// <summary>
        /// Returns int4.yxxz swizzling.
        /// </summary>
        public int4 yxxz => new int4(y, x, x, z);

        /// <summary>
        /// Returns int4.grrb swizzling (equivalent to int4.yxxz).
        /// </summary>
        public int4 grrb => new int4(y, x, x, z);

        /// <summary>
        /// Returns int4.yxxw swizzling.
        /// </summary>
        public int4 yxxw => new int4(y, x, x, w);

        /// <summary>
        /// Returns int4.grra swizzling (equivalent to int4.yxxw).
        /// </summary>
        public int4 grra => new int4(y, x, x, w);

        /// <summary>
        /// Returns int4.yxy swizzling.
        /// </summary>
        public int3 yxy => new int3(y, x, y);

        /// <summary>
        /// Returns int4.grg swizzling (equivalent to int4.yxy).
        /// </summary>
        public int3 grg => new int3(y, x, y);

        /// <summary>
        /// Returns int4.yxyx swizzling.
        /// </summary>
        public int4 yxyx => new int4(y, x, y, x);

        /// <summary>
        /// Returns int4.grgr swizzling (equivalent to int4.yxyx).
        /// </summary>
        public int4 grgr => new int4(y, x, y, x);

        /// <summary>
        /// Returns int4.yxyy swizzling.
        /// </summary>
        public int4 yxyy => new int4(y, x, y, y);

        /// <summary>
        /// Returns int4.grgg swizzling (equivalent to int4.yxyy).
        /// </summary>
        public int4 grgg => new int4(y, x, y, y);

        /// <summary>
        /// Returns int4.yxyz swizzling.
        /// </summary>
        public int4 yxyz => new int4(y, x, y, z);

        /// <summary>
        /// Returns int4.grgb swizzling (equivalent to int4.yxyz).
        /// </summary>
        public int4 grgb => new int4(y, x, y, z);

        /// <summary>
        /// Returns int4.yxyw swizzling.
        /// </summary>
        public int4 yxyw => new int4(y, x, y, w);

        /// <summary>
        /// Returns int4.grga swizzling (equivalent to int4.yxyw).
        /// </summary>
        public int4 grga => new int4(y, x, y, w);

        /// <summary>
        /// Returns int4.yxz swizzling.
        /// </summary>
        public int3 yxz => new int3(y, x, z);

        /// <summary>
        /// Returns int4.grb swizzling (equivalent to int4.yxz).
        /// </summary>
        public int3 grb => new int3(y, x, z);

        /// <summary>
        /// Returns int4.yxzx swizzling.
        /// </summary>
        public int4 yxzx => new int4(y, x, z, x);

        /// <summary>
        /// Returns int4.grbr swizzling (equivalent to int4.yxzx).
        /// </summary>
        public int4 grbr => new int4(y, x, z, x);

        /// <summary>
        /// Returns int4.yxzy swizzling.
        /// </summary>
        public int4 yxzy => new int4(y, x, z, y);

        /// <summary>
        /// Returns int4.grbg swizzling (equivalent to int4.yxzy).
        /// </summary>
        public int4 grbg => new int4(y, x, z, y);

        /// <summary>
        /// Returns int4.yxzz swizzling.
        /// </summary>
        public int4 yxzz => new int4(y, x, z, z);

        /// <summary>
        /// Returns int4.grbb swizzling (equivalent to int4.yxzz).
        /// </summary>
        public int4 grbb => new int4(y, x, z, z);

        /// <summary>
        /// Returns int4.yxzw swizzling.
        /// </summary>
        public int4 yxzw => new int4(y, x, z, w);

        /// <summary>
        /// Returns int4.grba swizzling (equivalent to int4.yxzw).
        /// </summary>
        public int4 grba => new int4(y, x, z, w);

        /// <summary>
        /// Returns int4.yxw swizzling.
        /// </summary>
        public int3 yxw => new int3(y, x, w);

        /// <summary>
        /// Returns int4.gra swizzling (equivalent to int4.yxw).
        /// </summary>
        public int3 gra => new int3(y, x, w);

        /// <summary>
        /// Returns int4.yxwx swizzling.
        /// </summary>
        public int4 yxwx => new int4(y, x, w, x);

        /// <summary>
        /// Returns int4.grar swizzling (equivalent to int4.yxwx).
        /// </summary>
        public int4 grar => new int4(y, x, w, x);

        /// <summary>
        /// Returns int4.yxwy swizzling.
        /// </summary>
        public int4 yxwy => new int4(y, x, w, y);

        /// <summary>
        /// Returns int4.grag swizzling (equivalent to int4.yxwy).
        /// </summary>
        public int4 grag => new int4(y, x, w, y);

        /// <summary>
        /// Returns int4.yxwz swizzling.
        /// </summary>
        public int4 yxwz => new int4(y, x, w, z);

        /// <summary>
        /// Returns int4.grab swizzling (equivalent to int4.yxwz).
        /// </summary>
        public int4 grab => new int4(y, x, w, z);

        /// <summary>
        /// Returns int4.yxww swizzling.
        /// </summary>
        public int4 yxww => new int4(y, x, w, w);

        /// <summary>
        /// Returns int4.graa swizzling (equivalent to int4.yxww).
        /// </summary>
        public int4 graa => new int4(y, x, w, w);

        /// <summary>
        /// Returns int4.yy swizzling.
        /// </summary>
        public int2 yy => new int2(y, y);

        /// <summary>
        /// Returns int4.gg swizzling (equivalent to int4.yy).
        /// </summary>
        public int2 gg => new int2(y, y);

        /// <summary>
        /// Returns int4.yyx swizzling.
        /// </summary>
        public int3 yyx => new int3(y, y, x);

        /// <summary>
        /// Returns int4.ggr swizzling (equivalent to int4.yyx).
        /// </summary>
        public int3 ggr => new int3(y, y, x);

        /// <summary>
        /// Returns int4.yyxx swizzling.
        /// </summary>
        public int4 yyxx => new int4(y, y, x, x);

        /// <summary>
        /// Returns int4.ggrr swizzling (equivalent to int4.yyxx).
        /// </summary>
        public int4 ggrr => new int4(y, y, x, x);

        /// <summary>
        /// Returns int4.yyxy swizzling.
        /// </summary>
        public int4 yyxy => new int4(y, y, x, y);

        /// <summary>
        /// Returns int4.ggrg swizzling (equivalent to int4.yyxy).
        /// </summary>
        public int4 ggrg => new int4(y, y, x, y);

        /// <summary>
        /// Returns int4.yyxz swizzling.
        /// </summary>
        public int4 yyxz => new int4(y, y, x, z);

        /// <summary>
        /// Returns int4.ggrb swizzling (equivalent to int4.yyxz).
        /// </summary>
        public int4 ggrb => new int4(y, y, x, z);

        /// <summary>
        /// Returns int4.yyxw swizzling.
        /// </summary>
        public int4 yyxw => new int4(y, y, x, w);

        /// <summary>
        /// Returns int4.ggra swizzling (equivalent to int4.yyxw).
        /// </summary>
        public int4 ggra => new int4(y, y, x, w);

        /// <summary>
        /// Returns int4.yyy swizzling.
        /// </summary>
        public int3 yyy => new int3(y, y, y);

        /// <summary>
        /// Returns int4.ggg swizzling (equivalent to int4.yyy).
        /// </summary>
        public int3 ggg => new int3(y, y, y);

        /// <summary>
        /// Returns int4.yyyx swizzling.
        /// </summary>
        public int4 yyyx => new int4(y, y, y, x);

        /// <summary>
        /// Returns int4.gggr swizzling (equivalent to int4.yyyx).
        /// </summary>
        public int4 gggr => new int4(y, y, y, x);

        /// <summary>
        /// Returns int4.yyyy swizzling.
        /// </summary>
        public int4 yyyy => new int4(y, y, y, y);

        /// <summary>
        /// Returns int4.gggg swizzling (equivalent to int4.yyyy).
        /// </summary>
        public int4 gggg => new int4(y, y, y, y);

        /// <summary>
        /// Returns int4.yyyz swizzling.
        /// </summary>
        public int4 yyyz => new int4(y, y, y, z);

        /// <summary>
        /// Returns int4.gggb swizzling (equivalent to int4.yyyz).
        /// </summary>
        public int4 gggb => new int4(y, y, y, z);

        /// <summary>
        /// Returns int4.yyyw swizzling.
        /// </summary>
        public int4 yyyw => new int4(y, y, y, w);

        /// <summary>
        /// Returns int4.ggga swizzling (equivalent to int4.yyyw).
        /// </summary>
        public int4 ggga => new int4(y, y, y, w);

        /// <summary>
        /// Returns int4.yyz swizzling.
        /// </summary>
        public int3 yyz => new int3(y, y, z);

        /// <summary>
        /// Returns int4.ggb swizzling (equivalent to int4.yyz).
        /// </summary>
        public int3 ggb => new int3(y, y, z);

        /// <summary>
        /// Returns int4.yyzx swizzling.
        /// </summary>
        public int4 yyzx => new int4(y, y, z, x);

        /// <summary>
        /// Returns int4.ggbr swizzling (equivalent to int4.yyzx).
        /// </summary>
        public int4 ggbr => new int4(y, y, z, x);

        /// <summary>
        /// Returns int4.yyzy swizzling.
        /// </summary>
        public int4 yyzy => new int4(y, y, z, y);

        /// <summary>
        /// Returns int4.ggbg swizzling (equivalent to int4.yyzy).
        /// </summary>
        public int4 ggbg => new int4(y, y, z, y);

        /// <summary>
        /// Returns int4.yyzz swizzling.
        /// </summary>
        public int4 yyzz => new int4(y, y, z, z);

        /// <summary>
        /// Returns int4.ggbb swizzling (equivalent to int4.yyzz).
        /// </summary>
        public int4 ggbb => new int4(y, y, z, z);

        /// <summary>
        /// Returns int4.yyzw swizzling.
        /// </summary>
        public int4 yyzw => new int4(y, y, z, w);

        /// <summary>
        /// Returns int4.ggba swizzling (equivalent to int4.yyzw).
        /// </summary>
        public int4 ggba => new int4(y, y, z, w);

        /// <summary>
        /// Returns int4.yyw swizzling.
        /// </summary>
        public int3 yyw => new int3(y, y, w);

        /// <summary>
        /// Returns int4.gga swizzling (equivalent to int4.yyw).
        /// </summary>
        public int3 gga => new int3(y, y, w);

        /// <summary>
        /// Returns int4.yywx swizzling.
        /// </summary>
        public int4 yywx => new int4(y, y, w, x);

        /// <summary>
        /// Returns int4.ggar swizzling (equivalent to int4.yywx).
        /// </summary>
        public int4 ggar => new int4(y, y, w, x);

        /// <summary>
        /// Returns int4.yywy swizzling.
        /// </summary>
        public int4 yywy => new int4(y, y, w, y);

        /// <summary>
        /// Returns int4.ggag swizzling (equivalent to int4.yywy).
        /// </summary>
        public int4 ggag => new int4(y, y, w, y);

        /// <summary>
        /// Returns int4.yywz swizzling.
        /// </summary>
        public int4 yywz => new int4(y, y, w, z);

        /// <summary>
        /// Returns int4.ggab swizzling (equivalent to int4.yywz).
        /// </summary>
        public int4 ggab => new int4(y, y, w, z);

        /// <summary>
        /// Returns int4.yyww swizzling.
        /// </summary>
        public int4 yyww => new int4(y, y, w, w);

        /// <summary>
        /// Returns int4.ggaa swizzling (equivalent to int4.yyww).
        /// </summary>
        public int4 ggaa => new int4(y, y, w, w);

        /// <summary>
        /// Returns int4.yz swizzling.
        /// </summary>
        public int2 yz => new int2(y, z);

        /// <summary>
        /// Returns int4.gb swizzling (equivalent to int4.yz).
        /// </summary>
        public int2 gb => new int2(y, z);

        /// <summary>
        /// Returns int4.yzx swizzling.
        /// </summary>
        public int3 yzx => new int3(y, z, x);

        /// <summary>
        /// Returns int4.gbr swizzling (equivalent to int4.yzx).
        /// </summary>
        public int3 gbr => new int3(y, z, x);

        /// <summary>
        /// Returns int4.yzxx swizzling.
        /// </summary>
        public int4 yzxx => new int4(y, z, x, x);

        /// <summary>
        /// Returns int4.gbrr swizzling (equivalent to int4.yzxx).
        /// </summary>
        public int4 gbrr => new int4(y, z, x, x);

        /// <summary>
        /// Returns int4.yzxy swizzling.
        /// </summary>
        public int4 yzxy => new int4(y, z, x, y);

        /// <summary>
        /// Returns int4.gbrg swizzling (equivalent to int4.yzxy).
        /// </summary>
        public int4 gbrg => new int4(y, z, x, y);

        /// <summary>
        /// Returns int4.yzxz swizzling.
        /// </summary>
        public int4 yzxz => new int4(y, z, x, z);

        /// <summary>
        /// Returns int4.gbrb swizzling (equivalent to int4.yzxz).
        /// </summary>
        public int4 gbrb => new int4(y, z, x, z);

        /// <summary>
        /// Returns int4.yzxw swizzling.
        /// </summary>
        public int4 yzxw => new int4(y, z, x, w);

        /// <summary>
        /// Returns int4.gbra swizzling (equivalent to int4.yzxw).
        /// </summary>
        public int4 gbra => new int4(y, z, x, w);

        /// <summary>
        /// Returns int4.yzy swizzling.
        /// </summary>
        public int3 yzy => new int3(y, z, y);

        /// <summary>
        /// Returns int4.gbg swizzling (equivalent to int4.yzy).
        /// </summary>
        public int3 gbg => new int3(y, z, y);

        /// <summary>
        /// Returns int4.yzyx swizzling.
        /// </summary>
        public int4 yzyx => new int4(y, z, y, x);

        /// <summary>
        /// Returns int4.gbgr swizzling (equivalent to int4.yzyx).
        /// </summary>
        public int4 gbgr => new int4(y, z, y, x);

        /// <summary>
        /// Returns int4.yzyy swizzling.
        /// </summary>
        public int4 yzyy => new int4(y, z, y, y);

        /// <summary>
        /// Returns int4.gbgg swizzling (equivalent to int4.yzyy).
        /// </summary>
        public int4 gbgg => new int4(y, z, y, y);

        /// <summary>
        /// Returns int4.yzyz swizzling.
        /// </summary>
        public int4 yzyz => new int4(y, z, y, z);

        /// <summary>
        /// Returns int4.gbgb swizzling (equivalent to int4.yzyz).
        /// </summary>
        public int4 gbgb => new int4(y, z, y, z);

        /// <summary>
        /// Returns int4.yzyw swizzling.
        /// </summary>
        public int4 yzyw => new int4(y, z, y, w);

        /// <summary>
        /// Returns int4.gbga swizzling (equivalent to int4.yzyw).
        /// </summary>
        public int4 gbga => new int4(y, z, y, w);

        /// <summary>
        /// Returns int4.yzz swizzling.
        /// </summary>
        public int3 yzz => new int3(y, z, z);

        /// <summary>
        /// Returns int4.gbb swizzling (equivalent to int4.yzz).
        /// </summary>
        public int3 gbb => new int3(y, z, z);

        /// <summary>
        /// Returns int4.yzzx swizzling.
        /// </summary>
        public int4 yzzx => new int4(y, z, z, x);

        /// <summary>
        /// Returns int4.gbbr swizzling (equivalent to int4.yzzx).
        /// </summary>
        public int4 gbbr => new int4(y, z, z, x);

        /// <summary>
        /// Returns int4.yzzy swizzling.
        /// </summary>
        public int4 yzzy => new int4(y, z, z, y);

        /// <summary>
        /// Returns int4.gbbg swizzling (equivalent to int4.yzzy).
        /// </summary>
        public int4 gbbg => new int4(y, z, z, y);

        /// <summary>
        /// Returns int4.yzzz swizzling.
        /// </summary>
        public int4 yzzz => new int4(y, z, z, z);

        /// <summary>
        /// Returns int4.gbbb swizzling (equivalent to int4.yzzz).
        /// </summary>
        public int4 gbbb => new int4(y, z, z, z);

        /// <summary>
        /// Returns int4.yzzw swizzling.
        /// </summary>
        public int4 yzzw => new int4(y, z, z, w);

        /// <summary>
        /// Returns int4.gbba swizzling (equivalent to int4.yzzw).
        /// </summary>
        public int4 gbba => new int4(y, z, z, w);

        /// <summary>
        /// Returns int4.yzw swizzling.
        /// </summary>
        public int3 yzw => new int3(y, z, w);

        /// <summary>
        /// Returns int4.gba swizzling (equivalent to int4.yzw).
        /// </summary>
        public int3 gba => new int3(y, z, w);

        /// <summary>
        /// Returns int4.yzwx swizzling.
        /// </summary>
        public int4 yzwx => new int4(y, z, w, x);

        /// <summary>
        /// Returns int4.gbar swizzling (equivalent to int4.yzwx).
        /// </summary>
        public int4 gbar => new int4(y, z, w, x);

        /// <summary>
        /// Returns int4.yzwy swizzling.
        /// </summary>
        public int4 yzwy => new int4(y, z, w, y);

        /// <summary>
        /// Returns int4.gbag swizzling (equivalent to int4.yzwy).
        /// </summary>
        public int4 gbag => new int4(y, z, w, y);

        /// <summary>
        /// Returns int4.yzwz swizzling.
        /// </summary>
        public int4 yzwz => new int4(y, z, w, z);

        /// <summary>
        /// Returns int4.gbab swizzling (equivalent to int4.yzwz).
        /// </summary>
        public int4 gbab => new int4(y, z, w, z);

        /// <summary>
        /// Returns int4.yzww swizzling.
        /// </summary>
        public int4 yzww => new int4(y, z, w, w);

        /// <summary>
        /// Returns int4.gbaa swizzling (equivalent to int4.yzww).
        /// </summary>
        public int4 gbaa => new int4(y, z, w, w);

        /// <summary>
        /// Returns int4.yw swizzling.
        /// </summary>
        public int2 yw => new int2(y, w);

        /// <summary>
        /// Returns int4.ga swizzling (equivalent to int4.yw).
        /// </summary>
        public int2 ga => new int2(y, w);

        /// <summary>
        /// Returns int4.ywx swizzling.
        /// </summary>
        public int3 ywx => new int3(y, w, x);

        /// <summary>
        /// Returns int4.gar swizzling (equivalent to int4.ywx).
        /// </summary>
        public int3 gar => new int3(y, w, x);

        /// <summary>
        /// Returns int4.ywxx swizzling.
        /// </summary>
        public int4 ywxx => new int4(y, w, x, x);

        /// <summary>
        /// Returns int4.garr swizzling (equivalent to int4.ywxx).
        /// </summary>
        public int4 garr => new int4(y, w, x, x);

        /// <summary>
        /// Returns int4.ywxy swizzling.
        /// </summary>
        public int4 ywxy => new int4(y, w, x, y);

        /// <summary>
        /// Returns int4.garg swizzling (equivalent to int4.ywxy).
        /// </summary>
        public int4 garg => new int4(y, w, x, y);

        /// <summary>
        /// Returns int4.ywxz swizzling.
        /// </summary>
        public int4 ywxz => new int4(y, w, x, z);

        /// <summary>
        /// Returns int4.garb swizzling (equivalent to int4.ywxz).
        /// </summary>
        public int4 garb => new int4(y, w, x, z);

        /// <summary>
        /// Returns int4.ywxw swizzling.
        /// </summary>
        public int4 ywxw => new int4(y, w, x, w);

        /// <summary>
        /// Returns int4.gara swizzling (equivalent to int4.ywxw).
        /// </summary>
        public int4 gara => new int4(y, w, x, w);

        /// <summary>
        /// Returns int4.ywy swizzling.
        /// </summary>
        public int3 ywy => new int3(y, w, y);

        /// <summary>
        /// Returns int4.gag swizzling (equivalent to int4.ywy).
        /// </summary>
        public int3 gag => new int3(y, w, y);

        /// <summary>
        /// Returns int4.ywyx swizzling.
        /// </summary>
        public int4 ywyx => new int4(y, w, y, x);

        /// <summary>
        /// Returns int4.gagr swizzling (equivalent to int4.ywyx).
        /// </summary>
        public int4 gagr => new int4(y, w, y, x);

        /// <summary>
        /// Returns int4.ywyy swizzling.
        /// </summary>
        public int4 ywyy => new int4(y, w, y, y);

        /// <summary>
        /// Returns int4.gagg swizzling (equivalent to int4.ywyy).
        /// </summary>
        public int4 gagg => new int4(y, w, y, y);

        /// <summary>
        /// Returns int4.ywyz swizzling.
        /// </summary>
        public int4 ywyz => new int4(y, w, y, z);

        /// <summary>
        /// Returns int4.gagb swizzling (equivalent to int4.ywyz).
        /// </summary>
        public int4 gagb => new int4(y, w, y, z);

        /// <summary>
        /// Returns int4.ywyw swizzling.
        /// </summary>
        public int4 ywyw => new int4(y, w, y, w);

        /// <summary>
        /// Returns int4.gaga swizzling (equivalent to int4.ywyw).
        /// </summary>
        public int4 gaga => new int4(y, w, y, w);

        /// <summary>
        /// Returns int4.ywz swizzling.
        /// </summary>
        public int3 ywz => new int3(y, w, z);

        /// <summary>
        /// Returns int4.gab swizzling (equivalent to int4.ywz).
        /// </summary>
        public int3 gab => new int3(y, w, z);

        /// <summary>
        /// Returns int4.ywzx swizzling.
        /// </summary>
        public int4 ywzx => new int4(y, w, z, x);

        /// <summary>
        /// Returns int4.gabr swizzling (equivalent to int4.ywzx).
        /// </summary>
        public int4 gabr => new int4(y, w, z, x);

        /// <summary>
        /// Returns int4.ywzy swizzling.
        /// </summary>
        public int4 ywzy => new int4(y, w, z, y);

        /// <summary>
        /// Returns int4.gabg swizzling (equivalent to int4.ywzy).
        /// </summary>
        public int4 gabg => new int4(y, w, z, y);

        /// <summary>
        /// Returns int4.ywzz swizzling.
        /// </summary>
        public int4 ywzz => new int4(y, w, z, z);

        /// <summary>
        /// Returns int4.gabb swizzling (equivalent to int4.ywzz).
        /// </summary>
        public int4 gabb => new int4(y, w, z, z);

        /// <summary>
        /// Returns int4.ywzw swizzling.
        /// </summary>
        public int4 ywzw => new int4(y, w, z, w);

        /// <summary>
        /// Returns int4.gaba swizzling (equivalent to int4.ywzw).
        /// </summary>
        public int4 gaba => new int4(y, w, z, w);

        /// <summary>
        /// Returns int4.yww swizzling.
        /// </summary>
        public int3 yww => new int3(y, w, w);

        /// <summary>
        /// Returns int4.gaa swizzling (equivalent to int4.yww).
        /// </summary>
        public int3 gaa => new int3(y, w, w);

        /// <summary>
        /// Returns int4.ywwx swizzling.
        /// </summary>
        public int4 ywwx => new int4(y, w, w, x);

        /// <summary>
        /// Returns int4.gaar swizzling (equivalent to int4.ywwx).
        /// </summary>
        public int4 gaar => new int4(y, w, w, x);

        /// <summary>
        /// Returns int4.ywwy swizzling.
        /// </summary>
        public int4 ywwy => new int4(y, w, w, y);

        /// <summary>
        /// Returns int4.gaag swizzling (equivalent to int4.ywwy).
        /// </summary>
        public int4 gaag => new int4(y, w, w, y);

        /// <summary>
        /// Returns int4.ywwz swizzling.
        /// </summary>
        public int4 ywwz => new int4(y, w, w, z);

        /// <summary>
        /// Returns int4.gaab swizzling (equivalent to int4.ywwz).
        /// </summary>
        public int4 gaab => new int4(y, w, w, z);

        /// <summary>
        /// Returns int4.ywww swizzling.
        /// </summary>
        public int4 ywww => new int4(y, w, w, w);

        /// <summary>
        /// Returns int4.gaaa swizzling (equivalent to int4.ywww).
        /// </summary>
        public int4 gaaa => new int4(y, w, w, w);

        /// <summary>
        /// Returns int4.zx swizzling.
        /// </summary>
        public int2 zx => new int2(z, x);

        /// <summary>
        /// Returns int4.br swizzling (equivalent to int4.zx).
        /// </summary>
        public int2 br => new int2(z, x);

        /// <summary>
        /// Returns int4.zxx swizzling.
        /// </summary>
        public int3 zxx => new int3(z, x, x);

        /// <summary>
        /// Returns int4.brr swizzling (equivalent to int4.zxx).
        /// </summary>
        public int3 brr => new int3(z, x, x);

        /// <summary>
        /// Returns int4.zxxx swizzling.
        /// </summary>
        public int4 zxxx => new int4(z, x, x, x);

        /// <summary>
        /// Returns int4.brrr swizzling (equivalent to int4.zxxx).
        /// </summary>
        public int4 brrr => new int4(z, x, x, x);

        /// <summary>
        /// Returns int4.zxxy swizzling.
        /// </summary>
        public int4 zxxy => new int4(z, x, x, y);

        /// <summary>
        /// Returns int4.brrg swizzling (equivalent to int4.zxxy).
        /// </summary>
        public int4 brrg => new int4(z, x, x, y);

        /// <summary>
        /// Returns int4.zxxz swizzling.
        /// </summary>
        public int4 zxxz => new int4(z, x, x, z);

        /// <summary>
        /// Returns int4.brrb swizzling (equivalent to int4.zxxz).
        /// </summary>
        public int4 brrb => new int4(z, x, x, z);

        /// <summary>
        /// Returns int4.zxxw swizzling.
        /// </summary>
        public int4 zxxw => new int4(z, x, x, w);

        /// <summary>
        /// Returns int4.brra swizzling (equivalent to int4.zxxw).
        /// </summary>
        public int4 brra => new int4(z, x, x, w);

        /// <summary>
        /// Returns int4.zxy swizzling.
        /// </summary>
        public int3 zxy => new int3(z, x, y);

        /// <summary>
        /// Returns int4.brg swizzling (equivalent to int4.zxy).
        /// </summary>
        public int3 brg => new int3(z, x, y);

        /// <summary>
        /// Returns int4.zxyx swizzling.
        /// </summary>
        public int4 zxyx => new int4(z, x, y, x);

        /// <summary>
        /// Returns int4.brgr swizzling (equivalent to int4.zxyx).
        /// </summary>
        public int4 brgr => new int4(z, x, y, x);

        /// <summary>
        /// Returns int4.zxyy swizzling.
        /// </summary>
        public int4 zxyy => new int4(z, x, y, y);

        /// <summary>
        /// Returns int4.brgg swizzling (equivalent to int4.zxyy).
        /// </summary>
        public int4 brgg => new int4(z, x, y, y);

        /// <summary>
        /// Returns int4.zxyz swizzling.
        /// </summary>
        public int4 zxyz => new int4(z, x, y, z);

        /// <summary>
        /// Returns int4.brgb swizzling (equivalent to int4.zxyz).
        /// </summary>
        public int4 brgb => new int4(z, x, y, z);

        /// <summary>
        /// Returns int4.zxyw swizzling.
        /// </summary>
        public int4 zxyw => new int4(z, x, y, w);

        /// <summary>
        /// Returns int4.brga swizzling (equivalent to int4.zxyw).
        /// </summary>
        public int4 brga => new int4(z, x, y, w);

        /// <summary>
        /// Returns int4.zxz swizzling.
        /// </summary>
        public int3 zxz => new int3(z, x, z);

        /// <summary>
        /// Returns int4.brb swizzling (equivalent to int4.zxz).
        /// </summary>
        public int3 brb => new int3(z, x, z);

        /// <summary>
        /// Returns int4.zxzx swizzling.
        /// </summary>
        public int4 zxzx => new int4(z, x, z, x);

        /// <summary>
        /// Returns int4.brbr swizzling (equivalent to int4.zxzx).
        /// </summary>
        public int4 brbr => new int4(z, x, z, x);

        /// <summary>
        /// Returns int4.zxzy swizzling.
        /// </summary>
        public int4 zxzy => new int4(z, x, z, y);

        /// <summary>
        /// Returns int4.brbg swizzling (equivalent to int4.zxzy).
        /// </summary>
        public int4 brbg => new int4(z, x, z, y);

        /// <summary>
        /// Returns int4.zxzz swizzling.
        /// </summary>
        public int4 zxzz => new int4(z, x, z, z);

        /// <summary>
        /// Returns int4.brbb swizzling (equivalent to int4.zxzz).
        /// </summary>
        public int4 brbb => new int4(z, x, z, z);

        /// <summary>
        /// Returns int4.zxzw swizzling.
        /// </summary>
        public int4 zxzw => new int4(z, x, z, w);

        /// <summary>
        /// Returns int4.brba swizzling (equivalent to int4.zxzw).
        /// </summary>
        public int4 brba => new int4(z, x, z, w);

        /// <summary>
        /// Returns int4.zxw swizzling.
        /// </summary>
        public int3 zxw => new int3(z, x, w);

        /// <summary>
        /// Returns int4.bra swizzling (equivalent to int4.zxw).
        /// </summary>
        public int3 bra => new int3(z, x, w);

        /// <summary>
        /// Returns int4.zxwx swizzling.
        /// </summary>
        public int4 zxwx => new int4(z, x, w, x);

        /// <summary>
        /// Returns int4.brar swizzling (equivalent to int4.zxwx).
        /// </summary>
        public int4 brar => new int4(z, x, w, x);

        /// <summary>
        /// Returns int4.zxwy swizzling.
        /// </summary>
        public int4 zxwy => new int4(z, x, w, y);

        /// <summary>
        /// Returns int4.brag swizzling (equivalent to int4.zxwy).
        /// </summary>
        public int4 brag => new int4(z, x, w, y);

        /// <summary>
        /// Returns int4.zxwz swizzling.
        /// </summary>
        public int4 zxwz => new int4(z, x, w, z);

        /// <summary>
        /// Returns int4.brab swizzling (equivalent to int4.zxwz).
        /// </summary>
        public int4 brab => new int4(z, x, w, z);

        /// <summary>
        /// Returns int4.zxww swizzling.
        /// </summary>
        public int4 zxww => new int4(z, x, w, w);

        /// <summary>
        /// Returns int4.braa swizzling (equivalent to int4.zxww).
        /// </summary>
        public int4 braa => new int4(z, x, w, w);

        /// <summary>
        /// Returns int4.zy swizzling.
        /// </summary>
        public int2 zy => new int2(z, y);

        /// <summary>
        /// Returns int4.bg swizzling (equivalent to int4.zy).
        /// </summary>
        public int2 bg => new int2(z, y);

        /// <summary>
        /// Returns int4.zyx swizzling.
        /// </summary>
        public int3 zyx => new int3(z, y, x);

        /// <summary>
        /// Returns int4.bgr swizzling (equivalent to int4.zyx).
        /// </summary>
        public int3 bgr => new int3(z, y, x);

        /// <summary>
        /// Returns int4.zyxx swizzling.
        /// </summary>
        public int4 zyxx => new int4(z, y, x, x);

        /// <summary>
        /// Returns int4.bgrr swizzling (equivalent to int4.zyxx).
        /// </summary>
        public int4 bgrr => new int4(z, y, x, x);

        /// <summary>
        /// Returns int4.zyxy swizzling.
        /// </summary>
        public int4 zyxy => new int4(z, y, x, y);

        /// <summary>
        /// Returns int4.bgrg swizzling (equivalent to int4.zyxy).
        /// </summary>
        public int4 bgrg => new int4(z, y, x, y);

        /// <summary>
        /// Returns int4.zyxz swizzling.
        /// </summary>
        public int4 zyxz => new int4(z, y, x, z);

        /// <summary>
        /// Returns int4.bgrb swizzling (equivalent to int4.zyxz).
        /// </summary>
        public int4 bgrb => new int4(z, y, x, z);

        /// <summary>
        /// Returns int4.zyxw swizzling.
        /// </summary>
        public int4 zyxw => new int4(z, y, x, w);

        /// <summary>
        /// Returns int4.bgra swizzling (equivalent to int4.zyxw).
        /// </summary>
        public int4 bgra => new int4(z, y, x, w);

        /// <summary>
        /// Returns int4.zyy swizzling.
        /// </summary>
        public int3 zyy => new int3(z, y, y);

        /// <summary>
        /// Returns int4.bgg swizzling (equivalent to int4.zyy).
        /// </summary>
        public int3 bgg => new int3(z, y, y);

        /// <summary>
        /// Returns int4.zyyx swizzling.
        /// </summary>
        public int4 zyyx => new int4(z, y, y, x);

        /// <summary>
        /// Returns int4.bggr swizzling (equivalent to int4.zyyx).
        /// </summary>
        public int4 bggr => new int4(z, y, y, x);

        /// <summary>
        /// Returns int4.zyyy swizzling.
        /// </summary>
        public int4 zyyy => new int4(z, y, y, y);

        /// <summary>
        /// Returns int4.bggg swizzling (equivalent to int4.zyyy).
        /// </summary>
        public int4 bggg => new int4(z, y, y, y);

        /// <summary>
        /// Returns int4.zyyz swizzling.
        /// </summary>
        public int4 zyyz => new int4(z, y, y, z);

        /// <summary>
        /// Returns int4.bggb swizzling (equivalent to int4.zyyz).
        /// </summary>
        public int4 bggb => new int4(z, y, y, z);

        /// <summary>
        /// Returns int4.zyyw swizzling.
        /// </summary>
        public int4 zyyw => new int4(z, y, y, w);

        /// <summary>
        /// Returns int4.bgga swizzling (equivalent to int4.zyyw).
        /// </summary>
        public int4 bgga => new int4(z, y, y, w);

        /// <summary>
        /// Returns int4.zyz swizzling.
        /// </summary>
        public int3 zyz => new int3(z, y, z);

        /// <summary>
        /// Returns int4.bgb swizzling (equivalent to int4.zyz).
        /// </summary>
        public int3 bgb => new int3(z, y, z);

        /// <summary>
        /// Returns int4.zyzx swizzling.
        /// </summary>
        public int4 zyzx => new int4(z, y, z, x);

        /// <summary>
        /// Returns int4.bgbr swizzling (equivalent to int4.zyzx).
        /// </summary>
        public int4 bgbr => new int4(z, y, z, x);

        /// <summary>
        /// Returns int4.zyzy swizzling.
        /// </summary>
        public int4 zyzy => new int4(z, y, z, y);

        /// <summary>
        /// Returns int4.bgbg swizzling (equivalent to int4.zyzy).
        /// </summary>
        public int4 bgbg => new int4(z, y, z, y);

        /// <summary>
        /// Returns int4.zyzz swizzling.
        /// </summary>
        public int4 zyzz => new int4(z, y, z, z);

        /// <summary>
        /// Returns int4.bgbb swizzling (equivalent to int4.zyzz).
        /// </summary>
        public int4 bgbb => new int4(z, y, z, z);

        /// <summary>
        /// Returns int4.zyzw swizzling.
        /// </summary>
        public int4 zyzw => new int4(z, y, z, w);

        /// <summary>
        /// Returns int4.bgba swizzling (equivalent to int4.zyzw).
        /// </summary>
        public int4 bgba => new int4(z, y, z, w);

        /// <summary>
        /// Returns int4.zyw swizzling.
        /// </summary>
        public int3 zyw => new int3(z, y, w);

        /// <summary>
        /// Returns int4.bga swizzling (equivalent to int4.zyw).
        /// </summary>
        public int3 bga => new int3(z, y, w);

        /// <summary>
        /// Returns int4.zywx swizzling.
        /// </summary>
        public int4 zywx => new int4(z, y, w, x);

        /// <summary>
        /// Returns int4.bgar swizzling (equivalent to int4.zywx).
        /// </summary>
        public int4 bgar => new int4(z, y, w, x);

        /// <summary>
        /// Returns int4.zywy swizzling.
        /// </summary>
        public int4 zywy => new int4(z, y, w, y);

        /// <summary>
        /// Returns int4.bgag swizzling (equivalent to int4.zywy).
        /// </summary>
        public int4 bgag => new int4(z, y, w, y);

        /// <summary>
        /// Returns int4.zywz swizzling.
        /// </summary>
        public int4 zywz => new int4(z, y, w, z);

        /// <summary>
        /// Returns int4.bgab swizzling (equivalent to int4.zywz).
        /// </summary>
        public int4 bgab => new int4(z, y, w, z);

        /// <summary>
        /// Returns int4.zyww swizzling.
        /// </summary>
        public int4 zyww => new int4(z, y, w, w);

        /// <summary>
        /// Returns int4.bgaa swizzling (equivalent to int4.zyww).
        /// </summary>
        public int4 bgaa => new int4(z, y, w, w);

        /// <summary>
        /// Returns int4.zz swizzling.
        /// </summary>
        public int2 zz => new int2(z, z);

        /// <summary>
        /// Returns int4.bb swizzling (equivalent to int4.zz).
        /// </summary>
        public int2 bb => new int2(z, z);

        /// <summary>
        /// Returns int4.zzx swizzling.
        /// </summary>
        public int3 zzx => new int3(z, z, x);

        /// <summary>
        /// Returns int4.bbr swizzling (equivalent to int4.zzx).
        /// </summary>
        public int3 bbr => new int3(z, z, x);

        /// <summary>
        /// Returns int4.zzxx swizzling.
        /// </summary>
        public int4 zzxx => new int4(z, z, x, x);

        /// <summary>
        /// Returns int4.bbrr swizzling (equivalent to int4.zzxx).
        /// </summary>
        public int4 bbrr => new int4(z, z, x, x);

        /// <summary>
        /// Returns int4.zzxy swizzling.
        /// </summary>
        public int4 zzxy => new int4(z, z, x, y);

        /// <summary>
        /// Returns int4.bbrg swizzling (equivalent to int4.zzxy).
        /// </summary>
        public int4 bbrg => new int4(z, z, x, y);

        /// <summary>
        /// Returns int4.zzxz swizzling.
        /// </summary>
        public int4 zzxz => new int4(z, z, x, z);

        /// <summary>
        /// Returns int4.bbrb swizzling (equivalent to int4.zzxz).
        /// </summary>
        public int4 bbrb => new int4(z, z, x, z);

        /// <summary>
        /// Returns int4.zzxw swizzling.
        /// </summary>
        public int4 zzxw => new int4(z, z, x, w);

        /// <summary>
        /// Returns int4.bbra swizzling (equivalent to int4.zzxw).
        /// </summary>
        public int4 bbra => new int4(z, z, x, w);

        /// <summary>
        /// Returns int4.zzy swizzling.
        /// </summary>
        public int3 zzy => new int3(z, z, y);

        /// <summary>
        /// Returns int4.bbg swizzling (equivalent to int4.zzy).
        /// </summary>
        public int3 bbg => new int3(z, z, y);

        /// <summary>
        /// Returns int4.zzyx swizzling.
        /// </summary>
        public int4 zzyx => new int4(z, z, y, x);

        /// <summary>
        /// Returns int4.bbgr swizzling (equivalent to int4.zzyx).
        /// </summary>
        public int4 bbgr => new int4(z, z, y, x);

        /// <summary>
        /// Returns int4.zzyy swizzling.
        /// </summary>
        public int4 zzyy => new int4(z, z, y, y);

        /// <summary>
        /// Returns int4.bbgg swizzling (equivalent to int4.zzyy).
        /// </summary>
        public int4 bbgg => new int4(z, z, y, y);

        /// <summary>
        /// Returns int4.zzyz swizzling.
        /// </summary>
        public int4 zzyz => new int4(z, z, y, z);

        /// <summary>
        /// Returns int4.bbgb swizzling (equivalent to int4.zzyz).
        /// </summary>
        public int4 bbgb => new int4(z, z, y, z);

        /// <summary>
        /// Returns int4.zzyw swizzling.
        /// </summary>
        public int4 zzyw => new int4(z, z, y, w);

        /// <summary>
        /// Returns int4.bbga swizzling (equivalent to int4.zzyw).
        /// </summary>
        public int4 bbga => new int4(z, z, y, w);

        /// <summary>
        /// Returns int4.zzz swizzling.
        /// </summary>
        public int3 zzz => new int3(z, z, z);

        /// <summary>
        /// Returns int4.bbb swizzling (equivalent to int4.zzz).
        /// </summary>
        public int3 bbb => new int3(z, z, z);

        /// <summary>
        /// Returns int4.zzzx swizzling.
        /// </summary>
        public int4 zzzx => new int4(z, z, z, x);

        /// <summary>
        /// Returns int4.bbbr swizzling (equivalent to int4.zzzx).
        /// </summary>
        public int4 bbbr => new int4(z, z, z, x);

        /// <summary>
        /// Returns int4.zzzy swizzling.
        /// </summary>
        public int4 zzzy => new int4(z, z, z, y);

        /// <summary>
        /// Returns int4.bbbg swizzling (equivalent to int4.zzzy).
        /// </summary>
        public int4 bbbg => new int4(z, z, z, y);

        /// <summary>
        /// Returns int4.zzzz swizzling.
        /// </summary>
        public int4 zzzz => new int4(z, z, z, z);

        /// <summary>
        /// Returns int4.bbbb swizzling (equivalent to int4.zzzz).
        /// </summary>
        public int4 bbbb => new int4(z, z, z, z);

        /// <summary>
        /// Returns int4.zzzw swizzling.
        /// </summary>
        public int4 zzzw => new int4(z, z, z, w);

        /// <summary>
        /// Returns int4.bbba swizzling (equivalent to int4.zzzw).
        /// </summary>
        public int4 bbba => new int4(z, z, z, w);

        /// <summary>
        /// Returns int4.zzw swizzling.
        /// </summary>
        public int3 zzw => new int3(z, z, w);

        /// <summary>
        /// Returns int4.bba swizzling (equivalent to int4.zzw).
        /// </summary>
        public int3 bba => new int3(z, z, w);

        /// <summary>
        /// Returns int4.zzwx swizzling.
        /// </summary>
        public int4 zzwx => new int4(z, z, w, x);

        /// <summary>
        /// Returns int4.bbar swizzling (equivalent to int4.zzwx).
        /// </summary>
        public int4 bbar => new int4(z, z, w, x);

        /// <summary>
        /// Returns int4.zzwy swizzling.
        /// </summary>
        public int4 zzwy => new int4(z, z, w, y);

        /// <summary>
        /// Returns int4.bbag swizzling (equivalent to int4.zzwy).
        /// </summary>
        public int4 bbag => new int4(z, z, w, y);

        /// <summary>
        /// Returns int4.zzwz swizzling.
        /// </summary>
        public int4 zzwz => new int4(z, z, w, z);

        /// <summary>
        /// Returns int4.bbab swizzling (equivalent to int4.zzwz).
        /// </summary>
        public int4 bbab => new int4(z, z, w, z);

        /// <summary>
        /// Returns int4.zzww swizzling.
        /// </summary>
        public int4 zzww => new int4(z, z, w, w);

        /// <summary>
        /// Returns int4.bbaa swizzling (equivalent to int4.zzww).
        /// </summary>
        public int4 bbaa => new int4(z, z, w, w);

        /// <summary>
        /// Returns int4.zw swizzling.
        /// </summary>
        public int2 zw => new int2(z, w);

        /// <summary>
        /// Returns int4.ba swizzling (equivalent to int4.zw).
        /// </summary>
        public int2 ba => new int2(z, w);

        /// <summary>
        /// Returns int4.zwx swizzling.
        /// </summary>
        public int3 zwx => new int3(z, w, x);

        /// <summary>
        /// Returns int4.bar swizzling (equivalent to int4.zwx).
        /// </summary>
        public int3 bar => new int3(z, w, x);

        /// <summary>
        /// Returns int4.zwxx swizzling.
        /// </summary>
        public int4 zwxx => new int4(z, w, x, x);

        /// <summary>
        /// Returns int4.barr swizzling (equivalent to int4.zwxx).
        /// </summary>
        public int4 barr => new int4(z, w, x, x);

        /// <summary>
        /// Returns int4.zwxy swizzling.
        /// </summary>
        public int4 zwxy => new int4(z, w, x, y);

        /// <summary>
        /// Returns int4.barg swizzling (equivalent to int4.zwxy).
        /// </summary>
        public int4 barg => new int4(z, w, x, y);

        /// <summary>
        /// Returns int4.zwxz swizzling.
        /// </summary>
        public int4 zwxz => new int4(z, w, x, z);

        /// <summary>
        /// Returns int4.barb swizzling (equivalent to int4.zwxz).
        /// </summary>
        public int4 barb => new int4(z, w, x, z);

        /// <summary>
        /// Returns int4.zwxw swizzling.
        /// </summary>
        public int4 zwxw => new int4(z, w, x, w);

        /// <summary>
        /// Returns int4.bara swizzling (equivalent to int4.zwxw).
        /// </summary>
        public int4 bara => new int4(z, w, x, w);

        /// <summary>
        /// Returns int4.zwy swizzling.
        /// </summary>
        public int3 zwy => new int3(z, w, y);

        /// <summary>
        /// Returns int4.bag swizzling (equivalent to int4.zwy).
        /// </summary>
        public int3 bag => new int3(z, w, y);

        /// <summary>
        /// Returns int4.zwyx swizzling.
        /// </summary>
        public int4 zwyx => new int4(z, w, y, x);

        /// <summary>
        /// Returns int4.bagr swizzling (equivalent to int4.zwyx).
        /// </summary>
        public int4 bagr => new int4(z, w, y, x);

        /// <summary>
        /// Returns int4.zwyy swizzling.
        /// </summary>
        public int4 zwyy => new int4(z, w, y, y);

        /// <summary>
        /// Returns int4.bagg swizzling (equivalent to int4.zwyy).
        /// </summary>
        public int4 bagg => new int4(z, w, y, y);

        /// <summary>
        /// Returns int4.zwyz swizzling.
        /// </summary>
        public int4 zwyz => new int4(z, w, y, z);

        /// <summary>
        /// Returns int4.bagb swizzling (equivalent to int4.zwyz).
        /// </summary>
        public int4 bagb => new int4(z, w, y, z);

        /// <summary>
        /// Returns int4.zwyw swizzling.
        /// </summary>
        public int4 zwyw => new int4(z, w, y, w);

        /// <summary>
        /// Returns int4.baga swizzling (equivalent to int4.zwyw).
        /// </summary>
        public int4 baga => new int4(z, w, y, w);

        /// <summary>
        /// Returns int4.zwz swizzling.
        /// </summary>
        public int3 zwz => new int3(z, w, z);

        /// <summary>
        /// Returns int4.bab swizzling (equivalent to int4.zwz).
        /// </summary>
        public int3 bab => new int3(z, w, z);

        /// <summary>
        /// Returns int4.zwzx swizzling.
        /// </summary>
        public int4 zwzx => new int4(z, w, z, x);

        /// <summary>
        /// Returns int4.babr swizzling (equivalent to int4.zwzx).
        /// </summary>
        public int4 babr => new int4(z, w, z, x);

        /// <summary>
        /// Returns int4.zwzy swizzling.
        /// </summary>
        public int4 zwzy => new int4(z, w, z, y);

        /// <summary>
        /// Returns int4.babg swizzling (equivalent to int4.zwzy).
        /// </summary>
        public int4 babg => new int4(z, w, z, y);

        /// <summary>
        /// Returns int4.zwzz swizzling.
        /// </summary>
        public int4 zwzz => new int4(z, w, z, z);

        /// <summary>
        /// Returns int4.babb swizzling (equivalent to int4.zwzz).
        /// </summary>
        public int4 babb => new int4(z, w, z, z);

        /// <summary>
        /// Returns int4.zwzw swizzling.
        /// </summary>
        public int4 zwzw => new int4(z, w, z, w);

        /// <summary>
        /// Returns int4.baba swizzling (equivalent to int4.zwzw).
        /// </summary>
        public int4 baba => new int4(z, w, z, w);

        /// <summary>
        /// Returns int4.zww swizzling.
        /// </summary>
        public int3 zww => new int3(z, w, w);

        /// <summary>
        /// Returns int4.baa swizzling (equivalent to int4.zww).
        /// </summary>
        public int3 baa => new int3(z, w, w);

        /// <summary>
        /// Returns int4.zwwx swizzling.
        /// </summary>
        public int4 zwwx => new int4(z, w, w, x);

        /// <summary>
        /// Returns int4.baar swizzling (equivalent to int4.zwwx).
        /// </summary>
        public int4 baar => new int4(z, w, w, x);

        /// <summary>
        /// Returns int4.zwwy swizzling.
        /// </summary>
        public int4 zwwy => new int4(z, w, w, y);

        /// <summary>
        /// Returns int4.baag swizzling (equivalent to int4.zwwy).
        /// </summary>
        public int4 baag => new int4(z, w, w, y);

        /// <summary>
        /// Returns int4.zwwz swizzling.
        /// </summary>
        public int4 zwwz => new int4(z, w, w, z);

        /// <summary>
        /// Returns int4.baab swizzling (equivalent to int4.zwwz).
        /// </summary>
        public int4 baab => new int4(z, w, w, z);

        /// <summary>
        /// Returns int4.zwww swizzling.
        /// </summary>
        public int4 zwww => new int4(z, w, w, w);

        /// <summary>
        /// Returns int4.baaa swizzling (equivalent to int4.zwww).
        /// </summary>
        public int4 baaa => new int4(z, w, w, w);

        /// <summary>
        /// Returns int4.wx swizzling.
        /// </summary>
        public int2 wx => new int2(w, x);

        /// <summary>
        /// Returns int4.ar swizzling (equivalent to int4.wx).
        /// </summary>
        public int2 ar => new int2(w, x);

        /// <summary>
        /// Returns int4.wxx swizzling.
        /// </summary>
        public int3 wxx => new int3(w, x, x);

        /// <summary>
        /// Returns int4.arr swizzling (equivalent to int4.wxx).
        /// </summary>
        public int3 arr => new int3(w, x, x);

        /// <summary>
        /// Returns int4.wxxx swizzling.
        /// </summary>
        public int4 wxxx => new int4(w, x, x, x);

        /// <summary>
        /// Returns int4.arrr swizzling (equivalent to int4.wxxx).
        /// </summary>
        public int4 arrr => new int4(w, x, x, x);

        /// <summary>
        /// Returns int4.wxxy swizzling.
        /// </summary>
        public int4 wxxy => new int4(w, x, x, y);

        /// <summary>
        /// Returns int4.arrg swizzling (equivalent to int4.wxxy).
        /// </summary>
        public int4 arrg => new int4(w, x, x, y);

        /// <summary>
        /// Returns int4.wxxz swizzling.
        /// </summary>
        public int4 wxxz => new int4(w, x, x, z);

        /// <summary>
        /// Returns int4.arrb swizzling (equivalent to int4.wxxz).
        /// </summary>
        public int4 arrb => new int4(w, x, x, z);

        /// <summary>
        /// Returns int4.wxxw swizzling.
        /// </summary>
        public int4 wxxw => new int4(w, x, x, w);

        /// <summary>
        /// Returns int4.arra swizzling (equivalent to int4.wxxw).
        /// </summary>
        public int4 arra => new int4(w, x, x, w);

        /// <summary>
        /// Returns int4.wxy swizzling.
        /// </summary>
        public int3 wxy => new int3(w, x, y);

        /// <summary>
        /// Returns int4.arg swizzling (equivalent to int4.wxy).
        /// </summary>
        public int3 arg => new int3(w, x, y);

        /// <summary>
        /// Returns int4.wxyx swizzling.
        /// </summary>
        public int4 wxyx => new int4(w, x, y, x);

        /// <summary>
        /// Returns int4.argr swizzling (equivalent to int4.wxyx).
        /// </summary>
        public int4 argr => new int4(w, x, y, x);

        /// <summary>
        /// Returns int4.wxyy swizzling.
        /// </summary>
        public int4 wxyy => new int4(w, x, y, y);

        /// <summary>
        /// Returns int4.argg swizzling (equivalent to int4.wxyy).
        /// </summary>
        public int4 argg => new int4(w, x, y, y);

        /// <summary>
        /// Returns int4.wxyz swizzling.
        /// </summary>
        public int4 wxyz => new int4(w, x, y, z);

        /// <summary>
        /// Returns int4.argb swizzling (equivalent to int4.wxyz).
        /// </summary>
        public int4 argb => new int4(w, x, y, z);

        /// <summary>
        /// Returns int4.wxyw swizzling.
        /// </summary>
        public int4 wxyw => new int4(w, x, y, w);

        /// <summary>
        /// Returns int4.arga swizzling (equivalent to int4.wxyw).
        /// </summary>
        public int4 arga => new int4(w, x, y, w);

        /// <summary>
        /// Returns int4.wxz swizzling.
        /// </summary>
        public int3 wxz => new int3(w, x, z);

        /// <summary>
        /// Returns int4.arb swizzling (equivalent to int4.wxz).
        /// </summary>
        public int3 arb => new int3(w, x, z);

        /// <summary>
        /// Returns int4.wxzx swizzling.
        /// </summary>
        public int4 wxzx => new int4(w, x, z, x);

        /// <summary>
        /// Returns int4.arbr swizzling (equivalent to int4.wxzx).
        /// </summary>
        public int4 arbr => new int4(w, x, z, x);

        /// <summary>
        /// Returns int4.wxzy swizzling.
        /// </summary>
        public int4 wxzy => new int4(w, x, z, y);

        /// <summary>
        /// Returns int4.arbg swizzling (equivalent to int4.wxzy).
        /// </summary>
        public int4 arbg => new int4(w, x, z, y);

        /// <summary>
        /// Returns int4.wxzz swizzling.
        /// </summary>
        public int4 wxzz => new int4(w, x, z, z);

        /// <summary>
        /// Returns int4.arbb swizzling (equivalent to int4.wxzz).
        /// </summary>
        public int4 arbb => new int4(w, x, z, z);

        /// <summary>
        /// Returns int4.wxzw swizzling.
        /// </summary>
        public int4 wxzw => new int4(w, x, z, w);

        /// <summary>
        /// Returns int4.arba swizzling (equivalent to int4.wxzw).
        /// </summary>
        public int4 arba => new int4(w, x, z, w);

        /// <summary>
        /// Returns int4.wxw swizzling.
        /// </summary>
        public int3 wxw => new int3(w, x, w);

        /// <summary>
        /// Returns int4.ara swizzling (equivalent to int4.wxw).
        /// </summary>
        public int3 ara => new int3(w, x, w);

        /// <summary>
        /// Returns int4.wxwx swizzling.
        /// </summary>
        public int4 wxwx => new int4(w, x, w, x);

        /// <summary>
        /// Returns int4.arar swizzling (equivalent to int4.wxwx).
        /// </summary>
        public int4 arar => new int4(w, x, w, x);

        /// <summary>
        /// Returns int4.wxwy swizzling.
        /// </summary>
        public int4 wxwy => new int4(w, x, w, y);

        /// <summary>
        /// Returns int4.arag swizzling (equivalent to int4.wxwy).
        /// </summary>
        public int4 arag => new int4(w, x, w, y);

        /// <summary>
        /// Returns int4.wxwz swizzling.
        /// </summary>
        public int4 wxwz => new int4(w, x, w, z);

        /// <summary>
        /// Returns int4.arab swizzling (equivalent to int4.wxwz).
        /// </summary>
        public int4 arab => new int4(w, x, w, z);

        /// <summary>
        /// Returns int4.wxww swizzling.
        /// </summary>
        public int4 wxww => new int4(w, x, w, w);

        /// <summary>
        /// Returns int4.araa swizzling (equivalent to int4.wxww).
        /// </summary>
        public int4 araa => new int4(w, x, w, w);

        /// <summary>
        /// Returns int4.wy swizzling.
        /// </summary>
        public int2 wy => new int2(w, y);

        /// <summary>
        /// Returns int4.ag swizzling (equivalent to int4.wy).
        /// </summary>
        public int2 ag => new int2(w, y);

        /// <summary>
        /// Returns int4.wyx swizzling.
        /// </summary>
        public int3 wyx => new int3(w, y, x);

        /// <summary>
        /// Returns int4.agr swizzling (equivalent to int4.wyx).
        /// </summary>
        public int3 agr => new int3(w, y, x);

        /// <summary>
        /// Returns int4.wyxx swizzling.
        /// </summary>
        public int4 wyxx => new int4(w, y, x, x);

        /// <summary>
        /// Returns int4.agrr swizzling (equivalent to int4.wyxx).
        /// </summary>
        public int4 agrr => new int4(w, y, x, x);

        /// <summary>
        /// Returns int4.wyxy swizzling.
        /// </summary>
        public int4 wyxy => new int4(w, y, x, y);

        /// <summary>
        /// Returns int4.agrg swizzling (equivalent to int4.wyxy).
        /// </summary>
        public int4 agrg => new int4(w, y, x, y);

        /// <summary>
        /// Returns int4.wyxz swizzling.
        /// </summary>
        public int4 wyxz => new int4(w, y, x, z);

        /// <summary>
        /// Returns int4.agrb swizzling (equivalent to int4.wyxz).
        /// </summary>
        public int4 agrb => new int4(w, y, x, z);

        /// <summary>
        /// Returns int4.wyxw swizzling.
        /// </summary>
        public int4 wyxw => new int4(w, y, x, w);

        /// <summary>
        /// Returns int4.agra swizzling (equivalent to int4.wyxw).
        /// </summary>
        public int4 agra => new int4(w, y, x, w);

        /// <summary>
        /// Returns int4.wyy swizzling.
        /// </summary>
        public int3 wyy => new int3(w, y, y);

        /// <summary>
        /// Returns int4.agg swizzling (equivalent to int4.wyy).
        /// </summary>
        public int3 agg => new int3(w, y, y);

        /// <summary>
        /// Returns int4.wyyx swizzling.
        /// </summary>
        public int4 wyyx => new int4(w, y, y, x);

        /// <summary>
        /// Returns int4.aggr swizzling (equivalent to int4.wyyx).
        /// </summary>
        public int4 aggr => new int4(w, y, y, x);

        /// <summary>
        /// Returns int4.wyyy swizzling.
        /// </summary>
        public int4 wyyy => new int4(w, y, y, y);

        /// <summary>
        /// Returns int4.aggg swizzling (equivalent to int4.wyyy).
        /// </summary>
        public int4 aggg => new int4(w, y, y, y);

        /// <summary>
        /// Returns int4.wyyz swizzling.
        /// </summary>
        public int4 wyyz => new int4(w, y, y, z);

        /// <summary>
        /// Returns int4.aggb swizzling (equivalent to int4.wyyz).
        /// </summary>
        public int4 aggb => new int4(w, y, y, z);

        /// <summary>
        /// Returns int4.wyyw swizzling.
        /// </summary>
        public int4 wyyw => new int4(w, y, y, w);

        /// <summary>
        /// Returns int4.agga swizzling (equivalent to int4.wyyw).
        /// </summary>
        public int4 agga => new int4(w, y, y, w);

        /// <summary>
        /// Returns int4.wyz swizzling.
        /// </summary>
        public int3 wyz => new int3(w, y, z);

        /// <summary>
        /// Returns int4.agb swizzling (equivalent to int4.wyz).
        /// </summary>
        public int3 agb => new int3(w, y, z);

        /// <summary>
        /// Returns int4.wyzx swizzling.
        /// </summary>
        public int4 wyzx => new int4(w, y, z, x);

        /// <summary>
        /// Returns int4.agbr swizzling (equivalent to int4.wyzx).
        /// </summary>
        public int4 agbr => new int4(w, y, z, x);

        /// <summary>
        /// Returns int4.wyzy swizzling.
        /// </summary>
        public int4 wyzy => new int4(w, y, z, y);

        /// <summary>
        /// Returns int4.agbg swizzling (equivalent to int4.wyzy).
        /// </summary>
        public int4 agbg => new int4(w, y, z, y);

        /// <summary>
        /// Returns int4.wyzz swizzling.
        /// </summary>
        public int4 wyzz => new int4(w, y, z, z);

        /// <summary>
        /// Returns int4.agbb swizzling (equivalent to int4.wyzz).
        /// </summary>
        public int4 agbb => new int4(w, y, z, z);

        /// <summary>
        /// Returns int4.wyzw swizzling.
        /// </summary>
        public int4 wyzw => new int4(w, y, z, w);

        /// <summary>
        /// Returns int4.agba swizzling (equivalent to int4.wyzw).
        /// </summary>
        public int4 agba => new int4(w, y, z, w);

        /// <summary>
        /// Returns int4.wyw swizzling.
        /// </summary>
        public int3 wyw => new int3(w, y, w);

        /// <summary>
        /// Returns int4.aga swizzling (equivalent to int4.wyw).
        /// </summary>
        public int3 aga => new int3(w, y, w);

        /// <summary>
        /// Returns int4.wywx swizzling.
        /// </summary>
        public int4 wywx => new int4(w, y, w, x);

        /// <summary>
        /// Returns int4.agar swizzling (equivalent to int4.wywx).
        /// </summary>
        public int4 agar => new int4(w, y, w, x);

        /// <summary>
        /// Returns int4.wywy swizzling.
        /// </summary>
        public int4 wywy => new int4(w, y, w, y);

        /// <summary>
        /// Returns int4.agag swizzling (equivalent to int4.wywy).
        /// </summary>
        public int4 agag => new int4(w, y, w, y);

        /// <summary>
        /// Returns int4.wywz swizzling.
        /// </summary>
        public int4 wywz => new int4(w, y, w, z);

        /// <summary>
        /// Returns int4.agab swizzling (equivalent to int4.wywz).
        /// </summary>
        public int4 agab => new int4(w, y, w, z);

        /// <summary>
        /// Returns int4.wyww swizzling.
        /// </summary>
        public int4 wyww => new int4(w, y, w, w);

        /// <summary>
        /// Returns int4.agaa swizzling (equivalent to int4.wyww).
        /// </summary>
        public int4 agaa => new int4(w, y, w, w);

        /// <summary>
        /// Returns int4.wz swizzling.
        /// </summary>
        public int2 wz => new int2(w, z);

        /// <summary>
        /// Returns int4.ab swizzling (equivalent to int4.wz).
        /// </summary>
        public int2 ab => new int2(w, z);

        /// <summary>
        /// Returns int4.wzx swizzling.
        /// </summary>
        public int3 wzx => new int3(w, z, x);

        /// <summary>
        /// Returns int4.abr swizzling (equivalent to int4.wzx).
        /// </summary>
        public int3 abr => new int3(w, z, x);

        /// <summary>
        /// Returns int4.wzxx swizzling.
        /// </summary>
        public int4 wzxx => new int4(w, z, x, x);

        /// <summary>
        /// Returns int4.abrr swizzling (equivalent to int4.wzxx).
        /// </summary>
        public int4 abrr => new int4(w, z, x, x);

        /// <summary>
        /// Returns int4.wzxy swizzling.
        /// </summary>
        public int4 wzxy => new int4(w, z, x, y);

        /// <summary>
        /// Returns int4.abrg swizzling (equivalent to int4.wzxy).
        /// </summary>
        public int4 abrg => new int4(w, z, x, y);

        /// <summary>
        /// Returns int4.wzxz swizzling.
        /// </summary>
        public int4 wzxz => new int4(w, z, x, z);

        /// <summary>
        /// Returns int4.abrb swizzling (equivalent to int4.wzxz).
        /// </summary>
        public int4 abrb => new int4(w, z, x, z);

        /// <summary>
        /// Returns int4.wzxw swizzling.
        /// </summary>
        public int4 wzxw => new int4(w, z, x, w);

        /// <summary>
        /// Returns int4.abra swizzling (equivalent to int4.wzxw).
        /// </summary>
        public int4 abra => new int4(w, z, x, w);

        /// <summary>
        /// Returns int4.wzy swizzling.
        /// </summary>
        public int3 wzy => new int3(w, z, y);

        /// <summary>
        /// Returns int4.abg swizzling (equivalent to int4.wzy).
        /// </summary>
        public int3 abg => new int3(w, z, y);

        /// <summary>
        /// Returns int4.wzyx swizzling.
        /// </summary>
        public int4 wzyx => new int4(w, z, y, x);

        /// <summary>
        /// Returns int4.abgr swizzling (equivalent to int4.wzyx).
        /// </summary>
        public int4 abgr => new int4(w, z, y, x);

        /// <summary>
        /// Returns int4.wzyy swizzling.
        /// </summary>
        public int4 wzyy => new int4(w, z, y, y);

        /// <summary>
        /// Returns int4.abgg swizzling (equivalent to int4.wzyy).
        /// </summary>
        public int4 abgg => new int4(w, z, y, y);

        /// <summary>
        /// Returns int4.wzyz swizzling.
        /// </summary>
        public int4 wzyz => new int4(w, z, y, z);

        /// <summary>
        /// Returns int4.abgb swizzling (equivalent to int4.wzyz).
        /// </summary>
        public int4 abgb => new int4(w, z, y, z);

        /// <summary>
        /// Returns int4.wzyw swizzling.
        /// </summary>
        public int4 wzyw => new int4(w, z, y, w);

        /// <summary>
        /// Returns int4.abga swizzling (equivalent to int4.wzyw).
        /// </summary>
        public int4 abga => new int4(w, z, y, w);

        /// <summary>
        /// Returns int4.wzz swizzling.
        /// </summary>
        public int3 wzz => new int3(w, z, z);

        /// <summary>
        /// Returns int4.abb swizzling (equivalent to int4.wzz).
        /// </summary>
        public int3 abb => new int3(w, z, z);

        /// <summary>
        /// Returns int4.wzzx swizzling.
        /// </summary>
        public int4 wzzx => new int4(w, z, z, x);

        /// <summary>
        /// Returns int4.abbr swizzling (equivalent to int4.wzzx).
        /// </summary>
        public int4 abbr => new int4(w, z, z, x);

        /// <summary>
        /// Returns int4.wzzy swizzling.
        /// </summary>
        public int4 wzzy => new int4(w, z, z, y);

        /// <summary>
        /// Returns int4.abbg swizzling (equivalent to int4.wzzy).
        /// </summary>
        public int4 abbg => new int4(w, z, z, y);

        /// <summary>
        /// Returns int4.wzzz swizzling.
        /// </summary>
        public int4 wzzz => new int4(w, z, z, z);

        /// <summary>
        /// Returns int4.abbb swizzling (equivalent to int4.wzzz).
        /// </summary>
        public int4 abbb => new int4(w, z, z, z);

        /// <summary>
        /// Returns int4.wzzw swizzling.
        /// </summary>
        public int4 wzzw => new int4(w, z, z, w);

        /// <summary>
        /// Returns int4.abba swizzling (equivalent to int4.wzzw).
        /// </summary>
        public int4 abba => new int4(w, z, z, w);

        /// <summary>
        /// Returns int4.wzw swizzling.
        /// </summary>
        public int3 wzw => new int3(w, z, w);

        /// <summary>
        /// Returns int4.aba swizzling (equivalent to int4.wzw).
        /// </summary>
        public int3 aba => new int3(w, z, w);

        /// <summary>
        /// Returns int4.wzwx swizzling.
        /// </summary>
        public int4 wzwx => new int4(w, z, w, x);

        /// <summary>
        /// Returns int4.abar swizzling (equivalent to int4.wzwx).
        /// </summary>
        public int4 abar => new int4(w, z, w, x);

        /// <summary>
        /// Returns int4.wzwy swizzling.
        /// </summary>
        public int4 wzwy => new int4(w, z, w, y);

        /// <summary>
        /// Returns int4.abag swizzling (equivalent to int4.wzwy).
        /// </summary>
        public int4 abag => new int4(w, z, w, y);

        /// <summary>
        /// Returns int4.wzwz swizzling.
        /// </summary>
        public int4 wzwz => new int4(w, z, w, z);

        /// <summary>
        /// Returns int4.abab swizzling (equivalent to int4.wzwz).
        /// </summary>
        public int4 abab => new int4(w, z, w, z);

        /// <summary>
        /// Returns int4.wzww swizzling.
        /// </summary>
        public int4 wzww => new int4(w, z, w, w);

        /// <summary>
        /// Returns int4.abaa swizzling (equivalent to int4.wzww).
        /// </summary>
        public int4 abaa => new int4(w, z, w, w);

        /// <summary>
        /// Returns int4.ww swizzling.
        /// </summary>
        public int2 ww => new int2(w, w);

        /// <summary>
        /// Returns int4.aa swizzling (equivalent to int4.ww).
        /// </summary>
        public int2 aa => new int2(w, w);

        /// <summary>
        /// Returns int4.wwx swizzling.
        /// </summary>
        public int3 wwx => new int3(w, w, x);

        /// <summary>
        /// Returns int4.aar swizzling (equivalent to int4.wwx).
        /// </summary>
        public int3 aar => new int3(w, w, x);

        /// <summary>
        /// Returns int4.wwxx swizzling.
        /// </summary>
        public int4 wwxx => new int4(w, w, x, x);

        /// <summary>
        /// Returns int4.aarr swizzling (equivalent to int4.wwxx).
        /// </summary>
        public int4 aarr => new int4(w, w, x, x);

        /// <summary>
        /// Returns int4.wwxy swizzling.
        /// </summary>
        public int4 wwxy => new int4(w, w, x, y);

        /// <summary>
        /// Returns int4.aarg swizzling (equivalent to int4.wwxy).
        /// </summary>
        public int4 aarg => new int4(w, w, x, y);

        /// <summary>
        /// Returns int4.wwxz swizzling.
        /// </summary>
        public int4 wwxz => new int4(w, w, x, z);

        /// <summary>
        /// Returns int4.aarb swizzling (equivalent to int4.wwxz).
        /// </summary>
        public int4 aarb => new int4(w, w, x, z);

        /// <summary>
        /// Returns int4.wwxw swizzling.
        /// </summary>
        public int4 wwxw => new int4(w, w, x, w);

        /// <summary>
        /// Returns int4.aara swizzling (equivalent to int4.wwxw).
        /// </summary>
        public int4 aara => new int4(w, w, x, w);

        /// <summary>
        /// Returns int4.wwy swizzling.
        /// </summary>
        public int3 wwy => new int3(w, w, y);

        /// <summary>
        /// Returns int4.aag swizzling (equivalent to int4.wwy).
        /// </summary>
        public int3 aag => new int3(w, w, y);

        /// <summary>
        /// Returns int4.wwyx swizzling.
        /// </summary>
        public int4 wwyx => new int4(w, w, y, x);

        /// <summary>
        /// Returns int4.aagr swizzling (equivalent to int4.wwyx).
        /// </summary>
        public int4 aagr => new int4(w, w, y, x);

        /// <summary>
        /// Returns int4.wwyy swizzling.
        /// </summary>
        public int4 wwyy => new int4(w, w, y, y);

        /// <summary>
        /// Returns int4.aagg swizzling (equivalent to int4.wwyy).
        /// </summary>
        public int4 aagg => new int4(w, w, y, y);

        /// <summary>
        /// Returns int4.wwyz swizzling.
        /// </summary>
        public int4 wwyz => new int4(w, w, y, z);

        /// <summary>
        /// Returns int4.aagb swizzling (equivalent to int4.wwyz).
        /// </summary>
        public int4 aagb => new int4(w, w, y, z);

        /// <summary>
        /// Returns int4.wwyw swizzling.
        /// </summary>
        public int4 wwyw => new int4(w, w, y, w);

        /// <summary>
        /// Returns int4.aaga swizzling (equivalent to int4.wwyw).
        /// </summary>
        public int4 aaga => new int4(w, w, y, w);

        /// <summary>
        /// Returns int4.wwz swizzling.
        /// </summary>
        public int3 wwz => new int3(w, w, z);

        /// <summary>
        /// Returns int4.aab swizzling (equivalent to int4.wwz).
        /// </summary>
        public int3 aab => new int3(w, w, z);

        /// <summary>
        /// Returns int4.wwzx swizzling.
        /// </summary>
        public int4 wwzx => new int4(w, w, z, x);

        /// <summary>
        /// Returns int4.aabr swizzling (equivalent to int4.wwzx).
        /// </summary>
        public int4 aabr => new int4(w, w, z, x);

        /// <summary>
        /// Returns int4.wwzy swizzling.
        /// </summary>
        public int4 wwzy => new int4(w, w, z, y);

        /// <summary>
        /// Returns int4.aabg swizzling (equivalent to int4.wwzy).
        /// </summary>
        public int4 aabg => new int4(w, w, z, y);

        /// <summary>
        /// Returns int4.wwzz swizzling.
        /// </summary>
        public int4 wwzz => new int4(w, w, z, z);

        /// <summary>
        /// Returns int4.aabb swizzling (equivalent to int4.wwzz).
        /// </summary>
        public int4 aabb => new int4(w, w, z, z);

        /// <summary>
        /// Returns int4.wwzw swizzling.
        /// </summary>
        public int4 wwzw => new int4(w, w, z, w);

        /// <summary>
        /// Returns int4.aaba swizzling (equivalent to int4.wwzw).
        /// </summary>
        public int4 aaba => new int4(w, w, z, w);

        /// <summary>
        /// Returns int4.www swizzling.
        /// </summary>
        public int3 www => new int3(w, w, w);

        /// <summary>
        /// Returns int4.aaa swizzling (equivalent to int4.www).
        /// </summary>
        public int3 aaa => new int3(w, w, w);

        /// <summary>
        /// Returns int4.wwwx swizzling.
        /// </summary>
        public int4 wwwx => new int4(w, w, w, x);

        /// <summary>
        /// Returns int4.aaar swizzling (equivalent to int4.wwwx).
        /// </summary>
        public int4 aaar => new int4(w, w, w, x);

        /// <summary>
        /// Returns int4.wwwy swizzling.
        /// </summary>
        public int4 wwwy => new int4(w, w, w, y);

        /// <summary>
        /// Returns int4.aaag swizzling (equivalent to int4.wwwy).
        /// </summary>
        public int4 aaag => new int4(w, w, w, y);

        /// <summary>
        /// Returns int4.wwwz swizzling.
        /// </summary>
        public int4 wwwz => new int4(w, w, w, z);

        /// <summary>
        /// Returns int4.aaab swizzling (equivalent to int4.wwwz).
        /// </summary>
        public int4 aaab => new int4(w, w, w, z);

        /// <summary>
        /// Returns int4.wwww swizzling.
        /// </summary>
        public int4 wwww => new int4(w, w, w, w);

        /// <summary>
        /// Returns int4.aaaa swizzling (equivalent to int4.wwww).
        /// </summary>
        public int4 aaaa => new int4(w, w, w, w);

        #endregion

    }
}
