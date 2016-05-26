namespace ClashOfKings.Models.Commands
{
    using System;
    using System.Linq;

    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]
    public class CreateUnitCommand : Command
    {
        public CreateUnitCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            var numberOfUnits = int.Parse(commandParams[0]);
            var unitName = commandParams[1];
            var cityName = commandParams[2];

            if (numberOfUnits < 0)
            {
                throw new ArgumentOutOfRangeException("numberOfUnits", "Number of units should be non-negative");
            }

            var units = this.Engine.UnitFactory.CreateUnits(unitName, numberOfUnits);
            var city = this.Engine.Continent.GetCityByName(cityName);

            if (city == null)
            {
                throw new ArgumentNullException("city");
            }

            if (city.AvailableUnitCapacity(units.First().Type) < units.Sum(u => u.HousingSpacesRequired))
            {
                throw new InsufficientHousingSpacesException(
                    String.Format("City {0} does not have enough housing spaces to accommodate {1} units of {2}", city.Name, numberOfUnits, unitName));
            }

            var totalTrainingCost = units.Sum(u => u.TrainingCost);

            if (city.ControllingHouse.TreasuryAmount < totalTrainingCost)
            {
                throw new InsufficientFundsException(
                    String.Format("House {0} does not have enough funds to train {1} units of {2}", city.ControllingHouse.Name, numberOfUnits, unitName));
            }

            city.ControllingHouse.TreasuryAmount -= totalTrainingCost;
            city.AddUnits(units);

            this.Engine.Render("Successfully added {0} units of {1} to city {2}", numberOfUnits, unitName, city.Name);
        }
    }
}
