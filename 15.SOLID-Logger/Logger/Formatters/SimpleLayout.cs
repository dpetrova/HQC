namespace Logger.Formatters
{
    public class SimpleLayout : Layout
    {
        public override string Format()
        {
            return string.Format("{0} - {1} - {2}", this.Date, this.Level, this.Message);
        }
    }
}
