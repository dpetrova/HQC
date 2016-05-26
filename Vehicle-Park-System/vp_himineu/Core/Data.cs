namespace VehiclePark.Core
{
    using System;
    using System.Collections.Generic;
    using VehiclePark.Interfaces;
    using Wintellect.PowerCollections;

    public class Data : IData
    {
        public Data(int numberOfSectors)
        {
            this.VehiclesInPark = new Dictionary<IVehicle, string>();
            this.ParkingPlace = new Dictionary<string, IVehicle>();
            this.LicencePlates = new Dictionary<string, IVehicle>();
            this.StartTime = new Dictionary<IVehicle, DateTime>();
            this.Owners = new MultiDictionary<string, IVehicle>(false);
            this.Count = new int[numberOfSectors];
        }
        
        public Dictionary<IVehicle, string> VehiclesInPark { get; set; }

        public Dictionary<string, IVehicle> ParkingPlace { get; set; }

        public Dictionary<string, IVehicle> LicencePlates { get; set; }

        public Dictionary<IVehicle, DateTime> StartTime { get; set; }

        public MultiDictionary<string, IVehicle> Owners { get; set; }

        public int[] Count { get; set; }
    }
}