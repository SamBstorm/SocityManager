using System;
using System.Collections.Generic;
using System.Text;
using D = DAL.SocityManager.Entities;
using B = BLL.SocityManager.Entities;

namespace BLL.SocityManager.Handlers
{
    public static class Mapper
    {
        public static D.Local ToDAL(this B.Local entity)
        {
            if (entity == null) return null;
            return new D.Local()
            {
                Id = entity.Id,
                Name = entity.Name,
                BuildingFloor = entity.BuildingFloor,
                BuildingId = entity.Building.Id,
                Surface = entity.Surface,
                HaveAirCo = entity.HaveAirCo,
                HaveProjector = entity.HaveProjector,
                WorkStationCount = entity.WorkStationCount
            };
        }
        public static B.Local ToBLL(this D.Local entity)
        {
            if (entity == null) return null;
            return new B.Local()
            {
                Id = entity.Id,
                Name = entity.Name,
                BuildingFloor = entity.BuildingFloor,
                Surface = entity.Surface,
                HaveAirCo = entity.HaveAirCo,
                HaveProjector = entity.HaveProjector,
                WorkStationCount = entity.WorkStationCount
            };
        }
        public static D.Building ToDAL(this B.Building entity)
        {
            if (entity == null) return null;
            return new D.Building()
            {
                Id = entity.Id,
                Name = entity.Name,
                Number = entity.Number,
                Street = entity.Street,
                City = entity.City,
                ZipCode = entity.ZipCode,
                FloorCount = entity.FloorCount,
                ParkingCount = entity.ParkingCount
            };
        }
        public static B.Building ToBLL(this D.Building entity)
        {
            if (entity == null) return null;
            return new B.Building()
            {
                Id = entity.Id,
                Name = entity.Name,
                Number = entity.Number,
                Street = entity.Street,
                City = entity.City,
                ZipCode = entity.ZipCode,
                FloorCount = entity.FloorCount,
                ParkingCount = entity.ParkingCount,
                Locals = new List<B.Local>()
            };
        }
        public static D.User ToDAL(this B.User entity)
        {
            if (entity == null) return null;
            return new D.User()
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password
            };
        }
        public static B.User ToBLL(this D.User entity)
        {
            if (entity == null) return null;
            return new B.User()
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password
            };
        }
    }
}
