using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/convert-array-into-zig-zag-fashion1638/1
Given an array arr of distinct elements of size N, the task is to rearrange the elements of the array in a zig-zag
 fashion so that the converted array should be in the below form: 

arr[0] < arr[1]  > arr[2] < arr[3] > arr[4] < . . . . arr[n-2] < arr[n-1] > arr[n]. 

Input:N = 7
Arr[] = {4, 3, 7, 8, 6, 2, 1}
Output: 3 7 4 8 2 6 1
Explanation: 3 < 7 > 4 < 8 > 2 < 6 > 1

Algo: 
1. loop though elements and check for operator.
2. if the numbers are not as per operator , make a switch.
3. at the end of every loop switch the operator.
*/
public class ArrayZigZag
{
    public void Convert(int[] arr, int n)
    {
        bool isLessThanOperator = true;
        for (int i = 0; i < n - 1; i++)
        {
            if (isLessThanOperator && arr[i] > arr[i + 1])
            {//swap
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }

            else if (!isLessThanOperator && arr[i] < arr[i + 1])
            {
                //swap
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
            isLessThanOperator = !isLessThanOperator;
        }
    }
}

[TestClass]
public class TestArrayZigZag
{
    [TestMethod]
    [DataRow(7, "4 3 7 8 6 2 1", "3 7 4 8 2 6 1")]
    [DataRow(4, "1 4 3 2", "1 4 2 3")]

    public void TestConvert(int numberOfElements, string elements, string expectedOutput)
    {
        //Arrange
        var stringArr1 = elements.Split(' ');
        var arr = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr1[i]);
        }

        //Act
        var obj = new ArrayZigZag();
        obj.Convert(arr, numberOfElements);

        var outputString = string.Join(' ', arr);

        //Assert
        Assert.AreEqual(expectedOutput, outputString);
    }
}