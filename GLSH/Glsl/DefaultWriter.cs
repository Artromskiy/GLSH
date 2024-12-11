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
        string thisToken = _backend.GetThisToken();
        string returnString = $"return {thisToken};".Indent();
        string resultDecl = $"{_backend.CSharpToShaderType(type)} {thisToken};".Indent();
        return
        $$"""
        {{declarationString}}
        {
        {{resultDecl}}
        {{string.Join(Environment.NewLine, Array.ConvertAll(structDeclaration.fields, field => FieldToString(field, thisToken)))}}
        {{returnString}}
        }

        """;
    }

    private string FieldToString(StructField field, string thisToken)
    {
        var invocation = _backend.FormatInvocation(field.typeName, "default", []);
        return $"{thisToken}.{field.fieldName} = {invocation};".Indent();
    }
}
