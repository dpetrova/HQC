namespace RotatingMatrix.Tests
{
    using GameFifteen;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PossibleMovementUnitTest
    {
        [TestMethod]
        public void PossibleMovement_WithEmptyCells_ShouldReturnTrue()
        {
            int[,] matrix = 
            {
                { 1, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 3 }
            };

            Cell current = new Cell(2, 2);

            bool possibleMovement = RotatingWalkInMatrix.PossibleMovement(matrix, current);

            Assert.IsTrue(possibleMovement);
        }


        [TestMethod]
        public void PossibleMovement_WithNoEmptyCells_ShouldReturnFalse()
        {
            int[,] matrix = 
            {
                { 1, 7, 8 },
                { 6, 2, 9 },
                { 5, 4, 3 }
            };

            Cell current = new Cell(1, 2);

            bool possibleMovement = RotatingWalkInMatrix.PossibleMovement(matrix, current);

            Assert.IsFalse(possibleMovement);
        }

    }
}
