#### Previous: [Graphs &laquo;](../Graphs.md)

### BFS

Pseudo code
    
    push first vertice to the stack
      while stack is not empty do:
          pop vertice
          if vertice not visited do:
              print it out
              mark as visited
              add all neighbours to the stack

Solution
    
``` cs 
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
```

#### Previous: [Graphs &laquo;](../Graphs.md)
