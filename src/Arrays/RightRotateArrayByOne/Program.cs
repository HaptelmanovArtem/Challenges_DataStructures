RotateArray(new[] { 1, 2, 3, 4, 5 }, 5);

return 0;

static void RotateArray(int []arr, int size)
{
    var last = arr[size - 1];
    var temp = arr[0];

    for (int i = 0; i < size; i++)
    {
        if (i + 1 >= size)
        {
            break;
        }

        var temp1 = arr[i + 1];
        arr[i + 1] = i == 0 ? arr[0] : temp;

        temp = temp1;
    }

    arr[0] = last;
}