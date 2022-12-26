using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/reverse-array-in-groups0255/1
Given an array arr[] of positive integers of size N. Reverse every sub-array group of size K.

Note: If at any instance, there are no more subarrays of size greater than or equal to K, 
then reverse the last subarray (irrespective of its size).
You shouldn't return any array, modify the given array in-place.

Input: N = 5, K = 3
arr[] = {1,2,3,4,5}
Output: 3 2 1 5 4
Explanation: First group consists of elements 1, 2, 3. Second group consists of 4,5.

Algo:
1. outer loop for incrementing based on group number
2. inner loop for reversing.
*/
public class ReverseArrayInGroup
{
    public void ReverseInGroups(int[] arr, int N, int K)
    {
        for (int i = 0; i < N; i = i + K)
        {
            var l = i;
            var r = Math.Min(i + K - 1, N - 1); // This is to avoid outOfBoundException

            while (l < r)
            {
                var temp = arr[l];
                arr[l] = arr[r];
                arr[r] = temp;
                l++;
                r--;
            }
        }
    }
}

[TestClass]
public class TestReverseArrayInGroup
{
    [TestMethod]
    [DataRow(5, 3, "1 2 3 4 5", "3 2 1 5 4")]
    [DataRow(4, 3, "5 6 8 9", "8 6 5 9")]
    public void TestReverseInGroups(int numberOfElements, int k, string elements, string expectedOutput)
    {
        //Arrange
        var stringArr1 = elements.Split(' ');
        var arr = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr1[i]);
        }

        //Act
        var obj = new ReverseArrayInGroup();
        obj.ReverseInGroups(arr, numberOfElements, k);
        var outputString = string.Join(' ', arr);

        //Assert
        Assert.AreEqual(expectedOutput, outputString);
    }
}