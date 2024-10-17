using Microsoft.CodeAnalysis;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GLSH;

public class ParameterDefinition
{
    public readonly string name;
    public readonly TypeReference type;
    public readonly ParameterDirection direction;
    public readonly IParameterSymbol symbol;

    public ParameterDefinition(string name, TypeReference type, ParameterDirection direction, IParameterSymbol symbol)
    {
        this.name = name;
        this.type = type;
        this.direction = direction;
        this.symbol = symbol;
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

        return new ParameterDefinition(name, new(fullType, semanticModel.GetTypeInfo(ps.Type).Type), direction, declaredSymbol);
    }
}

public enum ParameterDirection
{
    In,
    Out,
    InOut
}
