#### Previous: [Home &laquo;](../Graphs.md)

## Dijkstra

Pseudo Code

    /*
     * Set the distance of all the vertices as infinity and start vertex = 0
     * Save all the vertices in minheap
     * Do until minheap is not empty
     *     current vertex = extract from minheap
     *         for each neighbour of current V
     *             if current V distance + current edge distance < neighbour distance
     *                 update neighbour distance and parent
     * 
     */

Solution

``` cs 
private static void Dijkstra(List<Vertex> graph, int startVertex)
{
    const int infinity = 99999;

    List<Vertex> minHeap = new List<Vertex>();

    foreach (var vertex in graph)
    {
        if (vertex.Name == startVertex)
        {
            vertex.PathValue = 0;
            minHeap.Add(vertex);
            continue;
        }
        
        vertex.PathValue = infinity;
        minHeap.Add(vertex);
    }

    while (minHeap.Count > 0)
    {
        var currentVertex = minHeap.First();
        minHeap.Remove(currentVertex);
        foreach (var neighbour in currentVertex.Edges)
        {
            if (currentVertex.PathValue + neighbour.Weight < neighbour.To.PathValue)
            {
                neighbour.To.PathValue = currentVertex.PathValue + neighbour.Weight;
                neighbour.To.Parent = currentVertex;
                
                // refresh the priority queue
                minHeap.Remove(neighbour.To);
                minHeap.Insert(0, neighbour.To);
            }
        }
    }
}
```

#### Previous: [Home &laquo;](../Graphs.md)
