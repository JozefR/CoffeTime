using System;
using System.Collections.Generic;
using System.Linq;

namespace DFS_FindBiggestComponent
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines("../../../graphData.txt");
            
            int[][] edges = new int[12][];

            for (int i = 0; i < inputData.Length; i++)
            {
                var edge = inputData[i].Split(" ").Select(int.Parse).ToArray();
                edges[i] = new []{edge[0], edge[1]};
            } 
            
            var components = CountComponents(10, edges);
        }
        
        public static int CountComponents(int n, int[][] edges)
        {
            int count = 0;
            var visited = new bool[n];
            var dict = new Dictionary<int, List<int>>();
            for (int i = 1; i <= n; i++)
            {
                dict[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                var from = edge[0];
                var to = edge[1];

                dict[@from].Add(to);
                dict[to].Add(@from);
            }
            
            for (int i = 1; i <= n; i++)
            {
                if (!visited[i - 1])
                {
                    CountComponentsHelperDfs(n, dict, i, visited);
                    count++;
                }                
            }

            return count;
        }
        
        private static void CountComponentsHelperDfs(int n, Dictionary<int, List<int>> dict, int cur, bool[] visited)
        {
            if (visited[cur - 1])
                return;

            int[][] edgesTest = new int[12][];

            Stack<int> verticeStack = new Stack<int>();

            foreach (var edges in dict[cur])
            {
                verticeStack.Push(edges);
            }

            while (verticeStack.Count > 0)
            {
                var vertice = verticeStack.Pop();

                if (visited[vertice - 1] == false)
                {
                    Console.WriteLine(vertice);
                    visited[vertice - 1] = true;

                    foreach (var neighbour in dict[vertice])
                    {
                        verticeStack.Push(neighbour);
                        edgesTest[vertice] = new[] {vertice, neighbour};
                    }
                }
            }
        }
    }
}