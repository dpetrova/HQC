using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReformatYourOwnCode_old
{
    class Employee
    {
        private int empNum;
        private double empSal;

        //using a constructor to initialize the fields
        public Employee(int num, double salary)
        {
            empNum = num;
            empSal = salary;
        }

        //default constructor required?
        public Employee()
        {

        }

        //not using auto-implemented properties
        public int EmpNum
        {
            get { return empNum; }
            set { empNum = value; }
        }
        
        //using auto-implemented properties
        public double EmpSal {get; set;}

        public string GetGreeting()
        {
            string greeting = "Hello, I am employee #:" + EmpNum;
            return greeting;
        }
    }
}
