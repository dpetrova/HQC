namespace AirConditionerTester.Tests
{
    using BigMani.Core;
    using BigMani.Interfaces;
    using BigMani.Models;
    using BigMani.Repositories;
    using BigMani.UI;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StatusTests
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
        public void Status_ShouldReturnCorrectPercent()
        {
            var report = new Report("XXXX", "SSS", 10);
            this.executor.RegisterStationaryAirConditioner("XXXX", "SSS", "A", 750);
            Repository.Reports.Add(report);

            var status = this.executor.Status();
            var expected = "Jobs complete: 150.00%";

            Assert.AreEqual(expected, status);
        }
    }
}
