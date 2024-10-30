using System;
using System.Diagnostics;

namespace GLSH.Compiler.Internal;

[DebuggerDisplay("{ToString()}")]
public readonly struct StructDeclarationData : IEquatable<StructDeclarationData>
{
    public readonly string name;
    public readonly StructField[] fields;

    public StructDeclarationData(string name, StructField[] fields)
    {
        this.name = name;
        this.fields = fields;
    }
    public override string ToString() => $"{name} [{fields.Length}]";
    public override int GetHashCode() => name.GetHashCode();
    public bool Equals(StructDeclarationData other) => name == other.name;
    public override bool Equals(object? obj) => obj is StructDeclarationData other && Equals(other);
    public static bool operator ==(StructDeclarationData left, StructDeclarationData right) => left.Equals(right);
    public static bool operator !=(StructDeclarationData left, StructDeclarationData right) => !(left == right);
}


public readonly struct StructField : IEquatable<StructField>
{
    public readonly string typeName;
    public readonly string fieldName;

    public StructField(string typeName, string fieldName)
    {
        this.typeName = typeName;
        this.fieldName = fieldName;
    }

    public override string ToString() => $"{typeName} {fieldName}";

    public bool Equals(StructField other) => typeName == other.typeName && fieldName == other.fieldName;
    public override bool Equals(object? obj) => obj is StructField other && Equals(other);
    public static bool operator ==(StructField left, StructField right) => left.Equals(right);
    public static bool operator !=(StructField left, StructField right) => !(left == right);
    public override int GetHashCode() => HashCode.Combine(typeName, fieldName);
}

