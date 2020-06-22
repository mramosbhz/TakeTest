using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TakeTest.Library;

namespace TakeTest.Application
{
    public static class ExportPaths
    {
        public static void Export(Graph graph, List<(string, string)> shipments, string routesFile)
        {
            PathBuilder builder = new PathBuilder();
            IShortestPathAlgorithm shortestPathFinder = new DijkstraShortestPathAlgorithm(graph, builder);
            StringBuilder sb = new StringBuilder();

            foreach ((string, string) shipment in shipments)
            {
                try
                {
                    sb.AppendLine(builder.ToString(shortestPathFinder.FindShortestPath(shipment.Item1, shipment.Item2)));
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    sb.AppendLine(String.Format("ERROR: UNKNOWN '{0}'", ex.ActualValue));
                }
                catch (Exception)
                {
                    sb.AppendLine("ERROR: INVALID REQUEST");
                }
            }

            File.WriteAllText(routesFile, sb.ToString());
        }
    }
}