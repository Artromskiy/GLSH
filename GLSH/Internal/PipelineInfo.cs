namespace GLSH.Compiler.Internal;

internal class PipelineInfo
{
    public readonly string name;
    public readonly MethodDeclarationData vertexEntry;
    public readonly MethodDeclarationData fragmentEntry;
    public readonly MethodDeclarationData computeEntry;

    public PipelineInfo(string name, MethodDeclarationData vertexEntry, MethodDeclarationData fragmentEntry)
    {
        this.name = name;
        this.vertexEntry = vertexEntry;
        this.fragmentEntry = fragmentEntry;
    }

    public PipelineInfo(string name, MethodDeclarationData computeEntry)
    {
        this.name = name;
        this.computeEntry = computeEntry;
    }
}
