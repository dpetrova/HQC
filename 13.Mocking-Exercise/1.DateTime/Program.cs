using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DateTime
{
    using DateTime = System.DateTime;

    class Program
    {
        static void Main()
        {
            var dateNow = DateTime.Now;
            Console.WriteLine(dateNow);

            var datePlusOneDay = dateNow.AddDays(1);
            Console.WriteLine(datePlusOneDay);

            Console.WriteLine("Min Value: " + DateTime.MinValue);
            Console.WriteLine("Max Value: " + DateTime.MaxValue);

            //var test = DateTime.MinValue.AddDays(-1);
            //Console.WriteLine(test);
        }
    }
}
