namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append()
        {
            string output = this.Layout.Format();

            Console.WriteLine(output);
        }
    }
}
