﻿using GLSH.Primitives;
using GLSH.Primitives.Attributes;
using GLSH.Primitives.Attributes.New;
using System.Numerics;
using static GLSH.Primitives.ShaderBuiltins;

namespace Runner.Some.StupidNamespace;

//[GraphicsPipeline(nameof(NewTestShader))]
internal class NewTestShader
{
    [Layout(set: 0, binding: 0)] Matrix4x4 Projection;
    [Layout(set: 0, binding: 1)] Matrix4x4 View;
    [Layout(set: 0, binding: 2)] Matrix4x4 World;
    [Layout(set: 1, binding: 0)] Texture2DResource SurfaceTexture;
    [Layout(set: 1, binding: 1)] SamplerResource Sampler;

    public struct VertexInput
    {
        [VertexSemantic(SemanticType.Position)][Layout(location: 0)] public Vector3 Position;
        [VertexSemantic(SemanticType.TextureCoordinate)][Layout(location: 1)] public Vector2 TextureCoord;
    }

    public struct FragmentInput
    {
        [VertexSemantic(SemanticType.SystemPosition)][Layout(location: 0)] public Vector4 Position;
        [VertexSemantic(SemanticType.TextureCoordinate)][Layout(location: 1)] public Vector2 TextureCoord;
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
