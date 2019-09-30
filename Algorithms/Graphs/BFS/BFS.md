#### Previous: [Home &laquo;](../../../README.md)

### BFS first run

Pseudo code
      
      While all vertices are not explored do:
          enqueue(any vertex)
          While Queue is not empty
              v = dequeue()
              if v is not visited then
              v mark as visited
              enqueue (all adjacent unvisited vertices of v)

``` cs 
public static void BFS(Node graph)
{
    Queue queue = new Queue();

    queue.EnQueue(graph);
    while (queue.IsEmpty() == false)
    {
        if (queue.Front().Visited == false)
        {
            Console.WriteLine(queue.Front().Value);
            queue.Front().Visited = true;

            foreach (var neighbour in queue.Front().Neighbours)
            {
                queue.EnQueue(neighbour);
            }

            queue.DeQueue();
        }
        else
        {
            queue.DeQueue();
        }
    }
}
```

#### Previous: [Home &laquo;](../../../README.md)
