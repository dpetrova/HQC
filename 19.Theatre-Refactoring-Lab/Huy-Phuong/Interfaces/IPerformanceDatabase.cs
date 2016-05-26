// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPerformanceDatabase.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Huy_Phuong.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Huy_Phuong.Models;

    /// <summary>
    /// The IPerformanceDatabase interface.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Add theatres.
        /// </summary>
        /// <param name="theatreName">
        /// Theatre name
        /// </param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Gets the available theatres.
        /// </summary>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Add performances.
        /// </summary>
        /// <param name="theatreName">
        /// Theatre name
        /// </param>
        /// <param name="performanceTitle">
        /// Performance title
        /// </param>
        /// <param name="startDateTime">
        /// Date and time of the beginning of the performance.
        /// </param>
        /// <param name="duration">
        /// Duration of the performance.
        /// </param>
        /// <param name="price">
        /// Price of the performance.
        /// </param>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Gets all available performances.
        /// </summary>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Gets all available performances per certain theater.
        /// </summary>
        /// <param name="theatreName">
        /// Theatre name
        /// </param>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}