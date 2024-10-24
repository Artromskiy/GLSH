using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        /// <summary>
        /// Refers to GLSL 450 specs.
        /// 5 Operators and Expressions
        /// 5.9 Expressions
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Member> Operators()
        {
            var boolVType = new VectorType(BuiltinType.TypeBool, Components);

            // TODO Vector_X_Matrix multiplication

            yield return new Operator(BuiltinType.TypeBool, "==")
            {
                Parameters = this.LhsRhs(),
                CodeString = $"{string.Join("&&", this.Fields.Select(s => "lhs." + s + " == " + "rhs." + s))}",
            };

            yield return new Operator(BuiltinType.TypeBool, "!=")
            {
                Parameters = this.LhsRhs(),
                CodeString = $"{string.Join("||", this.Fields.Select(s => "lhs." + s + " != " + "rhs." + s))}",
            };

            if (BaseType != BuiltinType.TypeUint && BaseType != BuiltinType.TypeBool)
                yield return new ComponentWiseOperator(Fields, this, "-", this, "v", "-{0}");

            if (BaseType != BuiltinType.TypeBool)
            {
                yield return new ComponentWiseOperator(Fields, this, "+", this, "lhs", this, "rhs", "{0} + {1}") { CanScalar0 = true, CanScalar1 = true };
                yield return new ComponentWiseOperator(Fields, this, "-", this, "lhs", this, "rhs", "{0} - {1}") { CanScalar0 = true, CanScalar1 = true };
                yield return new ComponentWiseOperator(Fields, this, "*", this, "lhs", this, "rhs", "{0} * {1}") { CanScalar0 = true, CanScalar1 = true };
                yield return new ComponentWiseOperator(Fields, this, "/", this, "lhs", this, "rhs", "{0} / {1}") { CanScalar0 = true, CanScalar1 = true };
            }

            if (BaseType == BuiltinType.TypeInt || BaseType == BuiltinType.TypeUint)
            {
                yield return new ComponentWiseOperator(Fields, this, "~", this, "v", "~{0}");
                yield return new ComponentWiseOperator(Fields, this, "%", this, "lhs", this, "rhs", "{0} % {1}") { CanScalar0 = true, CanScalar1 = true };
                yield return new ComponentWiseOperator(Fields, this, "^", this, "lhs", this, "rhs", "{0} ^ {1}") { CanScalar0 = true, CanScalar1 = true };
                yield return new ComponentWiseOperator(Fields, this, "|", this, "lhs", this, "rhs", "{0} | {1}") { CanScalar0 = true, CanScalar1 = true };
                yield return new ComponentWiseOperator(Fields, this, "&", this, "lhs", this, "rhs", "{0} & {1}") { CanScalar0 = true, CanScalar1 = true };
            }
            if (BaseType == BuiltinType.TypeInt)
            {
                yield return new ComponentWiseOperator(Fields, this, "<<", this, "lhs", this, "rhs", "{0} << {1}") { CanScalar1 = true };
                yield return new ComponentWiseOperator(Fields, this, ">>", this, "lhs", this, "rhs", "{0} >> {1}") { CanScalar1 = true };
            }
            if (BaseType == BuiltinType.TypeUint)
            {
                yield return new ComponentWiseOperator(Fields, this, "<<", this, "lhs", this, "rhs", $"{{0}} << ({BuiltinType.TypeInt.Name}){{1}}") { CanScalar1 = true };
                yield return new ComponentWiseOperator(Fields, this, ">>", this, "lhs", this, "rhs", $"{{0}} >> ({BuiltinType.TypeInt.Name}){{1}}") { CanScalar1 = true };
            }
        }
    }
}
