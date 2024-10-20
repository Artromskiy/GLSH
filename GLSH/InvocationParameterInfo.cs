using System.Linq;

namespace GLSH.Compiler;

public readonly struct InvocationParameterInfo
{
    public readonly string fullTypeName;
    public readonly string identifier;

    public static string FormatParameters(InvocationParameterInfo[] parameterInfos)
    {
        return string.Join(", ", parameterInfos.Select(pi => pi.identifier));
    }

    public InvocationParameterInfo(string fullTypeName, string identifier)
    {
        this.fullTypeName = fullTypeName;
        this.identifier = identifier;
    }
}
