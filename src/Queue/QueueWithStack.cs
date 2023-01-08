namespace Queue;

/*
    You have to implement enqueue() and dequeue() functions in the newQueue class by using the Stack class.
    enqueue() will insert a value into the queue and dequeue will remove a value from the queue.
*/
public class QueueWithStack
{
    private readonly Stack<int> _mainStack = new();
    private readonly Stack<int> _tempStack = new();

    public void Enqueue(int value)
    {
        _mainStack.Push(value);
    }

    public int Dequeue()
    {
        if (_mainStack.Count == 0)
            return -1;

        while (_mainStack.TryPop(out var result))
        {
            _tempStack.Push(result);
        }

        var dequeueItem = _tempStack.Pop();

        while (_tempStack.TryPop(out var result))
        {
            _mainStack.Push(result);
        }

        return dequeueItem;
    }
}