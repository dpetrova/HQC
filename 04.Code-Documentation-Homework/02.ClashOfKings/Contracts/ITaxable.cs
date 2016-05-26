// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaxable.cs" company="">
//   
// </copyright>
// <summary>
//   The Taxable interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The Taxable interface.
    /// </summary>
    public interface ITaxable
    {
        /// <summary>
        /// Gets or sets the tax base.
        /// </summary>
        decimal TaxBase { get; set; }
    }
}