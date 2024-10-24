using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GLSH
{
    public static class GLSHInfo
    {
        public static HashSet<string> knownTypes = new HashSet<string>()
        {
            typeof(int2).FullName!,
            typeof(int3).FullName!,
            typeof(int4).FullName!,
            typeof(uint2).FullName!,
            typeof(uint3).FullName!,
            typeof(uint4).FullName!,
            typeof(float2).FullName!,
            typeof(float3).FullName!,
            typeof(float4).FullName!,
            typeof(double2).FullName!,
            typeof(double3).FullName!,
            typeof(double4).FullName!,
            typeof(bool2).FullName!,
            typeof(bool3).FullName!,
            typeof(bool4).FullName!,
            typeof(float2x2).FullName!,
            typeof(float3x2).FullName!,
            typeof(float4x2).FullName!,
            typeof(float2x3).FullName!,
            typeof(float3x3).FullName!,
            typeof(float4x3).FullName!,
            typeof(float2x4).FullName!,
            typeof(float3x4).FullName!,
            typeof(float4x4).FullName!,
            typeof(double2x2).FullName!,
            typeof(double3x2).FullName!,
            typeof(double4x2).FullName!,
            typeof(double2x3).FullName!,
            typeof(double3x3).FullName!,
            typeof(double4x3).FullName!,
            typeof(double2x4).FullName!,
            typeof(double3x4).FullName!,
            typeof(double4x4).FullName!,
        };
        public static Dictionary<string, string> knownTypesToGlslTypes = new Dictionary<string, string>()
        {
            {typeof(int2).FullName!, "ivec2"},
            {typeof(int3).FullName!, "ivec3"},
            {typeof(int4).FullName!, "ivec4"},
            {typeof(uint2).FullName!, "uvec2"},
            {typeof(uint3).FullName!, "uvec3"},
            {typeof(uint4).FullName!, "uvec4"},
            {typeof(float2).FullName!, "vec2"},
            {typeof(float3).FullName!, "vec3"},
            {typeof(float4).FullName!, "vec4"},
            {typeof(double2).FullName!, "dvec2"},
            {typeof(double3).FullName!, "dvec3"},
            {typeof(double4).FullName!, "dvec4"},
            {typeof(bool2).FullName!, "bvec2"},
            {typeof(bool3).FullName!, "bvec3"},
            {typeof(bool4).FullName!, "bvec4"},
            {typeof(float2x2).FullName!, "mat2"},
            {typeof(float3x2).FullName!, "mat3x2"},
            {typeof(float4x2).FullName!, "mat4x2"},
            {typeof(float2x3).FullName!, "mat2x3"},
            {typeof(float3x3).FullName!, "mat3"},
            {typeof(float4x3).FullName!, "mat4x3"},
            {typeof(float2x4).FullName!, "mat2x4"},
            {typeof(float3x4).FullName!, "mat3x4"},
            {typeof(float4x4).FullName!, "mat4"},
            {typeof(double2x2).FullName!, "dmat2"},
            {typeof(double3x2).FullName!, "dmat3x2"},
            {typeof(double4x2).FullName!, "dmat4x2"},
            {typeof(double2x3).FullName!, "dmat2x3"},
            {typeof(double3x3).FullName!, "dmat3"},
            {typeof(double4x3).FullName!, "dmat4x3"},
            {typeof(double2x4).FullName!, "dmat2x4"},
            {typeof(double3x4).FullName!, "dmat3x4"},
            {typeof(double4x4).FullName!, "dmat4"},
        };
    }
}
