using System.Collections.Generic;
using GLSH.Primitives;
using System;
using System.Numerics;
namespace GLSH;

internal static class ShaderPrimitiveTypes
{
    private static readonly HashSet<string> s_primitiveTypes =
    [
        typeof(Single).FullName!,
        typeof(Boolean).FullName!,
        typeof(UInt32).FullName!,
        typeof(Int32).FullName!,
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
        // typeof(Byte2).FullName!,
        // typeof(Byte4).FullName!,
        // typeof(SByte2).FullName!,
        // typeof(SByte4).FullName!,
        // typeof(UShort2).FullName!,
        // typeof(UShort4).FullName!,
        // typeof(Short2).FullName!,
        // typeof(Short4).FullName!,
    ];

    public static bool IsPrimitiveType(string name)
    {
        return s_primitiveTypes.Contains(name);
    }
}
