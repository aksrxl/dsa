using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/leaders-in-an-array-1587115620/1
Given an array A of positive integers. Your task is to find the leaders in the array. An element of array is leader 
if it is greater than or equal to all the elements to its right side. The rightmost element is always a leader.

Input: n = 6 A[] = {16,17,4,3,5,2}
Output: 17 5 2
Explanation: The first leader is 17 as it is greater than all the elements
to its right.  Similarly, the next leader is 5. The right most element 
is always a leader so it is also included. 

Algo:
1. loop from end marking end as the greatest.
2. compare for next greater and push to stack.
3. convert stack to array and output.
*/
public class LeaderInArray
{
    public int[] Leaders(int[] arr, int N)
    {
        var stack = new Stack<int>();
        stack.Push(arr[N - 1]);
        var maxSoFar = arr[N - 1];
        for (int i = N - 2; i >= 0; i--)
        {
            if (arr[i] >= maxSoFar)
            {
                maxSoFar = arr[i];
                stack.Push(arr[i]);
            }
        }
        return stack.ToArray();
    }
}

[TestClass]
public class TestLeaderInArray
{
    [TestMethod]
    [DataRow(6, "16 17 4 3 5 2", "17 5 2")]
    [DataRow(5, "1 2 3 4 0", "4 0")]
    public void TestLeaders(int numberOfElements, string elements, string expectedOutput)
    {
        //Arrange
        var stringArr = elements.Split(' ');
        var arr = new int[stringArr.Length];
        for (int i = 0; i < stringArr.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr[i]);
        }

        //Act
        var obj = new LeaderInArray();
        var leaders = obj.Leaders(arr, numberOfElements);
        var outputString = string.Join(' ', leaders);

        //Assert
        Assert.AreEqual(expectedOutput, outputString);
    }
}