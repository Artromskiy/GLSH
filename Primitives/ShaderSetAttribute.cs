using System;

namespace GLSH.Primitives;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public class ShaderSetAttribute : Attribute
{
    public string Name { get; }
    public string VertexShader { get; }
    public string FragmentShader { get; }

    public ShaderSetAttribute(string name, string vs, string fs)
    {
        Name = name;
        VertexShader = vs;
        FragmentShader = fs;
    }
}
