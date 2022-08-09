using BLL.SocityManager.Entities;
using BLL.SocityManager.Handlers;
using Common.SocityManager.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SocityManager.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly IUserRepository<DAL.SocityManager.Entities.User> _repo;

        public UserService(IUserRepository<DAL.SocityManager.Entities.User> repo)
        {
            this._repo = repo;
        }
        public User CheckPassword(string email, string password)
        {
            return _repo.CheckPassword(email, password).ToBLL();
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public User Get(Guid id)
        {
            return _repo.Get(id).ToBLL();
        }

        public Guid Insert(User entity)
        {
            return _repo.Insert(entity.ToDAL());
        }
    }
}
