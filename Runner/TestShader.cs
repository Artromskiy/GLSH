using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Runner.Some.StupidNamespace;

[GraphicsPipeline(nameof(MinExample))]
public class MinExample
{
    public Matrix4x4 Projection;
    public Matrix4x4 View;
    public Matrix4x4 World;
    public Texture2DResource SurfaceTexture;
    public SamplerResource Sampler;

    public struct VertexInput
    {
        [VertexSemantic(SemanticType.Position)] public Vector3 Position;
        [VertexSemantic(SemanticType.TextureCoordinate)] public Vector2 TextureCoord;
    }

    public struct FragmentInput
    {
        [VertexSemantic(SemanticType.SystemPosition)] public Vector4 Position;
        [VertexSemantic(SemanticType.TextureCoordinate)] public Vector2 TextureCoord;
    }

    [VertexEntryPoint]
    public FragmentInput VertexShaderFunc(VertexInput input)
    {
        FragmentInput output;
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
