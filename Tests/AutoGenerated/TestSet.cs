﻿using GLSH;
using GLSH.Glsl;
using System.Linq;
using Tests.Tools;
using Xunit;
using Xunit.Abstractions;

namespace Tests.AutoGenerated
{
    /// <summary>
    /// An individual test set.
    /// </summary>
    internal class TestSet
    {
        /// <summary>
        /// The owner <see cref="TestSets"/> collection.
        /// </summary>
        public readonly TestSets TestSets;

        /// <summary>
        /// The test name.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The <see cref="LanguageBackend"/> if any; otherwise <see langword="null"/>.
        /// </summary>
        public readonly LanguageBackend Backend;

        /// <summary>
        /// The results data.
        /// </summary>
        public byte[] Results { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="TestSet"/> has been executed yet.
        /// </summary>
        /// <value>
        ///   <c>true</c> if executed; otherwise, <c>false</c>.
        /// </value>
        public bool Executed => Results != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestSet"/> class.
        /// </summary>
        /// <param name="testSets">The test sets.</param>
        /// <param name="toolChain">The tool chain (if any).</param>
        public TestSet(TestSets testSets)
        {
            TestSets = testSets;
            Name = "GPU" ?? "CPU";
            Backend = new Glsl450Backend(testSets.compilation);
        }

        /// <summary>
        /// Allocates the results buffer.
        /// </summary>
        /// <param name="output">The output.</param>
        private void AllocateResults(ITestOutputHelper output)
        {
            // Create results data structure.
            using (new TestTimer(output,
                $"Creating result buffer ({(TestSets.mappings.ResultSetSize * TestSets.testLoops).ToMemorySize()})"))
            {
                Results = new byte[TestSets.mappings.ResultSetSize * TestSets.testLoops];
            }
        }

        /// <summary>
        /// Executes the specified test.
        /// </summary>
        /// <param name="generationResult">The generation result.</param>
        /// <param name="csFunctionName">Name of the cs function.</param>
        /// <param name="output">The output.</param>
        public void Execute(
            ShaderGenerationResult generationResult,
            string csFunctionName,
            ITestOutputHelper output)
        {
            if (Executed)
            {
                output.WriteLine(
                    $"The {Name} tests have already been executed!");
                return;
            }

            TestSets testSets = TestSets;
            Mappings mappings = testSets.mappings;


            // REMOVED IF CHECK!!!
            //if (ToolChain == null)
            {
                /*
                 * Generate the test data and the result set data for the CPU.
                 */
                AllocateResults(output);
                using (new TestTimer(output, $"Running {testSets.testLoops} iterations on the {Name} backend"))
                {
                    for (int test = 0; test < testSets.testLoops; test++)
                    {
                        foreach (MethodMap method in mappings.MethodMaps)
                        {
                            method.ExecuteCPU(TestSets.testData, Results, test);
                        }
                    }

                    return;
                }
            }

            GeneratedShaderSet set;
            CompileResult compilationResult;
            // Compile shader for this backend.
            using (new TestTimer(output, $"Compiling Compute Shader for {ToolChain.Name}"))
            {
                set = generationResult.GetOutput(Backend).Single();
                compilationResult =
                    ToolChain.Compile(set.ComputeShaderCode, Stage.Compute, set.ComputeFunction.Name);
            }

            if (compilationResult.HasError)
            {
                output.WriteLine($"Failed to compile Compute Shader from set \"{set.Name}\"!");
                output.WriteLine(compilationResult.ToString());
                return;
            }

            Assert.NotNull(compilationResult.CompiledOutput);
            OnDeviceTestingVeldrid(output, mappings);
        }

        private void OnDeviceTestingVeldrid(ITestOutputHelper output, Mappings mappings)
        {
            /*
            using (GraphicsDevice graphicsDevice = ToolChain.CreateHeadless())
            {
                if (!graphicsDevice.Features.ComputeShader)
                {
                    output.WriteLine(
                        $"The {ToolChain.GraphicsBackend} backend does not support compute shaders, skipping!");
                    return;
                }

                ResourceFactory factory = graphicsDevice.ResourceFactory;
                using (DeviceBuffer inOutBuffer = factory.CreateBuffer(
                    new BufferDescription(
                        (uint)mappings.BufferSize,
                        BufferUsage.StructuredBufferReadWrite,
                        (uint)mappings.StructSize)))

                using (Shader computeShader = factory.CreateShader(
                    new ShaderDescription(
                        ShaderStages.Compute,
                        compilationResult.CompiledOutput,
                        csFunctionName)))

                using (ResourceLayout inOutStorageLayout = factory.CreateResourceLayout(
                    new ResourceLayoutDescription(
                        new ResourceLayoutElementDescription("InOutBuffer", ResourceKind.StructuredBufferReadWrite,
                            ShaderStages.Compute))))

                using (Pipeline computePipeline = factory.CreateComputePipeline(new ComputePipelineDescription(
                    computeShader,
                    new[] { inOutStorageLayout },
                    1, 1, 1)))


                using (ResourceSet computeResourceSet = factory.CreateResourceSet(
                    new ResourceSetDescription(inOutStorageLayout, inOutBuffer)))

                using (CommandList commandList = factory.CreateCommandList())
                {
                    // Ensure the headless graphics device is the backend we expect.
                    Assert.Equal(ToolChain.GraphicsBackend, graphicsDevice.BackendType);

                    output.WriteLine($"Created compute pipeline for {Name} backend.");

                    // Allocate the results buffer
                    AllocateResults(output);

                    using (new TestTimer(output,
                        $"Running {testSets.TestLoops} iterations on the {Name} backend"))
                    {
                        // Loop for each test
                        for (int test = 0; test < testSets.TestLoops; test++)
                        {
                            // Update parameter buffer
                            graphicsDevice.UpdateBuffer(
                                inOutBuffer,
                                0,
                                // Get the portion of test data for the current test loop
                                Marshal.UnsafeAddrOfPinnedArrayElement(testSets.TestData, mappings.BufferSize * test),
                                (uint)mappings.BufferSize);
                            graphicsDevice.WaitForIdle();

                            // Execute compute shaders
                            commandList.Begin();
                            commandList.SetPipeline(computePipeline);
                            commandList.SetComputeResourceSet(0, computeResourceSet);
                            commandList.Dispatch((uint)mappings.Methods, 1, 1);
                            commandList.End();

                            graphicsDevice.SubmitCommands(commandList);
                            graphicsDevice.WaitForIdle();

                            // Read back parameters using a staging buffer
                            using (DeviceBuffer stagingBuffer =
                                factory.CreateBuffer(
                                    new BufferDescription(inOutBuffer.SizeInBytes, BufferUsage.Staging)))
                            {
                                commandList.Begin();
                                commandList.CopyBuffer(inOutBuffer, 0, stagingBuffer, 0, stagingBuffer.SizeInBytes);
                                commandList.End();
                                graphicsDevice.SubmitCommands(commandList);
                                graphicsDevice.WaitForIdle();

                                // Read back test results
                                MappedResource map = graphicsDevice.Map(stagingBuffer, MapMode.Read);

                                mappings.SetResults(map.Data, Results, test);
                                graphicsDevice.Unmap(stagingBuffer);
                            }
                        }
                    }
                }
            }
            */
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{Name} tests{(Executed ? $" [Executed]" : string.Empty)}";
    }
}