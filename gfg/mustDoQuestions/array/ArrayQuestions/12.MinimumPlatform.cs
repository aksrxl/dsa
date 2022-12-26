using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/minimum-platforms-1587115620/1
Given arrival and departure times of all trains that reach a railway station. 
Find the minimum number of platforms required for the railway station so that no train is kept waiting.
Consider that all the trains arrive on the same day and leave on the same day. Arrival and departure time 
can never be the same for a train but we can have arrival time of one train equal to departure time of the other. At any given instance of time, same platform can not be used for 
both departure of a train and arrival of another train. In such cases, we need different platforms.

Input: n = 6 
arr[] = {0900, 0940, 0950, 1100, 1500, 1800}
dep[] = {0910, 1200, 1120, 1130, 1900, 2000}
Output: 3
Explanation: 
Minimum 3 platforms are required to safely arrive and depart all trains.

Algo:
Tips: instead of finding the maximum number of platform, find the maximum number of trains 
      at a given point of time.
*/
public class MinimumPlatform
{
    public int FindPlatform(int[] arr, int[] dep, int n)
    {
        var maxTrainAtPointOfTime = 0;
        var maxPlatformRequired = 0;
        Array.Sort(arr);
        Array.Sort(dep);
        var i = 0;
        var j = 0;
        while (i < arr.Length && j < dep.Length)
        {
            if (arr[i] <= dep[j]) // means we have one more train at this point to accomodate
            {
                maxTrainAtPointOfTime++;
                i++;
            }
            else // means a train has departed.
            {
                maxTrainAtPointOfTime--;
                j++;
            }
            // Max because , at some point of time there might be no of platform required more than 
            // the current max train, similarly for this time max number of trains can be more than maxplatform required in past.
            maxPlatformRequired = Math.Max(maxPlatformRequired, maxTrainAtPointOfTime);
        }
        return maxPlatformRequired;
    }
}

[TestClass]
public class TestMinimumPlatform
{
    [TestMethod]
    [DataRow(6, "0900 0940 0950 1100 1500 1800", "0910 1200 1120 1130 1900 2000", 3)]
    [DataRow(3, "0900 1100 1235", "1000 1200 1240", 1)]
    public void TestFindPlatform(int numberOfElements, string elements1, string elements2, int expectedOutput)
    {
        //Arrange
        var stringArr1 = elements1.Split(' ');
        var arr1 = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr1[i] = Convert.ToInt32(stringArr1[i]);
        }

        var stringArr2 = elements2.Split(' ');
        var arr2 = new int[stringArr2.Length];
        for (int i = 0; i < stringArr2.Length; i++)
        {
            arr2[i] = Convert.ToInt32(stringArr2[i]);
        }

        //Act
        var obj = new MinimumPlatform();
        var maxPlatform = obj.FindPlatform(arr1, arr2, numberOfElements);

        //Assert
        Assert.AreEqual(expectedOutput, maxPlatform);
    }
}