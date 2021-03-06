#### Previous: [Home &laquo;](../Medium.md)

# Max Sum Tree

[Codewars](https://www.codewars.com/kata/57e5279b7cf1aea5cf000359)

You are given a binary tree. Implement the method maxSum which 
returns the maximal sum of a route from root to leaf.

For example, given the following tree:
    
        17
       /  \
      3   -10
     /    /  \
    2    16   1
             /
            13
        
        
           5
         /   \
       -22    11
       / \    / \
      9  50  9   2
        
The method should return 23, since [17,-10,16] is the route
from root to leaf with the maximal sum.


## Solutions

``` cs  
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
```

#### Previous: [Home &laquo;](../Medium.md)
