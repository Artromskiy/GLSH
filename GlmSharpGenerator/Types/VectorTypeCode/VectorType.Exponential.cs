using GlmSharpGenerator.Members;
using System.Collections.Generic;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        /// <summary>
        /// Refers to GLSL 450 specs.
        /// 8 Built-in Functions
        /// 8.2 Exponential Functions
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Member> ExponentialFunctions()
        {
            if (BaseType == BuiltinType.TypeFloat)
            {
                yield return new ComponentWiseStaticFunction(Fields, this, "Pow", this, "lhs", this, "rhs", $"{BaseTypeName}.Pow({{0}}, {{1}})") { GlslName = "pow" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Exp", this, "v", $"{BaseTypeName}.Exp({{0}})") { GlslName = "exp" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Log", this, "v", $"{BaseTypeName}.Log({{0}})") { GlslName = "log" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Exp2", this, "v", $"{BaseTypeName}.Exp2({{0}})") { GlslName = "exp2" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Log2", this, "v", $"{BaseTypeName}.Log2({{0}})") { GlslName = "log2" };
            }
            if (BaseType == BuiltinType.TypeFloat || BaseType == BuiltinType.TypeDouble)
            {
                yield return new ComponentWiseStaticFunction(Fields, this, "Sqrt", this, "v", $"{BaseTypeName}.Sqrt({{0}})") { GlslName = "sqrt" };
                yield return new ComponentWiseStaticFunction(Fields, this, "InverseSqrt", this, "v", $"{BaseTypeName}.ReciprocalSqrtEstimate({{0}})") { GlslName = "inversesqrt" };
            }
        }
    }
}
