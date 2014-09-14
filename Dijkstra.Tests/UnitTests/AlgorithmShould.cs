using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Dijkstra.Entities;

namespace Dijkstra.Tests.UnitTests
{
    [TestClass]
    public class AlgorithmShould
    {
        private Algorithm algorithm;

        [TestInitialize]
        public void Initialize()
        {
            this.algorithm = new Algorithm();
        }

        [TestMethod]
        public void CalculateRightDistanceForTwoNodes()
        {
            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            vertex1.Edges.Add(new Edge { To = vertex2, Length = 5 });
            var graph = new List<Vertex> { vertex1, vertex2 };

            var expected = new List<ShortestPath>
            { 
                new ShortestPath { From = vertex1, To = vertex1, Length = 0 },
                new ShortestPath { From = vertex1, To = vertex2, Length = 5 },
            };

            List<ShortestPath> actual = this.algorithm.FindShortestPaths(graph, sourceVertexId: 1);

            AssertionHelper.AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateRightDistanceForThreeNodes()
        {
            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            var vertex3 = new Vertex(3);
            vertex1.Edges.Add(new Edge { To = vertex2, Length = 5 });
            vertex1.Edges.Add(new Edge { To = vertex3, Length = 6 });
            var graph = new List<Vertex> { vertex1, vertex2, vertex3 };

            var expected = new List<ShortestPath>
            { 
                new ShortestPath { From = vertex1, To = vertex1, Length = 0 },
                new ShortestPath { From = vertex1, To = vertex2, Length = 5 },
                new ShortestPath { From = vertex1, To = vertex3, Length = 6 },
            };

            List<ShortestPath> actual = this.algorithm.FindShortestPaths(graph, sourceVertexId: 1);

            AssertionHelper.AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateRightDistanceForThreeNodesOneNodeUnreacheble()
        {
            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            var vertex3 = new Vertex(3);
            vertex1.Edges.Add(new Edge { To = vertex2, Length = 5 });
            var graph = new List<Vertex> { vertex1, vertex2, vertex3 };

            var expected = new List<ShortestPath>
            { 
                new ShortestPath { From = vertex1, To = vertex1, Length = 0 },
                new ShortestPath { From = vertex1, To = vertex2, Length = 5 },
                new ShortestPath { From = vertex1, To = vertex3, Length = Algorithm.Infinity },
            };

            List<ShortestPath> actual = this.algorithm.FindShortestPaths(graph, sourceVertexId: 1);

            AssertionHelper.AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateRightDistanceForFourNodes()
        {
            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            var vertex3 = new Vertex(3);
            var vertex4 = new Vertex(4);
            vertex1.Edges.Add(new Edge { To = vertex2, Length = 3 });
            vertex1.Edges.Add(new Edge { To = vertex3, Length = 4 });
            vertex1.Edges.Add(new Edge { To = vertex4, Length = 1 });
            vertex2.Edges.Add(new Edge { To = vertex4, Length = 5 });
            vertex4.Edges.Add(new Edge { To = vertex3, Length = 2 });
            var graph = new List<Vertex> { vertex1, vertex2, vertex3, vertex4 };

            var expected = new List<ShortestPath>
            { 
                new ShortestPath { From = vertex1, To = vertex1, Length = 0 },
                new ShortestPath { From = vertex1, To = vertex2, Length = 3 },
                new ShortestPath { From = vertex1, To = vertex3, Length = 3 },
                new ShortestPath { From = vertex1, To = vertex4, Length = 1 },
            };

            List<ShortestPath> actual = this.algorithm.FindShortestPaths(graph, sourceVertexId: 1);

            AssertionHelper.AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateRightDistanceForThreeNodesFirstIsNotPointingToThird()
        {
            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            var vertex3 = new Vertex(3);
            vertex1.Edges.Add(new Edge { To = vertex2, Length = 5 });
            vertex2.Edges.Add(new Edge { To = vertex3, Length = 6 });
            var graph = new List<Vertex> { vertex1, vertex2, vertex3 };

            var expected = new List<ShortestPath>
            { 
                new ShortestPath { From = vertex1, To = vertex1, Length = 0 },
                new ShortestPath { From = vertex1, To = vertex2, Length = 5 },
                new ShortestPath { From = vertex1, To = vertex3, Length = 11 },
            };

            List<ShortestPath> actual = this.algorithm.FindShortestPaths(graph, sourceVertexId: 1);

            AssertionHelper.AssertAreEqual(expected, actual);
        }
    }
}
