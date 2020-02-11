using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace MaxSumTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
            *      5
            *    /   \
            *  -22    11
            *  / \    / \
            * 9  50  9   2
            */
            TreeNode left = TreeNode.Leaf(-22).WithLeaves(9, 50);
            TreeNode right = TreeNode.Leaf(11).WithLeaves(9, 2);

            TreeNode root = TreeNode.Join(5, left, right);
            
            var solution = MaxSum(root);
        }
        
        public static int MaxSum(TreeNode treeNode)
        {
            if (treeNode == null) return 0;

            int left = 0;
            int right = 0;

            if (treeNode.left != null)
            {
                left = MaxSum(treeNode.left);
            }

            if (treeNode.right != null)
            {
                right = MaxSum(treeNode.right);
            }

            return Math.Max(left, right) + treeNode.value;
        }
    }

    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public static TreeNode Leaf(int value)
        {
            var tree = new TreeNode
            {
                value = value
            };

            return tree;
        }

        internal TreeNode WithLeaves(int v1, int v2)
        {
            if (left == null)
            {
                left = new TreeNode {value = v1};
            }

            if (right == null)
            {
                right = new TreeNode {value = v2};
            }

            return this;
        }

        internal static TreeNode Join(int v, TreeNode left, TreeNode right)
        {
            var root = new TreeNode {left = left, right = right, value = v};

            return root;
        }

        public override string ToString()
        {
            return String.Format($"Root:{value} Left:{left.value} Right:{right.value}");
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void MaxSumInNullTree()
        {
            TreeNode root = null;
            Assert.AreEqual(0, Program.MaxSum(root));
        }

        /**
         *      5
         *    /   \
         *  -22    11
         *  / \    / \
         * 9  50  9   2
         */
        [Test]
        public void MaxSumInPerfectTree()
        {
            TreeNode left = TreeNode.Leaf(-22).WithLeaves(9, 50);
            TreeNode right = TreeNode.Leaf(11).WithLeaves(9, 2);
            TreeNode root = TreeNode.Join(5, left, right);
            Assert.AreEqual(33, Program.MaxSum(root));
        }
    }
}