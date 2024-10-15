using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using GLSH;

namespace Tests.Tools
{
    /// <summary>
    /// A Tool Chain to complete compilation of a shader for a particular <see cref="LanguageBackend" />.
    /// </summary>
    public static partial class ToolChain
    {
        /// <summary>
        /// The default timeout in ms to allow for a tool to run.
        /// </summary>
        public const int DefaultTimeout = 30000;

        private const string WindowsKitsFolder = @"C:\Program Files (x86)\Windows Kits";
        private const string VulkanSdkEnvVar = "VULKAN_SDK";
        private const string XcrunPath = "/usr/bin/xcrun";

        private static readonly CompileDelegate _compileFunction;
        public static readonly string Name;
        public static readonly ToolFeatures Features = ToolFeatures.Compilation | ToolFeatures.Transpilation | ToolFeatures.ToHeadless;

        /// <summary>
        /// Executes a compile tool.
        /// </summary>
        /// <param name="toolPath">The tool path.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="code">The code.</param>
        /// <param name="encoding">The encoding.</param>
        /// <param name="outputPath">The output path.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static CompileResult Execute(
            string toolPath,
            string arguments,
            string code,
            string outputPath = null,
            Encoding encoding = default)
        {
            using AutoResetEvent errorWaitHandle = new(false);
            using Process process = new();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = toolPath,
                Arguments = arguments,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            StringBuilder output = new();
            StringBuilder error = new();
            using AutoResetEvent outputWaitHandle = new(false);
            // Add handlers to handle data
            // ReSharper disable AccessToDisposedClosure
            process.OutputDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    try
                    {
                        outputWaitHandle.Set();
                    }
                    catch { }
                }
                else
                {
                    output.AppendLine(e.Data);
                }
            };
            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    try
                    {
                        errorWaitHandle.Set();
                    }
                    catch { }
                }
                else
                {
                    error.AppendLine(e.Data);
                }
            };
            // ReSharper restore AccessToDisposedClosure

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            int exitCode;
            if (!process.WaitForExit(DefaultTimeout) || !outputWaitHandle.WaitOne(DefaultTimeout) ||
                !errorWaitHandle.WaitOne(DefaultTimeout))
            {
                if (output.Length > 0)
                {
                    output.AppendLine("TIMED OUT!").AppendLine();
                }

                error.AppendLine($"Timed out calling: \"{toolPath}\" {process.StartInfo.Arguments}");
                exitCode = int.MinValue;
            }
            else
            {
                exitCode = process.ExitCode;
            }

            // Get compiled output (if any).
            byte[] outputBytes;
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                // No output expected, just encode the existing code into bytes.
                outputBytes = (encoding ?? Encoding.Default).GetBytes(code);
            }
            else
            {
                if (File.Exists(outputPath))
                {
                    try
                    {
                        // Attemp to read output file
                        outputBytes = File.ReadAllBytes(outputPath);
                    }
                    catch (Exception e)
                    {
                        outputBytes = [];
                        error.AppendLine($"Failed to read the output file, \"{outputPath}\": {e.Message}");
                    }
                }
                else
                {
                    outputBytes = [];
                    error.AppendLine($"The output file \"{outputPath}\" was not found!");
                }
            }

            return new CompileResult(code, exitCode, output.ToString(), error.ToString(), outputBytes);
        }

        /*
         * Open GL
         */
        private static readonly Lazy<string> _glslvPath = new Lazy<string>(
            () =>
            {
                // First, try to launch from the current environment.
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = "glslangvalidator",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                    };
                    using (Process p = Process.Start(psi))
                    {
                        p.StandardOutput.ReadToEndAsync();
                        p.StandardError.ReadToEndAsync();
                        p.WaitForExit(2000);
                    }

                    return "glslangvalidator";
                }
                catch
                {
                }

                // Check if the Vulkan SDK is installed, and use the compiler bundled there.
                string vulkanSdkPath = Environment.GetEnvironmentVariable(VulkanSdkEnvVar);
                if (vulkanSdkPath == null)
                {
                    return null;
                }

                string exeExtension = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".exe" : string.Empty;
                string exePath = Path.Combine(vulkanSdkPath, "bin", "glslangvalidator" + exeExtension);
                return File.Exists(exePath) ? exePath : null;
            },
            LazyThreadSafetyMode.ExecutionAndPublication);

        private static CompileResult GLCompile(string code, Stage stage, string entryPoint)
        {
            using TempFile inputFile = new();
            File.WriteAllText(inputFile, code);

            StringBuilder args = new();
            args.Append("-S ");
            switch (stage)
            {
                case Stage.Vertex:
                    args.Append("vert");
                    break;
                case Stage.Fragment:
                    args.Append("frag");
                    break;
                case Stage.Compute:
                    args.Append("comp");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
            }

            args.Append($" \"{inputFile.FilePath}\"");

            return Execute(_glslvPath.Value, args.ToString(), code);
        }

        /*
         * Vulkan
         */
        private static CompileResult VulkanCompile(string code, Stage stage, string entryPoint)
        {
            using TempFile inputFile = new();
            using TempFile outputFile = new();
            File.WriteAllText(inputFile, code);

            StringBuilder args = new();
            args.Append("-S ");
            switch (stage)
            {
                case Stage.Vertex:
                    args.Append("vert");
                    break;
                case Stage.Fragment:
                    args.Append("frag");
                    break;
                case Stage.Compute:
                    args.Append("comp");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
            }
            args.Append($" -V -o \"{outputFile.FilePath}\" \"{inputFile.FilePath}\"");

            return Execute(_glslvPath.Value, args.ToString(), code, outputFile);
        }

        private delegate CompileResult CompileDelegate(string code, Stage stage, string entryPoint);
    }

    public class RequiredToolFeatureMissingException : Exception
    {
        public RequiredToolFeatureMissingException(string message) : base(message) { }
    }
}
