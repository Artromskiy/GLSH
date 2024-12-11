using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace GLSH.Compiler.Internal
{
    internal partial class MethodWriter
    {
        public override string VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (NeedsPropertyWrap(node))
            {
                ShaderGenerationException.ThrowIf(Utilities.GetAccessType(node) != AccessType.Get,
                    "Setter usage should be handled by VisitAssignmentExpression");
                return WrappedGetter(node, new(_backend.GetThisToken()));
            }
            ShaderGenerationException.ThrowIf(NeedsMethodWrap(node),
                "Method usage should be handled by VisitMemberAccessExpression or VisitInvocationExpression");

            var symbol = GetModel(node).GetSymbolInfo(node).Symbol;

            // self access
            if ((symbol is IFieldSymbol || symbol is IPropertySymbol) &&
                containingType == symbol.ContainingType.GetFullMetadataName())
                return $"{_backend.GetThisToken()}.{node.Identifier.ValueText}";

            return node.Identifier.ValueText;
        }

        public override string? VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            if (NeedsPropertyWrap(node))
            {
                ShaderGenerationException.ThrowIf(Utilities.GetAccessType(node) != AccessType.Get,
                    "Setter usage should be handled by VisitAssignmentExpression");

                InvocationArgument parameter = new(Visit(node.Expression) ?? _backend.GetThisToken());
                return WrappedGetter(node.Name, parameter);
            }
            if (NeedsMethodWrap(node))
            {
                var arg = Visit(node.Expression);
                InvocationArgument[] invocationParameters = [];
                if (arg != null)
                    invocationParameters = [new(arg)];
                return WrappedMethod(node.Name, invocationParameters);
            }
            return Visit(node.Expression) + "." + Visit(node.Name);
        }

        /// <summary>
        /// Used to find imlicit casts
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public override string? Visit(SyntaxNode? node)
        {
            if (node != null)
            {
                var methodConversion = GetModel(node).GetConversion(node).MethodSymbol;
            }
            return base.Visit(node);
        }



        public override string? VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            var nameSyntax = node.Left is IdentifierNameSyntax id ? id : (node.Left as MemberAccessExpressionSyntax)!.Name;
            var inoutThis = (node.Left as MemberAccessExpressionSyntax)?.Expression;

            bool wrapLhs = NeedsPropertyWrap(node.Left);

            string rightExpr = Visit(node.Right);
            if (wrapLhs)
            {
                InvocationArgument inoutParam = new(Visit(inoutThis) ?? _backend.GetThisToken());
                return WrappedSetter(nameSyntax!, new(rightExpr), inoutParam);
            }
            string? leftExpr = Visit(node.Left);

            return $"{leftExpr} {node.OperatorToken.ValueText} {rightExpr}";
        }

        public override string? VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var nameSyntax = node.Expression is IdentifierNameSyntax id ? id : (node.Expression as MemberAccessExpressionSyntax)!.Name;
            var inoutThis = (node.Expression as MemberAccessExpressionSyntax)?.Expression;

            var inoutThisParameter = Visit(inoutThis);
            List<InvocationArgument> allArgs = [.. GetArguments(node.ArgumentList)];
            if (inoutThisParameter != null)
                allArgs.Insert(0, new(inoutThisParameter));

            return WrappedMethod(nameSyntax, [.. allArgs]);
        }

        private InvocationArgument[] GetArguments(ArgumentListSyntax? argumentListSyntax)
        {
            if (argumentListSyntax == null)
                return [];
            return argumentListSyntax.Arguments.Select(a => new InvocationArgument(Visit(a.Expression))).ToArray();
        }

        private bool NeedsPropertyWrap(ExpressionSyntax node)
        {
            var symbol = GetModel(node).GetSymbolInfo(node).Symbol;
            var propSyntax = symbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as PropertyDeclarationSyntax;
            bool isMethodProp = !(propSyntax?.AccessorList?.Accessors.All(a => a.Body == null && a.ExpressionBody == null) ?? true);
            return isMethodProp;
        }

        public override string VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            var info = GetModel(node).GetSymbolInfo(node).Symbol;
            var typeName = info.ContainingType.GetFullMetadataName();
            var methodName = info.Name;
            var left = Visit(node.Left)!;
            var right = Visit(node.Right)!;
            return _backend.FormatBinaryExpression(typeName, methodName, left, right);
        }

        private bool NeedsMethodWrap(ExpressionSyntax node)
        {
            var symbol = GetModel(node).GetSymbolInfo(node).Symbol;
            return symbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() is MethodDeclarationSyntax;
        }

        private string WrappedMethod(SyntaxNode node, InvocationArgument[] args)
        {
            var symbolInfo = GetModel(node).GetSymbolInfo(node);
            return WrappedMethod(symbolInfo.Symbol as IMethodSymbol, args);
        }

        private string WrappedMethod(IMethodSymbol method, InvocationArgument[] args)
        {
            var methodName = method.Name;
            var typeName = method.ContainingType.GetFullMetadataName();
            return _backend.FormatInvocation(typeName, methodName, args);
        }

        private string WrappedGetter(SimpleNameSyntax node, InvocationArgument inoutThis)
        {
            var propSymbol = GetModel(node).GetSymbolInfo(node).Symbol;
            var propDeclSyntax = propSymbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as PropertyDeclarationSyntax;
            var accessor = propDeclSyntax?.AccessorList?.Accessors.FirstOrDefault(a => a.IsKind(SyntaxKind.GetAccessorDeclaration));
            var method = GetModel(accessor).GetDeclaredSymbol(accessor);
            return WrappedMethod(method, [inoutThis]);
        }

        private string WrappedSetter(SimpleNameSyntax node, InvocationArgument value, InvocationArgument inoutThis)
        {
            var propSymbol = GetModel(node).GetSymbolInfo(node).Symbol;
            var propDeclSyntax = propSymbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax() as PropertyDeclarationSyntax;
            var accessor = propDeclSyntax?.AccessorList?.Accessors.FirstOrDefault(a => a.IsKind(SyntaxKind.SetAccessorDeclaration));
            var method = GetModel(accessor).GetDeclaredSymbol(accessor);
            return WrappedMethod(method, [inoutThis, value]);
        }

        public override string? VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            return WrappedMethod(node, GetArguments(node.ArgumentList));
        }

        public override string? VisitImplicitObjectCreationExpression(ImplicitObjectCreationExpressionSyntax node)
        {
            return WrappedMethod(node, GetArguments(node.ArgumentList));
        }
    }
}
