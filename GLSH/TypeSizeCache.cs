using GLSH.Compiler.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace GLSH.Compiler;

[Obsolete("Rewrite this hell")]
public static class TypeSizeCache
{
    private static readonly IReadOnlyDictionary<string, int> s_knownSizes = new Dictionary<string, int>()
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
    };

    private static readonly IReadOnlyDictionary<string, int> s_shaderAlignments = new Dictionary<string, int>()
    {
        { typeof(Vector2).FullName!, 8 },
        { typeof(Vector3).FullName!, 16 },
        { typeof(Vector4).FullName!, 16 },
        { typeof(Matrix4x4).FullName!, 16 },
        { typeof(UInt2).FullName!, 8 },
        { typeof(UInt3).FullName!, 16 },
        { typeof(UInt4).FullName!, 16 },
        { typeof(Int2).FullName!, 8 },
        { typeof(Int3).FullName!, 16 },
        { typeof(Int4).FullName!, 16 },
    };

    private static readonly ConcurrentDictionary<ITypeSymbol, AlignmentInfo> s_cachedSizes
        = new(SymbolEqualityComparer.Default);

    public static AlignmentInfo Get(ITypeSymbol symbol)
    {
        Debug.Assert(symbol.Kind != SymbolKind.ArrayType);
        return s_cachedSizes.TryGetValue(symbol, out AlignmentInfo alignmentInfo)
            ? alignmentInfo
            : Analyze(symbol);
    }

    private static AlignmentInfo Analyze(ITypeSymbol typeSymbol)
    {
        // Check if we already know this type
        if (s_cachedSizes.TryGetValue(typeSymbol, out AlignmentInfo alignmentInfo))
            return alignmentInfo;

        string symbolFullName = typeSymbol.GetFullMetadataName();

        // Get any specific shader alignment
        int? specificShaderAlignment = s_shaderAlignments.TryGetValue(symbolFullName, out int sa)
            ? sa
            : null;

        // Check if this in our list of known sizes
        if (s_knownSizes.TryGetValue(symbolFullName, out int knownSize))
        {
            alignmentInfo = new AlignmentInfo(knownSize, knownSize, knownSize, specificShaderAlignment ?? knownSize);
            s_cachedSizes.TryAdd(typeSymbol, alignmentInfo);
            return alignmentInfo;
        }

        // Check if enum
        if (typeSymbol.TypeKind == TypeKind.Enum)
        {
            string enumBaseType = ((INamedTypeSymbol)typeSymbol).EnumUnderlyingType.GetFullMetadataName();
            if (!s_knownSizes.TryGetValue(enumBaseType, out int enumSize))
            {
                throw new ShaderGenerationException($"Unknown enum base type: {enumBaseType}");
            }

            alignmentInfo = new AlignmentInfo(enumSize, enumSize, enumSize, specificShaderAlignment ?? enumSize);
            s_cachedSizes.TryAdd(typeSymbol, alignmentInfo);
            return alignmentInfo;
        }

        // NOTE This check only works for known types accessible to ShaderGen, but it will pick up most non-blittable types.
        if (BlittableHelper.IsBlittable(symbolFullName) == false)
        {
            throw new ShaderGenerationException($"Cannot use the {symbolFullName} type in a shader as it is not a blittable type.");
        }

        // Unknown type, get the instance fields.
        ITypeSymbol[] fields = typeSymbol.GetMembers()
            .Where(symb => symb.Kind == SymbolKind.Field && !symb.IsStatic)
            .Select(symb => ((IFieldSymbol)symb).Type)
            .ToArray();

        if (fields.Length == 0)
        {
            throw new ShaderGenerationException($"No fields on type {symbolFullName}, cannot assess size of structure.");
        }

        int csharpSize = 0;
        int shaderSize = 0;
        int csharpAlignment = 0;
        int shaderAlignment = 0;

        // Calculate size of struct from its fields alignment infos
        foreach (ITypeSymbol fieldType in fields)
        {
            // Determine if type is blittable
            alignmentInfo = Analyze(fieldType);
            csharpAlignment = Math.Max(csharpAlignment, alignmentInfo.csharpAlignment);
            csharpSize += alignmentInfo.csharpSize + csharpSize % alignmentInfo.csharpAlignment;
            shaderAlignment = Math.Max(shaderAlignment, alignmentInfo.shaderAlignment);
            shaderSize += alignmentInfo.shaderSize + shaderSize % alignmentInfo.shaderAlignment;
        }

        // Return new alignment info after adding into cache.
        alignmentInfo = new AlignmentInfo(csharpSize, shaderSize, csharpAlignment, specificShaderAlignment ?? shaderAlignment);
        s_cachedSizes.TryAdd(typeSymbol, alignmentInfo);
        return alignmentInfo;
    }
}
