namespace BigMani
{
    using BigMani.Core;
    using BigMani.UI;

    public class MainProgram
    {
        public static void Main()
        {
            var engine = new Engine(new ConsoleUserInterface());
            engine.Run();
        }
    }
}
