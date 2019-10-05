using System;
using System.Collections.Generic;

namespace DFS
{
    class Program
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

            var v1 = new Node(1);
            var v2 = new Node(2);
            var v3 = new Node(3);
            var v4 = new Node(4);
            var v5 = new Node(5);
            var v6 = new Node(6);
            var v7 = new Node(7);

            v1.Neighbours.Add(v2);
            v1.Neighbours.Add(v3);
            v2.Neighbours.Add(v4);
            v2.Neighbours.Add(v5);
            v3.Neighbours.Add(v6);
            v4.Neighbours.Add(v7);
            v4.Neighbours.Add(v5);
            v6.Neighbours.Add(v7);

            DFS(v1);
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
        public static void DFS(Node graph)
        {
            Stack<Node> verticeStack = new Stack<Node>();
            verticeStack.Push(graph);

            while (verticeStack.Count > 0)
            {
                var vertice = verticeStack.Pop();

                if (vertice.Visited == false)
                {
                    Console.WriteLine(vertice);
                    vertice.Visited = true;

                    foreach (var neighbour in vertice.Neighbours)
                    {
                        verticeStack.Push(neighbour);
                    }
                }
            }
        }
    }

    class Node
    {
        public int Value { get; set; }

        public bool Visited { get; set; }
        public List<Node> Neighbours { get; set; }

        public Node(int value)
        {
            Value = value;
            Neighbours = new List<Node>();
        }

        public override string ToString()
        {
            return string.Format($"V {Value}");
        }
    }
}