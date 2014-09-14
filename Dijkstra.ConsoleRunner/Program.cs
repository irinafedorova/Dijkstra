using System;

using Dijkstra.ConsoleRunner.Helpers;

namespace Dijkstra.ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine(
                    "Please specify input file path, source vertex id and " +
                    "coma-separated list of destination verticies ids.");
            }
            else
            {
                try
                {
                    var inputGraphFileContent = ArgumentsParser.GetFileContent(args[0]);
                    var sourceVertexId = ArgumentsParser.ParseSourceVertexId(args[1]);
                    var destinationVerticesIds = ArgumentsParser.ParseDestinationVerticesIds(args[2]);

                    var algorithmRunner = new AlgorithmRunner();
                    var shortestPaths = algorithmRunner.FindShortestPaths(
                        inputGraphFileContent,
                        sourceVertexId);

                    var result = OutputFormatter.Format(shortestPaths, destinationVerticesIds);

                    Console.WriteLine("Result is {0}", result);
                }
                catch (Exception ex)
                {
                    PrintError(ex);
                }
            }

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        private static void PrintError(Exception ex)
        {
            var currentColor = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var message = ex.Message;
            if (ex.InnerException != null)
            {
                message += " (" + ex.InnerException.Message + ")";
            }
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
