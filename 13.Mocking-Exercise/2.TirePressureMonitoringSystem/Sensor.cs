using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.TirePressureMonitoringSystem
{
    public class Sensor : ISensor
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //
        const double Offset = 16;

        public Sensor(IRandomNumberProvider randomNumberProvider)
        {
            this.RandomNumberProvider = randomNumberProvider;
        }

        public IRandomNumberProvider RandomNumberProvider { get; set; }

        
        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = ReadPressureSample();

            return Offset + pressureTelemetryValue;
        }

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * this.RandomNumberProvider.GetRandomNumber() * this.RandomNumberProvider.GetRandomNumber();
        }
    }
}
