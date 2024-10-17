using GLSH.Primitives;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;

namespace GLSH;

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

        _contexts.Add(setName, new BackendContext());
    }

    internal BackendContext GetContext(string setName)
    {
        if (!_contexts.TryGetValue(setName, out BackendContext? ret))
        {
            throw new InvalidOperationException("There was no Shader Set generated with the name " + setName);
        }
        return ret;
    }


    internal ShaderModel GetShaderModel(string setName)
    {
        BackendContext context = GetContext(setName);

        foreach (ResourceDefinition rd in context.Resources
            .Where(rd =>
                rd.resourceKind == ShaderResourceKind.Uniform
                || rd.resourceKind == ShaderResourceKind.RWStructuredBuffer
                || rd.resourceKind == ShaderResourceKind.StructuredBuffer))
        {
            ForceTypeDiscovery(setName, rd.valueType);
        }
        // HACK: Discover all field structure types.
        foreach (StructureDefinition sd in context.Structures.ToArray())
        {
            foreach (FieldDefinition fd in sd.fields)
            {
                ForceTypeDiscovery(setName, fd.type);
            }
        }

        ResourceDefinition[] vertexResources = null;
        ResourceDefinition[] fragmentResources = null;
        ResourceDefinition[] computeResources = null;
        ShaderFunctionAndMethodDeclarationSyntax[] contextFunctions = [.. context.Functions];

        // Discover all parameter types
        foreach (ShaderFunctionAndMethodDeclarationSyntax sf in contextFunctions)
        {
            foreach (ParameterDefinition funcParam in sf.function.parameters)
            {
                if (funcParam.symbol.Type.TypeKind == TypeKind.Struct)
                {
                    ForceTypeDiscovery(setName, funcParam.type);
                }
            }
        }

        foreach (ShaderFunctionAndMethodDeclarationSyntax sf in contextFunctions)
        {
            if (sf.function.IsEntryPoint)
            {
                MethodProcessResult processedFunction = ProcessEntryFunction(setName, sf.function);

                if (sf.function.type == ShaderFunctionType.VertexEntryPoint)
                {
                    vertexResources = [.. processedFunction.resourcesUsed];
                }
                else if (sf.function.type == ShaderFunctionType.FragmentEntryPoint)
                {
                    fragmentResources = [.. processedFunction.resourcesUsed];
                }
                else
                {
                    Debug.Assert(sf.function.type == ShaderFunctionType.ComputeEntryPoint);
                    computeResources = [.. processedFunction.resourcesUsed];
                }
            }
        }

        return new ShaderModel(
            [.. context.Structures],
            [.. context.Resources],
            context.Functions.Select(sfabs => sfabs.function).ToArray(),
            vertexResources,
            fragmentResources,
            computeResources);
    }

    internal virtual string CorrectAssignedValue(
        string leftExprType,
        string rightExpr,
        string rightExprType)
    {
        return rightExpr;
    }

    private void ForceTypeDiscovery(string setName, TypeReference tr)
    {
        if (ShaderPrimitiveTypes.IsPrimitiveType(tr.name))
            return;

        if (tr.typeInfo.TypeKind == TypeKind.Enum)
        {
            INamedTypeSymbol? enumBaseType = ((INamedTypeSymbol)tr.typeInfo).EnumUnderlyingType;
            if (enumBaseType != null
                && enumBaseType.SpecialType != SpecialType.System_Int32
                && enumBaseType.SpecialType != SpecialType.System_UInt32)
            {
                throw new ShaderGenerationException("Resource type's field had an invalid enum base type: " + enumBaseType.ToDisplayString());
            }
            return;
        }

        ITypeSymbol type = tr.typeInfo;
        string name = tr.name;
        if (type is INamedTypeSymbol namedTypeSymb && namedTypeSymb.TypeArguments.Length == 1)
            name = Utilities.GetFullTypeName(namedTypeSymb.TypeArguments[0], out _);

        if (!TryDiscoverStructure(setName, name, out StructureDefinition? sd))
            throw new ShaderGenerationException("Resource type's field could not be resolved: " + name);

        foreach (FieldDefinition field in sd.fields)
        {
            ForceTypeDiscovery(setName, field.type);
        }
    }

    public MethodProcessResult ProcessEntryFunction(string setName, ShaderFunction function)
    {
        ArgumentNullException.ThrowIfNull(function);

        if (!_processedFunctions.TryGetValue(function, out MethodProcessResult? result))
        {
            if (!function.IsEntryPoint)
                throw new ShaderGenerationException("Functions listed in a ShaderSet attribute must have either VertexFunction or FragmentFunction attributes.");

            result = GenerateFullTextCore(setName, function);
            _processedFunctions.Add(function, result);
        }

        return result;
    }

    internal string CSharpToShaderType(TypeReference typeReference)
    {
        ArgumentNullException.ThrowIfNull(typeReference);

        string typeNameString;
        if (typeReference.typeInfo.TypeKind == TypeKind.Enum)
        {
            var e = ((INamedTypeSymbol)typeReference.typeInfo).EnumUnderlyingType;
            typeNameString = e.GetFullMetadataName();
        }
        else
        {
            typeNameString = typeReference.name.Trim();
        }

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

        List<StructureDefinition> structures = GetContext(setName).Structures;
        if (!structures.Any(old => old.name == sd.name))
        {
            structures.Add(sd);
        }
    }

    internal virtual bool IsIndexerAccess(SymbolInfo member)
    {
        return member.Symbol.ContainingType.GetFullMetadataName() == typeof(Matrix4x4).FullName!
            && member.Symbol.Name[0] == 'M'
            && char.IsDigit(member.Symbol.Name[1]);
    }

    internal virtual void AddResource(string setName, ResourceDefinition rd)
    {
        ArgumentNullException.ThrowIfNull(rd);

        GetContext(setName).Resources.Add(rd);
    }

    internal virtual void AddFunction(string setName, ShaderFunctionAndMethodDeclarationSyntax sf)
    {
        ArgumentNullException.ThrowIfNull(sf);

        var context = GetContext(setName);

        if (!context.Functions.Contains(sf))
        {
            context.Functions.Add(sf);
        }
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

        ShaderFunctionAndMethodDeclarationSyntax? function = GetContext(setName).Functions
            .SingleOrDefault(
                sfabs => sfabs.function.declaringType == type && sfabs.function.name == method
                    && parameterInfos.Length == sfabs.function.parameters.Length);
        if (function != null)
        {
            ParameterDefinition[] funcParameters = function.function.parameters;
            string[] formattedParams = new string[funcParameters.Length];
            for (int i = 0; i < formattedParams.Length; i++)
            {
                formattedParams[i] = FormatInvocationParameter(funcParameters[i], parameterInfos[i]);
            }

            string invocationList = string.Join(", ", formattedParams);
            string fullMethodName = CSharpToShaderType(function.function.declaringType) + "_" + function.function.name.Replace(".", "0_");
            return $"{fullMethodName}({invocationList})";
        }

        return FormatInvocationCore(setName, type, method, parameterInfos);
    }

    protected virtual string FormatInvocationParameter(ParameterDefinition def, InvocationParameterInfo ipi)
    {
        return CSharpToIdentifierNameCore(ipi.fullTypeName, ipi.identifier);
    }

    protected void ValidateRequiredSemantics(string setName, ShaderFunction function, ShaderFunctionType type)
    {
        if (type == ShaderFunctionType.Normal)
            return;

        if (type == ShaderFunctionType.VertexEntryPoint)
        {
            foreach (FieldDefinition field in GetRequiredStructureType(setName, function.returnType).fields)
            {
                if (field.semanticType != SemanticType.None)
                    continue;
                throw new ShaderGenerationException("Function return type is missing semantics on field: " + field.name);
            }
        }

        foreach (ParameterDefinition pd in function.parameters)
        {
            foreach (FieldDefinition field in GetRequiredStructureType(setName, pd.type).fields)
            {
                if (field.semanticType != SemanticType.None)
                    continue;

                throw new ShaderGenerationException(
                    $"Function parameter {pd.name}'s type is missing semantics on field: {field.name}");
            }
        }
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

    protected bool TryDiscoverStructure(string setName, string name, [NotNullWhen(true)] out StructureDefinition? sd)
    {
        INamedTypeSymbol? type = _compilation.GetTypeByMetadataName(name);
        var originalDeclaration = type.OriginalDefinition;
        if (type == null || originalDeclaration.DeclaringSyntaxReferences.Length == 0)
        {
            sd = null;
            return false;
        }
        SyntaxNode declaringSyntax = type.OriginalDefinition.DeclaringSyntaxReferences[0].GetSyntax();
        if (declaringSyntax is StructDeclarationSyntax sds &&
            ShaderSyntaxWalker.TryGetStructDefinition(_compilation.GetSemanticModel(sds.SyntaxTree), sds, out sd))
        {
            AddStructure(setName, sd);
            return true;
        }

        sd = null;
        return false;
    }

    internal abstract string CorrectIdentifier(string identifier);
    protected abstract string CSharpToShaderTypeCore(string fullType);
    protected abstract string CSharpToIdentifierNameCore(string typeName, string identifier);
    protected abstract MethodProcessResult GenerateFullTextCore(string setName, ShaderFunction function);
    protected abstract string FormatInvocationCore(string setName, string type, string method, InvocationParameterInfo[] parameterInfos);
    internal abstract string GetComputeGroupCountsDeclaration(UInt3 groupCounts);

    internal static string CorrectLiteral(string literal)
    {
        if (!literal.StartsWith("0x", StringComparison.OrdinalIgnoreCase) &&
            literal.EndsWith("f", StringComparison.OrdinalIgnoreCase) &&
            !literal.Contains('.'))
            // This isn't a hack at all
            return literal.Insert(literal.Length - 1, ".");

        return literal;
    }

    internal abstract string ParameterDirection(ParameterDirection direction);

    internal virtual string CorrectCastExpression(string type, string expression)
    {
        return $"({type}) {expression}";
    }

    protected virtual ShaderMethodVisitor VisitShaderMethod(string setName, ShaderFunction func)
    {
        return new ShaderMethodVisitor(_compilation, setName, func, this);
    }

    protected HashSet<ResourceDefinition> ProcessFunctions(string setName, ShaderFunctionAndMethodDeclarationSyntax entryPoint, out string funcs, out string entry)
    {
        HashSet<ResourceDefinition> resourcesUsed = [];
        StringBuilder sb = new();

        foreach (ShaderFunctionAndMethodDeclarationSyntax f in entryPoint.orderedFunctionList)
        {
            if (!f.function.IsEntryPoint)
            {
                MethodProcessResult processResult = VisitShaderMethod(setName, f.function).VisitFunction(f.methodDeclaration);
                foreach (ResourceDefinition rd in processResult.resourcesUsed)
                    resourcesUsed.Add(rd);

                sb.AppendLine(processResult.fullText);
            }
        }
        funcs = sb.ToString();

        MethodProcessResult result = VisitShaderMethod(setName, entryPoint.function).VisitFunction(entryPoint.methodDeclaration);

        foreach (ResourceDefinition rd in result.resourcesUsed)
            resourcesUsed.Add(rd);

        entry = result.fullText;

        return resourcesUsed;
    }

    protected void ValidateResourcesUsed(string setName, IEnumerable<ResourceDefinition> resources)
    {
        foreach (ResourceDefinition resource in resources)
        {
            bool alignmentCheckNeeded =
            resource.resourceKind == ShaderResourceKind.Uniform ||
            resource.resourceKind == ShaderResourceKind.StructuredBuffer ||
            resource.resourceKind == ShaderResourceKind.RWStructuredBuffer;

            if (!alignmentCheckNeeded)
                continue;

            TypeReference type = resource.valueType;
            ValidateAlignedStruct(setName, type);
        }
    }

    private void ValidateAlignedStruct(string setName, TypeReference tr)
    {
        StructureDefinition? def = GetContext(setName).Structures.SingleOrDefault(sd => sd.name == tr.name);

        if (def == null)
            return;

        if (!def.cSharpMatchesShaderAlignment)
            throw new ShaderGenerationException(
                $"Structure type {tr.name} cannot be used as a resource because its alignment is not consistent between C# and shader languages.");

        foreach (FieldDefinition fd in def.fields)
            ValidateAlignedStruct(setName, fd.type);
    }
}
