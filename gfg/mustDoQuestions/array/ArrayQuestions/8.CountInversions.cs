using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/inversion-of-array-1587115620/1
Given an array of integers. Find the Inversion Count in the array. 

Input: N = 5, arr[] = {2, 4, 1, 3, 5}
Output: 3
Explanation: The sequence 2, 4, 1, 3, 5 
has three inversions (2, 1), (4, 1), (4, 3).

Algo:
This is a variation of merge sort.
in the step where we merge left and right array.
swap happens when left array element is greater than the right element array.
That is when a swap happens and we should increment the counter.
*/
public class CountInversions
{
    public int Count = 0;
    public long InversionCount(long[] arr, long N)
    {
        MergeSort(arr);
        return Count;
    }

    private long[] MergeSort(long[] arr)
    {
        if (arr.Length < 2)
            return arr;

        var mid = arr.Length / 2;
        var left = new long[mid];
        var right = new long[arr.Length - mid];

        for (int i = 0; i < mid; i++)
        {
            left[i] = arr[i];
        }

        for (int i = mid; i < arr.Length; i++)
        {
            right[i - mid] = arr[i];
        }

        var leftMerged = MergeSort(left);
        var rightMerged = MergeSort(right);
        var mergedArray = MergeArrays(leftMerged, rightMerged);
        return mergedArray;
    }

    private long[] MergeArrays(long[] left, long[] right)
    {
        var i = 0;
        var j = 0;
        var k = 0;

        var mArr = new long[left.Length + right.Length];

        while (i < left.Length && j < right.Length)
        {
            //Meaning no swap happened
            if (left[i] <= right[j])
            {
                mArr[k] = left[i];
                i++;
                k++;
            }
            else //Meaning swap happened
            {
                //Count increment is not simple increment count.
                //left -> 3 4 5 8
                //right-> 1 2 6
                // 1 is lesser than 3 , one swap , but since both the array are already sorted.
                // remaining elements of left are also greater than 1.
                //Therefore count increments by following logic.
                Count = Count + (left.Length - i);

                mArr[k] = right[j];
                j++;
                k++;
            }
        }

        while (i < left.Length)
        {
            mArr[k] = left[i];
            i++;
            k++;
        }

        while (j < right.Length)
        {
            mArr[k] = right[j];
            j++;
            k++;
        }

        return mArr;
    }
}

[TestClass]
public class TestCountInversions
{
    [TestMethod]
    [DataRow(5, "2 4 1 3 5", 3)]
    [DataRow(5, "2 3 4 5 6", 0)]
    [DataRow(3, "10 10 10", 0)]
    public void TestInversionCount(int numberOfElements, string elements, int expectedOutput)
    {
        //Arrange
        var stringArr = elements.Split(' ');
        var arr = new long[stringArr.Length];
        for (int i = 0; i < stringArr.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr[i]);
        }

        //Act
        var obj = new CountInversions();
        var count = obj.InversionCount(arr, numberOfElements);

        //Assert
        Assert.AreEqual(expectedOutput, count);
    }
}