using Microsoft.CodeAnalysis;

namespace GLSH;

public class TypeReference
{
    public readonly string name;
    public readonly ITypeSymbol typeInfo;

    public TypeReference(string name, ITypeSymbol typeInfo)
    {
        this.name = name;
        this.typeInfo = typeInfo;
    }

    public override string ToString() => name;
}
