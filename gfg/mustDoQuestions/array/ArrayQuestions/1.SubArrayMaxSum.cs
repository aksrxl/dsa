using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;
/*
//https://practice.geeksforgeeks.org/problems/subarray-with-given-sum-1587115621/1
Given an unsorted array A of size N that contains only non-negative integers, 
find a continuous sub-array which adds 
to a given number S and return the left and right index(1-based indexing) of that subarray.
*/

//Solution class
public static class SubArrayMaxSum
{
    public static List<int> SubArraySum(int[] arr, int n, int s)
    {
        var list = new List<int>();
        int sum = arr[0]; // assigning sum as 1st element
        int start = 0; // setting starting point as 0
        for (int i = 1; i <= arr.Length; i++)
        { // remember we are starting from 1
            while (sum > s && start < i - 1)
            {
                sum -= arr[start];   // remove 1st ele if sum exceeds;
                start++;// move starting point by 1 ahead
            }
            if (sum == s)
            {
                return new List<int> { start + 1, i }; // 1 based index therefore +1
            }
            if (i < n)
            {
                sum += arr[i]; // we have not reached to sum so add nxtelement to sum
            }
        }
        return new List<int> { -1 };// we are here coz nothing has been returned;
    }
}

//TestClass
[TestClass]
public class TestSubArrayMaxSum
{
    [TestMethod]
    public void TestSubArrayMaxSumValid()
    {
        //Arrange
        int requiredSum = 12;
        var arr = new int[] { 1, 2, 3, 7, 5 };

        //Act
        var subArrayMaxSum = SubArrayMaxSum.SubArraySum(arr, 5, requiredSum);

        //Act
        // the required sum is met between 2nd and 4th element.
        Assert.AreEqual(subArrayMaxSum.Count, 2);
        Assert.AreEqual(subArrayMaxSum[0], 2);
        Assert.AreEqual(subArrayMaxSum[1], 4);
    }
}
