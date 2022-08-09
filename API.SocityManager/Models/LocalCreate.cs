namespace API.SocityManager.Models
{
    public class LocalCreate
    {
        public string Name { get; set; }
        public Guid BuildingId { get; set; }
        public int BuildingFloor { get; set; }
        public double Surface { get; set; }
        public bool? HaveAirCo { get; set; }
        public bool? HaveProjector { get; set; }
        public int WorkStationCount { get; set; }
    }
}
