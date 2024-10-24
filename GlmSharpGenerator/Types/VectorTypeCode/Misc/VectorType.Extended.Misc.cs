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
