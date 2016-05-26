namespace Huy_Phuong.Models
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatre, string name, DateTime startDate, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.Name = name;
            this.StartDate = startDate;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theatre { get; private set; }

        public string Name { get; private set; }

        public DateTime StartDate { get; private set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; protected set; }


        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int recent = this.StartDate.CompareTo(otherPerformance.StartDate);
            return recent;
        }


        public override string ToString()
        {
            string result = string.Format("({0}, {1}, {2})", this.Name, this.Theatre, this.StartDate.ToString("dd.MM.yyyy HH:mm"));

            return result;
        }
    }
}
