using System;
using System.Collections.Generic;

namespace TakeTest.Library
{
    public static class MinimumWeightExtractor
    {
        public static string Extract(Dictionary<string, ShortDistanceStep> shortestDistances, List<string> visitedVertices)
        {
            int minimumDistance = Int32.MaxValue;
            string indexOfMinimumDistance = String.Empty;

            foreach (KeyValuePair<string, ShortDistanceStep> kvp in shortestDistances)
            {
                if (visitedVertices.IndexOf(kvp.Key) == -1 && kvp.Value.Distance <= minimumDistance)
                {
                    minimumDistance = kvp.Value.Distance;
                    indexOfMinimumDistance = kvp.Key;
                }
            }

            return indexOfMinimumDistance;
        }
    }
}