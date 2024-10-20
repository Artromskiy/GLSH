using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace GLSH.Compiler.Internal;
internal static class AttributeHelper
{
    public static T CreateAttributeOfType<T>(this AttributeSyntax node, Compilation compilation)
        where T : Attribute =>
        node.CreateAttributeOfType<T>(compilation.GetSemanticModel(node.SyntaxTree));

    public static T CreateAttributeOfType<T>(this AttributeSyntax node, SemanticModel model) where T : Attribute
    {
        var args = node.ArgumentList?.Arguments.Select(arg => (arg.NameColon?.Name?.ToString(), arg.Expression)).ToArray();
        if (args == null)
            throw new InvalidOperationException("No arguments found for the attribute.");
        var constructors = typeof(T).GetConstructors();
        foreach (var constructor in constructors)
        {
            var parameters = constructor.GetParameters();
            if (args.Length > parameters.Length || args.Length < parameters.Count(p => !p.IsOptional))
                continue;
            try
            {
                var convertedArgs = ConvertArguments(parameters, args, model);
                if (constructor.Invoke(convertedArgs) is not T attribute)
                    continue;
                return attribute;
            }
            catch
            {
                continue;
            }
        }

        throw new InvalidOperationException("No matching constructor found for the attribute.");
    }

    private static object?[] ConvertArguments(ParameterInfo[] parameters, (string? colonName, ExpressionSyntax expression)[] argumentList, SemanticModel semanticModel)
    {
        object?[] convertedArgs = new object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            if (parameters[i].IsOptional)
                convertedArgs[i] = parameters[i].DefaultValue!;
        }
        for (int i = 0; i < argumentList.Length; i++)
        {
            (string? colonName, ExpressionSyntax expression) item = argumentList[i];
            Optional<object?> constantValue = semanticModel.GetConstantValue(item.expression);
            var argIndex = item.colonName != null ? Array.FindIndex(parameters, p => p.Name == item.colonName) : i;
            if (constantValue.HasValue)
                convertedArgs[argIndex] = constantValue.Value;
        }

        return convertedArgs;
    }

    public static bool TryGetAttributeFromCsSyntax<T>(CSharpSyntaxNode mds, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? attributeSyntax) where T : Attribute
    {
        attributeSyntax = default;
        var fullAttributeNameToSearch = typeof(T).FullName!;
        foreach (var attributeSymbol in model.GetDeclaredSymbol(mds)?.GetAttributes() ?? [])
        {
            if (attributeSymbol.AttributeClass?.GetFullMetadataName() == fullAttributeNameToSearch)
            {
                attributeSyntax = attributeSymbol.ApplicationSyntaxReference?.GetSyntax() as AttributeSyntax;
                Debug.Assert(attributeSymbol.ApplicationSyntaxReference != null);
                Debug.Assert(attributeSyntax != null);
                return true;
            }
        }
        return false;
    }


    private static bool TryGetAttributeFromList<T>(SyntaxList<AttributeListSyntax> attributeLists, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? foundAttributeSyntax) where T : Attribute
    {
        foundAttributeSyntax = null;
        var fullAttributeNameToSearch = typeof(T).FullName!;
        foreach (var attributeList in attributeLists)
        {
            foreach (var attributeSyntax in attributeList.Attributes)
            {
                if (fullAttributeNameToSearch == model.GetTypeInfo(attributeSyntax).Type?.GetFullMetadataName())
                {
                    foundAttributeSyntax = attributeSyntax;
                    return true;
                }
            }
        }
        return false;
    }

    public static bool TryGetAttribute<T>(MemberDeclarationSyntax mds, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? foundAttributeSyntax) where T : Attribute
    {
        return TryGetAttributeFromList<T>(mds.AttributeLists, model, out foundAttributeSyntax);
    }
    public static bool TryGetAttribute<T>(BaseTypeDeclarationSyntax mds, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? foundAttributeSyntax) where T : Attribute
    {
        return TryGetAttributeFromList<T>(mds.AttributeLists, model, out foundAttributeSyntax);
    }
    public static bool TryGetAttribute<T>(BaseFieldDeclarationSyntax mds, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? foundAttributeSyntax) where T : Attribute
    {
        return TryGetAttributeFromList<T>(mds.AttributeLists, model, out foundAttributeSyntax);
    }
    public static bool TryGetAttribute<T>(BasePropertyDeclarationSyntax mds, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? foundAttributeSyntax) where T : Attribute
    {
        return TryGetAttributeFromList<T>(mds.AttributeLists, model, out foundAttributeSyntax);
    }
    public static bool TryGetAttribute<T>(BaseMethodDeclarationSyntax mds, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? foundAttributeSyntax) where T : Attribute
    {
        return TryGetAttributeFromList<T>(mds.AttributeLists, model, out foundAttributeSyntax);
    }
    public static bool TryGetAttribute<T>(VariableDeclarationSyntax mds, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? foundAttributeSyntax) where T : Attribute
    {
        return TryGetAttributeFromCsSyntax<T>(mds, model, out foundAttributeSyntax);
    }
    public static bool TryGetAttribute<T>(VariableDeclaratorSyntax mds, SemanticModel model, [NotNullWhen(true)] out AttributeSyntax? foundAttributeSyntax) where T : Attribute
    {
        return TryGetAttributeFromCsSyntax<T>(mds, model, out foundAttributeSyntax);
    }
    public static bool TryGetAttributeFromSyntax<T>(CSharpSyntaxNode mds, Compilation compilation, [NotNullWhen(true)] out AttributeSyntax? attributeSyntax) where T : Attribute
    {
        var model = compilation.GetSemanticModel(mds.SyntaxTree);
        return TryGetAttributeFromCsSyntax<T>(mds, model, out attributeSyntax);
    }

}
