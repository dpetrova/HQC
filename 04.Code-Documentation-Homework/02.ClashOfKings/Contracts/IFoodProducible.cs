// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFoodProducible.cs" company="">
//   
// </copyright>
// <summary>
//   The FoodProducible interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The FoodProducible interface.
    /// </summary>
    public interface IFoodProducible
    {
        /// <summary>
        /// Gets or sets the food production.
        /// </summary>
        double FoodProduction { get; set; }

        /// <summary>
        /// Gets or sets the food storage.
        /// </summary>
        double FoodStorage { get; set; }
    }
}