using Microsoft.CodeAnalysis;
using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace GLSH.Compiler.Internal
{
    internal partial class MethodWriter
    {
        public override string VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (NeedsPropertyWrap(node))
            {
                var access = Utilities.GetAccessType(node);
                if (access == Utilities.AccessType.Set || access == Utilities.AccessType.GetAndSet)
                    throw new NotImplementedException();
                else
                    return WrappedGetter(node);
            }

            var symbol = GetModel(node).GetSymbolInfo(node).Symbol;
            if (symbol is IFieldSymbol || symbol is IPropertySymbol)
                return "this." + node.Identifier.ValueText;

            return node.Identifier.ValueText;
        }

        public override string? VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            return base.VisitMemberAccessExpression(node);
        }

        public override string? VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            var type = GetGlTypeName(node.Type);
            var declarator = node.Variables[0];
            var identifier = declarator.Identifier;
            var right = base.Visit(declarator.Initializer.Value);

            return $"{type} {identifier} = {right};";
        }

        public override string? VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            bool wrapRhs = node.Right is IdentifierNameSyntax && NeedsPropertyWrap(node.Right);
            bool wrapLhs = node.Left is IdentifierNameSyntax && NeedsPropertyWrap(node.Left);

            string? rightExpr = wrapRhs ? WrappedGetter(node.Right) : Visit(node.Right);
            string? leftExpr = wrapLhs ? WrappedSetter(node.Left, rightExpr) : Visit(node.Left);

            if (wrapLhs)
                return leftExpr;

            return $"{leftExpr} {node.OperatorToken.ValueText} {rightExpr}";
        }

        public override string? VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            if (node.Expression is IdentifierNameSyntax ins)
            {
                SymbolInfo symbolInfo = GetModel(node).GetSymbolInfo(ins);
                string type = symbolInfo.Symbol.ContainingType.GetFullMetadataName();
                string method = symbolInfo.Symbol.Name;
                var args = string.Join(", ", node.ArgumentList.Arguments.Select(a => a.RefKindKeyword.ValueText + " " + Visit(a.Expression)));
                return type + "." + method + $"({args})";
            }
            return null;
        }

        private bool NeedsPropertyWrap(ExpressionSyntax node)
        {
            var symbol = GetModel(node).GetSymbolInfo(node).Symbol;
            var isProp = symbol is IPropertySymbol;
            var propSyntax = symbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as PropertyDeclarationSyntax;
            bool isMethodProp = !(propSyntax?.AccessorList?.Accessors.All(a => a.Body == null && a.ExpressionBody == null) ?? true);
            return isMethodProp;
        }

        private string WrappedGetter(ExpressionSyntax node)
        {
            var propSymbol = GetModel(node).GetSymbolInfo(node).Symbol;
            var propDeclSyntax = propSymbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as PropertyDeclarationSyntax;
            var accessor = propDeclSyntax?.AccessorList?.Accessors.FirstOrDefault(a => a.IsKind(SyntaxKind.GetAccessorDeclaration));
            var method = GetModel(accessor).GetDeclaredSymbol(accessor);
            return $"{GetMethodName(method)}(inout this)";
        }

        private string WrappedSetter(ExpressionSyntax node, string? parameter)
        {
            var propSymbol = GetModel(node).GetSymbolInfo(node).Symbol;
            var propDeclSyntax = propSymbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as PropertyDeclarationSyntax;
            var accessor = propDeclSyntax?.AccessorList?.Accessors.FirstOrDefault(a => a.IsKind(SyntaxKind.SetAccessorDeclaration));
            var method = GetModel(accessor).GetDeclaredSymbol(accessor);
            return $"{GetMethodName(method)}(inout this, {parameter})";
        }

        private string GetMethodName(IMethodSymbol method)
        {
            var typeName = method.ContainingType.GetFullMetadataName();
            var methodName = method.Name;
            var fullName = $"{typeName}.{methodName}";
            return _backend.CSharpToShaderType(fullName);
        }
    }
}
