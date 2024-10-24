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
    }
}
