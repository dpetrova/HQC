namespace Logger
{
    using Appenders;
    using Formatters;
    
    class LoggerMainProgram
    {
        static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevelThreshold = ReportLevel.Error;
            var logger = new Logger(consoleAppender);
            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            logger.Info("Everything seems fine");
            logger.Warning("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
            
            var xmlLayout = new XmlLayout();
            var consoleAppender2 = new ConsoleAppender(xmlLayout);
            var logger2 = new Logger(consoleAppender2);
            logger2.Fatal("mscorlib.dll does not respond");
            logger2.Critical("No connection string found in App.config");
            
            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = "log.txt";
            var logger3 = new Logger(fileAppender);
            logger3.Warning("Warning - missing files..");
            fileAppender.Close();
        }
    }
}
