using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;
using static System.Linq.Enumerable;
using static System.String;
namespace GlmSharpGenerator.Types
{
    internal partial class MatrixType
    {
        /// <summary>
        /// Refers to GLSL 450 specs.
        /// 5 Operators and Expressions.
        /// 5.9 Expressions.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Member> Operators()
        {
            var p = " + ";
            var c = ", ";
            // matrix-matrix-multiplication
            for (var rcols = 2; rcols <= 4; ++rcols)
            {
                var rhs = new MatrixType(BaseType, rcols, Columns);
                var resultType = new MatrixType(BaseType, rcols, Rows);
                var ctrParams1 = Join(c, FieldsHelper(rcols, Rows).Select(f => Join(p, Range(0, Columns).Select(i => $"lhs[{i}, {f[2]}] * rhs[{f[1]}, {i}]"))));
                yield return new Operator(resultType, "*")
                {
                    Comment = $"Executes a matrix-matrix-multiplication {Name} * {rhs.Name} -> {resultType.Name}.",
                    Parameters = [$"{Name} lhs", $"{rhs.Name} rhs"],
                    Code = [$"new {resultType.Name}({ctrParams1})"],
                };
            }

            string ctrParams2 = Join(c, Range(0, Rows).Select(r => Join(p, Range(0, Columns).Select(c => $"m[{c}, {r}] * v.{"xyzw"[c]}"))));
            var retType = new VectorType(BaseType, Rows);
            var inpType = new VectorType(BaseType, Columns);
            yield return new Operator(retType, "*")
            {
                Comment = "Executes a matrix-vector-multiplication.",
                Parameters = [$"{Name} m", $"{inpType.Name} v"],
                Code = [$"new {retType.Name}({ctrParams2})"]
            };

            // arithmetic operators
            foreach (var kvp in new Dictionary<string, string>
            {
                {"+", "+ (addition)"},
                {"-", "- (subtraction)"},
                {"/", "/ (division)"},
                {"*", "* (multiplication)"} // only scalar
            })
            {
                var op = kvp.Key;
                var opComment = kvp.Value;

                if (op != "*")
                    yield return new Operator(this, op) // matrix * matrix
                    {
                        Comment = $"Executes a component-wise {opComment}.",
                        Parameters = this.LhsRhs(),
                        Code = [$"new {Name}({Fields.Select(f => $"lhs{f} {op} rhs{f}").CommaSeparated()})"]
                    };
                yield return new Operator(this, op) // scalar * matrix
                {
                    Comment = $"Executes a component-wise {opComment} with scalar.",
                    Parameters = [$"{BaseTypeName} s", $"{Name} m"],
                    Code = [$"new {Name}({Fields.Select(f => $"s {op} m{f}").CommaSeparated()})"]
                };
                yield return new Operator(this, op) // matrix * scalar
                {
                    Comment = $"Executes a component-wise {opComment} with scalar.",
                    Parameters = [$"{Name} m", $"{BaseTypeName} s"],
                    Code = [$"new {Name}({Fields.Select(f => $"m{f} {op} s").CommaSeparated()})"]
                };
            }
        }

        private IEnumerable<string> Legacy()
        {
            // matrix-matrix-division
            if (Rows == Columns && BaseType.IsSigned)
            {
                foreach (var line in "Executes a matrix-matrix-divison A / B == A * B^-1 (use with caution).".AsComment()) yield return line;
                yield return string.Format("public static {0} operator/({0} A, {0} B) => A * B.Inverse;", NameThat);
            }
        }

    }
}
