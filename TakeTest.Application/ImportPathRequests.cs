using System;
using System.IO;
using System.Collections.Generic;

namespace TakeTest.Application
{
    public static class ImportPathRequests
    {
        public static List<(string, string)> Import(string shipmentsFile)
        {
            List<(string, string)> shipments = new List<(string, string)>();

            foreach (string line in File.ReadAllLines(shipmentsFile))
            {
                string[] dataSplit = line.Split(' ');
                shipments.Add((dataSplit[0], dataSplit[1]));
            }

            return shipments;
        }
    }
}