namespace GLSH.Compiler;

public class ShaderSetProcessorInput
{
    public readonly string setName;
    public readonly ShaderFunction vertexFunction;
    public readonly ShaderFunction fragmentFunction;
    public readonly ShaderModel model;

    public ShaderSetProcessorInput(
        string name,
        ShaderFunction vertexFunction,
        ShaderFunction fragmentFunction,
        ShaderModel model)
    {
        setName = name;
        this.vertexFunction = vertexFunction;
        this.fragmentFunction = fragmentFunction;
        this.model = model;
    }
}
