using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace GLSH.Compiler.Internal;

internal class CallsAndStructsGraphWalker : CallGraphWalker
{
    private readonly List<StructDeclarationData> _orderedStructs = [];
    private readonly HashSet<string> _visitedDeclarations = [];

    public ReadOnlySpan<StructDeclarationData> OrderedStructs => CollectionsMarshal.AsSpan(_orderedStructs);

    public CallsAndStructsGraphWalker(Compilation compilation, MethodDeclarationData method) : base(compilation, method) { }

    private StructDeclarationSyntax? GetStructDeclarationSyntax(TypeSyntax type)
    {
        return GetInfo(type).Symbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as StructDeclarationSyntax;
    }

    public override void VisitParameter(ParameterSyntax node)
    {
        var type = node.Type;
        Debug.Assert(type != null);
        var sds = GetStructDeclarationSyntax(type);
        DiscoverStruct(sds);
    }

    public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
    {
        base.VisitVariableDeclaration(node);
        var sds = GetStructDeclarationSyntax(node.Type);
        DiscoverStruct(sds);
    }

    private void DiscoverStruct(StructDeclarationSyntax? node)
    {
        if (node == null)
            return;

        var name = GetModel(node).GetDeclaredSymbol(node)?.GetFullMetadataName();

        if (name == null || !_visitedDeclarations.Add(name))
            return;

        var fieldWalker = new FieldWalker(_compilation);
        fieldWalker.Visit(node);
        foreach (var item in fieldWalker.fields)
        {
            var type = _compilation.GetTypeByMetadataName(item.typeName);
            var sds = type?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as StructDeclarationSyntax;
            DiscoverStruct(sds);
        }

        _orderedStructs.Add(new StructDeclarationData(name, [.. fieldWalker.fields]));
    }



    private class FieldWalker : CSharpSyntaxWalker
    {
        private readonly Compilation _compilation;
        public readonly List<StructField> fields = [];

        public FieldWalker(Compilation compilation) => _compilation = compilation;

        public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            var type = node.Declaration.Type;
            var typeName = _compilation.GetSemanticModel(node.SyntaxTree).GetTypeInfo(node.Declaration.Type).Type?.GetFullMetadataName();
            if (typeName == null)
                return;

            foreach (var variable in node.Declaration.Variables)
            {
                var fieldName = variable.Identifier.ToString();
                fields.Add(new StructField(typeName, fieldName));
            }
        }

        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            if (node.AccessorList?.Accessors.Any(a => a.Body != null || a.ExpressionBody != null) ?? true)
                return;
            var typeName = _compilation.GetSemanticModel(node.SyntaxTree).GetTypeInfo(node.Type).Type?.GetFullMetadataName();
            if (typeName == null)
                return;

            var fieldName = node.Identifier.ToString();
            fields.Add(new StructField(typeName, fieldName));
        }
    }
}
