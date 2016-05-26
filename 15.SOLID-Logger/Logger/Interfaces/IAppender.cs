namespace Logger.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; set; }

        ReportLevel ReportLevelThreshold { get; set; }

        void Append();
    }
}
