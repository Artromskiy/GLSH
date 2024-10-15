using GLSH;
using GLSH.Glsl;
using GLSH.Primitives;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Runner;

internal static class Program
{
    private const string CsSearch = "*.cs";
    private const string Scripts = "Scripts";


    private static readonly CSharpParseOptions _parseOptions = new(LanguageVersion.CSharp12);
    private static readonly CSharpCompilationOptions _compilationOptions = new
    (
        OutputKind.DynamicallyLinkedLibrary,
        optimizationLevel: OptimizationLevel.Release,
        allowUnsafe: true
    );




    public static int Main(string[] args)
    
    {
        Compilation compilation = CompileScripts();
        Glsl450Backend glsl450 = new(compilation);
        
        ShaderGenerator sg = new(compilation, [glsl450]);
        ShaderGenerationResult shaderGenResult;
        try
        {
            shaderGenResult = sg.GenerateShaders();
        }
        catch (Exception e) when (!Debugger.IsAttached)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("An error was encountered while generating shader code:");
            sb.AppendLine(e.ToString());
            Console.Error.WriteLine(sb.ToString());
            return -1;
        }
        Console.WriteLine("Compiled");
        Console.ReadKey();

        return 0;
    }

    public static Compilation CompileScripts()
    {
        string shaderCode = "C:\\Users\\FLOW\\Documents\\GitHub\\GLSH\\Runner";
        string libCode = "C:\\Users\\FLOW\\Documents\\GitHub\\GLSH\\Primitives";
        var sourceFiles = Directory.EnumerateFiles(shaderCode, CsSearch, SearchOption.AllDirectories);
        //sourceFiles = sourceFiles.Concat(Directory.EnumerateFiles(libCode, CsSearch, SearchOption.AllDirectories).Where(f=> !f.Contains(nameof(ShaderBuiltinException))));
        var trees = sourceFiles.Select(x =>
        {
            using var stream = File.OpenRead(x);
            var tree = CSharpSyntaxTree.ParseText(SourceText.From(stream), _parseOptions);
            var debug = tree.ToString();
            return tree;
        });

        var references = GetReferences(trees);

        return CSharpCompilation.Create(Scripts, trees, references, _compilationOptions);
    }

    private static void LogCompilation(EmitResult result)
    {
        foreach (var item in result.Diagnostics)
            Debug.Assert(false, item.GetMessage());
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
}
