namespace VehiclePark.UI
{
    using System;
    using VehiclePark.Interfaces;

    public class UserInterface : IUserInterface
    {
        public string ReadLine()
        {
            string commandLine = Console.ReadLine();

            return commandLine;
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
