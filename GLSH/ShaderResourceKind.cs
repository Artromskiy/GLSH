namespace GLSH.Compiler;

public enum ShaderResourceKind
{
    Uniform,
    Texture2D,
    Texture2DArray,
    TextureCube,
    Texture2DMS,
    Sampler,
    StructuredBuffer,
    RWStructuredBuffer,
    RWTexture2D,
    SamplerComparison,
    DepthTexture2D,
    DepthTexture2DArray,
    AtomicBuffer,
}


public static class ShaderResourceKindExtensions
{
    public static bool IsGenericResource(this ShaderResourceKind kind) =>
            kind == ShaderResourceKind.StructuredBuffer ||
            kind == ShaderResourceKind.RWStructuredBuffer ||
            kind == ShaderResourceKind.RWTexture2D;

    public static bool NeedsForceTypeDiscovery(this ShaderResourceKind kind) =>
            kind == ShaderResourceKind.Uniform ||
            kind == ShaderResourceKind.RWStructuredBuffer ||
            kind == ShaderResourceKind.StructuredBuffer;
}