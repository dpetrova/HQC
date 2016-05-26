// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHouse.cs" company="">
//   
// </copyright>
// <summary>
//   The House interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The House interface.
    /// </summary>
    public interface IHouse : ITaxCollector, ICityController, IUpdateable, IRenderable
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }
    }
}