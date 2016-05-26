// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGameEngine.cs" company="">
//   
// </copyright>
// <summary>
//   The GameEngine interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The GameEngine interface.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Gets the unit factory.
        /// </summary>
        IUnitFactory UnitFactory { get; }

        /// <summary>
        /// Gets the army structure factory.
        /// </summary>
        IArmyStructureFactory ArmyStructureFactory { get; }

        /// <summary>
        /// Gets the command factory.
        /// </summary>
        ICommandFactory CommandFactory { get; }

        /// <summary>
        /// Gets the continent.
        /// </summary>
        IContinent Continent { get; }

        /// <summary>
        /// The run method.
        /// </summary>
        void Run();

        /// <summary>
        /// Execute command.
        /// </summary>
        /// <param name="commandInput">
        /// The command input.
        /// </param>
        void ExecuteCommand(string commandInput);

        /// <summary>
        /// The render method.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        void Render(string message, params object[] parameters);
    }
}