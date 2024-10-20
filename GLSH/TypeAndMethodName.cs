using System;
using System.Diagnostics.CodeAnalysis;

namespace GLSH.Compiler;

internal class TypeAndMethodName : IEquatable<TypeAndMethodName>
{
    public readonly string containingTypeName;
    public readonly string methodName;
    public readonly string fullMethodName;

    public TypeAndMethodName(string typeName, string methodName) :
        this(typeName, methodName, $"{typeName}.{methodName}")
    { }

    private TypeAndMethodName(string typeName, string methodName, string fullName)
    {
        containingTypeName = typeName;
        this.methodName = methodName;
        fullMethodName = fullName;
    }

    public static bool Get(string fullMethodName, [NotNullWhen(true)] out TypeAndMethodName? typeAndMethodName)
    {
        typeAndMethodName = null;
        // with modulo result will be 0 if it's last symbol in the string
        int index = fullMethodName.LastIndexOf('.') % (fullMethodName.Length - 1);
        if (index <= 0)
            return false;

        string typeName = fullMethodName[..index];
        string methodName = fullMethodName[(index + 1)..];
        typeAndMethodName = new(typeName, methodName, fullMethodName);
        return true;
    }

    public bool Equals(TypeAndMethodName? other)
    {
        return other is not null && containingTypeName == other.containingTypeName && methodName == other.methodName;
    }

    public override int GetHashCode() => fullMethodName.GetHashCode();

    public override string ToString() => fullMethodName;

    public override bool Equals(object? obj)
    {
        return Equals(obj as TypeAndMethodName);
    }
}
