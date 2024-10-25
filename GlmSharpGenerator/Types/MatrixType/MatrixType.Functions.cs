using GlmSharpGenerator.Members;
using System.Collections.Generic;

namespace GlmSharpGenerator.Types
{
    internal partial class MatrixType
    {
        /// <summary>
        /// Refers to GLSL 450 specs.
        /// 8 Built-in Functions.
        /// 8.6 Matrix Functions.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Member> Functions()
        {
            var transposedType = new MatrixType(BaseType, Rows, Columns);
            var cols = new VectorType(BaseType, Columns);
            var rows = new VectorType(BaseType, Rows);
            yield return new Function(this, "OuterProduct")
            {
                GlslName = "outerProduct",
                Static = true,
                Parameters = [rows.Name + " col", cols.Name + " row"],
                CodeString = $"{Construct(this, OutProduct(cols, rows, "row", "col"))}",
            };
            yield return new Function(transposedType, "Transpose")
            {
                GlslName = "transpose",
                Static = true,
                Parameters = this.TypedArgs("v"),
                CodeString = $"new {transposedType.Name}({ConvertArg(FieldsTransposed, "v").CommaSeparated()})",
            };

            if (Rows != Columns)
                yield break;

            /*
            yield return new Function(this, "Inverse")
            {
                GlslName = "inverse",
                Static = true,
                Comment = "Returns the inverse of this matrix (use with caution).",
                Parameters = this.TypedArgs("v"),
                CodeString = $"{Name}.Adjugate(v) / {Name}.Determinant(v)",
            };
            */

            yield return new Function(BaseType, "Determinant")
            {
                GlslName = "determinant",
                Static = true,
                Parameters = this.TypedArgs("v"),
                CodeString = HelperDet(ConvertArg(HelperFieldsOf(Rows), "v")),
            };

            /*
            yield return new Function(this, "Divide")
            {
                Static = true,
                Visibility = "private",
                Comment = "Executes a matrix-matrix-divison A / B == A * B^-1 (use with caution).",
                Parameters = [$"{Name} A", $"{Name} B"],
                Code = [$"A * {Name}.Inverse(B)"]
            };
            */

            /*
            var adjugateFields = FieldsTransposed.Select(f => HelperDet(HelperSubmatrix(HelperFieldsOf(Rows), ColOf(f), RowOf(f)), ColOf(f) + RowOf(f))).CommaSeparated();
            adjugateFields = adjugateFields.Replace("m", "v");
            yield return new Function(this, "Adjugate")
            {
                Visibility = "private",
                Static = true,
                Parameters = this.TypedArgs("v"),
                CodeString = $"new {Name}({adjugateFields})",
            };
            */
        }

        private static IEnumerable<string> OutProduct(VectorType col, VectorType row, string colP, string rowP)
        {
            foreach (var cf in col.Fields)
                foreach (var rf in row.Fields)
                    yield return $"{colP}.{cf} * {rowP}.{rf}";
        }

        private static IEnumerable<string> ConvertArg(IEnumerable<string> parameters, string arg)
        {
            foreach (var item in parameters)
                yield return arg + item;
        }

        private static string[,] ConvertArg(string[,] parameters, string arg)
        {
            for (int i = 0; i < parameters.GetLength(0); i++)
                for (int j = 0; j < parameters.GetLength(1); j++)
                    parameters[i, j] = $"{arg}{parameters[i, j]}";
            return parameters;
        }
    }
}
