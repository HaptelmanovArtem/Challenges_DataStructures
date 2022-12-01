static int [] removeEven(int[]Arr, int size)
{
    var resultSize = 0;

    foreach (var t in Arr)
        if (t % 2 != 0)
            resultSize++;

    var result = new int[resultSize];

    var index = 0;
    foreach (var t in Arr)
    {
        if (t % 2 == 0) 
            continue;
        
        result[index] = t;
        index++;
    }
    
    return result;
}