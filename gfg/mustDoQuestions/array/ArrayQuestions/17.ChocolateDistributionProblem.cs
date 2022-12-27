using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/chocolate-distribution-problem3825/1
Given an array A[ ] of positive integers of size N, where each value represents the number of chocolates in a packet.
Each packet can have a variable number of chocolates. There are M students, 
the task is to distribute chocolate packets among M students such that :
1. Each student gets exactly one packet.
2. The difference between maximum number of chocolates given to a student and minimum number of chocolates given to a student is minimum.

Input: N = 8, M = 5 A = {3, 4, 1, 9, 56, 7, 9, 12}
Output: 6
Explanation: The minimum difference between maximum chocolates and minimum chocolates 
is 9 - 3 = 6 by choosing following M packets :{3, 4, 9, 7, 9}.

Algo:
    1. sort the array
    2. find the difference in end elements in a group of M elements
    3. keep track of the min difference so far.
    4. return min difference.
*/
public class ChocolateDistributionProblem
{
    public long FindMinDiff(int[] arr, int n, long m)
    {
        Array.Sort(arr);
        var minDiff = long.MaxValue;
        for (int i = 0; i <= n - m; i++)
        {
            var diff = arr[i + m - 1] - arr[i];
            if (diff < minDiff)
            {
                minDiff = diff;
            }
        }
        return minDiff;
    }
}

[TestClass]
public class TestChocolateDistributionProblem
{
    [TestMethod]
    [DataRow(8, "3 4 1 9 56 7 9 12", 5, 6)]
    [DataRow(7, "7 3 2 4 9 12 56", 3, 2)]

    public void TestFindMinDiff(int numberOfElements, string elements, int m, long expectedOutput)
    {
        //Arrange
        var stringArr1 = elements.Split(' ');
        var arr = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr1[i]);
        }

        //Act
        var obj = new ChocolateDistributionProblem();
        var minDiff = obj.FindMinDiff(arr, numberOfElements, m);

        //Assert
        Assert.AreEqual(expectedOutput, minDiff);
    }
}