using System;

namespace GLSH.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class VertexEntryPointAttribute : Attribute { }