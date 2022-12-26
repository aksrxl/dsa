using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/missing-number-in-array1416/1
Given two arrays X and Y of positive integers, find the number of pairs such that xy > yx (raised to power of)
 where x is an element from X and y is an element from Y.

Input: 
M = 3, X[] = [2 1 6] 
N = 2, Y[] = [1 5]
Output: 3
Explanation: 
The pairs which follow xy > yx are 
as such: 21 > 12,  25 > 52 and 61 > 16 .

Algo:
*/
public class NumberOfPairs
{
    public long CountPairs(int[] X, int[] Y, int n, int m)
    {
        //code here
        return 1;
    }
}

[TestClass]
public class TestNumberOfPairs
{
    [TestMethod]
    public void TestCountPairs()
    {
        //TODO
    }
}