namespace Stack;

/*
     Implement the following functions to implement two stacks by using a single array to store elements. 
     You can make changes to the constructor as well. A solution is placed in the solution section for your help, 
     but it is suggested that you solve it on your own first.
 */
public class TwoStacks
{
    private readonly int _size;
    private readonly int[] _arr;
    private int top1, top2;

    public TwoStacks(int n)
    {
        _size = n;
        _arr = new int[n];
        top2 = _size - 1;
        top1 = 0;
    }
    
    //Insert Value in First Stack  
    public void Push1(int value)
    {
        if(top1 >= top2) // another stack
            return;
        
        _arr[top1] = value;
        top1++;
    }
    
    //Insert Value in Second Stack  
    public void Push2(int value)
    {
        if(top1 > top2) // another stack
            return;
        
        _arr[--top2] = value;
    }

    //Return and remove top Value from First Stack
    public int Pop1()
    {
        if (top1 > 0)
        {
            return _arr[--top1];
        }   
        
        return -1;
    }

    //Return and remove top Value from Second Stack
    public int Pop2()
    {
        if (top2 < _size)
        {
            return _arr[top2++];
        }
        
        return -1;
    }
}