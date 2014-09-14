using System.Collections.Generic;

using Dijkstra.Entities;

namespace Dijkstra.Interfaces
{
    public interface IGraphParser
    {
        List<Vertex> Parse(string input);
    }
}