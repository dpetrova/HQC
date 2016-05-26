namespace VehiclePark.Models
{
    public class Truck : Vehicle
    {
        public Truck(string licensePlate, string person, int hours)
            : base(licensePlate, person, hours)
        {
            this.RegularRate = 4.75M;
            this.OvertimeRate = 6.2M;
        }
    }
}
