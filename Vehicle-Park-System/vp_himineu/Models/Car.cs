namespace VehiclePark.Models
{
    public class Car : Vehicle
    {
        public Car(string licensePlate, string person, int hours)
            : base(licensePlate, person, hours)
        {
            this.RegularRate = 2;
            this.OvertimeRate = 3.5M;
        }
    }
}
