using GLSH.Primitives;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GLSH;

public partial class ShaderMethodVisitor : CSharpSyntaxVisitor<string>
{
    protected readonly Compilation _compilation;
    protected readonly string _setName;
    protected readonly LanguageBackend _backend;
    protected readonly ShaderFunction _shaderFunction;
    private readonly string? _containingTypeName;
    private readonly HashSet<ResourceDefinition> _resourcesUsed = [];

    public ShaderMethodVisitor(
        Compilation compilation,
        string setName,
        ShaderFunction shaderFunction,
        LanguageBackend backend)
    {
        _compilation = compilation;
        _setName = setName;
        _shaderFunction = shaderFunction;
        _backend = backend;
    }

    private SemanticModel GetModel(SyntaxNode node) => _compilation.GetSemanticModel(node.SyntaxTree);


    [Obsolete("Rewrite this hell")]
    public MethodProcessResult VisitFunction(BaseMethodDeclarationSyntax node)
    {
        StringBuilder sb = new();
        string blockResult;
        // Visit block first in order to discover builtin variables.
        if (node.Body != null)
            blockResult = VisitBlock(node.Body);
        else if (node.ExpressionBody != null)
            blockResult = VisitArrowExpressionClause(node.ExpressionBody);
        else
            throw new NotSupportedException("Methods without bodies cannot be shader functions.");

        string functionDeclStr = GetFunctionDeclStr();

        if (_shaderFunction.type == ShaderFunctionType.ComputeEntryPoint)
            sb.AppendLine(_backend.GetComputeGroupCountsDeclaration(_shaderFunction.computeGroupCounts));

        sb.AppendLine(functionDeclStr);
        sb.AppendLine(blockResult);
        return new MethodProcessResult(sb.ToString(), _resourcesUsed);
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitBlock(BlockSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine("{");

        // Only declare discarded variables - i.e. MyFunc(out _) - for the top-level block in a function.
        if (node.Parent.IsKind(SyntaxKind.MethodDeclaration))
            sb.Append(DeclareDiscardedVariables(node));

        foreach (StatementSyntax ss in node.Statements)
        {
            sb.Append(DeclareInlineOutVariables(ss));

            string? statementResult = Visit(ss);
            if (string.IsNullOrEmpty(statementResult))
                throw new NotImplementedException($"{ss.GetType()} statements are not implemented.");
            else
                sb.AppendLine("    " + statementResult);
        }

        sb.AppendLine("}");
        return sb.ToString();
    }

    /// <summary>
    /// Declares any "discard"ed variables - i.e. MyFunc(out _) - for this block and all nested blocks.
    /// </summary>
    [Obsolete("Rewrite this hell")]
    private string DeclareDiscardedVariables(BlockSyntax block)
    {
        StringBuilder sb = new();

        SemanticModel semanticModel = GetModel(block);

        IEnumerable<ISymbol> discardedVariables = block
            .DescendantNodes()
            .Where(x => x.IsKind(SyntaxKind.IdentifierName))
            .Select(x => semanticModel.GetSymbolInfo(x).Symbol)
            .Where(x => x.Kind == SymbolKind.Discard)
            .Cast<IDiscardSymbol>();

        List<ISymbol> alreadyWrittenTypes = [];

        foreach (IDiscardSymbol discardedVariable in discardedVariables)
        {
            if (alreadyWrittenTypes.Contains(discardedVariable.Type))
            {
                continue;
            }

            sb.Append("    ");
            sb.Append(GetDiscardedVariableType(discardedVariable));
            sb.Append(' ');
            sb.Append(GetDiscardedVariableName(discardedVariable));
            sb.AppendLine(";");

            alreadyWrittenTypes.Add(discardedVariable.Type);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Check for any inline "out" variable declarations in this statement - i.e. MyFunc(out var result) - 
    /// and declare those variables now.
    /// </summary>
    [Obsolete("Rewrite this hell")]
    private string DeclareInlineOutVariables(StatementSyntax statement)
    {
        StringBuilder sb = new();

        IEnumerable<SyntaxNode> declarationExpressionNodes = statement
            .DescendantNodes(x => !x.IsKind(SyntaxKind.Block)) // Don't descend into child blocks
            .Where(x => x.IsKind(SyntaxKind.DeclarationExpression));

        foreach (DeclarationExpressionSyntax declarationExpressionNode in declarationExpressionNodes)
        {
            string varType = _compilation.GetSemanticModel(declarationExpressionNode.Type.SyntaxTree).GetFullTypeName(declarationExpressionNode.Type);
            string mappedType = _backend.CSharpToShaderType(varType);

            sb.Append("    ");
            sb.Append(mappedType);
            sb.Append(' ');

            switch (declarationExpressionNode.Designation)
            {
                case SingleVariableDesignationSyntax svds:
                    string identifier = _backend.CorrectIdentifier(svds.Identifier.Text);
                    sb.Append(identifier);
                    sb.Append(';');
                    sb.AppendLine();
                    break;

                default:
                    throw new NotImplementedException($"{declarationExpressionNode.Designation.GetType()} designations are not implemented.");
            }
        }

        return sb.ToString();
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine("{");

        string? expressionResult = Visit(node.Expression);

        if (string.IsNullOrEmpty(expressionResult))
            throw new NotImplementedException($"{node.Expression.GetType()} expressions are not implemented.");

        if (_shaderFunction.returnType.name == typeof(void).FullName!)
        {
            sb.AppendLine($"    {expressionResult};");
        }
        else
        {
            sb.AppendLine($"    return {expressionResult};");
        }

        sb.AppendLine("}");
        return sb.ToString();
    }

    [Obsolete("Rewrite this hell")]
    protected virtual string GetFunctionDeclStr()
    {
        string returnType = _backend.CSharpToShaderType(_shaderFunction.returnType.name);
        string fullDeclType = _backend.CSharpToShaderType(_shaderFunction.declaringType);
        string shaderFunctionName = _shaderFunction.name.Replace(".", "0_");
        string funcName = _shaderFunction.IsEntryPoint
            ? shaderFunctionName
            : fullDeclType + "_" + shaderFunctionName;
        return $"{returnType} {funcName}({GetParameterDeclList()})";
    }

    public override string VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
    {
        if (node.Modifiers.Any(x => x.IsKind(SyntaxKind.ConstKeyword)))
        {
            return " "; // TODO: Can't return empty string here because of validation check in VisitBlock
        }
        return Visit(node.Declaration);
    }

    public override string VisitEqualsValueClause(EqualsValueClauseSyntax node)
    {
        return node.EqualsToken.ToFullString() + Visit(node.Value);
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitAssignmentExpression(AssignmentExpressionSyntax node)
    {
        string token = node.OperatorToken.ToFullString().Trim();
        if (token == "%=")
        {
            throw new ShaderGenerationException(
                "Modulus operator not supported in shader functions. Use ShaderBuiltins.Mod instead.");
        }

        string leftExpr = base.Visit(node.Left);
        string leftExprType = GetModel(node).GetFullTypeName(node.Left);
        string rightExpr = base.Visit(node.Right);
        string rightExprType = GetModel(node).GetFullTypeName(node.Right);

        string assignedValue = _backend.CorrectAssignedValue(leftExprType, rightExpr, rightExprType);
        return $"{leftExpr} {token} {assignedValue}";
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
    {
        SymbolInfo exprSymbol = GetModel(node).GetSymbolInfo(node.Expression);
        if (exprSymbol.Symbol.Kind == SymbolKind.NamedType)
        {
            SymbolInfo symbolInfo = GetModel(node).GetSymbolInfo(node);
            ISymbol? symbol = symbolInfo.Symbol;

            // Enum field
            INamedTypeSymbol namedTypeSymbol = (INamedTypeSymbol)exprSymbol.Symbol;
            if (namedTypeSymbol.TypeKind == TypeKind.Enum)
            {
                IFieldSymbol enumFieldSymbol = (IFieldSymbol)symbol;
                string constantValueString = enumFieldSymbol.ConstantValue.ToString();
                if (namedTypeSymbol.EnumUnderlyingType.SpecialType == SpecialType.System_UInt32)
                {
                    // TODO: We need to do this for literal values too, if they don't already have this suffix, 
                    // so this should be refactored.
                    constantValueString += "u";
                }
                return constantValueString;
            }

            // Static member access
            if (symbol.Kind == SymbolKind.Property || symbol.Kind == SymbolKind.Field)
                return Visit(node.Name);

            string typeName = exprSymbol.Symbol.GetFullMetadataName();
            string targetName = Visit(node.Name);
            return _backend.FormatInvocation(_setName, typeName, targetName, Array.Empty<InvocationParameterInfo>());
        }

        // Other accesses
        bool isIndexerAccess = _backend.IsIndexerAccess(GetModel(node).GetSymbolInfo(node.Name));
        // string expr = Visit(node.Expression);
        // string name = Visit(node.Name);
        Visit(node.Expression);
        Visit(node.Name);

        if (!isIndexerAccess)
            return Visit(node.Expression) + node.OperatorToken.ToFullString() + Visit(node.Name);
        else
            return Visit(node.Expression) + Visit(node.Name);
    }

    public override string VisitExpressionStatement(ExpressionStatementSyntax node)
    {
        return $"{Visit(node.Expression)};";
    }

    public override string VisitReturnStatement(ReturnStatementSyntax node)
    {
        return $"return {Visit(node.Expression)};";
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitInvocationExpression(InvocationExpressionSyntax node)
    {
        if (node.Expression is IdentifierNameSyntax ins)
        {
            InvocationParameterInfo[] parameterInfos = GetParameterInfos(node.ArgumentList);
            SymbolInfo symbolInfo = GetModel(node).GetSymbolInfo(ins);
            string type = symbolInfo.Symbol.ContainingType.ToDisplayString();
            string method = symbolInfo.Symbol.Name;

            if (type == typeof(ShaderBuiltins).FullName)
                ProcessBuiltInMethodInvocation(method, node);


            return _backend.FormatInvocation(_setName, type, method, parameterInfos);
        }
        else if (node.Expression is MemberAccessExpressionSyntax maes)
        {
            SymbolInfo methodSymbol = GetModel(maes).GetSymbolInfo(maes);
            if (methodSymbol.Symbol is IMethodSymbol ims)
            {
                string containingType = ims.ContainingType.GetFullMetadataName();
                string methodName = ims.MetadataName;
                List<InvocationParameterInfo> pis = [];
                if (ims.IsExtensionMethod)
                {
                    string identifier = Visit(maes.Expression);
                    string identifierType = GetModel(maes.Expression).GetFullTypeName(maes.Expression);
                    Debug.Assert(identifier != null);
                    // Might need FullTypeName here too.
                    pis.Add(new InvocationParameterInfo(identifier, identifierType));
                }

                else if (!ims.IsStatic) // Add implicit "this" parameter.
                {
                    string identifier = null;
                    if (maes.Expression is MemberAccessExpressionSyntax subExpression)
                    {
                        identifier = Visit(subExpression);
                    }
                    else if (maes.Expression is IdentifierNameSyntax identNameSyntax)
                    {
                        identifier = Visit(identNameSyntax);
                    }

                    Debug.Assert(identifier != null);
                    pis.Add(new InvocationParameterInfo(containingType, identifier));
                }

                if (containingType == typeof(ShaderBuiltins).FullName)
                {
                    ProcessBuiltInMethodInvocation(methodName, node);
                }

                pis.AddRange(GetParameterInfos(node.ArgumentList));
                return _backend.FormatInvocation(_setName, containingType, methodName, [.. pis]);
            }

            throw new NotImplementedException();
        }

        string message = "Function calls must be made through an IdentifierNameSyntax or a MemberAccessExpressionSyntax.";
        message += Environment.NewLine + "This node used a " + node.Expression.GetType().Name;
        message += Environment.NewLine + node.ToFullString();
        throw new NotImplementedException(message);
    }

    private void ProcessBuiltInMethodInvocation(string name, InvocationExpressionSyntax node)
    {
        switch (name)
        {
            case nameof(ShaderBuiltins.Ddx):
            case nameof(ShaderBuiltins.Ddy):
            case nameof(ShaderBuiltins.SampleComparisonLevelZero):
                if (_shaderFunction.type == ShaderFunctionType.VertexEntryPoint || _shaderFunction.type == ShaderFunctionType.ComputeEntryPoint)
                    throw new ShaderGenerationException($"{name} can only be used within Fragment shaders.");
                break;

            case nameof(ShaderBuiltins.InterlockedAdd):
                _shaderFunction.UsesInterlockedAdd = true;
                break;
        }
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        string token = node.OperatorToken.ToFullString().Trim();
        if (token == "%")
        {
            throw new ShaderGenerationException(
                "Modulus operator not supported in shader functions. Use ShaderBuiltins.Mod instead.");
        }

        string leftExpr = Visit(node.Left);
        string leftExprType = GetModel(node).GetFullTypeName(node.Left);
        string operatorToken = node.OperatorToken.ToString();
        string rightExpr = Visit(node.Right);
        string rightExprType = GetModel(node).GetFullTypeName(node.Right);

        return _backend.CorrectBinaryExpression(leftExpr, leftExprType, operatorToken, rightExpr, rightExprType);
    }

    public override string VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
    {
        return node.OpenParenToken + Visit(node.Expression) + node.CloseParenToken;
    }

    public override string VisitArgumentList(ArgumentListSyntax node)
    {
        return string.Join(", ", node.Arguments.Select(Visit));
    }

    public override string VisitArgument(ArgumentSyntax node)
    {
        string result = Visit(node.Expression);
        if (string.IsNullOrEmpty(result))
            throw new NotImplementedException($"{node.Expression.GetType()} arguments are not implemented.");

        return result;
    }

    public override string VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
    {
        SymbolInfo symbolInfo = GetModel(node).GetSymbolInfo(node.Type);
        string fullName = symbolInfo.Symbol.GetFullMetadataName();
        InvocationParameterInfo[] parameters = GetParameterInfos(node.ArgumentList);
        return _backend.FormatInvocation(_setName, fullName, ".ctor", parameters);
    }

    private string GetDiscardedVariableType(ISymbol symbol)
    {
        Debug.Assert(symbol.Kind == SymbolKind.Discard);
        string varType = Utilities.GetFullTypeName(((IDiscardSymbol)symbol).Type, out _);
        return _backend.CSharpToShaderType(varType);
    }

    private string GetDiscardedVariableName(ISymbol symbol)
    {
        string mappedType = GetDiscardedVariableType(symbol);
        return _backend.CorrectIdentifier($"_shadergen_discard_{mappedType}");
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitIdentifierName(IdentifierNameSyntax node)
    {
        SymbolInfo symbolInfo = GetModel(node).GetSymbolInfo(node);
        ISymbol symbol = symbolInfo.Symbol;
        if (symbol.Kind == SymbolKind.Discard)
            return GetDiscardedVariableName(symbol);

        string containingTypeName = symbol.ContainingType.GetFullMetadataName();
        if (containingTypeName == typeof(ShaderBuiltins).FullName)
            TryRecognizeBuiltInVariable(symbolInfo);

        if (symbol is IFieldSymbol fs && fs.HasConstantValue)
            // TODO: Share code to format constant values.
            return string.Format(CultureInfo.InvariantCulture, "{0}", fs.ConstantValue);

        else if (symbol.Kind == SymbolKind.Field && containingTypeName == _containingTypeName)
        {
            string symbolName = symbol.Name;
            ResourceDefinition? referencedResource = _backend.GetContext(_setName).Resources.SingleOrDefault(rd => rd.name == symbolName);
            if (referencedResource != null)
            {
                _resourcesUsed.Add(referencedResource);
                _shaderFunction.UsesTexture2DMS |= referencedResource.resourceKind == ShaderResourceKind.Texture2DMS;
                bool usesStructuredBuffer = referencedResource.resourceKind == ShaderResourceKind.StructuredBuffer
                    || referencedResource.resourceKind == ShaderResourceKind.RWStructuredBuffer
                    || referencedResource.resourceKind == ShaderResourceKind.AtomicBuffer;
                _shaderFunction.UsesStructuredBuffer |= usesStructuredBuffer;
                _shaderFunction.UsesRWTexture2D |= referencedResource.resourceKind == ShaderResourceKind.RWTexture2D;
            }

            return _backend.CorrectFieldAccess(symbolInfo);
        }
        else if (symbol.Kind == SymbolKind.Property)
        {
            return _backend.FormatInvocation(_setName, containingTypeName, symbol.Name, Array.Empty<InvocationParameterInfo>());
        }
        else if (symbol is ILocalSymbol ls && ls.HasConstantValue)
        {
            // TODO: Share code to format constant values.
            return string.Format(CultureInfo.InvariantCulture, "{0}", ls.ConstantValue);
        }

        string mapped = _backend.CSharpToShaderIdentifierName(symbolInfo);
        return _backend.CorrectIdentifier(mapped);
    }

    [Obsolete("Rewrite this hell")]
    private void TryRecognizeBuiltInVariable(SymbolInfo symbolInfo)
    {
        string name = symbolInfo.Symbol.Name;
        if (name == nameof(ShaderBuiltins.VertexID))
        {
            if (_shaderFunction.type != ShaderFunctionType.VertexEntryPoint)
                throw new ShaderGenerationException("VertexID can only be used within Vertex shaders.");

            _shaderFunction.UsesVertexID = true;
        }
        else if (name == nameof(ShaderBuiltins.InstanceID))
        {
            _shaderFunction.UsesInstanceID = true;
        }
        else if (name == nameof(ShaderBuiltins.DispatchThreadID))
        {
            if (_shaderFunction.type != ShaderFunctionType.ComputeEntryPoint)
                throw new ShaderGenerationException("DispatchThreadID can only be used within Vertex shaders.");

            _shaderFunction.UsesDispatchThreadID = true;
        }
        else if (name == nameof(ShaderBuiltins.GroupThreadID))
        {
            if (_shaderFunction.type != ShaderFunctionType.ComputeEntryPoint)
                throw new ShaderGenerationException("GroupThreadID can only be used within Vertex shaders.");

            _shaderFunction.UsesGroupThreadID = true;
        }
        else if (name == nameof(ShaderBuiltins.IsFrontFace))
        {
            if (_shaderFunction.type != ShaderFunctionType.FragmentEntryPoint)
                throw new ShaderGenerationException("IsFrontFace can only be used within Fragment shaders.");

            _shaderFunction.UsesFrontFace = true;
        }
    }

    public override string VisitLiteralExpression(LiteralExpressionSyntax node)
    {
        string literal = node.ToFullString().Trim();
        return LanguageBackend.CorrectLiteral(literal);
    }

    public override string VisitIfStatement(IfStatementSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine("if (" + Visit(node.Condition) + ")");
        sb.AppendLine(Visit(node.Statement));
        sb.AppendLine(Visit(node.Else));
        return sb.ToString();
    }

    public override string VisitElseClause(ElseClauseSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine("else");
        sb.AppendLine(Visit(node.Statement));
        return sb.ToString();
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitForStatement(ForStatementSyntax node)
    {
        StringBuilder sb = new();
        string declaration = Visit(node.Declaration);
        string incrementers = string.Join(", ", node.Incrementors.Select(es => Visit(es)));
        string condition = Visit(node.Condition);
        sb.AppendLine($"for ({declaration} {condition}; {incrementers})");
        sb.AppendLine(Visit(node.Statement));
        return sb.ToString();
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitSwitchStatement(SwitchStatementSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine($"switch ({Visit(node.Expression)})");
        sb.AppendLine("{");
        foreach (SwitchSectionSyntax section in node.Sections)
        {
            foreach (SwitchLabelSyntax label in section.Labels)
                sb.AppendLine(Visit(label));

            foreach (StatementSyntax statement in section.Statements)
                sb.AppendLine(Visit(statement));
        }
        sb.AppendLine("}");
        return sb.ToString();
    }
    [Obsolete("Rewrite this hell")]
    public override string VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
    {
        StringBuilder sb = new();
        sb.AppendLine($"case {Visit(node.Value)}:");
        return sb.ToString();
    }

    public override string VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
    {
        return "default:";
    }

    public override string VisitBreakStatement(BreakStatementSyntax node)
    {
        return "break;";
    }

    public override string VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
    {
        return node.OperatorToken.ToFullString() + Visit(node.Operand);
    }

    public override string VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
    {
        return Visit(node.Operand) + node.OperatorToken.ToFullString();
    }

    public override string VisitElementAccessExpression(ElementAccessExpressionSyntax node)
    {
        return Visit(node.Expression) + Visit(node.ArgumentList);
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitVariableDeclaration(VariableDeclarationSyntax node)
    {
        if (node.Variables.Count != 1)
            throw new NotImplementedException();

        StringBuilder sb = new();

        SemanticModel semanticModel = GetModel(node);
        string varType = semanticModel.GetFullTypeName(node.Type);
        TypeReference typeRef = new(varType, semanticModel.GetTypeInfo(node.Type).Type);
        string mappedType = _backend.CSharpToShaderType(typeRef);

        sb.Append(mappedType);
        sb.Append(' ');
        VariableDeclaratorSyntax varDeclarator = node.Variables[0];
        string identifier = _backend.CorrectIdentifier(varDeclarator.Identifier.ToString());
        sb.Append(identifier);

        if (varDeclarator.Initializer != null)
        {
            sb.Append(' ');
            sb.Append(varDeclarator.Initializer.EqualsToken.ToString());
            sb.Append(' ');

            string? rightExpr = base.Visit(varDeclarator.Initializer.Value);
            string rightExprType = GetModel(node).GetFullTypeName(varDeclarator.Initializer.Value);

            sb.Append(_backend.CorrectAssignedValue(varType, rightExpr, rightExprType));
        }

        sb.Append(';');

        return sb.ToString();
    }


    public override string VisitBracketedArgumentList(BracketedArgumentListSyntax node)
    {
        return node.OpenBracketToken.ToFullString()
            + string.Join(", ", node.Arguments.Select(Visit))
            + node.CloseBracketToken.ToFullString();
    }

    public override string VisitCastExpression(CastExpressionSyntax node)
    {
        string varType = _compilation.GetSemanticModel(node.Type.SyntaxTree).GetFullTypeName(node.Type);
        string mappedType = _backend.CSharpToShaderType(varType);

        return _backend.CorrectCastExpression(mappedType, Visit(node.Expression));
    }

    public override string? VisitDeclarationExpression(DeclarationExpressionSyntax node)
    {
        return Visit(node.Designation);
    }

    public override string VisitSingleVariableDesignation(SingleVariableDesignationSyntax node)
    {
        return _backend.CorrectIdentifier(node.Identifier.Text);
    }

    public override string VisitConditionalExpression(ConditionalExpressionSyntax node)
    {
        return Visit(node.Condition)
            + node.QuestionToken.ToFullString()
            + Visit(node.WhenTrue)
            + node.ColonToken.ToFullString()
            + Visit(node.WhenFalse);
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitDoStatement(DoStatementSyntax node)
    {
        StringBuilder sb = new();
        sb.Append(node.DoKeyword);
        sb.Append(" {");
        sb.AppendLine();
        sb.Append(Visit(node.Statement));
        sb.AppendLine();
        sb.Append(" } while (");
        sb.Append(Visit(node.Condition));
        sb.Append(");");
        return sb.ToString();

    }

    [Obsolete("Rewrite this hell")]
    public override string VisitWhileStatement(WhileStatementSyntax node)
    {
        StringBuilder sb = new();
        sb.Append("while (");
        sb.Append(Visit(node.Condition));
        sb.AppendLine(")");
        sb.Append(Visit(node.Statement));
        return sb.ToString();
    }

    protected string GetParameterDeclList()
    {
        return string.Join(", ", _shaderFunction.parameters.Select(FormatParameter));
    }

    protected virtual string FormatParameter(ParameterDefinition pd)
    {
        return $"{_backend.ParameterDirection(pd.direction)} {_backend.CSharpToShaderType(pd.type)} {_backend.CorrectIdentifier(pd.name)}";
    }

    private InvocationParameterInfo[] GetParameterInfos(ArgumentListSyntax argumentList)
    {
        return argumentList.Arguments.Select(GetInvocationParameterInfo).ToArray();
    }

    private InvocationParameterInfo GetInvocationParameterInfo(ArgumentSyntax argSyntax)
    {
        TypeInfo typeInfo = GetModel(argSyntax).GetTypeInfo(argSyntax.Expression);
        return new InvocationParameterInfo(typeInfo.Type.ToDisplayString(), Visit(argSyntax.Expression));
    }
}
