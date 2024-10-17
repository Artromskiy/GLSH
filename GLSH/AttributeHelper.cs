using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace GLSH;
internal static class AttributeHelper
{
    public static T CreateAttributeOfType<T>(this AttributeSyntax node, Compilation compilation)
        where T : Attribute =>
        node.CreateAttributeOfType<T>(compilation.GetSemanticModel(node.SyntaxTree));
        
    public static T CreateAttributeOfType<T>(this AttributeSyntax node, SemanticModel model) where T : Attribute
    {
        var args = node.ArgumentList?.Arguments.Select(arg => arg.Expression).ToArray();
        if (args == null)
            throw new InvalidOperationException("No arguments found for the attribute.");

        var constructors = typeof(T).GetConstructors();

        foreach (var constructor in constructors)
        {
            var parameters = constructor.GetParameters();
            if (parameters.Length != args.Length)
                continue;
            try
            {
                if (constructor.Invoke(ConvertArguments(parameters, args, model)) is not T attribute)
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

    private static object?[] ConvertArguments(ParameterInfo[] parameters, ExpressionSyntax[] argumentList, SemanticModel semanticModel)
    {
        object?[] convertedArgs = new object[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            var parameterType = parameters[i].ParameterType;

            if (parameterType == typeof(Type))
                throw new NotImplementedException();

            var constantValue = semanticModel.GetConstantValue(argumentList[i]);
            if (constantValue.HasValue)
            {
                convertedArgs[i] = constantValue.Value;
                continue;
            }
            else
            {
                throw new InvalidOperationException($"Unsupported parameter type: {parameterType}");
            }
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
