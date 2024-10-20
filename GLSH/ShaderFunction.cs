namespace GLSH.Compiler;

public class ShaderFunction
{
    public readonly string declaringType;
    public readonly string name;
    public readonly TypeReference returnType;
    public readonly int colorOutputCount; // TODO: This always returns 0.
    public readonly ParameterDefinition[] parameters;
    public readonly ShaderFunctionType type;
    public readonly UInt3 computeGroupCounts;
    public bool IsEntryPoint => type != ShaderFunctionType.Normal;
    public bool UsesVertexID { get; internal set; }
    public bool UsesInstanceID { get; internal set; }
    public bool UsesDispatchThreadID { get; internal set; }
    public bool UsesGroupThreadID { get; internal set; }
    public bool UsesFrontFace { get; internal set; }
    public bool UsesTexture2DMS { get; internal set; }
    public bool UsesStructuredBuffer { get; internal set; }
    public bool UsesRWTexture2D { get; internal set; }
    public bool UsesInterlockedAdd { get; internal set; }

    public ShaderFunction(
        string declaringType,
        string name,
        TypeReference returnType,
        ParameterDefinition[] parameters,
        ShaderFunctionType type,
        UInt3 computeGroupCounts)
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
