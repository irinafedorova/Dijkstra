using System.Collections.Generic;
using System.Text;

using Dijkstra.Entities;

namespace Dijkstra.ConsoleRunner.Helpers
{
    public static class OutputFormatter
    {
        public static string Format(
            List<ShortestPath> shortestPaths, List<int> destinationVerticesIds)
        {
            var result = new StringBuilder();

            foreach (var destinationVertexId in destinationVerticesIds)
            {
                var distance = shortestPaths.Find(x => x.To.Id == destinationVertexId)
                                            .Length.ToString();
                result.Append(distance);
                result.Append(',');
            }

            return result.ToString().TrimEnd(',');
        }
    }
}
