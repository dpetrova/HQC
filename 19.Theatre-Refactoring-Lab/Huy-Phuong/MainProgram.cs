namespace Huy_Phuong
{
    using System;
    using System.Globalization;
    using System.Linq;

    using Huy_Phuong.Interfaces;
    using Huy_Phuong.Models;

    internal partial class MainProgram
    {
        public static readonly IPerformanceDatabase Database = new PerformanceDatabase();

        protected static void Main()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == null)
                {
                    return;
                }

                if (input != string.Empty)
                {
                    var tokens = input.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    var command = tokens[0];
                    var parameters = tokens.Skip(1).Select(p => p.Trim()).ToArray();
                    string message;

                    try
                    {
                        switch (command)
                        {
                            case "AddTheatre":
                                var theatreName = parameters[0];
                                Database.AddTheatre(theatreName);
                                message = "Theatre added";
                                break;
                            case "PrintAllTheatres":
                                var theatres = Database.ListTheatres().ToList();
                                message = string.Join(", ", theatres);
                                break;
                            case "AddPerformance":
                                theatreName = parameters[0];
                                var performanceTitle = parameters[1];
                                var startDateTime = DateTime.ParseExact(
                                    parameters[2], 
                                    "dd.MM.yyyy HH:mm", 
                                    CultureInfo.InvariantCulture);
                                var duration = TimeSpan.Parse(parameters[3]);
                                var price = decimal.Parse(parameters[4], NumberStyles.Float);
                                Database.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                                message = "Performance added";
                                break;
                            case "PrintAllPerformances":
                                var performances = Database.ListAllPerformances().ToList();
                                message = string.Join(", ", performances);
                                break;
                            case "PrintPerformances":
                                theatreName = parameters[0];
                                var performancesPerTheatre = Database.ListPerformances(theatreName).ToList();
                                message = string.Join(", ", performancesPerTheatre);
                                break;
                            default:
                                message = "Invalid command!";
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        message = "Error: " + ex.Message;
                    }

                    Console.WriteLine(message);
                }
            }
        }
    }
}