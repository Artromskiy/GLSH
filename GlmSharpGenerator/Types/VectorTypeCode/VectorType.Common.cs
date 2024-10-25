using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        /// <summary>
        /// Refers to GLSL 450 specs.
        /// 8 Built-in Functions.
        /// 8.3 Common Functions.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Member> CommonFunctions()
        {
            var boolVec = new VectorType(BuiltinType.TypeBool, Components);
            var intVec = new VectorType(BuiltinType.TypeInt, Components);
            var uintVec = new VectorType(BuiltinType.TypeUint, Components);
            var floatVec = new VectorType(BuiltinType.TypeFloat, Components);
            if (BaseType == BuiltinType.TypeFloat || BaseType == BuiltinType.TypeInt || BaseType == BuiltinType.TypeDouble)
            {
                yield return new ComponentWiseStaticFunction(Fields, this, "Abs", this, "v", $"{BaseTypeName}.Abs({{0}})") { GlslName = "abs" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Sign", this, "v", $"{BaseTypeName}.Sign({{0}})") { GlslName = "sign" };
            }
            if (BaseType == BuiltinType.TypeFloat || BaseType == BuiltinType.TypeDouble)
            {
                yield return new ComponentWiseStaticFunction(Fields, this, "Floor", this, "v",$"{BaseTypeName}.Floor({{0}})") { GlslName = "floor" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Truncate", this, "v", $"{BaseTypeName}.Truncate({{0}})") { GlslName = "trunc" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Round", this, "v", $"{BaseTypeName}.Round({{0}})") { GlslName = "round" };
                yield return new ComponentWiseStaticFunction(Fields, this, "RoundEven", this, "v", $"{BaseTypeName}.Round({{0}}, MidpointRounding.ToEven)") { GlslName = "roundEven" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Ceiling", this, "v", $"{BaseTypeName}.Ceiling({{0}})") { GlslName = "ceil" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Fract", this, "v", $"{{0}} - {BaseTypeName}.Floor({{0}})") { GlslName = "fract" }; 
                yield return new ComponentWiseStaticFunction(Fields, this, "Mod", this, "lhs", this, "rhs", $"{{0}} - {{1}} * {BaseTypeName}.Floor({{0}} / {{1}})") { CanScalar1 = true , GlslName = "mod" };
                //TODO Add Modf
                yield return new ComponentWiseStaticFunction(Fields, this, "Lerp", this, "edge0", this, "edge1", this, "v", $"{BaseTypeName}.Lerp({{0}}, {{1}}, {{2}})") { CanScalar2 = true, GlslName = "mix" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Step", this, "edge", this, "x", $"{{1}} < {{0}} ? 0 : 1") { CanScalar0 = true, GlslName = "step" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Smoothstep", this, "edge0", this, "edge1", this, "v", $"{BaseTypeName}.Clamp(({{2}} - {{0}}) / ({{1}} - {{0}}), 0, 1).HermiteInterpolationOrder3()") { CanScalar2 = true, GlslName = "smoothstep"};
                yield return new ComponentWiseStaticFunction(Fields, boolVec, "IsNaN", this, "v", $"{BaseTypeName}.IsNaN({{0}})") { GlslName = "isnan" };
                yield return new ComponentWiseStaticFunction(Fields, boolVec, "IsInfinity", this, "v", $"{BaseTypeName}.IsInfinity({{0}})") { GlslName = "isinf" }; ;
                yield return new ComponentWiseStaticFunction(Fields, this, "Fma", this, "a", this, "b", this, "c", $"{BaseTypeName}.FusedMultiplyAdd({{0}}, {{1}}, {{2}})") { GlslName = "fma" };
            }
            if (BaseType == BuiltinType.TypeFloat || BaseType == BuiltinType.TypeDouble || BaseType == BuiltinType.TypeInt || BaseType == BuiltinType.TypeUint)
            {
                yield return new ComponentWiseStaticFunction(Fields, this, "Min", this, "lhs", this, "rhs", $"{BaseTypeName}.Min({{0}}, {{1}})") { CanScalar1 = true , GlslName = "min" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Max", this, "lhs", this, "rhs", $"{BaseTypeName}.Max({{0}}, {{1}})") { CanScalar1 = true, GlslName = "max" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Clamp", this, "v", this, "min", this, "max", $"{BaseTypeName}.Clamp({{0}}, {{1}}, {{2}})") { GlslName = "clamp" };
                yield return new Function(this, "Clamp")
                {
                    GlslName = "clamp",
                    Static = true,
                    Parameters = [$"{Name} v", $"{BaseType.Name} min", $"{BaseType.Name} max"],
                    Code = [$"{Construct(this, Fields.Select(f => $"{BaseTypeName}.Clamp(v.{f}, min, max)"))}"],
                    Comment = $"Returns a {Name} from component-wise application of Clamp ({BaseTypeName}.Clamp(v, min, max)).",
                };
            }

            if (BaseType == BuiltinType.TypeFloat || BaseType == BuiltinType.TypeDouble || BaseType == BuiltinType.TypeInt || BaseType == BuiltinType.TypeUint || BaseType == BuiltinType.TypeBool)
            {
                // weird boolean mix
                yield return new ComponentWiseStaticFunction(Fields, this, "Mix", this, "x", this, "y", boolVec, "a", $"{{2}} ? {{1}} : {{0}}") { GlslName = "mix" };
            }
            if (BaseType == BuiltinType.TypeFloat)
            {
                yield return new ComponentWiseStaticFunction(Fields, intVec, "FloatBitsToInt", this, "v", $"Unsafe.As<{BaseTypeName}, {intVec.BaseTypeName}>(ref {{0}})") { GlslName = "floatBitsToInt" };
                yield return new ComponentWiseStaticFunction(Fields, uintVec, "FloatBitsToUInt", this, "v", $"Unsafe.As<{BaseTypeName}, {uintVec.BaseTypeName}>(ref {{0}})") { GlslName = "floatBitsToUint" };
            }
            if (BaseType == BuiltinType.TypeInt)
            {
                yield return new ComponentWiseStaticFunction(Fields, floatVec, "IntBitsToFloat", this, "v", $"Unsafe.As<{BaseTypeName}, {floatVec.BaseTypeName}>(ref {{0}})") { GlslName = "intBitsToFloat" };
            }
            if (BaseType == BuiltinType.TypeUint)
            {
                yield return new ComponentWiseStaticFunction(Fields, floatVec, "UIntBitsToFloat", this, "v", $"Unsafe.As<{BaseTypeName}, {floatVec.BaseTypeName}>(ref {{0}})") { GlslName = "uintBitsToFloat" };
            }
            // TODO
            // frexp
            // ldexp




            // frexp
            // exp = MathF.ILogB(x);
            // x = significand * 2 ^ exp;
            // significand = x / (2 ^ exp)

            // ldexp  x = MathF.ScaleB(significand, exp)
        }
    }
}
