namespace VehiclePark.Interfaces
{
    using System;
     
    /// <summary>
    /// Provides the basic operations required to run a vehicle park.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Inserts a car in the vehicle park.
        /// </summary>
        /// <param name="vehicle"> The vehicle to insert in the park. </param>
        /// <param name="sector"> The sector where the car should be parked. </param>
        /// <param name="place"> The number of the place within the sector where the car should be parked. </param>
        /// <param name="time"> The time of parking. </param>
        /// <returns>
        /// Returns a success message if the car has been parked successfully. If the requested parking space (sector, place, or both)
        /// is invalid or occupied, or there is already a vehicle with the same license plate number in the park, returns an error message.
        /// </returns>
        string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime time);

        /// <summary>
        /// Performs all operations required when a vehicle leaves the park. 
        /// Removes the vehicle from the park and prints a parking ticket for the owner.
        /// </summary>
        /// <param name="licencePlate"> The license plate of the vehicle. </param>
        /// <param name="endTime"> The time of leaving. </param>
        /// <param name="paid"> The amount paid by the customer. </param>
        /// <returns>
        /// Returns the issued parking ticket in a ready to print form.
        /// If there is no vehicle with the specified license plate number in the park, returns an error message.
        /// </returns>
        string ExitVehicle(string licencePlate, DateTime endTime, decimal paid);

        /// <summary>
        /// Displays the current status of the vehicle park - how many parking slots are full in each of the parking sectors.
        /// </summary>
        /// <returns>
        /// Returns a message displaying the number of free spaces (and the full percentage) in the park.
        /// </returns>
        string GetStatus();

        /// <summary>
        /// Finds the vehicle with the specified license plate number in the vehicle park.
        /// </summary>
        /// <param name="licencePlate"> The license plate number of the vehicle to find. </param>
        /// <returns>
        /// Returns information about the vehicle and its parking place.
        /// If there is no vehicle with the specified license plate in the park, returns an error message.
        /// </returns>
        string FindVehicle(string licencePlate);

        /// <summary>
        /// Finds all vehicles in the park which belong to the specified owner.
        /// </summary>
        /// <param name="owner"> The owner of the vehicles to find. </param>
        /// <returns>
        /// Returns information about each vehicle by the owner, ordered by arrival time and by license plate number.
        /// If there are no vehicles by the owner, returns an error message.
        /// </returns>
        string FindVehiclesByOwner(string owner);
    }
}