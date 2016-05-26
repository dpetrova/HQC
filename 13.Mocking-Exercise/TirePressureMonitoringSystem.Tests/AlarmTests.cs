using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TirePressureMonitoringSystem.Tests
{
    using Moq;

    using _2.TirePressureMonitoringSystem;

    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void Sensor_ByPressureValue_BelowLowPressureThreshold_ShouldAlarmOn()
        {
            var mock = new Mock<ISensor>();
            mock.Setup(s => s.PopNextPressurePsiValue()).Returns(16);

            var alarm = new Alarm(mock.Object);
            alarm.Check();
            var isOn = alarm.AlarmOn;
            var expected = true;

            Assert.AreEqual(expected, isOn);
        }


        [TestMethod]
        public void Sensor_ByPressureValue_UpperHighPressureThreshold_ShouldAlarmOn()
        {
            var mock = new Mock<ISensor>();
            mock.Setup(s => s.PopNextPressurePsiValue()).Returns(22);

            var alarm = new Alarm(mock.Object);
            alarm.Check();
            var isOn = alarm.AlarmOn;
            var expected = true;

            Assert.AreEqual(expected, isOn);
        }


        [TestMethod]
        public void Sensor_ByPressureValue_WithinTheSafePressureInterval_ShouldAlarmOff()
        {
            var mock = new Mock<ISensor>();
            mock.Setup(s => s.PopNextPressurePsiValue()).Returns(19);

            var alarm = new Alarm(mock.Object);
            alarm.Check();
            var isOn = alarm.AlarmOn;
            var expected = false;

            Assert.AreEqual(expected, isOn);
        }
    }
}
