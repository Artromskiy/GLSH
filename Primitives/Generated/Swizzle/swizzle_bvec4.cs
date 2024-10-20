using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type bool with 4 components, used for implementing swizzling for bool4.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_bvec4
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

        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        internal readonly bool w;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_bvec4.
        /// </summary>
        internal swizzle_bvec4(bool x, bool y, bool z, bool w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns bool4.xx swizzling.
        /// </summary>
        public bool2 xx => new bool2(x, x);

        /// <summary>
        /// Returns bool4.rr swizzling (equivalent to bool4.xx).
        /// </summary>
        public bool2 rr => new bool2(x, x);

        /// <summary>
        /// Returns bool4.xxx swizzling.
        /// </summary>
        public bool3 xxx => new bool3(x, x, x);

        /// <summary>
        /// Returns bool4.rrr swizzling (equivalent to bool4.xxx).
        /// </summary>
        public bool3 rrr => new bool3(x, x, x);

        /// <summary>
        /// Returns bool4.xxxx swizzling.
        /// </summary>
        public bool4 xxxx => new bool4(x, x, x, x);

        /// <summary>
        /// Returns bool4.rrrr swizzling (equivalent to bool4.xxxx).
        /// </summary>
        public bool4 rrrr => new bool4(x, x, x, x);

        /// <summary>
        /// Returns bool4.xxxy swizzling.
        /// </summary>
        public bool4 xxxy => new bool4(x, x, x, y);

        /// <summary>
        /// Returns bool4.rrrg swizzling (equivalent to bool4.xxxy).
        /// </summary>
        public bool4 rrrg => new bool4(x, x, x, y);

        /// <summary>
        /// Returns bool4.xxxz swizzling.
        /// </summary>
        public bool4 xxxz => new bool4(x, x, x, z);

        /// <summary>
        /// Returns bool4.rrrb swizzling (equivalent to bool4.xxxz).
        /// </summary>
        public bool4 rrrb => new bool4(x, x, x, z);

        /// <summary>
        /// Returns bool4.xxxw swizzling.
        /// </summary>
        public bool4 xxxw => new bool4(x, x, x, w);

        /// <summary>
        /// Returns bool4.rrra swizzling (equivalent to bool4.xxxw).
        /// </summary>
        public bool4 rrra => new bool4(x, x, x, w);

        /// <summary>
        /// Returns bool4.xxy swizzling.
        /// </summary>
        public bool3 xxy => new bool3(x, x, y);

        /// <summary>
        /// Returns bool4.rrg swizzling (equivalent to bool4.xxy).
        /// </summary>
        public bool3 rrg => new bool3(x, x, y);

        /// <summary>
        /// Returns bool4.xxyx swizzling.
        /// </summary>
        public bool4 xxyx => new bool4(x, x, y, x);

        /// <summary>
        /// Returns bool4.rrgr swizzling (equivalent to bool4.xxyx).
        /// </summary>
        public bool4 rrgr => new bool4(x, x, y, x);

        /// <summary>
        /// Returns bool4.xxyy swizzling.
        /// </summary>
        public bool4 xxyy => new bool4(x, x, y, y);

        /// <summary>
        /// Returns bool4.rrgg swizzling (equivalent to bool4.xxyy).
        /// </summary>
        public bool4 rrgg => new bool4(x, x, y, y);

        /// <summary>
        /// Returns bool4.xxyz swizzling.
        /// </summary>
        public bool4 xxyz => new bool4(x, x, y, z);

        /// <summary>
        /// Returns bool4.rrgb swizzling (equivalent to bool4.xxyz).
        /// </summary>
        public bool4 rrgb => new bool4(x, x, y, z);

        /// <summary>
        /// Returns bool4.xxyw swizzling.
        /// </summary>
        public bool4 xxyw => new bool4(x, x, y, w);

        /// <summary>
        /// Returns bool4.rrga swizzling (equivalent to bool4.xxyw).
        /// </summary>
        public bool4 rrga => new bool4(x, x, y, w);

        /// <summary>
        /// Returns bool4.xxz swizzling.
        /// </summary>
        public bool3 xxz => new bool3(x, x, z);

        /// <summary>
        /// Returns bool4.rrb swizzling (equivalent to bool4.xxz).
        /// </summary>
        public bool3 rrb => new bool3(x, x, z);

        /// <summary>
        /// Returns bool4.xxzx swizzling.
        /// </summary>
        public bool4 xxzx => new bool4(x, x, z, x);

        /// <summary>
        /// Returns bool4.rrbr swizzling (equivalent to bool4.xxzx).
        /// </summary>
        public bool4 rrbr => new bool4(x, x, z, x);

        /// <summary>
        /// Returns bool4.xxzy swizzling.
        /// </summary>
        public bool4 xxzy => new bool4(x, x, z, y);

        /// <summary>
        /// Returns bool4.rrbg swizzling (equivalent to bool4.xxzy).
        /// </summary>
        public bool4 rrbg => new bool4(x, x, z, y);

        /// <summary>
        /// Returns bool4.xxzz swizzling.
        /// </summary>
        public bool4 xxzz => new bool4(x, x, z, z);

        /// <summary>
        /// Returns bool4.rrbb swizzling (equivalent to bool4.xxzz).
        /// </summary>
        public bool4 rrbb => new bool4(x, x, z, z);

        /// <summary>
        /// Returns bool4.xxzw swizzling.
        /// </summary>
        public bool4 xxzw => new bool4(x, x, z, w);

        /// <summary>
        /// Returns bool4.rrba swizzling (equivalent to bool4.xxzw).
        /// </summary>
        public bool4 rrba => new bool4(x, x, z, w);

        /// <summary>
        /// Returns bool4.xxw swizzling.
        /// </summary>
        public bool3 xxw => new bool3(x, x, w);

        /// <summary>
        /// Returns bool4.rra swizzling (equivalent to bool4.xxw).
        /// </summary>
        public bool3 rra => new bool3(x, x, w);

        /// <summary>
        /// Returns bool4.xxwx swizzling.
        /// </summary>
        public bool4 xxwx => new bool4(x, x, w, x);

        /// <summary>
        /// Returns bool4.rrar swizzling (equivalent to bool4.xxwx).
        /// </summary>
        public bool4 rrar => new bool4(x, x, w, x);

        /// <summary>
        /// Returns bool4.xxwy swizzling.
        /// </summary>
        public bool4 xxwy => new bool4(x, x, w, y);

        /// <summary>
        /// Returns bool4.rrag swizzling (equivalent to bool4.xxwy).
        /// </summary>
        public bool4 rrag => new bool4(x, x, w, y);

        /// <summary>
        /// Returns bool4.xxwz swizzling.
        /// </summary>
        public bool4 xxwz => new bool4(x, x, w, z);

        /// <summary>
        /// Returns bool4.rrab swizzling (equivalent to bool4.xxwz).
        /// </summary>
        public bool4 rrab => new bool4(x, x, w, z);

        /// <summary>
        /// Returns bool4.xxww swizzling.
        /// </summary>
        public bool4 xxww => new bool4(x, x, w, w);

        /// <summary>
        /// Returns bool4.rraa swizzling (equivalent to bool4.xxww).
        /// </summary>
        public bool4 rraa => new bool4(x, x, w, w);

        /// <summary>
        /// Returns bool4.xy swizzling.
        /// </summary>
        public bool2 xy => new bool2(x, y);

        /// <summary>
        /// Returns bool4.rg swizzling (equivalent to bool4.xy).
        /// </summary>
        public bool2 rg => new bool2(x, y);

        /// <summary>
        /// Returns bool4.xyx swizzling.
        /// </summary>
        public bool3 xyx => new bool3(x, y, x);

        /// <summary>
        /// Returns bool4.rgr swizzling (equivalent to bool4.xyx).
        /// </summary>
        public bool3 rgr => new bool3(x, y, x);

        /// <summary>
        /// Returns bool4.xyxx swizzling.
        /// </summary>
        public bool4 xyxx => new bool4(x, y, x, x);

        /// <summary>
        /// Returns bool4.rgrr swizzling (equivalent to bool4.xyxx).
        /// </summary>
        public bool4 rgrr => new bool4(x, y, x, x);

        /// <summary>
        /// Returns bool4.xyxy swizzling.
        /// </summary>
        public bool4 xyxy => new bool4(x, y, x, y);

        /// <summary>
        /// Returns bool4.rgrg swizzling (equivalent to bool4.xyxy).
        /// </summary>
        public bool4 rgrg => new bool4(x, y, x, y);

        /// <summary>
        /// Returns bool4.xyxz swizzling.
        /// </summary>
        public bool4 xyxz => new bool4(x, y, x, z);

        /// <summary>
        /// Returns bool4.rgrb swizzling (equivalent to bool4.xyxz).
        /// </summary>
        public bool4 rgrb => new bool4(x, y, x, z);

        /// <summary>
        /// Returns bool4.xyxw swizzling.
        /// </summary>
        public bool4 xyxw => new bool4(x, y, x, w);

        /// <summary>
        /// Returns bool4.rgra swizzling (equivalent to bool4.xyxw).
        /// </summary>
        public bool4 rgra => new bool4(x, y, x, w);

        /// <summary>
        /// Returns bool4.xyy swizzling.
        /// </summary>
        public bool3 xyy => new bool3(x, y, y);

        /// <summary>
        /// Returns bool4.rgg swizzling (equivalent to bool4.xyy).
        /// </summary>
        public bool3 rgg => new bool3(x, y, y);

        /// <summary>
        /// Returns bool4.xyyx swizzling.
        /// </summary>
        public bool4 xyyx => new bool4(x, y, y, x);

        /// <summary>
        /// Returns bool4.rggr swizzling (equivalent to bool4.xyyx).
        /// </summary>
        public bool4 rggr => new bool4(x, y, y, x);

        /// <summary>
        /// Returns bool4.xyyy swizzling.
        /// </summary>
        public bool4 xyyy => new bool4(x, y, y, y);

        /// <summary>
        /// Returns bool4.rggg swizzling (equivalent to bool4.xyyy).
        /// </summary>
        public bool4 rggg => new bool4(x, y, y, y);

        /// <summary>
        /// Returns bool4.xyyz swizzling.
        /// </summary>
        public bool4 xyyz => new bool4(x, y, y, z);

        /// <summary>
        /// Returns bool4.rggb swizzling (equivalent to bool4.xyyz).
        /// </summary>
        public bool4 rggb => new bool4(x, y, y, z);

        /// <summary>
        /// Returns bool4.xyyw swizzling.
        /// </summary>
        public bool4 xyyw => new bool4(x, y, y, w);

        /// <summary>
        /// Returns bool4.rgga swizzling (equivalent to bool4.xyyw).
        /// </summary>
        public bool4 rgga => new bool4(x, y, y, w);

        /// <summary>
        /// Returns bool4.xyz swizzling.
        /// </summary>
        public bool3 xyz => new bool3(x, y, z);

        /// <summary>
        /// Returns bool4.rgb swizzling (equivalent to bool4.xyz).
        /// </summary>
        public bool3 rgb => new bool3(x, y, z);

        /// <summary>
        /// Returns bool4.xyzx swizzling.
        /// </summary>
        public bool4 xyzx => new bool4(x, y, z, x);

        /// <summary>
        /// Returns bool4.rgbr swizzling (equivalent to bool4.xyzx).
        /// </summary>
        public bool4 rgbr => new bool4(x, y, z, x);

        /// <summary>
        /// Returns bool4.xyzy swizzling.
        /// </summary>
        public bool4 xyzy => new bool4(x, y, z, y);

        /// <summary>
        /// Returns bool4.rgbg swizzling (equivalent to bool4.xyzy).
        /// </summary>
        public bool4 rgbg => new bool4(x, y, z, y);

        /// <summary>
        /// Returns bool4.xyzz swizzling.
        /// </summary>
        public bool4 xyzz => new bool4(x, y, z, z);

        /// <summary>
        /// Returns bool4.rgbb swizzling (equivalent to bool4.xyzz).
        /// </summary>
        public bool4 rgbb => new bool4(x, y, z, z);

        /// <summary>
        /// Returns bool4.xyzw swizzling.
        /// </summary>
        public bool4 xyzw => new bool4(x, y, z, w);

        /// <summary>
        /// Returns bool4.rgba swizzling (equivalent to bool4.xyzw).
        /// </summary>
        public bool4 rgba => new bool4(x, y, z, w);

        /// <summary>
        /// Returns bool4.xyw swizzling.
        /// </summary>
        public bool3 xyw => new bool3(x, y, w);

        /// <summary>
        /// Returns bool4.rga swizzling (equivalent to bool4.xyw).
        /// </summary>
        public bool3 rga => new bool3(x, y, w);

        /// <summary>
        /// Returns bool4.xywx swizzling.
        /// </summary>
        public bool4 xywx => new bool4(x, y, w, x);

        /// <summary>
        /// Returns bool4.rgar swizzling (equivalent to bool4.xywx).
        /// </summary>
        public bool4 rgar => new bool4(x, y, w, x);

        /// <summary>
        /// Returns bool4.xywy swizzling.
        /// </summary>
        public bool4 xywy => new bool4(x, y, w, y);

        /// <summary>
        /// Returns bool4.rgag swizzling (equivalent to bool4.xywy).
        /// </summary>
        public bool4 rgag => new bool4(x, y, w, y);

        /// <summary>
        /// Returns bool4.xywz swizzling.
        /// </summary>
        public bool4 xywz => new bool4(x, y, w, z);

        /// <summary>
        /// Returns bool4.rgab swizzling (equivalent to bool4.xywz).
        /// </summary>
        public bool4 rgab => new bool4(x, y, w, z);

        /// <summary>
        /// Returns bool4.xyww swizzling.
        /// </summary>
        public bool4 xyww => new bool4(x, y, w, w);

        /// <summary>
        /// Returns bool4.rgaa swizzling (equivalent to bool4.xyww).
        /// </summary>
        public bool4 rgaa => new bool4(x, y, w, w);

        /// <summary>
        /// Returns bool4.xz swizzling.
        /// </summary>
        public bool2 xz => new bool2(x, z);

        /// <summary>
        /// Returns bool4.rb swizzling (equivalent to bool4.xz).
        /// </summary>
        public bool2 rb => new bool2(x, z);

        /// <summary>
        /// Returns bool4.xzx swizzling.
        /// </summary>
        public bool3 xzx => new bool3(x, z, x);

        /// <summary>
        /// Returns bool4.rbr swizzling (equivalent to bool4.xzx).
        /// </summary>
        public bool3 rbr => new bool3(x, z, x);

        /// <summary>
        /// Returns bool4.xzxx swizzling.
        /// </summary>
        public bool4 xzxx => new bool4(x, z, x, x);

        /// <summary>
        /// Returns bool4.rbrr swizzling (equivalent to bool4.xzxx).
        /// </summary>
        public bool4 rbrr => new bool4(x, z, x, x);

        /// <summary>
        /// Returns bool4.xzxy swizzling.
        /// </summary>
        public bool4 xzxy => new bool4(x, z, x, y);

        /// <summary>
        /// Returns bool4.rbrg swizzling (equivalent to bool4.xzxy).
        /// </summary>
        public bool4 rbrg => new bool4(x, z, x, y);

        /// <summary>
        /// Returns bool4.xzxz swizzling.
        /// </summary>
        public bool4 xzxz => new bool4(x, z, x, z);

        /// <summary>
        /// Returns bool4.rbrb swizzling (equivalent to bool4.xzxz).
        /// </summary>
        public bool4 rbrb => new bool4(x, z, x, z);

        /// <summary>
        /// Returns bool4.xzxw swizzling.
        /// </summary>
        public bool4 xzxw => new bool4(x, z, x, w);

        /// <summary>
        /// Returns bool4.rbra swizzling (equivalent to bool4.xzxw).
        /// </summary>
        public bool4 rbra => new bool4(x, z, x, w);

        /// <summary>
        /// Returns bool4.xzy swizzling.
        /// </summary>
        public bool3 xzy => new bool3(x, z, y);

        /// <summary>
        /// Returns bool4.rbg swizzling (equivalent to bool4.xzy).
        /// </summary>
        public bool3 rbg => new bool3(x, z, y);

        /// <summary>
        /// Returns bool4.xzyx swizzling.
        /// </summary>
        public bool4 xzyx => new bool4(x, z, y, x);

        /// <summary>
        /// Returns bool4.rbgr swizzling (equivalent to bool4.xzyx).
        /// </summary>
        public bool4 rbgr => new bool4(x, z, y, x);

        /// <summary>
        /// Returns bool4.xzyy swizzling.
        /// </summary>
        public bool4 xzyy => new bool4(x, z, y, y);

        /// <summary>
        /// Returns bool4.rbgg swizzling (equivalent to bool4.xzyy).
        /// </summary>
        public bool4 rbgg => new bool4(x, z, y, y);

        /// <summary>
        /// Returns bool4.xzyz swizzling.
        /// </summary>
        public bool4 xzyz => new bool4(x, z, y, z);

        /// <summary>
        /// Returns bool4.rbgb swizzling (equivalent to bool4.xzyz).
        /// </summary>
        public bool4 rbgb => new bool4(x, z, y, z);

        /// <summary>
        /// Returns bool4.xzyw swizzling.
        /// </summary>
        public bool4 xzyw => new bool4(x, z, y, w);

        /// <summary>
        /// Returns bool4.rbga swizzling (equivalent to bool4.xzyw).
        /// </summary>
        public bool4 rbga => new bool4(x, z, y, w);

        /// <summary>
        /// Returns bool4.xzz swizzling.
        /// </summary>
        public bool3 xzz => new bool3(x, z, z);

        /// <summary>
        /// Returns bool4.rbb swizzling (equivalent to bool4.xzz).
        /// </summary>
        public bool3 rbb => new bool3(x, z, z);

        /// <summary>
        /// Returns bool4.xzzx swizzling.
        /// </summary>
        public bool4 xzzx => new bool4(x, z, z, x);

        /// <summary>
        /// Returns bool4.rbbr swizzling (equivalent to bool4.xzzx).
        /// </summary>
        public bool4 rbbr => new bool4(x, z, z, x);

        /// <summary>
        /// Returns bool4.xzzy swizzling.
        /// </summary>
        public bool4 xzzy => new bool4(x, z, z, y);

        /// <summary>
        /// Returns bool4.rbbg swizzling (equivalent to bool4.xzzy).
        /// </summary>
        public bool4 rbbg => new bool4(x, z, z, y);

        /// <summary>
        /// Returns bool4.xzzz swizzling.
        /// </summary>
        public bool4 xzzz => new bool4(x, z, z, z);

        /// <summary>
        /// Returns bool4.rbbb swizzling (equivalent to bool4.xzzz).
        /// </summary>
        public bool4 rbbb => new bool4(x, z, z, z);

        /// <summary>
        /// Returns bool4.xzzw swizzling.
        /// </summary>
        public bool4 xzzw => new bool4(x, z, z, w);

        /// <summary>
        /// Returns bool4.rbba swizzling (equivalent to bool4.xzzw).
        /// </summary>
        public bool4 rbba => new bool4(x, z, z, w);

        /// <summary>
        /// Returns bool4.xzw swizzling.
        /// </summary>
        public bool3 xzw => new bool3(x, z, w);

        /// <summary>
        /// Returns bool4.rba swizzling (equivalent to bool4.xzw).
        /// </summary>
        public bool3 rba => new bool3(x, z, w);

        /// <summary>
        /// Returns bool4.xzwx swizzling.
        /// </summary>
        public bool4 xzwx => new bool4(x, z, w, x);

        /// <summary>
        /// Returns bool4.rbar swizzling (equivalent to bool4.xzwx).
        /// </summary>
        public bool4 rbar => new bool4(x, z, w, x);

        /// <summary>
        /// Returns bool4.xzwy swizzling.
        /// </summary>
        public bool4 xzwy => new bool4(x, z, w, y);

        /// <summary>
        /// Returns bool4.rbag swizzling (equivalent to bool4.xzwy).
        /// </summary>
        public bool4 rbag => new bool4(x, z, w, y);

        /// <summary>
        /// Returns bool4.xzwz swizzling.
        /// </summary>
        public bool4 xzwz => new bool4(x, z, w, z);

        /// <summary>
        /// Returns bool4.rbab swizzling (equivalent to bool4.xzwz).
        /// </summary>
        public bool4 rbab => new bool4(x, z, w, z);

        /// <summary>
        /// Returns bool4.xzww swizzling.
        /// </summary>
        public bool4 xzww => new bool4(x, z, w, w);

        /// <summary>
        /// Returns bool4.rbaa swizzling (equivalent to bool4.xzww).
        /// </summary>
        public bool4 rbaa => new bool4(x, z, w, w);

        /// <summary>
        /// Returns bool4.xw swizzling.
        /// </summary>
        public bool2 xw => new bool2(x, w);

        /// <summary>
        /// Returns bool4.ra swizzling (equivalent to bool4.xw).
        /// </summary>
        public bool2 ra => new bool2(x, w);

        /// <summary>
        /// Returns bool4.xwx swizzling.
        /// </summary>
        public bool3 xwx => new bool3(x, w, x);

        /// <summary>
        /// Returns bool4.rar swizzling (equivalent to bool4.xwx).
        /// </summary>
        public bool3 rar => new bool3(x, w, x);

        /// <summary>
        /// Returns bool4.xwxx swizzling.
        /// </summary>
        public bool4 xwxx => new bool4(x, w, x, x);

        /// <summary>
        /// Returns bool4.rarr swizzling (equivalent to bool4.xwxx).
        /// </summary>
        public bool4 rarr => new bool4(x, w, x, x);

        /// <summary>
        /// Returns bool4.xwxy swizzling.
        /// </summary>
        public bool4 xwxy => new bool4(x, w, x, y);

        /// <summary>
        /// Returns bool4.rarg swizzling (equivalent to bool4.xwxy).
        /// </summary>
        public bool4 rarg => new bool4(x, w, x, y);

        /// <summary>
        /// Returns bool4.xwxz swizzling.
        /// </summary>
        public bool4 xwxz => new bool4(x, w, x, z);

        /// <summary>
        /// Returns bool4.rarb swizzling (equivalent to bool4.xwxz).
        /// </summary>
        public bool4 rarb => new bool4(x, w, x, z);

        /// <summary>
        /// Returns bool4.xwxw swizzling.
        /// </summary>
        public bool4 xwxw => new bool4(x, w, x, w);

        /// <summary>
        /// Returns bool4.rara swizzling (equivalent to bool4.xwxw).
        /// </summary>
        public bool4 rara => new bool4(x, w, x, w);

        /// <summary>
        /// Returns bool4.xwy swizzling.
        /// </summary>
        public bool3 xwy => new bool3(x, w, y);

        /// <summary>
        /// Returns bool4.rag swizzling (equivalent to bool4.xwy).
        /// </summary>
        public bool3 rag => new bool3(x, w, y);

        /// <summary>
        /// Returns bool4.xwyx swizzling.
        /// </summary>
        public bool4 xwyx => new bool4(x, w, y, x);

        /// <summary>
        /// Returns bool4.ragr swizzling (equivalent to bool4.xwyx).
        /// </summary>
        public bool4 ragr => new bool4(x, w, y, x);

        /// <summary>
        /// Returns bool4.xwyy swizzling.
        /// </summary>
        public bool4 xwyy => new bool4(x, w, y, y);

        /// <summary>
        /// Returns bool4.ragg swizzling (equivalent to bool4.xwyy).
        /// </summary>
        public bool4 ragg => new bool4(x, w, y, y);

        /// <summary>
        /// Returns bool4.xwyz swizzling.
        /// </summary>
        public bool4 xwyz => new bool4(x, w, y, z);

        /// <summary>
        /// Returns bool4.ragb swizzling (equivalent to bool4.xwyz).
        /// </summary>
        public bool4 ragb => new bool4(x, w, y, z);

        /// <summary>
        /// Returns bool4.xwyw swizzling.
        /// </summary>
        public bool4 xwyw => new bool4(x, w, y, w);

        /// <summary>
        /// Returns bool4.raga swizzling (equivalent to bool4.xwyw).
        /// </summary>
        public bool4 raga => new bool4(x, w, y, w);

        /// <summary>
        /// Returns bool4.xwz swizzling.
        /// </summary>
        public bool3 xwz => new bool3(x, w, z);

        /// <summary>
        /// Returns bool4.rab swizzling (equivalent to bool4.xwz).
        /// </summary>
        public bool3 rab => new bool3(x, w, z);

        /// <summary>
        /// Returns bool4.xwzx swizzling.
        /// </summary>
        public bool4 xwzx => new bool4(x, w, z, x);

        /// <summary>
        /// Returns bool4.rabr swizzling (equivalent to bool4.xwzx).
        /// </summary>
        public bool4 rabr => new bool4(x, w, z, x);

        /// <summary>
        /// Returns bool4.xwzy swizzling.
        /// </summary>
        public bool4 xwzy => new bool4(x, w, z, y);

        /// <summary>
        /// Returns bool4.rabg swizzling (equivalent to bool4.xwzy).
        /// </summary>
        public bool4 rabg => new bool4(x, w, z, y);

        /// <summary>
        /// Returns bool4.xwzz swizzling.
        /// </summary>
        public bool4 xwzz => new bool4(x, w, z, z);

        /// <summary>
        /// Returns bool4.rabb swizzling (equivalent to bool4.xwzz).
        /// </summary>
        public bool4 rabb => new bool4(x, w, z, z);

        /// <summary>
        /// Returns bool4.xwzw swizzling.
        /// </summary>
        public bool4 xwzw => new bool4(x, w, z, w);

        /// <summary>
        /// Returns bool4.raba swizzling (equivalent to bool4.xwzw).
        /// </summary>
        public bool4 raba => new bool4(x, w, z, w);

        /// <summary>
        /// Returns bool4.xww swizzling.
        /// </summary>
        public bool3 xww => new bool3(x, w, w);

        /// <summary>
        /// Returns bool4.raa swizzling (equivalent to bool4.xww).
        /// </summary>
        public bool3 raa => new bool3(x, w, w);

        /// <summary>
        /// Returns bool4.xwwx swizzling.
        /// </summary>
        public bool4 xwwx => new bool4(x, w, w, x);

        /// <summary>
        /// Returns bool4.raar swizzling (equivalent to bool4.xwwx).
        /// </summary>
        public bool4 raar => new bool4(x, w, w, x);

        /// <summary>
        /// Returns bool4.xwwy swizzling.
        /// </summary>
        public bool4 xwwy => new bool4(x, w, w, y);

        /// <summary>
        /// Returns bool4.raag swizzling (equivalent to bool4.xwwy).
        /// </summary>
        public bool4 raag => new bool4(x, w, w, y);

        /// <summary>
        /// Returns bool4.xwwz swizzling.
        /// </summary>
        public bool4 xwwz => new bool4(x, w, w, z);

        /// <summary>
        /// Returns bool4.raab swizzling (equivalent to bool4.xwwz).
        /// </summary>
        public bool4 raab => new bool4(x, w, w, z);

        /// <summary>
        /// Returns bool4.xwww swizzling.
        /// </summary>
        public bool4 xwww => new bool4(x, w, w, w);

        /// <summary>
        /// Returns bool4.raaa swizzling (equivalent to bool4.xwww).
        /// </summary>
        public bool4 raaa => new bool4(x, w, w, w);

        /// <summary>
        /// Returns bool4.yx swizzling.
        /// </summary>
        public bool2 yx => new bool2(y, x);

        /// <summary>
        /// Returns bool4.gr swizzling (equivalent to bool4.yx).
        /// </summary>
        public bool2 gr => new bool2(y, x);

        /// <summary>
        /// Returns bool4.yxx swizzling.
        /// </summary>
        public bool3 yxx => new bool3(y, x, x);

        /// <summary>
        /// Returns bool4.grr swizzling (equivalent to bool4.yxx).
        /// </summary>
        public bool3 grr => new bool3(y, x, x);

        /// <summary>
        /// Returns bool4.yxxx swizzling.
        /// </summary>
        public bool4 yxxx => new bool4(y, x, x, x);

        /// <summary>
        /// Returns bool4.grrr swizzling (equivalent to bool4.yxxx).
        /// </summary>
        public bool4 grrr => new bool4(y, x, x, x);

        /// <summary>
        /// Returns bool4.yxxy swizzling.
        /// </summary>
        public bool4 yxxy => new bool4(y, x, x, y);

        /// <summary>
        /// Returns bool4.grrg swizzling (equivalent to bool4.yxxy).
        /// </summary>
        public bool4 grrg => new bool4(y, x, x, y);

        /// <summary>
        /// Returns bool4.yxxz swizzling.
        /// </summary>
        public bool4 yxxz => new bool4(y, x, x, z);

        /// <summary>
        /// Returns bool4.grrb swizzling (equivalent to bool4.yxxz).
        /// </summary>
        public bool4 grrb => new bool4(y, x, x, z);

        /// <summary>
        /// Returns bool4.yxxw swizzling.
        /// </summary>
        public bool4 yxxw => new bool4(y, x, x, w);

        /// <summary>
        /// Returns bool4.grra swizzling (equivalent to bool4.yxxw).
        /// </summary>
        public bool4 grra => new bool4(y, x, x, w);

        /// <summary>
        /// Returns bool4.yxy swizzling.
        /// </summary>
        public bool3 yxy => new bool3(y, x, y);

        /// <summary>
        /// Returns bool4.grg swizzling (equivalent to bool4.yxy).
        /// </summary>
        public bool3 grg => new bool3(y, x, y);

        /// <summary>
        /// Returns bool4.yxyx swizzling.
        /// </summary>
        public bool4 yxyx => new bool4(y, x, y, x);

        /// <summary>
        /// Returns bool4.grgr swizzling (equivalent to bool4.yxyx).
        /// </summary>
        public bool4 grgr => new bool4(y, x, y, x);

        /// <summary>
        /// Returns bool4.yxyy swizzling.
        /// </summary>
        public bool4 yxyy => new bool4(y, x, y, y);

        /// <summary>
        /// Returns bool4.grgg swizzling (equivalent to bool4.yxyy).
        /// </summary>
        public bool4 grgg => new bool4(y, x, y, y);

        /// <summary>
        /// Returns bool4.yxyz swizzling.
        /// </summary>
        public bool4 yxyz => new bool4(y, x, y, z);

        /// <summary>
        /// Returns bool4.grgb swizzling (equivalent to bool4.yxyz).
        /// </summary>
        public bool4 grgb => new bool4(y, x, y, z);

        /// <summary>
        /// Returns bool4.yxyw swizzling.
        /// </summary>
        public bool4 yxyw => new bool4(y, x, y, w);

        /// <summary>
        /// Returns bool4.grga swizzling (equivalent to bool4.yxyw).
        /// </summary>
        public bool4 grga => new bool4(y, x, y, w);

        /// <summary>
        /// Returns bool4.yxz swizzling.
        /// </summary>
        public bool3 yxz => new bool3(y, x, z);

        /// <summary>
        /// Returns bool4.grb swizzling (equivalent to bool4.yxz).
        /// </summary>
        public bool3 grb => new bool3(y, x, z);

        /// <summary>
        /// Returns bool4.yxzx swizzling.
        /// </summary>
        public bool4 yxzx => new bool4(y, x, z, x);

        /// <summary>
        /// Returns bool4.grbr swizzling (equivalent to bool4.yxzx).
        /// </summary>
        public bool4 grbr => new bool4(y, x, z, x);

        /// <summary>
        /// Returns bool4.yxzy swizzling.
        /// </summary>
        public bool4 yxzy => new bool4(y, x, z, y);

        /// <summary>
        /// Returns bool4.grbg swizzling (equivalent to bool4.yxzy).
        /// </summary>
        public bool4 grbg => new bool4(y, x, z, y);

        /// <summary>
        /// Returns bool4.yxzz swizzling.
        /// </summary>
        public bool4 yxzz => new bool4(y, x, z, z);

        /// <summary>
        /// Returns bool4.grbb swizzling (equivalent to bool4.yxzz).
        /// </summary>
        public bool4 grbb => new bool4(y, x, z, z);

        /// <summary>
        /// Returns bool4.yxzw swizzling.
        /// </summary>
        public bool4 yxzw => new bool4(y, x, z, w);

        /// <summary>
        /// Returns bool4.grba swizzling (equivalent to bool4.yxzw).
        /// </summary>
        public bool4 grba => new bool4(y, x, z, w);

        /// <summary>
        /// Returns bool4.yxw swizzling.
        /// </summary>
        public bool3 yxw => new bool3(y, x, w);

        /// <summary>
        /// Returns bool4.gra swizzling (equivalent to bool4.yxw).
        /// </summary>
        public bool3 gra => new bool3(y, x, w);

        /// <summary>
        /// Returns bool4.yxwx swizzling.
        /// </summary>
        public bool4 yxwx => new bool4(y, x, w, x);

        /// <summary>
        /// Returns bool4.grar swizzling (equivalent to bool4.yxwx).
        /// </summary>
        public bool4 grar => new bool4(y, x, w, x);

        /// <summary>
        /// Returns bool4.yxwy swizzling.
        /// </summary>
        public bool4 yxwy => new bool4(y, x, w, y);

        /// <summary>
        /// Returns bool4.grag swizzling (equivalent to bool4.yxwy).
        /// </summary>
        public bool4 grag => new bool4(y, x, w, y);

        /// <summary>
        /// Returns bool4.yxwz swizzling.
        /// </summary>
        public bool4 yxwz => new bool4(y, x, w, z);

        /// <summary>
        /// Returns bool4.grab swizzling (equivalent to bool4.yxwz).
        /// </summary>
        public bool4 grab => new bool4(y, x, w, z);

        /// <summary>
        /// Returns bool4.yxww swizzling.
        /// </summary>
        public bool4 yxww => new bool4(y, x, w, w);

        /// <summary>
        /// Returns bool4.graa swizzling (equivalent to bool4.yxww).
        /// </summary>
        public bool4 graa => new bool4(y, x, w, w);

        /// <summary>
        /// Returns bool4.yy swizzling.
        /// </summary>
        public bool2 yy => new bool2(y, y);

        /// <summary>
        /// Returns bool4.gg swizzling (equivalent to bool4.yy).
        /// </summary>
        public bool2 gg => new bool2(y, y);

        /// <summary>
        /// Returns bool4.yyx swizzling.
        /// </summary>
        public bool3 yyx => new bool3(y, y, x);

        /// <summary>
        /// Returns bool4.ggr swizzling (equivalent to bool4.yyx).
        /// </summary>
        public bool3 ggr => new bool3(y, y, x);

        /// <summary>
        /// Returns bool4.yyxx swizzling.
        /// </summary>
        public bool4 yyxx => new bool4(y, y, x, x);

        /// <summary>
        /// Returns bool4.ggrr swizzling (equivalent to bool4.yyxx).
        /// </summary>
        public bool4 ggrr => new bool4(y, y, x, x);

        /// <summary>
        /// Returns bool4.yyxy swizzling.
        /// </summary>
        public bool4 yyxy => new bool4(y, y, x, y);

        /// <summary>
        /// Returns bool4.ggrg swizzling (equivalent to bool4.yyxy).
        /// </summary>
        public bool4 ggrg => new bool4(y, y, x, y);

        /// <summary>
        /// Returns bool4.yyxz swizzling.
        /// </summary>
        public bool4 yyxz => new bool4(y, y, x, z);

        /// <summary>
        /// Returns bool4.ggrb swizzling (equivalent to bool4.yyxz).
        /// </summary>
        public bool4 ggrb => new bool4(y, y, x, z);

        /// <summary>
        /// Returns bool4.yyxw swizzling.
        /// </summary>
        public bool4 yyxw => new bool4(y, y, x, w);

        /// <summary>
        /// Returns bool4.ggra swizzling (equivalent to bool4.yyxw).
        /// </summary>
        public bool4 ggra => new bool4(y, y, x, w);

        /// <summary>
        /// Returns bool4.yyy swizzling.
        /// </summary>
        public bool3 yyy => new bool3(y, y, y);

        /// <summary>
        /// Returns bool4.ggg swizzling (equivalent to bool4.yyy).
        /// </summary>
        public bool3 ggg => new bool3(y, y, y);

        /// <summary>
        /// Returns bool4.yyyx swizzling.
        /// </summary>
        public bool4 yyyx => new bool4(y, y, y, x);

        /// <summary>
        /// Returns bool4.gggr swizzling (equivalent to bool4.yyyx).
        /// </summary>
        public bool4 gggr => new bool4(y, y, y, x);

        /// <summary>
        /// Returns bool4.yyyy swizzling.
        /// </summary>
        public bool4 yyyy => new bool4(y, y, y, y);

        /// <summary>
        /// Returns bool4.gggg swizzling (equivalent to bool4.yyyy).
        /// </summary>
        public bool4 gggg => new bool4(y, y, y, y);

        /// <summary>
        /// Returns bool4.yyyz swizzling.
        /// </summary>
        public bool4 yyyz => new bool4(y, y, y, z);

        /// <summary>
        /// Returns bool4.gggb swizzling (equivalent to bool4.yyyz).
        /// </summary>
        public bool4 gggb => new bool4(y, y, y, z);

        /// <summary>
        /// Returns bool4.yyyw swizzling.
        /// </summary>
        public bool4 yyyw => new bool4(y, y, y, w);

        /// <summary>
        /// Returns bool4.ggga swizzling (equivalent to bool4.yyyw).
        /// </summary>
        public bool4 ggga => new bool4(y, y, y, w);

        /// <summary>
        /// Returns bool4.yyz swizzling.
        /// </summary>
        public bool3 yyz => new bool3(y, y, z);

        /// <summary>
        /// Returns bool4.ggb swizzling (equivalent to bool4.yyz).
        /// </summary>
        public bool3 ggb => new bool3(y, y, z);

        /// <summary>
        /// Returns bool4.yyzx swizzling.
        /// </summary>
        public bool4 yyzx => new bool4(y, y, z, x);

        /// <summary>
        /// Returns bool4.ggbr swizzling (equivalent to bool4.yyzx).
        /// </summary>
        public bool4 ggbr => new bool4(y, y, z, x);

        /// <summary>
        /// Returns bool4.yyzy swizzling.
        /// </summary>
        public bool4 yyzy => new bool4(y, y, z, y);

        /// <summary>
        /// Returns bool4.ggbg swizzling (equivalent to bool4.yyzy).
        /// </summary>
        public bool4 ggbg => new bool4(y, y, z, y);

        /// <summary>
        /// Returns bool4.yyzz swizzling.
        /// </summary>
        public bool4 yyzz => new bool4(y, y, z, z);

        /// <summary>
        /// Returns bool4.ggbb swizzling (equivalent to bool4.yyzz).
        /// </summary>
        public bool4 ggbb => new bool4(y, y, z, z);

        /// <summary>
        /// Returns bool4.yyzw swizzling.
        /// </summary>
        public bool4 yyzw => new bool4(y, y, z, w);

        /// <summary>
        /// Returns bool4.ggba swizzling (equivalent to bool4.yyzw).
        /// </summary>
        public bool4 ggba => new bool4(y, y, z, w);

        /// <summary>
        /// Returns bool4.yyw swizzling.
        /// </summary>
        public bool3 yyw => new bool3(y, y, w);

        /// <summary>
        /// Returns bool4.gga swizzling (equivalent to bool4.yyw).
        /// </summary>
        public bool3 gga => new bool3(y, y, w);

        /// <summary>
        /// Returns bool4.yywx swizzling.
        /// </summary>
        public bool4 yywx => new bool4(y, y, w, x);

        /// <summary>
        /// Returns bool4.ggar swizzling (equivalent to bool4.yywx).
        /// </summary>
        public bool4 ggar => new bool4(y, y, w, x);

        /// <summary>
        /// Returns bool4.yywy swizzling.
        /// </summary>
        public bool4 yywy => new bool4(y, y, w, y);

        /// <summary>
        /// Returns bool4.ggag swizzling (equivalent to bool4.yywy).
        /// </summary>
        public bool4 ggag => new bool4(y, y, w, y);

        /// <summary>
        /// Returns bool4.yywz swizzling.
        /// </summary>
        public bool4 yywz => new bool4(y, y, w, z);

        /// <summary>
        /// Returns bool4.ggab swizzling (equivalent to bool4.yywz).
        /// </summary>
        public bool4 ggab => new bool4(y, y, w, z);

        /// <summary>
        /// Returns bool4.yyww swizzling.
        /// </summary>
        public bool4 yyww => new bool4(y, y, w, w);

        /// <summary>
        /// Returns bool4.ggaa swizzling (equivalent to bool4.yyww).
        /// </summary>
        public bool4 ggaa => new bool4(y, y, w, w);

        /// <summary>
        /// Returns bool4.yz swizzling.
        /// </summary>
        public bool2 yz => new bool2(y, z);

        /// <summary>
        /// Returns bool4.gb swizzling (equivalent to bool4.yz).
        /// </summary>
        public bool2 gb => new bool2(y, z);

        /// <summary>
        /// Returns bool4.yzx swizzling.
        /// </summary>
        public bool3 yzx => new bool3(y, z, x);

        /// <summary>
        /// Returns bool4.gbr swizzling (equivalent to bool4.yzx).
        /// </summary>
        public bool3 gbr => new bool3(y, z, x);

        /// <summary>
        /// Returns bool4.yzxx swizzling.
        /// </summary>
        public bool4 yzxx => new bool4(y, z, x, x);

        /// <summary>
        /// Returns bool4.gbrr swizzling (equivalent to bool4.yzxx).
        /// </summary>
        public bool4 gbrr => new bool4(y, z, x, x);

        /// <summary>
        /// Returns bool4.yzxy swizzling.
        /// </summary>
        public bool4 yzxy => new bool4(y, z, x, y);

        /// <summary>
        /// Returns bool4.gbrg swizzling (equivalent to bool4.yzxy).
        /// </summary>
        public bool4 gbrg => new bool4(y, z, x, y);

        /// <summary>
        /// Returns bool4.yzxz swizzling.
        /// </summary>
        public bool4 yzxz => new bool4(y, z, x, z);

        /// <summary>
        /// Returns bool4.gbrb swizzling (equivalent to bool4.yzxz).
        /// </summary>
        public bool4 gbrb => new bool4(y, z, x, z);

        /// <summary>
        /// Returns bool4.yzxw swizzling.
        /// </summary>
        public bool4 yzxw => new bool4(y, z, x, w);

        /// <summary>
        /// Returns bool4.gbra swizzling (equivalent to bool4.yzxw).
        /// </summary>
        public bool4 gbra => new bool4(y, z, x, w);

        /// <summary>
        /// Returns bool4.yzy swizzling.
        /// </summary>
        public bool3 yzy => new bool3(y, z, y);

        /// <summary>
        /// Returns bool4.gbg swizzling (equivalent to bool4.yzy).
        /// </summary>
        public bool3 gbg => new bool3(y, z, y);

        /// <summary>
        /// Returns bool4.yzyx swizzling.
        /// </summary>
        public bool4 yzyx => new bool4(y, z, y, x);

        /// <summary>
        /// Returns bool4.gbgr swizzling (equivalent to bool4.yzyx).
        /// </summary>
        public bool4 gbgr => new bool4(y, z, y, x);

        /// <summary>
        /// Returns bool4.yzyy swizzling.
        /// </summary>
        public bool4 yzyy => new bool4(y, z, y, y);

        /// <summary>
        /// Returns bool4.gbgg swizzling (equivalent to bool4.yzyy).
        /// </summary>
        public bool4 gbgg => new bool4(y, z, y, y);

        /// <summary>
        /// Returns bool4.yzyz swizzling.
        /// </summary>
        public bool4 yzyz => new bool4(y, z, y, z);

        /// <summary>
        /// Returns bool4.gbgb swizzling (equivalent to bool4.yzyz).
        /// </summary>
        public bool4 gbgb => new bool4(y, z, y, z);

        /// <summary>
        /// Returns bool4.yzyw swizzling.
        /// </summary>
        public bool4 yzyw => new bool4(y, z, y, w);

        /// <summary>
        /// Returns bool4.gbga swizzling (equivalent to bool4.yzyw).
        /// </summary>
        public bool4 gbga => new bool4(y, z, y, w);

        /// <summary>
        /// Returns bool4.yzz swizzling.
        /// </summary>
        public bool3 yzz => new bool3(y, z, z);

        /// <summary>
        /// Returns bool4.gbb swizzling (equivalent to bool4.yzz).
        /// </summary>
        public bool3 gbb => new bool3(y, z, z);

        /// <summary>
        /// Returns bool4.yzzx swizzling.
        /// </summary>
        public bool4 yzzx => new bool4(y, z, z, x);

        /// <summary>
        /// Returns bool4.gbbr swizzling (equivalent to bool4.yzzx).
        /// </summary>
        public bool4 gbbr => new bool4(y, z, z, x);

        /// <summary>
        /// Returns bool4.yzzy swizzling.
        /// </summary>
        public bool4 yzzy => new bool4(y, z, z, y);

        /// <summary>
        /// Returns bool4.gbbg swizzling (equivalent to bool4.yzzy).
        /// </summary>
        public bool4 gbbg => new bool4(y, z, z, y);

        /// <summary>
        /// Returns bool4.yzzz swizzling.
        /// </summary>
        public bool4 yzzz => new bool4(y, z, z, z);

        /// <summary>
        /// Returns bool4.gbbb swizzling (equivalent to bool4.yzzz).
        /// </summary>
        public bool4 gbbb => new bool4(y, z, z, z);

        /// <summary>
        /// Returns bool4.yzzw swizzling.
        /// </summary>
        public bool4 yzzw => new bool4(y, z, z, w);

        /// <summary>
        /// Returns bool4.gbba swizzling (equivalent to bool4.yzzw).
        /// </summary>
        public bool4 gbba => new bool4(y, z, z, w);

        /// <summary>
        /// Returns bool4.yzw swizzling.
        /// </summary>
        public bool3 yzw => new bool3(y, z, w);

        /// <summary>
        /// Returns bool4.gba swizzling (equivalent to bool4.yzw).
        /// </summary>
        public bool3 gba => new bool3(y, z, w);

        /// <summary>
        /// Returns bool4.yzwx swizzling.
        /// </summary>
        public bool4 yzwx => new bool4(y, z, w, x);

        /// <summary>
        /// Returns bool4.gbar swizzling (equivalent to bool4.yzwx).
        /// </summary>
        public bool4 gbar => new bool4(y, z, w, x);

        /// <summary>
        /// Returns bool4.yzwy swizzling.
        /// </summary>
        public bool4 yzwy => new bool4(y, z, w, y);

        /// <summary>
        /// Returns bool4.gbag swizzling (equivalent to bool4.yzwy).
        /// </summary>
        public bool4 gbag => new bool4(y, z, w, y);

        /// <summary>
        /// Returns bool4.yzwz swizzling.
        /// </summary>
        public bool4 yzwz => new bool4(y, z, w, z);

        /// <summary>
        /// Returns bool4.gbab swizzling (equivalent to bool4.yzwz).
        /// </summary>
        public bool4 gbab => new bool4(y, z, w, z);

        /// <summary>
        /// Returns bool4.yzww swizzling.
        /// </summary>
        public bool4 yzww => new bool4(y, z, w, w);

        /// <summary>
        /// Returns bool4.gbaa swizzling (equivalent to bool4.yzww).
        /// </summary>
        public bool4 gbaa => new bool4(y, z, w, w);

        /// <summary>
        /// Returns bool4.yw swizzling.
        /// </summary>
        public bool2 yw => new bool2(y, w);

        /// <summary>
        /// Returns bool4.ga swizzling (equivalent to bool4.yw).
        /// </summary>
        public bool2 ga => new bool2(y, w);

        /// <summary>
        /// Returns bool4.ywx swizzling.
        /// </summary>
        public bool3 ywx => new bool3(y, w, x);

        /// <summary>
        /// Returns bool4.gar swizzling (equivalent to bool4.ywx).
        /// </summary>
        public bool3 gar => new bool3(y, w, x);

        /// <summary>
        /// Returns bool4.ywxx swizzling.
        /// </summary>
        public bool4 ywxx => new bool4(y, w, x, x);

        /// <summary>
        /// Returns bool4.garr swizzling (equivalent to bool4.ywxx).
        /// </summary>
        public bool4 garr => new bool4(y, w, x, x);

        /// <summary>
        /// Returns bool4.ywxy swizzling.
        /// </summary>
        public bool4 ywxy => new bool4(y, w, x, y);

        /// <summary>
        /// Returns bool4.garg swizzling (equivalent to bool4.ywxy).
        /// </summary>
        public bool4 garg => new bool4(y, w, x, y);

        /// <summary>
        /// Returns bool4.ywxz swizzling.
        /// </summary>
        public bool4 ywxz => new bool4(y, w, x, z);

        /// <summary>
        /// Returns bool4.garb swizzling (equivalent to bool4.ywxz).
        /// </summary>
        public bool4 garb => new bool4(y, w, x, z);

        /// <summary>
        /// Returns bool4.ywxw swizzling.
        /// </summary>
        public bool4 ywxw => new bool4(y, w, x, w);

        /// <summary>
        /// Returns bool4.gara swizzling (equivalent to bool4.ywxw).
        /// </summary>
        public bool4 gara => new bool4(y, w, x, w);

        /// <summary>
        /// Returns bool4.ywy swizzling.
        /// </summary>
        public bool3 ywy => new bool3(y, w, y);

        /// <summary>
        /// Returns bool4.gag swizzling (equivalent to bool4.ywy).
        /// </summary>
        public bool3 gag => new bool3(y, w, y);

        /// <summary>
        /// Returns bool4.ywyx swizzling.
        /// </summary>
        public bool4 ywyx => new bool4(y, w, y, x);

        /// <summary>
        /// Returns bool4.gagr swizzling (equivalent to bool4.ywyx).
        /// </summary>
        public bool4 gagr => new bool4(y, w, y, x);

        /// <summary>
        /// Returns bool4.ywyy swizzling.
        /// </summary>
        public bool4 ywyy => new bool4(y, w, y, y);

        /// <summary>
        /// Returns bool4.gagg swizzling (equivalent to bool4.ywyy).
        /// </summary>
        public bool4 gagg => new bool4(y, w, y, y);

        /// <summary>
        /// Returns bool4.ywyz swizzling.
        /// </summary>
        public bool4 ywyz => new bool4(y, w, y, z);

        /// <summary>
        /// Returns bool4.gagb swizzling (equivalent to bool4.ywyz).
        /// </summary>
        public bool4 gagb => new bool4(y, w, y, z);

        /// <summary>
        /// Returns bool4.ywyw swizzling.
        /// </summary>
        public bool4 ywyw => new bool4(y, w, y, w);

        /// <summary>
        /// Returns bool4.gaga swizzling (equivalent to bool4.ywyw).
        /// </summary>
        public bool4 gaga => new bool4(y, w, y, w);

        /// <summary>
        /// Returns bool4.ywz swizzling.
        /// </summary>
        public bool3 ywz => new bool3(y, w, z);

        /// <summary>
        /// Returns bool4.gab swizzling (equivalent to bool4.ywz).
        /// </summary>
        public bool3 gab => new bool3(y, w, z);

        /// <summary>
        /// Returns bool4.ywzx swizzling.
        /// </summary>
        public bool4 ywzx => new bool4(y, w, z, x);

        /// <summary>
        /// Returns bool4.gabr swizzling (equivalent to bool4.ywzx).
        /// </summary>
        public bool4 gabr => new bool4(y, w, z, x);

        /// <summary>
        /// Returns bool4.ywzy swizzling.
        /// </summary>
        public bool4 ywzy => new bool4(y, w, z, y);

        /// <summary>
        /// Returns bool4.gabg swizzling (equivalent to bool4.ywzy).
        /// </summary>
        public bool4 gabg => new bool4(y, w, z, y);

        /// <summary>
        /// Returns bool4.ywzz swizzling.
        /// </summary>
        public bool4 ywzz => new bool4(y, w, z, z);

        /// <summary>
        /// Returns bool4.gabb swizzling (equivalent to bool4.ywzz).
        /// </summary>
        public bool4 gabb => new bool4(y, w, z, z);

        /// <summary>
        /// Returns bool4.ywzw swizzling.
        /// </summary>
        public bool4 ywzw => new bool4(y, w, z, w);

        /// <summary>
        /// Returns bool4.gaba swizzling (equivalent to bool4.ywzw).
        /// </summary>
        public bool4 gaba => new bool4(y, w, z, w);

        /// <summary>
        /// Returns bool4.yww swizzling.
        /// </summary>
        public bool3 yww => new bool3(y, w, w);

        /// <summary>
        /// Returns bool4.gaa swizzling (equivalent to bool4.yww).
        /// </summary>
        public bool3 gaa => new bool3(y, w, w);

        /// <summary>
        /// Returns bool4.ywwx swizzling.
        /// </summary>
        public bool4 ywwx => new bool4(y, w, w, x);

        /// <summary>
        /// Returns bool4.gaar swizzling (equivalent to bool4.ywwx).
        /// </summary>
        public bool4 gaar => new bool4(y, w, w, x);

        /// <summary>
        /// Returns bool4.ywwy swizzling.
        /// </summary>
        public bool4 ywwy => new bool4(y, w, w, y);

        /// <summary>
        /// Returns bool4.gaag swizzling (equivalent to bool4.ywwy).
        /// </summary>
        public bool4 gaag => new bool4(y, w, w, y);

        /// <summary>
        /// Returns bool4.ywwz swizzling.
        /// </summary>
        public bool4 ywwz => new bool4(y, w, w, z);

        /// <summary>
        /// Returns bool4.gaab swizzling (equivalent to bool4.ywwz).
        /// </summary>
        public bool4 gaab => new bool4(y, w, w, z);

        /// <summary>
        /// Returns bool4.ywww swizzling.
        /// </summary>
        public bool4 ywww => new bool4(y, w, w, w);

        /// <summary>
        /// Returns bool4.gaaa swizzling (equivalent to bool4.ywww).
        /// </summary>
        public bool4 gaaa => new bool4(y, w, w, w);

        /// <summary>
        /// Returns bool4.zx swizzling.
        /// </summary>
        public bool2 zx => new bool2(z, x);

        /// <summary>
        /// Returns bool4.br swizzling (equivalent to bool4.zx).
        /// </summary>
        public bool2 br => new bool2(z, x);

        /// <summary>
        /// Returns bool4.zxx swizzling.
        /// </summary>
        public bool3 zxx => new bool3(z, x, x);

        /// <summary>
        /// Returns bool4.brr swizzling (equivalent to bool4.zxx).
        /// </summary>
        public bool3 brr => new bool3(z, x, x);

        /// <summary>
        /// Returns bool4.zxxx swizzling.
        /// </summary>
        public bool4 zxxx => new bool4(z, x, x, x);

        /// <summary>
        /// Returns bool4.brrr swizzling (equivalent to bool4.zxxx).
        /// </summary>
        public bool4 brrr => new bool4(z, x, x, x);

        /// <summary>
        /// Returns bool4.zxxy swizzling.
        /// </summary>
        public bool4 zxxy => new bool4(z, x, x, y);

        /// <summary>
        /// Returns bool4.brrg swizzling (equivalent to bool4.zxxy).
        /// </summary>
        public bool4 brrg => new bool4(z, x, x, y);

        /// <summary>
        /// Returns bool4.zxxz swizzling.
        /// </summary>
        public bool4 zxxz => new bool4(z, x, x, z);

        /// <summary>
        /// Returns bool4.brrb swizzling (equivalent to bool4.zxxz).
        /// </summary>
        public bool4 brrb => new bool4(z, x, x, z);

        /// <summary>
        /// Returns bool4.zxxw swizzling.
        /// </summary>
        public bool4 zxxw => new bool4(z, x, x, w);

        /// <summary>
        /// Returns bool4.brra swizzling (equivalent to bool4.zxxw).
        /// </summary>
        public bool4 brra => new bool4(z, x, x, w);

        /// <summary>
        /// Returns bool4.zxy swizzling.
        /// </summary>
        public bool3 zxy => new bool3(z, x, y);

        /// <summary>
        /// Returns bool4.brg swizzling (equivalent to bool4.zxy).
        /// </summary>
        public bool3 brg => new bool3(z, x, y);

        /// <summary>
        /// Returns bool4.zxyx swizzling.
        /// </summary>
        public bool4 zxyx => new bool4(z, x, y, x);

        /// <summary>
        /// Returns bool4.brgr swizzling (equivalent to bool4.zxyx).
        /// </summary>
        public bool4 brgr => new bool4(z, x, y, x);

        /// <summary>
        /// Returns bool4.zxyy swizzling.
        /// </summary>
        public bool4 zxyy => new bool4(z, x, y, y);

        /// <summary>
        /// Returns bool4.brgg swizzling (equivalent to bool4.zxyy).
        /// </summary>
        public bool4 brgg => new bool4(z, x, y, y);

        /// <summary>
        /// Returns bool4.zxyz swizzling.
        /// </summary>
        public bool4 zxyz => new bool4(z, x, y, z);

        /// <summary>
        /// Returns bool4.brgb swizzling (equivalent to bool4.zxyz).
        /// </summary>
        public bool4 brgb => new bool4(z, x, y, z);

        /// <summary>
        /// Returns bool4.zxyw swizzling.
        /// </summary>
        public bool4 zxyw => new bool4(z, x, y, w);

        /// <summary>
        /// Returns bool4.brga swizzling (equivalent to bool4.zxyw).
        /// </summary>
        public bool4 brga => new bool4(z, x, y, w);

        /// <summary>
        /// Returns bool4.zxz swizzling.
        /// </summary>
        public bool3 zxz => new bool3(z, x, z);

        /// <summary>
        /// Returns bool4.brb swizzling (equivalent to bool4.zxz).
        /// </summary>
        public bool3 brb => new bool3(z, x, z);

        /// <summary>
        /// Returns bool4.zxzx swizzling.
        /// </summary>
        public bool4 zxzx => new bool4(z, x, z, x);

        /// <summary>
        /// Returns bool4.brbr swizzling (equivalent to bool4.zxzx).
        /// </summary>
        public bool4 brbr => new bool4(z, x, z, x);

        /// <summary>
        /// Returns bool4.zxzy swizzling.
        /// </summary>
        public bool4 zxzy => new bool4(z, x, z, y);

        /// <summary>
        /// Returns bool4.brbg swizzling (equivalent to bool4.zxzy).
        /// </summary>
        public bool4 brbg => new bool4(z, x, z, y);

        /// <summary>
        /// Returns bool4.zxzz swizzling.
        /// </summary>
        public bool4 zxzz => new bool4(z, x, z, z);

        /// <summary>
        /// Returns bool4.brbb swizzling (equivalent to bool4.zxzz).
        /// </summary>
        public bool4 brbb => new bool4(z, x, z, z);

        /// <summary>
        /// Returns bool4.zxzw swizzling.
        /// </summary>
        public bool4 zxzw => new bool4(z, x, z, w);

        /// <summary>
        /// Returns bool4.brba swizzling (equivalent to bool4.zxzw).
        /// </summary>
        public bool4 brba => new bool4(z, x, z, w);

        /// <summary>
        /// Returns bool4.zxw swizzling.
        /// </summary>
        public bool3 zxw => new bool3(z, x, w);

        /// <summary>
        /// Returns bool4.bra swizzling (equivalent to bool4.zxw).
        /// </summary>
        public bool3 bra => new bool3(z, x, w);

        /// <summary>
        /// Returns bool4.zxwx swizzling.
        /// </summary>
        public bool4 zxwx => new bool4(z, x, w, x);

        /// <summary>
        /// Returns bool4.brar swizzling (equivalent to bool4.zxwx).
        /// </summary>
        public bool4 brar => new bool4(z, x, w, x);

        /// <summary>
        /// Returns bool4.zxwy swizzling.
        /// </summary>
        public bool4 zxwy => new bool4(z, x, w, y);

        /// <summary>
        /// Returns bool4.brag swizzling (equivalent to bool4.zxwy).
        /// </summary>
        public bool4 brag => new bool4(z, x, w, y);

        /// <summary>
        /// Returns bool4.zxwz swizzling.
        /// </summary>
        public bool4 zxwz => new bool4(z, x, w, z);

        /// <summary>
        /// Returns bool4.brab swizzling (equivalent to bool4.zxwz).
        /// </summary>
        public bool4 brab => new bool4(z, x, w, z);

        /// <summary>
        /// Returns bool4.zxww swizzling.
        /// </summary>
        public bool4 zxww => new bool4(z, x, w, w);

        /// <summary>
        /// Returns bool4.braa swizzling (equivalent to bool4.zxww).
        /// </summary>
        public bool4 braa => new bool4(z, x, w, w);

        /// <summary>
        /// Returns bool4.zy swizzling.
        /// </summary>
        public bool2 zy => new bool2(z, y);

        /// <summary>
        /// Returns bool4.bg swizzling (equivalent to bool4.zy).
        /// </summary>
        public bool2 bg => new bool2(z, y);

        /// <summary>
        /// Returns bool4.zyx swizzling.
        /// </summary>
        public bool3 zyx => new bool3(z, y, x);

        /// <summary>
        /// Returns bool4.bgr swizzling (equivalent to bool4.zyx).
        /// </summary>
        public bool3 bgr => new bool3(z, y, x);

        /// <summary>
        /// Returns bool4.zyxx swizzling.
        /// </summary>
        public bool4 zyxx => new bool4(z, y, x, x);

        /// <summary>
        /// Returns bool4.bgrr swizzling (equivalent to bool4.zyxx).
        /// </summary>
        public bool4 bgrr => new bool4(z, y, x, x);

        /// <summary>
        /// Returns bool4.zyxy swizzling.
        /// </summary>
        public bool4 zyxy => new bool4(z, y, x, y);

        /// <summary>
        /// Returns bool4.bgrg swizzling (equivalent to bool4.zyxy).
        /// </summary>
        public bool4 bgrg => new bool4(z, y, x, y);

        /// <summary>
        /// Returns bool4.zyxz swizzling.
        /// </summary>
        public bool4 zyxz => new bool4(z, y, x, z);

        /// <summary>
        /// Returns bool4.bgrb swizzling (equivalent to bool4.zyxz).
        /// </summary>
        public bool4 bgrb => new bool4(z, y, x, z);

        /// <summary>
        /// Returns bool4.zyxw swizzling.
        /// </summary>
        public bool4 zyxw => new bool4(z, y, x, w);

        /// <summary>
        /// Returns bool4.bgra swizzling (equivalent to bool4.zyxw).
        /// </summary>
        public bool4 bgra => new bool4(z, y, x, w);

        /// <summary>
        /// Returns bool4.zyy swizzling.
        /// </summary>
        public bool3 zyy => new bool3(z, y, y);

        /// <summary>
        /// Returns bool4.bgg swizzling (equivalent to bool4.zyy).
        /// </summary>
        public bool3 bgg => new bool3(z, y, y);

        /// <summary>
        /// Returns bool4.zyyx swizzling.
        /// </summary>
        public bool4 zyyx => new bool4(z, y, y, x);

        /// <summary>
        /// Returns bool4.bggr swizzling (equivalent to bool4.zyyx).
        /// </summary>
        public bool4 bggr => new bool4(z, y, y, x);

        /// <summary>
        /// Returns bool4.zyyy swizzling.
        /// </summary>
        public bool4 zyyy => new bool4(z, y, y, y);

        /// <summary>
        /// Returns bool4.bggg swizzling (equivalent to bool4.zyyy).
        /// </summary>
        public bool4 bggg => new bool4(z, y, y, y);

        /// <summary>
        /// Returns bool4.zyyz swizzling.
        /// </summary>
        public bool4 zyyz => new bool4(z, y, y, z);

        /// <summary>
        /// Returns bool4.bggb swizzling (equivalent to bool4.zyyz).
        /// </summary>
        public bool4 bggb => new bool4(z, y, y, z);

        /// <summary>
        /// Returns bool4.zyyw swizzling.
        /// </summary>
        public bool4 zyyw => new bool4(z, y, y, w);

        /// <summary>
        /// Returns bool4.bgga swizzling (equivalent to bool4.zyyw).
        /// </summary>
        public bool4 bgga => new bool4(z, y, y, w);

        /// <summary>
        /// Returns bool4.zyz swizzling.
        /// </summary>
        public bool3 zyz => new bool3(z, y, z);

        /// <summary>
        /// Returns bool4.bgb swizzling (equivalent to bool4.zyz).
        /// </summary>
        public bool3 bgb => new bool3(z, y, z);

        /// <summary>
        /// Returns bool4.zyzx swizzling.
        /// </summary>
        public bool4 zyzx => new bool4(z, y, z, x);

        /// <summary>
        /// Returns bool4.bgbr swizzling (equivalent to bool4.zyzx).
        /// </summary>
        public bool4 bgbr => new bool4(z, y, z, x);

        /// <summary>
        /// Returns bool4.zyzy swizzling.
        /// </summary>
        public bool4 zyzy => new bool4(z, y, z, y);

        /// <summary>
        /// Returns bool4.bgbg swizzling (equivalent to bool4.zyzy).
        /// </summary>
        public bool4 bgbg => new bool4(z, y, z, y);

        /// <summary>
        /// Returns bool4.zyzz swizzling.
        /// </summary>
        public bool4 zyzz => new bool4(z, y, z, z);

        /// <summary>
        /// Returns bool4.bgbb swizzling (equivalent to bool4.zyzz).
        /// </summary>
        public bool4 bgbb => new bool4(z, y, z, z);

        /// <summary>
        /// Returns bool4.zyzw swizzling.
        /// </summary>
        public bool4 zyzw => new bool4(z, y, z, w);

        /// <summary>
        /// Returns bool4.bgba swizzling (equivalent to bool4.zyzw).
        /// </summary>
        public bool4 bgba => new bool4(z, y, z, w);

        /// <summary>
        /// Returns bool4.zyw swizzling.
        /// </summary>
        public bool3 zyw => new bool3(z, y, w);

        /// <summary>
        /// Returns bool4.bga swizzling (equivalent to bool4.zyw).
        /// </summary>
        public bool3 bga => new bool3(z, y, w);

        /// <summary>
        /// Returns bool4.zywx swizzling.
        /// </summary>
        public bool4 zywx => new bool4(z, y, w, x);

        /// <summary>
        /// Returns bool4.bgar swizzling (equivalent to bool4.zywx).
        /// </summary>
        public bool4 bgar => new bool4(z, y, w, x);

        /// <summary>
        /// Returns bool4.zywy swizzling.
        /// </summary>
        public bool4 zywy => new bool4(z, y, w, y);

        /// <summary>
        /// Returns bool4.bgag swizzling (equivalent to bool4.zywy).
        /// </summary>
        public bool4 bgag => new bool4(z, y, w, y);

        /// <summary>
        /// Returns bool4.zywz swizzling.
        /// </summary>
        public bool4 zywz => new bool4(z, y, w, z);

        /// <summary>
        /// Returns bool4.bgab swizzling (equivalent to bool4.zywz).
        /// </summary>
        public bool4 bgab => new bool4(z, y, w, z);

        /// <summary>
        /// Returns bool4.zyww swizzling.
        /// </summary>
        public bool4 zyww => new bool4(z, y, w, w);

        /// <summary>
        /// Returns bool4.bgaa swizzling (equivalent to bool4.zyww).
        /// </summary>
        public bool4 bgaa => new bool4(z, y, w, w);

        /// <summary>
        /// Returns bool4.zz swizzling.
        /// </summary>
        public bool2 zz => new bool2(z, z);

        /// <summary>
        /// Returns bool4.bb swizzling (equivalent to bool4.zz).
        /// </summary>
        public bool2 bb => new bool2(z, z);

        /// <summary>
        /// Returns bool4.zzx swizzling.
        /// </summary>
        public bool3 zzx => new bool3(z, z, x);

        /// <summary>
        /// Returns bool4.bbr swizzling (equivalent to bool4.zzx).
        /// </summary>
        public bool3 bbr => new bool3(z, z, x);

        /// <summary>
        /// Returns bool4.zzxx swizzling.
        /// </summary>
        public bool4 zzxx => new bool4(z, z, x, x);

        /// <summary>
        /// Returns bool4.bbrr swizzling (equivalent to bool4.zzxx).
        /// </summary>
        public bool4 bbrr => new bool4(z, z, x, x);

        /// <summary>
        /// Returns bool4.zzxy swizzling.
        /// </summary>
        public bool4 zzxy => new bool4(z, z, x, y);

        /// <summary>
        /// Returns bool4.bbrg swizzling (equivalent to bool4.zzxy).
        /// </summary>
        public bool4 bbrg => new bool4(z, z, x, y);

        /// <summary>
        /// Returns bool4.zzxz swizzling.
        /// </summary>
        public bool4 zzxz => new bool4(z, z, x, z);

        /// <summary>
        /// Returns bool4.bbrb swizzling (equivalent to bool4.zzxz).
        /// </summary>
        public bool4 bbrb => new bool4(z, z, x, z);

        /// <summary>
        /// Returns bool4.zzxw swizzling.
        /// </summary>
        public bool4 zzxw => new bool4(z, z, x, w);

        /// <summary>
        /// Returns bool4.bbra swizzling (equivalent to bool4.zzxw).
        /// </summary>
        public bool4 bbra => new bool4(z, z, x, w);

        /// <summary>
        /// Returns bool4.zzy swizzling.
        /// </summary>
        public bool3 zzy => new bool3(z, z, y);

        /// <summary>
        /// Returns bool4.bbg swizzling (equivalent to bool4.zzy).
        /// </summary>
        public bool3 bbg => new bool3(z, z, y);

        /// <summary>
        /// Returns bool4.zzyx swizzling.
        /// </summary>
        public bool4 zzyx => new bool4(z, z, y, x);

        /// <summary>
        /// Returns bool4.bbgr swizzling (equivalent to bool4.zzyx).
        /// </summary>
        public bool4 bbgr => new bool4(z, z, y, x);

        /// <summary>
        /// Returns bool4.zzyy swizzling.
        /// </summary>
        public bool4 zzyy => new bool4(z, z, y, y);

        /// <summary>
        /// Returns bool4.bbgg swizzling (equivalent to bool4.zzyy).
        /// </summary>
        public bool4 bbgg => new bool4(z, z, y, y);

        /// <summary>
        /// Returns bool4.zzyz swizzling.
        /// </summary>
        public bool4 zzyz => new bool4(z, z, y, z);

        /// <summary>
        /// Returns bool4.bbgb swizzling (equivalent to bool4.zzyz).
        /// </summary>
        public bool4 bbgb => new bool4(z, z, y, z);

        /// <summary>
        /// Returns bool4.zzyw swizzling.
        /// </summary>
        public bool4 zzyw => new bool4(z, z, y, w);

        /// <summary>
        /// Returns bool4.bbga swizzling (equivalent to bool4.zzyw).
        /// </summary>
        public bool4 bbga => new bool4(z, z, y, w);

        /// <summary>
        /// Returns bool4.zzz swizzling.
        /// </summary>
        public bool3 zzz => new bool3(z, z, z);

        /// <summary>
        /// Returns bool4.bbb swizzling (equivalent to bool4.zzz).
        /// </summary>
        public bool3 bbb => new bool3(z, z, z);

        /// <summary>
        /// Returns bool4.zzzx swizzling.
        /// </summary>
        public bool4 zzzx => new bool4(z, z, z, x);

        /// <summary>
        /// Returns bool4.bbbr swizzling (equivalent to bool4.zzzx).
        /// </summary>
        public bool4 bbbr => new bool4(z, z, z, x);

        /// <summary>
        /// Returns bool4.zzzy swizzling.
        /// </summary>
        public bool4 zzzy => new bool4(z, z, z, y);

        /// <summary>
        /// Returns bool4.bbbg swizzling (equivalent to bool4.zzzy).
        /// </summary>
        public bool4 bbbg => new bool4(z, z, z, y);

        /// <summary>
        /// Returns bool4.zzzz swizzling.
        /// </summary>
        public bool4 zzzz => new bool4(z, z, z, z);

        /// <summary>
        /// Returns bool4.bbbb swizzling (equivalent to bool4.zzzz).
        /// </summary>
        public bool4 bbbb => new bool4(z, z, z, z);

        /// <summary>
        /// Returns bool4.zzzw swizzling.
        /// </summary>
        public bool4 zzzw => new bool4(z, z, z, w);

        /// <summary>
        /// Returns bool4.bbba swizzling (equivalent to bool4.zzzw).
        /// </summary>
        public bool4 bbba => new bool4(z, z, z, w);

        /// <summary>
        /// Returns bool4.zzw swizzling.
        /// </summary>
        public bool3 zzw => new bool3(z, z, w);

        /// <summary>
        /// Returns bool4.bba swizzling (equivalent to bool4.zzw).
        /// </summary>
        public bool3 bba => new bool3(z, z, w);

        /// <summary>
        /// Returns bool4.zzwx swizzling.
        /// </summary>
        public bool4 zzwx => new bool4(z, z, w, x);

        /// <summary>
        /// Returns bool4.bbar swizzling (equivalent to bool4.zzwx).
        /// </summary>
        public bool4 bbar => new bool4(z, z, w, x);

        /// <summary>
        /// Returns bool4.zzwy swizzling.
        /// </summary>
        public bool4 zzwy => new bool4(z, z, w, y);

        /// <summary>
        /// Returns bool4.bbag swizzling (equivalent to bool4.zzwy).
        /// </summary>
        public bool4 bbag => new bool4(z, z, w, y);

        /// <summary>
        /// Returns bool4.zzwz swizzling.
        /// </summary>
        public bool4 zzwz => new bool4(z, z, w, z);

        /// <summary>
        /// Returns bool4.bbab swizzling (equivalent to bool4.zzwz).
        /// </summary>
        public bool4 bbab => new bool4(z, z, w, z);

        /// <summary>
        /// Returns bool4.zzww swizzling.
        /// </summary>
        public bool4 zzww => new bool4(z, z, w, w);

        /// <summary>
        /// Returns bool4.bbaa swizzling (equivalent to bool4.zzww).
        /// </summary>
        public bool4 bbaa => new bool4(z, z, w, w);

        /// <summary>
        /// Returns bool4.zw swizzling.
        /// </summary>
        public bool2 zw => new bool2(z, w);

        /// <summary>
        /// Returns bool4.ba swizzling (equivalent to bool4.zw).
        /// </summary>
        public bool2 ba => new bool2(z, w);

        /// <summary>
        /// Returns bool4.zwx swizzling.
        /// </summary>
        public bool3 zwx => new bool3(z, w, x);

        /// <summary>
        /// Returns bool4.bar swizzling (equivalent to bool4.zwx).
        /// </summary>
        public bool3 bar => new bool3(z, w, x);

        /// <summary>
        /// Returns bool4.zwxx swizzling.
        /// </summary>
        public bool4 zwxx => new bool4(z, w, x, x);

        /// <summary>
        /// Returns bool4.barr swizzling (equivalent to bool4.zwxx).
        /// </summary>
        public bool4 barr => new bool4(z, w, x, x);

        /// <summary>
        /// Returns bool4.zwxy swizzling.
        /// </summary>
        public bool4 zwxy => new bool4(z, w, x, y);

        /// <summary>
        /// Returns bool4.barg swizzling (equivalent to bool4.zwxy).
        /// </summary>
        public bool4 barg => new bool4(z, w, x, y);

        /// <summary>
        /// Returns bool4.zwxz swizzling.
        /// </summary>
        public bool4 zwxz => new bool4(z, w, x, z);

        /// <summary>
        /// Returns bool4.barb swizzling (equivalent to bool4.zwxz).
        /// </summary>
        public bool4 barb => new bool4(z, w, x, z);

        /// <summary>
        /// Returns bool4.zwxw swizzling.
        /// </summary>
        public bool4 zwxw => new bool4(z, w, x, w);

        /// <summary>
        /// Returns bool4.bara swizzling (equivalent to bool4.zwxw).
        /// </summary>
        public bool4 bara => new bool4(z, w, x, w);

        /// <summary>
        /// Returns bool4.zwy swizzling.
        /// </summary>
        public bool3 zwy => new bool3(z, w, y);

        /// <summary>
        /// Returns bool4.bag swizzling (equivalent to bool4.zwy).
        /// </summary>
        public bool3 bag => new bool3(z, w, y);

        /// <summary>
        /// Returns bool4.zwyx swizzling.
        /// </summary>
        public bool4 zwyx => new bool4(z, w, y, x);

        /// <summary>
        /// Returns bool4.bagr swizzling (equivalent to bool4.zwyx).
        /// </summary>
        public bool4 bagr => new bool4(z, w, y, x);

        /// <summary>
        /// Returns bool4.zwyy swizzling.
        /// </summary>
        public bool4 zwyy => new bool4(z, w, y, y);

        /// <summary>
        /// Returns bool4.bagg swizzling (equivalent to bool4.zwyy).
        /// </summary>
        public bool4 bagg => new bool4(z, w, y, y);

        /// <summary>
        /// Returns bool4.zwyz swizzling.
        /// </summary>
        public bool4 zwyz => new bool4(z, w, y, z);

        /// <summary>
        /// Returns bool4.bagb swizzling (equivalent to bool4.zwyz).
        /// </summary>
        public bool4 bagb => new bool4(z, w, y, z);

        /// <summary>
        /// Returns bool4.zwyw swizzling.
        /// </summary>
        public bool4 zwyw => new bool4(z, w, y, w);

        /// <summary>
        /// Returns bool4.baga swizzling (equivalent to bool4.zwyw).
        /// </summary>
        public bool4 baga => new bool4(z, w, y, w);

        /// <summary>
        /// Returns bool4.zwz swizzling.
        /// </summary>
        public bool3 zwz => new bool3(z, w, z);

        /// <summary>
        /// Returns bool4.bab swizzling (equivalent to bool4.zwz).
        /// </summary>
        public bool3 bab => new bool3(z, w, z);

        /// <summary>
        /// Returns bool4.zwzx swizzling.
        /// </summary>
        public bool4 zwzx => new bool4(z, w, z, x);

        /// <summary>
        /// Returns bool4.babr swizzling (equivalent to bool4.zwzx).
        /// </summary>
        public bool4 babr => new bool4(z, w, z, x);

        /// <summary>
        /// Returns bool4.zwzy swizzling.
        /// </summary>
        public bool4 zwzy => new bool4(z, w, z, y);

        /// <summary>
        /// Returns bool4.babg swizzling (equivalent to bool4.zwzy).
        /// </summary>
        public bool4 babg => new bool4(z, w, z, y);

        /// <summary>
        /// Returns bool4.zwzz swizzling.
        /// </summary>
        public bool4 zwzz => new bool4(z, w, z, z);

        /// <summary>
        /// Returns bool4.babb swizzling (equivalent to bool4.zwzz).
        /// </summary>
        public bool4 babb => new bool4(z, w, z, z);

        /// <summary>
        /// Returns bool4.zwzw swizzling.
        /// </summary>
        public bool4 zwzw => new bool4(z, w, z, w);

        /// <summary>
        /// Returns bool4.baba swizzling (equivalent to bool4.zwzw).
        /// </summary>
        public bool4 baba => new bool4(z, w, z, w);

        /// <summary>
        /// Returns bool4.zww swizzling.
        /// </summary>
        public bool3 zww => new bool3(z, w, w);

        /// <summary>
        /// Returns bool4.baa swizzling (equivalent to bool4.zww).
        /// </summary>
        public bool3 baa => new bool3(z, w, w);

        /// <summary>
        /// Returns bool4.zwwx swizzling.
        /// </summary>
        public bool4 zwwx => new bool4(z, w, w, x);

        /// <summary>
        /// Returns bool4.baar swizzling (equivalent to bool4.zwwx).
        /// </summary>
        public bool4 baar => new bool4(z, w, w, x);

        /// <summary>
        /// Returns bool4.zwwy swizzling.
        /// </summary>
        public bool4 zwwy => new bool4(z, w, w, y);

        /// <summary>
        /// Returns bool4.baag swizzling (equivalent to bool4.zwwy).
        /// </summary>
        public bool4 baag => new bool4(z, w, w, y);

        /// <summary>
        /// Returns bool4.zwwz swizzling.
        /// </summary>
        public bool4 zwwz => new bool4(z, w, w, z);

        /// <summary>
        /// Returns bool4.baab swizzling (equivalent to bool4.zwwz).
        /// </summary>
        public bool4 baab => new bool4(z, w, w, z);

        /// <summary>
        /// Returns bool4.zwww swizzling.
        /// </summary>
        public bool4 zwww => new bool4(z, w, w, w);

        /// <summary>
        /// Returns bool4.baaa swizzling (equivalent to bool4.zwww).
        /// </summary>
        public bool4 baaa => new bool4(z, w, w, w);

        /// <summary>
        /// Returns bool4.wx swizzling.
        /// </summary>
        public bool2 wx => new bool2(w, x);

        /// <summary>
        /// Returns bool4.ar swizzling (equivalent to bool4.wx).
        /// </summary>
        public bool2 ar => new bool2(w, x);

        /// <summary>
        /// Returns bool4.wxx swizzling.
        /// </summary>
        public bool3 wxx => new bool3(w, x, x);

        /// <summary>
        /// Returns bool4.arr swizzling (equivalent to bool4.wxx).
        /// </summary>
        public bool3 arr => new bool3(w, x, x);

        /// <summary>
        /// Returns bool4.wxxx swizzling.
        /// </summary>
        public bool4 wxxx => new bool4(w, x, x, x);

        /// <summary>
        /// Returns bool4.arrr swizzling (equivalent to bool4.wxxx).
        /// </summary>
        public bool4 arrr => new bool4(w, x, x, x);

        /// <summary>
        /// Returns bool4.wxxy swizzling.
        /// </summary>
        public bool4 wxxy => new bool4(w, x, x, y);

        /// <summary>
        /// Returns bool4.arrg swizzling (equivalent to bool4.wxxy).
        /// </summary>
        public bool4 arrg => new bool4(w, x, x, y);

        /// <summary>
        /// Returns bool4.wxxz swizzling.
        /// </summary>
        public bool4 wxxz => new bool4(w, x, x, z);

        /// <summary>
        /// Returns bool4.arrb swizzling (equivalent to bool4.wxxz).
        /// </summary>
        public bool4 arrb => new bool4(w, x, x, z);

        /// <summary>
        /// Returns bool4.wxxw swizzling.
        /// </summary>
        public bool4 wxxw => new bool4(w, x, x, w);

        /// <summary>
        /// Returns bool4.arra swizzling (equivalent to bool4.wxxw).
        /// </summary>
        public bool4 arra => new bool4(w, x, x, w);

        /// <summary>
        /// Returns bool4.wxy swizzling.
        /// </summary>
        public bool3 wxy => new bool3(w, x, y);

        /// <summary>
        /// Returns bool4.arg swizzling (equivalent to bool4.wxy).
        /// </summary>
        public bool3 arg => new bool3(w, x, y);

        /// <summary>
        /// Returns bool4.wxyx swizzling.
        /// </summary>
        public bool4 wxyx => new bool4(w, x, y, x);

        /// <summary>
        /// Returns bool4.argr swizzling (equivalent to bool4.wxyx).
        /// </summary>
        public bool4 argr => new bool4(w, x, y, x);

        /// <summary>
        /// Returns bool4.wxyy swizzling.
        /// </summary>
        public bool4 wxyy => new bool4(w, x, y, y);

        /// <summary>
        /// Returns bool4.argg swizzling (equivalent to bool4.wxyy).
        /// </summary>
        public bool4 argg => new bool4(w, x, y, y);

        /// <summary>
        /// Returns bool4.wxyz swizzling.
        /// </summary>
        public bool4 wxyz => new bool4(w, x, y, z);

        /// <summary>
        /// Returns bool4.argb swizzling (equivalent to bool4.wxyz).
        /// </summary>
        public bool4 argb => new bool4(w, x, y, z);

        /// <summary>
        /// Returns bool4.wxyw swizzling.
        /// </summary>
        public bool4 wxyw => new bool4(w, x, y, w);

        /// <summary>
        /// Returns bool4.arga swizzling (equivalent to bool4.wxyw).
        /// </summary>
        public bool4 arga => new bool4(w, x, y, w);

        /// <summary>
        /// Returns bool4.wxz swizzling.
        /// </summary>
        public bool3 wxz => new bool3(w, x, z);

        /// <summary>
        /// Returns bool4.arb swizzling (equivalent to bool4.wxz).
        /// </summary>
        public bool3 arb => new bool3(w, x, z);

        /// <summary>
        /// Returns bool4.wxzx swizzling.
        /// </summary>
        public bool4 wxzx => new bool4(w, x, z, x);

        /// <summary>
        /// Returns bool4.arbr swizzling (equivalent to bool4.wxzx).
        /// </summary>
        public bool4 arbr => new bool4(w, x, z, x);

        /// <summary>
        /// Returns bool4.wxzy swizzling.
        /// </summary>
        public bool4 wxzy => new bool4(w, x, z, y);

        /// <summary>
        /// Returns bool4.arbg swizzling (equivalent to bool4.wxzy).
        /// </summary>
        public bool4 arbg => new bool4(w, x, z, y);

        /// <summary>
        /// Returns bool4.wxzz swizzling.
        /// </summary>
        public bool4 wxzz => new bool4(w, x, z, z);

        /// <summary>
        /// Returns bool4.arbb swizzling (equivalent to bool4.wxzz).
        /// </summary>
        public bool4 arbb => new bool4(w, x, z, z);

        /// <summary>
        /// Returns bool4.wxzw swizzling.
        /// </summary>
        public bool4 wxzw => new bool4(w, x, z, w);

        /// <summary>
        /// Returns bool4.arba swizzling (equivalent to bool4.wxzw).
        /// </summary>
        public bool4 arba => new bool4(w, x, z, w);

        /// <summary>
        /// Returns bool4.wxw swizzling.
        /// </summary>
        public bool3 wxw => new bool3(w, x, w);

        /// <summary>
        /// Returns bool4.ara swizzling (equivalent to bool4.wxw).
        /// </summary>
        public bool3 ara => new bool3(w, x, w);

        /// <summary>
        /// Returns bool4.wxwx swizzling.
        /// </summary>
        public bool4 wxwx => new bool4(w, x, w, x);

        /// <summary>
        /// Returns bool4.arar swizzling (equivalent to bool4.wxwx).
        /// </summary>
        public bool4 arar => new bool4(w, x, w, x);

        /// <summary>
        /// Returns bool4.wxwy swizzling.
        /// </summary>
        public bool4 wxwy => new bool4(w, x, w, y);

        /// <summary>
        /// Returns bool4.arag swizzling (equivalent to bool4.wxwy).
        /// </summary>
        public bool4 arag => new bool4(w, x, w, y);

        /// <summary>
        /// Returns bool4.wxwz swizzling.
        /// </summary>
        public bool4 wxwz => new bool4(w, x, w, z);

        /// <summary>
        /// Returns bool4.arab swizzling (equivalent to bool4.wxwz).
        /// </summary>
        public bool4 arab => new bool4(w, x, w, z);

        /// <summary>
        /// Returns bool4.wxww swizzling.
        /// </summary>
        public bool4 wxww => new bool4(w, x, w, w);

        /// <summary>
        /// Returns bool4.araa swizzling (equivalent to bool4.wxww).
        /// </summary>
        public bool4 araa => new bool4(w, x, w, w);

        /// <summary>
        /// Returns bool4.wy swizzling.
        /// </summary>
        public bool2 wy => new bool2(w, y);

        /// <summary>
        /// Returns bool4.ag swizzling (equivalent to bool4.wy).
        /// </summary>
        public bool2 ag => new bool2(w, y);

        /// <summary>
        /// Returns bool4.wyx swizzling.
        /// </summary>
        public bool3 wyx => new bool3(w, y, x);

        /// <summary>
        /// Returns bool4.agr swizzling (equivalent to bool4.wyx).
        /// </summary>
        public bool3 agr => new bool3(w, y, x);

        /// <summary>
        /// Returns bool4.wyxx swizzling.
        /// </summary>
        public bool4 wyxx => new bool4(w, y, x, x);

        /// <summary>
        /// Returns bool4.agrr swizzling (equivalent to bool4.wyxx).
        /// </summary>
        public bool4 agrr => new bool4(w, y, x, x);

        /// <summary>
        /// Returns bool4.wyxy swizzling.
        /// </summary>
        public bool4 wyxy => new bool4(w, y, x, y);

        /// <summary>
        /// Returns bool4.agrg swizzling (equivalent to bool4.wyxy).
        /// </summary>
        public bool4 agrg => new bool4(w, y, x, y);

        /// <summary>
        /// Returns bool4.wyxz swizzling.
        /// </summary>
        public bool4 wyxz => new bool4(w, y, x, z);

        /// <summary>
        /// Returns bool4.agrb swizzling (equivalent to bool4.wyxz).
        /// </summary>
        public bool4 agrb => new bool4(w, y, x, z);

        /// <summary>
        /// Returns bool4.wyxw swizzling.
        /// </summary>
        public bool4 wyxw => new bool4(w, y, x, w);

        /// <summary>
        /// Returns bool4.agra swizzling (equivalent to bool4.wyxw).
        /// </summary>
        public bool4 agra => new bool4(w, y, x, w);

        /// <summary>
        /// Returns bool4.wyy swizzling.
        /// </summary>
        public bool3 wyy => new bool3(w, y, y);

        /// <summary>
        /// Returns bool4.agg swizzling (equivalent to bool4.wyy).
        /// </summary>
        public bool3 agg => new bool3(w, y, y);

        /// <summary>
        /// Returns bool4.wyyx swizzling.
        /// </summary>
        public bool4 wyyx => new bool4(w, y, y, x);

        /// <summary>
        /// Returns bool4.aggr swizzling (equivalent to bool4.wyyx).
        /// </summary>
        public bool4 aggr => new bool4(w, y, y, x);

        /// <summary>
        /// Returns bool4.wyyy swizzling.
        /// </summary>
        public bool4 wyyy => new bool4(w, y, y, y);

        /// <summary>
        /// Returns bool4.aggg swizzling (equivalent to bool4.wyyy).
        /// </summary>
        public bool4 aggg => new bool4(w, y, y, y);

        /// <summary>
        /// Returns bool4.wyyz swizzling.
        /// </summary>
        public bool4 wyyz => new bool4(w, y, y, z);

        /// <summary>
        /// Returns bool4.aggb swizzling (equivalent to bool4.wyyz).
        /// </summary>
        public bool4 aggb => new bool4(w, y, y, z);

        /// <summary>
        /// Returns bool4.wyyw swizzling.
        /// </summary>
        public bool4 wyyw => new bool4(w, y, y, w);

        /// <summary>
        /// Returns bool4.agga swizzling (equivalent to bool4.wyyw).
        /// </summary>
        public bool4 agga => new bool4(w, y, y, w);

        /// <summary>
        /// Returns bool4.wyz swizzling.
        /// </summary>
        public bool3 wyz => new bool3(w, y, z);

        /// <summary>
        /// Returns bool4.agb swizzling (equivalent to bool4.wyz).
        /// </summary>
        public bool3 agb => new bool3(w, y, z);

        /// <summary>
        /// Returns bool4.wyzx swizzling.
        /// </summary>
        public bool4 wyzx => new bool4(w, y, z, x);

        /// <summary>
        /// Returns bool4.agbr swizzling (equivalent to bool4.wyzx).
        /// </summary>
        public bool4 agbr => new bool4(w, y, z, x);

        /// <summary>
        /// Returns bool4.wyzy swizzling.
        /// </summary>
        public bool4 wyzy => new bool4(w, y, z, y);

        /// <summary>
        /// Returns bool4.agbg swizzling (equivalent to bool4.wyzy).
        /// </summary>
        public bool4 agbg => new bool4(w, y, z, y);

        /// <summary>
        /// Returns bool4.wyzz swizzling.
        /// </summary>
        public bool4 wyzz => new bool4(w, y, z, z);

        /// <summary>
        /// Returns bool4.agbb swizzling (equivalent to bool4.wyzz).
        /// </summary>
        public bool4 agbb => new bool4(w, y, z, z);

        /// <summary>
        /// Returns bool4.wyzw swizzling.
        /// </summary>
        public bool4 wyzw => new bool4(w, y, z, w);

        /// <summary>
        /// Returns bool4.agba swizzling (equivalent to bool4.wyzw).
        /// </summary>
        public bool4 agba => new bool4(w, y, z, w);

        /// <summary>
        /// Returns bool4.wyw swizzling.
        /// </summary>
        public bool3 wyw => new bool3(w, y, w);

        /// <summary>
        /// Returns bool4.aga swizzling (equivalent to bool4.wyw).
        /// </summary>
        public bool3 aga => new bool3(w, y, w);

        /// <summary>
        /// Returns bool4.wywx swizzling.
        /// </summary>
        public bool4 wywx => new bool4(w, y, w, x);

        /// <summary>
        /// Returns bool4.agar swizzling (equivalent to bool4.wywx).
        /// </summary>
        public bool4 agar => new bool4(w, y, w, x);

        /// <summary>
        /// Returns bool4.wywy swizzling.
        /// </summary>
        public bool4 wywy => new bool4(w, y, w, y);

        /// <summary>
        /// Returns bool4.agag swizzling (equivalent to bool4.wywy).
        /// </summary>
        public bool4 agag => new bool4(w, y, w, y);

        /// <summary>
        /// Returns bool4.wywz swizzling.
        /// </summary>
        public bool4 wywz => new bool4(w, y, w, z);

        /// <summary>
        /// Returns bool4.agab swizzling (equivalent to bool4.wywz).
        /// </summary>
        public bool4 agab => new bool4(w, y, w, z);

        /// <summary>
        /// Returns bool4.wyww swizzling.
        /// </summary>
        public bool4 wyww => new bool4(w, y, w, w);

        /// <summary>
        /// Returns bool4.agaa swizzling (equivalent to bool4.wyww).
        /// </summary>
        public bool4 agaa => new bool4(w, y, w, w);

        /// <summary>
        /// Returns bool4.wz swizzling.
        /// </summary>
        public bool2 wz => new bool2(w, z);

        /// <summary>
        /// Returns bool4.ab swizzling (equivalent to bool4.wz).
        /// </summary>
        public bool2 ab => new bool2(w, z);

        /// <summary>
        /// Returns bool4.wzx swizzling.
        /// </summary>
        public bool3 wzx => new bool3(w, z, x);

        /// <summary>
        /// Returns bool4.abr swizzling (equivalent to bool4.wzx).
        /// </summary>
        public bool3 abr => new bool3(w, z, x);

        /// <summary>
        /// Returns bool4.wzxx swizzling.
        /// </summary>
        public bool4 wzxx => new bool4(w, z, x, x);

        /// <summary>
        /// Returns bool4.abrr swizzling (equivalent to bool4.wzxx).
        /// </summary>
        public bool4 abrr => new bool4(w, z, x, x);

        /// <summary>
        /// Returns bool4.wzxy swizzling.
        /// </summary>
        public bool4 wzxy => new bool4(w, z, x, y);

        /// <summary>
        /// Returns bool4.abrg swizzling (equivalent to bool4.wzxy).
        /// </summary>
        public bool4 abrg => new bool4(w, z, x, y);

        /// <summary>
        /// Returns bool4.wzxz swizzling.
        /// </summary>
        public bool4 wzxz => new bool4(w, z, x, z);

        /// <summary>
        /// Returns bool4.abrb swizzling (equivalent to bool4.wzxz).
        /// </summary>
        public bool4 abrb => new bool4(w, z, x, z);

        /// <summary>
        /// Returns bool4.wzxw swizzling.
        /// </summary>
        public bool4 wzxw => new bool4(w, z, x, w);

        /// <summary>
        /// Returns bool4.abra swizzling (equivalent to bool4.wzxw).
        /// </summary>
        public bool4 abra => new bool4(w, z, x, w);

        /// <summary>
        /// Returns bool4.wzy swizzling.
        /// </summary>
        public bool3 wzy => new bool3(w, z, y);

        /// <summary>
        /// Returns bool4.abg swizzling (equivalent to bool4.wzy).
        /// </summary>
        public bool3 abg => new bool3(w, z, y);

        /// <summary>
        /// Returns bool4.wzyx swizzling.
        /// </summary>
        public bool4 wzyx => new bool4(w, z, y, x);

        /// <summary>
        /// Returns bool4.abgr swizzling (equivalent to bool4.wzyx).
        /// </summary>
        public bool4 abgr => new bool4(w, z, y, x);

        /// <summary>
        /// Returns bool4.wzyy swizzling.
        /// </summary>
        public bool4 wzyy => new bool4(w, z, y, y);

        /// <summary>
        /// Returns bool4.abgg swizzling (equivalent to bool4.wzyy).
        /// </summary>
        public bool4 abgg => new bool4(w, z, y, y);

        /// <summary>
        /// Returns bool4.wzyz swizzling.
        /// </summary>
        public bool4 wzyz => new bool4(w, z, y, z);

        /// <summary>
        /// Returns bool4.abgb swizzling (equivalent to bool4.wzyz).
        /// </summary>
        public bool4 abgb => new bool4(w, z, y, z);

        /// <summary>
        /// Returns bool4.wzyw swizzling.
        /// </summary>
        public bool4 wzyw => new bool4(w, z, y, w);

        /// <summary>
        /// Returns bool4.abga swizzling (equivalent to bool4.wzyw).
        /// </summary>
        public bool4 abga => new bool4(w, z, y, w);

        /// <summary>
        /// Returns bool4.wzz swizzling.
        /// </summary>
        public bool3 wzz => new bool3(w, z, z);

        /// <summary>
        /// Returns bool4.abb swizzling (equivalent to bool4.wzz).
        /// </summary>
        public bool3 abb => new bool3(w, z, z);

        /// <summary>
        /// Returns bool4.wzzx swizzling.
        /// </summary>
        public bool4 wzzx => new bool4(w, z, z, x);

        /// <summary>
        /// Returns bool4.abbr swizzling (equivalent to bool4.wzzx).
        /// </summary>
        public bool4 abbr => new bool4(w, z, z, x);

        /// <summary>
        /// Returns bool4.wzzy swizzling.
        /// </summary>
        public bool4 wzzy => new bool4(w, z, z, y);

        /// <summary>
        /// Returns bool4.abbg swizzling (equivalent to bool4.wzzy).
        /// </summary>
        public bool4 abbg => new bool4(w, z, z, y);

        /// <summary>
        /// Returns bool4.wzzz swizzling.
        /// </summary>
        public bool4 wzzz => new bool4(w, z, z, z);

        /// <summary>
        /// Returns bool4.abbb swizzling (equivalent to bool4.wzzz).
        /// </summary>
        public bool4 abbb => new bool4(w, z, z, z);

        /// <summary>
        /// Returns bool4.wzzw swizzling.
        /// </summary>
        public bool4 wzzw => new bool4(w, z, z, w);

        /// <summary>
        /// Returns bool4.abba swizzling (equivalent to bool4.wzzw).
        /// </summary>
        public bool4 abba => new bool4(w, z, z, w);

        /// <summary>
        /// Returns bool4.wzw swizzling.
        /// </summary>
        public bool3 wzw => new bool3(w, z, w);

        /// <summary>
        /// Returns bool4.aba swizzling (equivalent to bool4.wzw).
        /// </summary>
        public bool3 aba => new bool3(w, z, w);

        /// <summary>
        /// Returns bool4.wzwx swizzling.
        /// </summary>
        public bool4 wzwx => new bool4(w, z, w, x);

        /// <summary>
        /// Returns bool4.abar swizzling (equivalent to bool4.wzwx).
        /// </summary>
        public bool4 abar => new bool4(w, z, w, x);

        /// <summary>
        /// Returns bool4.wzwy swizzling.
        /// </summary>
        public bool4 wzwy => new bool4(w, z, w, y);

        /// <summary>
        /// Returns bool4.abag swizzling (equivalent to bool4.wzwy).
        /// </summary>
        public bool4 abag => new bool4(w, z, w, y);

        /// <summary>
        /// Returns bool4.wzwz swizzling.
        /// </summary>
        public bool4 wzwz => new bool4(w, z, w, z);

        /// <summary>
        /// Returns bool4.abab swizzling (equivalent to bool4.wzwz).
        /// </summary>
        public bool4 abab => new bool4(w, z, w, z);

        /// <summary>
        /// Returns bool4.wzww swizzling.
        /// </summary>
        public bool4 wzww => new bool4(w, z, w, w);

        /// <summary>
        /// Returns bool4.abaa swizzling (equivalent to bool4.wzww).
        /// </summary>
        public bool4 abaa => new bool4(w, z, w, w);

        /// <summary>
        /// Returns bool4.ww swizzling.
        /// </summary>
        public bool2 ww => new bool2(w, w);

        /// <summary>
        /// Returns bool4.aa swizzling (equivalent to bool4.ww).
        /// </summary>
        public bool2 aa => new bool2(w, w);

        /// <summary>
        /// Returns bool4.wwx swizzling.
        /// </summary>
        public bool3 wwx => new bool3(w, w, x);

        /// <summary>
        /// Returns bool4.aar swizzling (equivalent to bool4.wwx).
        /// </summary>
        public bool3 aar => new bool3(w, w, x);

        /// <summary>
        /// Returns bool4.wwxx swizzling.
        /// </summary>
        public bool4 wwxx => new bool4(w, w, x, x);

        /// <summary>
        /// Returns bool4.aarr swizzling (equivalent to bool4.wwxx).
        /// </summary>
        public bool4 aarr => new bool4(w, w, x, x);

        /// <summary>
        /// Returns bool4.wwxy swizzling.
        /// </summary>
        public bool4 wwxy => new bool4(w, w, x, y);

        /// <summary>
        /// Returns bool4.aarg swizzling (equivalent to bool4.wwxy).
        /// </summary>
        public bool4 aarg => new bool4(w, w, x, y);

        /// <summary>
        /// Returns bool4.wwxz swizzling.
        /// </summary>
        public bool4 wwxz => new bool4(w, w, x, z);

        /// <summary>
        /// Returns bool4.aarb swizzling (equivalent to bool4.wwxz).
        /// </summary>
        public bool4 aarb => new bool4(w, w, x, z);

        /// <summary>
        /// Returns bool4.wwxw swizzling.
        /// </summary>
        public bool4 wwxw => new bool4(w, w, x, w);

        /// <summary>
        /// Returns bool4.aara swizzling (equivalent to bool4.wwxw).
        /// </summary>
        public bool4 aara => new bool4(w, w, x, w);

        /// <summary>
        /// Returns bool4.wwy swizzling.
        /// </summary>
        public bool3 wwy => new bool3(w, w, y);

        /// <summary>
        /// Returns bool4.aag swizzling (equivalent to bool4.wwy).
        /// </summary>
        public bool3 aag => new bool3(w, w, y);

        /// <summary>
        /// Returns bool4.wwyx swizzling.
        /// </summary>
        public bool4 wwyx => new bool4(w, w, y, x);

        /// <summary>
        /// Returns bool4.aagr swizzling (equivalent to bool4.wwyx).
        /// </summary>
        public bool4 aagr => new bool4(w, w, y, x);

        /// <summary>
        /// Returns bool4.wwyy swizzling.
        /// </summary>
        public bool4 wwyy => new bool4(w, w, y, y);

        /// <summary>
        /// Returns bool4.aagg swizzling (equivalent to bool4.wwyy).
        /// </summary>
        public bool4 aagg => new bool4(w, w, y, y);

        /// <summary>
        /// Returns bool4.wwyz swizzling.
        /// </summary>
        public bool4 wwyz => new bool4(w, w, y, z);

        /// <summary>
        /// Returns bool4.aagb swizzling (equivalent to bool4.wwyz).
        /// </summary>
        public bool4 aagb => new bool4(w, w, y, z);

        /// <summary>
        /// Returns bool4.wwyw swizzling.
        /// </summary>
        public bool4 wwyw => new bool4(w, w, y, w);

        /// <summary>
        /// Returns bool4.aaga swizzling (equivalent to bool4.wwyw).
        /// </summary>
        public bool4 aaga => new bool4(w, w, y, w);

        /// <summary>
        /// Returns bool4.wwz swizzling.
        /// </summary>
        public bool3 wwz => new bool3(w, w, z);

        /// <summary>
        /// Returns bool4.aab swizzling (equivalent to bool4.wwz).
        /// </summary>
        public bool3 aab => new bool3(w, w, z);

        /// <summary>
        /// Returns bool4.wwzx swizzling.
        /// </summary>
        public bool4 wwzx => new bool4(w, w, z, x);

        /// <summary>
        /// Returns bool4.aabr swizzling (equivalent to bool4.wwzx).
        /// </summary>
        public bool4 aabr => new bool4(w, w, z, x);

        /// <summary>
        /// Returns bool4.wwzy swizzling.
        /// </summary>
        public bool4 wwzy => new bool4(w, w, z, y);

        /// <summary>
        /// Returns bool4.aabg swizzling (equivalent to bool4.wwzy).
        /// </summary>
        public bool4 aabg => new bool4(w, w, z, y);

        /// <summary>
        /// Returns bool4.wwzz swizzling.
        /// </summary>
        public bool4 wwzz => new bool4(w, w, z, z);

        /// <summary>
        /// Returns bool4.aabb swizzling (equivalent to bool4.wwzz).
        /// </summary>
        public bool4 aabb => new bool4(w, w, z, z);

        /// <summary>
        /// Returns bool4.wwzw swizzling.
        /// </summary>
        public bool4 wwzw => new bool4(w, w, z, w);

        /// <summary>
        /// Returns bool4.aaba swizzling (equivalent to bool4.wwzw).
        /// </summary>
        public bool4 aaba => new bool4(w, w, z, w);

        /// <summary>
        /// Returns bool4.www swizzling.
        /// </summary>
        public bool3 www => new bool3(w, w, w);

        /// <summary>
        /// Returns bool4.aaa swizzling (equivalent to bool4.www).
        /// </summary>
        public bool3 aaa => new bool3(w, w, w);

        /// <summary>
        /// Returns bool4.wwwx swizzling.
        /// </summary>
        public bool4 wwwx => new bool4(w, w, w, x);

        /// <summary>
        /// Returns bool4.aaar swizzling (equivalent to bool4.wwwx).
        /// </summary>
        public bool4 aaar => new bool4(w, w, w, x);

        /// <summary>
        /// Returns bool4.wwwy swizzling.
        /// </summary>
        public bool4 wwwy => new bool4(w, w, w, y);

        /// <summary>
        /// Returns bool4.aaag swizzling (equivalent to bool4.wwwy).
        /// </summary>
        public bool4 aaag => new bool4(w, w, w, y);

        /// <summary>
        /// Returns bool4.wwwz swizzling.
        /// </summary>
        public bool4 wwwz => new bool4(w, w, w, z);

        /// <summary>
        /// Returns bool4.aaab swizzling (equivalent to bool4.wwwz).
        /// </summary>
        public bool4 aaab => new bool4(w, w, w, z);

        /// <summary>
        /// Returns bool4.wwww swizzling.
        /// </summary>
        public bool4 wwww => new bool4(w, w, w, w);

        /// <summary>
        /// Returns bool4.aaaa swizzling (equivalent to bool4.wwww).
        /// </summary>
        public bool4 aaaa => new bool4(w, w, w, w);

        #endregion

    }
}
