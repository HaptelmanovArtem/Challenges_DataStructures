// See https://aka.ms/new-console-template for more information

var res = FindProductV2(new[] { 4, 2, 1, 5, 0 }, 5);

return 0;

// Accumulate
static int[] FindProductV2(int[] arr, int size)
{
    var product = new int[size];

    var accum = 1;

    for (int i = 0; i < size; i++)
    {
        product[i] = accum;
        accum *= arr[i];
    }

    accum = 1;
    
    for (var j = size - 1; j >= 0; j--)
    {
        product[j] *= accum;
        accum *= arr[j];
    }
    
    return product;
}

// Simple
static int[] FindProduct(int []arr, int size) 
{ 
    var product = new int[size];

    for (var i = 0; i < arr.Length; i++)
    {
        var temp = 1;
        
        for (int j = 0; j < arr.Length; j++)
        {
            if(j == i)
                continue;
            
            temp *= arr[j];
        }

        product[i] = temp;
    }
    
    return product; 
} 