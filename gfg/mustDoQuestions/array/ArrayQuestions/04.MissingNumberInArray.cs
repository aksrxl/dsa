using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/missing-number-in-array1416/1
Given an array of size N-1 such that it only contains distinct integers in the range of 1 to N.
Find the missing element.

N = 5
A[] = {1,2,3,5}
Output: 4

Algo: Xor properties
 Commutative => x^y = y^x ; 
 Associative => x^(y^z) = (x^y)^z;
 Identity element = > x^0 = x
 Self-inverse => x^x = 0

    1. prepare an array for n elements , with elements eg {1,2,3,4,5, ....n}
    2. Xor all the elements.
    3. xor all the elements of input array.
    4. xor both the array , since x^x = 0 , all the repeting numbers cancel out each other, leaving behind the missing number.

*/
public class MissingNumberInArray
{
    public int MissingNumber(int[] arr, int n)
    {
        var xorResult = 0; // since o^x = 0;
                           // till n-1 to prevent array out of bound , since array has one less element
                           // the missing nth element is xored at line 36 
        for (int i = 0; i < n - 1; i++)
        {
            //(xor of array) ^(the number array element)
            xorResult = (arr[i] ^ xorResult) ^ (i + 1);
        }
        return xorResult ^ n; //xor with the missing last element , since it was not included in the loop
    }
}

[TestClass]
public class TestMissingNumberInArray
{
    [TestMethod]
    [DataRow(5, "1 2 3 5", 4)]
    [DataRow(10, "6 1 2 8 3 4 7 10 5", 9)]
    public void TestMissingNumber(int numberOfElements, string elements, int expectedOutput)
    {
        //Arrange
        var stringArr = elements.Split(' ');
        var arr = new int[stringArr.Length];
        for (int i = 0; i < stringArr.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr[i]);
        }

        //Act
        var obj = new MissingNumberInArray();
        var count = obj.MissingNumber(arr, numberOfElements);

        //Act
        Assert.AreEqual(expectedOutput, count);
    }
}