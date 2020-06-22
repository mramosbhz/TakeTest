using System;
using System.Collections.Generic;

namespace TakeTest.Library
{
    public class PathBuilder
    {
        public Path Build(Dictionary<string, ShortDistanceStep> shortestDistances, string source, string destination)
        {
            Path path = new Path();
            path.TotalDistance = shortestDistances[destination].Distance;

            string currentVertex = destination;

            if (!String.IsNullOrEmpty(shortestDistances[currentVertex].Previous) || source == destination)
            {
                while (!String.IsNullOrEmpty(currentVertex))
                {
                    path.Vertices.Insert(0, currentVertex);
                    currentVertex = shortestDistances[currentVertex].Previous;
                }
            }

            return path;
        }

        public string ToString(Path path)
        {
            if (path.Vertices.Count == 0)
                return Graph.UNREACHABLE.ToString();

            return String.Format(
                "{0} {1}", 
                String.Join(" ", path.Vertices.ToArray()), 
                path.TotalDistance
            );
        }
    }
}