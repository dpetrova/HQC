namespace Methods.Models
{
    using System;

    internal class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        internal static bool IsHorizontalLine(Point first, Point second)
        {
            return first.Y.CompareTo(second.Y) == 0;
        }

        internal static bool IsVerticalLine(Point first, Point second)
        {
            return first.X.CompareTo(second.X) == 0;
        }

        internal static double CalcDistance(Point first, Point second)
        {
            var distance =
                Math.Sqrt(((second.X - first.X) * (second.X - first.X)) + ((second.Y - first.Y) * (second.Y - first.Y)));
            return distance;
        }
    }
}