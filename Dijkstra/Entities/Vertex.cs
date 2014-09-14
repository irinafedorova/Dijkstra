using System.Collections.Generic;

namespace Dijkstra.Entities
{
    public class Vertex
    {
        public List<Edge> Edges { get; private set; }

        public int Id { get; private set; }

        public Vertex(int id)
        {
            Id = id;
            Edges = new List<Edge>();
        }
    }
}
