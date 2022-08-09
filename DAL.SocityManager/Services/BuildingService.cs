using Common.SocityManager.Repositories;
using DAL.SocityManager.Entities;
using DAL.SocityManager.Handlers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Connections;

namespace DAL.SocityManager.Services
{
    public class BuildingService : ServiceBase, IBuildingRepository<Building>
    {
        public BuildingService(IConfiguration config) : base(config)
        {
        }

        public void Delete(Guid id)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_Building_Delete",true);
            command.AddParameter("id", id);
            connection.ExecuteNonQuery(command);
        }

        public Building Get(Guid id)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SELECT * FROM [Building] WHERE [Id] = @id");
            command.AddParameter("id", id);
            return connection.ExecuteReader<Building>(command, Mapper.ToBuilding).SingleOrDefault();
        }

        public IEnumerable<Building> Get()
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SELECT * FROM [Building]");
            return connection.ExecuteReader<Building>(command, Mapper.ToBuilding);
        }

        public Building GetByLocal(Guid localId)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SELECT * FROM [Building] WHERE [Id] = (SELECT [BuildingId] FROM [Local] WHERE [Id] = @id)");
            command.AddParameter("id", localId);
            return connection.ExecuteReader<Building>(command, Mapper.ToBuilding).SingleOrDefault();
        }

        public Guid Insert(Building entity)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_Building_Insert", true);
            command.AddParameter("name", entity.Name);
            command.AddParameter("number", entity.Number);
            command.AddParameter("street", entity.Street);
            command.AddParameter("city", entity.City);
            command.AddParameter("zipCode", entity.ZipCode);
            command.AddParameter("floorCount", entity.FloorCount);
            command.AddParameter("parkingCount", entity.ParkingCount);
            return (Guid)connection.ExecuteScalar(command);
        }

        public void Update(Guid id, Building entity)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_Building_Update", true);
            command.AddParameter("id", id);
            command.AddParameter("name", entity.Name);
            command.AddParameter("number", entity.Number);
            command.AddParameter("street", entity.Street);
            command.AddParameter("city", entity.City);
            command.AddParameter("zipCode", entity.ZipCode);
            command.AddParameter("floorCount", entity.FloorCount);
            command.AddParameter("parkingCount", entity.ParkingCount);
            connection.ExecuteNonQuery(command);
        }
    }
}
