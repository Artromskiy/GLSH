namespace GLSH.Compiler;

/// <summary>
/// Represents the concrete output of a shader generation for a specific shader set,
/// created using a specific LanguageBackend.
/// </summary>
public class GeneratedPipeline
{
    public readonly string name;
    public readonly string vertexShaderCode;
    public readonly string fragmentShaderCode;
    public readonly string computeShaderCode;
    public readonly ShaderFunction vertexFunction;
    public readonly ShaderFunction fragmentFunction;
    public readonly ShaderFunction computeFunction;
    //public readonly ShaderModel model;

    public GeneratedPipeline(string name, string vsCode, string fsCode, string csCode,
        ShaderFunction vertexfunction, ShaderFunction fragmentFunction, ShaderFunction computeFunction)
    {
        if (string.IsNullOrEmpty(vsCode) && string.IsNullOrEmpty(fsCode) && string.IsNullOrEmpty(csCode))
            throw new ShaderGenerationException("At least one of vsCode, fsCode, or csCode must be non-empty");

        this.name = name;
        vertexShaderCode = vsCode;
        fragmentShaderCode = fsCode;
        computeShaderCode = csCode;
        vertexFunction = vertexfunction;
        this.fragmentFunction = fragmentFunction;
        this.computeFunction = computeFunction;
        //this.model = model;
    }
}
