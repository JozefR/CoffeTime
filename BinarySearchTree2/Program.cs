namespace BinarySearchTree2
{
    class Program
    {
        static void Main()
        {
            var tree = new BinarySearchTree();

            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(20);

            tree.Delete(20);

            var find = tree.Find(20);
        }
    }

    class BinarySearchTree
    {
        public Vertex Root { get; set; }

        public BinarySearchTree()
        {
            Root = new Vertex(this);
        }

        public Vertex Find(int value)
        {
            var vertex = SearchFor(value);
            return vertex;
        }

        public void Insert(int value)
        {
            var vertex = SearchFor(value);

            if (vertex.Value == null)
            {
                Vertex left = new Vertex(this);
                Vertex right = new Vertex(this);
                left.Interval = new[] { vertex.Interval[0], value};
                right.Interval = new[] { value, vertex.Interval[1]};
                vertex.Interval = null;
                vertex.Value = value;
                vertex.Left = left;
                vertex.Right = right;
                left.Father = vertex;
                right.Father = vertex;
            }
        }

        public Vertex Delete(int value)
        {
            var vertex = SearchFor(value);

            if (vertex.Value != null)
            {
                // left son is a list
                if (vertex.Left.Value == null)
                {
                    var leftIndex = vertex.Left.Interval[0];
                    vertex = delete(vertex, vertex.Left);

                    while (vertex.Value != null)
                    {
                        vertex = vertex.Left;
                    }

                    vertex.Interval[0] = leftIndex;
                }
                else
                {
                    var vertexRight = vertex.Left;
                    while (vertexRight.Right.Value != null)
                    {
                        vertexRight = vertexRight.Right;
                    }

                    vertex.Value = vertexRight.Value;
                    delete(vertexRight, vertexRight.Right);
                    var vertexLeft = vertex.Right;
                    while (vertexLeft.Value != null)
                    {
                        vertexLeft = vertexLeft.Left;
                    }

                    vertexLeft.Interval[0] = vertex.Value.Value;
                }
            }

            return vertex;
        }

        private Vertex delete(Vertex vertex, Vertex vertexLeft)
        {
            Vertex vertexZ = vertex.Left == vertexLeft ? vertex.Right : vertex.Left;

            if (vertex != Root)
            {
                vertexZ.Father = Root.Father;
                if (vertex == vertex.Father.Right)
                {
                    vertex.Father.Right = vertexZ;
                }
                else
                {
                    vertex.Father.Left = vertexZ;
                }
            }
            else
            {
                vertexZ.Father = null;
                Root = vertexZ;
            }

            return vertex;
        }

        private Vertex SearchFor(int value)
        {
            var vertex = Root;

            while (vertex.Value != null && vertex.Value != value)
            {
                if (value < vertex.Value)
                    vertex = vertex.Left;
                else
                    vertex = vertex.Right;
            }

            return vertex;
        }
    }

    class Vertex
    {
        public Vertex Left { get; set; }
        public Vertex Right { get; set; }
        public Vertex Father { get; set; }

        public int? Value { get; set; }
        public int[] Interval { get; set; }

        public BinarySearchTree Tree { get; set; }

        public Vertex(BinarySearchTree binarySearchTree)
        {
            Tree = binarySearchTree;
            Interval = new int[2];
        }
    }
}