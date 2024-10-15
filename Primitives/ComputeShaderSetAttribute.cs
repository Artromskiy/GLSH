using System;

namespace GLSH.Primitives;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public class ComputeShaderSetAttribute : Attribute
{
    public readonly string setName;
    public readonly string entryPointName;
    public ComputeShaderSetAttribute(string setName, string computeShaderFunctionName)
    {
        this.setName = setName;
        entryPointName = computeShaderFunctionName;
    }
}
