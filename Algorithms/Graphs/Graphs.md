#### Previous: [Home &laquo;](../../README.md)

# Intro to Graphs

### BFS

Pseudo code
      
      While all vertices are not explored do:
          enqueue(any vertex)
          While Queue is not empty
              v = dequeue()
              if v is not visited then
              v mark as visited
              enqueue (all adjacent unvisited vertices of v)

*Solution*

``` cs 
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
```

### DFS

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

### Generic Graph Data Structure

[Source:](https://www.koderdojo.com/blog/depth-first-search-algorithm-in-csharp-and-net-core)

#### Previous: [Home &laquo;](../../README.md)