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

### DFS Recursion

Pseudo code
        
      pick some vertice from a graph
      create boolean array with vertices in the graph
      create component index helper variable with value = - 1.
      create components dictionary with int key for number of components and list of vertices 
          set each boolean array index to false
              iterate over graph vertices
                  if vertice not visited do
                      method Visit with index and graph vertice parameter
     
      Visit for vertice, index
      set for this vertice in boolean array true
      add vertice to components array
          iterate over degree of this vertice
              if degree not visited then
                  visit
     
      NOTICE: We are not visiting the neighbours of the vertice, we are going still deeper
                 
Solution
    
``` cs 
private static void DfsRecursion(Graph graph)
{
    bool[] visited = new bool[graph.Vertices.Count];
    int componentIndex = -1;
    Dictionary<int, List<int>> components = new Dictionary<int, List<int>>();

    foreach (var vertex in graph.Vertices)
    {
        if (visited[vertex.Value - 1] == false)
        {
            componentIndex += 1;
            components[componentIndex] = new List<int>();
            Visit(vertex, graph, visited, componentIndex, components);
        }
    }
}

private static void Visit(Vertex vertex, Graph graph, bool[] visited, in int componentIndex, Dictionary<int, List<int>> components)
{
    visited[vertex.Value - 1] = true;
    components[componentIndex].Add(vertex.Value);

    foreach (var edge in vertex.Edges)
    {
        Vertex ver = edge.To;
        if (visited[ver.Value - 1] == false)
        {
            Visit(ver, graph, visited, componentIndex, components);
        }
    }
}
```

#### Previous: [Home &laquo;](../../README.md)