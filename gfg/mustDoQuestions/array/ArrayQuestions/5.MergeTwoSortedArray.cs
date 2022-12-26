using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/merge-two-sorted-arrays-1587115620/1
Given an array of size N-1 such that it only contains distinct integers in the range of 1 to N.
Find the missing element.

n = 4, arr1[] = [1 3 5 7] 
m = 5, arr2[] = [0 2 6 8 9]
Output: arr1[] = [0 1 2 3] arr2[] = [5 6 7 8 9]
Explanation:
After merging the two non-decreasing arrays, we get, 0 1 2 3 5 6 7 8 9.

Algo:
1. take an array of length a+b
2. take three pointers for each a, b and final array.
3. compare a and b for smaller value and increment counter accordingly.
4. one of the element would have exhausted , fill the remaining elements in final array
   with the elements of array whose counter has not exhausted.
5. move back the element from final to the individual array.
*/
public class MergeTwoSortedArray
{
    public void Merge(int[] a, int[] b, int s, int t)
    {
        var arr = new int[s + t];
        int i = 0;
        int j = 0;
        int k = 0;

        // filling in arr in a sorted way
        while (i < s && j < t)
        {
            if (a[i] < b[j])
            {
                arr[k] = a[i];
                i++;
                k++;
            }
            else
            {
                arr[k] = b[j];
                k++;
                j++;
            }
        }
        // incase a has pending items
        while (i < s)
        {
            arr[k] = a[i];
            i++;
            k++;
        }
        //incase b has pending items
        while (j < t)
        {
            arr[k] = b[j];
            j++;
            k++;
        }

        for (int x = 0; x < s; x++)
        {
            a[x] = arr[x];
        }
        // chances of making mistake for below loop
        for (int y = s; y < arr.Length; y++)
        {
            b[y - s] = arr[y];
        }
    }

    public void MergeWithoutExtraSpace(int[] a, int[] b, int s, int t)
    {
        //TODO
    }
}

[TestClass]
public class TestMergeTwoSortedArray
{
    [TestMethod]
    [DataRow(2, "10 12", 3, "5 18 20", "5 10 12 18 20")]
    [DataRow(4, "1 3 5 7", 5, "0 2 6 8 9", "0 1 2 3 5 6 7 8 9")]
    public void TestMerge(int s, string sElements, int t, string tElements, string expectedOutputString)
    {
        //Arrange
        var stringArr1 = sElements.Split(' ');
        var a = new int[stringArr1.Length];
        for (int i = 0; i < stringArr1.Length; i++)
        {
            a[i] = Convert.ToInt32(stringArr1[i]);
        }

        var stringArr2 = tElements.Split(' ');
        var b = new int[stringArr2.Length];
        for (int i = 0; i < stringArr2.Length; i++)
        {
            b[i] = Convert.ToInt32(stringArr2[i]);
        }

        //Act
        var obj = new MergeTwoSortedArray();
        obj.Merge(a, b, s, t);

        //Assert
        var outputstring = string.Join(' ', a, b);
        Assert.AreEqual(expectedOutputString, outputstring);
    }
}