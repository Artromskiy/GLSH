using System;

namespace GLSH.Primitives;

public class ResourceSetAttribute : Attribute
{
    public int Set { get; }

    public ResourceSetAttribute(int set)
    {
        Set = set;
    }
}
