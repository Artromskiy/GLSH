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

        TestStruct t = new TestStruct();
        t.Increment();
        t.Value += 1;
        t.vall = t.Value;
        
        //bool4 b = new(true);
        //b = bool4.Mix(b, b, b);
        DoSome();
        DoInt(GetInt());

        float4 someFloat = new (0f);
        someFloat += new float4(1);
        someFloat -= new float4(3);
        someFloat /= new float4(new float2(1), 3);
        //someFloat = new(default(float2), 3);
        someFloat = float4.Abs(someFloat);

        Vector4 worldPosition = Mul(World, new Vector4(input.Position, 1));
        Vector4 viewPosition = Mul(View, worldPosition);
        output.Position = Mul(Projection, viewPosition);
        output.TextureCoord = input.TextureCoord;
        return output;
    }

    public void DoInt(int val)
    {
        DoInt2(val);
    }

    public int DoInt2(int val)
    {
        return GetInt();
    }

    public int GetInt()
    {
        return 0;
    }

    public void DoSome()
    {
        DoInt2(0);
        GetInt();
        DoInt(DoInt2(DoInt2(0)));
    }


    private struct TestStruct
    {
        public float vall;
        public float Value
        {
            get
            {
                return GetValue() + GetValue2();
            }
            set
            {
                vall = value;
            }
        }
        public void Increment()
        {
            vall = Value + GetValue();
        }

        public TestStruct()
        {
            Value = 0;
            Increment();
        }
    }

    private static int GetValue()
    {
        return 3 + GetValue2();
    }
    private static int GetValue2()
    {
        return 3;
    }


    [FragmentEntryPoint]
    public Vector4 FragmentShaderFunc(FragmentInput input)
    {
        return Sample(SurfaceTexture, Sampler, input.TextureCoord);
    }
}
