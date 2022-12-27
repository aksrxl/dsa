using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/kth-smallest-element5635/1
Given an array arr[] of N non-negative integers representing the height of blocks. If width of each block is 1,
compute how much water can be trapped between the blocks during the rainy season. 

Input: N = 6 arr[] = {3,0,0,2,0,4}
Output:10
Explaination : See the question for link for pictorial explaination

Algo:
    
*/
public class TrappingRainWater
{
    public long TrappingWater(int[] arr, int n)
    {
        //code here - TODO
        return 1;
    }
}

[TestClass]
public class TestTrappingRainWater
{
    [TestMethod]
    [DataRow(6, "3 0 0 2 0 4", 10)]
    [DataRow(4, "7 4 0 9", 10)]
    [DataRow(4, "6 9 9", 0)]
    public void TestFindKthSmallestElement(int numberOfElements, string elements, int expectedOutput)
    {
        //Arrange
        var stringArr1 = elements.Split(' ');
        var arr = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr1[i]);
        }

        //Act
        var obj = new TrappingRainWater();
        var trappedWater = obj.TrappingWater(arr, numberOfElements);

        //Assert
        Assert.AreEqual(expectedOutput, trappedWater);
    }
}