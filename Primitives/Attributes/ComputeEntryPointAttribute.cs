using System;

namespace GLSH.Primitives;

[AttributeUsage(AttributeTargets.Method)]
public class ComputeEntryPointAttribute : Attribute
{
    public uint GroupCountX { get; }
    public uint GroupCountY { get; }
    public uint GroupCountZ { get; }

    public ComputeEntryPointAttribute(uint groupCountX, uint groupCountY, uint groupCountZ)
    {
        GroupCountX = groupCountX;
        GroupCountY = groupCountY;
        GroupCountZ = groupCountZ;
    }
}
