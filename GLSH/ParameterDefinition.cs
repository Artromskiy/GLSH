using System;

namespace GLSH.Compiler;

[Obsolete]
public class ParameterDefinition
{
    public readonly string name;
    public readonly TypeReference type;
    public readonly ParameterDirection direction;

    public ParameterDefinition(string name, TypeReference type, ParameterDirection direction, bool isStruct)
    {
        this.name = name;
        this.type = type;
        this.direction = direction;
    }
}
