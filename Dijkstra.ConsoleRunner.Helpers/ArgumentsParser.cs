using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dijkstra.ConsoleRunner.Helpers
{
    public static class ArgumentsParser
    {
        public static string GetFileContent(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Graph input file path was not specified");
            }

            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Can't read graph file", ex);
            }
        }

        public static int ParseSourceVertexId(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Source vertex id was not specified");
            }

            int sourceVertexId;
            bool sourceVertexIdParsed = int.TryParse(input, out sourceVertexId);
            if (!sourceVertexIdParsed)
            {
                throw new ArgumentException("Source vertex id was not an integer: " + input);
            }

            return sourceVertexId;
        }

        public static List<int> ParseDestinationVerticesIds(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Destination vertecies ids were not specified");
            }

            List<int> result;

            try
            {
                result = input.Replace(" ", "")
                              .Split(',').ToList()
                              .Select(x => int.Parse(x)).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    "Destination vertecies ids were not int the correct format: " + input,
                    ex);
            }

            return result;
        }
    }
}