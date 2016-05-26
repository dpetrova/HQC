namespace VehiclePark.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehiclePark.Interfaces;
    using VehiclePark.Models;

    [TestClass]
    public class ExitVehicleUnitTests
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
        public void ExitVehicle_WithInvalidLicencePlate_ShouldReturnErrorMessage()
        {
            var message = this.park.ExitVehicle("AA0000AA", new DateTime(2016, 2, 6, 10, 35, 15), 6.5m);
            var expected = "There is no vehicle with license plate AA0000AA in the park";

            Assert.AreEqual(expected, message);
        }

        [TestMethod]
        public void ExitVehicle_ValidParameters_WithinReservedHours_ShouldReturnSuccessfullTicket()
        {
            this.park.InsertVehicle(this.vehicle, 1, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            var ticket = this.park.ExitVehicle(this.vehicle.LicensePlate, new DateTime(2016, 2, 6, 11, 35, 15), 5.0m);
            var expected = "********************\r\n" +
                           "Car [AA0000AA], owned by Owner\r\n" +
                           "at place (1,2)\r\n" +
                           "Rate: $4.00\r\n" +
                           "Overtime rate: $0.00\r\n" +
                           "--------------------\r\n" +
                           "Total: $4.00\r\n" +
                           "Paid: $5.00\r\n" +
                           "Change: $1.00\r\n" +
                           "********************";

            Assert.AreEqual(expected, ticket);
        }

        [TestMethod]
        public void ExitVehicle_ValidParameters_ExceededReservedHours_ShouldReturnSuccessfullTicket()
        {
            this.park.InsertVehicle(this.vehicle, 1, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            var ticket = this.park.ExitVehicle(this.vehicle.LicensePlate, new DateTime(2016, 2, 6, 14, 35, 15), 20.0m);
            var expected = "********************\r\n" +
                           "Car [AA0000AA], owned by Owner\r\n" +
                           "at place (1,2)\r\n" +
                           "Rate: $4.00\r\n" +
                           "Overtime rate: $7.00\r\n" +
                           "--------------------\r\n" +
                           "Total: $11.00\r\n" +
                           "Paid: $20.00\r\n" +
                           "Change: $9.00\r\n" +
                           "********************";

            Assert.AreEqual(expected, ticket);
        }

    }
}
