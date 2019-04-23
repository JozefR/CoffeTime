namespace BinarySearchTree2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree();

            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(20);

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