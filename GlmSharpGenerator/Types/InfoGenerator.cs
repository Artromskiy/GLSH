using System.Collections.Generic;

namespace GlmSharpGenerator.Types
{
    internal class InfoGenerator
    {

        public static IEnumerable<string> InfoFile()
        {
            yield return "using System;";
            yield return "using System.Collections;";
            yield return "using System.Collections.Generic;";
            yield return "using System.Globalization;";
            yield return "using System.Runtime.InteropServices;";
            yield return "using System.Runtime.CompilerServices;";
            yield return "using System.Diagnostics.CodeAnalysis;";
            yield return "using System.Runtime.Serialization;";
            yield return "using System.Numerics;";
            yield return "using System.Linq;";
            yield return "";
            yield return "// ReSharper disable InconsistentNaming";
            yield return "";
            yield return "namespace " + AbstractType.Namespace;
            yield return "{";

            yield return "public static class GLSHInfo".Indent();
            yield return "{".Indent();

            foreach (var item in KnownTypesNames())
                yield return item.Indent(2);

            foreach (var item in KnownTypesToGlslTypes())
                yield return item.Indent(2);

            yield return "}".Indent();
            yield return "}";
        }

        private static IEnumerable<string> KnownTypesNames()
        {
            yield return "public static readonly HashSet<string> knownTypes = new HashSet<string>()";
            yield return "{";
            foreach (var item in AbstractType.Types)
                yield return $"typeof({item.Key}).FullName!,".Indent();
            yield return "};";
        }

        private static IEnumerable<string> KnownTypesToGlslTypes()
        {
            yield return "public static readonly Dictionary<string, string> knownTypesToGlslTypes = new Dictionary<string, string>()";
            yield return "{";
            foreach (var item in AbstractType.Types)
                yield return $"{{typeof({item.Key}).FullName!, \"{item.Value.GlslName}\"}},".Indent();
            yield return "};";
        }
    }
}
