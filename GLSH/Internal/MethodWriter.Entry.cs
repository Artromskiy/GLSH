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
    private readonly StringBuilder stringBuilder = new();

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

    private string GetMethodDefinition(IMethodSymbol symbol)
    {
        var returnType = _backend.CSharpToShaderType(symbol.ReturnType.GetFullMetadataName());
        var containingType = _backend.CSharpToShaderType(symbol.ContainingType.GetFullMetadataName());
        var methodName = GetMethodName(symbol);
        List<string> parameters = [];

        if (!symbol.IsStatic) // convert to extension-like thing
            parameters.Add($"inout {containingType} this");

        parameters.AddRange(symbol.Parameters.Select(p =>
        {
            var refKind = _backend.CorrectArgumentRefKind(p.RefKind.ToString());
            var typeName = _backend.CSharpToShaderType(p.Type.GetFullMetadataName());
            var identifier = p.Name;
            return $"{refKind} {typeName} {identifier}";
        }));

        return $"{returnType} {methodName}({string.Join(", ", parameters)})";
    }

    private string? GetBodyDeclaration(IMethodSymbol symbol, BlockSyntax? block, ArrowExpressionClauseSyntax? arrow)
    {
        if (block != null)
            return Visit(block);

        bool isVoid = symbol.ReturnType.GetFullMetadataName() == typeof(void).FullName!;
        var returnKeyword = isVoid ? "" : "return";
        return
        $$"""

        {
            {{returnKeyword}} {{Visit(arrow!.Expression)}};
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