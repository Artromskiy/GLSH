using System;

namespace GLSH.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ComputeEntryPointAttribute : Attribute
{
    public uint localSizeX;
    public uint localSizeY;
    public uint localSizeZ;

    public ComputeEntryPointAttribute(uint localSizeX = 1, uint localSizeY = 1, uint localSizeZ = 1)
    {
        this.localSizeX = localSizeX;
        this.localSizeY = localSizeY;
        this.localSizeZ = localSizeZ;
    }
}
