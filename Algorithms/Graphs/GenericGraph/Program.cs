using System;
using System.Collections.Generic;

namespace GenericGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var vertexes = new[] {1, 2, 3};
            var edges = new[] {Tuple.Create(1, 2), Tuple.Create(1, 3)};
            var adjacencyList = new Graph<int>(vertexes, edges);
        }
    }

    public class GraphTraversing<T>
    {
        // BFS
        public void BFS(Graph<T> graph)
        {
        }
    }

    public class Graph<T>
    {
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public Graph(IEnumerable<T> vertexes, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertexes)
            {
                AddVertex(vertex);
            }

            foreach (var edge in edges)
            {
                AddEdges(edge);
            }
        }

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdges(Tuple<T, T> neighbours)
        {
            if (AdjacencyList.ContainsKey(neighbours.Item1) && AdjacencyList.ContainsKey(neighbours.Item2))
            {
                AdjacencyList[neighbours.Item1].Add(neighbours.Item2);
                AdjacencyList[neighbours.Item2].Add(neighbours.Item1);
            }
        }
    }
}