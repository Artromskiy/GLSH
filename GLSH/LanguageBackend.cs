using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;

namespace GLSH.Compiler;

public abstract class LanguageBackend
{
    protected readonly Compilation _compilation;
    private readonly Dictionary<string, BackendContext> _contexts = [];
    private readonly Dictionary<ShaderFunction, MethodProcessResult> _processedFunctions = [];

    internal LanguageBackend(Compilation compilation)
    {
        _compilation = compilation;
    }

    // Must be called before attempting to retrieve the context.
    internal void InitContext(string setName)
    {
        if (_contexts.ContainsKey(setName))
        {
            throw new InvalidOperationException("A set was initialized twice: " + setName);
        }

        _contexts.Add(setName, new());
    }

    internal BackendContext GetContext(string setName)
    {
        if (!_contexts.TryGetValue(setName, out BackendContext? ret))
        {
            throw new InvalidOperationException("There was no Shader Set generated with the name " + setName);
        }
        return ret;
    }


    [Obsolete("Rewrite this hell")]
    internal ShaderModel GetShaderModel(string setName)
    {
        BackendContext context = GetContext(setName);

        foreach (ResourceDefinition rd in context.Resources)
            if (rd.resourceKind.NeedsForceTypeDiscovery())
                ForceTypeDiscovery(setName, rd.valueType);
        // HACK: Discover all field structure types.
        foreach (StructureDefinition sd in context.Structures)
            foreach (FieldDefinition fd in sd.fields)
                ForceTypeDiscovery(setName, fd.type);

        ResourceDefinition[] vertexResources = [];
        ResourceDefinition[] fragmentResources = [];
        ResourceDefinition[] computeResources = [];
        ShaderFunctionAndMethodDeclarationSyntax[] contextFunctions = [.. context.Functions];

        // Discover all parameter types
        foreach (var sf in contextFunctions)
            foreach (var funcParam in sf.function.parameters)
                if (funcParam.isStruct)
                    ForceTypeDiscovery(setName, funcParam.type);

        foreach (ShaderFunctionAndMethodDeclarationSyntax sf in contextFunctions)
        {
            if (!sf.function.IsEntryPoint)
                continue;

            var resourcesOfPipelineFunction = sf.function.type switch
            {
                ShaderFunctionType.VertexEntryPoint => vertexResources,
                ShaderFunctionType.FragmentEntryPoint => fragmentResources,
                ShaderFunctionType.ComputeEntryPoint => computeResources,
                _ => throw new ShaderGenerationException("Attempt to process resource not bound to EntryPoint")
            };
            resourcesOfPipelineFunction = [.. ProcessEntryFunction(setName, sf.function).resourcesUsed];
        }
        ShaderFunction[] functions = new ShaderFunction[context.Functions.Length];
        for (int i = 0; i < context.Functions.Length; i++)
            functions[i] = context.Functions[i].function;
        return new ShaderModel([.. context.Structures], [.. context.Resources], functions,
            vertexResources, fragmentResources, computeResources);
    }

    internal virtual string CorrectAssignedValue(string leftExprType, string rightExpr, string rightExprType) => rightExpr;

    [Obsolete("Rewrite this hell")]
    private void ForceTypeDiscovery(string setName, TypeReference tr)
    {
        if (ShaderPrimitiveTypes.IsPrimitiveType(tr.name))
            return;

        if (tr.isEnum)
        {
            ShaderGenerationException.ThrowIf(tr.enumTypeName != typeof(int).FullName! && tr.enumTypeName != typeof(uint).FullName!,
            "Resource type's field had an invalid enum base type: {0}", tr.enumTypeName);
            return;
        }

        string name = tr.name;
        if (tr.isArray)
            name = tr.arrayTypeName;

        ShaderGenerationException.ThrowIf(!TryDiscoverStructure(setName, name, out StructureDefinition? sd),
            "Resource type's field could not be resolved: {0}", name);

        foreach (FieldDefinition field in sd.fields)
            ForceTypeDiscovery(setName, field.type);
    }

    public MethodProcessResult ProcessEntryFunction(string setName, ShaderFunction function)
    {
        ArgumentNullException.ThrowIfNull(function);

        if (_processedFunctions.TryGetValue(function, out MethodProcessResult? result))
            return result;

        ShaderGenerationException.ThrowIf(!function.IsEntryPoint,
            "Functions listed in a ShaderSet attribute must have either VertexFunction or FragmentFunction attributes.");

        result = GenerateFullTextCore(setName, function);
        _processedFunctions.Add(function, result);
        return result;
    }

    [Obsolete("Rewrite this hell")]
    internal string CSharpToShaderType(TypeReference typeReference)
    {
        ArgumentNullException.ThrowIfNull(typeReference);

        string? typeNameString;
        if (typeReference.isEnum)
            typeNameString = typeReference.enumTypeName!;
        else
            typeNameString = typeReference.name.Trim(); // why we Trim?

        return CSharpToShaderTypeCore(typeNameString);
    }

    internal string CSharpToShaderType(string fullType)
    {
        ArgumentNullException.ThrowIfNull(fullType);

        return CSharpToShaderTypeCore(fullType);
    }

    internal virtual void AddStructure(string setName, StructureDefinition sd)
    {
        ArgumentNullException.ThrowIfNull(sd);
        var ctx = GetContext(setName);

        if (!ctx.Structures.Exists(old => old.name == sd.name))
            ctx.AddStructure(sd);
    }

    internal virtual bool IsIndexerAccess(SymbolInfo member)
    {
        return member.Symbol.ContainingType.GetFullMetadataName() == typeof(Matrix4x4).FullName! &&
            member.Symbol.Name[0] == 'M' && char.IsDigit(member.Symbol.Name[1]);
    }

    internal virtual void AddResource(string setName, ResourceDefinition rd)
    {
        ArgumentNullException.ThrowIfNull(rd);
        GetContext(setName).AddResource(rd);
    }

    internal virtual void AddFunction(string setName, ShaderFunctionAndMethodDeclarationSyntax sf)
    {
        ArgumentNullException.ThrowIfNull(sf);
        var ctx = GetContext(setName);
        if (!ctx.Functions.Contains(sf))
            ctx.AddFunction(sf);
    }

    internal virtual string CSharpToShaderIdentifierName(SymbolInfo symbolInfo)
    {
        string typeName = symbolInfo.Symbol.ContainingType.ToDisplayString();
        string identifier = symbolInfo.Symbol.Name;
        return CorrectIdentifier(CSharpToIdentifierNameCore(typeName, identifier));
    }

    internal string FormatInvocation(string setName, string type, string method, InvocationParameterInfo[] parameterInfos)
    {
        Debug.Assert(setName != null);
        Debug.Assert(type != null);
        Debug.Assert(method != null);
        Debug.Assert(parameterInfos != null);

        ShaderFunction? function = GetContext(setName).Functions.SingleOrDefault(
                sfabs => sfabs.function.declaringType == type && sfabs.function.name == method &&
                parameterInfos.Length == sfabs.function.parameters.Length)?.function;

        if (function == null)
            return FormatInvocationCore(setName, type, method, parameterInfos);

        ParameterDefinition[] funcParameters = function.parameters;
        string[] formattedParams = new string[funcParameters.Length];
        for (int i = 0; i < formattedParams.Length; i++)
            formattedParams[i] = FormatInvocationParameter(funcParameters[i], parameterInfos[i]);

        string invocationList = string.Join(", ", formattedParams);
        string fullMethodName = $"{CSharpToShaderType(function.declaringType)}_{function.name.Replace(".", "0_")}";
        return $"{fullMethodName}({invocationList})";
    }

    protected virtual string FormatInvocationParameter(ParameterDefinition def, InvocationParameterInfo ipi)
    {
        return CSharpToIdentifierNameCore(ipi.fullTypeName, ipi.identifier);
    }

    [Obsolete("Will use explicit and implicit layouts, so need to change this")]
    protected void ValidateRequiredSemantics(string setName, ShaderFunction function, ShaderFunctionType type)
    {
        if (type == ShaderFunctionType.Normal)
            return;

        if (type == ShaderFunctionType.VertexEntryPoint)
            foreach (var field in GetRequiredStructureType(setName, function.returnType).fields)
                ShaderGenerationException.ThrowIf(field.location == -1,
                    "Function return type is missing semantics on field: {0}", field.name);

        foreach (var pd in function.parameters)
            foreach (var field in GetRequiredStructureType(setName, pd.type).fields)
                ShaderGenerationException.ThrowIf(field.location == -1,
                    "Function parameter {0}'s type is missing semantics on field: {1}", pd.name, field.name);
    }

    protected virtual StructureDefinition GetRequiredStructureType(string setName, TypeReference type)
    {
        StructureDefinition? result = GetContext(setName).Structures.SingleOrDefault(sd => sd.name == type.name);

        if (result == null && !TryDiscoverStructure(setName, type.name, out result))
            throw new ShaderGenerationException("Type referred by was not discovered: " + type.name);

        return result;
    }

    internal virtual string CorrectBinaryExpression(
        string leftExpr,
        string leftExprType,
        string operatorToken,
        string rightExpr,
        string rightExprType)
    {
        return $"{leftExpr} {operatorToken} {rightExpr}";
    }

    internal virtual string CorrectFieldAccess(SymbolInfo symbolInfo)
    {
        string mapped = CSharpToShaderIdentifierName(symbolInfo);
        return CorrectIdentifier(mapped);
    }

    [Obsolete("Why the hell we are rewalking in backend?")]
    protected bool TryDiscoverStructure(string setName, string name, [NotNullWhen(true)] out StructureDefinition? sd)
    {
        sd = null;
        INamedTypeSymbol? type = _compilation.GetTypeByMetadataName(name);
        if (type == null || type.OriginalDefinition.DeclaringSyntaxReferences.Length == 0)
            return false;
        SyntaxNode declaringSyntax = type.OriginalDefinition.DeclaringSyntaxReferences[0].GetSyntax();
        if (declaringSyntax is StructDeclarationSyntax sds &&
            ShaderSyntaxWalker.TryGetStructDefinition(_compilation.GetSemanticModel(sds.SyntaxTree), sds, out sd))
        {
            AddStructure(setName, sd);
            return true;
        }

        return false;
    }

    internal abstract string CorrectIdentifier(string identifier);
    protected abstract string CSharpToShaderTypeCore(string fullType);
    protected abstract string CSharpToIdentifierNameCore(string typeName, string identifier);
    protected abstract MethodProcessResult GenerateFullTextCore(string setName, ShaderFunction function);
    protected abstract string FormatInvocationCore(string setName, string type, string method, InvocationParameterInfo[] parameterInfos);
    internal abstract string GetComputeGroupCountsDeclaration(UInt3 groupCounts);
    internal abstract string ParameterDirection(ParameterDirection direction);

    internal static string CorrectLiteral(string literal)
    {
        if (!literal.StartsWith("0x", StringComparison.OrdinalIgnoreCase) &&
            literal.EndsWith("f", StringComparison.OrdinalIgnoreCase) &&
            !literal.Contains('.'))
            // This isn't a hack at all
            return literal.Insert(literal.Length - 1, ".");

        return literal;
    }


    internal virtual string CorrectCastExpression(string type, string expression) => $"({type}) {expression}";

    protected virtual ShaderMethodVisitor VisitShaderMethod(string setName, ShaderFunction func) =>
        new(_compilation, setName, func, this);

    protected HashSet<ResourceDefinition> ProcessFunctions(string setName, ShaderFunctionAndMethodDeclarationSyntax entryPoint, out string funcs, out string entry)
    {
        HashSet<ResourceDefinition> resourcesUsed = [];
        StringBuilder sb = new();

        foreach (var funcAndDecl in entryPoint.orderedFunctionList)
        {
            if (funcAndDecl.function.IsEntryPoint)
                continue;
            var processResult = VisitShaderMethod(setName, funcAndDecl.function).VisitFunction(funcAndDecl.methodDeclaration);
            sb.AppendLine(processResult.fullText);
            resourcesUsed.UnionWith(processResult.resourcesUsed);
        }

        funcs = sb.ToString();
        var result = VisitShaderMethod(setName, entryPoint.function).VisitFunction(entryPoint.methodDeclaration);
        entry = result.fullText;
        resourcesUsed.UnionWith(result.resourcesUsed);
        return resourcesUsed;
    }

    protected void ValidateResourcesUsed(string setName, IEnumerable<ResourceDefinition> resources)
    {
        foreach (ResourceDefinition resource in resources)
            if (AlignmentCheckNeeded(resource))
                ValidateAlignedStruct(setName, resource.valueType);
    }

    private static bool AlignmentCheckNeeded(ResourceDefinition resource) =>
        resource.resourceKind == ShaderResourceKind.Uniform ||
        resource.resourceKind == ShaderResourceKind.StructuredBuffer ||
        resource.resourceKind == ShaderResourceKind.RWStructuredBuffer;

    private void ValidateAlignedStruct(string setName, TypeReference tr)
    {
        if (ShaderPrimitiveTypes.IsPrimitiveType(tr.name))
            return;
        var ctx = GetContext(setName);
        StructureDefinition? def = ctx.Structures.SingleOrDefault(sd => sd.name == tr.name);
        ShaderGenerationException.ThrowIf(def == null, "Attempt to validate type {0} without {1}", tr.name, nameof(StructureDefinition));
        ShaderGenerationException.ThrowIf(!def.cSharpMatchesShaderAlignment,
            "Structure type {1} cannot be used as a resource. Alignment is not consistent between C# and shader languages.", tr.name);

        foreach (FieldDefinition fd in def.fields)
            ValidateAlignedStruct(setName, fd.type);
    }
}
