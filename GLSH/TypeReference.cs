using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System;

namespace GLSH.Compiler;

[Obsolete]
public class TypeReference
{
    public readonly string name;
    public readonly bool isEnum;
    public readonly string? enumTypeName;
    public readonly bool isArray;
    public readonly string? arrayTypeName;

    internal TypeReference(string name, ITypeSymbol typeInfo)
    {
        this.name = name;
        isEnum = typeInfo.TypeKind == TypeKind.Enum;
        if (isEnum && typeInfo is INamedTypeSymbol e)
            enumTypeName = e.EnumUnderlyingType?.GetFullMetadataName();
        isArray = typeInfo.TypeKind == TypeKind.Array;
        if (isArray && typeInfo is INamedTypeSymbol namedTypeSymb)
            arrayTypeName = Utilities.GetFullTypeName(namedTypeSymb.TypeArguments[0]);
    }

    public override string ToString() => name;
}
