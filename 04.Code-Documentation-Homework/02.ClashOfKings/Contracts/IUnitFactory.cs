// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The UnitFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// The UnitFactory interface.
    /// </summary>
    public interface IUnitFactory
    {
        /// <summary>
        /// Create units.
        /// </summary>
        /// <param name="unitType">
        /// The unit type.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// ICollection of MilitaryUnit.
        /// </returns>
        ICollection<IMilitaryUnit> CreateUnits(string unitType, int count);
    }
}