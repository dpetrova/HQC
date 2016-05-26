namespace VehiclePark.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public interface IData
    {
        Dictionary<IVehicle, string> VehiclesInPark { get; set; }

        Dictionary<string, IVehicle> ParkingPlace { get; set; }

        Dictionary<string, IVehicle> LicencePlates { get; set; }

        Dictionary<IVehicle, DateTime> StartTime { get; set; }

        MultiDictionary<string, IVehicle> Owners { get; set; }

        int[] Count { get; set; }
    }
}
