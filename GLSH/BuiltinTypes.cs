using System.Collections.Generic;
using System;
using System.Numerics;
namespace GLSH;

public static class BuiltinTypes
{
    private static readonly HashSet<string> s_builtins =
    [
        typeof(float).FullName!,
        typeof(Vector2).FullName!,
        typeof(Vector3).FullName!,
        typeof(Vector4).FullName!,
        typeof(Matrix4x4).FullName!,
    ];

    public static bool IsBuiltinType(string fullTypeName)
    {
        return s_builtins.Contains(fullTypeName);
    }
}
