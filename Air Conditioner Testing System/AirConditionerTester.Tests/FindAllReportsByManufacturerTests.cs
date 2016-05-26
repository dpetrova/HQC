using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirConditionerTester.Tests
{
    using BigMani.Core;
    using BigMani.Interfaces;
    using BigMani.Models;
    using BigMani.Repositories;
    using BigMani.UI;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindAllReportsByManufacturerTests
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
        public void FindAllReports_NoReports_ShouldReturnErrorMessage()
        {
            var reports = this.executor.FindAllReportsByManufacturer("Manufacturer");

            var expected = "No reports.";

            Assert.AreEqual(expected, reports);
        }

        [TestMethod]
        public void FindAllReports_ValidManufacturer_ShouldReturnSuccessfullMessage()
        {
            var report = new Report("Manufacturer", "AA00", 10);
            Repository.Reports.Add(report);

            var reports = this.executor.FindAllReportsByManufacturer("Manufacturer");

            var expected = "Reports from Manufacturer:\r\n" +
                           "Report\r\n" +
                           "====================\r\n" +
                           "Manufacturer: Manufacturer\r\n" +
                           "Model: AA00\r\n" +
                           "Mark: Passed\r\n" +
                           "====================";

            Assert.AreEqual(expected, reports);
        }


        [TestMethod]
        public void FindAllReports_ManyReports_ShouldReturnThemOrderedByModel()
        {
            var otherReport = new Report("Manufacturer", "BB00", 10);
           
            Repository.Reports.Add(otherReport);
            
            var reports = this.executor.FindAllReportsByManufacturer("Manufacturer");

            var expected = "Reports from Manufacturer:\r\n" +
                           "Report\r\n" +
                           "====================\r\n" +
                           "Manufacturer: Manufacturer\r\n" +
                           "Model: AA00\r\n" +
                           "Mark: Passed\r\n" +
                           "====================\r\n" +
                           "Report\r\n" +
                           "====================\r\n" +
                           "Manufacturer: Manufacturer\r\n" +
                           "Model: BB00\r\n" +
                           "Mark: Passed\r\n" +
                           "====================";

            Assert.AreEqual(expected, reports);
        }
    }
}
