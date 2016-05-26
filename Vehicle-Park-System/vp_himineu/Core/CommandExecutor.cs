namespace VehiclePark.Core
{
    using System;
    using VehiclePark.Interfaces;
    using VehiclePark.Models;

    public class CommandExecutor
    {
        private VehiclePark VehiclePark { get; set; }

        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            switch (command.Name)
            {
                case "SetupPark":
                    var sectors = int.Parse(command.Parameters["sectors"]);
                    var places = int.Parse(command.Parameters["placesPerSector"]);
                    this.VehiclePark = new VehiclePark(sectors, places);
                    return "Vehicle park created";
                case "Park":
                    var type = command.Parameters["type"];
                    var licensePlate = command.Parameters["licensePlate"];
                    var owner = command.Parameters["owner"];
                    var reservedHours = int.Parse(command.Parameters["hours"]);
                    var sector = int.Parse(command.Parameters["sector"]);
                    var place = int.Parse(command.Parameters["place"]);
                    var startTime = DateTime.Parse(
                                command.Parameters["time"],
                                null,
                                System.Globalization.DateTimeStyles.RoundtripKind);
                    switch (type)
                    {
                        case "car":
                            var car = new Car(licensePlate, owner, reservedHours);
                            return this.VehiclePark.InsertVehicle(car, sector, place, startTime);
                        case "motorbike":
                            var motorbike = new Motorbike(licensePlate, owner, reservedHours);
                            return this.VehiclePark.InsertVehicle(motorbike, sector, place, startTime);
                        case "truck":
                            var truck = new Truck(licensePlate, owner, reservedHours);
                            return this.VehiclePark.InsertVehicle(truck, sector, place, startTime);
                        default:
                            throw new InvalidOperationException("Invalid vehicle.");
                    }

                case "Exit":
                    licensePlate = command.Parameters["licensePlate"];
                    var endTime = DateTime.Parse(
                        command.Parameters["time"],
                        null,
                        System.Globalization.DateTimeStyles.RoundtripKind);
                    var price = decimal.Parse(command.Parameters["paid"]);
                    return this.VehiclePark.ExitVehicle(licensePlate, endTime, price);
                case "Status":
                    return this.VehiclePark.GetStatus();
                case "FindVehicle":
                    licensePlate = command.Parameters["licensePlate"];
                    return this.VehiclePark.FindVehicle(licensePlate);
                case "VehiclesByOwner":
                    owner = command.Parameters["owner"];
                    return this.VehiclePark.FindVehiclesByOwner(owner);
                default:
                    throw new InvalidOperationException("Invalid command.");
            }
        }
    }
}