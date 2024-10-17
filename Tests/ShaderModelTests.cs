using GLSH;
using GLSH.Glsl;
using GLSH.Primitives;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using Tests.TestAssets;
using Tests.Tools;
using Xunit;

namespace Tests
{
    public class ShaderModelTests
    {
        [Fact]
        public void TestVertexShader_ShaderModel()
        {
            string functionName = "TestShaders.TestVertexShader.VS";
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new ShaderGenerator(compilation, backend, functionName);
            ShaderGenerationResult genResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> sets = genResult.GetOutput(backend);
            Assert.Equal(1, sets.Count);
            ShaderModel shaderModel = sets[0].model;

            Assert.Equal(2, shaderModel.structures.Length);
            Assert.Equal(3, shaderModel.allResources.Length);
            ShaderFunction vsEntry = shaderModel.GetFunction(functionName);
            Assert.Equal("VS", vsEntry.name);
            Assert.Single(vsEntry.parameters);
            Assert.True(vsEntry.IsEntryPoint);
            Assert.Equal(ShaderFunctionType.VertexEntryPoint, vsEntry.type);
        }

        [Fact]
        public void TestVertexShader_VertexSemantics()
        {
            string functionName = "TestShaders.TestVertexShader.VS";
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new ShaderGenerator(compilation, backend, functionName);
            ShaderGenerationResult genResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> sets = genResult.GetOutput(backend);
            Assert.Equal(1, sets.Count);
            ShaderModel shaderModel = sets[0].model;

            StructureDefinition vsInput = shaderModel.GetStructureDefinition(typeof(PositionTexture).FullName!);
            Assert.Equal(SemanticType.Position, vsInput.fields[0].semanticType);
            Assert.Equal(SemanticType.TextureCoordinate, vsInput.fields[1].semanticType);

            StructureDefinition fsInput = shaderModel.GetStructureDefinition(typeof(TestVertexShader.VertexOutput).FullName!);
            Assert.Equal(SemanticType.SystemPosition, fsInput.fields[0].semanticType);
            Assert.Equal(SemanticType.TextureCoordinate, fsInput.fields[1].semanticType);
        }

        [SkippableFact(typeof(RequiredToolFeatureMissingException))]
        public void PartialFiles()
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new(compilation, backend, "TestShaders.PartialVertex.VertexShaderFunc");

            ShaderGenerationResult genResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> sets = genResult.GetOutput(backend);
            Assert.Equal(1, sets.Count);
            GeneratedShaderSet set = sets[0];
            ShaderModel shaderModel = set.model;
            string vsCode = set.vertexShaderCode;
            CompileResult result = ToolChain.Compile(vsCode, Stage.Vertex, "VertexShaderFunc");
            Assert.False(result.HasError, result.ToString());
        }

        [Fact]
        public void PointLightsInfo_CorrectSize()
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new ShaderGenerator(compilation, backend, "TestShaders.PointLightTestShaders.VS");

            ShaderGenerationResult genResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> sets = genResult.GetOutput(backend);
            Assert.Equal(1, sets.Count);
            GeneratedShaderSet set = sets[0];
            ShaderModel shaderModel = set.model;

            Assert.Single(shaderModel.allResources);
            Assert.Equal(208, shaderModel.GetTypeSize(shaderModel.allResources[0].valueType));
        }

        [Fact]
        public void MultipleResourceSets_CorrectlyParsed()
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new ShaderGenerator(compilation, backend, "TestShaders.MultipleResourceSets.VS");

            ShaderGenerationResult genResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> sets = genResult.GetOutput(backend);
            Assert.Equal(1, sets.Count);
            GeneratedShaderSet set = sets[0];
            ShaderModel shaderModel = set.model;

            Assert.Equal(13, shaderModel.allResources.Length);

            Assert.Equal(0, shaderModel.allResources[0].set);
            Assert.Equal(0, shaderModel.allResources[0].binding);
            Assert.Equal(0, shaderModel.allResources[1].set);
            Assert.Equal(1, shaderModel.allResources[1].binding);
            Assert.Equal(1, shaderModel.allResources[2].set);
            Assert.Equal(0, shaderModel.allResources[2].binding);
            Assert.Equal(2, shaderModel.allResources[3].set);
            Assert.Equal(0, shaderModel.allResources[3].binding);
            Assert.Equal(3, shaderModel.allResources[4].set);
            Assert.Equal(0, shaderModel.allResources[4].binding);
            Assert.Equal(4, shaderModel.allResources[5].set);
            Assert.Equal(0, shaderModel.allResources[5].binding);
            Assert.Equal(0, shaderModel.allResources[6].set);
            Assert.Equal(2, shaderModel.allResources[6].binding);

            Assert.Equal(0, shaderModel.allResources[7].set);
            Assert.Equal(3, shaderModel.allResources[7].binding);
            Assert.Equal(4, shaderModel.allResources[8].set);
            Assert.Equal(1, shaderModel.allResources[8].binding);
            Assert.Equal(0, shaderModel.allResources[9].set);
            Assert.Equal(4, shaderModel.allResources[9].binding);

            Assert.Equal(2, shaderModel.allResources[10].set);
            Assert.Equal(1, shaderModel.allResources[10].binding);
            Assert.Equal(0, shaderModel.allResources[11].set);
            Assert.Equal(5, shaderModel.allResources[11].binding);
            Assert.Equal(1, shaderModel.allResources[12].set);
            Assert.Equal(1, shaderModel.allResources[12].binding);
        }

        [Fact]
        public void ResourcesUsedInStages()
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new ShaderGenerator(
                compilation, backend, "TestShaders.UsedResourcesShaders.VS", "TestShaders.UsedResourcesShaders.FS");

            ShaderGenerationResult genResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> sets = genResult.GetOutput(backend);
            Assert.Equal(1, sets.Count);
            GeneratedShaderSet set = sets[0];
            ShaderModel shaderModel = set.model;

            Assert.Equal(4, shaderModel.vertexResources.Length);
            Assert.Contains(shaderModel.vertexResources, rd => rd.name == "VS_M0");
            Assert.Contains(shaderModel.vertexResources, rd => rd.name == "VS_M1");
            Assert.Contains(shaderModel.vertexResources, rd => rd.name == "VS_T0");
            Assert.Contains(shaderModel.vertexResources, rd => rd.name == "VS_S0");

            Assert.Equal(5, shaderModel.fragmentResources.Length);
            Assert.Contains(shaderModel.fragmentResources, rd => rd.name == "FS_M0");
            Assert.Contains(shaderModel.fragmentResources, rd => rd.name == "FS_M1");
            Assert.Contains(shaderModel.fragmentResources, rd => rd.name == "FS_T0");
            Assert.Contains(shaderModel.fragmentResources, rd => rd.name == "FS_S0");
            Assert.Contains(shaderModel.fragmentResources, rd => rd.name == "FS_M2_Indirect");
        }

        [Fact]
        public void StructureSizes()
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            ShaderGenerator sg = new ShaderGenerator(compilation, backend, "TestShaders.StructureSizeTests.VS");

            ShaderGenerationResult genResult = sg.GenerateShaders();
            IReadOnlyList<GeneratedShaderSet> sets = genResult.GetOutput(backend);
            Assert.Equal(1, sets.Count);
            GeneratedShaderSet set = sets[0];
            ShaderModel shaderModel = set.model;

            StructureDefinition test0 = shaderModel.GetStructureDefinition(typeof(StructureSizeTests.SizeTest_0).FullName!);
            Assert.Equal(48, test0.alignment.CSharpSize);
            Assert.True(test0.cSharpMatchesShaderAlignment);

            StructureDefinition test1 = shaderModel.GetStructureDefinition(typeof(StructureSizeTests.SizeTest_1).FullName!);
            Assert.Equal(52, test1.alignment.CSharpSize);
            Assert.True(test1.cSharpMatchesShaderAlignment);

            StructureDefinition test2 = shaderModel.GetStructureDefinition(typeof(StructureSizeTests.SizeTest_2).FullName!);
            Assert.Equal(48, test2.alignment.CSharpSize);
            Assert.False(test2.cSharpMatchesShaderAlignment);

            StructureDefinition test3 = shaderModel.GetStructureDefinition(typeof(StructureSizeTests.SizeTest_3).FullName!);
            //nameof(TestShaders) + "." + nameof(StructureSizeTests) + "+" + nameof(StructureSizeTests.SizeTest_3));
            Assert.Equal(64, test3.alignment.CSharpSize);
            Assert.False(test3.cSharpMatchesShaderAlignment);

            Assert.Equal(4, shaderModel.GetTypeSize(test3.fields[0].type));
            Assert.Equal(12, shaderModel.GetTypeSize(test3.fields[1].type));
            Assert.Equal(12, shaderModel.GetTypeSize(test3.fields[2].type));
            Assert.Equal(16, shaderModel.GetTypeSize(test3.fields[3].type));
            Assert.Equal(4, shaderModel.GetTypeSize(test3.fields[4].type));
            Assert.Equal(16, shaderModel.GetTypeSize(test3.fields[5].type));
        }
    }
}
