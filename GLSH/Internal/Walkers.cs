using Microsoft.CodeAnalysis;
using System;

namespace GLSH.Compiler.Internal
{
    internal static class Walkers
    {

        public static ReadOnlySpan<MethodDeclarationData> GetOrderedMethodDeclarations(Compilation compilation, MethodDeclarationData method)
        {
            CallGraphWalker callGraphWalker = new CallGraphWalker(compilation, method);
            return callGraphWalker.OrderedMethods;
        }

        public static ReadOnlySpan<StructDeclarationData> GetOrderedStructDeclarations(Compilation compilation, MethodDeclarationData method)
        {
            CallsAndStructsGraphWalker structGraphWalker = new CallsAndStructsGraphWalker(compilation, method);
            return structGraphWalker.OrderedStructs;
        }


    }
}
