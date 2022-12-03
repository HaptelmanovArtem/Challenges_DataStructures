
ReArrange(new []{-23,1,-2,0,44,-9,8}, 7);

static void ReArrange(int []arr, int size)
{
    var tempArr = new int[size];
    var index = 0;
    
    for (int i = 0; i < size; i++)
    {
        if (arr[i] < 0)
            tempArr[index++] = arr[i];
    }

    for (int i = 0; i < size; i++)
    {
        if(arr[i] >= 0)
            tempArr[index++] = arr[i];
    }

    for (int i = 0; i < size; i++)
    {
        arr[i] = tempArr[i];
    }
}