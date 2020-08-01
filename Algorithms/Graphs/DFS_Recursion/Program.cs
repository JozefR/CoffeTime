using System.Collections.Generic;
using DataStorage;

namespace DFS_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = System.IO.File.ReadAllLines("/Users/jozefrandjak/Documents/NETCore/Projects/CoffeTime/Files/TenVerticeGraph.txt");
            
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

        private static void Visit(Vertex vertex, bool[] visited, in int componentIndex, Dictionary<int, List<int>> components)
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
}