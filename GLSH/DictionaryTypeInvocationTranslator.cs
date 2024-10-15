using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GLSH;

internal class DictionaryTypeInvocationTranslator : TypeInvocationTranslator
{
    private readonly Dictionary<string, InvocationTranslator> _translators = [];

    public DictionaryTypeInvocationTranslator(Dictionary<string, InvocationTranslator> translators)
    {
        _translators = translators;
    }

    public override bool GetTranslator(
        string method,
        InvocationParameterInfo[] parameters,
        [NotNullWhen(true)] out InvocationTranslator? translator)
    {
        return _translators.TryGetValue(method, out translator);
    }
}
