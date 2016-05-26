namespace BigMani.Models
{
    using System;
    using BigMani.Utilities;

    public class CarAirConditioner : AirConditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCoverage)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCoverage;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            if (sqrtVolume < 3)
            {
                return 1;
            }

            // BUG: it was return 2
            return 0;
        }

        public override string ToString()
        {
            string print = base.ToString();

            print += "Volume Covered: " + this.VolumeCovered + "\r\n";

            print += "====================";

            return print;
        }
    }
}
