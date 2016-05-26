namespace Logger
{
    using Interfaces;

    public class Logger : ILogger
    {
        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }

        public IAppender Appender { get; set; }

        public void Log(string message, ReportLevel level)
        {
            this.Appender.Layout.Message = message;
            this.Appender.Layout.Level = level;
            if (level >= this.Appender.ReportLevelThreshold)
            {
                this.Appender.Append();
            }
        }

        public void Info(string message)
        {
            this.Log(message, ReportLevel.Info);
        }

        public void Warning(string message)
        {
            this.Log(message, ReportLevel.Warning);
        }

        public void Error(string message)
        {
            this.Log(message, ReportLevel.Error);
        }

        public void Critical(string message)
        {
            this.Log(message, ReportLevel.Critical);
        }

        public void Fatal(string message)
        {
            this.Log(message, ReportLevel.Fatal);
        }
    }
}
