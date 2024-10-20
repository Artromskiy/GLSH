using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type double with 4 components, used for implementing swizzling for double4.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_dvec4
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

        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        internal readonly double w;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_dvec4.
        /// </summary>
        internal swizzle_dvec4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns double4.xx swizzling.
        /// </summary>
        public double2 xx => new double2(x, x);

        /// <summary>
        /// Returns double4.rr swizzling (equivalent to double4.xx).
        /// </summary>
        public double2 rr => new double2(x, x);

        /// <summary>
        /// Returns double4.xxx swizzling.
        /// </summary>
        public double3 xxx => new double3(x, x, x);

        /// <summary>
        /// Returns double4.rrr swizzling (equivalent to double4.xxx).
        /// </summary>
        public double3 rrr => new double3(x, x, x);

        /// <summary>
        /// Returns double4.xxxx swizzling.
        /// </summary>
        public double4 xxxx => new double4(x, x, x, x);

        /// <summary>
        /// Returns double4.rrrr swizzling (equivalent to double4.xxxx).
        /// </summary>
        public double4 rrrr => new double4(x, x, x, x);

        /// <summary>
        /// Returns double4.xxxy swizzling.
        /// </summary>
        public double4 xxxy => new double4(x, x, x, y);

        /// <summary>
        /// Returns double4.rrrg swizzling (equivalent to double4.xxxy).
        /// </summary>
        public double4 rrrg => new double4(x, x, x, y);

        /// <summary>
        /// Returns double4.xxxz swizzling.
        /// </summary>
        public double4 xxxz => new double4(x, x, x, z);

        /// <summary>
        /// Returns double4.rrrb swizzling (equivalent to double4.xxxz).
        /// </summary>
        public double4 rrrb => new double4(x, x, x, z);

        /// <summary>
        /// Returns double4.xxxw swizzling.
        /// </summary>
        public double4 xxxw => new double4(x, x, x, w);

        /// <summary>
        /// Returns double4.rrra swizzling (equivalent to double4.xxxw).
        /// </summary>
        public double4 rrra => new double4(x, x, x, w);

        /// <summary>
        /// Returns double4.xxy swizzling.
        /// </summary>
        public double3 xxy => new double3(x, x, y);

        /// <summary>
        /// Returns double4.rrg swizzling (equivalent to double4.xxy).
        /// </summary>
        public double3 rrg => new double3(x, x, y);

        /// <summary>
        /// Returns double4.xxyx swizzling.
        /// </summary>
        public double4 xxyx => new double4(x, x, y, x);

        /// <summary>
        /// Returns double4.rrgr swizzling (equivalent to double4.xxyx).
        /// </summary>
        public double4 rrgr => new double4(x, x, y, x);

        /// <summary>
        /// Returns double4.xxyy swizzling.
        /// </summary>
        public double4 xxyy => new double4(x, x, y, y);

        /// <summary>
        /// Returns double4.rrgg swizzling (equivalent to double4.xxyy).
        /// </summary>
        public double4 rrgg => new double4(x, x, y, y);

        /// <summary>
        /// Returns double4.xxyz swizzling.
        /// </summary>
        public double4 xxyz => new double4(x, x, y, z);

        /// <summary>
        /// Returns double4.rrgb swizzling (equivalent to double4.xxyz).
        /// </summary>
        public double4 rrgb => new double4(x, x, y, z);

        /// <summary>
        /// Returns double4.xxyw swizzling.
        /// </summary>
        public double4 xxyw => new double4(x, x, y, w);

        /// <summary>
        /// Returns double4.rrga swizzling (equivalent to double4.xxyw).
        /// </summary>
        public double4 rrga => new double4(x, x, y, w);

        /// <summary>
        /// Returns double4.xxz swizzling.
        /// </summary>
        public double3 xxz => new double3(x, x, z);

        /// <summary>
        /// Returns double4.rrb swizzling (equivalent to double4.xxz).
        /// </summary>
        public double3 rrb => new double3(x, x, z);

        /// <summary>
        /// Returns double4.xxzx swizzling.
        /// </summary>
        public double4 xxzx => new double4(x, x, z, x);

        /// <summary>
        /// Returns double4.rrbr swizzling (equivalent to double4.xxzx).
        /// </summary>
        public double4 rrbr => new double4(x, x, z, x);

        /// <summary>
        /// Returns double4.xxzy swizzling.
        /// </summary>
        public double4 xxzy => new double4(x, x, z, y);

        /// <summary>
        /// Returns double4.rrbg swizzling (equivalent to double4.xxzy).
        /// </summary>
        public double4 rrbg => new double4(x, x, z, y);

        /// <summary>
        /// Returns double4.xxzz swizzling.
        /// </summary>
        public double4 xxzz => new double4(x, x, z, z);

        /// <summary>
        /// Returns double4.rrbb swizzling (equivalent to double4.xxzz).
        /// </summary>
        public double4 rrbb => new double4(x, x, z, z);

        /// <summary>
        /// Returns double4.xxzw swizzling.
        /// </summary>
        public double4 xxzw => new double4(x, x, z, w);

        /// <summary>
        /// Returns double4.rrba swizzling (equivalent to double4.xxzw).
        /// </summary>
        public double4 rrba => new double4(x, x, z, w);

        /// <summary>
        /// Returns double4.xxw swizzling.
        /// </summary>
        public double3 xxw => new double3(x, x, w);

        /// <summary>
        /// Returns double4.rra swizzling (equivalent to double4.xxw).
        /// </summary>
        public double3 rra => new double3(x, x, w);

        /// <summary>
        /// Returns double4.xxwx swizzling.
        /// </summary>
        public double4 xxwx => new double4(x, x, w, x);

        /// <summary>
        /// Returns double4.rrar swizzling (equivalent to double4.xxwx).
        /// </summary>
        public double4 rrar => new double4(x, x, w, x);

        /// <summary>
        /// Returns double4.xxwy swizzling.
        /// </summary>
        public double4 xxwy => new double4(x, x, w, y);

        /// <summary>
        /// Returns double4.rrag swizzling (equivalent to double4.xxwy).
        /// </summary>
        public double4 rrag => new double4(x, x, w, y);

        /// <summary>
        /// Returns double4.xxwz swizzling.
        /// </summary>
        public double4 xxwz => new double4(x, x, w, z);

        /// <summary>
        /// Returns double4.rrab swizzling (equivalent to double4.xxwz).
        /// </summary>
        public double4 rrab => new double4(x, x, w, z);

        /// <summary>
        /// Returns double4.xxww swizzling.
        /// </summary>
        public double4 xxww => new double4(x, x, w, w);

        /// <summary>
        /// Returns double4.rraa swizzling (equivalent to double4.xxww).
        /// </summary>
        public double4 rraa => new double4(x, x, w, w);

        /// <summary>
        /// Returns double4.xy swizzling.
        /// </summary>
        public double2 xy => new double2(x, y);

        /// <summary>
        /// Returns double4.rg swizzling (equivalent to double4.xy).
        /// </summary>
        public double2 rg => new double2(x, y);

        /// <summary>
        /// Returns double4.xyx swizzling.
        /// </summary>
        public double3 xyx => new double3(x, y, x);

        /// <summary>
        /// Returns double4.rgr swizzling (equivalent to double4.xyx).
        /// </summary>
        public double3 rgr => new double3(x, y, x);

        /// <summary>
        /// Returns double4.xyxx swizzling.
        /// </summary>
        public double4 xyxx => new double4(x, y, x, x);

        /// <summary>
        /// Returns double4.rgrr swizzling (equivalent to double4.xyxx).
        /// </summary>
        public double4 rgrr => new double4(x, y, x, x);

        /// <summary>
        /// Returns double4.xyxy swizzling.
        /// </summary>
        public double4 xyxy => new double4(x, y, x, y);

        /// <summary>
        /// Returns double4.rgrg swizzling (equivalent to double4.xyxy).
        /// </summary>
        public double4 rgrg => new double4(x, y, x, y);

        /// <summary>
        /// Returns double4.xyxz swizzling.
        /// </summary>
        public double4 xyxz => new double4(x, y, x, z);

        /// <summary>
        /// Returns double4.rgrb swizzling (equivalent to double4.xyxz).
        /// </summary>
        public double4 rgrb => new double4(x, y, x, z);

        /// <summary>
        /// Returns double4.xyxw swizzling.
        /// </summary>
        public double4 xyxw => new double4(x, y, x, w);

        /// <summary>
        /// Returns double4.rgra swizzling (equivalent to double4.xyxw).
        /// </summary>
        public double4 rgra => new double4(x, y, x, w);

        /// <summary>
        /// Returns double4.xyy swizzling.
        /// </summary>
        public double3 xyy => new double3(x, y, y);

        /// <summary>
        /// Returns double4.rgg swizzling (equivalent to double4.xyy).
        /// </summary>
        public double3 rgg => new double3(x, y, y);

        /// <summary>
        /// Returns double4.xyyx swizzling.
        /// </summary>
        public double4 xyyx => new double4(x, y, y, x);

        /// <summary>
        /// Returns double4.rggr swizzling (equivalent to double4.xyyx).
        /// </summary>
        public double4 rggr => new double4(x, y, y, x);

        /// <summary>
        /// Returns double4.xyyy swizzling.
        /// </summary>
        public double4 xyyy => new double4(x, y, y, y);

        /// <summary>
        /// Returns double4.rggg swizzling (equivalent to double4.xyyy).
        /// </summary>
        public double4 rggg => new double4(x, y, y, y);

        /// <summary>
        /// Returns double4.xyyz swizzling.
        /// </summary>
        public double4 xyyz => new double4(x, y, y, z);

        /// <summary>
        /// Returns double4.rggb swizzling (equivalent to double4.xyyz).
        /// </summary>
        public double4 rggb => new double4(x, y, y, z);

        /// <summary>
        /// Returns double4.xyyw swizzling.
        /// </summary>
        public double4 xyyw => new double4(x, y, y, w);

        /// <summary>
        /// Returns double4.rgga swizzling (equivalent to double4.xyyw).
        /// </summary>
        public double4 rgga => new double4(x, y, y, w);

        /// <summary>
        /// Returns double4.xyz swizzling.
        /// </summary>
        public double3 xyz => new double3(x, y, z);

        /// <summary>
        /// Returns double4.rgb swizzling (equivalent to double4.xyz).
        /// </summary>
        public double3 rgb => new double3(x, y, z);

        /// <summary>
        /// Returns double4.xyzx swizzling.
        /// </summary>
        public double4 xyzx => new double4(x, y, z, x);

        /// <summary>
        /// Returns double4.rgbr swizzling (equivalent to double4.xyzx).
        /// </summary>
        public double4 rgbr => new double4(x, y, z, x);

        /// <summary>
        /// Returns double4.xyzy swizzling.
        /// </summary>
        public double4 xyzy => new double4(x, y, z, y);

        /// <summary>
        /// Returns double4.rgbg swizzling (equivalent to double4.xyzy).
        /// </summary>
        public double4 rgbg => new double4(x, y, z, y);

        /// <summary>
        /// Returns double4.xyzz swizzling.
        /// </summary>
        public double4 xyzz => new double4(x, y, z, z);

        /// <summary>
        /// Returns double4.rgbb swizzling (equivalent to double4.xyzz).
        /// </summary>
        public double4 rgbb => new double4(x, y, z, z);

        /// <summary>
        /// Returns double4.xyzw swizzling.
        /// </summary>
        public double4 xyzw => new double4(x, y, z, w);

        /// <summary>
        /// Returns double4.rgba swizzling (equivalent to double4.xyzw).
        /// </summary>
        public double4 rgba => new double4(x, y, z, w);

        /// <summary>
        /// Returns double4.xyw swizzling.
        /// </summary>
        public double3 xyw => new double3(x, y, w);

        /// <summary>
        /// Returns double4.rga swizzling (equivalent to double4.xyw).
        /// </summary>
        public double3 rga => new double3(x, y, w);

        /// <summary>
        /// Returns double4.xywx swizzling.
        /// </summary>
        public double4 xywx => new double4(x, y, w, x);

        /// <summary>
        /// Returns double4.rgar swizzling (equivalent to double4.xywx).
        /// </summary>
        public double4 rgar => new double4(x, y, w, x);

        /// <summary>
        /// Returns double4.xywy swizzling.
        /// </summary>
        public double4 xywy => new double4(x, y, w, y);

        /// <summary>
        /// Returns double4.rgag swizzling (equivalent to double4.xywy).
        /// </summary>
        public double4 rgag => new double4(x, y, w, y);

        /// <summary>
        /// Returns double4.xywz swizzling.
        /// </summary>
        public double4 xywz => new double4(x, y, w, z);

        /// <summary>
        /// Returns double4.rgab swizzling (equivalent to double4.xywz).
        /// </summary>
        public double4 rgab => new double4(x, y, w, z);

        /// <summary>
        /// Returns double4.xyww swizzling.
        /// </summary>
        public double4 xyww => new double4(x, y, w, w);

        /// <summary>
        /// Returns double4.rgaa swizzling (equivalent to double4.xyww).
        /// </summary>
        public double4 rgaa => new double4(x, y, w, w);

        /// <summary>
        /// Returns double4.xz swizzling.
        /// </summary>
        public double2 xz => new double2(x, z);

        /// <summary>
        /// Returns double4.rb swizzling (equivalent to double4.xz).
        /// </summary>
        public double2 rb => new double2(x, z);

        /// <summary>
        /// Returns double4.xzx swizzling.
        /// </summary>
        public double3 xzx => new double3(x, z, x);

        /// <summary>
        /// Returns double4.rbr swizzling (equivalent to double4.xzx).
        /// </summary>
        public double3 rbr => new double3(x, z, x);

        /// <summary>
        /// Returns double4.xzxx swizzling.
        /// </summary>
        public double4 xzxx => new double4(x, z, x, x);

        /// <summary>
        /// Returns double4.rbrr swizzling (equivalent to double4.xzxx).
        /// </summary>
        public double4 rbrr => new double4(x, z, x, x);

        /// <summary>
        /// Returns double4.xzxy swizzling.
        /// </summary>
        public double4 xzxy => new double4(x, z, x, y);

        /// <summary>
        /// Returns double4.rbrg swizzling (equivalent to double4.xzxy).
        /// </summary>
        public double4 rbrg => new double4(x, z, x, y);

        /// <summary>
        /// Returns double4.xzxz swizzling.
        /// </summary>
        public double4 xzxz => new double4(x, z, x, z);

        /// <summary>
        /// Returns double4.rbrb swizzling (equivalent to double4.xzxz).
        /// </summary>
        public double4 rbrb => new double4(x, z, x, z);

        /// <summary>
        /// Returns double4.xzxw swizzling.
        /// </summary>
        public double4 xzxw => new double4(x, z, x, w);

        /// <summary>
        /// Returns double4.rbra swizzling (equivalent to double4.xzxw).
        /// </summary>
        public double4 rbra => new double4(x, z, x, w);

        /// <summary>
        /// Returns double4.xzy swizzling.
        /// </summary>
        public double3 xzy => new double3(x, z, y);

        /// <summary>
        /// Returns double4.rbg swizzling (equivalent to double4.xzy).
        /// </summary>
        public double3 rbg => new double3(x, z, y);

        /// <summary>
        /// Returns double4.xzyx swizzling.
        /// </summary>
        public double4 xzyx => new double4(x, z, y, x);

        /// <summary>
        /// Returns double4.rbgr swizzling (equivalent to double4.xzyx).
        /// </summary>
        public double4 rbgr => new double4(x, z, y, x);

        /// <summary>
        /// Returns double4.xzyy swizzling.
        /// </summary>
        public double4 xzyy => new double4(x, z, y, y);

        /// <summary>
        /// Returns double4.rbgg swizzling (equivalent to double4.xzyy).
        /// </summary>
        public double4 rbgg => new double4(x, z, y, y);

        /// <summary>
        /// Returns double4.xzyz swizzling.
        /// </summary>
        public double4 xzyz => new double4(x, z, y, z);

        /// <summary>
        /// Returns double4.rbgb swizzling (equivalent to double4.xzyz).
        /// </summary>
        public double4 rbgb => new double4(x, z, y, z);

        /// <summary>
        /// Returns double4.xzyw swizzling.
        /// </summary>
        public double4 xzyw => new double4(x, z, y, w);

        /// <summary>
        /// Returns double4.rbga swizzling (equivalent to double4.xzyw).
        /// </summary>
        public double4 rbga => new double4(x, z, y, w);

        /// <summary>
        /// Returns double4.xzz swizzling.
        /// </summary>
        public double3 xzz => new double3(x, z, z);

        /// <summary>
        /// Returns double4.rbb swizzling (equivalent to double4.xzz).
        /// </summary>
        public double3 rbb => new double3(x, z, z);

        /// <summary>
        /// Returns double4.xzzx swizzling.
        /// </summary>
        public double4 xzzx => new double4(x, z, z, x);

        /// <summary>
        /// Returns double4.rbbr swizzling (equivalent to double4.xzzx).
        /// </summary>
        public double4 rbbr => new double4(x, z, z, x);

        /// <summary>
        /// Returns double4.xzzy swizzling.
        /// </summary>
        public double4 xzzy => new double4(x, z, z, y);

        /// <summary>
        /// Returns double4.rbbg swizzling (equivalent to double4.xzzy).
        /// </summary>
        public double4 rbbg => new double4(x, z, z, y);

        /// <summary>
        /// Returns double4.xzzz swizzling.
        /// </summary>
        public double4 xzzz => new double4(x, z, z, z);

        /// <summary>
        /// Returns double4.rbbb swizzling (equivalent to double4.xzzz).
        /// </summary>
        public double4 rbbb => new double4(x, z, z, z);

        /// <summary>
        /// Returns double4.xzzw swizzling.
        /// </summary>
        public double4 xzzw => new double4(x, z, z, w);

        /// <summary>
        /// Returns double4.rbba swizzling (equivalent to double4.xzzw).
        /// </summary>
        public double4 rbba => new double4(x, z, z, w);

        /// <summary>
        /// Returns double4.xzw swizzling.
        /// </summary>
        public double3 xzw => new double3(x, z, w);

        /// <summary>
        /// Returns double4.rba swizzling (equivalent to double4.xzw).
        /// </summary>
        public double3 rba => new double3(x, z, w);

        /// <summary>
        /// Returns double4.xzwx swizzling.
        /// </summary>
        public double4 xzwx => new double4(x, z, w, x);

        /// <summary>
        /// Returns double4.rbar swizzling (equivalent to double4.xzwx).
        /// </summary>
        public double4 rbar => new double4(x, z, w, x);

        /// <summary>
        /// Returns double4.xzwy swizzling.
        /// </summary>
        public double4 xzwy => new double4(x, z, w, y);

        /// <summary>
        /// Returns double4.rbag swizzling (equivalent to double4.xzwy).
        /// </summary>
        public double4 rbag => new double4(x, z, w, y);

        /// <summary>
        /// Returns double4.xzwz swizzling.
        /// </summary>
        public double4 xzwz => new double4(x, z, w, z);

        /// <summary>
        /// Returns double4.rbab swizzling (equivalent to double4.xzwz).
        /// </summary>
        public double4 rbab => new double4(x, z, w, z);

        /// <summary>
        /// Returns double4.xzww swizzling.
        /// </summary>
        public double4 xzww => new double4(x, z, w, w);

        /// <summary>
        /// Returns double4.rbaa swizzling (equivalent to double4.xzww).
        /// </summary>
        public double4 rbaa => new double4(x, z, w, w);

        /// <summary>
        /// Returns double4.xw swizzling.
        /// </summary>
        public double2 xw => new double2(x, w);

        /// <summary>
        /// Returns double4.ra swizzling (equivalent to double4.xw).
        /// </summary>
        public double2 ra => new double2(x, w);

        /// <summary>
        /// Returns double4.xwx swizzling.
        /// </summary>
        public double3 xwx => new double3(x, w, x);

        /// <summary>
        /// Returns double4.rar swizzling (equivalent to double4.xwx).
        /// </summary>
        public double3 rar => new double3(x, w, x);

        /// <summary>
        /// Returns double4.xwxx swizzling.
        /// </summary>
        public double4 xwxx => new double4(x, w, x, x);

        /// <summary>
        /// Returns double4.rarr swizzling (equivalent to double4.xwxx).
        /// </summary>
        public double4 rarr => new double4(x, w, x, x);

        /// <summary>
        /// Returns double4.xwxy swizzling.
        /// </summary>
        public double4 xwxy => new double4(x, w, x, y);

        /// <summary>
        /// Returns double4.rarg swizzling (equivalent to double4.xwxy).
        /// </summary>
        public double4 rarg => new double4(x, w, x, y);

        /// <summary>
        /// Returns double4.xwxz swizzling.
        /// </summary>
        public double4 xwxz => new double4(x, w, x, z);

        /// <summary>
        /// Returns double4.rarb swizzling (equivalent to double4.xwxz).
        /// </summary>
        public double4 rarb => new double4(x, w, x, z);

        /// <summary>
        /// Returns double4.xwxw swizzling.
        /// </summary>
        public double4 xwxw => new double4(x, w, x, w);

        /// <summary>
        /// Returns double4.rara swizzling (equivalent to double4.xwxw).
        /// </summary>
        public double4 rara => new double4(x, w, x, w);

        /// <summary>
        /// Returns double4.xwy swizzling.
        /// </summary>
        public double3 xwy => new double3(x, w, y);

        /// <summary>
        /// Returns double4.rag swizzling (equivalent to double4.xwy).
        /// </summary>
        public double3 rag => new double3(x, w, y);

        /// <summary>
        /// Returns double4.xwyx swizzling.
        /// </summary>
        public double4 xwyx => new double4(x, w, y, x);

        /// <summary>
        /// Returns double4.ragr swizzling (equivalent to double4.xwyx).
        /// </summary>
        public double4 ragr => new double4(x, w, y, x);

        /// <summary>
        /// Returns double4.xwyy swizzling.
        /// </summary>
        public double4 xwyy => new double4(x, w, y, y);

        /// <summary>
        /// Returns double4.ragg swizzling (equivalent to double4.xwyy).
        /// </summary>
        public double4 ragg => new double4(x, w, y, y);

        /// <summary>
        /// Returns double4.xwyz swizzling.
        /// </summary>
        public double4 xwyz => new double4(x, w, y, z);

        /// <summary>
        /// Returns double4.ragb swizzling (equivalent to double4.xwyz).
        /// </summary>
        public double4 ragb => new double4(x, w, y, z);

        /// <summary>
        /// Returns double4.xwyw swizzling.
        /// </summary>
        public double4 xwyw => new double4(x, w, y, w);

        /// <summary>
        /// Returns double4.raga swizzling (equivalent to double4.xwyw).
        /// </summary>
        public double4 raga => new double4(x, w, y, w);

        /// <summary>
        /// Returns double4.xwz swizzling.
        /// </summary>
        public double3 xwz => new double3(x, w, z);

        /// <summary>
        /// Returns double4.rab swizzling (equivalent to double4.xwz).
        /// </summary>
        public double3 rab => new double3(x, w, z);

        /// <summary>
        /// Returns double4.xwzx swizzling.
        /// </summary>
        public double4 xwzx => new double4(x, w, z, x);

        /// <summary>
        /// Returns double4.rabr swizzling (equivalent to double4.xwzx).
        /// </summary>
        public double4 rabr => new double4(x, w, z, x);

        /// <summary>
        /// Returns double4.xwzy swizzling.
        /// </summary>
        public double4 xwzy => new double4(x, w, z, y);

        /// <summary>
        /// Returns double4.rabg swizzling (equivalent to double4.xwzy).
        /// </summary>
        public double4 rabg => new double4(x, w, z, y);

        /// <summary>
        /// Returns double4.xwzz swizzling.
        /// </summary>
        public double4 xwzz => new double4(x, w, z, z);

        /// <summary>
        /// Returns double4.rabb swizzling (equivalent to double4.xwzz).
        /// </summary>
        public double4 rabb => new double4(x, w, z, z);

        /// <summary>
        /// Returns double4.xwzw swizzling.
        /// </summary>
        public double4 xwzw => new double4(x, w, z, w);

        /// <summary>
        /// Returns double4.raba swizzling (equivalent to double4.xwzw).
        /// </summary>
        public double4 raba => new double4(x, w, z, w);

        /// <summary>
        /// Returns double4.xww swizzling.
        /// </summary>
        public double3 xww => new double3(x, w, w);

        /// <summary>
        /// Returns double4.raa swizzling (equivalent to double4.xww).
        /// </summary>
        public double3 raa => new double3(x, w, w);

        /// <summary>
        /// Returns double4.xwwx swizzling.
        /// </summary>
        public double4 xwwx => new double4(x, w, w, x);

        /// <summary>
        /// Returns double4.raar swizzling (equivalent to double4.xwwx).
        /// </summary>
        public double4 raar => new double4(x, w, w, x);

        /// <summary>
        /// Returns double4.xwwy swizzling.
        /// </summary>
        public double4 xwwy => new double4(x, w, w, y);

        /// <summary>
        /// Returns double4.raag swizzling (equivalent to double4.xwwy).
        /// </summary>
        public double4 raag => new double4(x, w, w, y);

        /// <summary>
        /// Returns double4.xwwz swizzling.
        /// </summary>
        public double4 xwwz => new double4(x, w, w, z);

        /// <summary>
        /// Returns double4.raab swizzling (equivalent to double4.xwwz).
        /// </summary>
        public double4 raab => new double4(x, w, w, z);

        /// <summary>
        /// Returns double4.xwww swizzling.
        /// </summary>
        public double4 xwww => new double4(x, w, w, w);

        /// <summary>
        /// Returns double4.raaa swizzling (equivalent to double4.xwww).
        /// </summary>
        public double4 raaa => new double4(x, w, w, w);

        /// <summary>
        /// Returns double4.yx swizzling.
        /// </summary>
        public double2 yx => new double2(y, x);

        /// <summary>
        /// Returns double4.gr swizzling (equivalent to double4.yx).
        /// </summary>
        public double2 gr => new double2(y, x);

        /// <summary>
        /// Returns double4.yxx swizzling.
        /// </summary>
        public double3 yxx => new double3(y, x, x);

        /// <summary>
        /// Returns double4.grr swizzling (equivalent to double4.yxx).
        /// </summary>
        public double3 grr => new double3(y, x, x);

        /// <summary>
        /// Returns double4.yxxx swizzling.
        /// </summary>
        public double4 yxxx => new double4(y, x, x, x);

        /// <summary>
        /// Returns double4.grrr swizzling (equivalent to double4.yxxx).
        /// </summary>
        public double4 grrr => new double4(y, x, x, x);

        /// <summary>
        /// Returns double4.yxxy swizzling.
        /// </summary>
        public double4 yxxy => new double4(y, x, x, y);

        /// <summary>
        /// Returns double4.grrg swizzling (equivalent to double4.yxxy).
        /// </summary>
        public double4 grrg => new double4(y, x, x, y);

        /// <summary>
        /// Returns double4.yxxz swizzling.
        /// </summary>
        public double4 yxxz => new double4(y, x, x, z);

        /// <summary>
        /// Returns double4.grrb swizzling (equivalent to double4.yxxz).
        /// </summary>
        public double4 grrb => new double4(y, x, x, z);

        /// <summary>
        /// Returns double4.yxxw swizzling.
        /// </summary>
        public double4 yxxw => new double4(y, x, x, w);

        /// <summary>
        /// Returns double4.grra swizzling (equivalent to double4.yxxw).
        /// </summary>
        public double4 grra => new double4(y, x, x, w);

        /// <summary>
        /// Returns double4.yxy swizzling.
        /// </summary>
        public double3 yxy => new double3(y, x, y);

        /// <summary>
        /// Returns double4.grg swizzling (equivalent to double4.yxy).
        /// </summary>
        public double3 grg => new double3(y, x, y);

        /// <summary>
        /// Returns double4.yxyx swizzling.
        /// </summary>
        public double4 yxyx => new double4(y, x, y, x);

        /// <summary>
        /// Returns double4.grgr swizzling (equivalent to double4.yxyx).
        /// </summary>
        public double4 grgr => new double4(y, x, y, x);

        /// <summary>
        /// Returns double4.yxyy swizzling.
        /// </summary>
        public double4 yxyy => new double4(y, x, y, y);

        /// <summary>
        /// Returns double4.grgg swizzling (equivalent to double4.yxyy).
        /// </summary>
        public double4 grgg => new double4(y, x, y, y);

        /// <summary>
        /// Returns double4.yxyz swizzling.
        /// </summary>
        public double4 yxyz => new double4(y, x, y, z);

        /// <summary>
        /// Returns double4.grgb swizzling (equivalent to double4.yxyz).
        /// </summary>
        public double4 grgb => new double4(y, x, y, z);

        /// <summary>
        /// Returns double4.yxyw swizzling.
        /// </summary>
        public double4 yxyw => new double4(y, x, y, w);

        /// <summary>
        /// Returns double4.grga swizzling (equivalent to double4.yxyw).
        /// </summary>
        public double4 grga => new double4(y, x, y, w);

        /// <summary>
        /// Returns double4.yxz swizzling.
        /// </summary>
        public double3 yxz => new double3(y, x, z);

        /// <summary>
        /// Returns double4.grb swizzling (equivalent to double4.yxz).
        /// </summary>
        public double3 grb => new double3(y, x, z);

        /// <summary>
        /// Returns double4.yxzx swizzling.
        /// </summary>
        public double4 yxzx => new double4(y, x, z, x);

        /// <summary>
        /// Returns double4.grbr swizzling (equivalent to double4.yxzx).
        /// </summary>
        public double4 grbr => new double4(y, x, z, x);

        /// <summary>
        /// Returns double4.yxzy swizzling.
        /// </summary>
        public double4 yxzy => new double4(y, x, z, y);

        /// <summary>
        /// Returns double4.grbg swizzling (equivalent to double4.yxzy).
        /// </summary>
        public double4 grbg => new double4(y, x, z, y);

        /// <summary>
        /// Returns double4.yxzz swizzling.
        /// </summary>
        public double4 yxzz => new double4(y, x, z, z);

        /// <summary>
        /// Returns double4.grbb swizzling (equivalent to double4.yxzz).
        /// </summary>
        public double4 grbb => new double4(y, x, z, z);

        /// <summary>
        /// Returns double4.yxzw swizzling.
        /// </summary>
        public double4 yxzw => new double4(y, x, z, w);

        /// <summary>
        /// Returns double4.grba swizzling (equivalent to double4.yxzw).
        /// </summary>
        public double4 grba => new double4(y, x, z, w);

        /// <summary>
        /// Returns double4.yxw swizzling.
        /// </summary>
        public double3 yxw => new double3(y, x, w);

        /// <summary>
        /// Returns double4.gra swizzling (equivalent to double4.yxw).
        /// </summary>
        public double3 gra => new double3(y, x, w);

        /// <summary>
        /// Returns double4.yxwx swizzling.
        /// </summary>
        public double4 yxwx => new double4(y, x, w, x);

        /// <summary>
        /// Returns double4.grar swizzling (equivalent to double4.yxwx).
        /// </summary>
        public double4 grar => new double4(y, x, w, x);

        /// <summary>
        /// Returns double4.yxwy swizzling.
        /// </summary>
        public double4 yxwy => new double4(y, x, w, y);

        /// <summary>
        /// Returns double4.grag swizzling (equivalent to double4.yxwy).
        /// </summary>
        public double4 grag => new double4(y, x, w, y);

        /// <summary>
        /// Returns double4.yxwz swizzling.
        /// </summary>
        public double4 yxwz => new double4(y, x, w, z);

        /// <summary>
        /// Returns double4.grab swizzling (equivalent to double4.yxwz).
        /// </summary>
        public double4 grab => new double4(y, x, w, z);

        /// <summary>
        /// Returns double4.yxww swizzling.
        /// </summary>
        public double4 yxww => new double4(y, x, w, w);

        /// <summary>
        /// Returns double4.graa swizzling (equivalent to double4.yxww).
        /// </summary>
        public double4 graa => new double4(y, x, w, w);

        /// <summary>
        /// Returns double4.yy swizzling.
        /// </summary>
        public double2 yy => new double2(y, y);

        /// <summary>
        /// Returns double4.gg swizzling (equivalent to double4.yy).
        /// </summary>
        public double2 gg => new double2(y, y);

        /// <summary>
        /// Returns double4.yyx swizzling.
        /// </summary>
        public double3 yyx => new double3(y, y, x);

        /// <summary>
        /// Returns double4.ggr swizzling (equivalent to double4.yyx).
        /// </summary>
        public double3 ggr => new double3(y, y, x);

        /// <summary>
        /// Returns double4.yyxx swizzling.
        /// </summary>
        public double4 yyxx => new double4(y, y, x, x);

        /// <summary>
        /// Returns double4.ggrr swizzling (equivalent to double4.yyxx).
        /// </summary>
        public double4 ggrr => new double4(y, y, x, x);

        /// <summary>
        /// Returns double4.yyxy swizzling.
        /// </summary>
        public double4 yyxy => new double4(y, y, x, y);

        /// <summary>
        /// Returns double4.ggrg swizzling (equivalent to double4.yyxy).
        /// </summary>
        public double4 ggrg => new double4(y, y, x, y);

        /// <summary>
        /// Returns double4.yyxz swizzling.
        /// </summary>
        public double4 yyxz => new double4(y, y, x, z);

        /// <summary>
        /// Returns double4.ggrb swizzling (equivalent to double4.yyxz).
        /// </summary>
        public double4 ggrb => new double4(y, y, x, z);

        /// <summary>
        /// Returns double4.yyxw swizzling.
        /// </summary>
        public double4 yyxw => new double4(y, y, x, w);

        /// <summary>
        /// Returns double4.ggra swizzling (equivalent to double4.yyxw).
        /// </summary>
        public double4 ggra => new double4(y, y, x, w);

        /// <summary>
        /// Returns double4.yyy swizzling.
        /// </summary>
        public double3 yyy => new double3(y, y, y);

        /// <summary>
        /// Returns double4.ggg swizzling (equivalent to double4.yyy).
        /// </summary>
        public double3 ggg => new double3(y, y, y);

        /// <summary>
        /// Returns double4.yyyx swizzling.
        /// </summary>
        public double4 yyyx => new double4(y, y, y, x);

        /// <summary>
        /// Returns double4.gggr swizzling (equivalent to double4.yyyx).
        /// </summary>
        public double4 gggr => new double4(y, y, y, x);

        /// <summary>
        /// Returns double4.yyyy swizzling.
        /// </summary>
        public double4 yyyy => new double4(y, y, y, y);

        /// <summary>
        /// Returns double4.gggg swizzling (equivalent to double4.yyyy).
        /// </summary>
        public double4 gggg => new double4(y, y, y, y);

        /// <summary>
        /// Returns double4.yyyz swizzling.
        /// </summary>
        public double4 yyyz => new double4(y, y, y, z);

        /// <summary>
        /// Returns double4.gggb swizzling (equivalent to double4.yyyz).
        /// </summary>
        public double4 gggb => new double4(y, y, y, z);

        /// <summary>
        /// Returns double4.yyyw swizzling.
        /// </summary>
        public double4 yyyw => new double4(y, y, y, w);

        /// <summary>
        /// Returns double4.ggga swizzling (equivalent to double4.yyyw).
        /// </summary>
        public double4 ggga => new double4(y, y, y, w);

        /// <summary>
        /// Returns double4.yyz swizzling.
        /// </summary>
        public double3 yyz => new double3(y, y, z);

        /// <summary>
        /// Returns double4.ggb swizzling (equivalent to double4.yyz).
        /// </summary>
        public double3 ggb => new double3(y, y, z);

        /// <summary>
        /// Returns double4.yyzx swizzling.
        /// </summary>
        public double4 yyzx => new double4(y, y, z, x);

        /// <summary>
        /// Returns double4.ggbr swizzling (equivalent to double4.yyzx).
        /// </summary>
        public double4 ggbr => new double4(y, y, z, x);

        /// <summary>
        /// Returns double4.yyzy swizzling.
        /// </summary>
        public double4 yyzy => new double4(y, y, z, y);

        /// <summary>
        /// Returns double4.ggbg swizzling (equivalent to double4.yyzy).
        /// </summary>
        public double4 ggbg => new double4(y, y, z, y);

        /// <summary>
        /// Returns double4.yyzz swizzling.
        /// </summary>
        public double4 yyzz => new double4(y, y, z, z);

        /// <summary>
        /// Returns double4.ggbb swizzling (equivalent to double4.yyzz).
        /// </summary>
        public double4 ggbb => new double4(y, y, z, z);

        /// <summary>
        /// Returns double4.yyzw swizzling.
        /// </summary>
        public double4 yyzw => new double4(y, y, z, w);

        /// <summary>
        /// Returns double4.ggba swizzling (equivalent to double4.yyzw).
        /// </summary>
        public double4 ggba => new double4(y, y, z, w);

        /// <summary>
        /// Returns double4.yyw swizzling.
        /// </summary>
        public double3 yyw => new double3(y, y, w);

        /// <summary>
        /// Returns double4.gga swizzling (equivalent to double4.yyw).
        /// </summary>
        public double3 gga => new double3(y, y, w);

        /// <summary>
        /// Returns double4.yywx swizzling.
        /// </summary>
        public double4 yywx => new double4(y, y, w, x);

        /// <summary>
        /// Returns double4.ggar swizzling (equivalent to double4.yywx).
        /// </summary>
        public double4 ggar => new double4(y, y, w, x);

        /// <summary>
        /// Returns double4.yywy swizzling.
        /// </summary>
        public double4 yywy => new double4(y, y, w, y);

        /// <summary>
        /// Returns double4.ggag swizzling (equivalent to double4.yywy).
        /// </summary>
        public double4 ggag => new double4(y, y, w, y);

        /// <summary>
        /// Returns double4.yywz swizzling.
        /// </summary>
        public double4 yywz => new double4(y, y, w, z);

        /// <summary>
        /// Returns double4.ggab swizzling (equivalent to double4.yywz).
        /// </summary>
        public double4 ggab => new double4(y, y, w, z);

        /// <summary>
        /// Returns double4.yyww swizzling.
        /// </summary>
        public double4 yyww => new double4(y, y, w, w);

        /// <summary>
        /// Returns double4.ggaa swizzling (equivalent to double4.yyww).
        /// </summary>
        public double4 ggaa => new double4(y, y, w, w);

        /// <summary>
        /// Returns double4.yz swizzling.
        /// </summary>
        public double2 yz => new double2(y, z);

        /// <summary>
        /// Returns double4.gb swizzling (equivalent to double4.yz).
        /// </summary>
        public double2 gb => new double2(y, z);

        /// <summary>
        /// Returns double4.yzx swizzling.
        /// </summary>
        public double3 yzx => new double3(y, z, x);

        /// <summary>
        /// Returns double4.gbr swizzling (equivalent to double4.yzx).
        /// </summary>
        public double3 gbr => new double3(y, z, x);

        /// <summary>
        /// Returns double4.yzxx swizzling.
        /// </summary>
        public double4 yzxx => new double4(y, z, x, x);

        /// <summary>
        /// Returns double4.gbrr swizzling (equivalent to double4.yzxx).
        /// </summary>
        public double4 gbrr => new double4(y, z, x, x);

        /// <summary>
        /// Returns double4.yzxy swizzling.
        /// </summary>
        public double4 yzxy => new double4(y, z, x, y);

        /// <summary>
        /// Returns double4.gbrg swizzling (equivalent to double4.yzxy).
        /// </summary>
        public double4 gbrg => new double4(y, z, x, y);

        /// <summary>
        /// Returns double4.yzxz swizzling.
        /// </summary>
        public double4 yzxz => new double4(y, z, x, z);

        /// <summary>
        /// Returns double4.gbrb swizzling (equivalent to double4.yzxz).
        /// </summary>
        public double4 gbrb => new double4(y, z, x, z);

        /// <summary>
        /// Returns double4.yzxw swizzling.
        /// </summary>
        public double4 yzxw => new double4(y, z, x, w);

        /// <summary>
        /// Returns double4.gbra swizzling (equivalent to double4.yzxw).
        /// </summary>
        public double4 gbra => new double4(y, z, x, w);

        /// <summary>
        /// Returns double4.yzy swizzling.
        /// </summary>
        public double3 yzy => new double3(y, z, y);

        /// <summary>
        /// Returns double4.gbg swizzling (equivalent to double4.yzy).
        /// </summary>
        public double3 gbg => new double3(y, z, y);

        /// <summary>
        /// Returns double4.yzyx swizzling.
        /// </summary>
        public double4 yzyx => new double4(y, z, y, x);

        /// <summary>
        /// Returns double4.gbgr swizzling (equivalent to double4.yzyx).
        /// </summary>
        public double4 gbgr => new double4(y, z, y, x);

        /// <summary>
        /// Returns double4.yzyy swizzling.
        /// </summary>
        public double4 yzyy => new double4(y, z, y, y);

        /// <summary>
        /// Returns double4.gbgg swizzling (equivalent to double4.yzyy).
        /// </summary>
        public double4 gbgg => new double4(y, z, y, y);

        /// <summary>
        /// Returns double4.yzyz swizzling.
        /// </summary>
        public double4 yzyz => new double4(y, z, y, z);

        /// <summary>
        /// Returns double4.gbgb swizzling (equivalent to double4.yzyz).
        /// </summary>
        public double4 gbgb => new double4(y, z, y, z);

        /// <summary>
        /// Returns double4.yzyw swizzling.
        /// </summary>
        public double4 yzyw => new double4(y, z, y, w);

        /// <summary>
        /// Returns double4.gbga swizzling (equivalent to double4.yzyw).
        /// </summary>
        public double4 gbga => new double4(y, z, y, w);

        /// <summary>
        /// Returns double4.yzz swizzling.
        /// </summary>
        public double3 yzz => new double3(y, z, z);

        /// <summary>
        /// Returns double4.gbb swizzling (equivalent to double4.yzz).
        /// </summary>
        public double3 gbb => new double3(y, z, z);

        /// <summary>
        /// Returns double4.yzzx swizzling.
        /// </summary>
        public double4 yzzx => new double4(y, z, z, x);

        /// <summary>
        /// Returns double4.gbbr swizzling (equivalent to double4.yzzx).
        /// </summary>
        public double4 gbbr => new double4(y, z, z, x);

        /// <summary>
        /// Returns double4.yzzy swizzling.
        /// </summary>
        public double4 yzzy => new double4(y, z, z, y);

        /// <summary>
        /// Returns double4.gbbg swizzling (equivalent to double4.yzzy).
        /// </summary>
        public double4 gbbg => new double4(y, z, z, y);

        /// <summary>
        /// Returns double4.yzzz swizzling.
        /// </summary>
        public double4 yzzz => new double4(y, z, z, z);

        /// <summary>
        /// Returns double4.gbbb swizzling (equivalent to double4.yzzz).
        /// </summary>
        public double4 gbbb => new double4(y, z, z, z);

        /// <summary>
        /// Returns double4.yzzw swizzling.
        /// </summary>
        public double4 yzzw => new double4(y, z, z, w);

        /// <summary>
        /// Returns double4.gbba swizzling (equivalent to double4.yzzw).
        /// </summary>
        public double4 gbba => new double4(y, z, z, w);

        /// <summary>
        /// Returns double4.yzw swizzling.
        /// </summary>
        public double3 yzw => new double3(y, z, w);

        /// <summary>
        /// Returns double4.gba swizzling (equivalent to double4.yzw).
        /// </summary>
        public double3 gba => new double3(y, z, w);

        /// <summary>
        /// Returns double4.yzwx swizzling.
        /// </summary>
        public double4 yzwx => new double4(y, z, w, x);

        /// <summary>
        /// Returns double4.gbar swizzling (equivalent to double4.yzwx).
        /// </summary>
        public double4 gbar => new double4(y, z, w, x);

        /// <summary>
        /// Returns double4.yzwy swizzling.
        /// </summary>
        public double4 yzwy => new double4(y, z, w, y);

        /// <summary>
        /// Returns double4.gbag swizzling (equivalent to double4.yzwy).
        /// </summary>
        public double4 gbag => new double4(y, z, w, y);

        /// <summary>
        /// Returns double4.yzwz swizzling.
        /// </summary>
        public double4 yzwz => new double4(y, z, w, z);

        /// <summary>
        /// Returns double4.gbab swizzling (equivalent to double4.yzwz).
        /// </summary>
        public double4 gbab => new double4(y, z, w, z);

        /// <summary>
        /// Returns double4.yzww swizzling.
        /// </summary>
        public double4 yzww => new double4(y, z, w, w);

        /// <summary>
        /// Returns double4.gbaa swizzling (equivalent to double4.yzww).
        /// </summary>
        public double4 gbaa => new double4(y, z, w, w);

        /// <summary>
        /// Returns double4.yw swizzling.
        /// </summary>
        public double2 yw => new double2(y, w);

        /// <summary>
        /// Returns double4.ga swizzling (equivalent to double4.yw).
        /// </summary>
        public double2 ga => new double2(y, w);

        /// <summary>
        /// Returns double4.ywx swizzling.
        /// </summary>
        public double3 ywx => new double3(y, w, x);

        /// <summary>
        /// Returns double4.gar swizzling (equivalent to double4.ywx).
        /// </summary>
        public double3 gar => new double3(y, w, x);

        /// <summary>
        /// Returns double4.ywxx swizzling.
        /// </summary>
        public double4 ywxx => new double4(y, w, x, x);

        /// <summary>
        /// Returns double4.garr swizzling (equivalent to double4.ywxx).
        /// </summary>
        public double4 garr => new double4(y, w, x, x);

        /// <summary>
        /// Returns double4.ywxy swizzling.
        /// </summary>
        public double4 ywxy => new double4(y, w, x, y);

        /// <summary>
        /// Returns double4.garg swizzling (equivalent to double4.ywxy).
        /// </summary>
        public double4 garg => new double4(y, w, x, y);

        /// <summary>
        /// Returns double4.ywxz swizzling.
        /// </summary>
        public double4 ywxz => new double4(y, w, x, z);

        /// <summary>
        /// Returns double4.garb swizzling (equivalent to double4.ywxz).
        /// </summary>
        public double4 garb => new double4(y, w, x, z);

        /// <summary>
        /// Returns double4.ywxw swizzling.
        /// </summary>
        public double4 ywxw => new double4(y, w, x, w);

        /// <summary>
        /// Returns double4.gara swizzling (equivalent to double4.ywxw).
        /// </summary>
        public double4 gara => new double4(y, w, x, w);

        /// <summary>
        /// Returns double4.ywy swizzling.
        /// </summary>
        public double3 ywy => new double3(y, w, y);

        /// <summary>
        /// Returns double4.gag swizzling (equivalent to double4.ywy).
        /// </summary>
        public double3 gag => new double3(y, w, y);

        /// <summary>
        /// Returns double4.ywyx swizzling.
        /// </summary>
        public double4 ywyx => new double4(y, w, y, x);

        /// <summary>
        /// Returns double4.gagr swizzling (equivalent to double4.ywyx).
        /// </summary>
        public double4 gagr => new double4(y, w, y, x);

        /// <summary>
        /// Returns double4.ywyy swizzling.
        /// </summary>
        public double4 ywyy => new double4(y, w, y, y);

        /// <summary>
        /// Returns double4.gagg swizzling (equivalent to double4.ywyy).
        /// </summary>
        public double4 gagg => new double4(y, w, y, y);

        /// <summary>
        /// Returns double4.ywyz swizzling.
        /// </summary>
        public double4 ywyz => new double4(y, w, y, z);

        /// <summary>
        /// Returns double4.gagb swizzling (equivalent to double4.ywyz).
        /// </summary>
        public double4 gagb => new double4(y, w, y, z);

        /// <summary>
        /// Returns double4.ywyw swizzling.
        /// </summary>
        public double4 ywyw => new double4(y, w, y, w);

        /// <summary>
        /// Returns double4.gaga swizzling (equivalent to double4.ywyw).
        /// </summary>
        public double4 gaga => new double4(y, w, y, w);

        /// <summary>
        /// Returns double4.ywz swizzling.
        /// </summary>
        public double3 ywz => new double3(y, w, z);

        /// <summary>
        /// Returns double4.gab swizzling (equivalent to double4.ywz).
        /// </summary>
        public double3 gab => new double3(y, w, z);

        /// <summary>
        /// Returns double4.ywzx swizzling.
        /// </summary>
        public double4 ywzx => new double4(y, w, z, x);

        /// <summary>
        /// Returns double4.gabr swizzling (equivalent to double4.ywzx).
        /// </summary>
        public double4 gabr => new double4(y, w, z, x);

        /// <summary>
        /// Returns double4.ywzy swizzling.
        /// </summary>
        public double4 ywzy => new double4(y, w, z, y);

        /// <summary>
        /// Returns double4.gabg swizzling (equivalent to double4.ywzy).
        /// </summary>
        public double4 gabg => new double4(y, w, z, y);

        /// <summary>
        /// Returns double4.ywzz swizzling.
        /// </summary>
        public double4 ywzz => new double4(y, w, z, z);

        /// <summary>
        /// Returns double4.gabb swizzling (equivalent to double4.ywzz).
        /// </summary>
        public double4 gabb => new double4(y, w, z, z);

        /// <summary>
        /// Returns double4.ywzw swizzling.
        /// </summary>
        public double4 ywzw => new double4(y, w, z, w);

        /// <summary>
        /// Returns double4.gaba swizzling (equivalent to double4.ywzw).
        /// </summary>
        public double4 gaba => new double4(y, w, z, w);

        /// <summary>
        /// Returns double4.yww swizzling.
        /// </summary>
        public double3 yww => new double3(y, w, w);

        /// <summary>
        /// Returns double4.gaa swizzling (equivalent to double4.yww).
        /// </summary>
        public double3 gaa => new double3(y, w, w);

        /// <summary>
        /// Returns double4.ywwx swizzling.
        /// </summary>
        public double4 ywwx => new double4(y, w, w, x);

        /// <summary>
        /// Returns double4.gaar swizzling (equivalent to double4.ywwx).
        /// </summary>
        public double4 gaar => new double4(y, w, w, x);

        /// <summary>
        /// Returns double4.ywwy swizzling.
        /// </summary>
        public double4 ywwy => new double4(y, w, w, y);

        /// <summary>
        /// Returns double4.gaag swizzling (equivalent to double4.ywwy).
        /// </summary>
        public double4 gaag => new double4(y, w, w, y);

        /// <summary>
        /// Returns double4.ywwz swizzling.
        /// </summary>
        public double4 ywwz => new double4(y, w, w, z);

        /// <summary>
        /// Returns double4.gaab swizzling (equivalent to double4.ywwz).
        /// </summary>
        public double4 gaab => new double4(y, w, w, z);

        /// <summary>
        /// Returns double4.ywww swizzling.
        /// </summary>
        public double4 ywww => new double4(y, w, w, w);

        /// <summary>
        /// Returns double4.gaaa swizzling (equivalent to double4.ywww).
        /// </summary>
        public double4 gaaa => new double4(y, w, w, w);

        /// <summary>
        /// Returns double4.zx swizzling.
        /// </summary>
        public double2 zx => new double2(z, x);

        /// <summary>
        /// Returns double4.br swizzling (equivalent to double4.zx).
        /// </summary>
        public double2 br => new double2(z, x);

        /// <summary>
        /// Returns double4.zxx swizzling.
        /// </summary>
        public double3 zxx => new double3(z, x, x);

        /// <summary>
        /// Returns double4.brr swizzling (equivalent to double4.zxx).
        /// </summary>
        public double3 brr => new double3(z, x, x);

        /// <summary>
        /// Returns double4.zxxx swizzling.
        /// </summary>
        public double4 zxxx => new double4(z, x, x, x);

        /// <summary>
        /// Returns double4.brrr swizzling (equivalent to double4.zxxx).
        /// </summary>
        public double4 brrr => new double4(z, x, x, x);

        /// <summary>
        /// Returns double4.zxxy swizzling.
        /// </summary>
        public double4 zxxy => new double4(z, x, x, y);

        /// <summary>
        /// Returns double4.brrg swizzling (equivalent to double4.zxxy).
        /// </summary>
        public double4 brrg => new double4(z, x, x, y);

        /// <summary>
        /// Returns double4.zxxz swizzling.
        /// </summary>
        public double4 zxxz => new double4(z, x, x, z);

        /// <summary>
        /// Returns double4.brrb swizzling (equivalent to double4.zxxz).
        /// </summary>
        public double4 brrb => new double4(z, x, x, z);

        /// <summary>
        /// Returns double4.zxxw swizzling.
        /// </summary>
        public double4 zxxw => new double4(z, x, x, w);

        /// <summary>
        /// Returns double4.brra swizzling (equivalent to double4.zxxw).
        /// </summary>
        public double4 brra => new double4(z, x, x, w);

        /// <summary>
        /// Returns double4.zxy swizzling.
        /// </summary>
        public double3 zxy => new double3(z, x, y);

        /// <summary>
        /// Returns double4.brg swizzling (equivalent to double4.zxy).
        /// </summary>
        public double3 brg => new double3(z, x, y);

        /// <summary>
        /// Returns double4.zxyx swizzling.
        /// </summary>
        public double4 zxyx => new double4(z, x, y, x);

        /// <summary>
        /// Returns double4.brgr swizzling (equivalent to double4.zxyx).
        /// </summary>
        public double4 brgr => new double4(z, x, y, x);

        /// <summary>
        /// Returns double4.zxyy swizzling.
        /// </summary>
        public double4 zxyy => new double4(z, x, y, y);

        /// <summary>
        /// Returns double4.brgg swizzling (equivalent to double4.zxyy).
        /// </summary>
        public double4 brgg => new double4(z, x, y, y);

        /// <summary>
        /// Returns double4.zxyz swizzling.
        /// </summary>
        public double4 zxyz => new double4(z, x, y, z);

        /// <summary>
        /// Returns double4.brgb swizzling (equivalent to double4.zxyz).
        /// </summary>
        public double4 brgb => new double4(z, x, y, z);

        /// <summary>
        /// Returns double4.zxyw swizzling.
        /// </summary>
        public double4 zxyw => new double4(z, x, y, w);

        /// <summary>
        /// Returns double4.brga swizzling (equivalent to double4.zxyw).
        /// </summary>
        public double4 brga => new double4(z, x, y, w);

        /// <summary>
        /// Returns double4.zxz swizzling.
        /// </summary>
        public double3 zxz => new double3(z, x, z);

        /// <summary>
        /// Returns double4.brb swizzling (equivalent to double4.zxz).
        /// </summary>
        public double3 brb => new double3(z, x, z);

        /// <summary>
        /// Returns double4.zxzx swizzling.
        /// </summary>
        public double4 zxzx => new double4(z, x, z, x);

        /// <summary>
        /// Returns double4.brbr swizzling (equivalent to double4.zxzx).
        /// </summary>
        public double4 brbr => new double4(z, x, z, x);

        /// <summary>
        /// Returns double4.zxzy swizzling.
        /// </summary>
        public double4 zxzy => new double4(z, x, z, y);

        /// <summary>
        /// Returns double4.brbg swizzling (equivalent to double4.zxzy).
        /// </summary>
        public double4 brbg => new double4(z, x, z, y);

        /// <summary>
        /// Returns double4.zxzz swizzling.
        /// </summary>
        public double4 zxzz => new double4(z, x, z, z);

        /// <summary>
        /// Returns double4.brbb swizzling (equivalent to double4.zxzz).
        /// </summary>
        public double4 brbb => new double4(z, x, z, z);

        /// <summary>
        /// Returns double4.zxzw swizzling.
        /// </summary>
        public double4 zxzw => new double4(z, x, z, w);

        /// <summary>
        /// Returns double4.brba swizzling (equivalent to double4.zxzw).
        /// </summary>
        public double4 brba => new double4(z, x, z, w);

        /// <summary>
        /// Returns double4.zxw swizzling.
        /// </summary>
        public double3 zxw => new double3(z, x, w);

        /// <summary>
        /// Returns double4.bra swizzling (equivalent to double4.zxw).
        /// </summary>
        public double3 bra => new double3(z, x, w);

        /// <summary>
        /// Returns double4.zxwx swizzling.
        /// </summary>
        public double4 zxwx => new double4(z, x, w, x);

        /// <summary>
        /// Returns double4.brar swizzling (equivalent to double4.zxwx).
        /// </summary>
        public double4 brar => new double4(z, x, w, x);

        /// <summary>
        /// Returns double4.zxwy swizzling.
        /// </summary>
        public double4 zxwy => new double4(z, x, w, y);

        /// <summary>
        /// Returns double4.brag swizzling (equivalent to double4.zxwy).
        /// </summary>
        public double4 brag => new double4(z, x, w, y);

        /// <summary>
        /// Returns double4.zxwz swizzling.
        /// </summary>
        public double4 zxwz => new double4(z, x, w, z);

        /// <summary>
        /// Returns double4.brab swizzling (equivalent to double4.zxwz).
        /// </summary>
        public double4 brab => new double4(z, x, w, z);

        /// <summary>
        /// Returns double4.zxww swizzling.
        /// </summary>
        public double4 zxww => new double4(z, x, w, w);

        /// <summary>
        /// Returns double4.braa swizzling (equivalent to double4.zxww).
        /// </summary>
        public double4 braa => new double4(z, x, w, w);

        /// <summary>
        /// Returns double4.zy swizzling.
        /// </summary>
        public double2 zy => new double2(z, y);

        /// <summary>
        /// Returns double4.bg swizzling (equivalent to double4.zy).
        /// </summary>
        public double2 bg => new double2(z, y);

        /// <summary>
        /// Returns double4.zyx swizzling.
        /// </summary>
        public double3 zyx => new double3(z, y, x);

        /// <summary>
        /// Returns double4.bgr swizzling (equivalent to double4.zyx).
        /// </summary>
        public double3 bgr => new double3(z, y, x);

        /// <summary>
        /// Returns double4.zyxx swizzling.
        /// </summary>
        public double4 zyxx => new double4(z, y, x, x);

        /// <summary>
        /// Returns double4.bgrr swizzling (equivalent to double4.zyxx).
        /// </summary>
        public double4 bgrr => new double4(z, y, x, x);

        /// <summary>
        /// Returns double4.zyxy swizzling.
        /// </summary>
        public double4 zyxy => new double4(z, y, x, y);

        /// <summary>
        /// Returns double4.bgrg swizzling (equivalent to double4.zyxy).
        /// </summary>
        public double4 bgrg => new double4(z, y, x, y);

        /// <summary>
        /// Returns double4.zyxz swizzling.
        /// </summary>
        public double4 zyxz => new double4(z, y, x, z);

        /// <summary>
        /// Returns double4.bgrb swizzling (equivalent to double4.zyxz).
        /// </summary>
        public double4 bgrb => new double4(z, y, x, z);

        /// <summary>
        /// Returns double4.zyxw swizzling.
        /// </summary>
        public double4 zyxw => new double4(z, y, x, w);

        /// <summary>
        /// Returns double4.bgra swizzling (equivalent to double4.zyxw).
        /// </summary>
        public double4 bgra => new double4(z, y, x, w);

        /// <summary>
        /// Returns double4.zyy swizzling.
        /// </summary>
        public double3 zyy => new double3(z, y, y);

        /// <summary>
        /// Returns double4.bgg swizzling (equivalent to double4.zyy).
        /// </summary>
        public double3 bgg => new double3(z, y, y);

        /// <summary>
        /// Returns double4.zyyx swizzling.
        /// </summary>
        public double4 zyyx => new double4(z, y, y, x);

        /// <summary>
        /// Returns double4.bggr swizzling (equivalent to double4.zyyx).
        /// </summary>
        public double4 bggr => new double4(z, y, y, x);

        /// <summary>
        /// Returns double4.zyyy swizzling.
        /// </summary>
        public double4 zyyy => new double4(z, y, y, y);

        /// <summary>
        /// Returns double4.bggg swizzling (equivalent to double4.zyyy).
        /// </summary>
        public double4 bggg => new double4(z, y, y, y);

        /// <summary>
        /// Returns double4.zyyz swizzling.
        /// </summary>
        public double4 zyyz => new double4(z, y, y, z);

        /// <summary>
        /// Returns double4.bggb swizzling (equivalent to double4.zyyz).
        /// </summary>
        public double4 bggb => new double4(z, y, y, z);

        /// <summary>
        /// Returns double4.zyyw swizzling.
        /// </summary>
        public double4 zyyw => new double4(z, y, y, w);

        /// <summary>
        /// Returns double4.bgga swizzling (equivalent to double4.zyyw).
        /// </summary>
        public double4 bgga => new double4(z, y, y, w);

        /// <summary>
        /// Returns double4.zyz swizzling.
        /// </summary>
        public double3 zyz => new double3(z, y, z);

        /// <summary>
        /// Returns double4.bgb swizzling (equivalent to double4.zyz).
        /// </summary>
        public double3 bgb => new double3(z, y, z);

        /// <summary>
        /// Returns double4.zyzx swizzling.
        /// </summary>
        public double4 zyzx => new double4(z, y, z, x);

        /// <summary>
        /// Returns double4.bgbr swizzling (equivalent to double4.zyzx).
        /// </summary>
        public double4 bgbr => new double4(z, y, z, x);

        /// <summary>
        /// Returns double4.zyzy swizzling.
        /// </summary>
        public double4 zyzy => new double4(z, y, z, y);

        /// <summary>
        /// Returns double4.bgbg swizzling (equivalent to double4.zyzy).
        /// </summary>
        public double4 bgbg => new double4(z, y, z, y);

        /// <summary>
        /// Returns double4.zyzz swizzling.
        /// </summary>
        public double4 zyzz => new double4(z, y, z, z);

        /// <summary>
        /// Returns double4.bgbb swizzling (equivalent to double4.zyzz).
        /// </summary>
        public double4 bgbb => new double4(z, y, z, z);

        /// <summary>
        /// Returns double4.zyzw swizzling.
        /// </summary>
        public double4 zyzw => new double4(z, y, z, w);

        /// <summary>
        /// Returns double4.bgba swizzling (equivalent to double4.zyzw).
        /// </summary>
        public double4 bgba => new double4(z, y, z, w);

        /// <summary>
        /// Returns double4.zyw swizzling.
        /// </summary>
        public double3 zyw => new double3(z, y, w);

        /// <summary>
        /// Returns double4.bga swizzling (equivalent to double4.zyw).
        /// </summary>
        public double3 bga => new double3(z, y, w);

        /// <summary>
        /// Returns double4.zywx swizzling.
        /// </summary>
        public double4 zywx => new double4(z, y, w, x);

        /// <summary>
        /// Returns double4.bgar swizzling (equivalent to double4.zywx).
        /// </summary>
        public double4 bgar => new double4(z, y, w, x);

        /// <summary>
        /// Returns double4.zywy swizzling.
        /// </summary>
        public double4 zywy => new double4(z, y, w, y);

        /// <summary>
        /// Returns double4.bgag swizzling (equivalent to double4.zywy).
        /// </summary>
        public double4 bgag => new double4(z, y, w, y);

        /// <summary>
        /// Returns double4.zywz swizzling.
        /// </summary>
        public double4 zywz => new double4(z, y, w, z);

        /// <summary>
        /// Returns double4.bgab swizzling (equivalent to double4.zywz).
        /// </summary>
        public double4 bgab => new double4(z, y, w, z);

        /// <summary>
        /// Returns double4.zyww swizzling.
        /// </summary>
        public double4 zyww => new double4(z, y, w, w);

        /// <summary>
        /// Returns double4.bgaa swizzling (equivalent to double4.zyww).
        /// </summary>
        public double4 bgaa => new double4(z, y, w, w);

        /// <summary>
        /// Returns double4.zz swizzling.
        /// </summary>
        public double2 zz => new double2(z, z);

        /// <summary>
        /// Returns double4.bb swizzling (equivalent to double4.zz).
        /// </summary>
        public double2 bb => new double2(z, z);

        /// <summary>
        /// Returns double4.zzx swizzling.
        /// </summary>
        public double3 zzx => new double3(z, z, x);

        /// <summary>
        /// Returns double4.bbr swizzling (equivalent to double4.zzx).
        /// </summary>
        public double3 bbr => new double3(z, z, x);

        /// <summary>
        /// Returns double4.zzxx swizzling.
        /// </summary>
        public double4 zzxx => new double4(z, z, x, x);

        /// <summary>
        /// Returns double4.bbrr swizzling (equivalent to double4.zzxx).
        /// </summary>
        public double4 bbrr => new double4(z, z, x, x);

        /// <summary>
        /// Returns double4.zzxy swizzling.
        /// </summary>
        public double4 zzxy => new double4(z, z, x, y);

        /// <summary>
        /// Returns double4.bbrg swizzling (equivalent to double4.zzxy).
        /// </summary>
        public double4 bbrg => new double4(z, z, x, y);

        /// <summary>
        /// Returns double4.zzxz swizzling.
        /// </summary>
        public double4 zzxz => new double4(z, z, x, z);

        /// <summary>
        /// Returns double4.bbrb swizzling (equivalent to double4.zzxz).
        /// </summary>
        public double4 bbrb => new double4(z, z, x, z);

        /// <summary>
        /// Returns double4.zzxw swizzling.
        /// </summary>
        public double4 zzxw => new double4(z, z, x, w);

        /// <summary>
        /// Returns double4.bbra swizzling (equivalent to double4.zzxw).
        /// </summary>
        public double4 bbra => new double4(z, z, x, w);

        /// <summary>
        /// Returns double4.zzy swizzling.
        /// </summary>
        public double3 zzy => new double3(z, z, y);

        /// <summary>
        /// Returns double4.bbg swizzling (equivalent to double4.zzy).
        /// </summary>
        public double3 bbg => new double3(z, z, y);

        /// <summary>
        /// Returns double4.zzyx swizzling.
        /// </summary>
        public double4 zzyx => new double4(z, z, y, x);

        /// <summary>
        /// Returns double4.bbgr swizzling (equivalent to double4.zzyx).
        /// </summary>
        public double4 bbgr => new double4(z, z, y, x);

        /// <summary>
        /// Returns double4.zzyy swizzling.
        /// </summary>
        public double4 zzyy => new double4(z, z, y, y);

        /// <summary>
        /// Returns double4.bbgg swizzling (equivalent to double4.zzyy).
        /// </summary>
        public double4 bbgg => new double4(z, z, y, y);

        /// <summary>
        /// Returns double4.zzyz swizzling.
        /// </summary>
        public double4 zzyz => new double4(z, z, y, z);

        /// <summary>
        /// Returns double4.bbgb swizzling (equivalent to double4.zzyz).
        /// </summary>
        public double4 bbgb => new double4(z, z, y, z);

        /// <summary>
        /// Returns double4.zzyw swizzling.
        /// </summary>
        public double4 zzyw => new double4(z, z, y, w);

        /// <summary>
        /// Returns double4.bbga swizzling (equivalent to double4.zzyw).
        /// </summary>
        public double4 bbga => new double4(z, z, y, w);

        /// <summary>
        /// Returns double4.zzz swizzling.
        /// </summary>
        public double3 zzz => new double3(z, z, z);

        /// <summary>
        /// Returns double4.bbb swizzling (equivalent to double4.zzz).
        /// </summary>
        public double3 bbb => new double3(z, z, z);

        /// <summary>
        /// Returns double4.zzzx swizzling.
        /// </summary>
        public double4 zzzx => new double4(z, z, z, x);

        /// <summary>
        /// Returns double4.bbbr swizzling (equivalent to double4.zzzx).
        /// </summary>
        public double4 bbbr => new double4(z, z, z, x);

        /// <summary>
        /// Returns double4.zzzy swizzling.
        /// </summary>
        public double4 zzzy => new double4(z, z, z, y);

        /// <summary>
        /// Returns double4.bbbg swizzling (equivalent to double4.zzzy).
        /// </summary>
        public double4 bbbg => new double4(z, z, z, y);

        /// <summary>
        /// Returns double4.zzzz swizzling.
        /// </summary>
        public double4 zzzz => new double4(z, z, z, z);

        /// <summary>
        /// Returns double4.bbbb swizzling (equivalent to double4.zzzz).
        /// </summary>
        public double4 bbbb => new double4(z, z, z, z);

        /// <summary>
        /// Returns double4.zzzw swizzling.
        /// </summary>
        public double4 zzzw => new double4(z, z, z, w);

        /// <summary>
        /// Returns double4.bbba swizzling (equivalent to double4.zzzw).
        /// </summary>
        public double4 bbba => new double4(z, z, z, w);

        /// <summary>
        /// Returns double4.zzw swizzling.
        /// </summary>
        public double3 zzw => new double3(z, z, w);

        /// <summary>
        /// Returns double4.bba swizzling (equivalent to double4.zzw).
        /// </summary>
        public double3 bba => new double3(z, z, w);

        /// <summary>
        /// Returns double4.zzwx swizzling.
        /// </summary>
        public double4 zzwx => new double4(z, z, w, x);

        /// <summary>
        /// Returns double4.bbar swizzling (equivalent to double4.zzwx).
        /// </summary>
        public double4 bbar => new double4(z, z, w, x);

        /// <summary>
        /// Returns double4.zzwy swizzling.
        /// </summary>
        public double4 zzwy => new double4(z, z, w, y);

        /// <summary>
        /// Returns double4.bbag swizzling (equivalent to double4.zzwy).
        /// </summary>
        public double4 bbag => new double4(z, z, w, y);

        /// <summary>
        /// Returns double4.zzwz swizzling.
        /// </summary>
        public double4 zzwz => new double4(z, z, w, z);

        /// <summary>
        /// Returns double4.bbab swizzling (equivalent to double4.zzwz).
        /// </summary>
        public double4 bbab => new double4(z, z, w, z);

        /// <summary>
        /// Returns double4.zzww swizzling.
        /// </summary>
        public double4 zzww => new double4(z, z, w, w);

        /// <summary>
        /// Returns double4.bbaa swizzling (equivalent to double4.zzww).
        /// </summary>
        public double4 bbaa => new double4(z, z, w, w);

        /// <summary>
        /// Returns double4.zw swizzling.
        /// </summary>
        public double2 zw => new double2(z, w);

        /// <summary>
        /// Returns double4.ba swizzling (equivalent to double4.zw).
        /// </summary>
        public double2 ba => new double2(z, w);

        /// <summary>
        /// Returns double4.zwx swizzling.
        /// </summary>
        public double3 zwx => new double3(z, w, x);

        /// <summary>
        /// Returns double4.bar swizzling (equivalent to double4.zwx).
        /// </summary>
        public double3 bar => new double3(z, w, x);

        /// <summary>
        /// Returns double4.zwxx swizzling.
        /// </summary>
        public double4 zwxx => new double4(z, w, x, x);

        /// <summary>
        /// Returns double4.barr swizzling (equivalent to double4.zwxx).
        /// </summary>
        public double4 barr => new double4(z, w, x, x);

        /// <summary>
        /// Returns double4.zwxy swizzling.
        /// </summary>
        public double4 zwxy => new double4(z, w, x, y);

        /// <summary>
        /// Returns double4.barg swizzling (equivalent to double4.zwxy).
        /// </summary>
        public double4 barg => new double4(z, w, x, y);

        /// <summary>
        /// Returns double4.zwxz swizzling.
        /// </summary>
        public double4 zwxz => new double4(z, w, x, z);

        /// <summary>
        /// Returns double4.barb swizzling (equivalent to double4.zwxz).
        /// </summary>
        public double4 barb => new double4(z, w, x, z);

        /// <summary>
        /// Returns double4.zwxw swizzling.
        /// </summary>
        public double4 zwxw => new double4(z, w, x, w);

        /// <summary>
        /// Returns double4.bara swizzling (equivalent to double4.zwxw).
        /// </summary>
        public double4 bara => new double4(z, w, x, w);

        /// <summary>
        /// Returns double4.zwy swizzling.
        /// </summary>
        public double3 zwy => new double3(z, w, y);

        /// <summary>
        /// Returns double4.bag swizzling (equivalent to double4.zwy).
        /// </summary>
        public double3 bag => new double3(z, w, y);

        /// <summary>
        /// Returns double4.zwyx swizzling.
        /// </summary>
        public double4 zwyx => new double4(z, w, y, x);

        /// <summary>
        /// Returns double4.bagr swizzling (equivalent to double4.zwyx).
        /// </summary>
        public double4 bagr => new double4(z, w, y, x);

        /// <summary>
        /// Returns double4.zwyy swizzling.
        /// </summary>
        public double4 zwyy => new double4(z, w, y, y);

        /// <summary>
        /// Returns double4.bagg swizzling (equivalent to double4.zwyy).
        /// </summary>
        public double4 bagg => new double4(z, w, y, y);

        /// <summary>
        /// Returns double4.zwyz swizzling.
        /// </summary>
        public double4 zwyz => new double4(z, w, y, z);

        /// <summary>
        /// Returns double4.bagb swizzling (equivalent to double4.zwyz).
        /// </summary>
        public double4 bagb => new double4(z, w, y, z);

        /// <summary>
        /// Returns double4.zwyw swizzling.
        /// </summary>
        public double4 zwyw => new double4(z, w, y, w);

        /// <summary>
        /// Returns double4.baga swizzling (equivalent to double4.zwyw).
        /// </summary>
        public double4 baga => new double4(z, w, y, w);

        /// <summary>
        /// Returns double4.zwz swizzling.
        /// </summary>
        public double3 zwz => new double3(z, w, z);

        /// <summary>
        /// Returns double4.bab swizzling (equivalent to double4.zwz).
        /// </summary>
        public double3 bab => new double3(z, w, z);

        /// <summary>
        /// Returns double4.zwzx swizzling.
        /// </summary>
        public double4 zwzx => new double4(z, w, z, x);

        /// <summary>
        /// Returns double4.babr swizzling (equivalent to double4.zwzx).
        /// </summary>
        public double4 babr => new double4(z, w, z, x);

        /// <summary>
        /// Returns double4.zwzy swizzling.
        /// </summary>
        public double4 zwzy => new double4(z, w, z, y);

        /// <summary>
        /// Returns double4.babg swizzling (equivalent to double4.zwzy).
        /// </summary>
        public double4 babg => new double4(z, w, z, y);

        /// <summary>
        /// Returns double4.zwzz swizzling.
        /// </summary>
        public double4 zwzz => new double4(z, w, z, z);

        /// <summary>
        /// Returns double4.babb swizzling (equivalent to double4.zwzz).
        /// </summary>
        public double4 babb => new double4(z, w, z, z);

        /// <summary>
        /// Returns double4.zwzw swizzling.
        /// </summary>
        public double4 zwzw => new double4(z, w, z, w);

        /// <summary>
        /// Returns double4.baba swizzling (equivalent to double4.zwzw).
        /// </summary>
        public double4 baba => new double4(z, w, z, w);

        /// <summary>
        /// Returns double4.zww swizzling.
        /// </summary>
        public double3 zww => new double3(z, w, w);

        /// <summary>
        /// Returns double4.baa swizzling (equivalent to double4.zww).
        /// </summary>
        public double3 baa => new double3(z, w, w);

        /// <summary>
        /// Returns double4.zwwx swizzling.
        /// </summary>
        public double4 zwwx => new double4(z, w, w, x);

        /// <summary>
        /// Returns double4.baar swizzling (equivalent to double4.zwwx).
        /// </summary>
        public double4 baar => new double4(z, w, w, x);

        /// <summary>
        /// Returns double4.zwwy swizzling.
        /// </summary>
        public double4 zwwy => new double4(z, w, w, y);

        /// <summary>
        /// Returns double4.baag swizzling (equivalent to double4.zwwy).
        /// </summary>
        public double4 baag => new double4(z, w, w, y);

        /// <summary>
        /// Returns double4.zwwz swizzling.
        /// </summary>
        public double4 zwwz => new double4(z, w, w, z);

        /// <summary>
        /// Returns double4.baab swizzling (equivalent to double4.zwwz).
        /// </summary>
        public double4 baab => new double4(z, w, w, z);

        /// <summary>
        /// Returns double4.zwww swizzling.
        /// </summary>
        public double4 zwww => new double4(z, w, w, w);

        /// <summary>
        /// Returns double4.baaa swizzling (equivalent to double4.zwww).
        /// </summary>
        public double4 baaa => new double4(z, w, w, w);

        /// <summary>
        /// Returns double4.wx swizzling.
        /// </summary>
        public double2 wx => new double2(w, x);

        /// <summary>
        /// Returns double4.ar swizzling (equivalent to double4.wx).
        /// </summary>
        public double2 ar => new double2(w, x);

        /// <summary>
        /// Returns double4.wxx swizzling.
        /// </summary>
        public double3 wxx => new double3(w, x, x);

        /// <summary>
        /// Returns double4.arr swizzling (equivalent to double4.wxx).
        /// </summary>
        public double3 arr => new double3(w, x, x);

        /// <summary>
        /// Returns double4.wxxx swizzling.
        /// </summary>
        public double4 wxxx => new double4(w, x, x, x);

        /// <summary>
        /// Returns double4.arrr swizzling (equivalent to double4.wxxx).
        /// </summary>
        public double4 arrr => new double4(w, x, x, x);

        /// <summary>
        /// Returns double4.wxxy swizzling.
        /// </summary>
        public double4 wxxy => new double4(w, x, x, y);

        /// <summary>
        /// Returns double4.arrg swizzling (equivalent to double4.wxxy).
        /// </summary>
        public double4 arrg => new double4(w, x, x, y);

        /// <summary>
        /// Returns double4.wxxz swizzling.
        /// </summary>
        public double4 wxxz => new double4(w, x, x, z);

        /// <summary>
        /// Returns double4.arrb swizzling (equivalent to double4.wxxz).
        /// </summary>
        public double4 arrb => new double4(w, x, x, z);

        /// <summary>
        /// Returns double4.wxxw swizzling.
        /// </summary>
        public double4 wxxw => new double4(w, x, x, w);

        /// <summary>
        /// Returns double4.arra swizzling (equivalent to double4.wxxw).
        /// </summary>
        public double4 arra => new double4(w, x, x, w);

        /// <summary>
        /// Returns double4.wxy swizzling.
        /// </summary>
        public double3 wxy => new double3(w, x, y);

        /// <summary>
        /// Returns double4.arg swizzling (equivalent to double4.wxy).
        /// </summary>
        public double3 arg => new double3(w, x, y);

        /// <summary>
        /// Returns double4.wxyx swizzling.
        /// </summary>
        public double4 wxyx => new double4(w, x, y, x);

        /// <summary>
        /// Returns double4.argr swizzling (equivalent to double4.wxyx).
        /// </summary>
        public double4 argr => new double4(w, x, y, x);

        /// <summary>
        /// Returns double4.wxyy swizzling.
        /// </summary>
        public double4 wxyy => new double4(w, x, y, y);

        /// <summary>
        /// Returns double4.argg swizzling (equivalent to double4.wxyy).
        /// </summary>
        public double4 argg => new double4(w, x, y, y);

        /// <summary>
        /// Returns double4.wxyz swizzling.
        /// </summary>
        public double4 wxyz => new double4(w, x, y, z);

        /// <summary>
        /// Returns double4.argb swizzling (equivalent to double4.wxyz).
        /// </summary>
        public double4 argb => new double4(w, x, y, z);

        /// <summary>
        /// Returns double4.wxyw swizzling.
        /// </summary>
        public double4 wxyw => new double4(w, x, y, w);

        /// <summary>
        /// Returns double4.arga swizzling (equivalent to double4.wxyw).
        /// </summary>
        public double4 arga => new double4(w, x, y, w);

        /// <summary>
        /// Returns double4.wxz swizzling.
        /// </summary>
        public double3 wxz => new double3(w, x, z);

        /// <summary>
        /// Returns double4.arb swizzling (equivalent to double4.wxz).
        /// </summary>
        public double3 arb => new double3(w, x, z);

        /// <summary>
        /// Returns double4.wxzx swizzling.
        /// </summary>
        public double4 wxzx => new double4(w, x, z, x);

        /// <summary>
        /// Returns double4.arbr swizzling (equivalent to double4.wxzx).
        /// </summary>
        public double4 arbr => new double4(w, x, z, x);

        /// <summary>
        /// Returns double4.wxzy swizzling.
        /// </summary>
        public double4 wxzy => new double4(w, x, z, y);

        /// <summary>
        /// Returns double4.arbg swizzling (equivalent to double4.wxzy).
        /// </summary>
        public double4 arbg => new double4(w, x, z, y);

        /// <summary>
        /// Returns double4.wxzz swizzling.
        /// </summary>
        public double4 wxzz => new double4(w, x, z, z);

        /// <summary>
        /// Returns double4.arbb swizzling (equivalent to double4.wxzz).
        /// </summary>
        public double4 arbb => new double4(w, x, z, z);

        /// <summary>
        /// Returns double4.wxzw swizzling.
        /// </summary>
        public double4 wxzw => new double4(w, x, z, w);

        /// <summary>
        /// Returns double4.arba swizzling (equivalent to double4.wxzw).
        /// </summary>
        public double4 arba => new double4(w, x, z, w);

        /// <summary>
        /// Returns double4.wxw swizzling.
        /// </summary>
        public double3 wxw => new double3(w, x, w);

        /// <summary>
        /// Returns double4.ara swizzling (equivalent to double4.wxw).
        /// </summary>
        public double3 ara => new double3(w, x, w);

        /// <summary>
        /// Returns double4.wxwx swizzling.
        /// </summary>
        public double4 wxwx => new double4(w, x, w, x);

        /// <summary>
        /// Returns double4.arar swizzling (equivalent to double4.wxwx).
        /// </summary>
        public double4 arar => new double4(w, x, w, x);

        /// <summary>
        /// Returns double4.wxwy swizzling.
        /// </summary>
        public double4 wxwy => new double4(w, x, w, y);

        /// <summary>
        /// Returns double4.arag swizzling (equivalent to double4.wxwy).
        /// </summary>
        public double4 arag => new double4(w, x, w, y);

        /// <summary>
        /// Returns double4.wxwz swizzling.
        /// </summary>
        public double4 wxwz => new double4(w, x, w, z);

        /// <summary>
        /// Returns double4.arab swizzling (equivalent to double4.wxwz).
        /// </summary>
        public double4 arab => new double4(w, x, w, z);

        /// <summary>
        /// Returns double4.wxww swizzling.
        /// </summary>
        public double4 wxww => new double4(w, x, w, w);

        /// <summary>
        /// Returns double4.araa swizzling (equivalent to double4.wxww).
        /// </summary>
        public double4 araa => new double4(w, x, w, w);

        /// <summary>
        /// Returns double4.wy swizzling.
        /// </summary>
        public double2 wy => new double2(w, y);

        /// <summary>
        /// Returns double4.ag swizzling (equivalent to double4.wy).
        /// </summary>
        public double2 ag => new double2(w, y);

        /// <summary>
        /// Returns double4.wyx swizzling.
        /// </summary>
        public double3 wyx => new double3(w, y, x);

        /// <summary>
        /// Returns double4.agr swizzling (equivalent to double4.wyx).
        /// </summary>
        public double3 agr => new double3(w, y, x);

        /// <summary>
        /// Returns double4.wyxx swizzling.
        /// </summary>
        public double4 wyxx => new double4(w, y, x, x);

        /// <summary>
        /// Returns double4.agrr swizzling (equivalent to double4.wyxx).
        /// </summary>
        public double4 agrr => new double4(w, y, x, x);

        /// <summary>
        /// Returns double4.wyxy swizzling.
        /// </summary>
        public double4 wyxy => new double4(w, y, x, y);

        /// <summary>
        /// Returns double4.agrg swizzling (equivalent to double4.wyxy).
        /// </summary>
        public double4 agrg => new double4(w, y, x, y);

        /// <summary>
        /// Returns double4.wyxz swizzling.
        /// </summary>
        public double4 wyxz => new double4(w, y, x, z);

        /// <summary>
        /// Returns double4.agrb swizzling (equivalent to double4.wyxz).
        /// </summary>
        public double4 agrb => new double4(w, y, x, z);

        /// <summary>
        /// Returns double4.wyxw swizzling.
        /// </summary>
        public double4 wyxw => new double4(w, y, x, w);

        /// <summary>
        /// Returns double4.agra swizzling (equivalent to double4.wyxw).
        /// </summary>
        public double4 agra => new double4(w, y, x, w);

        /// <summary>
        /// Returns double4.wyy swizzling.
        /// </summary>
        public double3 wyy => new double3(w, y, y);

        /// <summary>
        /// Returns double4.agg swizzling (equivalent to double4.wyy).
        /// </summary>
        public double3 agg => new double3(w, y, y);

        /// <summary>
        /// Returns double4.wyyx swizzling.
        /// </summary>
        public double4 wyyx => new double4(w, y, y, x);

        /// <summary>
        /// Returns double4.aggr swizzling (equivalent to double4.wyyx).
        /// </summary>
        public double4 aggr => new double4(w, y, y, x);

        /// <summary>
        /// Returns double4.wyyy swizzling.
        /// </summary>
        public double4 wyyy => new double4(w, y, y, y);

        /// <summary>
        /// Returns double4.aggg swizzling (equivalent to double4.wyyy).
        /// </summary>
        public double4 aggg => new double4(w, y, y, y);

        /// <summary>
        /// Returns double4.wyyz swizzling.
        /// </summary>
        public double4 wyyz => new double4(w, y, y, z);

        /// <summary>
        /// Returns double4.aggb swizzling (equivalent to double4.wyyz).
        /// </summary>
        public double4 aggb => new double4(w, y, y, z);

        /// <summary>
        /// Returns double4.wyyw swizzling.
        /// </summary>
        public double4 wyyw => new double4(w, y, y, w);

        /// <summary>
        /// Returns double4.agga swizzling (equivalent to double4.wyyw).
        /// </summary>
        public double4 agga => new double4(w, y, y, w);

        /// <summary>
        /// Returns double4.wyz swizzling.
        /// </summary>
        public double3 wyz => new double3(w, y, z);

        /// <summary>
        /// Returns double4.agb swizzling (equivalent to double4.wyz).
        /// </summary>
        public double3 agb => new double3(w, y, z);

        /// <summary>
        /// Returns double4.wyzx swizzling.
        /// </summary>
        public double4 wyzx => new double4(w, y, z, x);

        /// <summary>
        /// Returns double4.agbr swizzling (equivalent to double4.wyzx).
        /// </summary>
        public double4 agbr => new double4(w, y, z, x);

        /// <summary>
        /// Returns double4.wyzy swizzling.
        /// </summary>
        public double4 wyzy => new double4(w, y, z, y);

        /// <summary>
        /// Returns double4.agbg swizzling (equivalent to double4.wyzy).
        /// </summary>
        public double4 agbg => new double4(w, y, z, y);

        /// <summary>
        /// Returns double4.wyzz swizzling.
        /// </summary>
        public double4 wyzz => new double4(w, y, z, z);

        /// <summary>
        /// Returns double4.agbb swizzling (equivalent to double4.wyzz).
        /// </summary>
        public double4 agbb => new double4(w, y, z, z);

        /// <summary>
        /// Returns double4.wyzw swizzling.
        /// </summary>
        public double4 wyzw => new double4(w, y, z, w);

        /// <summary>
        /// Returns double4.agba swizzling (equivalent to double4.wyzw).
        /// </summary>
        public double4 agba => new double4(w, y, z, w);

        /// <summary>
        /// Returns double4.wyw swizzling.
        /// </summary>
        public double3 wyw => new double3(w, y, w);

        /// <summary>
        /// Returns double4.aga swizzling (equivalent to double4.wyw).
        /// </summary>
        public double3 aga => new double3(w, y, w);

        /// <summary>
        /// Returns double4.wywx swizzling.
        /// </summary>
        public double4 wywx => new double4(w, y, w, x);

        /// <summary>
        /// Returns double4.agar swizzling (equivalent to double4.wywx).
        /// </summary>
        public double4 agar => new double4(w, y, w, x);

        /// <summary>
        /// Returns double4.wywy swizzling.
        /// </summary>
        public double4 wywy => new double4(w, y, w, y);

        /// <summary>
        /// Returns double4.agag swizzling (equivalent to double4.wywy).
        /// </summary>
        public double4 agag => new double4(w, y, w, y);

        /// <summary>
        /// Returns double4.wywz swizzling.
        /// </summary>
        public double4 wywz => new double4(w, y, w, z);

        /// <summary>
        /// Returns double4.agab swizzling (equivalent to double4.wywz).
        /// </summary>
        public double4 agab => new double4(w, y, w, z);

        /// <summary>
        /// Returns double4.wyww swizzling.
        /// </summary>
        public double4 wyww => new double4(w, y, w, w);

        /// <summary>
        /// Returns double4.agaa swizzling (equivalent to double4.wyww).
        /// </summary>
        public double4 agaa => new double4(w, y, w, w);

        /// <summary>
        /// Returns double4.wz swizzling.
        /// </summary>
        public double2 wz => new double2(w, z);

        /// <summary>
        /// Returns double4.ab swizzling (equivalent to double4.wz).
        /// </summary>
        public double2 ab => new double2(w, z);

        /// <summary>
        /// Returns double4.wzx swizzling.
        /// </summary>
        public double3 wzx => new double3(w, z, x);

        /// <summary>
        /// Returns double4.abr swizzling (equivalent to double4.wzx).
        /// </summary>
        public double3 abr => new double3(w, z, x);

        /// <summary>
        /// Returns double4.wzxx swizzling.
        /// </summary>
        public double4 wzxx => new double4(w, z, x, x);

        /// <summary>
        /// Returns double4.abrr swizzling (equivalent to double4.wzxx).
        /// </summary>
        public double4 abrr => new double4(w, z, x, x);

        /// <summary>
        /// Returns double4.wzxy swizzling.
        /// </summary>
        public double4 wzxy => new double4(w, z, x, y);

        /// <summary>
        /// Returns double4.abrg swizzling (equivalent to double4.wzxy).
        /// </summary>
        public double4 abrg => new double4(w, z, x, y);

        /// <summary>
        /// Returns double4.wzxz swizzling.
        /// </summary>
        public double4 wzxz => new double4(w, z, x, z);

        /// <summary>
        /// Returns double4.abrb swizzling (equivalent to double4.wzxz).
        /// </summary>
        public double4 abrb => new double4(w, z, x, z);

        /// <summary>
        /// Returns double4.wzxw swizzling.
        /// </summary>
        public double4 wzxw => new double4(w, z, x, w);

        /// <summary>
        /// Returns double4.abra swizzling (equivalent to double4.wzxw).
        /// </summary>
        public double4 abra => new double4(w, z, x, w);

        /// <summary>
        /// Returns double4.wzy swizzling.
        /// </summary>
        public double3 wzy => new double3(w, z, y);

        /// <summary>
        /// Returns double4.abg swizzling (equivalent to double4.wzy).
        /// </summary>
        public double3 abg => new double3(w, z, y);

        /// <summary>
        /// Returns double4.wzyx swizzling.
        /// </summary>
        public double4 wzyx => new double4(w, z, y, x);

        /// <summary>
        /// Returns double4.abgr swizzling (equivalent to double4.wzyx).
        /// </summary>
        public double4 abgr => new double4(w, z, y, x);

        /// <summary>
        /// Returns double4.wzyy swizzling.
        /// </summary>
        public double4 wzyy => new double4(w, z, y, y);

        /// <summary>
        /// Returns double4.abgg swizzling (equivalent to double4.wzyy).
        /// </summary>
        public double4 abgg => new double4(w, z, y, y);

        /// <summary>
        /// Returns double4.wzyz swizzling.
        /// </summary>
        public double4 wzyz => new double4(w, z, y, z);

        /// <summary>
        /// Returns double4.abgb swizzling (equivalent to double4.wzyz).
        /// </summary>
        public double4 abgb => new double4(w, z, y, z);

        /// <summary>
        /// Returns double4.wzyw swizzling.
        /// </summary>
        public double4 wzyw => new double4(w, z, y, w);

        /// <summary>
        /// Returns double4.abga swizzling (equivalent to double4.wzyw).
        /// </summary>
        public double4 abga => new double4(w, z, y, w);

        /// <summary>
        /// Returns double4.wzz swizzling.
        /// </summary>
        public double3 wzz => new double3(w, z, z);

        /// <summary>
        /// Returns double4.abb swizzling (equivalent to double4.wzz).
        /// </summary>
        public double3 abb => new double3(w, z, z);

        /// <summary>
        /// Returns double4.wzzx swizzling.
        /// </summary>
        public double4 wzzx => new double4(w, z, z, x);

        /// <summary>
        /// Returns double4.abbr swizzling (equivalent to double4.wzzx).
        /// </summary>
        public double4 abbr => new double4(w, z, z, x);

        /// <summary>
        /// Returns double4.wzzy swizzling.
        /// </summary>
        public double4 wzzy => new double4(w, z, z, y);

        /// <summary>
        /// Returns double4.abbg swizzling (equivalent to double4.wzzy).
        /// </summary>
        public double4 abbg => new double4(w, z, z, y);

        /// <summary>
        /// Returns double4.wzzz swizzling.
        /// </summary>
        public double4 wzzz => new double4(w, z, z, z);

        /// <summary>
        /// Returns double4.abbb swizzling (equivalent to double4.wzzz).
        /// </summary>
        public double4 abbb => new double4(w, z, z, z);

        /// <summary>
        /// Returns double4.wzzw swizzling.
        /// </summary>
        public double4 wzzw => new double4(w, z, z, w);

        /// <summary>
        /// Returns double4.abba swizzling (equivalent to double4.wzzw).
        /// </summary>
        public double4 abba => new double4(w, z, z, w);

        /// <summary>
        /// Returns double4.wzw swizzling.
        /// </summary>
        public double3 wzw => new double3(w, z, w);

        /// <summary>
        /// Returns double4.aba swizzling (equivalent to double4.wzw).
        /// </summary>
        public double3 aba => new double3(w, z, w);

        /// <summary>
        /// Returns double4.wzwx swizzling.
        /// </summary>
        public double4 wzwx => new double4(w, z, w, x);

        /// <summary>
        /// Returns double4.abar swizzling (equivalent to double4.wzwx).
        /// </summary>
        public double4 abar => new double4(w, z, w, x);

        /// <summary>
        /// Returns double4.wzwy swizzling.
        /// </summary>
        public double4 wzwy => new double4(w, z, w, y);

        /// <summary>
        /// Returns double4.abag swizzling (equivalent to double4.wzwy).
        /// </summary>
        public double4 abag => new double4(w, z, w, y);

        /// <summary>
        /// Returns double4.wzwz swizzling.
        /// </summary>
        public double4 wzwz => new double4(w, z, w, z);

        /// <summary>
        /// Returns double4.abab swizzling (equivalent to double4.wzwz).
        /// </summary>
        public double4 abab => new double4(w, z, w, z);

        /// <summary>
        /// Returns double4.wzww swizzling.
        /// </summary>
        public double4 wzww => new double4(w, z, w, w);

        /// <summary>
        /// Returns double4.abaa swizzling (equivalent to double4.wzww).
        /// </summary>
        public double4 abaa => new double4(w, z, w, w);

        /// <summary>
        /// Returns double4.ww swizzling.
        /// </summary>
        public double2 ww => new double2(w, w);

        /// <summary>
        /// Returns double4.aa swizzling (equivalent to double4.ww).
        /// </summary>
        public double2 aa => new double2(w, w);

        /// <summary>
        /// Returns double4.wwx swizzling.
        /// </summary>
        public double3 wwx => new double3(w, w, x);

        /// <summary>
        /// Returns double4.aar swizzling (equivalent to double4.wwx).
        /// </summary>
        public double3 aar => new double3(w, w, x);

        /// <summary>
        /// Returns double4.wwxx swizzling.
        /// </summary>
        public double4 wwxx => new double4(w, w, x, x);

        /// <summary>
        /// Returns double4.aarr swizzling (equivalent to double4.wwxx).
        /// </summary>
        public double4 aarr => new double4(w, w, x, x);

        /// <summary>
        /// Returns double4.wwxy swizzling.
        /// </summary>
        public double4 wwxy => new double4(w, w, x, y);

        /// <summary>
        /// Returns double4.aarg swizzling (equivalent to double4.wwxy).
        /// </summary>
        public double4 aarg => new double4(w, w, x, y);

        /// <summary>
        /// Returns double4.wwxz swizzling.
        /// </summary>
        public double4 wwxz => new double4(w, w, x, z);

        /// <summary>
        /// Returns double4.aarb swizzling (equivalent to double4.wwxz).
        /// </summary>
        public double4 aarb => new double4(w, w, x, z);

        /// <summary>
        /// Returns double4.wwxw swizzling.
        /// </summary>
        public double4 wwxw => new double4(w, w, x, w);

        /// <summary>
        /// Returns double4.aara swizzling (equivalent to double4.wwxw).
        /// </summary>
        public double4 aara => new double4(w, w, x, w);

        /// <summary>
        /// Returns double4.wwy swizzling.
        /// </summary>
        public double3 wwy => new double3(w, w, y);

        /// <summary>
        /// Returns double4.aag swizzling (equivalent to double4.wwy).
        /// </summary>
        public double3 aag => new double3(w, w, y);

        /// <summary>
        /// Returns double4.wwyx swizzling.
        /// </summary>
        public double4 wwyx => new double4(w, w, y, x);

        /// <summary>
        /// Returns double4.aagr swizzling (equivalent to double4.wwyx).
        /// </summary>
        public double4 aagr => new double4(w, w, y, x);

        /// <summary>
        /// Returns double4.wwyy swizzling.
        /// </summary>
        public double4 wwyy => new double4(w, w, y, y);

        /// <summary>
        /// Returns double4.aagg swizzling (equivalent to double4.wwyy).
        /// </summary>
        public double4 aagg => new double4(w, w, y, y);

        /// <summary>
        /// Returns double4.wwyz swizzling.
        /// </summary>
        public double4 wwyz => new double4(w, w, y, z);

        /// <summary>
        /// Returns double4.aagb swizzling (equivalent to double4.wwyz).
        /// </summary>
        public double4 aagb => new double4(w, w, y, z);

        /// <summary>
        /// Returns double4.wwyw swizzling.
        /// </summary>
        public double4 wwyw => new double4(w, w, y, w);

        /// <summary>
        /// Returns double4.aaga swizzling (equivalent to double4.wwyw).
        /// </summary>
        public double4 aaga => new double4(w, w, y, w);

        /// <summary>
        /// Returns double4.wwz swizzling.
        /// </summary>
        public double3 wwz => new double3(w, w, z);

        /// <summary>
        /// Returns double4.aab swizzling (equivalent to double4.wwz).
        /// </summary>
        public double3 aab => new double3(w, w, z);

        /// <summary>
        /// Returns double4.wwzx swizzling.
        /// </summary>
        public double4 wwzx => new double4(w, w, z, x);

        /// <summary>
        /// Returns double4.aabr swizzling (equivalent to double4.wwzx).
        /// </summary>
        public double4 aabr => new double4(w, w, z, x);

        /// <summary>
        /// Returns double4.wwzy swizzling.
        /// </summary>
        public double4 wwzy => new double4(w, w, z, y);

        /// <summary>
        /// Returns double4.aabg swizzling (equivalent to double4.wwzy).
        /// </summary>
        public double4 aabg => new double4(w, w, z, y);

        /// <summary>
        /// Returns double4.wwzz swizzling.
        /// </summary>
        public double4 wwzz => new double4(w, w, z, z);

        /// <summary>
        /// Returns double4.aabb swizzling (equivalent to double4.wwzz).
        /// </summary>
        public double4 aabb => new double4(w, w, z, z);

        /// <summary>
        /// Returns double4.wwzw swizzling.
        /// </summary>
        public double4 wwzw => new double4(w, w, z, w);

        /// <summary>
        /// Returns double4.aaba swizzling (equivalent to double4.wwzw).
        /// </summary>
        public double4 aaba => new double4(w, w, z, w);

        /// <summary>
        /// Returns double4.www swizzling.
        /// </summary>
        public double3 www => new double3(w, w, w);

        /// <summary>
        /// Returns double4.aaa swizzling (equivalent to double4.www).
        /// </summary>
        public double3 aaa => new double3(w, w, w);

        /// <summary>
        /// Returns double4.wwwx swizzling.
        /// </summary>
        public double4 wwwx => new double4(w, w, w, x);

        /// <summary>
        /// Returns double4.aaar swizzling (equivalent to double4.wwwx).
        /// </summary>
        public double4 aaar => new double4(w, w, w, x);

        /// <summary>
        /// Returns double4.wwwy swizzling.
        /// </summary>
        public double4 wwwy => new double4(w, w, w, y);

        /// <summary>
        /// Returns double4.aaag swizzling (equivalent to double4.wwwy).
        /// </summary>
        public double4 aaag => new double4(w, w, w, y);

        /// <summary>
        /// Returns double4.wwwz swizzling.
        /// </summary>
        public double4 wwwz => new double4(w, w, w, z);

        /// <summary>
        /// Returns double4.aaab swizzling (equivalent to double4.wwwz).
        /// </summary>
        public double4 aaab => new double4(w, w, w, z);

        /// <summary>
        /// Returns double4.wwww swizzling.
        /// </summary>
        public double4 wwww => new double4(w, w, w, w);

        /// <summary>
        /// Returns double4.aaaa swizzling (equivalent to double4.wwww).
        /// </summary>
        public double4 aaaa => new double4(w, w, w, w);

        #endregion

    }
}
