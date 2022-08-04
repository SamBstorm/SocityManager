using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SocityManager.Entities
{
    public class Building
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int FloorCount { get; set; }
        public int ParkingCount { get; set; }
    }
}
