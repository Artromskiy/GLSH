using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GLSH.Compiler.Internal;

internal static class Utilities
{
    public static string GetFullTypeName(this SemanticModel model, ExpressionSyntax type)
    {
        return model.GetFullTypeName(type, out _);
    }

    [Obsolete("Rewrite this hell")]
    public static string GetFullTypeName(this SemanticModel model, ExpressionSyntax type, out bool isArray)
    {
        ArgumentNullException.ThrowIfNull(model);
        ArgumentNullException.ThrowIfNull(type);

        if (type.SyntaxTree != model.SyntaxTree)
            model = model.Compilation.GetSemanticModel(type.SyntaxTree);

        TypeInfo typeInfo = model.GetTypeInfo(type);
        if (typeInfo.Type == null)
        {
            typeInfo = model.GetSpeculativeTypeInfo(0, type, SpeculativeBindingOption.BindAsTypeOrNamespace);
            if (typeInfo.Type == null || typeInfo.Type is IErrorTypeSymbol)
            {
                throw new InvalidOperationException("Unable to resolve type: " + type + " at " + type.GetLocation());
            }
        }

        return GetFullTypeName(typeInfo.Type, out isArray);
    }

    public static string GetFullTypeName(ITypeSymbol type, out bool isArray)
    {
        if (type is IArrayTypeSymbol ats)
        {
            isArray = true;
            return ats.ElementType.GetFullMetadataName();
        }
        else
        {
            isArray = false;
            return type.GetFullMetadataName();
        }
    }

    public static string GetFullTypeName(ITypeSymbol type)
    {
        if (type is IArrayTypeSymbol ats)
            return ats.ElementType.GetFullMetadataName();
        else
            return type.GetFullMetadataName();
    }

    public static string GetFullMetadataName(this ISymbol s)
    {
        if (s == null || IsRootNamespace(s))
            return string.Empty;

        if (s.Kind == SymbolKind.ArrayType)
            return ((IArrayTypeSymbol)s).ElementType.GetFullMetadataName() + "[]";

        StringBuilder sb = new(s.MetadataName);
        ISymbol last = s;

        s = s.ContainingSymbol;

        while (!IsRootNamespace(s))
        {
            var separator = s is ITypeSymbol && last is ITypeSymbol ? '+' : '.';
            sb.Insert(0, separator);
            sb.Insert(0, s.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat));
            s = s.ContainingSymbol;
        }
        return sb.ToString();
    }

    private static bool IsRootNamespace(ISymbol symbol) => symbol is INamespaceSymbol s && s.IsGlobalNamespace;

    public static string GetFunctionContainingTypeName(SyntaxNode node, SemanticModel model) =>
        model.GetDeclaredSymbol(node)!.ContainingSymbol.GetFullMetadataName();

    /// <summary>
    /// Gets the full namespace + name for the given SymbolInfo.
    /// </summary>
    public static string GetFullName(SymbolInfo symbolInfo)
    {
        Debug.Assert(symbolInfo.Symbol != null);
        return symbolInfo.Symbol.GetFullMetadataName();
    }

    public static MethodDeclarationData GetMethodDeclarationData(IMethodSymbol methodSymbol)
    {
        var methodName = methodSymbol.Name;
        var containingType = methodSymbol.ContainingSymbol.GetFullMetadataName();
        var returnTypeName = methodName == ".ctor" ? containingType : methodSymbol.ReturnType.GetFullMetadataName();
        var parameters = methodSymbol.Parameters.Select(GetParamData).ToArray();
        return new MethodDeclarationData(containingType, methodName, returnTypeName, parameters);
    }

    public static INamedTypeSymbol GetTypeSymbol(StructDeclarationData structDeclaration, Compilation compilation)
    {
        return compilation.GetTypeByMetadataName(structDeclaration.name)!;
    }

    public static IMethodSymbol? GetMethodSymbol(MethodDeclarationData method, Compilation compilation)
    {
        var type = compilation.GetTypeByMetadataName(method.containingType);
        return type?.GetMembers().OfType<IMethodSymbol>().FirstOrDefault(methodSymbol => GetMethodDeclarationData(methodSymbol) == method);
    }

    public static SyntaxNode? GetMethodSyntax(MethodDeclarationData method, Compilation compilation)
    {
        return GetMethodSymbol(method, compilation)?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax();
    }

    private static ParamData GetParamData(IParameterSymbol item)
    {
        var typeName = item.Type.GetFullMetadataName();
        var direction = item.RefKind switch
        {
            RefKind.Out => ParameterDirection.Out,
            RefKind.Ref => ParameterDirection.InOut,
            _ => ParameterDirection.In,
        };
        return new ParamData(typeName, direction);
    }

    public static ParameterDirection RefKindToDirection(RefKind refKind) => refKind switch
    {
        RefKind.Out => ParameterDirection.Out,
        RefKind.Ref => ParameterDirection.InOut,
        _ => ParameterDirection.In
    };


    //
    // ++/--    pre/postfix increments            get/set
    // =        lhs of simple assignments         set
    // +=, -=   lhs of other assigments           get/set
    // x.y      rhs, of compound member access    recurr up
    //
    // any other use is just a get
    //
    // TOOD: ref parameters?
    //
    public static AccessType GetAccessType(SyntaxNode node)
    {
        SyntaxKind kind = node.Parent.Kind();

        if (kind == SyntaxKind.PostIncrementExpression ||
            kind == SyntaxKind.PostDecrementExpression ||
            kind == SyntaxKind.PreIncrementExpression ||
            kind == SyntaxKind.PreDecrementExpression)
            return AccessType.GetAndSet;

        if (node.Parent is AssignmentExpressionSyntax syntax && syntax.Left == node)
            return kind == SyntaxKind.SimpleAssignmentExpression ? AccessType.Set : AccessType.GetAndSet;
        if (node.Parent is MemberAccessExpressionSyntax m && m.Name == node)
            return GetAccessType(node.Parent);

        return AccessType.Get;
    }

    public static string Indent(this string? s, int lvl = 1)
    {
        return new string(' ', lvl * 4) + s;
    }

    public static bool IsAutoProperty(PropertyDeclarationSyntax propDeclaration)
    {
        return propDeclaration.AccessorList?.Accessors.All(a => a.Body == null && a.ExpressionBody == null) ?? true;
    }
}
