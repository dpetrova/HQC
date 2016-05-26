// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContinent.cs" company="">
//   
// </copyright>
// <summary>
//   The Continent interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// The Continent interface.
    /// </summary>
    public interface IContinent : IRenderable, IUpdateable
    {
        /// <summary>
        /// Gets the city neighbors and distances.
        /// </summary>
        Dictionary<ICity, Dictionary<ICity, double>> CityNeighborsAndDistances { get; }

        /// <summary>
        /// Get city by name.
        /// </summary>
        /// <param name="cityName">
        /// The city name.
        /// </param>
        /// <returns>
        /// The city.
        /// </returns>
        ICity GetCityByName(string cityName);

        /// <summary>
        /// Get house by name.
        /// </summary>
        /// <param name="houseName">
        /// The house name.
        /// </param>
        /// <returns>
        /// The house <see cref="IHouse"/>.
        /// </returns>
        IHouse GetHouseByName(string houseName);

        /// <summary>
        /// Add city.
        /// </summary>
        /// <param name="city">
        /// The city.
        /// </param>
        void AddCity(ICity city);

        /// <summary>
        /// Add house.
        /// </summary>
        /// <param name="house">
        /// The house.
        /// </param>
        void AddHouse(IHouse house);

        /// <summary>
        /// Verify the troop movement.
        /// </summary>
        /// <param name="startingCity">
        /// The starting city.
        /// </param>
        /// <param name="destinationCity">
        /// The destination city.
        /// </param>
        void VerifyTroopMovement(ICity startingCity, ICity destinationCity);
    }
}