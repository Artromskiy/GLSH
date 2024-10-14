
namespace GLSH;

internal abstract class TypeInvocationTranslator
{
    public abstract bool GetTranslator(
        string method,
        InvocationParameterInfo[] parameters,
        out InvocationTranslator translator);
}
