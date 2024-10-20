using System;

namespace GLSH.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class GraphicsPipelineAttribute : Attribute
{
    public readonly string name;

    public GraphicsPipelineAttribute(string name)
    {
        this.name = name;
    }
}
