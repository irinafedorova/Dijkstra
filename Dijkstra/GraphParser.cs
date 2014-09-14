using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Dijkstra.Entities;
using Dijkstra.Interfaces;

namespace Dijkstra
{
    public class GraphParser : IGraphParser
    {
        public List<Vertex> Parse(string input)
        {
            var result = new List<Vertex>();

            string[] lines = Regex.Split(input, Environment.NewLine);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var parts = Regex.Split(line, "\t");
                var vertexId = int.Parse(parts[0]);

                Vertex vertex;

                vertex = this.GetVertex(result, vertexId);

                for (int i = 1; i < parts.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(parts[i]))
                    {
                        var edgeStringRepresenatation = parts[i].Split(',');
                        var headVertexId = int.Parse(edgeStringRepresenatation[0]);
                        var distance = int.Parse(edgeStringRepresenatation[1]);

                        var head = this.GetVertex(result, headVertexId);

                        var edge = new Edge { To = head, Length = distance };

                        vertex.Edges.Add(edge);
                    }
                }
            }

            return result;
        }

        private Vertex GetVertex(List<Vertex> result, int vertexId)
        {
            Vertex vertex;
            if (!result.Exists(x => x.Id == vertexId))
            {
                vertex = new Vertex(vertexId);
                result.Add(vertex);
            }
            else
            {
                vertex = result.Find(x => x.Id == vertexId);
            }
            return vertex;
        }
    }
}
