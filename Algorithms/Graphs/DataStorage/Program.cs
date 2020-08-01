using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStorage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines("../../../graphData.txt");
            
            Graph graph = CreateLinkedGraph(inputData);

            int[][] matrix = CreateMatrix(graph);
            
            PrintMatrix(matrix);
        }
        
        public static Graph CreateLinkedGraph(string[] inputData)
        {
            var graph = new Graph();
            
            for (int i = 0; i < inputData.Length; i++)
            {
                if (i == 0)
                {
                    graph.AddVertices(int.Parse(inputData[i]));
                    continue;
                }

                var edge = inputData[i].Split(" ").Select(int.Parse).ToArray();

                if (edge.Length > 2)
                {
                    graph.AddEdge(edge[0], edge[0], edge[1], edge[2]);
                }
                else
                {
                    graph.AddEdge(edge[0], edge[0], edge[1]);
                }
            }

            return graph;
        }

        public static int[][] CreateMatrix(Graph graph)
        {
            // Create matrix based on graph vertexes length.
            // set matrix based on vertex edges. 
            int rows = graph.Vertices.Count;
            int columns = graph.Vertices.Count;
            
            int[][] matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int [matrix.Length];
            }
            
            foreach (var vertice in graph.Vertices)
            {
                foreach (var edge in vertice.Edges)
                {
                    // because matrix is indexed from zero we need to decrease from, to edges
                    int matrixColumn = edge.From.Name - 1;
                    int matrixRow = edge.To.Name - 1;
                    matrix[matrixRow][matrixColumn] = 1;
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(" " + matrix[i][j]);
                }
                Console.WriteLine("");
            }                
        }
    }

    public class Graph
    {
        public Graph()
        {
            Vertices = new List<Vertex>();
        }

        public List<Vertex> Vertices { get; }

        public void AddVertices(int vertices)
        {
            for (int i = 1; i <= vertices; i++)
            {
                Vertices.Add(new Vertex(i));
            }
        }

        public void AddEdge(int vertexNumber, int from, int to)
        {
            Edge edge = new Edge(this.Vertices[from - 1], this.Vertices[to - 1]);
            Vertices[vertexNumber - 1].AddEdge(edge);
        }
        
        public void AddEdge(int vertexNumber, int from, int to, int weight)
        {
            Edge edge = new Edge(this.Vertices[from - 1], this.Vertices[to - 1], weight);
            Vertices[vertexNumber - 1].AddEdge(edge);
        }
    }

    public class Vertex
    {
        public Vertex(int name)
        {
            Edges = new List<Edge>();
            Name = name;
        }

        /// <summary>
        /// Name of the Vertex
        /// </summary>
        public int Name { get; set; }

        /// <summary>
        /// Relaxed path value for this vertex
        /// </summary>
        public int PathValue { get; set; }

        public Vertex Parent { get; set; }
        public bool Visited { get; set; }
        public List<Edge> Edges { get; }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public override string ToString()
        {
            return String.Format($"V{Name}");
        }
    }

    public class Edge
    {
        public Edge(Vertex from, Vertex to)
        {
            From = from;
            To = to;
        }

        public Edge(Vertex from, Vertex to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public Vertex From { get; }
        public Vertex To { get; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return String.Format($"Edge {From}{To}");
        }
    }
}