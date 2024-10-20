using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace GLSH.Compiler;

public class ParameterDefinition
{
    public readonly string name;
    public readonly TypeReference type;
    public readonly ParameterDirection direction;
    public readonly bool isStruct;

    public ParameterDefinition(string name, TypeReference type, ParameterDirection direction, IParameterSymbol symbol)
    {
        this.name = name;
        this.type = type;
        this.direction = direction;
        isStruct = symbol.Type.TypeKind == TypeKind.Struct;
    }

    [Obsolete("Rewrite this hell")]
    public static ParameterDefinition GetParameterDefinition(Compilation compilation, ParameterSyntax ps)
    {
        SemanticModel semanticModel = compilation.GetSemanticModel(ps.SyntaxTree);
        string fullType = semanticModel.GetFullTypeName(ps.Type);
        string name = ps.Identifier.ToFullString();
        ParameterDirection direction = ParameterDirection.In;
        IParameterSymbol declaredSymbol = (IParameterSymbol)semanticModel.GetDeclaredSymbol(ps);
        RefKind refKind = declaredSymbol.RefKind;
        if (refKind == RefKind.Out)
            direction = ParameterDirection.Out;
        else if (refKind == RefKind.Ref)
            direction = ParameterDirection.InOut;
        TypeReference typeRef = new(fullType, semanticModel.GetTypeInfo(ps.Type).Type);
        return new ParameterDefinition(name, typeRef, direction, declaredSymbol);
    }
}

public enum ParameterDirection
{
    In,
    Out,
    InOut
}
