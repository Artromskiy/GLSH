namespace GLSH.Compiler;

public class FieldDefinition
{
    public readonly string name;
    public readonly TypeReference type;
    public readonly int location;
    /// <summary>
    /// The number of elements in an array, if this is an array field.
    /// Returns 0 if the field is not an array.
    /// </summary>
    public readonly int arrayElementCount;
    public readonly AlignmentInfo alignment;
    public bool IsArray => arrayElementCount > 0;

    public FieldDefinition(
        string name,
        TypeReference type,
        int location,
        int arrayElementCount,
        AlignmentInfo size)
    {
        this.name = name;
        this.type = type;
        this.location = location;
        this.arrayElementCount = arrayElementCount;
        alignment = size;
    }
}
