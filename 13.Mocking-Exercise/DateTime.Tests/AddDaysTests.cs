using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateTime.Tests
{
    using Moq;

    using _1.DateTime;

    using DateTime = System.DateTime;

    [TestClass]
    public class AddDaysTests
    {
        [TestMethod]
        public void AddingADay_ToTheMiddleOfTheMonth_ShouldAddADayCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2015, 1, 16));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expected = new DateTime(2015, 1, 17);

            Assert.AreEqual(expected, date);
        }


        [TestMethod]
        public void AddingADay_ToTheEndOfTheMonth_ShouldAddADayInTheNextMonth()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2015, 7, 31));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expected = new DateTime(2015, 8, 1);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void AddingNegativeValue_ShouldSubstractDays()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2015, 1, 16));

            var date = mock.Object.DateTimeNow.AddDays(-5);
            var expected = new DateTime(2015, 1, 11);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void AddingNegativeValue_InTheStartOfTheMonth_ShouldSubstractDaysIntoPreviosMonth()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2015, 1, 1));

            var date = mock.Object.DateTimeNow.AddDays(-5);
            var expected = new DateTime(2014, 12, 27);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void AddingADay_ToALeapYear_ShouldAddADayCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(2008, 2, 28));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expected = new DateTime(2008, 2, 29);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void AddingADay_ToANonLeapYear_ShouldAddADayCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(new DateTime(1900, 2, 28));

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expected = new DateTime(1900, 3, 1);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        public void AddADay_ToDateTimeMinValue_ShouldAddADayCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(DateTime.MinValue);

            var date = mock.Object.DateTimeNow.AddDays(1);
            var expected = new DateTime(1, 1, 2);

            Assert.AreEqual(expected, date);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SubstractADay_ToDateTimeMinValue_ShouldThrow()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(DateTime.MinValue);

            var date = mock.Object.DateTimeNow.AddDays(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddADay_ToDateTimeMaxValue_ShouldThrow()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(DateTime.MaxValue);

            var date = mock.Object.DateTimeNow.AddDays(1);
        }

        [TestMethod]
        public void SubstractADay_ToDateTimeMaxValue_ShouldSubstractADayCorrectly()
        {
            var mock = new Mock<IDateTimeProvider>();
            mock.Setup(d => d.DateTimeNow).Returns(DateTime.MaxValue);

            var date = mock.Object.DateTimeNow.AddDays(-1);
            var expected = new DateTime(9999, 12, 30);

            Assert.AreEqual(expected, date);
        }

    }
}
