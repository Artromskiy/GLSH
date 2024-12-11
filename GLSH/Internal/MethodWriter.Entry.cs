using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLSH.Compiler.Internal;

internal partial class MethodWriter : CSharpSyntaxVisitor<string>
{
    private readonly Compilation _compilation;
    private readonly LanguageBackend _backend;
    private string containingType;

    public MethodWriter(Compilation compilation, LanguageBackend backend)
    {
        _compilation = compilation;
        _backend = backend;
    }

    private SemanticModel GetModel(SyntaxNode node) => _compilation.GetSemanticModel(node.SyntaxTree);
    private string? GetCsTypeName(TypeSyntax node) => GetModel(node).GetSymbolInfo(node).Symbol?.GetFullMetadataName();

    private string? GetGlTypeName(TypeSyntax node)
    {
        var csName = GetCsTypeName(node);
        return csName != null ? _backend.CSharpToShaderType(csName) : null;
    }

    public string WriteMethod(MethodDeclarationData methodDeclarationData)
    {
        var syntax = Utilities.GetMethodSyntax(methodDeclarationData, _compilation);
        return Visit(syntax);
    }

    public override string? VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        var symbol = GetModel(node).GetDeclaredSymbol(node)!;
        var declaration = GetMethodDefinition(symbol);
        var body = GetBodyDeclaration(symbol, node.Body, node.ExpressionBody);
        return declaration + body;
    }

    public override string? VisitAccessorDeclaration(AccessorDeclarationSyntax node)
    {
        var symbol = GetModel(node).GetDeclaredSymbol(node)!;
        var declaration = GetMethodDefinition(symbol);
        var body = GetBodyDeclaration(symbol, node.Body, node.ExpressionBody);
        return declaration + body;
    }

    private string GetMethodDefinition(IMethodSymbol method)
    {
        var returnType = method.ReturnType.GetFullMetadataName();
        containingType = method.ContainingType.GetFullMetadataName();
        List<InvocationParameter> parameters = [];

        if (!method.IsStatic) // convert to extension-like thing
            parameters.Add(new(containingType, _backend.GetThisToken(), ParameterDirection.InOut));

        parameters.AddRange(method.Parameters.Select(p =>
        {
            var direction = Utilities.RefKindToDirection(p.RefKind);
            var typeName = p.Type.GetFullMetadataName();
            var identifier = p.Name;
            return new InvocationParameter(typeName, identifier, direction);
        }));

        return _backend.FormatDeclaration(returnType, containingType, method.Name, [.. parameters]);
    }

    private string? GetBodyDeclaration(IMethodSymbol symbol, BlockSyntax? block, ArrowExpressionClauseSyntax? arrow)
    {
        if (block != null)
            return Visit(block);

        bool isVoid = symbol.ReturnType.GetFullMetadataName() == typeof(void).FullName!;
        var returnKeyword = isVoid ? "" : "return ";
        var resultString = $"{returnKeyword}{Visit(arrow!.Expression)};";
        return
        $$"""

        {
        {{resultString.Indent()}}
        }

        """;
    }

    public override string? VisitBlock(BlockSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine();
        sb.AppendLine("{");
        foreach (var statement in node.Statements)
            sb.AppendLine(Visit(statement).Indent());
        sb.AppendLine("}");
        return sb.ToString();
    }
}