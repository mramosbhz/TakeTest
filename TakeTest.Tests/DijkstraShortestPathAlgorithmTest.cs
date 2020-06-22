using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeTest.Library;

namespace TakeTest.Tests
{
    [TestClass]
    public class DijkstraShortestPathAlgorithmTest
    {
        private readonly PathBuilder builder;
        private readonly Graph graph;
        private readonly IShortestPathAlgorithm shortestPathFinder;

        public DijkstraShortestPathAlgorithmTest()
        {
            this.builder = new PathBuilder();
            this.graph = new Graph();
            graph.AddEdge("LS", "SF", 1);
            graph.AddEdge("SF", "LS", 2);
            graph.AddEdge("LS", "LV", 1);
            graph.AddEdge("LV", "LS", 1);
            graph.AddEdge("SF", "LV", 2);
            graph.AddEdge("LV", "SF", 2);
            graph.AddEdge("LS", "RC", 1);
            graph.AddEdge("RC", "LS", 2);
            graph.AddEdge("SF", "WS", 1);
            graph.AddEdge("WS", "SF", 2);
            graph.AddEdge("LV", "BC", 1);
            graph.AddEdge("BC", "LV", 1);

            this.shortestPathFinder = new DijkstraShortestPathAlgorithm(this.graph, this.builder);
        }

        [TestMethod]
        public void FindShortestPath_For_SFandWS_Returns_SF_WS_1()
        {
            var shipment = ("SF", "WS");
            Assert.AreEqual("SF WS 1", this.builder.ToString(this.shortestPathFinder.FindShortestPath(shipment.Item1, shipment.Item2)));
        }

        [TestMethod]
        public void FindShortestPath_For_LSandBC_Returns_LS_LV_BC_2()
        {
            var shipment = ("LS", "BC");
            Assert.AreEqual("LS LV BC 2", this.builder.ToString(this.shortestPathFinder.FindShortestPath(shipment.Item1, shipment.Item2)));
        }

        [TestMethod]
        public void FindShortestPath_For_WSandBC_Returns_WS_SF_LV_BC_5()
        {
            var shipment = ("WS", "BC");
            Assert.AreEqual("WS SF LV BC 5", this.builder.ToString(this.shortestPathFinder.FindShortestPath(shipment.Item1, shipment.Item2)));
        }
        
        [TestMethod]
        public void FindShortestPath_For_Unreachable_Vertex()
        {
            var shipment = ("AA", "BB");
            Graph localGraph = new Graph();
            localGraph.AddEdge(shipment.Item1, shipment.Item2, 1);

            IShortestPathAlgorithm localShortestPathFinder = new DijkstraShortestPathAlgorithm(localGraph, this.builder);
            Assert.AreEqual(Graph.UNREACHABLE.ToString(), this.builder.ToString(localShortestPathFinder.FindShortestPath(shipment.Item2, shipment.Item1)));
        }
        
        [TestMethod]
        public void FindShortestPath_FromInvalidSource_ThrowsArgumentOutOfRangeException()
        {
            var shipment = ("AA", "BC");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.shortestPathFinder.FindShortestPath(shipment.Item1, shipment.Item2));
        }
        
        [TestMethod]
        public void FindShortestPath_ToInvalidDestination_ThrowsArgumentOutOfRangeException()
        {
            var shipment = ("WS", "AA");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.shortestPathFinder.FindShortestPath(shipment.Item1, shipment.Item2));
        }
    }
}