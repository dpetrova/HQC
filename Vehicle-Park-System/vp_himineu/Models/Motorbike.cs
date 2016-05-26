namespace VehiclePark.Models
{
    public class Motorbike : Vehicle
    {
        public Motorbike(string licensePlate, string person, int hours)
            : base(licensePlate, person, hours)
        {
            this.RegularRate = 1.35M;
            this.OvertimeRate = 3M;
        }
    }
}
