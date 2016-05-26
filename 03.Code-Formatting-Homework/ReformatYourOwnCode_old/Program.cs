namespace ReformatYourOwnCode_old
{
    using System;

    using ReformatYourOwnCode;

    internal class Program
    {
        private static void Main()
        {
            var pesho = new EmployeeReformatted(12345, 1000.99);
            var greeting = pesho.GetGreeting();
            Console.WriteLine(greeting);
        }
    }
}