using System;

namespace GLSH.Primitives;

public class ArraySizeAttribute : Attribute
{
    public int ElementCount { get; }

    public ArraySizeAttribute(int elementCount)
    {
        ElementCount = elementCount;
    }
}
