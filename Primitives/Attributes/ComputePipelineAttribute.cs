using System;

namespace GLSH.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class ComputePipelineAttribute : Attribute
{
    public readonly string name;
    public ComputePipelineAttribute(string name)
    {
        this.name = name;
    }
}
