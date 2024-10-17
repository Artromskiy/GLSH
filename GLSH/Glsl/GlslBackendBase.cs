using GLSH.Primitives;
using System;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace GLSH.Glsl;

public abstract class GlslBackendBase : LanguageBackend
{
    protected readonly HashSet<string> _uniformNames = [];
    protected readonly HashSet<string> _ssboNames = [];

    public GlslBackendBase(Compilation compilation) : base(compilation)
    {
    }

    [Obsolete("Check this")]
    protected void WriteStructure(StringBuilder sb, StructureDefinition sd)
    {
        sb.AppendLine($"struct {CSharpToShaderType(sd.name)}");
        sb.AppendLine("{");
        StringBuilder fb = new();
        foreach (FieldDefinition field in sd.fields)
        {
            string fieldTypeStr = GetStructureFieldType(field);
            fb.Append(fieldTypeStr);
            fb.Append(' ');
            fb.Append(CorrectIdentifier(field.name.Trim()));
            int arrayCount = field.arrayElementCount;
            if (arrayCount > 0)
            {
                fb.Append('['); fb.Append(arrayCount); fb.Append(']');
            }
            fb.Append(';');
            sb.Append("    ");
            sb.AppendLine(fb.ToString());
            fb.Clear();
        }
        sb.AppendLine("};");
        sb.AppendLine();
    }

    protected virtual string GetStructureFieldType(FieldDefinition field)
    {
        return CSharpToShaderType(field.type);
    }

    [Obsolete("Rewrite this hell")]
    protected override MethodProcessResult GenerateFullTextCore(string setName, ShaderFunction function)
    {
        BackendContext context = GetContext(setName);
        StringBuilder sb = new();

        ShaderFunctionAndMethodDeclarationSyntax? entryPoint = context.Functions.SingleOrDefault(
            sfabs => sfabs.function.name == function.name);
        if (entryPoint == null)
        {
            throw new ShaderGenerationException("Couldn't find given function: " + function.name);
        }

        ValidateRequiredSemantics(setName, entryPoint.function, function.type);

        StructureDefinition[] orderedStructures
            = StructureDependencyGraph.GetOrderedStructureList(_compilation, context.Structures);

        foreach (StructureDefinition sd in orderedStructures)
        {
            WriteStructure(sb, sd);
        }

        HashSet<ResourceDefinition> resourcesUsed
            = ProcessFunctions(setName, entryPoint, out string funcStr, out string entryStr);

        ValidateResourcesUsed(setName, resourcesUsed);

        int structuredBufferIndex = 0;
        int rwTextureIndex = 0;
        foreach (ResourceDefinition rd in context.Resources)
        {
            if (!resourcesUsed.Contains(rd))
            {
                continue;
            }

            switch (rd.resourceKind)
            {
                case ShaderResourceKind.Uniform:
                    WriteUniform(sb, rd);
                    break;
                case ShaderResourceKind.Texture2D:
                    WriteTexture2D(sb, rd);
                    break;
                case ShaderResourceKind.Texture2DArray:
                    WriteTexture2DArray(sb, rd);
                    break;
                case ShaderResourceKind.TextureCube:
                    WriteTextureCube(sb, rd);
                    break;
                case ShaderResourceKind.Texture2DMS:
                    WriteTexture2DMS(sb, rd);
                    function.UsesTexture2DMS = true;
                    break;
                case ShaderResourceKind.Sampler:
                    WriteSampler(sb, rd);
                    break;
                case ShaderResourceKind.SamplerComparison:
                    WriteSamplerComparison(sb, rd);
                    break;
                case ShaderResourceKind.StructuredBuffer:
                case ShaderResourceKind.RWStructuredBuffer:
                case ShaderResourceKind.AtomicBuffer:
                    WriteStructuredBuffer(sb, rd, rd.resourceKind == ShaderResourceKind.StructuredBuffer, structuredBufferIndex);
                    structuredBufferIndex++;
                    break;
                case ShaderResourceKind.RWTexture2D:
                    WriteRWTexture2D(sb, rd, rwTextureIndex);
                    rwTextureIndex++;
                    break;
                case ShaderResourceKind.DepthTexture2D:
                    WriteDepthTexture2D(sb, rd);
                    break;
                case ShaderResourceKind.DepthTexture2DArray:
                    WriteDepthTexture2DArray(sb, rd);
                    break;
                default: throw new ShaderGenerationException("Illegal resource kind: " + rd.resourceKind);
            }
        }

        sb.AppendLine(funcStr);
        sb.AppendLine(entryStr);

        WriteMainFunction(setName, sb, entryPoint.function);

        // Append version last because it relies on information from parsing the shader.
        StringBuilder versionSB = new();
        WriteVersionHeader(function, entryPoint.orderedFunctionList, versionSB);

        sb.Insert(0, versionSB.ToString());

        return new MethodProcessResult(sb.ToString(), resourcesUsed);
    }

    [Obsolete("Rewrite this hell")]
    private void WriteMainFunction(string setName, StringBuilder sb, ShaderFunction entryFunction)
    {
        ParameterDefinition? input = entryFunction.parameters.Length > 0
            ? entryFunction.parameters[0]
            : null;
        StructureDefinition? inputType = input != null
            ? GetRequiredStructureType(setName, input.type)
            : null;
        StructureDefinition? outputType =
            entryFunction.returnType.name != typeof(Vector4).FullName!
            && entryFunction.returnType.name != typeof(void).FullName!
                ? GetRequiredStructureType(setName, entryFunction.returnType)
                : null;

        string fragCoordName = null;

        if (inputType != null)
        {
            // Declare "in" variables
            int inVarIndex = 0;
            fragCoordName = null;
            foreach (FieldDefinition field in inputType.fields)
            {
                if (entryFunction.type == ShaderFunctionType.FragmentEntryPoint
                    && fragCoordName == null
                    && field.semanticType == SemanticType.SystemPosition)
                {
                    fragCoordName = field.name;
                }
                else
                {
                    WriteInOutVariable(
                        sb,
                        true,
                        entryFunction.type == ShaderFunctionType.VertexEntryPoint,
                        CSharpToShaderType(field.type.name),
                        CorrectIdentifier(field.name),
                        inVarIndex);
                    inVarIndex += 1;
                }
            }
        }

        string mappedReturnType = CSharpToShaderType(entryFunction.returnType.name);

        // Declare "out" variables
        if (entryFunction.type == ShaderFunctionType.VertexEntryPoint)
        {
            int outVarIndex = 0;
            foreach (FieldDefinition field in outputType.fields)
            {
                if (field.semanticType == SemanticType.SystemPosition)
                {
                    continue;
                }
                else
                {
                    WriteInOutVariable(
                        sb,
                        false,
                        true,
                        CSharpToShaderType(field.type.name),
                        "out_" + CorrectIdentifier(field.name),
                        outVarIndex);
                    outVarIndex += 1;
                }
            }
        }
        else
        {
            Debug.Assert(entryFunction.type == ShaderFunctionType.FragmentEntryPoint
                || entryFunction.type == ShaderFunctionType.ComputeEntryPoint);

            if (mappedReturnType == "vec4")
            {
                WriteInOutVariable(sb, false, false, "vec4", "_outputColor_", 0);
            }
            else if (mappedReturnType != "void")
            {
                // Composite struct -- declare an out variable for each.
                int colorTargetIndex = 0;
                foreach (FieldDefinition field in outputType.fields)
                {
                    Debug.Assert(field.semanticType == SemanticType.ColorTarget);
                    Debug.Assert(field.type.name == typeof(Vector4).FullName!);
                    int index = colorTargetIndex++;
                    sb.AppendLine($"    layout(location = {index}) out vec4 _outputColor_{index};");
                }
            }
        }

        sb.AppendLine();

        sb.AppendLine($"void main()");
        sb.AppendLine("{");
        if (inputType != null)
        {
            string inTypeName = CSharpToShaderType(inputType.name);
            sb.AppendLine($"    {inTypeName} {CorrectIdentifier("input")};");

            // Assign synthetic "in" variables (with real field name) to structure passed to actual function.
            int inoutIndex = 0;
            bool foundSystemPosition = false;
            foreach (FieldDefinition field in inputType.fields)
            {
                if (entryFunction.type == ShaderFunctionType.VertexEntryPoint)
                {
                    sb.AppendLine($"    {CorrectIdentifier("input")}.{CorrectIdentifier(field.name)} = {CorrectIdentifier(field.name)};");
                }
                else
                {
                    if (field.semanticType == SemanticType.SystemPosition && !foundSystemPosition)
                    {
                        Debug.Assert(field.name == fragCoordName);
                        foundSystemPosition = true;
                        sb.AppendLine($"    {CorrectIdentifier("input")}.{CorrectIdentifier(field.name)} = gl_FragCoord;");
                    }
                    else
                    {
                        sb.AppendLine($"    {CorrectIdentifier("input")}.{CorrectIdentifier(field.name)} = fsin_{inoutIndex++};");
                    }
                }
            }
        }

        // Call actual function.
        string invocationStr = inputType != null
            ? $"{entryFunction.name}({CorrectIdentifier("input")})"
            : $"{entryFunction.name}()";
        if (mappedReturnType != "void")
        {
            sb.AppendLine($"    {mappedReturnType} {CorrectIdentifier("output")} = {invocationStr};");
        }
        else
        {
            sb.AppendLine($"    {invocationStr};");
        }

        // Assign output fields to synthetic "out" variables with normalized "fsin_#" names.
        if (entryFunction.type == ShaderFunctionType.VertexEntryPoint)
        {
            int inoutIndex = 0;
            FieldDefinition systemPositionField = null;
            foreach (FieldDefinition field in outputType.fields)
            {
                if (systemPositionField == null && field.semanticType == SemanticType.SystemPosition)
                {
                    systemPositionField = field;
                }
                else
                {
                    sb.AppendLine($"    fsin_{inoutIndex++} = {CorrectIdentifier("output")}.{CorrectIdentifier(field.name)};");
                }
            }

            if (systemPositionField == null)
            {
                // TODO: Should be caught earlier.
                throw new ShaderGenerationException("Vertex functions must output a SystemPosition semantic.");
            }

            sb.AppendLine($"    gl_Position = {CorrectIdentifier("output")}.{CorrectIdentifier(systemPositionField.name)};");
            EmitGlPositionCorrection(sb);
        }
        else if (entryFunction.type == ShaderFunctionType.FragmentEntryPoint)
        {
            if (mappedReturnType == "vec4")
            {
                sb.AppendLine($"    _outputColor_ = {CorrectIdentifier("output")};");
            }
            else if (mappedReturnType != "void")
            {
                // Composite struct -- assign each field to output
                int colorTargetIndex = 0;
                foreach (FieldDefinition field in outputType.fields)
                {
                    Debug.Assert(field.semanticType == SemanticType.ColorTarget);
                    sb.AppendLine($"    _outputColor_{colorTargetIndex++} = {CorrectIdentifier("output")}.{CorrectIdentifier(field.name)};");
                }
            }
        }
        sb.AppendLine("}");
    }

    protected override string CSharpToIdentifierNameCore(string typeName, string identifier)
    {
        return GlslKnownIdentifiers.GetMappedIdentifier(typeName, identifier);
    }

    internal override string CorrectIdentifier(string identifier)
    {
        if (s_glslKeywords.Contains(identifier))
        {
            return identifier + "_";
        }

        return identifier;
    }

    internal override void AddResource(string setName, ResourceDefinition rd)
    {
        if (rd.resourceKind == ShaderResourceKind.Uniform)
            _uniformNames.Add(rd.name);

        bool ssbo =
            rd.resourceKind == ShaderResourceKind.StructuredBuffer||
            rd.resourceKind == ShaderResourceKind.RWStructuredBuffer||
            rd.resourceKind == ShaderResourceKind.AtomicBuffer;

        if (ssbo)
            _ssboNames.Add(rd.name);

        base.AddResource(setName, rd);
    }

    internal override string CorrectFieldAccess(SymbolInfo symbolInfo)
    {
        string originalName = symbolInfo.Symbol.Name;
        string mapped = CSharpToShaderIdentifierName(symbolInfo);
        string identifier = CorrectIdentifier(mapped);
        if (_uniformNames.Contains(originalName) || _ssboNames.Contains(originalName))
        {
            return "field_" + identifier;
        }
        else
        {
            return identifier;
        }
    }

    internal override string GetComputeGroupCountsDeclaration(UInt3 groupCounts)
    {
        return $"layout(local_size_x = {groupCounts.X}, local_size_y = {groupCounts.Y}, local_size_z = {groupCounts.Z}) in;";
    }

    internal override string ParameterDirection(ParameterDirection direction)
    {
        return direction switch
        {
            GLSH.ParameterDirection.Out => "out",
            GLSH.ParameterDirection.InOut => "inout",
            _ => string.Empty,
        };
    }

    private static readonly HashSet<string> s_glslKeywords =
    [
        "input", "output",
    ];

    protected abstract void WriteVersionHeader(
        ShaderFunction function,
        ShaderFunctionAndMethodDeclarationSyntax[] orderedFunctions,
        StringBuilder sb);
    protected abstract void WriteUniform(StringBuilder sb, ResourceDefinition rd);
    protected abstract void WriteSampler(StringBuilder sb, ResourceDefinition rd);
    protected abstract void WriteSamplerComparison(StringBuilder sb, ResourceDefinition rd);
    protected abstract void WriteTexture2D(StringBuilder sb, ResourceDefinition rd);
    protected abstract void WriteTexture2DArray(StringBuilder sb, ResourceDefinition rd);
    protected abstract void WriteTextureCube(StringBuilder sb, ResourceDefinition rd);
    protected abstract void WriteTexture2DMS(StringBuilder sb, ResourceDefinition rd);
    protected abstract void WriteStructuredBuffer(StringBuilder sb, ResourceDefinition rd, bool isReadOnly, int index);
    protected abstract void WriteRWTexture2D(StringBuilder sb, ResourceDefinition rd, int index);
    protected abstract void WriteDepthTexture2D(StringBuilder sb, ResourceDefinition rd);
    protected abstract void WriteDepthTexture2DArray(StringBuilder sb, ResourceDefinition rd);

    protected abstract void WriteInOutVariable(
        StringBuilder sb,
        bool isInVar,
        bool isVertexStage,
        string normalizedType,
        string normalizedIdentifier,
        int index);
    protected abstract void EmitGlPositionCorrection(StringBuilder sb);

    internal override string CorrectCastExpression(string type, string expression)
    {
        return $"{type}({expression})";
    }
}
