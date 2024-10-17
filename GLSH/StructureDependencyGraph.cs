using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace GLSH;

public static class StructureDependencyGraph
{
    public static StructureDefinition[] GetOrderedStructureList(Compilation compilation, List<StructureDefinition> allDefs)
    {
        List<StructureDefinition> results = [];

        foreach (StructureDefinition sd in allDefs)
            Traverse(compilation, allDefs, sd, results);

        return [.. results];
    }

    private static void Traverse(
        Compilation compilation,
        List<StructureDefinition> allDefs,
        StructureDefinition current,
        List<StructureDefinition> results)
    {
        foreach (FieldDefinition field in current.fields)
        {
            StructureDefinition? fieldTypeDef = allDefs.SingleOrDefault(sd => sd.name == field.type.name);
            if (fieldTypeDef != null)
                Traverse(compilation, allDefs, fieldTypeDef, results);
        }

        if (!results.Contains(current))
            results.Add(current);
    }
}
