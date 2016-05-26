namespace BigMani.Models
{
    using System;
    using BigMani.Utilities;

    public class StationaryAirConditioner : AirConditioner
    {
        private int energyRating;

        private int powerUsage;

        public StationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
            : base(manufacturer, model)
        {
            switch (energyEfficiencyRating)
            {
                case "A":
                    this.energyRating = 10;
                    break;
                case "B":
                    this.energyRating = 12;
                    break;
                case "C":
                    this.energyRating = 15;
                    break;
                case "D":
                    this.energyRating = 20;
                    break;
                case "E":
                    this.energyRating = 90;
                    break;
            }

            this.powerUsage = powerUsage;
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositive, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public int EnergyRating
        {
            get
            {
                return this.energyRating;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectRating));
                }

                this.powerUsage = value;
            }
        }
        
        public override int Test()
        {
            if (this.powerUsage / 100 <= this.energyRating)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            string print = base.ToString();

            string energy = "A";
            switch (this.energyRating)
            {
                case 12:
                    energy = "B";
                    break;
                case 15:
                    energy = "C";
                    break;
                case 20:
                    energy = "D";
                    break;
                case 90:
                    energy = "E";
                    break;
            }

            print += "Required energy efficiency rating: " + energy + "\r\n" + "Power Usage(KW / h): " +
                     this.powerUsage + "\r\n";
            
            print += "====================";

            return print;
        }
    }
}
