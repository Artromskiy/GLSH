using System.Collections.Generic;

namespace GLSH.Compiler;

public class BuiltinTypes
{
    public static readonly HashSet<string> knownTypes = new HashSet<string>()
    {
        typeof(void).FullName!,
        typeof(int).FullName!,
        typeof(uint).FullName!,
        typeof(float).FullName!,
        typeof(double).FullName!,
        typeof(bool).FullName!,
    };

    public static readonly Dictionary<string, string> knownTypesToGlslTypes = new Dictionary<string, string>()
    {
        {typeof(void).FullName!, "void"},
        {typeof(int).FullName!, "int"},
        {typeof(uint).FullName!, "uint"},
        {typeof(float).FullName!, "float"},
        {typeof(double).FullName!, "double"},
        {typeof(bool).FullName!, "bool"},
    };

    public static readonly Dictionary<string, string> knownTypesToDefault = new Dictionary<string, string>()
    {
        {typeof(int).FullName!, "0"},
        {typeof(uint).FullName!, "0"},
        {typeof(float).FullName!, "0f"},
        {typeof(double).FullName!, "0.0"},
        {typeof(bool).FullName!, "false"},
    };
}