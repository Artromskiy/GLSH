using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class MatrixType
    {
        private IEnumerable<Member> Constructors()
        {
            // Constructors
            yield return new Constructor(this, Fields)
            {
                Parameters = Fields.TypedArgs(BaseType),
                Initializers = Fields,
                Comment = "Component-wise constructor"
            };
            // by-mat-ctors
            for (var rows = 2; rows <= 4; ++rows)
                for (var cols = 2; cols <= 4; ++cols)
                {
                    var matType = new MatrixType(BaseType, cols, rows);
                    yield return new Constructor(this, Fields)
                    {
                        Parameters = matType.TypedArgs("m"),
                        Initializers = Fields.Select(f => matType.HasField(f) ? "m." + f : IsDiagonal(f) && !string.IsNullOrEmpty(OneValue) ? OneValue : ZeroValue),
                        Comment = $"Constructs this matrix from a {matType.Name}. Non-overwritten fields are from an Identity matrix."
                    };
                }
            // by-column-vector-ctors
            for (var rows = 2; rows <= Rows; ++rows)
                for (var cols = 2; cols <= Columns; ++cols)
                {
                    var vecType = new VectorType(BaseType, rows);
                    var matType = new MatrixType(BaseType, cols, rows);
                    yield return new Constructor(this, Fields)
                    {
                        Parameters = vecType.TypedArgs(cols.ForIndexUpTo(c => "c" + c)),
                        Initializers = Fields.Select(f => matType.HasField(f) ? "c" + f[1] + "." + ArgOf(RowOf(f)) : IsDiagonal(f) && !string.IsNullOrEmpty(OneValue) ? OneValue : ZeroValue),
                        Comment = string.Format("Constructs this matrix from a series of column vectors. Non-overwritten fields are from an Identity matrix.")
                    };
                }


        }
    }
}
