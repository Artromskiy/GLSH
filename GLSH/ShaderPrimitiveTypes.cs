using GLSH.Primitives;
using System.Collections.Generic;
using System.Numerics;
namespace GLSH;

internal static class ShaderPrimitiveTypes
{
    private static readonly HashSet<string> s_primitiveTypes =
    [
        typeof(float).FullName!,
        typeof(bool).FullName!,
        typeof(uint).FullName!,
        typeof(int).FullName!,
        typeof(Vector2).FullName!,
        typeof(Vector3).FullName!,
        typeof(Vector4).FullName!,
        typeof(Matrix4x4).FullName!,
        typeof(UInt2).FullName!,
        typeof(UInt3).FullName!,
        typeof(UInt4).FullName!,
        typeof(Int2).FullName!,
        typeof(Int3).FullName!,
        typeof(Int4).FullName!,
    ];

    public static bool IsPrimitiveType(string name)
    {
        return s_primitiveTypes.Contains(name);
    }
}
