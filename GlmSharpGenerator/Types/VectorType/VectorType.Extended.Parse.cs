using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        private IEnumerable<Member> ParseFunctions()
        {
            if (!BaseType.IsComplex && !BaseType.Generic)
            {
                // Parse
                yield return new Function(this, "Parse")
                {
                    Static = true,
                    ParameterString = "string s",
                    CodeString = "Parse(s, \", \")",
                    Comment = "Converts the string representation of the vector into a vector representation (using ', ' as a separator)."
                };

                yield return new Function(this, "Parse")
                {
                    Static = true,
                    ParameterString = "string s, string sep",
                    Code = new[]
                    {
                        "var kvp = s.Split(new[] { sep }, StringSplitOptions.None);",
                        string.Format("if (kvp.Length != {0}) throw new FormatException(\"input has not exactly {0} parts\");", Components),
                        $"return new {NameThat}({Components.ForIndexUpTo(i => $"{BaseTypeName}.Parse(kvp[{i}].Trim())").CommaSeparated()});"
                    },
                    Comment = "Converts the string representation of the vector into a vector representation (using a designated separator)."
                };

                if (BaseType.Name != "bool")
                {
                    yield return new Function(this, "Parse")
                    {
                        Static = true,
                        ParameterString = "string s, string sep, IFormatProvider provider",
                        Code = new[]
                        {
                            "var kvp = s.Split(new[] { sep }, StringSplitOptions.None);",
                            string.Format("if (kvp.Length != {0}) throw new FormatException(\"input has not exactly {0} parts\");", Components),
                            $"return new {NameThat}({Components.ForIndexUpTo(i => $"{BaseTypeName}.Parse(kvp[{i}].Trim(), provider)").CommaSeparated()});"
                        },
                        Comment = "Converts the string representation of the vector into a vector representation (using a designated separator and a type provider)."
                    };
                    yield return new Function(this, "Parse")
                    {
                        Static = true,
                        ParameterString = "string s, string sep, NumberStyles style",
                        Code = new[]
                        {
                            "var kvp = s.Split(new[] { sep }, StringSplitOptions.None);",
                            string.Format("if (kvp.Length != {0}) throw new FormatException(\"input has not exactly {0} parts\");", Components),
                            $"return new {NameThat}({Components.ForIndexUpTo(i => $"{BaseTypeName}.Parse(kvp[{i}].Trim(), style)").CommaSeparated()});"
                        },
                        Comment = "Converts the string representation of the vector into a vector representation (using a designated separator and a number style)."
                    };
                    yield return new Function(this, "Parse")
                    {
                        Static = true,
                        ParameterString = "string s, string sep, NumberStyles style, IFormatProvider provider",
                        Code = new[]
                        {
                            "var kvp = s.Split(new[] { sep }, StringSplitOptions.None);",
                            string.Format("if (kvp.Length != {0}) throw new FormatException(\"input has not exactly {0} parts\");", Components),
                            $"return new {NameThat}({Components.ForIndexUpTo(i => $"{BaseTypeName}.Parse(kvp[{i}].Trim(), style, provider)").CommaSeparated()});"
                        },
                        Comment = "Converts the string representation of the vector into a vector representation (using a designated separator and a number style and a format provider)."
                    };
                }

                // TryParse
                yield return new Function(BuiltinType.TypeBool, "TryParse")
                {
                    Static = true,
                    ParameterString = $"string s, out {NameThat} result",
                    CodeString = "TryParse(s, \", \", out result)",
                    Comment = "Tries to convert the string representation of the vector into a vector representation (using ', ' as a separator), returns false if string was invalid."
                };

                yield return new Function(BuiltinType.TypeBool, "TryParse")
                {
                    Static = true,
                    ParameterString = $"string s, string sep, out {NameThat} result",
                    Code = new[]
                    {
                        "result = Zero;",
                        "if (string.IsNullOrEmpty(s)) return false;",
                        "var kvp = s.Split(new[] { sep }, StringSplitOptions.None);",
                        $"if (kvp.Length != {Components}) return false;",
                        $"{BaseTypeName} {CompString.Select(c => c + " = " + ZeroValue).CommaSeparated()};",
                        $"var ok = {Components.ForIndexUpTo(i => $"{BaseTypeName}.TryParse(kvp[{i}].Trim(), out {ArgOf(i)})").Aggregated(" && ")};",
                        $"result = ok ? new {NameThat}({CompArgString}) : Zero;",
                        "return ok;"
                    },
                    Comment = "Tries to convert the string representation of the vector into a vector representation (using a designated separator), returns false if string was invalid."
                };

                if (!BaseType.IsBool)
                {
                    yield return new Function(BuiltinType.TypeBool, "TryParse")
                    {
                        Static = true,
                        ParameterString = $"string s, string sep, NumberStyles style, IFormatProvider provider, out {NameThat} result",
                        Code = new[]
                        {
                            "result = Zero;",
                            "if (string.IsNullOrEmpty(s)) return false;",
                            "var kvp = s.Split(new[] { sep }, StringSplitOptions.None);",
                            $"if (kvp.Length != {Components}) return false;",
                            $"{BaseTypeName} {CompString.Select(c => c + " = " + ZeroValue).CommaSeparated()};",
                            $"var ok = {Components.ForIndexUpTo(i => $"{BaseTypeName}.TryParse(kvp[{i}].Trim(), style, provider, out {ArgOf(i)})").Aggregated(" && ")};",
                            $"result = ok ? new {NameThat}({CompArgString}) : Zero;",
                            "return ok;"
                        },
                        Comment = "Tries to convert the string representation of the vector into a vector representation (using a designated separator and a number style and a format provider), returns false if string was invalid."
                    };
                }
            }

        }
    }
}
