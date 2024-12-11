using System.Collections.Generic;

namespace GlmSharpGenerator.Types
{
    internal static class OperatorTranslations
    {
        public static Dictionary<string, string> nameToOperator = new Dictionary<string, string>()
        {
            {"op_Equality", "=="},
            {"op_Inequality", "!="},
            {"op_GreaterThan", ">"},
            {"op_LessThan", "<"},
            {"op_GreaterThanOrEqual", ">="},
            {"op_LessThanOrEqual", "<="},
            {"op_BitwiseAnd", "&"},
            {"op_BitwiseOr", "|"},
            {"op_Addition", "+"},
            {"op_Subtraction", "-"},
            {"op_Division", "/"},
            {"op_Modulus", "%"},
            {"op_Multiply", "*"},
            {"op_LeftShift", "<<"},
            {"op_RightShift", ">>"},
            {"op_ExclusiveOr", "^"},
            {"op_UnaryNegation", "-"},
            {"op_UnaryPlus", "+"},
            {"op_LogicalNot", "!"},
            {"op_OnesComplement", "~"},
            {"op_Increment", "++"},
            {"op_Decrement", "--"},
        };
    }
}
