using System;

namespace GLSH.Primitives.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class VertexSemanticAttribute(SemanticType type) : Attribute
{
    public readonly SemanticType type = type;
}