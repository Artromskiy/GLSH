using GLSH.Primitives;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace GLSH.Glsl;

public static class GlslKnownIdentifiers
{
    private static readonly Dictionary<string, Dictionary<string, string>> s_mappings = GetMappings();
    private static readonly Dictionary<string, string> builtinMappings = new(){
    { nameof(ShaderBuiltins.E), "2.71828182845905" },
    { nameof(ShaderBuiltins.PI), "3.14159265358979" },
    { nameof(ShaderBuiltins.DegreesPerRadian), "57.2957795130823" },};
    private static readonly Dictionary<string, string> v2Mappings = new(){
    { nameof(Vector2.X), "x" },
    { nameof(Vector2.Y), "y" },};
    private static readonly Dictionary<string, string> v3Mappings = new(){
    { nameof(Vector3.X), "x" },
    { nameof(Vector3.Y), "y" },
    { nameof(Vector3.Z), "z" },};
    private static readonly Dictionary<string, string> v4Mappings = new(){
    { nameof(Vector4.X), "x" },
    { nameof(Vector4.Y), "y" },
    { nameof(Vector4.Z), "z" },
    { nameof(Vector4.W), "w" },};
    private static readonly Dictionary<string, string> m4x4Mappings = new(){
    { nameof(Matrix4x4.M11), "[0][0]" },
    { nameof(Matrix4x4.M12), "[1][0]" },
    { nameof(Matrix4x4.M13), "[2][0]" },
    { nameof(Matrix4x4.M14), "[3][0]" },
    { nameof(Matrix4x4.M21), "[0][1]" },
    { nameof(Matrix4x4.M22), "[1][1]" },
    { nameof(Matrix4x4.M23), "[2][1]" },
    { nameof(Matrix4x4.M24), "[3][1]" },
    { nameof(Matrix4x4.M31), "[0][2]" },
    { nameof(Matrix4x4.M32), "[1][2]" },
    { nameof(Matrix4x4.M33), "[2][2]" },
    { nameof(Matrix4x4.M34), "[3][2]" },
    { nameof(Matrix4x4.M41), "[0][3]" },
    { nameof(Matrix4x4.M42), "[1][3]" },
    { nameof(Matrix4x4.M43), "[2][3]" },
    { nameof(Matrix4x4.M44), "[3][3]" },};
    private static readonly Dictionary<string, string> uint2Mappings = new(){
    { nameof(UInt2.X), "x" },
    { nameof(UInt2.Y), "y" },};
    private static readonly Dictionary<string, string> uint3Mappings = new(){
    { nameof(UInt3.X), "x" },
    { nameof(UInt3.Y), "y" },
    { nameof(UInt3.Z), "z" },};
    private static readonly Dictionary<string, string> uint4Mappings = new(){
    { nameof(UInt4.X), "x" },
    { nameof(UInt4.Y), "y" },
    { nameof(UInt4.Z), "z" },
    { nameof(UInt4.W), "w" },};
    private static readonly Dictionary<string, string> int2Mappings = new(){
    { nameof(Int2.X), "x" },
    { nameof(Int2.Y), "y" },};
    private static readonly Dictionary<string, string> int3Mappings = new(){
    { nameof(Int3.X), "x" },
    { nameof(Int3.Y), "y" },
    { nameof(Int3.Z), "z" },};
    private static readonly Dictionary<string, string> int4Mappings = new(){
    { nameof(Int4.X), "x" },
    { nameof(Int4.Y), "y" },
    { nameof(Int4.Z), "z" },
    { nameof(Int4.W), "w" },};
    private static readonly Dictionary<string, string> mathfMappings = new(){
    // TODO Note MathF is not included in .Net Standard
    { "E", "2.71828182845905" },
    { "PI", "3.14159265358979" },};

    private static Dictionary<string, Dictionary<string, string>> GetMappings()
    {

        Dictionary<string, Dictionary<string, string>> ret = [];
        ret.Add(typeof(ShaderBuiltins).FullName!, builtinMappings);
        ret.Add(typeof(Vector2).FullName!, v2Mappings);
        ret.Add(typeof(Vector3).FullName!, v3Mappings);
        ret.Add(typeof(Vector4).FullName!, v4Mappings);
        ret.Add(typeof(Matrix4x4).FullName!, m4x4Mappings);
        ret.Add(typeof(UInt2).FullName!, uint2Mappings);
        ret.Add(typeof(UInt3).FullName!, uint3Mappings);
        ret.Add(typeof(UInt4).FullName!, uint4Mappings);
        ret.Add(typeof(Int2).FullName!, int2Mappings);
        ret.Add(typeof(Int3).FullName!, int3Mappings);
        ret.Add(typeof(Int4).FullName!, int4Mappings);
        ret.Add(typeof(MathF).FullName!, mathfMappings);

        return ret;
    }

    public static string GetMappedIdentifier(string type, string identifier)
    {
        if (s_mappings.TryGetValue(type, out var dict) && dict.TryGetValue(identifier, out string mappedValue))
            return mappedValue;

        return identifier;
    }
}
