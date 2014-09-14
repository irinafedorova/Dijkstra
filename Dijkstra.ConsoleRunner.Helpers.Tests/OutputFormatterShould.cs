using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Dijkstra.Entities;

namespace Dijkstra.ConsoleRunner.Helpers.Tests
{
    [TestClass]
    public class OutputFormatterShould
    {
        [TestMethod]
        public void FilterDestinationVertices()
        {
            var expected = "3,1";

            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            var vertex3 = new Vertex(3);
            var vertex4 = new Vertex(4);
            var shortestPaths =
                    new List<ShortestPath> 
                        {
                            new ShortestPath { From = vertex1, To = vertex1, Length = 0 },
                            new ShortestPath { From = vertex1, To = vertex2, Length = 3 },
                            new ShortestPath { From = vertex1, To = vertex3, Length = 3 },
                            new ShortestPath { From = vertex1, To = vertex4, Length = 1 },
                        };
            var destinationVerticesIds = new List<int> { 2, 4 };

            var actual = OutputFormatter.Format(shortestPaths, destinationVerticesIds);

            Assert.AreEqual(expected, actual);
        }
    }
}