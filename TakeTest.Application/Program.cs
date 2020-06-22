using System;
using System.Collections.Generic;
using System.IO;
using TakeTest.Library;

namespace TakeTest.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("usage: program pathsFile shipmentsFile outputFile");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("usage: program pathsFile shipmentsFile outputFile");
                Console.WriteLine(" - error: pathsFile not found");
                return;
            }

            if (!File.Exists(args[1]))
            {
                Console.WriteLine("usage: program pathsFile shipmentsFile outputFile");
                Console.WriteLine(" - error: shipmentsFile not found");
                return;
            }
            
            ExportPaths.Export(
                ImportGraph.Import(args[0]), 
                ImportPathRequests.Import(args[1]),
                args[2]
            );
        }
    }
}
