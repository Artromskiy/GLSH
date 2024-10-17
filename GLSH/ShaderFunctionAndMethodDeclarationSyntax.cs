using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace GLSH;

public class ShaderFunctionAndMethodDeclarationSyntax : IEquatable<ShaderFunctionAndMethodDeclarationSyntax>
{
    public readonly ShaderFunction function;
    public readonly BaseMethodDeclarationSyntax methodDeclaration;
    /// <summary>
    /// Only present for entry-point functions.
    /// </summary>
    public readonly ShaderFunctionAndMethodDeclarationSyntax[] orderedFunctionList;

    public ShaderFunctionAndMethodDeclarationSyntax(ShaderFunction function, BaseMethodDeclarationSyntax methodDeclaration, ShaderFunctionAndMethodDeclarationSyntax[] orderedFunctionList)
    {
        this.function = function;
        this.methodDeclaration = methodDeclaration;
        this.orderedFunctionList = orderedFunctionList;
    }

    public bool Equals(ShaderFunctionAndMethodDeclarationSyntax? other)
    {
        return other is not null &&
            function.declaringType == other.function.declaringType &&
            function.name == other.function.name;
    }

    public override bool Equals(object? obj) => Equals(obj as ShaderFunctionAndMethodDeclarationSyntax);
    public override int GetHashCode()=> HashCode.Combine(function.declaringType, function.name);
    public override string ToString() => function.ToString();
}
