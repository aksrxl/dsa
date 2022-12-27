using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayQuestions;

/*
https://practice.geeksforgeeks.org/problems/convert-array-into-zig-zag-fashion1638/1
Given a matrix of size r*c. Traverse the matrix in spiral form.

Input:
r = 4, c = 4
matrix[][] = {
           {1,  2,  3,  4},
           {5,  6,  7,  8},
           {9,  10, 11, 12},
           {13, 14, 15, 16}}
Output: 
1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10

Algo: 
1. have four variable for min and max column/row 
2. keep incrementing/decrementing to control the traversal, keeping in mind the number of elements.
*/
public class SpiralTraversalOfMatrix
{
    public List<int> Traverse(List<List<int>> matrix, int r, int c)
    {
        var twoDArray = new int[r, c];
        var numberOfElements = r * c;
        var list = new List<int>();
        var count = 0;
        for (int x = 0; x < r; x++)
        {
            for (int y = 0; y < c; y++)
            {
                twoDArray[x, y] = (matrix[x])[y];
            }
        }

        var minColumn = 0;
        var minRow = 0;
        var maxColuumn = c - 1;
        var maxRow = r - 1;
        while (count < numberOfElements)
        {
            // going right
            for (int i = minRow, j = minColumn; j <= maxColuumn && count < numberOfElements; j++)
            {
                list.Add(twoDArray[i, j]);
                count++;
            }
            minRow++;

            //going bottom
            for (int i = minRow, j = maxColuumn; i <= maxRow && count < numberOfElements; i++)
            {
                list.Add(twoDArray[i, j]);
                count++;
            }
            maxColuumn--;

            //going left
            for (int i = maxRow, j = maxColuumn; j >= minColumn && count < numberOfElements; j--)
            {
                list.Add(twoDArray[i, j]);
                count++;
            }
            maxRow--;

            //going up
            for (int i = maxRow, j = minColumn; i >= minRow && count < numberOfElements; i--)
            {
                list.Add(twoDArray[i, j]);
                count++;
            }
            minColumn++;
        }
        return list;
    }
}

[TestClass]
public class TestSpiralTraversalOfMatrix
{
    [TestMethod]

    public void TestTraverse()
    {
        //Arrange
        var listOfList = new List<List<int>>();
        listOfList.Add(new List<int> { 1, 2, 3, 4 });
        listOfList.Add(new List<int> { 5, 6, 7, 8 });
        listOfList.Add(new List<int> { 9, 10, 11, 12 });
        listOfList.Add(new List<int> { 13, 14, 15, 16 });
        //Act
        var obj = new SpiralTraversalOfMatrix();
        var list = obj.Traverse(listOfList, 4, 4);

        var outputString = string.Join(' ', list);

        //Assert
        Assert.AreEqual("1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10", outputString);
    }
}