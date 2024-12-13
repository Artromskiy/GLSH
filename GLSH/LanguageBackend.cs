using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace GLSH.Compiler;

public abstract class LanguageBackend
{
    protected readonly Compilation _compilation;

    internal Dictionary<MethodDeclarationData, StructDeclarationData[]> _structsInfo = [];
    internal Dictionary<MethodDeclarationData, MethodDeclarationData[]> _methodsInfo = [];

    internal Dictionary<StructDeclarationData, string> _structsCache = [];
    internal Dictionary<MethodDeclarationData, string> _methodsCache = [];

    internal LanguageBackend(Compilation compilation)
    {
        _compilation = compilation;
    }

    public string ProcessEntryFunction(MethodDeclarationData function)
    {
        ArgumentNullException.ThrowIfNull(function);
        CollectData(function);
        var result = GenerateFullTextCore(function);
        return result;
    }

    private void CollectData(MethodDeclarationData entryPoint)
    {
        CallsAndStructsGraphWalker walker = new(_compilation, entryPoint);
        _structsInfo.Add(entryPoint, [.. walker.OrderedStructs]);
        _methodsInfo.Add(entryPoint, [.. walker.OrderedMethods]);
    }


    internal virtual string CorrectAssignedValue(string leftExprType, string rightExpr, string rightExprType) => rightExpr;

    internal virtual string CSharpToShaderIdentifierName(SymbolInfo symbolInfo)
    {
        string typeName = symbolInfo.Symbol.ContainingType.ToDisplayString();
        string identifier = symbolInfo.Symbol.Name;
        return CorrectIdentifier(CSharpToIdentifierNameCore(typeName, identifier));
    }




    internal virtual string CorrectFieldAccess(SymbolInfo symbolInfo)
    {
        string mapped = CSharpToShaderIdentifierName(symbolInfo);
        return CorrectIdentifier(mapped);
    }
    protected abstract string GenerateFullTextCore(MethodDeclarationData function);


    internal abstract string GetComputeGroupCountsDeclaration(uint3 groupCounts);
    internal virtual string CorrectCastExpression(string type, string expression) => $"({type}) {expression}";
    internal abstract string CorrectIdentifier(string identifier);
    protected abstract string CSharpToIdentifierNameCore(string typeName, string identifier);

    public abstract string CSharpToShaderType(string fullType);
    public abstract string FormatDirection(ParameterDirection direction);
    public abstract string FormatInvocation(string type, string method, InvocationArgument[] arguments);
    public abstract string FormatDeclaration(string returnType, string type, string method, InvocationParameter[] parameters);
    public abstract string FormatBinaryExpression(string type, string method, string leftExpr, string rightExpr);
}
