using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace GLSH.Compiler.Internal;

/// <summary>
/// Walks given entry function and returns all method declarations used to call it.
/// Method declarations are ordered in list in a way that any method's dependencies are already present in that list before
/// </summary>
internal class CallGraphWalker : CSharpSyntaxWalker
{
    protected readonly Compilation _compilation;

    private readonly List<MethodDeclarationData> _orderedMethods = [];
    private readonly HashSet<MethodDeclarationData> _visitedDeclarations = [];

    public ReadOnlySpan<MethodDeclarationData> OrderedMethods => CollectionsMarshal.AsSpan(_orderedMethods);

    private readonly Dictionary<SyntaxTree, SemanticModel> _semanticModelCache = [];
    private readonly Dictionary<SyntaxNode, SymbolInfo> _symbolCache = [];


    public CallGraphWalker(Compilation compilation, MethodDeclarationData method) : base()
    {
        _compilation = compilation;
        SyntaxNode? decl = Utilities.GetMethodSyntax(method, _compilation);
        Debug.Assert(decl != null);
        Visit(decl);
    }

    protected SemanticModel GetModel(SyntaxNode node)
    {
        if (!_semanticModelCache.TryGetValue(node.SyntaxTree, out SemanticModel? model))
            _semanticModelCache[node.SyntaxTree] = model = _compilation.GetSemanticModel(node.SyntaxTree);
        return model;
    }

    protected SymbolInfo GetInfo(SyntaxNode node)
    {
        if (!_symbolCache.TryGetValue(node, out SymbolInfo symbol))
            _symbolCache[node] = symbol = GetModel(node).GetSymbolInfo(node);
        return symbol;
    }

    protected SyntaxNode? GetOriginalDeclaration(SyntaxNode node)
    {
        SymbolInfo info = GetInfo(node);
        ISymbol? symbol = info.Symbol ?? info.CandidateSymbols.FirstOrDefault();
        return symbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax();
    }

    /// <summary>
    /// Visits invocation expression, all it's expreessions and method declaration.
    /// Adds new <see cref="MethodDeclarationData"/> to list
    /// in deepest first order.
    /// </summary>
    /// <param name="node"></param>
    public sealed override void VisitInvocationExpression(InvocationExpressionSyntax node) // methods
    {
        base.VisitInvocationExpression(node);

        if (GetOriginalDeclaration(node) is not MethodDeclarationSyntax methodDecl)
            return;

        string name = methodDecl.Identifier.ToString();
        string structName = Utilities.GetFunctionContainingTypeName(methodDecl, GetModel(methodDecl));
        string returnType = GetName(methodDecl.ReturnType);
        ParamData[] paramDatas = methodDecl.ParameterList.Parameters.Select(GetParamData).ToArray();
        MethodDeclarationData methodData = new MethodDeclarationData(structName, name, returnType, paramDatas);
        if (_visitedDeclarations.Add(methodData))
        {
            Visit(methodDecl.Body);
            _orderedMethods.Add(methodData);
        }
    }
    public sealed override void VisitImplicitObjectCreationExpression(ImplicitObjectCreationExpressionSyntax node)
    {
        base.VisitImplicitObjectCreationExpression(node);

        // Then search for methods in constructors
        if (GetOriginalDeclaration(node) is not ConstructorDeclarationSyntax ctorDeclaration)
            return;

        VisitContructor(ctorDeclaration);
    }

    /// <summary>
    /// Visits object creation expression, all it's expreessions and constructor delcaration.
    /// Adds new <see cref="MethodDeclarationData"/> to list
    /// in deepest first order.
    /// </summary>
    /// <param name="node"></param>
    public sealed override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node) // constructors
    {
        base.VisitObjectCreationExpression(node);

        // Then search for methods in constructors
        if (GetOriginalDeclaration(node) is not ConstructorDeclarationSyntax ctorDeclaration)
            return;

        VisitContructor(ctorDeclaration);
    }

    public override void Visit(SyntaxNode? node)
    {
        base.Visit(node);
        if (node == null)
            return;

        Conversion conv = GetModel(node).GetConversion(node);
        if (!conv.IsUserDefined)
            return;

        ConversionOperatorDeclarationSyntax? operatorDecl = conv.MethodSymbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as ConversionOperatorDeclarationSyntax;
        Debug.Assert(operatorDecl != null);

        string name = "." + operatorDecl.ImplicitOrExplicitKeyword.ValueText;
        string structName = Utilities.GetFunctionContainingTypeName(operatorDecl, GetModel(operatorDecl));
        string returnType = GetName(operatorDecl.Type);
        ParamData[] paramDatas = operatorDecl.ParameterList.Parameters.Select(GetParamData).ToArray();
        MethodDeclarationData methodData = new(structName, name, returnType, paramDatas);
        if (_visitedDeclarations.Add(methodData))
        {
            base.Visit(operatorDecl.Body);
            _orderedMethods.Add(methodData);
        }

        base.Visit(operatorDecl);
    }

    /// <summary>
    /// Visits assignment expression, all it's expreessions and property declarations.
    /// Adds new <see cref="MethodDeclarationData"/> to list
    /// in deepest first order.
    /// </summary>
    /// <param name="node"></param>
    public sealed override void VisitAssignmentExpression(AssignmentExpressionSyntax node) // property inside struct
    {
        base.VisitAssignmentExpression(node);
        VisitProperty(node.Right);
        VisitProperty(node.Left);
    }

    /// <summary>
    /// Visits member access expression, all it's expreessions and property declarations.
    /// Adds new <see cref="MethodDeclarationData"/> to list
    /// in deepest first order.
    /// </summary>
    /// <param name="node"></param>
    public sealed override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node) // properties
    {
        base.VisitMemberAccessExpression(node);
        VisitProperty(node);
    }

    public sealed override void VisitElementAccessExpression(ElementAccessExpressionSyntax node) // indexers
    {
        base.VisitElementAccessExpression(node);
    }

    public sealed override void VisitBinaryExpression(BinaryExpressionSyntax node) // overloaded operators
    {
        base.VisitBinaryExpression(node);
    }

    private void VisitContructor(ConstructorDeclarationSyntax ctorDeclaration)
    {
        string ctorId = ctorDeclaration.Identifier.ToString();
        string name = ".ctor";
        string className = Utilities.GetFunctionContainingTypeName(ctorDeclaration, GetModel(ctorDeclaration));
        string returnType = className;
        ParamData[] paramDatas = ctorDeclaration.ParameterList.Parameters.Select(GetParamData).ToArray();
        MethodDeclarationData methodData = new(className, name, returnType, paramDatas);

        if (_visitedDeclarations.Add(methodData))
        {
            Visit(ctorDeclaration.Body);
            _orderedMethods.Add(methodData);
        }
    }

    /// <summary>
    /// Visits property declaration, and it's body recursively.
    /// Adds new <see cref="MethodDeclarationData"/> to list
    /// in deepest first order.
    /// </summary>
    /// <param name="node"></param>
    private void VisitProperty(SyntaxNode node)
    {
        SyntaxNode? declaration = GetOriginalDeclaration(node);
        if (declaration is not PropertyDeclarationSyntax propDeclaration)
            return;

        if (Utilities.IsAutoProperty(propDeclaration))
            return;

        AccessType accessType = Utilities.GetAccessType(node);

        string returnType = GetName(propDeclaration.Type);
        string name = propDeclaration.Identifier.ToString();
        string className = Utilities.GetFunctionContainingTypeName(propDeclaration, GetModel(propDeclaration));
        ParamData[] paramDatas = [new ParamData(returnType, ParameterDirection.In)];
        var setMethodData = new MethodDeclarationData(className, "get_" + name, returnType, []);
        var getMethodData = new MethodDeclarationData(className, "set_" + name, typeof(void).FullName!, paramDatas);

        if ((accessType == AccessType.Get || accessType == AccessType.GetAndSet) && _visitedDeclarations.Add(setMethodData)) // get
        {
            AccessorDeclarationSyntax? getter = propDeclaration.AccessorList?.Accessors.Where(a => a.IsKind(SyntaxKind.SetAccessorDeclaration)).FirstOrDefault();
            Visit(getter);
            _orderedMethods.Add(setMethodData);
        }
        if ((accessType == AccessType.Set || accessType == AccessType.GetAndSet) && _visitedDeclarations.Add(getMethodData)) // set
        {
            AccessorDeclarationSyntax? setter = propDeclaration.AccessorList?.Accessors.Where(a => a.IsKind(SyntaxKind.GetAccessorDeclaration)).FirstOrDefault();
            Visit(setter);
            _orderedMethods.Add(getMethodData);
        }
    }

    private string GetName(TypeSyntax typeSyntax)
    {
        return GetModel(typeSyntax).GetSymbolInfo(typeSyntax).Symbol.GetFullMetadataName();
    }

    private ParamData GetParamData(ParameterSyntax item)
    {
        string typeName = GetName(item.Type);
        var refKind = (GetModel(item).GetDeclaredSymbol(item))!.RefKind;
        var direction = Utilities.RefKindToDirection(refKind);
        return new ParamData(typeName, direction);
    }
}
