// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICity.cs" company="">
//   
// </copyright>
// <summary>
//   The City interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    using ClashOfKings.Models;

    /// <summary>
    /// The City interface.
    /// </summary>
    public interface ICity : IUpgradeable, IDowngradeable, IDefendable, ITaxable, IArmyBase, IUpdateable, IRenderable
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the city type.
        /// </summary>
        CityType CityType { get; }

        /// <summary>
        /// Gets or sets the controlling house.
        /// </summary>
        IHouse ControllingHouse { get; set; }
    }
}