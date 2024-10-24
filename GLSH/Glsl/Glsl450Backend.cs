using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace GLSH.Compiler.Glsl;

public class Glsl450Backend : GlslBackendBase
{
    public Glsl450Backend(Compilation compilation) : base(compilation)
    {
    }

    protected override string CSharpToShaderTypeCore(string fullType)
    {
        return GlslKnownTypes.GetMappedName(fullType).Replace('.', '_').Replace('+', '_');
    }

    protected override void WriteVersionHeader(ShaderFunction function,
        ShaderFunctionAndMethodDeclarationSyntax[] orderedFunctions,
        StringBuilder sb)
    {
        sb.AppendLine(
        """
        #version 450
        #extension GL_ARB_separate_shader_objects : enable
        #extension GL_ARB_shading_language_420pack : enable
        """);
    }

    protected override void WriteUniform(StringBuilder sb, ResourceDefinition rd)
    {
        string layout = FormatLayoutStr(rd);

        sb.AppendLine(
        $$"""
        {{layout}} uniform {{rd.name}}
        {
            {{CSharpToShaderType(rd.valueType.name)}} field_{{CorrectIdentifier(rd.name.Trim())}};
        };

        """);
    }

    protected override void WriteStructuredBuffer(StringBuilder sb, ResourceDefinition rd, bool isReadOnly, int index)
    {
        string valueType = rd.valueType.name;
        string type = valueType == typeof(AtomicBufferUInt32).FullName ? "uint" :
            valueType == typeof(AtomicBufferInt32).FullName ? "int" : CSharpToShaderType(rd.valueType.name);

        string layout = FormatLayoutStr(rd, "std430");
        string readOnlyStr = isReadOnly ? " readonly" : " ";

        sb.AppendLine(
        $$"""
        {{layout}}{{readOnlyStr}} buffer {{rd.name}}
        {
            {{type}} field_{{CorrectIdentifier(rd.name.Trim())}}[];
        };
        """);
    }

    protected override void WriteSampler(StringBuilder sb, ResourceDefinition rd) =>
        WriteTexture(sb, rd, "sampler");
    protected override void WriteSamplerComparison(StringBuilder sb, ResourceDefinition rd) =>
        WriteTexture(sb, rd, "samplerShadow");
    protected override void WriteTexture2D(StringBuilder sb, ResourceDefinition rd) =>
        WriteTexture(sb, rd, "texture2D");
    protected override void WriteTexture2DArray(StringBuilder sb, ResourceDefinition rd) =>
        WriteTexture(sb, rd, "texture2DArray");
    protected override void WriteTextureCube(StringBuilder sb, ResourceDefinition rd) =>
        WriteTexture(sb, rd, "textureCube");
    protected override void WriteTexture2DMS(StringBuilder sb, ResourceDefinition rd) =>
        WriteTexture(sb, rd, "texture2DMS");
    protected override void WriteDepthTexture2D(StringBuilder sb, ResourceDefinition rd) =>
        WriteTexture2D(sb, rd);
    protected override void WriteDepthTexture2DArray(StringBuilder sb, ResourceDefinition rd) =>
        WriteTexture2DArray(sb, rd);
    private void WriteTexture(StringBuilder sb, ResourceDefinition rd, string uniformName) =>
        sb.AppendLine($"{FormatLayoutStr(rd)} uniform {uniformName} {CorrectIdentifier(rd.name)};");


    protected override void WriteInOutVariable(
        StringBuilder sb,
        bool isInVar,
        bool isVertexStage,
        string normalizedType,
        string normalizedIdentifier,
        int index)
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

    protected override void WriteRWTexture2D(StringBuilder sb, ResourceDefinition rd, int index)
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

    protected override string FormatInvocationCore(string setName, string type, string method, InvocationParameterInfo[] parameterInfos)
    {
        return Glsl450KnownFunctions.TranslateInvocation(type, method, parameterInfos);
    }

    private string FormatLayoutStr(ResourceDefinition rd, string? storageSpec = null)
    {
        string storageSpecPart = storageSpec != null ? $"{storageSpec}, " : string.Empty;
        return $"layout({storageSpecPart}set = {rd.set}, binding = {rd.binding})";
    }
}
