using Microsoft.CodeAnalysis;

namespace GLSH;

public class TypeReference
{
    public string Name { get; }
    public ITypeSymbol TypeInfo { get; }

    public TypeReference(string name, ITypeSymbol typeInfo)
    {
        Name = name;
        TypeInfo = typeInfo;
    }

    public override string ToString() => Name;
}
