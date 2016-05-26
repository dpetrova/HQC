namespace Event
{
    using System;
    using System.Text;

    internal class Event : IComparable
    {
        private readonly DateTime date;

        private readonly string location;

        private readonly string title;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            var other = obj as Event;
            var eventsByDate = this.date.CompareTo(other.date);
            var eventsByTitle = this.title.CompareTo(other.title);
            var eventsByLocation = this.location.CompareTo(other.location);

            if (eventsByDate == 0)
            {
                if (eventsByTitle == 0)
                {
                    return eventsByLocation;
                }

                return eventsByTitle;
            }

            return eventsByDate;
        }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);
            if (!string.IsNullOrEmpty(this.location))
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}