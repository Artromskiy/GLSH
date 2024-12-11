using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;

namespace Runner.Some.StupidNamespace;

[GraphicsPipeline(nameof(MinExample))]
public class MinExample
{
    [Layout(set: 0, binding: 0)] public float4x4 projection;
    [Layout(set: 0, binding: 1)] public float4x4 view;
    [Layout(set: 0, binding: 2)] public float4x4 world;
    [Layout(set: 1, binding: 0)] public Texture2DResource SurfaceTexture;
    [Layout(set: 1, binding: 1)] public SamplerResource Sampler;


    public struct VertexInput
    {
        [Layout(location: 0)] public float3 position;
        [Layout(location: 1)] public float2 textureCoord;
    }

    public struct FragmentInput
    {
        [Layout(location: 0)] public float4 Position;
        [Layout(location: 1)] public float2 TextureCoord;
    }

    [VertexEntryPoint]
    public FragmentInput VertexShaderFunc(VertexInput input)
    {
        TestStruct3 d = default;
        FragmentInput output = default;
        output = default(FragmentInput);
        float4 worldPosition = world * new float4(input.position, 1);
        var viewPosition = view * worldPosition;
        output.Position = projection * viewPosition;
        output.TextureCoord = input.textureCoord;
        return output;
    }

    [FragmentEntryPoint]
    public Vector4 FragmentShaderFunc(FragmentInput input)
    {
        Vector2 texCoords = new Vector2(input.TextureCoord.x, input.TextureCoord.y);
        return Sample(SurfaceTexture, Sampler, texCoords);
    }

    private struct TestStruct
    {
        public float2 field;
        public float2 AutoProp { get; set; }
        public float2 Prop { get => field; set => field = value; }
        public float2 GetMethod() => field;
        public void SetMethod(float2 val) => field = val;
        public float2 GetMethodAutoProp() => AutoProp;
        public void SetMethodAutoProp(float2 val) => AutoProp = val;
        public float2 GetMethodProp() => Prop;
        public void SetMethodProp(float2 val) => Prop = val;
    }

    private struct TestStruct2
    {
        private TestStruct field;
        public TestStruct AutoProp { get; set; }
        public float2 Prop
        {
            get => field.Prop;
            set => field.Prop = value;
        }
        public float2 GetMethod()
        {
            return field.field;
        }
        public void SetMethod(float2 val)
        {
            field.field = val;
        }
        public float2 GetMethodAutoProp()
        {
            return field.AutoProp;
        }
        public void SetMethodAutoProp(float2 val)
        {
            field.AutoProp = val;
        }
        public float2 GetMethodProp()
        {
            return field.Prop;
        }
        public float GetMethodProp1()
        {
            return field.Prop.x;
        }
        public void SetMethodProp(float2 val)
        {
            field.Prop = val;
        }
        public float2 GetMethodMethod()
        {
            return field.GetMethod();
        }
        public void SetMethodMethod(float2 val)
        {
            field.SetMethod(val);
        }
    }

    private struct TestStruct3
    {
        private TestStruct2 ts;
        private TestStruct f = default;
        private float f2 = 2;

        public static TestStruct3 TestStruct3_default()
        {
            TestStruct3 ts3;
            // set every member to default
            // (in glsl it's artificial method, non existent in C#)
            ts3.ts = default;
            ts3.f = default;
            ts3.f2 = default;
            return ts3;
        }

        // ctor code in C#
        public TestStruct3()
        {
            ts = new TestStruct2();
        }

        // real ctor in glsl
        public static TestStruct3 TestStruct3_ctor()
        {
            var t = TestStruct3_default(); // call default

            t.f = default; // copy members initializer code
            t.f2 = 2; // copy members initializer code

            t.ts = new TestStruct2(); // paste ctor code

            return t;
        }
    }
}
