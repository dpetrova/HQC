namespace Huy_Phuong.Models
{
    using System;
    using System.Collections.Generic;

    using Huy_Phuong.Exceptions;
    using Huy_Phuong.Interfaces;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> performances =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.performances.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.performances[theatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.performances.Keys;

            if (theatres == null || theatres.Count == 0)
            {
                throw new NullReferenceException("No theatres");
            }

            return theatres;
        }

        public void AddPerformance(
            string theatreName, 
            string performanceTitle, 
            DateTime startDateTime, 
            TimeSpan duration, 
            decimal price)
        {
            if (!this.performances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performancesPerTheatre = this.performances[theatreName];

            var endDateTime = startDateTime + duration;

            if (IsOverlapping(performancesPerTheatre, startDateTime, endDateTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var newPerformance = new Performance(theatreName, performanceTitle, startDateTime, duration, price);

            performancesPerTheatre.Add(newPerformance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.performances.Keys;
            var allPerformances = new List<Performance>();

            foreach (var theatre in theatres)
            {
                var performancesPerTheatre = this.performances[theatre];
                allPerformances.AddRange(performancesPerTheatre);
            }

            if (allPerformances == null || allPerformances.Count == 0)
            {
                throw new NullReferenceException("No performances");
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.performances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performancesPerTheatre = this.performances[theatreName];

            if (performancesPerTheatre == null || performancesPerTheatre.Count == 0)
            {
                throw new NullReferenceException("No performances");
            }

            return performancesPerTheatre;
        }

        private static bool IsOverlapping(
            IEnumerable<Performance> performances, 
            DateTime startDateTime, 
            DateTime endDateTime)
        {
            foreach (var performance in performances)
            {
                var start = performance.StartDate;
                var end = performance.StartDate + performance.Duration;

                var isOverlap = (start <= startDateTime && startDateTime <= end)
                                || (start <= endDateTime && endDateTime <= end)
                                || (startDateTime <= start && start <= endDateTime)
                                || (startDateTime <= end && end <= endDateTime);

                if (isOverlap)
                {
                    return true;
                }
            }

            return false;
        }
    }
}