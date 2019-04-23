using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();

            tree.AddValue(15);
            tree.AddValue(6);
            tree.AddValue(4);
            tree.AddValue(5);
            tree.AddValue(23);
            tree.AddValue(71);
            tree.AddValue(50);
            tree.AddValue(8);

            tree.Traverse();
        }

        class Tree
        {
            private Node Root { get; set; }

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

            public Node Find(int value)
            {
                return Root.SearchFor(value);
            }
        }

        class Node
        {
            private Node Left { get; set; }
            private Node Right { get; set; }

            private readonly int _value;

            public Node(int value)
            {
                _value = value;
            }

            protected internal void AddNode(Node node)
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

            protected internal void Visit()
            {
                if (Left != null)
                    Left.Visit();

                Console.WriteLine(_value);

                if (Right != null)
                    Right.Visit();
            }

            protected internal Node SearchFor(int val)
            {
                var root = this;

                while (root != null && root._value != val)
                {
                    if (root._value > val)
                        root = root.Left;
                    else
                        root = root.Right;
                }

                return root;
            }
        }
    }
}