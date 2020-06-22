using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeTest.Application;

namespace TakeTest.Tests
{
    [TestClass]
    public class ImportGraphTest
    {
        [TestMethod]
        public void ImportGraph_Import_Six_Vertices()
        {
            Assert.AreEqual(6, ImportGraph.Import("../../../Resources/paths.txt").Vertices.Count);
        }
    }
}