using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dijkstra.ConsoleRunner.Helpers.Tests
{
    [TestClass]
    public class ArgumentsParserShould
    {
        [TestMethod]
        public void GetFileContent()
        {
            var expected = "file" + Environment.NewLine + "content";
            var path = @"..\..\input\test.txt";
            string actual = ArgumentsParser.GetFileContent(path);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailIfFileDoesNotExist()
        {
            var path = @"..\..\input\test1.txt";
            ArgumentsParser.GetFileContent(path);
        }

        [TestMethod]
        public void ParseSourceVertexId()
        {
            var expected = 1;
            var input = "1";
            int actual = ArgumentsParser.ParseSourceVertexId(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailIfSourceVertexIdIsInvalid()
        {
            var input = "a";
            ArgumentsParser.ParseSourceVertexId(input);
        }

        [TestMethod]
        public void ParseDestinationVerticesIds()
        {
            var expected = new List<int> { 1, 2, 3};
            var input = "1,2,3";
            List<int> actual = ArgumentsParser.ParseDestinationVerticesIds(input);
            Assert.AreEqual(expected.Count, actual.Count, "Count");
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i], "element " + i);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailIfDestinationVerticesIdsAreInvalid()
        {
            var input = "1,b,3";
            ArgumentsParser.ParseDestinationVerticesIds(input);
        }
    }
}
