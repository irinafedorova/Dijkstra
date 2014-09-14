using System;
using System.Collections.Generic;
using System.Linq;

using Dijkstra.Entities;
using Dijkstra.Interfaces;

namespace Dijkstra
{
    public class Algorithm : IAlgorithm
    {
        public const int Infinity = int.MaxValue;

        public List<ShortestPath> FindShortestPaths(List<Vertex> graph, int sourceVertexId)
        {
            var result = new List<ShortestPath>();
            var unprocessedVerticies = new List<Vertex>();

            var sourceVertex = graph.Find(x => x.Id == sourceVertexId);
            if (sourceVertex == null)
            {
                throw new ArgumentException(
                    string.Format(
                        "Source vertex with id {0} is not in the graph.",
                        sourceVertexId));
            }

            result.Add(new ShortestPath
                            {
                                From = sourceVertex,
                                To = sourceVertex,
                                Length = 0
                            });
            unprocessedVerticies.AddRange(graph);
            unprocessedVerticies.Remove(sourceVertex);

            var processedAllReachableVetecies = false;

            while (!processedAllReachableVetecies)
            {
                var shortestPath = this.FindClosestHead(
                                            sourceVertex,
                                            result,
                                            unprocessedVerticies);

                if (shortestPath == null)
                {
                    processedAllReachableVetecies = true;
                }
                else
                {
                    result.Add(shortestPath);
                    unprocessedVerticies.Remove(shortestPath.To);
                }
            }

            foreach (var unprocessedVertex in unprocessedVerticies)
            {
                result.Add(new ShortestPath
                                {
                                    From = sourceVertex,
                                    To = unprocessedVertex,
                                    Length = Infinity
                                });
            }

            return result.OrderBy(x => x.To.Id).ToList();
        }

        private ShortestPath FindClosestHead(
            Vertex sourceVertex,
            List<ShortestPath> processedPaths,
            List<Vertex> unprocessedVerticies)
        {
            if (unprocessedVerticies.Count == 0)
            {
                return null;
            }

            Vertex closestHead = null;
            int shortestDistance = Infinity;

            foreach (var processedPath in processedPaths)
            {
                foreach (var edge in processedPath.To.Edges)
                {
                    if (unprocessedVerticies.Contains(edge.To))
                    {
                        var greadyCriterian = processedPath.Length + edge.Length;
                        if (greadyCriterian < shortestDistance)
                        {
                            shortestDistance = greadyCriterian;
                            closestHead = edge.To;
                        }
                    }
                }
            }

            if (closestHead == null)
            {
                return null;
            }

            return new ShortestPath { From = sourceVertex, To = closestHead, Length = shortestDistance };
        }
    }
}