using System;

namespace GLSH.Primitives.Attributes;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class ArraySizeAttribute : Attribute
{
    public int ElementCount { get; }

    public ArraySizeAttribute(int elementCount)
    {
        ElementCount = elementCount;
    }
}
