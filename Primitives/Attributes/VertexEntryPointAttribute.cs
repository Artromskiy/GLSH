using System;

namespace GLSH.Primitives.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class VertexEntryPointAttribute : Attribute { }