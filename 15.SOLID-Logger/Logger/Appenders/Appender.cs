namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Layout cannot be null.");
                }

                this.layout = value;
            }
        }

        public ReportLevel ReportLevelThreshold { get; set; }

        public abstract void Append();
    }
}
