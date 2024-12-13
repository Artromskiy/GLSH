using GLSH.Compiler.Internal;
using System;

namespace GLSH.Compiler.Glsl;

internal class DefaultWriter
{
    private readonly LanguageBackend _backend;
    public DefaultWriter(LanguageBackend backend)
    {
        _backend = backend;
    }

    public string WriteDefault(StructDeclarationData structDeclaration)
    {
        string type = structDeclaration.name;
        string declarationString = _backend.FormatDeclaration(type, type, "default", []);
        string thisToken = GLSHConstants.ThisToken;
        string returnString = $"return {thisToken};".Indent();
        string resultDecl = $"{_backend.CSharpToShaderType(type)} {thisToken};".Indent();
        return
        $$"""
        {{declarationString}}
        {
        {{resultDecl}}
        {{FieldsToString(structDeclaration.fields)}}
        {{returnString}}
        }

        """;
    }

    private string FieldsToString(StructField[] fields)
    {
        return string.Join(Environment.NewLine, Array.ConvertAll(fields, field =>
        {
            var invocation = _backend.FormatInvocation(field.typeName, "default", []);
            return $"{GLSHConstants.ThisToken}.{field.fieldName} = {invocation};".Indent();
        }));
    }
}
