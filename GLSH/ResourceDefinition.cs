namespace GLSH;

public class ResourceDefinition
{
    public readonly string name;
    public readonly int set;
    public readonly int binding;
    public readonly TypeReference valueType;
    public readonly ShaderResourceKind resourceKind;

    public ResourceDefinition(string name, int set, int binding, TypeReference valueType, ShaderResourceKind kind)
    {
        this.name = name;
        this.set = set;
        this.binding = binding;
        this.valueType = valueType;
        resourceKind = kind;
    }
}
