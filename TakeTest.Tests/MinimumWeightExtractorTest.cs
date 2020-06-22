using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeTest.Library;

namespace TakeTest.Tests
{
    [TestClass]
    public class MinimumWeightExtractorTest
    {
        private readonly Dictionary<string, ShortDistanceStep> shortestDistances;

        public MinimumWeightExtractorTest()
        {
            this.shortestDistances = new Dictionary<string, ShortDistanceStep>();
            this.shortestDistances.Add("AA", new ShortDistanceStep(0, ""));
            this.shortestDistances.Add("BB", new ShortDistanceStep(Int32.MaxValue, ""));
        }

        [TestMethod]
        public void MinimumWeightExtractor_Extract_Minimum()
        {
            Assert.AreEqual("AA", MinimumWeightExtractor.Extract(this.shortestDistances, new List<string>()));
        }   
    }
}