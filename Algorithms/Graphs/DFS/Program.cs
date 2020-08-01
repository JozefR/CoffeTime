using System;
using System.Collections.Generic;
using System.Linq;
using DataStorage;

namespace DFS
{
    internal class A_SimpleDfs
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

            var inputData = System.IO.File.ReadAllLines(@"../../../../Files/SevenVertice.txt");

            Graph graphData = DataStorage.Program.CreateLinkedGraph(inputData);

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
                        Vertex verNeighbour = neighbour.To;
                        verticeStack.Push(verNeighbour);
                    }
                }
            }
        }
    }

    internal class B_DfsWithComponents
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines("../../../graphData.txt");

            int[][] edges = new int[12][];

            for (int i = 0; i < inputData.Length; i++)
            {
                var edge = inputData[i].Split(" ").Select(int.Parse).ToArray();
                edges[i] = new[] {edge[0], edge[1]};
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

    internal class C_DfsBiggestRegion
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }

            public static int GetBiggestRegion(int[][] matrix)
            {
                int maxRegion = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 1)
                        {
                            int size = GetRegionSize(matrix, row, col);
                            maxRegion = Math.Max(size, maxRegion);
                        }
                    }
                }

                return maxRegion;
            }

            private static int GetRegionSize(int[][] matrix, in int row, in int col)
            {
                if (row < 0 || col < 0 || row >= matrix.Length || col >= matrix[row].Length)
                    return 0;
                if (matrix[row][col] == 0)
                    return 0;

                matrix[row][col] = 0;
                int size = 1;
                for (int r = row - 1; r < row + 1; r++)
                {
                    for (int c = col - 1; c < col + 1; c++)
                    {
                        if (r != row || c != col)
                        {
                            size += GetRegionSize(matrix, row, col);
                        }
                    }
                }

                return size;
            }
    }

    internal class D_DfsRecursion
    {
            static void Main(string[] args)
            {
                var inputData =
                    System.IO.File.ReadAllLines(
                        "/Users/jozefrandjak/Documents/NETCore/Projects/CoffeTime/Files/TenVerticeGraph.txt");

                Graph graph = DataStorage.Program.CreateLinkedGraph(inputData);

                DfsRecursion(graph);
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

            private static void DfsRecursion(Graph graph)
            {
                bool[] visited = new bool[graph.Vertices.Count];
                int componentIndex = -1;
                Dictionary<int, List<int>> components = new Dictionary<int, List<int>>();

                foreach (var vertex in graph.Vertices)
                {
                    if (visited[vertex.Name - 1] == false)
                    {
                        componentIndex += 1;
                        components[componentIndex] = new List<int>();
                        Visit(vertex, visited, componentIndex, components);
                    }
                }
            }

            private static void Visit(Vertex vertex, bool[] visited, in int componentIndex,
                Dictionary<int, List<int>> components)
            {
                visited[vertex.Name - 1] = true;
                components[componentIndex].Add(vertex.Name);

                foreach (var edge in vertex.Edges)
                {
                    Vertex ver = edge.To;
                    if (visited[ver.Name - 1] == false)
                    {
                        Visit(ver, visited, componentIndex, components);
                    }
                }
            }
    }

    internal class E_DfsPlayGround
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines(@"../../../../Files/alpha.txt");

            Graph graphData = Program.CreateLinkedGraph(inputData);

            DfsCompRecursion(graphData);
        }

        private static void DfsCompRecursion(Graph graph)
        {
            var parent = new Dictionary<Vertex, Vertex>();
            foreach (var v in graph.Vertices)
            {
                if (!parent.ContainsKey(v))
                {
                    parent[v] = null;
                    Console.WriteLine(v);
                    DfsPlayRecursion(v, parent);
                }
            }
        }

        private static void DfsPlayRecursion(Vertex s, Dictionary<Vertex, Vertex> parent)
        {
            foreach (var uEdge in s.Edges)
            {
                if (!parent.ContainsKey(uEdge.To))
                {
                    Console.WriteLine(uEdge.To);
                    parent[uEdge.To] = s;
                    DfsPlayRecursion(uEdge.To, parent);
                }
            }
        }

        private static void DfsPlay(Graph graphData)
        {
            Stack<Vertex> stack = new Stack<Vertex>();
            stack.Push(graphData.Vertices[0]);

            while (stack.Count > 0)
            {
                var v = stack.Pop();
                if (v.Visited == false)
                {
                    v.Visited = true;
                    Console.WriteLine(v);
                    foreach (var u in v.Edges)
                    {
                        stack.Push(u.To);
                    }
                }
            }
        }
    }
}