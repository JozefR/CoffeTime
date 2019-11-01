using System;
using System.Collections;
using System.Collections.Generic;
using DataStorage;

namespace BFS_WithLevels
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines(@"../../../../Files/EightVertice.txt");
            
            Graph graph = new Graph();

            Graph graphData = DataStorage.Program.CreateLinkedGraph(inputData, graph);

            BfsLevels(graphData.Vertices[0]);
        }

        /* PSEUDO CODE
         * create levels dictionary with initial vertice and initial level 0
         * create parent dictionary with initial vertice and parent = none
         * set index to 1
         * create frontier array and set it to initial vertice
         * while frontier not empty then
         *    create empty array called next
         *    iterate over frontier vertices 
         *      iterate over frontier edges
         *            if edge not visited then
         *                set levels dictionary for not visited edge to current level
         *                set parent dictionary for not visited edge to frontier
         *                append not visited edge to next
         *      set frontier to next
         *      set index to + 1
         */
        private static void BfsLevels(Vertex vertex)
        {
            // Key vertice name, value level
            var level = new Dictionary<int, int> {[vertex.Value] = 0};
            var parent = new Dictionary<int, int?>{[vertex.Value] = null};
            var i = 1;
            var frontier = new List<Vertex>(){vertex};

            while (frontier.Count > 0)
            {
                var next = new List<Vertex>();

                foreach (var front in frontier)
                {
                    foreach (var edge in front.Edges)
                    {
                        if (!level.ContainsKey(edge.To.Value))
                        {
                            level[edge.To.Value] = i;
                            parent[edge.To.Value] = front.Value;
                            next.Add(edge.To);
                        }
                    }
                }
                frontier = next;
                i++;
            }
        }
    }
}