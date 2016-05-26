// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IArmyStructure.cs" company="">
//   
// </copyright>
// <summary>
//   The ArmyStructure interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    using ClashOfKings.Models;
    using ClashOfKings.Models.Armies;

    /// <summary>
    /// The ArmyStructure interface.
    /// </summary>
    public interface IArmyStructure
    {
        /// <summary>
        /// Gets the required city type.
        /// </summary>
        CityType RequiredCityType { get; }

        /// <summary>
        /// Gets the build cost.
        /// </summary>
        decimal BuildCost { get; }

        /// <summary>
        /// Gets the capacity.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Gets the unit type.
        /// </summary>
        UnitType UnitType { get; }
    }
}