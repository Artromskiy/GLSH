namespace GLSH.Compiler;

public class StructureDefinition
{
    public readonly string name;
    public readonly FieldDefinition[] fields;
    public readonly AlignmentInfo alignment;
    public readonly bool cSharpMatchesShaderAlignment;

    public StructureDefinition(string name, FieldDefinition[] fields, AlignmentInfo size)
    {
        this.name = name;
        this.fields = fields;
        alignment = size;
        cSharpMatchesShaderAlignment = GetCSharpMatchesShaderAlignment();
    }

    private bool GetCSharpMatchesShaderAlignment()
    {
        int csharpOffset = 0;
        int shaderOffset = 0;

        for (int i = 0; i < fields.Length; i++)
            if (!CheckAlignments(fields[i], ref csharpOffset, ref shaderOffset))
                return false;

        return true;
    }

    private static bool CheckAlignments(FieldDefinition fd, ref int cs, ref int shader)
    {
        if (cs % fd.alignment.csharpAlignment != 0 || shader % fd.alignment.shaderAlignment != 0)
            return false;

        cs += fd.alignment.csharpSize;
        shader += fd.alignment.csharpSize;
        return cs == shader;
    }
}
