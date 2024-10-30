using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Text;

namespace GLSH.Compiler.Internal;

internal partial class MethodWriter
{
    public override string VisitIfStatement(IfStatementSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine("if (" + Visit(node.Condition) + ")");
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
        string? declaration = Visit(node.Declaration);
        string? condition = Visit(node.Condition);
        Asserts.NotNull(condition, declaration);
        string incrementers = string.Join(", ", node.Incrementors.Select(Visit));
        return
        $$"""
        for ({{declaration}} {{condition}}; {{incrementers}})
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

    public override string? VisitLiteralExpression(LiteralExpressionSyntax node)
    {
        return node.ToFullString();
    }

    public override string VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        string token = node.OperatorToken.ToFullString().Trim();
        string opToken = node.OperatorToken.ValueText;
        ShaderGenerationException.ThrowIf(token == "%=",
            "Modulus operator not supported in shader functions. Use ShaderBuiltins.Mod instead.");

        string? leftExpr = Visit(node.Left);
        string? rightExpr = Visit(node.Right);
        Asserts.NotNull(leftExpr, rightExpr);
        return $"{leftExpr} {opToken} {rightExpr}";
        //return _backend.CorrectBinaryExpression(leftExpr, leftExprType, operatorToken, rightExpr, rightExprType);
    }


}
