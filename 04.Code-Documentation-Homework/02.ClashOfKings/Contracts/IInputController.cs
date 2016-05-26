// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInputController.cs" company="">
//   
// </copyright>
// <summary>
//   The InputController interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The InputController interface.
    /// </summary>
    public interface IInputController
    {
        /// <summary>
        /// Read the input.
        /// </summary>
        /// <returns>
        /// The input string.
        /// </returns>
        string ReadInput();
    }
}