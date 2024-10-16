using GLSH.Primitives;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace GLSH.Glsl;

public class Glsl450Backend : GlslBackendBase
{
    public Glsl450Backend(Compilation compilation) : base(compilation)
    {
    }

    protected override string CSharpToShaderTypeCore(string fullType)
    {
        return GlslKnownTypes.GetMappedName(fullType, true)
            .Replace(".", "_");
    }

    protected override void WriteVersionHeader(
        ShaderFunction function,
        ShaderFunctionAndMethodDeclarationSyntax[] orderedFunctions,
        StringBuilder sb)
    {
        sb.AppendLine("#version 450");
        sb.AppendLine("#extension GL_ARB_separate_shader_objects : enable");
        sb.AppendLine("#extension GL_ARB_shading_language_420pack : enable");
    }

    protected override void WriteUniform(StringBuilder sb, ResourceDefinition rd)
    {
        string layout = FormatLayoutStr(rd);
        sb.AppendLine($"{layout} uniform {rd.name}");
        sb.AppendLine("{");
        sb.AppendLine($"    {CSharpToShaderType(rd.valueType.name)} field_{CorrectIdentifier(rd.name.Trim())};");
        sb.AppendLine("};");
        sb.AppendLine();
    }

    protected override void WriteStructuredBuffer(StringBuilder sb, ResourceDefinition rd, bool isReadOnly, int index)
    {
        string valueType = rd.valueType.name;
        string type = valueType == typeof(AtomicBufferUInt32).FullName
            ? "uint"
            : valueType == typeof(AtomicBufferInt32).FullName
                ? "int"
                : CSharpToShaderType(rd.valueType.name);
        string layout = FormatLayoutStr(rd, "std430");
        string readOnlyStr = isReadOnly ? " readonly" : " ";
        sb.AppendLine($"{layout}{readOnlyStr} buffer {rd.name}");
        sb.AppendLine("{");
        sb.AppendLine($"    {type} field_{CorrectIdentifier(rd.name.Trim())}[];");
        sb.AppendLine("};");
    }

    protected override void WriteSampler(StringBuilder sb, ResourceDefinition rd)
    {
        sb.Append(FormatLayoutStr(rd));
        sb.Append(' ');
        sb.Append("uniform sampler ");
        sb.Append(CorrectIdentifier(rd.name));
        sb.AppendLine(";");
    }

    protected override void WriteSamplerComparison(StringBuilder sb, ResourceDefinition rd)
    {
        sb.Append(FormatLayoutStr(rd));
        sb.Append(' ');
        sb.Append("uniform samplerShadow ");
        sb.Append(CorrectIdentifier(rd.name));
        sb.AppendLine(";");
    }

    protected override void WriteTexture2D(StringBuilder sb, ResourceDefinition rd)
    {
        sb.Append(FormatLayoutStr(rd));
        sb.Append(' ');
        sb.Append("uniform texture2D ");
        sb.Append(CorrectIdentifier(rd.name));
        sb.AppendLine(";");
    }

    protected override void WriteTexture2DArray(StringBuilder sb, ResourceDefinition rd)
    {
        sb.Append(FormatLayoutStr(rd));
        sb.Append(' ');
        sb.Append("uniform texture2DArray ");
        sb.Append(CorrectIdentifier(rd.name));
        sb.AppendLine(";");
    }

    protected override void WriteTextureCube(StringBuilder sb, ResourceDefinition rd)
    {
        sb.Append(FormatLayoutStr(rd));
        sb.Append(' ');
        sb.Append("uniform textureCube ");
        sb.Append(CorrectIdentifier(rd.name));
        sb.AppendLine(";");
    }

    protected override void WriteTexture2DMS(StringBuilder sb, ResourceDefinition rd)
    {
        sb.Append(FormatLayoutStr(rd));
        sb.Append(' ');
        sb.Append("uniform texture2DMS ");
        sb.Append(CorrectIdentifier(rd.name));
        sb.AppendLine(";");
    }

    protected override void WriteDepthTexture2D(StringBuilder sb, ResourceDefinition rd)
    {
        WriteTexture2D(sb, rd);
    }

    protected override void WriteDepthTexture2DArray(StringBuilder sb, ResourceDefinition rd)
    {
        WriteTexture2DArray(sb, rd);
    }

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
        if ((isVertexStage && isInVar) || (!isVertexStage && !isInVar))
        {
            identifier = normalizedIdentifier;
        }
        else
        {
            Debug.Assert(isVertexStage || isInVar);
            identifier = $"fsin_{index}";
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

        sb.Append(FormatLayoutStr(rd, layoutType));
        sb.Append(' ');
        sb.Append("uniform image2D ");
        sb.Append(CorrectIdentifier(rd.name));
        sb.AppendLine(";");
        sb.AppendLine();
    }

    protected override string FormatInvocationCore(string setName, string type, string method, InvocationParameterInfo[] parameterInfos)
    {
        return Glsl450KnownFunctions.TranslateInvocation(type, method, parameterInfos);
    }

    private string FormatLayoutStr(ResourceDefinition rd, string storageSpec = null)
    {
        string storageSpecPart = storageSpec != null ? $"{storageSpec}, " : string.Empty;
        return $"layout({storageSpecPart}set = {rd.set}, binding = {rd.binding})";
    }

    protected override void EmitGlPositionCorrection(StringBuilder sb)
    {
        sb.AppendLine($"        gl_Position.y = -gl_Position.y; // Correct for Vulkan clip coordinates");
    }
}
