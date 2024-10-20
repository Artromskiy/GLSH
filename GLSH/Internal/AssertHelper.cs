using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace GLSH.Compiler.Internal;

internal static class Asserts
{
    [DoesNotReturn]
    [Conditional("DEBUG")]
    public static void NotNull(params object?[] objects)
    {
        foreach (var obj in objects)
            Debug.Assert(obj is not null);
    }
}
