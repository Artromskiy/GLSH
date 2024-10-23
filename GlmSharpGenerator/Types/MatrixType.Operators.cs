using GlmSharpGenerator.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlmSharpGenerator.Types
{
    internal partial class MatrixType
    {
        private IEnumerable<Member> Operators()
        {
            // matrix-matrix-multiplication
            for (var rcols = 2; rcols <= 4; ++rcols)
            {
                var rhsType = new MatrixType(BaseType, rcols, Columns);
                var resultType = new MatrixType(BaseType, rcols, Rows);
                var constructorParams1 = FieldsHelper(rcols, Rows).Select(f => Columns.ForIndexUpTo(i => $"lhs.m{i}{f[2]} * rhs.m{f[1]}{i}").Aggregated(" + ")).CommaSeparated();
                yield return new Operator(resultType, "*")
                {
                    Comment = $"Executes a matrix-matrix-multiplication {Name} * {rhsType.Name} -> {resultType}.",
                    Parameters = [$"{Name} lhs", $"{rhsType.Name} rhs"],
                    Code = [$"new {resultType.Name}({constructorParams1})"],
                };
            }
            var s = string.Format("public static {0} operator*({1} m, {2} v) => new {0}({3});",
                VectorType.GetName(BaseType, Rows), NameThat, VectorType.GetName(BaseType, Columns),
                Rows.ForIndexUpTo(r => Columns.ForIndexUpTo(c => "m.m" + c + r + " * v." + "xyzw"[c]).Aggregated(" + ")).CommaSeparated());

            string constructorParams2 = Rows.ForIndexUpTo(r => Columns.ForIndexUpTo(c => $"m.m{c}{r} * v.{"xyzw"[c]}").Aggregated(" + ")).CommaSeparated();
            var retType = new VectorType(BaseType, Rows);
            var inpType = new VectorType(BaseType, Columns);
            yield return new Operator(retType, "*")
            {
                Comment = "Executes a matrix-vector-multiplication.",
                Parameters = [$"{Name} m", $"{inpType.Name} v"],
                Code = [$"new {retType.Name}({constructorParams2})"]
            };
        }

        private IEnumerable<string> Legacy()
        {

            // matrix-matrix-multiplication
            for (var rcols = 2; rcols <= 4; ++rcols)
            {
                var lhsRows = Rows;
                var lhsCols = Columns;
                var rhsRows = Columns;
                var rhsColumns = rcols;
                var rhsType = GetName(BaseType, rhsColumns, rhsRows) + GenericSuffix;
                var resultType = GetName(BaseType, rhsColumns, lhsRows) + GenericSuffix;
                foreach (var line in $"Executes a matrix-matrix-multiplication {NameThat} * {rhsType} -> {resultType}.".AsComment()) yield return line;
                yield return string.Format("public static {0} operator*({1} lhs, {2} rhs) => new {0}({3});",
                    resultType, NameThat, rhsType,
                    FieldsHelper(rhsColumns, lhsRows).Select(f => lhsCols.ForIndexUpTo(i => string.Format("lhs.m{1}{2} * rhs.m{0}{1}", f[1], i, f[2])).Aggregated(" + ")).CommaSeparated());
            }

            // matrix-matrix-division
            if (Rows == Columns && BaseType.IsSigned)
            {
                foreach (var line in "Executes a matrix-matrix-divison A / B == A * B^-1 (use with caution).".AsComment()) yield return line;
                yield return string.Format("public static {0} operator/({0} A, {0} B) => A * B.Inverse;", NameThat);
            }
        }

    }
}
