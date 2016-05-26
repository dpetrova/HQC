using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DateTime
{
    using DateTime = System.DateTime;

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeNow
        {
            get { return DateTime.Now; }
        }
    }
}
