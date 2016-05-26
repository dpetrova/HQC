namespace RotatingMatrix.Tests
{
    using GameFifteen;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetSmallestFreeCellUnitTest
    {
        [TestMethod]
        public void GetSmallestFreeCell_WhenNoMoreEmptyCellsInAllDirections_ShouldGetCellCorrectly()
        {
            int[,] matrix = 
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 0, 3, 26, 30, 22 },
                { 13, 0, 0, 4, 25, 23 },
                { 12, 0, 0, 0, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            Cell smallestFreeCell = RotatingWalkInMatrix.GetSmallestFreeCell(matrix);

            Cell expected = new Cell(2, 1);

            //Assert.AreEqual(expected, smallestFreeCell);
            Assert.AreEqual(expected.Row, smallestFreeCell.Row);
            Assert.AreEqual(expected.Col, smallestFreeCell.Col);
        }
    }
}
