using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Reflection;

namespace GLSH;
internal class AttributeFactory
{
    public static T CreateFromNode<T>(AttributeSyntax node, Compilation compilation) where T : Attribute
    {
        SemanticModel semanticModel = compilation.GetSemanticModel(node.SyntaxTree);
        var args = node.ArgumentList?.Arguments.Select(arg => arg.Expression).ToArray();

        if (args == null)
            throw new InvalidOperationException("No arguments found for the attribute.");

        var attributeType = typeof(T);
        var constructors = attributeType.GetConstructors();

        foreach (var constructor in constructors)
        {
            var parameters = constructor.GetParameters();
            if (parameters.Length != args.Length)
                continue;
            try
            {
                var convertedArgs = ConvertArguments(parameters, args, semanticModel);
                return (T)constructor.Invoke(convertedArgs);
            }
            catch
            {
                continue;
            }
        }

        throw new InvalidOperationException("No matching constructor found for the attribute.");
    }

    private static object[] ConvertArguments(ParameterInfo[] parameters, ExpressionSyntax[] argumentList, SemanticModel semanticModel)
    {
        object[] convertedArgs = new object[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            var parameterType = parameters[i].ParameterType;

            if (parameterType == typeof(Type))
            {
                throw new NotImplementedException();
            }
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
}
