using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Numerics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace GLSH
{
    public static class GLSHInfo
    {
        public static readonly HashSet<string> knownTypes = new HashSet<string>()
        {
            typeof(int2).FullName!,
            typeof(int3).FullName!,
            typeof(int4).FullName!,
            typeof(uint2).FullName!,
            typeof(uint3).FullName!,
            typeof(uint4).FullName!,
            typeof(float2).FullName!,
            typeof(float3).FullName!,
            typeof(float4).FullName!,
            typeof(double2).FullName!,
            typeof(double3).FullName!,
            typeof(double4).FullName!,
            typeof(bool2).FullName!,
            typeof(bool3).FullName!,
            typeof(bool4).FullName!,
            typeof(float2x2).FullName!,
            typeof(float3x2).FullName!,
            typeof(float4x2).FullName!,
            typeof(float2x3).FullName!,
            typeof(float3x3).FullName!,
            typeof(float4x3).FullName!,
            typeof(float2x4).FullName!,
            typeof(float3x4).FullName!,
            typeof(float4x4).FullName!,
            typeof(double2x2).FullName!,
            typeof(double3x2).FullName!,
            typeof(double4x2).FullName!,
            typeof(double2x3).FullName!,
            typeof(double3x3).FullName!,
            typeof(double4x3).FullName!,
            typeof(double2x4).FullName!,
            typeof(double3x4).FullName!,
            typeof(double4x4).FullName!,
        };
        public static readonly Dictionary<string, string> knownTypesToGlslTypes = new Dictionary<string, string>()
        {
            {typeof(int2).FullName!, "ivec2"},
            {typeof(int3).FullName!, "ivec3"},
            {typeof(int4).FullName!, "ivec4"},
            {typeof(uint2).FullName!, "uvec2"},
            {typeof(uint3).FullName!, "uvec3"},
            {typeof(uint4).FullName!, "uvec4"},
            {typeof(float2).FullName!, "vec2"},
            {typeof(float3).FullName!, "vec3"},
            {typeof(float4).FullName!, "vec4"},
            {typeof(double2).FullName!, "dvec2"},
            {typeof(double3).FullName!, "dvec3"},
            {typeof(double4).FullName!, "dvec4"},
            {typeof(bool2).FullName!, "bvec2"},
            {typeof(bool3).FullName!, "bvec3"},
            {typeof(bool4).FullName!, "bvec4"},
            {typeof(float2x2).FullName!, "mat2"},
            {typeof(float3x2).FullName!, "mat3x2"},
            {typeof(float4x2).FullName!, "mat4x2"},
            {typeof(float2x3).FullName!, "mat2x3"},
            {typeof(float3x3).FullName!, "mat3"},
            {typeof(float4x3).FullName!, "mat4x3"},
            {typeof(float2x4).FullName!, "mat2x4"},
            {typeof(float3x4).FullName!, "mat3x4"},
            {typeof(float4x4).FullName!, "mat4"},
            {typeof(double2x2).FullName!, "dmat2"},
            {typeof(double3x2).FullName!, "dmat3x2"},
            {typeof(double4x2).FullName!, "dmat4x2"},
            {typeof(double2x3).FullName!, "dmat2x3"},
            {typeof(double3x3).FullName!, "dmat3"},
            {typeof(double4x3).FullName!, "dmat4x3"},
            {typeof(double2x4).FullName!, "dmat2x4"},
            {typeof(double3x4).FullName!, "dmat3x4"},
            {typeof(double4x4).FullName!, "dmat4"},
        };
        private static readonly Dictionary<string, string> knownint2Functions = new Dictionary<string, string>()
        {
            {nameof(int2.LesserThan), "lessThan"},
            {nameof(int2.LesserThanEqual), "lessThanEqual"},
            {nameof(int2.GreaterThan), "greaterThan"},
            {nameof(int2.GreaterThanEqual), "greaterThanEqual"},
            {nameof(int2.Equal), "equal"},
            {nameof(int2.NotEqual), "notEqual"},
            {nameof(int2.Abs), "abs"},
            {nameof(int2.Sign), "sign"},
            {nameof(int2.Min), "min"},
            {nameof(int2.Max), "max"},
            {nameof(int2.Clamp), "clamp"},
            {nameof(int2.Mix), "mix"},
            {nameof(int2.IntBitsToFloat), "intBitsToFloat"},
        };
        private static readonly Dictionary<string, string> knownint3Functions = new Dictionary<string, string>()
        {
            {nameof(int3.LesserThan), "lessThan"},
            {nameof(int3.LesserThanEqual), "lessThanEqual"},
            {nameof(int3.GreaterThan), "greaterThan"},
            {nameof(int3.GreaterThanEqual), "greaterThanEqual"},
            {nameof(int3.Equal), "equal"},
            {nameof(int3.NotEqual), "notEqual"},
            {nameof(int3.Abs), "abs"},
            {nameof(int3.Sign), "sign"},
            {nameof(int3.Min), "min"},
            {nameof(int3.Max), "max"},
            {nameof(int3.Clamp), "clamp"},
            {nameof(int3.Mix), "mix"},
            {nameof(int3.IntBitsToFloat), "intBitsToFloat"},
        };
        private static readonly Dictionary<string, string> knownint4Functions = new Dictionary<string, string>()
        {
            {nameof(int4.LesserThan), "lessThan"},
            {nameof(int4.LesserThanEqual), "lessThanEqual"},
            {nameof(int4.GreaterThan), "greaterThan"},
            {nameof(int4.GreaterThanEqual), "greaterThanEqual"},
            {nameof(int4.Equal), "equal"},
            {nameof(int4.NotEqual), "notEqual"},
            {nameof(int4.Abs), "abs"},
            {nameof(int4.Sign), "sign"},
            {nameof(int4.Min), "min"},
            {nameof(int4.Max), "max"},
            {nameof(int4.Clamp), "clamp"},
            {nameof(int4.Mix), "mix"},
            {nameof(int4.IntBitsToFloat), "intBitsToFloat"},
        };
        private static readonly Dictionary<string, string> knownuint2Functions = new Dictionary<string, string>()
        {
            {nameof(uint2.LesserThan), "lessThan"},
            {nameof(uint2.LesserThanEqual), "lessThanEqual"},
            {nameof(uint2.GreaterThan), "greaterThan"},
            {nameof(uint2.GreaterThanEqual), "greaterThanEqual"},
            {nameof(uint2.Equal), "equal"},
            {nameof(uint2.NotEqual), "notEqual"},
            {nameof(uint2.Min), "min"},
            {nameof(uint2.Max), "max"},
            {nameof(uint2.Clamp), "clamp"},
            {nameof(uint2.Mix), "mix"},
            {nameof(uint2.UIntBitsToFloat), "uintBitsToFloat"},
        };
        private static readonly Dictionary<string, string> knownuint3Functions = new Dictionary<string, string>()
        {
            {nameof(uint3.LesserThan), "lessThan"},
            {nameof(uint3.LesserThanEqual), "lessThanEqual"},
            {nameof(uint3.GreaterThan), "greaterThan"},
            {nameof(uint3.GreaterThanEqual), "greaterThanEqual"},
            {nameof(uint3.Equal), "equal"},
            {nameof(uint3.NotEqual), "notEqual"},
            {nameof(uint3.Min), "min"},
            {nameof(uint3.Max), "max"},
            {nameof(uint3.Clamp), "clamp"},
            {nameof(uint3.Mix), "mix"},
            {nameof(uint3.UIntBitsToFloat), "uintBitsToFloat"},
        };
        private static readonly Dictionary<string, string> knownuint4Functions = new Dictionary<string, string>()
        {
            {nameof(uint4.LesserThan), "lessThan"},
            {nameof(uint4.LesserThanEqual), "lessThanEqual"},
            {nameof(uint4.GreaterThan), "greaterThan"},
            {nameof(uint4.GreaterThanEqual), "greaterThanEqual"},
            {nameof(uint4.Equal), "equal"},
            {nameof(uint4.NotEqual), "notEqual"},
            {nameof(uint4.Min), "min"},
            {nameof(uint4.Max), "max"},
            {nameof(uint4.Clamp), "clamp"},
            {nameof(uint4.Mix), "mix"},
            {nameof(uint4.UIntBitsToFloat), "uintBitsToFloat"},
        };
        private static readonly Dictionary<string, string> knownfloat2Functions = new Dictionary<string, string>()
        {
            {nameof(float2.Radians), "radians"},
            {nameof(float2.Degrees), "degrees"},
            {nameof(float2.Sin), "sin"},
            {nameof(float2.Cos), "cos"},
            {nameof(float2.Tan), "tan"},
            {nameof(float2.Asin), "asin"},
            {nameof(float2.Acos), "acos"},
            {nameof(float2.Atan), "atan"},
            {nameof(float2.Sinh), "sinh"},
            {nameof(float2.Cosh), "cosh"},
            {nameof(float2.Tanh), "tanh"},
            {nameof(float2.Asinh), "asinh"},
            {nameof(float2.Acosh), "acosh"},
            {nameof(float2.Atanh), "atanh"},
            {nameof(float2.Length), "length"},
            {nameof(float2.Distance), "distance"},
            {nameof(float2.Dot), "dot"},
            {nameof(float2.Normalize), "normalize"},
            {nameof(float2.FaceForward), "faceforward"},
            {nameof(float2.Reflect), "reflect"},
            {nameof(float2.Refract), "refract"},
            {nameof(float2.Pow), "pow"},
            {nameof(float2.Exp), "exp"},
            {nameof(float2.Log), "log"},
            {nameof(float2.Exp2), "exp2"},
            {nameof(float2.Log2), "log2"},
            {nameof(float2.Sqrt), "sqrt"},
            {nameof(float2.InverseSqrt), "inversesqrt"},
            {nameof(float2.LesserThan), "lessThan"},
            {nameof(float2.LesserThanEqual), "lessThanEqual"},
            {nameof(float2.GreaterThan), "greaterThan"},
            {nameof(float2.GreaterThanEqual), "greaterThanEqual"},
            {nameof(float2.Equal), "equal"},
            {nameof(float2.NotEqual), "notEqual"},
            {nameof(float2.Abs), "abs"},
            {nameof(float2.Sign), "sign"},
            {nameof(float2.Floor), "floor"},
            {nameof(float2.Truncate), "trunc"},
            {nameof(float2.Round), "round"},
            {nameof(float2.RoundEven), "roundEven"},
            {nameof(float2.Ceiling), "ceil"},
            {nameof(float2.Fract), "fract"},
            {nameof(float2.Mod), "mod"},
            {nameof(float2.Lerp), "mix"},
            {nameof(float2.Step), "step"},
            {nameof(float2.Smoothstep), "smoothstep"},
            {nameof(float2.IsNaN), "isnan"},
            {nameof(float2.IsInfinity), "isinf"},
            {nameof(float2.Fma), "fma"},
            {nameof(float2.Min), "min"},
            {nameof(float2.Max), "max"},
            {nameof(float2.Clamp), "clamp"},
            {nameof(float2.Mix), "mix"},
            {nameof(float2.FloatBitsToInt), "floatBitsToInt"},
            {nameof(float2.FloatBitsToUInt), "floatBitsToUint"},
        };
        private static readonly Dictionary<string, string> knownfloat3Functions = new Dictionary<string, string>()
        {
            {nameof(float3.Radians), "radians"},
            {nameof(float3.Degrees), "degrees"},
            {nameof(float3.Sin), "sin"},
            {nameof(float3.Cos), "cos"},
            {nameof(float3.Tan), "tan"},
            {nameof(float3.Asin), "asin"},
            {nameof(float3.Acos), "acos"},
            {nameof(float3.Atan), "atan"},
            {nameof(float3.Sinh), "sinh"},
            {nameof(float3.Cosh), "cosh"},
            {nameof(float3.Tanh), "tanh"},
            {nameof(float3.Asinh), "asinh"},
            {nameof(float3.Acosh), "acosh"},
            {nameof(float3.Atanh), "atanh"},
            {nameof(float3.Length), "length"},
            {nameof(float3.Distance), "distance"},
            {nameof(float3.Dot), "dot"},
            {nameof(float3.Cross), "cross"},
            {nameof(float3.Normalize), "normalize"},
            {nameof(float3.FaceForward), "faceforward"},
            {nameof(float3.Reflect), "reflect"},
            {nameof(float3.Refract), "refract"},
            {nameof(float3.Pow), "pow"},
            {nameof(float3.Exp), "exp"},
            {nameof(float3.Log), "log"},
            {nameof(float3.Exp2), "exp2"},
            {nameof(float3.Log2), "log2"},
            {nameof(float3.Sqrt), "sqrt"},
            {nameof(float3.InverseSqrt), "inversesqrt"},
            {nameof(float3.LesserThan), "lessThan"},
            {nameof(float3.LesserThanEqual), "lessThanEqual"},
            {nameof(float3.GreaterThan), "greaterThan"},
            {nameof(float3.GreaterThanEqual), "greaterThanEqual"},
            {nameof(float3.Equal), "equal"},
            {nameof(float3.NotEqual), "notEqual"},
            {nameof(float3.Abs), "abs"},
            {nameof(float3.Sign), "sign"},
            {nameof(float3.Floor), "floor"},
            {nameof(float3.Truncate), "trunc"},
            {nameof(float3.Round), "round"},
            {nameof(float3.RoundEven), "roundEven"},
            {nameof(float3.Ceiling), "ceil"},
            {nameof(float3.Fract), "fract"},
            {nameof(float3.Mod), "mod"},
            {nameof(float3.Lerp), "mix"},
            {nameof(float3.Step), "step"},
            {nameof(float3.Smoothstep), "smoothstep"},
            {nameof(float3.IsNaN), "isnan"},
            {nameof(float3.IsInfinity), "isinf"},
            {nameof(float3.Fma), "fma"},
            {nameof(float3.Min), "min"},
            {nameof(float3.Max), "max"},
            {nameof(float3.Clamp), "clamp"},
            {nameof(float3.Mix), "mix"},
            {nameof(float3.FloatBitsToInt), "floatBitsToInt"},
            {nameof(float3.FloatBitsToUInt), "floatBitsToUint"},
        };
        private static readonly Dictionary<string, string> knownfloat4Functions = new Dictionary<string, string>()
        {
            {nameof(float4.Radians), "radians"},
            {nameof(float4.Degrees), "degrees"},
            {nameof(float4.Sin), "sin"},
            {nameof(float4.Cos), "cos"},
            {nameof(float4.Tan), "tan"},
            {nameof(float4.Asin), "asin"},
            {nameof(float4.Acos), "acos"},
            {nameof(float4.Atan), "atan"},
            {nameof(float4.Sinh), "sinh"},
            {nameof(float4.Cosh), "cosh"},
            {nameof(float4.Tanh), "tanh"},
            {nameof(float4.Asinh), "asinh"},
            {nameof(float4.Acosh), "acosh"},
            {nameof(float4.Atanh), "atanh"},
            {nameof(float4.Length), "length"},
            {nameof(float4.Distance), "distance"},
            {nameof(float4.Dot), "dot"},
            {nameof(float4.Normalize), "normalize"},
            {nameof(float4.FaceForward), "faceforward"},
            {nameof(float4.Reflect), "reflect"},
            {nameof(float4.Refract), "refract"},
            {nameof(float4.Pow), "pow"},
            {nameof(float4.Exp), "exp"},
            {nameof(float4.Log), "log"},
            {nameof(float4.Exp2), "exp2"},
            {nameof(float4.Log2), "log2"},
            {nameof(float4.Sqrt), "sqrt"},
            {nameof(float4.InverseSqrt), "inversesqrt"},
            {nameof(float4.LesserThan), "lessThan"},
            {nameof(float4.LesserThanEqual), "lessThanEqual"},
            {nameof(float4.GreaterThan), "greaterThan"},
            {nameof(float4.GreaterThanEqual), "greaterThanEqual"},
            {nameof(float4.Equal), "equal"},
            {nameof(float4.NotEqual), "notEqual"},
            {nameof(float4.Abs), "abs"},
            {nameof(float4.Sign), "sign"},
            {nameof(float4.Floor), "floor"},
            {nameof(float4.Truncate), "trunc"},
            {nameof(float4.Round), "round"},
            {nameof(float4.RoundEven), "roundEven"},
            {nameof(float4.Ceiling), "ceil"},
            {nameof(float4.Fract), "fract"},
            {nameof(float4.Mod), "mod"},
            {nameof(float4.Lerp), "mix"},
            {nameof(float4.Step), "step"},
            {nameof(float4.Smoothstep), "smoothstep"},
            {nameof(float4.IsNaN), "isnan"},
            {nameof(float4.IsInfinity), "isinf"},
            {nameof(float4.Fma), "fma"},
            {nameof(float4.Min), "min"},
            {nameof(float4.Max), "max"},
            {nameof(float4.Clamp), "clamp"},
            {nameof(float4.Mix), "mix"},
            {nameof(float4.FloatBitsToInt), "floatBitsToInt"},
            {nameof(float4.FloatBitsToUInt), "floatBitsToUint"},
        };
        private static readonly Dictionary<string, string> knowndouble2Functions = new Dictionary<string, string>()
        {
            {nameof(double2.Length), "length"},
            {nameof(double2.Distance), "distance"},
            {nameof(double2.Dot), "dot"},
            {nameof(double2.Normalize), "normalize"},
            {nameof(double2.FaceForward), "faceforward"},
            {nameof(double2.Reflect), "reflect"},
            {nameof(double2.Refract), "refract"},
            {nameof(double2.Sqrt), "sqrt"},
            {nameof(double2.InverseSqrt), "inversesqrt"},
            {nameof(double2.LesserThan), "lessThan"},
            {nameof(double2.LesserThanEqual), "lessThanEqual"},
            {nameof(double2.GreaterThan), "greaterThan"},
            {nameof(double2.GreaterThanEqual), "greaterThanEqual"},
            {nameof(double2.Equal), "equal"},
            {nameof(double2.NotEqual), "notEqual"},
            {nameof(double2.Abs), "abs"},
            {nameof(double2.Sign), "sign"},
            {nameof(double2.Floor), "floor"},
            {nameof(double2.Truncate), "trunc"},
            {nameof(double2.Round), "round"},
            {nameof(double2.RoundEven), "roundEven"},
            {nameof(double2.Ceiling), "ceil"},
            {nameof(double2.Fract), "fract"},
            {nameof(double2.Mod), "mod"},
            {nameof(double2.Lerp), "mix"},
            {nameof(double2.Step), "step"},
            {nameof(double2.Smoothstep), "smoothstep"},
            {nameof(double2.IsNaN), "isnan"},
            {nameof(double2.IsInfinity), "isinf"},
            {nameof(double2.Fma), "fma"},
            {nameof(double2.Min), "min"},
            {nameof(double2.Max), "max"},
            {nameof(double2.Clamp), "clamp"},
            {nameof(double2.Mix), "mix"},
        };
        private static readonly Dictionary<string, string> knowndouble3Functions = new Dictionary<string, string>()
        {
            {nameof(double3.Length), "length"},
            {nameof(double3.Distance), "distance"},
            {nameof(double3.Dot), "dot"},
            {nameof(double3.Cross), "cross"},
            {nameof(double3.Normalize), "normalize"},
            {nameof(double3.FaceForward), "faceforward"},
            {nameof(double3.Reflect), "reflect"},
            {nameof(double3.Refract), "refract"},
            {nameof(double3.Sqrt), "sqrt"},
            {nameof(double3.InverseSqrt), "inversesqrt"},
            {nameof(double3.LesserThan), "lessThan"},
            {nameof(double3.LesserThanEqual), "lessThanEqual"},
            {nameof(double3.GreaterThan), "greaterThan"},
            {nameof(double3.GreaterThanEqual), "greaterThanEqual"},
            {nameof(double3.Equal), "equal"},
            {nameof(double3.NotEqual), "notEqual"},
            {nameof(double3.Abs), "abs"},
            {nameof(double3.Sign), "sign"},
            {nameof(double3.Floor), "floor"},
            {nameof(double3.Truncate), "trunc"},
            {nameof(double3.Round), "round"},
            {nameof(double3.RoundEven), "roundEven"},
            {nameof(double3.Ceiling), "ceil"},
            {nameof(double3.Fract), "fract"},
            {nameof(double3.Mod), "mod"},
            {nameof(double3.Lerp), "mix"},
            {nameof(double3.Step), "step"},
            {nameof(double3.Smoothstep), "smoothstep"},
            {nameof(double3.IsNaN), "isnan"},
            {nameof(double3.IsInfinity), "isinf"},
            {nameof(double3.Fma), "fma"},
            {nameof(double3.Min), "min"},
            {nameof(double3.Max), "max"},
            {nameof(double3.Clamp), "clamp"},
            {nameof(double3.Mix), "mix"},
        };
        private static readonly Dictionary<string, string> knowndouble4Functions = new Dictionary<string, string>()
        {
            {nameof(double4.Length), "length"},
            {nameof(double4.Distance), "distance"},
            {nameof(double4.Dot), "dot"},
            {nameof(double4.Normalize), "normalize"},
            {nameof(double4.FaceForward), "faceforward"},
            {nameof(double4.Reflect), "reflect"},
            {nameof(double4.Refract), "refract"},
            {nameof(double4.Sqrt), "sqrt"},
            {nameof(double4.InverseSqrt), "inversesqrt"},
            {nameof(double4.LesserThan), "lessThan"},
            {nameof(double4.LesserThanEqual), "lessThanEqual"},
            {nameof(double4.GreaterThan), "greaterThan"},
            {nameof(double4.GreaterThanEqual), "greaterThanEqual"},
            {nameof(double4.Equal), "equal"},
            {nameof(double4.NotEqual), "notEqual"},
            {nameof(double4.Abs), "abs"},
            {nameof(double4.Sign), "sign"},
            {nameof(double4.Floor), "floor"},
            {nameof(double4.Truncate), "trunc"},
            {nameof(double4.Round), "round"},
            {nameof(double4.RoundEven), "roundEven"},
            {nameof(double4.Ceiling), "ceil"},
            {nameof(double4.Fract), "fract"},
            {nameof(double4.Mod), "mod"},
            {nameof(double4.Lerp), "mix"},
            {nameof(double4.Step), "step"},
            {nameof(double4.Smoothstep), "smoothstep"},
            {nameof(double4.IsNaN), "isnan"},
            {nameof(double4.IsInfinity), "isinf"},
            {nameof(double4.Fma), "fma"},
            {nameof(double4.Min), "min"},
            {nameof(double4.Max), "max"},
            {nameof(double4.Clamp), "clamp"},
            {nameof(double4.Mix), "mix"},
        };
        private static readonly Dictionary<string, string> knownbool2Functions = new Dictionary<string, string>()
        {
            {nameof(bool2.Equal), "equal"},
            {nameof(bool2.NotEqual), "notEqual"},
            {nameof(bool2.Any), "any"},
            {nameof(bool2.All), "all"},
            {nameof(bool2.Not), "not"},
            {nameof(bool2.Mix), "mix"},
        };
        private static readonly Dictionary<string, string> knownbool3Functions = new Dictionary<string, string>()
        {
            {nameof(bool3.Equal), "equal"},
            {nameof(bool3.NotEqual), "notEqual"},
            {nameof(bool3.Any), "any"},
            {nameof(bool3.All), "all"},
            {nameof(bool3.Not), "not"},
            {nameof(bool3.Mix), "mix"},
        };
        private static readonly Dictionary<string, string> knownbool4Functions = new Dictionary<string, string>()
        {
            {nameof(bool4.Equal), "equal"},
            {nameof(bool4.NotEqual), "notEqual"},
            {nameof(bool4.Any), "any"},
            {nameof(bool4.All), "all"},
            {nameof(bool4.Not), "not"},
            {nameof(bool4.Mix), "mix"},
        };
        private static readonly Dictionary<string, string> knownfloat2x2Functions = new Dictionary<string, string>()
        {
            {nameof(float2x2.OuterProduct), "outerProduct"},
            {nameof(float2x2.Transpose), "transpose"},
            {nameof(float2x2.Determinant), "determinant"},
        };
        private static readonly Dictionary<string, string> knownfloat3x2Functions = new Dictionary<string, string>()
        {
            {nameof(float3x2.OuterProduct), "outerProduct"},
            {nameof(float3x2.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knownfloat4x2Functions = new Dictionary<string, string>()
        {
            {nameof(float4x2.OuterProduct), "outerProduct"},
            {nameof(float4x2.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knownfloat2x3Functions = new Dictionary<string, string>()
        {
            {nameof(float2x3.OuterProduct), "outerProduct"},
            {nameof(float2x3.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knownfloat3x3Functions = new Dictionary<string, string>()
        {
            {nameof(float3x3.OuterProduct), "outerProduct"},
            {nameof(float3x3.Transpose), "transpose"},
            {nameof(float3x3.Determinant), "determinant"},
        };
        private static readonly Dictionary<string, string> knownfloat4x3Functions = new Dictionary<string, string>()
        {
            {nameof(float4x3.OuterProduct), "outerProduct"},
            {nameof(float4x3.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knownfloat2x4Functions = new Dictionary<string, string>()
        {
            {nameof(float2x4.OuterProduct), "outerProduct"},
            {nameof(float2x4.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knownfloat3x4Functions = new Dictionary<string, string>()
        {
            {nameof(float3x4.OuterProduct), "outerProduct"},
            {nameof(float3x4.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knownfloat4x4Functions = new Dictionary<string, string>()
        {
            {nameof(float4x4.OuterProduct), "outerProduct"},
            {nameof(float4x4.Transpose), "transpose"},
            {nameof(float4x4.Determinant), "determinant"},
        };
        private static readonly Dictionary<string, string> knowndouble2x2Functions = new Dictionary<string, string>()
        {
            {nameof(double2x2.OuterProduct), "outerProduct"},
            {nameof(double2x2.Transpose), "transpose"},
            {nameof(double2x2.Determinant), "determinant"},
        };
        private static readonly Dictionary<string, string> knowndouble3x2Functions = new Dictionary<string, string>()
        {
            {nameof(double3x2.OuterProduct), "outerProduct"},
            {nameof(double3x2.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knowndouble4x2Functions = new Dictionary<string, string>()
        {
            {nameof(double4x2.OuterProduct), "outerProduct"},
            {nameof(double4x2.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knowndouble2x3Functions = new Dictionary<string, string>()
        {
            {nameof(double2x3.OuterProduct), "outerProduct"},
            {nameof(double2x3.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knowndouble3x3Functions = new Dictionary<string, string>()
        {
            {nameof(double3x3.OuterProduct), "outerProduct"},
            {nameof(double3x3.Transpose), "transpose"},
            {nameof(double3x3.Determinant), "determinant"},
        };
        private static readonly Dictionary<string, string> knowndouble4x3Functions = new Dictionary<string, string>()
        {
            {nameof(double4x3.OuterProduct), "outerProduct"},
            {nameof(double4x3.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knowndouble2x4Functions = new Dictionary<string, string>()
        {
            {nameof(double2x4.OuterProduct), "outerProduct"},
            {nameof(double2x4.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knowndouble3x4Functions = new Dictionary<string, string>()
        {
            {nameof(double3x4.OuterProduct), "outerProduct"},
            {nameof(double3x4.Transpose), "transpose"},
        };
        private static readonly Dictionary<string, string> knowndouble4x4Functions = new Dictionary<string, string>()
        {
            {nameof(double4x4.OuterProduct), "outerProduct"},
            {nameof(double4x4.Transpose), "transpose"},
            {nameof(double4x4.Determinant), "determinant"},
        };
        private static readonly Dictionary<string, string> knownint2Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
            {"op_OnesComplement", "~"},
            {"op_Modulus", "%"},
            {"op_ExclusiveOr", "^"},
            {"op_BitwiseOr", "|"},
            {"op_BitwiseAnd", "&"},
            {"op_LeftShift", "<<"},
            {"op_RightShift", ">>"},
        };
        private static readonly Dictionary<string, string> knownint3Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
            {"op_OnesComplement", "~"},
            {"op_Modulus", "%"},
            {"op_ExclusiveOr", "^"},
            {"op_BitwiseOr", "|"},
            {"op_BitwiseAnd", "&"},
            {"op_LeftShift", "<<"},
            {"op_RightShift", ">>"},
        };
        private static readonly Dictionary<string, string> knownint4Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
            {"op_OnesComplement", "~"},
            {"op_Modulus", "%"},
            {"op_ExclusiveOr", "^"},
            {"op_BitwiseOr", "|"},
            {"op_BitwiseAnd", "&"},
            {"op_LeftShift", "<<"},
            {"op_RightShift", ">>"},
        };
        private static readonly Dictionary<string, string> knownuint2Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
            {"op_OnesComplement", "~"},
            {"op_Modulus", "%"},
            {"op_ExclusiveOr", "^"},
            {"op_BitwiseOr", "|"},
            {"op_BitwiseAnd", "&"},
            {"op_LeftShift", "<<"},
            {"op_RightShift", ">>"},
        };
        private static readonly Dictionary<string, string> knownuint3Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
            {"op_OnesComplement", "~"},
            {"op_Modulus", "%"},
            {"op_ExclusiveOr", "^"},
            {"op_BitwiseOr", "|"},
            {"op_BitwiseAnd", "&"},
            {"op_LeftShift", "<<"},
            {"op_RightShift", ">>"},
        };
        private static readonly Dictionary<string, string> knownuint4Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
            {"op_OnesComplement", "~"},
            {"op_Modulus", "%"},
            {"op_ExclusiveOr", "^"},
            {"op_BitwiseOr", "|"},
            {"op_BitwiseAnd", "&"},
            {"op_LeftShift", "<<"},
            {"op_RightShift", ">>"},
        };
        private static readonly Dictionary<string, string> knownfloat2Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat3Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat4Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble2Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble3Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble4Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_UnaryNegation", "-"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Multiply", "*"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownbool2Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
        };
        private static readonly Dictionary<string, string> knownbool3Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
        };
        private static readonly Dictionary<string, string> knownbool4Operators = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
        };
        private static readonly Dictionary<string, string> knownfloat2x2Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat3x2Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat4x2Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat2x3Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat3x3Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat4x3Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat2x4Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat3x4Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knownfloat4x4Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble2x2Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble3x2Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble4x2Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble2x3Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble3x3Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble4x3Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble2x4Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble3x4Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        private static readonly Dictionary<string, string> knowndouble4x4Operators = new Dictionary<string, string>()
        {
            {"op_Multiply", "*"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
        };
        public static readonly Dictionary<string, Dictionary<string, string>> knownFunctionsGlobal = new Dictionary<string, Dictionary<string, string>>()
        {
            {typeof(int2).FullName!, knownint2Functions },
            {typeof(int3).FullName!, knownint3Functions },
            {typeof(int4).FullName!, knownint4Functions },
            {typeof(uint2).FullName!, knownuint2Functions },
            {typeof(uint3).FullName!, knownuint3Functions },
            {typeof(uint4).FullName!, knownuint4Functions },
            {typeof(float2).FullName!, knownfloat2Functions },
            {typeof(float3).FullName!, knownfloat3Functions },
            {typeof(float4).FullName!, knownfloat4Functions },
            {typeof(double2).FullName!, knowndouble2Functions },
            {typeof(double3).FullName!, knowndouble3Functions },
            {typeof(double4).FullName!, knowndouble4Functions },
            {typeof(bool2).FullName!, knownbool2Functions },
            {typeof(bool3).FullName!, knownbool3Functions },
            {typeof(bool4).FullName!, knownbool4Functions },
            {typeof(float2x2).FullName!, knownfloat2x2Functions },
            {typeof(float3x2).FullName!, knownfloat3x2Functions },
            {typeof(float4x2).FullName!, knownfloat4x2Functions },
            {typeof(float2x3).FullName!, knownfloat2x3Functions },
            {typeof(float3x3).FullName!, knownfloat3x3Functions },
            {typeof(float4x3).FullName!, knownfloat4x3Functions },
            {typeof(float2x4).FullName!, knownfloat2x4Functions },
            {typeof(float3x4).FullName!, knownfloat3x4Functions },
            {typeof(float4x4).FullName!, knownfloat4x4Functions },
            {typeof(double2x2).FullName!, knowndouble2x2Functions },
            {typeof(double3x2).FullName!, knowndouble3x2Functions },
            {typeof(double4x2).FullName!, knowndouble4x2Functions },
            {typeof(double2x3).FullName!, knowndouble2x3Functions },
            {typeof(double3x3).FullName!, knowndouble3x3Functions },
            {typeof(double4x3).FullName!, knowndouble4x3Functions },
            {typeof(double2x4).FullName!, knowndouble2x4Functions },
            {typeof(double3x4).FullName!, knowndouble3x4Functions },
            {typeof(double4x4).FullName!, knowndouble4x4Functions },
        };
        public static readonly Dictionary<string, Dictionary<string, string>> knownOperatorsGlobal = new Dictionary<string, Dictionary<string, string>>()
        {
            {typeof(int2).FullName!, knownint2Operators },
            {typeof(int3).FullName!, knownint3Operators },
            {typeof(int4).FullName!, knownint4Operators },
            {typeof(uint2).FullName!, knownuint2Operators },
            {typeof(uint3).FullName!, knownuint3Operators },
            {typeof(uint4).FullName!, knownuint4Operators },
            {typeof(float2).FullName!, knownfloat2Operators },
            {typeof(float3).FullName!, knownfloat3Operators },
            {typeof(float4).FullName!, knownfloat4Operators },
            {typeof(double2).FullName!, knowndouble2Operators },
            {typeof(double3).FullName!, knowndouble3Operators },
            {typeof(double4).FullName!, knowndouble4Operators },
            {typeof(bool2).FullName!, knownbool2Operators },
            {typeof(bool3).FullName!, knownbool3Operators },
            {typeof(bool4).FullName!, knownbool4Operators },
            {typeof(float2x2).FullName!, knownfloat2x2Operators },
            {typeof(float3x2).FullName!, knownfloat3x2Operators },
            {typeof(float4x2).FullName!, knownfloat4x2Operators },
            {typeof(float2x3).FullName!, knownfloat2x3Operators },
            {typeof(float3x3).FullName!, knownfloat3x3Operators },
            {typeof(float4x3).FullName!, knownfloat4x3Operators },
            {typeof(float2x4).FullName!, knownfloat2x4Operators },
            {typeof(float3x4).FullName!, knownfloat3x4Operators },
            {typeof(float4x4).FullName!, knownfloat4x4Operators },
            {typeof(double2x2).FullName!, knowndouble2x2Operators },
            {typeof(double3x2).FullName!, knowndouble3x2Operators },
            {typeof(double4x2).FullName!, knowndouble4x2Operators },
            {typeof(double2x3).FullName!, knowndouble2x3Operators },
            {typeof(double3x3).FullName!, knowndouble3x3Operators },
            {typeof(double4x3).FullName!, knowndouble4x3Operators },
            {typeof(double2x4).FullName!, knowndouble2x4Operators },
            {typeof(double3x4).FullName!, knowndouble3x4Operators },
            {typeof(double4x4).FullName!, knowndouble4x4Operators },
        };
    }
}
