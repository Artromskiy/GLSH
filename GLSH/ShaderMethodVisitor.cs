using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GLSH.Compiler;

public partial class ShaderMethodVisitor : CSharpSyntaxVisitor<string>
{
    protected readonly Compilation _compilation;
    protected readonly string _setName;
    protected readonly LanguageBackend _backend;
    protected readonly ShaderFunction _shaderFunction;
    private readonly HashSet<ResourceDefinition> _resourcesUsed = [];
    private string? _containingTypeName;

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
        //var nodeBody = (SyntaxNode)node.Body ?? node.ExpressionBody;
        _containingTypeName = Utilities.GetFunctionContainingTypeName(node, GetModel(node));
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
            string? statementResult = Visit(ss);
            if (string.IsNullOrEmpty(statementResult))
                throw new NotImplementedException($"{ss.GetType()} statements are not implemented.");

            sb.Append(DeclareInlineOutVariables(ss));
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

        IEnumerable<IDiscardSymbol> discardedVariables = block
            .DescendantNodes()
            .Where(x => x.IsKind(SyntaxKind.IdentifierName))
            .Select(x => semanticModel.GetSymbolInfo(x).Symbol)
            .Where(x => x.Kind == SymbolKind.Discard)
            .OfType<IDiscardSymbol>();

        List<ISymbol> alreadyWrittenTypes = [];

        foreach (IDiscardSymbol discardedVariable in discardedVariables)
        {
            if (alreadyWrittenTypes.Contains(discardedVariable.Type))
                continue;

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

        var declarationExpressionNodes = statement.
            DescendantNodes(x => !x.IsKind(SyntaxKind.Block)). // Don't descend into child blocks
            Where(x => x.IsKind(SyntaxKind.DeclarationExpression)).
            OfType<DeclarationExpressionSyntax>();

        foreach (DeclarationExpressionSyntax declarationExpressionNode in declarationExpressionNodes)
        {
            if (declarationExpressionNode.Designation is not SingleVariableDesignationSyntax svds)
                throw new NotImplementedException($"{declarationExpressionNode.Designation.GetType()} designations are not implemented.");

            string varType = _compilation.GetSemanticModel(declarationExpressionNode.Type.SyntaxTree).GetFullTypeName(declarationExpressionNode.Type);
            string mappedType = _backend.CSharpToShaderType(varType);
            string identifier = _backend.CorrectIdentifier(svds.Identifier.Text);

            sb.AppendLine($"    {mappedType} {identifier};");
        }

        return sb.ToString();
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
    {
        string? expressionResult = Visit(node.Expression);
        if (string.IsNullOrEmpty(expressionResult))
            throw new NotImplementedException($"{node.Expression.GetType()} expressions are not implemented.");

        bool voidReturn = _shaderFunction.returnType.name == typeof(void).FullName!;
        string returnSymbol = voidReturn ? "return " : string.Empty;
        return
        $$"""
        {
            {{returnSymbol}}{{expressionResult}};
        }
        """;
    }

    protected virtual string GetFunctionDeclStr()
    {
        string returnType = _backend.CSharpToShaderType(_shaderFunction.returnType.name);
        string fullDeclType = _backend.CSharpToShaderType(_shaderFunction.declaringType);
        string shaderFunctionName = _shaderFunction.name.Replace(".", "0_");
        string funcName = _shaderFunction.IsEntryPoint ? shaderFunctionName : $"{fullDeclType}_{shaderFunctionName}";
        return $"{returnType} {funcName}({GetParameterDeclList()})";
    }

    [Obsolete("TODO: Can't return empty string here because of validation check in VisitBlock")]
    public override string VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node) =>
        node.Modifiers.Any(x => x.IsKind(SyntaxKind.ConstKeyword)) ? " " : Visit(node.Declaration)!;

    public override string VisitEqualsValueClause(EqualsValueClauseSyntax node) =>
        $"{node.EqualsToken.ToFullString()}{Visit(node.Value)}";

    public override string VisitAssignmentExpression(AssignmentExpressionSyntax node)
    {
        string token = node.OperatorToken.ToFullString().Trim();

        ShaderGenerationException.ThrowIf(token == "%=",
            "Modulus operator not supported in shader functions. Use ShaderBuiltins.Mod instead.");

        string? leftExpr = base.Visit(node.Left);
        string leftExprType = GetModel(node).GetFullTypeName(node.Left);
        string? rightExpr = base.Visit(node.Right);
        string rightExprType = GetModel(node).GetFullTypeName(node.Right);
        Asserts.NotNull(leftExpr, rightExpr);
        string assignedValue = _backend.CorrectAssignedValue(leftExprType, rightExpr, rightExprType);
        return $"{leftExpr} {token} {assignedValue}";
    }

    [Obsolete("Rewrite this hell")]
    public override string VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
    {
        SymbolInfo exprSymbol = GetModel(node).GetSymbolInfo(node.Expression);
        if (exprSymbol.Symbol.Kind != SymbolKind.NamedType)
        {
            // Other accesses
            bool isIndexerAccess = _backend.IsIndexerAccess(GetModel(node).GetSymbolInfo(node.Name));
            // string expr = Visit(node.Expression);
            // string name = Visit(node.Name);
            // Visit(node.Expression); // why the hell we even do it?
            // Visit(node.Name);

            if (!isIndexerAccess)
                return $"{Visit(node.Expression)}{node.OperatorToken.ToFullString()}{Visit(node.Name)}";
            else
                return $"{Visit(node.Expression)}{Visit(node.Name)}";
        }

        SymbolInfo symbolInfo = GetModel(node).GetSymbolInfo(node);
        ISymbol? symbol = symbolInfo.Symbol;
        ShaderGenerationException.ThrowIfNull(symbol, "Unable to get symbol");

        // Enum field
        INamedTypeSymbol namedTypeSymbol = (INamedTypeSymbol)exprSymbol.Symbol;
        if (namedTypeSymbol.TypeKind == TypeKind.Enum)
        {
            string? constantValueString = (symbol as IFieldSymbol)?.ConstantValue?.ToString();
            ShaderGenerationException.ThrowIfNull(constantValueString, "Unable to extract constant value from symbol");
            if (namedTypeSymbol.EnumUnderlyingType!.SpecialType == SpecialType.System_UInt32)
                constantValueString += "u";
            return constantValueString;
        }

        // Static member access
        if (symbol.Kind == SymbolKind.Property || symbol.Kind == SymbolKind.Field)
            return Visit(node.Name);

        string typeName = exprSymbol.Symbol.GetFullMetadataName();
        string? targetName = Visit(node.Name);
        Debug.Assert(targetName != null);
        return _backend.FormatInvocation(_setName, typeName, targetName, []);

    }

    public override string VisitExpressionStatement(ExpressionStatementSyntax node) =>
        $"{Visit(node.Expression)};";

    public override string VisitReturnStatement(ReturnStatementSyntax node) =>
        $"return {Visit(node.Expression)};";


    [Obsolete("Rewrite this hell")]
    public override string VisitInvocationExpression(InvocationExpressionSyntax node)
    {
        if (node.Expression is IdentifierNameSyntax ins)
        {
            InvocationParameterInfo[] parameterInfos = GetParameterInfos(node.ArgumentList);
            SymbolInfo symbolInfo = GetModel(node).GetSymbolInfo(ins);
            Debug.Assert(symbolInfo.Symbol != null);
            string type = symbolInfo.Symbol.ContainingType.ToDisplayString();
            string method = symbolInfo.Symbol.Name;
            if (type == typeof(ShaderBuiltins).FullName)
                ProcessBuiltInMethodInvocation(method, node);
            return _backend.FormatInvocation(_setName, type, method, parameterInfos);
        }

        if (node.Expression is not MemberAccessExpressionSyntax maes)
        {
            string message =
            $$"""
            Function calls must be made through an {{nameof(IdentifierNameSyntax)}} or a {{nameof(MemberAccessExpressionSyntax)}}.
            This node used a {{node.Expression.GetType().Name}}
            {{node.ToFullString()}}
            """;
            throw new NotImplementedException(message);
        }

        SymbolInfo methodSymbol = GetModel(maes).GetSymbolInfo(maes);

        if (methodSymbol.Symbol is not IMethodSymbol ims)
            throw new NotImplementedException();

        string containingType = ims.ContainingType.GetFullMetadataName();
        string methodName = ims.MetadataName;
        List<InvocationParameterInfo> pis = [];
        if (ims.IsExtensionMethod)
        {
            string? identifier = Visit(maes.Expression);
            string identifierType = GetModel(maes.Expression).GetFullTypeName(maes.Expression);
            Debug.Assert(identifier != null);
            pis.Add(new InvocationParameterInfo(identifier, identifierType));// Might need FullTypeName here too.
        }

        else if (!ims.IsStatic) // Add implicit "this" parameter.
        {
            string? identifier = null;
            if (maes.Expression is MemberAccessExpressionSyntax subExpression)
                identifier = Visit(subExpression);
            else if (maes.Expression is IdentifierNameSyntax identNameSyntax)
                identifier = Visit(identNameSyntax);

            Debug.Assert(identifier != null);
            pis.Add(new InvocationParameterInfo(containingType, identifier));
        }

        if (containingType == typeof(ShaderBuiltins).FullName)
            ProcessBuiltInMethodInvocation(methodName, node);

        pis.AddRange(GetParameterInfos(node.ArgumentList));
        return _backend.FormatInvocation(_setName, containingType, methodName, [.. pis]);
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

    public override string VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        string token = node.OperatorToken.ToFullString().Trim();

        ShaderGenerationException.ThrowIf(token == "%=",
            "Modulus operator not supported in shader functions. Use ShaderBuiltins.Mod instead.");

        string? leftExpr = Visit(node.Left);
        string leftExprType = GetModel(node).GetFullTypeName(node.Left);
        string operatorToken = node.OperatorToken.ToString();
        string? rightExpr = Visit(node.Right);
        string rightExprType = GetModel(node).GetFullTypeName(node.Right);
        Asserts.NotNull(leftExpr, rightExpr);

        return _backend.CorrectBinaryExpression(leftExpr, leftExprType, operatorToken, rightExpr, rightExprType);
    }

    public override string VisitParenthesizedExpression(ParenthesizedExpressionSyntax node) =>
        $"{node.OpenParenToken}{Visit(node.Expression)}{node.CloseParenToken}";

    public override string VisitArgumentList(ArgumentListSyntax node) =>
        string.Join(", ", node.Arguments.Select(Visit));

    public override string VisitArgument(ArgumentSyntax node)
    {
        string? result = Visit(node.Expression);
        if (string.IsNullOrEmpty(result))
            throw new NotImplementedException($"{node.Expression.GetType()} arguments are not implemented.");

        return result;
    }

    public override string VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
    {
        SymbolInfo symbolInfo = GetModel(node).GetSymbolInfo(node.Type);
        ShaderGenerationException.ThrowIfNull(symbolInfo.Symbol, "Unable to get symbol");
        string fullName = symbolInfo.Symbol.GetFullMetadataName();
        InvocationParameterInfo[] parameters = GetParameterInfos(node.ArgumentList);
        return _backend.FormatInvocation(_setName, fullName, ".ctor", parameters);
    }

    private string GetDiscardedVariableType(ISymbol symbol)
    {
        Debug.Assert(symbol.Kind == SymbolKind.Discard);
        string varType = Utilities.GetFullTypeName(((IDiscardSymbol)symbol).Type);
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
            return string.Format(CultureInfo.InvariantCulture, "{0}", fs.ConstantValue);

        else if (symbol.Kind == SymbolKind.Field && containingTypeName == _containingTypeName)
        {
            string symbolName = symbol.Name;
            ResourceDefinition? referencedResource = _backend.GetContext(_setName).Resources.SingleOrDefault(rd => rd.name == symbolName);
            if (referencedResource != null)
            {
                _resourcesUsed.Add(referencedResource);
                var resKind = referencedResource.resourceKind;
                _shaderFunction.UsesTexture2DMS |= resKind == ShaderResourceKind.Texture2DMS;
                _shaderFunction.UsesRWTexture2D |= resKind == ShaderResourceKind.RWTexture2D;

                _shaderFunction.UsesStructuredBuffer |=
                    resKind == ShaderResourceKind.StructuredBuffer ||
                    resKind == ShaderResourceKind.RWStructuredBuffer ||
                    resKind == ShaderResourceKind.AtomicBuffer;
            }

            return _backend.CorrectFieldAccess(symbolInfo);
        }
        else if (symbol.Kind == SymbolKind.Property)
            return _backend.FormatInvocation(_setName, containingTypeName, symbol.Name, []);
        else if (symbol is ILocalSymbol ls && ls.HasConstantValue)
            return string.Format(CultureInfo.InvariantCulture, "{0}", ls.ConstantValue);

        string mapped = _backend.CSharpToShaderIdentifierName(symbolInfo);
        return _backend.CorrectIdentifier(mapped);
    }

    private void TryRecognizeBuiltInVariable(SymbolInfo symbolInfo)
    {
        Debug.Assert(symbolInfo.Symbol != null);
        string name = symbolInfo.Symbol.Name;

        ShaderGenerationException.ThrowIf(GetTypeByFunctionName(name) != _shaderFunction.type,
            "{0} can only be used within {1}", name, _shaderFunction.type);

        _shaderFunction.UsesVertexID |= name == nameof(ShaderBuiltins.VertexID);
        _shaderFunction.UsesInstanceID |= name == nameof(ShaderBuiltins.InstanceID);
        _shaderFunction.UsesDispatchThreadID |= name == nameof(ShaderBuiltins.DispatchThreadID);
        _shaderFunction.UsesGroupThreadID |= name == nameof(ShaderBuiltins.GroupThreadID);
        _shaderFunction.UsesFrontFace |= name == nameof(ShaderBuiltins.IsFrontFace);
    }

    private static ShaderFunctionType GetTypeByFunctionName(string name) => name switch
    {
        nameof(ShaderBuiltins.VertexID) => ShaderFunctionType.VertexEntryPoint,
        nameof(ShaderBuiltins.InstanceID) => ShaderFunctionType.VertexEntryPoint,
        nameof(ShaderBuiltins.IsFrontFace) => ShaderFunctionType.FragmentEntryPoint,
        nameof(ShaderBuiltins.DispatchThreadID) => ShaderFunctionType.ComputeEntryPoint,
        nameof(ShaderBuiltins.GroupThreadID) => ShaderFunctionType.ComputeEntryPoint,
        _ => ShaderFunctionType.Normal
    };

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

    public override string VisitElseClause(ElseClauseSyntax node) =>
        $$"""
        else
        {{Visit(node.Statement)}}
        """;

    [Obsolete("Rewrite this hell")]
    public override string VisitForStatement(ForStatementSyntax node)
    {
        string? declaration = Visit(node.Declaration);
        string? condition = Visit(node.Condition);
        Asserts.NotNull(condition, declaration);
        string incrementers = string.Join(", ", node.Incrementors.Select(Visit));
        return
        $$"""
        for ({{declaration}} {{condition}}; {{incrementers}})
        {{Visit(node.Statement)}}
        """;
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

    public override string VisitCaseSwitchLabel(CaseSwitchLabelSyntax node) =>
        $"case {Visit(node.Value)}:";

    public override string VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node) =>
        "default:";

    public override string VisitBreakStatement(BreakStatementSyntax node) =>
        "break;";

    public override string VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node) =>
        node.OperatorToken.ToFullString() + Visit(node.Operand);

    public override string VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node) =>
        Visit(node.Operand) + node.OperatorToken.ToFullString();

    public override string VisitElementAccessExpression(ElementAccessExpressionSyntax node) =>
        Visit(node.Expression) + Visit(node.ArgumentList);


    public override string VisitVariableDeclaration(VariableDeclarationSyntax node)
    {
        if (node.Variables.Count != 1)
            throw new NotImplementedException();

        SemanticModel model = GetModel(node);
        string varType = model.GetFullTypeName(node.Type);
        TypeReference typeRef = new(varType, model.GetTypeInfo(node.Type).Type);
        string mappedType = _backend.CSharpToShaderType(typeRef);
        VariableDeclaratorSyntax varDeclarator = node.Variables[0];
        string identifier = _backend.CorrectIdentifier(varDeclarator.Identifier.ToString());

        if (varDeclarator.Initializer == null)
            return $"{mappedType} {identifier};";

        string? rightExpr = base.Visit(varDeclarator.Initializer.Value);
        string rightExprType = model.GetFullTypeName(varDeclarator.Initializer.Value);
        string assignedValue = _backend.CorrectAssignedValue(varType, rightExpr, rightExprType);
        string initializer = varDeclarator.Initializer.EqualsToken.ToString();

        return $"{mappedType} {identifier} {initializer} {assignedValue};";
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

    public override string? VisitDeclarationExpression(DeclarationExpressionSyntax node) =>
        Visit(node.Designation);

    public override string VisitSingleVariableDesignation(SingleVariableDesignationSyntax node) =>
        _backend.CorrectIdentifier(node.Identifier.Text);

    public override string VisitConditionalExpression(ConditionalExpressionSyntax node)
    {
        return Visit(node.Condition)
            + node.QuestionToken.ToFullString()
            + Visit(node.WhenTrue)
            + node.ColonToken.ToFullString()
            + Visit(node.WhenFalse);
    }

    public override string VisitDoStatement(DoStatementSyntax node)
    {
        return
        $$"""
        {{node.DoKeyword}}
        {
            {{Visit(node.Statement)}}
        } while({{Visit(node.Condition)}});
        """;
    }

    public override string VisitWhileStatement(WhileStatementSyntax node)
    {
        return
        $$"""
        while({{Visit(node.Condition)}})
        {{Visit(node.Statement)}}
        """;
    }

    protected string GetParameterDeclList() =>
        string.Join(", ", _shaderFunction.parameters.Select(FormatParameter));

    protected virtual string FormatParameter(ParameterDefinition pd) =>
        $"{_backend.ParameterDirection(pd.direction)} {_backend.CSharpToShaderType(pd.type)} {_backend.CorrectIdentifier(pd.name)}";

    private InvocationParameterInfo[] GetParameterInfos(ArgumentListSyntax? argumentList) =>
        argumentList?.Arguments.Select(GetInvocationParameterInfo).ToArray() ?? [];

    private InvocationParameterInfo GetInvocationParameterInfo(ArgumentSyntax argSyntax)
    {
        TypeInfo typeInfo = GetModel(argSyntax).GetTypeInfo(argSyntax.Expression);
        ShaderGenerationException.ThrowIfNull(typeInfo.Type, "Unable to get symbol");
        return new InvocationParameterInfo(typeInfo.Type.ToDisplayString(), Visit(argSyntax.Expression));
    }
}