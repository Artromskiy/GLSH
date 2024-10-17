using System.Collections.Generic;

namespace GLSH;

internal class BackendContext
{
    internal readonly List<StructureDefinition> Structures = [];
    internal readonly List<ResourceDefinition> Resources = [];
    internal readonly List<ShaderFunctionAndMethodDeclarationSyntax> Functions = [];
}
