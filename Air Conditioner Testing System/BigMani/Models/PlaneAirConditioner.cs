namespace BigMani.Models
{
    using System;
    using BigMani.Utilities;

    public class PlaneAirConditioner : AirConditioner
    {
        private int volumeCovered;

        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCoverage;
            this.ElectricityUsed = Convert.ToInt32(electricityUsed);
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

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            if (this.ElectricityUsed / sqrtVolume < Constants.MinPlaneElectricity)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            string print = base.ToString();

            print += "Volume Covered: " + this.VolumeCovered + "\r\n" + "Electricity Used: " + this.ElectricityUsed + "\r\n";

            print += "====================";

            return print;
        }
    }
}
