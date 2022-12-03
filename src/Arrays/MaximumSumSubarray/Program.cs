// Given an unsorted array A the maximum sum subarray is the subarray (contiguous elements) from A
// for which the sum of the elements is maximum. In this challenge, find the sum of the maximum sum subarray.
// This problem is trick because the array might have negative integers in any position.
// Therefore, you have to cater to those negative integers while choosing the continuous subarray with
// the largest positive values.

var res = MaxSumArr(new[] { -2,10,7,-5,15,6 }, 6);

return res;

int MaxSumArr(int[] arr, int arrSize)
{
    var maxSum = int.MinValue;
    var currentSum = arr[0];

    for (int i = 1; i < arr.Length; i++)
    {
        if (currentSum < 0)
            currentSum = arr[i];
        else
            currentSum += arr[i];
        
        if (maxSum < currentSum)
        {
            maxSum = currentSum;
        }
    }

    return maxSum;
}