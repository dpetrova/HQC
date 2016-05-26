namespace VehiclePark.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehiclePark.Interfaces;
    using VehiclePark.Models;

    [TestClass]
    public class InsertVehicleUnitTests
    {
        private VehiclePark park;
        private IVehicle vehicle;
        
        [TestInitialize]
        public void InitializeData()
        {
            this.park = new VehiclePark(3, 2);
            this.vehicle = new Car("AA0000AA", "Owner", 2);
        }

        [TestMethod]
        public void InsertVehicle_OnEmptyPlace_ShouldReturnSuccessfullMessage()
        {
            var message = this.park.InsertVehicle(this.vehicle, 1, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            var expected = "Car parked successfully at place (1,2)";

            Assert.AreEqual(expected, message);
        }

        [TestMethod]
        public void InsertVehicle_OnInvalidSector_ShouldReturnErrorMessage()
        {
            var message = this.park.InsertVehicle(this.vehicle, 5, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            var expected = "There is no sector 5 in the park";

            Assert.AreEqual(expected, message);
        }

        [TestMethod]
        public void InsertVehicle_OnInvalidPlace_ShouldReturnErrorMessage()
        {
            var message = this.park.InsertVehicle(this.vehicle, 2, 10, new DateTime(2016, 2, 6, 10, 35, 15));
            var expected = "There is no place 10 in sector 2";

            Assert.AreEqual(expected, message);
        }

        [TestMethod]
        public void InsertVehicle_OnOccupiedPlace_ShouldReturnErrorMessage()
        {
            this.park.InsertVehicle(this.vehicle, 1, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            var message = this.park.InsertVehicle(this.vehicle, 1, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            var expected = "The place (1,2) is occupied";

            Assert.AreEqual(expected, message);
        }

        [TestMethod]
        public void InsertVehicle_WithAlreadyExistingLicencePlate_ShouldReturnErrorMessage()
        {
            var anotherCar = new Car("AA0000AA", "Another owner", 5);
            this.park.InsertVehicle(anotherCar, 1, 2, new DateTime(2016, 2, 6));

            var message = this.park.InsertVehicle(this.vehicle, 2, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            var expected = "There is already a vehicle with license plate AA0000AA in the park";

            Assert.AreEqual(expected, message);
        }
    }
}
