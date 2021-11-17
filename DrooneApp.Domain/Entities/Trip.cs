using System.Collections.Generic;
using System.Linq;

namespace DroneApp.Domain.Entities
{
    /// <summary>
    /// Trip entity class
    /// </summary>
    public class Trip
    {
        public int Number { get; set; }

        public List<Location> Locations { get; set; } = new();

        internal float GetWeigtht()
        {
            return Locations.Sum(l => l.PackageWeight);
        }
    }
}
