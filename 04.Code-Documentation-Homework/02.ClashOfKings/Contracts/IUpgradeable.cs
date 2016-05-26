// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpgradeable.cs" company="">
//   
// </copyright>
// <summary>
//   The Upgradeable interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The Upgradeable interface.
    /// </summary>
    public interface IUpgradeable
    {
        /// <summary>
        /// Gets the upgrade cost.
        /// </summary>
        decimal UpgradeCost { get; }

        /// <summary>
        /// The upgrade.
        /// </summary>
        void Upgrade();
    }
}