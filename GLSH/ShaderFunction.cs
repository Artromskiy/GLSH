namespace GLSH.Compiler;

public class ShaderFunction
{
    public readonly string declaringType;
    public readonly string name;
    public readonly TypeReference returnType;
    public readonly int colorOutputCount; // TODO: This always returns 0.
    public readonly ParameterDefinition[] parameters;
    public readonly ShaderFunctionType type;
    public readonly uint3 computeGroupCounts;
    public bool IsEntryPoint => type != ShaderFunctionType.Normal;

    public ShaderFunction(
        string declaringType,
        string name,
        TypeReference returnType,
        ParameterDefinition[] parameters,
        ShaderFunctionType type,
        uint3 computeGroupCounts)
    {
        this.declaringType = declaringType;
        this.name = name;
        this.returnType = returnType;
        this.parameters = parameters;
        this.type = type;
        this.computeGroupCounts = computeGroupCounts;
    }

    public override string ToString() => $"{declaringType}.{name} [{type}]";
}
