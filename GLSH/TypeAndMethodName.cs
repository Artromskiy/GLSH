using System;
using System.Diagnostics.CodeAnalysis;

namespace GLSH;

internal class TypeAndMethodName : IEquatable<TypeAndMethodName>
{
    public readonly string typeName;
    public readonly string methodName;
    public readonly string fullName;

    public TypeAndMethodName(string typeName, string methodName) :
        this(typeName, methodName, $"{typeName}.{methodName}") { }

    private TypeAndMethodName(string typeName, string methodName, string fullName)
    {
        this.typeName = typeName;
        this.methodName = methodName;
        this.fullName = fullName;
    }

    public static bool Get(string fullName, [NotNullWhen(true)] out TypeAndMethodName? typeAndMethodName)
    {
        typeAndMethodName = null;
        // with modulo result will be 0 if it's last symbol in the string
        int index = fullName.LastIndexOf('.') % (fullName.Length - 1);
        if (index <= 0)
            return false;

        string typeName = fullName[..index];
        string methodName = fullName[(index + 1)..];
        typeAndMethodName = new(typeName, methodName, fullName);
        return true;
    }

    public bool Equals(TypeAndMethodName? other)
    {
        return other is not null && typeName == other.typeName && methodName == other.methodName;
    }

    public override int GetHashCode() => fullName.GetHashCode();

    public override string ToString() => fullName;

    public override bool Equals(object? obj)
    {
        return Equals(obj as TypeAndMethodName);
    }
}
