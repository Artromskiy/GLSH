using GLSH.Primitives;
using System.Collections.Generic;
using System.Numerics;
using System;

namespace GLSH.Glsl;

internal static class GlslKnownTypes
{
    private static readonly Dictionary<string, string> s_knownTypesShared = new()
    {
        { typeof(uint).FullName!, "uint" },
        { typeof(int).FullName!, "int" },
        { typeof(float).FullName!, "float" },
        { typeof(Vector2).FullName!, "vec2" },
        { typeof(Vector3).FullName!, "vec3" },
        { typeof(Vector4).FullName!, "vec4" },
        { typeof(Matrix4x4).FullName!, "mat4" },
        { typeof(void).FullName!, "void" },
        { typeof(bool).FullName!, "bool" },
        { typeof(UInt2).FullName!, "uvec2" },
        { typeof(UInt3).FullName!, "uvec3" },
        { typeof(UInt4).FullName!, "uvec4" },
        { typeof(Int2).FullName!, "ivec2" },
        { typeof(Int3).FullName!, "ivec3" },
        { typeof(Int4).FullName!, "ivec4" },

    };

    private static readonly Dictionary<string, string> s_knownTypesGL = new()
    {
        { typeof(Texture2DResource).FullName!, "sampler2D" },
        { typeof(Texture2DArrayResource).FullName!, "sampler2DArray" },
        { typeof(TextureCubeResource).FullName!, "samplerCube" },
        { typeof(DepthTexture2DResource).FullName!, "sampler2DShadow" },
        { typeof(DepthTexture2DArrayResource).FullName!, "sampler2DArrayShadow" },
        { typeof(SamplerResource).FullName!, "SamplerDummy" },
        { typeof(SamplerComparisonResource).FullName!, "SamplerComparisonDummy" },
    };

    private static readonly Dictionary<string, string> s_knownTypesVulkan = new()
    {
        { typeof(Texture2DResource).FullName!, "texture2D" },
        { typeof(Texture2DArrayResource).FullName!, "texture2DArray" },
        { typeof(TextureCubeResource).FullName!, "textureCube" },
        { typeof(DepthTexture2DResource).FullName!, "texture2D" },
        { typeof(DepthTexture2DArrayResource).FullName!, "texture2DArray" },
        { typeof(SamplerResource).FullName!, "sampler" },
        { typeof(SamplerComparisonResource).FullName!, "samplerShadow" },
    };


    public static string GetMappedName(string name, bool vulkan)
    {
        if (s_knownTypesShared.TryGetValue(name, out string mapped))
        {
            return mapped;
        }
        else if (vulkan)
        {
            if (s_knownTypesVulkan.TryGetValue(name, out mapped))
            {
                return mapped;
            }
        }
        else
        {
            if (s_knownTypesGL.TryGetValue(name, out mapped))
            {
                return mapped;
            }
        }

        return name;
    }
}
