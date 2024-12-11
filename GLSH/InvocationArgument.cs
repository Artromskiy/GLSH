using System.Linq;

namespace GLSH.Compiler;

public readonly struct InvocationArgument
{
    public readonly string argument;

    public InvocationArgument(string argument)
    {
        this.argument = argument;
    }
}
