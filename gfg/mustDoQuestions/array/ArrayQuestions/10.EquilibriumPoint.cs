using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/equilibrium-point-1587115620/1
Given an array A of n positive numbers. The task is to find the first Equilibrium Point in an array. 
Equilibrium Point in an array is a position such that the sum of elements before it is equal to the sum of elements after it.

Input: n = 5 A[] = {1,3,5,2,2} 
Output: 3 
Explanation: equilibrium point is at position 3 
as elements before it (1+3) = 
elements after it (2+2). 

Algo:
Variation of binary search.
1. take a mid point as equibilirium point.
2. find sum of left and right array from mid point [excluding midpoint];
3. include/exclude element in left/right part depending on left or right sum is greater/lesser.
4. keep shiftin (+/-) the mid point
*/
public class EquilibriumPoint
{
    public int GetPoint(int[] arr, int n)
    {
        if (n == 1)
            return 1;
        var mid = n / 2;
        var leftSum = 0;
        var rightSum = 0;

        for (int i = 0; i < mid; i++)
        {
            leftSum += arr[i];
        }

        for (int i = mid + 1; i < n; i++)
        {
            rightSum += arr[i];
        }



        if (leftSum < rightSum)
        {
            while (leftSum < rightSum && mid < n - 1)
            {
                leftSum += arr[mid];
                rightSum -= arr[mid + 1];
                mid++;
            }
        }
        if (leftSum > rightSum)
        {
            while (leftSum > rightSum && mid > 0)
            {
                leftSum -= arr[mid - 1];
                rightSum += arr[mid];
                mid--;
            }
        }

        if (leftSum == rightSum)
        {
            return mid + 1; // Since 1 based index
        }
        return -1;
    }
}

[TestClass]
public class TestEquilibriumPoint
{
    [TestMethod]
    [DataRow(5, "1 3 5 2 2", 3)]
    [DataRow(1, "1", 1)]
    public void TestGetPoint(int numberOfElements, string elements, int expectedOutput)
    {
        //Arrange
        var stringArr = elements.Split(' ');
        var arr = new int[stringArr.Length];
        for (int i = 0; i < stringArr.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr[i]);
        }

        //Act
        var obj = new EquilibriumPoint();
        var point = obj.GetPoint(arr, numberOfElements);

        //Assert
        Assert.AreEqual(expectedOutput, point);
    }
}