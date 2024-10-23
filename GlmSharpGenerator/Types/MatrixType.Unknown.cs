using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class MatrixType // legacy
    {

        private IEnumerable<Member> BodyLegacy2()
        {
            var colVecType = new VectorType(BaseType, Rows);
            var rowVecType = new VectorType(BaseType, Columns);
            var quatType = new QuaternionType(BaseType);
            var diagonal = Rows == Columns;


            // Columns
            for (var col = 0; col < Columns; ++col)
                yield return new Property("Column" + col, colVecType)
                {
                    GetterLine = $"return {Construct(colVecType, Column(col))};",
                    Setter = Column(col).Select((f, i) => $"{f} = value.{ArgOf(i)};"),
                    Comment = $"Gets or sets the column nr {col}"
                };
            // Rows
            for (var row = 0; row < Rows; ++row)
                yield return new Property("Row" + row, rowVecType)
                {
                    GetterLine = $"return {Construct(rowVecType, Row(row))};",
                    Setter = Row(row).Select((f, i) => $"{f} = value.{ArgOf(i)};"),
                    Comment = $"Gets or sets the row nr {row}"
                };

            // Basetype constants
            foreach (var constant in BaseType.TypeConstants)
            {
                yield return new StaticProperty("All" + constant, this)
                {
                    Value = Construct(this, $"{BaseTypeName}.{constant}".RepeatTimes(FieldCount)),
                    Comment = $"Predefined all-{constant} matrix"
                };

                yield return new StaticProperty("Diagonal" + constant, this)
                {
                    Value = Construct(this, Fields.Select(f => IsDiagonal(f) ? $"{BaseTypeName}.{constant}" : ZeroValue)),
                    Comment = $"Predefined diagonal-{constant} matrix"
                };
            }
            // to or from quaternion
            if (GenerateQuaternions && BaseType.IsFloatingPoint && Rows == Columns && Rows >= 3)
            {
                yield return new Constructor(this, Fields)
                {
                    Parameters = quatType.TypedArgs(" q"),
                    ConstructorChain = $"this(q.ToMat{Rows})",
                    Comment = $"Creates a rotation matrix from a {quatType.Name}."
                };

                yield return new ExplicitOperator(this)
                {
                    Parameters = quatType.TypedArgs(" q"),
                    CodeString = $"q.ToMat{Rows}",
                    Comment = $"Creates a rotation matrix from a {quatType.Name}."
                };

                yield return new Property("ToQuaternion", quatType)
                {
                    GetterLine = quatType.Name + ".FromMat" + Rows + "(this)",
                    Comment = "Creates a quaternion from the rotational part of this matrix."
                };
            }

            // predefs
            yield return new StaticProperty("Zero", this)
            {
                Value = Construct(this, ZeroValue.RepeatTimes(FieldCount)),
                Comment = "Predefined all-zero matrix"
            };

            if (!string.IsNullOrEmpty(BaseType.OneValue))
            {
                yield return new StaticProperty("Ones", this)
                {
                    Value = Construct(this, OneValue.RepeatTimes(FieldCount)),
                    Comment = "Predefined all-ones matrix"
                };

                yield return new StaticProperty("Identity", this)
                {
                    Value = Construct(this, Fields.Select(f => IsDiagonal(f) ? OneValue : ZeroValue)),
                    Comment = "Predefined identity matrix"
                };
            }




            if (BaseType.IsComplex)
            {
                yield return new StaticProperty("ImaginaryOnes", this)
                {
                    Value = Construct(this, "Complex.ImaginaryOne".RepeatTimes(FieldCount)),
                    Comment = "Predefined all-imaginary-ones matrix"
                };

                yield return new StaticProperty("ImaginaryIdentity", this)
                {
                    Value = Construct(this, Fields.Select(f => IsDiagonal(f) ? "Complex.ImaginaryOne" : ZeroValue)),
                    Comment = string.Format("Predefined diagonal-imaginary-one matrix")
                };
            }
        }

        protected IEnumerable<string> BodyLegacy
        {
            get
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

                // matrix-vector-multiplication
                foreach (var line in "Executes a matrix-vector-multiplication.".AsComment()) yield return line;
                yield return string.Format("public static {0} operator*({1} m, {2} v) => new {0}({3});",
                    VectorType.GetName(BaseType, Rows), NameThat, VectorType.GetName(BaseType, Columns),
                    Rows.ForIndexUpTo(r => Columns.ForIndexUpTo(c => "m.m" + c + r + " * v." + "xyzw"[c]).Aggregated(" + ")).CommaSeparated());

                // matrix-matrix-division
                if (Rows == Columns && BaseType.IsSigned)
                {
                    foreach (var line in "Executes a matrix-matrix-divison A / B == A * B^-1 (use with caution).".AsComment()) yield return line;
                    yield return string.Format("public static {0} operator/({0} A, {0} B) => A * B.Inverse;", NameThat);
                }


                // arithmetic operators
                foreach (var kvp in new Dictionary<string, string>
                    {
                        {"+", "+ (add)"},
                        {"-", "- (subtract)"},
                        {"/", "/ (divide)"}, // only scalar
                        {"*", "* (multiply)"} // only scalar
                    })
                {
                    var op = kvp.Key;
                    var opComment = kvp.Value;

                    var onlyScalar = op == "/" || op == "*";

                    if (!onlyScalar)
                    {
                        foreach (var line in $"Executes a component-wise {opComment}.".AsComment()) yield return line;
                        yield return ComponentWiseOperator(op);
                    }
                    foreach (var line in $"Executes a component-wise {opComment} with a scalar.".AsComment()) yield return line;
                    yield return ComponentWiseOperatorScalar(op, BaseTypeName);
                    foreach (var line in $"Executes a component-wise {opComment} with a scalar.".AsComment()) yield return line;
                    yield return ComponentWiseOperatorScalarL(op, BaseTypeName);
                }

                #region Unknown





                // Transposed
                foreach (var line in "Returns a transposed version of this matrix.".AsComment())
                    yield return line;
                yield return string.Format("public {0} Transposed => new {0}({1});", ClassNameTransposed, FieldsTransposed.CommaSeparated());



                // Logicals
                if (BaseType.IsBool)
                {
                    foreach (var line in "Returns the minimal component of this matrix.".AsComment()) yield return line;
                    yield return $"public {BaseTypeName} MinElement => {Fields.Aggregated(" && ")};";

                    foreach (var line in "Returns the maximal component of this matrix.".AsComment()) yield return line;
                    yield return $"public {BaseTypeName} MaxElement => {Fields.Aggregated(" || ")};";

                    foreach (var line in "Returns true if all component are true.".AsComment()) yield return line;
                    yield return $"public {BaseTypeName} All => {Fields.Aggregated(" && ")};";

                    foreach (var line in "Returns true if any component is true.".AsComment()) yield return line;
                    yield return $"public {BaseTypeName} Any => {Fields.Aggregated(" || ")};";

                    foreach (var line in "Executes a component-wise &amp;&amp;. (sorry for different overload but &amp;&amp; cannot be overloaded directly)".AsComment()) yield return line;
                    yield return ComponentWiseOperator("&", "&&");

                    foreach (var line in "Executes a component-wise ||. (sorry for different overload but || cannot be overloaded directly)".AsComment()) yield return line;
                    yield return ComponentWiseOperator("|", "||");
                }



                // Equality comparisons
                foreach (var line in "Returns true iff this equals rhs component-wise.".AsComment()) yield return line;
                yield return $"public bool Equals({NameThat} rhs) => {Fields.Select(c => Comparer(c.ToString())).Aggregated(" && ")};";

                if (!FullUnmanaged)
                {
                    foreach (var line in "Returns true iff this equals rhs type- and component-wise.".AsComment()) yield return line;
                    yield return "public override bool Equals(object obj)";
                    yield return "{";
                    yield return "    if (ReferenceEquals(null, obj)) return false;";
                    yield return string.Format("    return obj is {0} && Equals(({0}) obj);", NameThat);
                    yield return "}";
                }
                foreach (var line in "Returns true iff this equals rhs component-wise.".AsComment()) yield return line;
                yield return string.Format("public static bool operator ==({0} lhs, {0} rhs) => lhs.Equals(rhs);", NameThat);

                foreach (var line in "Returns true iff this does not equal rhs (component-wise).".AsComment()) yield return line;
                yield return string.Format("public static bool operator !=({0} lhs, {0} rhs) => !lhs.Equals(rhs);", NameThat);

                foreach (var line in "Returns a hash code for this instance.".AsComment()) yield return line;
                yield return "public override int GetHashCode()";
                yield return "{";
                yield return "    unchecked";
                yield return "    {";
                yield return "        return " + HashCodeFor(FieldCount - 1) + ";";
                yield return "    }";
                yield return "}";



                // Arithmetics
                var lengthType = BaseType.LengthType;

                if (!BaseType.IsComplex)
                {
                    foreach (var line in "Returns the minimal component of this matrix.".AsComment()) yield return line;
                    yield return $"public {BaseTypeName} MinElement => {NestedBiFuncFor(MathClass + ".Min({0}, {1})", FieldCount - 1, FieldFor)};";

                    foreach (var line in "Returns the maximal component of this matrix.".AsComment()) yield return line;
                    yield return $"public {BaseTypeName} MaxElement => {NestedBiFuncFor(MathClass + ".Max({0}, {1})", FieldCount - 1, FieldFor)};";
                }

                foreach (var line in "Returns the euclidean length of this matrix.".AsComment()) yield return line;
                yield return string.Format("public {0} Length => ({0}){1};", lengthType, SqrtOf(Fields.Select(SqrOf).Aggregated(" + ")));

                foreach (var line in "Returns the squared euclidean length of this matrix.".AsComment()) yield return line;
                yield return $"public {lengthType} LengthSqr => {Fields.Select(SqrOf).Aggregated(" + ")};";

                foreach (var line in "Returns the sum of all fields.".AsComment()) yield return line;
                yield return $"public {BaseTypeName} Sum => {Fields.Aggregated(" + ")};";

                foreach (var line in "Returns the euclidean norm of this matrix.".AsComment()) yield return line;
                yield return string.Format("public {0} Norm => ({0}){1};", lengthType, SqrtOf(Fields.Select(SqrOf).Aggregated(" + ")));

                foreach (var line in "Returns the one-norm of this matrix.".AsComment()) yield return line;
                yield return $"public {lengthType} Norm1 => {Fields.Select(AbsString).Aggregated(" + ")};";

                foreach (var line in "Returns the two-norm of this matrix.".AsComment()) yield return line;
                yield return string.Format("public {0} Norm2 => ({0}){1};", lengthType, SqrtOf(Fields.Select(SqrOf).Aggregated(" + ")));

                foreach (var line in "Returns the max-norm of this matrix.".AsComment()) yield return line;
                yield return $"public {BaseTypeName} NormMax => {NestedBiFuncFor(MathClass + ".Max({0}, {1})", FieldCount - 1, c => AbsString(FieldFor(c)))};";

                foreach (var line in "Returns the p-norm of this matrix.".AsComment()) yield return line;
                yield return $"public double NormP(double p) => Math.Pow({Fields.Select(c => $"Math.Pow((double){AbsString(c)}, p)").Aggregated(" + ")}, 1 / p);";

                // determinant
                if (Rows == Columns)
                {
                    foreach (var line in "Returns determinant of this matrix.".AsComment()) yield return line;
                    yield return $"public {BaseTypeName} Determinant => {HelperDet(HelperFieldsOf(Rows))};";

                    if (BaseType.IsSigned)
                    {
                        foreach (var line in "Returns the adjunct of this matrix.".AsComment()) yield return line;
                        yield return string.Format("public {0} Adjugate => new {0}({1});", NameThat, FieldsTransposed.Select(f => HelperDet(HelperSubmatrix(HelperFieldsOf(Rows), ColOf(f), RowOf(f)), ColOf(f) + RowOf(f))).CommaSeparated());

                        foreach (var line in "Returns the inverse of this matrix (use with caution).".AsComment()) yield return line;
                        yield return $"public {NameThat} Inverse => Adjugate / Determinant;";
                    }
                }

                // Indexer
                foreach (var line in $"Returns the number of Fields ({Columns} x {Rows} = {FieldCount}).".AsComment()) yield return line;
                yield return $"public const int Count = {FieldCount};";

                foreach (var line in "Gets/Sets a specific 2D-indexed component (a bit slower than direct access).".AsComment()) yield return line;
                yield return $"public {BaseTypeName} this[int col, int row]";
                yield return "{";
                yield return "    get";
                yield return "    {";
                yield return $"        return this[col * {Rows} + row];";
                yield return "    }";
                yield return "    set";
                yield return "    {";
                yield return $"        this[col * {Rows} + row] = value;";
                yield return "    }";
                yield return "}";

                #endregion


                #region Comp-wise Unknown to glsl

                // component-wise ops
                foreach (var line in "Executes a component-wise * (multiply).".AsComment()) yield return line;
                yield return string.Format("public static {0} CompMul({0} A, {0} B) => new {0}({1});", NameThat, Fields.Select(f => string.Format("A.{0} * B.{0}", f)).CommaSeparated());

                foreach (var line in "Executes a component-wise / (divide).".AsComment()) yield return line;
                yield return string.Format("public static {0} CompDiv({0} A, {0} B) => new {0}({1});", NameThat, Fields.Select(f => string.Format("A.{0} / B.{0}", f)).CommaSeparated());

                foreach (var line in "Executes a component-wise + (add).".AsComment()) yield return line;
                yield return string.Format("public static {0} CompAdd({0} A, {0} B) => new {0}({1});", NameThat, Fields.Select(f => string.Format("A.{0} + B.{0}", f)).CommaSeparated());

                foreach (var line in "Executes a component-wise - (subtract).".AsComment()) yield return line;
                yield return string.Format("public static {0} CompSub({0} A, {0} B) => new {0}({1});", NameThat, Fields.Select(f => string.Format("A.{0} - B.{0}", f)).CommaSeparated());
                #endregion
                // integer-only operators
                #region Int matrices Unknown to glsl
                if (BaseType.IsInteger)
                {
                    foreach (var kvp in new Dictionary<string, string>
                        {
                            {"%", "% (modulo)"},
                            {"^", "^ (xor)"},
                            {"|", "| (bitwise-or)"},
                            {"&", "&amp; (bitwise-and)"}
                        })
                    {
                        var op = kvp.Key;
                        var opComment = kvp.Value;

                        foreach (var line in $"Executes a component-wise {opComment}.".AsComment()) yield return line;
                        yield return ComponentWiseOperator(op);
                        foreach (var line in $"Executes a component-wise {opComment} with a scalar.".AsComment()) yield return line;
                        yield return ComponentWiseOperatorScalar(op, BaseTypeName);
                        foreach (var line in $"Executes a component-wise {opComment} with a scalar.".AsComment()) yield return line;
                        yield return ComponentWiseOperatorScalarL(op, BaseTypeName);
                    }

                    foreach (var line in "Executes a component-wise left-shift with a scalar.".AsComment()) yield return line;
                    yield return ComponentWiseOperatorScalar("<<", "int");

                    foreach (var line in "Executes a component-wise right-shift with a scalar.".AsComment()) yield return line;
                    yield return ComponentWiseOperatorScalar(">>", "int");
                }
                #endregion
                // comparisons
                #region Complex Unknown to glsl
                if (!BaseType.IsComplex)
                {
                    foreach (var kvp in new Dictionary<string, string>
                        {
                            {"<", "lesser-than"},
                            {"<=", "lesser-or-equal"},
                            {">", "greater-than"},
                            {">=", "greater-or-equal"}
                        })
                    {
                        var op = kvp.Key;
                        var opComment = kvp.Value;

                        foreach (var line in $"Executes a component-wise {opComment} comparison.".AsComment()) yield return line;
                        yield return ComparisonOperator(op);
                        foreach (var line in $"Executes a component-wise {opComment} comparison with a scalar.".AsComment()) yield return line;
                        yield return ComparisonOperatorScalar(op, BaseTypeName);
                        foreach (var line in $"Executes a component-wise {opComment} comparison with a scalar.".AsComment()) yield return line;
                        yield return ComparisonOperatorScalarL(op, BaseTypeName);
                    }
                }
                #endregion

                // special mat4x4 funcs
                #region Helpers unknown for glsl
                if (BaseType.IsFloatingPoint && Rows == 4 && Columns == 4)
                {
                    // frustum
                    foreach (var line in "Creates a frustrum projection matrix.".AsComment()) yield return line;
                    yield return string.Format("public static {0} Frustum({1} left, {1} right, {1} bottom, {1} top, {1} nearVal, {1} farVal)", NameThat, BaseTypeName);
                    yield return "{";
                    yield return "    var m = Identity;";
                    yield return "    m.m00 = (2 * nearVal) / (right - left);";
                    yield return "    m.m11 = (2 * nearVal) / (top - bottom);";
                    yield return "    m.m20 = (right + left) / (right - left);";
                    yield return "    m.m21 = (top + bottom) / (top - bottom);";
                    yield return "    m.m22 = -(farVal + nearVal) / (farVal - nearVal);";
                    yield return "    m.m23 = -1;";
                    yield return "    m.m32 = -(2 * farVal * nearVal) / (farVal - nearVal);";
                    yield return "    return m;";
                    yield return "}";

                    // infinite perspective
                    foreach (var line in "Creates a matrix for a symmetric perspective-view frustum with far plane at infinite.".AsComment()) yield return line;
                    yield return string.Format("public static {0} InfinitePerspective({1} fovy, {1} aspect, {1} zNear)", NameThat, BaseTypeName);
                    yield return "{";
                    yield return "    var range = Math.Tan((double)fovy / 2.0) * (double)zNear;";
                    yield return "    var l = -range * (double)aspect;";
                    yield return "    var r = range * (double)aspect;";
                    yield return "    var b = -range;";
                    yield return "    var t = range;";
                    yield return "    var m = Identity;";
                    yield return $"    m.m00 = ({BaseTypeName})( ((2.0)*(double)zNear)/(r - l) );";
                    yield return $"    m.m11 = ({BaseTypeName})( ((2.0)*(double)zNear)/(t - b) );";
                    yield return $"    m.m22 = ({BaseTypeName})( - (1.0) );";
                    yield return $"    m.m23 = ({BaseTypeName})( - (1.0) );";
                    yield return $"    m.m32 = ({BaseTypeName})( - (2.0)*(double)zNear );";
                    yield return "    return m;";
                    yield return "}";

                    // look at
                    foreach (var line in "Build a look at view matrix.".AsComment()) yield return line;
                    yield return string.Format("public static {0} LookAt({1} eye, {1} center, {1} up)", NameThat, VectorType.GetName(BaseType, 3));
                    yield return "{";
                    yield return "    var f = (center - eye).Normalized;";
                    yield return $"    var s = {VectorType.GetName(BaseType, 3)}.Cross(f, up).Normalized;";
                    yield return $"    var u = {VectorType.GetName(BaseType, 3)}.Cross(s, f);";
                    yield return "    var m = Identity;";
                    yield return "    m.m00 = s.x;";
                    yield return "    m.m10 = s.y;";
                    yield return "    m.m20 = s.z;";
                    yield return "    m.m01 = u.x;";
                    yield return "    m.m11 = u.y;";
                    yield return "    m.m21 = u.z;";
                    yield return "    m.m02 = -f.x;";
                    yield return "    m.m12 = -f.y;";
                    yield return "    m.m22 = -f.z;";
                    yield return $"    m.m30 = -{VectorType.GetName(BaseType, 3)}.Dot(s, eye);";
                    yield return $"    m.m31 = -{VectorType.GetName(BaseType, 3)}.Dot(u, eye);";
                    yield return $"    m.m32 = {VectorType.GetName(BaseType, 3)}.Dot(f, eye);";
                    yield return "    return m;";
                    yield return "}";

                    // ortho
                    foreach (var line in "Creates a matrix for an orthographic parallel viewing volume.".AsComment()) yield return line;
                    yield return string.Format("public static {0} Ortho({1} left, {1} right, {1} bottom, {1} top, {1} zNear, {1} zFar)", NameThat, BaseTypeName);
                    yield return "{";
                    yield return "    var m = Identity;";
                    yield return "    m.m00 = 2/(right - left);";
                    yield return "    m.m11 = 2/(top - bottom);";
                    yield return "    m.m22 = - 2/(zFar - zNear);";
                    yield return "    m.m30 = - (right + left)/(right - left);";
                    yield return "    m.m31 = - (top + bottom)/(top - bottom);";
                    yield return "    m.m32 = - (zFar + zNear)/(zFar - zNear);";
                    yield return "    return m;";
                    yield return "}";

                    foreach (var line in "Creates a matrix for projecting two-dimensional coordinates onto the screen.".AsComment()) yield return line;
                    yield return string.Format("public static {0} Ortho({1} left, {1} right, {1} bottom, {1} top)", NameThat, BaseTypeName);
                    yield return "{";
                    yield return "    var m = Identity;";
                    yield return "    m.m00 = 2/(right - left);";
                    yield return "    m.m11 = 2/(top - bottom);";
                    yield return "    m.m22 = - 1;";
                    yield return "    m.m30 = - (right + left)/(right - left);";
                    yield return "    m.m31 = - (top + bottom)/(top - bottom);";
                    yield return "    return m;";
                    yield return "}";

                    // perspective
                    foreach (var line in "Creates a perspective transformation matrix.".AsComment()) yield return line;
                    yield return string.Format("public static {0} Perspective({1} fovy, {1} aspect, {1} zNear, {1} zFar)", NameThat, BaseTypeName);
                    yield return "{";
                    yield return "    var tanHalfFovy = Math.Tan((double)fovy / 2.0);";
                    yield return "    var m = Zero;";
                    yield return $"    m.m00 = ({BaseTypeName})( 1 / ((double)aspect * tanHalfFovy) );";
                    yield return $"    m.m11 = ({BaseTypeName})( 1 / (tanHalfFovy) );";
                    yield return $"    m.m22 = ({BaseTypeName})( -(zFar + zNear) / (zFar - zNear) );";
                    yield return $"    m.m23 = ({BaseTypeName})( -1 );";
                    yield return $"    m.m32 = ({BaseTypeName})( -(2 * zFar * zNear) / (zFar - zNear) );";
                    yield return "    return m;";
                    yield return "}";

                    // perspectiveFov
                    foreach (var line in "Builds a perspective projection matrix based on a field of view.".AsComment()) yield return line;
                    yield return string.Format("public static {0} PerspectiveFov({1} fov, {1} width, {1} height, {1} zNear, {1} zFar)", NameThat, BaseTypeName);
                    yield return "{";
                    yield return "    if (width <= 0) throw new ArgumentOutOfRangeException(\"width\");";
                    yield return "    if (height <= 0) throw new ArgumentOutOfRangeException(\"height\");";
                    yield return "    if (fov <= 0) throw new ArgumentOutOfRangeException(\"fov\");";
                    yield return "    var h = Math.Cos((double)fov / 2.0) / Math.Sin((double)fov / 2.0);";
                    yield return "    var w = h * (double)(height / width);";
                    yield return "    var m = Zero;";
                    yield return $"    m.m00 = ({BaseTypeName})w;";
                    yield return $"    m.m11 = ({BaseTypeName})h;";
                    yield return "    m.m22 = - (zFar + zNear)/(zFar - zNear);";
                    yield return "    m.m23 = - 1;";
                    yield return "    m.m32 = - (2*zFar*zNear)/(zFar - zNear);";
                    yield return "    return m;";
                    yield return "}";

                    // TODO: Pick matrix

                    // project
                    foreach (var line in "Map the specified object coordinates (obj.x, obj.y, obj.z) into window coordinates.".AsComment()) yield return line;
                    yield return string.Format("public static {1} Project({1} obj, {0} model, {0} proj, {2} viewport)", NameThat, VectorType.GetName(BaseType, 3), VectorType.GetName(BaseType, 4));
                    yield return "{";
                    yield return $"    var tmp = proj * (model * new {VectorType.GetName(BaseType, 4)}(obj, 1));";
                    yield return "    tmp /= tmp.w;";
                    yield return string.Format("    tmp = tmp * {0} + {0};", ConstantSuffixFor("0.5"));
                    yield return "    tmp.x = tmp.x * viewport.z + viewport.x;";
                    yield return "    tmp.y = tmp.y * viewport.w + viewport.y;";
                    yield return "    return tmp.swizzle.xyz;";
                    yield return "}";

                    // unproject
                    foreach (var line in "Map the specified window coordinates (win.x, win.y, win.z) into object coordinates.".AsComment()) yield return line;
                    yield return string.Format("public static {1} UnProject({1} win, {0} model, {0} proj, {2} viewport)", NameThat, VectorType.GetName(BaseType, 3), VectorType.GetName(BaseType, 4));
                    yield return "{";
                    yield return $"    var tmp = new {VectorType.GetName(BaseType, 4)}(win, 1);";
                    yield return "    tmp.x = (tmp.x - viewport.x) / viewport.z;";
                    yield return "    tmp.y = (tmp.y - viewport.y) / viewport.w;";
                    yield return "    tmp = tmp * 2 - 1;";
                    yield return "";
                    yield return "    var unp = proj.Inverse * tmp;";
                    yield return "    unp /= unp.w;";
                    yield return "    var obj = model.Inverse * unp;";
                    yield return $"    return ({VectorType.GetName(BaseType, 3)})obj / obj.w;";
                    yield return "}";

                    foreach (var line in "Map the specified window coordinates (win.x, win.y, win.z) into object coordinates (faster but less precise).".AsComment()) yield return line;
                    yield return string.Format("public static {1} UnProjectFaster({1} win, {0} model, {0} proj, {2} viewport)", NameThat, VectorType.GetName(BaseType, 3), VectorType.GetName(BaseType, 4));
                    yield return "{";
                    yield return $"    var tmp = new {VectorType.GetName(BaseType, 4)}(win, 1);";
                    yield return "    tmp.x = (tmp.x - viewport.x) / viewport.z;";
                    yield return "    tmp.y = (tmp.y - viewport.y) / viewport.w;";
                    yield return "    tmp = tmp * 2 - 1;";
                    yield return "";
                    yield return "    var obj = (proj * model).Inverse * tmp;";
                    yield return $"    return ({VectorType.GetName(BaseType, 3)})obj / obj.w;";
                    yield return "}";

                    // rotate
                    foreach (var line in "Builds a rotation 4 * 4 matrix created from an axis vector and an angle in radians.".AsComment()) yield return line;
                    yield return $"public static {NameThat} Rotate({BaseTypeName} angle, {VectorType.GetName(BaseType, 3)} v)";
                    yield return "{";
                    yield return $"    var c = ({BaseTypeName})Math.Cos((double)angle);";
                    yield return $"    var s = ({BaseTypeName})Math.Sin((double)angle);";
                    yield return "";
                    yield return "    var axis = v.Normalized;";
                    yield return "    var temp = (1 - c) * axis;";
                    yield return "";
                    yield return "    var m = Identity;";
                    yield return "    m.m00 = c + temp.x * axis.x;";
                    yield return "    m.m01 = 0 + temp.x * axis.y + s * axis.z;";
                    yield return "    m.m02 = 0 + temp.x * axis.z - s * axis.y;";
                    yield return "";
                    yield return "    m.m10 = 0 + temp.y * axis.x - s * axis.z;";
                    yield return "    m.m11 = c + temp.y * axis.y;";
                    yield return "    m.m12 = 0 + temp.y * axis.z + s * axis.x;";
                    yield return "";
                    yield return "    m.m20 = 0 + temp.z * axis.x + s * axis.y;";
                    yield return "    m.m21 = 0 + temp.z * axis.y - s * axis.x;";
                    yield return "    m.m22 = c + temp.z * axis.z;";
                    yield return "    return m;";
                    yield return "}";

                    for (var axis = 0; axis < 3; ++axis)
                    {
                        foreach (var line in $"Builds a rotation matrix around Unit{"XYZ"[axis]} and an angle in radians.".AsComment()) yield return line;
                        yield return $"public static {NameThat} Rotate{"XYZ"[axis]}({BaseTypeName} angle)";
                        yield return "{";
                        // TODO: more performant
                        yield return $"    return Rotate(angle, {VectorType.GetName(BaseType, 3)}.Unit{"XYZ"[axis]});";
                        yield return "}";
                    }

                    // scale
                    foreach (var line in "Builds a scale matrix by components x, y, z.".AsComment()) yield return line;
                    yield return string.Format("public static {0} Scale({1} x, {1} y, {1} z)", NameThat, BaseTypeName);
                    yield return "{";
                    yield return "    var m = Identity;";
                    yield return "    m.m00 = x;";
                    yield return "    m.m11 = y;";
                    yield return "    m.m22 = z;";
                    yield return "    return m;";
                    yield return "}";

                    foreach (var line in "Builds a scale matrix by vector v.".AsComment()) yield return line;
                    yield return $"public static {NameThat} Scale({VectorType.GetName(BaseType, 3)} v) => Scale(v.x, v.y, v.z);";
                    foreach (var line in "Builds a scale matrix by uniform scaling s.".AsComment()) yield return line;
                    yield return $"public static {NameThat} Scale({BaseTypeName} s) => Scale(s, s, s);";

                    // translation
                    foreach (var line in "Builds a translation matrix by components x, y, z.".AsComment()) yield return line;
                    yield return string.Format("public static {0} Translate({1} x, {1} y, {1} z)", NameThat, BaseTypeName);
                    yield return "{";
                    yield return "    var m = Identity;";
                    yield return "    m.m30 = x;";
                    yield return "    m.m31 = y;";
                    yield return "    m.m32 = z;";
                    yield return "    return m;";
                    yield return "}";

                    foreach (var line in "Builds a translation matrix by vector v.".AsComment()) yield return line;
                    yield return $"public static {NameThat} Translate({VectorType.GetName(BaseType, 3)} v) => Translate(v.x, v.y, v.z);";
                }
                #endregion
            }
        }
    }
}
