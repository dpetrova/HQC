// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommand.cs" company="">
//   
// </copyright>
// <summary>
//   The Command interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The Command interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the engine.
        /// </summary>
        IGameEngine Engine { get; }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="commandParams">
        /// The command params.
        /// </param>
        void Execute(params string[] commandParams);
    }
}