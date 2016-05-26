namespace BigMani.Interfaces
{
    /// <summary>
    /// Provides the members of the Report interface.
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <value>
        /// The manufacturer.
        /// </value>
        string Manufacturer { get; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        string Model { get; }

        /// <summary>
        /// Gets the mark.
        /// </summary>
        /// <value>
        /// The mark.
        /// </value>
        int Mark { get; }
    }
}