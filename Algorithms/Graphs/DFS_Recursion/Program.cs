﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataStorage;

namespace DFS_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines("/Users/jozefrandjak/Documents/NETCore/Projects/CoffeTime/Files/TenVerticeGraph.txt");
            
            Graph graphEmpty = new Graph(); 
            
            Graph graph = DataStorage.Program.CreateLinkedGraph(inputData, graphEmpty);

            DfSrecursion(graph);
        }

        /* PSEUDO CODE
         * pick some vertice from a graph
         * create boolean array with vertices in the graph
         * create component index helper variable with value = - 1.
         * create components dictionary with int key for number of components and list of vertices 
         *     set each boolean array index to false
         *         iterate over graph vertices
         *             if vertice not visited do
         *                 method Visit with index and graph vertice parameter
         *
         * Visit for vertice, index
         * set for this vertice in boolean array true
         * add vertice to components array
         *     iterate over degree of this vertice
         *         if degree not visited then
         *             visit
         *
         * NOTICE: We are not visiting the neighbours of the vertice, we are going still deeper
         */
        static void DfSrecursion(Graph graph)
        {
            bool[] visited = new bool[graph.Vertices.Count];
            int componentIndex = -1;
            Dictionary<int, List<int>> components = new Dictionary<int, List<int>>();

            foreach (var vertex in graph.Vertices)
            {
                if (visited[vertex.Value - 1] == false)
                {
                    componentIndex += 1;
                    components[componentIndex] = new List<int>();
                    Visit(vertex, graph, visited, componentIndex, components);
                }
            }
        }

        private static void Visit(Vertex vertex, Graph graph, bool[] visited, in int componentIndex, Dictionary<int, List<int>> components)
        {
            visited[vertex.Value - 1] = true;
            components[componentIndex].Add(vertex.Value);

            foreach (var edge in vertex.Edges)
            {
                Vertex ver = edge.To;
                if (visited[ver.Value - 1] == false)
                {
                    Visit(ver, graph, visited, componentIndex, components);
                }
            }
        }
    }
}