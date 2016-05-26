using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.TirePressureMonitoringSystem
{
    class Program
    {
        static void Main()
        {
            var randomNumberProvider = new RandomNumberProvider();

            var sensor = new Sensor(randomNumberProvider);

            sensor.PopNextPressurePsiValue();

            var alarm = new Alarm(sensor);

            alarm.Check();

            Console.WriteLine(alarm.AlarmOn);
        }
    }
}
