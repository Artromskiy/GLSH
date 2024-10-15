using GLSH.Primitives;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace GLSH;

internal class ShaderSetDiscoverer : CSharpSyntaxWalker
{
    private readonly HashSet<string> _discoveredNames = [];
    private readonly List<ShaderSetInfo> _shaderSets = [];
    public Compilation? compilation;

    private const int AttributeLength = 9;
    private static readonly string ShaderSetName = nameof(ShaderSetAttribute)[..^AttributeLength];
    private static readonly string ComputeShaderSet = nameof(ComputeShaderSetAttribute)[..^AttributeLength];

    public override void VisitAttribute(AttributeSyntax node)
    {
        var nodeName = node.Name.ToFullString();
        // TODO: Only look at assembly-level attributes.
        if (nodeName == ComputeShaderSet)
        {
            var data = AttributeFactory.CreateFromNode<ComputeShaderSetAttribute>(node, compilation);
            string? name = data.setName;
            string? cs = data.entryPointName;
            if (!TypeAndMethodName.Get(cs, out TypeAndMethodName csName))
            {
                throw new ShaderGenerationException("ComputeShaderSetAttribute has an incomplete or invalid compute shader name.");
            }
            _shaderSets.Add(new ShaderSetInfo(name, csName));
        }
        else if (nodeName == ShaderSetName)
        {
            var data = AttributeFactory.CreateFromNode<ShaderSetAttribute>(node, compilation);
            string? name = data.Name;
            string? vs = data.VertexShader;
            TypeAndMethodName? vsName = null;

            if (vs != null && !TypeAndMethodName.Get(vs, out vsName))
            {
                throw new ShaderGenerationException("ShaderSetAttribute has an incomplete or invalid vertex shader name.");
            }

            TypeAndMethodName? fsName = null;
            string? fs = data.FragmentShader;
            if (fs != null && !TypeAndMethodName.Get(fs, out fsName))
            {
                throw new ShaderGenerationException("ShaderSetAttribute has an incomplete or invalid fragment shader name.");
            }

            if (vsName == null && fsName == null)
            {
                throw new ShaderGenerationException("ShaderSetAttribute must specify at least one shader name.");
            }

            if (!_discoveredNames.Add(name))
            {
                throw new ShaderGenerationException("Multiple shader sets with the same name were defined: " + name);
            }

            _shaderSets.Add(new ShaderSetInfo(
                name,
                vsName,
                fsName));
        }
    }

    private string? GetStringParam(AttributeSyntax node, int index)
    {
        var args = node.ArgumentList.Arguments[index];
        string text = args.ToFullString();
        if (text == "null")
        {
            return null;
        }
        else
        {
            return text.Trim().TrimStart('"').TrimEnd('"');
        }
    }

    public ShaderSetInfo[] GetShaderSets() => [.. _shaderSets];
}
