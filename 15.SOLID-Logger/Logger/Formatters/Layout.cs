namespace Logger.Formatters
{
    using System;
    using Interfaces;

    public abstract class Layout : ILayout
    {
        private string message;

        public string Message 
        {
            get
            {
                return this.message;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Message cannot be empty.");
                }

                this.message = value;
            } 
        }

        public ReportLevel Level { get; set; }

        public DateTime Date
        {
            get { return DateTime.Now; }
        }

        public abstract string Format();
    }
}
