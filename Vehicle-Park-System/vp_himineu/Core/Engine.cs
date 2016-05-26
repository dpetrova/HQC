namespace VehiclePark.Core
{
    using System;
    using VehiclePark.Interfaces;
    using VehiclePark.UI;

    public class Engine : IEngine
    {
        private readonly CommandExecutor executor;
        private IUserInterface ui;

        public Engine(CommandExecutor executor)
        {
            this.executor = executor;
            this.ui = new UserInterface();
        }

        public Engine()
            : this(new CommandExecutor())
        {
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.ui.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine = commandLine.Trim();

                // BUG: it was: if(string.IsNullOrEmpty(commandLine))
                if (!string.IsNullOrEmpty(commandLine)) 
                {
                    try
                    {
                        var command = new Command(commandLine);
                        string commandResult = this.executor.Execute(command);
                        this.ui.WriteLine(commandResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}