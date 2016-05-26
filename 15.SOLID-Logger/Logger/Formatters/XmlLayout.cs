namespace Logger.Formatters
{
    using System.Text;

    public class XmlLayout : Layout
    {
        public override string Format()
        {
            var output = new StringBuilder();
            output.AppendLine("<log>");
            output.AppendLine("    <date>" + this.Date + "</date>");
            output.AppendLine("    <level>" + this.Level + "</level>");
            output.AppendLine("    <message>" + this.Message + "</message>");
            output.AppendLine("</log>");

            return output.ToString();
        }
    }
}
