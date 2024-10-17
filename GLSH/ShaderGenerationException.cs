using Microsoft.CodeAnalysis;
using System;
using System.Text;

namespace GLSH;

public class ShaderGenerationException : Exception
{
    public ShaderGenerationException()
    {
    }

    public ShaderGenerationException(string message) : base(message)
    {
    }

    public ShaderGenerationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ShaderGenerationException(string message, SyntaxNode node) : base(FormatNodeData(message, node))
    {
    }

    private static string FormatNodeData(string message, SyntaxNode node)
    {
        StringBuilder sb = new();
        var file = node.SyntaxTree.GetRoot().ToString();
        sb.Append(message);
        sb.AppendLine();
        sb.AppendLine($"File path: {node.SyntaxTree.FilePath}");
        sb.AppendLine($"Code line: {node.SpanStart}");
        return sb.ToString();
    }
}
