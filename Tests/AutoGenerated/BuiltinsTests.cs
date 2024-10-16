﻿using GLSH;
using GLSH.Primitives;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tests.Tools;
using Xunit;
using Xunit.Abstractions;

namespace Tests.AutoGenerated
{
    public class BuiltinsTests
    {
        #region Test Configuration

        /// <summary>
        /// The skip reason, set to <see langword="null"/> to enable tests in class.
        /// </summary>
        private const string SkipReason = null;

        /// <summary>
        /// The number of failure examples to output.
        /// </summary>
        private const int FailureExamples = 5;

        /// <summary>
        /// Controls the minimum mantissa when generating a floating point number (how 'small' it can go)
        /// </summary>
        /// <remarks>To test all valid floats this should be set to -126.</remarks>
        private static readonly int MinMantissa = -3;

        /// <summary>
        /// Controls the maximum mantissa when generating a floating point number (how 'big' it can go)
        /// </summary>
        /// <remarks>To test all valid floats this should be set to 128.</remarks>
        private static readonly int MaxMantissa = 3;

        /// <summary>
        /// The float epsilon is used to indicate how close two floats need to be to be considered approximately equal.
        /// </summary>
        private readonly float FloatEpsilon = 1f;

        /// <summary>
        /// The methods to exclude from <see cref="ShaderBuiltins"/>
        /// </summary>
        /// <remarks>TODO See #78 to show why this is another reason to split ShaderBuiltins.</remarks>
        private static readonly HashSet<string> _gpuOnly =
        [
            nameof(ShaderBuiltins.Sample),
            nameof(ShaderBuiltins.SampleGrad),
            nameof(ShaderBuiltins.Load),
            nameof(ShaderBuiltins.Store),
            nameof(ShaderBuiltins.SampleComparisonLevelZero),
            nameof(ShaderBuiltins.Discard),
            nameof(ShaderBuiltins.ClipToTextureCoordinates),
            nameof(ShaderBuiltins.Ddx),
            nameof(ShaderBuiltins.DdxFine),
            nameof(ShaderBuiltins.Ddy),
            nameof(ShaderBuiltins.DdyFine),
            nameof(ShaderBuiltins.InterlockedAdd)
        ];

        /// <summary>
        /// Gets the methods to test.
        /// </summary>
        /// <value>
        /// The methods to test.
        /// </value>
        private static IEnumerable<MethodInfo> MethodsToTest => typeof(ShaderBuiltins)
            .GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)
            .Where(m => !_gpuOnly.Contains(m.Name) && !m.IsSpecialName)
            .OrderBy(m => m.Name);

        /// <summary>
        /// The number of test iterations for each backend.
        /// </summary>
        private const int TestLoops = 1000;

        #endregion


        /// <summary>
        /// The output stream for tests.
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuiltinsTests"/> class.
        /// </summary>
        /// <param name="output">The output.</param>
        public BuiltinsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [SkippableFact(typeof(RequiredToolFeatureMissingException), Skip = SkipReason)]
        private void TestBuiltins()
        {
            /*
             * Auto-generate C# code for testing methods.
            */
            IReadOnlyList<MethodInfo>? methods = null;
            Mappings mappings;
            Compilation compilation;

            using (new TestTimer(_output, () => $"Generating C# shader code to test {methods.Count} methods"))
            {
                // Get all the methods we wish to test
                methods = MethodsToTest.ToArray();
                mappings = CreateMethodTestCompilation(methods, out compilation);

                // Note, you could use compilation.Emit(...) at this point to compile the auto-generated code!
                // however, for now we'll invoke methods directly rather than executing the C# code that has been
                // generated, as loading emitted code into a test is currently much more difficult.
            }

            // Allocate enough space to store the result sets for each backend!
            TestSets testSets = null;
            using (new TestTimer(_output, () =>
            $"Generating random test data ({(mappings.BufferSize * testSets.testLoops).ToMemorySize()}) for {testSets.testLoops} iterations of {mappings.Methods} methods"))
            {
                testSets = new TestSets(compilation, mappings, TestLoops, MinMantissa, MaxMantissa);
            }

            /*
             * Transpile shaders
             */

            ShaderGenerationResult generationResult;

            using (new TestTimer(_output, t => $"Generated shader sets for {ToolChain.Name} backend in {t * 1000:#.##}ms."))
            {
                ShaderGenerator sg = new(compilation, testSets.Select(t => t.Backend).Where(b => b != null).ToArray(), null, null, "ComputeShader.CS");
                generationResult = sg.GenerateShaders();
            }

            /*
             * Loop through each backend to run tests.
             */
            bool first = true;
            using (new TestTimer(_output, "Executing all tests on all backends"))
            {
                foreach (TestSet testSet in testSets)
                {
                    _output.WriteLine(string.Empty);
                    if (first)
                    {
                        // This is the first test set, so we use Space1 instead of Spacer 2.
                        first = false;
                        _output.WriteLine(TestUtil.Spacer1);
                    }
                    else
                    {
                        _output.WriteLine(TestUtil.Spacer2);
                    }

                    _output.WriteLine(string.Empty);

                    testSet.Execute(generationResult, "CS", _output);
                }

                _output.WriteLine(string.Empty);
            }

            _output.WriteLine(string.Empty);
            _output.WriteLine(TestUtil.Spacer1);
            _output.WriteLine(string.Empty);

            Assert.True(testSets.Count(t => t.Executed) > 1,
                "At least 2 test sets are required for comparison.");

            /*
             * Finally, evaluate differences between results
             */
            IReadOnlyList<(MethodMap MethodMap, IReadOnlyList<Failure> Failures)> failures;
            using (new TestTimer(_output, "Analysing results for failures"))
            {
                failures = testSets.GetFailures(FloatEpsilon)
                    .Select(kvp => (MethodMap: kvp.Key, Failures: kvp.Value))
                    .OrderByDescending(kvp => kvp.Failures.Count)
                    .ToArray();
            }

            if (!failures.Any())
            {
                _output.WriteLine("No failures detected!");
                return;
            }

            _output.WriteLine(
                $"{failures.Count} methods had failures out of {mappings.Methods} ({100.0 * failures.Count / mappings.Methods:#.##}%).");

            _output.WriteLine(string.Empty);

            // Get pointer array
            string lastMethodName = null;
            foreach ((MethodMap methodMap, IReadOnlyList<Failure> methodFailures) in failures)
            {
                if (lastMethodName != methodMap.Method.Name)
                {
                    if (lastMethodName != null)
                    {
                        // Seperate methods of different names with spacer 1
                        _output.WriteLine(string.Empty);
                        _output.WriteLine(TestUtil.Spacer1);
                        _output.WriteLine(string.Empty);
                    }

                    lastMethodName = methodMap.Method.Name;
                }
                else
                {
                    _output.WriteLine(string.Empty);
                    _output.WriteLine(TestUtil.Spacer2);
                    _output.WriteLine(string.Empty);
                }

                int failureCount = methodFailures.Count;
                _output.WriteLine(
                    $"{TestUtil.GetUnicodePieChart((double)failureCount / testSets.testLoops)} {methodMap.Signature} failed {failureCount}/{testSets.testLoops} ({failureCount * 100.0 / testSets.testLoops:#.##}%).");

                // Output examples!
                int example = 0;
                foreach (Failure failure in methodFailures)
                {
                    _output.WriteLine(string.Empty);
                    if (example++ >= FailureExamples)
                    {
                        _output.WriteLine("…");
                        break;
                    }

                    _output.WriteLine(failure.ToString());
                }
            }

            _output.WriteLine(string.Empty);
            _output.WriteLine(TestUtil.Spacer2);
            _output.WriteLine(string.Empty);
        }

        /// <summary>
        /// Creates the method test compilation.
        /// </summary>
        /// <param name="methods">The methods.</param>
        /// <param name="compilation">The compilation.</param>
        /// <returns></returns>
        private static Mappings CreateMethodTestCompilation(IReadOnlyCollection<MethodInfo> methods,
            out Compilation compilation)
        {
            Assert.NotNull(methods);
            Assert.NotEmpty(methods);

            // Create compilation
            CSharpCompilationOptions cSharpCompilationOptions = new(OutputKind.DynamicallyLinkedLibrary, allowUnsafe: true);
            compilation = CSharpCompilation.Create("TestAssembly", null, TestUtil.ProjectReferences, cSharpCompilationOptions);

            // Temporary structure to hold method maps until after we calculate input structure.
            var methodMaps =
                new (int Index, MethodInfo Method, IReadOnlyDictionary<ParameterInfo, string> Parameters, string
                    ReturnField)[methods.Count];

            PaddedStructCreator paddedStructCreator = new(compilation);

            StringBuilder codeBuilder = new();
            codeBuilder.Append(SBSP1);
            codeBuilder.Append(methods.Count);
            codeBuilder.Append(SBSP2);

            StringBuilder argsBuilder = new();
            /*
             * Output test cases
             */
            int methodNumber = 0;
            foreach (MethodInfo method in methods)
            {
                Assert.True(method.IsStatic);

                ParameterInfo[] parameterInfos = method.GetParameters();
                Dictionary<ParameterInfo, string> parameterMap = new(parameterInfos.Length);

                foreach (ParameterInfo parameterInfo in parameterInfos)
                {
                    if (argsBuilder.Length > 0)
                    {
                        argsBuilder.Append(",");
                    }

                    string fieldName = paddedStructCreator.GetFieldName(parameterInfo.ParameterType);
                    parameterMap.Add(parameterInfo, fieldName);
                    argsBuilder.Append(SBSParam.Replace("$$NAME$$", fieldName));
                }

                string returnName = method.ReturnType != typeof(void)
                    ? paddedStructCreator.GetFieldName(method.ReturnType)
                    : null;

                string output = returnName != null
                    ? SBSParam.Replace("$$NAME$$", returnName) + " = "
                    : string.Empty;

                codeBuilder.Append(SBSCase
                    .Replace("$$CASE$$", methodNumber.ToString())
                    .Replace("$$RESULT$$", output)
                    .Replace("$$METHOD$$", $"{method.DeclaringType.FullName}.{method.Name}")
                    .Replace("$$ARGS$$", argsBuilder.ToString()));

                methodMaps[methodNumber] = (methodNumber++, method, parameterMap, returnName);
                paddedStructCreator.Reset();
                argsBuilder.Clear();
            }

            codeBuilder.Append(SBSP3);

            /*
             * Output test fields
             */
            IReadOnlyList<PaddedStructCreator.Field> fields = paddedStructCreator.GetFields(out int bufferSize);
            int size = 0;
            foreach (PaddedStructCreator.Field field in fields)
            {
                codeBuilder.AppendLine(
                    $"        // {size,3}: Alignment = {field.AlignmentInfo.ShaderAlignment} {(field.IsPaddingField ? " [PADDING}" : string.Empty)}");
                codeBuilder.AppendLine(
                    $"        {(field.IsPaddingField ? "private" : "public")} {field.Type.FullName} {field.Name};");
                codeBuilder.AppendLine(string.Empty);
                size += field.AlignmentInfo.ShaderSize;
            }

            Assert.Equal(size, bufferSize);

            codeBuilder.Append(SBSP4);

            string code = codeBuilder.ToString();
            compilation = compilation.AddSyntaxTrees(CSharpSyntaxTree.ParseText(code));
            return new Mappings(bufferSize, fields.ToDictionary(f => f.Name), methodMaps);
        }

        #region Code Building Strings
        private static readonly string SBSP1 = @"public class ComputeShader
    {
        public const uint Methods = ";
        private static readonly string SBSP2 = @";

        [ShaderGen.ResourceTestSet(0)] public ShaderGen.RWStructuredBuffer<ComputeShaderParameters> InOutParameters;

        [ShaderGen.ComputeShader(1, 1, 1)]
        public void CS()
        {
            int index = (int)ShaderGen.ShaderBuiltins.DispatchThreadID.X;
            if (index >= Methods) return;
            ComputeShaderParameters parameters = InOutParameters[index];
            switch (index)
            {
";
        private static readonly string SBSCase = @"                case $$CASE$$:
                    $$RESULT$$$$METHOD$$($$ARGS$$);
                    break;
";
        private static readonly string SBSParam = @"parameters.$$NAME$$";
        private static readonly string SBSP3 = @"            }

            InOutParameters[index] = parameters;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ComputeShaderParameters
    {
";
        private static readonly string SBSP4 = @"}";
        #endregion
    }
}