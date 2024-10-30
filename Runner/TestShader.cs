using GLSH;
using GLSH.Attributes;
using System.Numerics;
using static GLSH.ShaderBuiltins;
namespace Runner.Some.StupidNamespace;

[GraphicsPipeline(nameof(MinExample))]
public class MinExample
{
    [Layout(set: 0, binding: 0)] public Matrix4x4 Projection;
    [Layout(set: 0, binding: 1)] public Matrix4x4 View;
    [Layout(set: 0, binding: 2)] public Matrix4x4 World;
    [Layout(set: 1, binding: 0)] public Texture2DResource SurfaceTexture;
    [Layout(set: 1, binding: 1)] public SamplerResource Sampler;

    public struct VertexInput
    {
        [Layout(location: 0)] public Vector3 Position;
        [Layout(location: 1)] public Vector2 TextureCoord;
    }

    public struct FragmentInput
    {
        [Layout(location: 0)] public Vector4 Position;
        [Layout(location: 1)] public Vector2 TextureCoord;
    }

    [VertexEntryPoint]
    public FragmentInput VertexShaderFunc(VertexInput input)
    {
        FragmentInput output;

        TestStruct ts = new TestStruct();
        ts.AutoProp = new float2(1);
        var b = ts.AutoProp;
        ts.Prop = new float2(1);
        b = ts.Prop;
        ts.SetMethod(new float2(1));
        ts.SetMethodAutoProp(new float2(1));
        ts.SetMethodProp(new float2(1));
        b = ts.GetMethod();
        b = ts.GetMethodAutoProp();
        b = ts.GetMethodProp();

        ts.Prop = new float2(1);
        Vector4 worldPosition = Mul(World, new Vector4(input.Position, 1));
        Vector4 viewPosition = Mul(View, worldPosition);
        output.Position = Mul(Projection, viewPosition);
        output.TextureCoord = input.TextureCoord;

        return output;
    }

    [FragmentEntryPoint]
    public Vector4 FragmentShaderFunc(FragmentInput input)
    {
        return Sample(SurfaceTexture, Sampler, input.TextureCoord);
    }

    private struct TestStruct
    {
        private float2 field;
        public float2 AutoProp { get; set; }
        public float2 Prop
        {
            get => field;
            set => field = value;
        }
        public float2 GetMethod() => field;
        public void SetMethod(float2 val) => field = val;
        public float2 GetMethodAutoProp() => AutoProp;
        public void SetMethodAutoProp(float2 val) => AutoProp = val;
        public float2 GetMethodProp() => Prop;
        public void SetMethodProp(float2 val) => Prop = val;
        /*
        public static void Prop_set(ref TestStruct @this, float2 value)
        {
            @this.field = value;
        }

        public static void SetMethodProp(ref TestStruct @this, float2 val)
        {
            Prop_set(ref @this, val);
        }
        */
    }
}
