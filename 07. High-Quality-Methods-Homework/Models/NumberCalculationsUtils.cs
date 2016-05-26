namespace Methods.Models
{
    using System;

    internal class NumberCalculationsUtils
    {
        internal static void PrintAsNumber(double number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    Console.WriteLine("Invalid print format");
                    break;
            }
        }

        internal static int FindMaxNumber(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException("The array is not initialized.");
            }

            var maxNumber = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                int numberToCompare = numbers[i];

                if (maxNumber < numberToCompare)
                {
                    maxNumber = numberToCompare;
                }
            }

            return maxNumber;
        }

        internal static string NumberToDigit(int number)
        {
            string numberAsDigit;
            switch (number)
            {
                case 0:
                    numberAsDigit = "zero";
                    break;
                case 1:
                    numberAsDigit = "one";
                    break;
                case 2:
                    numberAsDigit = "two";
                    break;
                case 3:
                    numberAsDigit = "three";
                    break;
                case 4:
                    numberAsDigit = "four";
                    break;
                case 5:
                    numberAsDigit = "five";
                    break;
                case 6:
                    numberAsDigit = "six";
                    break;
                case 7:
                    numberAsDigit = "seven";
                    break;
                case 8:
                    numberAsDigit = "eight";
                    break;
                case 9:
                    numberAsDigit = "nine";
                    break;
                default:
                    numberAsDigit = "Invalid positive integer number!";
                    break;
            }

            return numberAsDigit;
        }
    }
}
