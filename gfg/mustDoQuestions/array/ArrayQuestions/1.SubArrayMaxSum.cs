using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;
/*
https://practice.geeksforgeeks.org/problems/subarray-with-given-sum-1587115621/1
Given an unsorted array A of size N that contains only non-negative integers, 
find a continuous sub-array which adds 
to a given number S and return the left and right index(1-based indexing) of that subarray.
*/


public class SubArrayMaxSum
{
    /* Algo
     : 1. loop from index 1 till n.
       2. keep a track of the starting point from where you are adding to get sum.
       3. keep a check if temp sum has exceeded the required sum.
       4. keep subtracting the left most element from sum and incrementing the starting element , 
          until the sum is greater than required sum. 
       5. check if the sum is equal to required sum.
    */
    public List<int> SubArraySum(int[] arr, int n, int requiredSum)
    {
        var currentSum = arr[0];
        var startingPoint = 0;

        // till i<=n; equals to because we are incrementing the sum post check. 
        // so we want to check for the last number as well.
        // but we do not want to increment the sum of nth index coz it will be out of bound.
        //thats why the check at line 33 
        for (int i = 1; i <= n; i++)
        {
            while (currentSum > requiredSum && startingPoint < i - 1)
            {
                currentSum = currentSum - arr[startingPoint];
                startingPoint++;
            }

            if (currentSum == requiredSum)
                return new List<int> { startingPoint + 1, i };

            if (i < n) // this will prevent outofbound exception for loop since we are running loop till n 
                currentSum = currentSum + arr[i];
        }
        return new List<int> { -1 };
    }
}
//----------------------------------------------------
[TestClass]
public class TestSubArrayMaxSum
{
    [TestMethod]
    [DataRow(1, 5, 12, "1 2 3 7 5")]
    [DataRow(2, 42, 468, "135 101 170 125 79 159 163 65 106 146 82 28 162 92 196 143 28 37 192 5 103 154 93 183 22 117 119 96 48 127 172 139 70 113 68 100 36 95 104 12 123 134")]
    public void TestSubArrayMaxSumValid1(int caseNumber, int numberOfElements, int requiredSum, string elements)
    {
        //Arrange
        var stringArr = elements.Split(' ');
        var arr = new int[numberOfElements];
        for (int i = 0; i < numberOfElements; i++)
        {
            arr[i] = Convert.ToInt32(stringArr[i]);
        }

        //Act
        var obj = new SubArrayMaxSum();
        var subArrayMaxSum = obj.SubArraySum(arr, numberOfElements, requiredSum);

        //Act

        switch (caseNumber)
        {
            case 1:
                {
                    Assert.AreEqual(2, subArrayMaxSum.Count);
                    Assert.AreEqual(2, subArrayMaxSum[0]);
                    Assert.AreEqual(4, subArrayMaxSum[1]);
                    break;
                }
            case 2:
                {
                    Assert.AreEqual(2, subArrayMaxSum.Count);
                    Assert.AreEqual(38, subArrayMaxSum[0]);
                    Assert.AreEqual(42, subArrayMaxSum[1]);
                    break;
                }
        }
    }
}
