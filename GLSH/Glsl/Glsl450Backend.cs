using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace GLSH.Compiler.Glsl;

public class Glsl450Backend : LanguageBackend
{
    protected const string fragIn = "fsin_";
    private const string inIdf = "input";
    private const string outIdf = "output";

    public Glsl450Backend(Compilation compilation) : base(compilation) { }

    protected sealed override string GenerateFullTextCore(MethodDeclarationData entryFunction)
    {
        StringBuilder sb = new();

        foreach (var structure in _structsCache[entryFunction])
            WriteStructure(sb, structure);

        foreach (var method in _methodsCache[entryFunction])
            WriteMethod(sb, method);


        // Write header last
        // Write structure declarations
        // Write resource declarations
        // Write method declarations

        //WriteMainFunction(setName, sb, entryPoint.function);

        StringBuilder versionSB = new();
        WriteVersionHeader(versionSB);

        sb.Insert(0, versionSB.ToString());

        return sb.ToString();
    }

    private void WriteStructure(StringBuilder sb, StructDeclarationData structDecl)
    {
        StringBuilder fb = new();
        foreach (var field in structDecl.fields)
            fb.AppendLine($"    {CSharpToShaderTypeCore(field.typeName)} {CorrectIdentifier(field.fieldName)};");

        sb.AppendLine(
        $$"""
        struct {{CSharpToShaderTypeCore(structDecl.name)}}
        {
        {{fb}}};
        """
        );
    }

    private void WriteMethod(StringBuilder sb, MethodDeclarationData methodDecl)
    {
        var fw = new MethodWriter(_compilation, this);
        var syntax = Utilities.GetMethodSyntax(methodDecl, _compilation);
        var method = fw.Visit(syntax);
        sb.Append(method);
    }


    private void WriteInputDeclarations(StringBuilder sb, ref string? fragCoordName, StructureDefinition inputType, ShaderFunction entryFunction)
    {
        // Declare "in" variables
        int inVarIndex = 0;
        fragCoordName = null;
        foreach (FieldDefinition field in inputType.fields)
        {
            WriteInOutVariable(sb, true, entryFunction.type == ShaderFunctionType.VertexEntryPoint,
                CSharpToShaderTypeCore(field.type.name), CorrectIdentifier(field.name), inVarIndex);
            inVarIndex += 1;
        }
    }

    private void WriteOutOfVertexDeclarations(StringBuilder sb, StructureDefinition outputType)
    {
        int outVarIndex = 0;
        foreach (FieldDefinition field in outputType.fields)
        {
            WriteInOutVariable(sb, false, true,
                CSharpToShaderTypeCore(field.type.name),
                "out_" + CorrectIdentifier(field.name),
                outVarIndex);
            outVarIndex += 1;
        }
    }

    protected override string CSharpToIdentifierNameCore(string typeName, string identifier)
    {
        return GlslKnownIdentifiers.GetMappedIdentifier(typeName, identifier);
    }

    internal override string CorrectIdentifier(string identifier)
    {
        return identifier;
    }

    internal override string CorrectCastExpression(string type, string expression)
    {
        return $"{type}({expression})";
    }


    protected override string CSharpToShaderTypeCore(string fullType)
    {
        return GlslKnownTypes.GetMappedName(fullType).Replace('.', '_').Replace('+', '_');
    }

    protected void WriteVersionHeader(StringBuilder sb)
    {
        sb.AppendLine(
        """
        #version 450
        #extension GL_ARB_separate_shader_objects : enable
        #extension GL_ARB_shading_language_420pack : enable
        """);
    }


    protected void WriteUniform(StringBuilder sb, ResourceDefinition rd)
    {
        string layout = FormatLayoutStr(rd);

        sb.AppendLine(
        $$"""
        {{layout}} uniform {{rd.name}}
        {
            {{CSharpToShaderTypeCore(rd.valueType.name)}} field_{{CorrectIdentifier(rd.name.Trim())}};
        };

        """);
    }


    protected void WriteInOutVariable(StringBuilder sb, bool isInVar, bool isVertexStage, string normalizedType, string normalizedIdentifier, int index)
    {
        string qualifier = isInVar ? "in" : "out";
        string identifier;
        if (isVertexStage && isInVar || !isVertexStage && !isInVar)
        {
            identifier = normalizedIdentifier;
        }
        else
        {
            Debug.Assert(isVertexStage || isInVar);
            identifier = $"{fragIn}{index}";
        }
        sb.AppendLine($"layout(location = {index}) {qualifier} {normalizedType} {identifier};");

    }

    protected void WriteRWTexture2D(StringBuilder sb, ResourceDefinition rd, int index)
    {
        string layoutType;

        if (rd.valueType.name == typeof(Vector4).FullName)
            layoutType = "rgba32f";
        else if (rd.valueType.name == typeof(float).FullName!)
            layoutType = "r32f";
        else
            throw new ShaderGenerationException($"Invalid RWTexture2D type. T must be Vector4 or float.");

        sb.Append($"{FormatLayoutStr(rd, layoutType)} uniform image2D {CorrectIdentifier(rd.name)};");
    }

    protected override string FormatInvocationCore(string type, string method, InvocationParameterInfo[] parameterInfos)
    {
        return Glsl450KnownFunctions.TranslateMethodInvocation(type, method, parameterInfos);
    }

    private string FormatLayoutStr(ResourceDefinition rd, string? storageSpec = null)
    {
        string storageSpecPart = storageSpec != null ? $"{storageSpec}, " : string.Empty;
        return $"layout({storageSpecPart}set = {rd.set}, binding = {rd.binding})";
    }

    internal override string GetComputeGroupCountsDeclaration(uint3 groupCounts)
    {
        return " ";
    }

    internal override string ParameterDirection(ParameterDirection direction)
    {
        return " ";
    }

    public override string CorrectArgumentRefKind(string refKind)
    {
        return refKind == "ref" ? "inout" : " ";
    }

    public override string GetMethodName(MethodDeclarationData method)
    {
        throw new System.NotImplementedException();
    }
}
