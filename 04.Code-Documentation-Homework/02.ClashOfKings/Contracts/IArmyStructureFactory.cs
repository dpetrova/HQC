// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IArmyStructureFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The ArmyStructureFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The ArmyStructureFactory interface.
    /// </summary>
    public interface IArmyStructureFactory
    {
        /// <summary>
        /// Create a structure.
        /// </summary>
        /// <param name="structureName">
        /// The structure name.
        /// </param>
        /// <returns>
        /// The army structure.
        /// </returns>
        IArmyStructure CreateStructure(string structureName);
    }
}