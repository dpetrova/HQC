// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaxCollector.cs" company="">
//   
// </copyright>
// <summary>
//   The TaxCollector interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The TaxCollector interface.
    /// </summary>
    public interface ITaxCollector
    {
        /// <summary>
        /// Gets or sets the treasury amount.
        /// </summary>
        decimal TreasuryAmount { get; set; }
    }
}