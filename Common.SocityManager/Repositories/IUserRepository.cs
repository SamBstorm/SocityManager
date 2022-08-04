using System;
using System.Collections.Generic;
using System.Text;

namespace Common.SocityManager.Repositories
{
    public interface IUserRepository<TUser>
    {
        TUser Get(Guid id);
        TUser CheckPassword(string email, string password);
        void Delete(Guid id);
        Guid Insert(TUser entity);
    }
}
