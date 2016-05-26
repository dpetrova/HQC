namespace GameFifteen
{
    using System;
    using System.Linq;

    public class RotatingWalkInMatrix
    {
        private static readonly Cell[] AllDirections =
            {
                new Cell(1, 1), // top left to bottom right
                new Cell(1, 0), // top to bottom
                new Cell(1, -1), // top right to bottom left
                new Cell(0, -1), // right to left
                new Cell(-1, -1), // bottom right to top left
                new Cell(-1, 0), // bottom to top
                new Cell(-1, 1), // bottom left to top right
                new Cell(0, 1) // left to right
            };

        public static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();

            int size;
            while (!int.TryParse(input, out size) || size < 0 || size > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            var matrix = FillMatrix(size);

            PrintMatrix(matrix);
        }

        public static int[,] FillMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            int value = 1;
            var position = new Cell(0, 0);
            var direction = new Cell(1, 1);

            while (true)
            {
                matrix[position.Row, position.Col] = value;

                if (!PossibleMovement(matrix, position))
                {
                    break;
                }

                while (IsOutOfBoundaries(matrix, position, direction))
                {
                    direction = ChangeDirection(direction);
                }

                position.Row += direction.Row;
                position.Col += direction.Col;
                value++;
            }

            position = GetSmallestFreeCell(matrix);
            value++;

            if (position.Row != 0 && position.Col != 0)
            {
                direction.Row = 1;
                direction.Col = 1;

                while (true)
                {
                    matrix[position.Row, position.Col] = value;

                    if (!PossibleMovement(matrix, position))
                    {
                        break;
                    }

                    if (IsOutOfBoundaries(matrix, position, direction))
                    {
                        while (IsOutOfBoundaries(matrix, position, direction))
                        {
                            direction = ChangeDirection(direction);
                        }
                    }

                    position.Row += direction.Row;
                    position.Col += direction.Col;
                    value++;
                }
            }

            return matrix;
        }

        public static bool IsOutOfBoundaries(int[,] matrix, Cell position, Cell direction)
        {
            return position.Row + direction.Row >= matrix.GetLength(0) ||
                   position.Row + direction.Row < 0 ||
                   position.Col + direction.Col >= matrix.GetLength(1) ||
                   position.Col + direction.Col < 0 ||
                   matrix[position.Row + direction.Row, position.Col + direction.Col] != 0;
        } 

        public static Cell ChangeDirection(Cell current)
        {
            int direction = 0;
            for (int i = 0; i < AllDirections.Length; i++)
            {
                if (AllDirections[i].Row == current.Row && AllDirections[i].Col == current.Col)
                {
                    direction = i;
                    break;
                }
            }

            if (direction == 7)
            {
                current.Row = AllDirections[0].Row;
                current.Col = AllDirections[0].Col;
                return current;
            }

            current.Row = AllDirections[direction + 1].Row;
            current.Col = AllDirections[direction + 1].Col;
            return current;
        }

        public static bool PossibleMovement(int[,] matrix, Cell current)
        {
            Cell[] newDirections =
            {
                new Cell(1, 1),
                new Cell(1, 0),
                new Cell(1, -1),
                new Cell(0, -1),
                new Cell(-1, -1),
                new Cell(-1, 0),
                new Cell(-1, 1),
                new Cell(0, 1)
            };

            foreach (var direction in newDirections)
            {
                if (current.Row + direction.Row >= matrix.GetLength(0) || current.Row + direction.Row < 0)
                {
                    direction.Row = 0;
                }

                if (current.Col + direction.Col >= matrix.GetLength(1) || current.Col + direction.Col < 0)
                {
                    direction.Col = 0;
                }
            }

            return newDirections.Any(direction => matrix[current.Row + direction.Row, current.Col + direction.Col] == 0);
        }

        public static Cell GetSmallestFreeCell(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        return new Cell(i, j);
                    }
                }
            }

            return new Cell(0, 0);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
