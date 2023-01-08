namespace Stack;

public class Stack
{
    private readonly int[] _arr;
    private readonly int _capacity;
    private int _currentPosition;

    public Stack(int capacity)
    {
        _arr = new int[capacity];
        _capacity = capacity;
        _currentPosition = 0;
    }

    public void Push(int value)
    {
        if (_capacity < _currentPosition)
        {
            _arr[_currentPosition++] = value;
        }

        throw new IndexOutOfRangeException();
    }

    public int Pop()
    {
        if (_currentPosition == 0)
            throw new IndexOutOfRangeException("Stack is empty");

        return _arr[--_currentPosition];
    }

    public int GetTop()
    {
        if (_currentPosition == 0)
            return -1;

        return _arr[_currentPosition - 1];
    }

    public int GetSize()
    {
        return _currentPosition;
    }
    
    public void ShowStack()
    {
        int i = 0;
        while (i < _currentPosition)
        {
            Console.Write("\t" + _arr[_currentPosition - 1 - i]);
            i++;
        }
        Console.WriteLine("");
    }
}