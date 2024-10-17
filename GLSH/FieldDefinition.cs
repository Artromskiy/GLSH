using GLSH.Primitives;

namespace GLSH;

public class FieldDefinition
{
    public readonly string name;
    public readonly TypeReference type;
    public readonly SemanticType semanticType;
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
        SemanticType semanticType,
        int arrayElementCount,
        AlignmentInfo size)
    {
        this.name = name;
        this.type = type;
        this.semanticType = semanticType;
        this.arrayElementCount = arrayElementCount;
        alignment = size;
    }
}
