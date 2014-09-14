using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Dijkstra.Entities;

namespace Dijkstra.Tests.UnitTests
{
    [TestClass]
    public class InputParserShould
    {
        private GraphParser graphParser;

        [TestInitialize]
        public void Initialize()
        {
            this.graphParser = new GraphParser();
        }

        [TestMethod]
        public void ParseTwoNodeInput()
        {
            var input = PrepareInput(@"1 2,5");

            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            vertex1.Edges.Add(new Edge { To = vertex2, Length = 5 });
            var expected = new List<Vertex> { vertex1, vertex2 };

            List<Vertex> actual = this.graphParser.Parse(input);

            AssertionHelper.AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseThreeNodeInput()
        {
            var input = PrepareInput(
@"1 2,5
2 3,6");

            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            var vertex3 = new Vertex(3);
            vertex1.Edges.Add(new Edge { To = vertex2, Length = 5 });
            vertex2.Edges.Add(new Edge { To = vertex3, Length = 6 });
            var expected = new List<Vertex> { vertex1, vertex2, vertex3 };

            List<Vertex> actual = this.graphParser.Parse(input);

            AssertionHelper.AssertAreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseFourNodeInput()
        {
            var input = PrepareInput(
@"1 2,5
2 3,6
4 3,4 2,7");

            var vertex1 = new Vertex(1);
            var vertex2 = new Vertex(2);
            var vertex3 = new Vertex(3);
            var vertex4 = new Vertex(4);
            vertex1.Edges.Add(new Edge { To = vertex2, Length = 5 });
            vertex2.Edges.Add(new Edge { To = vertex3, Length = 6 });
            vertex4.Edges.Add(new Edge { To = vertex3, Length = 4 });
            vertex4.Edges.Add(new Edge { To = vertex2, Length = 7 });
            var expected = new List<Vertex> { vertex1, vertex2, vertex3, vertex4 };

            List<Vertex> actual = this.graphParser.Parse(input);

            AssertionHelper.AssertAreEqual(expected, actual);
        }

        private string PrepareInput(string input)
        {
            return input.Replace(" ", "\t");
        }
    }
}
