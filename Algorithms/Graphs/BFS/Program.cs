using System;
using System.Collections.Generic;

namespace BFS
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

            BFS2(v1);
        }
        /* PSEUDO
         * While all vertices are not explored do:
         *     enqueue(any vertex)
         *     While Queue is not empty
         *         v = dequeue()
         *         if v is not visited then
         *         v mark as visited
         *         enqueue (all adjacent unvisited vertices of v)
         */

        public static void BFS(Node graph)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(graph);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (vertex.Visited == false)
                {
                    Console.WriteLine(vertex.Value);
                    vertex.Visited = true;
                    foreach (var neighbour in vertex.Neighbours)
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        public static void BFS2(Node graph)
        {
            Queue queue = new Queue();

            queue.EnQueue(graph);
            while (queue.IsEmpty() == false)
            {
                if (queue.Front().Visited == false)
                {
                    Console.WriteLine(queue.Front().Value);
                    queue.Front().Visited = true;

                    foreach (var neighbour in queue.Front().Neighbours)
                    {
                        queue.EnQueue(neighbour);
                    }

                    queue.DeQueue();
                }
                else
                {
                    queue.DeQueue();
                }
            }
        }



        // Helper Queue => just for demostration how could queue work
        public class Queue
        {
            private List<Node> _data;
            private int _startPointer;

            public Queue()
            {
                _data = new List<Node>();
                _startPointer = 0;
            }

            public bool EnQueue(Node number)
            {
                _data.Add(number);
                return true;
            }

            public bool DeQueue()
            {
                if (IsEmpty())
                    return false;

                ++_startPointer;
                return true;
            }

            public Node Front()
            {
                return _data[_startPointer];
            }

            public bool IsEmpty()
            {
                return _startPointer >= _data.Count;
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