using System.Data;
using System.Text;

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
        var stack = new Stack<int>();
        var result = new List<int>();
        var visitedMap = new bool[AdjacencyList.Length];

        for (var i = 0; i < AdjacencyList.Length; i++)
        {
            if (!visitedMap[i])
            {
                stack.Push(i);
                visitedMap[i] = true;
            }

            while (stack.Count != 0)
            {
                var currentNode = stack.Pop();
                result.Add(currentNode);
                var temp = AdjacencyList[currentNode].First;
                while (temp != null)
                {
                    if (visitedMap[temp.Value] != true)
                    {
                        stack.Push(temp.Value);
                        visitedMap[temp.Value] = true;
                    }

                    temp = temp.Next;
                }
            }
        }

        return result;
    }

    public List<int> GetDepthFirstSearch()
    {
        var queue = new Queue<int>();
        var result = new List<int>();
        var visitedMap = new bool[AdjacencyList.Length];

        for (var i = 0; i < AdjacencyList.Length; i++)
        {
            if (!visitedMap[i])
            {
                queue.Enqueue(i);
                visitedMap[i] = true;
            }

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                result.Add(currentNode);
                var temp = AdjacencyList[currentNode].First;
                while (temp != null)
                {
                    if (visitedMap[temp.Value] != true)
                    {
                        queue.Enqueue(temp.Value);
                        visitedMap[temp.Value] = true;
                    }

                    temp = temp.Next;
                }
            }
        }

        return result;
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

    public int GetEdgesCountWithMatrix()
    {
        if (AdjacencyList.Length == 0)
            return 0;

        var pairs = new int[AdjacencyList.Length, AdjacencyList.Length];
        var edges = 0;

        for (var i = 0; i < AdjacencyList.Length; i++)
        {
            foreach (var vertices in AdjacencyList[i])
            {
                if (pairs[vertices, i] == 1)
                    continue;

                pairs[i, vertices] = 1;
                edges++;
            }
        }

        return edges;
    }

    public int GetEdgesCountForUndirected()
    {
        if (AdjacencyList.Length == 0)
            return 0;

        var edges = 0;

        for (var i = 0; i < AdjacencyList.Length; i++)
            edges += AdjacencyList[i].Count;

        return edges / 2;
    }

    public bool CheckPath(int source, int destination)
    {
        if (source == destination)
            return true;

        bool Traversal(LinkedList<int> vertices, int destinationVertex)
        {
            foreach (var vertex in vertices)
            {
                if (vertex == destinationVertex)
                    return true;

                if (Traversal(AdjacencyList[vertex], destinationVertex))
                    return true;
            }

            return false;
        }

        return Traversal(AdjacencyList[source], destination);
    }

    // https://www.educative.io/courses/data-structures-interviews-cs/qVDXOZ0pnzD
    // A graph can only be a tree under two conditions:
    // There are no cycles.
    // The graph is connected.
    public bool IsTree()
    {
        var visitedMap = new Dictionary<int, bool>();

        for (var i = 0; i < VerticesCount(); i++)
        {
            visitedMap[i] = false;
        }

        bool DetectLoop(LinkedList<int> vertices, int currentVertex, Dictionary<int, bool> visitingMap)
        {
            if (visitingMap.ContainsKey(currentVertex))
                return true;

            visitingMap[currentVertex] = true;

            foreach (var vertex in vertices)
            {
                if (DetectLoop(AdjacencyList[vertex], vertex, visitingMap))
                    return true;
            }

            return false;
        }

        if (DetectLoop(AdjacencyList[0], 0, visitedMap))
            return false;

        if (visitedMap.Any(i => i.Value == false))
            return false;

        return true;
    }

    public int FindShortestPath(int source, int destination)
    {
        if (source == destination)
            return 0;

        var queue = new Queue<int>();
        var visitedMap = new bool[AdjacencyList.Length];
        var distanceMap = new int[AdjacencyList.Length];

        if (!visitedMap[source])
        {
            queue.Enqueue(source);
            visitedMap[source] = true;
        }

        while (queue.Count != 0)
        {
            var currentNode = queue.Dequeue();
            var temp = AdjacencyList[currentNode].First;
            while (temp != null)
            {
                if (!visitedMap[temp.Value])
                {
                    queue.Enqueue(temp.Value);
                    visitedMap[temp.Value] = true;
                    distanceMap[temp.Value] = distanceMap[currentNode] + 1;
                }

                if (temp.Value == destination)
                    return distanceMap[temp.Value];

                temp = temp.Next;
            }
        }

        return -1;
    }

    public void RemoveEdge(int source, int destination)
    { 
        AdjacencyList[source].Remove(destination);
    }
}