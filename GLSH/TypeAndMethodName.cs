using System;

namespace GLSH;

internal class TypeAndMethodName : IEquatable<TypeAndMethodName>
{
    public string TypeName;
    public string MethodName;

    public string FullName => TypeName + "." + MethodName;

    public static bool Get(string fullName, out TypeAndMethodName typeAndMethodName)
    {
        string[] parts = fullName.Split('.');
        if (parts.Length < 2)
        {
            typeAndMethodName = default;
            return false;
        }
        string typeName = parts[0];
        for (int i = 1; i < parts.Length - 1; i++)
        {
            typeName += "." + parts[i];
        }

        typeAndMethodName = new TypeAndMethodName { TypeName = typeName, MethodName = parts[parts.Length - 1] };
        return true;
    }

    public bool Equals(TypeAndMethodName? other)
    {
        return other is not null && TypeName == other.TypeName && MethodName == other.MethodName;
    }

    public override int GetHashCode() => FullName.GetHashCode();

    public override string ToString() => FullName;

    public override bool Equals(object? obj)
    {
        return Equals(obj as TypeAndMethodName);
    }
}
