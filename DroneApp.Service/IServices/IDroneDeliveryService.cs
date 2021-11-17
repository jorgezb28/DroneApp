using System.Collections.Generic;
using DroneApp.Domain.Entities;

namespace DroneApp.Service.IServices
{
    public interface IDroneDeliveryService
    {
        /// <summary>
        /// Get drone deliveires based on instructions string
        /// </summary>
        /// <param name="instrunctions">Instructions String</param>
        /// <returns>List of drones with its respectives trips</returns>
        List<Drone> ProcessDeliveries(string instrunctions);
    }
}
