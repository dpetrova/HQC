// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICityController.cs" company="">
//   
// </copyright>
// <summary>
//   The CityController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// The CityController interface.
    /// </summary>
    public interface ICityController
    {
        /// <summary>
        /// Gets the controlled cities.
        /// </summary>
        IEnumerable<ICity> ControlledCities { get; }

        /// <summary>
        /// Add city to house.
        /// </summary>
        /// <param name="city">
        /// The city.
        /// </param>
        void AddCityToHouse(ICity city);

        /// <summary>
        /// Remove city from house.
        /// </summary>
        /// <param name="city">
        /// The city.
        /// </param>
        void RemoveCityFromHouse(string city);

        /// <summary>
        /// Upgrade city.
        /// </summary>
        /// <param name="city">
        /// The city.
        /// </param>
        void UpgradeCity(ICity city);
    }
}