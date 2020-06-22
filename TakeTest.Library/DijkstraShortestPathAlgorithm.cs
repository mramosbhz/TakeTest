using System;
using System.Collections.Generic;
using System.Linq;

namespace TakeTest.Library
{
    public class DijkstraShortestPathAlgorithm : IShortestPathAlgorithm
    {
        private Graph graph;
        private PathBuilder builder;

        public DijkstraShortestPathAlgorithm(Graph graph, PathBuilder builder)
        {
            this.graph = graph;
            this.builder = builder;
        }

        public Path FindShortestPath(string source, string destination)
        {
            Dictionary<string, ShortDistanceStep> shortestDistances = new Dictionary<string, ShortDistanceStep>();
            List<string> unvisitedVertices = this.graph.Vertices.Select(element => element.Key).ToList();
            List<string> visitedVertices = new List<string>();

            if (unvisitedVertices.IndexOf(source) == -1)
                throw new ArgumentOutOfRangeException("source", source, "The argument does not exists in vertices list.");
                
            if (unvisitedVertices.IndexOf(destination) == -1)
                throw new ArgumentOutOfRangeException("destination", destination, "The argument does not exists in vertices list.");

            foreach (KeyValuePair<string, Dictionary<string, int>> kvp in this.graph.Vertices)
            {
                shortestDistances.Add(kvp.Key, new ShortDistanceStep(Int32.MaxValue, String.Empty));
            }

            shortestDistances[source].Distance = 0;

            while (unvisitedVertices.Count > 0)
            {
                string currentVertex = MinimumWeightExtractor.Extract(shortestDistances, visitedVertices);
                visitedVertices.Add(currentVertex);
                unvisitedVertices.Remove(currentVertex);

                if (currentVertex == destination)
                    break;

                foreach (KeyValuePair<string, int> kvp in this.graph.Vertices[currentVertex])
                {
                    int edgeDistance = shortestDistances[currentVertex].Distance + this.graph.GetWeight(currentVertex, kvp.Key);
                    if (edgeDistance != Graph.UNREACHABLE && edgeDistance < shortestDistances[kvp.Key].Distance)
                    {
                        shortestDistances[kvp.Key].Distance = edgeDistance;
                        shortestDistances[kvp.Key].Previous = currentVertex;
                    }
                }
            }

            return builder.Build(shortestDistances, source, destination);
        }
    }
}