namespace VehiclePark.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using global::VehiclePark.Core;
    using global::VehiclePark.Interfaces;

    public class VehiclePark : IVehiclePark
    {
        private readonly ILayout layout;
        private readonly IData data;

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.data = new Data(numberOfSectors);
        }

        public VehiclePark(ILayout layout, IData data)
        {
            this.layout = layout;
            this.data = data;
        }

        public string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime time)
        {
            if (sector > this.layout.Sectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.layout.Places)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.ParkingPlace.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.LicencePlates.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", vehicle.LicensePlate);
            }

            this.data.VehiclesInPark[vehicle] = string.Format("({0},{1})", sector, place);
            this.data.ParkingPlace[string.Format("({0},{1})", sector, place)] = vehicle;
            this.data.LicencePlates[vehicle.LicensePlate] = vehicle;
            this.data.StartTime[vehicle] = time;
            this.data.Owners[vehicle.Owner].Add(vehicle);
            this.data.Count[sector - 1]++;
            return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, place);
        }

        public string ExitVehicle(string licencePlate, DateTime endTime, decimal paid)
        {
            var vehicle = this.data.LicencePlates.ContainsKey(licencePlate) ? this.data.LicencePlates[licencePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licencePlate);
            }

            var start = this.data.StartTime[vehicle];
            int end = (int)Math.Round((endTime - start).TotalHours);
            var ticket = new StringBuilder();
            ticket.AppendLine(new string('*', 20))
                  .AppendFormat("{0}", vehicle)
                  .AppendLine()
                  .AppendFormat("at place {0}", this.data.VehiclesInPark[vehicle])
                  .AppendLine()
                  .AppendFormat("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate)
                  .AppendLine()
                  .AppendFormat("Overtime rate: ${0:F2}", end > vehicle.ReservedHours ? (end - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)
                  .AppendLine()
                  .AppendLine(new string('-', 20))
                  .AppendFormat("Total: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate + (end > vehicle.ReservedHours ? (end - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))
                  .AppendLine().AppendFormat("Paid: ${0:F2}", paid)
                  .AppendLine().AppendFormat("Change: ${0:F2}", paid - ((vehicle.ReservedHours * vehicle.RegularRate) + (end > vehicle.ReservedHours ? (end - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                  .AppendLine().Append(new string('*', 20));

            // Delete
            int sector = int.Parse(this.data.VehiclesInPark[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            this.data.ParkingPlace.Remove(this.data.VehiclesInPark[vehicle]);
            this.data.VehiclesInPark.Remove(vehicle);
            this.data.LicencePlates.Remove(vehicle.LicensePlate);
            this.data.StartTime.Remove(vehicle);
            this.data.Owners.Remove(vehicle.Owner, vehicle);
            this.data.Count[sector - 1]--;

            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = this.data.Count
                .Select((occupied, index) => 
                    string.Format(
                    "Sector {0}: {1} / {2} ({3}% full)",
                    index + 1,
                    occupied,
                    this.layout.Places,
                    Math.Round((double)occupied / this.layout.Places * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licencePlate)
        {
            var vehicle = this.data.LicencePlates.ContainsKey(licencePlate) ? this.data.LicencePlates[licencePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licencePlate);
            }

            return this.Input(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.data.ParkingPlace.Values.Any(v => v.Owner == owner))
            {
                return string.Format("No vehicles by {0}", owner);
            }

            //BOTTLENECK: 1 unneccessary foreach and .ToList()
            //var found = this.data.ParkingPlace.Values.ToList();

            //var res = found;
            //foreach (var f in found)
            //{
            //    res = res
            //        .Where(v => v.Owner == owner)
            //        .OrderBy(v => v.LicensePlate)
            //        .ToList();
            //}
            //return string.Join(Environment.NewLine, this.Input(res));

            var foundVehicles = this.data.Owners[owner]
                    .OrderBy(v => this.data.StartTime[v])
                    .ThenBy(v => v.LicensePlate)
                    .ToList();
            
            return string.Join(Environment.NewLine, this.Input(foundVehicles));
        }

        private string Input(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(
                Environment.NewLine, 
                vehicles.Select(vehicle => string.Format(
                    "{0}{1}Parked at {2}", 
                    vehicle.ToString(), 
                    Environment.NewLine, 
                    this.data.VehiclesInPark[vehicle])));
        }
    }
}
