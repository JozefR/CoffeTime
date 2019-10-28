using System;
using System.Collections.Generic;
using DataStorage;

namespace DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *     V1------V2
             *     |       |  \
             *     |       |    \
             *     V3      V4-----V5
             *     |       |    /
             *     |       |  /
             *     V6-----v7
             */

            var inputData = System.IO.File.ReadAllLines(args[0]);

            Graph graph = new Graph();

            Graph graphData = DataStorage.Program.CreateLinkedGraph(inputData, graph);

            DFS(graphData);
        }

        /*
         * PSEUDO CODE
         * push first vertice to the stack
         *     while stack is not empty do:
         *         pop vertice
         *         if vertice not visited do:
         *             print it out
         *             mark as visited
         *             add all neighbours to the stack
         */
        public static void DFS(Graph graph)
        {
            Stack<Vertex> verticeStack = new Stack<Vertex>();
            verticeStack.Push(graph.Vertices[0]);

            while (verticeStack.Count > 0)
            {
                var vertice = verticeStack.Pop();

                if (vertice.Visited == false)
                {
                    Console.WriteLine(vertice);
                    vertice.Visited = true;

                    foreach (var neighbour in vertice.Edges)
                    {
                        Vertex verNeighbour = graph.Vertices[neighbour.To.Value - 1];
                        verticeStack.Push(verNeighbour);
                    }
                }
            }
        }
    }
}