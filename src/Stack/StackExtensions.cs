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
            if (stack.Count == 0 || stack.Peek() > value)
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

    /*
     * Next Greater Element Using a Stack
     */
    public static int[] NextGreaterElement(int[] arr, int size)
    {
        var result = new int[size];
        var stack = new Stack<int>();

        for (var i = arr.Length - 1; i >= 0; i--)
        {
            stack.Push(arr[i]);
        }

        int GetNextTop(Stack<int> tempStack, int value)
        {
            if (tempStack.Count == 0)
                return -1;

            if (tempStack.Peek() > value)
                return tempStack.Peek();

            var item = tempStack.Pop();
            var res = GetNextTop(tempStack, value);
            tempStack.Push(item);

            return res;
        }

        var index = 0;
        while (stack.Count != 0)
        {
            var topItem = stack.Pop();

            var item = GetNextTop(stack, topItem);
            result[index++] = item;
        }

        return result;
    }

    // Check Balanced Parentheses Using Stack
    /*
        In this problem, you have to implement the isBalanced() function, which will take a string containing only curly {}, square [], and round () parentheses.
        The function will tell you whether all the parentheses in the string are balanced or not.
        For all the parentheses to be balanced, every opening parenthesis must have a closing one. The order in which they appear also matters. 
        For example, {[]} is balanced, but {[}] is not.
     */
    public static bool IsBalanced(string exp)
    {
        var pairs = new Dictionary<char, char>
        {
            ['{'] = '}',
            ['('] = ')',
            ['['] = ']',
        };
        
        if (exp.Length % 2 != 0)
            return false;

        var startingStack = new Stack<char>();
        var endingStack = new Stack<char>();
        var midIndex = exp.Length / 2;
        
        for (int i = 0; i < midIndex; i++)
            startingStack.Push(exp[i]);

        for (int i = exp.Length - 1; i >= midIndex; i--)
            endingStack.Push(exp[i]);

        while (startingStack.Count != 0 || endingStack.Count != 0)
        {
            if (pairs[startingStack.Pop()] != endingStack.Pop())
                return false;
        }

        return true;
    }
}