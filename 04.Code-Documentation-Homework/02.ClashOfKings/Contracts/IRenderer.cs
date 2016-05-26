// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderer.cs" company="">
//   
// </copyright>
// <summary>
//   The Renderer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ClashOfKings.Contracts
{
    /// <summary>
    /// The Renderer interface.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// The print.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        void Print(string message, params object[] parameters);
    }
}