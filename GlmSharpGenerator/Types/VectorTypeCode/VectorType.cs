﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal partial class VectorType : AbstractType
    {
        public override string GlslName => BaseName = BaseType.Prefix + "vec" + Components;

        public VectorType(BuiltinType type, int comps)
        {
            Components = comps;
            BaseType = type;
            BaseName = type.Prefix + "vec";
        }

        public int Components { get; set; } = 3;

        public IEnumerable<string> Fields => "xyzw".Substring(0, Components).Select(c => c.ToString());
        public override string Name => GetName(BaseType, Components);
        public override string Folder => "Vec" + Components;
        public override string DataContractArg { get; } = "(Namespace = \"vec\")";
        public string CompString => "xyzw".Substring(0, Components);
        public override string TypeComment => $"A vector of type {BaseTypeName} with {Components} components.";
        public string CompArgString => CompString.CommaSeparated();
        public char ArgOf(int c) => "xyzw"[c];
        public string ArgOfs(int c) => "xyzw"[c].ToString();
        public char ArgOfUpper(int c) => char.ToUpper("xyzw"[c]);

        public static string GetName(BuiltinType type, int components) => type.Name + components;


        public IEnumerable<string> SubCompParameters(int start, int end) => "xyzw".Substring(start, end - start + 1).Select(c => BaseTypeName + " " + c);
        public string SubCompParameterString(int start, int end) => SubCompParameters(start, end).CommaSeparated();
        public IEnumerable<string> SubCompArgs(int start, int end) => "xyzw".Substring(start, end - start + 1).Select(c => c.ToString());
        public string HashCodeFor(int c) => (c == 0 ? "" : $"(({HashCodeFor(c - 1)}) * {BaseType.HashCodeMultiplier}) ^ ") + HashCodeOf(ArgOf(c).ToString());
        public string NestedBiFuncFor(string format, int c, Func<int, string> argOf) => c == 0 ? argOf(c) : string.Format(format, NestedBiFuncFor(format, c - 1, argOf), argOf(c));

    }
}
