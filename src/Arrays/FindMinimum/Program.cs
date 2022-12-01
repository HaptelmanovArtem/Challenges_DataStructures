// See https://aka.ms/new-console-template for more information

var a = FindMinimum(new[] { 9, 2, 3, 6 }, 4);

return 0;

static int FindMinimum(int []arr, int size)
{
    var minimum = arr[0];

    for (var i = 0; i < arr.Length; i++)
    {
        if (arr[i] < minimum)
            minimum = arr[i];
    }
    
    return minimum;
}