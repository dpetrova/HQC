// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IArmyBase.cs" company="">
//   
// </copyright>
// <summary>
//   The ArmyBase interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    using System.Collections.Generic;

    using ClashOfKings.Models.Armies;

    /// <summary>
    /// The ArmyBase interface.
    /// </summary>
    public interface IArmyBase : IFoodProducible
    {
        /// <summary>
        /// Gets the available military units.
        /// </summary>
        IEnumerable<IMilitaryUnit> AvailableMilitaryUnits { get; }

        /// <summary>
        /// Gets the available units by type.
        /// </summary>
        Dictionary<UnitType, int> AvailableUnitsByType { get; }

        /// <summary>
        /// Gets the army structures.
        /// </summary>
        IEnumerable<IArmyStructure> ArmyStructures { get; }

        /// <summary>
        /// The available unit capacity.
        /// </summary>
        /// <param name="type">
        /// The unit type.
        /// </param>
        /// <returns>
        /// The unit capacity.
        /// </returns>
        int AvailableUnitCapacity(UnitType type);

        /// <summary>
        /// Add units.
        /// </summary>
        /// <param name="units">
        /// ICollection of units.
        /// </param>
        void AddUnits(ICollection<IMilitaryUnit> units);

        /// <summary>
        /// Remove units.
        /// </summary>
        /// <returns>
        /// ICollection of units.
        /// </returns>
        ICollection<IMilitaryUnit> RemoveUnits();

        /// <summary>
        /// Add army structure.
        /// </summary>
        /// <param name="structure">
        /// Army Structure.
        /// </param>
        void AddArmyStructure(IArmyStructure structure);
    }
}