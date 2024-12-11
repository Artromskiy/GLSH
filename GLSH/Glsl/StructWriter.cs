using GLSH.Compiler.Internal;
using System;

namespace GLSH.Compiler.Glsl;

internal class StructWriter
{
    private readonly LanguageBackend _backend;
    public StructWriter(LanguageBackend backend)
    {
        _backend = backend;
    }

    public string WriteStructure(StructDeclarationData structDecl)
    {
        return
        $$"""
        struct {{_backend.CSharpToShaderType(structDecl.name)}}
        {
        {{string.Join(Environment.NewLine, Array.ConvertAll(structDecl.fields, WriteField))}}
        }
        """;
    }

    private string WriteField(StructField field)
    {
        var identifier = _backend.CorrectIdentifier(field.fieldName);
        return $"{_backend.CSharpToShaderType(field.typeName)} {identifier};".Indent();
    }
}
