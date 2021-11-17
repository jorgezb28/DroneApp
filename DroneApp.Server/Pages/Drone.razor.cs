using System;
using System.Collections.Generic;
using DroneApp.Service.IServices;
using Microsoft.AspNetCore.Components;
using DroneDomain = DroneApp.Domain.Entities.Drone;

namespace DroneApp.Server.Pages
{
    public partial class Drone
    {
        [Inject]
        public IDroneDeliveryService DroneDeliveryService { get; set; }

        public string Instructions { get; set; }

        private List<DroneDomain> DroneDeliveries { get; set; } = new();

        private string Error = string.Empty;

        private void ProcessDelivery()
        {
            Error = string.Empty;
            DroneDeliveries.Clear();

            try
            {
                DroneDeliveries = DroneDeliveryService.ProcessDeliveries(Instructions);
            }
            catch (Exception exception)
            {
                Error = exception.Message;
            }
        }
    }
}
