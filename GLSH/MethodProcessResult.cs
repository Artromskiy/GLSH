using System.Collections.Generic;

namespace GLSH.Compiler;

public class MethodProcessResult
{
    public readonly string fullText;
    public readonly HashSet<ResourceDefinition> resourcesUsed;

    public MethodProcessResult(string fullText, HashSet<ResourceDefinition> resourcesUsed)
    {
        this.fullText = fullText;
        this.resourcesUsed = resourcesUsed;
    }
}
