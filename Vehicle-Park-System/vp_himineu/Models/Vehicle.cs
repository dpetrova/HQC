namespace VehiclePark.Models
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    using global::VehiclePark.Interfaces;

    public class Vehicle : IVehicle
    {
        private string licensePlate;
        private string owner;
        private decimal regularRate;
        private decimal overtimeRate;
        private int reservedHours;

        public Vehicle(string licensePlate, string person, int hours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = person;
            this.ReservedHours = hours;
        }
        
        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            set
            {
                // BUG: correct regex
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}[0-9]{4}[A-Z]{2}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                } 

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidCastException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));
                }

                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overtimeRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative."));
                }

                this.overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.reservedHours;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.reservedHours = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", this.GetType().Name, this.LicensePlate, this.Owner);
            return vehicle.ToString();
        }
    }
}
