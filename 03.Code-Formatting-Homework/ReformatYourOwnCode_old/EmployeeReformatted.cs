namespace ReformatYourOwnCode
{
    using System;

    internal class EmployeeReformatted
    {
        private int employeeNumber;

        private double employeeSalary;

        public EmployeeReformatted(int number, double salary)
        {
            this.EmployeeNumber = number;
            this.EmployeeSalary = salary;
        }

        public int EmployeeNumber
        {
            get
            {
                return this.employeeNumber;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("value", "The employee number cannot be negative.");
                }

                this.employeeNumber = value;
            }
        }

        public double EmployeeSalary
        {
            get
            {
                return this.employeeSalary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("value", "The salary cannot be negative.");
                }

                this.employeeSalary = value;
            }
        }

        public string GetGreeting()
        {
            var greeting = "Hello, I am employee #:" + this.EmployeeNumber;
            return greeting;
        }
    }
}