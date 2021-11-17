namespace DroneApp.Domain.Entities
{
    /// <summary>
    /// Location entity with needed information for drone's deliveries
    /// </summary>
    public class Location
    {
        public string Name { get; set; }

        public float PackageWeight { get; set; }
    }
}
