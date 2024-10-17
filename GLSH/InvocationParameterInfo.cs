using System.Linq;

namespace GLSH;

public readonly struct InvocationParameterInfo
{
    public readonly string fullTypeName;
    public readonly string identifier;

    public static string GetInvocationParameterList(InvocationParameterInfo[] parameterInfos)
    {
        return string.Join(", ", parameterInfos.Select(pi => pi.identifier));
    }

    public InvocationParameterInfo(string fullTypeName, string Identifier)
    {
        this.fullTypeName = fullTypeName;
        this.identifier = Identifier;
    }
}
