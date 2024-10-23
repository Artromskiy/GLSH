using GlmSharpGenerator.Members;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class MatrixType : AbstractType
    {
        public MatrixType(BuiltinType type, int cols, int rows)
        {
            Columns = cols;
            Rows = rows;
            BaseType = type;
            BaseName = type.Prefix + "mat";
        }

        private static string GetName(BuiltinType type, int cols, int rows) => type.Name + cols + "x" + rows;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int FieldCount => Rows * Columns;
        public override string DataContractArg { get; } = "(Namespace = \"mat\")";

        public override string Name => GetName(BaseType, Columns, Rows);

        public override string Folder => "Mat" + Columns + "x" + Rows;

        public override string TypeComment => $"A matrix of type {BaseTypeName} with {Columns} columns and {Rows} rows.";

        public bool HasField(string f) => ColOf(f) < Columns && RowOf(f) < Rows;

        private static string[,] HelperFieldsOf(int s)
        {
            var f = new string[s, s];
            for (var x = 0; x < s; ++x)
                for (var y = 0; y < s; ++y)
                    f[x, y] = "m" + x + y;
            return f;
        }

        private static string[,] HelperSubmatrix(string[,] old, int tx, int ty)
        {
            var s = old.GetLength(0) - 1;
            var f = new string[s, s];
            for (var x = 0; x < s; ++x)
                for (var y = 0; y < s; ++y)
                    f[x, y] = old[x + (x >= tx ? 1 : 0), y + (y >= ty ? 1 : 0)];
            return f;
        }

        private static string HelperDet(string[,] f, int initialSign = 0)
        {
            var s = f.GetLength(0);
            if (s == 1)
                return (initialSign % 2 == 1 ? "-" : "") + f[0, 0];
            if (s <= 2)
                return (initialSign % 2 == 1 ? "-" : "") + string.Format("{0} * {1} {4} {2} * {3}", f[0, 0], f[1, 1], f[1, 0], f[0, 1], initialSign % 2 == 0 ? "-" : "+");

            var res = initialSign % 2 == 1 ? "-" : "";
            for (var i = 0; i < s; ++i)
            {
                if (res.Length > 1)
                    res += (i + initialSign) % 2 == 1 ? " - " : " + ";
                res += f[i, 0] + " * (" + HelperDet(HelperSubmatrix(f, i, 0)) + ")";
            }

            return res;
        }
        private string ClassNameTransposed => BaseType.Name + Rows + "x" + Columns + GenericSuffix;

        private IEnumerable<string> Fields
        {
            get
            {
                for (var x = 0; x < Columns; ++x)
                    for (var y = 0; y < Rows; ++y)
                        yield return "m" + x + y;
            }
        }
        private IEnumerable<string> FieldsTransposed
        {
            get
            {
                for (var y = 0; y < Rows; ++y)
                    for (var x = 0; x < Columns; ++x)
                        yield return "m" + x + y;
            }
        }
        private IEnumerable<string> Column(int col)
        {
            for (var y = 0; y < Rows; ++y)
                yield return "m" + col + y;
        }
        private IEnumerable<string> Column(int col, string parameter)
        {
            for (var y = 0; y < Rows; ++y)
                yield return parameter + ".m" + col + y;
        }
        private IEnumerable<string> Row(int row)
        {
            for (var x = 0; x < Columns; ++x)
                yield return "m" + x + row;
        }

        private string FieldFor(int f) => $"m{f / Rows}{f % Rows}";

        private string ArgOf(int c) => "xyzw"[c].ToString();

        private int RowOf(string fieldName) => fieldName[2] - '0';
        private int ColOf(string fieldName) => fieldName[1] - '0';

        private bool IsDiagonal(string fieldName) => fieldName[1] == fieldName[2];

        private IEnumerable<string> Constructor(string comment, string args, IEnumerable<string> assignments)
        {
            foreach (var line in comment.AsComment())
                yield return line;
            yield return $"public {Name}({args})";
            yield return "{";
            var it = assignments.GetEnumerator();
            foreach (var c in Fields)
                yield return $"this.{c} = {(it.MoveNext() ? it.Current : (c[1] == c[2] ? BaseType.OneValue : BaseType.ZeroValue))};".Indent();
            yield return "}";
        }

        public string HashCodeFor(int c) => (c == 0 ? "" : $"(({HashCodeFor(c - 1)}) * {BaseType.HashCodeMultiplier}) ^ ") + HashCodeOf(FieldFor(c));


        public string ComponentWiseOperator(string op)
            => string.Format("public static {0} operator{2}({0} lhs, {0} rhs) => new {0}({1});", NameThat,
                    Fields.Select(c => string.Format("lhs.{0} {1} rhs.{0}", c, op)).CommaSeparated(), op);

        public string ComponentWiseOperator(string op, string internalOp)
            => string.Format("public static {0} operator{2}({0} lhs, {0} rhs) => new {0}({1});", NameThat,
                    Fields.Select(c => string.Format("lhs.{0} {1} rhs.{0}", c, internalOp)).CommaSeparated(), op);

        public string ComponentWiseOperatorScalar(string op, string scalarType)
            => string.Format("public static {0} operator{2}({0} lhs, {3} rhs) => new {0}({1});", NameThat,
                    Fields.Select(c => $"lhs.{c} {op} rhs").CommaSeparated(), op, scalarType);

        public string ComponentWiseOperatorScalarL(string op, string scalarType)
            => string.Format("public static {0} operator{2}({3} lhs, {0} rhs) => new {0}({1});", NameThat,
                    Fields.Select(c => string.Format("lhs {1} rhs.{0}", c, op)).CommaSeparated(), op, scalarType);

        public string ComponentWiseOperatorForeign(string op, string returnType)
            => string.Format("public static {3} operator{2}({0} lhs, {3} rhs) => new {3}({1});", NameThat,
                    Fields.Select(c => string.Format("lhs.{0} {1} rhs.{0}", c, op)).CommaSeparated(), op, returnType);
        public string ComponentWiseOperatorForeignL(string op, string returnType)
            => string.Format("public static {3} operator{2}({3} lhs, {0} rhs) => new {3}({1});", NameThat,
                    Fields.Select(c => string.Format("lhs.{0} {1} rhs.{0}", c, op)).CommaSeparated(), op, returnType);

        public string ComponentWiseOperatorForeignScalar(string op, string scalarType, string returnType)
            => string.Format("public static {4} operator{2}({0} lhs, {3} rhs) => new {4}({1});", NameThat,
                    Fields.Select(c => $"lhs.{c} {op} rhs").CommaSeparated(), op, scalarType, returnType);

        public string ComponentWiseOperatorForeignScalarL(string op, string scalarType, string returnType)
            => string.Format("public static {4} operator{2}({3} lhs, {0} rhs) => new {4}({1});", NameThat,
                    Fields.Select(c => string.Format("lhs {1} rhs.{0}", c, op)).CommaSeparated(), op, scalarType, returnType);

        public string ComparisonOperator(string op)
            => string.Format("public static {3} operator{2}({0} lhs, {0} rhs) => new {3}({1});", NameThat,
                    Fields.Select(c => string.Format("lhs.{0} {1} rhs.{0}", c, op)).CommaSeparated(), op,
                    GetName(BuiltinType.TypeBool, Columns, Rows));

        public string ComparisonOperatorScalar(string op, string scalarType)
            => string.Format("public static {3} operator{2}({0} lhs, {4} rhs) => new {3}({1});", NameThat,
                    Fields.Select(c => $"lhs.{c} {op} rhs").CommaSeparated(), op,
                    GetName(BuiltinType.TypeBool, Columns, Rows), scalarType);

        public string ComparisonOperatorScalarL(string op, string scalarType)
            => string.Format("public static {3} operator{2}({4} lhs, {0} rhs) => new {3}({1});", NameThat,
                    Fields.Select(c => string.Format("lhs {1} rhs.{0}", c, op)).CommaSeparated(), op,
                    GetName(BuiltinType.TypeBool, Columns, Rows), scalarType);

        public string NestedBiFuncFor(string format, int c, Func<int, string> argOf) => c == 0 ? argOf(c) : string.Format(format, NestedBiFuncFor(format, c - 1, argOf), argOf(c));

        public IEnumerable<string> FieldsHelper(int cols, int rows)
        {
            for (var x = 0; x < cols; ++x)
                for (var y = 0; y < rows; ++y)
                    yield return "m" + x + y;
        }

        public override IEnumerable<Member> GenerateMembers()
        {
            var colVecType = new VectorType(BaseType, Rows);
            var rowVecType = new VectorType(BaseType, Columns);
            var quatType = new QuaternionType(BaseType);
            var diagonal = Rows == Columns;

            // fields
            foreach (var f in Fields)
                yield return new Field(f, BaseType)
                {
                    Comment = $"Column {ColOf(f)}, Rows {RowOf(f)}"
                };

            foreach (var item in Constructors())
                yield return item;

            foreach (var item in Operators())
                yield return item;

            foreach (var item in Functions())
                yield return item;

            yield return new Field("Count", BuiltinType.TypeInt)
            {
                Constant = true,
                Comment = $"Returns the number of Fields ({Columns} x {Rows} = {FieldCount}).",
                DefaultValue = FieldCount.ToString(),
            };

            yield return new Indexer(BaseType)
            {
                ParameterString = "int col, int row",
                Getter = [$"if ((uint)col >= {Columns})",
                          "    throw new ArgumentOutOfRangeException(nameof(col));",
                          $"if ((uint)row >= {Rows})",
                          "    throw new ArgumentOutOfRangeException(nameof(row));",
                          $"return Unsafe.Add(ref m00, col * {Rows} + row);"],
                Setter = [$"if ((uint)col >= {Columns})",
                          "    throw new ArgumentOutOfRangeException(nameof(col));",
                          $"if ((uint)row >= {Rows})",
                          "    throw new ArgumentOutOfRangeException(nameof(row));",
                          $"Unsafe.Add(ref m00, col * {Rows} + row) = value;"],
                Comment = "Gets/Sets a specific indexed column."
            };


            var indexerVector = new VectorType(BaseType, Rows);
            yield return new Indexer(indexerVector)
            {
                ParameterString = "int col",
                Getter = [$"if ((uint)col >= {Columns})",
                          "    throw new ArgumentOutOfRangeException(nameof(col));",
                          $"return MemoryMarshal.Cast<{Name}, {indexerVector.Name}>(new Span<{Name}>(ref this))[col];"],
                Setter = [$"if ((uint)col >= {Columns})",
                          "    throw new ArgumentOutOfRangeException(nameof(col));",
                          $"MemoryMarshal.Cast<{Name}, {indexerVector.Name}>(new Span<{Name}>(ref this))[col] = value;"],
                Comment = "Gets/Sets a specific indexed component."
            };

            // Extensions
            yield return new Function(new AnyType($"IEnumerator<{BaseTypeName}>"), "GetEnumerator")
            {
                Static = true,
                Extension = true,
                Parameters = ["this " + Name + " value"],
                Code = Fields.Select(f => $"yield return value.{f};"),
                Comment = "Returns an enumerator that iterates through all fields."
            };

            yield return new Function(new ArrayType(BaseType, "[,]"), "GetValues")
            {
                Static = true,
                Extension = true,
                Parameters = ["this " + Name + " value"],
                CodeString = $"new[,] {{ {Columns.ForIndexUpTo(col => "{ " + Column(col, "value").CommaSeparated() + " }").CommaSeparated()} }}",
                Comment = "Creates a 2D array with all values (address: Values[x, y])"
            };

            yield return new Function(new ArrayType(BaseType), "GetValues1D")
            {
                Static = true,
                Extension = true,
                Parameters = ["this " + Name + " value"],
                CodeString = $"new[] {{ {Fields.CommaSeparated("value")} }}",
                Comment = "Creates a 1D array with all values (internal order)"
            };
        }

    }
}
