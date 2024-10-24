using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        /// <summary>
        /// Refers to GLSL 450 specs.
        /// 8 Built-in Functions
        /// 8.7 Vector Relational Functions
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Member> RelationalFunctions()
        {
            var boolVType = new VectorType(BuiltinType.TypeBool, Components);

            if (BaseType == BuiltinType.TypeFloat || BaseType == BuiltinType.TypeDouble || BaseType == BuiltinType.TypeInt || BaseType == BuiltinType.TypeUint)
            {
                yield return new ComponentWiseStaticFunction(Fields, boolVType, "GreaterThan", this, "lhs", this, "rhs", "{0} > {1}");
                yield return new ComponentWiseStaticFunction(Fields, boolVType, "GreaterThanEqual", this, "lhs", this, "rhs", "{0} >= {1}");
                yield return new ComponentWiseStaticFunction(Fields, boolVType, "LesserThan", this, "lhs", this, "rhs", "{0} < {1}");
                yield return new ComponentWiseStaticFunction(Fields, boolVType, "LesserThanEqual", this, "lhs", this, "rhs", "{0} <= {1}");
            }

            if (BaseType == BuiltinType.TypeFloat || BaseType == BuiltinType.TypeDouble || BaseType == BuiltinType.TypeInt || BaseType == BuiltinType.TypeUint || BaseType == BuiltinType.TypeBool)
            {
                yield return new ComponentWiseStaticFunction(Fields, boolVType, "Equal", this, "lhs", this, "rhs", BaseType.EqualFormat);
                yield return new ComponentWiseStaticFunction(Fields, boolVType, "NotEqual", this, "lhs", this, "rhs", BaseType.NotEqualFormat);
            }

            if (BaseType == BuiltinType.TypeBool)
            {
                yield return new Function(BuiltinType.TypeBool, "Any")
                {
                    Static = true,
                    ParameterString = $"{Name} v",
                    Code = [$"{string.Join("||", Fields.Select(s => $"v.{s}"))}"]
                };
                yield return new Function(BuiltinType.TypeBool, "All")
                {
                    Static = true,
                    ParameterString = $"{Name} v",
                    Code = [$"{string.Join("&&", Fields.Select(s => $"v.{s}"))}"]
                };
                yield return new ComponentWiseStaticFunction(Fields, boolVType, "Not", this, "v", "!{0}");
            }
        }
    }
}
