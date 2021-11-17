using System.Collections.Generic;
using System.Linq;

namespace DroneApp.Domain.Entities
{
    /// <summary>
    /// Drone entity class
    /// </summary>
    public class Drone
    {
        public string Name { get; set; }
       
        public float MaxWeightCapacity { get; set; }

        public List<Trip> Trips { get; set; } = new();

        internal bool HasCapacity(int trip, float packageWeight)
        {
            var currentTrip = Trips.FirstOrDefault(t=>t.Number == trip);
            if (currentTrip is null)
            {
                Trips.Add(new Trip()
                {
                    Number = trip,
                });
                currentTrip = Trips.FirstOrDefault(t => t.Number == trip);
            }

            var tripAvailableWeigth = MaxWeightCapacity - currentTrip.GetWeigtht();
            if (tripAvailableWeigth >= packageWeight)
            {
                return true;
            }
            return false;
        }
    }
}
