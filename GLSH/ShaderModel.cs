using GLSH.Primitives;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GLSH;

public class ShaderModel
{
    public readonly StructureDefinition[] structures;
    public readonly ResourceDefinition[] allResources;
    public readonly ShaderFunction[] functions;

    public readonly ResourceDefinition[] vertexResources;
    public readonly ResourceDefinition[] fragmentResources;
    public readonly ResourceDefinition[] computeResources;

    public ShaderModel(
        StructureDefinition[] structures,
        ResourceDefinition[] resources,
        ShaderFunction[] functions,
        ResourceDefinition[] vertexResources,
        ResourceDefinition[] fragmentResources,
        ResourceDefinition[] computeResources)
    {
        this.structures = structures;
        allResources = resources;
        this.functions = functions;
        this.vertexResources = vertexResources;
        this.fragmentResources = fragmentResources;
        this.computeResources = computeResources;
    }

    public StructureDefinition GetStructureDefinition(TypeReference typeRef) => GetStructureDefinition(typeRef.name);
    public StructureDefinition GetStructureDefinition(string name)
    {
        return structures.FirstOrDefault(sd => sd.name == name);
    }

    public ShaderFunction GetFunction(string name)
    {
        if (name.EndsWith('.'))
            throw new ArgumentException($"{nameof(name)} must be a valid function name.");

        if (name.Contains('.'))
            name = name.Split('.').Last();

        return functions.FirstOrDefault(sf => sf.name == name);
    }

    public int GetTypeSize(TypeReference tr)
    {
        if (s_knownTypeSizes.TryGetValue(tr.name, out int ret))
            return ret;

        if (tr.typeInfo.TypeKind == TypeKind.Enum)
        {
            string enumBaseType = ((INamedTypeSymbol)tr.typeInfo).EnumUnderlyingType.GetFullMetadataName();
            if (s_knownTypeSizes.TryGetValue(enumBaseType, out int enumRet))
                return enumRet;
            else
                throw new InvalidOperationException($"Unknown enum base type: {enumBaseType}");
        }
        StructureDefinition sd = GetStructureDefinition(tr);
        return sd == null
            ? throw new InvalidOperationException("Unable to determine the size for type: " + tr.name)
            : sd.alignment.CSharpSize;
    }

    private static readonly Dictionary<string, int> s_knownTypeSizes = new()
    {
        { typeof(byte).FullName!, 1 },
        { typeof(sbyte).FullName!, 1 },
        { typeof(ushort).FullName!, 2 },
        { typeof(short).FullName!, 2 },
        { typeof(uint).FullName!, 4 },
        { typeof(int).FullName!, 4 },
        { typeof(ulong).FullName!, 8 },
        { typeof(long).FullName!, 8 },
        { typeof(float).FullName!, 4 },
        { typeof(double).FullName!, 8 },
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
