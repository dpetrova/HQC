// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandFactory.cs" company="">
//   
// </copyright>
// <summary>
//   The CommandFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The CommandFactory interface.
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Create command.
        /// </summary>
        /// <param name="commandName">
        /// The command name.
        /// </param>
        /// <param name="engine">
        /// The engine.
        /// </param>
        /// <returns>
        /// The command.
        /// </returns>
        ICommand CreateCommand(string commandName, IGameEngine engine);
    }
}