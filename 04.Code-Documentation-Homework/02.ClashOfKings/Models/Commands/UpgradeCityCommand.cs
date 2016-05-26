namespace ClashOfKings.Models.Commands
{
    using System;

    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]
    public class UpgradeCityCommand : Command
    {
        public UpgradeCityCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string cityName = commandParams[0];
            var city = this.Engine.Continent.GetCityByName(cityName);

            if (city == null)
            {
                throw new ArgumentNullException("city");
            }

            city.ControllingHouse.UpgradeCity(city);
            this.Engine.Render(String.Format("City {0} successfully upgraded to {0}", city.Name, city.CityType));
        }
    }
}
