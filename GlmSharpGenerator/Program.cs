﻿using GlmSharpGenerator.Types;
using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace GlmSharpGenerator
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            //var slnFolder = "C:\\Users\\FLOW\\Documents\\GitHub\\GLSH";
            var genFolder = "C:\\Users\\FLOW\\Documents\\GitHub\\GLSH\\Primitives\\Generated";
            var extGenFolder = "C:\\Users\\FLOW\\Documents\\GitHub\\GLSH\\GLSH.Extensions";
            var infoGenFolder = "C:\\Users\\FLOW\\Documents\\GitHub\\GLSH\\GLSH";
            args = [genFolder];

            Console.WriteLine("GlmSharp Generator");
            string path = genFolder;//  Path.Combine(basePath, "GlmSharp");
            string extPath = extGenFolder;
            string infoPath = infoGenFolder;
            //string testpath = Path.Combine(basePath, "GlmSharpTest");

            AbstractType.InitTypes();
            // see: https://www.opengl.org/sdk/docs/man4/html/ for functions
            foreach (var type in AbstractType.Types.Values)
            {
                // generate lib code
                {
                    var filename = type.PathOf(path);
                    new FileInfo(filename).Directory?.Create();
                    if (type.CSharpFile.WriteToFileIfChanged(filename))
                        Console.WriteLine("    CHANGED " + filename);
                }
                {
                    var filename = type.GlmPathOf(path);
                    new FileInfo(filename).Directory?.Create();
                    if (type.GlmSharpFile.WriteToFileIfChanged(filename))
                        Console.WriteLine("    CHANGED " + filename);
                }
                if (AbstractType.SeparateUnmanagedAsExtensions)
                {
                    var filename = type.ExtPathOf(extPath);
                    new FileInfo(filename).Directory?.Create();
                    if (type.ExtCSharpFile.WriteToFileIfChanged(filename))
                        Console.WriteLine("    CHANGED " + filename);
                }
            }

            var file = AbstractType.InfoPathOf(infoPath, "GLSHInfo");
            new FileInfo(file).Directory?.Create();
            if (InfoGenerator.InfoFile().WriteToFileIfChanged(file))
                Console.WriteLine("    CHANGED " + file);
        }
    }
}