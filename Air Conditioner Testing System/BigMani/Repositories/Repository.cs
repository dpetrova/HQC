namespace BigMani.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using BigMani.Models;

    public static class Repository
    {
        static Repository()
        {
            AirConditioners = new List<AirConditioner>();
            Reports = new List<Report>();
        }

        internal static List<AirConditioner> AirConditioners { get;  set; }

        public static List<Report> Reports { get;  set; }

        internal static void AddAirConditioner(AirConditioner airConditioner)
        {
            AirConditioners.Add(airConditioner);
        }

        internal static void RemoveAirConditioner(AirConditioner airConditioner)
        {
            AirConditioners.Remove(airConditioner);
        }

        internal static AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            // PERFORMANCE: it was .Where().First
            return AirConditioners.First(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        internal static int GetAirConditionersCount()
        {
            return AirConditioners.Count;
        }

        public static void AddReport(Report report)
        {
            Reports.Add(report);
        }

        public static void RemoveReport(Report report)
        {
            Reports.Remove(report);
        }

        public static Report GetReport(string manufacturer, string model)
        {
            // PERFORMANCE: it was .Where().First
            return Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public static int GetReportsCount()
        {
            return Reports.Count;
        }

        public static List<Report> GetReportsByManufacturer(string manufacturer)
        {
            return Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}
