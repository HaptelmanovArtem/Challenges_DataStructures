namespace Graph;

public class DirectedGraph
{
    protected readonly LinkedList<int>[] AdjacencyList;

    public DirectedGraph(int verticesCount)
    {
        AdjacencyList = new LinkedList<int>[verticesCount];

        for (var i = 0; i < verticesCount; i++)
            AdjacencyList[i] = new LinkedList<int>();
    }

    public int VerticesCount() => AdjacencyList.Length;

    public virtual void AddEdge(int vertex, int toVertex)
    {
        if (vertex >= AdjacencyList.Length || toVertex >= AdjacencyList.Length)
            throw new InvalidOperationException();
        
        AdjacencyList[vertex].AddFirst(toVertex);
    }

    public void Print()
    {
        for (var vertex = 0; vertex < VerticesCount(); vertex++)
        {
            Console.Write($"Vertex - {vertex} [ ");
            foreach (var adjacencyItem in AdjacencyList[vertex])
            {
                Console.Write($"{adjacencyItem}, ");
            }

            Console.Write(" ]");
            Console.WriteLine();
        }
    }

    public List<int> GetBreadthFirstSearch()
    {
        var visitedVertices = new HashSet<int>();
        
        for (var i = 0; i < AdjacencyList.Length; i++)
        {
            visitedVertices.Add(i);

            foreach (var adjacencyVertex in AdjacencyList[i])
            {
                visitedVertices.Add(adjacencyVertex);
            }
        }

        return visitedVertices.ToList();
    }
    
    public List<int> GetDepthFirstSearch()
    {
        var result = new HashSet<int>();

        void Traversal(LinkedList<int> vertices, int currentVertex, HashSet<int> accumulatedSet)
        {
            accumulatedSet.Add(currentVertex);

            foreach (var vertex in vertices)
            {
                accumulatedSet.Add(vertex);
                Traversal(AdjacencyList[vertex], vertex, accumulatedSet);
            }
        }
        
        for (var i = 0; i < AdjacencyList.Length; i++)
        {
            if(result.Contains(i))
                continue;
            
            Traversal(AdjacencyList[i], i, result);
        }

        return result.ToList();
    }

    public bool IsContainsCycle()
    {
        bool DetectLoop(LinkedList<int> vertices, int currentVertex, Dictionary<int, bool>? visitingMap = null)
        {
            visitingMap ??= new Dictionary<int, bool>();

            if (visitingMap.ContainsKey(currentVertex))
                return true;
                
            visitingMap.Add(currentVertex, true);
            
            foreach (var vertex in vertices)
            {
                if (DetectLoop(AdjacencyList[vertex], vertex, visitingMap))
                    return true;
            }

            return false;
        }
        
        for (var currentVertex = 0; currentVertex < AdjacencyList.Length; currentVertex++)
        {
            if (DetectLoop(AdjacencyList[currentVertex], currentVertex))
            {
                return true;
            }
        }

        return false;
    }

    // 1) need to save path for each vertex and check if path contains all vertices 
    // 2) check last visited vertex. If all vertices has been visited that last checked vertex is a mother.
    public int GetMotherVertex()
    {
        void Traversal(LinkedList<int> vertices, int currentVertex, bool[] visited)
        {
            visited[currentVertex] = true;
            
            foreach (var vertex in vertices)
            {
                if (!visited[vertex])
                    Traversal(AdjacencyList[vertex], vertex, visited);
            }
        }

        var visitedVertices = new bool[VerticesCount()];
        var lastVisitedVertex = -1;
        
        for (var i = 0; i < VerticesCount(); i++)
        {
            if (!visitedVertices[i])
            {
                Traversal(AdjacencyList[i], i, visitedVertices);
                lastVisitedVertex = i;
            }
        }

        for (var i = 0; i < visitedVertices.Length; i++)
        {
            visitedVertices[i] = false;
        }
        
        Traversal(AdjacencyList[lastVisitedVertex], lastVisitedVertex, visitedVertices);

        for (var i = 0; i < visitedVertices.Length; i++)
        {
            if (visitedVertices[i] == false)
                return -1;
        }
        
        return lastVisitedVertex;
    }
}