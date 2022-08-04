using DAL.SocityManager.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.SocityManager.Handlers
{
    public static class Mapper
    {
        public static User ToUser(IDataRecord record)
        {
            if (record == null) return null;
            return new User()
            {
                Id = (Guid)record[nameof(User.Id)],
                Email = (string)record[nameof(User.Email)],
                Password = (string)record[nameof(User.Password)]
            };
        }
        public static Building ToBuilding(IDataRecord record)
        {
            if (record == null) return null;
            return new Building()
            {
                Id = (Guid)record[nameof(Building.Id)],
                Name = (string)record[nameof(Building.Name)],
                Number = (string)record[nameof(Building.Number)],
                Street = (string)record[nameof(Building.Street)],
                City = (string)record[nameof(Building.City)],
                ZipCode = (string)record[nameof(Building.ZipCode)],
                FloorCount = (int)record[nameof(Building.FloorCount)],
                ParkingCount = (int)record[nameof(Building.ParkingCount)]
            };
        }
        public static Local ToLocal(IDataRecord record)
        {
            if (record == null) return null;
            return new Local()
            {
                Id = (Guid)record[nameof(Local.Id)],
                Name = (string)record[nameof(Local.Name)],
                BuildingId = (Guid)record[nameof(Local.BuildingId)],
                BuildingFloor = (int)record[nameof(Local.BuildingFloor)],
                Surface = (double)record[nameof(Local.Surface)],
                HaveAirCo = (record[nameof(Local.HaveAirCo)] is DBNull) ?null:(bool?)record[nameof(Local.HaveAirCo)],
                HaveProjector = (record[nameof(Local.HaveProjector)] is DBNull) ? null : (bool?)record[nameof(Local.HaveProjector)],
                WorkStationCount = (int)record[nameof(Local.WorkStationCount)]
            };
        }
    }
}
