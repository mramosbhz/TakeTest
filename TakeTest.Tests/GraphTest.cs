using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeTest.Library;

namespace TakeTest.Tests
{
    [TestClass]
    public class GraphTest
    {
        private readonly Graph graph;

        public GraphTest()
        {
            this.graph = new Graph();
            this.graph.AddEdge("LS", "SF", 1);
            this.graph.AddEdge("SF", "LV", 2);
            this.graph.AddEdge("SF", "LS", 3);
            this.graph.AddEdge("WS", "BC", 4);
        }

        [TestMethod]
        public void Weight_ForLSandSF_ReturnsOne()
        {
            Assert.AreEqual(1, this.graph.GetWeight("LS", "SF"));
        }

        [TestMethod]
        public void SFNeighbors_Count_ReturnsTwo()
        {
            Assert.AreEqual(2, this.graph.GetNeighbors("SF").Count);
        }

        [TestMethod]
        public void SFNeighbors_ReturnsLSanLV() 
        {
            Assert.IsTrue(this.graph.GetNeighbors("SF").IndexOf("LS") > -1 && this.graph.GetNeighbors("SF").IndexOf("LV") > -1);
        }

        [TestMethod]
        public void SF_DoesNot_ReachWS() 
        {
            Assert.AreEqual(Graph.UNREACHABLE, this.graph.GetWeight("SF", "WS"));
        }

        [TestMethod]
        public void GetWeight_FalseEdge_ThrowsArgumentOutOfRangeException() 
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.graph.GetWeight("AA", "ZZ"));
        } 

        [TestMethod]
        public void GetNeighbors_FalseVertex_ThrowsArgumentOutOfRangeException() 
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.graph.GetNeighbors("AA"));
        }
    }
}
