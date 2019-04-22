using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();

            tree.AddValue(2);
            tree.AddValue(22);
            tree.AddValue(12);
            tree.AddValue(40);
            tree.AddValue(55);
            tree.AddValue(80);
            tree.AddValue(1);

            tree.Traverse();

            var find = tree.Find(12);
            var find1 = tree.Find(21);
            var find2 = tree.Find(80);
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

            public Node Find(int value)
            {
                var node = Root.SearchFor(value);
                return node;
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