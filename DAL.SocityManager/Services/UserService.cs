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
    public class UserService : ServiceBase,IUserRepository<User>
    {
        public UserService(IConfiguration config) : base(config)
        {
        }

        public User CheckPassword(string email, string password)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_User_Check", true);
            command.AddParameter("email", email);
            command.AddParameter("password", password);
            return connection.ExecuteReader<User>(command, Mapper.ToUser).SingleOrDefault();
        }

        public void Delete(Guid id)
        {

            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_User_Delete", true);
            command.AddParameter("id", id);
            connection.ExecuteNonQuery(command);
        }

        public User Get(Guid id)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SELECT [Id], [Email] , '*******' AS [Password] FROM User WHERE [Id]=@id");
            command.AddParameter("id", id);
            return connection.ExecuteReader<User>(command, Mapper.ToUser).SingleOrDefault();
        }

        public Guid Insert(User entity)
        {
            Connection connection = new Connection(InvariantName, ConnectionString);
            Command command = new Command("SP_User_Insert", true);
            command.AddParameter("email", entity.Email);
            command.AddParameter("password", entity.Password);
            return (Guid)connection.ExecuteScalar(command);
        }
    }
}
