using System;

namespace GLSH.Primitives.Attributes.New;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class LayoutAttribute : Attribute
{
    public readonly int set = -1;
    public readonly int binding = -1;
    public readonly int location = -1;
    public LayoutAttribute(int set = -1, int binding = -1, int location = -1)
    {
        this.set = int.Max(this.set, set);
        this.binding = int.Max(this.binding, binding);
        this.location = int.Max(this.location, location);
    }
}
