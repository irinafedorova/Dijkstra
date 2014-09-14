using System.Collections.Generic;

using Dijkstra.Entities;

namespace Dijkstra.Interfaces
{
    public interface IAlgorithm
    {
        List<ShortestPath> FindShortestPaths(List<Vertex> graph, int sourceVertexId);
    }
}
