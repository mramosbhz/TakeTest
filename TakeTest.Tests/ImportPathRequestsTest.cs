using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TakeTest.Application;

namespace TakeTest.Tests
{
    [TestClass]
    public class ImportPathRequestsTest
    {
        [TestMethod]
        public void ImportPathRequests_Import_Three_PathRequests()
        {
            Assert.AreEqual(3, ImportPathRequests.Import("../../../Resources/shipments.txt").Count);
        }
    }
}