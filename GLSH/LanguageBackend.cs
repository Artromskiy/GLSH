using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GLSH.Compiler;

public abstract class LanguageBackend
{
    protected readonly Compilation _compilation;

    internal Dictionary<MethodDeclarationData, StructDeclarationData[]> _structsCache = [];
    internal Dictionary<MethodDeclarationData, MethodDeclarationData[]> _methodsCache = [];

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
        _structsCache.Add(entryPoint, [..walker.OrderedStructs]);
        _methodsCache.Add(entryPoint, [..walker.OrderedMethods]);
    }


    internal virtual string CorrectAssignedValue(string leftExprType, string rightExpr, string rightExprType) => rightExpr;

    internal virtual string CSharpToShaderIdentifierName(SymbolInfo symbolInfo)
    {
        string typeName = symbolInfo.Symbol.ContainingType.ToDisplayString();
        string identifier = symbolInfo.Symbol.Name;
        return CorrectIdentifier(CSharpToIdentifierNameCore(typeName, identifier));
    }

    internal string FormatInvocation(string type, string method, InvocationParameterInfo[] parameterInfos)
    {
        Debug.Assert(type != null);
        Debug.Assert(method != null);
        Debug.Assert(parameterInfos != null);

        ShaderFunction? function = default; // this is function from context which we want to get by it's name

        if (function == null)
            return FormatInvocationCore(type, method, parameterInfos);

        ParameterDefinition[] funcParameters = function.parameters;
        string[] formattedParams = new string[funcParameters.Length];
        for (int i = 0; i < formattedParams.Length; i++)
            formattedParams[i] = FormatInvocationParameter(funcParameters[i], parameterInfos[i]);

        string invocationList = string.Join(", ", formattedParams);
        string fullMethodName = $"{CSharpToShaderTypeCore(function.declaringType)}_{function.name.Replace(".", "0_")}";
        return $"{fullMethodName}({invocationList})";
    }

    protected virtual string FormatInvocationParameter(ParameterDefinition def, InvocationParameterInfo ipi)
    {
        return CSharpToIdentifierNameCore(ipi.fullTypeName, ipi.identifier);
    }


    internal virtual string CorrectBinaryExpression(string leftExpr, string leftExprType, string operatorToken, string rightExpr, string rightExprType)
    {
        return $"{leftExpr} {operatorToken} {rightExpr}";
    }

    internal virtual string CorrectFieldAccess(SymbolInfo symbolInfo)
    {
        string mapped = CSharpToShaderIdentifierName(symbolInfo);
        return CorrectIdentifier(mapped);
    }

    public string CSharpToShaderType(string typeName) => CSharpToShaderTypeCore(typeName);
    internal abstract string CorrectIdentifier(string identifier);
    protected abstract string CSharpToShaderTypeCore(string fullType);
    protected abstract string CSharpToIdentifierNameCore(string typeName, string identifier);
    protected abstract string GenerateFullTextCore(MethodDeclarationData function);
    protected abstract string FormatInvocationCore(string type, string method, InvocationParameterInfo[] parameterInfos);
    internal abstract string GetComputeGroupCountsDeclaration(uint3 groupCounts);
    internal abstract string ParameterDirection(ParameterDirection direction);
    internal virtual string CorrectCastExpression(string type, string expression) => $"({type}) {expression}";
    public abstract string CorrectArgumentRefKind(string refKind);

    public abstract string GetMethodName(MethodDeclarationData method);
}
