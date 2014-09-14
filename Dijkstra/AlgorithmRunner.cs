using System.Collections.Generic;

using Dijkstra.Entities;
using Dijkstra.Interfaces;

namespace Dijkstra
{
    public class AlgorithmRunner
    {
        private IAlgorithm algorithm;

        private IGraphParser graphParser;

        public AlgorithmRunner()
        {
            this.graphParser = new GraphParser();
            this.algorithm = new Algorithm();
        }

        public AlgorithmRunner(IGraphParser graphParser, IAlgorithm algorithm)
        {
            this.graphParser = graphParser;
            this.algorithm = algorithm;
        }

        public List<ShortestPath> FindShortestPaths(
            string inputGraph,
            int sourceVertexId)
        {
            var graph = this.graphParser.Parse(inputGraph);
            List<ShortestPath> shortestPaths = 
                this.algorithm.FindShortestPaths(graph, sourceVertexId);

            return shortestPaths;
        }
    }
}
