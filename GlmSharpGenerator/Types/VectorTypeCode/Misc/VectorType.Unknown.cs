using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        private IEnumerable<Member> UnknownMembers() // just legacy code
        {
            var boolVType = new VectorType(BuiltinType.TypeBool, Components);
            var doubleVType = new VectorType(BuiltinType.TypeDouble, Components);
            var integerVType = new VectorType(BuiltinType.TypeInt, Components);
            var absVType = !string.IsNullOrEmpty(BaseType.AbsOverrideType) ? Types[BaseType.AbsOverrideTypePrefix + "vec" + Components] : this;
            var lengthType = new AnyType(BaseType.LengthType);


            // Basetype constants
            foreach (var constant in BaseType.TypeConstants)
            {
                yield return new StaticProperty(constant, this)
                {
                    Value = Construct(this, $"{BaseTypeName}.{constant}".RepeatTimes(Components)),
                    Comment = $"Predefined all-{constant} vector"
                };
            }


            // Equality comparisons
            yield return new Function(BuiltinType.TypeBool, "Equals")
            {
                ParameterString = NameThat + " rhs",
                CodeString = Fields.Select(Comparer).Aggregated(" && "),
                Comment = "Returns true iff this equals rhs component-wise."
            };

            yield return new Operator(BuiltinType.TypeBool, "==")
            {
                Parameters = this.LhsRhs(),
                CodeString = "lhs.Equals(rhs)",
                Comment = "Returns true iff this equals rhs component-wise."
            };

            yield return new Operator(BuiltinType.TypeBool, "!=")
            {
                Parameters = this.LhsRhs(),
                CodeString = "!lhs.Equals(rhs)",
                Comment = "Returns true iff this does not equal rhs (component-wise)."
            };

            yield return new Function(BuiltinType.TypeInt, "GetHashCode")
            {
                Override = true,
                Code = new[]
                {
                    "unchecked",
                    "{",
                    $"    return {HashCodeFor(Components - 1)};",
                    "}"
                },
                Comment = "Returns a hash code for this instance."
            };

            if (BaseType.HasArithmetics && !BaseType.IsInteger)
                yield return new Function(BuiltinType.TypeBool, "ApproxEqual")
                {
                    Static = true,
                    Parameters = this.TypedArgs("lhs", "rhs").Concat(lengthType.TypedArgs("eps = " + lengthType.ConstantSuffixFor("0.1"))),
                    CodeString = "Distance(lhs, rhs) <= eps",
                    Comment = "Returns true iff distance between lhs and rhs is less than or equal to epsilon"
                };

            // Component-wise static functions

            if (BaseType.HasComparisons)
            {
                yield return new ComponentWiseOperator(Fields, boolVType, "<", this, "lhs", this, "rhs", "{0} < {1}");
                yield return new ComponentWiseOperator(Fields, boolVType, "<=", this, "lhs", this, "rhs", "{0} <= {1}");
                yield return new ComponentWiseOperator(Fields, boolVType, ">", this, "lhs", this, "rhs", "{0} > {1}");
                yield return new ComponentWiseOperator(Fields, boolVType, ">=", this, "lhs", this, "rhs", "{0} >= {1}");
            }

            if (BaseType.IsBool)
            {
                yield return new ComponentWiseStaticFunction(Fields, boolVType, "Not", this, "v", "!{0}");
                yield return new ComponentWiseOperator(Fields, this, "!", this, "v", "!{0}");
                yield return new ComponentWiseStaticFunction(Fields, this, "And", this, "lhs", this, "rhs", "{0} && {1}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Nand", this, "lhs", this, "rhs", "!({0} && {1})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Or", this, "lhs", this, "rhs", "{0} || {1}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Nor", this, "lhs", this, "rhs", "!({0} || {1})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Xor", this, "lhs", this, "rhs", "{0} != {1}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Xnor", this, "lhs", this, "rhs", "{0} == {1}");
                yield return new ComponentWiseOperator(Fields, this, "&", this, "lhs", this, "rhs", "{0} && {1}");
                yield return new ComponentWiseOperator(Fields, this, "|", this, "lhs", this, "rhs", "{0} || {1}");
            }

            // Basetype test functions
            foreach (var kvp in BaseType.TypeTestFuncs)
                yield return new ComponentWiseStaticFunction(Fields, boolVType, kvp.Key, this, "v", kvp.Value);

            if (BaseType.HasArithmetics)
            {
                yield return new ComponentWiseStaticFunction(Fields, absVType, "Abs", this, "v", AbsString("{0}"));
                yield return new ComponentWiseStaticFunction(Fields, this, "HermiteInterpolationOrder3", this, "v", "(3 - 2 * {0}) * {0} * {0}");
                yield return new ComponentWiseStaticFunction(Fields, this, "HermiteInterpolationOrder5", this, "v", "((6 * {0} - 15) * {0} + 10) * {0} * {0} * {0}");

                yield return new ComponentWiseStaticFunction(Fields, this, "Sqr", this, "v", "{0} * {0}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Pow2", this, "v", "{0} * {0}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Pow3", this, "v", "{0} * {0} * {0}");

                // TODO: Acosh, Asinh, Atanh

                yield return new ComponentWiseStaticFunction(Fields, this, "Step", this, "v", string.Format("{{0}} >= {0} ? {1} : {0}", ZeroValue, OneValue));
                yield return new ComponentWiseStaticFunction(Fields, this, "Sqrt", this, "v", $"({BaseTypeName})Math.Sqrt((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "InverseSqrt", this, "v", $"({BaseTypeName})(1.0 / Math.Sqrt((double){{0}}))");
                yield return new ComponentWiseStaticFunction(Fields, integerVType, "Sign", this, "v", "Math.Sign({0})");

                yield return new ComponentWiseStaticFunction(Fields, this, "Max", this, "lhs", this, "rhs", MathClass + ".Max({0}, {1})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Min", this, "lhs", this, "rhs", MathClass + ".Min({0}, {1})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Pow", this, "lhs", this, "rhs", BaseTypeCast + "Math.Pow((double){0}, (double){1})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Log", this, "lhs", this, "rhs", BaseTypeCast + "Math.Log((double){0}, (double){1})");
                // TODO: Check if v > max ? max : v < min ? min : v is faster
                yield return new ComponentWiseStaticFunction(Fields, this, "Clamp", this, "v", this, "min", this, "max", MathClass + ".Min(" + MathClass + ".Max({0}, {1}), {2})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Mix", this, "min", this, "max", this, "a", "{0} * (1-{2}) + {1} * {2}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Lerp", this, "min", this, "max", this, "a", "{0} * (1-{2}) + {1} * {2}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Smoothstep", this, "edge0", this, "edge1", this, "v", "(({2} - {0}) / ({1} - {0})).Clamp().HermiteInterpolationOrder3()");
                yield return new ComponentWiseStaticFunction(Fields, this, "Smootherstep", this, "edge0", this, "edge1", this, "v", "(({2} - {0}) / ({1} - {0})).Clamp().HermiteInterpolationOrder5()");

                yield return new ComponentWiseStaticFunction(Fields, this, "Fma", this, "a", this, "b", this, "c", "{0} * {1} + {2}");

                // outer product
                // TODO: add to respective matrices
                for (var comps = 2; comps <= 4; ++comps)
                {
                    var otherVec = new VectorType(BaseType, comps);
                    var matThisThat = new MatrixType(BaseType, Components, comps);
                    var matThatThis = new MatrixType(BaseType, comps, Components);

                    yield return new Function(matThisThat, "OuterProduct")
                    {
                        Static = true,
                        Parameters = new[] { otherVec.Name + " c", this.Name + " r" },
                        CodeString = Construct(matThisThat, Components.ForIndexUpTo(ArgOfs).SelectMany(c => comps.ForIndexUpTo(ArgOf).Format("c.{0} * r." + c))),
                        Comment = "OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r."
                    };

                    if (comps != Components)
                        yield return new Function(matThatThis, "OuterProduct")
                        {
                            Static = true,
                            Parameters = new[] { this.Name + " c", otherVec.Name + " r" },
                            CodeString = Construct(matThatThis, comps.ForIndexUpTo(ArgOfs).SelectMany(c => Components.ForIndexUpTo(ArgOf).Format("c.{0} * r." + c))),
                            Comment = "OuterProduct treats the first parameter c as a column vector (matrix with one column) and the second parameter r as a row vector (matrix with one row) and does a linear algebraic matrix multiply c * r, yielding a matrix whose number of rows is the number of components in c and whose number of columns is the number of components in r."
                        };
                }

                // Operators
                yield return new ComponentWiseStaticFunction(Fields, this, "Add", this, "lhs", this, "rhs", "{0} + {1}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Sub", this, "lhs", this, "rhs", "{0} - {1}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Mul", this, "lhs", this, "rhs", "{0} * {1}");
                yield return new ComponentWiseStaticFunction(Fields, this, "Div", this, "lhs", this, "rhs", "{0} / {1}");

                yield return new ComponentWiseOperator(Fields, this, "+", this, "lhs", this, "rhs", "{0} + {1}");
                yield return new ComponentWiseOperator(Fields, this, "-", this, "lhs", this, "rhs", "{0} - {1}");
                yield return new ComponentWiseOperator(Fields, this, "*", this, "lhs", this, "rhs", "{0} * {1}");
                yield return new ComponentWiseOperator(Fields, this, "/", this, "lhs", this, "rhs", "{0} / {1}");

                yield return new ComponentWiseOperator(Fields, this, "+", this, "v", "identity") { ReturnOverride = "v" };

                if (BaseType.IsSigned)
                    yield return new ComponentWiseOperator(Fields, this, "-", this, "v", "-{0}");

                if (BaseType.IsInteger)
                {
                    yield return new ComponentWiseStaticFunction(Fields, this, "Xor", this, "lhs", this, "rhs", "{0} ^ {1}");
                    yield return new ComponentWiseStaticFunction(Fields, this, "BitwiseOr", this, "lhs", this, "rhs", "{0} | {1}");
                    yield return new ComponentWiseStaticFunction(Fields, this, "BitwiseAnd", this, "lhs", this, "rhs", "{0} & {1}");

                    yield return new ComponentWiseOperator(Fields, this, "~", this, "v", "~{0}");
                    yield return new ComponentWiseOperator(Fields, this, "^", this, "lhs", this, "rhs", "{0} ^ {1}");
                    yield return new ComponentWiseOperator(Fields, this, "|", this, "lhs", this, "rhs", "{0} | {1}");
                    yield return new ComponentWiseOperator(Fields, this, "&", this, "lhs", this, "rhs", "{0} & {1}");

                    yield return new ComponentWiseStaticFunction(Fields, this, "LeftShift", this, "lhs", integerVType, "rhs", "{0} << {1}");
                    yield return new ComponentWiseStaticFunction(Fields, this, "RightShift", this, "lhs", integerVType, "rhs", "{0} >> {1}");
                    yield return new ComponentWiseOperator(Fields, this, "<<", this, "lhs", BuiltinType.TypeInt, "rhs", "{0} << {1}") { CanScalar0 = false, CanScalar1 = false };
                    yield return new ComponentWiseOperator(Fields, this, ">>", this, "lhs", BuiltinType.TypeInt, "rhs", "{0} >> {1}") { CanScalar0 = false, CanScalar1 = false };
                }
            }

            if (BaseType.IsFloatingPoint)
            {
                yield return new ComponentWiseStaticFunction(Fields, this, "Modulo", this, "lhs", this, "rhs", "{0} % {1}");
                yield return new ComponentWiseOperator(Fields, this, "%", this, "lhs", this, "rhs", "{0} % {1}");

                yield return new ComponentWiseStaticFunction(Fields, this, "Degrees", this, "v", BaseTypeCast + "({0} * " + ConstantSuffixFor("57.295779513082320876798154814105170332405472466564321") + ")") { AdditionalComment = "Radians-To-Degrees Conversion" };
                yield return new ComponentWiseStaticFunction(Fields, this, "Radians", this, "v", BaseTypeCast + "({0} * " + ConstantSuffixFor("0.0174532925199432957692369076848861271344287188854172") + ")") { AdditionalComment = "Degrees-To-Radians Conversion" };

                yield return new ComponentWiseStaticFunction(Fields, this, "Acos", this, "v", $"({BaseTypeName})Math.Acos((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Asin", this, "v", $"({BaseTypeName})Math.Asin((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Atan", this, "v", $"({BaseTypeName})Math.Atan((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Cos", this, "v", $"({BaseTypeName})Math.Cos((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Cosh", this, "v", $"({BaseTypeName})Math.Cosh((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Exp", this, "v", $"({BaseTypeName})Math.Exp((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Log", this, "v", $"({BaseTypeName})Math.Log((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Log2", this, "v", $"({BaseTypeName})Math.Log((double){{0}}, 2)");
                yield return new ComponentWiseStaticFunction(Fields, this, "Log10", this, "v", $"({BaseTypeName})Math.Log10((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Floor", this, "v", $"({BaseTypeName})Math.Floor({{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Ceiling", this, "v", $"({BaseTypeName})Math.Ceiling({{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Round", this, "v", $"({BaseTypeName})Math.Round({{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Sin", this, "v", $"({BaseTypeName})Math.Sin((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Sinh", this, "v", $"({BaseTypeName})Math.Sinh((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Tan", this, "v", $"({BaseTypeName})Math.Tan((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Tanh", this, "v", $"({BaseTypeName})Math.Tanh((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Truncate", this, "v", $"({BaseTypeName})Math.Truncate((double){{0}})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Fract", this, "v", $"({BaseTypeName})({{0}} - Math.Floor({{0}}))");
                yield return new ComponentWiseStaticFunction(Fields, this, "Trunc", this, "v", "(long)({0})");
            }


            // Logicals
            if (BaseType.IsBool)
            {
                yield return new AggregatedProperty(Fields, "MinElement", BaseType, "&&", "Returns the minimal component of this vector.");
                yield return new AggregatedProperty(Fields, "MaxElement", BaseType, "||", "Returns the maximal component of this vector.");
                yield return new AggregatedProperty(Fields, "All", BaseType, "&&", "Returns true if all component are true.");
                yield return new AggregatedProperty(Fields, "Any", BaseType, "||", "Returns true if any component is true.");
            }

            // Aggregated Properties
            if (BaseType.HasArithmetics)
            {
                yield return new Property("MinElement", BaseType)
                {
                    GetterLine = NestedSymmetricFunction(Fields, MathClass + ".Min({0}, {1})"),
                    Comment = "Returns the minimal component of this vector."
                };
                yield return new Property("MaxElement", BaseType)
                {
                    GetterLine = NestedSymmetricFunction(Fields, MathClass + ".Max({0}, {1})"),
                    Comment = "Returns the maximal component of this vector."
                };

                yield return new Property("Length", lengthType)
                {
                    GetterLine = "(" + lengthType.Name + ")" + SqrtOf(Fields.Select(SqrOf).Aggregated(" + ")),
                    Comment = "Returns the euclidean length of this vector."
                };

                yield return new AggregatedProperty(Fields.Select(SqrOf), "LengthSqr", lengthType, "+", "Returns the squared euclidean length of this vector.");
                yield return new AggregatedProperty(Fields, "Sum", BaseType, "+", "Returns the sum of all components.");

                yield return new Property("Norm", lengthType)
                {
                    GetterLine = "(" + lengthType.Name + ")" + SqrtOf(Fields.Select(SqrOf).Aggregated(" + ")),
                    Comment = "Returns the euclidean norm of this vector."
                };
                yield return new Property("Norm1", lengthType)
                {
                    GetterLine = Fields.Select(AbsString).Aggregated(" + "),
                    Comment = "Returns the one-norm of this vector."
                };
                yield return new Property("Norm2", lengthType)
                {
                    GetterLine = "(" + lengthType.Name + ")" + SqrtOf(Fields.Select(SqrOf).Aggregated(" + ")),
                    Comment = "Returns the two-norm (euclidean length) of this vector."
                };
                yield return new Property("NormMax", lengthType)
                {
                    GetterLine = NestedSymmetricFunction(Fields.Select(AbsString), MathClass + ".Max({0}, {1})"),
                    Comment = "Returns the max-norm of this vector."
                };
                yield return new Function(new AnyType("double"), "NormP")
                {
                    ParameterString = "double p",
                    CodeString = $"Math.Pow({Fields.Select(c => $"Math.Pow((double){AbsString(c)}, p)").Aggregated(" + ")}, 1 / p)",
                    Comment = "Returns the p-norm of this vector."
                };

                // normalized
                if (!BaseType.IsInteger)
                {
                    yield return new Property("Normalized", this)
                    {
                        GetterLine = $"this / {BaseTypeCast}Length",
                        Comment = "Returns a copy of this vector with length one (undefined if this has zero length)."
                    };
                    yield return new Property("NormalizedSafe", this)
                    {
                        GetterLine = $"this == Zero ? Zero : this / {BaseTypeCast}Length",
                        Comment = "Returns a copy of this vector with length one (returns zero if length is zero)."
                    };
                }
            }



            // Arithmetic Funcs
            if (BaseType.HasArithmetics)
            {
                // dot
                yield return new Function(BaseType, "Dot")
                {
                    Static = true,
                    Parameters = this.LhsRhs(),
                    CodeString = Fields.Format(DotFormatString).Aggregated(" + "),
                    Comment = "Returns the inner product (dot product, scalar product) of the two vectors."
                };

                // distance
                yield return new Function(lengthType, "Distance")
                {
                    Static = true,
                    Parameters = this.LhsRhs(),
                    CodeString = "(lhs - rhs).Length",
                    Comment = "Returns the euclidean distance between the two vectors."
                };
                yield return new Function(lengthType, "DistanceSqr")
                {
                    Static = true,
                    Parameters = this.LhsRhs(),
                    CodeString = "(lhs - rhs).LengthSqr",
                    Comment = "Returns the squared euclidean distance between the two vectors."
                };

                // cross product
                switch (Components)
                {
                    case 3:
                        yield return new Function(this, "Cross")
                        {
                            Static = true,
                            Parameters = this.TypedArgs("l", "r"),
                            CodeString = Construct(this, "l.y * r.z - l.z * r.y, l.z * r.x - l.x * r.z, l.x * r.y - l.y * r.x"),
                            Comment = "Returns the outer product (cross product, vector product) of the two vectors."
                        };
                        break;
                    case 2:
                        yield return new Function(BaseType, "Cross")
                        {
                            Static = true,
                            Parameters = this.TypedArgs("l", "r"),
                            CodeString = "l.x * r.y - l.y * r.x",
                            Comment = "Returns the length of the outer product (cross product, vector product) of the two vectors."
                        };
                        break;
                }

                if (BaseType.IsSigned)
                {
                    // reflect
                    yield return new Function(this, "Reflect")
                    {
                        Static = true,
                        Parameters = this.TypedArgs("I", "N"),
                        CodeString = "I - 2 * Dot(N, I) * N",
                        Comment = "Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result)."
                    };

                    // refract
                    yield return new Function(this, "Refract")
                    {
                        Static = true,
                        Parameters = this.TypedArgs("I", "N").SConcat(BaseTypeName + " eta"),
                        Code = new[]
                        {
                                "var dNI = Dot(N, I);",
                                "var k = 1 - eta * eta * (1 - dNI * dNI);",
                                "if (k < 0) return Zero;",
                                string.Format("return eta * I - (eta * dNI + ({1}){0}) * N;", SqrtOf("k"), BaseTypeName)
                            },
                        Comment = "Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result)."
                    };

                    // faceforward
                    yield return new Function(this, "FaceForward")
                    {
                        Static = true,
                        Parameters = this.TypedArgs("N", "I", "Nref"),
                        CodeString = "Dot(Nref, I) < 0 ? N : -N",
                        Comment = "Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N)."
                    };
                }
            }
        }
    }
}
