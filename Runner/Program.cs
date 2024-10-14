using GLSH;
using GLSH.Glsl;
using Microsoft.CodeAnalysis;
using System.Diagnostics;
using System.Text;

namespace Runner
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            Compilation compilation = default!;
            Glsl450Backend glsl450 = new(compilation);

            ShaderGenerator sg = new(compilation, [glsl450]);
            ShaderGenerationResult shaderGenResult;
            try
            {
                shaderGenResult = sg.GenerateShaders();
            }
            catch (Exception e) when (!Debugger.IsAttached)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("An error was encountered while generating shader code:");
                sb.AppendLine(e.ToString());
                Console.Error.WriteLine(sb.ToString());
                return -1;
            }

            return 0;
        }
    }
}
