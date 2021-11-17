using System.Collections.Generic;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;
using DroneApp.Service.IServices;

namespace DroneApp.Service.Services
{
    public class DroneDeliveryService: IDroneDeliveryService
    {
        private readonly IDeliveryService _deliveryService;

        public DroneDeliveryService(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        /// <inheritdoc/>
        public List<Drone> ProcessDeliveries(string instrunctions)
        {
            var droneDeliveries = _deliveryService.GetDroneDeliveries(instrunctions);
            return droneDeliveries;
        }
    }
}
