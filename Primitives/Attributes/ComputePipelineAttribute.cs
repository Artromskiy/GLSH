using System;

namespace GLSH.Primitives.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class ComputePipelineAttribute : Attribute
{
    public readonly string setName;
    public readonly string entryPointName;
    public ComputePipelineAttribute(string setName, string computeShaderFunctionName)
    {
        this.setName = setName;
        entryPointName = computeShaderFunctionName;
    }
}
