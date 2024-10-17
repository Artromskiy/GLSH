using GLSH;
using GLSH.Glsl;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Text;
using Tests.Tools;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class ShaderGeneratorTests
    {
        private readonly ITestOutputHelper _output;

        public ShaderGeneratorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public static IEnumerable<object[]> ShaderSets()
        {
            yield return new object[] { "TestShaders.TestVertexShader.VS", null };
            yield return new object[] { null, "TestShaders.TestFragmentShader.FS" };
            yield return new object[] { "TestShaders.TestVertexShader.VS", "TestShaders.TestFragmentShader.FS" };
            yield return new object[] { null, "TestShaders.TextureSamplerFragment.FS" };
            yield return new object[] { "TestShaders.VertexAndFragment.VS", "TestShaders.VertexAndFragment.FS" };
            yield return new object[] { null, "TestShaders.ComplexExpression.FS" };
            yield return new object[] { "TestShaders.PartialVertex.VertexShaderFunc", null };
            yield return new object[] { "TestShaders.VeldridShaders.ForwardMtlCombined.VS", "TestShaders.VeldridShaders.ForwardMtlCombined.FS" };
            yield return new object[] { "TestShaders.VeldridShaders.ForwardMtlCombined.VS", null };
            yield return new object[] { null, "TestShaders.VeldridShaders.ForwardMtlCombined.FS" };
            yield return new object[] { "TestShaders.CustomStructResource.VS", null };
            yield return new object[] { "TestShaders.Swizzles.VS", null };
            yield return new object[] { "TestShaders.CustomMethodCalls.VS", null };
            yield return new object[] { "TestShaders.VeldridShaders.ShadowDepth.VS", "TestShaders.VeldridShaders.ShadowDepth.FS" };
            yield return new object[] { "TestShaders.ShaderBuiltinsTestShader.VS", null };
            yield return new object[] { null, "TestShaders.ShaderBuiltinsTestShader.FS" };
            yield return new object[] { "TestShaders.VectorConstructors.VS", null };
            yield return new object[] { "TestShaders.VectorIndexers.VS", null };
            yield return new object[] { "TestShaders.VectorStaticProperties.VS", null };
            yield return new object[] { "TestShaders.VectorStaticFunctions.VS", null };
            yield return new object[] { "TestShaders.MultipleResourceSets.VS", null };
            yield return new object[] { "TestShaders.MultipleColorOutputs.VS", "TestShaders.MultipleColorOutputs.FS" };
            yield return new object[] { "TestShaders.MultisampleTexture.VS", null };
            yield return new object[] { "TestShaders.BuiltInVariables.VS", null };
            yield return new object[] { "TestShaders.MathFunctions.VS", null };
            yield return new object[] { "TestShaders.Matrix4x4Members.VS", null };
            yield return new object[] { "TestShaders.CustomMethodUsingUniform.VS", null };
            yield return new object[] { "TestShaders.PointLightTestShaders.VS", null };
            yield return new object[] { "TestShaders.UIntVectors.VS", null };
            yield return new object[] { "TestShaders.VeldridShaders.UIntVertexAttribs.VS", null };
            yield return new object[] { "TestShaders.SwitchStatements.VS", null };
            yield return new object[] { "TestShaders.VariableTypes.VS", null };
            yield return new object[] { "TestShaders.OutParameters.VS", null };
            yield return new object[] { null, "TestShaders.ExpressionBodiedMethods.ExpressionBodyWithReturn" };
            yield return new object[] { null, "TestShaders.ExpressionBodiedMethods.ExpressionBodyWithoutReturn" };
            yield return new object[] { "TestShaders.StructuredBufferTestShader.VS", null };
            yield return new object[] { null, "TestShaders.StructuredBufferTestShader.FS" };
            yield return new object[] { null, "TestShaders.DepthTextureSamplerFragment.FS" };
            yield return new object[] { null, "TestShaders.Enums.FS" };
            yield return new object[] { "TestShaders.VertexWithStructuredBuffer.VS", null };
            yield return new object[] { "TestShaders.WhileAndDoWhile.VS", null };
        }

        public static IEnumerable<object[]> ComputeShaders()
        {
            yield return new object[] { "TestShaders.SimpleCompute.CS" };
            yield return new object[] { "TestShaders.ComplexCompute.CS" };
        }

        private static readonly HashSet<string> s_glslesSkippedShaders =
        [
            "TestShaders.ComplexCompute.CS"
        ];


        [SkippableTheory(typeof(RequiredToolFeatureMissingException))]
        [MemberData(nameof(ShaderSets))]
        public void Glsl450Compile(string vsName, string fsName) => TestCompile(vsName, fsName);


        private static void TestCompile(string vsName, string fsName, string csName = null)
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new(compilation, backend, vsName, fsName, csName);
            ShaderGenerationResult generationResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> sets = generationResult.GetOutput(backend);
            Assert.Single(sets);
            GeneratedShaderSet set = sets[0];
            ShaderModel shaderModel = set.model;

            List<CompileResult> results = new List<CompileResult>();
            if (!string.IsNullOrWhiteSpace(vsName))
            {
                ShaderFunction vsFunction = shaderModel.GetFunction(vsName);
                string vsCode = set.vertexShaderCode;

                results.Add(ToolChain.Compile(vsCode, Stage.Vertex, vsFunction.name));
            }
            if (!string.IsNullOrWhiteSpace(fsName))
            {
                ShaderFunction fsFunction = shaderModel.GetFunction(fsName);
                string fsCode = set.fragmentShaderCode;
                results.Add(ToolChain.Compile(fsCode, Stage.Fragment, fsFunction.name));
            }
            if (!string.IsNullOrWhiteSpace(csName))
            {
                ShaderFunction csFunction = shaderModel.GetFunction(csName);
                string csCode = set.computeShaderCode;
                results.Add(ToolChain.Compile(csCode, Stage.Compute, csFunction.name));
            }

            // Collate results
            StringBuilder builder = new();
            foreach (CompileResult result in results)
            {
                if (result.HasError)
                {
                    builder.AppendLine(result.ToString());
                }
            }

            Assert.True(builder.Length < 1, builder.ToString());
        }

        public static IEnumerable<object[]> ErrorSets()
        {
            yield return new object[] { "TestShaders.MissingFunctionAttribute.VS", null };
            yield return new object[] { "TestShaders.PercentOperator.PercentVS", null };
            yield return new object[] { "TestShaders.PercentOperator.PercentEqualsVS", null };
        }

        [Theory]
        [MemberData(nameof(ErrorSets))]
        public void ExpectedException(string vsName, string fsName)
        {
            /*
            Compilation compilation = TestUtil.GetCompilation();
            Glsl330Backend backend = new Glsl330Backend(compilation);
            ShaderGenerator sg = new ShaderGenerator(compilation, backend, vsName, fsName);

            Assert.Throws<ShaderGenerationException>(() => sg.GenerateShaders());
            */
        }
    }
}
