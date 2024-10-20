namespace GLSH.Compiler;

public delegate string InvocationTranslator(string typeName, string methodName, InvocationParameterInfo[] parameters);
