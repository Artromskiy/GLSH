using System;

namespace GLSH.Compiler.Internal;

internal class ShaderSetInfo
{
    public readonly string name;
    public readonly TypeAndMethodName? vertexShader;
    public readonly TypeAndMethodName? fragmentShader;
    public readonly TypeAndMethodName? computeShader;

    public ShaderSetInfo(string name, TypeAndMethodName vs, TypeAndMethodName fs)
    {
        if (vs == null && fs == null)
            throw new ArgumentException("At least one of vs or fs must be non-null.");

        this.name = name;
        vertexShader = vs;
        fragmentShader = fs;
    }

    public ShaderSetInfo(string name, TypeAndMethodName cs)
    {
        this.name = name;
        computeShader = cs;
    }
}
