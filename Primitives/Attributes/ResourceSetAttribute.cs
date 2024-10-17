using System;

namespace GLSH.Primitives.Attributes;

public class ResourceSetAttribute : Attribute
{
    public int Set { get; }

    public ResourceSetAttribute(int set)
    {
        Set = set;
    }
}
