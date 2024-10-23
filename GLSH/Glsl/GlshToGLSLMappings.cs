using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLSH;

namespace GLSH.Compiler.Glsl
{
    class GlshToGLSLMappings
    {
        Dictionary<string, InvocationTranslator> builtinMappings = new()
        {
            { nameof(glm.Mix), SimpleNameTranslator }
        };




        private static string SimpleNameTranslator(string type, string method, InvocationParameterInfo[] parameters)
        {
            return $"{method.ToLower()}({InvocationParameterInfo.FormatParameters(parameters)})";
        }
    }
}
