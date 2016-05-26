namespace RotatingMatrix.Tests
{
    using GameFifteen;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FillMatrixUnitTest
    {
        [TestMethod]
        public void FillMatrixOfSizeOne_ShouldFillMatrixCorrectly()
        {
            int[,] matrix = RotatingWalkInMatrix.FillMatrix(1);

            int[,] expected = 
            {
                { 1 }
            };

            CollectionAssert.AreEqual(expected, matrix);
        }

        [TestMethod]
        public void FillMatrixOfSizeThree_ShouldFillMatrixCorrectly()
        {
            int[,] matrix = RotatingWalkInMatrix.FillMatrix(3);

            int[,] expected = 
            {
                { 1, 7, 8 },
                { 6, 2, 9 },
                { 5, 4, 3 }
            };

            CollectionAssert.AreEqual(expected, matrix);
        }

        [TestMethod]
        public void FillMatrixOfSizeSix_ShouldFillMatrixCorrectly()
        {
            int[,] matrix = RotatingWalkInMatrix.FillMatrix(6);

            int[,] expected = 
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            CollectionAssert.AreEqual(expected, matrix);
        }
    }
}
