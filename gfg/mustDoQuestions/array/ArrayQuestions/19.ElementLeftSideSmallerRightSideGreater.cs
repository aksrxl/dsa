using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/unsorted-array4925/1
Given an unsorted array of size N. Find the first element in array such that all of its 
left elements are smaller and all right elements to it are greater than it.


Input:N = 4 A[] = {4, 2, 5, 7}
Output: 5
Explanation: Elements on left of 5 are smaller than 5 and on right of it are greater than 5.

Algo: for 4 , 2 , 5, 7
Tips: Look for the element which is greater than the greatest element towards right 
      and lesser then the least element on the right
Prepare minimum array :-> loop from end and prepare min array such that it has the minimum element as encountered travelling from the right
Prepare maximum array :-> loop from start and prepare max array such that it has the maxmimu element as encountered travelling from the left.

array    : 4 2 5 7
max array: 2 2 5 7  <- travelling from right update the array with min
min array: 4 4 5 7  -> travelling from left update the array with max.

look for element arr[i] in array such that max[i-1]<arr[i]<min[i+1] 

*/
public class ElementLeftSideSmallerRightSideGreater
{
    public int FindElement(int[] arr, int n)
    {
        var minArray = new int[n];
        var maxArray = new int[n];

        var max = arr[0];
        var min = arr[n - 1];
        minArray[n - 1] = min;
        maxArray[0] = max;

        //maxArray
        for (int i = 1; i < n; i++)
        {
            if (arr[i] >= max)
            {
                maxArray[i] = arr[i];
                max = arr[i];
            }
            else
            {
                maxArray[i] = max;
            }
        }

        //minArray
        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] <= min)
            {
                minArray[i] = arr[i];
                min = arr[i];
            }
            else
            {
                minArray[i] = min;
            }
        }

        for (int i = 1; i < n - 1; i++)
        {
            if (maxArray[i - 1] <= arr[i] && arr[i] <= minArray[i + 1])
            {
                return arr[i];
            }
        }
        return -1;
    }
}

[TestClass]
public class TestElementLeftSideSmallerRightSideGreater
{
    [TestMethod]
    [DataRow(4, "4 2 5 7", 5)]
    [DataRow(3, "11 9 12", -1)]

    public void TestFindElement(int numberOfElements, string elements, int expectedOutput)
    {
        //Arrange
        var stringArr1 = elements.Split(' ');
        var arr = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr1[i]);
        }

        //Act
        var obj = new ElementLeftSideSmallerRightSideGreater();
        var element = obj.FindElement(arr, numberOfElements);

        //Assert
        Assert.AreEqual(expectedOutput, element);
    }
}