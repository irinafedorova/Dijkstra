using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Dijkstra.Entities;

namespace Dijkstra.Tests.IntegrationTests
{
    [TestClass]
    public class AlgorithmRunnerShould
    {
        [TestMethod]
        public void FindShortestPaths()
        {
            var inputGraph = @"1 2,10 3,20".Replace(" ", "\t");
            var sourceVertexId = 1;
            var destinationVerticesIds = new List<int> { 2, 4 };

            var algorithmRunner = new AlgorithmRunner();

            List<ShortestPath> actual = algorithmRunner.FindShortestPaths(
                                            inputGraph, sourceVertexId);

            var expected = new List<ShortestPath> { 
                new ShortestPath{ From = new Vertex(1), To = new Vertex(1), Length = 0},
                new ShortestPath{ From = new Vertex(1), To = new Vertex(2), Length = 10},
                new ShortestPath{ From = new Vertex(1), To = new Vertex(3), Length = 20},
            };

            AssertionHelper.AssertAreEqual(expected, actual);
        }
    }
}