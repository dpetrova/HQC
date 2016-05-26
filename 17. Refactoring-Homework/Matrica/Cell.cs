namespace GameFifteen
{
    using System;

    public class Cell : IEquatable<Cell>
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool Equals(Cell other)
        {
            return this.Row == other.Row && this.Col == other.Col;
        }
    }
}
