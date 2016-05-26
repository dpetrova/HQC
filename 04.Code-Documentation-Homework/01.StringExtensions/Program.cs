namespace _01.StringExtensions
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var inputString = "123";
            var toMd5Hash = inputString.ToMd5Hash();
            Console.WriteLine(toMd5Hash);

            var toShort = inputString.ToShort();
            Console.WriteLine(toShort);

            var str = "myurukhai";
            var output = str.GetStringBetween("ur", "hai");
            Console.WriteLine(output);

            var cyrillic = "урукхаи";
            var latin = cyrillic.ConvertCyrillicToLatinLetters();
            Console.WriteLine(latin);
        }
    }
}