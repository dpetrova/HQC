namespace VehiclePark.Models
{
    using System;

    using global::VehiclePark.Interfaces;

    public class Layout : ILayout
    {
        private int sectors;
        private int places;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;
            this.Places = placesPerSector;
        }
        
        public int Sectors
        {
            get
            {
                return this.sectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of sectors must be positive.");
                }

                this.sectors = value;
            }
        }

        public int Places
        {
            get
            {
                return this.places;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of places per sector must be positive.");
                }

                this.places = value;
            }
        }
    }
}
