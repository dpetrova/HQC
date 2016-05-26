namespace BigMani.Models
{
   using BigMani.Interfaces;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, int mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Mark { get; set; }

        // BUG found
        public override string ToString()
        {
            string result = string.Empty;
            var mark = string.Empty;
            if (this.Mark == 0)
            {
                mark = "Failed";
            }
            else
            {
                mark = "Passed";
            }

            result += "Report" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " + this.Manufacturer + "\r\n" +
                      "Model: " + this.Model + "\r\n" + "Mark: " + mark + "\r\n" + "====================";

            return result;
        }
    }
}
