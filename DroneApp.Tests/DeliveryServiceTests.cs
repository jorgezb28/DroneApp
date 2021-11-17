using System.Collections.Generic;
using System.Linq;
using System.Text;
using DroneApp.Domain;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;
using DrooneApp.Domain.DomainServices;
using Xunit;

namespace DroneApp.Tests
{
    public class DeliveryServiceTests
    {
        private IDeliveryService _deliveryService;

        public DeliveryServiceTests()
        {
            _deliveryService = new DeliveryService(new InstructionService());
        }

        [Fact]
        public void ShouldGetDeliveriesTripsWhenDroneUnique()
        {
            //Arrange
            var drones = new List<Drone>();
            drones.Add(new Drone() { Name = "D1", MaxWeightCapacity = 50 });

            var locations = new List<Location>();
            locations.Add(new Location() { Name = "L1", PackageWeight = 10 });
            locations.Add(new Location() { Name = "L2", PackageWeight = 5 });
            locations.Add(new Location() { Name = "L3", PackageWeight = 30 });

            //Act
            _deliveryService.GetDeliveriesTrips(drones, locations);

            //Asert
            Assert.Single(drones);
            Assert.Single(drones.First().Trips);
        }

        [Fact]
        public void ShouldGetDeliveriesTripsWhenDroneUniqueWithMultipleTrips()
        {
            //Arrange
            var drones = new List<Drone>();
            drones.Add(new Drone() { Name = "D1", MaxWeightCapacity = 50 });

            var locations = new List<Location>();
            locations.Add(new Location() { Name = "L1", PackageWeight = 10 });
            locations.Add(new Location() { Name = "L2", PackageWeight = 5 });
            locations.Add(new Location() { Name = "L3", PackageWeight = 30 });
            locations.Add(new Location() { Name = "L4", PackageWeight = 20 });
            locations.Add(new Location() { Name = "L5", PackageWeight = 30 });

            //Act
            _deliveryService.GetDeliveriesTrips(drones, locations);

            //Asert
            Assert.Single(drones);
            Assert.Equal(2,drones.First().Trips.Count);
        }

        [Fact]
        public void ShouldGetDeliveriesTripsWithMultipleDronesAndMultipleTrips()
        {
            //Arrange
            var drones = new List<Drone>();
            drones.Add(new Drone() { Name = "D1", MaxWeightCapacity = 25 });
            drones.Add(new Drone() { Name = "D2", MaxWeightCapacity = 50 });

            var locations = new List<Location>();
            locations.Add(new Location() { Name = "L1", PackageWeight = 10 });
            locations.Add(new Location() { Name = "L2", PackageWeight = 15 });
            locations.Add(new Location() { Name = "L3", PackageWeight = 30 });
            locations.Add(new Location() { Name = "L4", PackageWeight = 50 });
            locations.Add(new Location() { Name = "L5", PackageWeight = 5 });
            locations.Add(new Location() { Name = "L6", PackageWeight = 30 });
            locations.Add(new Location() { Name = "L7", PackageWeight = 25 });

            //Act
            _deliveryService.GetDeliveriesTrips(drones, locations);

            //Asert
            Assert.Equal(2,drones.Count);
            Assert.Equal(3, drones[0].Trips.Count);
            Assert.Equal(3, drones[1].Trips.Count);
        }

        [Fact]
        public void ShouldGGetDroneDeliveriesWithInstructionString()
        {
            //Arrange
            var instructions = new StringBuilder();
            instructions.AppendLine("Drone D1,25,Drone D2,50");
            instructions.AppendLine("Location L1,10");
            instructions.AppendLine("Location L2,15");
            instructions.AppendLine("Location L3,30");
            instructions.AppendLine("Location L4,50");
            instructions.AppendLine("Location L5,5");
            instructions.AppendLine("Location L6,30");
            instructions.AppendLine("Location L7,25");

            //Act
            var result = _deliveryService.GetDroneDeliveries(instructions.ToString().TrimEnd());

            //Asert
            Assert.Equal(2, result.Count);
            Assert.Equal(3, result[0].Trips.Count);
            Assert.Equal(3, result[1].Trips.Count);
        }
    }
}
