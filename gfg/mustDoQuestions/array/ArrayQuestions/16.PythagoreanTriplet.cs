using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/pythagorean-triplet3018/1
Given an array arr of N integers, 
write a function that returns true if there is a triplet (a, b, c) that satisfies a2 + b2 = c2, otherwise false. 

Input: N = 5 Arr[] = {3, 2, 4, 6, 5}
Output: Yes
Explanation: a=3, b=4, and c=5 forms a pythagorean triplet.

Algo:
    1) loop through and make a dictionary entry for all the numbers.
    2) run two loops to find SQRT(a^2 +b^2) and see if its precent in the dictionary.
    3) while finding dictionary , we need to check if its the perfect squareroot, by comparing both int and float squareroot.
*/
public class PythagoreanTriplet
{
    public bool CheckTriplet(int[] arr, int n)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            if (dict.ContainsKey(arr[i]))
            {
                dict[arr[i]] += 1;
            }
            else
            {
                dict.Add(arr[i], 1);
            }
        }

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var sqrtToFindInt = (int)Math.Sqrt((arr[i] * arr[i]) + (arr[j] * arr[j]));
                var sqrtToFinDouble = Math.Sqrt((arr[i] * arr[i]) + (arr[j] * arr[j]));
                if (sqrtToFindInt == sqrtToFinDouble && dict.ContainsKey(sqrtToFindInt))
                {
                    return true;
                }
            }
        }
        return false;
    }
}

[TestClass]
public class TestPythagoreanTriplet
{
    [TestMethod]
    [DataRow(5, "3 2 4 6 5", true)]
    [DataRow(3, "3 8 5", false)]
    public void TestCheckTriplet(int numberOfElements, string elements, bool expectedOutput)
    {
        //Arrange
        var stringArr1 = elements.Split(' ');
        var arr = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr1[i]);
        }

        //Act
        var obj = new PythagoreanTriplet();
        var hasTriplet = obj.CheckTriplet(arr, numberOfElements);

        //Assert
        Assert.AreEqual(expectedOutput, hasTriplet);
    }
}