using Microsoft.CodeAnalysis;
using System.Diagnostics.CodeAnalysis;

namespace GLSH.Compiler;

// https://stackoverflow.com/questions/20458457/getting-class-fullname-including-namespace-from-roslyn-classdeclarationsyntax
internal static class SyntaxNodeHelper
{
    public static bool TryGetParentSyntax<T>(SyntaxNode? syntaxNode, [NotNullWhen(true)] out T? result)
        where T : SyntaxNode
    {
        // set defaults
        result = null;

        if (syntaxNode == null)
            return false;

        try
        {
            syntaxNode = syntaxNode.Parent;

            if (syntaxNode == null)
                return false;

            if (!typeof(T).IsAssignableFrom(syntaxNode.GetType()))
                return TryGetParentSyntax(syntaxNode, out result);

            result = (syntaxNode as T)!;
            return true;
        }
        catch
        {
            return false;
        }
    }
}
