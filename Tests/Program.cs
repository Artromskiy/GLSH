﻿using System;
using System.Collections.Generic;

internal class Program
{
    private static int Main(string[] args)
    {
        List<string> newArgs = new(args);
        newArgs.Insert(0, typeof(Program).Assembly.Location);
        int returnCode = Xunit.ConsoleClient.Program.Main([.. newArgs]);
        Console.WriteLine("Tests finished. Press any key to exit.");
        if (!Console.IsInputRedirected)
        {
            Console.ReadKey(true);
        }
        return returnCode;
    }
}
