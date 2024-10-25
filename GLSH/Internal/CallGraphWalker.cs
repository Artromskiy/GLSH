using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GLSH.Compiler.Internal
{
    internal class CallGraphWalker : CSharpSyntaxWalker
    {
        private readonly Compilation _compilation;
        private readonly List<MethodDeclData> methodDeclarations = [];
        private readonly HashSet<MethodDeclData> visitedDeclarations = [];


        private SemanticModel GetModel(SyntaxNode node) => _compilation.GetSemanticModel(node.SyntaxTree);
        private SymbolInfo GetInfo(SyntaxNode node) => GetModel(node).GetSymbolInfo(node);
        public CallGraphWalker(Compilation compilation, TypeAndMethodName name) : base()
        {
            _compilation = compilation;
            SyntaxNode? decl = null;
            bool isConstructor = name.methodName == ".ctor";
            INamedTypeSymbol symb = _compilation.GetTypeByMetadataName(name.containingTypeName)!;
            var children = symb.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax().ChildNodes();
            if (!isConstructor)
                decl = children?.FirstOrDefault(n => n is MethodDeclarationSyntax mds && mds.Identifier.ToString() == name.methodName);
            else
                decl = children?.FirstOrDefault(n => n is ConstructorDeclarationSyntax);

            Visit(decl);
        }

        public override void Visit(SyntaxNode? node)
        {
            base.Visit(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node) // methods
        {
            base.VisitInvocationExpression(node);

            var declaration = GetOriginalDeclaration(node);
            if (declaration is not MethodDeclarationSyntax methodDecl)
                return;

            var name = methodDecl.Identifier.ToString();
            var className = Utilities.GetFunctionContainingTypeName(methodDecl, GetModel(methodDecl));
            var returnType = GetName(methodDecl.ReturnType);
            var paramDatas = methodDecl.ParameterList.Parameters.Select(GetParamData).ToArray();
            var methodData = new MethodDeclData(new(className, name), returnType, paramDatas);
            if (visitedDeclarations.Add(methodData))
            {
                base.Visit(methodDecl.Body);
                methodDeclarations.Add(methodData);
            }
        }

        public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node) // constructors
        {
            base.VisitObjectCreationExpression(node);

            var declaration = GetOriginalDeclaration(node);
            if (declaration is not ConstructorDeclarationSyntax ctorDeclaration)
                return;
            var ctorId = ctorDeclaration.Identifier.ToString();
            var name = ".ctor";
            var className = Utilities.GetFunctionContainingTypeName(ctorDeclaration, GetModel(ctorDeclaration));
            var returnType = className;
            var paramDatas = ctorDeclaration.ParameterList.Parameters.Select(GetParamData).ToArray();
            var methodData = new MethodDeclData(new(className, name), returnType, paramDatas);

            if (visitedDeclarations.Add(methodData))
            {
                base.Visit(ctorDeclaration.Body);
                methodDeclarations.Add(methodData);
            }
        }

        public override void VisitAssignmentExpression(AssignmentExpressionSyntax node) // property inside struct
        {
            base.VisitAssignmentExpression(node);
            base.Visit(node.Left);
            base.Visit(node.Right);
            VisitProperty(node.Right);
            VisitProperty(node.Left);
        }

        public override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node) // properties
        {
            base.VisitMemberAccessExpression(node);
            VisitProperty(node);
        }

        private void VisitProperty(SyntaxNode node)
        {
            var declaration = GetOriginalDeclaration(node);
            if (declaration is not PropertyDeclarationSyntax propDeclaration)
                return;

            if (!(propDeclaration.AccessorList?.Accessors.All(a => a.Body != null || a.ExpressionBody != null) ?? false)) // auto property
                return;

            var accessType = GetAccessType(node);

            var name = propDeclaration.Identifier.ToString();
            var className = Utilities.GetFunctionContainingTypeName(propDeclaration, GetModel(propDeclaration));
            var returnType = accessType == AccessType.Set ? typeof(void).FullName! : GetName(propDeclaration.Type);
            ParamData[] paramDatas = [];
            var methodData = new MethodDeclData(new(className, name), returnType, paramDatas);

            if (visitedDeclarations.Add(methodData))
            {
                var getter = propDeclaration.AccessorList?.Accessors.Where(a => a.IsKind(SyntaxKind.SetAccessorDeclaration)).FirstOrDefault();
                var setter = propDeclaration.AccessorList?.Accessors.Where(a => a.IsKind(SyntaxKind.GetAccessorDeclaration)).FirstOrDefault();
                if (accessType != AccessType.GetAndSet)
                {
                    base.Visit(accessType == AccessType.Get ? getter : setter);
                }
                else
                {
                    base.Visit(getter);
                    base.Visit(setter);
                }
                methodDeclarations.Add(methodData);
            }
        }


        public override void VisitElementAccessExpression(ElementAccessExpressionSyntax node) // indexers
        {
            base.VisitElementAccessExpression(node);
        }

        public override void VisitBinaryExpression(BinaryExpressionSyntax node) // overloaded operators
        {
            base.VisitBinaryExpression(node);

            var info = GetInfo(node);
            var symbol = info.Symbol ?? info.CandidateSymbols.FirstOrDefault();
            ShaderGenerationException.ThrowIf(symbol == null, $"A constructor reference could not be identified: {0}", node);
            var declaration = symbol.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax();
            if (declaration is not PropertyDeclarationSyntax propDeclaration)
                return;
        }

        public override void VisitCastExpression(CastExpressionSyntax node) // explicit operators
        {
            base.VisitCastExpression(node);
        }


        private string GetName(TypeSyntax typeSyntax)
        {
            return GetModel(typeSyntax).GetSymbolInfo(typeSyntax).Symbol.GetFullMetadataName();
        }

        private ParamData GetParamData(ParameterSyntax item)
        {
            var typeName = GetName(item.Type);
            var direction = (GetModel(item).GetDeclaredSymbol(item))!.RefKind switch
            {
                RefKind.Out => ParameterDirection.Out,
                RefKind.Ref => ParameterDirection.InOut,
                _ => ParameterDirection.In,
            };
            return new ParamData(typeName, direction);
        }

        private SyntaxNode? GetOriginalDeclaration(SyntaxNode node)
        {
            var info = GetInfo(node);
            var symbol = info.Symbol ?? info.CandidateSymbols.FirstOrDefault();
            //ShaderGenerationException.ThrowIf(symbol == null, $"A method reference could not be identified: {0}", node);
            return symbol?.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax();
        }

        [DebuggerDisplay("{DebuggerDisplay,nq}")]
        private readonly struct MethodDeclData : IEquatable<MethodDeclData>
        {
            public readonly TypeAndMethodName methodName;
            public readonly string returnTypeName;
            public readonly ParamData[] parameters;

            private string DebuggerDisplay => methodName.fullMethodName;

            public MethodDeclData(TypeAndMethodName methodName, string returnTypeName, ParamData[] parameters)
            {
                this.methodName = methodName;
                this.returnTypeName = returnTypeName;
                this.parameters = parameters;
            }

            public readonly bool Equals(MethodDeclData other)
            {
                return methodName.Equals(other.methodName) &&
                returnTypeName == other.returnTypeName &&
                parameters.SequenceEqual(other.parameters);
            }

            public override readonly bool Equals(object? obj) => obj is MethodDeclData other && Equals(other);
            public override int GetHashCode() => HashCode.Combine(methodName, returnTypeName);
        }

        private readonly struct ParamData : IEquatable<ParamData>
        {
            public readonly string typeName;
            public readonly ParameterDirection direction;

            public ParamData(string typeName, ParameterDirection direction)
            {
                this.typeName = typeName;
                this.direction = direction;
            }

            public readonly bool Equals(ParamData other) => typeName == other.typeName && direction == other.direction;

            public override bool Equals(object? obj) => obj is ParamData other && Equals(other);
            public override readonly int GetHashCode() => HashCode.Combine(typeName, direction);
        }

        private enum AccessType
        {
            Get,
            Set,
            GetAndSet
        }

        //
        // ++/--    pre/postfix increments            get/set
        // =        lhs of simple assignments         set
        // +=, -=   lhs of other assigments           get/set
        // x.y      rhs, of compound member access    recurr up
        //
        // any other use is just a get
        //
        // TOOD: ref parameters?
        //
        private AccessType GetAccessType(SyntaxNode node)
        {
            var kind = node.Parent.Kind();

            if (kind == SyntaxKind.PostIncrementExpression ||
                kind == SyntaxKind.PostDecrementExpression ||
                kind == SyntaxKind.PreIncrementExpression ||
                kind == SyntaxKind.PreDecrementExpression)
                return AccessType.GetAndSet;

            if (node.Parent is AssignmentExpressionSyntax syntax && syntax.Left == node)
                return kind == SyntaxKind.SimpleAssignmentExpression ? AccessType.Set : AccessType.GetAndSet;
            if (node.Parent is MemberAccessExpressionSyntax m && m.Name == node)
                return GetAccessType(node.Parent);

            return AccessType.Get;
        }
    }
}
