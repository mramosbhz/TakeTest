using System;
using System.Collections.Generic;
using System.Linq;

namespace TakeTest.Library
{
    public class Graph
    {
        public static int UNREACHABLE = -1;

        private Dictionary<string, Dictionary<string, int>> vertices;

        public Dictionary<string, Dictionary<string, int>> Vertices 
        {
            get { return this.vertices; }
        }

        public Graph()
        {
            this.vertices = new Dictionary<string, Dictionary<string, int>>();
        }

        public void AddEdge(string source, string destination, int weight)
        {
            if (!this.vertices.ContainsKey(source))
                this.vertices.Add(source, new Dictionary<string, int>());
            
            if (!this.vertices.ContainsKey(destination))
                this.vertices.Add(destination, new Dictionary<string, int>());

            this.vertices[source].Add(destination, weight);
        }

        public int GetWeight(string source, string destination)
        {
            if (!this.vertices.ContainsKey(source))
                throw new ArgumentOutOfRangeException("source", source, "This argument does not exists in vertices list.");
            
            if (!this.vertices[source].ContainsKey(destination))
                return UNREACHABLE;

            return this.vertices[source][destination];
        }

        public List<string> GetNeighbors(string source)
        {
            if (!this.vertices.ContainsKey(source))
                throw new ArgumentOutOfRangeException("source", source, "This argument does not exists in vertices list.");
                
            return this.vertices[source].Select(x => x.Key).ToList<string>();
        }
    }
}
