namespace MatrixMultiplicator
{
    using System;

    class MatrixMultiplicator
    {
        static void Main()
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var dotProduct = MultiplyMatrices(firstMatrix, secondMatrix);

            for (int row = 0; row < dotProduct.GetLength(0); row++)
            {
                for (int col = 0; col < dotProduct.GetLength(1); col++)
                {
                    Console.Write(dotProduct[row, col] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[,] MultiplyMatrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var numberOfColumns = firstMatrix.GetLength(1);

            var dotProduct = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

            for (int row = 0; row < dotProduct.GetLength(0); row++)
            {
                for (int col = 0; col < dotProduct.GetLength(1); col++)
                {
                    for (int inner = 0; inner < numberOfColumns; inner++)
                    {
                        dotProduct[row, col] += firstMatrix[row, inner] * secondMatrix[inner, col];
                    }
                }
            }
            
            return dotProduct;
        }
    }
}