using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStorage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines(args[0]);
            
            Graph graphEmpty = new Graph();

            Graph graph = CreateLinkedGraph(inputData, graphEmpty);

            int[,] matrix = CreateMatrix(graph);
            
            PrintMatrix(matrix);
        }
        
        public static Graph CreateLinkedGraph(string[] inputData, Graph graph)
        {
            for (int i = 0; i < inputData.Length; i++)
            {
                if (i == 0)
                {
                    graph.AddVertices(int.Parse(inputData[i]));
                    continue;
                }

                var edge = inputData[i].Split(" ").Select(int.Parse).ToArray();
                graph.AddEdge(edge[0], edge[0], edge[1]);
            }

            return graph;
        }

        private static int[,] CreateMatrix(Graph graph)
        {
            // Create matrix based on graph vertexes length.
            // set matrix based on vertex edges. 
            int rows = graph.Vertices.Count;
            int columns = graph.Vertices.Count;
            
            int[,] matrix = new int[rows, columns];

            foreach (var vertice in graph.Vertices)
            {
                foreach (var edge in vertice.Edges)
                {
                    // because matrix is indexed from zero we need to decrease from, to edges
                    int matrixColumn = edge.From - 1;
                    int matrixRow = edge.To - 1;
                    matrix[matrixRow, matrixColumn] = 1;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" " + matrix[i, j]);
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
            for (int i = 0; i < vertices; i++)
            {
                Vertices.Add(new Vertex());
            }
        }

        public void AddEdge(int vertexNumber, int from, int to)
        {
            Vertex edge = new Vertex(from, to);
            Vertices[vertexNumber - 1].AddEdge(edge);
        }
    }

    public class Vertex
    {
        public Vertex()
        {
            Edges = new List<Vertex>();
        }

        public Vertex(int from, int to)
        {
            Edges = new List<Vertex>();
            From = from;
            To = to;
        }

        public List<Vertex> Edges { get; }
        
        public bool Visited { get; set; }

        public int From { get; set; }

        public int  To { get; set; }
        
        public void AddEdge(Vertex edge)
        {
            Edges.Add(edge);
        }
    }
}