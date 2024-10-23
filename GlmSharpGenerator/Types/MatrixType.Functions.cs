using GlmSharpGenerator.Members;
using System.Collections.Generic;

namespace GlmSharpGenerator.Types
{
    internal partial class MatrixType
    {
        private IEnumerable<Member> Functions()
        {
            var transposedType = new MatrixType(BaseType, Rows, Columns);
            var cols = new VectorType(BaseType, Columns);
            var rows = new VectorType(BaseType, Rows); 
            yield return new Function(this, "OuterProduct")
            {
                Static = true,
                Parameters = [rows.Name + " col", cols.Name + " row"],
                CodeString = $"{Construct(this, OutProduct(cols, rows, "row", "col"))}",
            };
            yield return new Function(transposedType, "Transpose")
            {
                Static = true,
                Parameters = this.TypedArgs("v"),
                CodeString = $"new {transposedType.Name}({ConvertArg(FieldsTransposed, "v").CommaSeparated()})",
            };

            if(Columns == Rows)
            yield return new Function(BaseType, "Determinant")
            {
                Static = true,
                Parameters = this.TypedArgs("v"),
                CodeString = HelperDet(ConvertArg(HelperFieldsOf(Rows), "v")),
            };
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
                yield return arg + "." + item;
        }

        private static string[,] ConvertArg(string[,] parameters, string arg)
        {
            for (int i = 0; i < parameters.GetLength(0); i++)
                for (int j = 0; j < parameters.GetLength(1); j++)
                    parameters[i, j] = arg + "." + parameters[i, j];
            return parameters;
        }
    }
}
