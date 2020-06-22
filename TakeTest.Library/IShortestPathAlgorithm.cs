using System;
using System.Collections.Generic;

namespace TakeTest.Library
{
    public interface IShortestPathAlgorithm
    {
        Path FindShortestPath(string source, string destination);
    }
}