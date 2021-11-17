using System;
using System.Collections.Generic;
using System.Linq;
using DroneApp.Domain;
using DroneApp.Domain.Common;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;

namespace DrooneApp.Domain.DomainServices
{
    public class DeliveryService: IDeliveryService
    {
        private readonly IInstructionService _instructionService;

        public DeliveryService(IInstructionService instructionService)
        {
            _instructionService = instructionService;
        }

        /// <inheritdoc/>
        public List<Drone> GetDroneDeliveries(string instrunctions)
        {
            var drones = new List<Drone>();
            var locations = new List<Location>();

            var instructionsArrays = instrunctions.Split('\n');

            for (int i = 0; i < instructionsArrays.Length; i++)
            {
                var instruction = _instructionService.ParseInstruction(instructionsArrays[i]);
                if (instruction is IntructionDrone droneInstruction)
                {
                    drones.AddRange(droneInstruction.Drones);
                }
                else if (instruction is InstructionLocation locationInstruction)
                {
                    locations.AddRange(locationInstruction.Locations);
                }
                else
                {
                    throw new Exception(StringConstants.InvalidInstruction);
                }
            }

            GetDeliveriesTrips(drones, locations);

            return drones;
        }

        /// <inheritdoc/>
        public void GetDeliveriesTrips(List<Drone> drones, List<Location> locations)
        {
            var locationsStack = new Stack<Location>(locations.OrderBy(l => l.PackageWeight));
            
            while (locationsStack.Count > 0)
            {
                var location = locationsStack.Pop();

                if (!HaveDronesCapacityForPackage(drones, location.PackageWeight))
                {
                    throw new Exception(StringConstants.PackageTooBig);
                }

                var trip = GetDroneTripWithCapacity(drones, location.PackageWeight);

                foreach (var drone in drones)
                {
                    if (drone.HasCapacity(trip, location.PackageWeight))
                    {
                        var droneTrip = drone.Trips.FirstOrDefault(t => t.Number == trip);
                        droneTrip.Locations.Add(location);
                        break;
                    }
                }
            }
        }

        public bool HaveDronesCapacityForPackage(List<Drone> drones, float packageWeight)
        {
            var haveCapacity = false;
            foreach (var drone in drones)
            {
                if (packageWeight > drone.MaxWeightCapacity)
                {
                    haveCapacity = false;
                    continue;
                }
                else {
                    haveCapacity = true;
                    break;
                }
            }
            return haveCapacity;
        }

        public int GetDroneTripWithCapacity(List<Drone> drones, float packageWeight)
        {
            var maxTrip = 0;
            foreach (var drone in drones)
            {
                foreach (var droneTrip in drone.Trips)
                {
                    maxTrip = droneTrip.Number;
                    if (drone.HasCapacity(droneTrip.Number, packageWeight))
                    {
                        return droneTrip.Number;
                    }
                }
                
            }
            return ++maxTrip;
        }

    }
}
