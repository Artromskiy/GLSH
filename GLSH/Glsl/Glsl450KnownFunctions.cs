using GLSH.Compiler.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace GLSH.Compiler.Glsl;

[Obsolete("Rewrite this hell")]
public static class Glsl450KnownFunctions
{
    private static readonly Dictionary<string, TypeInvocationTranslator> s_mappings = GetMappings();

    private static Dictionary<string, TypeInvocationTranslator> GetMappings()
    {
        Dictionary<string, TypeInvocationTranslator> ret = [];

        Dictionary<string, InvocationTranslator> builtinMappings = new()
        {
            { nameof(ShaderBuiltins.Abs), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Acos), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Acosh), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Asin), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Asinh), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Atan), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Atanh), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Cbrt), CubeRoot },
            { nameof(ShaderBuiltins.Ceiling), SimpleNameTranslator("ceil") },
            { nameof(ShaderBuiltins.Clamp), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.ClipToTextureCoordinates), ClipToTextureCoordinates },
            { nameof(ShaderBuiltins.Cos), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Cosh), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Degrees), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Ddx), SimpleNameTranslator("dFdx") },
            { nameof(ShaderBuiltins.DdxFine), SimpleNameTranslator("dFdxFine") },
            { nameof(ShaderBuiltins.Ddy), SimpleNameTranslator("dFdy") },
            { nameof(ShaderBuiltins.DdyFine), SimpleNameTranslator("dFdyFine") },
            { nameof(ShaderBuiltins.Discard), Discard },
            { nameof(ShaderBuiltins.DispatchThreadID), DispatchThreadID },
            { nameof(ShaderBuiltins.Exp), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Exp2), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Floor), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.FMod), FMod },
            { nameof(ShaderBuiltins.Frac), SimpleNameTranslator("fract") },
            { nameof(ShaderBuiltins.GroupThreadID), GroupThreadID },
            { nameof(ShaderBuiltins.InstanceID), InstanceID },
            { nameof(ShaderBuiltins.InterlockedAdd), InterlockedAdd },
            { nameof(ShaderBuiltins.IsFrontFace), IsFrontFace },
            { nameof(ShaderBuiltins.Lerp), SimpleNameTranslator("mix") },
            { nameof(ShaderBuiltins.Load), Load },
            { nameof(ShaderBuiltins.Log), Log },
            { nameof(ShaderBuiltins.Log2), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Log10), Log10 },
            { nameof(ShaderBuiltins.Max), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Min), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Mod), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Mul), MatrixMul },
            { nameof(ShaderBuiltins.Pow), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Radians), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Round), Round },
            { nameof(ShaderBuiltins.Rsqrt), SimpleNameTranslator("inversesqrt") },
            { nameof(ShaderBuiltins.Sample), Sample },
            { nameof(ShaderBuiltins.SampleComparisonLevelZero), SampleComparisonLevelZero },
            { nameof(ShaderBuiltins.SampleGrad), SampleGrad },
            { nameof(ShaderBuiltins.Saturate), Saturate },
            { nameof(ShaderBuiltins.Sign), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Sin), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Sinh), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.SmoothStep), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Sqrt), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Step), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Store), Store },
            { nameof(ShaderBuiltins.Tan), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Tanh), SimpleNameTranslator() },
            { nameof(ShaderBuiltins.Truncate), SimpleNameTranslator("trunc") },
            { nameof(ShaderBuiltins.VertexID), VertexID }
        };
        ret.Add(typeof(ShaderBuiltins).FullName!, new DictionaryTypeInvocationTranslator(builtinMappings));

        Dictionary<string, InvocationTranslator> v2Mappings = new()
        {
            { ".ctor", VectorCtor },
            { nameof(Vector2.Abs), SimpleNameTranslator() },
            { nameof(Vector2.Add), BinaryOpTranslator("+") },
            { nameof(Vector2.Clamp), SimpleNameTranslator() },
            // Doesn't exist! { nameof(Vector2.Cos), SimpleNameTranslator("cos") },
            { nameof(Vector2.Distance), SimpleNameTranslator("distance") },
            { nameof(Vector2.DistanceSquared), DistanceSquared },
            { nameof(Vector2.Divide), BinaryOpTranslator("/") },
            { nameof(Vector2.Dot), SimpleNameTranslator() },
            { nameof(Vector2.Lerp), SimpleNameTranslator("mix") },
            { nameof(Vector2.Max), SimpleNameTranslator() },
            { nameof(Vector2.Min), SimpleNameTranslator() },
            { nameof(Vector2.Multiply), BinaryOpTranslator("*") },
            { nameof(Vector2.Negate), Negate },
            { nameof(Vector2.Normalize), SimpleNameTranslator() },
            { nameof(Vector2.Reflect), SimpleNameTranslator() },
            // Doesn't exist! { nameof(Vector2.Sin), SimpleNameTranslator("sin") },
            { nameof(Vector2.SquareRoot), SimpleNameTranslator("sqrt") },
            { nameof(Vector2.Subtract), BinaryOpTranslator("-") },
            { nameof(Vector2.Length), SimpleNameTranslator() },
            { nameof(Vector2.LengthSquared), LengthSquared },
            { nameof(Vector2.Zero), VectorStaticAccessor },
            { nameof(Vector2.One), VectorStaticAccessor },
            { nameof(Vector2.UnitX), VectorStaticAccessor },
            { nameof(Vector2.UnitY), VectorStaticAccessor },
            { nameof(Vector2.Transform), Vector2Transform }
        };
        ret.Add(typeof(Vector2).FullName!, new DictionaryTypeInvocationTranslator(v2Mappings));

        Dictionary<string, InvocationTranslator> v3Mappings = new()
        {
            { ".ctor", VectorCtor },
            { nameof(Vector3.Abs), SimpleNameTranslator() },
            { nameof(Vector3.Add), BinaryOpTranslator("+") },
            { nameof(Vector3.Clamp), SimpleNameTranslator() },
            // Doesn't exist! { nameof(Vector3.Cos), SimpleNameTranslator("cos") },
            { nameof(Vector3.Cross), SimpleNameTranslator() },
            { nameof(Vector3.Distance), SimpleNameTranslator() },
            { nameof(Vector3.DistanceSquared), DistanceSquared },
            { nameof(Vector3.Divide), BinaryOpTranslator("/") },
            { nameof(Vector3.Dot), SimpleNameTranslator() },
            { nameof(Vector3.Lerp), SimpleNameTranslator("mix") },
            { nameof(Vector3.Max), SimpleNameTranslator() },
            { nameof(Vector3.Min), SimpleNameTranslator() },
            { nameof(Vector3.Multiply), BinaryOpTranslator("*") },
            { nameof(Vector3.Negate), Negate },
            { nameof(Vector3.Normalize), SimpleNameTranslator() },
            { nameof(Vector3.Reflect), SimpleNameTranslator() },
            // Doesn't exist! { nameof(Vector3.Sin), SimpleNameTranslator("sin") },
            { nameof(Vector3.SquareRoot), SimpleNameTranslator("sqrt") },
            { nameof(Vector3.Subtract), BinaryOpTranslator("-") },
            { nameof(Vector3.Length), SimpleNameTranslator() },
            { nameof(Vector3.LengthSquared), LengthSquared },
            { nameof(Vector3.Zero), VectorStaticAccessor },
            { nameof(Vector3.One), VectorStaticAccessor },
            { nameof(Vector3.UnitX), VectorStaticAccessor },
            { nameof(Vector3.UnitY), VectorStaticAccessor },
            { nameof(Vector3.UnitZ), VectorStaticAccessor },
            { nameof(Vector3.Transform), Vector3Transform }
        };
        ret.Add(typeof(Vector3).FullName!, new DictionaryTypeInvocationTranslator(v3Mappings));

        Dictionary<string, InvocationTranslator> v4Mappings = new()
        {
            { ".ctor", VectorCtor },
            { nameof(Vector4.Abs), SimpleNameTranslator() },
            { nameof(Vector4.Add), BinaryOpTranslator("+") },
            { nameof(Vector4.Clamp), SimpleNameTranslator() },
            // Doesn't exist! { nameof(Vector4.Cos), SimpleNameTranslator("cos") },
            { nameof(Vector4.Distance), SimpleNameTranslator() },
            { nameof(Vector4.DistanceSquared), DistanceSquared },
            { nameof(Vector4.Divide), BinaryOpTranslator("/") },
            { nameof(Vector4.Dot), SimpleNameTranslator() },
            { nameof(Vector4.Lerp), SimpleNameTranslator("mix") },
            { nameof(Vector4.Max), SimpleNameTranslator() },
            { nameof(Vector4.Min), SimpleNameTranslator() },
            { nameof(Vector4.Multiply), BinaryOpTranslator("*") },
            { nameof(Vector4.Negate), Negate },
            { nameof(Vector4.Normalize), SimpleNameTranslator() },
            // Doesn't exist! { nameof(Vector4.Reflect), SimpleNameTranslator("reflect") },
            // Doesn't exist! { nameof(Vector4.Sin), SimpleNameTranslator("sin") },
            { nameof(Vector4.SquareRoot), SimpleNameTranslator("sqrt") },
            { nameof(Vector4.Subtract), BinaryOpTranslator("-") },
            { nameof(Vector4.Length), SimpleNameTranslator() },
            { nameof(Vector4.LengthSquared), LengthSquared },
            { nameof(Vector4.Zero), VectorStaticAccessor },
            { nameof(Vector4.One), VectorStaticAccessor },
            { nameof(Vector4.UnitX), VectorStaticAccessor },
            { nameof(Vector4.UnitY), VectorStaticAccessor },
            { nameof(Vector4.UnitZ), VectorStaticAccessor },
            { nameof(Vector4.UnitW), VectorStaticAccessor },
            { nameof(Vector4.Transform), Vector4Transform }
        };
        ret.Add(typeof(Vector4).FullName!, new DictionaryTypeInvocationTranslator(v4Mappings));

        Dictionary<string, InvocationTranslator> u2Mappings = new()
        {
            { ".ctor", VectorCtor },
        };
        ret.Add(typeof(UInt2).FullName!, new DictionaryTypeInvocationTranslator(u2Mappings));
        ret.Add(typeof(Int2).FullName!, new DictionaryTypeInvocationTranslator(u2Mappings));

        Dictionary<string, InvocationTranslator> m4x4Mappings = new()
        {
            { ".ctor", MatrixCtor }
        };
        ret.Add(typeof(Matrix4x4).FullName!, new DictionaryTypeInvocationTranslator(m4x4Mappings));

        Dictionary<string, InvocationTranslator> mathfMappings = new()
        {
            // TODO Note cannot use nameof as MathF isn't included in this project...
            { "Abs", SimpleNameTranslator() },
            { "Acos", SimpleNameTranslator() },
            { "Acosh", SimpleNameTranslator() },
            { "Asin", SimpleNameTranslator() },
            { "Asinh", SimpleNameTranslator() },
            { "Atan", SimpleNameTranslator() },
            { "Atan2", SimpleNameTranslator("atan") }, // Note atan supports both (x) and (y,x)
            { "Atanh", SimpleNameTranslator() },
            { "Cbrt", CubeRoot }, // We can calculate the 1/3rd power, which might not give exactly the same result?
            { "Ceiling", SimpleNameTranslator("ceil") },
            { "Cos", SimpleNameTranslator() },
            { "Cosh", SimpleNameTranslator() },
            { "Exp", SimpleNameTranslator() },
            { "Floor", SimpleNameTranslator() },
            // TODO IEEERemainder(Single, Single) - see https://stackoverflow.com/questions/1971645/is-math-ieeeremainderx-y-equivalent-to-xy
            // How close is it to frac()?
            { "Log", Log },
            { "Log10", Log10 },
            { "Max", SimpleNameTranslator() },
            { "Min", SimpleNameTranslator() },
            { "Pow", SimpleNameTranslator() },
            { "Round", Round },
            { "Sin", SimpleNameTranslator() },
            { "Sinh", SimpleNameTranslator() },
            { "Sqrt", SimpleNameTranslator() },
            { "Tan", SimpleNameTranslator() },
            { "Tanh", SimpleNameTranslator() },
            { "Truncate", SimpleNameTranslator() }
        };
        ret.Add(typeof(MathF).FullName!, new DictionaryTypeInvocationTranslator(mathfMappings));

        ret.Add(typeof(ShaderSwizzle).FullName!, new SwizzleTranslator());

        Dictionary<string, InvocationTranslator> vectorExtensionMappings = new()
        {
            { nameof(VectorExtensions.GetComponent), VectorGetComponent },
            { nameof(VectorExtensions.SetComponent), VectorSetComponent },
        };
        ret.Add(typeof(VectorExtensions).FullName!, new DictionaryTypeInvocationTranslator(vectorExtensionMappings));

        return ret;
    }

    private static string MatrixCtor(string typeName, string methodName, InvocationParameterInfo[] p)
    {
        string paramList = string.Join(", ",
            p[0].identifier, p[4].identifier, p[8].identifier, p[12].identifier,
            p[1].identifier, p[5].identifier, p[9].identifier, p[13].identifier,
            p[2].identifier, p[6].identifier, p[10].identifier, p[14].identifier,
            p[3].identifier, p[7].identifier, p[11].identifier, p[15].identifier);

        return $"mat4({paramList})";
    }

    private static string VectorGetComponent(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"{parameters[0].identifier}[{parameters[1].identifier}]";
    }

    private static string VectorSetComponent(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"{parameters[0].identifier}[{parameters[1].identifier}] = {parameters[2].identifier}";
    }

    public static string TranslateInvocation(string type, string method, InvocationParameterInfo[] parameters)
    {
        if (s_mappings.TryGetValue(type, out var dict))
        {
            if (dict.GetTranslator(method, parameters, out var mappedValue))
            {
                return mappedValue(type, method, parameters);
            }
        }

        throw new ShaderGenerationException($"Reference to unknown function: {type}.{method}");
    }

    private static InvocationTranslator SimpleNameTranslator(string nameTarget = null)
    {
        return (type, method, parameters) =>
        {
            return $"{nameTarget ?? method.ToLower()}({InvocationParameterInfo.FormatParameters(parameters)})";
        };
    }

    private static string LengthSquared(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"dot({parameters[0].identifier}, {parameters[0].identifier})";
    }

    private static string Negate(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"-{parameters[0].identifier}";
    }

    private static string DistanceSquared(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"dot({parameters[0].identifier} - {parameters[1].identifier}, {parameters[0].identifier} - {parameters[1].identifier})";
    }

    private static InvocationTranslator BinaryOpTranslator(string op)
    {
        return (type, method, parameters) =>
        {
            return $"{parameters[0].identifier} {op} {parameters[1].identifier}";
        };
    }

    private static string MatrixMul(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"{parameters[0].identifier} * {parameters[1].identifier}";
    }

    private static string Sample(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        if (parameters[0].fullTypeName == typeof(Texture2DResource).FullName)
        {
            return $"texture(sampler2D({parameters[0].identifier}, {parameters[1].identifier}), {parameters[2].identifier})";
        }
        else if (parameters[0].fullTypeName == typeof(Texture2DArrayResource).FullName)
        {
            return $"texture(sampler2DArray({parameters[0].identifier}, {parameters[1].identifier}), vec3({parameters[2].identifier}, {parameters[3].identifier}))";
        }
        else if (parameters[0].fullTypeName == typeof(TextureCubeResource).FullName)
        {
            return $"texture(samplerCube({parameters[0].identifier}, {parameters[1].identifier}), {parameters[2].identifier})";
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private static string SampleGrad(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        if (parameters[0].fullTypeName == typeof(Texture2DResource).FullName)
        {
            return $"textureGrad(sampler2D({parameters[0].identifier}, {parameters[1].identifier}), {parameters[2].identifier}, {parameters[3].identifier}, {parameters[4].identifier})";
        }
        else if (parameters[0].fullTypeName == typeof(Texture2DArrayResource).FullName)
        {
            return $"textureGrad(sampler2DArray({parameters[0].identifier}, {parameters[1].identifier}), vec3({parameters[2].identifier}, {parameters[3].identifier}), {parameters[4].identifier}, {parameters[5].identifier})";
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private static string SampleComparisonLevelZero(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        if (parameters[0].fullTypeName == typeof(DepthTexture2DResource).FullName!)
        {
            return $"textureLod(sampler2DShadow({parameters[0].identifier}, {parameters[1].identifier}), vec3({parameters[2].identifier}, {parameters[3].identifier}), 0.0)";
        }
        else if (parameters[0].fullTypeName == typeof(DepthTexture2DArrayResource).FullName!)
        {
            // See https://github.com/KhronosGroup/SPIRV-Cross/issues/207 for why we need to use textureGrad here instead of textureLod.
            return $"textureGrad(sampler2DArrayShadow({parameters[0].identifier}, {parameters[1].identifier}), vec4({parameters[2].identifier}, {parameters[3].identifier}, {parameters[4].identifier}), vec2(0.0), vec2(0.0))";
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private static string Load(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        if (parameters[0].fullTypeName.Contains("RWTexture2D"))
        {
            if (parameters[0].fullTypeName.Contains("<float>"))
            {
                return $"imageLoad({parameters[0].identifier}, ivec2({parameters[1].identifier})).r";
            }
            else
            {
                return $"imageLoad({parameters[0].identifier}, ivec2({parameters[1].identifier}))";
            }
        }
        else if (parameters[0].fullTypeName == typeof(Texture2DResource).FullName!)
        {
            return $"texelFetch(sampler2D({parameters[0].identifier}, {parameters[1].identifier}), ivec2({parameters[2].identifier}), {parameters[3].identifier})";
        }
        else
        {
            return $"texelFetch(sampler2DMS({parameters[0].identifier}, {parameters[1].identifier}), ivec2({parameters[2].identifier}), {parameters[3].identifier})";
        }
    }

    private static string Store(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        if (parameters[0].fullTypeName.Contains("<float>"))
        {
            return $"imageStore({parameters[0].identifier}, ivec2({parameters[1].identifier}), vec4({parameters[2].identifier}))";
        }
        else
        {
            return $"imageStore({parameters[0].identifier}, ivec2({parameters[1].identifier}), {parameters[2].identifier})";
        }
    }

    private static string Discard(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"discard";
    }

    private static string Saturate(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        if (parameters.Length == 1)
        {
            return $"clamp({parameters[0].identifier}, 0, 1)";
        }
        else
        {
            throw new ShaderGenerationException("Unhandled number of arguments to ShaderBuiltins.Discard.");
        }
    }

    private static string ClipToTextureCoordinates(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        string target = parameters[0].identifier;
        return $"vec2(({target}.x / {target}.w) / 2 + 0.5, ({target}.y / {target}.w) / -2 + 0.5)";
    }

    private static string VertexID(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return "gl_VertexIndex";
    }

    private static string InstanceID(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return "gl_InstanceIndex";
    }

    private static string DispatchThreadID(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return "gl_GlobalInvocationID";
    }

    private static string GroupThreadID(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return "gl_LocalInvocationID";
    }

    private static string IsFrontFace(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return "gl_FrontFacing";
    }

    private static string InterlockedAdd(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"atomicAdd({parameters[0].identifier}[{parameters[1].identifier}], {parameters[2].identifier})";
    }

    private static string VectorCtor(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        GetVectorTypeInfo(typeName, out string shaderType, out int elementCount);
        string paramList;
        if (parameters.Length == 0)
        {
            paramList = string.Join(", ", Enumerable.Repeat("0", elementCount));
        }
        else if (parameters.Length == 1)
        {
            paramList = string.Join(", ", Enumerable.Repeat(parameters[0].identifier, elementCount));
        }
        else
        {
            StringBuilder sb = new();
            for (int i = 0; i < parameters.Length; i++)
            {
                InvocationParameterInfo ipi = parameters[i];
                sb.Append(ipi.identifier);

                if (i != parameters.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            paramList = sb.ToString();
        }

        return $"{shaderType}({paramList})";
    }

    private static string VectorStaticAccessor(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        Debug.Assert(parameters.Length == 0);
        GetVectorTypeInfo(typeName, out string shaderType, out int elementCount);
        if (methodName == "Zero")
        {
            return $"{shaderType}({string.Join(", ", Enumerable.Repeat("0", elementCount))})";
        }
        else if (methodName == "One")
        {
            return $"{shaderType}({string.Join(", ", Enumerable.Repeat("1", elementCount))})";
        }
        else if (methodName == "UnitX")
        {
            string paramList;
            if (elementCount == 2) { paramList = "1, 0"; }
            else if (elementCount == 3) { paramList = "1, 0, 0"; }
            else { paramList = "1, 0, 0, 0"; }
            return $"{shaderType}({paramList})";
        }
        else if (methodName == "UnitY")
        {
            string paramList;
            if (elementCount == 2) { paramList = "0, 1"; }
            else if (elementCount == 3) { paramList = "0, 1, 0"; }
            else { paramList = "0, 1, 0, 0"; }
            return $"{shaderType}({paramList})";
        }
        else if (methodName == "UnitZ")
        {
            string paramList;
            if (elementCount == 3) { paramList = "0, 0, 1"; }
            else { paramList = "0, 0, 1, 0"; }
            return $"{shaderType}({paramList})";
        }
        else if (methodName == "UnitW")
        {
            return $"{shaderType}(0, 0, 0, 1)";
        }
        else
        {
            Debug.Fail("Invalid static vector accessor: " + methodName);
            return null;
        }
    }

    private static string Vector2Transform(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"({parameters[1].identifier} * vec4({parameters[0].identifier}, 0, 1)).xy";
    }

    private static string Vector3Transform(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        return $"({parameters[1].identifier} * vec4({parameters[0].identifier}, 1)).xyz";
    }

    private static string Vector4Transform(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        string vecParam;
        if (parameters[0].fullTypeName == typeof(Vector2).FullName!)
        {
            vecParam = $"vec4({parameters[0].identifier}, 0, 1)";
        }
        else if (parameters[0].fullTypeName == typeof(Vector3).FullName!)
        {
            vecParam = $"vec4({parameters[0].identifier}, 1)";
        }
        else
        {
            vecParam = parameters[0].identifier;
        }

        return $"{parameters[1].identifier} * {vecParam}";
    }

    private static void GetVectorTypeInfo(string name, out string shaderType, out int elementCount)
    {
        if (name == typeof(Vector2).FullName!) { shaderType = "vec2"; elementCount = 2; }
        else if (name == typeof(Vector3).FullName!) { shaderType = "vec3"; elementCount = 3; }
        else if (name == typeof(Vector4).FullName!) { shaderType = "vec4"; elementCount = 4; }
        else if (name == typeof(Int2).FullName!) { shaderType = "ivec2"; elementCount = 2; }
        else if (name == typeof(UInt2).FullName!) { shaderType = "uvec2"; elementCount = 2; }
        else { throw new ShaderGenerationException("VectorCtor translator was called on an invalid type: " + name); }
    }

    private static string CubeRoot(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        string pType = parameters[0].fullTypeName;
        if (pType == typeof(float).FullName! || pType == "float") // TODO Why are we getting float?
        {
            return $"pow({parameters[0].identifier}, 0.333333333333333)";
        }

        GetVectorTypeInfo(pType, out string shaderType, out int elementCount);
        // TODO All backends but Vulkan return NaN for Cbrt of a -ve number...
        return
            $"pow({parameters[0].identifier}, {shaderType}({string.Join(",", Enumerable.Range(0, elementCount).Select(i => "0.333333333333333"))}))";
    }

    private static string Log(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        if (parameters.Length < 2)
        {
            return $"log({parameters[0].identifier})";
        }

        // TODO Get computed constant value for parameter 2 rather than simple string
        string param2 = parameters[1].identifier;
        if (float.TryParse(param2, out float @base))
        {
            if (Math.Abs(@base - 2f) < float.Epsilon)
            {
                return $"log2({parameters[0].identifier})";
            }

            if (Math.Abs(@base - Math.E) < float.Epsilon)
            {
                return $"log({parameters[0].identifier})";
            }
        }

        return $"(log({parameters[0].identifier})/log({parameters[1].identifier}))";
    }

    private static string Log10(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        // Divide by Log(10) = 2.30258509299405 as OpenGL doesn't suppport log10 natively
        return $"(log({parameters[0].identifier})/2.30258509299405)";
    }

    private static string Round(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        // TODO Should we use RoundEven here for safety??
        if (parameters.Length < 2)
        {
            return $"round({parameters[0].identifier})";
        }

        // TODO Need to Implement to support MathF fully
        // Round(Single, Int32)
        // Round(Single, Int32, MidpointRounding)
        // Round(Single, MidpointRounding)
        throw new NotImplementedException();
    }

    private static string FMod(string typeName, string methodName, InvocationParameterInfo[] parameters)
    {
        // D3D & Vulkan return Max when max < min, but OpenGL returns Min, so we need
        // to correct by returning Max when max < min.
        bool isFloat = parameters[1].fullTypeName == typeof(float).FullName! || parameters[1].fullTypeName == "float";
        string p0 = $"{parameters[0].identifier}`";
        string p1 = $"{parameters[1].identifier}{(isFloat ? string.Empty : "`")}";
        return AddCheck(parameters[0].fullTypeName,
            $"({p0}-{p1}*trunc({p0}/{p1}))");
    }

    private static readonly string[] _vectorAccessors = { "x", "y", "z", "w" };

    private static readonly HashSet<string> _oneDimensionalTypes =
        new(new[]
            {
                typeof(float).FullName!,
                "float",
                typeof(int).FullName!,
                "int",
                typeof(uint).FullName!,
                "uint"
            },
            StringComparer.InvariantCultureIgnoreCase);

    /// <summary>
    /// Implements a check for each element of a vector.
    /// </summary>
    /// <param name="typeName">Name of the type.</param>
    /// <param name="check">The check.</param>
    /// <returns></returns>
    private static string AddCheck(string typeName, string check)
    {
        if (_oneDimensionalTypes.Contains(typeName))
        {
            // The check can stay as it is, strip the '`' characters.
            return check.Replace("`", string.Empty);
        }

        GetVectorTypeInfo(typeName, out string shaderType, out int elementCount);
        return
            $"{shaderType}({string.Join(",", _vectorAccessors.Take(elementCount).Select(a => check.Replace("`", "." + a)))})";
    }
}
