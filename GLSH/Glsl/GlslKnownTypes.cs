using System.Collections.Generic;
using System.Numerics;

namespace GLSH.Compiler.Glsl;

internal static class GlslKnownTypes
{
    private static readonly Dictionary<string, string> _knownBuiltingTypes = new()
    {
        { typeof(void).FullName!, "void" },
        { typeof(bool).FullName!, "bool" },
        { typeof(int).FullName!, "int" },
        { typeof(uint).FullName!, "uint" },
        { typeof(float).FullName!, "float" },
        { typeof(double).FullName!, "double" },

        { typeof(Vector2).FullName!, "vec2" },
        { typeof(Vector3).FullName!, "vec3" },
        { typeof(Vector4).FullName!, "vec4" },
        { typeof(Matrix4x4).FullName!, "mat4" },
        { typeof(UInt2).FullName!, "uvec2" },
        { typeof(UInt3).FullName!, "uvec3" },
        { typeof(UInt4).FullName!, "uvec4" },
        { typeof(Int2).FullName!, "ivec2" },
        { typeof(Int3).FullName!, "ivec3" },
        { typeof(Int4).FullName!, "ivec4" },
    };

    private static readonly Dictionary<string, string> _knownOpaqueTypes = new()
    {
        { typeof(SamplerResource).FullName!, "sampler" },
        { typeof(Texture2DResource).FullName!, "texture2D" },
        { typeof(TextureCubeResource).FullName!, "textureCube" },
        { typeof(DepthTexture2DResource).FullName!, "texture2D" },
        { typeof(Texture2DArrayResource).FullName!, "texture2DArray" },
        { typeof(SamplerComparisonResource).FullName!, "samplerShadow" },
        { typeof(DepthTexture2DArrayResource).FullName!, "texture2DArray" },
    };


    public static string GetMappedName(string name)
    {
        if (!GLSHInfo.knownTypesToGlslTypes.TryGetValue(name, out string? mapped) &&
            !_knownBuiltingTypes.TryGetValue(name, out mapped) &&
            !_knownOpaqueTypes.TryGetValue(name, out mapped))
            return name;
        return mapped;
    }
}