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

        //bool4 b = new(true);
        //b = bool4.Mix(b, b, b);
        float4x4 model;

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
}
