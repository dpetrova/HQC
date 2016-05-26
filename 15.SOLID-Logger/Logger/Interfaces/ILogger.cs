namespace Logger.Interfaces
{
    public interface ILogger
    {
        IAppender Appender { get; set; }

        void Log(string message, ReportLevel level);

        void Info(string message);

        void Warning(string message);

        void Error(string message);

        void Critical(string message);

        void Fatal(string message);
    }
}
