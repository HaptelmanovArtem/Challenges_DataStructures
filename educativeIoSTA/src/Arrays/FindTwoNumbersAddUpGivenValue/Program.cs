static int[] FindSum(int []arr, int value, int size)
{
    Sort(arr, 0, arr.Length - 1);

    var i = 0;
    var j = size - 1;

    while (i < j)
    {
        var temp = arr[i] + arr[j];
        
        if (temp == value)
        {
            return new[] { arr[i], arr[j] };
        }

        if (temp > value)
            j--;

        if (temp < value)
            i++;
    }

    return arr;
}

static void Sort(int[] arr, int startIndex, int endIndex)
{
    if (startIndex >= endIndex)
        return;
    
    var center = Partition(arr, startIndex, endIndex);
    
    if(center > 1)
        Sort(arr, startIndex, center - 1);
    if(center + 1 < endIndex)
        Sort(arr, center + 1, endIndex);
}

static int Partition(int[] arr, int i, int j)
{
    var iIndex = i + 1 == arr.Length ? i : i + 1;
    var pivot = arr[i];

    while (true)
    {
        while (arr[iIndex] < pivot)
        {
            iIndex++;
        }

        while (arr[j] > pivot)
        {
            j--;
        }

        if (iIndex < j)
        {
            if (arr[iIndex] == arr[j])
                return j;
            
            Swap(arr, iIndex, j);
        }
        else
        {
            if (pivot < arr[iIndex] && pivot > arr[j])
            {
                Swap(arr, i, j);
            }
            
            return j;
        }
    }
}

static void Swap(int[] arr, int x, int y)
{
    var temp = arr[x];
    arr[x] = arr[y];
    arr[y] = temp;
}