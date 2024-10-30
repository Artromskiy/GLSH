using System;
using System.Diagnostics;
using System.Linq;

namespace GLSH.Compiler.Internal;

[DebuggerDisplay("{ToString()}")]
public readonly struct MethodDeclarationData : IEquatable<MethodDeclarationData>
{
    public readonly string containingType;
    public readonly string methodName;
    public readonly string returnTypeName;
    private readonly ParamData[] _parameters;
    public ReadOnlySpan<ParamData> Parameters => _parameters;

    public override string ToString()
    {
        var par = _parameters.Length == 0 ? "()" : $"({_parameters.Length})";
        return $"{returnTypeName} {containingType}.{methodName}{par}";
    }

    public MethodDeclarationData(string containingType, string methodName, string returnTypeName, ParamData[] parameters)
    {
        this.containingType = containingType;
        this.methodName = methodName;
        this.returnTypeName = returnTypeName;
        this._parameters = parameters;
    }

    public readonly bool Equals(MethodDeclarationData other)
    {
        return containingType == other.containingType &&
        methodName == other.methodName &&
        returnTypeName == other.returnTypeName &&
        _parameters.SequenceEqual(other._parameters);
    }

    public override int GetHashCode() => HashCode.Combine(containingType, methodName, returnTypeName);
    public override readonly bool Equals(object? obj) => obj is MethodDeclarationData other && Equals(other);
    public static bool operator ==(MethodDeclarationData left, MethodDeclarationData right) => left.Equals(right);
    public static bool operator !=(MethodDeclarationData left, MethodDeclarationData right) => !(left == right);
}

[DebuggerDisplay("{ToString()}")]

public readonly struct ParamData : IEquatable<ParamData>
{
    public readonly string typeName;
    public readonly ParameterDirection direction;

    public ParamData(string typeName, ParameterDirection direction)
    {
        this.typeName = typeName;
        this.direction = direction;
    }

    public override string ToString() => $"{direction.ToString().ToLower()} {typeName}";

    public readonly bool Equals(ParamData other) => typeName == other.typeName && direction == other.direction;
    public override bool Equals(object? obj) => obj is ParamData other && Equals(other);
    public override readonly int GetHashCode() => HashCode.Combine(typeName, direction);
    public static bool operator ==(ParamData left, ParamData right) => left.Equals(right);
    public static bool operator !=(ParamData left, ParamData right) => !(left == right);
}