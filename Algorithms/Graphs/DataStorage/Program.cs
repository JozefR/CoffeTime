using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines("../../../graphData.txt");
            Graph graph = new Graph();
            
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
        }
    }

    class Graph
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
            Edge edge = new Edge(from, to);
            Vertices[vertexNumber - 1].AddEdge(edge);
        }
    }

    class Vertex
    {
        public Vertex()
        {
            Edges = new List<Edge>();
        }

        public List<Edge> Edges { get; }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
    }

    class Edge
    {
        public Edge(int from, int to)
        {
            From = from;
            To = to;
        }

        public int From { get; }
        public int To { get; }
    }
}