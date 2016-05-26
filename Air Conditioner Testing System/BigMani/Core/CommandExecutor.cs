namespace BigMani.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BigMani.Exceptions;
    using BigMani.Models;
    using BigMani.Repositories;
    using BigMani.Utilities;

    public class CommandExecutor
    {
        private readonly Engine engine;

        public CommandExecutor(Engine engine)
        {
            this.engine = engine;
        }

        public void Execute()
        {
            var command = this.engine.InputCommand;

            try
            {
                switch (command.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        this.ValidateParametersCount(command, 4);
                        this.engine.UserInterface.WriteLine(this.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            command.Parameters[2],
                            int.Parse(command.Parameters[3])));
                        break;
                    case "RegisterCarAirConditioner":
                        this.ValidateParametersCount(command, 3);
                        this.engine.UserInterface.WriteLine(this.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2])));
                        break;
                    case "RegisterPlaneAirConditioner":
                        this.ValidateParametersCount(command, 4);
                        this.engine.UserInterface.WriteLine(this.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            command.Parameters[3]));
                        break;
                    case "TestAirConditioner":
                        this.ValidateParametersCount(command, 2);
                        this.engine.UserInterface.WriteLine(this.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]));
                        break;
                    case "FindAirConditioner":
                        this.ValidateParametersCount(command, 2);
                        this.engine.UserInterface.WriteLine(this.FindAirConditioner(
                            command.Parameters[1],
                            command.Parameters[0]));
                        break;
                    case "FindReport":
                        this.ValidateParametersCount(command, 2);
                        this.engine.UserInterface.WriteLine(this.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]));
                        break;
                        //BUG: it case was missing
                    case "FindAllReportsByManufacturer":
                        this.ValidateParametersCount(command, 1);
                        this.engine.UserInterface.WriteLine(this.FindAllReportsByManufacturer(
                            command.Parameters[0]));
                        break;
                    case "Status":
                        this.ValidateParametersCount(command, 0);
                        this.engine.UserInterface.WriteLine(this.Status());
                        break;
                    default:
                        throw new InvalidOperationException(Constants.InvalidCommand);
                }
            }

                // BUG: found

            catch (NonExistantEntryException ex)
            {
                this.engine.UserInterface.WriteLine(ex.Message);
            }
            catch (DuplicateEntryException ex)
            {
                this.engine.UserInterface.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                this.engine.UserInterface.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                this.engine.UserInterface.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                this.engine.UserInterface.WriteLine(ex.Message);
            }
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            var stationaryAirConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);


            if (Repository.AirConditioners.Any(a => a.Manufacturer == manufacturer && a.Model == model))
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }

            Repository.AirConditioners.Add(stationaryAirConditioner);

            return string.Format(
                Constants.Register,
                stationaryAirConditioner.Model,
                stationaryAirConditioner.Manufacturer);
        }

        // BUG: found replace places of model and manufacturer
        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            var carAirConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);

            if (Repository.AirConditioners.Any(a => a.Manufacturer == manufacturer && a.Model == model))
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }

            Repository.AirConditioners.Add(carAirConditioner);

            return string.Format(Constants.Register, carAirConditioner.Model, carAirConditioner.Manufacturer);
        }

        /// <summary>
        /// Registers a new plane air conditioner with the specified manufacturer, model, volume covered and electricity used.
        /// </summary>
        /// <param name="manufacturer"> The manufacurer of the air conditioner. </param>
        /// <param name="model"> The model of the air conditioner. </param>
        /// <param name="volumeCoverage"> The volume covered by the air conditioner. </param>
        /// <param name="electricityUsed"> The used electricity of the air conditioner. </param>
        /// <returns>
        /// Returns a success message if the plane air conditioner has been registered successfully. If case of error, returns an error message.
        /// </returns>
        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            var planeAirConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);

            if (Repository.AirConditioners.Any(a => a.Manufacturer == manufacturer && a.Model == model))
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }
            
            Repository.AirConditioners.Add(planeAirConditioner);

            return string.Format(Constants.Register, planeAirConditioner.Model, planeAirConditioner.Manufacturer);
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = Repository.GetAirConditioner(manufacturer, model);
            if (airConditioner == null)
            {
                throw new NonExistantEntryException(string.Format(Constants.NonExist));
            }

            // WTFC???
            //airConditioner.energyRating += 5;
            var mark = airConditioner.Test();

            var report = new Report(airConditioner.Manufacturer, airConditioner.Model, mark);

            if (Repository.Reports.Any(r => r.Manufacturer == manufacturer && r.Model == model))
            {
                throw new DuplicateEntryException("An entry for the given model already exists.");
            }

            Repository.Reports.Add(report);

            return string.Format(Constants.Test, model, manufacturer);

            // throw new InvalidOperationException(string.Format(Constants.Test, model, manufacturer));
        }

        /// <summary>
        /// Find air conditioner by given manufacturer and model.
        /// </summary>
        /// <param name="manufacturer"> The manufacurer of the air conditioner. </param>
        /// <param name="model"> The model of the air conditioner. </param>
        /// <returns>
        /// If found, returns a success message with the found air conditioners. If case there are not, returns an NonExistantEntryException.
        /// </returns>
        public string FindAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = Repository.GetAirConditioner(manufacturer, model);
            if (airConditioner == null)
            {
                throw new NonExistantEntryException(string.Format(Constants.NonExist));
            }

            return airConditioner.ToString();
        }

        public string FindReport(string manufacturer, string model)
        {
            Report report = Repository.GetReport(manufacturer, model);

            // BUG: it was InvalidOperationException(report.ToString())
            if (report == null)
            {
                throw new NonExistantEntryException(string.Format(Constants.NonExist));
            }

            return report.ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<Report> reports = Repository.GetReportsByManufacturer(manufacturer);

            if (reports.Count == 0)
            {
                return Constants.NoReports;
            }

            // BUG: it was OrderBy(x => x.Mark)
            reports = reports
                .OrderBy(x => x.Model)
                .ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }

        /// <summary>
        /// Prints a message displaying the status of the system.
        /// </summary>
        /// <returns>
        /// A message displaying the status of the system (percentage of air conditioners tested).
        /// </returns>
        public string Status()
        {
            int reports = Repository.GetReportsCount();
            double airConditioners = Repository.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Constants.Status, percent);
        }

        public void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }
        }
    }
}
