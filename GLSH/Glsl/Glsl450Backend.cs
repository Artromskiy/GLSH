using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GLSH.Compiler.Glsl;

public class Glsl450Backend : LanguageBackend
{
    private readonly StructWriter _structWriter;
    private readonly DefaultWriter _defaultWriter;
    private readonly MethodWriter _methodWriter;

    public Glsl450Backend(Compilation compilation) : base(compilation)
    {
        _structWriter = new StructWriter(this);
        _defaultWriter = new DefaultWriter(this);
        _methodWriter = new MethodWriter(compilation, this);
    }

    protected sealed override string GenerateFullTextCore(MethodDeclarationData entryFunction)
    {
        StringBuilder sb = new();
        sb.AppendLine("// Structs");
        var structsInfo = _structsInfo[entryFunction];
        foreach (var structure in structsInfo)
            sb.AppendLine(WriteStructure(structure));

        sb.AppendLine("// Defaults");
        foreach (var structure in structsInfo)
            sb.AppendLine(WriteDefault(structure));

        sb.AppendLine("// Methods");
        foreach (var method in _methodsInfo[entryFunction])
            sb.AppendLine(WriteMethod(method));

        sb.AppendLine("// Main");
        sb.AppendLine(WriteMethod(entryFunction));

        StringBuilder versionSB = new();
        WriteVersionHeader(versionSB);

        sb.Insert(0, versionSB.ToString());
        var res = sb.ToString();
        return res;
    }

    private string WriteStructure(StructDeclarationData structDecl)
    {
        if (!_structsCache.TryGetValue(structDecl, out var structDeclString))
            _structsCache[structDecl] = structDeclString = _structWriter.WriteStructure(structDecl);
        return structDeclString;
    }

    private string WriteMethod(MethodDeclarationData methodDecl)
    {
        if (!_methodsCache.TryGetValue(methodDecl, out var methodDeclString))
            _methodsCache[methodDecl] = methodDeclString = _methodWriter.WriteMethod(methodDecl);
        return methodDeclString;
    }

    private string WriteDefault(StructDeclarationData structDeclaration)
    {
        string type = structDeclaration.name;
        var methodDecl = new MethodDeclarationData(type, GLSHConstants.Default, type, []);
        if (!_methodsCache.TryGetValue(methodDecl, out var methodDeclString))
            _methodsCache[methodDecl] = methodDeclString = _defaultWriter.WriteDefault(structDeclaration);
        return methodDeclString;
    }

    protected override string CSharpToIdentifierNameCore(string typeName, string identifier)
    {
        if (GLSHInfo.knownTypes.Contains(typeName))
            return identifier;

        return identifier;
    }

    internal override string CorrectIdentifier(string identifier)
    {
        return identifier;
    }

    internal override string CorrectCastExpression(string type, string expression)
    {
        return $"{type}({expression})";
    }


    private static void WriteVersionHeader(StringBuilder sb)
    {
        sb.AppendLine(
        """
        #version 450

        #extension GL_ARB_separate_shader_objects : enable
        #extension GL_ARB_shading_language_420pack : enable

        """);
    }

    internal override string GetComputeGroupCountsDeclaration(uint3 groupCounts)
    {
        return " ";
    }

    public override string CSharpToShaderType(string fullType)
    {
        if (GLSHInfo.knownTypesToGlslTypes.TryGetValue(fullType, out string? mapped) ||
            BuiltinTypes.knownTypesToGlslTypes.TryGetValue(fullType, out mapped))
            return mapped;
        return fullType.Replace('.', '_').Replace('+', '_');
    }

    public override string FormatInvocation(string type, string method, InvocationArgument[] arguments)
    {
        Debug.Assert(type != null);
        Debug.Assert(method != null);
        Debug.Assert(arguments != null);
        var formattedArguments = FormatArguments(arguments);

        // simple known functions
        if (GLSHInfo.knownFunctionsGlobal.TryGetValue(type, out var methodTable) &&
            methodTable.TryGetValue(method, out string? value))
            return $"{value}({formattedArguments})";

        // default ctors can be created with one zero argument
        if ((method == GLSHConstants.Ctor || method == GLSHConstants.Default) &&
            GLSHInfo.knownTypesToGlslTypes.TryGetValue(type, out value) && arguments.Length == 0)
            return $"{value}(0)";

        // other builtin ctors always match glsl's, so just translate type and parse arguments
        if (method == GLSHConstants.Ctor && GLSHInfo.knownTypesToGlslTypes.TryGetValue(type, out value))
            return $"{value}({formattedArguments})";

        // in fact it's same as extracting constant expression
        if (method == GLSHConstants.Default && BuiltinTypes.knownTypesToDefault.TryGetValue(type, out var defaultValue))
            return defaultValue;

        var fullName = ($"{type}_{method}").Replace('.', '_').Replace('+', '_');
        return $"{fullName}({formattedArguments})";
    }

    public override string FormatBinaryExpression(string type, string method, string leftExpr, string rightExpr)
    {
        if (GLSHInfo.knownOperatorsGlobal.TryGetValue(type, out var operatorTable) &&
            operatorTable.TryGetValue(method, out string? operatorToken))
            return $"{leftExpr} {operatorToken} {rightExpr}";

        var fullName = ($"{type}_{method}").Replace('.', '_').Replace('+', '_');
        return $"{fullName}({leftExpr}, {rightExpr})";
    }

    public override string FormatDeclaration(string returnType, string type, string method, InvocationParameter[] parameters)
    {
        Debug.Assert(type != null);
        Debug.Assert(method != null);
        Debug.Assert(parameters != null);

        var formattedParameters = FormatParameters(parameters);
        var returnTypeFormatted = CSharpToShaderType(returnType);
        var fullName = ($"{type}_{method}").Replace('.', '_').Replace('+', '_');
        return $"{returnTypeFormatted} {fullName}({formattedParameters})";
    }

    public static string FormatArguments(InvocationArgument[] argumentInfos) =>
        string.Join(", ", argumentInfos.Select(pi => pi.argument));

    public string FormatParameters(InvocationParameter[] parameterInfos) =>
        string.Join(", ", parameterInfos.Select(param =>
        {
            var direction = FormatDirection(param.direction);
            var type = CSharpToShaderType(param.type);
            if (string.IsNullOrEmpty(direction))
                return $"{type} {param.identifier}";
            return $"{direction} {type} {param.identifier}";
        }));


    public override string FormatDirection(ParameterDirection direction) => direction switch
    {
        ParameterDirection.In => "",
        ParameterDirection.Out => "out",
        ParameterDirection.InOut => "inout",
        _ => throw new System.NotImplementedException(),
    };
}