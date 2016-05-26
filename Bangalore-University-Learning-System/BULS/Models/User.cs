namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Utilities;

    public class User
    {
        private string username;
        private string password;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Courses = new HashSet<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string message = string.Format("The username must be at least 5 symbols long.");
                    throw new ArgumentException(message);
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                // BUG: the password length is at least 6 characters
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    string message = string.Format("The password must be at least 6 symbols long.");
                    throw new ArgumentException(message);
                }

                var hashedPassword = HashUtilities.HashPassword(value);
                this.password = hashedPassword;
            }
        }

        public Role Role { get; private set; }

        //bottleneck: search in a list is a slow operation
        //public IList<Course> Courses { get; private set; }
        public ISet<Course> Courses { get; private set; }

        public void EnrollInCourse(Course course)
        {
            this.Courses.Add(course);
        }
    }
}
