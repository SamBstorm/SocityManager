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
    public class LocalService : ServiceBase, ILocalRepository<Local>
    {
        public LocalService(IConfiguration config) : base(config)
        {
        }

        public void Delete(Guid id)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_Local_Delete",true);
            command.AddParameter("id", id);
            connection.ExecuteNonQuery(command);
        }

        public Local Get(Guid id)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SELECT * FROM [Local] WHERE [Id] = @id");
            command.AddParameter("id", id);
            return connection.ExecuteReader<Local>(command, Mapper.ToLocal).SingleOrDefault();
        }

        public IEnumerable<Local> Get()
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SELECT * FROM [Local]");
            return connection.ExecuteReader<Local>(command, Mapper.ToLocal);
        }

        public IEnumerable<Local> GetByBuilding(Guid buildingId)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SELECT * FROM [Local] WHERE [BuildingId] = @id");
            command.AddParameter("id", buildingId);
            return connection.ExecuteReader<Local>(command, Mapper.ToLocal);
        }

        public Guid Insert(Local entity)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_Local_Insert", true);
            command.AddParameter("name", entity.Name);
            command.AddParameter("buildingId", entity.BuildingId);
            command.AddParameter("buildingFloor", entity.BuildingFloor);
            command.AddParameter("surface", entity.Surface);
            command.AddParameter("haveAirCo", entity.HaveAirCo);
            command.AddParameter("haveProjector", entity.HaveProjector);
            command.AddParameter("workStationCount", entity.WorkStationCount);
            return (Guid)connection.ExecuteScalar(command);
        }

        public void Update(Guid id, Local entity)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_Local_Update", true);
            command.AddParameter("id", id);
            command.AddParameter("name", entity.Name);
            command.AddParameter("buildingId", entity.BuildingId);
            command.AddParameter("buildingFloor", entity.BuildingFloor);
            command.AddParameter("surface", entity.Surface);
            command.AddParameter("haveAirCo", entity.HaveAirCo);
            command.AddParameter("haveProjector", entity.HaveProjector);
            command.AddParameter("workStationCount", entity.WorkStationCount);
            connection.ExecuteNonQuery(command);
        }
    }
}
