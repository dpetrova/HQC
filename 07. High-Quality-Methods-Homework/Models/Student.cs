namespace Methods.Models
{
    using System;
    using System.Text.RegularExpressions;

    internal class Student
    {
        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName)
            : this(firstName, lastName, null)
        {
        }

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "First name cannot be null or empty");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Lats name cannot be null or empty");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.GetBirthDate(this.OtherInfo);
            DateTime secondDate = this.GetBirthDate(other.OtherInfo);
            return firstDate < secondDate;
        }

        public DateTime GetBirthDate(string info)
        {
            string pattern = @"([0-9]{2}.[0-9]{2}.[0-9]{4})";
            Regex regexBirthDate = new Regex(pattern);
            Match matchBirthDate = regexBirthDate.Match(info);

            if (!matchBirthDate.Success)
            {
                throw new ArgumentException("Cannot parse birthdate from otherInfo!");
            }

            var birthDate = DateTime.Parse(matchBirthDate.ToString());

            return birthDate;

            //string dateAsString = info.Substring(info.Length - 10);
            //DateTime date;

            //if (!DateTime.TryParse(dateAsString, out date))
            //{
            //    throw new InvalidOperationException(string.Format("Unable to parse '{0}'.", dateAsString));
            //}

            //return date;
        }
    }
}
