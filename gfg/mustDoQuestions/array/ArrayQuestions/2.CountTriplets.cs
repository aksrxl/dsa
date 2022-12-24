using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;
/*
https://practice.geeksforgeeks.org/problems/count-the-triplets4615/1
Given an array of distinct integers. 
The task is to count all the triplets such that sum of two elements equals the third element.

  Algo
1. sort the array
2. loop from n-1 to 2
3. keep two pointers left starting from 0 , and right starting from i-1
4. keep checking for sum of l+r, till left and right are not colliding
5. if equals increment the count
6. if less, increment the left
7. if greater, decrement the right
*/
public class CountTriplets
{
    public int GetCount(int[] arr, int n)
    {
        var count = 0;
        Array.Sort(arr);
        for (int i = n - 1; i >= 2; i--)
        {
            var left = 0;
            var right = i - 1;
            while (left < right)
            {
                var sum = arr[left] + arr[right];
                if (sum == arr[i])
                {
                    count++;
                    left++;
                    right--;
                }
                else if (sum < arr[i])
                    left++;
                else
                    right--;
            }
        }
        return count;
    }
}

[TestClass]
public class TestCountTriplets
{
    [TestMethod]
    [DataRow(4, "1 5 3 2", 2)] // 1+2=3, 3+2=5
    [DataRow(5, "1 2 3 4 5 ", 4)] // 1+2=3, 1+3=4, 1+4=5, 2+3=5 

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
        var obj = new CountTriplets();
        var count = obj.GetCount(arr, numberOfElements);

        //Act
        Assert.AreEqual(expectedOutput, count);
    }
}