using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/kadanes-algorithm-1587115620/1
Given an array Arr[] of N integers. Find the contiguous sub-array(containing at least one number)
which has the maximum sum and return its sum.
N = 5 Arr[] = {1,2,3,-2,5}
Output: 9
Explanation: Max subarray sum is 9 of elements (1, 2, 3, -2, 5) which is a contiguous subarray.

Algo: Kadane's algorithm
1. assing maxsofar as least possible value , for this case it is long min value i.e -9223372036854775808
2. keep adding number in loop in current sum.
3. keep checking and updating maxsumso far if currentSum is greater than maxSumSo far.
4. return maxSum so far
Note: at any moment if the sum goes below 0 , assign currentSum to zero 
      coz , its already < 0  and the sum is only decreasing the sum, so
      there are chances of getting greater sum after that point.
*/
public class KadaneAlgorithm
{
    public long MaxSubArraySum(int[] arr, int n)
    {
        var maxSoFar = long.MinValue;
        var currentSum = 0;
        for (int i = 0; i < n; i++)
        {
            currentSum += arr[i];
            if (currentSum > maxSoFar)
            {
                maxSoFar = currentSum;
            }

            if (currentSum < 0)
            {
                currentSum = 0;
            }
        }
        return maxSoFar;
    }
}

[TestClass]
public class TestKadaneAlgorithm
{
    [TestMethod]
    [DataRow(5, "1 2 3 -2 5", 9)] // 1+2+3+(-1)+5 = 9
    [DataRow(4, "-1 -2 -3 -4", -1)] // -1 since thats the greatest

    public void TestSubArrayMaxSumValid1(int numberOfElements, string elements, int expectedOutput)
    {
        //Arrange
        var stringArr = elements.Split(' ');
        var arr = new int[numberOfElements];
        for (int i = 0; i < numberOfElements; i++)
        {
            arr[i] = Convert.ToInt32(stringArr[i]);
        }

        //Act
        var obj = new KadaneAlgorithm();
        var count = obj.MaxSubArraySum(arr, numberOfElements);

        //Act
        Assert.AreEqual(expectedOutput, count);
    }
}