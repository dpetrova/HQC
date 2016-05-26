namespace AirConditionerTester.Tests
{
    using System;
    using BigMani.Core;
    using BigMani.Exceptions;
    using BigMani.Interfaces;
    using BigMani.UI;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class RegisterStationaryAirConditionerTests
    {
        private IUserInterface userInterface;

        private Engine engine;

        private CommandExecutor executor;

        [TestInitialize]
        public void InitializeData()
        {
            this.engine = new Engine(this.userInterface);
            this.executor = new CommandExecutor(this.engine);
            this.userInterface = new ConsoleUserInterface();
        }

        [TestMethod]
        public void RegisterStationaryAirConditioner_ValidParameters_ShouldReturnSuccessfullMessage()
        {
            var message = this.executor.RegisterStationaryAirConditioner("Manufacturer", "AA00", "A", 750);

            var expected = "Air Conditioner model AA00 from Manufacturer registered successfully.";
            
            Assert.AreEqual(expected, message);
        }


        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void RegisterStationaryAirConditioner_AlreadyExsisting_ShouldReturnErrorMessage()
        {
            this.executor.RegisterStationaryAirConditioner("Manufacturer", "AA00", "A", 750);
            this.executor.RegisterStationaryAirConditioner("Manufacturer", "AA00", "A", 750);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationaryAirConditioner_InValidManufacturer_ShouldReturnErrorMessage()
        {
            this.executor.RegisterStationaryAirConditioner("Man", "AA00", "A", 750);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationaryAirConditioner_InValidModel_ShouldReturnErrorMessage()
        {
            this.executor.RegisterStationaryAirConditioner("Manufacturer", "A", "A", 750);
        }
    }
}
