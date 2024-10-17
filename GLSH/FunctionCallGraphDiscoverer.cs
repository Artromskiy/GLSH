using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GLSH;

internal class FunctionCallGraphDiscoverer
{
    public Compilation Compilation { get; }
    private readonly CallGraphNode _rootNode;
    private readonly Dictionary<TypeAndMethodName, CallGraphNode> _nodesByName = [];

    public FunctionCallGraphDiscoverer(Compilation compilation, TypeAndMethodName rootMethod)
    {
        Compilation = compilation;
        bool foundDecl = GetDeclaration(rootMethod, out var declaration);
        _rootNode = new CallGraphNode(rootMethod, declaration);
        Debug.Assert(foundDecl);
        _nodesByName.Add(rootMethod, _rootNode);
    }

    public ShaderFunctionAndMethodDeclarationSyntax[] GetOrderedCallList()
    {
        HashSet<ShaderFunctionAndMethodDeclarationSyntax> result = [];
        TraverseNode(result, _rootNode);
        return [.. result];
    }

    [Obsolete("Rewrite this hell")]
    private void TraverseNode(HashSet<ShaderFunctionAndMethodDeclarationSyntax> result, CallGraphNode node)
    {
        foreach (ShaderFunctionAndMethodDeclarationSyntax existing in result)
        {
            if (node.Parents.Any(cgn => cgn.name.Equals(existing)))
            {
                throw new ShaderGenerationException("There was a cyclical call graph involving " + existing + " and " + node.name);
            }
        }

        foreach (CallGraphNode child in node.Children)
        {
            TraverseNode(result, child);
        }

        ShaderFunctionAndMethodDeclarationSyntax sfab = Utilities.GetShaderFunction(node.declaration, Compilation, false);

        result.Add(sfab);
    }

    public void GenerateFullGraph()
    {
        ExploreCallNode(_rootNode);
    }

    [Obsolete("Rewrite this hell")]
    private void ExploreCallNode(CallGraphNode node)
    {
        Debug.Assert(node.declaration != null);
        MethodWalker walker = new(this);
        walker.Visit(node.declaration);
        TypeAndMethodName[] childrenNames = walker.GetChildren();
        foreach (TypeAndMethodName childName in childrenNames)
        {
            if (childName.Equals(node.name))
            {
                throw new ShaderGenerationException(
                    $"A function invoked transitively by {_rootNode.name} calls {childName}, which calls itself. Recursive functions are not supported.");
            }
            CallGraphNode childNode = GetNode(childName);
            if (childNode.declaration != null)
            {
                childNode.Parents.Add(node);
                node.Children.Add(childNode);
                ExploreCallNode(childNode);
            }
        }
    }

    private CallGraphNode GetNode(TypeAndMethodName name)
    {
        if (!_nodesByName.TryGetValue(name, out CallGraphNode? node))
        {
            GetDeclaration(name, out var declaration);
            node = new CallGraphNode(name, declaration);
            _nodesByName.Add(name, node);
        }

        return node;
    }

    [Obsolete("Rewrite this hell")]
    private bool GetDeclaration(TypeAndMethodName name, [NotNullWhen(true)] out BaseMethodDeclarationSyntax? decl)
    {
        bool isConstructor = name.methodName == ".ctor";
        INamedTypeSymbol symb = Compilation.GetTypeByMetadataName(name.typeName);
        foreach (SyntaxReference synRef in symb.DeclaringSyntaxReferences)
        {
            SyntaxNode node = synRef.GetSyntax();
            foreach (SyntaxNode child in node.ChildNodes())
            {
                if (isConstructor)
                {
                    if (child is ConstructorDeclarationSyntax cds)
                    {
                        decl = cds;
                        return true;
                    }
                }


                if (child is MethodDeclarationSyntax mds)
                {
                    if (mds.Identifier.ToFullString() == name.methodName)
                    {
                        decl = mds;
                        return true;
                    }
                }
            }
        }

        decl = null;
        return false;
    }

    private class MethodWalker : CSharpSyntaxWalker
    {
        private readonly FunctionCallGraphDiscoverer _discoverer;
        private readonly HashSet<TypeAndMethodName> _children = [];

        public MethodWalker(FunctionCallGraphDiscoverer discoverer) : base(SyntaxWalkerDepth.StructuredTrivia)
        {
            _discoverer = discoverer;
        }

        [Obsolete("Rewrite this hell")]
        public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            SymbolInfo symbolInfo = _discoverer.Compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(node);
            ISymbol? symbol = symbolInfo.Symbol;
            if (symbol == null && symbolInfo.CandidateSymbols.Length == 1)
            {
                symbol = symbolInfo.CandidateSymbols[0];
            }
            if (symbol == null)
            {
                throw new ShaderGenerationException($"A constructor reference could not be identified: {node}");
            }

            string containingType = symbol.ContainingType.ToDisplayString();
            _children.Add(new TypeAndMethodName(containingType, ".ctor"));

            base.VisitObjectCreationExpression(node);
        }

        [Obsolete("Rewrite this hell")]
        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            if (node.Expression is IdentifierNameSyntax ins)
            {
                SymbolInfo symbolInfo = _discoverer.Compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(ins);
                ISymbol? symbol = symbolInfo.Symbol;
                if (symbol == null && symbolInfo.CandidateSymbols.Length == 1)
                {
                    symbol = symbolInfo.CandidateSymbols[0];
                }
                if (symbol == null)
                {
                    throw new ShaderGenerationException($"A member reference could not be identified: {node.Expression}", node);
                }

                string containingType = symbol.ContainingType.ToDisplayString();
                string methodName = symbol.Name;
                _children.Add(new TypeAndMethodName(containingType, methodName));
            }
            else if (node.Expression is MemberAccessExpressionSyntax maes)
            {
                SymbolInfo methodSymbol = _discoverer.Compilation.GetSemanticModel(maes.SyntaxTree).GetSymbolInfo(maes);
                ISymbol? symbol = methodSymbol.Symbol;
                if (symbol == null && methodSymbol.CandidateSymbols.Length == 1)
                {
                    symbol = methodSymbol.CandidateSymbols[0];
                }
                if (symbol == null)
                {
                    throw new ShaderGenerationException($"A member reference could not be identified: {node.Expression}");
                }

                if (symbol is IMethodSymbol ims)
                {
                    string containingType = ims.ContainingType.GetFullMetadataName();
                    string methodName = ims.MetadataName;
                    _children.Add(new TypeAndMethodName(containingType, methodName));
                }
            }
            else
            {
                throw new NotImplementedException();
            }

            base.VisitInvocationExpression(node);
        }

        public TypeAndMethodName[] GetChildren() => [.. _children];
    }
}

internal class CallGraphNode
{
    public readonly TypeAndMethodName name;
    /// <summary>
    /// May be null.
    /// </summary>
    public readonly BaseMethodDeclarationSyntax? declaration;
    /// <summary>
    /// Functions called by this function.
    /// </summary>
    public readonly HashSet<CallGraphNode> Children = [];
    public readonly HashSet<CallGraphNode> Parents = [];

    public CallGraphNode(TypeAndMethodName name, BaseMethodDeclarationSyntax? declaration)
    {
        this.name = name;
        this.declaration = declaration;
    }
}
