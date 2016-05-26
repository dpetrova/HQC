using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    using Models;

    public class Minesweeper
    {
        private static void Main()
        {
            const int maxNumberOfMines = 35;
            
            string command = string.Empty;
            char[,] board = CreateBoard();
            char[,] mines = SetMines();
            int counter = 0;
            bool isSweeped = false;
            var players = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool isPlaying = true;
            bool isWon = false;

            do
            {
                if (isPlaying)
                {
                    Console.WriteLine(
                        "Lets play Minesweeper. Find the empty squares while avoiding the mines. The faster you clear the board, the better your score."
                        + " Command 'top' shows score, 'restart' load a new game, 'exit' exits the application!");
                    PrintBoard(board);
                    isPlaying = false;
                }

                Console.Write("Write row and col separated by comma : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRating(players);
                        break;
                    case "restart":
                        board = CreateBoard();
                        mines = SetMines();
                        PrintBoard(board);
                        isSweeped = false;
                        isPlaying = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                CreateNextGameStage(board, mines, row, col);
                                counter++;
                            }

                            if (maxNumberOfMines == counter)
                            {
                                isWon = true;
                            }
                            else
                            {
                                PrintBoard(board);
                            }
                        }
                        else
                        {
                            isSweeped = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (isSweeped)
                {
                    PrintBoard(mines);
                    Console.Write("\nYou died! You score {0}. " + "Enter your name: ", counter);
                    string name = Console.ReadLine();
                    Player player = new Player(name, counter);

                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Score < player.Score)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    players.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Score.CompareTo(firstPlayer.Score));

                    PrintRating(players);

                    board = CreateBoard();
                    mines = SetMines();
                    counter = 0;
                    isSweeped = false;
                    isPlaying = true;
                }

                if (isWon)
                {
                    Console.WriteLine("\nCongratulations! You won the game!");
                    PrintBoard(mines);

                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();

                    Player player = new Player(name, counter);
                    players.Add(player);
                    PrintRating(players);
                    board = CreateBoard();
                    mines = SetMines();
                    counter = 0;
                    isWon = false;
                    isPlaying = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }


        private static void PrintRating(List<Player> rating)
        {
            Console.WriteLine("\nRating:");
            if (rating.Count > 0)
            {
                for (int i = 0; i < rating.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, rating[i].Name, rating[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rating!\n");
            }
        }


        private static void CreateNextGameStage(char[,] board, char[,] mines, int row, int col)
        {
            char numberOfMines = CalculateNeighbourMines(mines, row, col);
            mines[row, col] = numberOfMines;
            board[row, col] = numberOfMines;
        }


        private static void PrintBoard(char[,] board)
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < width; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < height; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }


        private static char[,] CreateBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }


        private static char[,] SetMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!mines.Contains(randomNumber))
                {
                    mines.Add(randomNumber);
                }
            }

            foreach (int mine in mines)
            {
                int currentCol = mine / cols;
                int currentRow = mine % cols;
                if (currentRow == 0 && mine != 0)
                {
                    currentCol--;
                    currentRow = cols;
                }
                else
                {
                    currentRow++;
                }

                board[currentCol, currentRow - 1] = '*';
            }

            return board;
        }


        private static void SetNeighbourCells(char[,] board)
        {
            int col = board.GetLength(0);
            int row = board.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char cellSymbol = CalculateNeighbourMines(board, i, j);
                        board[i, j] = cellSymbol;
                    }
                }
            }
        }


        private static char CalculateNeighbourMines(char[,] board, int row, int col)
        {
            int numberOfMines = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    numberOfMines++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, col] == '*')
                {
                    numberOfMines++;
                }
            }

            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if (col + 1 < cols)
            {
                if (board[row, col + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            return char.Parse(numberOfMines.ToString());
        }
    }
}