namespace Stack;

public class GetMinFromStack
{
    private readonly Stack<int> _mainStack = new();
    private readonly Stack<int> _minStack = new();

    public GetMinFromStack(int size)
    {
    }

    public GetMinFromStack()
    {
    }
    
    public void Push(int value)
    {
        _mainStack.Push(value);

        if (_mainStack.Count == 0)
        {
            _minStack.Push(value);
        }

        _minStack.Push(_mainStack.Peek() < _minStack.Peek() ? value : _minStack.Peek());
    }

    public int Pop()
    {
        _minStack.Pop();
        return _mainStack.Pop();
    }

    public int Min()
    {
        return _minStack.Peek();
    }
}