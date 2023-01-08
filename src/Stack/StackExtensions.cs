namespace Stack;

public static class StackExtensions
{
    public static Stack<int> Sort(this Stack<int> stack, int size)
    {
        var tempArr = new int[size];

        for (int i = 0; i < size; i++)
        {
            tempArr[i] = stack.Pop();
        }

        var maxItem = int.MinValue;
        for (int i = 0; i < size; i++)
        {
            var maxIndex = 0;
            for (int j = 0; j < size; j++)
            {
                if (tempArr[j] > maxItem)
                {
                    maxItem = tempArr[j];
                    maxIndex = j;
                }
            }

            tempArr[maxIndex] = int.MinValue;
            stack.Push(maxItem);
            maxItem = int.MinValue;
        }

        return stack;
    }
    
    public static Stack<int> SortV2(this Stack<int> stack, int size)
    {
        var tempStack = new Stack<int>();

        while (stack.Count != 0)
        {
            var value = stack.Pop();

            if (tempStack.Count == 0)
            {
                tempStack.Push(value);
                continue;
            }

            if (value >= tempStack.Peek())
            {
                tempStack.Push(value);
            }
            else
            {
                while (tempStack.Count != 0)
                {
                    stack.Push(tempStack.Pop());
                }
                tempStack.Push(value);
            }
        }

        while (tempStack.Count != 0)
        {
            stack.Push(tempStack.Pop());
        }

        return stack;
    }
    
    public static Stack<int> SortV3(this Stack<int> stack, int size)
    {
        static void Insert(Stack<int> stack, int value)
        {
            if(stack.Count == 0 || stack.Peek() > value)
                stack.Push(value);
            else
            {
                var temp = stack.Pop();
                Insert(stack, value);
                stack.Push(temp);
            }
        }

        if (stack.Count == 0) 
            return stack;
        
        var item = stack.Pop();
        SortV3(stack, size);
        Insert(stack, item);

        return stack;
    }

    /*
     * Evaluate Postfix Expression Using a Stack
     */
    public static int EvaluatePostFix(string exp)
    {
        int ExecuteOperation(char type, int x, int y)
        {
            return type switch
            {
                '+' => y + x,
                '*' => y * x,
                '-' => y - x,
                '/' => y / x,
                _ => throw new NotSupportedException()
            };
        }
        
        var stack = new Stack<int>();

        foreach (var i in exp)
        {
            if (char.IsDigit(i))
            {
                stack.Push(int.Parse(i.ToString()));
                continue;
            }
            
            stack.Push(ExecuteOperation(i, stack.Pop(), stack.Pop()));
        }
        
        return stack.Pop();
    }
}