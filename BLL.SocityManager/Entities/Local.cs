using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SocityManager.Entities
{
    public class Local
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Building Building { get; set; }
        public int BuildingFloor { get; set; }
        public double Surface { get; set; }
        public bool? HaveAirCo { get; set; }
        public bool? HaveProjector { get; set; }
        public int WorkStationCount { get; set; }
    }
}
