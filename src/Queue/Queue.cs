using SingleLinkedList;

namespace Queue;

public class Queue
{
    private readonly DoubleLinkedList _doubleLinkedList = new();
    private int _queueSize = 0;

    public void Enqueue(int value)
    {
        _doubleLinkedList.InsertAtTail(value);
        _queueSize++;
    }

    public void Dequeue()
    {
        _doubleLinkedList.DeleteHead();
        _queueSize--;
    }

    public bool IsEmpty()
    {
        return _doubleLinkedList.IsEmpty();
    }

    public int GetFront()
    {
        var headNode = _doubleLinkedList.GetHead();

        if (headNode is null)
        {
            return -1;
        }

        return headNode.Value;
    }

    public int GetSize() => _queueSize;
    
    
    /*
        Implement a function string [] findBin(int n), which will generate binary numbers from 1 to n
        stored in an array of type string by making use of a queue.
     */
    public string[] FindBin(int n)
    {
        for (var i = 1; i <= n; i++)
        {
            Enqueue(i);
        }

        var result = new string[n];
        var tempIndex = 0;
        
        while (_queueSize > 0)
        {
            var first = GetFront();

            result[tempIndex++] = Convert.ToString(first, 2);
            
            Dequeue();
        }

        return result;
    }

    /*
        Implement the function Reverse, 
        which takes a queue and a number k as input and reverses the first k elements of the queue.
     */
    public void Reverse(int size)
    {
        if (size < 0 || size >= GetSize())
            throw new ArgumentOutOfRangeException(nameof(size));

        if (size == 0)
            return;

        var stack = new Stack.Stack(size);

        var temp = 0;
        while (size > temp)
        {
            stack.Push(GetFront());
            Dequeue();
            temp++;
        }

        while (stack.GetSize() != 0)
        {
            Enqueue(stack.Pop());
        }

        for (int i = 0; i < GetSize() - size; i++)
        {
            Enqueue(GetFront());
            Dequeue();
        }
    }
}