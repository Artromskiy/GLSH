using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GLSH.Swizzle
{

    /// <summary>
    /// Temporary vector of type float with 4 components, used for implementing swizzling for float4.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "swizzle")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct swizzle_vec4
    {

        #region Fields

        /// <summary>
        /// x-component
        /// </summary>
        [DataMember]
        internal readonly float x;

        /// <summary>
        /// y-component
        /// </summary>
        [DataMember]
        internal readonly float y;

        /// <summary>
        /// z-component
        /// </summary>
        [DataMember]
        internal readonly float z;

        /// <summary>
        /// w-component
        /// </summary>
        [DataMember]
        internal readonly float w;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor for swizzle_vec4.
        /// </summary>
        internal swizzle_vec4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Returns float4.xx swizzling.
        /// </summary>
        public float2 xx => new float2(x, x);

        /// <summary>
        /// Returns float4.rr swizzling (equivalent to float4.xx).
        /// </summary>
        public float2 rr => new float2(x, x);

        /// <summary>
        /// Returns float4.xxx swizzling.
        /// </summary>
        public float3 xxx => new float3(x, x, x);

        /// <summary>
        /// Returns float4.rrr swizzling (equivalent to float4.xxx).
        /// </summary>
        public float3 rrr => new float3(x, x, x);

        /// <summary>
        /// Returns float4.xxxx swizzling.
        /// </summary>
        public float4 xxxx => new float4(x, x, x, x);

        /// <summary>
        /// Returns float4.rrrr swizzling (equivalent to float4.xxxx).
        /// </summary>
        public float4 rrrr => new float4(x, x, x, x);

        /// <summary>
        /// Returns float4.xxxy swizzling.
        /// </summary>
        public float4 xxxy => new float4(x, x, x, y);

        /// <summary>
        /// Returns float4.rrrg swizzling (equivalent to float4.xxxy).
        /// </summary>
        public float4 rrrg => new float4(x, x, x, y);

        /// <summary>
        /// Returns float4.xxxz swizzling.
        /// </summary>
        public float4 xxxz => new float4(x, x, x, z);

        /// <summary>
        /// Returns float4.rrrb swizzling (equivalent to float4.xxxz).
        /// </summary>
        public float4 rrrb => new float4(x, x, x, z);

        /// <summary>
        /// Returns float4.xxxw swizzling.
        /// </summary>
        public float4 xxxw => new float4(x, x, x, w);

        /// <summary>
        /// Returns float4.rrra swizzling (equivalent to float4.xxxw).
        /// </summary>
        public float4 rrra => new float4(x, x, x, w);

        /// <summary>
        /// Returns float4.xxy swizzling.
        /// </summary>
        public float3 xxy => new float3(x, x, y);

        /// <summary>
        /// Returns float4.rrg swizzling (equivalent to float4.xxy).
        /// </summary>
        public float3 rrg => new float3(x, x, y);

        /// <summary>
        /// Returns float4.xxyx swizzling.
        /// </summary>
        public float4 xxyx => new float4(x, x, y, x);

        /// <summary>
        /// Returns float4.rrgr swizzling (equivalent to float4.xxyx).
        /// </summary>
        public float4 rrgr => new float4(x, x, y, x);

        /// <summary>
        /// Returns float4.xxyy swizzling.
        /// </summary>
        public float4 xxyy => new float4(x, x, y, y);

        /// <summary>
        /// Returns float4.rrgg swizzling (equivalent to float4.xxyy).
        /// </summary>
        public float4 rrgg => new float4(x, x, y, y);

        /// <summary>
        /// Returns float4.xxyz swizzling.
        /// </summary>
        public float4 xxyz => new float4(x, x, y, z);

        /// <summary>
        /// Returns float4.rrgb swizzling (equivalent to float4.xxyz).
        /// </summary>
        public float4 rrgb => new float4(x, x, y, z);

        /// <summary>
        /// Returns float4.xxyw swizzling.
        /// </summary>
        public float4 xxyw => new float4(x, x, y, w);

        /// <summary>
        /// Returns float4.rrga swizzling (equivalent to float4.xxyw).
        /// </summary>
        public float4 rrga => new float4(x, x, y, w);

        /// <summary>
        /// Returns float4.xxz swizzling.
        /// </summary>
        public float3 xxz => new float3(x, x, z);

        /// <summary>
        /// Returns float4.rrb swizzling (equivalent to float4.xxz).
        /// </summary>
        public float3 rrb => new float3(x, x, z);

        /// <summary>
        /// Returns float4.xxzx swizzling.
        /// </summary>
        public float4 xxzx => new float4(x, x, z, x);

        /// <summary>
        /// Returns float4.rrbr swizzling (equivalent to float4.xxzx).
        /// </summary>
        public float4 rrbr => new float4(x, x, z, x);

        /// <summary>
        /// Returns float4.xxzy swizzling.
        /// </summary>
        public float4 xxzy => new float4(x, x, z, y);

        /// <summary>
        /// Returns float4.rrbg swizzling (equivalent to float4.xxzy).
        /// </summary>
        public float4 rrbg => new float4(x, x, z, y);

        /// <summary>
        /// Returns float4.xxzz swizzling.
        /// </summary>
        public float4 xxzz => new float4(x, x, z, z);

        /// <summary>
        /// Returns float4.rrbb swizzling (equivalent to float4.xxzz).
        /// </summary>
        public float4 rrbb => new float4(x, x, z, z);

        /// <summary>
        /// Returns float4.xxzw swizzling.
        /// </summary>
        public float4 xxzw => new float4(x, x, z, w);

        /// <summary>
        /// Returns float4.rrba swizzling (equivalent to float4.xxzw).
        /// </summary>
        public float4 rrba => new float4(x, x, z, w);

        /// <summary>
        /// Returns float4.xxw swizzling.
        /// </summary>
        public float3 xxw => new float3(x, x, w);

        /// <summary>
        /// Returns float4.rra swizzling (equivalent to float4.xxw).
        /// </summary>
        public float3 rra => new float3(x, x, w);

        /// <summary>
        /// Returns float4.xxwx swizzling.
        /// </summary>
        public float4 xxwx => new float4(x, x, w, x);

        /// <summary>
        /// Returns float4.rrar swizzling (equivalent to float4.xxwx).
        /// </summary>
        public float4 rrar => new float4(x, x, w, x);

        /// <summary>
        /// Returns float4.xxwy swizzling.
        /// </summary>
        public float4 xxwy => new float4(x, x, w, y);

        /// <summary>
        /// Returns float4.rrag swizzling (equivalent to float4.xxwy).
        /// </summary>
        public float4 rrag => new float4(x, x, w, y);

        /// <summary>
        /// Returns float4.xxwz swizzling.
        /// </summary>
        public float4 xxwz => new float4(x, x, w, z);

        /// <summary>
        /// Returns float4.rrab swizzling (equivalent to float4.xxwz).
        /// </summary>
        public float4 rrab => new float4(x, x, w, z);

        /// <summary>
        /// Returns float4.xxww swizzling.
        /// </summary>
        public float4 xxww => new float4(x, x, w, w);

        /// <summary>
        /// Returns float4.rraa swizzling (equivalent to float4.xxww).
        /// </summary>
        public float4 rraa => new float4(x, x, w, w);

        /// <summary>
        /// Returns float4.xy swizzling.
        /// </summary>
        public float2 xy => new float2(x, y);

        /// <summary>
        /// Returns float4.rg swizzling (equivalent to float4.xy).
        /// </summary>
        public float2 rg => new float2(x, y);

        /// <summary>
        /// Returns float4.xyx swizzling.
        /// </summary>
        public float3 xyx => new float3(x, y, x);

        /// <summary>
        /// Returns float4.rgr swizzling (equivalent to float4.xyx).
        /// </summary>
        public float3 rgr => new float3(x, y, x);

        /// <summary>
        /// Returns float4.xyxx swizzling.
        /// </summary>
        public float4 xyxx => new float4(x, y, x, x);

        /// <summary>
        /// Returns float4.rgrr swizzling (equivalent to float4.xyxx).
        /// </summary>
        public float4 rgrr => new float4(x, y, x, x);

        /// <summary>
        /// Returns float4.xyxy swizzling.
        /// </summary>
        public float4 xyxy => new float4(x, y, x, y);

        /// <summary>
        /// Returns float4.rgrg swizzling (equivalent to float4.xyxy).
        /// </summary>
        public float4 rgrg => new float4(x, y, x, y);

        /// <summary>
        /// Returns float4.xyxz swizzling.
        /// </summary>
        public float4 xyxz => new float4(x, y, x, z);

        /// <summary>
        /// Returns float4.rgrb swizzling (equivalent to float4.xyxz).
        /// </summary>
        public float4 rgrb => new float4(x, y, x, z);

        /// <summary>
        /// Returns float4.xyxw swizzling.
        /// </summary>
        public float4 xyxw => new float4(x, y, x, w);

        /// <summary>
        /// Returns float4.rgra swizzling (equivalent to float4.xyxw).
        /// </summary>
        public float4 rgra => new float4(x, y, x, w);

        /// <summary>
        /// Returns float4.xyy swizzling.
        /// </summary>
        public float3 xyy => new float3(x, y, y);

        /// <summary>
        /// Returns float4.rgg swizzling (equivalent to float4.xyy).
        /// </summary>
        public float3 rgg => new float3(x, y, y);

        /// <summary>
        /// Returns float4.xyyx swizzling.
        /// </summary>
        public float4 xyyx => new float4(x, y, y, x);

        /// <summary>
        /// Returns float4.rggr swizzling (equivalent to float4.xyyx).
        /// </summary>
        public float4 rggr => new float4(x, y, y, x);

        /// <summary>
        /// Returns float4.xyyy swizzling.
        /// </summary>
        public float4 xyyy => new float4(x, y, y, y);

        /// <summary>
        /// Returns float4.rggg swizzling (equivalent to float4.xyyy).
        /// </summary>
        public float4 rggg => new float4(x, y, y, y);

        /// <summary>
        /// Returns float4.xyyz swizzling.
        /// </summary>
        public float4 xyyz => new float4(x, y, y, z);

        /// <summary>
        /// Returns float4.rggb swizzling (equivalent to float4.xyyz).
        /// </summary>
        public float4 rggb => new float4(x, y, y, z);

        /// <summary>
        /// Returns float4.xyyw swizzling.
        /// </summary>
        public float4 xyyw => new float4(x, y, y, w);

        /// <summary>
        /// Returns float4.rgga swizzling (equivalent to float4.xyyw).
        /// </summary>
        public float4 rgga => new float4(x, y, y, w);

        /// <summary>
        /// Returns float4.xyz swizzling.
        /// </summary>
        public float3 xyz => new float3(x, y, z);

        /// <summary>
        /// Returns float4.rgb swizzling (equivalent to float4.xyz).
        /// </summary>
        public float3 rgb => new float3(x, y, z);

        /// <summary>
        /// Returns float4.xyzx swizzling.
        /// </summary>
        public float4 xyzx => new float4(x, y, z, x);

        /// <summary>
        /// Returns float4.rgbr swizzling (equivalent to float4.xyzx).
        /// </summary>
        public float4 rgbr => new float4(x, y, z, x);

        /// <summary>
        /// Returns float4.xyzy swizzling.
        /// </summary>
        public float4 xyzy => new float4(x, y, z, y);

        /// <summary>
        /// Returns float4.rgbg swizzling (equivalent to float4.xyzy).
        /// </summary>
        public float4 rgbg => new float4(x, y, z, y);

        /// <summary>
        /// Returns float4.xyzz swizzling.
        /// </summary>
        public float4 xyzz => new float4(x, y, z, z);

        /// <summary>
        /// Returns float4.rgbb swizzling (equivalent to float4.xyzz).
        /// </summary>
        public float4 rgbb => new float4(x, y, z, z);

        /// <summary>
        /// Returns float4.xyzw swizzling.
        /// </summary>
        public float4 xyzw => new float4(x, y, z, w);

        /// <summary>
        /// Returns float4.rgba swizzling (equivalent to float4.xyzw).
        /// </summary>
        public float4 rgba => new float4(x, y, z, w);

        /// <summary>
        /// Returns float4.xyw swizzling.
        /// </summary>
        public float3 xyw => new float3(x, y, w);

        /// <summary>
        /// Returns float4.rga swizzling (equivalent to float4.xyw).
        /// </summary>
        public float3 rga => new float3(x, y, w);

        /// <summary>
        /// Returns float4.xywx swizzling.
        /// </summary>
        public float4 xywx => new float4(x, y, w, x);

        /// <summary>
        /// Returns float4.rgar swizzling (equivalent to float4.xywx).
        /// </summary>
        public float4 rgar => new float4(x, y, w, x);

        /// <summary>
        /// Returns float4.xywy swizzling.
        /// </summary>
        public float4 xywy => new float4(x, y, w, y);

        /// <summary>
        /// Returns float4.rgag swizzling (equivalent to float4.xywy).
        /// </summary>
        public float4 rgag => new float4(x, y, w, y);

        /// <summary>
        /// Returns float4.xywz swizzling.
        /// </summary>
        public float4 xywz => new float4(x, y, w, z);

        /// <summary>
        /// Returns float4.rgab swizzling (equivalent to float4.xywz).
        /// </summary>
        public float4 rgab => new float4(x, y, w, z);

        /// <summary>
        /// Returns float4.xyww swizzling.
        /// </summary>
        public float4 xyww => new float4(x, y, w, w);

        /// <summary>
        /// Returns float4.rgaa swizzling (equivalent to float4.xyww).
        /// </summary>
        public float4 rgaa => new float4(x, y, w, w);

        /// <summary>
        /// Returns float4.xz swizzling.
        /// </summary>
        public float2 xz => new float2(x, z);

        /// <summary>
        /// Returns float4.rb swizzling (equivalent to float4.xz).
        /// </summary>
        public float2 rb => new float2(x, z);

        /// <summary>
        /// Returns float4.xzx swizzling.
        /// </summary>
        public float3 xzx => new float3(x, z, x);

        /// <summary>
        /// Returns float4.rbr swizzling (equivalent to float4.xzx).
        /// </summary>
        public float3 rbr => new float3(x, z, x);

        /// <summary>
        /// Returns float4.xzxx swizzling.
        /// </summary>
        public float4 xzxx => new float4(x, z, x, x);

        /// <summary>
        /// Returns float4.rbrr swizzling (equivalent to float4.xzxx).
        /// </summary>
        public float4 rbrr => new float4(x, z, x, x);

        /// <summary>
        /// Returns float4.xzxy swizzling.
        /// </summary>
        public float4 xzxy => new float4(x, z, x, y);

        /// <summary>
        /// Returns float4.rbrg swizzling (equivalent to float4.xzxy).
        /// </summary>
        public float4 rbrg => new float4(x, z, x, y);

        /// <summary>
        /// Returns float4.xzxz swizzling.
        /// </summary>
        public float4 xzxz => new float4(x, z, x, z);

        /// <summary>
        /// Returns float4.rbrb swizzling (equivalent to float4.xzxz).
        /// </summary>
        public float4 rbrb => new float4(x, z, x, z);

        /// <summary>
        /// Returns float4.xzxw swizzling.
        /// </summary>
        public float4 xzxw => new float4(x, z, x, w);

        /// <summary>
        /// Returns float4.rbra swizzling (equivalent to float4.xzxw).
        /// </summary>
        public float4 rbra => new float4(x, z, x, w);

        /// <summary>
        /// Returns float4.xzy swizzling.
        /// </summary>
        public float3 xzy => new float3(x, z, y);

        /// <summary>
        /// Returns float4.rbg swizzling (equivalent to float4.xzy).
        /// </summary>
        public float3 rbg => new float3(x, z, y);

        /// <summary>
        /// Returns float4.xzyx swizzling.
        /// </summary>
        public float4 xzyx => new float4(x, z, y, x);

        /// <summary>
        /// Returns float4.rbgr swizzling (equivalent to float4.xzyx).
        /// </summary>
        public float4 rbgr => new float4(x, z, y, x);

        /// <summary>
        /// Returns float4.xzyy swizzling.
        /// </summary>
        public float4 xzyy => new float4(x, z, y, y);

        /// <summary>
        /// Returns float4.rbgg swizzling (equivalent to float4.xzyy).
        /// </summary>
        public float4 rbgg => new float4(x, z, y, y);

        /// <summary>
        /// Returns float4.xzyz swizzling.
        /// </summary>
        public float4 xzyz => new float4(x, z, y, z);

        /// <summary>
        /// Returns float4.rbgb swizzling (equivalent to float4.xzyz).
        /// </summary>
        public float4 rbgb => new float4(x, z, y, z);

        /// <summary>
        /// Returns float4.xzyw swizzling.
        /// </summary>
        public float4 xzyw => new float4(x, z, y, w);

        /// <summary>
        /// Returns float4.rbga swizzling (equivalent to float4.xzyw).
        /// </summary>
        public float4 rbga => new float4(x, z, y, w);

        /// <summary>
        /// Returns float4.xzz swizzling.
        /// </summary>
        public float3 xzz => new float3(x, z, z);

        /// <summary>
        /// Returns float4.rbb swizzling (equivalent to float4.xzz).
        /// </summary>
        public float3 rbb => new float3(x, z, z);

        /// <summary>
        /// Returns float4.xzzx swizzling.
        /// </summary>
        public float4 xzzx => new float4(x, z, z, x);

        /// <summary>
        /// Returns float4.rbbr swizzling (equivalent to float4.xzzx).
        /// </summary>
        public float4 rbbr => new float4(x, z, z, x);

        /// <summary>
        /// Returns float4.xzzy swizzling.
        /// </summary>
        public float4 xzzy => new float4(x, z, z, y);

        /// <summary>
        /// Returns float4.rbbg swizzling (equivalent to float4.xzzy).
        /// </summary>
        public float4 rbbg => new float4(x, z, z, y);

        /// <summary>
        /// Returns float4.xzzz swizzling.
        /// </summary>
        public float4 xzzz => new float4(x, z, z, z);

        /// <summary>
        /// Returns float4.rbbb swizzling (equivalent to float4.xzzz).
        /// </summary>
        public float4 rbbb => new float4(x, z, z, z);

        /// <summary>
        /// Returns float4.xzzw swizzling.
        /// </summary>
        public float4 xzzw => new float4(x, z, z, w);

        /// <summary>
        /// Returns float4.rbba swizzling (equivalent to float4.xzzw).
        /// </summary>
        public float4 rbba => new float4(x, z, z, w);

        /// <summary>
        /// Returns float4.xzw swizzling.
        /// </summary>
        public float3 xzw => new float3(x, z, w);

        /// <summary>
        /// Returns float4.rba swizzling (equivalent to float4.xzw).
        /// </summary>
        public float3 rba => new float3(x, z, w);

        /// <summary>
        /// Returns float4.xzwx swizzling.
        /// </summary>
        public float4 xzwx => new float4(x, z, w, x);

        /// <summary>
        /// Returns float4.rbar swizzling (equivalent to float4.xzwx).
        /// </summary>
        public float4 rbar => new float4(x, z, w, x);

        /// <summary>
        /// Returns float4.xzwy swizzling.
        /// </summary>
        public float4 xzwy => new float4(x, z, w, y);

        /// <summary>
        /// Returns float4.rbag swizzling (equivalent to float4.xzwy).
        /// </summary>
        public float4 rbag => new float4(x, z, w, y);

        /// <summary>
        /// Returns float4.xzwz swizzling.
        /// </summary>
        public float4 xzwz => new float4(x, z, w, z);

        /// <summary>
        /// Returns float4.rbab swizzling (equivalent to float4.xzwz).
        /// </summary>
        public float4 rbab => new float4(x, z, w, z);

        /// <summary>
        /// Returns float4.xzww swizzling.
        /// </summary>
        public float4 xzww => new float4(x, z, w, w);

        /// <summary>
        /// Returns float4.rbaa swizzling (equivalent to float4.xzww).
        /// </summary>
        public float4 rbaa => new float4(x, z, w, w);

        /// <summary>
        /// Returns float4.xw swizzling.
        /// </summary>
        public float2 xw => new float2(x, w);

        /// <summary>
        /// Returns float4.ra swizzling (equivalent to float4.xw).
        /// </summary>
        public float2 ra => new float2(x, w);

        /// <summary>
        /// Returns float4.xwx swizzling.
        /// </summary>
        public float3 xwx => new float3(x, w, x);

        /// <summary>
        /// Returns float4.rar swizzling (equivalent to float4.xwx).
        /// </summary>
        public float3 rar => new float3(x, w, x);

        /// <summary>
        /// Returns float4.xwxx swizzling.
        /// </summary>
        public float4 xwxx => new float4(x, w, x, x);

        /// <summary>
        /// Returns float4.rarr swizzling (equivalent to float4.xwxx).
        /// </summary>
        public float4 rarr => new float4(x, w, x, x);

        /// <summary>
        /// Returns float4.xwxy swizzling.
        /// </summary>
        public float4 xwxy => new float4(x, w, x, y);

        /// <summary>
        /// Returns float4.rarg swizzling (equivalent to float4.xwxy).
        /// </summary>
        public float4 rarg => new float4(x, w, x, y);

        /// <summary>
        /// Returns float4.xwxz swizzling.
        /// </summary>
        public float4 xwxz => new float4(x, w, x, z);

        /// <summary>
        /// Returns float4.rarb swizzling (equivalent to float4.xwxz).
        /// </summary>
        public float4 rarb => new float4(x, w, x, z);

        /// <summary>
        /// Returns float4.xwxw swizzling.
        /// </summary>
        public float4 xwxw => new float4(x, w, x, w);

        /// <summary>
        /// Returns float4.rara swizzling (equivalent to float4.xwxw).
        /// </summary>
        public float4 rara => new float4(x, w, x, w);

        /// <summary>
        /// Returns float4.xwy swizzling.
        /// </summary>
        public float3 xwy => new float3(x, w, y);

        /// <summary>
        /// Returns float4.rag swizzling (equivalent to float4.xwy).
        /// </summary>
        public float3 rag => new float3(x, w, y);

        /// <summary>
        /// Returns float4.xwyx swizzling.
        /// </summary>
        public float4 xwyx => new float4(x, w, y, x);

        /// <summary>
        /// Returns float4.ragr swizzling (equivalent to float4.xwyx).
        /// </summary>
        public float4 ragr => new float4(x, w, y, x);

        /// <summary>
        /// Returns float4.xwyy swizzling.
        /// </summary>
        public float4 xwyy => new float4(x, w, y, y);

        /// <summary>
        /// Returns float4.ragg swizzling (equivalent to float4.xwyy).
        /// </summary>
        public float4 ragg => new float4(x, w, y, y);

        /// <summary>
        /// Returns float4.xwyz swizzling.
        /// </summary>
        public float4 xwyz => new float4(x, w, y, z);

        /// <summary>
        /// Returns float4.ragb swizzling (equivalent to float4.xwyz).
        /// </summary>
        public float4 ragb => new float4(x, w, y, z);

        /// <summary>
        /// Returns float4.xwyw swizzling.
        /// </summary>
        public float4 xwyw => new float4(x, w, y, w);

        /// <summary>
        /// Returns float4.raga swizzling (equivalent to float4.xwyw).
        /// </summary>
        public float4 raga => new float4(x, w, y, w);

        /// <summary>
        /// Returns float4.xwz swizzling.
        /// </summary>
        public float3 xwz => new float3(x, w, z);

        /// <summary>
        /// Returns float4.rab swizzling (equivalent to float4.xwz).
        /// </summary>
        public float3 rab => new float3(x, w, z);

        /// <summary>
        /// Returns float4.xwzx swizzling.
        /// </summary>
        public float4 xwzx => new float4(x, w, z, x);

        /// <summary>
        /// Returns float4.rabr swizzling (equivalent to float4.xwzx).
        /// </summary>
        public float4 rabr => new float4(x, w, z, x);

        /// <summary>
        /// Returns float4.xwzy swizzling.
        /// </summary>
        public float4 xwzy => new float4(x, w, z, y);

        /// <summary>
        /// Returns float4.rabg swizzling (equivalent to float4.xwzy).
        /// </summary>
        public float4 rabg => new float4(x, w, z, y);

        /// <summary>
        /// Returns float4.xwzz swizzling.
        /// </summary>
        public float4 xwzz => new float4(x, w, z, z);

        /// <summary>
        /// Returns float4.rabb swizzling (equivalent to float4.xwzz).
        /// </summary>
        public float4 rabb => new float4(x, w, z, z);

        /// <summary>
        /// Returns float4.xwzw swizzling.
        /// </summary>
        public float4 xwzw => new float4(x, w, z, w);

        /// <summary>
        /// Returns float4.raba swizzling (equivalent to float4.xwzw).
        /// </summary>
        public float4 raba => new float4(x, w, z, w);

        /// <summary>
        /// Returns float4.xww swizzling.
        /// </summary>
        public float3 xww => new float3(x, w, w);

        /// <summary>
        /// Returns float4.raa swizzling (equivalent to float4.xww).
        /// </summary>
        public float3 raa => new float3(x, w, w);

        /// <summary>
        /// Returns float4.xwwx swizzling.
        /// </summary>
        public float4 xwwx => new float4(x, w, w, x);

        /// <summary>
        /// Returns float4.raar swizzling (equivalent to float4.xwwx).
        /// </summary>
        public float4 raar => new float4(x, w, w, x);

        /// <summary>
        /// Returns float4.xwwy swizzling.
        /// </summary>
        public float4 xwwy => new float4(x, w, w, y);

        /// <summary>
        /// Returns float4.raag swizzling (equivalent to float4.xwwy).
        /// </summary>
        public float4 raag => new float4(x, w, w, y);

        /// <summary>
        /// Returns float4.xwwz swizzling.
        /// </summary>
        public float4 xwwz => new float4(x, w, w, z);

        /// <summary>
        /// Returns float4.raab swizzling (equivalent to float4.xwwz).
        /// </summary>
        public float4 raab => new float4(x, w, w, z);

        /// <summary>
        /// Returns float4.xwww swizzling.
        /// </summary>
        public float4 xwww => new float4(x, w, w, w);

        /// <summary>
        /// Returns float4.raaa swizzling (equivalent to float4.xwww).
        /// </summary>
        public float4 raaa => new float4(x, w, w, w);

        /// <summary>
        /// Returns float4.yx swizzling.
        /// </summary>
        public float2 yx => new float2(y, x);

        /// <summary>
        /// Returns float4.gr swizzling (equivalent to float4.yx).
        /// </summary>
        public float2 gr => new float2(y, x);

        /// <summary>
        /// Returns float4.yxx swizzling.
        /// </summary>
        public float3 yxx => new float3(y, x, x);

        /// <summary>
        /// Returns float4.grr swizzling (equivalent to float4.yxx).
        /// </summary>
        public float3 grr => new float3(y, x, x);

        /// <summary>
        /// Returns float4.yxxx swizzling.
        /// </summary>
        public float4 yxxx => new float4(y, x, x, x);

        /// <summary>
        /// Returns float4.grrr swizzling (equivalent to float4.yxxx).
        /// </summary>
        public float4 grrr => new float4(y, x, x, x);

        /// <summary>
        /// Returns float4.yxxy swizzling.
        /// </summary>
        public float4 yxxy => new float4(y, x, x, y);

        /// <summary>
        /// Returns float4.grrg swizzling (equivalent to float4.yxxy).
        /// </summary>
        public float4 grrg => new float4(y, x, x, y);

        /// <summary>
        /// Returns float4.yxxz swizzling.
        /// </summary>
        public float4 yxxz => new float4(y, x, x, z);

        /// <summary>
        /// Returns float4.grrb swizzling (equivalent to float4.yxxz).
        /// </summary>
        public float4 grrb => new float4(y, x, x, z);

        /// <summary>
        /// Returns float4.yxxw swizzling.
        /// </summary>
        public float4 yxxw => new float4(y, x, x, w);

        /// <summary>
        /// Returns float4.grra swizzling (equivalent to float4.yxxw).
        /// </summary>
        public float4 grra => new float4(y, x, x, w);

        /// <summary>
        /// Returns float4.yxy swizzling.
        /// </summary>
        public float3 yxy => new float3(y, x, y);

        /// <summary>
        /// Returns float4.grg swizzling (equivalent to float4.yxy).
        /// </summary>
        public float3 grg => new float3(y, x, y);

        /// <summary>
        /// Returns float4.yxyx swizzling.
        /// </summary>
        public float4 yxyx => new float4(y, x, y, x);

        /// <summary>
        /// Returns float4.grgr swizzling (equivalent to float4.yxyx).
        /// </summary>
        public float4 grgr => new float4(y, x, y, x);

        /// <summary>
        /// Returns float4.yxyy swizzling.
        /// </summary>
        public float4 yxyy => new float4(y, x, y, y);

        /// <summary>
        /// Returns float4.grgg swizzling (equivalent to float4.yxyy).
        /// </summary>
        public float4 grgg => new float4(y, x, y, y);

        /// <summary>
        /// Returns float4.yxyz swizzling.
        /// </summary>
        public float4 yxyz => new float4(y, x, y, z);

        /// <summary>
        /// Returns float4.grgb swizzling (equivalent to float4.yxyz).
        /// </summary>
        public float4 grgb => new float4(y, x, y, z);

        /// <summary>
        /// Returns float4.yxyw swizzling.
        /// </summary>
        public float4 yxyw => new float4(y, x, y, w);

        /// <summary>
        /// Returns float4.grga swizzling (equivalent to float4.yxyw).
        /// </summary>
        public float4 grga => new float4(y, x, y, w);

        /// <summary>
        /// Returns float4.yxz swizzling.
        /// </summary>
        public float3 yxz => new float3(y, x, z);

        /// <summary>
        /// Returns float4.grb swizzling (equivalent to float4.yxz).
        /// </summary>
        public float3 grb => new float3(y, x, z);

        /// <summary>
        /// Returns float4.yxzx swizzling.
        /// </summary>
        public float4 yxzx => new float4(y, x, z, x);

        /// <summary>
        /// Returns float4.grbr swizzling (equivalent to float4.yxzx).
        /// </summary>
        public float4 grbr => new float4(y, x, z, x);

        /// <summary>
        /// Returns float4.yxzy swizzling.
        /// </summary>
        public float4 yxzy => new float4(y, x, z, y);

        /// <summary>
        /// Returns float4.grbg swizzling (equivalent to float4.yxzy).
        /// </summary>
        public float4 grbg => new float4(y, x, z, y);

        /// <summary>
        /// Returns float4.yxzz swizzling.
        /// </summary>
        public float4 yxzz => new float4(y, x, z, z);

        /// <summary>
        /// Returns float4.grbb swizzling (equivalent to float4.yxzz).
        /// </summary>
        public float4 grbb => new float4(y, x, z, z);

        /// <summary>
        /// Returns float4.yxzw swizzling.
        /// </summary>
        public float4 yxzw => new float4(y, x, z, w);

        /// <summary>
        /// Returns float4.grba swizzling (equivalent to float4.yxzw).
        /// </summary>
        public float4 grba => new float4(y, x, z, w);

        /// <summary>
        /// Returns float4.yxw swizzling.
        /// </summary>
        public float3 yxw => new float3(y, x, w);

        /// <summary>
        /// Returns float4.gra swizzling (equivalent to float4.yxw).
        /// </summary>
        public float3 gra => new float3(y, x, w);

        /// <summary>
        /// Returns float4.yxwx swizzling.
        /// </summary>
        public float4 yxwx => new float4(y, x, w, x);

        /// <summary>
        /// Returns float4.grar swizzling (equivalent to float4.yxwx).
        /// </summary>
        public float4 grar => new float4(y, x, w, x);

        /// <summary>
        /// Returns float4.yxwy swizzling.
        /// </summary>
        public float4 yxwy => new float4(y, x, w, y);

        /// <summary>
        /// Returns float4.grag swizzling (equivalent to float4.yxwy).
        /// </summary>
        public float4 grag => new float4(y, x, w, y);

        /// <summary>
        /// Returns float4.yxwz swizzling.
        /// </summary>
        public float4 yxwz => new float4(y, x, w, z);

        /// <summary>
        /// Returns float4.grab swizzling (equivalent to float4.yxwz).
        /// </summary>
        public float4 grab => new float4(y, x, w, z);

        /// <summary>
        /// Returns float4.yxww swizzling.
        /// </summary>
        public float4 yxww => new float4(y, x, w, w);

        /// <summary>
        /// Returns float4.graa swizzling (equivalent to float4.yxww).
        /// </summary>
        public float4 graa => new float4(y, x, w, w);

        /// <summary>
        /// Returns float4.yy swizzling.
        /// </summary>
        public float2 yy => new float2(y, y);

        /// <summary>
        /// Returns float4.gg swizzling (equivalent to float4.yy).
        /// </summary>
        public float2 gg => new float2(y, y);

        /// <summary>
        /// Returns float4.yyx swizzling.
        /// </summary>
        public float3 yyx => new float3(y, y, x);

        /// <summary>
        /// Returns float4.ggr swizzling (equivalent to float4.yyx).
        /// </summary>
        public float3 ggr => new float3(y, y, x);

        /// <summary>
        /// Returns float4.yyxx swizzling.
        /// </summary>
        public float4 yyxx => new float4(y, y, x, x);

        /// <summary>
        /// Returns float4.ggrr swizzling (equivalent to float4.yyxx).
        /// </summary>
        public float4 ggrr => new float4(y, y, x, x);

        /// <summary>
        /// Returns float4.yyxy swizzling.
        /// </summary>
        public float4 yyxy => new float4(y, y, x, y);

        /// <summary>
        /// Returns float4.ggrg swizzling (equivalent to float4.yyxy).
        /// </summary>
        public float4 ggrg => new float4(y, y, x, y);

        /// <summary>
        /// Returns float4.yyxz swizzling.
        /// </summary>
        public float4 yyxz => new float4(y, y, x, z);

        /// <summary>
        /// Returns float4.ggrb swizzling (equivalent to float4.yyxz).
        /// </summary>
        public float4 ggrb => new float4(y, y, x, z);

        /// <summary>
        /// Returns float4.yyxw swizzling.
        /// </summary>
        public float4 yyxw => new float4(y, y, x, w);

        /// <summary>
        /// Returns float4.ggra swizzling (equivalent to float4.yyxw).
        /// </summary>
        public float4 ggra => new float4(y, y, x, w);

        /// <summary>
        /// Returns float4.yyy swizzling.
        /// </summary>
        public float3 yyy => new float3(y, y, y);

        /// <summary>
        /// Returns float4.ggg swizzling (equivalent to float4.yyy).
        /// </summary>
        public float3 ggg => new float3(y, y, y);

        /// <summary>
        /// Returns float4.yyyx swizzling.
        /// </summary>
        public float4 yyyx => new float4(y, y, y, x);

        /// <summary>
        /// Returns float4.gggr swizzling (equivalent to float4.yyyx).
        /// </summary>
        public float4 gggr => new float4(y, y, y, x);

        /// <summary>
        /// Returns float4.yyyy swizzling.
        /// </summary>
        public float4 yyyy => new float4(y, y, y, y);

        /// <summary>
        /// Returns float4.gggg swizzling (equivalent to float4.yyyy).
        /// </summary>
        public float4 gggg => new float4(y, y, y, y);

        /// <summary>
        /// Returns float4.yyyz swizzling.
        /// </summary>
        public float4 yyyz => new float4(y, y, y, z);

        /// <summary>
        /// Returns float4.gggb swizzling (equivalent to float4.yyyz).
        /// </summary>
        public float4 gggb => new float4(y, y, y, z);

        /// <summary>
        /// Returns float4.yyyw swizzling.
        /// </summary>
        public float4 yyyw => new float4(y, y, y, w);

        /// <summary>
        /// Returns float4.ggga swizzling (equivalent to float4.yyyw).
        /// </summary>
        public float4 ggga => new float4(y, y, y, w);

        /// <summary>
        /// Returns float4.yyz swizzling.
        /// </summary>
        public float3 yyz => new float3(y, y, z);

        /// <summary>
        /// Returns float4.ggb swizzling (equivalent to float4.yyz).
        /// </summary>
        public float3 ggb => new float3(y, y, z);

        /// <summary>
        /// Returns float4.yyzx swizzling.
        /// </summary>
        public float4 yyzx => new float4(y, y, z, x);

        /// <summary>
        /// Returns float4.ggbr swizzling (equivalent to float4.yyzx).
        /// </summary>
        public float4 ggbr => new float4(y, y, z, x);

        /// <summary>
        /// Returns float4.yyzy swizzling.
        /// </summary>
        public float4 yyzy => new float4(y, y, z, y);

        /// <summary>
        /// Returns float4.ggbg swizzling (equivalent to float4.yyzy).
        /// </summary>
        public float4 ggbg => new float4(y, y, z, y);

        /// <summary>
        /// Returns float4.yyzz swizzling.
        /// </summary>
        public float4 yyzz => new float4(y, y, z, z);

        /// <summary>
        /// Returns float4.ggbb swizzling (equivalent to float4.yyzz).
        /// </summary>
        public float4 ggbb => new float4(y, y, z, z);

        /// <summary>
        /// Returns float4.yyzw swizzling.
        /// </summary>
        public float4 yyzw => new float4(y, y, z, w);

        /// <summary>
        /// Returns float4.ggba swizzling (equivalent to float4.yyzw).
        /// </summary>
        public float4 ggba => new float4(y, y, z, w);

        /// <summary>
        /// Returns float4.yyw swizzling.
        /// </summary>
        public float3 yyw => new float3(y, y, w);

        /// <summary>
        /// Returns float4.gga swizzling (equivalent to float4.yyw).
        /// </summary>
        public float3 gga => new float3(y, y, w);

        /// <summary>
        /// Returns float4.yywx swizzling.
        /// </summary>
        public float4 yywx => new float4(y, y, w, x);

        /// <summary>
        /// Returns float4.ggar swizzling (equivalent to float4.yywx).
        /// </summary>
        public float4 ggar => new float4(y, y, w, x);

        /// <summary>
        /// Returns float4.yywy swizzling.
        /// </summary>
        public float4 yywy => new float4(y, y, w, y);

        /// <summary>
        /// Returns float4.ggag swizzling (equivalent to float4.yywy).
        /// </summary>
        public float4 ggag => new float4(y, y, w, y);

        /// <summary>
        /// Returns float4.yywz swizzling.
        /// </summary>
        public float4 yywz => new float4(y, y, w, z);

        /// <summary>
        /// Returns float4.ggab swizzling (equivalent to float4.yywz).
        /// </summary>
        public float4 ggab => new float4(y, y, w, z);

        /// <summary>
        /// Returns float4.yyww swizzling.
        /// </summary>
        public float4 yyww => new float4(y, y, w, w);

        /// <summary>
        /// Returns float4.ggaa swizzling (equivalent to float4.yyww).
        /// </summary>
        public float4 ggaa => new float4(y, y, w, w);

        /// <summary>
        /// Returns float4.yz swizzling.
        /// </summary>
        public float2 yz => new float2(y, z);

        /// <summary>
        /// Returns float4.gb swizzling (equivalent to float4.yz).
        /// </summary>
        public float2 gb => new float2(y, z);

        /// <summary>
        /// Returns float4.yzx swizzling.
        /// </summary>
        public float3 yzx => new float3(y, z, x);

        /// <summary>
        /// Returns float4.gbr swizzling (equivalent to float4.yzx).
        /// </summary>
        public float3 gbr => new float3(y, z, x);

        /// <summary>
        /// Returns float4.yzxx swizzling.
        /// </summary>
        public float4 yzxx => new float4(y, z, x, x);

        /// <summary>
        /// Returns float4.gbrr swizzling (equivalent to float4.yzxx).
        /// </summary>
        public float4 gbrr => new float4(y, z, x, x);

        /// <summary>
        /// Returns float4.yzxy swizzling.
        /// </summary>
        public float4 yzxy => new float4(y, z, x, y);

        /// <summary>
        /// Returns float4.gbrg swizzling (equivalent to float4.yzxy).
        /// </summary>
        public float4 gbrg => new float4(y, z, x, y);

        /// <summary>
        /// Returns float4.yzxz swizzling.
        /// </summary>
        public float4 yzxz => new float4(y, z, x, z);

        /// <summary>
        /// Returns float4.gbrb swizzling (equivalent to float4.yzxz).
        /// </summary>
        public float4 gbrb => new float4(y, z, x, z);

        /// <summary>
        /// Returns float4.yzxw swizzling.
        /// </summary>
        public float4 yzxw => new float4(y, z, x, w);

        /// <summary>
        /// Returns float4.gbra swizzling (equivalent to float4.yzxw).
        /// </summary>
        public float4 gbra => new float4(y, z, x, w);

        /// <summary>
        /// Returns float4.yzy swizzling.
        /// </summary>
        public float3 yzy => new float3(y, z, y);

        /// <summary>
        /// Returns float4.gbg swizzling (equivalent to float4.yzy).
        /// </summary>
        public float3 gbg => new float3(y, z, y);

        /// <summary>
        /// Returns float4.yzyx swizzling.
        /// </summary>
        public float4 yzyx => new float4(y, z, y, x);

        /// <summary>
        /// Returns float4.gbgr swizzling (equivalent to float4.yzyx).
        /// </summary>
        public float4 gbgr => new float4(y, z, y, x);

        /// <summary>
        /// Returns float4.yzyy swizzling.
        /// </summary>
        public float4 yzyy => new float4(y, z, y, y);

        /// <summary>
        /// Returns float4.gbgg swizzling (equivalent to float4.yzyy).
        /// </summary>
        public float4 gbgg => new float4(y, z, y, y);

        /// <summary>
        /// Returns float4.yzyz swizzling.
        /// </summary>
        public float4 yzyz => new float4(y, z, y, z);

        /// <summary>
        /// Returns float4.gbgb swizzling (equivalent to float4.yzyz).
        /// </summary>
        public float4 gbgb => new float4(y, z, y, z);

        /// <summary>
        /// Returns float4.yzyw swizzling.
        /// </summary>
        public float4 yzyw => new float4(y, z, y, w);

        /// <summary>
        /// Returns float4.gbga swizzling (equivalent to float4.yzyw).
        /// </summary>
        public float4 gbga => new float4(y, z, y, w);

        /// <summary>
        /// Returns float4.yzz swizzling.
        /// </summary>
        public float3 yzz => new float3(y, z, z);

        /// <summary>
        /// Returns float4.gbb swizzling (equivalent to float4.yzz).
        /// </summary>
        public float3 gbb => new float3(y, z, z);

        /// <summary>
        /// Returns float4.yzzx swizzling.
        /// </summary>
        public float4 yzzx => new float4(y, z, z, x);

        /// <summary>
        /// Returns float4.gbbr swizzling (equivalent to float4.yzzx).
        /// </summary>
        public float4 gbbr => new float4(y, z, z, x);

        /// <summary>
        /// Returns float4.yzzy swizzling.
        /// </summary>
        public float4 yzzy => new float4(y, z, z, y);

        /// <summary>
        /// Returns float4.gbbg swizzling (equivalent to float4.yzzy).
        /// </summary>
        public float4 gbbg => new float4(y, z, z, y);

        /// <summary>
        /// Returns float4.yzzz swizzling.
        /// </summary>
        public float4 yzzz => new float4(y, z, z, z);

        /// <summary>
        /// Returns float4.gbbb swizzling (equivalent to float4.yzzz).
        /// </summary>
        public float4 gbbb => new float4(y, z, z, z);

        /// <summary>
        /// Returns float4.yzzw swizzling.
        /// </summary>
        public float4 yzzw => new float4(y, z, z, w);

        /// <summary>
        /// Returns float4.gbba swizzling (equivalent to float4.yzzw).
        /// </summary>
        public float4 gbba => new float4(y, z, z, w);

        /// <summary>
        /// Returns float4.yzw swizzling.
        /// </summary>
        public float3 yzw => new float3(y, z, w);

        /// <summary>
        /// Returns float4.gba swizzling (equivalent to float4.yzw).
        /// </summary>
        public float3 gba => new float3(y, z, w);

        /// <summary>
        /// Returns float4.yzwx swizzling.
        /// </summary>
        public float4 yzwx => new float4(y, z, w, x);

        /// <summary>
        /// Returns float4.gbar swizzling (equivalent to float4.yzwx).
        /// </summary>
        public float4 gbar => new float4(y, z, w, x);

        /// <summary>
        /// Returns float4.yzwy swizzling.
        /// </summary>
        public float4 yzwy => new float4(y, z, w, y);

        /// <summary>
        /// Returns float4.gbag swizzling (equivalent to float4.yzwy).
        /// </summary>
        public float4 gbag => new float4(y, z, w, y);

        /// <summary>
        /// Returns float4.yzwz swizzling.
        /// </summary>
        public float4 yzwz => new float4(y, z, w, z);

        /// <summary>
        /// Returns float4.gbab swizzling (equivalent to float4.yzwz).
        /// </summary>
        public float4 gbab => new float4(y, z, w, z);

        /// <summary>
        /// Returns float4.yzww swizzling.
        /// </summary>
        public float4 yzww => new float4(y, z, w, w);

        /// <summary>
        /// Returns float4.gbaa swizzling (equivalent to float4.yzww).
        /// </summary>
        public float4 gbaa => new float4(y, z, w, w);

        /// <summary>
        /// Returns float4.yw swizzling.
        /// </summary>
        public float2 yw => new float2(y, w);

        /// <summary>
        /// Returns float4.ga swizzling (equivalent to float4.yw).
        /// </summary>
        public float2 ga => new float2(y, w);

        /// <summary>
        /// Returns float4.ywx swizzling.
        /// </summary>
        public float3 ywx => new float3(y, w, x);

        /// <summary>
        /// Returns float4.gar swizzling (equivalent to float4.ywx).
        /// </summary>
        public float3 gar => new float3(y, w, x);

        /// <summary>
        /// Returns float4.ywxx swizzling.
        /// </summary>
        public float4 ywxx => new float4(y, w, x, x);

        /// <summary>
        /// Returns float4.garr swizzling (equivalent to float4.ywxx).
        /// </summary>
        public float4 garr => new float4(y, w, x, x);

        /// <summary>
        /// Returns float4.ywxy swizzling.
        /// </summary>
        public float4 ywxy => new float4(y, w, x, y);

        /// <summary>
        /// Returns float4.garg swizzling (equivalent to float4.ywxy).
        /// </summary>
        public float4 garg => new float4(y, w, x, y);

        /// <summary>
        /// Returns float4.ywxz swizzling.
        /// </summary>
        public float4 ywxz => new float4(y, w, x, z);

        /// <summary>
        /// Returns float4.garb swizzling (equivalent to float4.ywxz).
        /// </summary>
        public float4 garb => new float4(y, w, x, z);

        /// <summary>
        /// Returns float4.ywxw swizzling.
        /// </summary>
        public float4 ywxw => new float4(y, w, x, w);

        /// <summary>
        /// Returns float4.gara swizzling (equivalent to float4.ywxw).
        /// </summary>
        public float4 gara => new float4(y, w, x, w);

        /// <summary>
        /// Returns float4.ywy swizzling.
        /// </summary>
        public float3 ywy => new float3(y, w, y);

        /// <summary>
        /// Returns float4.gag swizzling (equivalent to float4.ywy).
        /// </summary>
        public float3 gag => new float3(y, w, y);

        /// <summary>
        /// Returns float4.ywyx swizzling.
        /// </summary>
        public float4 ywyx => new float4(y, w, y, x);

        /// <summary>
        /// Returns float4.gagr swizzling (equivalent to float4.ywyx).
        /// </summary>
        public float4 gagr => new float4(y, w, y, x);

        /// <summary>
        /// Returns float4.ywyy swizzling.
        /// </summary>
        public float4 ywyy => new float4(y, w, y, y);

        /// <summary>
        /// Returns float4.gagg swizzling (equivalent to float4.ywyy).
        /// </summary>
        public float4 gagg => new float4(y, w, y, y);

        /// <summary>
        /// Returns float4.ywyz swizzling.
        /// </summary>
        public float4 ywyz => new float4(y, w, y, z);

        /// <summary>
        /// Returns float4.gagb swizzling (equivalent to float4.ywyz).
        /// </summary>
        public float4 gagb => new float4(y, w, y, z);

        /// <summary>
        /// Returns float4.ywyw swizzling.
        /// </summary>
        public float4 ywyw => new float4(y, w, y, w);

        /// <summary>
        /// Returns float4.gaga swizzling (equivalent to float4.ywyw).
        /// </summary>
        public float4 gaga => new float4(y, w, y, w);

        /// <summary>
        /// Returns float4.ywz swizzling.
        /// </summary>
        public float3 ywz => new float3(y, w, z);

        /// <summary>
        /// Returns float4.gab swizzling (equivalent to float4.ywz).
        /// </summary>
        public float3 gab => new float3(y, w, z);

        /// <summary>
        /// Returns float4.ywzx swizzling.
        /// </summary>
        public float4 ywzx => new float4(y, w, z, x);

        /// <summary>
        /// Returns float4.gabr swizzling (equivalent to float4.ywzx).
        /// </summary>
        public float4 gabr => new float4(y, w, z, x);

        /// <summary>
        /// Returns float4.ywzy swizzling.
        /// </summary>
        public float4 ywzy => new float4(y, w, z, y);

        /// <summary>
        /// Returns float4.gabg swizzling (equivalent to float4.ywzy).
        /// </summary>
        public float4 gabg => new float4(y, w, z, y);

        /// <summary>
        /// Returns float4.ywzz swizzling.
        /// </summary>
        public float4 ywzz => new float4(y, w, z, z);

        /// <summary>
        /// Returns float4.gabb swizzling (equivalent to float4.ywzz).
        /// </summary>
        public float4 gabb => new float4(y, w, z, z);

        /// <summary>
        /// Returns float4.ywzw swizzling.
        /// </summary>
        public float4 ywzw => new float4(y, w, z, w);

        /// <summary>
        /// Returns float4.gaba swizzling (equivalent to float4.ywzw).
        /// </summary>
        public float4 gaba => new float4(y, w, z, w);

        /// <summary>
        /// Returns float4.yww swizzling.
        /// </summary>
        public float3 yww => new float3(y, w, w);

        /// <summary>
        /// Returns float4.gaa swizzling (equivalent to float4.yww).
        /// </summary>
        public float3 gaa => new float3(y, w, w);

        /// <summary>
        /// Returns float4.ywwx swizzling.
        /// </summary>
        public float4 ywwx => new float4(y, w, w, x);

        /// <summary>
        /// Returns float4.gaar swizzling (equivalent to float4.ywwx).
        /// </summary>
        public float4 gaar => new float4(y, w, w, x);

        /// <summary>
        /// Returns float4.ywwy swizzling.
        /// </summary>
        public float4 ywwy => new float4(y, w, w, y);

        /// <summary>
        /// Returns float4.gaag swizzling (equivalent to float4.ywwy).
        /// </summary>
        public float4 gaag => new float4(y, w, w, y);

        /// <summary>
        /// Returns float4.ywwz swizzling.
        /// </summary>
        public float4 ywwz => new float4(y, w, w, z);

        /// <summary>
        /// Returns float4.gaab swizzling (equivalent to float4.ywwz).
        /// </summary>
        public float4 gaab => new float4(y, w, w, z);

        /// <summary>
        /// Returns float4.ywww swizzling.
        /// </summary>
        public float4 ywww => new float4(y, w, w, w);

        /// <summary>
        /// Returns float4.gaaa swizzling (equivalent to float4.ywww).
        /// </summary>
        public float4 gaaa => new float4(y, w, w, w);

        /// <summary>
        /// Returns float4.zx swizzling.
        /// </summary>
        public float2 zx => new float2(z, x);

        /// <summary>
        /// Returns float4.br swizzling (equivalent to float4.zx).
        /// </summary>
        public float2 br => new float2(z, x);

        /// <summary>
        /// Returns float4.zxx swizzling.
        /// </summary>
        public float3 zxx => new float3(z, x, x);

        /// <summary>
        /// Returns float4.brr swizzling (equivalent to float4.zxx).
        /// </summary>
        public float3 brr => new float3(z, x, x);

        /// <summary>
        /// Returns float4.zxxx swizzling.
        /// </summary>
        public float4 zxxx => new float4(z, x, x, x);

        /// <summary>
        /// Returns float4.brrr swizzling (equivalent to float4.zxxx).
        /// </summary>
        public float4 brrr => new float4(z, x, x, x);

        /// <summary>
        /// Returns float4.zxxy swizzling.
        /// </summary>
        public float4 zxxy => new float4(z, x, x, y);

        /// <summary>
        /// Returns float4.brrg swizzling (equivalent to float4.zxxy).
        /// </summary>
        public float4 brrg => new float4(z, x, x, y);

        /// <summary>
        /// Returns float4.zxxz swizzling.
        /// </summary>
        public float4 zxxz => new float4(z, x, x, z);

        /// <summary>
        /// Returns float4.brrb swizzling (equivalent to float4.zxxz).
        /// </summary>
        public float4 brrb => new float4(z, x, x, z);

        /// <summary>
        /// Returns float4.zxxw swizzling.
        /// </summary>
        public float4 zxxw => new float4(z, x, x, w);

        /// <summary>
        /// Returns float4.brra swizzling (equivalent to float4.zxxw).
        /// </summary>
        public float4 brra => new float4(z, x, x, w);

        /// <summary>
        /// Returns float4.zxy swizzling.
        /// </summary>
        public float3 zxy => new float3(z, x, y);

        /// <summary>
        /// Returns float4.brg swizzling (equivalent to float4.zxy).
        /// </summary>
        public float3 brg => new float3(z, x, y);

        /// <summary>
        /// Returns float4.zxyx swizzling.
        /// </summary>
        public float4 zxyx => new float4(z, x, y, x);

        /// <summary>
        /// Returns float4.brgr swizzling (equivalent to float4.zxyx).
        /// </summary>
        public float4 brgr => new float4(z, x, y, x);

        /// <summary>
        /// Returns float4.zxyy swizzling.
        /// </summary>
        public float4 zxyy => new float4(z, x, y, y);

        /// <summary>
        /// Returns float4.brgg swizzling (equivalent to float4.zxyy).
        /// </summary>
        public float4 brgg => new float4(z, x, y, y);

        /// <summary>
        /// Returns float4.zxyz swizzling.
        /// </summary>
        public float4 zxyz => new float4(z, x, y, z);

        /// <summary>
        /// Returns float4.brgb swizzling (equivalent to float4.zxyz).
        /// </summary>
        public float4 brgb => new float4(z, x, y, z);

        /// <summary>
        /// Returns float4.zxyw swizzling.
        /// </summary>
        public float4 zxyw => new float4(z, x, y, w);

        /// <summary>
        /// Returns float4.brga swizzling (equivalent to float4.zxyw).
        /// </summary>
        public float4 brga => new float4(z, x, y, w);

        /// <summary>
        /// Returns float4.zxz swizzling.
        /// </summary>
        public float3 zxz => new float3(z, x, z);

        /// <summary>
        /// Returns float4.brb swizzling (equivalent to float4.zxz).
        /// </summary>
        public float3 brb => new float3(z, x, z);

        /// <summary>
        /// Returns float4.zxzx swizzling.
        /// </summary>
        public float4 zxzx => new float4(z, x, z, x);

        /// <summary>
        /// Returns float4.brbr swizzling (equivalent to float4.zxzx).
        /// </summary>
        public float4 brbr => new float4(z, x, z, x);

        /// <summary>
        /// Returns float4.zxzy swizzling.
        /// </summary>
        public float4 zxzy => new float4(z, x, z, y);

        /// <summary>
        /// Returns float4.brbg swizzling (equivalent to float4.zxzy).
        /// </summary>
        public float4 brbg => new float4(z, x, z, y);

        /// <summary>
        /// Returns float4.zxzz swizzling.
        /// </summary>
        public float4 zxzz => new float4(z, x, z, z);

        /// <summary>
        /// Returns float4.brbb swizzling (equivalent to float4.zxzz).
        /// </summary>
        public float4 brbb => new float4(z, x, z, z);

        /// <summary>
        /// Returns float4.zxzw swizzling.
        /// </summary>
        public float4 zxzw => new float4(z, x, z, w);

        /// <summary>
        /// Returns float4.brba swizzling (equivalent to float4.zxzw).
        /// </summary>
        public float4 brba => new float4(z, x, z, w);

        /// <summary>
        /// Returns float4.zxw swizzling.
        /// </summary>
        public float3 zxw => new float3(z, x, w);

        /// <summary>
        /// Returns float4.bra swizzling (equivalent to float4.zxw).
        /// </summary>
        public float3 bra => new float3(z, x, w);

        /// <summary>
        /// Returns float4.zxwx swizzling.
        /// </summary>
        public float4 zxwx => new float4(z, x, w, x);

        /// <summary>
        /// Returns float4.brar swizzling (equivalent to float4.zxwx).
        /// </summary>
        public float4 brar => new float4(z, x, w, x);

        /// <summary>
        /// Returns float4.zxwy swizzling.
        /// </summary>
        public float4 zxwy => new float4(z, x, w, y);

        /// <summary>
        /// Returns float4.brag swizzling (equivalent to float4.zxwy).
        /// </summary>
        public float4 brag => new float4(z, x, w, y);

        /// <summary>
        /// Returns float4.zxwz swizzling.
        /// </summary>
        public float4 zxwz => new float4(z, x, w, z);

        /// <summary>
        /// Returns float4.brab swizzling (equivalent to float4.zxwz).
        /// </summary>
        public float4 brab => new float4(z, x, w, z);

        /// <summary>
        /// Returns float4.zxww swizzling.
        /// </summary>
        public float4 zxww => new float4(z, x, w, w);

        /// <summary>
        /// Returns float4.braa swizzling (equivalent to float4.zxww).
        /// </summary>
        public float4 braa => new float4(z, x, w, w);

        /// <summary>
        /// Returns float4.zy swizzling.
        /// </summary>
        public float2 zy => new float2(z, y);

        /// <summary>
        /// Returns float4.bg swizzling (equivalent to float4.zy).
        /// </summary>
        public float2 bg => new float2(z, y);

        /// <summary>
        /// Returns float4.zyx swizzling.
        /// </summary>
        public float3 zyx => new float3(z, y, x);

        /// <summary>
        /// Returns float4.bgr swizzling (equivalent to float4.zyx).
        /// </summary>
        public float3 bgr => new float3(z, y, x);

        /// <summary>
        /// Returns float4.zyxx swizzling.
        /// </summary>
        public float4 zyxx => new float4(z, y, x, x);

        /// <summary>
        /// Returns float4.bgrr swizzling (equivalent to float4.zyxx).
        /// </summary>
        public float4 bgrr => new float4(z, y, x, x);

        /// <summary>
        /// Returns float4.zyxy swizzling.
        /// </summary>
        public float4 zyxy => new float4(z, y, x, y);

        /// <summary>
        /// Returns float4.bgrg swizzling (equivalent to float4.zyxy).
        /// </summary>
        public float4 bgrg => new float4(z, y, x, y);

        /// <summary>
        /// Returns float4.zyxz swizzling.
        /// </summary>
        public float4 zyxz => new float4(z, y, x, z);

        /// <summary>
        /// Returns float4.bgrb swizzling (equivalent to float4.zyxz).
        /// </summary>
        public float4 bgrb => new float4(z, y, x, z);

        /// <summary>
        /// Returns float4.zyxw swizzling.
        /// </summary>
        public float4 zyxw => new float4(z, y, x, w);

        /// <summary>
        /// Returns float4.bgra swizzling (equivalent to float4.zyxw).
        /// </summary>
        public float4 bgra => new float4(z, y, x, w);

        /// <summary>
        /// Returns float4.zyy swizzling.
        /// </summary>
        public float3 zyy => new float3(z, y, y);

        /// <summary>
        /// Returns float4.bgg swizzling (equivalent to float4.zyy).
        /// </summary>
        public float3 bgg => new float3(z, y, y);

        /// <summary>
        /// Returns float4.zyyx swizzling.
        /// </summary>
        public float4 zyyx => new float4(z, y, y, x);

        /// <summary>
        /// Returns float4.bggr swizzling (equivalent to float4.zyyx).
        /// </summary>
        public float4 bggr => new float4(z, y, y, x);

        /// <summary>
        /// Returns float4.zyyy swizzling.
        /// </summary>
        public float4 zyyy => new float4(z, y, y, y);

        /// <summary>
        /// Returns float4.bggg swizzling (equivalent to float4.zyyy).
        /// </summary>
        public float4 bggg => new float4(z, y, y, y);

        /// <summary>
        /// Returns float4.zyyz swizzling.
        /// </summary>
        public float4 zyyz => new float4(z, y, y, z);

        /// <summary>
        /// Returns float4.bggb swizzling (equivalent to float4.zyyz).
        /// </summary>
        public float4 bggb => new float4(z, y, y, z);

        /// <summary>
        /// Returns float4.zyyw swizzling.
        /// </summary>
        public float4 zyyw => new float4(z, y, y, w);

        /// <summary>
        /// Returns float4.bgga swizzling (equivalent to float4.zyyw).
        /// </summary>
        public float4 bgga => new float4(z, y, y, w);

        /// <summary>
        /// Returns float4.zyz swizzling.
        /// </summary>
        public float3 zyz => new float3(z, y, z);

        /// <summary>
        /// Returns float4.bgb swizzling (equivalent to float4.zyz).
        /// </summary>
        public float3 bgb => new float3(z, y, z);

        /// <summary>
        /// Returns float4.zyzx swizzling.
        /// </summary>
        public float4 zyzx => new float4(z, y, z, x);

        /// <summary>
        /// Returns float4.bgbr swizzling (equivalent to float4.zyzx).
        /// </summary>
        public float4 bgbr => new float4(z, y, z, x);

        /// <summary>
        /// Returns float4.zyzy swizzling.
        /// </summary>
        public float4 zyzy => new float4(z, y, z, y);

        /// <summary>
        /// Returns float4.bgbg swizzling (equivalent to float4.zyzy).
        /// </summary>
        public float4 bgbg => new float4(z, y, z, y);

        /// <summary>
        /// Returns float4.zyzz swizzling.
        /// </summary>
        public float4 zyzz => new float4(z, y, z, z);

        /// <summary>
        /// Returns float4.bgbb swizzling (equivalent to float4.zyzz).
        /// </summary>
        public float4 bgbb => new float4(z, y, z, z);

        /// <summary>
        /// Returns float4.zyzw swizzling.
        /// </summary>
        public float4 zyzw => new float4(z, y, z, w);

        /// <summary>
        /// Returns float4.bgba swizzling (equivalent to float4.zyzw).
        /// </summary>
        public float4 bgba => new float4(z, y, z, w);

        /// <summary>
        /// Returns float4.zyw swizzling.
        /// </summary>
        public float3 zyw => new float3(z, y, w);

        /// <summary>
        /// Returns float4.bga swizzling (equivalent to float4.zyw).
        /// </summary>
        public float3 bga => new float3(z, y, w);

        /// <summary>
        /// Returns float4.zywx swizzling.
        /// </summary>
        public float4 zywx => new float4(z, y, w, x);

        /// <summary>
        /// Returns float4.bgar swizzling (equivalent to float4.zywx).
        /// </summary>
        public float4 bgar => new float4(z, y, w, x);

        /// <summary>
        /// Returns float4.zywy swizzling.
        /// </summary>
        public float4 zywy => new float4(z, y, w, y);

        /// <summary>
        /// Returns float4.bgag swizzling (equivalent to float4.zywy).
        /// </summary>
        public float4 bgag => new float4(z, y, w, y);

        /// <summary>
        /// Returns float4.zywz swizzling.
        /// </summary>
        public float4 zywz => new float4(z, y, w, z);

        /// <summary>
        /// Returns float4.bgab swizzling (equivalent to float4.zywz).
        /// </summary>
        public float4 bgab => new float4(z, y, w, z);

        /// <summary>
        /// Returns float4.zyww swizzling.
        /// </summary>
        public float4 zyww => new float4(z, y, w, w);

        /// <summary>
        /// Returns float4.bgaa swizzling (equivalent to float4.zyww).
        /// </summary>
        public float4 bgaa => new float4(z, y, w, w);

        /// <summary>
        /// Returns float4.zz swizzling.
        /// </summary>
        public float2 zz => new float2(z, z);

        /// <summary>
        /// Returns float4.bb swizzling (equivalent to float4.zz).
        /// </summary>
        public float2 bb => new float2(z, z);

        /// <summary>
        /// Returns float4.zzx swizzling.
        /// </summary>
        public float3 zzx => new float3(z, z, x);

        /// <summary>
        /// Returns float4.bbr swizzling (equivalent to float4.zzx).
        /// </summary>
        public float3 bbr => new float3(z, z, x);

        /// <summary>
        /// Returns float4.zzxx swizzling.
        /// </summary>
        public float4 zzxx => new float4(z, z, x, x);

        /// <summary>
        /// Returns float4.bbrr swizzling (equivalent to float4.zzxx).
        /// </summary>
        public float4 bbrr => new float4(z, z, x, x);

        /// <summary>
        /// Returns float4.zzxy swizzling.
        /// </summary>
        public float4 zzxy => new float4(z, z, x, y);

        /// <summary>
        /// Returns float4.bbrg swizzling (equivalent to float4.zzxy).
        /// </summary>
        public float4 bbrg => new float4(z, z, x, y);

        /// <summary>
        /// Returns float4.zzxz swizzling.
        /// </summary>
        public float4 zzxz => new float4(z, z, x, z);

        /// <summary>
        /// Returns float4.bbrb swizzling (equivalent to float4.zzxz).
        /// </summary>
        public float4 bbrb => new float4(z, z, x, z);

        /// <summary>
        /// Returns float4.zzxw swizzling.
        /// </summary>
        public float4 zzxw => new float4(z, z, x, w);

        /// <summary>
        /// Returns float4.bbra swizzling (equivalent to float4.zzxw).
        /// </summary>
        public float4 bbra => new float4(z, z, x, w);

        /// <summary>
        /// Returns float4.zzy swizzling.
        /// </summary>
        public float3 zzy => new float3(z, z, y);

        /// <summary>
        /// Returns float4.bbg swizzling (equivalent to float4.zzy).
        /// </summary>
        public float3 bbg => new float3(z, z, y);

        /// <summary>
        /// Returns float4.zzyx swizzling.
        /// </summary>
        public float4 zzyx => new float4(z, z, y, x);

        /// <summary>
        /// Returns float4.bbgr swizzling (equivalent to float4.zzyx).
        /// </summary>
        public float4 bbgr => new float4(z, z, y, x);

        /// <summary>
        /// Returns float4.zzyy swizzling.
        /// </summary>
        public float4 zzyy => new float4(z, z, y, y);

        /// <summary>
        /// Returns float4.bbgg swizzling (equivalent to float4.zzyy).
        /// </summary>
        public float4 bbgg => new float4(z, z, y, y);

        /// <summary>
        /// Returns float4.zzyz swizzling.
        /// </summary>
        public float4 zzyz => new float4(z, z, y, z);

        /// <summary>
        /// Returns float4.bbgb swizzling (equivalent to float4.zzyz).
        /// </summary>
        public float4 bbgb => new float4(z, z, y, z);

        /// <summary>
        /// Returns float4.zzyw swizzling.
        /// </summary>
        public float4 zzyw => new float4(z, z, y, w);

        /// <summary>
        /// Returns float4.bbga swizzling (equivalent to float4.zzyw).
        /// </summary>
        public float4 bbga => new float4(z, z, y, w);

        /// <summary>
        /// Returns float4.zzz swizzling.
        /// </summary>
        public float3 zzz => new float3(z, z, z);

        /// <summary>
        /// Returns float4.bbb swizzling (equivalent to float4.zzz).
        /// </summary>
        public float3 bbb => new float3(z, z, z);

        /// <summary>
        /// Returns float4.zzzx swizzling.
        /// </summary>
        public float4 zzzx => new float4(z, z, z, x);

        /// <summary>
        /// Returns float4.bbbr swizzling (equivalent to float4.zzzx).
        /// </summary>
        public float4 bbbr => new float4(z, z, z, x);

        /// <summary>
        /// Returns float4.zzzy swizzling.
        /// </summary>
        public float4 zzzy => new float4(z, z, z, y);

        /// <summary>
        /// Returns float4.bbbg swizzling (equivalent to float4.zzzy).
        /// </summary>
        public float4 bbbg => new float4(z, z, z, y);

        /// <summary>
        /// Returns float4.zzzz swizzling.
        /// </summary>
        public float4 zzzz => new float4(z, z, z, z);

        /// <summary>
        /// Returns float4.bbbb swizzling (equivalent to float4.zzzz).
        /// </summary>
        public float4 bbbb => new float4(z, z, z, z);

        /// <summary>
        /// Returns float4.zzzw swizzling.
        /// </summary>
        public float4 zzzw => new float4(z, z, z, w);

        /// <summary>
        /// Returns float4.bbba swizzling (equivalent to float4.zzzw).
        /// </summary>
        public float4 bbba => new float4(z, z, z, w);

        /// <summary>
        /// Returns float4.zzw swizzling.
        /// </summary>
        public float3 zzw => new float3(z, z, w);

        /// <summary>
        /// Returns float4.bba swizzling (equivalent to float4.zzw).
        /// </summary>
        public float3 bba => new float3(z, z, w);

        /// <summary>
        /// Returns float4.zzwx swizzling.
        /// </summary>
        public float4 zzwx => new float4(z, z, w, x);

        /// <summary>
        /// Returns float4.bbar swizzling (equivalent to float4.zzwx).
        /// </summary>
        public float4 bbar => new float4(z, z, w, x);

        /// <summary>
        /// Returns float4.zzwy swizzling.
        /// </summary>
        public float4 zzwy => new float4(z, z, w, y);

        /// <summary>
        /// Returns float4.bbag swizzling (equivalent to float4.zzwy).
        /// </summary>
        public float4 bbag => new float4(z, z, w, y);

        /// <summary>
        /// Returns float4.zzwz swizzling.
        /// </summary>
        public float4 zzwz => new float4(z, z, w, z);

        /// <summary>
        /// Returns float4.bbab swizzling (equivalent to float4.zzwz).
        /// </summary>
        public float4 bbab => new float4(z, z, w, z);

        /// <summary>
        /// Returns float4.zzww swizzling.
        /// </summary>
        public float4 zzww => new float4(z, z, w, w);

        /// <summary>
        /// Returns float4.bbaa swizzling (equivalent to float4.zzww).
        /// </summary>
        public float4 bbaa => new float4(z, z, w, w);

        /// <summary>
        /// Returns float4.zw swizzling.
        /// </summary>
        public float2 zw => new float2(z, w);

        /// <summary>
        /// Returns float4.ba swizzling (equivalent to float4.zw).
        /// </summary>
        public float2 ba => new float2(z, w);

        /// <summary>
        /// Returns float4.zwx swizzling.
        /// </summary>
        public float3 zwx => new float3(z, w, x);

        /// <summary>
        /// Returns float4.bar swizzling (equivalent to float4.zwx).
        /// </summary>
        public float3 bar => new float3(z, w, x);

        /// <summary>
        /// Returns float4.zwxx swizzling.
        /// </summary>
        public float4 zwxx => new float4(z, w, x, x);

        /// <summary>
        /// Returns float4.barr swizzling (equivalent to float4.zwxx).
        /// </summary>
        public float4 barr => new float4(z, w, x, x);

        /// <summary>
        /// Returns float4.zwxy swizzling.
        /// </summary>
        public float4 zwxy => new float4(z, w, x, y);

        /// <summary>
        /// Returns float4.barg swizzling (equivalent to float4.zwxy).
        /// </summary>
        public float4 barg => new float4(z, w, x, y);

        /// <summary>
        /// Returns float4.zwxz swizzling.
        /// </summary>
        public float4 zwxz => new float4(z, w, x, z);

        /// <summary>
        /// Returns float4.barb swizzling (equivalent to float4.zwxz).
        /// </summary>
        public float4 barb => new float4(z, w, x, z);

        /// <summary>
        /// Returns float4.zwxw swizzling.
        /// </summary>
        public float4 zwxw => new float4(z, w, x, w);

        /// <summary>
        /// Returns float4.bara swizzling (equivalent to float4.zwxw).
        /// </summary>
        public float4 bara => new float4(z, w, x, w);

        /// <summary>
        /// Returns float4.zwy swizzling.
        /// </summary>
        public float3 zwy => new float3(z, w, y);

        /// <summary>
        /// Returns float4.bag swizzling (equivalent to float4.zwy).
        /// </summary>
        public float3 bag => new float3(z, w, y);

        /// <summary>
        /// Returns float4.zwyx swizzling.
        /// </summary>
        public float4 zwyx => new float4(z, w, y, x);

        /// <summary>
        /// Returns float4.bagr swizzling (equivalent to float4.zwyx).
        /// </summary>
        public float4 bagr => new float4(z, w, y, x);

        /// <summary>
        /// Returns float4.zwyy swizzling.
        /// </summary>
        public float4 zwyy => new float4(z, w, y, y);

        /// <summary>
        /// Returns float4.bagg swizzling (equivalent to float4.zwyy).
        /// </summary>
        public float4 bagg => new float4(z, w, y, y);

        /// <summary>
        /// Returns float4.zwyz swizzling.
        /// </summary>
        public float4 zwyz => new float4(z, w, y, z);

        /// <summary>
        /// Returns float4.bagb swizzling (equivalent to float4.zwyz).
        /// </summary>
        public float4 bagb => new float4(z, w, y, z);

        /// <summary>
        /// Returns float4.zwyw swizzling.
        /// </summary>
        public float4 zwyw => new float4(z, w, y, w);

        /// <summary>
        /// Returns float4.baga swizzling (equivalent to float4.zwyw).
        /// </summary>
        public float4 baga => new float4(z, w, y, w);

        /// <summary>
        /// Returns float4.zwz swizzling.
        /// </summary>
        public float3 zwz => new float3(z, w, z);

        /// <summary>
        /// Returns float4.bab swizzling (equivalent to float4.zwz).
        /// </summary>
        public float3 bab => new float3(z, w, z);

        /// <summary>
        /// Returns float4.zwzx swizzling.
        /// </summary>
        public float4 zwzx => new float4(z, w, z, x);

        /// <summary>
        /// Returns float4.babr swizzling (equivalent to float4.zwzx).
        /// </summary>
        public float4 babr => new float4(z, w, z, x);

        /// <summary>
        /// Returns float4.zwzy swizzling.
        /// </summary>
        public float4 zwzy => new float4(z, w, z, y);

        /// <summary>
        /// Returns float4.babg swizzling (equivalent to float4.zwzy).
        /// </summary>
        public float4 babg => new float4(z, w, z, y);

        /// <summary>
        /// Returns float4.zwzz swizzling.
        /// </summary>
        public float4 zwzz => new float4(z, w, z, z);

        /// <summary>
        /// Returns float4.babb swizzling (equivalent to float4.zwzz).
        /// </summary>
        public float4 babb => new float4(z, w, z, z);

        /// <summary>
        /// Returns float4.zwzw swizzling.
        /// </summary>
        public float4 zwzw => new float4(z, w, z, w);

        /// <summary>
        /// Returns float4.baba swizzling (equivalent to float4.zwzw).
        /// </summary>
        public float4 baba => new float4(z, w, z, w);

        /// <summary>
        /// Returns float4.zww swizzling.
        /// </summary>
        public float3 zww => new float3(z, w, w);

        /// <summary>
        /// Returns float4.baa swizzling (equivalent to float4.zww).
        /// </summary>
        public float3 baa => new float3(z, w, w);

        /// <summary>
        /// Returns float4.zwwx swizzling.
        /// </summary>
        public float4 zwwx => new float4(z, w, w, x);

        /// <summary>
        /// Returns float4.baar swizzling (equivalent to float4.zwwx).
        /// </summary>
        public float4 baar => new float4(z, w, w, x);

        /// <summary>
        /// Returns float4.zwwy swizzling.
        /// </summary>
        public float4 zwwy => new float4(z, w, w, y);

        /// <summary>
        /// Returns float4.baag swizzling (equivalent to float4.zwwy).
        /// </summary>
        public float4 baag => new float4(z, w, w, y);

        /// <summary>
        /// Returns float4.zwwz swizzling.
        /// </summary>
        public float4 zwwz => new float4(z, w, w, z);

        /// <summary>
        /// Returns float4.baab swizzling (equivalent to float4.zwwz).
        /// </summary>
        public float4 baab => new float4(z, w, w, z);

        /// <summary>
        /// Returns float4.zwww swizzling.
        /// </summary>
        public float4 zwww => new float4(z, w, w, w);

        /// <summary>
        /// Returns float4.baaa swizzling (equivalent to float4.zwww).
        /// </summary>
        public float4 baaa => new float4(z, w, w, w);

        /// <summary>
        /// Returns float4.wx swizzling.
        /// </summary>
        public float2 wx => new float2(w, x);

        /// <summary>
        /// Returns float4.ar swizzling (equivalent to float4.wx).
        /// </summary>
        public float2 ar => new float2(w, x);

        /// <summary>
        /// Returns float4.wxx swizzling.
        /// </summary>
        public float3 wxx => new float3(w, x, x);

        /// <summary>
        /// Returns float4.arr swizzling (equivalent to float4.wxx).
        /// </summary>
        public float3 arr => new float3(w, x, x);

        /// <summary>
        /// Returns float4.wxxx swizzling.
        /// </summary>
        public float4 wxxx => new float4(w, x, x, x);

        /// <summary>
        /// Returns float4.arrr swizzling (equivalent to float4.wxxx).
        /// </summary>
        public float4 arrr => new float4(w, x, x, x);

        /// <summary>
        /// Returns float4.wxxy swizzling.
        /// </summary>
        public float4 wxxy => new float4(w, x, x, y);

        /// <summary>
        /// Returns float4.arrg swizzling (equivalent to float4.wxxy).
        /// </summary>
        public float4 arrg => new float4(w, x, x, y);

        /// <summary>
        /// Returns float4.wxxz swizzling.
        /// </summary>
        public float4 wxxz => new float4(w, x, x, z);

        /// <summary>
        /// Returns float4.arrb swizzling (equivalent to float4.wxxz).
        /// </summary>
        public float4 arrb => new float4(w, x, x, z);

        /// <summary>
        /// Returns float4.wxxw swizzling.
        /// </summary>
        public float4 wxxw => new float4(w, x, x, w);

        /// <summary>
        /// Returns float4.arra swizzling (equivalent to float4.wxxw).
        /// </summary>
        public float4 arra => new float4(w, x, x, w);

        /// <summary>
        /// Returns float4.wxy swizzling.
        /// </summary>
        public float3 wxy => new float3(w, x, y);

        /// <summary>
        /// Returns float4.arg swizzling (equivalent to float4.wxy).
        /// </summary>
        public float3 arg => new float3(w, x, y);

        /// <summary>
        /// Returns float4.wxyx swizzling.
        /// </summary>
        public float4 wxyx => new float4(w, x, y, x);

        /// <summary>
        /// Returns float4.argr swizzling (equivalent to float4.wxyx).
        /// </summary>
        public float4 argr => new float4(w, x, y, x);

        /// <summary>
        /// Returns float4.wxyy swizzling.
        /// </summary>
        public float4 wxyy => new float4(w, x, y, y);

        /// <summary>
        /// Returns float4.argg swizzling (equivalent to float4.wxyy).
        /// </summary>
        public float4 argg => new float4(w, x, y, y);

        /// <summary>
        /// Returns float4.wxyz swizzling.
        /// </summary>
        public float4 wxyz => new float4(w, x, y, z);

        /// <summary>
        /// Returns float4.argb swizzling (equivalent to float4.wxyz).
        /// </summary>
        public float4 argb => new float4(w, x, y, z);

        /// <summary>
        /// Returns float4.wxyw swizzling.
        /// </summary>
        public float4 wxyw => new float4(w, x, y, w);

        /// <summary>
        /// Returns float4.arga swizzling (equivalent to float4.wxyw).
        /// </summary>
        public float4 arga => new float4(w, x, y, w);

        /// <summary>
        /// Returns float4.wxz swizzling.
        /// </summary>
        public float3 wxz => new float3(w, x, z);

        /// <summary>
        /// Returns float4.arb swizzling (equivalent to float4.wxz).
        /// </summary>
        public float3 arb => new float3(w, x, z);

        /// <summary>
        /// Returns float4.wxzx swizzling.
        /// </summary>
        public float4 wxzx => new float4(w, x, z, x);

        /// <summary>
        /// Returns float4.arbr swizzling (equivalent to float4.wxzx).
        /// </summary>
        public float4 arbr => new float4(w, x, z, x);

        /// <summary>
        /// Returns float4.wxzy swizzling.
        /// </summary>
        public float4 wxzy => new float4(w, x, z, y);

        /// <summary>
        /// Returns float4.arbg swizzling (equivalent to float4.wxzy).
        /// </summary>
        public float4 arbg => new float4(w, x, z, y);

        /// <summary>
        /// Returns float4.wxzz swizzling.
        /// </summary>
        public float4 wxzz => new float4(w, x, z, z);

        /// <summary>
        /// Returns float4.arbb swizzling (equivalent to float4.wxzz).
        /// </summary>
        public float4 arbb => new float4(w, x, z, z);

        /// <summary>
        /// Returns float4.wxzw swizzling.
        /// </summary>
        public float4 wxzw => new float4(w, x, z, w);

        /// <summary>
        /// Returns float4.arba swizzling (equivalent to float4.wxzw).
        /// </summary>
        public float4 arba => new float4(w, x, z, w);

        /// <summary>
        /// Returns float4.wxw swizzling.
        /// </summary>
        public float3 wxw => new float3(w, x, w);

        /// <summary>
        /// Returns float4.ara swizzling (equivalent to float4.wxw).
        /// </summary>
        public float3 ara => new float3(w, x, w);

        /// <summary>
        /// Returns float4.wxwx swizzling.
        /// </summary>
        public float4 wxwx => new float4(w, x, w, x);

        /// <summary>
        /// Returns float4.arar swizzling (equivalent to float4.wxwx).
        /// </summary>
        public float4 arar => new float4(w, x, w, x);

        /// <summary>
        /// Returns float4.wxwy swizzling.
        /// </summary>
        public float4 wxwy => new float4(w, x, w, y);

        /// <summary>
        /// Returns float4.arag swizzling (equivalent to float4.wxwy).
        /// </summary>
        public float4 arag => new float4(w, x, w, y);

        /// <summary>
        /// Returns float4.wxwz swizzling.
        /// </summary>
        public float4 wxwz => new float4(w, x, w, z);

        /// <summary>
        /// Returns float4.arab swizzling (equivalent to float4.wxwz).
        /// </summary>
        public float4 arab => new float4(w, x, w, z);

        /// <summary>
        /// Returns float4.wxww swizzling.
        /// </summary>
        public float4 wxww => new float4(w, x, w, w);

        /// <summary>
        /// Returns float4.araa swizzling (equivalent to float4.wxww).
        /// </summary>
        public float4 araa => new float4(w, x, w, w);

        /// <summary>
        /// Returns float4.wy swizzling.
        /// </summary>
        public float2 wy => new float2(w, y);

        /// <summary>
        /// Returns float4.ag swizzling (equivalent to float4.wy).
        /// </summary>
        public float2 ag => new float2(w, y);

        /// <summary>
        /// Returns float4.wyx swizzling.
        /// </summary>
        public float3 wyx => new float3(w, y, x);

        /// <summary>
        /// Returns float4.agr swizzling (equivalent to float4.wyx).
        /// </summary>
        public float3 agr => new float3(w, y, x);

        /// <summary>
        /// Returns float4.wyxx swizzling.
        /// </summary>
        public float4 wyxx => new float4(w, y, x, x);

        /// <summary>
        /// Returns float4.agrr swizzling (equivalent to float4.wyxx).
        /// </summary>
        public float4 agrr => new float4(w, y, x, x);

        /// <summary>
        /// Returns float4.wyxy swizzling.
        /// </summary>
        public float4 wyxy => new float4(w, y, x, y);

        /// <summary>
        /// Returns float4.agrg swizzling (equivalent to float4.wyxy).
        /// </summary>
        public float4 agrg => new float4(w, y, x, y);

        /// <summary>
        /// Returns float4.wyxz swizzling.
        /// </summary>
        public float4 wyxz => new float4(w, y, x, z);

        /// <summary>
        /// Returns float4.agrb swizzling (equivalent to float4.wyxz).
        /// </summary>
        public float4 agrb => new float4(w, y, x, z);

        /// <summary>
        /// Returns float4.wyxw swizzling.
        /// </summary>
        public float4 wyxw => new float4(w, y, x, w);

        /// <summary>
        /// Returns float4.agra swizzling (equivalent to float4.wyxw).
        /// </summary>
        public float4 agra => new float4(w, y, x, w);

        /// <summary>
        /// Returns float4.wyy swizzling.
        /// </summary>
        public float3 wyy => new float3(w, y, y);

        /// <summary>
        /// Returns float4.agg swizzling (equivalent to float4.wyy).
        /// </summary>
        public float3 agg => new float3(w, y, y);

        /// <summary>
        /// Returns float4.wyyx swizzling.
        /// </summary>
        public float4 wyyx => new float4(w, y, y, x);

        /// <summary>
        /// Returns float4.aggr swizzling (equivalent to float4.wyyx).
        /// </summary>
        public float4 aggr => new float4(w, y, y, x);

        /// <summary>
        /// Returns float4.wyyy swizzling.
        /// </summary>
        public float4 wyyy => new float4(w, y, y, y);

        /// <summary>
        /// Returns float4.aggg swizzling (equivalent to float4.wyyy).
        /// </summary>
        public float4 aggg => new float4(w, y, y, y);

        /// <summary>
        /// Returns float4.wyyz swizzling.
        /// </summary>
        public float4 wyyz => new float4(w, y, y, z);

        /// <summary>
        /// Returns float4.aggb swizzling (equivalent to float4.wyyz).
        /// </summary>
        public float4 aggb => new float4(w, y, y, z);

        /// <summary>
        /// Returns float4.wyyw swizzling.
        /// </summary>
        public float4 wyyw => new float4(w, y, y, w);

        /// <summary>
        /// Returns float4.agga swizzling (equivalent to float4.wyyw).
        /// </summary>
        public float4 agga => new float4(w, y, y, w);

        /// <summary>
        /// Returns float4.wyz swizzling.
        /// </summary>
        public float3 wyz => new float3(w, y, z);

        /// <summary>
        /// Returns float4.agb swizzling (equivalent to float4.wyz).
        /// </summary>
        public float3 agb => new float3(w, y, z);

        /// <summary>
        /// Returns float4.wyzx swizzling.
        /// </summary>
        public float4 wyzx => new float4(w, y, z, x);

        /// <summary>
        /// Returns float4.agbr swizzling (equivalent to float4.wyzx).
        /// </summary>
        public float4 agbr => new float4(w, y, z, x);

        /// <summary>
        /// Returns float4.wyzy swizzling.
        /// </summary>
        public float4 wyzy => new float4(w, y, z, y);

        /// <summary>
        /// Returns float4.agbg swizzling (equivalent to float4.wyzy).
        /// </summary>
        public float4 agbg => new float4(w, y, z, y);

        /// <summary>
        /// Returns float4.wyzz swizzling.
        /// </summary>
        public float4 wyzz => new float4(w, y, z, z);

        /// <summary>
        /// Returns float4.agbb swizzling (equivalent to float4.wyzz).
        /// </summary>
        public float4 agbb => new float4(w, y, z, z);

        /// <summary>
        /// Returns float4.wyzw swizzling.
        /// </summary>
        public float4 wyzw => new float4(w, y, z, w);

        /// <summary>
        /// Returns float4.agba swizzling (equivalent to float4.wyzw).
        /// </summary>
        public float4 agba => new float4(w, y, z, w);

        /// <summary>
        /// Returns float4.wyw swizzling.
        /// </summary>
        public float3 wyw => new float3(w, y, w);

        /// <summary>
        /// Returns float4.aga swizzling (equivalent to float4.wyw).
        /// </summary>
        public float3 aga => new float3(w, y, w);

        /// <summary>
        /// Returns float4.wywx swizzling.
        /// </summary>
        public float4 wywx => new float4(w, y, w, x);

        /// <summary>
        /// Returns float4.agar swizzling (equivalent to float4.wywx).
        /// </summary>
        public float4 agar => new float4(w, y, w, x);

        /// <summary>
        /// Returns float4.wywy swizzling.
        /// </summary>
        public float4 wywy => new float4(w, y, w, y);

        /// <summary>
        /// Returns float4.agag swizzling (equivalent to float4.wywy).
        /// </summary>
        public float4 agag => new float4(w, y, w, y);

        /// <summary>
        /// Returns float4.wywz swizzling.
        /// </summary>
        public float4 wywz => new float4(w, y, w, z);

        /// <summary>
        /// Returns float4.agab swizzling (equivalent to float4.wywz).
        /// </summary>
        public float4 agab => new float4(w, y, w, z);

        /// <summary>
        /// Returns float4.wyww swizzling.
        /// </summary>
        public float4 wyww => new float4(w, y, w, w);

        /// <summary>
        /// Returns float4.agaa swizzling (equivalent to float4.wyww).
        /// </summary>
        public float4 agaa => new float4(w, y, w, w);

        /// <summary>
        /// Returns float4.wz swizzling.
        /// </summary>
        public float2 wz => new float2(w, z);

        /// <summary>
        /// Returns float4.ab swizzling (equivalent to float4.wz).
        /// </summary>
        public float2 ab => new float2(w, z);

        /// <summary>
        /// Returns float4.wzx swizzling.
        /// </summary>
        public float3 wzx => new float3(w, z, x);

        /// <summary>
        /// Returns float4.abr swizzling (equivalent to float4.wzx).
        /// </summary>
        public float3 abr => new float3(w, z, x);

        /// <summary>
        /// Returns float4.wzxx swizzling.
        /// </summary>
        public float4 wzxx => new float4(w, z, x, x);

        /// <summary>
        /// Returns float4.abrr swizzling (equivalent to float4.wzxx).
        /// </summary>
        public float4 abrr => new float4(w, z, x, x);

        /// <summary>
        /// Returns float4.wzxy swizzling.
        /// </summary>
        public float4 wzxy => new float4(w, z, x, y);

        /// <summary>
        /// Returns float4.abrg swizzling (equivalent to float4.wzxy).
        /// </summary>
        public float4 abrg => new float4(w, z, x, y);

        /// <summary>
        /// Returns float4.wzxz swizzling.
        /// </summary>
        public float4 wzxz => new float4(w, z, x, z);

        /// <summary>
        /// Returns float4.abrb swizzling (equivalent to float4.wzxz).
        /// </summary>
        public float4 abrb => new float4(w, z, x, z);

        /// <summary>
        /// Returns float4.wzxw swizzling.
        /// </summary>
        public float4 wzxw => new float4(w, z, x, w);

        /// <summary>
        /// Returns float4.abra swizzling (equivalent to float4.wzxw).
        /// </summary>
        public float4 abra => new float4(w, z, x, w);

        /// <summary>
        /// Returns float4.wzy swizzling.
        /// </summary>
        public float3 wzy => new float3(w, z, y);

        /// <summary>
        /// Returns float4.abg swizzling (equivalent to float4.wzy).
        /// </summary>
        public float3 abg => new float3(w, z, y);

        /// <summary>
        /// Returns float4.wzyx swizzling.
        /// </summary>
        public float4 wzyx => new float4(w, z, y, x);

        /// <summary>
        /// Returns float4.abgr swizzling (equivalent to float4.wzyx).
        /// </summary>
        public float4 abgr => new float4(w, z, y, x);

        /// <summary>
        /// Returns float4.wzyy swizzling.
        /// </summary>
        public float4 wzyy => new float4(w, z, y, y);

        /// <summary>
        /// Returns float4.abgg swizzling (equivalent to float4.wzyy).
        /// </summary>
        public float4 abgg => new float4(w, z, y, y);

        /// <summary>
        /// Returns float4.wzyz swizzling.
        /// </summary>
        public float4 wzyz => new float4(w, z, y, z);

        /// <summary>
        /// Returns float4.abgb swizzling (equivalent to float4.wzyz).
        /// </summary>
        public float4 abgb => new float4(w, z, y, z);

        /// <summary>
        /// Returns float4.wzyw swizzling.
        /// </summary>
        public float4 wzyw => new float4(w, z, y, w);

        /// <summary>
        /// Returns float4.abga swizzling (equivalent to float4.wzyw).
        /// </summary>
        public float4 abga => new float4(w, z, y, w);

        /// <summary>
        /// Returns float4.wzz swizzling.
        /// </summary>
        public float3 wzz => new float3(w, z, z);

        /// <summary>
        /// Returns float4.abb swizzling (equivalent to float4.wzz).
        /// </summary>
        public float3 abb => new float3(w, z, z);

        /// <summary>
        /// Returns float4.wzzx swizzling.
        /// </summary>
        public float4 wzzx => new float4(w, z, z, x);

        /// <summary>
        /// Returns float4.abbr swizzling (equivalent to float4.wzzx).
        /// </summary>
        public float4 abbr => new float4(w, z, z, x);

        /// <summary>
        /// Returns float4.wzzy swizzling.
        /// </summary>
        public float4 wzzy => new float4(w, z, z, y);

        /// <summary>
        /// Returns float4.abbg swizzling (equivalent to float4.wzzy).
        /// </summary>
        public float4 abbg => new float4(w, z, z, y);

        /// <summary>
        /// Returns float4.wzzz swizzling.
        /// </summary>
        public float4 wzzz => new float4(w, z, z, z);

        /// <summary>
        /// Returns float4.abbb swizzling (equivalent to float4.wzzz).
        /// </summary>
        public float4 abbb => new float4(w, z, z, z);

        /// <summary>
        /// Returns float4.wzzw swizzling.
        /// </summary>
        public float4 wzzw => new float4(w, z, z, w);

        /// <summary>
        /// Returns float4.abba swizzling (equivalent to float4.wzzw).
        /// </summary>
        public float4 abba => new float4(w, z, z, w);

        /// <summary>
        /// Returns float4.wzw swizzling.
        /// </summary>
        public float3 wzw => new float3(w, z, w);

        /// <summary>
        /// Returns float4.aba swizzling (equivalent to float4.wzw).
        /// </summary>
        public float3 aba => new float3(w, z, w);

        /// <summary>
        /// Returns float4.wzwx swizzling.
        /// </summary>
        public float4 wzwx => new float4(w, z, w, x);

        /// <summary>
        /// Returns float4.abar swizzling (equivalent to float4.wzwx).
        /// </summary>
        public float4 abar => new float4(w, z, w, x);

        /// <summary>
        /// Returns float4.wzwy swizzling.
        /// </summary>
        public float4 wzwy => new float4(w, z, w, y);

        /// <summary>
        /// Returns float4.abag swizzling (equivalent to float4.wzwy).
        /// </summary>
        public float4 abag => new float4(w, z, w, y);

        /// <summary>
        /// Returns float4.wzwz swizzling.
        /// </summary>
        public float4 wzwz => new float4(w, z, w, z);

        /// <summary>
        /// Returns float4.abab swizzling (equivalent to float4.wzwz).
        /// </summary>
        public float4 abab => new float4(w, z, w, z);

        /// <summary>
        /// Returns float4.wzww swizzling.
        /// </summary>
        public float4 wzww => new float4(w, z, w, w);

        /// <summary>
        /// Returns float4.abaa swizzling (equivalent to float4.wzww).
        /// </summary>
        public float4 abaa => new float4(w, z, w, w);

        /// <summary>
        /// Returns float4.ww swizzling.
        /// </summary>
        public float2 ww => new float2(w, w);

        /// <summary>
        /// Returns float4.aa swizzling (equivalent to float4.ww).
        /// </summary>
        public float2 aa => new float2(w, w);

        /// <summary>
        /// Returns float4.wwx swizzling.
        /// </summary>
        public float3 wwx => new float3(w, w, x);

        /// <summary>
        /// Returns float4.aar swizzling (equivalent to float4.wwx).
        /// </summary>
        public float3 aar => new float3(w, w, x);

        /// <summary>
        /// Returns float4.wwxx swizzling.
        /// </summary>
        public float4 wwxx => new float4(w, w, x, x);

        /// <summary>
        /// Returns float4.aarr swizzling (equivalent to float4.wwxx).
        /// </summary>
        public float4 aarr => new float4(w, w, x, x);

        /// <summary>
        /// Returns float4.wwxy swizzling.
        /// </summary>
        public float4 wwxy => new float4(w, w, x, y);

        /// <summary>
        /// Returns float4.aarg swizzling (equivalent to float4.wwxy).
        /// </summary>
        public float4 aarg => new float4(w, w, x, y);

        /// <summary>
        /// Returns float4.wwxz swizzling.
        /// </summary>
        public float4 wwxz => new float4(w, w, x, z);

        /// <summary>
        /// Returns float4.aarb swizzling (equivalent to float4.wwxz).
        /// </summary>
        public float4 aarb => new float4(w, w, x, z);

        /// <summary>
        /// Returns float4.wwxw swizzling.
        /// </summary>
        public float4 wwxw => new float4(w, w, x, w);

        /// <summary>
        /// Returns float4.aara swizzling (equivalent to float4.wwxw).
        /// </summary>
        public float4 aara => new float4(w, w, x, w);

        /// <summary>
        /// Returns float4.wwy swizzling.
        /// </summary>
        public float3 wwy => new float3(w, w, y);

        /// <summary>
        /// Returns float4.aag swizzling (equivalent to float4.wwy).
        /// </summary>
        public float3 aag => new float3(w, w, y);

        /// <summary>
        /// Returns float4.wwyx swizzling.
        /// </summary>
        public float4 wwyx => new float4(w, w, y, x);

        /// <summary>
        /// Returns float4.aagr swizzling (equivalent to float4.wwyx).
        /// </summary>
        public float4 aagr => new float4(w, w, y, x);

        /// <summary>
        /// Returns float4.wwyy swizzling.
        /// </summary>
        public float4 wwyy => new float4(w, w, y, y);

        /// <summary>
        /// Returns float4.aagg swizzling (equivalent to float4.wwyy).
        /// </summary>
        public float4 aagg => new float4(w, w, y, y);

        /// <summary>
        /// Returns float4.wwyz swizzling.
        /// </summary>
        public float4 wwyz => new float4(w, w, y, z);

        /// <summary>
        /// Returns float4.aagb swizzling (equivalent to float4.wwyz).
        /// </summary>
        public float4 aagb => new float4(w, w, y, z);

        /// <summary>
        /// Returns float4.wwyw swizzling.
        /// </summary>
        public float4 wwyw => new float4(w, w, y, w);

        /// <summary>
        /// Returns float4.aaga swizzling (equivalent to float4.wwyw).
        /// </summary>
        public float4 aaga => new float4(w, w, y, w);

        /// <summary>
        /// Returns float4.wwz swizzling.
        /// </summary>
        public float3 wwz => new float3(w, w, z);

        /// <summary>
        /// Returns float4.aab swizzling (equivalent to float4.wwz).
        /// </summary>
        public float3 aab => new float3(w, w, z);

        /// <summary>
        /// Returns float4.wwzx swizzling.
        /// </summary>
        public float4 wwzx => new float4(w, w, z, x);

        /// <summary>
        /// Returns float4.aabr swizzling (equivalent to float4.wwzx).
        /// </summary>
        public float4 aabr => new float4(w, w, z, x);

        /// <summary>
        /// Returns float4.wwzy swizzling.
        /// </summary>
        public float4 wwzy => new float4(w, w, z, y);

        /// <summary>
        /// Returns float4.aabg swizzling (equivalent to float4.wwzy).
        /// </summary>
        public float4 aabg => new float4(w, w, z, y);

        /// <summary>
        /// Returns float4.wwzz swizzling.
        /// </summary>
        public float4 wwzz => new float4(w, w, z, z);

        /// <summary>
        /// Returns float4.aabb swizzling (equivalent to float4.wwzz).
        /// </summary>
        public float4 aabb => new float4(w, w, z, z);

        /// <summary>
        /// Returns float4.wwzw swizzling.
        /// </summary>
        public float4 wwzw => new float4(w, w, z, w);

        /// <summary>
        /// Returns float4.aaba swizzling (equivalent to float4.wwzw).
        /// </summary>
        public float4 aaba => new float4(w, w, z, w);

        /// <summary>
        /// Returns float4.www swizzling.
        /// </summary>
        public float3 www => new float3(w, w, w);

        /// <summary>
        /// Returns float4.aaa swizzling (equivalent to float4.www).
        /// </summary>
        public float3 aaa => new float3(w, w, w);

        /// <summary>
        /// Returns float4.wwwx swizzling.
        /// </summary>
        public float4 wwwx => new float4(w, w, w, x);

        /// <summary>
        /// Returns float4.aaar swizzling (equivalent to float4.wwwx).
        /// </summary>
        public float4 aaar => new float4(w, w, w, x);

        /// <summary>
        /// Returns float4.wwwy swizzling.
        /// </summary>
        public float4 wwwy => new float4(w, w, w, y);

        /// <summary>
        /// Returns float4.aaag swizzling (equivalent to float4.wwwy).
        /// </summary>
        public float4 aaag => new float4(w, w, w, y);

        /// <summary>
        /// Returns float4.wwwz swizzling.
        /// </summary>
        public float4 wwwz => new float4(w, w, w, z);

        /// <summary>
        /// Returns float4.aaab swizzling (equivalent to float4.wwwz).
        /// </summary>
        public float4 aaab => new float4(w, w, w, z);

        /// <summary>
        /// Returns float4.wwww swizzling.
        /// </summary>
        public float4 wwww => new float4(w, w, w, w);

        /// <summary>
        /// Returns float4.aaaa swizzling (equivalent to float4.wwww).
        /// </summary>
        public float4 aaaa => new float4(w, w, w, w);

        #endregion

    }
}
