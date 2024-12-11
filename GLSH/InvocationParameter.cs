namespace GLSH.Compiler;

public readonly struct InvocationParameter
{
    public readonly string type;
    public readonly string identifier;
    public readonly ParameterDirection direction;

    public InvocationParameter(string type, string identifier, ParameterDirection direction)
    {
        this.type = type;
        this.identifier = identifier;
        this.direction = direction;
    }
}
