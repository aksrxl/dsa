using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/sort-an-array-of-0s-1s-and-2s4231/1
Given an array of size N containing only 0s, 1s, and 2s; sort the array in ascending order.

Input: N = 5
arr[]= {0 2 1 2 0}
Output: 0 0 1 2 2

Algo:
1. Loop through and have a count of number of occurrence of 0,1,2
2. loop again and update array with 0s,1s and 2s
*/
public class SortArrayOf0And1
{
    public void Sort(int[] arr, long n)
    {
        var dict = new Dictionary<int, int>(){
            {0,0},
            {1,0},
            {2,0}
        };

        for (int i = 0; i < n; i++)
        {
            if (arr[i] == 0)
            {
                dict[0]++;
            }
            else if (arr[i] == 1)
            {
                dict[1]++;
            }
            else if (arr[i] == 2)
            {
                dict[2]++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (dict.ContainsKey(0) && dict[0] > 0)
            {
                arr[i] = 0;
                dict[0]--;
            }
            else if (dict.ContainsKey(1) && dict[1] > 0)
            {
                arr[i] = 1;
                dict[1]--;
            }
            else if (dict.ContainsKey(2) && dict[2] > 0)
            {
                arr[i] = 2;
                dict[2]--;
            }
        }
    }
}

[TestClass]
public class TestSortArrayOf0And1
{
    [TestMethod]
    [DataRow(5, "0 2 1 2 0", "0 0 1 2 2")]
    [DataRow(3, "0 1 0", "0 0 1")]
    public void TestSort(int numberOfElements, string elements, string expectedOutput)
    {
        //Arrange
        var stringArr = elements.Split(' ');
        var arr = new int[stringArr.Length];
        for (int i = 0; i < stringArr.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr[i]);
        }

        //Act
        var obj = new SortArrayOf0And1();
        obj.Sort(arr, numberOfElements);

        //Assert
        var outputString = string.Join(' ', arr);
        Assert.AreEqual(expectedOutput, outputString);
    }
}