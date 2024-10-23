using GlmSharpGenerator.Members;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType
    {

        public override IEnumerable<Member> GenerateMembers()
        {
            // fields
            foreach (var f in Fields)
                yield return new Field(f, BaseType) { Comment = $"{f}-component" };

            foreach (var item in Constructors())
                yield return item;

            foreach (var item in Operators())
                yield return item;

            foreach (var item in TrigonometryFunctions())
                yield return item;

            foreach (var item in GeometryFunctions())
                yield return item;

            foreach (var item in ExponentialFunctions())
                yield return item;

            foreach (var item in RelationalFunctions())
                yield return item;

            foreach (var item in CommonFunctions())
                yield return item;

            // values
            yield return new Function(new ArrayType(BaseType), "GetValues")
            {
                Static = true,
                Extension = true,
                Parameters = [$"this {Name} value"],
                CodeString = $"new[] {{ {CompString.CommaSeparated("value")} }}",
                Comment = "Returns an array with all values"
            };

            yield return new Function(new AnyType($"IEnumerator<{BaseTypeName}>"), "GetEnumerator")
            {
                Static = true,
                Extension = true,
                Parameters = [$"this {Name} value"],
                Code = Fields.Select(f => $"yield return value.{f};"),
                Comment = "Returns an enumerator that iterates through all fields."
            };

            // ToString
            yield return new Function(new AnyType("string"), "ToString")
            {
                Override = true,
                CodeString = "ToString(\", \")",
                Comment = "Returns a string representation of this vector using ', ' as a seperator."
            };
            yield return new Function(new AnyType("string"), "ToString")
            {
                ParameterString = "string sep",
                Visibility = "private",
                CodeString = Fields.Aggregated(" + sep + "),
                Comment = "Returns a string representation of this vector using a provided seperator."
            };

            yield return new Field("Count", BuiltinType.TypeInt)
            {
                Constant = true,
                DefaultValue = Components.ToString(),
                Comment = $"Returns the number of components ({Components})."
            };

            yield return new Indexer(BaseType)
            {
                ParameterString = "int index",
                Getter = [$"if ((uint)index >= Count)",
                          "    throw new ArgumentOutOfRangeException(nameof(index));",
                          "return Unsafe.Add(ref x, index);"],
                Setter = [$"if ((uint)index >= Count)",
                          "    throw new ArgumentOutOfRangeException(nameof(index));",
                          "Unsafe.Add(ref x, index) = value;"],
                Comment = "Gets/Sets a specific indexed component (a bit slower than direct access)."
            };

        }

    }
}
