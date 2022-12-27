using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/last-index-of-15847/1
Given a string S consisting only '0's and '1's,  find the last index of the '1' present in it.

Input: S = 00001
Output: 4

Algo: 

*/
public class LastIndexOf1
{
    public int FindIndex(string s)
    {
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '1')
            {
                return i;
            }
        }
        return -1;
    }
}

[TestClass]
public class TestLastIndexOf1
{
    [TestMethod]
    [DataRow("001010101000000", 8)]
    [DataRow("00001", 4)]
    public void TestFindIndex(string input, int expectedOutput)
    {
        //Act
        var obj = new LastIndexOf1();
        var index = obj.FindIndex(input);

        //Assert
        Assert.AreEqual(expectedOutput, index);
    }
}