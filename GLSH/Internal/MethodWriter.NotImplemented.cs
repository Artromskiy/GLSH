using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace GLSH.Compiler.Internal;

internal partial class MethodWriter
{
    public override string? VisitRangeExpression(RangeExpressionSyntax node)
    {
        throw new NotImplementedException("Range expressions are not supported");
    }


    // We should create appropriate postfix methods in glsl
    public override string? VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
    {
        return base.VisitPostfixUnaryExpression(node);
    }

    // We should create appropriate prefix methods in glsl
    public override string? VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
    {
        return base.VisitPrefixUnaryExpression(node);
    }
}
