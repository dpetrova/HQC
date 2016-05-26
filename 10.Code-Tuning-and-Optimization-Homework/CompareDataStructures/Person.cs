namespace CompareDataStructures
{
    using System;

    internal class Person
    {
        private string name;

        private string phone;

        public Person(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Phone", "Phone cannot be empty.");
                }

                this.phone = value;
            }
        }
    }
}