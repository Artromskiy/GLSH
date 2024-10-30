using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace GLSH.Compiler.Internal;

internal partial class MethodWriter
{
    public override string? VisitRangeExpression(RangeExpressionSyntax node)
    {
        throw new NotImplementedException("Range expressions are not supported");
    }

    public override string? VisitDefaultExpression(DefaultExpressionSyntax node)
    {
        // We should call default constructor, to do this, we need to create glsl method returning defaultType for each C# type, which uses default initialization (yeah, constructor chain)
        throw new NotImplementedException("Default variable creation is not supported");
    }
}
