// See https://aka.ms/new-console-template for more information

var a = FindFirstUnique(new []{2, 4, 6, 7, 6, 2}, 6);

return 0;

static int FindFirstUnique(int []arr, int size)
{
    for (int i = 0; i < size; i++)
    {
        var isUnique = true;
        
        for (int j = 0; j < size; j++)
        {
            if(i == j)
                continue;

            if (arr[i] == arr[j])
            {
                isUnique = false;
                break;
            }
        }

        if (isUnique)
            return arr[i];
    }
    
    return -1;
}