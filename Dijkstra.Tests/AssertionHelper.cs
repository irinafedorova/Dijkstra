using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Dijkstra.Entities;

namespace Dijkstra.Tests
{
    public class AssertionHelper
    {
        public static void AssertAreEqual(List<Vertex> expected, List<Vertex> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count, "actual.Count");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(
                    expected[i].Id,
                    actual[i].Id,
                    string.Format("actual[{0}].Id", i));
                Assert.AreEqual(
                    expected[i].Edges.Count,
                    actual[i].Edges.Count,
                    string.Format("actual[{0}].Edges.Count", i));

                for (int j = 0; j < expected[i].Edges.Count; j++)
                {
                    Assert.AreEqual(
                        expected[i].Edges[j].To.Id,
                        actual[i].Edges[j].To.Id,
                        string.Format("actual[{0}].Edges[{1}].To.Id", i, j));
                    Assert.AreEqual(
                        expected[i].Edges[j].Length,
                        actual[i].Edges[j].Length,
                        string.Format("actual[{0}].Edges[{1}].Length", i, j));
                }
            }
        }

        public static void AssertAreEqual(List<ShortestPath> expected, List<ShortestPath> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count, "actual.Count");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(
                    expected[i].From.Id,
                    actual[i].From.Id,
                    string.Format("actual[{0}].From.Id", i));
                Assert.AreEqual(
                    expected[i].To.Id,
                    actual[i].To.Id,
                    string.Format("actual[{0}].To.Id", i));
                Assert.AreEqual(
                    expected[i].Length,
                    actual[i].Length,
                    string.Format("actual[{0}].Length", i));
            }
        }
    }
}
