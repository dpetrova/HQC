using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VehiclePark.TestsWithMocking
{
    using System.Collections.Generic;

    using Moq;

    using VehiclePark.Interfaces;
    using VehiclePark.Models;

    using Wintellect.PowerCollections;

    [TestClass]
    public class FindVehicleUnitTests
    {
        private IVehicle vehicle;

        [TestInitialize]
        public void InitializeData()
        {
            this.vehicle = new Car("AA0000AA", "Owner", 2);
        }

        [TestMethod]
        public void FindVeficle_ValidLicencePlate_ShouldReturnVehicle()
        {
            var mock = new Mock<IData>();
            mock.Setup(vp => vp.VehiclesInPark).Returns(new Dictionary<IVehicle, string>(){ {this.vehicle, "(1,2)"} });
            mock.Setup(vp => vp.ParkingPlace).Returns(new Dictionary<string, IVehicle>() { { "(1,2)", this.vehicle } });
            mock.Setup(vp => vp.LicencePlates).Returns(new Dictionary<string, IVehicle>() { { "AA0000AA", this.vehicle } });
            mock.Setup(vp => vp.StartTime).Returns(new Dictionary<IVehicle, DateTime>() { { this.vehicle, new DateTime(2016, 2, 6, 10, 15, 30) } });
            mock.Setup(vp => vp.Owners).Returns(new MultiDictionary<string, IVehicle>(false) { { "Owner", this.vehicle } });
            mock.Setup(vp => vp.Count).Returns(new int[2]);

            var mock2 = new Mock<ILayout>();
            mock2.Setup(l => l.Sectors).Returns(2);
            mock2.Setup(l => l.Places).Returns(3);

            var park = new VehiclePark(mock2.Object, mock.Object);

            var found = park.FindVehicle("AA0000AA");
            
            var expected = "Car [AA0000AA], owned by Owner\r\n" +
                           "Parked at (1,2)\r\n";

            Assert.AreEqual(expected, found);
        }

        [TestMethod]
        public void FindVeficle_InValidLicencePlate_ShouldReturnVehicle()
        {
            var mock = new Mock<IData>();
            mock.Setup(vp => vp.VehiclesInPark).Returns(new Dictionary<IVehicle, string>() { { this.vehicle, "(1,2)" } });
            mock.Setup(vp => vp.ParkingPlace).Returns(new Dictionary<string, IVehicle>() { { "2", this.vehicle } });
            mock.Setup(vp => vp.LicencePlates).Returns(new Dictionary<string, IVehicle>() { { "AA0000AA", this.vehicle } });
            mock.Setup(vp => vp.StartTime).Returns(new Dictionary<IVehicle, DateTime>() { { this.vehicle, new DateTime(2016, 2, 6, 10, 15, 30) } });
            mock.Setup(vp => vp.Owners).Returns(new MultiDictionary<string, IVehicle>(false) { { "Owner", this.vehicle } });
            mock.Setup(vp => vp.Count).Returns(new int[2]);

            var mock2 = new Mock<ILayout>();
            mock2.Setup(l => l.Sectors).Returns(2);
            mock2.Setup(l => l.Places).Returns(3);

            var park = new VehiclePark(mock2.Object, mock.Object);

            var found = park.FindVehicle("BB0000BB");

            var expected = "There is no vehicle with license plate BB0000BB in the park";

            Assert.AreEqual(expected, found);
        }
    }
}
