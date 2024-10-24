using System.Collections.Generic;

namespace GLSH.Compiler.Glsl
{
    internal class GlshToGLSLMappings
    {
        private readonly Dictionary<string, InvocationTranslator> builtinMappings = new()
        {
            { nameof(glm.Mix), SimpleNameTranslator }
        };




        private static string SimpleNameTranslator(string type, string method, InvocationParameterInfo[] parameters)
        {
            return $"{method.ToLower()}({InvocationParameterInfo.FormatParameters(parameters)})";
        }
    }
}
