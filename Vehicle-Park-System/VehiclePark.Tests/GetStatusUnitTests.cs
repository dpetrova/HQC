using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePark.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VehiclePark.Interfaces;
    using VehiclePark.Models;

    [TestClass]
    public class GetStatusUnitTests
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
        public void GetStatus_ShouldReturnCorrectStatus()
        {
            this.park.InsertVehicle(this.vehicle, 1, 1, new DateTime(2016, 2, 6, 10, 35, 15));
            this.park.InsertVehicle(new Car("BB0000BB", "John", 2), 1, 2, new DateTime(2016, 2, 6, 10, 35, 15));
            this.park.InsertVehicle(new Car("CC0000CC", "Gail", 2), 2, 1, new DateTime(2016, 2, 6, 10, 35, 15));
            var status = this.park.GetStatus();
            var expected = "Sector 1: 2 / 2 (100% full)\r\n" +
                           "Sector 2: 1 / 2 (50% full)\r\n" + 
                           "Sector 3: 0 / 2 (0% full)";

            Assert.AreEqual(expected, status);
        }
    }
}
