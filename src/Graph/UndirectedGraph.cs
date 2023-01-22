namespace Graph;

public class UndirectedGraph : DirectedGraph
{
    public UndirectedGraph(int verticesCount) 
        : base(verticesCount)
    {
    }

    public override void AddEdge(int vertex, int toVertex)
    {
        AdjacencyList[vertex].AddFirst(toVertex);
        AdjacencyList[toVertex].AddFirst(vertex);
    }
}