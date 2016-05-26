// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMilitaryUnit.cs" company="">
//   
// </copyright>
// <summary>
//   The MilitaryUnit interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    using ClashOfKings.Models.Armies;

    /// <summary>
    /// The MilitaryUnit interface.
    /// </summary>
    public interface IMilitaryUnit : IDestroyable, IAttack
    {
        /// <summary>
        /// Gets the training cost.
        /// </summary>
        decimal TrainingCost { get; }

        /// <summary>
        /// Gets the upkeep cost.
        /// </summary>
        double UpkeepCost { get; }

        /// <summary>
        /// Gets the housing spaces required.
        /// </summary>
        int HousingSpacesRequired { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        UnitType Type { get; }
    }
}