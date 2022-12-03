// See https://aka.ms/new-console-template for more information

var a = FindSecondMaximumV2(new[] { -17,-29,-25,13,-29,39 }, 6);

return a;

// with sort
static int FindSecondMaximum(int []arr, int size)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
    
    return arr[1];
}

// simple
static int FindSecondMaximumV2(int []arr, int size)
{
    var max = int.MinValue;
    var secondMax = int.MinValue;

    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] > max)
        {
            secondMax = max;
            max = arr[i];
        }
        else if (arr[i] < max && arr[i] > secondMax)
        {
            secondMax = arr[i];

        }
    }
    
    return secondMax;
}