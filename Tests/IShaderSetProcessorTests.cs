﻿using GLSH;
using GLSH.Glsl;
using Microsoft.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Tests
{
    public class IShaderSetProcessorTests
    {
        [Fact]
        private void TestProcessor_UsersArgs()
        {
            Compilation compilation = TestUtil.GetCompilation();
            LanguageBackend backend = new Glsl450Backend(compilation);
            TestProcessor processor = new TestProcessor();
            ShaderGenerator sg = new ShaderGenerator(
                compilation,
                backend,
                "TestShaders.ProcessorTestShaders.VS", "TestShaders.ProcessorTestShaders.FS", null, processor);
            sg.GenerateShaders();
            Assert.Equal("This Sentence Should Be Printed By_Enumerating All Resources In Order", processor.Result);
        }

        private class TestProcessor : IShaderSetProcessor
        {
            public string Result { get; private set; }

            public string UserArgs { get; set; }

            public void ProcessShaderSet(ShaderSetProcessorInput input)
            {
                Result = string.Join(" ", input.model.allResources.Select(rd => rd.name));
            }
        }
    }
}
