using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GLSH.Compiler.Internal;

internal class BackendContext
{
    private readonly List<StructureDefinition> _structures = [];
    private readonly List<ResourceDefinition> _resources = [];
    private readonly List<ShaderFunctionAndMethodDeclarationSyntax> _functions = [];

    public ReadOnlySpan<StructureDefinition> Structures => CollectionsMarshal.AsSpan(_structures);
    public ReadOnlySpan<ResourceDefinition> Resources => CollectionsMarshal.AsSpan(_resources);
    public ReadOnlySpan<ShaderFunctionAndMethodDeclarationSyntax> Functions => CollectionsMarshal.AsSpan(_functions);

    public void AddStructure(StructureDefinition structure) => _structures.Add(structure);
    public void AddResource(ResourceDefinition resource) => _resources.Add(resource);
    public void AddFunction(ShaderFunctionAndMethodDeclarationSyntax function) => _functions.Add(function);

    public BackendContext() { }
}
