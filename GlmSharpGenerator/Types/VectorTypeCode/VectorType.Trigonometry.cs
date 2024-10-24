using GlmSharpGenerator.Members;
using System.Collections.Generic;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        /// <summary>
        /// Refers to GLSL 450 specs.
        /// 8 Built-in Functions.
        /// 8.1 Angle and Trigonometry Functions.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Member> TrigonometryFunctions()
        {
            if (BaseType != BuiltinType.TypeFloat)
                yield break;

            yield return new ComponentWiseStaticFunction(Fields, this, "Radians", this, "v", $"{BaseTypeName}.DegreesToRadians({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Degrees", this, "v", $"{BaseTypeName}.RadiansToDegrees({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Sin", this, "v", $"{BaseTypeName}.Sin({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Cos", this, "v", $"{BaseTypeName}.Cos({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Tan", this, "v", $"{BaseTypeName}.Tan({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Asin", this, "v", $"{BaseTypeName}.Asin({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Acos", this, "v", $"{BaseTypeName}.Acos({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Atan", this, "y", this, "x", $"{BaseTypeName}.Atan({{0}} / {{1}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Atan", this, "v", $"{BaseTypeName}.Atan({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Sinh", this, "v", $"{BaseTypeName}.Sinh({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Cosh", this, "v", $"{BaseTypeName}.Cosh({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Tanh", this, "v", $"{BaseTypeName}.Tanh({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Asinh", this, "v", $"{BaseTypeName}.Asinh({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Acosh", this, "v", $"{BaseTypeName}.Acosh({{0}})");
            yield return new ComponentWiseStaticFunction(Fields, this, "Atanh", this, "v", $"{BaseTypeName}.Atanh({{0}})");
        }
    }
}
