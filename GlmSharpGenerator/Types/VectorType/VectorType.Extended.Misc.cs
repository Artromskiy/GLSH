using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {
        private IEnumerable<Member> MiscFunctions()
        {
            var doubleVType = new VectorType(BuiltinType.TypeDouble, Components);

            // ienumerable ctors
            yield return new Constructor(this, Fields)
            {
                ParameterString = $"IReadOnlyList<{BaseTypeName}> v",
                Code = new[] { string.Format("var c = v.Count;") },
                Initializers = Components.ForIndexUpTo(i => string.Format("c < {0} ? {1} : v[{0}]", i, ZeroValue)),
                Comment = "From-array/list constructor (superfluous values are ignored, missing values are zero-filled)."
            };
            yield return new Constructor(this, Fields)
            {
                ParameterString = "Object[] v",
                Code = new[] { string.Format("var c = v.Length;") },
                Initializers = Components.ForIndexUpTo(i => string.Format("c < {0} ? {1} : ({2})v[{0}]", i, ZeroValue, BaseTypeName)),
                Comment = "Generic from-array constructor (superfluous values are ignored, missing values are zero-filled)."
            };
            yield return new Constructor(this, Fields)
            {
                ParameterString = $"{BaseTypeName}[] v",
                Code = new[] { string.Format("var c = v.Length;") },
                Initializers = Components.ForIndexUpTo(i => string.Format("c < {0} ? {1} : v[{0}]", i, ZeroValue)),
                Comment = "From-array constructor (superfluous values are ignored, missing values are zero-filled)."
            };
            yield return new Constructor(this, Fields)
            {
                ParameterString = $"{BaseTypeName}[] v, int startIndex",
                Code = new[] { string.Format("var c = v.Length;") },
                Initializers = Components.ForIndexUpTo(i => string.Format("c + startIndex < {0} ? {1} : v[{0} + startIndex]", i, ZeroValue)),
                Comment = "From-array constructor with base index (superfluous values are ignored, missing values are zero-filled)."
            };
            yield return new Constructor(this, Fields)
            {
                ParameterString = $"IEnumerable<{BaseTypeName}> v",
                ConstructorChain = "this(v.ToArray())",
                Comment = "From-IEnumerable constructor (superfluous values are ignored, missing values are zero-filled)."
            };
            yield return new Constructor(this, Fields)
            {
                ParameterString = $"IEnumerable<{BaseTypeName}> v",
                ConstructorChain = $"this(new List<{BaseTypeName}>(v).ToArray())",
                Comment = "From-IEnumerable constructor (superfluous values are ignored, missing values are zero-filled)."
            };




            //Equals
            yield return new Function(BuiltinType.TypeBool, "Equals")
            {
                Override = true,
                ParameterString = "object obj",
                Code = new[]
                {
                    "if (ReferenceEquals(null, obj)) return false;",
                    string.Format("return obj is {0} && Equals(({0}) obj);", NameThat)
                },
                Comment = "Returns true iff this equals rhs type- and component-wise."
            };

            // ToString
            if (!BaseType.Generic)
            {
                yield return new Function(new AnyType("string"), "ToString")
                {
                    ParameterString = "string sep, IFormatProvider provider",
                    CodeString = Fields.Select(f => f + ".ToString(provider)").Aggregated(" + sep + "),
                    Comment = "Returns a string representation of this vector using a provided seperator and a format provider for each component."
                };
                if (BaseType.HasFormatString)
                {
                    yield return new Function(new AnyType("string"), "ToString")
                    {
                        ParameterString = "string sep, string format",
                        CodeString = Fields.Select(f => f + ".ToString(format)").Aggregated(" + sep + "),
                        Comment = "Returns a string representation of this vector using a provided seperator and a format for each component."
                    };
                    yield return new Function(new AnyType("string"), "ToString")
                    {
                        ParameterString = "string sep, string format, IFormatProvider provider",
                        CodeString = Fields.Select(f => f + ".ToString(format, provider)").Aggregated(" + sep + "),
                        Comment = "Returns a string representation of this vector using a provided seperator and a format and format provider for each component."
                    };
                }
            }

            // Enumerator casts
            yield return new ExplicitOperator(new ArrayType(BaseType))
            {
                ParameterString = NameThat + " v",
                CodeString = $"new [] {{ {Fields.Select(f => "v." + f).CommaSeparated()} }}",
                Comment = $"Explicitly converts this to a {BaseTypeName} array."
            };
            yield return new ExplicitOperator(new AnyType("Object[]"))
            {
                ParameterString = NameThat + " v",
                CodeString = $"new Object[] {{ {Fields.Select(f => "v." + f).CommaSeparated()} }}",
                Comment = string.Format("Explicitly converts this to a generic object array.")
            };

            // IEnumerable
            yield return new Function(new AnyType($"IEnumerator<{BaseTypeName}>"), "GetEnumerator")
            {
                Code = Fields.Select(f => $"yield return {f};"),
                Comment = "Returns an enumerator that iterates through all components."
            };

            yield return new Function(new AnyType("IEnumerator"), "IEnumerable.GetEnumerator")
            {
                Visibility = "",
                CodeString = "GetEnumerator()",
                Comment = "Returns an enumerator that iterates through all components."
            };




            if (BaseType.IsComplex)
            {
                yield return new ComponentWiseStaticFunction(Fields, this, "Acos", this, "v", "Complex.Acos({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Asin", this, "v", "Complex.Asin({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Atan", this, "v", "Complex.Atan({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Cos", this, "v", "Complex.Cos({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Cosh", this, "v", "Complex.Cosh({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Exp", this, "v", "Complex.Exp({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Log", this, "v", "Complex.Log({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Log2", this, "v", "Complex.Log({0}, 2.0)");
                yield return new ComponentWiseStaticFunction(Fields, this, "Log10", this, "v", "Complex.Log10({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Reciprocal", this, "v", "Complex.Reciprocal({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Sin", this, "v", "Complex.Sin({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Sinh", this, "v", "Complex.Sinh({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Sqrt", this, "v", "Complex.Sqrt({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "InverseSqrt", this, "v", "Complex.One / Complex.Sqrt({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Tan", this, "v", "Complex.Tan({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Tanh", this, "v", "Complex.Tanh({0})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Conjugate", this, "v", "Complex.Conjugate({0})");

                yield return new ComponentWiseStaticFunction(Fields, this, "Pow", this, "lhs", this, "rhs", "Complex.Pow({0}, {1})");
                yield return new ComponentWiseStaticFunction(Fields, this, "Log", this, "lhs", doubleVType, "rhs", "Complex.Log({0}, {1})");

                yield return new ComponentWiseStaticFunction(Fields, this, "FromPolarCoordinates", doubleVType, "magnitude", doubleVType, "phase", "Complex.FromPolarCoordinates({0}, {1})");
            }

            if (BaseType.IsComplex)
            {
                yield return new StaticProperty("ImaginaryOnes", this)
                {
                    Value = Construct(this, "Complex.ImaginaryOne".RepeatTimes(Components)),
                    Comment = "Predefined all-imaginary-ones vector"
                };

                for (var c = 0; c < Components; ++c)
                    yield return new StaticProperty("ImaginaryUnit" + ArgOfUpper(c), this)
                    {
                        Value = Construct(this, c.ImpulseString("Complex.ImaginaryOne", ZeroValue, Components)),
                        Comment = $"Predefined unit-imaginary-{ArgOfUpper(c)} vector"
                    };
            }

            // Complex properties
            if (BaseType.IsComplex)
            {
                yield return new Property("Magnitude", doubleVType)
                {
                    GetterLine = Construct(doubleVType, Fields.Format("{0}.Magnitude")),
                    Comment = "Returns a vector containing component-wise magnitudes."
                };
                yield return new Property("Phase", doubleVType)
                {
                    GetterLine = Construct(doubleVType, Fields.Format("{0}.Phase")),
                    Comment = "Returns a vector containing component-wise phases."
                };
                yield return new Property("Imaginary", doubleVType)
                {
                    GetterLine = Construct(doubleVType, Fields.Format("{0}.Imaginary")),
                    Comment = "Returns a vector containing component-wise imaginary parts."
                };
                yield return new Property("Real", doubleVType)
                {
                    GetterLine = Construct(doubleVType, Fields.Format("{0}.Real")),
                    Comment = "Returns a vector containing component-wise real parts."
                };
            }

            // angle
            if (Components == 2 && BaseType.IsFloatingPoint)
            {
                yield return new Property("Angle", BuiltinType.TypeDouble)
                {
                    GetterLine = "Math.Atan2((double)y, (double)x)",
                    Comment = "Returns the vector angle (atan2(y, x)) in radians."
                };

                yield return new Function(this, "FromAngle")
                {
                    Static = true,
                    ParameterString = "double angleInRad",
                    CodeString = Construct(this, string.Format("({0})Math.Cos(angleInRad), ({0})Math.Sin(angleInRad)", BaseTypeName)),
                    Comment = "Returns a unit 2D vector with a given angle in radians (CAUTION: result may be truncated for integer types)."
                };

                yield return new Function(this, "Rotated")
                {
                    ParameterString = "double angleInRad",
                    CodeString = $"({Name})({GetName(BuiltinType.TypeDouble, 2)}.FromAngle(Angle + angleInRad) * (double)Length)",
                    Comment = "Returns a 2D vector that was rotated by a given angle in radians (CAUTION: result is casted and may be truncated)."
                };
            }
        }
    }
}
