using System.Collections.Generic;

namespace GLSH;

public class MethodProcessResult
{
    public string FullText { get; }
    public HashSet<ResourceDefinition> ResourcesUsed { get; set; }

    public MethodProcessResult(string fullText, HashSet<ResourceDefinition> resourcesUsed)
    {
        FullText = fullText;
        ResourcesUsed = resourcesUsed;
    }
}
