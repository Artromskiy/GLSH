namespace GLSH.Compiler;

public interface IShaderSetProcessor
{
    string UserArgs { get; set; }
    void ProcessShaderSet(ShaderSetProcessorInput input);
}
