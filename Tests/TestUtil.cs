using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tests
{
    internal static class TestUtil
    {
        /// <summary>
        /// A string of '═' symbols
        /// </summary>
        public static readonly string Spacer1 = new('═', 80);

        /// <summary>
        /// A string of '━' symbols
        /// </summary>
        public static readonly string Spacer2 = new('━', 80);

        private static readonly string ProjectBasePath = Path.Combine(AppContext.BaseDirectory, "TestAssets");

        private static IReadOnlyList<MetadataReference>? _projectReferences;
        public static IReadOnlyList<MetadataReference> ProjectReferences => _projectReferences ??= GetReferences(GetSyntaxTrees());

        public static Compilation GetCompilation()
            => GetCompilation(GetSyntaxTrees());
        public static Compilation GetCompilation(string code)
            => GetCompilation(CSharpSyntaxTree.ParseText(code));

        public static Compilation GetCompilation(params SyntaxTree[] syntaxTrees)
            => GetCompilation((IEnumerable<SyntaxTree>)syntaxTrees);

        public static Compilation GetCompilation(IEnumerable<SyntaxTree> syntaxTrees)
        {
            CSharpCompilation compilation = CSharpCompilation.Create(
                "TestAssembly", syntaxTrees, ProjectReferences,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            return compilation;
        }


        public static SyntaxTree GetSyntaxTree(Compilation compilation, string name)
        {
            foreach (SyntaxTree tree in compilation.SyntaxTrees)
            {
                if (Path.GetFileName(tree.FilePath) == name)
                {
                    return tree;
                }
            }

            throw new InvalidOperationException("Couldn't find a syntax tree with name " + name);
        }

        private static IEnumerable<SyntaxTree> GetSyntaxTrees()
        {
            foreach (string sourceItem in Directory.EnumerateFiles(ProjectBasePath, "*.cs", SearchOption.AllDirectories).ToArray())
            {
                using FileStream fs = File.OpenRead(sourceItem);
                SourceText st = SourceText.From(fs);
                yield return CSharpSyntaxTree.ParseText(st, path: sourceItem);
            }
        }


        private static List<MetadataReference> GetReferences(IEnumerable<SyntaxTree> trees)
        {
            MetadataReference mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
            List<MetadataReference> references = [mscorlib];

            string assemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location)!;
            references.AddRange(Assembly.
                GetEntryAssembly()!.
                GetReferencedAssemblies().
                Select(a => MetadataReference.CreateFromFile(Assembly.Load(a).Location)));

            references.AddRange(trees.
                Select(tree => tree.GetRoot().ChildNodes().
                OfType<UsingDirectiveSyntax>().
                Where(x => x.Name != null).
                Select(x => x.Name)).
            SelectMany(s => s).
            Select(u => Path.Combine(assemblyPath, u!.ToString() + ".dll")).
            Where(File.Exists).
            Select(p => MetadataReference.CreateFromFile(p)));
            return references;
        }




        public static IReadOnlyList<(string fieldName, object aValue, object bValue)> DeepCompareObjectFields(object a, object b)
        {
            // Creat failures list
            List<(string fieldName, object aValue, object bValue)> failures = [];

            if (a == b)
            {
                return failures;
            }

            // Get dictionary of fields by field name and type
            Dictionary<Type, IReadOnlyCollection<FieldInfo>> childFieldInfos = [];

            Type currentType = a?.GetType() ?? b.GetType();
            object aValue = a;
            object bValue = b;
            Stack<(string fieldName, Type fieldType, object aValue, object bValue)> stack = [];
            stack.Push((string.Empty, currentType, aValue, bValue));

            while (stack.Count > 0)
            {
                // Pop top of stack.
                var frame = stack.Pop();
                currentType = frame.fieldType;
                aValue = frame.aValue;
                bValue = frame.bValue;

                if (Equals(aValue, bValue))
                {
                    continue;
                }

                // Get fields (cached)
                if (!childFieldInfos.TryGetValue(currentType, out IReadOnlyCollection<FieldInfo> childFields))
                {
                    childFieldInfos.Add(currentType, childFields = currentType.GetFields().Where(f => !f.IsStatic).ToArray());
                }

                if (childFields.Count < 1)
                {
                    // No child fields, we have an inequality
                    string fullName = frame.fieldName;
                    failures.Add((fullName, aValue, bValue));
                    continue;
                }

                foreach (FieldInfo childField in childFields)
                {
                    object aMemberValue = childField.GetValue(aValue);
                    object bMemberValue = childField.GetValue(bValue);

                    // Short cut equality
                    if (Equals(aMemberValue, bMemberValue))
                    {
                        continue;
                    }

                    string fullName = string.IsNullOrWhiteSpace(frame.fieldName)
                        ? childField.Name
                        : $"{frame.fieldName}.{childField.Name}";
                    stack.Push((fullName, childField.FieldType, aMemberValue, bMemberValue));
                }
            }

            return failures.AsReadOnly();
        }

        /// <summary>
        /// The random number generators for each thread.
        /// </summary>
        private static readonly ThreadLocal<Random> _randomGenerators = new(() => new Random());

        /// <summary>
        /// Fills a struct with Random floats.
        /// </summary>
        /// <typeparam name="T">The random type</typeparam>
        /// <param name="minMantissa">The minimum mantissa.</param>
        /// <param name="maxMantissa">The maximum mantissa.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// minMantissa
        /// or
        /// maxMantissa
        /// </exception>
        public static unsafe T FillRandomFloats<T>(int minMantissa = -126, int maxMantissa = 128) where T : struct
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(minMantissa, -126);
            ArgumentOutOfRangeException.ThrowIfLessThan(maxMantissa, minMantissa);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(maxMantissa, 128);

            Random random = _randomGenerators.Value;
            int floatCount = Unsafe.SizeOf<T>() / sizeof(float);
            float* floats = stackalloc float[floatCount];
            for (int i = 0; i < floatCount; i++)
            {
                floats[i] = (float)((random.NextDouble() * 2.0 - 1.0) * Math.Pow(2.0, random.Next(minMantissa, maxMantissa)));
                //floats[i] = (float)(random.NextDouble() * floatRange * 2f) - floatRange;
            }

            return Unsafe.Read<T>(floats);
        }

        /// <summary>
        /// Gets a set of random floats.
        /// </summary>
        /// <param name="floatCount">The number of floats.</param>
        /// <param name="minMantissa">The minimum mantissa.</param>
        /// <param name="maxMantissa">The maximum mantissa.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">minMantissa
        /// or
        /// maxMantissa</exception>
        public static float[] GetRandomFloats(int floatCount, int minMantissa = -126, int maxMantissa = 128)
        {
            Random random = _randomGenerators.Value;
            float[] floats = new float[floatCount];
            for (int i = 0; i < floatCount; i++)
            {
                floats[i] = (float)((random.NextDouble() * 2.0 - 1.0) * Math.Pow(2.0, random.Next(minMantissa, maxMantissa)));
            }

            return floats;
        }

        #region ToMemorySize from https://github.com/webappsuk/CoreLibraries/blob/fbbebc99bc5c1f2e8b140c6c387e3ede4f89b40c/Utilities/UtilityExtensions.cs#L2951-L3116
        private static readonly string[] _memoryUnitsLong =
        {
            " byte",
            " kilobyte",
            " megabyte",
            " gigabyte",
            " terabyte",
            " petabyte",
            " exabyte"
        };

        private static readonly string[] _memoryUnitsShort = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

        /// <summary>
        /// Converts a number of bytes to a friendly memory size.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="longUnits">if set to <see langword="true" /> use long form unit names instead of symbols.</param>
        /// <param name="decimalPlaces">The number of decimal places between 0 and 16 (ignored for bytes).</param>
        /// <param name="breakPoint">The break point between 0 and 1024 (or 0D to base on decimal points).</param>
        /// <returns>System.String.</returns>
        public static string ToMemorySize(
            this int bytes,
            bool longUnits = false,
            uint decimalPlaces = 1,
            double breakPoint = 512D) => ((double)bytes).ToMemorySize(longUnits, decimalPlaces, breakPoint);

        /// <summary>
        /// Converts a number of bytes to a friendly memory size.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="longUnits">if set to <see langword="true" /> use long form unit names instead of symbols.</param>
        /// <param name="decimalPlaces">The number of decimal places between 0 and 16 (ignored for bytes).</param>
        /// <param name="breakPoint">The break point between 0 and 1024 (or 0D to base on decimal points).</param>
        /// <returns>System.String.</returns>
        public static string ToMemorySize(
            this long bytes,
            bool longUnits = false,
            uint decimalPlaces = 1,
            double breakPoint = 512D) => ((double)bytes).ToMemorySize(longUnits, decimalPlaces, breakPoint);

        /// <summary>
        /// Converts a number of bytes to a friendly memory size.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="longUnits">if set to <see langword="true" /> use long form unit names instead of symbols.</param>
        /// <param name="decimalPlaces">The number of decimal places between 0 and 16 (ignored for bytes).</param>
        /// <param name="breakPoint">The break point between 0 and 1024 (or 0D to base on decimal points).</param>
        /// <returns>System.String.</returns>
        public static string ToMemorySize(
            this double bytes,
            bool longUnits = false,
            uint decimalPlaces = 1,
            double breakPoint = 512D)
        {
            if (decimalPlaces < 1)
            {
                decimalPlaces = 0;
            }
            else if (decimalPlaces > 16)
            {
                decimalPlaces = 16;
            }

            // 921.6 is 0.9*1024, this means that be default the breakpoint will round up the last decimal place.
            if (breakPoint < 1)
            {
                breakPoint = 921.6D * Math.Pow(10, -decimalPlaces);
            }
            else if (breakPoint > 1023)
            {
                breakPoint = 1023;
            }

            uint maxDecimalPlaces = 0;
            uint unit = 0;
            double amount = bytes;
            while (Math.Abs(amount) >= breakPoint &&
                   unit < 6)
            {
                amount /= 1024;
                unit++;
                maxDecimalPlaces = Math.Min(decimalPlaces, maxDecimalPlaces + 3);
            }

            string format = "{0:N" + maxDecimalPlaces + "}{1}";
            return string.Format(
                format,
                amount,
                longUnits
                    ? _memoryUnitsLong[unit]
                    : _memoryUnitsShort[unit]);
        }
        #endregion

        public static bool ApproximatelyEqual(this float a, float b, float epsilon = float.Epsilon)
        {
            const float floatNormal = (1 << 23) * float.Epsilon;

            if (a == b)
            {
                // Shortcut, handles infinities
                return true;
            }

            float diff = Math.Abs(a - b);
            if (a == 0.0f || b == 0.0f || diff < floatNormal)
            {
                // a or b is zero, or both are extremely close to it.
                // relative error is less meaningful here
                return diff < epsilon * floatNormal;
            }

            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            // use relative error
            return diff / Math.Min(absA + absB, float.MaxValue) < epsilon;
        }

        /// <summary>
        /// The unicode characters to represent a pie chart.
        /// </summary>
        private static readonly char[] UnicodePieChars = { '○', '◔', '◑', '◕', '●' };

        /// <summary>
        /// Gets the unicode symbol to represent the <paramref name="ratio"/> as a pie chart.
        /// </summary>
        /// <param name="ratio">The ratio.</param>
        /// <returns></returns>
        public static char GetUnicodePieChart(double ratio) =>
            UnicodePieChars[(int)Math.Round(Math.Max(Math.Min(ratio, 1.0), 0.0) * (UnicodePieChars.Length - 1))];
    }
}