﻿using System;
using System.Collections.Generic;
using DataStorage;

namespace BFS_FindComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines(@"../../../../Files/SevenVertice.txt");
            
            var graph = DataStorage.Program.CreateLinkedGraph(inputData);
            
            Bfs(graph);
        }
        
        /*
         * PSEUDO CODE
         * set component index to -1
         * create components with index and vertices
         *     iterate over graph vertices
         *         set component index +1
         *         call bfs visit
         *
         * BfsVisit
         * Create queue and add picked vertex
         *     iterate until queue isn't empty
         *         pick (dequeue) vertex from queue
         *             if vertex not visited then
         *                 add vertex to components
         *                 set vertex as visited
         *                 add all edges from picked vertex to queue(enqueue)
         */
        private static void Bfs(Graph graph)
        {
            int componentIndex = -1;
            Dictionary<int, List<int>> components = new Dictionary<int, List<int>>();

            foreach (var vertex in graph.Vertices)
            {
                componentIndex += 1;
                Visit(vertex, components, componentIndex);
            }
        }

        private static void Visit(Vertex vertex, Dictionary<int, List<int>> components, int componentIndex)
        {
            Queue<Vertex> queueVertexes = new Queue<Vertex>();
            queueVertexes.Enqueue(vertex);

            while (queueVertexes.Count > 0)
            {
                Vertex deque = queueVertexes.Dequeue();
                
                if (deque.Visited == false)
                {
                    if (!components.ContainsKey(componentIndex))
                        components[componentIndex] = new List<int>();
                        
                    components[componentIndex].Add(deque.Name);
                    deque.Visited = true;
                    
                    foreach (var edges in deque.Edges)
                    {
                        queueVertexes.Enqueue(edges.To);
                    }
                }
            }
        }
    }
}