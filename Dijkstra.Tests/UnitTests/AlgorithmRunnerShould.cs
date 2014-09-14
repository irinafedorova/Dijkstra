using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

using Dijkstra.Entities;
using Dijkstra.Interfaces;

namespace Dijkstra.Tests.UnitTests
{
    [TestClass]
    public class AlgorithmRunnerShould
    {
        private AlgorithmRunner algorithmRunner;

        private IAlgorithm algorithm;

        private IGraphParser graphParser;

        [TestInitialize]
        public void Initialize()
        {
            this.graphParser = Substitute.For<IGraphParser>();
            this.algorithm = Substitute.For<IAlgorithm>();
            this.algorithmRunner = new AlgorithmRunner(this.graphParser, this.algorithm);
        }

        [TestMethod]
        public void DelegateToInputParserAndAlgorithm()
        {
            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            var vertex3 = new Vertex(3);
            var vertex4 = new Vertex(4);

            var expected = new List<ShortestPath> 
                    {
                        new ShortestPath { From = vertex1, To = vertex2, Length = 3 },
                        new ShortestPath { From = vertex1, To = vertex4, Length = 1 },
                    };

            var graph = new List<Vertex> 
                    {
                        new Vertex(1),
                    };

            this.graphParser
                .Parse(Arg.Any<string>())
                .Returns(graph);

            this.algorithm
                .FindShortestPaths(Arg.Any<List<Vertex>>(), Arg.Any<int>())
                .Returns(new List<ShortestPath>());

            var inputGraph = "some input graph";
            var sourceVertexId = 1;
            List<ShortestPath> actual = this.algorithmRunner.FindShortestPaths(
                inputGraph,
                sourceVertexId);

            this.graphParser.Received(1).Parse(inputGraph);
            this.algorithm.Received(1).FindShortestPaths(graph, sourceVertexId);
        }
    }
}