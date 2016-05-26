namespace VehiclePark.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehiclePark.Interfaces;
    using VehiclePark.Models;

    [TestClass]
    public class FindVehicleByOwnerUnitTests
    {
        private VehiclePark park;
        private IVehicle vehicle;
        private IVehicle anotherVehicle;

        [TestInitialize]
        public void InitializeData()
        {
            this.park = new VehiclePark(3, 2);
            this.vehicle = new Car("AA0000AA", "Owner", 2);
            this.anotherVehicle = new Motorbike("BB0000BB", "Owner", 3);
        }

        [TestMethod]
        public void FindVehicle_InvalidOwner_ShouldReturnErrorMessage()
        {
            var message = this.park.FindVehiclesByOwner("John");
            var expected = "No vehicles by John";

            Assert.AreEqual(expected, message);
        }

        [TestMethod]
        public void FindVehicle_ValidOwner_ShouldReturnVehicles()
        {
            this.park.InsertVehicle(this.vehicle, 1, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            this.park.InsertVehicle(this.anotherVehicle, 3, 1, new DateTime(2016, 2, 6, 10, 35, 15));

            var vehicles = this.park.FindVehiclesByOwner("Owner");
            var expected = "Car [AA0000AA], owned by Owner\r\n" +
                           "Parked at (1,2)\r\n" +
                           "Motorbike [BB0000BB], owned by Owner\r\n" +
                           "Parked at (3,1)";

            Assert.AreEqual(expected, vehicles);
        }


    }
}
