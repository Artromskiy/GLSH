using System;

namespace GLSH.Compiler.Internal;

internal class PipelineInfo
{
    public readonly string name;
    public readonly TypeAndMethodName? vertexEntry;
    public readonly TypeAndMethodName? fragmentEntry;
    public readonly TypeAndMethodName? computeEntry;

    public PipelineInfo(string name, TypeAndMethodName vs, TypeAndMethodName fs)
    {
        if (vs == null && fs == null)
            throw new ArgumentException("At least one of vs or fs must be non-null.");

        this.name = name;
        vertexEntry = vs;
        fragmentEntry = fs;
    }

    public PipelineInfo(string name, TypeAndMethodName cs)
    {
        this.name = name;
        computeEntry = cs;
    }
}
