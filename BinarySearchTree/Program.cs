using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();

            for (int i = 0; i < 20; i++)
            {
                var rnd = new Random();
                tree.AddValue(rnd.Next(0,100));
            }

            tree.Traverse();
        }

        class Tree
        {
            public Node Root { get; set; }

            public void AddValue(int value)
            {
                var node = new Node(value);

                if (Root == null)
                    Root = node;
                else
                    Root.AddNode(node);
            }

            public void Traverse()
            {
                Root.Visit();
            }
        }

        class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }

            private int _value;

            public Node(int value)
            {
                _value = value;
            }

            public void AddNode(Node node)
            {
                if (_value > node._value)
                {
                    if (Left != null)
                        Left.AddNode(node);
                    else
                        Left = node;
                }

                if (_value < node._value)
                {
                    if (Right != null)
                        Right.AddNode(node);
                    else
                        Right = node;
                }
            }

            public void Visit()
            {
                if (Left != null)
                    Left.Visit();

                Console.WriteLine(_value);

                if (Right != null)
                    Right.Visit();
            }
        }
    }
}