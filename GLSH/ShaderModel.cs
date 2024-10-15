using System;
using GLSH.Primitives;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace GLSH;

public class ShaderModel
{
    public StructureDefinition[] Structures { get; }
    public ResourceDefinition[] AllResources { get; }
    public ShaderFunction[] Functions { get; }

    public ResourceDefinition[] VertexResources { get; }
    public ResourceDefinition[] FragmentResources { get; }
    public ResourceDefinition[] ComputeResources { get; }

    public ShaderModel(
        StructureDefinition[] structures,
        ResourceDefinition[] resources,
        ShaderFunction[] functions,
        ResourceDefinition[] vertexResources,
        ResourceDefinition[] fragmentResources,
        ResourceDefinition[] computeResources)
    {
        Structures = structures;
        AllResources = resources;
        Functions = functions;
        VertexResources = vertexResources;
        FragmentResources = fragmentResources;
        ComputeResources = computeResources;
    }

    public StructureDefinition GetStructureDefinition(TypeReference typeRef) => GetStructureDefinition(typeRef.Name);
    public StructureDefinition GetStructureDefinition(string name)
    {
        return Structures.FirstOrDefault(sd => sd.Name == name);
    }

    public ShaderFunction GetFunction(string name)
    {
        if (name.EndsWith("."))
        {
            throw new ArgumentException($"{nameof(name)} must be a valid function name.");
        }

        if (name.Contains("."))
        {
            name = name.Split(new[] { '.' }).Last();
        }

        return Functions.FirstOrDefault(sf => sf.Name == name);
    }

    public int GetTypeSize(TypeReference tr)
    {
        if (s_knownTypeSizes.TryGetValue(tr.Name, out int ret))
        {
            return ret;
        }
        else if (tr.TypeInfo.TypeKind == TypeKind.Enum)
        {
            string enumBaseType = ((INamedTypeSymbol)tr.TypeInfo).EnumUnderlyingType.GetFullMetadataName();
            if (s_knownTypeSizes.TryGetValue(enumBaseType, out int enumRet))
            {
                return enumRet;
            }
            else
            {
                throw new InvalidOperationException($"Unknown enum base type: {enumBaseType}");
            }
        }
        else
        {
            StructureDefinition sd = GetStructureDefinition(tr);
            if (sd == null)
            {
                throw new InvalidOperationException("Unable to determine the size for type: " + tr.Name);
            }

            return sd.Alignment.CSharpSize;
        }
    }

    private static readonly Dictionary<string, int> s_knownTypeSizes = new()
    {
        { typeof(Byte).FullName!, 1 },
        { typeof(SByte).FullName!, 1 },
        { typeof(UInt16).FullName!, 2 },
        { typeof(Int16).FullName!, 2 },
        { typeof(UInt32).FullName!, 4 },
        { typeof(Int32).FullName!, 4 },
        { typeof(UInt64).FullName!, 8 },
        { typeof(Int64).FullName!, 8 },
        { typeof(Single).FullName!, 4 },
        { typeof(Double).FullName!, 8 },
        { typeof(Vector2).FullName!, 8 },
        { typeof(Vector3).FullName!, 12 },
        { typeof(Vector4).FullName!, 16 },
        { typeof(Matrix4x4).FullName!, 64 },
        { typeof(UInt2).FullName!, 8 },
        { typeof(UInt3).FullName!, 12 },
        { typeof(UInt4).FullName!, 16 },
        { typeof(Int2).FullName!, 8 },
        { typeof(Int3).FullName!, 12 },
        { typeof(Int4).FullName!, 16 },
    };
}
