using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using System.Text;

namespace GLSH.Compiler.Internal;

internal partial class MethodWriter
{
    public override string VisitIfStatement(IfStatementSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine($"if ({Visit(node.Condition)})");
        sb.AppendLine(Visit(node.Statement));
        sb.AppendLine(Visit(node.Else));
        return sb.ToString();
    }


    public override string VisitElseClause(ElseClauseSyntax node)
    {
        return
        $$"""
        else
        {{Visit(node.Statement)}}
        """;
    }

    public override string VisitForStatement(ForStatementSyntax node)
    {
        string incrementers = string.Join(", ", node.Incrementors.Select(Visit));
        return
        $$"""
        for ({{Visit(node.Declaration)}} {{Visit(node.Condition)}}; {{incrementers}})
        {{Visit(node.Statement)}}
        """;
    }


    public override string VisitSwitchStatement(SwitchStatementSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine($"switch ({Visit(node.Expression)})");
        sb.AppendLine("{");
        foreach (SwitchSectionSyntax section in node.Sections)
        {
            foreach (SwitchLabelSyntax label in section.Labels)
                sb.AppendLine(Visit(label));

            foreach (StatementSyntax statement in section.Statements)
                sb.AppendLine(Visit(statement));
        }
        sb.AppendLine("}");
        return sb.ToString();
    }

    public override string VisitDoStatement(DoStatementSyntax node)
    {
        return
        $$"""
        {{node.DoKeyword}}
        {
            {{Visit(node.Statement)}}
        } while({{Visit(node.Condition)}});
        """;
    }

    public override string VisitWhileStatement(WhileStatementSyntax node)
    {
        return
        $$"""
        while({{Visit(node.Condition)}})
        {{Visit(node.Statement)}}
        """;
    }


    public override string VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
    {
        return $"case {Visit(node.Value)}:";
    }

    public override string VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
    {
        return "default:";
    }

    public override string VisitBreakStatement(BreakStatementSyntax node)
    {
        return "break;";
    }

    public override string VisitReturnStatement(ReturnStatementSyntax node)
    {
        return $"return {Visit(node.Expression)};";
    }

    public override string? VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
    {
        return $"({Visit(node.Expression)})";
    }

    public override string VisitExpressionStatement(ExpressionStatementSyntax node)
    {
        return $"{Visit(node.Expression)};";
    }

    public override string? VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
    {
        return Visit(node.Declaration);
    }

    public override string? VisitLiteralExpression(LiteralExpressionSyntax node)
    {
        if (!node.IsKind(SyntaxKind.DefaultLiteralExpression))
            node.ToFullString();

        var typeName = GetModel(node).GetTypeInfo(node).Type.GetFullMetadataName();
        return _backend.FormatInvocation(typeName, "default", []);
    }

    public override string? VisitDefaultExpression(DefaultExpressionSyntax node)
    {
        var typeName = GetModel(node.Type).GetSymbolInfo(node.Type).Symbol.GetFullMetadataName();
        return _backend.FormatInvocation(typeName, "default", []);
    }

    public override string? VisitEqualsValueClause(EqualsValueClauseSyntax node)
    {
        return " = " + Visit(node.Value);
    }

    public override string? VisitVariableDeclarator(VariableDeclaratorSyntax node)
    {
        return $"{node.Identifier.ValueText} {Visit(node.Initializer)}";
    }

    public override string? VisitVariableDeclaration(VariableDeclarationSyntax node)
    {
        StringBuilder sb = new();
        var vars = node.Variables;
        var type = GetGlTypeName(node.Type);
        for (int i = 0; i < vars.Count - 1; i++)
            sb.AppendLine($"{type} {Visit(vars[i])};");
        sb.Append($"{GetGlTypeName(node.Type)} {Visit(node.Variables[^1])};");
        return sb.ToString();
    }
}
