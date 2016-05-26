namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Interfaces;

    public class FileAppender : Appender
    {
        private string file;
        private StreamWriter writer;

        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public string File
        {
            get
            {
                return this.file;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("File path cannot be empty.");
                }

                this.file = value;
            }
        }

        public override void Append()
        {
            this.writer = new StreamWriter(this.File, true);
            string output = this.Layout.Format();
            this.writer.WriteLine(output);
        }

        public void Close()
        {
            this.writer.Close();
        }
    }
}
