using System.Collections.Generic;
using DataStorage;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines("../../../../Files/TenVerticeWeight.txt");

            Graph graph = DataStorage.Program.CreateLinkedGraph(inputData);

            Dijkstra(graph);
        }

        /*
         * PSEUDO CODE
         * Relaxation Method
         * d[v] Set the length of current shortest path to starting vertex and the length zero.
         * (Through the process of relaxation d[v] should eventually become delta (s,v) which is the length of shortest path from s to v)
         * II[v] is the predecessor of v in the shortest path from s to v (from this we can then construct the shortest path).
         *     if d[v] is greater or equal then the predecessor weight plus current weight
         *        then d[v] becomes the value of predecessor plus current d[v] weight vertex
         *        set the II[v] of current vertex to predecessor.
         */

        private static void Dijkstra(Graph graph)
        {
            var shortestPath = graph.Vertices[0].PathValue;
            var predecessor = new List<Vertex>
            {
                graph.Vertices[0]
            };

            foreach (var vertex in graph.Vertices)
            {
                foreach (var edge in vertex.Edges)
                {
                    Vertex ver = edge.To;
                    Relaxation(predecessor, shortestPath, ver, edge);
                }
            }
        }

        private static void Relaxation(List<Vertex> predecessor, int shortestPath, Vertex ver, Edge current)
        {
            if (current.Weight > current.Weight + shortestPath)
            {
                shortestPath += current.Weight;
                predecessor.Add(ver);
            }
        }
    }
}