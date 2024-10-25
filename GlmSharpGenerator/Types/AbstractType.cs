﻿using GlmSharpGenerator.Members;
using GlmSharpGenerator.Tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlmSharpGenerator.Types
{
    internal abstract class AbstractType
    {
        public const bool GenerateHalfs = false;
        public const bool GenerateDecimals = false;
        public const bool GenerateLongs = false;
        public const bool GenerateQuaternions = false;

        public const bool FullUnmanaged = true;

        public const bool SeparateUnmanagedAsExtensions = true;

        /// <summary>
        /// true iff test generation is active
        /// </summary>
        public static bool TestMode { get; set; }

        /// <summary>
        /// Random
        /// </summary>
        public static Random Random = new Random(1234);

        /// <summary>
        /// All known types
        /// </summary>
        public static readonly Dictionary<string, AbstractType> Types = new Dictionary<string, AbstractType>();

        /// <summary>
        /// Math class prefix
        /// </summary>
        public virtual string MathClass => BaseType?.MathClass;

        /// <summary>
        /// Additional Attributes for type
        /// </summary>
        public virtual IEnumerable<string> Attributes =>
        [
            "Serializable",
            $"DataContract{DataContractArg}",
            "StructLayout(LayoutKind.Sequential)"
        ];

        /// <summary>
        /// Base name (e.g. vec, mat, quat)
        /// </summary>
        public string BaseName { get; set; } = "vec";

        /// <summary>
        /// Name of corresponding type in GLSL
        /// </summary>
        public virtual string GlslName { get; }
        /// <summary>
        /// Name of the base type
        /// </summary>
        public string BaseTypeName => BaseType.Name;
        /// <summary>
        /// Cast to basetype
        /// </summary>
        public string BaseTypeCast => "(" + BaseTypeName + ")";
        /// <summary>
        /// Actual name of the type (e.g. the C# class name)
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Name used for parameter types (for generics has T)
        /// </summary>
        public string NameThat => Name;
        /// <summary>
        /// Reference to base type
        /// </summary>
        public BuiltinType BaseType { get; set; }

        /// <summary>
        /// Namespace of this type
        /// </summary>
        public static string Namespace { get; } = "GLSH";

        /// <summary>
        /// Additional arg for data contracts
        /// </summary>
        public virtual string DataContractArg { get; } = "";

        /// <summary>
        /// Folder for this type
        /// </summary>
        public virtual string Folder { get; } = "";
        /// <summary>
        /// Class name for tests
        /// </summary>
        public virtual string TestClassName => BaseTypeName.Capitalized() + Folder + "Test";
        /// <summary>
        /// Folder with trailing /
        /// </summary>
        public string PathOf(string basePath) => string.IsNullOrEmpty(Folder) ? Path.Combine(basePath, Name + ".cs") : Path.Combine(basePath, Folder, Name + ".cs");
        public string GlmPathOf(string basePath) => string.IsNullOrEmpty(Folder) ? Path.Combine(basePath, Name + ".cs") : Path.Combine(basePath, Folder, Name + ".glm.cs");
        public string ExtPathOf(string basePath) => string.IsNullOrEmpty(Folder) ? Path.Combine(basePath, Name + ".cs") : Path.Combine(basePath, Folder, Name + ".ext.cs");
        public static string InfoPathOf(string basePath, string Name) => Path.Combine(basePath, Name + ".cs");

        /// <summary>
        /// Comment of this type
        /// </summary>
        public abstract string TypeComment { get; }

        /// <summary>
        /// List of C# base classes (mostly interfaces)
        /// </summary>
        public virtual IEnumerable<string> BaseClasses { get { yield break; } }

        /// <summary>
        /// All members
        /// </summary>
        public Member[] members;
        private Field[] fields;
        private Constructor[] constructors;
        private Property[] properties;
        private Property[] staticProperties;
        private ImplicitOperator[] implicitOperators;
        private ExplicitOperator[] explicitOperators;
        private Operator[] operators;
        private Function[] functions;
        private Function[] staticFunctions;
        private Indexer[] indexer;
        private ComponentWiseStaticFunction[] componentWiseStaticFunctions;
        private ComponentWiseOperator[] componentWiseOp;
        private Member[] glmMembers;
        private Function[] extensionFunctions;

        /// <summary>
        /// Generate all members
        /// </summary>
        public abstract IEnumerable<Member> GenerateMembers();

        /// <summary>
        /// Generates type members and sorts them
        /// </summary>
        public void Generate()
        {
            members = GenerateMembers().ToArray();

            //if (members.Any(m => string.IsNullOrEmpty(m.Comment)))
            //    throw new InvalidOperationException("Missing comment");

            foreach (var member in members)
                member.OriginalType = this;

            fields = members.OfType<Field>().ToArray();
            constructors = members.OfType<Constructor>().ToArray();
            properties = members.Where(m => !m.Static).OfType<Property>().ToArray();
            staticProperties = members.Where(m => m.Static).OfType<Property>().ToArray();
            implicitOperators = members.OfType<ImplicitOperator>().ToArray();
            explicitOperators = members.OfType<ExplicitOperator>().ToArray();
            operators = members.OfType<Operator>().ToArray();
            functions = members.Where(m => !m.Static && !m.Extension && m.GetType() == typeof(Function)).OfType<Function>().ToArray();
            staticFunctions = members.Where(m => m.Static && !m.Extension && m.GetType() == typeof(Function)).OfType<Function>().ToArray();
            indexer = members.OfType<Indexer>().ToArray();
            componentWiseStaticFunctions = members.OfType<ComponentWiseStaticFunction>().ToArray();
            componentWiseOp = members.OfType<ComponentWiseOperator>().ToArray();
            extensionFunctions = members.Where(m => m.Static && m.Extension && m.GetType() == typeof(Function)).OfType<Function>().ToArray();
            glmMembers = members.SelectMany(m => m.GlmMembers()).ToArray();
        }

        /// <summary>
        /// Constructs an object of a given type
        /// </summary>
        public string Construct(AbstractType type, IEnumerable<string> args) => $"new {type.NameThat}({args.CommaSeparated()})";
        /// <summary>
        /// Constructs an object of a given type
        /// </summary>
        public string Construct(AbstractType type, params string[] args) => $"new {type.NameThat}({args.CommaSeparated()})";

        /// <summary>
        /// Generate tests for this class
        /// </summary>
        public virtual IEnumerable<TestFunc> GenerateTests() { yield break; }

        public void ResetRandom(int x)
        {
            Random = new Random(x + TestClassName.GetHashCode());
        }

        public IEnumerable<string> TestFile
        {
            get
            {
                if (string.IsNullOrEmpty(Folder))
                    throw new NotSupportedException();

                yield return "using System;";
                yield return "using System.Collections;";
                yield return "using System.Collections.Generic;";
                yield return "using System.Globalization;";
                yield return "using System.Runtime.InteropServices;";
                yield return "using System.Runtime.Serialization;";
                yield return "using System.Numerics;";
                yield return "using System.Linq;";
                yield return "using NUnit.Framework;";
                yield return "using Newtonsoft.Json;";
                yield return "using GLSH;";
                yield return "";
                yield return "// ReSharper disable InconsistentNaming";
                yield return "";
                yield return "namespace GlmSharpTest.Generated." + Folder;
                yield return "{";
                yield return "    [TestFixture]";
                yield return "    public class " + TestClassName;
                yield return "    {";
                TestMode = true;
                ResetRandom(1234);
                foreach (var test in GenerateTests())
                {
                    yield return "";
                    yield return "[Test]".Indent(2);
                    yield return $"public void {test.Name}()".Indent(2);
                    yield return "{".Indent(2);
                    foreach (var line in test.Code)
                        yield return line.Indent(3);
                    yield return "}".Indent(2);
                }
                TestMode = false;
                yield return "";
                yield return "    }";
                yield return "}";
            }
        }

        public IEnumerable<string> GlmSharpFile
        {
            get
            {
                yield return "using System;";
                yield return "using System.Collections;";
                yield return "using System.Collections.Generic;";
                yield return "using System.Globalization;";
                yield return "using System.Runtime.InteropServices;";
                yield return "using System.Runtime.Serialization;";
                yield return "using System.Numerics;";
                yield return "using System.Linq;";
                yield return "";
                yield return "// ReSharper disable InconsistentNaming";
                yield return "";
                yield return "namespace " + Namespace;
                yield return "{";
                yield return "    /// <summary>";
                yield return "    /// Static class that contains static glm functions";
                yield return "    /// </summary>";
                yield return "    public static partial class glm";
                yield return "    {";
                foreach (var member in glmMembers)
                    foreach (var line in member.Lines)
                        yield return line.Indent(2);
                yield return "";
                yield return "    }";
                yield return "}";
            }
        }

        public IEnumerable<string> ExtCSharpFile
        {
            get
            {
                var baseclasses = BaseClasses.ToArray();
                yield return "using System;";
                yield return "using System.Collections;";
                yield return "using System.Collections.Generic;";
                yield return "using System.Globalization;";
                yield return "using System.Runtime.InteropServices;";
                yield return "using System.Runtime.Serialization;";
                yield return "using System.Numerics;";
                yield return "using System.Linq;";
                yield return "";
                yield return "// ReSharper disable InconsistentNaming";
                yield return "";
                yield return "namespace " + Namespace + ".Extensions";
                yield return "{";
                foreach (var line in TypeComment.AsComment()) yield return line.Indent();
                yield return "    public static class " + Name + "Extensions" + (baseclasses.Length == 0 ? "" : " : " + baseclasses.CommaSeparated());
                yield return "    {";


                if (extensionFunctions.Length > 0)
                {
                    yield return "";
                    yield return "        #region ExtensionFunctions";
                    foreach (var func in extensionFunctions)
                        foreach (var line in func.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                yield return "    }";
                yield return "}";
            }
        }

        public IEnumerable<string> CSharpFile
        {
            get
            {

                var baseclasses = BaseClasses.ToArray();
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
                yield return "namespace " + Namespace;
                yield return "{";
                foreach (var line in TypeComment.AsComment()) yield return line.Indent();
                foreach (var item in Attributes)
                    yield return $"[{item}]".Indent();
                yield return "    public struct " + Name + (baseclasses.Length == 0 ? "" : " : " + baseclasses.CommaSeparated());
                yield return "    {";

                if (fields.Length > 0)
                {
                    yield return "";
                    yield return "        #region Fields";
                    foreach (var field in fields)
                        foreach (var line in field.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (constructors.Length > 0)
                {
                    yield return "";
                    yield return "        #region Constructors";
                    foreach (var ctor in constructors)
                        foreach (var line in ctor.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (implicitOperators.Length > 0)
                {
                    yield return "";
                    yield return "        #region Implicit Operators";
                    foreach (var op in implicitOperators)
                        foreach (var line in op.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (explicitOperators.Length > 0)
                {
                    yield return "";
                    yield return "        #region Explicit Operators";
                    foreach (var op in explicitOperators)
                        foreach (var line in op.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (indexer.Length > 0)
                {
                    yield return "";
                    yield return "        #region Indexer";
                    foreach (var index in indexer)
                        foreach (var line in index.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (properties.Length > 0)
                {
                    yield return "";
                    yield return "        #region Properties";
                    foreach (var prop in properties)
                        foreach (var line in prop.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (staticProperties.Length > 0)
                {
                    yield return "";
                    yield return "        #region Static Properties";
                    foreach (var prop in staticProperties)
                        foreach (var line in prop.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (operators.Length > 0)
                {
                    yield return "";
                    yield return "        #region Operators";
                    foreach (var op in operators)
                        foreach (var line in op.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (functions.Length > 0)
                {
                    yield return "";
                    yield return "        #region Functions";
                    foreach (var func in functions)
                        foreach (var line in func.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (staticFunctions.Length > 0)
                {
                    yield return "";
                    yield return "        #region Static Functions";
                    foreach (var func in staticFunctions)
                        foreach (var line in func.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (componentWiseStaticFunctions.Length > 0)
                {
                    yield return "";
                    yield return "        #region Component-Wise Static Functions";
                    foreach (var func in componentWiseStaticFunctions)
                        foreach (var line in func.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                if (componentWiseOp.Length > 0)
                {
                    yield return "";
                    yield return "        #region Component-Wise Operator Overloads";
                    foreach (var op in componentWiseOp)
                        foreach (var line in op.Lines)
                            yield return line.Indent(2);
                    yield return "";
                    yield return "        #endregion";
                    yield return "";
                }

                foreach (var line in Body)
                    yield return line.Indent(2);
                yield return "    }";
                yield return "}";
            }
        }

        protected virtual IEnumerable<string> Body { get { yield break; } }

        public string Comparer(string val) => string.Format("{0}.Equals(rhs.{0})", val);

        public virtual string ZeroValue => BaseType.ZeroValue;
        public virtual string OneValue => BaseType.OneValue;

        public string HashCodeOf(string val) => $"{val}.GetHashCode()";


        public string SqrOf(string s) => s + "*" + s;

        public string SqrtOf(string s) => BaseType.Decimal ? "(" + s + ").Sqrt()" : $"Math.Sqrt({s})";
        public string SqrtOf(char s) => SqrOf(s.ToString());

        public string DotFormatString => "lhs.{0} * rhs.{0}";

        public string AbsString(string s) => BaseType.IsSigned ? (MathClass + $".Abs({s})") : s;
        public string AbsString(char s) => BaseType.IsSigned ? (MathClass + $".Abs({s})") : s.ToString();

        public string ConstantSuffixFor(string s)
        {
            var type = BaseType ?? this;

            if (type.Name == "float")
                return s + "f";

            if (type.Name == "bool")
                return s;

            if (type.Name == "Complex")
                return s;

            if (type.Name == "Half")
                return $"new Half({s})";

            if (type.Name == "double")
                return s + "d";

            if (type.Name == "decimal")
                return s + "m";

            if (type.Name == "int")
                return s + "";

            if (type.Name == "uint")
                return s + "u";

            if (type.Name == "long")
                return s + "L";

            throw new InvalidOperationException("unknown type " + this + ", " + type.Name);
        }

        public string ConstantStringFor(string s)
        {
            var type = BaseType ?? this;

            if (type.Name == "Half")
                return $"new Half({s})";

            return s;
        }

        public static void InitTypes()
        {
            Types.Clear();

            // vectors
            foreach (var type in BuiltinType.BaseTypes)
                for (var comp = 2; comp <= 4; ++comp)
                {
                    var vect = new VectorType(type, comp);
                    Types.Add(vect.Name, vect);
                }

            // matrices
            BuiltinType[] matrixTypes = [BuiltinType.TypeFloat, BuiltinType.TypeDouble];
            foreach (var type in matrixTypes)
                for (var rows = 2; rows <= 4; ++rows)
                    for (var cols = 2; cols <= 4; ++cols)
                    {
                        var matt = new MatrixType(type, cols, rows);
                        Types.Add(matt.Name, matt);
                    }

            // generate types
            foreach (var type in Types.Values)
                type.Generate();
        }

        private static string NestedSymmetricFunction(IReadOnlyList<string> fields, string funcFormat, int start, int end)
        {
            if (start == end)
                return fields[start];

            var mid = (start + end) / 2;
            return string.Format(funcFormat,
                NestedSymmetricFunction(fields, funcFormat, start, mid),
                NestedSymmetricFunction(fields, funcFormat, mid + 1, end));
        }
        public static string NestedSymmetricFunction(IEnumerable<string> ffs, string funcFormat)
        {
            var fs = ffs.ToArray();
            return NestedSymmetricFunction(fs, funcFormat, 0, fs.Length - 1);
        }
        public string TypeCast(BuiltinType otherType, string c)
        {
            if (otherType.HasArithmetics && BaseType.IsBool)
                return $"{c} ? {otherType.OneValue} : {otherType.ZeroValue}";

            if (otherType.IsBool && BaseType.HasArithmetics)
                return $"{c} != {BaseType.ZeroValue}";

            return $"({otherType.Name}){c}";
        }


        protected static string ToRgba(string xyzw)
        {
            var s = "";
            foreach (var c in xyzw)
            {
                switch (c)
                {
                    case 'x': s += 'r'; break;
                    case 'y': s += 'g'; break;
                    case 'z': s += 'b'; break;
                    case 'w': s += 'a'; break;
                }
            }
            return s;
        }
    }
}
