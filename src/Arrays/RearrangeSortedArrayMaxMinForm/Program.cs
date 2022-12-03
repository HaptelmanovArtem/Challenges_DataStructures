// Implement a function maxMin(int arr[], int size), which takes a sorted array arr and its size and will
// rearrange the elements of a sorted array such that the first position will have the largest number,
// the second will have the smallest, the third will have second largest, and so on. In other words, all the
// even-numbered indices will have the largest numbers in the array in descending order,
// and the odd-numbered indices will have the smallest numbers in ascending order.

MaxMin(new []{1,2,3,4,5,6,7}, 7);

static void MaxMin(int[] arr, int size)
{
    var i = 0;
    var j = size - 1;

    for (int k = size - 1; k >= size / 2; k--)
    {
        InsertAtPosition(arr, size - 1, i);
        i += 2;
    }
}

static void InsertAtPosition(int[] arr, int fromIndex, int toIndex)
{
    var temp = arr[fromIndex];

    for (int i = arr.Length - 1; i > toIndex; i--)
    {
        arr[i] = arr[i - 1];
    }
    
    arr[toIndex] = temp;
}