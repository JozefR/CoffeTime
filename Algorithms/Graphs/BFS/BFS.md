#### Previous: [Graphs &laquo;](../Graphs.md)

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

#### Previous: [Graphs &laquo;](../Graphs.md)
