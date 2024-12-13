using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace GLSH.Compiler;

public class ShaderGenerationException : Exception
{
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
        sb.Append(message);
        sb.AppendLine();
        sb.AppendLine($"File path: {node.SyntaxTree.FilePath}");
        sb.AppendLine($"Code line: {node.SpanStart}");
        return sb.ToString();
    }

    public static void ThrowIfNull([NotNull] object? argument, string message, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
            throw new ShaderGenerationException(string.Format(message, paramName));
    }

    public static void ThrowIf([DoesNotReturnIf(true)] bool needsThrow, string message)
    {
        if (needsThrow)
            throw new ShaderGenerationException(message);
    }

    public static void ThrowIf([DoesNotReturnIf(true)] bool needsThrow, string messageTemplate, object parameter)
    {
        if (needsThrow)
            throw new ShaderGenerationException(string.Format(messageTemplate, parameter));
    }
    public static void ThrowIf([DoesNotReturnIf(true)] bool needsThrow, string messageTemplate, object parameter1, object parameter2)
    {
        if (needsThrow)
            throw new ShaderGenerationException(string.Format(messageTemplate, parameter1, parameter2));
    }
}
