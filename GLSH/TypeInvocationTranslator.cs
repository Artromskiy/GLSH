using System.Diagnostics.CodeAnalysis;

namespace GLSH.Compiler;

internal abstract class TypeInvocationTranslator
{
    public abstract bool GetTranslator(
        string method,
        InvocationParameterInfo[] parameters,
        [NotNullWhen(true)] out InvocationTranslator? translator);
}
