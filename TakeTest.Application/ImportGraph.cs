using System;
using System.IO;
using TakeTest.Library;

namespace TakeTest.Application
{
    public static class ImportGraph
    {
        public static Graph Import(string pathsFile)
        {
            Graph graph = new Graph();
            foreach (string line in File.ReadAllLines(pathsFile))
            {
                string[] dataSplit = line.Split(' ');
                graph.AddEdge(dataSplit[0], dataSplit[1], Convert.ToInt32(dataSplit[2]));
            }

            return graph;
        }
    }
}