using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/stock-buy-and-sell-1587115621/1
The cost of stock on each day is given in an array A[] of size N. Find all the segments of days on which you buy and sell
 the stock so that in between those days your profit is maximum.

Input: N = 7 A[] = {100,180,260,310,40,535,695}
Output:1
Explanation: One possible solution is (0 3) (4 6) We can buy stock on day 0,
and sell it on 3rd day, which will give us maximum profit. Now, we buy 
stock on day 4 and sell it on day 6.

Algo:
Tips: This needs visualization the form of a graph.
    -> whenever there is a dip, meaning previous day value and day after value is greater , its a dip means buying zone
    -> whenever there is a peak, meaning prevoius day value and day after value is lesser, its a pick , selling zone.

*/
public class StockBuyAndSell
{
    public List<List<int>> FindBuySellList(int[] arr, int n)
    {
        var listOfList = new List<List<int>>();

        var buyingPoint = -1;
        var sellingPoint = -1;
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                if (arr[i] < arr[i + 1]) // check only for value a day after if it is a pick , buy
                {
                    buyingPoint = i;
                }
            }

            else if (i == n - 1) // check only for value a day before it it was a dip sale
            {
                if (arr[i] >= arr[i - 1] && buyingPoint != -1)
                {
                    listOfList.Add(new List<int> { buyingPoint, i });
                    buyingPoint = -1;
                    sellingPoint = -1;
                }
            }
            // for mid value check for plateue as well , since it can be sold if plateau occurs, so that we can buy on the next plateue value
            else if (arr[i] > arr[i - 1] && arr[i] >= arr[i + 1] && buyingPoint != -1)
            {
                listOfList.Add(new List<int> { buyingPoint, i });
                buyingPoint = -1;
                sellingPoint = -1;
            }
            // this is the plateau value we are buying at
            else if (arr[i] <= arr[i - 1] && arr[i] < arr[i + 1])
            {
                buyingPoint = i;
            }
        }
        return listOfList;
    }
}

[TestClass]
public class TestStockBuyAndSell
{
    [TestMethod]
    [DataRow(7, "100 180 260 310 40 535 695", 2)]
    [DataRow(9, "57 69 12 59 5 9 29 29 99", 4)]
    [DataRow(5, "4 2 2 2 4", 1)]

    public void TestFindBuySellList(int numberOfElements, string elements, int numberOfBuySellcombinations)
    {
        //Arrange
        var stringArr1 = elements.Split(' ');
        var arr = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr1[i]);
        }

        //Act
        var obj = new StockBuyAndSell();
        var buySelList = obj.FindBuySellList(arr, numberOfElements);

        //Assert
        Assert.AreEqual(numberOfBuySellcombinations, buySelList.Count);
    }
}