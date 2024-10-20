using System;

namespace GLSH.Compiler;

internal static class SpanExtensions
{
    public static T? Find<T>(this ReadOnlySpan<T> span, Predicate<T> match)
    {
        foreach (var item in span)
            if (match(item))
                return item;
        return default;
    }
    public static T? SingleOrDefault<T>(this ReadOnlySpan<T> span, Predicate<T> match)
    {
        bool found = false;
        T? returnValue = default;
        foreach (var item in span)
        {
            bool matches = match(item);
            if (matches && !found)
                returnValue = item;
            else if (matches && found)
                throw new Exception("More than one element matches predicate");
        }
        return returnValue;
    }
    public static bool Exists<T>(this ReadOnlySpan<T> span, Predicate<T> match)
    {
        foreach (var item in span)
            if (match(item))
                return true;
        return false;
    }
}