using API.SocityManager.Models;
using BLL.SocityManager.Entities;

namespace API.SocityManager.Handlers
{
    public static class Mapper
    {
        public static Building ToBuilding(this BuildingInsert entity)
        {
            if (entity == null) return null;
            return new Building()
            {
                Name = entity.Name,
                Number = entity.Number,
                Street = entity.Street,
                City = entity.City,
                ZipCode = entity.ZipCode,
                FloorCount = entity.FloorCount,
                ParkingCount = entity.ParkingCount
            };
        }
        public static Building ToBuilding(this BuildingUpdate entity)
        {
            if (entity == null) return null;
            return new Building()
            {
                Name = entity.Name,
                Number = entity.Number,
                Street = entity.Street,
                City = entity.City,
                ZipCode = entity.ZipCode,
                FloorCount = entity.FloorCount,
                ParkingCount = entity.ParkingCount
            };
        }

        public static Local ToLocal(this LocalCreate entity)
        {
            if (entity == null) return null;
            return new Local()
            {
                Name = entity.Name,
                Surface = entity.Surface,
                WorkStationCount = entity.WorkStationCount,
                BuildingFloor = entity.BuildingFloor,
                HaveAirCo = entity.HaveAirCo,
                HaveProjector = entity.HaveProjector,
                Building = new Building() { Id = entity.BuildingId}
            };
        }
    }
}
