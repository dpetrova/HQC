namespace BigMani.Core
{
    using System;

    using BigMani.Interfaces;
    
    public class Engine
    {
        //protected IUserInterface userInterface;

        //protected CommandExecutor executor;

        //protected Command inputCommand;

        public Engine(IUserInterface userInterface)
        {
            this.Executor = new CommandExecutor(this);
            this.UserInterface = userInterface;
        }

        public IUserInterface UserInterface { get; set; }

        public CommandExecutor Executor { get; set; }

        public Command InputCommand { get; set; }

        public void Run()
        {
            while (true)
            {
                string line = this.UserInterface.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.InputCommand = new Command(line);
                    this.Executor.Execute();
                }
                catch (InvalidOperationException ex)
                {
                    this.UserInterface.WriteLine(ex.Message);
                }
            }
        }
    }
}
