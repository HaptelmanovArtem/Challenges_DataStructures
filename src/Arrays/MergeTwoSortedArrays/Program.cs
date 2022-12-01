// See https://aka.ms/new-console-template for more information

static int[] mergeArrays(int [] arr1, int []arr2, int arr1Size, int arr2Size)
{
    var result = new int[arr1Size + arr2Size];

    var arr1index = 0;
    var arr2index = 0;
    
    for (var i = 0; i < result.Length; i++)
    {
        if (arr1index < arr1Size)
        {
            result[i] = arr1[arr1index++];
            continue;
        }

        if (arr2index < arr2Size)
            result[i] = arr2[arr2index++];
    }

    var temp = 0;

    for (int i = 0; i < result.Length; i++)
    for (int j = 0; j < result.Length; j++)
    {
        if (result[i] > result[j])
            continue;
        
        temp = result[j];
        result[j] = result[i];
        result[i] = temp;
    }

    return result;
}