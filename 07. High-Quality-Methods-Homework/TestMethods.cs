namespace Methods
{
    using System;
    using Methods.Models;

    internal class TestMethods
    {
        private static void Main()
        {
            var triangle = new Triangle(3, 4, 5);
            var triangleArea = triangle.CalcTriangleArea();
            Console.WriteLine(triangleArea);

            Console.WriteLine(NumberCalculationsUtils.NumberToDigit(5));

            Console.WriteLine(NumberCalculationsUtils.FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            NumberCalculationsUtils.PrintAsNumber(1.3, "f");
            NumberCalculationsUtils.PrintAsNumber(0.75, "%");
            NumberCalculationsUtils.PrintAsNumber(2.30, "r");

            var pointOne = new Point(3, -1);
            var pointTwo = new Point(3, 2.5);
            var isHorizontal = Point.IsHorizontalLine(pointOne, pointTwo);
            Console.WriteLine("Horizontal line? " + isHorizontal);
            var isVertical = Point.IsVerticalLine(pointOne, pointTwo);
            Console.WriteLine("Vertical line? " + isVertical);
            var distanceBetweenPoints = Point.CalcDistance(pointOne, pointTwo);
            Console.WriteLine(distanceBetweenPoints);

            var peter = new Student("Peter", "Peter");
            peter.OtherInfo = "From Sofia, born at 17.03.1992";
            var stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}