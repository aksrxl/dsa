using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/kth-smallest-element5635/1
Given an array arr[] and an integer K where K is smaller than size of array,
the task is to find the Kth smallest element in the given array. It is given that all array elements are distinct.

Input:N = 6 arr[] = 7 10 4 3 20 15 K = 3
Output : 7
Explanation :3rd smallest element in the given array is 7.

Algo:
    Tips : Read about Priority Queue, Medium link: https://medium.com/@dorlugasigal/c-10-priorityqueue-is-here-5067e2628470
    In priority queue, the item with lowest priority is dequeued first.
    priority queue in c# has minimum heap as default implememnation.
    Meaning elements are stored in ascending order of priority (minimum first), 
    so that, the items with least priority can be dequeued first
    This implementation can be changed by providing a different comparer.

    -> It can be solved in NlogN by sorting and returning the [k-1] elements from array.
    -> using priority queue it can be solved in KlogK < NlogN since k<=N , since for priority queue containing k elements 
      we have only k elements to sort.

    1. By default c# priority Queue is min heap, implement a custom comparer 'CustomIntComparer' for max heap.
    2. Run a loop for enqueuing the items if the count is less than k.
    3. if the count is equals to k and the incomin item is less than the top items, means we have a smaller number in k group,
       hence dedque the top element and enqueue the incoming element.
    4. if incoming is greater than the greatest number of queue(remember we have implemented max heap so elements are arranged in descending order.)
    5. return the top element as the kth smallest element , since we are only storing k elements
*/
public class KthSmallestElement
{
    public int FindKthSmallestElement(int[] arr, int n, int k)
    {
        var pq = new PriorityQueue<int, int>(new CustomIntComparer());
        foreach (var item in arr)
        {
            if (pq.Count == k && item < pq.Peek())
            {
                pq.Dequeue();
            }
            if (pq.Count < k)
            {
                pq.Enqueue(item, item);
            }
        }
        return pq.Peek();
    }
}

public class CustomIntComparer : IComparer<int>
{
    // this is for implementing max heap 
    public int Compare(int x, int y)
    {
        return y.CompareTo(x); // default implementation is x.CompareTo(y);
    }
}

[TestClass]
public class TestKthSmallestElement
{
    [TestMethod]
    [DataRow(6, "7 10 4 3 20 15", 3, 7)]
    [DataRow(5, "7 10 4 20 15", 4, 15)]
    public void TestFindKthSmallestElement(int numberOfElements, string elements1, int k, int expectedOutput)
    {
        //Arrange
        var stringArr1 = elements1.Split(' ');
        var arr = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            arr[i] = Convert.ToInt32(stringArr1[i]);
        }

        //Act
        var obj = new KthSmallestElement();
        var maxPlatform = obj.FindKthSmallestElement(arr, numberOfElements, k);

        //Assert
        Assert.AreEqual(expectedOutput, maxPlatform);
    }
}