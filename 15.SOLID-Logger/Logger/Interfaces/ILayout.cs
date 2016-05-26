namespace Logger.Interfaces
{
    using System;

    public interface ILayout
    {
        string Message { get; set; }

        ReportLevel Level { get; set; }

        DateTime Date { get; }

        string Format();
    }
}
