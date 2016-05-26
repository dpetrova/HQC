namespace RotatingMatrix.Tests
{
    using GameFifteen;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OutOfBoundariesUnitTest
    {
        [TestMethod]
        public void GetPositionOutOfMatrixBoundaries_ShouldReturnTrue()
        {
            int[,] matrix = new int[3, 3];

            Cell position = new Cell(2, 2);

            Cell direction = new Cell(1, 1);

            bool isOutOfBoundaries = RotatingWalkInMatrix.IsOutOfBoundaries(matrix, position, direction);

            Assert.IsTrue(isOutOfBoundaries);
        }


        [TestMethod]
        public void GetPositionInMatrixBoundaries_ShouldReturnFalse()
        {
            int[,] matrix = new int[3, 3];

            Cell position = new Cell(2, 2);

            Cell direction = new Cell(-1, -1);

            bool isOutOfBoundaries = RotatingWalkInMatrix.IsOutOfBoundaries(matrix, position, direction);

            Assert.IsFalse(isOutOfBoundaries);
        }
    }
}
